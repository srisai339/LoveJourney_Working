<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="TentativeBooking.aspx.cs" Inherits="Users_TentativeBooking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            <asp:Panel ID="pnlCusEnquiryReports" runat="server" Width="100%">
                <center>
                    <table width="100%">
                        <tr>
                            <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                font-weight: bold; color: Maroon;">
                                Tentative Booking
                            </td>
                        </tr>
                        <tr>
                            <td width="80%" align="center">
                                <table width="80%">
                                    <tr>
                                        <td width="15%" align="left">
                                            Source
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:DropDownList ID="ddlSources" runat="server" CssClass="Dropdownlist">
                                            </asp:DropDownList>
                                            <%--       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required"
                                        InitialValue="0" ControlToValidate="ddlAPI" runat="server" ValidationGroup="Go"
                                        Display="Dynamic" />--%>
                                        </td>
                                        <td width="15%" align="left">
                                            Destination
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:DropDownList ID="ddlDestinations" runat="server" CssClass="Dropdownlist">
                                            </asp:DropDownList>
                                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required"
                                        InitialValue="0" ControlToValidate="ddlOperator" runat="server" ValidationGroup="Go"
                                        Display="Dynamic" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="left">
                                            Date of Journey
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:TextBox ID="txtDOJ" runat="server" />
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                                Format="yyyy-MM-dd" TargetControlID="txtDOJ" PopupButtonID="ImageButton2" CssClass="cal_Theme1">
                                            </ajax:CalendarExtender>
                                        </td>
                                        <td width="15%" align="left">
                                            Operator
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:DropDownList ID="ddloperator" runat="server" CssClass="Dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="left">
                                            Name
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="Textbox" />
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required"
                                        InitialValue="0" ControlToValidate="ddlStatus" runat="server" ValidationGroup="Go"
                                        Display="Dynamic" />--%>
                                        </td>
                                        <td width="15%" align="left">
                                            Email ID
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:TextBox ID="txtEmailID" runat="server" CssClass="Textbox" />
                                        </td>
                                    </tr>
                                    <tr>
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
                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Dropdownlist">
                                                <asp:ListItem Text="ALL" />
                                                <asp:ListItem Text="InProgress" />
                                                <asp:ListItem Text="unbooked" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="left">
                                        </td>
                                        <td width="35%" align="left">
                                        </td>
                                        <td width="15%" align="left">
                                            <asp:Button ID="btnSearch" Text="GO" runat="server" CssClass="selectseats_input"
                                                ValidationGroup="Go" OnClick="btnSearch_Click" OnClientClick="showDiv();" />
                                        </td>
                                        <td width="35%" align="left">
                                            &nbsp;
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
                                <table width="100%">
                                    <tr>
                                        <td width="50%" align="left" valign="top">
                                            Select Page size&nbsp;:&nbsp;
                                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="Dropdownlist "
                                                Width="100px" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                <asp:ListItem Text="--Select--" Value="0" />
                                                <asp:ListItem Text="40" Value="1" />
                                                <asp:ListItem Text="80" Value="2" />
                                                <asp:ListItem Text="120" Value="3" />
                                            </asp:DropDownList>
                                        </td>
                                        <td width="50%" align="right">
                                            <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClick="lbtnXport2Xcel_Click1"
                                                OnClientClick="ExportGridviewtoExcel();" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton
                                                    ID="ImageButton3" ImageUrl="~/images/refresh.png" runat="server" Width="20px"
                                                    Height="20px" ToolTip="Refresh" OnClick="ImageButton3_Click" /><%--OnClick="Unnamed1_Click"--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:GridView ID="GvtentativeBooking" runat="server" AutoGenerateColumns="False"
                                    AllowSorting="True" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="No Tentative Bookings"
                                    OnPageIndexChanging="GvtentativeBooking_PageIndexChanging" OnSorting="GvtentativeBooking_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="BookingId" Visible="false" SortExpression="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookingId" Text='<%#Eval("ID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Travel" SortExpression="TravelOPName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTravel" Text='<%#Eval("TravelOPName") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bus Type" SortExpression="BusType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBusType" Text='<%#Eval("BusType") %>' runat="server" />
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
                                        <asp:TemplateField HeaderText="Travel Date" SortExpression="DateOfJourney">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDOJ" Text='<%#Eval("DateOfJourney") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No Of Seats" SortExpression="NoOfSeats">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfSeats" Text='<%#Eval("NoOfSeats") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--   <asp:TemplateField HeaderText="Date Of Creation" SortExpression="CreatedDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedDate" Text='<%#Eval("CreatedDate") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" Text='<%#Eval("Status") %>' runat="server" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
