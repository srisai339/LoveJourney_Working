<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="PanCard.aspx.cs" Inherits="Agent_Bus_PanCard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link href="../../css/chromestyle_New.css" rel="stylesheet" type="text/css" />
    <table width="800" class="container" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="100%" height="30px" valign="middle" align="center" class="tr" id="tdmsg"
                runat="server" visible="false"  >
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="tdmob" runat="server">
                <table width="800" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="center">
                            <!--contentTabs-->
                            <table width="850" border="0" cellspacing="0" cellpadding="0">
                            <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="../../images/formtop_left.png" /></td>
    <td class="form_top" width="395">&nbsp;</td>
    <td align="left" valign="bottom" width="29" height="23"><img src="../../images/formright_top.png" /></td>
  </tr>
                                <tr>
                                 <td class="form_left">&nbsp;</td>
                                    <!--CLEFT-->
                                <td width="500" align="left" bgcolor="#ffffff" valign="top">
                                <table>
                                <tr>
                                <td align="center" width="500">
             <table >
             <tr>
             <td style="font-weight:bold;font-size:18px;" valign="top"  class="online_booking" height="70px">
             <div id="chromemenu1" class="panchromestyle">
            <ul>
                                                                        <li><a href="#" rel="dropmenu2">
                                                                            
                                                                           Pancard</a></li>
                                                                    </ul>
                                                                    <script type="text/javascript">

                                                                        cssdropdown.startchrome("chromemenu1")

                                                                    </script>
                                                                    </div>
                                                                     
                                                                    </td>
             </tr>
             
             </table>
                                </td>
                                </tr>
                                <tr>
                                <td align="left" style="padding-left:25px;" valign="top">
                               
                                  <li>  <a href="../../Downloads/CSF.pdf" target="_blank">Change Request Application</a> </li>
                                <br />
                                                                       <li> <a href="../../Downloads/Form 49AA.pdf" target="_blank">New PAN Application ( for NRI F49AA)</a> </li>
                                                                        <br />
                                                                        <li>    <a href="../../Downloads/Form 49A.pdf" target="_blank">New PAN Application(for Indian Resident F49A)</a> </li>
                                                                         </td>
                                </tr>
                                </table>
                                </td>
                                     <td class="form_right">&nbsp;</td>
                                    <!--CLEFTend-->
                                    <td width="450" valign="middle" align="right">
                                       <%-- <img src="../../images/recharge_image.jpg" width="350" height="350" />--%>
                                       <table width="340" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="link_rt" valign="top">
    
    
    <table width="320" border="0" cellspacing="0" cellpadding="0">
  
  <tr>
    <td colspan="3" height="10"></td>
   
  </tr>
  <tr>
    <td align="center"><a href="../Flight/frmDomesticAvailability.aspx" target="_blank"><img src="../../img/flight.png" width="86" height="76"  /></a></td>
    <td align="center"><a href="../Hotel/HotelSearch.aspx" target="_blank"><img src="../../img/hotel.png" width="86" height="76"  /></a></td>
    <td align="center"><a href="../Bus/Default.aspx" target="_blank"><img src="../../img/bus.png" width="86" height="76"  /></a></td>
  </tr>
  <tr>
    <td align="center" class="flights"><a href="../Flight/frmDomesticAvailability.aspx" target="_blank">Flights</a></td>
    <td align="center" class="flights"><a href="../Hotel/HotelSearch.aspx" target="_blank">Hotels</a></td>
    <td align="center" class="flights"><a href="../Bus/Default.aspx" target="_blank">Bus</a></td>
  </tr>
  
  <tr>
    <td colspan="3" height="10"></td>
   
  </tr>
  <tr>
    <td align="center"><img src="../../img/TRAIN.png" width="86" height="76"  /></td>
    <td align="center"><a href="Recharge.aspx" target="_blank"><img src="../../img/RECHARGE.png" width="86" height="76"  /></a></td>
    <td align="center"><img src="../../img/TICKET.png" width="86" height="76"  /></td>
  </tr>
  <tr>
    <td align="center" class="flights">Train</td>
    <td align="center" class="flights"><a href="Recharge.aspx" target="_blank">Recharge</a></td>
    <td align="center" class="flights">Tickets</td>
  </tr>
  
  
  <tr>
    <td colspan="3" height="10"></td>
   
  </tr>
  <tr>
    <td align="center"><img src="../../img/CAR.png" width="86" height="76"  /></td>
    <td align="center"><img src="../../img/UTILITIES.png" width="86" height="76"  /></td>
    <td align="center"><img src="../../img/DMR.png" width="86" height="76"  /></td>
  </tr>
  <tr>
    <td align="center" class="flights">Car</td>
    <td align="center" class="flights">Utilities</td>
    <td align="center" class="flights">Dmr</td>
  </tr>
 

  
</table>

    
    
    </td>
  </tr>
</table>
                                    </td>
                                   
                                </tr>
                                <tr>
    <td align="center" valign="top" width="24" height="32"><img src="../../images/formbottom_left.png" /></td>
    <td class="form_bottom">&nbsp;</td>
    <td align="left" valign="top" width="29" height="32"><img src="../../images/formright_bottom.png" /></td>
  </tr>
                            </table>
                            <!--contentTabsEnd-->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <table>
                    <tr>
                        <td style="display: none">
                            <asp:Button ID="OpenID12" runat="server" Text="OK" />
                        </td>
                    </tr>
                    <tr>
                        <td style="display: none">
                            <asp:Button ID="OpenID14" runat="server" Text="OK" />
                        </td>
                    </tr>
                    <tr>
                        <td style="display: none">
                            <asp:Button ID="btnOpenID1" runat="server" Text="OK" />
                        </td>
                    </tr>
                    <tr>
                        <td style="display: none">
                            <asp:Button ID="OpenID" runat="server" Text="OK" />
                        </td>
                    </tr>
                    <tr>
                        <td style="display: none">
                            <asp:Button ID="popular" runat="server" Text="OK" />
                        </td>
                    </tr>
                     
                    <tr>
                        <td style="display: none">
                            <asp:Button ID="OpenID9" runat="server" Text="OK" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>

