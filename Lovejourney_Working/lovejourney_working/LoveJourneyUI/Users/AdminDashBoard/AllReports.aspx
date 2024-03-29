﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="AllReports.aspx.cs" Inherits="Users_AdminDashBoard_AllReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Load() {

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                var dateToday = new Date();
                $(".datepicker").datepicker({
                    dateFormat: 'dd/mm/yy',
                    numberOfMonths: 2,
                    showOn: "button",
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: '12-12-1990'
                });

                $(".datepicker1").datepicker({
                    dateFormat: 'dd/mm/yy',
                    showOn: "button",
                    numberOfMonths: 1,
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: '12-12-1990'
                });
            }
        }
        function showDate() {
            $(".datepicker").datepicker("show");
        }
        function showDate1() {
            $(".datepicker1").datepicker("show");
        }
        $(function () {
            var dateToday = new Date();
            $(".datepicker").datepicker({
                dateFormat: 'dd/mm/yy',
                numberOfMonths: 2,
                showOn: "button",
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: '12-12-1990'
            });

        });
        $(function () {
            var dateToday = new Date();
            $(".datepicker1").datepicker({
                dateFormat: 'dd/mm/yy',
                showOn: "button",
                numberOfMonths: 1,
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: '12-12-1990'
            });
        });
        function showDiv() {
            Page_ClientValidate("Search");
            if (Page_ClientValidate("Search")) {
                go();
                go1();
                go2();
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "Images/roller_big.gif"', 200);
            }
            else {
                return false;
            }
        }
        function Adddob() {
            //alert('hi');
            document.getElementById('<%=txtfrom.ClientID %>').value = "";

        }
        function Adddob1() {
            //alert('hi');
            document.getElementById('<%=txtto.ClientID %>').value = "";

        }

    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td align="center">
                <table width="1000" bgcolor="#ffffff">
                 <tr>
                                    <td colspan="2" align="center" class="lj_dbrd_hd">
                                        All Reports
                                    </td>
                                </tr>
                    <tr>
                        <td align="center">
                            <table width="600">
                               
                                <tr>
                                    <td align="center">
                                        <table width="600">
                                            <tr>
                                                <td colspan="6">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    User Name
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="ddlagent" Width="126" runat="server" CssClass="lj_inp">
                                                    </asp:TextBox>
                                                   <asp:autocompleteextender id="txtFrom_AutoCompleteExtender" runat="server" targetcontrolid="ddlagent"
                                                        servicemethod="GetAgentNames" minimumprefixlength="1" completioninterval="10"
                                                        completionsetcount="12" firstrowselected="True" delimitercharacters="" enabled="True"
                                                        servicepath="">
                                                </asp:autocompleteextender>
                                                    <asp:DropDownList ID="ddlagent1" runat="server" Visible="false">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Service Name
                                                </td>
                                                <td align="center">
                                                    <asp:DropDownList ID="ddlserviceName" runat="server" CssClass="lj_inp">
                                                        <asp:ListItem Value="-Please Select-">-Please Select-</asp:ListItem>
                                                        <asp:ListItem Value="DomesticFlights">Domestic Flights</asp:ListItem>
                                                        <asp:ListItem Value="InterNationalFlights">InterNational Flights</asp:ListItem>
                                                        <asp:ListItem Value="Hotels">Hotels</asp:ListItem>
                                                        <asp:ListItem Value="Bus">Bus</asp:ListItem>
                                                        <asp:ListItem Value="Recharge">Recharge</asp:ListItem>
                                                         <asp:ListItem Value="Cab">Cab</asp:ListItem>
                                                          <asp:ListItem Value="ALL">ALL</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="one"
                                                        InitialValue="-Please Select-" ControlToValidate="ddlserviceName" ErrorMessage="Please enter Service Name"
                                                        Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    From Date
                                                </td>
                                                <td align="center" style="padding-left:30px;">
                                                    <asp:TextBox ID="txtfrom" runat="server" Width="125" CssClass="datepicker" onchange="showDate(); return true;" onkeyup="javascript:Adddob();"></asp:TextBox>
                                                    <%-- <asp:CalendarExtender ID="calc" runat="server" TargetControlID="txtfrom" Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>--%>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    To Date
                                                </td>
                                                <td align="center" style="padding-left:20px;">
                                                    <asp:TextBox ID="txtto" runat="server" Width="125" CssClass="datepicker" OnClick="showDate1();" onkeyup="javascript:Adddob1();"></asp:TextBox>
                                                    <%-- <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtto"
                                                        Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>--%>
                                                    <%--<asp:CompareValidator ID="compare" runat="server" ControlToValidate="txtfrom" ControlToCompare="txtto"
                                                        Display="None" ValidationGroup="one" ErrorMessage="From Date should not be greater than To Date"
                                                        Type="Date" Operator="GreaterThan"></asp:CompareValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="compare">
                                                    </asp:ValidatorCalloutExtender>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Ref No
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtRefNo" Width="125" runat="server" CssClass="lj_inp">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    
                                                    Page Size</td>
                                                <td align="center" style="padding-right:40px;">
                                                  <asp:DropDownList ID="ddlpagesize" runat="server" width="100" AutoPostBack="True" CssClass="lj_inp"
                                                    onselectedindexchanged="ddlpagesize_SelectedIndexChanged">
                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                       
                                                        <asp:ListItem Value="100" Selected="True">100</asp:ListItem>
                                                        <asp:ListItem Value="150">150</asp:ListItem>
                                                        <asp:ListItem Value="200">200</asp:ListItem>
                                                         <asp:ListItem Value="250">250</asp:ListItem>
                                                        <asp:ListItem Value="300">300</asp:ListItem>


                                                     
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td colspan="6">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                              
                                             <td align="left">
                                           
                                            </td>
                                            <td>
                                             
                                            </td>
                                         
                                                
                                            </tr>
                                            <tr>
                                             <td align="center" colspan="6">
                                                    <asp:Button ID="btnsubmit" runat="server" Text="Search" ValidationGroup="one" CssClass="lj_dbrd_link1"
                                                        OnClick="btnsubmit_Click" />&nbsp;
                                                          <asp:Button ID="Button1" runat="server" Text="Reset" CausesValidation="false" CssClass="lj_dbrd_link1"  OnClick="Button1_Click" />
                                                         <asp:Button ID="btnExport" runat="server" Text="Export To Excel" Visible="false"
                                                    CssClass="buttonBook" 
                                                     onclick="btnExport_Click"/>
                                                </td>
                                            </tr>
                                          
                                              
                                              
                                          
                                            
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                    <asp:GridView ID="gdAllservicesreports" Width="100%" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataRowStyle-Height="250" AllowPaging="True" 
                                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                            ShowFooter="true" EmptyDataText="No records found" EmptyDataRowStyle-Font-Bold="true"
                                            EmptyDataRowStyle-Font-Size="Small" EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                            EmptyDataRowStyle-HorizontalAlign="Center" AllowSorting="True" CellPadding="4"
                                            EnableModelValidation="True" ForeColor="#333333"  OnPageIndexChanging="gdAllservicesreports_PageIndexChanging"
                                            OnSorting="gdAllservicesreports_Sorting" OnRowDataBound="gdAllservicesreports_RowDataBound"
                                           PageSize="150">
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Booking Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    Visible="false" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblrechargeFName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="UserName" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="UserName" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                                    ControlStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblserviceUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Service" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Service" HeaderStyle-ForeColor="White" HeaderStyle-Width="90px"
                                                    ControlStyle-Width="90px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblService" runat="server" Width="90px" Text='<%# Eval("Service") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ref No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="MBRefNo" HeaderStyle-ForeColor="White" HeaderStyle-Width="150px"
                                                    ControlStyle-Width="150px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblserviceReferenceNo" runat="server" Text='<%# Eval("MBRefNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                                <asp:TemplateField HeaderText="Actual Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="ActualFare" HeaderStyle-ForeColor="White" HeaderStyle-Width="130px"
                                                    ControlStyle-Width="130px"  >
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblserviceActualFare" runat="server" Width="130px" Text='<%# Eval("ActualFare") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <FooterTemplate>
                                                        <asp:Label ID="lblserviceActfare" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                           
                                                <asp:TemplateField HeaderText=" LJFare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="MBFare" HeaderStyle-ForeColor="White" HeaderStyle-Width="130px"
                                                    ControlStyle-Width="130px" >
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblserviceMBFare" runat="server" Width="180px" Text='<%# Eval("MBFare") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblserviceljfare" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Commission Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="CommisionFare" HeaderStyle-ForeColor="White" HeaderStyle-Width="80px"
                                                    ControlStyle-Width="80px" >
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblserviceCommisionFare" runat="server" Text='<%# Eval("CommisionFare") %>'></asp:Label>
                                                    </ItemTemplate>
                                                      <FooterTemplate>
                                                        <asp:Label ID="lblservicecomm" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                              
                                                <asp:TemplateField HeaderText="ClosingBalance" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="ClosingBalance" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px" >
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblserviceClosingBalance" runat="server" Text='<%# Eval("ClosingBalance") %>'></asp:Label>
                                                    </ItemTemplate>
                                                       <FooterTemplate>
                                                        <asp:Label ID="lblserviceFclosingbalance" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                      
                                                <asp:TemplateField HeaderText="Booking Date & Time " ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="CreatedDate" HeaderStyle-ForeColor="White" HeaderStyle-Width="150px"
                                                    ControlStyle-Width="150px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblserviceCreatedDate" runat="server" Width="70px" Text='<%# Eval("CreatedDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  
                                                </asp:TemplateField>
                                             
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <FooterStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                        <asp:GridView ID="GvFlightsReports" Width="100%" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataRowStyle-Height="250" AllowPaging="True" 
                                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                            ShowFooter="true" EmptyDataText="No records found" EmptyDataRowStyle-Font-Bold="true"
                                            EmptyDataRowStyle-Font-Size="Small" EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                            EmptyDataRowStyle-HorizontalAlign="Center" AllowSorting="True" CellPadding="4"
                                            EnableModelValidation="True" ForeColor="#333333" OnPageIndexChanging="GvFlightsReports_PageIndexChanging"
                                            OnRowDataBound="GvFlightsReports_RowDataBound" 
                                            OnSorting="GvFlightsReports_Sorting" PageSize="100">
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Booking Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    Visible="false" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingId" runat="server" Text='<%# Eval("Int_Booking_Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ref No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="ReferenceNo" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReferenceNo" runat="server" Text='<%# Eval("ReferenceNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Travel Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="ArrivalAirportName" HeaderStyle-ForeColor="White" HeaderStyle-Width="90px"
                                                    ControlStyle-Width="90px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblArrivalAirportName" runat="server" Width="90px" Text='<%# Eval("ArrivalAirportName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="CustomerDetails" HeaderStyle-ForeColor="White" HeaderStyle-Width="250px"
                                                    ControlStyle-Width="250px" Visible="false" >
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCustomerDetails" runat="server" Width="130px" Text='<%# Eval("CustomerDetails") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                           
                                                <asp:TemplateField HeaderText="Email ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="EmailAddress" HeaderStyle-ForeColor="White" HeaderStyle-Width="130px"
                                                    ControlStyle-Width="180px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmailAddress" runat="server" Width="180px" Text='<%# Eval("EmailAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Telephone" HeaderStyle-ForeColor="White" HeaderStyle-Width="80px"
                                                    ControlStyle-Width="80px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTelephone" runat="server" Text='<%# Eval("Telephone") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Journey Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="DepartureDateTime" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDepartureDateTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Flight No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="FlightNumber" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                       <%--         <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" SortExpression="CancellationCharges"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Width="50px" Text='<%# Eval("Type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Total Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Total" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                                    ControlStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActualBasefare" runat="server" Width="70px" Text='<%# Eval("Total") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblactulafare" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="LJ Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="PayableAmt" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                                    ControlStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPayableAmt" runat="server" Width="70px" Text='<%# Eval("PayableAmt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblPayableAmt1" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Scharge" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Scharge" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblScharge" runat="server" Text='<%# Eval("Scharge") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblScharge" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="TDiscount" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTDiscount" runat="server" Text='<%# Eval("TDiscount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lbldiscount" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
