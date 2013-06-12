<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master"
    AutoEventWireup="true" CodeFile="CustomerRequest.aspx.cs" Inherits="Users_CustomerRequest"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Summary
        {
            background-color: Silver;
            color: Wheat;
            font-family: Arial;
            font-size: 12px;
            border: 1px solid voilet;
        }
    </style>
    <script type="text/javascript">

        // setTimeout("location.reload(true);", 50000);
        
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
            <%--<asp:PostBackTrigger ControlID="btnview" />--%>
        </Triggers>
        <ContentTemplate>
            <%-- <asp:Timer ID="Timer1" Interval="60000" runat="server" OnTick="Timer1_Tick">
            </asp:Timer>--%>
            <table width="100%">
                <tr>
                    <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                        runat="server" visible="false">
                        <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlCusRequestReports" runat="server" Width="100%">
                <center>
                    <table width="100%">
                        <tr>
                         <td class="heading" align="center">
      Customer Enquiry
        </td>
                           <%-- <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                font-weight: bold; color: Maroon;">
                                Customer Requests
                            </td>--%>
                        </tr>
                        <tr>
                            <td width="80%" align="center">
                                <table width="60%">
                                    <tr>
                                        <td colspan="4" width="100%" align="left">
                                            Travel Date :
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="left">
                                            From
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:TextBox ID="txtTravelFrom" runat="server" /><asp:ImageButton ID="ImageButton1"
                                                runat="server" ImageUrl="~/Images/calendar.jpg" />
                                            <ajax:CalendarExtender ID="CalTravelFrom" runat="server" FirstDayOfWeek="Sunday"
                                                Format="yyyy-MM-dd" TargetControlID="txtTravelFrom" PopupButtonID="ImageButton1"
                                                CssClass="cal_Theme1">
                                            </ajax:CalendarExtender>
                                        </td>
                                        <td width="15%" align="right">
                                            To
                                        </td>
                                        <td width="35%" align="right">
                                            <asp:TextBox ID="txtTravelTo" runat="server" /><asp:ImageButton ID="ImageButton3"
                                                runat="server" ImageUrl="~/Images/calendar.jpg" />
                                            <ajax:CalendarExtender ID="CalTravelTo" runat="server" FirstDayOfWeek="Sunday" Format="yyyy-MM-dd"
                                                TargetControlID="txtTravelTo" PopupButtonID="ImageButton3" CssClass="cal_Theme1">
                                            </ajax:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" width="100%" align="left">
                                            Request Date :
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="left">
                                            From
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:TextBox ID="txtRequestFrom" runat="server" /><asp:ImageButton ID="ImageButton2"
                                                runat="server" ImageUrl="~/Images/calendar.jpg" />
                                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                                Format="yyyy-MM-dd" TargetControlID="txtRequestFrom" PopupButtonID="ImageButton2"
                                                CssClass="cal_Theme1">
                                            </ajax:CalendarExtender>
                                        </td>
                                        <td width="15%" align="right">
                                            To
                                        </td>
                                        <td width="35%" align="right">
                                            <asp:TextBox ID="txtRequestTo" runat="server" /><asp:ImageButton ID="ImageButton4"
                                                runat="server" ImageUrl="~/Images/calendar.jpg" />
                                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" FirstDayOfWeek="Sunday"
                                                Format="yyyy-MM-dd" TargetControlID="txtRequestTo" PopupButtonID="ImageButton4"
                                                CssClass="cal_Theme1">
                                            </ajax:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" align="left" colspan="2">
                                            &nbsp;
                                        </td>
                                        <td width="50%" align="left" colspan="2">
                                            <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="buttonBook"
                                                ValidationGroup="Go" OnClick="btnSearch_Click" OnClientClick="showDiv();" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" colspan="4">
                                            <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                                style="display: none" class="modalContainer">
                                                <div class="registerhead">
                                                    <img src="../images/loading.gif" width="150" height="150" alt="Loading" />
                                                </div>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <asp:Label ID="lblHtml" runat="server" Visible="false" />
                                <br />
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
                                                Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClientClick="ExportGridviewtoExcel();"
                                                OnClick="lbtnXport2Xcel_Click1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton
                                                    ImageUrl="~/images/refresh.png" runat="server" OnClientClick="window.location.reload();" /><%--OnClick="Unnamed1_Click"--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:GridView ID="GvCusRequests" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                    Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3" EnableModelValidation="True" EmptyDataText="No Customer Requests "
                                    AllowPaging="true" PageSize="40" OnPageIndexChanging="GvCusRequests_PageIndexChanging"
                                    OnSorting="GvCusRequests_Sorting" OnSelectedIndexChanged="GvCusRequests_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Text='<%#Eval("RequestId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Travel" SortExpression="TravelName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTravel" Text='<%#Eval("TravelName") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Journey" SortExpression="DOJ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDOJ" Text='<%#Eval("DOJ") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" Text='<%#Eval("Name") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Phone " SortExpression="PhoneNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContact" Text='<%#Eval("PhoneNo") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Seats" SortExpression="NoOFSeats">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalSeats" Text='<%#Eval("NoOFSeats") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlStatus" runat="server">
                                                    <asp:ListItem Text="InProgress" Value="0" />
                                                    <asp:ListItem Text="Booked" Value="1" />
                                                    <asp:ListItem Text="UnBooked" Value="2" />
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Time Elapsed" SortExpression="Time">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalElapsed" Text='<%#Eval("Time") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="CSE Person" SortExpression="CSEPerson">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCSEPerson" Text='<%#Eval("") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%-- <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" Text="View" runat="server" CssClass="selectseats_input" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="25px"
                                        HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <RowStyle ForeColor="#000066" Height="30px" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="30px"
                                        HorizontalAlign="Center" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                                        Height="30px" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:Panel>
            <%-- <asp:Button ID="btnok" Text="OK" runat="server"  Visible="false"/>
            <ajax:ModalPopupExtender ID="MPE1" DropShadow="true" PopupControlID="pnlViewCusRequest"
                TargetControlID="btnok" runat="server" BehaviorID="MPE1" OkControlID="btnClose">
            </ajax:ModalPopupExtender>--%>
            <%--<ajax:AnimationExtender ID="popupAnimation" runat="server" TargetControlID="btnok">
                <Animations>
                <Onsho>
                    
                   <Parallel AnimationTarget="pnlViewCusRequest"
                    Duration=".3" Fps="25">
                    <FadeIn />
                    </Parallel>
                </OnClick>
                </Animations>
            </ajax:AnimationExtender>--%>
            <%--  <asp:Panel ID="pnlViewCusRequest" runat="server" Style="display: none; background-color: White;"
                Width="500px" Height="300px">
                <center>
                    <table width="100%">
                        <tr>
                            <td width="100%">
                                <asp:Button ID="btnClose" Text="Close" runat="server" CssClass="selectseats_input" />
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:Panel>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
