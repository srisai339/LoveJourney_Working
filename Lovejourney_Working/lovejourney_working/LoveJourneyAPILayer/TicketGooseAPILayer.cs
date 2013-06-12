using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusAPILayer.TicketGooseNamespace;
using System.IO;
using System.Xml.Serialization;

namespace BusAPILayer
{
    public class TicketGooseAPILayer : ITicketGooseAPILayer
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public DataTable GetStationList()
        {
            try
            {
                TGTravelServiceClient o = new TGTravelServiceClient();
                o.Open();
                Station s = o.getStationList(UserId, Password);
                Array st = s.stationList;
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("stationId");
                dataTable.Columns.Add("stationName");
                foreach (StationDTO i in st)
                {
                    DataRow dr = dataTable.NewRow();
                    dr["stationId"] = i.stationId;
                    dr["stationName"] = i.stationName;
                    dataTable.Rows.Add(dr);
                }
                o.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetFromToStation()
        {
            try
            {
                TGTravelServiceClient o = new TGTravelServiceClient();
                o.Open();
                FromToStation from = o.getFromToStationIdList(UserId, Password);
                Array fm = from.fromToStationList;
                DataTable dtsid = new DataTable();
                dtsid.Columns.Add("toStationId");
                dtsid.Columns.Add("fromStationId");
                foreach (FromToStationDTO f in fm)
                {
                    foreach (string str in f.toStationId)
                    {
                        DataRow dd = dtsid.NewRow();
                        dd["toStationId"] = str.ToString();
                        dd["fromStationId"] = f.fromStationId;
                        dtsid.Rows.Add(dd);
                    }
                }
                o.Close();
                return dtsid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDestinations(string sourceId)
        {
            DataTable dt = new DataTable();
            BAL.ClsBAL obj = new BAL.ClsBAL();
            dt = obj.GetTicketGooseDestinations(sourceId).Tables[0];

            DataTable dtone = new DataTable();
            if (dt.Rows.Count > 0)
            {
                DataTable dtfrom = new DataTable();

                dtfrom = GetStationList();

                DataView dvfrom = dtfrom.DefaultView;
                dtone.Columns.Add("stationId");
                dtone.Columns.Add("stationName");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dvfrom.RowFilter = "stationId='" + dt.Rows[i]["fromStationId"] + "'";
                    DataRow row = dtone.NewRow();
                    row["stationId"] = dvfrom[0]["stationId"].ToString();
                    row["stationName"] = dvfrom[0]["stationName"].ToString();
                    dtone.Rows.Add(row);
                }
            }
            return dtone;
        }
        public DataTable GetTripList(string FromStationId, string ToStationId, string TravelDate)
        {
            try
            {
                DataTable dataTable = new DataTable();
                TGTravelServiceClient o = new TGTravelServiceClient();
                o.Open();
                TripWithArrival TripList = o.getTripListV2(UserId, Password, FromStationId, ToStationId, TravelDate);
                if (TripList.status.message.ToString() == "success")
                {
                    Array ObjArray = TripList.tripList;
                    dataTable.Columns.Add("arrivalTime");
                    dataTable.Columns.Add("availableSeats");
                    dataTable.Columns.Add("departureTime");
                    dataTable.Columns.Add("fare");
                    dataTable.Columns.Add("provider");
                    dataTable.Columns.Add("scheduleId");
                    dataTable.Columns.Add("ticketType");
                    dataTable.Columns.Add("type");
                    dataTable.Columns.Add("pickUpPoint");
                    dataTable.Columns.Add("sequence");

                    foreach (TripWithArrivalDTO Trip1 in ObjArray)
                    {
                        //foreach (PickUpPointDTO PickupPoint in Trip1.pickUpPointList)
                        {
                            DataRow dr = dataTable.NewRow();
                            dr["arrivalTime"] = Trip1.arrivalTime;
                            dr["availableSeats"] = Trip1.availableSeats;
                            dr["departureTime"] = Trip1.departureTime;
                            dr["fare"] = Trip1.fare;
                            dr["provider"] = Trip1.provider;
                            dr["scheduleId"] = Trip1.scheduleId;
                            dr["ticketType"] = Trip1.ticketType;
                            dr["type"] = Trip1.type;
                            dr["pickUpPoint"] = "";//PickupPoint.description;
                            dr["sequence"] = "";//PickupPoint.sequence;
                            DataRow[] ddd = dataTable.Select("scheduleId = '" + Trip1.scheduleId + "'");
                            if (ddd.Length == 0)
                            {
                                dataTable.Rows.Add(dr);
                            }
                        }
                    }
                }
                o.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTripDetails(string FromStationId, string ToStationId, string TravelDate, string scheduleId)
        {
            try
            {
                TGTravelServiceClient o = new TGTravelServiceClient();
                o.Open();
                DataSet ds1 = new DataSet("dataset");
                TripDetails TripDt = o.getTripDetailsV2(UserId, Password, FromStationId, ToStationId, TravelDate, scheduleId);
                DataTable dataTable = new DataTable();
                dataTable.TableName = "BusLayoutList";
                if (TripDt.status.message.ToString() == "success")
                {
                    dataTable.Columns.Add("level");
                    dataTable.Columns.Add("noOfRows");
                    dataTable.Columns.Add("noOfColumns");
                    dataTable.Columns.Add("rowNbr");
                    dataTable.Columns.Add("columnNbr");
                    dataTable.Columns.Add("seatNbr");
                    dataTable.Columns.Add("cellType");

                    TripDetailsDTO dd = TripDt.tripDetails;
                    foreach (BusLayoutDTO Bdt in dd.busLayoutList)
                    {
                        foreach (SeatDetailsDTO sdt in Bdt.seatDetailsList)
                        {
                            DataRow dr = dataTable.NewRow();
                            dr["level"] = Bdt.level;
                            dr["noOfRows"] = Bdt.nbrOfRows;
                            dr["noOfColumns"] = Bdt.nbrOfColumns;
                            dr["rowNbr"] = sdt.rowNbr;
                            dr["columnNbr"] = sdt.columnNbr;
                            dr["seatNbr"] = sdt.seatNbr;
                            dr["cellType"] = sdt.cellType;
                            dataTable.Rows.Add(dr);
                        }
                    }
                    DataTable dtseatdetails = new DataTable();
                    dtseatdetails.TableName = "SeatDetails";
                    dtseatdetails.Columns.Add("SeatseatNbr");
                    dtseatdetails.Columns.Add("seatType");
                    dtseatdetails.Columns.Add("fare");
                    dtseatdetails.Columns.Add("seatStatus");
                    foreach (SeatDetailDTO SDt in dd.seatDetailList)
                    {
                        DataRow drseat = dtseatdetails.NewRow();
                        drseat["SeatseatNbr"] = SDt.seatNbr;
                        drseat["seatType"] = SDt.seatType;
                        drseat["fare"] = SDt.fare;
                        drseat["seatStatus"] = SDt.seatStatus;
                        dtseatdetails.Rows.Add(drseat);
                    }
                    DataTable dtBoarding = new DataTable();
                    dtBoarding.TableName = "BoardingPoints";
                    dtBoarding.Columns.Add("boardingPointId");
                    dtBoarding.Columns.Add("boardingPointName");
                    dtBoarding.Columns.Add("time");

                    foreach (BoardingPointDTO BPdt in dd.boardingPointList)
                    {
                        DataRow drboarding = dtBoarding.NewRow();
                        drboarding["boardingPointId"] = BPdt.boardingPointId;
                        drboarding["boardingPointName"] = BPdt.boardingPointName;
                        drboarding["time"] = BPdt.time;
                        dtBoarding.Rows.Add(drboarding);
                    }

                    ds1.Tables.Add(dtseatdetails);
                    ds1.Tables.Add(dtBoarding);
                    ds1.Tables.Add(dataTable);
                }
                o.Close();
                return ds1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BlockSeatsForBooking(string scheduleId, string TravelDate, string FromStationId, string ToStationId, string boardingPointId,
            string emailId, string mobileNbr, string address, PassengerDetailDTO[] PassengerDetailDTO)
        {
            try
            {
                TGTravelServiceClient o = new TGTravelServiceClient();
                o.Open();
                BlockedSeatsForBookingDetails BlockSeatsBooking = o.blockSeatsForBooking(UserId, Password, scheduleId, TravelDate, FromStationId, ToStationId, boardingPointId, emailId, mobileNbr, address, PassengerDetailDTO);
                DataTable data = new DataTable();
                data.Columns.Add("BookingId");
                data.Columns.Add("expireTime");
                data.Columns.Add("cancellationDescList");
                if (BlockSeatsBooking.status.message.ToString() == "Success")
                {
                    foreach (var canceldesc in BlockSeatsBooking.cancellationDescList)
                    {
                        DataRow row = data.NewRow();
                        row["BookingId"] = BlockSeatsBooking.bookingId;
                        row["expireTime"] = BlockSeatsBooking.expireTime;
                        row["cancellationDescList"] = canceldesc.ToString();
                        data.Rows.Add(row);
                    }
                }
                o.Close();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BookTicket(string bookingId)
        {
            try
            {
                TGTravelServiceClient o = new TGTravelServiceClient();
                o.Open();
                DataTable data = new DataTable();
                data.Columns.Add("bookingId");
                data.Columns.Add("extraSeatInfo");
                data.Columns.Add("seatNbr");
                data.Columns.Add("travelsPhoneNbr");
                data.Columns.Add("cancellationDescList");
                data.Columns.Add("Status");
                BookingDetails booking = o.bookTicket(UserId, Password, bookingId);

                Array cancelarr = booking.extraSeatInfoList;
                foreach (ExtraSeatInfoDTO Cdesc in cancelarr)
                {
                    DataRow row = data.NewRow();
                    row["bookingId"] = bookingId;
                    row["extraSeatInfo"] = Cdesc.extraSeatInfo;
                    row["seatNbr"] = Cdesc.seatNbr;
                    row["travelsPhoneNbr"] = booking.travelsPhoneNbr;
                    row["Status"] = booking.status.message.ToString();
                    Array ac = booking.cancellationDescList;
                    row["cancellationDescList"] = ac.ToString();
                    data.Rows.Add(row);
                }
                o.Close();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CancelTicket(string bookingId, String[] SeatNo)
        {
            try
            {
                TGTravelServiceClient o = new TGTravelServiceClient();
                o.Open();
                DataTable data = new DataTable();
                data.Columns.Add("cancellationCharge");
                data.Columns.Add("seatFare");
                data.Columns.Add("seatNbr");
                data.Columns.Add("Status");

                CancellationChargeDetails CTicket = o.cancelTicket(UserId, Password, bookingId, SeatNo);
                foreach (CancellationChargeDetailsDTO CT in CTicket.cancellationChargeDetailsList)
                {
                    if (CTicket.status.message.ToString() == "Success")
                    {
                        DataRow row = data.NewRow();
                        row["cancellationCharge"] = CT.cancellationCharge;
                        row["seatFare"] = CT.seatFare;
                        row["seatNbr"] = CT.seatNbr;
                        row["Status"] = CTicket.status.message.ToString();
                        data.Rows.Add(row);
                    }
                }
                o.Close();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ConfirmTicketCancellation(string bookingId, String[] SeatNo)
        {
            try
            {
                TGTravelServiceClient o = new TGTravelServiceClient();
                o.Open();
                DataTable data = new DataTable();
                data.Columns.Add("Status");
                data.Columns.Add("refundAmount");
                CancellationDetails CDetails = o.confirmTicketCancellation(UserId, Password, bookingId, SeatNo);
                DataRow row = data.NewRow();
                if (CDetails.status.message.ToString() == "Success")
                {
                    row["refundAmount"] = CDetails.refundAmount;
                    row["Status"] = CDetails.status.message;
                    data.Rows.Add(row);
                }
                o.Close();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
