<%@ Page Language="C#" AutoEventWireup="true" CodeFile="redirectbus.aspx.cs" Inherits="redirectbus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function printPage(id) {
            var html = "<html>";

            html += document.getElementById(id).innerHTML;
            html += "</html>";

            var printWin = window.open('', '', 'left=0,top=0,toolbar=0,scrollbars=0,status  =0');
            printWin.document.write(html);
            printWin.document.close();
            printWin.focus();
            printWin.print();
            //printWin.close();

        }
    </script>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top" align="center">
                <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="printmail" runat="server">
                        <td width="900" align="center">
                            <table width="900" align="center">
                                <tr>
                                    <td width="523" align="left">
                                        <asp:LinkButton ID="lnknbck" runat="server" Text="Go to Home" CausesValidation="false"
                                            PostBackUrl="~/Default.aspx"></asp:LinkButton>
                                    </td>
                                    <td width="115" align="right">
                                        <span class="actions"><a onclick="printPage('printdiv');" target="_blank" class="et_srch">
                                            Print</a></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="900" align="center">
                            <asp:Panel ID="pnlmail" Width="900" runat="server">
                                <div id="printdiv" style="float: left;">
                                    <table width="900" cellspacing="0" cellpadding="0" border="1px solid black;">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top" align="center">
                                                            <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="900" align="center">
                                                                        <table width="900" cellspacing="0" cellpadding="0" border="1px solid black;">
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td align="left" width="300" height="96" valign="top">
                                                                                                <img src="http://lovejourney.in/Newimages/New_Logo.png" width="249" height="100"
                                                                                                    border="0" title="" />&nbsp;&nbsp;
                                                                                                <asp:Image ID="Image1" runat="server" Visible="false" />
                                                                                            </td>
                                                                                            <td align="right" valign="top">
                                                                                                <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td width="40" align="left">
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="40" align="left">
                                                                                                            <%--<img src="http://lovejourney.in/images/mail.png" width="30" height="30" />--%>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <a href="#">info@lovejourney.in</a>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="1" bgcolor="#979595">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" height="17">
                                                                                    Note: To initiate your journey, please present your itinerary receipt or e-ticket.
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" height="17">
                                                                                    Waiting list is not a confirmed ticket. Wait listed passengers are requested to
                                                                                    check for their ticket confirmation with our helpline.
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="1" bgcolor="#979595">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="5">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:GridView ID="gvView" runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                                                                    AllowSorting="false" PageSize="1" ShowHeader="false" ShowFooter="false" OnRowDataBound="gvView_RowDataBound">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                                                                            <ItemTemplate>
                                                                                                                <table width="900" border="0" cellspacing="0" cellpadding="0" class="ticket_bdr">
                                                                                                                    <tr>
                                                                                                                        <td align="left" height="26" valign="top">
                                                                                                                            lovejourney Ref No: &nbsp;
                                                                                                                            <asp:Label ID="lblTicketRefNo" runat="server" Text='<%#Eval("OnewayMBRefNo") %>' />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                <tr>
                                                                                                                                    <td align="left" height="20" width="10%">
                                                                                                                                        Journey Date:
                                                                                                                                    </td>
                                                                                                                                    <td width="20%" align="left">
                                                                                                                                        <asp:Label ID="lblDOJ" Text='<%#Eval("DateOfJourney") %>' runat="server" />
                                                                                                                                    </td>
                                                                                                                                    <td width="10%" align="left">
                                                                                                                                        PNR No:
                                                                                                                                    </td>
                                                                                                                                    <td width="20%" align="left">
                                                                                                                                        <asp:Label ID="lblTicketId" runat="server" Text='<%#Eval("PNRNumber") %>' />
                                                                                                                                    </td>
                                                                                                                                    <td align="left" width="10%">
                                                                                                                                    </td>
                                                                                                                                    <td width="30%" align="left">
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td align="left" height="20" width="10%">
                                                                                                                                        From:
                                                                                                                                    </td>
                                                                                                                                    <td width="20%" align="left">
                                                                                                                                        <asp:Label ID="lblSourceName" runat="server" Text='<%#Eval("SourceName") %>' />
                                                                                                                                    </td>
                                                                                                                                    <td align="left" width="10%">
                                                                                                                                        To:
                                                                                                                                    </td>
                                                                                                                                    <td width="20%" align="left">
                                                                                                                                        <asp:Label ID="lblDestinationName" runat="server" Text='<%#Eval("DestinationName") %>' />
                                                                                                                                    </td>
                                                                                                                                    <td align="left" width="10%">
                                                                                                                                        Travels:
                                                                                                                                    </td>
                                                                                                                                    <td width="30%" align="left">
                                                                                                                                        <asp:Label ID="lblTravelName" runat="server" Text='<%#Eval("TravelOPName") %>' />
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td align="left" height="20" width="10%">
                                                                                                                                        Coach:
                                                                                                                                    </td>
                                                                                                                                    <td width="40%" align="left" colspan="2">
                                                                                                                                        <asp:Label ID="lblBusType" runat="server" Text='<%#Eval("BusType") %>' />
                                                                                                                                    </td>
                                                                                                                                    <td align="left" width="10%">
                                                                                                                                        Boarding Point:
                                                                                                                                    </td>
                                                                                                                                    <td width="40%" align="left" colspan="2">
                                                                                                                                        <asp:Label ID="lblBordingTime" runat="server" Text='<%#Eval("BoardingPointName") %>' />
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td colspan="4" align="left">
                                                                                                                                        Boarding Point Address:
                                                                                                                                        <asp:Label ID="lblBoardingPoint" runat="server" Text='<%#Eval("BoardingInfo") %>' />
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td height="1" bgcolor="#000">
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                <tr>
                                                                                                                                    <td align="left" valign="top">
                                                                                                                                        <table border="0" cellspacing="0" cellpadding="0">
                                                                                                                                            <tr>
                                                                                                                                                <td align="left" height="20">
                                                                                                                                                    Passenger Details:
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td align="left">
                                                                                                                                                    <asp:Label ID="lblPassengerDetails" runat="server" Text='<%#Eval("PassengerDetails") %>'
                                                                                                                                                        BackColor="White"></asp:Label>
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                        </table>
                                                                                                                                    </td>
                                                                                                                                    <td align="center">
                                                                                                                                        <table width="580" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                            <tr>
                                                                                                                                                <td width="82" align="left" height="15">
                                                                                                                                                    Status:
                                                                                                                                                </td>
                                                                                                                                                <td width="82" align="left">
                                                                                                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("BStatus")%>'></asp:Label>
                                                                                                                                                </td>
                                                                                                                                                <td width="93" align="left">
                                                                                                                                                    Contact No:
                                                                                                                                                </td>
                                                                                                                                                <td width="93" align="left">
                                                                                                                                                    <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo ") %>'></asp:Label>
                                                                                                                                                </td>
                                                                                                                                                <td width="81" align="left">
                                                                                                                                                    Id Proof:
                                                                                                                                                </td>
                                                                                                                                                <td width="129" align="left">
                                                                                                                                                    <%#Eval("IDType ")%>
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td align="left" height="15">
                                                                                                                                                    Id Number:
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                    <%#Eval("IDNumber ")%>
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                    Booked By:
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                    <asp:Label ID="lblBookedBy" runat="server" Text='<%#Eval("FullName") %>' />
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                    Booked On:
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("DateOfBooking") %>' />
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td colspan="6">
                                                                                                                                                    <asp:Panel ID="pnlCancellationDetails" runat="server" Width="100%" Visible="false">
                                                                                                                                                        <table width="100%">
                                                                                                                                                            <tr>
                                                                                                                                                                <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                                    Cancelled By:
                                                                                                                                                                </td>
                                                                                                                                                                <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                                    <asp:Label ID="lblCancelledBY" runat="server" Text='<%# Eval("cancelledBy") %>' />
                                                                                                                                                                </td>
                                                                                                                                                                <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                                    Cancelled On:
                                                                                                                                                                </td>
                                                                                                                                                                <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("CancelledDate") %>' />
                                                                                                                                                                </td>
                                                                                                                                                                <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                                    Cash Coupon Issued:
                                                                                                                                                                </td>
                                                                                                                                                                <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("CancelCashCoupon") %>' />
                                                                                                                                                                </td>
                                                                                                                                                            </tr>
                                                                                                                                                        </table>
                                                                                                                                                    </asp:Panel>
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td align="left" height="15">
                                                                                                                                                    Amount:
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("TotalFare") %>' />
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                    Others:
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                  <asp:Label ID="Label25" runat="server" Text='<%# Eval("Markup") %>' />
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                    Total:
                                                                                                                                                </td>
                                                                                                                                                <td align="left">
                                                                                                                                                   <asp:Label ID="Label5" runat="server" Text='<%# Eval("TotalWithMarkPrice") %>' />
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                        </table>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td height="8">
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td height="1" bgcolor="#000">
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" height="25">
                                                                                                <table width="100%">
                                                                                                    <tr>
                                                                                                        <td width="50%">
                                                                                                            Cacnellation Policy:
                                                                                                        </td>
                                                                                                        <td width="50%">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td width="100%" align="center">
                                                                                                <asp:Panel ID="Panel10" runat="server">
                                                                                                    <asp:GridView ID="gvCancellationDetails" runat="server" AutoGenerateColumns="False"
                                                                                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                                                                        CellPadding="3" EnableModelValidation="True" Width="100%" EmptyDataText="No cancellation Policy Updated">
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField HeaderText="Cancellation Time">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblBeforeTime" runat="server" Text='<%# Eval("BeforeTime") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Cancellation Percentage (%)">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblPercentage" runat="server" Text='<%# Eval("CancePercentage") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                        <HeaderStyle BackColor="#eeeeee" Font-Bold="false" ForeColor="Black" HorizontalAlign="Left" />
                                                                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                        <RowStyle ForeColor="Black" HorizontalAlign="Left" BackColor="White" />
                                                                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                    </asp:GridView>
                                                                                                </asp:Panel>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="1" bgcolor="#000">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
