<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="OfficePickUp.aspx.cs" Inherits="Users_OfficePickUp"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ExportGridviewtoExcel() {
            __doPostBack("<%=lbtnXport2Xcel.UniqueID %>", '');
        }</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                        runat="server" visible="false">
                        <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:MultiView ID="MVOficePickup" runat="server">
                <asp:View ID="VwSearch" runat="server">
                    <asp:Panel ID="pnlCusEnquiryReports" runat="server" Width="100%">
                        <center>
                            <table width="100%">
                                <tr>
                                    <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                        font-weight: bold; color: Maroon;">
                                        Office Pickup Tickets
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80%" align="center">
                                        <table width="80%" cellpadding="0" cellspacing="0" style="line-height: 30px;">
                                            <tr>
                                                <td width="15%" align="left">
                                                    From
                                                </td>
                                                <td width="35%" align="left">
                                                    <asp:TextBox ID="txtFrom" runat="server" CssClass="textfield_2" />
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                                        Format="yyyy-MM-dd" PopupButtonID="ImageButton1" TargetControlID="txtFrom" CssClass="cal_Theme1">
                                                    </ajax:CalendarExtender>
                                                </td>
                                                <td width="15%" align="left">
                                                    To
                                                </td>
                                                <td width="35%" align="left">
                                                    <asp:TextBox ID="txtto" runat="server" CssClass="textfield_2" /><asp:ImageButton
                                                        ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" FirstDayOfWeek="Sunday"
                                                        Format="yyyy-MM-dd" TargetControlID="txtto" PopupButtonID="ImageButton2" CssClass="cal_Theme1">
                                                    </ajax:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" align="left" valign="top">
                                                    Date Filter
                                                </td>
                                                <td width="35%" align="left" valign="top">
                                                    <asp:DropDownList ID="ddlDatefilter" runat="server" CssClass="Dropdownlist">
                                                        <asp:ListItem Text="ALL" />
                                                        <asp:ListItem Text="Date Of Issue" Selected="True" />
                                                        <asp:ListItem Text="Date Of Journey" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="15%" align="left" valign="top">
                                                    Location
                                                </td>
                                                <td width="35%" align="left" valign="top">
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Dropdownlist">
                                                        <asp:ListItem Text="ALL" />
                                                        <asp:ListItem Text="HYDERABAD" />
                                                        <asp:ListItem Text="BANGALORE" />
                                                        <asp:ListItem Text="THRISSUR" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" align="left" valign="top">
                                                    Delivery Status
                                                </td>
                                                <td width="35%" align="left" valign="top">
                                                    <asp:DropDownList ID="ddlOfficeDeliveryStatus" runat="server" CssClass="Dropdownlist">
                                                        <asp:ListItem Text="ALL" />
                                                        <asp:ListItem Text="InProgress" />
                                                        <asp:ListItem Text="Delivered" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="15%" align="left" valign="top">
                                                    <%--Payment Status--%>
                                                </td>
                                                <td width="35%" align="left" valign="top">
                                                    <asp:Button ID="btnsearch" Text="Search" runat="server" CssClass="buttonBook"
                                                        OnClick="btnsearch_Click" OnClientClick="showDiv();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                            style="display: none" class="modalContainer">
                                            <div class="registerhead">
                                                <img src="../images/loading.gif" width="150" height="150" alt="Loading" />
                                            </div>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table width="100%">
                                            <tr>
                                                <td width="50%" align="left" valign="top">
                                                    Select Page size&nbsp;:&nbsp;
                                                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="Dropdownlist "
                                                        Width="100px">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <asp:ListItem Text="10" Value="1" />
                                                        <asp:ListItem Text="20" Value="2" />
                                                        <asp:ListItem Text="30" Value="3" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50%" align="right">
                                                    <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClientClick="ExportGridviewtoExcel();"
                                                        OnClick="lbtnXport2Xcel_Click1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="center">
                                        <asp:GridView ID="Gvofficepckup" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                            Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                            CellPadding="3" EnableModelValidation="True" EmptyDataText="No officepickup tickets Records"
                                            OnPageIndexChanging="Gvofficepckup_PageIndexChanging" OnSorting="Gvofficepckup_Sorting"
                                            OnRowCommand="Gvofficepckup_RowCommand" OnRowDataBound="Gvofficepckup_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="BookingId" SortExpression="BookingId" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingId" Text='<%#Eval("BookingId") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Route" SortExpression="Route">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoute" Text='<%#Eval("Route") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LoveJourney Ref No" SortExpression="OnewayMBRefNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblManabusRefNo" Text='<%#Eval("OnewayMBRefNo") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Travels" SortExpression="TravelOPName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTravels" Text='<%#Eval("TravelOPName") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Travel Date" SortExpression="DateOfJourney">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltravelDate" Text='<%#Eval("DateOfJourney") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Issued Date" SortExpression="DateOfBooking">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTimeelasped" Text='<%#Eval("DateOfBooking") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount" SortExpression="TotalFare">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalFre" Text='<%#Eval("TotalFare") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" Text='<%#Eval("FullName") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact" SortExpression="ContactNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContact" Text='<%#Eval("ContactNo") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Fare" SortExpression="TotalFare" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalFare" Text='<%#Eval("TotalFare") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CSE Person" SortExpression="UserName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCSEPerson" Text='<%#Eval("UserName") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="DeliveryStatus">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDeliveryStatus" Text='<%#Eval("DeliveryStatus") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Actions">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnView" Text="View" runat="server" CssClass="selectseats_input"
                                                            CommandName="View" CommandArgument='<%#Eval("BookingId") %>' OnClientClick="showDiv();" />
                                                        <asp:Button ID="btnUpdate" Text="Pay Info" runat="server" CssClass="selectseats_input"
                                                            CommandName="PayInfoUpdate" CommandArgument='<%#Eval("BookingId") %>' OnClientClick="showDiv();" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px"
                                                HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" Height="25px" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="25px"
                                                HorizontalAlign="Center" />
                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                                                Height="25px" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="vwView" runat="server">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" align="center">
                                <table width="880" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center">
                                            <table width="900" align="center">
                                                <tr>
                                                    <td width="523" align="left">
                                                        <span class="actions">
                                                            <asp:LinkButton ID="lbtnback" Text="Back" runat="server" OnClick="lbtnback_Click"
                                                                OnClientClick="showDiv();" /></span>
                                                    </td>
                                                    <td width="115" align="right">
                                                        <asp:LinkButton ID="lbtnmail" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
                                                            onclick="printPage('printdiv');" target="_blank">Print</a></span>
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
                                                                <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td align="left" width="300" height="96" valign="top">
                                                                            <img src="http://lovejourney.in/Newimages/New_Logo.png" width="143" height="88" border="0" title="Mana Bus" />&nbsp;&nbsp;
                                                                            <asp:Image ID="imgKesineni" runat="server" ImageUrl="http://lovejourney.in/images/kesineni-Logo.jpg"
                                                                                Width="100" Height="88" Visible="false" />
                                                                        </td>
                                                                        <td align="right">
                                                                            <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="40" align="left">
                                                                                        <img src="http://lovejourney.in/images/cal_icon.png" width="30" height="30" />
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <b>040-30404444</b>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="40" align="left">
                                                                                        <img src="http://lovejourney.in/images/mail.png" width="30" height="30" />
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <a href="#">support@LoveJourney.in</a>
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
                                                                <b>Note :</b> To initiate your journey, please present your itinerary receipt or
                                                                E-Ticket.
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
                                                                                                        <b class="man_hd">LoveJourney Reference Number :</b>&nbsp;
                                                                                                        <asp:Label ID="lblManabusRefNo" runat="server" Text='<%#Eval("OnewayMBRefNo") %>' />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td align="left" height="20" width="15%">
                                                                                                                    <b>Journey Date</b>
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <asp:Label ID="lblDOJ" Text='<%#Eval("DateOfJourney") %>' runat="server" />
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <b>Service No</b>
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <asp:Label ID="lblTravelOpPNR" Text='<%#Eval("ServiceNumber") %>' runat="server" />
                                                                                                                </td>
                                                                                                                <td align="left" width="10%">
                                                                                                                    <b>PNR Number</b>
                                                                                                                </td>
                                                                                                                <td width="30%" align="left">
                                                                                                                    <asp:Label ID="lblTicketId" runat="server" Text='<%#Eval("PNRNumber") %>' />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" height="20" width="15%">
                                                                                                                    <b>From </b>
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <asp:Label ID="lblSourceName" runat="server" Text='<%#Eval("SourceName") %>' />
                                                                                                                </td>
                                                                                                                <td align="left" width="15%">
                                                                                                                    <b>To </b>
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <asp:Label ID="lblDestinationName" runat="server" Text='<%#Eval("DestinationName") %>' />
                                                                                                                </td>
                                                                                                                <td align="left" width="10%">
                                                                                                                    <b>Travels</b>
                                                                                                                </td>
                                                                                                                <td width="30%" align="left">
                                                                                                                    <asp:Label ID="lblTravelName" runat="server" Text='<%#Eval("TravelOPName") %>' />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" height="25">
                                                                                                        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td width="50%">
                                                                                                                    <b>Coach</b>
                                                                                                                    <asp:Label ID="lblBusType" runat="server" Text='<%#Eval("BusType") %>' />
                                                                                                                </td>
                                                                                                                <td width="50%">
                                                                                                                    <b>Boarding Point :</b>
                                                                                                                    <asp:Label ID="lblBordingTime" runat="server" Text='<%#Eval("BoardingPointName") %>' />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" height="25">
                                                                                                        <b>Boarding Point Address :</b>
                                                                                                        <asp:Label ID="lblBoardingPoint" runat="server" Text='<%#Eval("BoardingInfo") %>' />
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
                                                                                                                                <b class="man_hd">Passenger Details :</b>
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
                                                                                                                                <b>Status</b>
                                                                                                                            </td>
                                                                                                                            <td width="82" align="left">
                                                                                                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("BStatus")%>'></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td width="93" align="left">
                                                                                                                                <b>Contact No</b>
                                                                                                                            </td>
                                                                                                                            <td width="93" align="left">
                                                                                                                                <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo ") %>'></asp:Label>
                                                                                                                                <asp:Label ID="lblEmailID" runat="server" Text='<%#Eval("EmailId ") %>' Visible="false"></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td width="81" align="left">
                                                                                                                                <b>Id Proof</b>
                                                                                                                            </td>
                                                                                                                            <td width="129" align="left">
                                                                                                                                <%#Eval("IDType ")%>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left" height="15">
                                                                                                                                <b>Id Number</b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <%#Eval("IDNumber ")%>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <b>Booked By </b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:Label ID="lblBookedBy" runat="server" Text='<%#Eval("FullName") %>' />
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <b>Booked On</b>
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
                                                                                                                                                <strong>Cancelled By</strong>
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <asp:Label ID="lblCancelledBY" runat="server" Text='<%#Eval("cancelledBy") %>' />
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <strong>Cancelled On </strong>
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("CancelledDate") %>' />
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <strong>Cash Coupon Issued</strong>
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("CancelCashCoupon") %>' />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                    </table>
                                                                                                                                </asp:Panel>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left" height="15">
                                                                                                                                <b><u>Amount</u></b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("TotalFare") %>' />
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <b><u>Others</u></b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                0.000
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <b><u>Total</u></b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("TotalFare") %>' />
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
                                                                                        <b class="man_hd">Cacnellation Policy :</b>
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
                                                                                    <HeaderStyle BackColor="#eeeeee" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
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
                                                                    <tr>
                                                                        <td>
                                                                            <table id="tblterms" border="0" cellpadding="0" cellspacing="0" style="display: none;">
                                                                                    <tr>
                                                                                        <td align="left" height="25">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="50%">
                                                                                                        <b class="man_hd">Terms & Conditions :</b>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="padding-left: 6px; padding-right: 6px">
                                                                                                        1. Lovejourney.in is ONLY a online ticket booking of buses, flights,hotels and recharge
                                                                                                        . It does not operate travel services of its own. In order to provide a comprehensive
                                                                                                        choice of travel operators, departure times and prices to customers, it has tied
                                                                                                        up with many travel operators.<br />
                                                                                                        lovejourney.in advices customers to choose travel operators they are aware of and
                                                                                                        whose service they are comfortable with.<br />
                                                                                                        <br />
                                                                                                        <span class="Paragraph"><strong>lovejourney.in responsibilities include:</strong></span><br />
                                                                                                        . Issuing a valid ticket (a ticket that will be accepted by the travel operator)
                                                                                                        for its' network of travel operators<br />
                                                                                                        . Providing refund and support in the event of cancellation<br />
                                                                                                        . Providing customer support and information in case of any delays / inconvenience<br />
                                                                                                        <br />
                                                                                                        <span class="Paragraph"><strong>lovejourney.in responsibilities do NOT include:</strong></span><br />
                                                                                                        . The travel operator's bus not departing / reaching on time<br />
                                                                                                        . The travel operator's employees being rude<br />
                                                                                                        . The travel operator's bus seats etc not being up to the customer's expectation<br />
                                                                                                        . The travel operator canceling the trip due to unavoidable reasons<br />
                                                                                                        . The baggage of the customer getting lost / stolen / damaged<br />
                                                                                                        . The travel operator changing a customer's seat at the last minute to accommodate
                                                                                                        a lady / child<br />
                                                                                                        . The customer waiting at the wrong boarding point (please call the bus operator
                                                                                                        to find out the exact boarding point if you are not a regular traveller on that
                                                                                                        particular bus)<br />
                                                                                                        . The travel operator changing the boarding point and/or using a pick-up vehicle
                                                                                                        at the boarding point to take customers to the bus departure point<br />
                                                                                                        2.The departure time mentioned on the ticket are only tentative timings. However
                                                                                                        the bus will not leave the source before the time that is mentioned on the ticket.<br />
                                                                                                        3. Passengers are required to furnish the following at the time of boarding the
                                                                                                        bus:<br />
                                                                                                        A copy of the ticket (A print out of the ticket or the print out of the ticket e-mail).
                                                                                                        <br />
                                                                                                        A valid identity proof
                                                                                                        <br />
                                                                                                        Failing to do so, they may not be allowed to board the bus.<br />
                                                                                                        4. Change of bus: In case the bus operator changes the type of bus due to some reason,
                                                                                                        lovejourney.in will refund the differential amount to the customer upon being intimated
                                                                                                        by the customers in 24 hours of the journey.<br />
                                                                                                        5. This ticket is not cancellable.<br />
                                                                                                        6. In case one needs the refund to be credited back to his/her bank account, please
                                                                                                        write your cash coupon details to info@lovejourney.in<br />
                                                                                                        * The home delivery charges (if any), will not be refunded in the event of ticket
                                                                                                        cancellation<br />
                                                                                                        7. In case a booking confirmation e-mail and sms gets delayed or fails because of
                                                                                                        technical reasons or as a result of incorrect e-mail ID / phone number provided
                                                                                                        by the user etc, a ticket will be considered 'booked' as long as the ticket shows
                                                                                                        up on the confirmation page of www.lovejourney.in<br />
                                                                                                        For any queries call at : 080-32561727,25220265 .<br />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="5">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                    </tr>
                                    <tr>
                                        <td width="900" align="center">
                                            <table width="900" align="center">
                                                <tr>
                                                    <td width="523">
                                                    </td>
                                                    <td width="115" align="right">
                                                        <span class="actions">
                                                            <asp:LinkButton ID="lbtnMaild" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
                                                                onclick="printPage('printdiv');" target="_blank">Print</a></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:GridView ID="gvDetails" AutoGenerateColumns="False" Width="60%" runat="server"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3" EnableModelValidation="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Ticket Details">
                                            <ItemTemplate>
                                                <table width="100%" style="line-height: 20px;">
                                                    <%--  <tr>
                                                        <td width="25%" align="left">
                                                            Manabus Ref No&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <strong>
                                                                <%#Eval("OnewayMBRefNo")%></strong>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            API Name&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("APIName")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            PNR Number&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("PNRNumber")%>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            Ticket Numnber&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("TicketNumber")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left" colspan="4">
                                                            Route&nbsp;&nbsp:&nbsp; <strong>
                                                                <%#Eval("Route")%></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            Date of Journey&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <strong>
                                                                <%#Eval("DateOfJourney")%></strong>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            Travel Name&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("TravelOPName")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            Date of Booking&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("DateOfBooking")%>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            Bustype&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("BusType")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            Total Fare&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("TotalFare")%>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            Seat Nos&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("SeatNos")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%" align="left" colspan="1">
                                                            BoardingPoint&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="50%" align="left" colspan="3">
                                                            <%#Eval("BoardingPointName")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%" align="left" colspan="1">
                                                            BoardingPoint Info&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="50%" align="left" colspan="3">
                                                            <%#Eval("BoardingInfo")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100%" colspan="4" align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            <strong>Personal Deatils</strong>&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                        </td>
                                                        <td width="25%" align="left">
                                                        </td>
                                                        <td width="25%" align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            Name&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("FullName")%>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            Email ID&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("EmailId")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            Contact No&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("ContactNo")%>
                                                        </td>
                                                        <td width="25%" align="left">
                                                        </td>
                                                        <td width="25%" align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100%" colspan="4" align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            <strong>Booking Deatils</strong>&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                        </td>
                                                        <td width="25%" align="left">
                                                        </td>
                                                        <td width="25%" align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            Payment Type&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("PaymentType")%>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            Delivery Type&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("DeliveryType")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            Coupon No&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("CouponNo")%>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            Delivery Status
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("DeliveryStatus")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="left">
                                                            Delivered By&nbsp;&nbsp:&nbsp;
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("DeliveredBy")%>
                                                        </td>
                                                        <td width="25%" align="left">
                                                            Amount Recieved By
                                                        </td>
                                                        <td width="25%" align="left">
                                                            <%#Eval("AmountRecievedBy")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
            <div style="text-align: left; display: none;">
                <asp:Button ID="openID" runat="server" Height="1px" Width="1px" /></div>
            <ajax:ModalPopupExtender ID="MPEUpdate" TargetControlID="openID" PopupControlID="Panel1"
                runat="server" BackgroundCssClass="loadingBackground" OkControlID="ImgClosepopup"
                DropShadow="false" Drag="false" X="450" Y="300" />
            <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="400" Style="display: none;
                color: Black;">
                <table width="400" cellpadding="0" cellspacing="0" style="line-height: 30px;">
                    <tr style="background-color: #006699; color: White;">
                        <td width="50%" align="left">
                            Update Delivery Status
                        </td>
                        <td width="50%" align="right">
                            <asp:Image ID="ImgClosepopup" runat="server" ImageUrl="~/images/CloseSeatLayout.png" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right" style="padding-right: 80px;">
                            Status
                        </td>
                        <td width="50%" align="left">
                            <asp:DropDownList ID="ddlDeliveryStatus" runat="server" CssClass="Dropdownlist">
                                <asp:ListItem Text="InProgress" Value="0" />
                                <asp:ListItem Text="Delivered" Value="1" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right" style="padding-right: 50px;">
                            Delivered By
                        </td>
                        <td width="50%" align="left">
                            <asp:TextBox ID="txtdeliveredBy" runat="server" MaxLength="50" CssClass="textfield_2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvdeliveredBy" ErrorMessage="*" runat="server" ControlToValidate="txtdeliveredBy"
                                ValidationGroup="Update"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right" style="padding-right: 10px;">
                            Money Collected BY
                        </td>
                        <td width="50%" align="left">
                            <asp:TextBox ID="txtMnyCollectedBY" runat="server" MaxLength="50" CssClass="textfield_2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" runat="server"
                                ControlToValidate="txtMnyCollectedBY" ValidationGroup="Update"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                        </td>
                        <td width="50%" align="left">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update"
                                CssClass="selectseats_input2" ValidationGroup="Update" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                CssClass="selectseats_input2" CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div style="text-align: left; display: none;">
                <asp:Button ID="openID1" runat="server" Height="1px" Width="1px" /></div>
            <ajax:ModalPopupExtender ID="MPEMail" TargetControlID="openID1" PopupControlID="Panel2"
                runat="server" BackgroundCssClass="loadingBackground" OkControlID="imgclose"
                DropShadow="false" Drag="false" X="450" Y="300" />
            <asp:Panel ID="Panel2" runat="server" BackColor="White" Width="400" Style="display: none;
                color: Black; border: 1px solid #006699">
                <table width="400" style="line-height: 30px;" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="40%" align="left" style="background-color: #006699; color: White; font-family: 'Comic Sans MS';
                            font-size: 14px;">
                            Email - Ticket
                        </td>
                        <td width="60%" align="right" style="background-color: #006699; color: White; font-family: 'Comic Sans MS';
                            font-size: 14px;">
                            <asp:Image ID="imgclose" runat="server" ImageUrl="../images/CloseSeatLayout.png" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right" style="padding-right: 80px;">
                            Email ID
                        </td>
                        <td width="60%" align="left">
                            <asp:TextBox ID="txtEmailTo" runat="server" CssClass="textfield_2" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmailTo" runat="server" ControlToValidate="txtEmailTo"
                                ErrorMessage="*" ValidationGroup="Email" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmailTo" runat="server" ControlToValidate="txtEmailTo"
                                ErrorMessage="Invalid" ValidationGroup="Email" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="center">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
                                <ProgressTemplate>
                                    <img src="../images/loaderb16.gif" width="20px" height="20px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <td width="60%" align="left">
                            <asp:Button ID="btnEmail" runat="server" Text="Send Mail" CssClass="selectseats_input2"
                                ValidationGroup="Email" OnClick="btnEmail_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnCancelEmail" runat="server" Text="Cancel" CssClass="selectseats_input2"
                                CausesValidation="false" OnClick="btnCancelEmail_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
