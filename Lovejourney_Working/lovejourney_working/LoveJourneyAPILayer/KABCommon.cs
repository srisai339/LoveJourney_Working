using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using BAL;
using System.IO;
using BusAPILayer.TicketGooseNamespace;

namespace BusAPILayer
{
    public class KABCommon
    {
        IBitlaAPILayer objBitlaAPILayer;
        IKesineniAPILayer objKesineniAPILayer;
        IAbhiBusAPILayer objAbhiBusAPILayer;
        IKalladaAPILayer objKalladaAPILayer;
        ITicketGooseAPILayer objTicketGooseAPILayer;

        public KABCommon(KesineniDetails kesineniDetails, AbhiBusDetails abhiBusDetails, BitlaDetails bitlaDetails)
        {
            try
            {
                objBitlaAPILayer = BitlaFactoryManager.GetBitlaAPILayerObject();
                objBitlaAPILayer.ApiKey = bitlaDetails.ApiKey;
                objBitlaAPILayer.URL = bitlaDetails.Url;

                objKesineniAPILayer = KesineniFactoryManager.GetKesineniAPILayerObject();
                objKesineniAPILayer.LoginId = kesineniDetails.LoginId;
                objKesineniAPILayer.Password = kesineniDetails.PassWord;

                objAbhiBusAPILayer = AbhiBusFactoryManager.GetAbhiBusAPILayerObject();

                objKalladaAPILayer = KalladaFactoryManager.GetKalladaAPILayerObject();

                objTicketGooseAPILayer = TicketGooseFactoryManager.GetTicketGooseAPILayerObject();
                objTicketGooseAPILayer.UserId = "ssdtech";
                objTicketGooseAPILayer.Password = "123456";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetSources()
        {
            try
            {
                DataSet dsBitlaCities = objBitlaAPILayer.GetCities();

                DataTable dtCombineSources = new DataTable();
                dtCombineSources.TableName = "Sources";
                dtCombineSources.Columns.Add("SourceName");
                dtCombineSources.Columns.Add("AllIds");
                dtCombineSources.Columns.Add("BitlaId");
                dtCombineSources.Columns.Add("KesineniId");
                dtCombineSources.Columns.Add("AbhiBusId");
                dtCombineSources.Columns.Add("KalladaId");
                dtCombineSources.Columns.Add("TicketGooseId");

                #region Bitla
                foreach (DataRow item in dsBitlaCities.Tables[0].Rows)
                {
                    DataRow dr = dtCombineSources.NewRow();
                    string sName = item["name"].ToString();
                    dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                    dr["AllIds"] = "Bit-" + item["id"].ToString();
                    dr["BitlaId"] = item["id"].ToString();
                    dr["KesineniId"] = "";
                    dr["AbhiBusId"] = "";
                    dr["KalladaId"] = "";
                    dr["TicketGooseId"] = "";
                    dtCombineSources.Rows.Add(dr);
                }
                #endregion

                #region Kesineni
                DataSet dsKesineniSources = objKesineniAPILayer.GetSourceStations();
                if (dsKesineniSources != null)
                {
                    if (dsKesineniSources.Tables[0].Columns.Count > 1)
                    {
                        foreach (DataRow item in dsKesineniSources.Tables[0].Rows)
                        {
                            DataRow[] drExist = dtCombineSources.Select("SourceName ='" + item["SourceStationName"].ToString().ToUpper() + "'");
                            if (drExist.Length == 0)
                            {
                                DataRow dr = dtCombineSources.NewRow();
                                string sName = item["SourceStationName"].ToString();
                                dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                                dr["AllIds"] = "Kes-" + item["SourceStationID"].ToString();
                                dr["BitlaId"] = "";
                                dr["KesineniId"] = item["SourceStationID"].ToString();
                                dr["AbhiBusId"] = "";
                                dr["KalladaId"] = "";
                                dr["TicketGooseId"] = "";
                                dtCombineSources.Rows.Add(dr);
                            }
                            else
                            {
                                foreach (DataRow drRow in drExist)
                                {
                                    DataRow dr = dtCombineSources.NewRow();
                                    string sName = item["SourceStationName"].ToString();
                                    dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                                    dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kes-" + item["SourceStationID"].ToString();
                                    dr["BitlaId"] = drRow["BitlaId"].ToString();
                                    dr["KesineniId"] = item["SourceStationID"].ToString();
                                    dr["AbhiBusId"] = "";
                                    dr["KalladaId"] = "";
                                    dr["TicketGooseId"] = "";
                                    dtCombineSources.Rows.Remove(drRow);
                                    dtCombineSources.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region AbhiBus
                DataTable dtAbhiBus = objAbhiBusAPILayer.GetSources();
                foreach (DataRow item in dtAbhiBus.Rows)
                {
                    DataRow[] drExist = dtCombineSources.Select("SourceName ='" + item["Source"].ToString().ToUpper() + "'");
                    if (drExist.Length == 0)
                    {
                        DataRow dr = dtCombineSources.NewRow();
                        string sName = item["Source"].ToString().ToUpper();
                        dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                        dr["AllIds"] = "Abh-" + item["SourceId"].ToString();
                        dr["BitlaId"] = "";
                        dr["KesineniId"] = "";
                        dr["AbhiBusId"] = item["SourceId"].ToString();
                        dr["KalladaId"] = "";
                        dr["TicketGooseId"] = "";
                        dtCombineSources.Rows.Add(dr);
                    }
                    else
                    {
                        foreach (DataRow drRow in drExist)
                        {
                            DataRow dr = dtCombineSources.NewRow();
                            string sName = item["Source"].ToString().ToUpper();
                            dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                            if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() != "")
                            {
                                dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kes-" + drRow["KesineniId"].ToString() + ":" + "Abh-" + item["SourceId"].ToString();
                            }
                            else if (drRow["BitlaId"].ToString() == "" && drRow["KesineniId"].ToString() != "")
                            {
                                dr["AllIds"] = "Kes-" + drRow["KesineniId"].ToString() + ":" + "Abh-" + item["SourceId"].ToString();
                            }
                            else if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() == "")
                            {
                                dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Abh-" + item["SourceId"].ToString();
                            }
                            dr["BitlaId"] = drRow["BitlaId"].ToString();
                            dr["KesineniId"] = drRow["KesineniId"].ToString();
                            dr["AbhiBusId"] = item["SourceId"].ToString();
                            dr["KalladaId"] = "";
                            dr["TicketGooseId"] = "";
                            dtCombineSources.Rows.Remove(drRow);
                            dtCombineSources.Rows.Add(dr);
                        }
                    }
                }
                #endregion

                #region Kallada
                DataTable dtKallada = objKalladaAPILayer.GetSources();
                foreach (DataRow row in dtKallada.Rows)
                {
                    DataRow[] drExist = dtCombineSources.Select("SourceName ='" + row["Source"].ToString().ToUpper() + "'");
                    if (drExist.Length == 0)
                    {
                        DataRow dr = dtCombineSources.NewRow();
                        string sName = row["Source"].ToString().ToUpper();
                        dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                        dr["AllIds"] = "Kal-" + row["SourceId"].ToString();
                        dr["BitlaId"] = "";
                        dr["KesineniId"] = "";
                        dr["AbhiBusId"] = "";
                        dr["KalladaId"] = row["SourceId"].ToString();
                        dr["TicketGooseId"] = "";
                        dtCombineSources.Rows.Add(dr);
                    }
                    else
                    {
                        foreach (DataRow drRow in drExist)
                        {
                            DataRow dr = dtCombineSources.NewRow();
                            string sName = row["Source"].ToString().ToUpper();
                            dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();

                            if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() != "" && drRow["AbhiBusId"].ToString() != "")
                            {
                                dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kes-" + drRow["KesineniId"].ToString() + ":"
                                    + "Abh-" + drRow["AbhiBusId"].ToString() + ":" + "Kal-" + row["SourceId"].ToString();
                            }
                            else if (drRow["BitlaId"].ToString() == "" && drRow["KesineniId"].ToString() != "" && drRow["AbhiBusId"].ToString() != "")
                            {
                                dr["AllIds"] = "Kes-" + drRow["KesineniId"].ToString() + ":" + "Abh-" + drRow["AbhiBusId"].ToString()
                                    + ":" + "Kal-" + row["SourceId"].ToString();
                            }
                            else if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() == "" && drRow["AbhiBusId"].ToString() != "")
                            {
                                dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Abh-" + drRow["AbhiBusId"].ToString()
                                    + ":" + "Kal-" + row["SourceId"].ToString();
                            }
                            else if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() != "" && drRow["AbhiBusId"].ToString() == "")
                            {
                                dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kes-" + drRow["KesineniId"].ToString()
                                    + ":" + "Kal-" + row["SourceId"].ToString();
                            }
                            else if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() == "" && drRow["AbhiBusId"].ToString() == "")
                            {
                                dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kal-" + row["SourceId"].ToString();
                            }
                            else if (drRow["BitlaId"].ToString() == "" && drRow["KesineniId"].ToString() != "" && drRow["AbhiBusId"].ToString() == "")
                            {
                                dr["AllIds"] = "Kes-" + drRow["KesineniId"].ToString() + ":" + "Kal-" + row["SourceId"].ToString();
                            }
                            else if (drRow["BitlaId"].ToString() == "" && drRow["KesineniId"].ToString() == "" && drRow["AbhiBusId"].ToString() != "")
                            {
                                dr["AllIds"] = "Abh-" + drRow["AbhiBusId"].ToString() + ":" + "Kal-" + row["SourceId"].ToString();
                            }

                            dr["BitlaId"] = drRow["BitlaId"].ToString();
                            dr["KesineniId"] = drRow["KesineniId"].ToString();
                            dr["AbhiBusId"] = drRow["AbhiBusId"].ToString();
                            dr["KalladaId"] = row["SourceId"].ToString();
                            dr["TicketGooseId"] = "";
                            dtCombineSources.Rows.Remove(drRow);
                            dtCombineSources.Rows.Add(dr);
                        }
                    }
                }
                #endregion

                #region TicketGoose
                DataTable dtTicketGoose = objTicketGooseAPILayer.GetStationList();
                if (dtTicketGoose != null)
                {
                    foreach (DataRow item in dtTicketGoose.Rows)
                    {
                        DataRow[] drExist = dtCombineSources.Select("SourceName ='" + item["stationName"].ToString().ToUpper() + "'");
                        if (drExist.Length == 0)
                        {
                            DataRow dr = dtCombineSources.NewRow();
                            string sName = item["stationName"].ToString().ToUpper();
                            dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                            dr["AllIds"] = "Tig-" + item["stationId"].ToString();
                            dr["BitlaId"] = "";
                            dr["KesineniId"] = "";
                            dr["AbhiBusId"] = "";
                            dr["KalladaId"] = "";
                            dr["TicketGooseId"] = item["stationId"].ToString();
                            dtCombineSources.Rows.Add(dr);
                        }
                        else
                        {
                            foreach (DataRow drRow in drExist)
                            {
                                DataRow dr = dtCombineSources.NewRow();
                                string sName = item["stationName"].ToString().ToUpper();
                                dr["SourceName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();

                                dr["AllIds"] = drRow["AllIds"].ToString() + ":" + "Tig-" + item["stationId"].ToString();

                                dr["BitlaId"] = drRow["BitlaId"].ToString();
                                dr["KesineniId"] = drRow["KesineniId"].ToString();
                                dr["AbhiBusId"] = drRow["AbhiBusId"].ToString();
                                dr["KalladaId"] = drRow["KalladaId"].ToString();
                                dr["TicketGooseId"] = item["stationId"].ToString();
                                dtCombineSources.Rows.Remove(drRow);
                                dtCombineSources.Rows.Add(dr);
                            }
                        }
                    }
                }
                #endregion

                DataView view = dtCombineSources.DefaultView;
                view.Sort = "SourceName ASC";
                return dtCombineSources;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetDestinations(string sourceIds)
        {
            try
            {
                DataTable dtCombineDestinations = new DataTable();
                dtCombineDestinations.TableName = "Destinations";
                dtCombineDestinations.Columns.Add("DestinationName");
                dtCombineDestinations.Columns.Add("AllIds");
                dtCombineDestinations.Columns.Add("BitlaId");
                dtCombineDestinations.Columns.Add("KesineniId");
                dtCombineDestinations.Columns.Add("AbhiBusId");
                dtCombineDestinations.Columns.Add("KalladaId");
                dtCombineDestinations.Columns.Add("TicketGooseId");

                string[] sourcesArray1 = sourceIds.Split(':');
                foreach (string str1 in sourcesArray1)
                {
                    string[] sourcesArray2 = str1.Split('-');

                    if (sourcesArray2[0].ToString() == "Bit")
                    {
                        DataTable dt = objBitlaAPILayer.GetDestinations(sourcesArray2[1].ToString());
                        if (dt != null)
                        {
                            foreach (DataRow item1 in dt.Rows)
                            {
                                DataRow dr = dtCombineDestinations.NewRow();
                                string sName = item1["DestinationName"].ToString().ToUpper();
                                dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                                dr["AllIds"] = "Bit-" + item1["DestinationId"].ToString();
                                dr["BitlaId"] = item1["DestinationId"].ToString();
                                dr["KesineniId"] = "";
                                dr["AbhiBusId"] = "";
                                dr["KalladaId"] = "";
                                dr["TicketGooseId"] = "";
                                dtCombineDestinations.Rows.Add(dr);
                            }
                        }
                    }
                    //if (sourcesArray2[0].ToString() == "Kes")
                    //{
                    //    DataTable dt = objKesineniAPILayer.GetDestinationStations(Convert.ToInt32(sourcesArray2[1].ToString())).Tables[0];
                    //    foreach (DataRow item2 in dt.Rows)
                    //    {
                    //        DataRow[] drExist = dtCombineDestinations.Select("DestinationName ='" + item2["DestinationStationName"].ToString().ToUpper() + "'");
                    //        if (drExist.Length == 0)
                    //        {
                    //            DataRow dr = dtCombineDestinations.NewRow();
                    //            string sName = item2["DestinationStationName"].ToString().ToUpper();
                    //            dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                    //            dr["AllIds"] = "Kes-" + item2["DestinationStationID"].ToString();
                    //            dr["BitlaId"] = "";
                    //            dr["KesineniId"] = item2["DestinationStationID"].ToString();
                    //            dr["AbhiBusId"] = "";
                    //            dr["KalladaId"] = "";
                    //            dr["TicketGooseId"] = "";
                    //            dtCombineDestinations.Rows.Add(dr);
                    //        }
                    //        else
                    //        {
                    //            foreach (DataRow drRow in drExist)
                    //            {
                    //                DataRow dr = dtCombineDestinations.NewRow();
                    //                string sName = item2["DestinationStationName"].ToString().ToUpper();
                    //                dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                    //                dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kes-" + item2["DestinationStationID"].ToString();
                    //                dr["BitlaId"] = drRow["BitlaId"].ToString();
                    //                dr["KesineniId"] = item2["DestinationStationID"].ToString();
                    //                dr["AbhiBusId"] = "";
                    //                dr["KalladaId"] = "";
                    //                dr["TicketGooseId"] = "";
                    //                dtCombineDestinations.Rows.Remove(drRow);
                    //                dtCombineDestinations.Rows.Add(dr);
                    //            }
                    //        }
                    //    }
                    //}
                    if (sourcesArray2[0].ToString() == "Abh")
                    {
                        DataTable dt = objAbhiBusAPILayer.GetDestinations(sourcesArray2[1].ToString());
                        foreach (DataRow item2 in dt.Rows)
                        {
                            DataRow[] drExist = dtCombineDestinations.Select("DestinationName ='" + item2["Destination"].ToString().ToUpper() + "'");
                            if (drExist.Length == 0)
                            {
                                DataRow dr = dtCombineDestinations.NewRow();
                                string sName = item2["Destination"].ToString().ToUpper();
                                dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                                dr["AllIds"] = "Abh-" + item2["DestinationId"].ToString();
                                dr["BitlaId"] = "";
                                dr["KesineniId"] = "";
                                dr["AbhiBusId"] = item2["DestinationId"].ToString();
                                dr["KalladaId"] = "";
                                dr["TicketGooseId"] = "";
                                dtCombineDestinations.Rows.Add(dr);
                            }
                            else
                            {
                                foreach (DataRow drRow in drExist)
                                {
                                    DataRow dr = dtCombineDestinations.NewRow();
                                    string sName = item2["Destination"].ToString().ToUpper();
                                    dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                                    if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() != "")
                                    {
                                        dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kes-" + drRow["KesineniId"].ToString() + ":" + "Abh-" + item2["DestinationId"].ToString();
                                    }
                                    else if (drRow["BitlaId"].ToString() == "" && drRow["KesineniId"].ToString() != "")
                                    {
                                        dr["AllIds"] = "Kes-" + drRow["KesineniId"].ToString() + ":" + "Abh-" + item2["DestinationId"].ToString();
                                    }
                                    else if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() == "")
                                    {
                                        dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Abh-" + item2["DestinationId"].ToString();
                                    }
                                    dr["BitlaId"] = drRow["BitlaId"].ToString();
                                    dr["KesineniId"] = drRow["KesineniId"].ToString();
                                    dr["AbhiBusId"] = item2["DestinationId"].ToString();
                                    dr["KalladaId"] = "";
                                    dr["TicketGooseId"] = "";
                                    dtCombineDestinations.Rows.Remove(drRow);
                                    dtCombineDestinations.Rows.Add(dr);
                                }
                            }
                        }
                    }
                    if (sourcesArray2[0].ToString() == "Kal")
                    {
                        DataTable dt = objKalladaAPILayer.GetDestinations(sourcesArray2[1].ToString());
                        foreach (DataRow item2 in dt.Rows)
                        {
                            DataRow[] drExist = dtCombineDestinations.Select("DestinationName ='" + item2["Destination"].ToString().ToUpper() + "'");
                            if (drExist.Length == 0)
                            {
                                DataRow dr = dtCombineDestinations.NewRow();
                                string sName = item2["Destination"].ToString().ToUpper();
                                dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                                dr["AllIds"] = "Kal-" + item2["DestinationId"].ToString();
                                dr["BitlaId"] = "";
                                dr["KesineniId"] = "";
                                dr["AbhiBusId"] = "";
                                dr["TicketGooseId"] = "";
                                dr["KalladaId"] = item2["DestinationId"].ToString();
                                dtCombineDestinations.Rows.Add(dr);
                            }
                            else
                            {
                                foreach (DataRow drRow in drExist)
                                {
                                    DataRow dr = dtCombineDestinations.NewRow();
                                    string sName = item2["Destination"].ToString().ToUpper();
                                    dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();

                                    if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() != "" && drRow["AbhiBusId"].ToString() != "")
                                    {
                                        dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kes-" + drRow["KesineniId"].ToString() + ":"
                                            + "Abh-" + drRow["AbhiBusId"].ToString() + ":" + "Kal-" + item2["DestinationId"].ToString();
                                    }
                                    else if (drRow["BitlaId"].ToString() == "" && drRow["KesineniId"].ToString() != "" && drRow["AbhiBusId"].ToString() != "")
                                    {
                                        dr["AllIds"] = "Kes-" + drRow["KesineniId"].ToString() + ":" + "Abh-" + drRow["AbhiBusId"].ToString()
                                            + ":" + "Kal-" + item2["DestinationId"].ToString();
                                    }
                                    else if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() == "" && drRow["AbhiBusId"].ToString() != "")
                                    {
                                        dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Abh-" + drRow["AbhiBusId"].ToString()
                                            + ":" + "Kal-" + item2["DestinationId"].ToString();
                                    }
                                    else if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() != "" && drRow["AbhiBusId"].ToString() == "")
                                    {
                                        dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kes-" + drRow["KesineniId"].ToString()
                                            + ":" + "Kal-" + item2["DestinationId"].ToString();
                                    }
                                    else if (drRow["BitlaId"].ToString() != "" && drRow["KesineniId"].ToString() == "" && drRow["AbhiBusId"].ToString() == "")
                                    {
                                        dr["AllIds"] = "Bit-" + drRow["BitlaId"].ToString() + ":" + "Kal-" + item2["DestinationId"].ToString();
                                    }
                                    else if (drRow["BitlaId"].ToString() == "" && drRow["KesineniId"].ToString() != "" && drRow["AbhiBusId"].ToString() == "")
                                    {
                                        dr["AllIds"] = "Kes-" + drRow["KesineniId"].ToString() + ":" + "Kal-" + item2["DestinationId"].ToString();
                                    }
                                    else if (drRow["BitlaId"].ToString() == "" && drRow["KesineniId"].ToString() == "" && drRow["AbhiBusId"].ToString() != "")
                                    {
                                        dr["AllIds"] = "Abh-" + drRow["AbhiBusId"].ToString() + ":" + "Kal-" + item2["DestinationId"].ToString();
                                    }

                                    dr["BitlaId"] = drRow["BitlaId"].ToString();
                                    dr["KesineniId"] = drRow["KesineniId"].ToString();
                                    dr["AbhiBusId"] = drRow["AbhiBusId"].ToString();
                                    dr["KalladaId"] = item2["DestinationId"].ToString();
                                    dr["TicketGooseId"] = "";
                                    dtCombineDestinations.Rows.Remove(drRow);
                                    dtCombineDestinations.Rows.Add(dr);
                                }
                            }
                        }
                    }
                    if (sourcesArray2[0].ToString() == "Tig")
                    {
                        DataTable dt = objTicketGooseAPILayer.GetDestinations(sourcesArray2[1].ToString());
                        foreach (DataRow item2 in dt.Rows)
                        {
                            DataRow[] drExist = dtCombineDestinations.Select("DestinationName ='" + item2["stationName"].ToString().ToUpper() + "'");
                            if (drExist.Length == 0)
                            {
                                DataRow dr = dtCombineDestinations.NewRow();
                                string sName = item2["stationName"].ToString().ToUpper();
                                dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();
                                dr["AllIds"] = "Tig-" + item2["stationId"].ToString();
                                dr["BitlaId"] = "";
                                dr["KesineniId"] = "";
                                dr["AbhiBusId"] = "";
                                dr["TicketGooseId"] = item2["stationId"].ToString();
                                dr["KalladaId"] = "";
                                dtCombineDestinations.Rows.Add(dr);
                            }
                            else
                            {
                                foreach (DataRow drRow in drExist)
                                {
                                    DataRow dr = dtCombineDestinations.NewRow();
                                    string sName = item2["stationName"].ToString().ToUpper();
                                    dr["DestinationName"] = char.ToUpper(sName[0]) + sName.Substring(1).ToLower();

                                    dr["AllIds"] = drRow["AllIds"].ToString() + ":" + "Tig-" + item2["stationId"].ToString();

                                    dr["BitlaId"] = drRow["BitlaId"].ToString();
                                    dr["KesineniId"] = drRow["KesineniId"].ToString();
                                    dr["AbhiBusId"] = drRow["AbhiBusId"].ToString();
                                    dr["KalladaId"] = drRow["KalladaId"].ToString();
                                    dr["TicketGooseId"] = item2["stationId"].ToString();
                                    dtCombineDestinations.Rows.Remove(drRow);
                                    dtCombineDestinations.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
                DataView view = dtCombineDestinations.DefaultView;
                view.Sort = "DestinationName ASC";
                return dtCombineDestinations;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRoutes(string sourceIds, string destinationIds, string journeyDate)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(journeyDate);
                journeyDate = dt.ToString("yyyy-MM-dd");

                int sNo = 1;

                #region RoutesDataTableStructure

                DataTable dtRoutes = new DataTable();
                dtRoutes.Columns.Add("API", typeof(System.String));
                dtRoutes.Columns.Add("Travels", typeof(System.String));
                dtRoutes.Columns.Add("BusType", typeof(System.String));
                dtRoutes.Columns.Add("BusTypeShort", typeof(System.String));
                dtRoutes.Columns.Add("DepTime", typeof(System.String));
                dtRoutes.Columns.Add("DepTimeInMins", System.Type.GetType("System.Int32"));
                dtRoutes.Columns.Add("ArrTime", typeof(System.String));
                dtRoutes.Columns.Add("ArrTimeInMins", System.Type.GetType("System.Int32"));
                dtRoutes.Columns.Add("Duration", typeof(System.String));
                dtRoutes.Columns.Add("Fare", System.Type.GetType("System.Decimal"));
                dtRoutes.Columns.Add("AvailableSeats", typeof(System.Int32));
                dtRoutes.Columns.Add("ReservationId", typeof(System.String));
                dtRoutes.Columns.Add("ServiceId", typeof(System.String));
                dtRoutes.Columns.Add("CoachTypeId", typeof(System.String));
                dtRoutes.Columns.Add("SourceId", typeof(System.String));
                dtRoutes.Columns.Add("DestinationId", typeof(System.String));
                dtRoutes.Columns.Add("SourceName", typeof(System.String));
                dtRoutes.Columns.Add("DestinationName", typeof(System.String));
                dtRoutes.Columns.Add("JourneyDate");
                dtRoutes.Columns.Add("BoardingPoints", typeof(System.String));
                DataColumn dc = new DataColumn();
                dc.ColumnName = "DropingPoints";
                dc.DataType = typeof(System.String);
                dtRoutes.Columns.Add(dc);
                dtRoutes.Columns.Add("BoardingPointsWithIds", typeof(System.String));
                dtRoutes.Columns.Add("DropingPointsWithIds", typeof(System.String));
                dtRoutes.Columns.Add("lblS", typeof(System.String));
                dtRoutes.Columns.Add("lblB", typeof(System.String));
                dtRoutes.Columns.Add("SNo", System.Type.GetType("System.Int32"));
                dtRoutes.Columns.Add("ServiceNumber", typeof(System.String));

                #endregion

                #region Source&DestinationIDs

                string[] sourcesArray1 = sourceIds.Split(':');
                string[] destinationsArray1 = destinationIds.Split(':');

                int[] bitlaSourceId = null;
                int[] bitlaDestinationId = null;

                int[] abhiBusSourceId = null;
                int[] abhiBusDestinationId = null;

                int[] ticketGooseSourceId = null;
                int[] ticketGooseDestinationId = null;

                foreach (string item in sourcesArray1)
                {
                    string[] sourcesArray2 = item.Split('-');

                    if (sourcesArray2[0].ToString() == "Bit")
                    {
                        bitlaSourceId = new int[sourcesArray2[1].ToString().Split(',').Length];

                        for (int i = 0; i < bitlaSourceId.Length; i++)
                        {
                            bitlaSourceId[i] = Convert.ToInt32(sourcesArray2[1].ToString().Split(',')[i].ToString());
                        }
                    }

                    if (sourcesArray2[0].ToString() == "Abh")
                    {
                        abhiBusSourceId = new int[sourcesArray2[1].ToString().Split(',').Length];

                        for (int i = 0; i < abhiBusSourceId.Length; i++)
                        {
                            abhiBusSourceId[i] = Convert.ToInt32(sourcesArray2[1].ToString().Split(',')[i].ToString());
                        }
                    }

                    if (sourcesArray2[0].ToString() == "Tig")
                    {
                        ticketGooseSourceId = new int[sourcesArray2[1].ToString().Split(',').Length];

                        for (int i = 0; i < ticketGooseSourceId.Length; i++)
                        {
                            ticketGooseSourceId[i] = Convert.ToInt32(sourcesArray2[1].ToString().Split(',')[i].ToString());
                        }
                    }

                }

                foreach (string item1 in destinationsArray1)
                {
                    string[] destinationsArray2 = item1.Split('-');
                    if (destinationsArray2[0].ToString() == "Bit")
                    {
                        bitlaDestinationId = new int[destinationsArray2[1].ToString().Split(',').Length];
                        for (int i = 0; i < bitlaDestinationId.Length; i++)
                        {
                            bitlaDestinationId[i] = Convert.ToInt32(destinationsArray2[1].ToString().Split(',')[i].ToString());
                        }
                    }

                    if (destinationsArray2[0].ToString() == "Abh")
                    {
                        abhiBusDestinationId = new int[destinationsArray2[1].ToString().Split(',').Length];
                        for (int i = 0; i < abhiBusDestinationId.Length; i++)
                        {
                            abhiBusDestinationId[i] = Convert.ToInt32(destinationsArray2[1].ToString().Split(',')[i].ToString());
                        }
                    }

                    if (destinationsArray2[0].ToString() == "Tig")
                    {
                        ticketGooseDestinationId = new int[destinationsArray2[1].ToString().Split(',').Length];
                        for (int i = 0; i < ticketGooseDestinationId.Length; i++)
                        {
                            ticketGooseDestinationId[i] = Convert.ToInt32(destinationsArray2[1].ToString().Split(',')[i].ToString());
                        }
                    }
                }

                #endregion

                #region Bitla
                DataSet dsBitlaAllAvailableRoutes = null;

                if (bitlaSourceId != null && bitlaDestinationId != null)
                {

                    foreach (int itemSourceId in bitlaSourceId)
                    {
                        foreach (int itemDestinationId in bitlaDestinationId)
                        {
                            DataRow[] drArrayOfBitla = null;

                            if (itemSourceId != 0 && itemDestinationId != 0)
                            {
                                string filePath = "";
                                filePath = System.Web.HttpContext.Current.Server.MapPath("~/Routes/" + journeyDate + ".xml").ToString();
                                if (File.Exists(filePath))
                                {
                                    dsBitlaAllAvailableRoutes = new DataSet();
                                    dsBitlaAllAvailableRoutes.ReadXml(filePath);
                                    int count = dsBitlaAllAvailableRoutes.Tables[0].Rows.Count;
                                    if (dsBitlaAllAvailableRoutes.Tables.Count >= 1)
                                    {
                                        drArrayOfBitla = dsBitlaAllAvailableRoutes.Tables[0].Select("origin_id = '" + Convert.ToString(itemSourceId)
                                            + "' AND destination_id = '" + Convert.ToString(itemDestinationId) + "'");
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        objBitlaAPILayer.Date = journeyDate;
                                        DataSet dsBitlaAllAvailableRoutes1 = null;
                                        dsBitlaAllAvailableRoutes1 = objBitlaAPILayer.GetAllAvailableRoutes();
                                        dsBitlaAllAvailableRoutes1.WriteXml(System.Web.HttpContext.Current.Server.MapPath("~/Routes/" + journeyDate + ".xml"));

                                        dsBitlaAllAvailableRoutes = new DataSet();
                                        dsBitlaAllAvailableRoutes.ReadXml(filePath);
                                        int count = dsBitlaAllAvailableRoutes.Tables[0].Rows.Count;
                                        if (dsBitlaAllAvailableRoutes.Tables.Count >= 1)
                                        {
                                            drArrayOfBitla = dsBitlaAllAvailableRoutes.Tables[0].Select("origin_id = '" + Convert.ToString(itemSourceId)
                                                + "' AND destination_id = '" + Convert.ToString(itemDestinationId) + "'");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Mailsender.SendErrorEmail("prasad@lovejourney.in;sunil@lovejourney.in;", "",
                                            "", "Bitla API Is Not Working // LoveJourney.in", ex.Message + ex.Source + ex.InnerException + ex.StackTrace);

                                        dsBitlaAllAvailableRoutes = null;
                                    }
                                }
                            }
                            if (dsBitlaAllAvailableRoutes != null)
                            {
                                if (dsBitlaAllAvailableRoutes.Tables.Count >= 1)
                                {
                                    {
                                        foreach (DataRow drArrayBit in drArrayOfBitla)
                                        {
                                            DataRow dr = dtRoutes.NewRow();
                                            dr["API"] = "Bit";
                                            dr["Travels"] = drArrayBit["travels"].ToString();
                                            dr["JourneyDate"] = journeyDate;
                                            dr["BusTypeShort"] = BusTypeString(drArrayBit["bus_type"].ToString());
                                            dr["BusType"] = drArrayBit["bus_type"].ToString();
                                            dr["ServiceNumber"] = "";

                                            #region DepTime And DepTimeInMins
                                            dr["DepTime"] = drArrayBit["dep_time"].ToString();
                                            if (drArrayBit["dep_time"].ToString() != "")
                                            {
                                                dr["DepTimeInMins"] = TimeInMins(drArrayBit["dep_time"].ToString());
                                            }
                                            #endregion

                                            #region Duration
                                            dr["Duration"] = drArrayBit["duration"].ToString() + " hrs";
                                            #endregion

                                            #region ArrTime And MinutesOfArrTimeAndDepTime
                                            string strDepTime = drArrayBit["dep_time"].ToString();
                                            string[] strDepTimeArray = strDepTime.Split(':');
                                            int hours = Convert.ToInt32(strDepTimeArray[0].ToString());
                                            int mins = (hours * 60) + Convert.ToInt32(strDepTimeArray[1].ToString().Substring(0, 2));
                                            string amorpm = Convert.ToString(strDepTimeArray[1].ToString().Substring(2, 2)).ToLower().ToString();

                                            string strDuration = drArrayBit["duration"].ToString();
                                            string[] strDurationArray = strDuration.Split(':');
                                            int hours1 = Convert.ToInt32(strDurationArray[0].ToString());
                                            int mins1 = (hours1 * 60) + Convert.ToInt32(strDurationArray[1].ToString().Substring(0));

                                            string total = "";

                                            int arrtimemins = 0;

                                            if (amorpm.Contains("p"))
                                            {
                                                total = Convert.ToString(mins + mins1 + 720);
                                                arrtimemins = mins + mins1 + 720;
                                            }
                                            else { total = Convert.ToString(mins + mins1); arrtimemins = mins + mins1; }

                                            dr["ArrTime"] = Time(total);
                                            if (dr["ArrTime"].ToString() != "")
                                            {
                                                dr["ArrTimeInMins"] = TimeInMins(dr["ArrTime"].ToString());
                                            }
                                            #endregion

                                            #region Fare
                                            decimal max = 0;
                                            string[] strFare = drArrayBit["fare_str"].ToString().Split(',');
                                            max = Convert.ToDecimal(strFare[0].ToString());
                                            foreach (var item in strFare)
                                            {
                                                decimal dec = Convert.ToDecimal(item.ToString());
                                                if (dec > max)
                                                {
                                                    max = dec;
                                                }
                                            }
                                            dr["Fare"] = max;
                                            #endregion

                                            dr["ReservationId"] = drArrayBit["reservation_id"].ToString();
                                            objBitlaAPILayer.ReservationId = drArrayBit["reservation_id"].ToString();
                                            DataSet ddd = null;
                                            try
                                            {
                                                ddd = objBitlaAPILayer.GetServiceDetails();
                                            }
                                            catch (Exception ex)
                                            {
                                                Mailsender.SendMail("prasad@lovejourney.in", "", "", "GetRoutesError - Bitla - GetServiceDetails", ex.Message + ex.Source + ex.InnerException + ex.StackTrace);
                                                ddd = null;
                                            }

                                            dr["AvailableSeats"] = drArrayBit["available_seats"].ToString();
                                            dr["ServiceId"] = "";
                                            dr["CoachTypeId"] = "";
                                            dr["SourceId"] = itemSourceId;
                                            dr["DestinationId"] = itemDestinationId;
                                            dr["SourceName"] = drArrayBit["origin"].ToString();
                                            dr["DestinationName"] = drArrayBit["destination"].ToString();
                                            dr["lblS"] = drArrayBit["reservation_id"].ToString();
                                            dr["lblB"] = "Bit;" + drArrayBit["reservation_id"].ToString() + ";" +
                                                Convert.ToString(itemSourceId) + ";" + Convert.ToString(itemDestinationId);
                                            dr["SNo"] = sNo;
                                            string bp = "";

                                            dr["BoardingPoints"] = bp;
                                            dr["DropingPoints"] = "";
                                            dr["BoardingPointsWithIds"] = "";
                                            dr["DropingPointsWithIds"] = "";

                                            if (ddd != null)
                                            {
                                                if (ddd.Tables.Count > 0)
                                                {
                                                    if (ddd.Tables[0].Rows.Count != 0)
                                                    {
                                                        if (ddd.Tables[0].Columns.Contains("available_seats"))
                                                        {
                                                            dr["AvailableSeats"] = ddd.Tables[0].Rows[0]["available_seats"].ToString();
                                                        }
                                                        if (ddd.Tables[0].Columns.Contains("cost"))
                                                        {
                                                            decimal max1 = 0;
                                                            string[] strFare1 = ddd.Tables[0].Rows[0]["cost"].ToString().Split(',');
                                                            max1 = Convert.ToDecimal(strFare1[0].ToString());
                                                            foreach (var item in strFare1)
                                                            {
                                                                decimal dec1 = Convert.ToDecimal(item.ToString());
                                                                if (dec1 > max1)
                                                                {
                                                                    max1 = dec1;
                                                                }
                                                            }
                                                            dr["Fare"] = max1;
                                                        }
                                                        if (ddd.Tables[0].Columns.Count != 2)
                                                        {
                                                            dtRoutes.Rows.Add(dr);
                                                            sNo = sNo + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region AbhiBus
                if (abhiBusSourceId != null && abhiBusDestinationId != null)
                {
                    foreach (int itemSourceId in abhiBusSourceId)
                    {
                        foreach (int itemDestinationId in abhiBusDestinationId)
                        {
                            DataTable dtAbhiBus = null;
                            if (itemSourceId != 0 && itemDestinationId != 0)
                            {
                                try
                                {
                                    dtAbhiBus = objAbhiBusAPILayer.GetServices(journeyDate, Convert.ToString(itemSourceId), Convert.ToString(itemDestinationId));
                                }
                                catch (Exception ex)
                                {
                                    Mailsender.SendErrorEmail("prasad@lovejourney.in;sunil@lovejourney.in;", "",
                                          "", "SVR API Is Not Working // LoveJourney.in", ex.Message + ex.Source + ex.InnerException + ex.StackTrace);
                                    dtAbhiBus = null;
                                }
                            }
                            if (dtAbhiBus != null)
                            {

                                foreach (DataRow drAr in dtAbhiBus.Rows)
                                {
                                    DataRow dr = dtRoutes.NewRow();
                                    dr["API"] = "Abh";
                                    dr["Travels"] = drAr["traveler_agent"].ToString();
                                    dr["JourneyDate"] = journeyDate;
                                    dr["BusTypeShort"] = BusTypeString(drAr["service_type"].ToString());
                                    dr["BusType"] = drAr["service_type"].ToString();
                                    dr["ServiceNumber"] = "";

                                    #region Arr&DepTime
                                    dr["DepTime"] = drAr["departure_time"].ToString();
                                    dr["ArrTime"] = drAr["arrival_time"].ToString();
                                    if (drAr["departure_time"].ToString() != "")
                                    {
                                        dr["DepTimeInMins"] = TimeInMins(drAr["departure_time"].ToString());
                                    }
                                    if (drAr["arrival_time"].ToString() != "")
                                    {
                                        dr["ArrTimeInMins"] = TimeInMins(drAr["arrival_time"].ToString());
                                    }
                                    #endregion

                                    #region Duration
                                    string dtime = drAr["departure_time"].ToString();
                                    string atime = drAr["arrival_time"].ToString();
                                    if (dtime != "" && atime != "")
                                    {
                                        dr["Duration"] = Duration(dtime, atime);
                                    }
                                    #endregion

                                    #region Fare
                                    decimal max = 0;
                                    string[] strFare = drAr["seat_fare_with_taxes"].ToString().Split(',');
                                    max = Convert.ToDecimal(strFare[0].ToString());
                                    foreach (var item in strFare)
                                    {
                                        decimal dec = Convert.ToDecimal(item.ToString());
                                        if (dec > max)
                                        {
                                            max = dec;
                                        }
                                    }
                                    dr["Fare"] = max;
                                    #endregion

                                    dr["AvailableSeats"] = drAr["remaining_seats"].ToString();
                                    dr["ReservationId"] = "";
                                    dr["ServiceId"] = drAr["service_id"].ToString();
                                    dr["CoachTypeId"] = drAr["service_name"].ToString();
                                    dr["SourceId"] = itemSourceId;
                                    dr["DestinationId"] = itemDestinationId;
                                    dr["BoardingPoints"] = drAr["boardingpoints"].ToString();
                                    dr["DropingPoints"] = drAr["droppingpoints"].ToString();
                                    dr["BoardingPointsWithIds"] = drAr["boardingpointsWithIds"].ToString();
                                    dr["DropingPointsWithIds"] = drAr["droppingpointsWithIds"].ToString();
                                    dr["lblS"] = Convert.ToString(itemSourceId) + "," + Convert.ToString(itemDestinationId) + ","
                                        + journeyDate + "," + drAr["service_id"].ToString();
                                    dr["lblB"] = "Abh;" + journeyDate + ";" + Convert.ToString(itemSourceId) + ";"
                                        + Convert.ToString(itemDestinationId) + ";" + drAr["service_id"].ToString();
                                    dr["SNo"] = sNo;
                                    dtRoutes.Rows.Add(dr);
                                    sNo = sNo + 1;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region TicketGoose
                if (ticketGooseSourceId != null && ticketGooseDestinationId != null)
                {
                    foreach (int itemSourceId in ticketGooseSourceId)
                    {
                        foreach (int itemDestinationId in ticketGooseDestinationId)
                        {
                            string[] str1 = journeyDate.Split('-');
                            string jd1 = str1[2].ToString() + "/" + str1[1].ToString() + "/" + str1[0].ToString();

                            DataTable dtTicketGoose = null;
                            if (itemSourceId != 0 && itemDestinationId != 0)
                            {
                                try
                                {
                                    dtTicketGoose = objTicketGooseAPILayer.GetTripList(Convert.ToString(itemSourceId), Convert.ToString(itemDestinationId), jd1);
                                }
                                catch (Exception ex)
                                {
                                    Mailsender.SendErrorEmail("prasad@lovejourney.in;sunil@lovejourney.in;", "",
                                         "", "TicketGoose API Is Not Working // LoveJourney.in", ex.Message + ex.Source + ex.InnerException + ex.StackTrace);
                                    dtTicketGoose = null;
                                }
                            }
                            if (dtTicketGoose != null)
                            {
                                if (dtTicketGoose.Rows.Count > 0)
                                {
                                    foreach (DataRow drAr in dtTicketGoose.Rows)
                                    {
                                        if (drAr["ticketType"].ToString() == "Book")
                                        {
                                            DataRow dr = dtRoutes.NewRow();
                                            dr["API"] = "Tig";
                                            dr["Travels"] = drAr["provider"].ToString();
                                            dr["JourneyDate"] = journeyDate;
                                            dr["BusTypeShort"] = BusTypeString(drAr["type"].ToString());
                                            dr["BusType"] = drAr["type"].ToString();
                                            dr["ServiceNumber"] = "";

                                            #region DepTime
                                            string strDepTime = drAr["departureTime"].ToString();
                                            if (strDepTime != "")
                                            {
                                                dr["DepTime"] = DateTime.Parse(drAr["departureTime"].ToString()).ToString("t");
                                                dr["DepTimeInMins"] = TimeInMins(strDepTime);
                                            }
                                            #endregion

                                            #region ArrTime
                                            string strArrTime = drAr["arrivalTime"].ToString();
                                            if (strArrTime != "")
                                            {
                                                dr["ArrTime"] = DateTime.Parse(drAr["arrivalTime"].ToString()).ToString("t");
                                                dr["ArrTimeInMins"] = TimeInMins(strArrTime);
                                            }
                                            #endregion

                                            #region Duration
                                            string dtime = drAr["departureTime"].ToString();
                                            string atime = drAr["arrivalTime"].ToString();
                                            if (dtime != "" && atime != "")
                                            {
                                                dr["Duration"] = Duration(dtime, atime);
                                            }
                                            #endregion

                                            #region Fare
                                            decimal max = 0;
                                            string[] strFare = drAr["fare"].ToString().Split(',');
                                            max = Convert.ToDecimal(strFare[0].ToString());
                                            foreach (var item in strFare)
                                            {
                                                decimal dec = Convert.ToDecimal(item.ToString());
                                                if (dec > max)
                                                {
                                                    max = dec;
                                                }
                                            }
                                            dr["Fare"] = max;
                                            #endregion

                                            dr["AvailableSeats"] = drAr["availableSeats"].ToString();
                                            dr["ReservationId"] = "";
                                            dr["ServiceId"] = "";
                                            dr["CoachTypeId"] = "";
                                            dr["SourceId"] = itemSourceId;
                                            dr["DestinationId"] = itemDestinationId;
                                            dr["lblS"] = Convert.ToString(itemSourceId) + "," +
                                                Convert.ToString(itemDestinationId) + "," + jd1 + "," + drAr["scheduleId"].ToString();
                                            dr["lblB"] = "Tig;" + Convert.ToString(itemSourceId) + ";" +
                                                Convert.ToString(itemDestinationId) + ";" + jd1 + ";" + drAr["scheduleId"].ToString();
                                            dr["SNo"] = sNo;
                                            string bp = "";

                                            dr["BoardingPoints"] = drAr["pickUpPoint"].ToString();
                                            dr["DropingPoints"] = "";
                                            dr["BoardingPointsWithIds"] = "";
                                            dr["DropingPointsWithIds"] = "";
                                            if (!drAr["provider"].ToString().ToLower().Contains("svr") && !drAr["provider"].ToString().ToLower().Contains("orange"))
                                            {
                                                dtRoutes.Rows.Add(dr);
                                                sNo = sNo + 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                DataView dv = new DataView(dtRoutes);
                dv.Sort = "Fare ASC";
                return dv.ToTable();
            }
            catch (Exception ex)
            {
                Mailsender.SendMail("prasad@lovejourney.in", "", "", "GetRoutesError", ex.Message + ex.Source + ex.InnerException + ex.StackTrace);
                throw;
            }
        }

        string BusTypeString(string inputString)
        {
            try
            {
                string busTypeShort = inputString;
                string bustypeshort = "";

                if (busTypeShort.ToLower().Contains("sleeper") && !busTypeShort.ToLower().Contains("semi"))
                {
                    if (bustypeshort == "")
                    {
                        bustypeshort = "S";//bustypeshort = "Sleeper";
                    }
                    else { bustypeshort = bustypeshort + " , " + "S"; }
                }

                if (busTypeShort.ToLower().Contains("sleeper") && busTypeShort.ToLower().Contains("semi"))
                {
                    if (bustypeshort == "")
                    {
                        bustypeshort = "X";//bustypeshort = "SemiSleeper";
                    }
                    else { bustypeshort = bustypeshort + " , " + "X"; }
                }

                if (busTypeShort.ToLower().Contains("ac") && !busTypeShort.ToLower().Contains("non-ac"))
                {
                    if (bustypeshort == "")
                    {
                        bustypeshort = "A";//bustypeshort = "AC";
                    }
                    else { bustypeshort = bustypeshort + " , " + "A"; }
                }

                if (busTypeShort.ToLower().Contains("airconditioned") && !busTypeShort.ToLower().Contains("non-ac"))
                {
                    if (bustypeshort == "")
                    {
                        bustypeshort = "A";//bustypeshort = "AC";
                    }
                    else { bustypeshort = bustypeshort + " , " + "A"; }
                }

                if (busTypeShort.ToLower().Contains("a/c") && !busTypeShort.ToLower().Contains("non-ac") && !busTypeShort.ToLower().Contains("non a/c"))
                {
                    if (bustypeshort == "")
                    {
                        bustypeshort = "A";//bustypeshort = "AC";
                    }
                    else { bustypeshort = bustypeshort + " , " + "A"; }
                }

                if (busTypeShort.ToLower().Contains("non-ac") && !busTypeShort.ToLower().Contains("airconditioned") && !busTypeShort.ToLower().Contains("a/c"))
                {
                    if (bustypeshort == "")
                    {
                        bustypeshort = "N";
                    }
                    else { bustypeshort = bustypeshort + " , " + "N"; }
                }
                if (busTypeShort.ToLower().Contains("non a/c") && !busTypeShort.ToLower().Contains("airconditioned") && !busTypeShort.ToLower().Contains("ac"))
                {
                    if (bustypeshort == "")
                    {
                        bustypeshort = "N";
                    }
                    else { bustypeshort = bustypeshort + " , " + "N"; }
                }
                if (!busTypeShort.ToLower().Contains("ac") && !busTypeShort.ToLower().Contains("airconditioned") && !busTypeShort.ToLower().Contains("a/c")
                    && !busTypeShort.ToLower().Contains("sleeper") && !busTypeShort.ToLower().Contains("semi")
                    )
                {
                    if (bustypeshort == "")
                    {
                        bustypeshort = "N";//bustypeshort = "NonAC";
                    }
                    else { bustypeshort = bustypeshort + " , " + "N"; }
                }

                if (busTypeShort.Contains("A.C. Sleeper"))
                {
                    bustypeshort = "A" + " , " + "S";
                }

                return bustypeshort;
            }
            catch (Exception)
            {
                throw;
            }
        }

        string Time(string mins)
        {
            string s = mins;
            int i = int.Parse(s);

            TimeSpan f = new TimeSpan(0, i, 0);
            int hours = f.Hours;

            string AmOrPm = " AM";

            if (hours > 12 && hours < 24)
            {
                hours = hours - 12;
                AmOrPm = " PM";
            }
            if (hours >= 24 && hours <= 36)
            {
                hours = hours - 24;
                AmOrPm = " AM";
                if (hours == 36)
                {
                    hours = hours - 24;
                    AmOrPm = " PM";
                }
            }
            if (hours > 36 && hours < 48)
            {
                hours = hours - 36;
                AmOrPm = " PM";
            }
            s = string.Format("{0:00}:{1:00}", hours, f.Minutes);
            return s + AmOrPm;
        }
        string Duration(string dtime, string atime)
        {
            TimeSpan interval;
            if (DateTime.Parse(dtime).ToString().ToLower().Contains("pm") && DateTime.Parse(atime).ToString().ToLower().Contains("am"))
            {
                interval = DateTime.Parse(dtime) - DateTime.Parse(atime).AddDays(1);
            }
            else
            {
                interval = DateTime.Parse(dtime) - DateTime.Parse(atime);
            }
            int hours = 0; int minutes = 0;
            hours = interval.Hours > 0 ? interval.Hours : -(interval.Hours);
            minutes = interval.Minutes > 0 ? interval.Minutes : -(interval.Minutes);

            string hoursStr = ""; string minutesStr = "";

            hoursStr = Convert.ToString(hours).Length != 1 ? Convert.ToString(hours) : "0" + Convert.ToString(hours);
            minutesStr = Convert.ToString(minutes).Length != 1 ? Convert.ToString(minutes) : "0" + Convert.ToString(minutes);

            return hoursStr + "." + minutesStr + " hrs";
        }
        double TimeInMins(string date)
        {
            DateTime d = DateTime.Parse(date);
            TimeSpan time = new TimeSpan(d.Hour, d.Minute, d.Second);
            return time.TotalMinutes;
        }

        public DataTable GetBoardingPoints(string lblBDParams, string api)
        {
            try
            {
                DataTable dtBoardingPoints = new DataTable();
                dtBoardingPoints.Columns.Add("Name");
                dtBoardingPoints.Columns.Add("Id");
                dtBoardingPoints.Columns.Add("Address");
                dtBoardingPoints.Columns.Add("ContactNumber");
                dtBoardingPoints.Columns.Add("Landmark");

                if (api == "Bit")
                {
                    objBitlaAPILayer.ReservationId = lblBDParams;
                    DataTable dsBit = objBitlaAPILayer.GetServiceDetails().Tables["stage"];
                    if (dsBit != null)
                    {
                        foreach (DataRow item in dsBit.Rows)
                        {
                            if (item["type"].ToString() == "Boarding at")
                            {
                                DataRow dr = dtBoardingPoints.NewRow();
                                dr["Name"] = item["name"].ToString() + " - " + item["time"].ToString();
                                dr["Id"] = item["id"].ToString();
                                dr["Address"] = item["address"].ToString();
                                dr["ContactNumber"] = item["contact_numbers"].ToString();
                                dr["Landmark"] = item["landmark"].ToString();
                                dtBoardingPoints.Rows.Add(dr);
                            }
                        }
                    }
                }
                else if (api == "Kes")
                {
                    string[] str = lblBDParams.Split(',');
                    DataSet dsKes = objKesineniAPILayer.GetBoardingPoints(str[2].ToString(), Convert.ToInt64(str[3].ToString()),
                        Convert.ToInt32(str[0].ToString()), Convert.ToInt32(str[1].ToString()));
                    if (dsKes != null)
                    {
                        foreach (DataRow item in dsKes.Tables[0].Rows)
                        {
                            DataRow dr = dtBoardingPoints.NewRow();
                            string arrTime = item["ArrivalTime"].ToString();
                            string[] s1 = new string[1];
                            s1[0] = "   ";
                            string[] s2 = arrTime.Split(s1, StringSplitOptions.None);
                            dr["Name"] = item["BoardingPointName"].ToString() + " - " + s2[4].ToString();//.Split('-')[1].ToString()
                            dr["Id"] = item["BoardingPointID"].ToString();
                            dr["Address"] = item["BoardingPointAddress"].ToString();
                            dr["ContactNumber"] = "";
                            dr["Landmark"] = item["BoardingPointLandmark"].ToString();
                            dtBoardingPoints.Rows.Add(dr);
                        }
                    }
                }
                else if (api == "Abh")
                {
                    string[] str = lblBDParams.Split(',');
                    DataTable dtAbhiBusSeatLayout = objAbhiBusAPILayer.GetSeatLayout(str[2].ToString(), str[0].ToString(), str[1].ToString(), str[3].ToString(), "seat");

                    if (dtAbhiBusSeatLayout.Rows.Count > 0)
                    {
                        string boardingString = dtAbhiBusSeatLayout.Rows[0]["boardingpoints"].ToString();
                        string[] boardingStringArray = boardingString.Split(';');
                        foreach (string item in boardingStringArray)
                        {
                            if (item != "")
                            {
                                string[] star = new string[1];
                                star[0] = " - ";
                                string[] ss = item.Split(star, StringSplitOptions.None);
                                string[] star1 = new string[1];
                                star1[0] = "^^";
                                string[] s = ss[1].ToString().Split(star1, StringSplitOptions.None);

                                DataRow dr = dtBoardingPoints.NewRow();
                                dr["Name"] = s[0].ToString() + " - " + ss[2].ToString();
                                dr["Id"] = ss[0].ToString();
                                dr["Address"] = ss[1].ToString();
                                dr["ContactNumber"] = "";
                                dr["Landmark"] = "";
                                dtBoardingPoints.Rows.Add(dr);
                            }
                        }
                    }
                }
                else if (api == "Kal")
                {
                    string[] str = lblBDParams.Split(',');
                    DataTable dtKalladaSeatLayout = objKalladaAPILayer.GetSeatLayout
                        (str[2].ToString(), str[0].ToString(), str[1].ToString(), str[3].ToString(), "seat");

                    if (dtKalladaSeatLayout.Rows.Count > 0)
                    {
                        string boardingString = dtKalladaSeatLayout.Rows[0]["boardingpoints"].ToString();
                        string[] boardingStringArray = boardingString.Split(';');
                        foreach (string item in boardingStringArray)
                        {
                            if (item != "")
                            {
                                string[] star = new string[1];
                                star[0] = " - ";
                                string[] ss = item.Split(star, StringSplitOptions.None);
                                string[] star1 = new string[1];
                                star1[0] = "^^";
                                string[] s = ss[1].ToString().Split(star1, StringSplitOptions.None);

                                DataRow dr = dtBoardingPoints.NewRow();
                                dr["Name"] = s[0].ToString() + " - " + ss[2].ToString();
                                dr["Id"] = ss[0].ToString();
                                dr["Address"] = "";
                                dr["ContactNumber"] = ss[1].ToString();
                                dr["Landmark"] = "";
                                dtBoardingPoints.Rows.Add(dr);
                            }
                        }
                    }
                }
                else if (api == "Tig")
                {
                    string[] str = lblBDParams.Split(',');
                    DataSet dsTicketGoose = objTicketGooseAPILayer.GetTripDetails(str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString());
                    DataTable dtTicketGooseBP = dsTicketGoose.Tables["BoardingPoints"];
                    foreach (DataRow item in dtTicketGooseBP.Rows)
                    {
                        DataRow dr = dtBoardingPoints.NewRow();
                        dr["Name"] = item["boardingPointName"].ToString();
                        dr["Id"] = item["boardingPointId"].ToString();
                        dr["Address"] = "";
                        dr["ContactNumber"] = "";
                        dr["Landmark"] = "";
                        dtBoardingPoints.Rows.Add(dr);
                    }
                }
                return dtBoardingPoints;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetBitlaSeatLayoutAndBoardingPoints(string inParams, out DataTable dtBPoints)
        {
            try
            {
                DataTable dtBoardingPoints = new DataTable();
                dtBoardingPoints.Columns.Add("Name");
                dtBoardingPoints.Columns.Add("Id");
                dtBoardingPoints.Columns.Add("Address");
                dtBoardingPoints.Columns.Add("ContactNumber");
                dtBoardingPoints.Columns.Add("Landmark");

                DataTable dtSeatLayout = new DataTable();
                dtSeatLayout.Columns.Add("API");
                dtSeatLayout.Columns.Add("Row", System.Type.GetType("System.Int32"));
                dtSeatLayout.Columns.Add("Column", System.Type.GetType("System.Int32"));
                dtSeatLayout.Columns.Add("Seat");
                dtSeatLayout.Columns.Add("SeatStatus");
                dtSeatLayout.Columns.Add("Fare");
                dtSeatLayout.Columns.Add("Message");
                dtSeatLayout.Columns.Add("Type");
                dtSeatLayout.Columns.Add("IsBookedByFemale");
                dtSeatLayout.Columns.Add("IsReservedForFemale");

                objBitlaAPILayer.ReservationId = inParams;
                DataSet ds = objBitlaAPILayer.GetServiceDetails();

                DataTable dsBit = ds.Tables["stage"];
                if (dsBit != null)
                {
                    foreach (DataRow item in dsBit.Rows)
                    {
                        if (item["type"].ToString() == "Boarding at")
                        {
                            DataRow dr = dtBoardingPoints.NewRow();
                            dr["Name"] = item["name"].ToString() + " - " + item["time"].ToString();
                            dr["Id"] = item["id"].ToString();
                            dr["Address"] = item["address"].ToString();
                            dr["ContactNumber"] = item["contact_numbers"].ToString();
                            dr["Landmark"] = item["landmark"].ToString();
                            dtBoardingPoints.Rows.Add(dr);
                        }
                    }
                }
                dtBPoints = dtBoardingPoints;


                if (ds.Tables[0].Columns.Count == 2)
                {
                    DataRow dr = dtSeatLayout.NewRow();
                    dr["API"] = "Bit";
                    dr["Row"] = DBNull.Value;
                    dr["Column"] = DBNull.Value;
                    dr["Seat"] = "";
                    dr["SeatStatus"] = "";
                    dr["Fare"] = "";
                    dr["Message"] = "Service is left.";
                    dr["Type"] = "";
                    dr["IsBookedByFemale"] = "";
                    DataSet dss1 = new DataSet();
                    dss1.Tables.Add(dtSeatLayout);
                    return dss1.Tables[0];
                }
                foreach (DataRow y in ds.Tables["seat"].Rows)
                {
                    DataRow dr = dtSeatLayout.NewRow();
                    dr["API"] = "Bit";
                    dr["Row"] = y["col_id"].ToString().Trim();
                    dr["Column"] = y["row_id"].ToString().Trim();
                    dr["Seat"] = y["number"].ToString().Trim();
                    string type = "";
                    string busTypeShort = ds.Tables[0].Rows[0]["bus_type"].ToString();
                    if (busTypeShort.ToLower().Contains("sleeper") && !busTypeShort.ToLower().Contains("semi")
                        //&& busTypeShort.ToLower().Contains("1+1")
                        )
                    {
                        type = "Sleeper";
                    }
                    dr["Type"] = type;
                    dr["SeatStatus"] = y["available"].ToString();
                    dr["Fare"] = y["fare"].ToString();
                    dr["Message"] = "";
                    if (y["available"].ToString() == "false" && y["is_ladies_seat"].ToString() == "true")
                    {
                        dr["IsBookedByFemale"] = "true";
                    }
                    else { dr["IsBookedByFemale"] = ""; }
                    dtSeatLayout.Rows.Add(dr);
                }

                return dtSeatLayout;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetTicketGooseSeatLayoutAndBoardingPoints(string inParams, out DataTable dtBPoints)
        {
            try
            {
                DataTable dtBoardingPoints = new DataTable();
                dtBoardingPoints.Columns.Add("Name");
                dtBoardingPoints.Columns.Add("Id");
                dtBoardingPoints.Columns.Add("Address");
                dtBoardingPoints.Columns.Add("ContactNumber");
                dtBoardingPoints.Columns.Add("Landmark");

                DataTable dtSeatLayout = new DataTable();
                dtSeatLayout.Columns.Add("API");
                dtSeatLayout.Columns.Add("Row", System.Type.GetType("System.Int32"));
                dtSeatLayout.Columns.Add("Column", System.Type.GetType("System.Int32"));
                dtSeatLayout.Columns.Add("Seat");
                dtSeatLayout.Columns.Add("SeatStatus");
                dtSeatLayout.Columns.Add("Fare");
                dtSeatLayout.Columns.Add("Message");
                dtSeatLayout.Columns.Add("Type");
                dtSeatLayout.Columns.Add("IsBookedByFemale");
                dtSeatLayout.Columns.Add("IsReservedForFemale");

                string[] str = inParams.Split(',');
                DataSet ds = objTicketGooseAPILayer.GetTripDetails(str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString());

                DataTable dtTicketGooseBP = ds.Tables["BoardingPoints"];
                foreach (DataRow item in dtTicketGooseBP.Rows)
                {
                    DataRow dr = dtBoardingPoints.NewRow();
                    dr["Name"] = item["boardingPointName"].ToString();
                    dr["Id"] = item["boardingPointId"].ToString();
                    dr["Address"] = "";
                    dr["ContactNumber"] = "";
                    dr["Landmark"] = "";
                    dtBoardingPoints.Rows.Add(dr);
                }

                dtBPoints = dtBoardingPoints;

                return dtSeatLayout;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetDropingPoints(string lblBDParams, string api)
        {
            try
            {
                DataTable dtBoardingPoints = new DataTable();
                dtBoardingPoints.Columns.Add("Name");
                dtBoardingPoints.Columns.Add("Id");
                dtBoardingPoints.Columns.Add("Address");
                dtBoardingPoints.Columns.Add("ContactNumber");
                dtBoardingPoints.Columns.Add("Landmark");

                if (api == "Kes")
                {
                    string[] str = lblBDParams.Split(',');
                    DataSet dsKes = objKesineniAPILayer.GetDroppingPoints(str[2].ToString(), Convert.ToInt64(str[3].ToString()),
                        Convert.ToInt32(str[0].ToString()), Convert.ToInt32(str[1].ToString()));
                    foreach (DataRow item in dsKes.Tables[0].Rows)
                    {
                        DataRow dr = dtBoardingPoints.NewRow();
                        dr["Name"] = item["DroppingPointName"].ToString();
                        dr["Id"] = item["DroppingPointID"].ToString();
                        dr["Address"] = item["DroppingPointAddress"].ToString();
                        dr["ContactNumber"] = "";
                        dr["Landmark"] = item["DroppingPointLandmark"].ToString();
                        dtBoardingPoints.Rows.Add(dr);
                    }
                }
                else if (api == "Bit")
                {
                    objBitlaAPILayer.ReservationId = lblBDParams;
                    DataTable dsBit = objBitlaAPILayer.GetServiceDetails().Tables["stage"];
                    foreach (DataRow item in dsBit.Rows)
                    {
                        if (item["type"].ToString() == "Drop Off")
                        {
                            DataRow dr = dtBoardingPoints.NewRow();
                            dr["Name"] = item["name"].ToString() + " - " + item["time"].ToString();
                            dr["Id"] = item["id"].ToString();
                            dr["Address"] = item["address"].ToString();
                            dr["ContactNumber"] = item["contact_numbers"].ToString();
                            dr["Landmark"] = item["landmark"].ToString();
                            dtBoardingPoints.Rows.Add(dr);
                        }
                    }
                }
                else if (api == "Abh")
                {
                    string[] str = lblBDParams.Split(',');
                    DataTable dtAbhiBusSeatLayout = objAbhiBusAPILayer.GetSeatLayout(str[2].ToString(), str[0].ToString(), str[1].ToString(), str[3].ToString(), "seat");

                    if (dtAbhiBusSeatLayout.Rows.Count > 0)
                    {
                        string boardingString = dtAbhiBusSeatLayout.Rows[0]["droppingpoints"].ToString();
                        string[] boardingStringArray = boardingString.Split(';');
                        foreach (string item in boardingStringArray)
                        {
                            if (item != "")
                            {
                                string[] star = new string[1];
                                star[0] = " - ";
                                string[] ss = item.Split(star, StringSplitOptions.None);
                                string[] star1 = new string[1];
                                star1[0] = "^^";
                                string[] s = ss[1].ToString().Split(star1, StringSplitOptions.None);

                                DataRow dr = dtBoardingPoints.NewRow();
                                dr["Name"] = s[0].ToString() + " - " + ss[2].ToString();
                                dr["Id"] = ss[0].ToString();
                                dr["Address"] = ss[1].ToString();
                                dr["ContactNumber"] = "";
                                dr["Landmark"] = "";
                                dtBoardingPoints.Rows.Add(dr);
                            }
                        }
                    }
                }
                else if (api == "Kal")
                {
                    string[] str = lblBDParams.Split(',');
                    DataTable dtKalladaSeatLayout = objKalladaAPILayer.GetSeatLayout(str[2].ToString(), str[0].ToString(), str[1].ToString(), str[3].ToString(), "seat");

                    if (dtKalladaSeatLayout.Rows.Count > 0)
                    {
                        string boardingString = dtKalladaSeatLayout.Rows[0]["droppingpoints"].ToString();
                        string[] boardingStringArray = boardingString.Split(';');
                        foreach (string item in boardingStringArray)
                        {
                            if (item != "")
                            {
                                string[] star = new string[1];
                                star[0] = " - ";
                                string[] ss = item.Split(star, StringSplitOptions.None);
                                string[] star1 = new string[1];
                                star1[0] = "^^";
                                string[] s = ss[1].ToString().Split(star1, StringSplitOptions.None);

                                DataRow dr = dtBoardingPoints.NewRow();
                                dr["Name"] = s[0].ToString() + " - " + ss[2].ToString();
                                dr["Id"] = ss[0].ToString();
                                dr["Address"] = ss[1].ToString();
                                dr["ContactNumber"] = "";
                                dr["Landmark"] = "";
                                dtBoardingPoints.Rows.Add(dr);
                            }
                        }
                    }
                }
                return dtBoardingPoints;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetSeatLayout(string api, string lblS)
        {
            try
            {
                DataTable dtSeatLayout = new DataTable();
                dtSeatLayout.Columns.Add("API");
                dtSeatLayout.Columns.Add("Row", System.Type.GetType("System.Int32"));
                dtSeatLayout.Columns.Add("Column", System.Type.GetType("System.Int32"));
                dtSeatLayout.Columns.Add("Seat");
                dtSeatLayout.Columns.Add("SeatStatus");
                dtSeatLayout.Columns.Add("Fare");
                dtSeatLayout.Columns.Add("Message");
                dtSeatLayout.Columns.Add("Type");
                dtSeatLayout.Columns.Add("IsBookedByFemale");
                dtSeatLayout.Columns.Add("IsReservedForFemale");


                if (api == "Bit")
                {
                    objBitlaAPILayer.ReservationId = lblS;
                    DataSet dsBitlaSeatLayout = objBitlaAPILayer.GetServiceDetails();

                    if (dsBitlaSeatLayout.Tables[0].Columns.Count == 2)
                    {
                        DataRow dr = dtSeatLayout.NewRow();
                        dr["API"] = "Bit";
                        dr["Row"] = "";
                        dr["Column"] = "";
                        dr["Seat"] = "";
                        dr["SeatStatus"] = "";
                        dr["Fare"] = "";
                        dr["Message"] = "Service is left.";
                        dr["Type"] = "";
                        dr["IsBookedByFemale"] = "";
                        DataSet dss1 = new DataSet();
                        dss1.Tables.Add(dtSeatLayout);
                        return dss1;
                    }

                    foreach (DataRow y in dsBitlaSeatLayout.Tables["seat"].Rows)
                    {
                        DataRow dr = dtSeatLayout.NewRow();
                        dr["API"] = "Bit";
                        dr["Row"] = y["col_id"].ToString().Trim();
                        dr["Column"] = y["row_id"].ToString().Trim();
                        dr["Seat"] = y["number"].ToString().Trim();
                        string type = "";
                        string busTypeShort = dsBitlaSeatLayout.Tables[0].Rows[0]["bus_type"].ToString();
                        if (busTypeShort.ToLower().Contains("sleeper") && !busTypeShort.ToLower().Contains("semi")
                            && busTypeShort.ToLower().Contains("1+1"))
                        {
                            type = "Sleeper";
                        }
                        dr["Type"] = type;
                        dr["SeatStatus"] = y["available"].ToString();
                        dr["Fare"] = y["fare"].ToString();
                        dr["Message"] = "";
                        if (y["available"].ToString() == "false" && y["is_ladies_seat"].ToString() == "true")
                        {
                            dr["IsBookedByFemale"] = "true";
                        }
                        else { dr["IsBookedByFemale"] = ""; }
                        dtSeatLayout.Rows.Add(dr);
                    }
                }
                else if (api == "Kes")
                {
                    string[] str = lblS.ToString().Split(',');
                    DataSet dsKesSeatLayout = objKesineniAPILayer.GetSeatLayout(Convert.ToInt32(str[0].ToString()),
                        Convert.ToInt32(str[1].ToString()), Convert.ToString(str[2].ToString()), Convert.ToInt32(str[3].ToString())
                        , Convert.ToInt32(str[4].ToString()));
                    DataTable dsKesineniSeatLayout = dsKesSeatLayout.Tables["SeatNumber"];
                    if (dsKesSeatLayout.Tables[0].Columns.Count > 1)
                    {
                        foreach (DataRow x in dsKesineniSeatLayout.Rows)
                        {
                            string strParams = x[0].ToString();
                            string[] strArray = strParams.Substring(2, x[0].ToString().Length - 4).Split(',');
                            string rowSeat = strArray[0].ToString().Substring(0);
                            string column = strArray[1].ToString().Substring(1);
                            string seat = strArray[3].ToString().Substring(1);
                            string seatStatus = strArray[4].ToString().Substring(1);
                            DataRow dr = dtSeatLayout.NewRow();
                            if (seatStatus == "V")
                            {
                                seatStatus = "true";
                                dr["IsBookedByFemale"] = "";
                            }
                            else
                            {
                                if (seatStatus == "F") { dr["IsBookedByFemale"] = "true"; }
                                else { dr["IsBookedByFemale"] = ""; }
                                seatStatus = "false";
                            }
                            dr["API"] = "Kes";
                            dr["Row"] = rowSeat.Trim();
                            dr["Column"] = column.Trim();
                            dr["Seat"] = seat.Trim();
                            dr["Type"] = dsKesSeatLayout.Tables[0].Rows[0]["SeatType"].ToString(); ;
                            dr["SeatStatus"] = seatStatus;
                            dr["Fare"] = dsKesSeatLayout.Tables[0].Rows[0]["TicketFare"].ToString();
                            dr["Message"] = "";
                            dtSeatLayout.Rows.Add(dr);
                        }
                    }
                }
                else if (api == "Abh")
                {
                    string[] str = lblS.ToString().Split(',');
                    DataTable dtAbhiBusSeatLayout = objAbhiBusAPILayer.GetSeatLayout(str[2].ToString(), str[0].ToString(), str[1].ToString(), str[3].ToString(), "seat");
                    dtAbhiBusSeatLayout.TableName = "Seat";
                    if (dtAbhiBusSeatLayout.Rows.Count > 0)
                    {
                        string seatLayoutString = dtAbhiBusSeatLayout.Rows[0]["tot_availableseat_num"].ToString();
                        string[] seatLayoutStringArray = seatLayoutString.Split(';');
                        foreach (string seat in seatLayoutStringArray)
                        {
                            if (seat != "" && seat != "#*#-")
                            {
                                string[] star = new string[1];
                                star[0] = "#*#";
                                string[] st = seat.Split(star, StringSplitOptions.None);
                                string[] stRowColumn = st[1].ToString().Split('-');
                                DataRow dr = dtSeatLayout.NewRow();
                                dr["API"] = "Abh";
                                dr["Row"] = stRowColumn[0].ToString().Trim();
                                dr["Column"] = stRowColumn[1].ToString().Trim();
                                dr["Seat"] = st[0].ToString().Trim();
                                dr["Type"] = "";
                                string seatStatus = "true";
                                dr["SeatStatus"] = seatStatus;
                                dr["Fare"] = dtAbhiBusSeatLayout.Rows[0]["seat_fare_with_taxes"].ToString();
                                dr["Message"] = "";
                                dr["IsBookedByFemale"] = "";
                                dtSeatLayout.Rows.Add(dr);
                            }
                        }

                        string seatLayoutString1 = dtAbhiBusSeatLayout.Rows[0]["bookedseats"].ToString();
                        string seatLayoutString2 = dtAbhiBusSeatLayout.Rows[0]["gendertype"].ToString();

                        string[] seatLayoutStringArray1 = seatLayoutString1.Split(';');
                        string[] seatLayoutStringArray2 = seatLayoutString2.Split(';');
                        int i = 0;
                        foreach (string seat1 in seatLayoutStringArray1)
                        {
                            if (seat1 != "" && seat1 != "#*#-")
                            {
                                string[] star = new string[1];
                                star[0] = "#*#";
                                string[] st = seat1.Split(star, StringSplitOptions.None);
                                string[] stRowColumn = st[1].ToString().Split('-');
                                DataRow dr = dtSeatLayout.NewRow();
                                dr["API"] = "Abh";
                                dr["Row"] = stRowColumn[0].ToString().Trim();
                                dr["Column"] = stRowColumn[1].ToString().Trim();
                                dr["Seat"] = st[0].ToString().Trim();
                                dr["Type"] = "";
                                string seatStatus = "false";
                                dr["SeatStatus"] = seatStatus;
                                dr["Fare"] = dtAbhiBusSeatLayout.Rows[0]["seat_fare_with_taxes"].ToString();
                                dr["Message"] = "";
                                if (i < seatLayoutStringArray2.Length)
                                {
                                    string sttr = seatLayoutStringArray2[i].ToString();
                                    if (sttr == "F")
                                    {
                                        dr["IsBookedByFemale"] = "true";
                                    }
                                    else { dr["IsBookedByFemale"] = ""; }
                                }
                                else { dr["IsBookedByFemale"] = ""; }
                                dtSeatLayout.Rows.Add(dr);
                            }
                            i += 1;
                        }
                    }
                }
                else if (api == "Kal")
                {
                    string[] str = lblS.ToString().Split(',');
                    DataTable dtKalladaSeatLayout = objKalladaAPILayer.GetSeatLayout(str[2].ToString(), str[0].ToString(), str[1].ToString(), str[3].ToString(), "seat");
                    dtKalladaSeatLayout.TableName = "Seat";
                    if (dtKalladaSeatLayout.Rows.Count > 0)
                    {
                        string seatLayoutString = dtKalladaSeatLayout.Rows[0]["layout_seat_status"].ToString();

                        string seatLayoutString1 = dtKalladaSeatLayout.Rows[0]["bookedseats"].ToString();
                        string seatLayoutString2 = dtKalladaSeatLayout.Rows[0]["gendertype"].ToString();

                        string[] seatLayoutStringArray = seatLayoutString.Split(';');

                        string[] seatLayoutStringArray1 = seatLayoutString1.Split(';');
                        string[] seatLayoutStringArray2 = seatLayoutString2.Split(';');

                        foreach (string seat in seatLayoutStringArray)
                        {
                            if (seat != "" && seat != "#*#-")
                            {
                                string[] star = new string[1];
                                star[0] = " #*# ";
                                string[] st = seat.Split(star, StringSplitOptions.None);
                                string[] stRowColumn = st[1].ToString().Split('-');
                                DataRow dr = dtSeatLayout.NewRow();
                                dr["API"] = "Kal";
                                dr["Row"] = stRowColumn[1].ToString().Trim();
                                dr["Column"] = stRowColumn[0].ToString().Trim();
                                dr["Seat"] = st[0].ToString().Trim();
                                dr["Type"] = "";
                                string seatStatus = "";
                                if (st[4].ToString() == "A")
                                {
                                    seatStatus = "true";
                                    dr["IsBookedByFemale"] = "";
                                }
                                else
                                {
                                    if (st[4].ToString().Contains("F"))
                                    {
                                        dr["IsBookedByFemale"] = "true";
                                    }
                                    else
                                    {
                                        dr["IsBookedByFemale"] = "";
                                    }
                                    seatStatus = "false";
                                }
                                dr["SeatStatus"] = seatStatus;
                                dr["Fare"] = dtKalladaSeatLayout.Rows[0]["seat_fare_with_taxes"].ToString();
                                dr["Message"] = "";
                                dtSeatLayout.Rows.Add(dr);
                            }
                        }
                    }
                }
                else if (api == "Tig")
                {
                    string[] str = lblS.Split(',');
                    DataSet ds = objTicketGooseAPILayer.GetTripDetails(str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString());
                    DataTable dtBusLayoutList = ds.Tables["BusLayoutList"];
                    DataTable dtSeatDetails = ds.Tables["SeatDetails"];

                    foreach (DataRow item in dtBusLayoutList.Rows)
                    {
                        DataRow dr = dtSeatLayout.NewRow();
                        dr["API"] = "Tig";
                        dr["Row"] = item["columnNbr"].ToString().Trim();
                        dr["Column"] = item["rowNbr"].ToString().Trim();
                        dr["Seat"] = item["seatNbr"].ToString().Trim();
                        dr["SeatStatus"] = "false";
                        dr["Fare"] = "";

                        DataRow[] drSeat = dtSeatDetails.Select("SeatseatNbr = '" + item["seatNbr"].ToString().Trim() + "'");
                        if (drSeat.Length > 0)
                        {
                            if (drSeat[0]["seatStatus"].ToString() == "A")
                            {
                                dr["SeatStatus"] = "true";
                                dr["Fare"] = drSeat[0]["fare"].ToString();
                                dr["IsBookedByFemale"] = "";
                                dr["IsReservedForFemale"] = "";
                            }
                            else if (drSeat[0]["seatStatus"].ToString() == "F")
                            {
                                dr["SeatStatus"] = "true";
                                dr["Fare"] = drSeat[0]["fare"].ToString();
                                dr["IsBookedByFemale"] = "";
                                dr["IsReservedForFemale"] = "true";
                            }
                            else if (drSeat[0]["seatStatus"].ToString() == "M")
                            {
                                dr["SeatStatus"] = "true";
                                dr["Fare"] = drSeat[0]["fare"].ToString();
                                dr["IsBookedByFemale"] = "";
                                dr["IsReservedForFemale"] = "";
                            }
                            else if (drSeat[0]["seatStatus"].ToString() == "B")
                            {
                                dr["SeatStatus"] = "false";
                                dr["Fare"] = drSeat[0]["fare"].ToString();
                                dr["IsBookedByFemale"] = "";
                                dr["IsReservedForFemale"] = "";
                            }
                        }

                        string type = "";
                        string busTypeShort = "";//dsBitlaSeatLayout.Tables[0].Rows[0]["bus_type"].ToString();
                        if (busTypeShort.ToLower().Contains("sleeper") && !busTypeShort.ToLower().Contains("semi")
                            && busTypeShort.ToLower().Contains("1+1"))
                        {
                            type = "Sleeper";
                        }
                        dr["Type"] = type;
                        dr["Message"] = "";

                        dtSeatLayout.Rows.Add(dr);
                    }
                }
                DataSet dss = new DataSet();
                dss.Tables.Add(dtSeatLayout);
                return dss;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet TentativeBooking(DataTable dtTicketInfo, string referenceNumber, out string api, out string status, out string statusReason)
        {
            try
            {
                DataSet ds = null;

                string str = dtTicketInfo.Rows[0]["OtherInfo"].ToString();
                string[] strArray = str.Split(';');

                api = ""; status = ""; statusReason = "";

                api = strArray[0].ToString();

                #region KesneniTentativeBooking
                if (api == "Kes")
                {
                    int sourceStationId = 0; int destinationStationId = 0; string journeyDate = ""; long serviceId = 0;
                    int coachTypeId = 0; int noOfSeats = 0; string seatNumbersList = ""; string firstNameList = "";
                    string lastNameList = ""; string genderList = ""; string ageList = ""; string contactNumberList = "";
                    string boardingPointIdList = ""; string droppingPointId = ""; string ticketFare = ""; string emailId = "";
                    string address = ""; string photoIdType = ""; string photoIdNo = ""; string photoIdIssuingAuthority = "";
                    decimal totalBasicFare = 0; decimal serviceTaxPercentage = 0; string discountcode = ""; string travels = "";
                    string sourcename = ""; string destinationname = ""; string bustype = "";
                    string boardingPoint = ""; int age = 0;

                    sourceStationId = Convert.ToInt32(strArray[1].ToString());
                    destinationStationId = Convert.ToInt32(strArray[2].ToString());
                    journeyDate = strArray[3].ToString();
                    serviceId = Convert.ToInt64(strArray[4].ToString());
                    coachTypeId = Convert.ToInt32(strArray[5].ToString());
                    noOfSeats = Convert.ToInt32(strArray[7].ToString());
                    seatNumbersList = strArray[8].ToString();
                    boardingPointIdList = strArray[9].ToString();
                    ticketFare = Convert.ToString(strArray[6].ToString());
                    droppingPointId = strArray[11].ToString();
                    emailId = dtTicketInfo.Rows[0]["EmailId"].ToString();
                    address = dtTicketInfo.Rows[0]["Address"].ToString();
                    travels = dtTicketInfo.Rows[0]["Travels"].ToString();
                    bustype = dtTicketInfo.Rows[0]["BusType"].ToString();
                    //sourcename = ViewState["From"].ToString();
                    //destinationname = ViewState["To"].ToString();
                    boardingPoint = dtTicketInfo.Rows[0]["BoardingPoint"].ToString();
                    age = Convert.ToInt32(dtTicketInfo.Rows[0]["Age"].ToString());
                    string firstname = dtTicketInfo.Rows[0]["FullName"].ToString();
                    string contactno = dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                    photoIdType = "photoIdType";
                    photoIdNo = referenceNumber;
                    photoIdIssuingAuthority = "photoIdIssuingAuthority";
                    totalBasicFare = Convert.ToDecimal(strArray[10].ToString());
                    serviceTaxPercentage = Convert.ToDecimal(0);
                    discountcode = "0";

                    if (dtTicketInfo.Columns.Contains("FullNameList") &&
                        dtTicketInfo.Columns.Contains("PhoneNoList") &&
                        dtTicketInfo.Columns.Contains("AgeList") &&
                        dtTicketInfo.Columns.Contains("GenderList"))
                    {
                        if (dtTicketInfo.Rows[0]["FullNameList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["PhoneNoList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["AgeList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["GenderList"].ToString() != "")
                        {
                            firstNameList = dtTicketInfo.Rows[0]["FullNameList"].ToString();
                            lastNameList = dtTicketInfo.Rows[0]["FullNameList"].ToString();
                            genderList = dtTicketInfo.Rows[0]["GenderList"].ToString();
                            ageList = dtTicketInfo.Rows[0]["AgeList"].ToString();
                            contactNumberList = dtTicketInfo.Rows[0]["PhoneNoList"].ToString();
                        }
                        else
                        {
                            firstNameList = dtTicketInfo.Rows[0]["FullName"].ToString();
                            lastNameList = dtTicketInfo.Rows[0]["FullName"].ToString();
                            genderList = dtTicketInfo.Rows[0]["Title"].ToString();
                            ageList = dtTicketInfo.Rows[0]["Age"].ToString();
                            contactNumberList = dtTicketInfo.Rows[0]["PhoneNo"].ToString();

                            if (noOfSeats > 1)
                            {
                                for (int i = 0; i < noOfSeats - 1; i++)
                                {
                                    firstNameList = firstNameList + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                                    lastNameList = lastNameList + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                                    contactNumberList = contactNumberList + "," + dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                                    ageList = ageList + "," + dtTicketInfo.Rows[0]["Age"].ToString();
                                    genderList = genderList + "," + dtTicketInfo.Rows[0]["Title"].ToString();
                                }
                            }
                        }
                    }

                    else
                    {
                        firstNameList = dtTicketInfo.Rows[0]["FullName"].ToString();
                        lastNameList = dtTicketInfo.Rows[0]["FullName"].ToString();
                        genderList = dtTicketInfo.Rows[0]["Title"].ToString();
                        ageList = dtTicketInfo.Rows[0]["Age"].ToString();
                        contactNumberList = dtTicketInfo.Rows[0]["PhoneNo"].ToString();

                        if (noOfSeats > 1)
                        {
                            for (int i = 0; i < noOfSeats - 1; i++)
                            {
                                firstNameList = firstNameList + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                                lastNameList = lastNameList + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                                contactNumberList = contactNumberList + "," + dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                                ageList = ageList + "," + dtTicketInfo.Rows[0]["Age"].ToString();
                                genderList = genderList + "," + dtTicketInfo.Rows[0]["Title"].ToString();
                            }
                        }
                    }

                    if (dtTicketInfo.Columns.Contains("IdType") &&
                       dtTicketInfo.Columns.Contains("IdNo") &&
                       dtTicketInfo.Columns.Contains("IdIssuedBy"))
                    {
                        if (dtTicketInfo.Rows[0]["IdType"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["IdNo"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["IdIssuedBy"].ToString() != "")
                        {
                            photoIdType = dtTicketInfo.Rows[0]["IdType"].ToString();
                            photoIdNo = dtTicketInfo.Rows[0]["IdNo"].ToString();
                            photoIdIssuingAuthority = dtTicketInfo.Rows[0]["IdIssuedBy"].ToString();
                        }
                    }

                    ds = objKesineniAPILayer.BookTicketsOnwardJourney(sourceStationId, destinationStationId, journeyDate,
                        serviceId, coachTypeId, noOfSeats, seatNumbersList, firstNameList, lastNameList, genderList,
                        ageList, contactNumberList, boardingPointIdList, droppingPointId, ticketFare, emailId, address,
                        photoIdType, photoIdNo, photoIdIssuingAuthority, totalBasicFare, serviceTaxPercentage, discountcode);

                    if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count > 1)
                    {
                        status = "Success";
                        statusReason = "";
                    }
                    if (ds.Tables[0].Columns.Count == 1)
                    {
                        status = "Fail";
                        statusReason = ds.Tables[0].Rows[0]["Message"].ToString();
                    }
                }
                #endregion

                #region BitlaTentativeBooking
                if (api == "Bit")
                {
                    objBitlaAPILayer.ReservationId = strArray[1].ToString();
                    objBitlaAPILayer.OriginId = strArray[2].ToString();
                    objBitlaAPILayer.DestinationId = strArray[3].ToString();
                    objBitlaAPILayer.BoardingAt = strArray[5].ToString();
                    objBitlaAPILayer.NoOfSeats = strArray[4].ToString();
                    objBitlaAPILayer.RefNumber = referenceNumber;
                    int noOfSeats = Convert.ToInt32(strArray[4].ToString());
                    string selectedSeats = strArray[6].ToString();
                    string[] selectedSeatsArray = selectedSeats.Split(',');

                    book_ticket bookTicket = new book_ticket();
                    object[] obj = new object[2];

                    book_ticketSeat_detailsSeat_detail[] sD = new book_ticketSeat_detailsSeat_detail[noOfSeats];

                    if (dtTicketInfo.Columns.Contains("FullNameList") &&
                        dtTicketInfo.Columns.Contains("PhoneNoList") &&
                        dtTicketInfo.Columns.Contains("AgeList") &&
                        dtTicketInfo.Columns.Contains("GenderList") &&
                        dtTicketInfo.Columns.Contains("IdType") &&
                        dtTicketInfo.Columns.Contains("IdNo") &&
                        dtTicketInfo.Columns.Contains("IdIssuedBy"))
                    {
                        if (dtTicketInfo.Rows[0]["FullNameList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["PhoneNoList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["AgeList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["GenderList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["IdType"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["IdNo"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["IdIssuedBy"].ToString() != "")
                        {
                            string[] fullNameListArray = dtTicketInfo.Rows[0]["FullNameList"].ToString().Split(',');
                            string[] phoneNoListArray = dtTicketInfo.Rows[0]["PhoneNoList"].ToString().Split(',');
                            string[] ageListArray = dtTicketInfo.Rows[0]["AgeList"].ToString().Split(',');
                            string[] genderListArray = dtTicketInfo.Rows[0]["GenderList"].ToString().Split(',');

                            string address = dtTicketInfo.Rows[0]["Address"].ToString();
                            string idType = dtTicketInfo.Rows[0]["IdType"].ToString();
                            string idNo = dtTicketInfo.Rows[0]["IdNo"].ToString();
                            string idIssuedBy = dtTicketInfo.Rows[0]["IdIssuedBy"].ToString();

                            for (int i = 0; i < noOfSeats; i++)
                            {
                                book_ticketSeat_detailsSeat_detail sdd = new book_ticketSeat_detailsSeat_detail();
                                sdd.seat_number = selectedSeatsArray[i].ToString();
                                sdd.title = genderListArray[i].ToString();
                                sdd.name = fullNameListArray[i].ToString();
                                sdd.age = ageListArray[i].ToString();
                                sdd.sex = genderListArray[i].ToString();

                                if (i == 0) { sdd.is_primary = "true"; }
                                else { sdd.is_primary = "false"; }

                                sdd.address = address;

                                string id = "";//1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card
                                if (idType.ToString().ToLower().Contains("pan"))
                                {
                                    id = "1";
                                }
                                else if (idType.ToString().ToLower().Contains("dri"))
                                {
                                    id = "2";
                                }
                                else if (idType.ToString().ToLower().Contains("pass"))
                                {
                                    id = "3";
                                }
                                else if (idType.ToString().ToLower().Contains("voter"))
                                {
                                    id = "4";
                                }
                                else if (idType.ToString().ToLower().Contains("adhar"))
                                {
                                    id = "5";
                                }
                                else if (idType.ToString().ToLower().Contains("ration"))
                                {
                                    id = "4";
                                }

                                sdd.id_card_type = id;

                                sdd.id_card_number = idNo;
                                sdd.id_card_issued_by = idIssuedBy;

                                sD[i] = sdd;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < noOfSeats; i++)
                            {
                                book_ticketSeat_detailsSeat_detail sdd = new book_ticketSeat_detailsSeat_detail();
                                sdd.seat_number = selectedSeatsArray[i].ToString();
                                sdd.title = "Mr";
                                sdd.name = dtTicketInfo.Rows[0]["FullName"].ToString();
                                sdd.age = dtTicketInfo.Rows[0]["Age"].ToString();
                                sdd.sex = dtTicketInfo.Rows[0]["Title"].ToString();
                                if (i == 0) { sdd.is_primary = "true"; }
                                else { sdd.is_primary = "false"; }

                                sdd.address = "";
                                sdd.id_card_type = "";//1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card
                                sdd.id_card_number = "";
                                sdd.id_card_issued_by = "";

                                sD[i] = sdd;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < noOfSeats; i++)
                        {
                            book_ticketSeat_detailsSeat_detail sdd = new book_ticketSeat_detailsSeat_detail();
                            sdd.seat_number = selectedSeatsArray[i].ToString();
                            sdd.title = "Mr";
                            sdd.name = dtTicketInfo.Rows[0]["FullName"].ToString();
                            sdd.age = dtTicketInfo.Rows[0]["Age"].ToString();
                            sdd.sex = dtTicketInfo.Rows[0]["Title"].ToString();
                            if (i == 0) { sdd.is_primary = "true"; }
                            else { sdd.is_primary = "false"; }

                            sdd.address = "";
                            sdd.id_card_type = "";//1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card
                            sdd.id_card_number = "";
                            sdd.id_card_issued_by = "";

                            sD[i] = sdd;
                        }
                    }
                    book_ticketSeat_details ss = new book_ticketSeat_details();
                    ss.seat_detail = sD;
                    book_ticketContact_detail cc = new book_ticketContact_detail();
                    cc.mobile_number = dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                    cc.email = dtTicketInfo.Rows[0]["EmailId"].ToString();
                    cc.emergency_name = dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                    obj[0] = ss;
                    obj[1] = cc;
                    bookTicket.Items = obj;

                    objBitlaAPILayer.TicketDetails = bookTicket;
                    ds = objBitlaAPILayer.ValidateBookTicket();

                    string strValidateBookTicket = "";
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count == 2)
                        {
                            strValidateBookTicket = ds.Tables[0].Rows[0]["message"].ToString();
                        }
                    }
                    if (strValidateBookTicket == "Success! You can book this ticket.")
                    {
                        status = "Success";
                        statusReason = "";
                    }
                    else
                    {
                        status = "Fail";
                        statusReason = ds.Tables[0].Rows[0]["message"].ToString();
                    }
                }
                #endregion

                #region AbhiBusTentativeBooking
                if (api == "Abh")
                {
                    string jDate = ""; string sId = ""; string dId = ""; string serviceId = ""; string selectedSeats = "";
                    int noOfSeats = 0; string bId = ""; string genderType = ""; string psgrName = "";
                    jDate = strArray[1].ToString();
                    sId = strArray[2].ToString();
                    dId = strArray[3].ToString();
                    serviceId = strArray[4].ToString();
                    selectedSeats = strArray[5].ToString();
                    bId = strArray[6].ToString();
                    noOfSeats = Convert.ToInt32(strArray[7].ToString());
                    genderType = dtTicketInfo.Rows[0]["Title"].ToString();
                    psgrName = dtTicketInfo.Rows[0]["FullName"].ToString();
                    if (noOfSeats > 1)
                    {
                        for (int i = 0; i < noOfSeats - 1; i++)
                        {
                            psgrName = psgrName + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                            genderType = genderType + "," + dtTicketInfo.Rows[0]["Title"].ToString();
                        }
                    }
                    DataTable dt1 = objAbhiBusAPILayer.SeatBlocking(jDate, sId, dId, serviceId, selectedSeats);
                    ds = new DataSet();
                    ds.Tables.Add(dt1);

                    if (dt1 != null && dt1.Columns.Count > 0 && dt1.Rows.Count > 0)
                    {
                        string sel_seats = dt1.Rows[0]["sel_seats"].ToString();
                        string sel_seat_row_cols = dt1.Rows[0]["sel_seat_row_cols"].ToString();
                        string total_fare = dt1.Rows[0]["total_fare"].ToString();
                        if (sel_seats != "" && total_fare != "")
                        {
                            status = "Success";
                            statusReason = "";
                        }
                        else
                        {
                            status = "Fail";
                            statusReason = "Your given seat numbers are already booked or not available in seat layout.";
                        }
                    }
                    else
                    {
                        status = "Fail";
                        statusReason = "Your given seat numbers are already booked or not available in seat layout.";
                    }
                }
                #endregion

                #region KalladaTentativeBooking
                if (api == "Kal")
                {
                    string jDate = ""; string sId = ""; string dId = ""; string serviceId = ""; string selectedSeats = "";
                    int noOfSeats = 0; string bId = ""; string genderType = ""; string psgrName = "";
                    jDate = strArray[1].ToString();
                    sId = strArray[2].ToString();
                    dId = strArray[3].ToString();
                    serviceId = strArray[4].ToString();
                    selectedSeats = strArray[5].ToString();
                    bId = strArray[6].ToString();
                    noOfSeats = Convert.ToInt32(strArray[7].ToString());
                    genderType = dtTicketInfo.Rows[0]["Title"].ToString();
                    psgrName = dtTicketInfo.Rows[0]["FullName"].ToString();
                    if (noOfSeats > 1)
                    {
                        for (int i = 0; i < noOfSeats - 1; i++)
                        {
                            psgrName = psgrName + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                            genderType = genderType + "," + dtTicketInfo.Rows[0]["Title"].ToString();
                        }
                    }
                    DataTable dt1 = objKalladaAPILayer.SeatBlocking(jDate, sId, dId, serviceId, selectedSeats);
                    ds = new DataSet();
                    ds.Tables.Add(dt1);

                    if (dt1 != null && dt1.Columns.Count > 0 && dt1.Rows.Count > 0)
                    {
                        string sel_seats = dt1.Rows[0]["sel_seats"].ToString();
                        string sel_seat_row_cols = dt1.Rows[0]["sel_seat_row_cols"].ToString();
                        string total_fare = dt1.Rows[0]["total_fare"].ToString();
                        if (sel_seats != "" && total_fare != "")
                        {
                            status = "Success";
                            statusReason = "";
                        }
                        else
                        {
                            status = "Fail";
                            statusReason = "Your given seat numbers are already booked or not available in seat layout.";
                        }
                    }
                    else
                    {
                        status = "Fail";
                        statusReason = "Your given seat numbers are already booked or not available in seat layout.";
                    }
                }
                #endregion

                #region TicketGooseBooking
                if (api == "Tig")
                {
                    string scheduleId = ""; string TravelDate = ""; string FromStationId = "";
                    string ToStationId = ""; string boardingPointId = ""; string emailId = "";
                    string mobileNbr = ""; string address = "";

                    string[] otherInfo = dtTicketInfo.Rows[0]["OtherInfo"].ToString().Split(';');

                    FromStationId = otherInfo[1].ToString();
                    ToStationId = otherInfo[2].ToString();
                    TravelDate = otherInfo[3].ToString();
                    scheduleId = otherInfo[4].ToString();
                    boardingPointId = otherInfo[5].ToString();

                    emailId = dtTicketInfo.Rows[0]["EmailId"].ToString();
                    mobileNbr = dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                    address = dtTicketInfo.Rows[0]["Address"].ToString();

                    string[] seatNos = dtTicketInfo.Rows[0]["SeatNos"].ToString().Split(',');
                    string[] ages = dtTicketInfo.Rows[0]["AgeList"].ToString().Split(',');
                    string[] genders = dtTicketInfo.Rows[0]["GenderList"].ToString().Split(',');
                    string[] names = dtTicketInfo.Rows[0]["FullNameList"].ToString().Split(',');

                    PassengerDetailDTO[] PassengerDetailDT = new PassengerDetailDTO[seatNos.Length];

                    for (int i = 0; i < seatNos.Length; i++)
                    {
                        PassengerDetailDTO PassengerDetailDTO1 = new PassengerDetailDTO();
                        PassengerDetailDTO1.age = ages[i].ToString();
                        PassengerDetailDTO1.name = names[i].ToString();
                        PassengerDetailDTO1.seatNbr = seatNos[i].ToString();
                        PassengerDetailDTO1.sex = genders[i].ToString();
                        PassengerDetailDT[i] = PassengerDetailDTO1;
                    }

                    DataTable dt = objTicketGooseAPILayer.BlockSeatsForBooking(scheduleId, TravelDate, FromStationId, ToStationId,
                        boardingPointId, emailId, mobileNbr, address, PassengerDetailDT);
                    ds = new DataSet();
                    ds.Tables.Add(dt);

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Columns.Contains("BookingId"))
                            {
                                status = "Success";
                                statusReason = "";
                            }
                            else
                            {
                                status = "Fail";
                                statusReason = "Your given seat numbers are already booked or not available in seat layout.";
                            }
                        }
                        else
                        {
                            status = "Fail";
                            statusReason = "Your given seat numbers are already booked or not available in seat layout.";
                        }
                    }
                    else
                    {
                        status = "Fail";
                        statusReason = "Your given seat numbers are already booked or not available in seat layout.";
                    }
                }
                #endregion

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected string GenerateManabusRefNo()
        {
            try
            {
                int minPassSize = 4;
                int maxPassSize = 4;
                StringBuilder stringBuilder = new StringBuilder();
                char[] charArray = "0123456789".ToCharArray();
                int newPassLength = new Random().Next(minPassSize, maxPassSize);
                char character;
                Random rnd = new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < newPassLength; i++)
                {
                    character = charArray[rnd.Next(0, (charArray.Length - 1))];
                    stringBuilder.Append(character);
                }
                //string refno = "MBRS" + stringBuilder.ToString();
                string refno = "MB" + stringBuilder.ToString();

                ClsBAL objBAL = new ClsBAL();
                string strUniqueId = objBAL.GetUniqueId();
                //if (objManabusBAL.CheckManabusRefNoAvailability(refno) == false)
                //{
                //    GenerateManabusRefNo();
                //}
                return refno + strUniqueId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Booking(DataTable dtTicketInfo, DataSet dsTentativeInfo, string referenceNumber, out string api,
                                out string status, out string statusReason)
        {
            try
            {
                DataSet dsBookingResult = null;
                string str = dtTicketInfo.Rows[0]["OtherInfo"].ToString();
                string[] strArray = str.Split(';');

                api = ""; status = ""; statusReason = "";

                api = strArray[0].ToString();

                #region KesineniBooking
                if (api == "Kes")
                {
                    int sourceStationId = 0; int destinationStationId = 0; string journeyDate = ""; long serviceId = 0;
                    int coachTypeId = 0; int noOfSeats = 0; string seatNumbersList = ""; string firstNameList = "";
                    string lastNameList = ""; string genderList = ""; string ageList = ""; string contactNumberList = "";
                    string boardingPointIdList = ""; string droppingPointId = ""; string ticketFare = ""; string emailId = "";
                    string address = ""; string photoIdType = ""; string photoIdNo = ""; string photoIdIssuingAuthority = "";
                    decimal totalBasicFare = 0; decimal serviceTaxPercentage = 0; string discountcode = "";

                    sourceStationId = Convert.ToInt32(strArray[1].ToString());
                    destinationStationId = Convert.ToInt32(strArray[2].ToString());
                    journeyDate = strArray[3].ToString();
                    serviceId = Convert.ToInt64(strArray[4].ToString());
                    coachTypeId = Convert.ToInt32(strArray[5].ToString());
                    noOfSeats = Convert.ToInt32(strArray[7].ToString());
                    seatNumbersList = strArray[8].ToString();
                    boardingPointIdList = strArray[9].ToString();
                    ticketFare = Convert.ToString(strArray[6].ToString());
                    droppingPointId = strArray[11].ToString();
                    emailId = dtTicketInfo.Rows[0]["EmailId"].ToString();
                    address = dtTicketInfo.Rows[0]["Address"].ToString();

                    photoIdType = "photoIdType";
                    photoIdNo = referenceNumber;
                    photoIdIssuingAuthority = "photoIdIssuingAuthority";
                    totalBasicFare = Convert.ToDecimal(strArray[10].ToString());
                    serviceTaxPercentage = Convert.ToDecimal(0);
                    discountcode = "0";

                    if (dtTicketInfo.Columns.Contains("FullNameList") &&
                       dtTicketInfo.Columns.Contains("PhoneNoList") &&
                       dtTicketInfo.Columns.Contains("AgeList") &&
                       dtTicketInfo.Columns.Contains("GenderList"))
                    {
                        if (dtTicketInfo.Rows[0]["FullNameList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["PhoneNoList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["AgeList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["GenderList"].ToString() != "")
                        {
                            firstNameList = dtTicketInfo.Rows[0]["FullNameList"].ToString();
                            lastNameList = dtTicketInfo.Rows[0]["FullNameList"].ToString();
                            genderList = dtTicketInfo.Rows[0]["GenderList"].ToString();
                            ageList = dtTicketInfo.Rows[0]["AgeList"].ToString();
                            contactNumberList = dtTicketInfo.Rows[0]["PhoneNoList"].ToString();
                        }
                        else
                        {
                            firstNameList = dtTicketInfo.Rows[0]["FullName"].ToString();
                            lastNameList = dtTicketInfo.Rows[0]["FullName"].ToString();
                            genderList = dtTicketInfo.Rows[0]["Title"].ToString();
                            ageList = dtTicketInfo.Rows[0]["Age"].ToString();
                            contactNumberList = dtTicketInfo.Rows[0]["PhoneNo"].ToString();

                            if (noOfSeats > 1)
                            {
                                for (int i = 0; i < noOfSeats - 1; i++)
                                {
                                    firstNameList = firstNameList + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                                    lastNameList = lastNameList + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                                    contactNumberList = contactNumberList + "," + dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                                    ageList = ageList + "," + dtTicketInfo.Rows[0]["Age"].ToString();
                                    genderList = genderList + "," + dtTicketInfo.Rows[0]["Title"].ToString();
                                }
                            }
                        }
                    }

                    else
                    {
                        firstNameList = dtTicketInfo.Rows[0]["FullName"].ToString();
                        lastNameList = dtTicketInfo.Rows[0]["FullName"].ToString();
                        genderList = dtTicketInfo.Rows[0]["Title"].ToString();
                        ageList = dtTicketInfo.Rows[0]["Age"].ToString();
                        contactNumberList = dtTicketInfo.Rows[0]["PhoneNo"].ToString();

                        if (noOfSeats > 1)
                        {
                            for (int i = 0; i < noOfSeats - 1; i++)
                            {
                                firstNameList = firstNameList + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                                lastNameList = lastNameList + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                                contactNumberList = contactNumberList + "," + dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                                ageList = ageList + "," + dtTicketInfo.Rows[0]["Age"].ToString();
                                genderList = genderList + "," + dtTicketInfo.Rows[0]["Title"].ToString();
                            }
                        }
                    }

                    if (dtTicketInfo.Columns.Contains("IdType") &&
                      dtTicketInfo.Columns.Contains("IdNo") &&
                      dtTicketInfo.Columns.Contains("IdIssuedBy"))
                    {
                        if (dtTicketInfo.Rows[0]["IdType"].ToString() != "" &&
                           dtTicketInfo.Rows[0]["IdNo"].ToString() != "")
                        {
                            photoIdType = dtTicketInfo.Rows[0]["IdType"].ToString();
                            photoIdNo = dtTicketInfo.Rows[0]["IdNo"].ToString();
                            photoIdIssuingAuthority = dtTicketInfo.Rows[0]["IdIssuedBy"].ToString();
                        }
                    }

                    DataSet ds = dsTentativeInfo;
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Count > 1)
                        {
                            int serviceTransId = 0;
                            long blockedTicketId = 0;
                            serviceTransId = Convert.ToInt32(ds.Tables[0].Rows[0]["ServiceTransDateID"].ToString());
                            blockedTicketId = Convert.ToInt64(ds.Tables[0].Rows[0]["BlockedTicketID"].ToString());
                            dsBookingResult = objKesineniAPILayer.BookTicketsConfirmationOnwardJourney(sourceStationId, destinationStationId, journeyDate,
                                serviceId, serviceTransId, noOfSeats, blockedTicketId, GenerateManabusRefNo(), GenerateManabusRefNo());
                            status = "Success"; statusReason = "";
                        }
                    }
                    else
                    {
                        status = "Fail"; statusReason = "Need to write.";
                    }
                }
                #endregion

                #region BitlaBooking
                if (api == "Bit")
                {
                    objBitlaAPILayer.ReservationId = strArray[1].ToString();
                    objBitlaAPILayer.OriginId = strArray[2].ToString();
                    objBitlaAPILayer.DestinationId = strArray[3].ToString();
                    objBitlaAPILayer.BoardingAt = strArray[5].ToString();
                    objBitlaAPILayer.NoOfSeats = strArray[4].ToString();
                    objBitlaAPILayer.RefNumber = referenceNumber;
                    int noOfSeats = Convert.ToInt32(strArray[4].ToString());
                    string selectedSeats = strArray[6].ToString();
                    string[] selectedSeatsArray = selectedSeats.Split(',');

                    book_ticket bookTicket = new book_ticket();
                    object[] obj = new object[2];

                    book_ticketSeat_detailsSeat_detail[] sD = new book_ticketSeat_detailsSeat_detail[noOfSeats];

                    if (dtTicketInfo.Columns.Contains("FullNameList") &&
                        dtTicketInfo.Columns.Contains("PhoneNoList") &&
                        dtTicketInfo.Columns.Contains("AgeList") &&
                        dtTicketInfo.Columns.Contains("GenderList") &&
                        dtTicketInfo.Columns.Contains("IdType") &&
                        dtTicketInfo.Columns.Contains("IdNo") &&
                        dtTicketInfo.Columns.Contains("IdIssuedBy"))
                    {
                        if (dtTicketInfo.Rows[0]["FullNameList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["PhoneNoList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["AgeList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["GenderList"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["IdType"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["IdNo"].ToString() != "" &&
                            dtTicketInfo.Rows[0]["IdIssuedBy"].ToString() != "")
                        {
                            string[] fullNameListArray = dtTicketInfo.Rows[0]["FullNameList"].ToString().Split(',');
                            string[] phoneNoListArray = dtTicketInfo.Rows[0]["PhoneNoList"].ToString().Split(',');
                            string[] ageListArray = dtTicketInfo.Rows[0]["AgeList"].ToString().Split(',');
                            string[] genderListArray = dtTicketInfo.Rows[0]["GenderList"].ToString().Split(',');

                            string address = dtTicketInfo.Rows[0]["Address"].ToString();
                            string idType = dtTicketInfo.Rows[0]["IdType"].ToString();
                            string idNo = dtTicketInfo.Rows[0]["IdNo"].ToString();
                            string idIssuedBy = dtTicketInfo.Rows[0]["IdIssuedBy"].ToString();

                            for (int i = 0; i < noOfSeats; i++)
                            {
                                book_ticketSeat_detailsSeat_detail sdd = new book_ticketSeat_detailsSeat_detail();
                                sdd.seat_number = selectedSeatsArray[i].ToString();
                                sdd.title = genderListArray[i].ToString();
                                sdd.name = fullNameListArray[i].ToString();
                                sdd.age = ageListArray[i].ToString();
                                sdd.sex = genderListArray[i].ToString();

                                if (i == 0) { sdd.is_primary = "true"; }
                                else { sdd.is_primary = "false"; }

                                sdd.address = address;

                                string id = "";//1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card
                                if (idType.ToString().ToLower().Contains("pan"))
                                {
                                    id = "1";
                                }
                                else if (idType.ToString().ToLower().Contains("dri"))
                                {
                                    id = "2";
                                }
                                else if (idType.ToString().ToLower().Contains("pass"))
                                {
                                    id = "3";
                                }
                                else if (idType.ToString().ToLower().Contains("voter"))
                                {
                                    id = "4";
                                }
                                else if (idType.ToString().ToLower().Contains("adhar"))
                                {
                                    id = "5";
                                }
                                else if (idType.ToString().ToLower().Contains("ration"))
                                {
                                    id = "4";
                                }

                                sdd.id_card_type = id;

                                sdd.id_card_number = idNo;
                                sdd.id_card_issued_by = idIssuedBy;

                                sD[i] = sdd;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < noOfSeats; i++)
                            {
                                book_ticketSeat_detailsSeat_detail sdd = new book_ticketSeat_detailsSeat_detail();
                                sdd.seat_number = selectedSeatsArray[i].ToString();
                                sdd.title = "Mr";
                                sdd.name = dtTicketInfo.Rows[0]["FullName"].ToString();
                                sdd.age = dtTicketInfo.Rows[0]["Age"].ToString();
                                sdd.sex = dtTicketInfo.Rows[0]["Title"].ToString();
                                if (i == 0) { sdd.is_primary = "true"; }
                                else { sdd.is_primary = "false"; }

                                sdd.address = "";
                                sdd.id_card_type = "";//1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card
                                sdd.id_card_number = "";
                                sdd.id_card_issued_by = "";

                                sD[i] = sdd;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < noOfSeats; i++)
                        {
                            book_ticketSeat_detailsSeat_detail sdd = new book_ticketSeat_detailsSeat_detail();
                            sdd.seat_number = selectedSeatsArray[i].ToString();
                            sdd.title = "Mr";
                            sdd.name = dtTicketInfo.Rows[0]["FullName"].ToString();
                            sdd.age = dtTicketInfo.Rows[0]["Age"].ToString();
                            sdd.sex = dtTicketInfo.Rows[0]["Title"].ToString();
                            if (i == 0) { sdd.is_primary = "true"; }
                            else { sdd.is_primary = "false"; }

                            sdd.address = "";
                            sdd.id_card_type = "";//1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card
                            sdd.id_card_number = "";
                            sdd.id_card_issued_by = "";

                            sD[i] = sdd;
                        }
                    }

                    book_ticketSeat_details ss = new book_ticketSeat_details();
                    ss.seat_detail = sD;
                    book_ticketContact_detail cc = new book_ticketContact_detail();
                    cc.mobile_number = dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                    cc.email = dtTicketInfo.Rows[0]["EmailId"].ToString();
                    cc.emergency_name = dtTicketInfo.Rows[0]["PhoneNo"].ToString();
                    obj[0] = ss;
                    obj[1] = cc;
                    bookTicket.Items = obj;

                    objBitlaAPILayer.TicketDetails = bookTicket;
                    DataSet dsBookTicket = dsTentativeInfo;
                    DataSet dsBookTicket2 = objBitlaAPILayer.BookTicket();
                    if (dsBookTicket2 != null)
                    {
                        if (dsBookTicket2.Tables[0].Rows.Count > 0)
                        {
                            status = "Success"; statusReason = "";
                            dsBookingResult = dsBookTicket2;
                        }
                        else
                        {
                            status = "Fail"; statusReason = "Need to write.";
                        }
                    }
                    else
                    {
                        status = "Fail"; statusReason = "Need to write.";
                    }
                }
                #endregion

                #region AbhiBusBooking
                if (api == "Abh")
                {
                    string jDate = ""; string sId = ""; string dId = ""; string serviceId = ""; string selectedSeats = "";
                    int noOfSeats = 0; string bId = ""; string genderType = ""; string psgrName = "";
                    jDate = strArray[1].ToString();
                    sId = strArray[2].ToString();
                    dId = strArray[3].ToString();
                    serviceId = strArray[4].ToString();
                    selectedSeats = strArray[5].ToString();
                    bId = strArray[6].ToString();
                    noOfSeats = Convert.ToInt32(strArray[7].ToString());
                    genderType = dtTicketInfo.Rows[0]["Title"].ToString();
                    psgrName = dtTicketInfo.Rows[0]["FullName"].ToString();
                    if (noOfSeats > 1)
                    {
                        for (int i = 0; i < noOfSeats - 1; i++)
                        {
                            psgrName = psgrName + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                            genderType = genderType + "," + dtTicketInfo.Rows[0]["Title"].ToString();
                        }
                    }
                    DataSet ds11 = dsTentativeInfo;
                    DataTable dt1 = ds11.Tables[0];
                    if (dt1 != null && dt1.Columns.Count > 0 && dt1.Rows.Count > 0)
                    {
                        string sel_seats = dt1.Rows[0]["sel_seats"].ToString();
                        string sel_seat_row_cols = dt1.Rows[0]["sel_seat_row_cols"].ToString();
                        string total_fare = dt1.Rows[0]["total_fare"].ToString();
                        if (sel_seats != "" && sel_seat_row_cols != "" && total_fare != "")
                        {
                            DataTable dt2 = objAbhiBusAPILayer.SeatBooking(jDate, sId, dId, serviceId, selectedSeats, genderType, psgrName,
                            bId, dtTicketInfo.Rows[0]["Address"].ToString(), dtTicketInfo.Rows[0]["FullName"].ToString(),
                            dtTicketInfo.Rows[0]["PhoneNo"].ToString(), dtTicketInfo.Rows[0]["EmailId"].ToString(), referenceNumber);
                            status = "Success"; statusReason = "Need to write";
                            dsBookingResult = new DataSet();
                            dsBookingResult.Tables.Add(dt2);
                        }
                    }
                    else
                    {
                        status = "Fail"; statusReason = "Need to write";
                    }
                }
                #endregion

                #region KalladaBooking
                if (api == "Kal")
                {
                    string jDate = ""; string sId = ""; string dId = ""; string serviceId = ""; string selectedSeats = "";
                    int noOfSeats = 0; string bId = ""; string genderType = ""; string psgrName = "";
                    jDate = strArray[1].ToString();
                    sId = strArray[2].ToString();
                    dId = strArray[3].ToString();
                    serviceId = strArray[4].ToString();
                    selectedSeats = strArray[5].ToString();
                    bId = strArray[6].ToString();
                    noOfSeats = Convert.ToInt32(strArray[7].ToString());
                    genderType = dtTicketInfo.Rows[0]["Title"].ToString();
                    psgrName = dtTicketInfo.Rows[0]["FullName"].ToString();
                    if (noOfSeats > 1)
                    {
                        for (int i = 0; i < noOfSeats - 1; i++)
                        {
                            psgrName = psgrName + "," + dtTicketInfo.Rows[0]["FullName"].ToString();
                            genderType = genderType + "," + dtTicketInfo.Rows[0]["Title"].ToString();
                        }
                    }
                    DataSet ds11 = dsTentativeInfo;
                    DataTable dt1 = ds11.Tables[0];
                    if (dt1 != null && dt1.Columns.Count > 0 && dt1.Rows.Count > 0)
                    {
                        string sel_seats = dt1.Rows[0]["sel_seats"].ToString();
                        string sel_seat_row_cols = dt1.Rows[0]["sel_seat_row_cols"].ToString();
                        string total_fare = dt1.Rows[0]["total_fare"].ToString();
                        if (sel_seats != "" && sel_seat_row_cols != "" && total_fare != "")
                        {
                            DataTable dt2 = objKalladaAPILayer.SeatBooking(jDate, sId, dId, serviceId, selectedSeats, genderType, psgrName,
                            bId, dtTicketInfo.Rows[0]["Address"].ToString(), dtTicketInfo.Rows[0]["FullName"].ToString(),
                            dtTicketInfo.Rows[0]["PhoneNo"].ToString(), dtTicketInfo.Rows[0]["EmailId"].ToString(), referenceNumber);
                            status = "Success"; statusReason = "Need to write";
                            dsBookingResult = new DataSet();
                            dsBookingResult.Tables.Add(dt2);
                        }
                    }
                    else
                    {
                        status = "Fail"; statusReason = "Need to write";
                    }
                }
                #endregion

                return dsBookingResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="api">1)Kes or 2)Abh or 3)Bit</param>
        /// <param name="type">Type of cancellation 1)Full or 2)Partial</param>
        /// <param name="inputParams"></param>
        /// <param name="status">Returns Status as 1)Success or 2)Fail</param>
        /// <param name="statusReason">Returns StatusReason</param>
        public void Cancel(string api, string type, string inputParams, out string status, out string statusReason)
        {
            try
            {
                status = ""; statusReason = "";

                #region Bitla
                if (api == "Bit")
                {
                    //string ticketNumberBitla = "MBS13281";
                    //string seatNumbersBitla = "16";
                    //objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                    //objBitlaAPILayer.SeatNumbers = seatNumbersBitla;
                    //DataSet dsBitla = objBitlaAPILayer.IsTicketCancellable();

                    #region Cancellation
                    //if (dsBitla != null)
                    //{
                    //    if (dsBitla.Tables[0].Rows.Count > 0 && dsBitla.Tables[0].Columns.Count > 2)
                    //    {
                    //        double cancelAmount = Convert.ToDouble(dsBitla.Tables[0].Rows[0]["refund_amount"].ToString()) -
                    //            Convert.ToDouble(dsBitla.Tables[0].Rows[0]["cancellation_charges"].ToString());
                    //        if (dsBitla.Tables[0].Rows[0]["is_cancellable"].ToString() == "true")
                    //        {
                    //            objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                    //            DataSet dsBitla1 = objBitlaAPILayer.CancelTicket();
                    //            GridView1.DataSource = dsBitla1; GridView1.DataBind();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        GridView1.DataSource = dsBitla; GridView1.DataBind();
                    //    }
                    //}
                    #endregion

                    #region PartialCancellation
                    //if (dsBitla != null)
                    //{
                    //    if (dsBitla.Tables[0].Rows.Count > 0 && dsBitla.Tables[0].Columns.Count > 2)
                    //    {
                    //        double cancelAmount = Convert.ToDouble(dsBitla.Tables[0].Rows[0]["refund_amount"].ToString()) -
                    //          Convert.ToDouble(dsBitla.Tables[0].Rows[0]["cancellation_charges"].ToString());
                    //        if (dsBitla.Tables[0].Rows[0]["is_cancellable"].ToString() == "true")
                    //        {
                    //            objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                    //            objBitlaAPILayer.SeatNumbers = seatNumbersBitla;
                    //            DataSet dsBitla2 = objBitlaAPILayer.CancelPartialTicket();
                    //            GridView1.DataSource = dsBitla2; GridView1.DataBind();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        GridView1.DataSource = dsBitla; GridView1.DataBind();
                    //    }
                    //}
                    #endregion
                }
                #endregion

                #region Kesineni
                if (api == "Kes")
                {
                    //string pnrNumberKesineni = "979B97";
                    //string firstNameKesineni = "a";
                    //string lastNameKesineni = "a";
                    //string dateOfJourneyKesineni = "05/25/2012";
                    //string seatNumberListKesineni = "10,9";
                    //DataSet dsKesineni = objKesineniAPILayer.CancelTickets(pnrNumberKesineni, firstNameKesineni, lastNameKesineni,
                    //    dateOfJourneyKesineni, seatNumberListKesineni);
                    //if (dsKesineni != null)
                    //{
                    //    if (dsKesineni.Tables[0].Rows.Count > 0 && dsKesineni.Tables[0].Columns.Count > 1)
                    //    {
                    //        double grandTotalRefund = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["GrandTotalRefunded"].ToString());
                    //        double cancellationCharges = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["CancellationCharges"].ToString());
                    //        DataSet dsKesineni1 = objKesineniAPILayer.ConfirmCancelTickets(pnrNumberKesineni, firstNameKesineni,
                    //            lastNameKesineni, dateOfJourneyKesineni, seatNumberListKesineni);
                    //        GridView1.DataSource = dsKesineni1;
                    //        GridView1.DataBind();
                    //    }
                    //    else
                    //    {
                    //        GridView1.DataSource = dsKesineni;
                    //        GridView1.DataBind();
                    //    }
                    //}
                }
                #endregion

                #region AbhiBus
                if (api == "Abh")
                {
                    string ticketNumberAbhiBus = inputParams;
                    if (type == "Full")
                    {
                        DataTable dtAbhiBus = objAbhiBusAPILayer.CancellationConfirmation(ticketNumberAbhiBus);
                        if (dtAbhiBus != null)
                        {
                            if (dtAbhiBus.Rows.Count > 0)
                            {
                                if (dtAbhiBus.Rows[0]["total_refund_amount"].ToString() == "Success")
                                {
                                    double totalRefundAmount = Convert.ToDouble(dtAbhiBus.Rows[0]["total_refund_amount"].ToString());
                                    DataTable dtAbhiBus1 = objAbhiBusAPILayer.TicketCancellation(ticketNumberAbhiBus);
                                    status = "Success"; statusReason = "Invalid Input.";
                                }
                                else { status = "Fail"; statusReason = "Invalid Input."; }
                            }
                        }
                        else
                        {
                            status = "Fail"; statusReason = "Invalid Input.";
                        }
                    }
                    else if (type == "Partial")
                    {
                        status = "Fail"; statusReason = "AbhiBus API does not support Partial type cancellation.";
                    }
                }
                #endregion

                #region Kallada
                if (api == "Kal")
                {
                    string ticketNumberAbhiBus = inputParams;
                    if (type == "Full")
                    {
                        DataTable dtKallada = objKalladaAPILayer.CancellationConfirmation(ticketNumberAbhiBus);
                        if (dtKallada != null)
                        {
                            if (dtKallada.Rows.Count > 0)
                            {
                                if (dtKallada.Rows[0]["total_refund_amount"].ToString() == "Success")
                                {
                                    double totalRefundAmount = Convert.ToDouble(dtKallada.Rows[0]["total_refund_amount"].ToString());
                                    DataTable dtKallada1 = objKalladaAPILayer.TicketCancellation(ticketNumberAbhiBus);
                                    status = "Success"; statusReason = "Invalid Input.";
                                }
                                else { status = "Fail"; statusReason = "Invalid Input."; }
                            }
                        }
                        else
                        {
                            status = "Fail"; statusReason = "Invalid Input.";
                        }
                    }
                    else if (type == "Partial")
                    {
                        status = "Fail"; statusReason = "Kallada API does not support Partial type cancellation.";
                    }
                }
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class KesineniDetails
    {
        private string m_LoginId;
        private string m_PassWord;
        public string LoginId
        {
            get { return m_LoginId; }
            set { m_LoginId = value; }
        }
        public string PassWord
        {
            get { return m_PassWord; }
            set { m_PassWord = value; }
        }

        public KesineniDetails()
        {
        }

        public KesineniDetails(String loginid, String password)
        {
            LoginId = loginid;
            PassWord = password;
        }
    }
    public class AbhiBusDetails
    {
        private string m_Url;
        public string Url
        {
            get { return m_Url; }
            set { m_Url = value; }
        }
    }
    public class BitlaDetails
    {
        private string m_Url;
        private string m_ApiKey;
        public string Url
        {
            get { return m_Url; }
            set { m_Url = value; }
        }
        public string ApiKey
        {
            get { return m_ApiKey; }
            set { m_ApiKey = value; }
        }

        public BitlaDetails()
        {
        }

        public BitlaDetails(String url, String apikey)
        {
            Url = url;
            ApiKey = apikey;
        }
    }
}