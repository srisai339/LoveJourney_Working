<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="CustomerEnquiry.aspx.cs" Inherits="Users_CustomerEnquiry" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ExportGridviewtoExcel() {
            __doPostBack("<%=lbtnXport2Xcel.UniqueID %>", '');
        }
        function Adddob() {
            //alert('hi');
            document.getElementById('<%=txtfromdate.ClientID %>').value = "";

        }
        function Adddob1() {
            //alert('hi');
            document.getElementById('<%=txttodate.ClientID %>').value = "";

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--   <asp:UpdatePanel ID="upcusenqiury" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
        <ContentTemplate>--%>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td bgcolor="#ffffff" height="450" valign="top">
                <table width="100%">
                    <tr>
                        <td class="heading" align="center">
                            Booking Reports
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                            runat="server" visible="false">
                            <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:MultiView ID="MVCusEnquiry" runat="server">
                    <asp:View ID="VWSearchCusEnquiry" runat="server">
                        <asp:Panel ID="pnlCusEnquiryReports" runat="server" Width="100%">
                            <center>
                                <table width="100%">
                                    <tr>
                                        <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                            font-weight: bold; color: Maroon;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="80%" align="center">
                                            <table width="80%">
                                                <tr id="source" runat="server" visible="false">
                                                    <td width="15%" align="left">
                                                        Source
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:DropDownList ID="ddlSources" runat="server" CssClass="Dropdownlist">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="15%" align="left">
                                                        Destination
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:DropDownList ID="ddlDestinations" runat="server" CssClass="Dropdownlist">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" align="left">
                                                        <%--   Date of Journey--%>From Date
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:TextBox ID="txtfromdate" runat="server" onkeyup="javascript:Adddob();" CssClass="lj_inp" />
                                                        <asp:TextBox ID="txtDOJ" runat="server" Visible="false" />
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                                            Format="yyyy-MM-dd" TargetControlID="txtfromdate" PopupButtonID="ImageButton2">
                                                        </ajax:CalendarExtender>
                                                    </td>
                                                    <td width="15%" align="left">
                                                        <%--  Date of Issue--%>
                                                        To Date
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:TextBox ID="txttodate" runat="server" onkeyup="javascript:Adddob1();" CssClass="lj_inp" />
                                                        <asp:TextBox ID="txtDateOfIssue" runat="server" Visible="false" />
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" FirstDayOfWeek="Sunday"
                                                            Format="yyyy-MM-dd" TargetControlID="txttodate" PopupButtonID="ImageButton1">
                                                        </ajax:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Reference No
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtrefeenceno" runat="server" CssClass="lj_inp" />
                                                    </td>
                                                    <td align="left">
                                                        User Name
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="ddlagent" Width="150" runat="server" CssClass="lj_inp">
                                                        </asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="txtFrom_AutoCompleteExtender" runat="server" TargetControlID="ddlagent"
                                                            ServiceMethod="GetAgentNames" MinimumPrefixLength="1" CompletionInterval="10"
                                                            CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                            ServicePath="">
                                                        </ajax:AutoCompleteExtender>
                                                        <asp:DropDownList ID="ddlagent1" runat="server" Visible="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="source1" runat="server" visible="false">
                                                    <td width="15%" align="left">
                                                        Name
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="Textbox" />
                                                    </td>
                                                    <td width="15%" align="left">
                                                        Email ID
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:TextBox ID="txtEmailID" runat="server" CssClass="Textbox" />
                                                    </td>
                                                </tr>
                                                <tr id="source2" runat="server" visible="false">
                                                    <td width="15%" align="left">
                                                        LoveJourneyRefNo
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:TextBox ID="txtManabusRefNo" runat="server" CssClass="Textbox" />
                                                    </td>
                                                </tr>
                                                <tr id="source3" runat="server" visible="false">
                                                    <td width="15%" align="left">
                                                        Contact
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:TextBox ID="txtContact" runat="server" CssClass="Textbox" />
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789"
                                                            TargetControlID="txtContact">
                                                        </ajax:FilteredTextBoxExtender>
                                                    </td>
                                                    <td width="15%" align="left">
                                                        Status
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <span id="Span1" style="display: none" class="loadingBackground"></span><span id="Span2"
                                                            style="display: none" class="modalContainer">
                                                            <div class="registerhead">
                                                                <img src="../images/loading.gif" width="150" height="150" alt="Loading" />
                                                            </div>
                                                        </span>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="85px">
                                                            <asp:ListItem Selected="True">ALL</asp:ListItem>
                                                            <asp:ListItem>Booked</asp:ListItem>
                                                            <asp:ListItem>Cancelled</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="Tr1" runat="server" visible="true">
                                                    <td width="15%" align="left">
                                                        Page Size
                                                    </td>
                                                    <td width="35%" align="left">
                                                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="lj_inp"
                                                            Width="100px" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Enabled="false">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="40" Value="1" />
                                                            <asp:ListItem Text="80" Value="2" />
                                                            <asp:ListItem Text="120" Value="3" />
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="15%" align="left">
                                                        &nbsp;
                                                    </td>
                                                    <td width="35%" align="left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="5">
                                                        <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="buttonBook" OnClick="btnSearch_Click"
                                                            OnClientClick="showDiv();" />&nbsp;
                                                        <asp:Button ID="Button1" runat="server" Text="Reset" CausesValidation="false" CssClass="buttonBook"
                                                            OnClick="Button1_Click" />
                                                        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel"
                                                            CssClass="buttonBook" Style="cursor: pointer;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%">
                                            &nbsp;
                                            <%-- <asp:Label ID="lblHtml" runat="server" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%">
                                            <table width="100%">
                                                <tr>
                                                    <td width="50%" align="left" valign="top">
                                                        &nbsp;:&nbsp;
                                                    </td>
                                                    <td width="50%" align="right">
                                                        <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                            Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClientClick="ExportGridviewtoExcel();"
                                                            OnClick="lbtnXport2Xcel_Click1" Visible="false" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton
                                                                ID="ImageButton3" ImageUrl="~/images/refresh.png" runat="server" OnClick="ImageButton3_Click"
                                                                Width="20px" Height="20px" ToolTip="Refresh" Visible="false" /><%--OnClick="Unnamed1_Click"--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="center">
                                            <asp:GridView ID="GvCusEnquiry" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                                ShowFooter="true" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                                BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="No  Records "
                                                OnPageIndexChanging="GvCusEnquiry_PageIndexChanging" OnSorting="GvCusEnquiry_Sorting"
                                                OnRowDataBound="GvCusEnquiry_RowDataBound" OnRowCommand="GvCusEnquiry_RowCommand"
                                                AllowPaging="True" PageSize="100">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="BookingId" Visible="false" SortExpression="BookingId">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBookingId" Text='<%#Eval("BookingId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ref No" SortExpression="OnewayMBRefNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblManabusRefNo" Text='<%#Eval("OnewayMBRefNo") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Travel" SortExpression="TravelOPName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTravel" Text='<%#Eval("TravelOPName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PNRNumber" SortExpression="PNRNumber">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPNRNumber" Text='<%#Eval("PNRNumber") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" Text='<%#Eval("FullName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email " SortExpression="EmailId">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmailID" Text='<%#Eval("EmailId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact" SortExpression="ContactNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblContact" Text='<%#Eval("ContactNo") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Journey" SortExpression="DateOfJourney">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDOJ" Text='<%#Eval("DateOfJourney") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Seat Number" SortExpression="SeatNos">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSeatNumbers" Text='<%#Eval("SeatNos") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Fare" SortExpression="TotalFare">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalFare" Text='<%#Eval("TotalFare") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalFare1" runat="server" ForeColor="Red"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Boarding Point" SortExpression="BoardingPointName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBoardingPoint" Text='<%#Eval("BoardingPointName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Booking Date & Time" SortExpression="BookingTime">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBookingTime" Text='<%#Eval("BookingTime") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCSEPerson" Text='<%#Eval("UserName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" SortExpression="BStatus">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBStatus" Text='<%#Eval("BStatus") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Actions">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnView" Text="View" runat="server" CssClass="buttonBook" CommandName="View"
                                                                CommandArgument='<%#Eval("BookingId") %>' OnClientClick="showDiv();" />
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
                    <asp:View ID="VWViewCusReport" runat="server">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top" align="center">
                                    <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center">
                                                <table width="900" align="center">
                                                    <tr>
                                                        <td width="503" align="left">
                                                            <span class="actions">
                                                                <asp:LinkButton ID="lbtnback" Text="Back" runat="server" OnClick="lbtnback_Click"
                                                                    OnClientClick="showDiv();" /></span>
                                                        </td>
                                                        <td width="220" align="right">
                                                            <span class="actions">
                                                                <%--<asp:RadioButton ID="radioButtonCancel" runat="server" AutoPostBack="true" Text="Cancel"
                                                        GroupName="radioGroup" OnCheckedChanged="radioButtonCancel_CheckedChanged" />--%>
                                                                <asp:LinkButton ID="lbtnCancel" Text="Cancel" runat="server" OnClick="lbtnCancel_Click"
                                                                    Visible="false" />
                                                                &nbsp;
                                                                <asp:LinkButton ID="LinkButton3" Text="Download" runat="server" OnClick="btnExportTOWord_Click" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:RadioButton ID="radioButtonMailUp" runat="server" OnCheckedChanged="radioButtonMail_CheckedChanged"
                                                                    AutoPostBack="true" Text="Mail" GroupName="radioGroup" />
                                                                <asp:LinkButton ID="lbtnmail" Text="Mail" runat="server" OnClick="lbtnmail_Click1"
                                                                    Visible="false" />
                                                                &nbsp;&nbsp;|&nbsp;&nbsp;<a onclick="printPage('printdiv');" target="_blank">
                                                                    <input id="Radio1" type="radio" runat="server" />Print </a></span>
                                                            <%--    <br />
                                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="radioGroup"/>
                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="radioGroup"/>
                                                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="radioGroup"/>--%>
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
                                                                                <img src="http://lovejourney.in/Newimages/New_Logo.png" height="88" border="0" title="Love Journey" />&nbsp;&nbsp;
                                                                            </td>
                                                                            <td align="right">
                                                                                <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="40" align="left">
                                                                                            <img src="http://www.lovejourney.in/images/call.jpg" alt="img" width="30" height="30" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <b>(080) 32 56 17 27</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="40" align="left">
                                                                                            <img src="http://www.lovejourney.in/images/messenge.jpg" alt="i" width="30" height="30" />
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
                                                                                                                        <b>Operator PNR</b>
                                                                                                                    </td>
                                                                                                                    <td width="15%" align="left">
                                                                                                                        <asp:Label ID="lblTravelOpPNR" Text='<%# Eval("PNRTicketIDs") %>' runat="server" />
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
                                                                                                            <table width="100%" align="left" style="border: 0px;">
                                                                                                                <tr>
                                                                                                                    <td width="50%" align="left">
                                                                                                                        <b>Coach</b>
                                                                                                                        <asp:Label ID="lblBusType" runat="server" Text='<%#Eval("BusType") %>' />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="50%">
                                                                                                            <b>Boarding Point :</b>
                                                                                                            <asp:Label ID="lblBordingTime" runat="server" Text='<%#Eval("BoardingPointName") %>' />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" height="25">
                                                                                                            <b>Boarding Point Address :</b>
                                                                                                            <asp:Label ID="lblBoardingPoint" runat="server" Text='<%#Eval("BoardingInfo") %>' />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" height="25">
                                                                                                            <asp:Label ID="lblEmailID" runat="server" Text='<%#Eval("EmailID") %>' Visible="false" />
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
                                                                                                                                    <asp:Label ID="lblTicketStatus" runat="server" Text='<%#Eval("BStatus")%>'></asp:Label>
                                                                                                                                </td>
                                                                                                                                <td width="93" align="left">
                                                                                                                                    <b>Contact No</b>
                                                                                                                                </td>
                                                                                                                                <td width="93" align="left">
                                                                                                                                    <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo ") %>'></asp:Label>
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
                                                                                                                                    <b>Booked By</b>
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
                                                                                                                                                    <strong>Cancelled On</strong>
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
                                                                                            <b class="man_hd">Cancellation Policy :</b>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="900" align="center">
                                                <table width="900" align="center">
                                                    <tr>
                                                        <td width="523">
                                                        </td>
                                                        <td width="115" align="right">
                                                            <span class="actions">
                                                                <asp:RadioButton ID="radioButtonMail" runat="server" Text="Mail" AutoPostBack="True"
                                                                    OnCheckedChanged="radioButtonMail_CheckedChanged" GroupName="radioGroup" />
                                                                <asp:LinkButton ID="lbtnMaild" Text="Mail" runat="server" OnClick="lbtnmail_Click1"
                                                                    Visible="false" />
                                                                &nbsp;&nbsp;|&nbsp;&nbsp;<a onclick="printPage('printdiv');" target="_blank">
                                                                    <input id="Radio2" type="radio" runat="server" />Print</a></span>
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
                                <td width="100%" align="center" style="display: none;">
                                    <asp:GridView ID="gvDetails" AutoGenerateColumns="False" Width="100%" runat="server"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                        CellPadding="3" EnableModelValidation="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Ticket Details">
                                                <ItemTemplate>
                                                    <table width="100%" style="line-height: 20px;" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="100%" align="left" colspan="6">
                                                                <strong>Booking Details</strong>
                                                            </td>
                                                        </tr>
                                                        <tr style="background-color: #006699; color: White;">
                                                            <td align="left">
                                                                <strong>Booking Type</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Booked On</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Transaction No.</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Sales Channel</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Issued By</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Fare</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <%#Eval("Type")%>
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("DateOfBooking")%>
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("SaleType")%>
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("UserName")%>
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("TotalFare")%>
                                                            </td>
                                                        </tr>
                                                        <tr style="background-color: #006699; color: White;">
                                                            <td align="left">
                                                                <strong>Transaction Charges</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Discount</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Total Amount</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Cash Coupon Issued</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Cash Coupon Amount</strong>
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("TotalFare")%>
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("CouponNo")%>
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("CashCouponAmount")%>
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" colspan="6" align="left">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr style="background-color: #006699; color: White;">
                                                            <td width="100%" colspan="6" align="left">
                                                                <strong>Comment:</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" colspan="6" align="left">
                                                                <%#Eval("Comment")%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" colspan="6" align="left">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="left" colspan="6">
                                                                <strong>Payment Deatils</strong>
                                                            </td>
                                                        </tr>
                                                        <tr style="background-color: #006699; color: White;">
                                                            <td align="left">
                                                                <strong>Payment Type</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Coupon No</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>PG Code</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Payment Ref No.</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Amount</strong>
                                                            </td>
                                                            <td align="left">
                                                                <strong>Transaction Charges</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <%#Eval("PaymentType")%>
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("CouponNo")%>
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("TotalFare")%>
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#006699" HorizontalAlign="Left"
                                            Font-Size="16px" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="text-align: left; display: none;">
                                        <asp:Button ID="openID" runat="server" Height="1px" Width="1px" /></div>
                                    <ajax:ModalPopupExtender ID="MPEMail" TargetControlID="openID" PopupControlID="Panel1"
                                        runat="server" BackgroundCssClass="loadingBackground" OkControlID="imgclose"
                                        DropShadow="false" Drag="false" X="450" Y="300" />
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="400" Style="display: none;
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
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