<%--                                                <asp:TemplateField HeaderText="LJ Fare (Rs)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="MBFare" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMBFare" runat="server" Text='<%# Eval("MBFare") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblMBFare" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Comm (Rs)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="TPartnerCommission" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTPartnerCommission" runat="server" Text='<%# Eval("TPartnerCommission") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblcomm" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comm(%)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false"
                                                    SortExpression="CommisionPercentage" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCommisionPercentage" runat="server" Width="50" Text='<%# Eval("CommisionPercentage") %>'></asp:Label>
                                                    </ItemTemplate>
                                              
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="MarkUp" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="TMarkUp" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTMarkUp" runat="server" Text='<%# Eval("TMarkUp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblmarkup" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Refund Amount" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" SortExpression="RefundAmount" HeaderStyle-ForeColor="White"
                                                    HeaderStyle-Width="80px" ControlStyle-Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRefundAmount" runat="server" Width="80px" Text='<%# Eval("RefundAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblRefundAmount1" Width="80px" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cancel Charges" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    SortExpression="CancellationCharges" ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCancellationCharges" runat="server" Width="100px" Text='<%# Eval("CancellationCharges") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblCancellationCharges1" Width="100px" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ClosingBalance" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="150px"
                                                    SortExpression="ClosingBalance" ControlStyle-Width="150px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClosingBalance" runat="server" Width="100px" Text='<%# Eval("ClosingBalance") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblClosingBalance1" Width="100px" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Booking Date & Time" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Width="80px" SortExpression="BookingTime"
                                                    ControlStyle-Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingTime" runat="server" Width="80px" Text='<%# Eval("BookingTime") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="UserName" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px" >
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserName" runat="server" Width="100px" Text='<%# Eval("UserName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Status" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                                    ControlStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <FooterStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                        <asp:GridView ID="gvMobile" runat="server" AutoGenerateColumns="False" GridLines="Both" 
                                            Visible="false" PageSize="100" AllowPaging="True" PagerStyle-CssClass="i2s_jp_bustext" EmptyDataText="No records found" 

                                            EmptyDataRowStyle-Font-Bold="true"
                                            EmptyDataRowStyle-Font-Size="Small" EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                            EmptyDataRowStyle-HorizontalAlign="Center"

                                            AlternatingRowStyle-CssClass="alt" AllowSorting="True" ForeColor="#333333" Width="100%"
                                            CellPadding="4" EnableModelValidation="True" OnPageIndexChanging="gvMobile_PageIndexChanging"
                                            OnSorting="gvMobile_Sorting">
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                              <%--  <asp:BoundField HeaderText="Name" DataField="FirstName" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center" SortExpression="FirstName" visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>--%>
                                                  <asp:BoundField HeaderText="Name" DataField="Name" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                       <asp:BoundField HeaderText="User Name" DataField="UserName" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center" SortExpression="UserName">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ProviderName" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                             
                                                <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center" SortExpression="MobileNo">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Commission" DataField="Commission" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Request Id" DataField="RequestID" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center" SortExpression="RequestID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                   <asp:BoundField HeaderText="Recharge Date" DataField="BookingTime" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="250" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="250" />
                                                </asp:BoundField>
                                                <%-- <asp:BoundField HeaderText="State" DataField="State" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="State" />
                                    <asp:BoundField HeaderText="City" DataField="City" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="City" />--%>
                                                <%-- <asp:BoundField HeaderText="Balance" DataField="BalanceAmount" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="BalanceAmount">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
                                        <asp:GridView ID="gvBookings" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                            Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                            CellPadding="3" EnableModelValidation="True" EmptyDataText="No Data Found" AllowPaging="True"
                                            PageSize="100" OnPageIndexChanging="gvBookings_PageIndexChanging" OnSorting="gvBookings_Sorting"
                                            ShowFooter="true" onrowdatabound="gvBookings_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="BookingId" Visible="false" SortExpression="BookingId">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingId" Text='<%# Eval("BookingId") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ref No" SortExpression="OnewayMBRefNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblManaBusRefNo" Text='<%# Eval("OnewayMBRefNo") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Agent Name" SortExpression="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblbName" Text='<%# Eval("Name") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Travel" SortExpression="TravelOPName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTravel" Text='<%# Eval("TravelOPName") %>' runat="server" Width="100" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" SortExpression="FullName" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" Text='<%# Eval("FullName") %>' runat="server" Width="100" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                                <asp:TemplateField HeaderText="Email " SortExpression="EmailId" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmailId" Text='<%# Eval("EmailId") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact" SortExpression="ContactNo" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContact" Text='<%# Eval("ContactNo") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="JourneyDate" SortExpression="DateOfJourney">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDOJ" Text='<%# Eval("DateOfJourney") %>' runat="server" Width="100" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Seat Nos" SortExpression="SeatNos" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSeatNumbers" Text='<%# Eval("SeatNos") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Fare" SortExpression="TotalFare">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActualFare" Text='<%# Eval("TotalFare") %>' Width="100" runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblActualFareTotal" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="LJ Fare" SortExpression="AmountPayable">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmountPayable" Text='<%# Eval("AmountPayable") %>' Width="100" runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblAmountPayable1" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LJ Fare" SortExpression="MBFare" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMBFare" Text='<%# Eval("MBFare") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblMBFareTotal" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Com (Rs)" SortExpression="CommisionFare">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCommisionFare" Text='<%# Eval("CommisionFare") %>' Width="50"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblCommisionFareTotal" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Com (%)" SortExpression="CommisionPercentage" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCommisionPercentage" Text='<%# Eval("CommisionPercentage") %>'
                                                            runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Refund Amt" SortExpression="RefundAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRefundAmount" Text='<%# Eval("RefundAmount") %>' Width="120" runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblRefundAmountTotal" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ClosingBalance" SortExpression="ClosingBalance">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClosingBalance" Text='<%# Eval("ClosingBalance") %>' Width="120" runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblClosingBalance1" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cancel Charge" SortExpression="CancellationCharges">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCancellationCharges" Text='<%# Eval("CancellationCharges") %>'
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblCancellationChargesTotal" Width="80" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="MarkUp" SortExpression="Comment" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMarkUp" Text='<%# Eval("Comment") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserName1" Text='<%# Eval("UserName") %>' runat="server" Width="70" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="BStatus">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCBStatus" Text='<%# Eval("BStatus") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Booking Date & Time" SortExpression="UserName" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingTime" Text='<%# Eval("BookingTime") %>' Width="70" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Agent" SortExpression="UserName" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookedBy" Width="120" Text='<%#Eval("UserName") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px"
                                                HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" Height="25px" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="25px"
                                                HorizontalAlign="Center" />
                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                                                Height="25px" />
                                        </asp:GridView>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                            Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                            CellPadding="3" EnableModelValidation="True" EmptyDataText="No Data Found" AllowPaging="True"
                                            PageSize="100" ShowFooter="true" OnPageIndexChanging="GridView1_PageIndexChanging"
                                            OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="BookingId" Visible="false" SortExpression="BookingId">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingId" Text='<%# Eval("BookingId") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ref No" SortExpression="ReferenceNo" ItemStyle-Width="120">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblManaBusRefNo" Width="120" Text='<%# Eval("ReferenceNo") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Agent Name" SortExpression="Name" ItemStyle-Width="120">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHName" Text='<%# Eval("Name") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hotel City" SortExpression="HotelCity" ItemStyle-Width="120">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTravel" Text='<%# Eval("HotelCity") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hotel Name " SortExpression="HotelName" ItemStyle-Width="120">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHotelName" Text='<%# Eval("HotelName") %>' Width="120" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CheckInDate <br/> CheckOutDate" SortExpression="CheckInDate"
                                                    Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCheckInDate" Text='<%# Eval("CheckInDate") %>' runat="server" /><br />
                                                        <asp:Label ID="lblCheckOutDate" Text='<%# Eval("CheckOutDate") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="CheckOutDate" SortExpression="CheckOutDate">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Name" SortExpression="FirstName" ItemStyle-Width="120" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFirstName" Text='<%# Eval("FirstName") %>' Width="120" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                                <asp:TemplateField HeaderText="EmailId <br/> MobileNo" SortExpression="EmailId" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbLEmailId" Text='<%# Eval("EmailId") %>' runat="server" />
                                                        <br />
                                                        <asp:Label ID="lblMobileNumber" Text='<%# Eval("MobileNumber") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--  <asp:TemplateField HeaderText="MobileNumber" SortExpression="MobileNumber">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Total Fare" SortExpression="HotelTotalFare" ItemStyle-Width="120">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActualFare" Text='<%# Eval("HotelTotalFare") %>' Width="100" runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblactulafare" ForeColor="Red" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LJ Fare" SortExpression="PayableAmt" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPayableAmt" Text='<%# Eval("PayableAmt") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblPayableAmt1" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Com (Rs)" SortExpression="CommisionFare" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTPartnerCommission" Text='<%# Eval("CommisionFare") %>' Width="80"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblcomm" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Com (%)" SortExpression="CommisionPercentage" ItemStyle-Width="50" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCommisionPercentage" Text='<%# Eval("CommisionPercentage") %>'
                                                            Width="80" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Refund Amt" SortExpression="RefundAmount" ItemStyle-Width="120">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRefundAmount" Text='<%# Eval("RefundAmount") %>' Width="100" runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblRefundAmount1" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cancel Charge" SortExpression="CancellationCharges"
                                                    ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCancellationCharges" Text='<%# Eval("CancellationCharges") %>'
                                                            Width="120" runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblCancellationCharges1" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="MarkUp" SortExpression="Comment" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMarkUp" Text='<%# Eval("Comment") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblMarkUpTotal" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Closing Bal" SortExpression="ClosingBalance" ItemStyle-Width="80">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClosingBalance" Text='<%# Eval("ClosingBalance") %>' Width="80"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblClosingBalance1" ForeColor="Red" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Booking Date & Time" SortExpression="BookingTime" ItemStyle-Width="80">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingTime" Text='<%# Eval("BookingTime") %>' Width="80" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="UserName" SortExpression="User Name" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserName1" Text='<%# Eval("UserName") %>' Width="50" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="Status" ItemStyle-Width="80">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCBStatus" Text='<%# Eval("Status") %>' Width="80" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px"
                                                HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" Height="25px" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="25px"
                                                HorizontalAlign="Center" />
                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                                                Height="25px" />
                                        </asp:GridView>
                                        <asp:GridView ID="gvCabBookings" Width="100%" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataRowStyle-Height="250" AllowPaging="True" 
                                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                            ShowFooter="true" EmptyDataText="No records found" EmptyDataRowStyle-Font-Bold="true"
                                            EmptyDataRowStyle-Font-Size="Small" EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                            EmptyDataRowStyle-HorizontalAlign="Center" AllowSorting="True" CellPadding="4"
                                            EnableModelValidation="True" ForeColor="#333333" 
                                             PageSize="100">
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Booking Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    Visible="false" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingId" runat="server" Text='<%# Eval("PassengerId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ref No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="ReferenceNo" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCabReferenceNo" runat="server" Text='<%# Eval("ReferanceId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcabFName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Car Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="ArrivalAirportName" HeaderStyle-ForeColor="White" HeaderStyle-Width="90px"
                                                    ControlStyle-Width="90px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblArrivalAirportName" runat="server" Width="90px" Text='<%# Eval("CarName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="AgentNamee" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="CustomerDetails" HeaderStyle-ForeColor="White" HeaderStyle-Width="250px"
                                                    ControlStyle-Width="250px" Visible="false" >
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCustomerDetails" runat="server" Width="130px" Text='<%# Eval("AgentName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                           
                                                <asp:TemplateField HeaderText="Email ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="EmailAddress" HeaderStyle-ForeColor="White" HeaderStyle-Width="130px"
                                                    ControlStyle-Width="180px" Visible="true">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmailAddress" runat="server" Width="180px" Text='<%# Eval("EmailId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Telephone" HeaderStyle-ForeColor="White" HeaderStyle-Width="80px"
                                                    ControlStyle-Width="80px" Visible="true">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTelephone" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Journey Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="DepartureDateTime" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="80px" Visible="true">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDepartureDateTime" runat="server" Text='<%# Eval("TravelDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                       <%--         <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" SortExpression="CancellationCharges"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Width="50px" Text='<%# Eval("Type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Total Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Total" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                                    ControlStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActualBasefare" runat="server" Width="70px" Text='<%# Eval("TotalFare") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblactulafare" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="LJ Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="PayableAmt" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                                    ControlStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPayableAmt" runat="server" Width="70px" Text='<%# Eval("BasicFare") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblPayableAmt1" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                              
<%--                                                <asp:TemplateField HeaderText="LJ Fare (Rs)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="MBFare" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMBFare" runat="server" Text='<%# Eval("MBFare") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblMBFare" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>--%>
                                               <%-- <asp:TemplateField HeaderText="Comm (Rs)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="TPartnerCommission" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTPartnerCommission" runat="server" Text='<%# Eval("TPartnerCommission") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblcomm" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>--%>
                                               <%-- <asp:TemplateField HeaderText="Comm(%)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false"
                                                    SortExpression="CommisionPercentage" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCommisionPercentage" runat="server" Width="50" Text='<%# Eval("CommisionPercentage") %>'></asp:Label>
                                                    </ItemTemplate>
                                              
                                                </asp:TemplateField>--%>
                                                <%--<asp:TemplateField HeaderText="MarkUp" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="TMarkUp" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                    ControlStyle-Width="50px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTMarkUp" runat="server" Text='<%# Eval("TMarkUp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblmarkup" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Refund Amount" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" SortExpression="RefundAmount" HeaderStyle-ForeColor="White"
                                                    HeaderStyle-Width="80px" ControlStyle-Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRefundAmount" runat="server" Width="80px" Text='<%# Eval("RefundAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblRefundAmount1" Width="80px" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cancel Charges" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    SortExpression="CancellationCharges" ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCancellationCharges" runat="server" Width="100px" Text='<%# Eval("CancellationCharges") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblCancellationCharges1" Width="100px" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ClosingBalance" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="150px"
                                                    SortExpression="ClosingBalance" ControlStyle-Width="150px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClosingBalance" runat="server" Width="100px" Text='<%# Eval("ClosingBalance") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblClosingBalance1" Width="100px" runat="server" ForeColor="Red"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="Booking Date & Time" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Width="80px" SortExpression="BookingTime"
                                                    ControlStyle-Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookingTime" runat="server" Width="80px" Text='<%# Eval("CreatedDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                          
                                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    SortExpression="Status" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                                    ControlStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <FooterStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
