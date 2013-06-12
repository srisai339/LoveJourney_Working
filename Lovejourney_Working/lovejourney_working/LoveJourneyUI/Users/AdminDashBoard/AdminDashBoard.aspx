<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="AdminDashBoard.aspx.cs" Inherits="Agent_Masters_AdminDashBoard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" /> 
     <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <link href="../../css/accordian.css" rel="stylesheet" type="text/css" />
      <link href="../../css/mak_style.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
         <script src="http://jquery.malsup.com/block/jquery.blockUI.js?v2.38" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <style>
     /* ajax tab panel*/
      
.ajax__myTab .ajax__tab_header
{
    font-family: verdana,tahoma,helvetica;
    font-size: 11px;
    border-bottom: solid 1px #059acc;
   
}

.ajax__myTab .ajax__tab_outer
{
    padding-right: 0px;
    height: 20px;
    background-color: #059acc;
    margin-right: 2px;
    border-right: solid 1px #059acc;
    border-top: solid 1px #059acc;
}

.ajax__myTab .ajax__tab_inner
{
    padding-left: 3px;
    background-color: #059acc;
    color: White;
}

.ajax__myTab .ajax__tab_tab
{
    height: 13 px;
    padding: 4px;
    margin: 0;
}

.ajax__myTab .ajax__tab_hover .ajax__tab_outer
{
    background-color: #059acc;
}

.ajax__myTab .ajax__tab_hover .ajax__tab_inner
{
    background-color: #059acc;
}

.ajax__myTab .ajax__tab_hover .ajax__tab_tab
{
}

.ajax__myTab .ajax__tab_active .ajax__tab_outer
{
    background-color: #fff;
    border-left: solid 1px #059acc;
    border-top: solid 1px #059acc;
}

.ajax__myTab .ajax__tab_active .ajax__tab_inner
{
    background-color: #fff;
    color: Black;
    border-bottom: solid 1px #fff;
}

.ajax__myTab .ajax__tab_active .ajax__tab_tab
{
}

.ajax__myTab .ajax__tab_body
{
    font-family: verdana,tahoma,helvetica;
    font-size: 10pt;
    border: 1px solid #059acc;
    border-top: 0;
    padding: 8px;
    background-color: #fff;
} 

    </style>
  <style type="text/css">
         
        .modalContainer
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            position: fixed;
            left: 25%;
            top: 25%;
            z-index: 750;
            background-color: inherit;
            padding: 0px;
        }
        .registerhead
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #044cb5;
            padding: 22px 0 10px 0;
        }
        .loadingBackground
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            filter: Alpha(Opacity=30);
            -moz-opacity: 0.3;
            opacity: 0.6;
            width: 100%;
            height: 1000px;
            background-color: #000;
            position: fixed;
            z-index: 500;
            top: 0px;
            left: 0px;
        }
    </style>
    <style type="text/css">
        .modalContainer
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            position: fixed;
            left: 25%;
            top: 25%;
            z-index: 750;
            background-color: inherit;
            padding: 0px;
        }
        .registerhead
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #044cb5;
            padding: 22px 0 10px 0;
        }
        .loadingBackground
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            filter: Alpha(Opacity=30);
            -moz-opacity: 0.3;
            opacity: 0.6;
            width: 100%;
            height: 1000px;
            background-color: #000;
            position: fixed;
            z-index: 500;
            top: 0px;
            left: 0px;
        }
        .back_bg1
        {
            background: url(../../images/Love.png) no-repeat top;
        }
    </style>  
     

    

    

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <table width="990" cellpadding="0" cellspacing="0" border="0">
      <%--<tr>
      <td class="lj_dbrd_hd">AdminDashBoard</td>
     </tr>
     <tr><td>&nbsp;&nbsp;</td></tr>
     <tr>
     <td align="center"><asp:Button ID="btnAdminQuery" runat="server" Text="AdminQuery"   
             CssClass="lj_dbrd_link1" onclick="btnAdminQuery_Click"/></td>
     </tr>--%>
      <tr>
            <td align="center" class="lj_dbrd_hd">
                <b>Admin Dashboard</b>
            </td>
        </tr>
        <tr>
            <td height="10">
            </td>
        </tr>


        
        <tr>
            <td align="right" >
                <asp:Button ID="lbtnNoticeMaster" runat="server" Text="Notices" OnClick="lbtnNoticeMaster_Click" CssClass="lj_dbrd_link1" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="lbtnRemainder" runat="server" Text="Reminder" OnClick="lbtnRemainder_Click"  CssClass="lj_dbrd_link1"/>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="lbtnMarkup" runat="server" Text="Markup Management"  CssClass="lj_dbrd_link1"
                    onclick="lbtnMarkup_Click" />
            </td>
        </tr>
        <tr>
            <td height="10">
            
            </td>
        </tr>
      
        <asp:Panel ID="pnlAdminDashBoard" runat="server">
        <tr>
            <td align="center">
                <%--<asp:GridView ID="gvNotices" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="1024" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                    GridLines="None" EmptyDataText="No Remainders" BackColor="White" PageSize="40"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowSorting="True">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#e4e4e4 " Font-Bold="True" Height="30px" CssClass="lJ_gv" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("ANid") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notices">
                            <ItemTemplate>
                                <asp:Label ID="lblHotelName" Text='<%#Eval("AdminNotice") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>--%>
                <%--<asp:GridView ID="gvNotices" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="1024" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                    GridLines="None" EmptyDataText="No Remainders" BackColor="White" PageSize="40"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowSorting="True">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#e4e4e4 " Font-Bold="True" Height="30px" CssClass="lJ_gv" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("Nid") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notices">
                            <ItemTemplate>
                                <asp:Label ID="lblHotelName" Text='<%#Eval("Notices") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>--%>
            </td>
            <%--<table width="990" cellpadding="0" cellspacing="0" border="0">
             <tr>
                <td align="center">
                   <b>Agent DashBoard</b>
                </td>
             </tr>
             <tr>
             <td align="left">
              <b>Notices</b>
             </td>
             </tr>
              <tr>
                <td align="left">
                 1.This is First Notice 
                </td>
              </tr>
              <tr>
                <td align="left">
                 2.This is Second  Notice 
                </td>
              </tr>
              <tr>
                <td align="left">
                 3.This is Third Notice 
                </td>
              </tr>
              <tr>
                <td align="right">
                 <asp:LinkButton ID="btnViewMore" runat="server" Text="ViewMore"></asp:LinkButton>
                 </td>
              </tr>
          </table>--%>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>

        
        <tr>
            <td align="center" valign="top" >
                <table width="990" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="300"  valign="top" >
                            <asp:TabContainer ID="TabContainer1" runat="server" BorderWidth="1" 
                                Font-Bold="true"  BorderStyle="Solid"  CssClass="ajax__myTab"   
                                ActiveTabIndex="2">
            <asp:TabPanel ID="TabPanel1" runat="server" BorderWidth="1" Font-Bold="true" EnableTheming="true"  >
             <HeaderTemplate>  
                    Flights 
                </HeaderTemplate>  
             <ContentTemplate>  
                    <table width="300" cellpadding="0" cellspacing="0" border="0">
                    <%--  <tr>
                        <td align="right">
                         From:
                        </td>
                        <td align="left">
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="lj_inp" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                         To:
                        </td>
                        <td align="left">  
                        <asp:TextBox ID="txtTo" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                         Day:
                        </td>
                        <td align="left">
                        <asp:TextBox ID="txtDay" runat="server" ></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                      <td>
                        <asp:Label ID="lblHeading" Text="Please Click Here To Book Your Ticket" runat="server" class="lJ_gv" ></asp:Label>
                      </td>
                    </tr>
                    <tr>
                      <td align="right">
                      <asp:Button ID="btnDomesticFlightsGo" runat="server" Text="Domestic" CssClass="lj_dbrd_link1" Width="100" OnClick="btnDomesticFlightsGo_Click"  />
                      <asp:Button ID="btnInternationalGo" runat="server" Text="InterNational" CssClass="lj_dbrd_link1" Width="100"  OnClick="btnInternationalGo_Click"/>
                      </td>
                    </tr>
                    </table>

                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="tabpanelBuses" runat="server">
                <HeaderTemplate>  
                    Buses
                </HeaderTemplate>  
                <ContentTemplate>  
                    <table width="300" cellpadding="0" cellspacing="0" border="0">
                    

                     <td>
                        <asp:Label ID="Label1" Text="Please Click Here To Book Your Bus Ticket" runat="server" class="lJ_gv" ></asp:Label>
                      </td>
                    <tr>
                    <td align="center">
                      <asp:Button ID="btnBusesGo" Text="Go" runat="server" CssClass="lj_dbrd_link1" Width="100" OnClick="btnBusesGo_Click"  />
                      </td>
                    </tr>
                    </table>
                    

                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="tabHotels" runat="server">
                <HeaderTemplate>  
                Hotels
                </HeaderTemplate>  
                <ContentTemplate>  
                    <table width="300" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                       <td>
                        <asp:Label ID="lblHotel" Text="Please Click Here To Book Your Hotel Ticket" runat="server" class="lJ_gv" ></asp:Label>
                      </td>
                    </tr>
                    <tr>
                    <td align="center">
                    <asp:Button ID="btnHotelsGo" runat="server" Text="Go"  CssClass="lj_dbrd_link1" OnClick="btnHotelsGo_Click"
                            Width="100px" />
                    </td>
                    </tr>
                    </table>
                    

                </ContentTemplate>
            </asp:TabPanel>
            </asp:TabContainer>
                            <%-- <ul>
            
            <li><a href="#">Bus</a></li>
             <li><a href="#">Flights</a></li>
              <li><a href="#">Hotels</a></li>
              <li><a href="#">Bus</a></li>
             <li><a href="#">Flights</a></li>
             
            </ul>--%>
                            <%--<table cellpadding="0" cellspacing="0" border="0" width="300" class="lj_mnu_bdr">
                                <tr>
                                    <td bgcolor="#00a9a1" class="lj_mnu">
                                        <ul>
                                            <li><a href="#" rel="pnl1" >Bus</a></li>
                                            <li><a href="#" rel="pnl3">Flights</a></li>
                                            <li><a href="#">Hotels</a></li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td >
                                                <div id="pnl1">
                                                    <asp:Panel ID="pnl" runat="server" Visible="false">
                                                        <asp:DropDownList ID="ddl" runat="server">
                                                        </asp:DropDownList>
                                                    </asp:Panel>
                                                      <asp:Panel ID="Panel1" runat="server" Visible="false">
                                                        <asp:TextBox ID="DropDownList1" runat="server">
                                                        </asp:TextBox>
                                                    </asp:Panel>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>--%>
                        </td>
                        <td width="350" align="center" valign="top">
                            <table width="260" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        

                                        <asp:Button ID="btnAccountManagement" runat="server" Text="Account Management" 
                                            CssClass="lj_dbrd_link1" onclick="btnAccountManagement_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="50">
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="lj_dbrd_link1" />&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="cancel" OnClick="btnCancel_Click"
                                            CssClass="lj_dbrd_link1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnGroupQuery" runat="server" Text="Group Query" 
                                            CssClass="lj_dbrd_link1" onclick="btnGroupQuery_Click" />&nbsp;&nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td height="50">
                                        <asp:Button ID="btnCheckFlightStatus" runat="server" Text="CheckBook Status" OnClick="btnCheckFlightStatus_Click"
                                            CssClass="lj_dbrd_link1" />
                                        <asp:Button ID="btnCheckCancelStatus" runat="server" Text="CheckCancel Status" OnClick="btnCheckCancelStatus_Click"
                                            CssClass="lj_dbrd_link1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="340" bgcolor="red">
                            <asp:Image ID="imggraph" runat="server" ImageUrl="~/images/map.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="li_tab_bdr" width="990">
                <asp:GridView ID="gvRemainders" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="990" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                    EmptyDataText="No Remainders" BackColor="White" PageSize="40" BorderColor="#CCCCCC"
                    GridLines="None" BorderStyle="None" BorderWidth="1px" AllowSorting="True">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#e4e4e4" Font-Bold="True" Height="30px" CssClass="lJ_gv" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="center" Height="25" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                    <Columns>
                        <asp:TemplateField HeaderText="Rid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("ARid") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                            <ItemStyle Width="" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reminder">
                            <ItemTemplate>
                                <asp:Label ID="Description" Text='<%#Eval("Remainder") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr><td>&nbsp;&nbsp;</td></tr>
        <tr><td>&nbsp;&nbsp;</td></tr>
        </asp:Panel>
        
      

   </table>









   <asp:Panel ID="adminPanelBuses" runat="server">
      <script type="text/javascript" language="javascript">
          function showDiv() {
              Page_ClientValidate("Search");
              if (Page_ClientValidate("Search")) {
                  go();
                  go1();
                  go2();
                  document.getElementById('mainDiv').style.display = "";
                  document.getElementById('contentDiv').style.display = "";
                  setTimeout('document.images["myAnimatedImage"].src = "../../Images/roller_big.gif"', 200);
              }
              else
                  return false;
          }
    </script>
    <style type="text/css">
        .modalContainer
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            position: fixed;
            left: 25%;
            top: 25%;
            z-index: 750;
            background-color: inherit;
            padding: 0px;
        }
        
        .registerhead
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #044cb5;
            padding: 22px 0 10px 0;
        }
        
        
        .loadingBackground
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            filter: Alpha(Opacity=30);
            -moz-opacity: 0.3;
            opacity: 0.6;
            width: 100%;
            height: 1000px;
            background-color: #000;
            position: fixed;
            z-index: 500;
            top: 0px;
            left: 0px;
        }
    </style>
    <script type="text/javascript">
        function Load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                var dateToday = new Date();
                $(".datepicker").datepicker({
                    dateFormat: 'dd-MM-yy',
                    numberOfMonths: 2,
                    showOn: "button",
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday
                });
                $("[id$='txtFromDate']").datepicker('setDate', 'today');
                $(".datepicker1").datepicker({
                    dateFormat: 'dd-MM-yy',
                    showOn: "button",
                    numberOfMonths: 1,
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday
                });
            }
        }
        function showDate() {
            $(".datepicker").datepicker("show");
        }
        $(function () {
            var dateToday = new Date();
            $(".datepicker").datepicker({
                dateFormat: 'dd-MM-yy',
                numberOfMonths: 2,
                showOn: "button",
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: dateToday
            });
            $("[id$='txtFromDate']").datepicker('setDate', 'today');
        });
        $(function () {
            var dateToday = new Date();
            $(".datepicker1").datepicker({
                dateFormat: 'dd-MM-yy',
                showOn: "button",
                numberOfMonths: 1,
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: dateToday
            });

        });
    </script>
    <script type="text/javascript">
        function go() {
            var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
            var SelectedIndex = DropdownList.selectedIndex;
            var SelectedValue = DropdownList.value;
            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            document.getElementById('Text1').value = SelectedText;

        }
    </script>
    <script type="text/javascript">
        function go1() {
            var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
            var SelectedIndex = DropdownList.selectedIndex;
            var SelectedValue = DropdownList.value;
            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            document.getElementById('Text2').value = SelectedText;
        }
    </script>
    <script type="text/javascript">
        function go2() {
            var SelectedText = document.getElementById('<%=txtFromDate.ClientID %>');
            document.getElementById('Text3').value = SelectedText.value;
        }
    </script>
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" align="left">
                <asp:UpdatePanel ID="up1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                    </Triggers>
                    <ContentTemplate>
                        <center>
                            <asp:Panel ID="pnlBook" runat="server" Width="65%">
                                <table width="65%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="100%" align="center" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" align="left">
                                            <asp:RadioButton ID="rbtnOneWay" Text="One Way" runat="server" Checked="true" AutoPostBack="True"
                                                GroupName="ONE" OnCheckedChanged="rbtnOneWay_CheckedChanged" />
                                        </td>
                                        <td width="50%" align="left">
                                            <asp:RadioButton ID="rbtnRoundTrip" Text="Round Trip" runat="server" AutoPostBack="True"
                                                GroupName="ONE" OnCheckedChanged="rbtnRoundTrip_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" valign="top">
                                            From
                                        </td>
                                        <td width="50%" valign="top">
                                            To
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" height="40px" valign="top" align="left">
                                            <asp:DropDownList ID="ddlSources" ValidationGroup="Search" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlSources_SelectedIndexChanged" Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ValidationGroup="Search"
                                                runat="server" ErrorMessage="Please select source." ControlToValidate="ddlSources"
                                                InitialValue="----------"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" CssClass="customCalloutStyle"
                                                runat="server" WarningIconImageUrl="~/Images/001_111.png" CloseImageUrl="~/Images/001_051.png"
                                                TargetControlID="RequiredFieldValidator1">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td width="50%" height="40px" valign="top" align="left">
                                            <asp:DropDownList ID="ddlDestinations" runat="server" ValidationGroup="Search" onchange="showDate();"
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Search"
                                                runat="server" ErrorMessage="Please select destination." Display="None" ControlToValidate="ddlDestinations"
                                                InitialValue="----------"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" CssClass="customCalloutStyle"
                                                runat="server" WarningIconImageUrl="~/Images/001_111.png" CloseImageUrl="~/Images/001_051.png"
                                                TargetControlID="RequiredFieldValidator2">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" valign="top" align="left">
                                            Travelling On
                                        </td>
                                        <td width="50%" valign="top" align="left">
                                            <asp:Label ID="lblReturningOn" runat="server" Visible="true" Text="Returning On"
                                                CssClass="runtext"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" valign="top" align="left">
                                            <asp:TextBox ID="txtFromDate" ValidationGroup="Search" runat="server" onKeyPress="javascript: return false;"
                                                onPaste="javascript: return false;" CssClass="datepicker" OnClick="showDate();" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Search"
                                                runat="server" ErrorMessage="Please enter date." ControlToValidate="txtFromDate"
                                                Display="None"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" CssClass="customCalloutStyle"
                                                runat="server" WarningIconImageUrl="~/Images/001_111.png" CloseImageUrl="~/Images/001_051.png"
                                                TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td width="50%" valign="top" align="left">
                                            <asp:TextBox ID="txtReturnDate" runat="server" Enabled="False" Visible="true" ValidationGroup="Search"
                                                onKeyPress="javascript: return false;" onPaste="javascript: return false;" OnClick="showDate();" />
                                            <asp:RequiredFieldValidator ID="RequiredReturn" ControlToValidate="txtReturnDate"
                                                runat="server" Visible="false" ErrorMessage="Please enter return date." Display="None"
                                                ValidationGroup="Search"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" CssClass="customCalloutStyle"
                                                runat="server" WarningIconImageUrl="~/Images/001_111.png" CloseImageUrl="~/Images/001_051.png"
                                                TargetControlID="RequiredReturn">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" valign="top" colspan="2">
                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" width="100%" valign="top" align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        <asp:Button ID="btnSearch" runat="server" Text="Search Buses" CssClass="search_btn_1"
                                                            OnClick="btnSearch_Click" ValidationGroup="Search" OnClientClick="showDiv();" />
                                                    </td>
                                                    <td width="70%">
                                                        <asp:UpdateProgress DynamicLayout="true" ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <img src="../../images/loaderb16.gif" width="30px" height="30px" alt="img" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                        <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                                            style="display: none" class="modalContainer">
                                                            <div class="registerhead">
                                                                <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
                                                                    <tr>
                                                                        <td width="9" height="8">
                                                                            <img src="../../images/l1.png" width="9" height="8" alt="img" />
                                                                        </td>
                                                                        <td height="8" width="582" bgcolor="#ffffff">
                                                                        </td>
                                                                        <td width="9" height="8">
                                                                            <img src="../../images/l2.png" width="9" height="8" alt="img" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" bgcolor="#ffffff" align="center" valign="top">
                                                                            <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td align="center" height="25" valign="top">
                                                                                        <img src="../../images/logo.gif" alt="Logo" width="143" height="88" border="0" title="LJ">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="1" bgcolor="#c6c6c6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" class="almost" height="20">
                                                                                        Almost there
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <img src="../../images/loading.gif" width="100" height="100" alt="img" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" class="almost12" height="20">
                                                                                        Searching for Buses
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20">
                                                                                        <input id="Text1" type="text" style="border: 0; text-align: right;" />&nbsp;&nbsp;To&nbsp;&nbsp;<input
                                                                                            id="Text2" type="text" style="border: 0;" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20">
                                                                                        On
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20">
                                                                                        <input id="Text3" type="text" style="border: 0; text-align: center;" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="9" height="8">
                                                                            <img src="../../images/l3.png" width="9" height="8" alt="img" />
                                                                        </td>
                                                                        <td height="8" width="582" bgcolor="#ffffff">
                                                                        </td>
                                                                        <td width="9" height="8">
                                                                            <img src="../../images/l4.png" width="9" height="8" alt="img" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </center>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
   </asp:Panel>




   <asp:Panel ID="pnlAdminHotels" runat="server">
   <script language="Javascript" type="text/javascript">

       function changeRows() {
           var count = document.forms[0].no_ofrooms[document.forms[0].no_ofrooms.selectedIndex].value;
           if (count == 1) {
               document.getElementById("row1").style.display = "";
               document.getElementById("row2").style.display = "none";
               document.getElementById("row3").style.display = "none";
               document.getElementById("row4").style.display = "none";
               document.getElementById("row1").style.visibility = "";
               document.getElementById("row2").style.visibility = "hidden";
               document.getElementById("row3").style.visibility = "hidden";
               document.getElementById("row4").style.visibility = "hidden";
           }
           else if (count == 2) {
               document.getElementById("row1").style.display = "";
               document.getElementById("row2").style.display = "";
               document.getElementById("row3").style.display = "none";
               document.getElementById("row4").style.display = "none";
               document.getElementById("row1").style.visibility = "";
               document.getElementById("row2").style.visibility = "";
               document.getElementById("row3").style.visibility = "hidden";
               document.getElementById("row4").style.visibility = "hidden";
           }
           else if (count == 3) {
               document.getElementById("row1").style.display = "";
               document.getElementById("row2").style.display = "";
               document.getElementById("row3").style.display = "";
               document.getElementById("row4").style.display = "none";
               document.getElementById("row1").style.visibility = "";
               document.getElementById("row2").style.visibility = "";
               document.getElementById("row3").style.visibility = "";
               document.getElementById("row4").style.visibility = "hidden";
           }
           else if (count == 4) {
               document.getElementById("row1").style.display = "";
               document.getElementById("row2").style.display = "";
               document.getElementById("row3").style.display = "";
               document.getElementById("row4").style.display = "";
               document.getElementById("row1").style.visibility = "";
               document.getElementById("row2").style.visibility = "";
               document.getElementById("row3").style.visibility = "";
               document.getElementById("row4").style.visibility = "";
           }
       }

       function showRoomsChildren() {
           document.getElementById("chld1").style.display = "none";
           document.getElementById("chld2").style.display = "none";
           document.getElementById("child11").style.display = "none";
           document.getElementById("child12").style.display = "none";
           document.getElementById("child21").style.display = "none";
           document.getElementById("child22").style.display = "none";
           document.getElementById("child31").style.display = "none";
           document.getElementById("child32").style.display = "none";
           document.getElementById("child41").style.display = "none";
           document.getElementById("child42").style.display = "none";

           document.getElementById("chld1").style.visibility = "hidden";
           document.getElementById("chld2").style.visibility = "hidden";
           document.getElementById("child11").style.visibility = "hidden";
           document.getElementById("child12").style.visibility = "hidden";
           document.getElementById("child21").style.visibility = "hidden";
           document.getElementById("child22").style.visibility = "hidden";
           document.getElementById("child31").style.visibility = "hidden";
           document.getElementById("child32").style.visibility = "hidden";
           document.getElementById("child41").style.visibility = "hidden";
           document.getElementById("child42").style.visibility = "hidden";
       }

       function showchildHeading() {
           var count4 = document.forms[0].str_ChildrenRoom4[document.forms[0].str_ChildrenRoom4.selectedIndex].value;
           var count3 = document.forms[0].str_ChildrenRoom3[document.forms[0].str_ChildrenRoom3.selectedIndex].value;
           var count2 = document.forms[0].str_ChildrenRoom2[document.forms[0].str_ChildrenRoom2.selectedIndex].value;
           var count1 = document.forms[0].str_ChildrenRoom1[document.forms[0].str_ChildrenRoom1.selectedIndex].value;
           if ((count1 == 2) || (count2 == 2) || (count3 == 2) || (count4 == 2)) {
               document.getElementById("chld1").style.display = "";
               document.getElementById("chld2").style.display = "";
               document.getElementById("chld1").style.visibility = "";
               document.getElementById("chld2").style.visibility = "";
           }
           else if ((count1 == 1) || (count2 == 1) || (count3 == 1) || (count4 == 1)) {
               document.getElementById("chld1").style.display = "";
               document.getElementById("chld2").style.display = "none";
               document.getElementById("chld1").style.visibility = "";
               document.getElementById("chld2").style.visibility = "hidden";
           }
           else if ((count1 == 0) || (count2 == 0) || (count3 == 0) || (count4 == 0)) {
               document.getElementById("chld1").style.display = "none";
               document.getElementById("chld2").style.display = "none";
               document.getElementById("chld1").style.visibility = "hidden";
               document.getElementById("chld2").style.visibility = "hidden";
           }
       }

       function showRoomsChildren1() {
           var count1 = document.forms[0].str_ChildrenRoom1[document.forms[0].str_ChildrenRoom1.selectedIndex].value;
           var countadult1 = document.forms[0].str_AdultsRoom1[document.forms[0].str_AdultsRoom1.selectedIndex].value;
           showchildHeading();
           if (count1 == 0) {
               document.getElementById("child11").style.display = "none";
               document.getElementById("child12").style.display = "none";
               document.getElementById("child11").style.visibility = "hidden";
               document.getElementById("child12").style.visibility = "hidden";
               document.forms[0].str_AgeChild1Room1.value = "-1"
               document.forms[0].str_AgeChild2Room1.value = "-1"
           }
           else if (count1 == 1) {
               document.getElementById("child11").style.display = "";
               document.getElementById("child12").style.display = "none";
               document.getElementById("child11").style.visibility = "";
               document.getElementById("child12").style.visibility = "hidden";
               document.forms[0].str_AgeChild2Room1.value = "-1"
           }
           else if (count1 == 2) {
               document.getElementById("child11").style.display = "";
               document.getElementById("child12").style.display = "";
               document.getElementById("child11").style.visibility = "";
               document.getElementById("child12").style.visibility = "";
           }

       }

       function showRoomsChildren2() {
           var count2 = document.forms[0].str_ChildrenRoom2[document.forms[0].str_ChildrenRoom2.selectedIndex].value;
           showchildHeading();

           if (count2 == 0) {
               document.getElementById("child21").style.display = "none";
               document.getElementById("child22").style.display = "none";
               document.getElementById("child21").style.visibility = "hidden";
               document.getElementById("child22").style.visibility = "hidden";
               document.forms[0].str_AgeChild1Room2.value = "-1"
               document.forms[0].str_AgeChild2Room2.value = "-1"
           }
           else if (count2 == 1) {
               document.getElementById("child21").style.display = "";
               document.getElementById("child22").style.display = "none";
               document.getElementById("child21").style.visibility = "";
               document.getElementById("child22").style.visibility = "hidden";
               document.forms[0].str_AgeChild2Room2.value = "-1"
           }
           else if (count2 == 2) {
               document.getElementById("child21").style.display = "";
               document.getElementById("child22").style.display = "";
               document.getElementById("child21").style.visibility = "";
               document.getElementById("child22").style.visibility = "";
           }

       }

       function showRoomsChildren3() {
           var count3 = document.forms[0].str_ChildrenRoom3[document.forms[0].str_ChildrenRoom3.selectedIndex].value;
           showchildHeading();
           if (count3 == 0) {
               document.getElementById("child31").style.display = "none";
               document.getElementById("child32").style.display = "none";
               document.getElementById("child31").style.visibility = "hidden";
               document.getElementById("child32").style.visibility = "hidden";
               document.forms[0].str_AgeChild1Room3.value = "-1"
               document.forms[0].str_AgeChild2Room3.value = "-1"
           }
           else if (count3 == 1) {
               document.getElementById("child31").style.display = "";
               document.getElementById("child32").style.display = "none";
               document.getElementById("child31").style.visibility = "";
               document.getElementById("child32").style.visibility = "hidden";
               document.forms[0].str_AgeChild2Room3.value = "-1"
           }
           else if (count3 == 2) {
               document.getElementById("child31").style.display = "";
               document.getElementById("child32").style.display = "";
               document.getElementById("child31").style.visibility = "";
               document.getElementById("child32").style.visibility = "";
           }

       }

       function showRoomsChildren4() {
           var count4 = document.forms[0].str_ChildrenRoom4[document.forms[0].str_ChildrenRoom4.selectedIndex].value;
           showchildHeading();
           if (count4 == 0) {
               document.getElementById("child41").style.display = "none";
               document.getElementById("child42").style.display = "none";
               document.getElementById("child41").style.visibility = "hidden"
               document.getElementById("child42").style.visibility = "hidden"
               document.forms[0].str_AgeChild1Room4.value = "-1"
               document.forms[0].str_AgeChild2Room4.value = "-1"
           }
           else if (count4 == 1) {
               document.getElementById("child41").style.display = "";
               document.getElementById("child42").style.display = "none";
               document.getElementById("child41").style.visibility = ""
               document.getElementById("child42").style.visibility = "hidden"
               document.forms[0].str_AgeChild2Room4.value = "-1"
           }
           else if (count4 == 2) {
               document.getElementById("child41").style.display = "";
               document.getElementById("child42").style.display = "";
               document.getElementById("child41").style.visibility = ""
               document.getElementById("child42").style.visibility = ""
           }

       }



       function startsearch() {
           var count = 0;
           var count1 = document.forms[0].str_ChildrenRoom1[document.forms[0].str_ChildrenRoom1.selectedIndex].value;
           var countadult1 = document.forms[0].str_AdultsRoom1[document.forms[0].str_AdultsRoom1.selectedIndex].value;
           count = parseInt(count1) + parseInt(countadult1);
           if (parseInt(count1) > 1 && parseInt(countadult1) > 2) {
               alert("No of passengers can't be more than (2 adults and 2 children) OR (3 adults and 1 children)OR (3 adults)in single room");
               return false;
           }
           //suraj 
           //alert(document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value);
           if (parseInt(count1) == 1) {//alert(document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value);
               if (document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value == "-1") {
                   alert("Please Select age of child");
                   return false;
               }
           }
           if (parseInt(count1) == 2) {//alert(document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value);
               if (document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value == "-1") {
                   alert("Please Select age of child");
                   return false;
               }
               if (document.forms[0].str_AgeChild2Room1[document.forms[0].str_AgeChild2Room1.selectedIndex].value == "-1") {
                   alert("Please Select age of child");
                   return false;
               }
           }
           //suraj
           var count2 = document.forms[0].str_ChildrenRoom2[document.forms[0].str_ChildrenRoom2.selectedIndex].value;
           var countadult2 = document.forms[0].str_AdultsRoom2[document.forms[0].str_AdultsRoom2.selectedIndex].value

           count = parseInt(count2) + parseInt(countadult2);
           if (parseInt(count2) > 1 && parseInt(countadult2) > 2) {
               alert("No of passengers can't be more than (2 adults and 2 children) OR (3 adults and 1 children)OR (3 adults)in single room");
               return false;
           }
           //suraj 
           if (parseInt(document.forms[0].no_ofrooms[document.forms[0].no_ofrooms.selectedIndex].value) == 2) {
               if (parseInt(count) < 1) {
                   alert("Please Select atleast one passenger in the Second Row OR Decrease the No. of Rooms");
                   return false;
               }
               if (parseInt(count1) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count1) == 2) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room1[document.forms[0].str_AgeChild2Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count2) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count2) == 2) {
                   if (document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room2[document.forms[0].str_AgeChild2Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
           }

           var count3 = document.forms[0].str_ChildrenRoom3[document.forms[0].str_ChildrenRoom3.selectedIndex].value;
           var countadult3 = document.forms[0].str_AdultsRoom3[document.forms[0].str_AdultsRoom3.selectedIndex].value

           count = parseInt(count3) + parseInt(countadult3);
           if (parseInt(count3) > 1 && parseInt(countadult3) > 2) {
               alert("No of passengers can't be more than (2 adults and 2 children) OR (3 adults and 1 children)OR (3 adults)in single room");
               return false;
           }
           if (parseInt(document.forms[0].no_ofrooms[document.forms[0].no_ofrooms.selectedIndex].value) == 3) {
               if (parseInt(count) < 1) {
                   alert("Please Select atleast one passenger in each Row OR Decrease the No. of Rooms");
                   return false;
               }
               if (parseInt(count1) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count1) == 2) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room1[document.forms[0].str_AgeChild2Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count2) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count2) == 2) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room2[document.forms[0].str_AgeChild2Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count3) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room3[document.forms[0].str_AgeChild1Room3.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count3) == 2) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room3[document.forms[0].str_AgeChild1Room3.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room3[document.forms[0].str_AgeChild2Room3.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
           }
           var count4 = document.forms[0].str_ChildrenRoom4[document.forms[0].str_ChildrenRoom4.selectedIndex].value;
           var countadult4 = document.forms[0].str_AdultsRoom4[document.forms[0].str_AdultsRoom4.selectedIndex].value

           count = parseInt(count4) + parseInt(countadult4);
           if (parseInt(count4) > 1 && parseInt(countadult4) > 2) {
               alert("No of passengers can't be more than (2 adults and 2 children) OR (3 adults and 1 children)OR (3 adults)in single room");
               return false;
           }
           if (parseInt(document.forms[0].no_ofrooms[document.forms[0].no_ofrooms.selectedIndex].value) == 4) {
               if (parseInt(count) < 1) {
                   alert("Please Select atleast one passenger in Each Row OR Decrease the No. of Rooms");
                   return false;
               }
               if (parseInt(count1) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count1) == 2) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room1[document.forms[0].str_AgeChild1Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room1[document.forms[0].str_AgeChild2Room1.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count2) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count2) == 2) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room2[document.forms[0].str_AgeChild2Room2.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count3) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room3[document.forms[0].str_AgeChild1Room3.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count3) == 2) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room3[document.forms[0].str_AgeChild1Room3.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room3[document.forms[0].str_AgeChild2Room3.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count4) == 1) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room4[document.forms[0].str_AgeChild1Room4.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
               if (parseInt(count4) == 2) {//alert(document.forms[0].str_AgeChild1Room2[document.forms[0].str_AgeChild1Room2.selectedIndex].value);
                   if (document.forms[0].str_AgeChild1Room4[document.forms[0].str_AgeChild1Room4.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
                   if (document.forms[0].str_AgeChild2Room4[document.forms[0].str_AgeChild2Room4.selectedIndex].value == "-1") {
                       alert("Please Select age of child");
                       return false;
                   }
               }
           }
           var d = document.forms[0].check_Inhotel.value;
           var r = document.forms[0].check_Outhotel.value;
           var serverDate = document.forms[0].currentdate.value;
           var serdat;
           var city = document.forms[0].strcity.value;
           if (city == "") {
               alert("Please select city");
               document.forms[0].strcity.focus();
               return false;
           }
           if (city == "line") {
               alert("Select valid city location");
               document.forms[0].strcity.focus();
               return false;
           }
           var arr = new Array(12);
           arr[0] = "Jan";
           arr[1] = "Feb";
           arr[2] = "Mar";
           arr[3] = "Apr";
           arr[4] = "May";
           arr[5] = "Jun";
           arr[6] = "Jul";
           arr[7] = "Aug";
           arr[8] = "Sep";
           arr[9] = "Oct";
           arr[10] = "Nov";
           arr[11] = "Dec";


           arrdepart = d.split("-");
           mm = arrdepart[1];
           dd = arrdepart[0];
           yy = arrdepart[2];
           arrreturn = r.split("-");
           mm1 = arrreturn[1];

           dd1 = arrreturn[0];
           yy1 = arrreturn[2];
           dd = parseFloat(dd);
           dd1 = parseFloat(dd1);

           document.forms[0].depart1.value = d;
           document.forms[0].return1.value = r;

           if (d == "") {
               alert("Please select Check-in date"); return false;
           }
           if (r == "") {
               alert("Please select Check-out date"); return false;
           }

           serdat = serverDate.split("-");
           mm2 = serdat[1];
           dd2 = serdat[0];
           yy2 = serdat[2];

           var h = serdat[3];
           var m = serdat[4];
           var s = serdat[5];

           for (var iCharCounter1 = 0; iCharCounter1 < 12; iCharCounter1++) {
               var charVal = arr[iCharCounter1];

               if (charVal == mm) {
                   mm = iCharCounter1 + 1;
               }
               if (charVal == mm1) {
                   mm1 = iCharCounter1 + 1;
               }

               if (charVal == mm2) {
                   mm2 = iCharCounter1 + 1;
               }
           }


           var now = new Date();
           servdate = new Date(yy2, mm2 - 1, dd2);
           tmpDate = new Date(yy, mm - 1, dd);

           var checkdate = new Date(servdate.getTime() + ((1000 * 60 * 60 * 24) * 1));

           if (((mm1 == 04) || (mm1 == 02) || (mm1 == 06) || (mm1 == 09) || (mm1 == 11)) && (dd1 == 31)) {
               alert("Invalid CheckOut Date...");
               return false;
           }
           if ((mm1 == 02) && (dd1 == 30)) {
               alert("Invalid CheckOut Date...");
               return false;
           }

           if (((mm == 04) || (mm == 02) || (mm == 06) || (mm == 09) || (mm == 11)) && (dd == 31)) {
               alert("Invalid Checkin Date... ");
               return false;
           }
           if ((mm == 02) && (dd == 30)) {
               alert("Invalid Checkin Date... ");
               return false;
           }



           if (dd == dd1 && mm == mm1 && yy == yy1) {
               if ((parseInt(h) + 8) >= 24) {
                   alert("Checkin and CheckOut Date can't be same \n Please select another date");
                   return false;
               }
           }


           if (tmpDate < servdate) {
               alert("Check-In Date cannot be before Today's Date");
               return false;
           }

           tmpDate1 = new Date(yy1, mm1 - 1, dd1);

           diffr = tmpDate1.getTime() - tmpDate.getTime();
           var tempdiff = diffr / 86400000;

           if (diffr <= 0) {
               alert("Check-out Date cannot be before Check-in Date.");
               return false;
           }
           if (tempdiff > 31) {
               alert("Number of booking days should not be more than 30 days");
               return false;
           }

           if (document.forms[0].c_urrency[1].checked == true) {
               alert("Search available only for Indian Resident");
               return false;
           }
           else {
               //					'&depart1=' + document.forms[0].depart1.value +
               //					'&return1=' + document.forms[0].return1.value +
               //					'&strcity=' + document.forms[0].strcity.value +

               //					'&check_Inhotel=' + document.forms[0].check_Inhotel.value +
               //					'&check_Outhotel=' + document.forms[0].check_Outhotel.value +
               //					'&no_ofrooms=' + document.forms[0].no_ofrooms.value +

               //					'&str_AdultsRoom1=' + document.forms[0].str_AdultsRoom1.value +
               //					'&str_ChildrenRoom1=' + document.forms[0].str_ChildrenRoom1.value +
               //					'&str_AgeChild1Room1=' + document.forms[0].str_AgeChild1Room1.value +
               //					'&str_AgeChild2Room1=' + document.forms[0].str_AgeChild2Room1.value +

               //					'&str_AdultsRoom2=' + document.forms[0].str_AdultsRoom2.value +
               //					'&str_ChildrenRoom2=' + document.forms[0].str_ChildrenRoom2.value +
               //					'&str_AgeChild1Room2=' + document.forms[0].str_AgeChild1Room2.value +
               //					'&str_AgeChild2Room2=' + document.forms[0].str_AgeChild2Room2.value +

               //					'&str_AdultsRoom3=' + document.forms[0].str_AdultsRoom3.value +
               //					'&str_ChildrenRoom3=' + document.forms[0].str_ChildrenRoom3.value +
               //					'&str_AgeChild1Room3=' + document.forms[0].str_AgeChild1Room3.value +
               //					'&str_AgeChild2Room3=' + document.forms[0].str_AgeChild2Room3.value +

               //					'&str_AdultsRoom4=' + document.forms[0].str_AdultsRoom4.value +
               //					'&str_ChildrenRoom4=' + document.forms[0].str_ChildrenRoom4.value +
               //					'&str_AgeChild1Room4=' + document.forms[0].str_AgeChild1Room4.value +
               //					'&str_AgeChild2Room4=' + document.forms[0].str_AgeChild2Room4.value +

               //					'&currency=true',
               //					'_parent',
               //					'toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,width=1024,height=1024');
               //                  alert("Searching...");
               $("#hdnValues").val(

                document.forms[0].strcity.value + ":" + document.forms[0].check_Inhotel.value + ":" + document.forms[0].check_Outhotel.value + ":"
                + document.forms[0].no_ofrooms.value

                + ":" + document.forms[0].str_AdultsRoom1.value + ":" + document.forms[0].str_ChildrenRoom1.value + ":"
                + document.forms[0].str_AgeChild1Room1.value + ":" + document.forms[0].str_AgeChild2Room1.value

                + ":" + document.forms[0].str_AdultsRoom2.value + ":" + document.forms[0].str_ChildrenRoom2.value + ":"
                + document.forms[0].str_AgeChild1Room2.value + ":" + document.forms[0].str_AgeChild2Room2.value

                + ":" + document.forms[0].str_AdultsRoom3.value + ":" + document.forms[0].str_ChildrenRoom3.value + ":"
                + document.forms[0].str_AgeChild1Room3.value + ":" + document.forms[0].str_AgeChild2Room3.value

                + ":" + document.forms[0].str_AdultsRoom4.value + ":" + document.forms[0].str_ChildrenRoom4.value + ":"
                + document.forms[0].str_AgeChild1Room4.value + ":" + document.forms[0].str_AgeChild2Room4.value

                );
              // alert($("#hdnValues").val());

               //myfunction();
               showDiv();

               return true;
           }
       }

    </script>
      <script type="text/javascript">
          function showDiv() {
              go();
              go1();
              go2();
              document.getElementById('mainDiv').style.display = "";
              document.getElementById('contentDiv').style.display = "";
              setTimeout('document.images["myAnimatedImage"].src = "../../Images/roller_big.gif"', 200);
          }
          function Load() {
              Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
              function EndRequestHandler(sender, args) {
                  var dateToday = new Date();
                  $(".datepicker").datepicker({
                      dateFormat: 'dd-M-yy',
                      numberOfMonths: 2,
                      showOn: "button",
                      buttonImage: "../../images/calendar.jpg",
                      buttonImageOnly: true,
                      showAnim: 'fadeIn',
                      minDate: dateToday
                  });
                  $("[id$='txtFromDate']").datepicker('setDate', 'today');
                  $(".datepicker1").datepicker({
                      dateFormat: 'dd-M-yy',
                      showOn: "button",
                      numberOfMonths: 2,
                      buttonImage: "../../images/calendar.jpg",
                      buttonImageOnly: true,
                      showAnim: 'fadeIn',
                      minDate: dateToday
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
                  dateFormat: 'dd-M-yy',
                  numberOfMonths: 2,
                  showOn: "button",
                  buttonImage: "../../images/calendar.jpg",
                  buttonImageOnly: true,
                  showAnim: 'fadeIn',
                  minDate: dateToday
              });
              $("[id$='txtFromDate']").datepicker('setDate', 'today');
          });
          $(function () {
              var dateToday = new Date();
              $(".datepicker1").datepicker({
                  dateFormat: 'dd-M-yy',
                  showOn: "button",
                  numberOfMonths: 2,
                  buttonImage: "../../images/calendar.jpg",
                  buttonImageOnly: true,
                  showAnim: 'fadeIn',
                  minDate: dateToday
              });
          });
    </script>
    <style type="text/css">
        .modalContainer
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            position: fixed;
            left: 25%;
            top: 25%;
            z-index: 750;
            background-color: inherit;
            padding: 0px;
        }
        .registerhead
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #044cb5;
            padding: 22px 0 10px 0;
        }
        .loadingBackground
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            filter: Alpha(Opacity=30);
            -moz-opacity: 0.3;
            opacity: 0.6;
            width: 100%;
            height: 1000px;
            background-color: #000;
            position: fixed;
            z-index: 500;
            top: 0px;
            left: 0px;
        }
    </style>

    

    <script type="text/javascript">
        function myfunction() {
            LoadHotels('',

              document.forms[0].strcity.value + "&" + document.forms[0].check_Inhotel.value + "&" + document.forms[0].check_Outhotel.value + "&"
                + document.forms[0].no_ofrooms.value

                + "&" + document.forms[0].str_AdultsRoom1.value + "&" + document.forms[0].str_ChildrenRoom1.value + "&"
                + document.forms[0].str_AgeChild1Room1.value + "&" + document.forms[0].str_AgeChild2Room1.value

                + "&" + document.forms[0].str_AdultsRoom2.value + "&" + document.forms[0].str_ChildrenRoom2.value + "&"
                + document.forms[0].str_AgeChild1Room2.value + "&" + document.forms[0].str_AgeChild2Room2.value

                + "&" + document.forms[0].str_AdultsRoom3.value + "&" + document.forms[0].str_ChildrenRoom3.value + "&"
                + document.forms[0].str_AgeChild1Room3.value + "&" + document.forms[0].str_AgeChild2Room3.value

                + "&" + document.forms[0].str_AdultsRoom4.value + "&" + document.forms[0].str_ChildrenRoom4.value + "&"
                + document.forms[0].str_AgeChild1Room4.value + "&" + document.forms[0].str_AgeChild2Room4.value

            );
            return false;
        }
    </script>
     <script type="text/javascript">
         function go() {
             var DropdownList = document.getElementById('ddlCity');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text3').value = SelectedText;
         }
         function go1() {
             document.getElementById('Text1').value = document.getElementById('check_Inhotel').value;
         }
         function go2() {
             document.getElementById('Text2').value = document.getElementById('check_Outhotel').value;
         }
    </script>
    <input type="hidden" name="currentdate" value="08-09-109-13-17-00" />
    <input type="hidden" name="partnerid" value="222073" />
    <input type="hidden" name="depart1" />
    <input type="hidden" name="return1" />
    <input type="hidden" name="corporate_user_id" value="null" />
    <asp:HiddenField ID="hdnValues" runat="server" />
    <table  border="0" cellpadding="0" cellspacing="0"  width="100%">
        <%--<tr>
            <td align="left" valign="top">
                <table width="964" border="0" height="82" class="header">
                    <tr>
                        <td align="left" valign="top" class="logo">
                            <a href="HotelSearch.aspx">
                                <img src="../../images/logo.gif" border="0" /></a>
                        </td>
                        <td align="left" valign="top">
                            <table width="729" border="0">
                                <tr>
                                    <td width="729" height="41" align="left" valign="top">
                                        <table width="729" height="41" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="103" align="right" valign="top">
                                                    <asp:Label ID="lblUsername" runat="server" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td width="10">
                                                </td>
                                                <td width="580" align="left" valign="top">
                                                  <asp:Menu ID="Menu3" runat="server" Orientation="Horizontal" Width="100%" OnMenuItemClick="Menu3_MenuItemClick">
                                                        <Items>
                                                            <asp:MenuItem NavigateUrl="~/Users/Bus/Bus_Search.aspx" Text="Buses" Value="Buses">
                                                            </asp:MenuItem>
                                                            <asp:MenuItem Text="Flights" Value="Flights" NavigateUrl="~/Users/Flight/frmDomesticAvailability.aspx"></asp:MenuItem>
                                                            <asp:MenuItem Text="Hotels" Value="Hotels" NavigateUrl="~/Users/Hotel/HotelSearch.aspx">
                                                            </asp:MenuItem>
                                                            <asp:MenuItem NavigateUrl="~/Users/Recharge/Recharge.aspx" Text="Recharge" Value="Recharge">
                                                            </asp:MenuItem>
                                                            <asp:MenuItem NavigateUrl="~/Users/Bus/Users.aspx" Text="CSE" Value="CSE"></asp:MenuItem>
                                                            <asp:MenuItem Text="Agents" Value="Agents">
                                                                <asp:MenuItem NavigateUrl="~/Users/Bus/Agents.aspx" Text="View" Value="View"></asp:MenuItem>
                                                                <asp:MenuItem NavigateUrl="~/Users/Bus/frmAgentsDeposits.aspx" Text="Deposits" Value="Deposits">
                                                                </asp:MenuItem>
                                                                <asp:MenuItem NavigateUrl="~/Users/Bus/AgentRequests.aspx" Text="Register Requests"
                                                                    Value="Register Requests"></asp:MenuItem>
                                                                <asp:MenuItem NavigateUrl="~/Users/Bus/FundTransferReport.aspx" Text="Deposit Requests"
                                                                    Value="Deposit Requests"></asp:MenuItem>
                                                            </asp:MenuItem>
                                                            <asp:MenuItem NavigateUrl="~/Users/Bus/PromoCode.aspx" Text="PromoCode" Value="PromoCode">
                                                            </asp:MenuItem>
                                                            <asp:MenuItem NavigateUrl="~/Users/Bus/ViewFeedbacks.aspx" Text="Feedbacks" Value="Feedbacks">
                                                            </asp:MenuItem>
                                                            <asp:MenuItem NavigateUrl="~/Users/Bus/ChangePassword.aspx" Text="ChangePwd" Value="ChangePwd">
                                                            </asp:MenuItem>
                                                            <asp:MenuItem Text="LogOut" Value="LogOut"></asp:MenuItem>
                                                        </Items>
                                                    </asp:Menu>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="729" height="41" align="left" valign="middle" class="menu">
                                        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" Width="100%">
                                            <Items>
                                                <asp:MenuItem NavigateUrl="~/Users/Hotel/HotelSearch.aspx" Text="Book Ticket" Value="Book Ticket">
                                                </asp:MenuItem>
                                                <asp:MenuItem NavigateUrl="~/Users/Hotel/PrintTicket.aspx" Text="Print Ticket" Value="Print Ticket">
                                                </asp:MenuItem>
                                                <asp:MenuItem NavigateUrl="~/Users/Hotel/CancelTicket.aspx" Text="Cancel Ticket"
                                                    Value="Cancel Ticket"></asp:MenuItem>
                                                <asp:MenuItem Text="Bookings" Value="Bookings" NavigateUrl="~/Users/Hotel/Bookings.aspx">
                                                </asp:MenuItem>
                                                <asp:MenuItem NavigateUrl="~/Users/Hotel/AgentBookings.aspx" Text="Agent Bookings"
                                                    Value="Agent Bookings"></asp:MenuItem>
                                            </Items>
                                        </asp:Menu>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        

        

        <tr>
            <td width="964" height="10" align="center" valign="top">
                <table width="964" style="border-bottom: 1px solid #669999;">
                    <tr>
                        <td width="964" height="10" align="center">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <br />
                <table width="100%">
                    <tr>
                        <td width="100%" height="30px" valign="middle" align="left" class="tr" id="td1"
                            runat="server" visible="false">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnlMain" runat="server">
                    <table width="964" border="0" >
                        <tr>
                            <td width="437" height="376" align="center" valign="top" class="onlie-bustickets-bg">
                                <table width="98%" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="35" align="center" colspan="3">
                                            <h3 style="color: #336699; font-size: 21px; margin-left: 32px; margin-top: 10px;
                                                margin-bottom: 10px;">
                                                <span style="color: #cc0000;">Online Hotel </span>Booking</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="35" align="right" class="ft01">
                                            City
                                        </td>
                                        <td width="5%" height="35" align="center" class="ft01">
                                            :
                                        </td>
                                        <td height="35" align="left">
                                            <select name="strcity" id="ddlCity" style="width: 120px;">
                                                <option value="">--Select City-- </option>
                                                <option value="AGRA">AGRA </option>
                                                <option value="BANGALORE">BANGALORE </option>
                                                <option value="CHENNAI">CHENNAI </option>
                                                <option value="GOA">GOA </option>
                                                <option value="HYDERABAD">HYDERABAD </option>
                                                <option value="JAIPUR">JAIPUR </option>
                                                <option value="KOLKATA">KOLKATA </option>
                                                <option value="MUMBAI" name="strcity">MUMBAI / BOMBAY </option>
                                                <option value="NEW DELHI">NEW DELHI </option>
                                                <option value="line">-------------- </option>
                                                <option value="AGARTALA">AGARTALA </option>
                                                <option value="AGRA">AGRA </option>
                                                <option value="AHMEDABAD">AHMEDABAD </option>
                                                <option value="AIZAWL">AIZAWL </option>
                                                <option value="AJMER">AJMER </option>
                                                <option value="AKOLA">AKOLA </option>
                                                <option value="ALIBAG">ALIBAG </option>
                                                <option value="ALLAHABAD">ALLAHABAD </option>
                                                <option value="ALLEPPEY">ALLEPPEY </option>
                                                <option value="ALMORA">ALMORA </option>
                                                <option value="ALSISAR">ALSISAR </option>
                                                <option value="ALWAR">ALWAR </option>
                                                <option value="AMBALA">AMBALA </option>
                                                <option value="AMLA">AMLA </option>
                                                <option value="AMRITSAR">AMRITSAR </option>
                                                <option value="ANAND">ANAND </option>
                                                <option value="ANKLESWAR">ANKLESWAR </option>
                                                <option value="ARONDA">ARONDA </option>
                                                <option value="ASHTAMUDI">ASHTAMUDI </option>
                                                <option value="AULI">AULI </option>
                                                <option value="AUNDH">AUNDH </option>
                                                <option value="AURANGABAD">AURANGABAD </option>
                                                <option value="BADAMI">BADAMI </option>
                                                <option value="BADDI">BADDI </option>
                                                <option value="BADRINATH">BADRINATH </option>
                                                <option value="BALASINOR">BALASINOR </option>
                                                <option value="BALRAMPUR">BALRAMPUR </option>
                                                <option value="BAMBORA">BAMBORA </option>
                                                <option value="BANDHAVGARH">BANDHAVGARH </option>
                                                <option value="BANDIPUR">BANDIPUR </option>
                                                <option value="BANGALORE">BANGALORE </option>
                                                <option value="BARBIL">BARBIL </option>
                                                <option value="BAREILY">BAREILY </option>
                                                <option value="BARKOT">BARKOT </option>
                                                <option value="BARODA">BARODA </option>
                                                <option value="BATHINDA">BATHINDA </option>
                                                <option value="BEHROR">BEHROR </option>
                                                <option value="BELGAUM">BELGAUM </option>
                                                <option value="BERHAMPUR">BERHAMPUR </option>
                                                <option value="BETALGHAT">BETALGHAT </option>
                                                <option value="BHANDARDARA">BHANDARDARA </option>
                                                <option value="BHARATPUR">BHARATPUR </option>
                                                <option value="BHARUCH">BHARUCH </option>
                                                <option value="BHAVANGADH">BHAVANGADH </option>
                                                <option value="BHAVNAGAR">BHAVNAGAR </option>
                                                <option value="BHILAI">BHILAI </option>
                                                <option value="BHILWARA">BHILWARA </option>
                                                <option value="BHIMTAL">BHIMTAL </option>
                                                <option value="BHOPAL">BHOPAL </option>
                                                <option value="BHUBANESHWAR">BHUBANESHWAR </option>
                                                <option value="BHUJ">BHUJ </option>
                                                <option value="BIKANER">BIKANER </option>
                                                <option value="BINSAR">BINSAR </option>
                                                <option value="BODHGAYA">BODHGAYA </option>
                                                <option value="BUNDI">BUNDI </option>
                                                <option value="CALICUT">CALICUT </option>
                                                <option value="CHAIL">CHAIL </option>
                                                <option value="CHAMBA">CHAMBA </option>
                                                <option value="CHAMUNDA DEVI">CHAMUNDA DEVI </option>
                                                <option value="CHANDIGARH">CHANDIGARH </option>
                                                <option value="CHENNAI">CHENNAI </option>
                                                <option value="CHHOTA UDEPUR">CHHOTA UDEPUR </option>
                                                <option value="CHICKMAGALUR">CHICKMAGALUR </option>
                                                <option value="CHIDAMBARAM">CHIDAMBARAM </option>
                                                <option value="CHIPLUN">CHIPLUN </option>
                                                <option value="CHITRAKOOT">CHITRAKOOT </option>
                                                <option value="CHITTORGARH">CHITTORGARH </option>
                                                <option value="COIMBATORE">COIMBATORE </option>
                                                <option value="COONOOR">COONOOR </option>
                                                <option value="COORG">COORG </option>
                                                <option value="CORBETT">CORBETT </option>
                                                <option value="CUTTACK">CUTTACK </option>
                                                <option value="DABHOSA">DABHOSA </option>
                                                <option value="DALHOUSIE">DALHOUSIE </option>
                                                <option value="DAMAN">DAMAN </option>
                                                <option value="DANDELI">DANDELI </option>
                                                <option value="DAPOLI">DAPOLI </option>
                                                <option value="DARJEELING">DARJEELING </option>
                                                <option value="DASADA">DASADA </option>
                                                <option value="DAUSA">DAUSA </option>
                                                <option value="DEHRADUN">DEHRADUN </option>
                                                <option value="DEOGARH">DEOGARH </option>
                                                <option value="DHARAMSHALA">DHARAMSHALA </option>
                                                <option value="DISTT. SEONI">DISTT. SEONI </option>
                                                <option value="DISTT. UMARIA">DISTT. UMARIA </option>
                                                <option value="DHOLPUR">DHOLPUR </option>
                                                <option value="DIBRUGARH">DIBRUGARH </option>
                                                <option value="DIGHA">DIGHA </option>
                                                <option value="DIU">DIU </option>
                                                <option value="DIVE AGAR">DIVE AGAR </option>
                                                <option value="DOOARS">DOOARS </option>
                                                <option value="DUNGARPUR">DUNGARPUR </option>
                                                <option value="DURGAPUR">DURGAPUR </option>
                                                <option value="DURSHET">DURSHET </option>
                                                <option value="DWARKA">DWARKA </option>
                                                <option value="FARIDABAD">FARIDABAD </option>
                                                <option value="FIROZABAD">FIROZABAD </option>
                                                <option value="GANDHIDHAM">GANDHIDHAM </option>
                                                <option value="GANDHINAGAR">GANDHINAGAR </option>
                                                <option value="GANGOTRI">GANGOTRI </option>
                                                <option value="GANGTOK">GANGTOK </option>
                                                <option value="GANPATIPULE">GANPATIPULE </option>
                                                <option value="GARHMUKTESHWAR">GARHMUKTESHWAR </option>
                                                <option value="GARHWAL">GARHWAL </option>
                                                <option value="GAYA">GAYA </option>
                                                <option value="GHANERAO">GHANERAO </option>
                                                <option value="GHANGARIA">GHANGARIA </option>
                                                <option value="GHAZIABAD">GHAZIABAD </option>
                                                <option value="GOA">GOA </option>
                                                <option value="GOKARNA">GOKARNA </option>
                                                <option value="GONDAL">GONDAL </option>
                                                <option value="GOPALPUR">GOPALPUR </option>
                                                <option value="GORAKHPUR">GORAKHPUR </option>
                                                <option value="GULMARG">GULMARG </option>
                                                <option value="GURGAON">GURGAON </option>
                                                <option value="GURUVAYOOR">GURUVAYOOR </option>
                                                <option value="GUWAHATI">GUWAHATI </option>
                                                <option value="GWALIOR">GWALIOR </option>
                                                <option value="HALDWANI">HALDWANI </option>
                                                <option value="HAMPI">HAMPI </option>
                                                <option value="HANSI">HANSI </option>
                                                <option value="HARIDWAR">HARIDWAR </option>
                                                <option value="HASSAN">HASSAN </option>
                                                <option value="HISSAR">HISSAR </option>
                                                <option value="HOSPET">HOSPET </option>
                                                <option value="HOSUR">HOSUR </option>
                                                <option value="HUBLI">HUBLI </option>
                                                <option value="HYDERABAD">HYDERABAD </option>
                                                <option value="IDUKKI">IDUKKI </option>
                                                <option value="IGATPURI">IGATPURI </option>
                                                <option value="IMPHAL">IMPHAL </option>
                                                <option value="INDORE">INDORE </option>
                                                <option value="JABALPUR">JABALPUR </option>
                                                <option value="JAGDALPUR">JAGDALPUR </option>
                                                <option value="JAIPUR">JAIPUR </option>
                                                <option value="JAISALMER">JAISALMER </option>
                                                <option value="JAISAMAND">JAISAMAND </option>
                                                <option value="JALANDHAR">JALANDHAR </option>
                                                <option value="JALGAON">JALGAON </option>
                                                <option value="JAMBUGODHA">JAMBUGODHA </option>
                                                <option value="JAMMU">JAMMU </option>
                                                <option value="JAMNAGAR">JAMNAGAR </option>
                                                <option value="JAMSHEDPUR">JAMSHEDPUR </option>
                                                <option value="JHANSI">JHANSI </option>
                                                <option value="JODHPUR">JODHPUR </option>
                                                <option value="JOJAWAR">JOJAWAR </option>
                                                <option value="JORHAT">JORHAT </option>
                                                <option value="JOSHIMATH">JOSHIMATH </option>
                                                <option value="JUNAGADH">JUNAGADH </option>
                                                <option value="KALIMPONG">KALIMPONG </option>
                                                <option value="KANAM">KANAM </option>
                                                <option value="KANATAL">KANATAL </option>
                                                <option value="KANCHIPURAM">KANCHIPURAM </option>
                                                <option value="KANHA">KANHA </option>
                                                <option value="KANPUR">KANPUR </option>
                                                <option value="KANHA">KANHA </option>
                                                <option value="KANNUR">KANNUR </option>
                                                <option value="KANPUR">KANPUR </option>
                                                <option value="KANYAKUMARI">KANYAKUMARI </option>
                                                <option value="KARAULI">KARAULI </option>
                                                <option value="KARGIL">KARGIL </option>
                                                <option value="KARWAR">KARWAR </option>
                                                <option value="KASAULI">KASAULI </option>
                                                <option value="KASHID">KASHID </option>
                                                <option value="KASHIPUR">KASHIPUR </option>
                                                <option value="KATRA">KATRA </option>
                                                <option value="KALIMPONG">KALIMPONG </option>
                                                <option value="KAUSANI">KAUSANI </option>
                                                <option value="KAZA">KAZA </option>
                                                <option value="KAZIRANGA">KAZIRANGA </option>
                                                <option value="KEDARNATH">KEDARNATH </option>
                                                <option value="KHAJURAHO">KHAJURAHO </option>
                                                <option value="KHANDALA">KHANDALA </option>
                                                <option value="KHAJIAR">KHAJIAR </option>
                                                <option value="KHARAPUR">KHARAPUR </option>
                                                <option value="KHEJARLA">KHEJARLA </option>
                                                <option value="KHIMSAR">KHIMSAR </option>
                                                <option value="KOCHI">KOCHI </option>
                                                <option value="KOCHIN">KOCHIN </option>
                                                <option value="KODAIKANAL">KODAIKANAL </option>
                                                <option value="KOLHAPUR">KOLHAPUR </option>
                                                <option value="KOLKATA">KOLKATA </option>
                                                <option value="KOLLAM">KOLLAM </option>
                                                <option value="KONNI">KONNI </option>
                                                <option value="KOSI">KOSI </option>
                                                <option value="KOTA">KOTA </option>
                                                <option value="KOVALAM">KOVALAM </option>
                                                <option value="KOTAGIRI">KOTAGIRI </option>
                                                <option value="KOTTAYAM">KOTTAYAM </option>
                                                <option value="KOZHIKODE / CALICUT">KOZHIKODE / CALICUT </option>
                                                <option value="KULLU">KULLU </option>
                                                <option value="KUMARAKOM">KUMARAKOM </option>
                                                <option value="KUMBAKONAM">KUMBAKONAM </option>
                                                <option value="KUMBALGARH">KUMBALGARH </option>
                                                <option value="KURSEONG">KURSEONG </option>
                                                <option value="KURUMBADI">KURUMBADI </option>
                                                <option value="KUTCH">KUTCH </option>
                                                <option value="KUSHINAGAR">KUSHINAGAR </option>
                                                <option value="LACHUNG">LACHUNG </option>
                                                <option value="LAKSHADWEEP">LAKSHADWEEP </option>
                                                <option value="LEH">LEH </option>
                                                <option value="LONAVALA">LONAVALA </option>
                                                <option value="LOTHAL">LOTHAL </option>
                                                <option value="LUCKNOW">LUCKNOW </option>
                                                <option value="LUDHIANA">LUDHIANA </option>
                                                <option value="MADURAI">MADURAI </option>
                                                <option value="MAHABALESHWAR">MAHABALESHWAR </option>
                                                <option value="MAHABALIPURAM">MAHABALIPURAM </option>
                                                <option value="MALSHEJ GHAT">MALSHEJ GHAT </option>
                                                <option value="MALVAN">MALVAN </option>
                                                <option value="MAMALLAPURAM">MAMALLAPURAM </option>
                                                <option value="MANALI">MANALI </option>
                                                <option value="MANDAVI">MANDAVI </option>
                                                <option value="MANDAWA">MANDAWA </option>
                                                <option value="MANDI">MANDI </option>
                                                <option value="MANDORMONI">MANDORMONI </option>
                                                <option value="MANDU">MANDU </option>
                                                <option value="MANESAR">MANESAR </option>
                                                <option value="MANGALORE">MANGALORE </option>
                                                <option value="MANIPAL">MANIPAL </option>
                                                <option value="MANVAR">MANVAR </option>
                                                <option value="MARCHULA">MARCHULA </option>
                                                <option value="MASHOBRA">MASHOBRA </option>
                                                <option value="MATHERAN">MATHERAN </option>
                                                <option value="MATHURA">MATHURA </option>
                                                <option value="MCLEODGANJ">MCLEODGANJ </option>
                                                <option value="MEERUT">MEERUT </option>
                                                <option value="MOHALI">MOHALI </option>
                                                <option value="MORADABAD">MORADABAD </option>
                                                <option value="MOUNT ABU">MOUNT ABU </option>
                                                <option value="MUKTESHWAR">MUKTESHWAR </option>
                                                <option value="MUKUNDGARH">MUKUNDGARH </option>
                                                <option value="MUMBAI">MUMBAI / BOMBAY </option>
                                                <option value="MUNDRA">MUNDRA </option>
                                                <option value="MUNNAR">MUNNAR </option>
                                                <option value="MURUD">MURUD </option>
                                                <option value="MURUD JANJIRA">MURUD JANJIRA </option>
                                                <option value="MUSSOORIE">MUSSOORIE </option>
                                                <option value="MYSORE">MYSORE </option>
                                                <option value="NADUKANI">NADUKANI </option>
                                                <option value="NAGAPATTINAM">NAGAPATTINAM </option>
                                                <option value="NAGAUR">NAGAUR </option>
                                                <option value="NAGARHOLE">NAGARHOLE </option>
                                                <option value="NAGAUR FORT">NAGAUR FORT </option>
                                                <option value="NAGPUR">NAGPUR </option>
                                                <option value="NAINITAL">NAINITAL </option>
                                                <option value="NALAGARH">NALAGARH </option>
                                                <option value="NALDEHRA">NALDEHRA </option>
                                                <option value="NANDED">NANDED </option>
                                                <option value="NAPNE">NAPNE </option>
                                                <option value="NARLAI">NARLAI </option>
                                                <option value="NASIK">NASIK </option>
                                                <option value="NATHDWARA">NATHDWARA </option>
                                                <option value="NAUKUCHIYATAL">NAUKUCHIYATAL </option>
                                                <option value="NAVI MUMBAI">NAVI MUMBAI </option>
                                                <option value="NERAL">NERAL </option>
                                                <option value="NEW DELHI">NEW DELHI </option>
                                                <option value="NILGIRI">NILGIRI </option>
                                                <option value="NOIDA">NOIDA </option>
                                                <option value="OOTY">OOTY </option>
                                                <option value="ORCHHA">ORCHHA </option>
                                                <option value="PACHEWAR">PACHEWAR </option>
                                                <option value="PACHMARHI">PACHMARHI </option>
                                                <option value="PAHALGAM">PAHALGAM </option>
                                                <option value="PALAKKAD">PALAKKAD </option>
                                                <option value="PALAMPUR">PALAMPUR </option>
                                                <option value="PALANPUR">PALANPUR </option>
                                                <option value="PALI">PALI </option>
                                                <option value="PALITANA">PALITANA </option>
                                                <option value="PANCHGANI">PANCHGANI </option>
                                                <option value="PANCHKULA">PANCHKULA </option>
                                                <option value="PANCHMARHI">PANCHMARHI </option>
                                                <option value="PANHALA">PANHALA </option>
                                                <option value="PANNA">PANNA </option>
                                                <option value="PANTNAGAR">PANTNAGAR </option>
                                                <option value="PANVEL">PANVEL </option>
                                                <option value="PARADEEP">PARADEEP </option>
                                                <option value="PARWANOO">PARWANOO </option>
                                                <option value="PATHANKOT">PATHANKOT </option>
                                                <option value="PATIALA">PATIALA </option>
                                                <option value="PATNA">PATNA </option>
                                                <option value="PATNITOP">PATNITOP </option>
                                                <option value="PELLING">PELLING </option>
                                                <option value="PENCH">PENCH </option>
                                                <option value="PERIYAR">PERIYAR </option>
                                                <option value="PHAGWARA">PHAGWARA </option>
                                                <option value="PHALODI">PHALODI </option>
                                                <option value="PINJORE">PINJORE </option>
                                                <option value="PONDICHERRY">PONDICHERRY </option>
                                                <option value="POOVAR">POOVAR </option>
                                                <option value="PORBANDAR">PORBANDAR </option>
                                                <option value="PORT BLAIR">PORT BLAIR </option>
                                                <option value="POSHINA">POSHINA </option>
                                                <option value="PRAGPUR">PRAGPUR </option>
                                                <option value="PUNE">PUNE </option>
                                                <option value="PURI">PURI </option>
                                                <option value="PUSKHAR">PUSKHAR </option>
                                                <option value="PUTTAPURTHY">PUTTAPURTHY </option>
                                                <option value="RAIBARELLY">RAIBARELLY </option>
                                                <option value="RAICHAK">RAICHAK </option>
                                                <option value="RAIPUR">RAIPUR </option>
                                                <option value="RAJAMUNDRY">RAJAMUNDRY </option>
                                                <option value="RAJASTHAN">RAJASTHAN </option>
                                                <option value="RAJGIR">RAJGIR </option>
                                                <option value="RAJKOT">RAJKOT </option>
                                                <option value="RAJPIPLA">RAJPIPLA </option>
                                                <option value="RAJSAMAND">RAJSAMAND </option>
                                                <option value="RAM NAGAR">RAM NAGAR </option>
                                                <option value="RAMESHWARAM">RAMESHWARAM </option>
                                                <option value="RAMGARH">RAMGARH </option>
                                                <option value="RANAKPUR">RANAKPUR </option>
                                                <option value="RANCHI">RANCHI </option>
                                                <option value="RANIKHET">RANIKHET </option>
                                                <option value="RANNY">RANNY </option>
                                                <option value="RANTHAMBORE">RANTHAMBORE </option>
                                                <option value="RATNAGIRI">RATNAGIRI </option>
                                                <option value="RAVANGLA">RAVANGLA </option>
                                                <option value="RISHIKESH">RISHIKESH </option>
                                                <option value="RISHYAP">RISHYAP </option>
                                                <option value="ROHETGARH">ROHETGARH </option>
                                                <option value="ROPAR">ROPAR </option>
                                                <option value="ROURKELA">ROURKELA </option>
                                                <option value="RUDRAPRAYAG">RUDRAPRAYAG </option>
                                                <option value="SAJAN">SAJAN </option>
                                                <option value="SALEM">SALEM </option>
                                                <option value="SAMODE">SAMODE </option>
                                                <option value="SAPUTARA">SAPUTARA </option>
                                                <option value="SARISKA">SARISKA </option>
                                                <option value="SASAN GIR">SASAN GIR </option>
                                                <option value="SATTAL">SATTAL </option>
                                                <option value="SAWAI MADHOPUR">SAWAI MADHOPUR </option>
                                                <option value="SAWANTWADI">SAWANTWADI </option>
                                                <option value="SECUNDERABAD">SECUNDERABAD </option>
                                                <option value="SERVICE ISSUE">SERVICE ISSUE </option>
                                                <option value="SHEKAVATI">SHEKAVATI </option>
                                                <option value="SHILLONG">SHILLONG </option>
                                                <option value="SHIMLA">SHIMLA </option>
                                                <option value="SHIRDI">SHIRDI </option>
                                                <option value="SHUT DOWN HOTEL">SHUT DOWN HOTEL </option>
                                                <option value="SIANA">SIANA </option>
                                                <option value="SILIGURI">SILIGURI </option>
                                                <option value="SILVASSA">SILVASSA </option>
                                                <option value="SIVAGANGA DISTRICT">SIVAGANGA DISTRICT </option>
                                                <option value="SOLAN">SOLAN </option>
                                                <option value="SONAULI">SONAULI </option>
                                                <option value="SRAVASTI">SRAVASTI </option>
                                                <option value="SRINAGAR">SRINAGAR </option>
                                                <option value="STARCRUISE">STARCRUISE </option>
                                                <option value="SUNDERBAN">SUNDERBAN </option>
                                                <option value="SURAT">SURAT </option>
                                                <option value="TAPOLA">TAPOLA </option>
                                                <option value="TARAPITH">TARAPITH </option>
                                                <option value="THANE">THANE </option>
                                                <option value="THANJAVUR">THANJAVUR </option>
                                                <option value="THATTEKKAD">THATTEKKAD </option>
                                                <option value="THEKKADY">THEKKADY </option>
                                                <option value="THIRUVANNAMALAI">THIRUVANNAMALAI </option>
                                                <option value="TIRUCHIRAPALLI">TIRUCHIRAPALLI </option>
                                                <option value="THIRUVANANTHAPURAM">THIRUVANANTHAPURAM </option>
                                                <option value="TIRUPATI">TIRUPATI </option>
                                                <option value="TIRUPUR">TIRUPUR </option>
                                                <option value="TRICHUR / THRISSUR">TRICHUR / THRISSUR </option>
                                                <option value="UDHAMPUR">UDHAMPUR </option>
                                                <option value="UDAIPUR">UDAIPUR </option>
                                                <option value="UJJAIN">UJJAIN </option>
                                                <option value="VADODARA">VADODARA </option>
                                                <option value="VAGAMON">VAGAMON </option>
                                                <option value="VALSAD">VALSAD </option>
                                                <option value="VAPI">VAPI </option>
                                                <option value="VARANASI">VARANASI </option>
                                                <option value="VARKALA">VARKALA </option>
                                                <option value="VELANKANNI">VELANKANNI </option>
                                                <option value="VELLORE">VELLORE </option>
                                                <option value="VERAVAL">VERAVAL </option>
                                                <option value="VIJAYAWADA">VIJAYAWADA </option>
                                                <option value="VIKRAMGADH">VIKRAMGADH </option>
                                                <option value="VILLAGE TIPPI">VILLAGE TIPPI </option>
                                                <option value="VISHAKAPATNAM">VISHAKAPATNAM </option>
                                                <option value="WANKANER">WANKANER </option>
                                                <option value="WAYANAD">WAYANAD </option>
                                                <option value="WEST KEMENG">WEST KEMENG </option>
                                                <option value="YAMUNOTRI">YAMUNOTRI </option>
                                                <option value="YERCAUD">YERCAUD </option>
                                                <option value="YUKSOM">YUKSOM </option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="35" align="right" class="ft01">
                                            Check In
                                        </td>
                                        <td height="35" align="center" class="ft01">
                                            :
                                        </td>
                                        <td height="35" align="left">
                                            <input size="15" type="text" name="check_Inhotel" onclick="showDate();" onfocus="this.blur();"
                                                class="datepicker" id="check_Inhotel" value="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="35" align="right" class="ft01">
                                            Check Out
                                        </td>
                                        <td height="35" align="center" class="ft01">
                                            :
                                        </td>
                                        <td height="35" align="left">
                                            <input type="text" size="15" name="check_Outhotel" onfocus="this.blur();" onclick="showDate1();"
                                                class="datepicker1" id="check_Outhotel" value="" />
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td height="35" align="right" class="ft01">
                                            Hotel Rating
                                        </td>
                                        <td height="35" align="center" class="ft01">
                                            :
                                        </td>
                                        <td height="35" align="left">
                                            <select style="width: 120px;" size="1" name="hotelPreference">
                                                <option value="0">All </option>
                                                <option value="5">5 Star and above </option>
                                                <option value="4">4 Star and above </option>
                                                <option value="3">3 Star and above </option>
                                                <option value="2">2 Star and above </option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="35" align="right" class="ft01">
                                            Rooms
                                        </td>
                                        <td height="35" align="center" class="ft01">
                                            :
                                        </td>
                                        <td height="35" align="left">
                                            <select size="1" name="no_ofrooms" style="width: 120px;" onchange="javascript:changeRows();">
                                                <option value="1">1 </option>
                                                <option value="2">2 </option>
                                                <option value="3">3 </option>
                                                <option value="4" selected="selected">4 </option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="3">
                                            <table align="center" width="290" cellpadding="0" cellspacing="4" border="0" style="border-collapse: collapse">
                                                <tr>
                                                    <td align="center" class="ft01" valign="middle">
                                                        <b>Room</b>
                                                    </td>
                                                    <td align="center" class="ft01">
                                                        <b>Adults</b>
                                                        <br />
                                                        (age 12+)
                                                    </td>
                                                    <td align="center" class="ft01">
                                                        <b>Children </b>
                                                        <br />
                                                        (0 - 2)
                                                    </td>
                                                    <td>
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse">
                                                            <tr>
                                                                <td width="33%" id="chld1" align="center" class="ft01">
                                                                    <b>Child1</b>
                                                                    <br />
                                                                    (Age)
                                                                </td>
                                                                <td width="33%" id="chld2" align="center" class="ft01">
                                                                    <b>Child2</b>
                                                                    <br />
                                                                    (Age)
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="row1">
                                                    <td align="center">
                                                        1
                                                    </td>
                                                    <td align="center">
                                                        <select size="1" name="str_AdultsRoom1" class="ddladults">
                                                            <option value="1">1 </option>
                                                            <option value="2">2 </option>
                                                            <option value="3">3 </option>
                                                            <option value="4">4 </option>
                                                        </select>
                                                    </td>
                                                    <td align="center">
                                                        <select size="1" name="str_ChildrenRoom1" onchange="javascript:showRoomsChildren1();" class="ddladults">
                                                            <option value="0" checked>0 </option>
                                                            <option value="1">1 </option>
                                                            <option value="2">2 </option>
                                                        </select>
                                                    </td>
                                                    <td>
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse">
                                                            <tr>
                                                                <td align="left" width="50%" id="child11">
                                                                    <select size="1" name="str_AgeChild1Room1" class="ddladults">
                                                                        <option value="-1">-- </option>
                                                                        <option value="0"><1 </option>
                                                                        <option value="1">1 </option>
                                                                        <option value="2">2 </option>
                                                                        <option value="3">3 </option>
                                                                        <option value="4">4 </option>
                                                                        <option value="5">5 </option>
                                                                        <option value="6">6 </option>
                                                                        <option value="7">7 </option>
                                                                        <option value="8">8 </option>
                                                                        <option value="9">9 </option>
                                                                        <option value="10">10 </option>
                                                                        <option value="11">11 </option>
                                                                        <option value="12">12 </option>
                                                                    </select>
                                                                </td>
                                                                <td align="center" width="50%" id="child12">
                                                                    <select size="1" name="str_AgeChild2Room1" class="ddladults">
                                                                        <option value="-1">-- </option>
                                                                        <option value="0"><1 </option>
                                                                        <option value="1">1 </option>
                                                                        <option value="2">2 </option>
                                                                        <option value="3">3 </option>
                                                                        <option value="4">4 </option>
                                                                        <option value="5">5 </option>
                                                                        <option value="6">6 </option>
                                                                        <option value="7">7 </option>
                                                                        <option value="8">8 </option>
                                                                        <option value="9">9 </option>
                                                                        <option value="10">10 </option>
                                                                        <option value="11">11 </option>
                                                                        <option value="12">12 </option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="row2">
                                                    <td align="center" class="smalltext">
                                                        2
                                                    </td>
                                                    <td align="center">
                                                        <select size="1" name="str_AdultsRoom2" class="ddladults">
                                                            <option value="1" selected="selected">1 </option>
                                                            <option value="2">2 </option>
                                                            <option value="3">3 </option>
                                                            <option value="4">4 </option>
                                                        </select>
                                                    </td>
                                                    <td align="center">
                                                        <select size="1" name="str_ChildrenRoom2" onchange="javascript:showRoomsChildren2();" class="ddladults">
                                                            <option value="0" checked>0 </option>
                                                            <option value="1">1 </option>
                                                            <option value="2">2 </option>
                                                        </select>
                                                    </td>
                                                    <td>
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse">
                                                            <tr>
                                                                <td align="left" width="33%" id="child21">
                                                                    <select size="1" name="str_AgeChild1Room2" class="ddladults">
                                                                        <option value="-1">-- </option>
                                                                        <option value="0"><1 </option>
                                                                        <option value="1">1 </option>
                                                                        <option value="2">2 </option>
                                                                        <option value="3">3 </option>
                                                                        <option value="4">4 </option>
                                                                        <option value="5">5 </option>
                                                                        <option value="6">6 </option>
                                                                        <option value="7">7 </option>
                                                                        <option value="8">8 </option>
                                                                        <option value="9">9 </option>
                                                                        <option value="10">10 </option>
                                                                        <option value="11">11 </option>
                                                                        <option value="12">12 </option>
                                                                    </select>
                                                                </td>
                                                                <td align="center" width="33%" id="child22">
                                                                    <select size="1" name="str_AgeChild2Room2" class="ddladults">
                                                                        <option value="-1">-- </option>
                                                                        <option value="0"><1 </option>
                                                                        <option value="1">1 </option>
                                                                        <option value="2">2 </option>
                                                                        <option value="3">3 </option>
                                                                        <option value="4">4 </option>
                                                                        <option value="5">5 </option>
                                                                        <option value="6">6 </option>
                                                                        <option value="7">7 </option>
                                                                        <option value="8">8 </option>
                                                                        <option value="9">9 </option>
                                                                        <option value="10">10 </option>
                                                                        <option value="11">11 </option>
                                                                        <option value="12">12 </option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="row3">
                                                    <td align="center" class="smalltext">
                                                        3
                                                    </td>
                                                    <td align="center">
                                                        <select size="1" name="str_AdultsRoom3" class="ddladults">
                                                            <option value="1" selected="selected">1 </option>
                                                            <option value="2">2 </option>
                                                            <option value="3">3 </option>
                                                            <option value="4">4 </option>
                                                        </select>
                                                    </td>
                                                    <td align="center">
                                                        <select size="1" name="str_ChildrenRoom3" onchange="javascript:showRoomsChildren3();" class="ddladults">
                                                            <option value="0" checked>0 </option>
                                                            <option value="1">1 </option>
                                                            <option value="2">2 </option>
                                                        </select>
                                                    </td>
                                                    <td>
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse">
                                                            <tr>
                                                                <td align="left" width="33%" id="child31">
                                                                    <select size="1" name="str_AgeChild1Room3" class="ddladults">
                                                                        <option value="-1">-- </option>
                                                                        <option value="0"><1 </option>
                                                                        <option value="1">1 </option>
                                                                        <option value="2">2 </option>
                                                                        <option value="3">3 </option>
                                                                        <option value="4">4 </option>
                                                                        <option value="5">5 </option>
                                                                        <option value="6">6 </option>
                                                                        <option value="7">7 </option>
                                                                        <option value="8">8 </option>
                                                                        <option value="9">9 </option>
                                                                        <option value="10">10 </option>
                                                                        <option value="11">11 </option>
                                                                        <option value="12">12 </option>
                                                                    </select>
                                                                </td>
                                                                <td align="center" width="33%" id="child32">
                                                                    <select size="1" name="str_AgeChild2Room3" class="ddladults">
                                                                        <option value="-1">-- </option>
                                                                        <option value="0"><1 </option>
                                                                        <option value="1">1 </option>
                                                                        <option value="2">2 </option>
                                                                        <option value="3">3 </option>
                                                                        <option value="4">4 </option>
                                                                        <option value="5">5 </option>
                                                                        <option value="6">6 </option>
                                                                        <option value="7">7 </option>
                                                                        <option value="8">8 </option>
                                                                        <option value="9">9 </option>
                                                                        <option value="10">10 </option>
                                                                        <option value="11">11 </option>
                                                                        <option value="12">12 </option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="row4">
                                                    <td align="center" class="smalltext">
                                                        4
                                                    </td>
                                                    <td align="center">
                                                        <select size="1" name="str_AdultsRoom4" class="ddladults">
                                                            <option value="1" selected="selected">1 </option>
                                                            <option value="2">2 </option>
                                                            <option value="3">3 </option>
                                                            <option value="4">4 </option>
                                                        </select>
                                                    </td>
                                                    <td align="center">
                                                        <select size="1" name="str_ChildrenRoom4" onchange="javascript:showRoomsChildren4();" class="ddladults">
                                                            <option value="0" checked>0 </option>
                                                            <option value="1">1 </option>
                                                            <option value="2">2 </option>
                                                        </select>
                                                    </td>
                                                    <td>
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse">
                                                            <tr>
                                                                <td align="left" width="33%" id="child41">
                                                                    <select size="1" name="str_AgeChild1Room4" class="ddladults">
                                                                        <option value="-1">-- </option>
                                                                        <option value="0"><1 </option>
                                                                        <option value="1">1 </option>
                                                                        <option value="2">2 </option>
                                                                        <option value="3">3 </option>
                                                                        <option value="4">4 </option>
                                                                        <option value="5">5 </option>
                                                                        <option value="6">6 </option>
                                                                        <option value="7">7 </option>
                                                                        <option value="8">8 </option>
                                                                        <option value="9">9 </option>
                                                                        <option value="10">10 </option>
                                                                        <option value="11">11 </option>
                                                                        <option value="12">12 </option>
                                                                    </select>
                                                                </td>
                                                                <td align="center" width="33%" id="child42">
                                                                    <select size="1" name="str_AgeChild2Room4" class="ddladults">
                                                                        <option value="-1">-- </option>
                                                                        <option value="0"><1 </option>
                                                                        <option value="1">1 </option>
                                                                        <option value="2">2 </option>
                                                                        <option value="3">3 </option>
                                                                        <option value="4">4 </option>
                                                                        <option value="5">5 </option>
                                                                        <option value="6">6 </option>
                                                                        <option value="7">7 </option>
                                                                        <option value="8">8 </option>
                                                                        <option value="9">9 </option>
                                                                        <option value="10">10 </option>
                                                                        <option value="11">11 </option>
                                                                        <option value="12">12 </option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td colspan="3" align="center" class="ft01">
                                            &nbsp;<b>Are you a resident of India ?</b>
                                            <br />
                                            <input type="radio" class="ft01" name="c_urrency" value="INR" checked />
                                            &nbsp;<b>Yes</b>&nbsp;
                                            <input type="radio" class="ft01" name="c_urrency" value="USD" />
                                            &nbsp;<b>No</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="35" align="center" class="ft01">
                                            <asp:Button ID="btnSearch1" runat="server" Text="Search Hotels" OnClick="btnSearch1_Click1" CssClass="buttonBook"
                                                ValidationGroup="Search" OnClientClick="return startsearch();" />
                                            <span id="Span1" style="display: none" class="loadingBackground"></span><span id="Span2"
                                                style="display: none" class="modalContainer">
                                                <div class="registerhead">
                                                    <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
                                                        <tr>
                                                            <td width="9" height="8">
                                                                <img src="../../images/l1.png" width="9" height="8" />
                                                            </td>
                                                            <td height="8" width="582" bgcolor="#ffffff">
                                                            </td>
                                                            <td width="9" height="8">
                                                                <img src="../../images/l2.png" width="9" height="8" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" bgcolor="#ffffff" align="center" valign="top">
                                                                <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td align="center" height="25" valign="top">
                                                                            <img src="../../images/logo.gif" alt="Logo" border="0" title="LoveJourney">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="1" bgcolor="#c6c6c6">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" class="almost" height="20">
                                                                            Almost there
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <img src="../../images/loading.gif" width="100" height="100" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" class="almost12" height="20">
                                                                            Searching for Hotels
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" height="20" width="582">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td width="100%" align="center">
                                                                                        City&nbsp;&nbsp;
                                                                                        <input id="Text4" type="text" style="border: 0;" />&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="100%" align="center">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td width="50%" align="center">
                                                                                                    CheckIn&nbsp;&nbsp;
                                                                                                    <input id="Text5" type="text" style="border: 0;" />
                                                                                                </td>
                                                                                                <td width="50%" align="center">
                                                                                                    CheckOut&nbsp;&nbsp;
                                                                                                    <input id="Text6" type="text" style="border: 0;" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" height="20" width="100%">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="9" height="8">
                                                                <img src="../../images/l3.png" width="9" height="8" />
                                                            </td>
                                                            <td height="8" width="582" bgcolor="#ffffff">
                                                            </td>
                                                            <td width="9" height="8">
                                                                <img src="../../images/l4.png" width="9" height="8" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="527" height="376" align="left" valign="top">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        

      <%--  <tr>
            <td width="964" height="3" align="left" valign="top">
                <table width="964" style="border-bottom: 1px solid #669999;">
                    <tr>
                        <td width="260" height="30" align="center" valign="middle" class="footer-menu">
                        </td>
                        <td width="390" height="30" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td width="314" height="30" align="center" valign="middle">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="964" align="center" valign="middle">
                Copyright @ All Rights Reserved By LoveJourney.in
            </td>
        </tr>--%>
    </table>
   </asp:Panel>
  <asp:Panel ID="pnlAdminDomesticFlights" runat="server">
     <script type="text/javascript">
         function ValueChangedHandler(sender, args) {


             document.getElementById("ctl00_ContentPlaceHolder1_lbl11").innerHTML = document.getElementById('<%= HiddenField2.ClientID %>').value;

             document.getElementById("lbl").innerHTML = document.getElementById('<%= HiddenField1.ClientID %>').value;

         }
         function Load() {

             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 var dateToday = new Date();
                 $(".datepicker").datepicker({
                     dateFormat: 'yy-mm-dd',
                     numberOfMonths: 2,
                     showOn: "button",
                     buttonImage: "../../images/calendar.jpg",
                     buttonImageOnly: true,
                     showAnim: 'fadeIn',
                     minDate: dateToday
                 });

                 $(".datepicker1").datepicker({
                     dateFormat: 'yy-mm-dd',
                     showOn: "button",
                     numberOfMonths: 1,
                     buttonImage: "../../images/calendar.jpg",
                     buttonImageOnly: true,
                     showAnim: 'fadeIn',
                     minDate: dateToday
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
                 dateFormat: 'yy-mm-dd',
                 numberOfMonths: 2,
                 showOn: "button",
                 buttonImage: "../../images/calendar.jpg",
                 buttonImageOnly: true,
                 showAnim: 'fadeIn',
                 minDate: dateToday
             });

         });
         $(function () {
             var dateToday = new Date();
             $(".datepicker1").datepicker({
                 dateFormat: 'yy-mm-dd',
                 showOn: "button",
                 numberOfMonths: 1,
                 buttonImage: "../../images/calendar.jpg",
                 buttonImageOnly: true,
                 showAnim: 'fadeIn',
                 minDate: dateToday
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
                 setTimeout('document.images["myAnimatedImage"].src = "../../Images/roller_big.gif"', 200);
             }
             else {
                 return false;
             }
         }

         function showDiv2() {
             Page_ClientValidate("SearchInt");
             if (Page_ClientValidate("SearchInt")) {
                 goInt();
                 go1Int();
                 go2Int();
                 document.getElementById('mainDiv2').style.display = "";
                 document.getElementById('contentDiv2').style.display = "";
                 setTimeout('document.images["myAnimatedImage"].src = "../../Images/roller_big.gif"', 200);
             }
             else {
                 return false;
             }
         }
      
    </script>
     <script type="text/javascript">
         function go() {
             var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text1').value = SelectedText;
         }
         function go1() {
             var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text2').value = SelectedText;
         }
         function go2() {
             var SelectedText = document.getElementById('<%=txtFromDate.ClientID %>');
             var strAr = SelectedText.value.split("-");
             var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
             document.getElementById('Text3').value = sel;


         }

         function goInt() {
             var DropdownList = document.getElementById('<%=ddlSourcesSearch.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text4').value = SelectedText;
         }
         function go1Int() {
             var DropdownList = document.getElementById('<%=ddlDestinationsSearch.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text5').value = SelectedText;
         }
         function go2Int() {
             var SelectedText = document.getElementById('<%=txtdatesearch.ClientID %>');
             var strAr = SelectedText.value.split("-");
             var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
             document.getElementById('Text6').value = sel;
         }

    </script>
     <table>
     <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="td2"
                runat="server" visible="false">
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="panelBookingStatus" runat="server">
    <table width="964" border="0" class="container">  
        <tr>
            <td>
                <div>  <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    <asp:Panel ID="pnlSearch" runat="server">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <table width="980">                               
                                        <tr>
                                            <td width="300">
                                                <table align="left" id="tblSearch" runat="server" valign="top" width="710" border="0"
                                                    cellpadding="0" cellspacing="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left" width="300">
                                                                <table width="350" align="center" runat="server" border="0" cellspacing="0" id="tbl_domesticFlights"
                                                                    cellpadding="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td class="agent" height="30" valign="middle" align="center" bgcolor="#0062af" style="color: Black">
                                                                                <div id="dom_flight" style="display: block;">
                                                                                    Domestic Flights
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td bgcolor="#990000">
                                                                                <table width="100%" border="0" cellpadding="1" cellspacing="1" height="280">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td valign="top" align="center" bgcolor="#ffffff">
                                                                                                <div id="DomesticFlight" style="display: block;">
                                                                                                    <table width="98%" border="0" cellpadding="0" cellspacing="0">
                                                                                                        <tr>
                                                                                                            <td valign="top" height="28" align="left">
                                                                                                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                    <tr>
                                                                                                                        <td width="155" valign="middle" align="center">
                                                                                                                            <asp:RadioButton ID="DrbtnOneWay" Text="One Way" runat="server" Checked="true" AutoPostBack="True"
                                                                                                                                GroupName="ONE" OnCheckedChanged="DrbtnOneWay_CheckedChanged" Font-Names="Arial" />
                                                                                                                        </td>
                                                                                                                        <td valign="middle" align="left">
                                                                                                                            <asp:RadioButton ID="DrbtnRoundTrip" Text="Round Trip" runat="server" AutoPostBack="True"
                                                                                                                                GroupName="ONE" OnCheckedChanged="DrbtnRoundTrip_CheckedChanged" Font-Names="Arial" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td width="155" height="28" valign="top" align="left">
                                                                                                                            Leaving From :
                                                                                                                        </td>
                                                                                                                        <td valign="top" height="28" align="left">
                                                                                                                            <asp:DropDownList ID="AddlSources" ValidationGroup="Search" runat="server" Width="150px">
                                                                                                                                <asp:ListItem Selected="True" Value="BOM">MUMBAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="line1">-------------------------------</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXA">AGARTALA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AGX">AGATTI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AGR">AGRA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AMD">AHMEDABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AJL">AIJWAL</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AKD">AKOLA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXD">ALLAHABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXV">ALONG</asp:ListItem>
                                                                                                                                <asp:ListItem Value="ATQ">AMRITSAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXU">AURANGABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXB">BAGDOGRA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RGH">BALURGHAT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXG">BELGAUM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BEP">BELLARY</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BUP">BHATINDA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BHU">BHAVNAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BHO">BHOPAL</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BBI">BHUBANESHWAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BHJ">BHUJ</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KUU">BHUNTAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BKB">BIKANER</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PAB">BILASPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CCJ">CALICUT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CBD">CAR NICOBAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXC">CHANDIGARH</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="COK">COCHIN</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CJB">COIMBATORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="COH">COOCH BEHAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CDP">CUDDAPAH</asp:ListItem>
                                                                                                                                <asp:ListItem Value="NMB">DAMAN</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DAE">DAPARIZO</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DAI">DARJEELING</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DED">DEHRA DUN</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DEP">DEPARIZO</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DBD">DHANBAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DHM">DHARAMSALA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DIB">DIBRUGARH</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DMU">DIMAPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DIU">DIU</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GAY">GAYA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GOI">GOA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GOP">GORAKHPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GUX">GUNA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GAU">GUWAHATI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GWL">GWALIOR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HSS">HISSAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HBX">HUBLI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IMF">IMPHAL</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IDR">INDORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JLR">JABALPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JGB">JAGDALPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JAI">JAIPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JSA">JAISALMER</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXJ">JAMMU</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JGA">JAMNAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXW">JAMSHEDPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PYB">JEYPORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JDH">JODHPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JRH">JORHAT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXH">KAILASHAHAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXQ">KAMALPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXY">KANDLA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KNU">KANPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXK">KESHOD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HJR">KHAJURAHO</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXN">KHOWAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KLH">KOLHAPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KTU">KOTA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KUU">KULU</asp:ListItem>
                                                                                                                                <asp:ListItem Value="LTU">LATUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXL">LEH</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXI">LILABARI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="LKO">LUCKNOW</asp:ListItem>
                                                                                                                                <asp:ListItem Value="LUH">LUDHIANA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXM">MADURAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="LDA">MALDA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXE">MANGALORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MOH">MOHANBARI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MZA">MUZAFFARNAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MZU">MUZAFFARPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MYQ">MYSORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="NAG">NAGPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="NDC">NANDED</asp:ListItem>
                                                                                                                                <asp:ListItem Value="ISK">NASIK</asp:ListItem>
                                                                                                                                <asp:ListItem Value="NVY">NEYVELI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="OMN">OSMANABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PGH">PANTNAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXT">PASIGHAT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXP">PATHANKOT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PAT">PATNA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PNY">PONDICHERRY</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PBD">PORBANDAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXZ">PORTBLAIR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PNQ">PUNE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PUT">PUTTAPARTHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BEK">PUTTAPARTHY</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RPR">RAIPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RJA">RAJAHMUNDRY</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RAJ">RAJKOT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RJI">RAJOURI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RMD">RAMAGUNDAM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXR">RANCHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RTC">RATNAGIRI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="REW">REWA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RRK">ROURKELA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RUP">RUPSI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SXV">SALEM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TNI">SATNA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SHL">SHILLONG</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SSE">SHOLAPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXS">SILCHAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SLV">SIMLA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SXR">SRINAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="STV">SURAT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TEZ">TEZPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TEI">TEZU</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TJV">THANJAVUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TRV">TRIVANDRUM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TRZ">TIRUCHIRAPALLI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TIR">TIRUPATI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="ICH">TRICHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TCR">TUTICORIN</asp:ListItem>
                                                                                                                                <asp:ListItem Value="UDR">UDAIPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BDQ">VADODRA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="VNS">VARANASI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="VGA">VIJAYAWADA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="VTZ">VISHAKHAPATNAM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="WGC">WARANGAL</asp:ListItem>
                                                                                                                            </asp:DropDownList>
                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None" ValidationGroup="Search"
                                                                                                                                runat="server" ErrorMessage="Select source." ControlToValidate="AddlSources" InitialValue="----------"></asp:RequiredFieldValidator>
                                                                                                                            <asp:ValidatorCalloutExtender ID="avce" runat="server" TargetControlID="RequiredFieldValidator4">
                                                                                                                            </asp:ValidatorCalloutExtender>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td valign="top" height="28" align="left">
                                                                                                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                    <tr>
                                                                                                                        <td width="155" valign="top" align="left">
                                                                                                                            Leaving To :
                                                                                                                        </td>
                                                                                                                        <td valign="top" align="left">
                                                                                                                            <asp:DropDownList ID="AddlDestinations" runat="server" ValidationGroup="Search" CssClass="Dropdownlist"
                                                                                                                                onchange="showDate();" Width="150px">
                                                                                                                                <asp:ListItem Selected="True" Value="DEL">DELHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="line1">-------------------------------</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXA">AGARTALA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AGX">AGATTI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AGR">AGRA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AMD">AHMEDABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AJL">AIJWAL</asp:ListItem>
                                                                                                                                <asp:ListItem Value="AKD">AKOLA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXD">ALLAHABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXV">ALONG</asp:ListItem>
                                                                                                                                <asp:ListItem Value="ATQ">AMRITSAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXU">AURANGABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXB">BAGDOGRA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RGH">BALURGHAT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXG">BELGAUM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BEP">BELLARY</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BUP">BHATINDA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BHU">BHAVNAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BHO">BHOPAL</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BBI">BHUBANESHWAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BHJ">BHUJ</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KUU">BHUNTAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BKB">BIKANER</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PAB">BILASPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CCJ">CALICUT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CBD">CAR NICOBAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXC">CHANDIGARH</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="COK">COCHIN</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CJB">COIMBATORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="COH">COOCH BEHAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CDP">CUDDAPAH</asp:ListItem>
                                                                                                                                <asp:ListItem Value="NMB">DAMAN</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DAE">DAPARIZO</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DAI">DARJEELING</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DED">DEHRA DUN</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DEP">DEPARIZO</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DBD">DHANBAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DHM">DHARAMSALA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DIB">DIBRUGARH</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DMU">DIMAPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="DIU">DIU</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GAY">GAYA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GOI">GOA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GOP">GORAKHPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GUX">GUNA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GAU">GUWAHATI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="GWL">GWALIOR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HSS">HISSAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HBX">HUBLI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IMF">IMPHAL</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IDR">INDORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JLR">JABALPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JGB">JAGDALPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JAI">JAIPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JSA">JAISALMER</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXJ">JAMMU</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JGA">JAMNAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXW">JAMSHEDPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PYB">JEYPORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JDH">JODHPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="JRH">JORHAT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXH">KAILASHAHAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXQ">KAMALPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXY">KANDLA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KNU">KANPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXK">KESHOD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="HJR">KHAJURAHO</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXN">KHOWAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KLH">KOLHAPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KTU">KOTA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="KUU">KULU</asp:ListItem>
                                                                                                                                <asp:ListItem Value="LTU">LATUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXL">LEH</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXI">LILABARI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="LKO">LUCKNOW</asp:ListItem>
                                                                                                                                <asp:ListItem Value="LUH">LUDHIANA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXM">MADURAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="LDA">MALDA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXE">MANGALORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MOH">MOHANBARI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MZA">MUZAFFARNAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MZU">MUZAFFARPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="MYQ">MYSORE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="NAG">NAGPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="NDC">NANDED</asp:ListItem>
                                                                                                                                <asp:ListItem Value="ISK">NASIK</asp:ListItem>
                                                                                                                                <asp:ListItem Value="NVY">NEYVELI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="OMN">OSMANABAD</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PGH">PANTNAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXT">PASIGHAT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXP">PATHANKOT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PAT">PATNA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PNY">PONDICHERRY</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PBD">PORBANDAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXZ">PORTBLAIR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PNQ">PUNE</asp:ListItem>
                                                                                                                                <asp:ListItem Value="PUT">PUTTAPARTHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BEK">PUTTAPARTHY</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RPR">RAIPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RJA">RAJAHMUNDRY</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RAJ">RAJKOT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RJI">RAJOURI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RMD">RAMAGUNDAM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXR">RANCHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RTC">RATNAGIRI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="REW">REWA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RRK">ROURKELA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="RUP">RUPSI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SXV">SALEM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TNI">SATNA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SHL">SHILLONG</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SSE">SHOLAPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="IXS">SILCHAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SLV">SIMLA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="SXR">SRINAGAR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="STV">SURAT</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TEZ">TEZPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TEI">TEZU</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TJV">THANJAVUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TRV">TRIVANDRUM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TRZ">TIRUCHIRAPALLI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TIR">TIRUPATI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="ICH">TRICHI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="TCR">TUTICORIN</asp:ListItem>
                                                                                                                                <asp:ListItem Value="UDR">UDAIPUR</asp:ListItem>
                                                                                                                                <asp:ListItem Value="BDQ">VADODRA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="VNS">VARANASI</asp:ListItem>
                                                                                                                                <asp:ListItem Value="VGA">VIJAYAWADA</asp:ListItem>
                                                                                                                                <asp:ListItem Value="VTZ">VISHAKHAPATNAM</asp:ListItem>
                                                                                                                                <asp:ListItem Value="WGC">WARANGAL</asp:ListItem>
                                                                                                                            </asp:DropDownList>
                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Search"
                                                                                                                                runat="server" ErrorMessage="Select destination." Display="None" ControlToValidate="AddlDestinations"
                                                                                                                                InitialValue="----------"></asp:RequiredFieldValidator>
                                                                                                                            <asp:ValidatorCalloutExtender ID="vceDestinations" runat="server" TargetControlID="RequiredFieldValidator5">
                                                                                                                            </asp:ValidatorCalloutExtender>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td valign="top" height="28" align="left">
                                                                                                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                    <tr>
                                                                                                                        <td width="155" valign="top" align="left">
                                                                                                                            Departure On :
                                                                                                                        </td>
                                                                                                                        <td valign="top" align="left">
                                                                                                                            <asp:TextBox ID="AtxtFromDate" ValidationGroup="Search" runat="server" onKeyPress="javascript: return false;"
                                                                                                                                onPaste="javascript: return false;" CssClass="datepicker" OnClick="showDate();"
                                                                                                                                OnTextChanged="NextDate" AutoPostBack="true" Width="150px" />
                                                                                                                            <asp:RequiredFieldValidator ID="rfvDepartureOn" ValidationGroup="Search"
                                                                                                                                runat="server" ErrorMessage="Enter date." ControlToValidate="AtxtFromDate" Display="None"></asp:RequiredFieldValidator>
                                                                                                                            <asp:ValidatorCalloutExtender ID="VceDepartureOn" runat="server" TargetControlID="rfvDepartureOn">
                                                                                                                            </asp:ValidatorCalloutExtender>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td valign="top" height="28" align="left">
                                                                                                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                    <tr>
                                                                                                                        <td width="155" valign="top" align="left">
                                                                                                                            <asp:Label ID="Label4" Text="Return On :" runat="server"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td valign="top" align="left">
                                                                                                                            <asp:TextBox ID="AtxtReturnDate" runat="server" Enabled="False" Visible="true" ValidationGroup="Search"
                                                                                                                                onKeyPress="javascript: return false;" onPaste="javascript: return false;" OnClick="showDate1();"
                                                                                                                                Width="150px" />
                                                                                                                            <asp:RequiredFieldValidator ID="rfvReturnDate" ControlToValidate="AtxtReturnDate"
                                                                                                                                runat="server" Visible="false" ErrorMessage="Enter return date." Display="None"
                                                                                                                                ValidationGroup="Search"></asp:RequiredFieldValidator>
                                                                                                                            <asp:ValidatorCalloutExtender ID="vceReturndate" runat="server" TargetControlID="rfvReturnDate">
                                                                                                                            </asp:ValidatorCalloutExtender>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="4" align="left" height="25">
                                                                                                                <span class="ft01">Adult&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                    Child</span><span class="ft03">(2-11 yrs)</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                <span class="ft01">Infant</span><span class="ft03">(&lt;2yrs)</span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="4" valign="top" align="left" height="25">
                                                                                                                <asp:DropDownList ID="ddlAdult" class="ft02" runat="server">
                                                                                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                                                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                                                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                                                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                                                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                                                                                    <asp:ListItem Value="6">06</asp:ListItem>
                                                                                                                    <asp:ListItem Value="7">07</asp:ListItem>
                                                                                                                    <asp:ListItem Value="8">08</asp:ListItem>
                                                                                                                    <asp:ListItem Value="9">09</asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                <img src="arzoo_search_files/blk.gif" width="40" height="1">
                                                                                                                <asp:DropDownList ID="ddlChild" class="ft02" runat="server">
                                                                                                                    <asp:ListItem Value="0">00</asp:ListItem>
                                                                                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                                                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                                                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                                                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                                                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                                                                                    <asp:ListItem Value="6">06</asp:ListItem>
                                                                                                                    <asp:ListItem Value="7">07</asp:ListItem>
                                                                                                                    <asp:ListItem Value="8">08</asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                <img src="arzoo_search_files/blk.gif" width="55" height="1">
                                                                                                                <asp:DropDownList ID="ddlInfant" class="ft02" runat="server">
                                                                                                                    <asp:ListItem Value="0">00</asp:ListItem>
                                                                                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                                                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                                                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                                                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                                                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                                                                                    <asp:ListItem Value="6">06</asp:ListItem>
                                                                                                                    <asp:ListItem Value="7">07</asp:ListItem>
                                                                                                                    <asp:ListItem Value="8">08</asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="ft01" colspan="4" align="left">
                                                                                                                Cabin:
                                                                                                                <asp:DropDownList ID="ddlCabin_type" class="ft02" runat="server">
                                                                                                                    <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                                                                                    <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                                                                                    <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td valign="top" height="28" align="left">
                                                                                                                <asp:Label ID="AlblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td valign="top" align="right">
                                                                                                                <asp:ImageButton ID="ibtnSearch" runat="server" CssClass="check-availability-btn"
                                                                                                                    ImageUrl="~/images/check-availability-btn.jpg" OnClick="ibtnSearch_Click" OnClientClick="showDiv();"
                                                                                                                    ValidationGroup="Search" />
                                                                                                                <span id="Span3" style="display: none" class="loadingBackground"></span><span id="Span4"
                                                                                                                    style="display: none" class="modalContainer">
                                                                                                                    <div class="registerhead">
                                                                                                                        <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" style="background: url(../../images/Love.png) no-repeat top;">
                                                                                                                            <tr>
                                                                                                                                <td width="9" height="8">
                                                                                                                                    <img src="../../images/l1.png" width="9" height="8" />
                                                                                                                                </td>
                                                                                                                                <td height="8" width="582">
                                                                                                                                </td>
                                                                                                                                <td width="9" height="8">
                                                                                                                                    <img src="../../images/l2.png" width="9" height="8" />
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td colspan="3" align="center" valign="top">
                                                                                                                                    <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="25" valign="top">
                                                                                                                                                <img src="../../images/logo.gif" alt="Logo" border="0" title="LoveJourney">
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td height="1">
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" class="almost" height="20">
                                                                                                                                                Almost there
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center">
                                                                                                                                                <img src="../../images/loading.gif" width="100" height="100" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" class="almost12" height="20">
                                                                                                                                                Searching for Flights
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                <input id="Text7" type="text" style="border-color: #0CF; border: 1px; text-align: right;" />
                                                                                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                <input id="Text8" type="text" style="border: 0;" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                On
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                <input id="Text9" type="text" style="border: 0; text-align: center;" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                    </table>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td width="9" height="8">
                                                                                                                                    <img src="../../images/l3.png" width="9" height="8" />
                                                                                                                                </td>
                                                                                                                                <td height="8" width="582">
                                                                                                                                </td>
                                                                                                                                <td width="9" height="8">
                                                                                                                                    <img src="../../images/l4.png" width="9" height="8" />
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </div>
                                                                                                                </span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                            <td style="width:100px"></td>
                                                             <td>
                                                <asp:Image ID="imgFlight" Width="600" Height="310" ImageUrl="~/images/flight1.jpg" runat="server" />
                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                           
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table runat="server" id="tblAirlineDet" visible="false" width="100%">
                            <tr>
                                <td>
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="7" align="center">
                                                Selected Flight & Fare Details
                                                <br />
                                                Onward Flight
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                Airline
                                            </th>
                                            <th>
                                                Departs
                                            </th>
                                            <th>
                                                Arrives
                                            </th>
                                            <th>
                                                Travel Date
                                            </th>
                                            <th>
                                                Origin
                                            </th>
                                            <th>
                                                Destination
                                            </th>
                                            <th>
                                                Fare + Taxes
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Image ID="img" runat="server" /><br />
                                                <asp:Label ID="lblAirlineName1" runat="server"></asp:Label>
                                                -
                                                <asp:Label ID="lblFlightNumber1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDepartTime1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblArrivalTime1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTravelDate" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrigin1" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDestination1" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTotalFare1" runat="server" Text=""></asp:Label>
                                                <asp:Label ID="lblFlightSegmentId1" runat="server" Visible="false"></asp:Label>
                                                <br />
                                                <asp:LinkButton ID="lnkFareDet" runat="server">Fare Details</asp:LinkButton>
                                                <asp:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDet"
                                                    OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareDetails1">
                                                </asp:HoverMenuExtender>
                                                <asp:Panel ID="pnlFareDetails1" runat="server" Style="display: none; background-color: White;
                                                    border: 1px Solid">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            Base Fare
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            Rs.
                                                                            <asp:Label ID="lblBaseFare1" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Airport Tax
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            Rs.
                                                                            <asp:Label ID="lblTax1" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Service Tax
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            Rs.
                                                                            <asp:Label ID="lblSTax1" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            SCharge
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            Rs.
                                                                            <asp:Label ID="lblSCharge1" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Discount
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            Rs.
                                                                            <asp:Label ID="lblTDiscount1" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Total
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            Rs.
                                                                            <asp:Label ID="lblTotal1" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblPartnerComm1" runat="server" Visible="false"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnBookNow" runat="server" Text="Book Now" OnClick="btnBookNow_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="90%">
                            <tr><td><table width="100%">
                               <tr>
                            <td  align="left">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                            </td>
                                  <td align="right">
                                    <asp:LinkButton ID="lnkModifySearch" runat="server" OnClick="lnkModifySearch_Click"
                                        Visible="False">Modify Search</asp:LinkButton>
                                </td>
                        </tr>
                            </table></td>
                          
                            </tr>
                            <tr id="ModifySearch" runat="server" visible="false">
                                <td>
                                    <table width="1000">
                                        <tr>
                                            <td colspan="8">
                                                <table>
                                                    <tr>
                                                        <td width="155" valign="middle" align="center">
                                                            <asp:RadioButton ID="rbonesearch" Text="One Way" runat="server" Checked="true" AutoPostBack="True"
                                                                GroupName="ONE" OnCheckedChanged="rbonesearch_CheckedChanged" Font-Names="Arial" />
                                                        </td>
                                                        <td valign="middle" align="left">
                                                            <asp:RadioButton ID="rbreturnsearch" Text="Round Trip" runat="server" AutoPostBack="True"
                                                                GroupName="ONE" OnCheckedChanged="rbreturnsearch_CheckedChanged" Font-Names="Arial" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100" height="28" valign="top" align="left">
                                                Leaving From :
                                            </td>
                                            <td width="100" valign="top" align="left">
                                                Leaving To :
                                            </td>
                                            <td width="160" valign="top" align="left">
                                                Departure On :
                                            </td>
                                            <td width="155" valign="top" align="left">
                                                <asp:Label ID="Label7" Text="Return On :" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" height="25" valign="top">
                                                Adult
                                            </td>
                                            <td valign="top" width="100">
                                                Child (2-11yrs)
                                            </td>
                                            <td valign="top" width="100">
                                                Infant (2yrs)
                                            </td>
                                            <td valign="top">
                                                Cabin:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom" height="28" align="left">
                                                <asp:DropDownList ID="ddlSourcesSearch" runat="server" ValidationGroup="Search" Width="140px">
                                                    <asp:ListItem Selected="True" Value="BOM">MUMBAI</asp:ListItem>
                                                    <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                    <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                    <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                    <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                    <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                    <asp:ListItem Value="line1">-------------------------------</asp:ListItem>
                                                    <asp:ListItem Value="IXA">AGARTALA</asp:ListItem>
                                                    <asp:ListItem Value="AGX">AGATTI</asp:ListItem>
                                                    <asp:ListItem Value="AGR">AGRA</asp:ListItem>
                                                    <asp:ListItem Value="AMD">AHMEDABAD</asp:ListItem>
                                                    <asp:ListItem Value="AJL">AIJWAL</asp:ListItem>
                                                    <asp:ListItem Value="AKD">AKOLA</asp:ListItem>
                                                    <asp:ListItem Value="IXD">ALLAHABAD</asp:ListItem>
                                                    <asp:ListItem Value="IXV">ALONG</asp:ListItem>
                                                    <asp:ListItem Value="ATQ">AMRITSAR</asp:ListItem>
                                                    <asp:ListItem Value="IXU">AURANGABAD</asp:ListItem>
                                                    <asp:ListItem Value="IXB">BAGDOGRA</asp:ListItem>
                                                    <asp:ListItem Value="RGH">BALURGHAT</asp:ListItem>
                                                    <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                    <asp:ListItem Value="IXG">BELGAUM</asp:ListItem>
                                                    <asp:ListItem Value="BEP">BELLARY</asp:ListItem>
                                                    <asp:ListItem Value="BUP">BHATINDA</asp:ListItem>
                                                    <asp:ListItem Value="BHU">BHAVNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="BHO">BHOPAL</asp:ListItem>
                                                    <asp:ListItem Value="BBI">BHUBANESHWAR</asp:ListItem>
                                                    <asp:ListItem Value="BHJ">BHUJ</asp:ListItem>
                                                    <asp:ListItem Value="KUU">BHUNTAR</asp:ListItem>
                                                    <asp:ListItem Value="BKB">BIKANER</asp:ListItem>
                                                    <asp:ListItem Value="PAB">BILASPUR</asp:ListItem>
                                                    <asp:ListItem Value="CCJ">CALICUT</asp:ListItem>
                                                    <asp:ListItem Value="CBD">CAR NICOBAR</asp:ListItem>
                                                    <asp:ListItem Value="IXC">CHANDIGARH</asp:ListItem>
                                                    <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                    <asp:ListItem Value="COK">COCHIN</asp:ListItem>
                                                    <asp:ListItem Value="CJB">COIMBATORE</asp:ListItem>
                                                    <asp:ListItem Value="COH">COOCH BEHAR</asp:ListItem>
                                                    <asp:ListItem Value="CDP">CUDDAPAH</asp:ListItem>
                                                    <asp:ListItem Value="NMB">DAMAN</asp:ListItem>
                                                    <asp:ListItem Value="DAE">DAPARIZO</asp:ListItem>
                                                    <asp:ListItem Value="DAI">DARJEELING</asp:ListItem>
                                                    <asp:ListItem Value="DED">DEHRA DUN</asp:ListItem>
                                                    <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                    <asp:ListItem Value="DEP">DEPARIZO</asp:ListItem>
                                                    <asp:ListItem Value="DBD">DHANBAD</asp:ListItem>
                                                    <asp:ListItem Value="DHM">DHARAMSALA</asp:ListItem>
                                                    <asp:ListItem Value="DIB">DIBRUGARH</asp:ListItem>
                                                    <asp:ListItem Value="DMU">DIMAPUR</asp:ListItem>
                                                    <asp:ListItem Value="DIU">DIU</asp:ListItem>
                                                    <asp:ListItem Value="GAY">GAYA</asp:ListItem>
                                                    <asp:ListItem Value="GOI">GOA</asp:ListItem>
                                                    <asp:ListItem Value="GOP">GORAKHPUR</asp:ListItem>
                                                    <asp:ListItem Value="GUX">GUNA</asp:ListItem>
                                                    <asp:ListItem Value="GAU">GUWAHATI</asp:ListItem>
                                                    <asp:ListItem Value="GWL">GWALIOR</asp:ListItem>
                                                    <asp:ListItem Value="HSS">HISSAR</asp:ListItem>
                                                    <asp:ListItem Value="HBX">HUBLI</asp:ListItem>
                                                    <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                    <asp:ListItem Value="IMF">IMPHAL</asp:ListItem>
                                                    <asp:ListItem Value="IDR">INDORE</asp:ListItem>
                                                    <asp:ListItem Value="JLR">JABALPUR</asp:ListItem>
                                                    <asp:ListItem Value="JGB">JAGDALPUR</asp:ListItem>
                                                    <asp:ListItem Value="JAI">JAIPUR</asp:ListItem>
                                                    <asp:ListItem Value="JSA">JAISALMER</asp:ListItem>
                                                    <asp:ListItem Value="IXJ">JAMMU</asp:ListItem>
                                                    <asp:ListItem Value="JGA">JAMNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="IXW">JAMSHEDPUR</asp:ListItem>
                                                    <asp:ListItem Value="PYB">JEYPORE</asp:ListItem>
                                                    <asp:ListItem Value="JDH">JODHPUR</asp:ListItem>
                                                    <asp:ListItem Value="JRH">JORHAT</asp:ListItem>
                                                    <asp:ListItem Value="IXH">KAILASHAHAR</asp:ListItem>
                                                    <asp:ListItem Value="IXQ">KAMALPUR</asp:ListItem>
                                                    <asp:ListItem Value="IXY">KANDLA</asp:ListItem>
                                                    <asp:ListItem Value="KNU">KANPUR</asp:ListItem>
                                                    <asp:ListItem Value="IXK">KESHOD</asp:ListItem>
                                                    <asp:ListItem Value="HJR">KHAJURAHO</asp:ListItem>
                                                    <asp:ListItem Value="IXN">KHOWAI</asp:ListItem>
                                                    <asp:ListItem Value="KLH">KOLHAPUR</asp:ListItem>
                                                    <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                    <asp:ListItem Value="KTU">KOTA</asp:ListItem>
                                                    <asp:ListItem Value="KUU">KULU</asp:ListItem>
                                                    <asp:ListItem Value="LTU">LATUR</asp:ListItem>
                                                    <asp:ListItem Value="IXL">LEH</asp:ListItem>
                                                    <asp:ListItem Value="IXI">LILABARI</asp:ListItem>
                                                    <asp:ListItem Value="LKO">LUCKNOW</asp:ListItem>
                                                    <asp:ListItem Value="LUH">LUDHIANA</asp:ListItem>
                                                    <asp:ListItem Value="IXM">MADURAI</asp:ListItem>
                                                    <asp:ListItem Value="LDA">MALDA</asp:ListItem>
                                                    <asp:ListItem Value="IXE">MANGALORE</asp:ListItem>
                                                    <asp:ListItem Value="MOH">MOHANBARI</asp:ListItem>
                                                    <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                    <asp:ListItem Value="MZA">MUZAFFARNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="MZU">MUZAFFARPUR</asp:ListItem>
                                                    <asp:ListItem Value="MYQ">MYSORE</asp:ListItem>
                                                    <asp:ListItem Value="NAG">NAGPUR</asp:ListItem>
                                                    <asp:ListItem Value="NDC">NANDED</asp:ListItem>
                                                    <asp:ListItem Value="ISK">NASIK</asp:ListItem>
                                                    <asp:ListItem Value="NVY">NEYVELI</asp:ListItem>
                                                    <asp:ListItem Value="OMN">OSMANABAD</asp:ListItem>
                                                    <asp:ListItem Value="PGH">PANTNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="IXT">PASIGHAT</asp:ListItem>
                                                    <asp:ListItem Value="IXP">PATHANKOT</asp:ListItem>
                                                    <asp:ListItem Value="PAT">PATNA</asp:ListItem>
                                                    <asp:ListItem Value="PNY">PONDICHERRY</asp:ListItem>
                                                    <asp:ListItem Value="PBD">PORBANDAR</asp:ListItem>
                                                    <asp:ListItem Value="IXZ">PORTBLAIR</asp:ListItem>
                                                    <asp:ListItem Value="PNQ">PUNE</asp:ListItem>
                                                    <asp:ListItem Value="PUT">PUTTAPARTHI</asp:ListItem>
                                                    <asp:ListItem Value="BEK">PUTTAPARTHY</asp:ListItem>
                                                    <asp:ListItem Value="RPR">RAIPUR</asp:ListItem>
                                                    <asp:ListItem Value="RJA">RAJAHMUNDRY</asp:ListItem>
                                                    <asp:ListItem Value="RAJ">RAJKOT</asp:ListItem>
                                                    <asp:ListItem Value="RJI">RAJOURI</asp:ListItem>
                                                    <asp:ListItem Value="RMD">RAMAGUNDAM</asp:ListItem>
                                                    <asp:ListItem Value="IXR">RANCHI</asp:ListItem>
                                                    <asp:ListItem Value="RTC">RATNAGIRI</asp:ListItem>
                                                    <asp:ListItem Value="REW">REWA</asp:ListItem>
                                                    <asp:ListItem Value="RRK">ROURKELA</asp:ListItem>
                                                    <asp:ListItem Value="RUP">RUPSI</asp:ListItem>
                                                    <asp:ListItem Value="SXV">SALEM</asp:ListItem>
                                                    <asp:ListItem Value="TNI">SATNA</asp:ListItem>
                                                    <asp:ListItem Value="SHL">SHILLONG</asp:ListItem>
                                                    <asp:ListItem Value="SSE">SHOLAPUR</asp:ListItem>
                                                    <asp:ListItem Value="IXS">SILCHAR</asp:ListItem>
                                                    <asp:ListItem Value="SLV">SIMLA</asp:ListItem>
                                                    <asp:ListItem Value="SXR">SRINAGAR</asp:ListItem>
                                                    <asp:ListItem Value="STV">SURAT</asp:ListItem>
                                                    <asp:ListItem Value="TEZ">TEZPUR</asp:ListItem>
                                                    <asp:ListItem Value="TEI">TEZU</asp:ListItem>
                                                    <asp:ListItem Value="TJV">THANJAVUR</asp:ListItem>
                                                    <asp:ListItem Value="TRV">TRIVANDRUM</asp:ListItem>
                                                    <asp:ListItem Value="TRZ">TIRUCHIRAPALLI</asp:ListItem>
                                                    <asp:ListItem Value="TIR">TIRUPATI</asp:ListItem>
                                                    <asp:ListItem Value="ICH">TRICHI</asp:ListItem>
                                                    <asp:ListItem Value="TCR">TUTICORIN</asp:ListItem>
                                                    <asp:ListItem Value="UDR">UDAIPUR</asp:ListItem>
                                                    <asp:ListItem Value="BDQ">VADODRA</asp:ListItem>
                                                    <asp:ListItem Value="VNS">VARANASI</asp:ListItem>
                                                    <asp:ListItem Value="VGA">VIJAYAWADA</asp:ListItem>
                                                    <asp:ListItem Value="VTZ">VISHAKHAPATNAM</asp:ListItem>
                                                    <asp:ListItem Value="WGC">WARANGAL</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td valign="bottom" align="left">
                                                <asp:DropDownList ID="ddlDestinationsSearch" runat="server" CssClass="Dropdownlist"
                                                    onchange="showDate();" ValidationGroup="Search" Width="140px">
                                                    <asp:ListItem Selected="True" Value="DEL">DELHI</asp:ListItem>
                                                    <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                    <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                    <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                    <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                    <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                    <asp:ListItem Value="line1">-------------------------------</asp:ListItem>
                                                    <asp:ListItem Value="IXA">AGARTALA</asp:ListItem>
                                                    <asp:ListItem Value="AGX">AGATTI</asp:ListItem>
                                                    <asp:ListItem Value="AGR">AGRA</asp:ListItem>
                                                    <asp:ListItem Value="AMD">AHMEDABAD</asp:ListItem>
                                                    <asp:ListItem Value="AJL">AIJWAL</asp:ListItem>
                                                    <asp:ListItem Value="AKD">AKOLA</asp:ListItem>
                                                    <asp:ListItem Value="IXD">ALLAHABAD</asp:ListItem>
                                                    <asp:ListItem Value="IXV">ALONG</asp:ListItem>
                                                    <asp:ListItem Value="ATQ">AMRITSAR</asp:ListItem>
                                                    <asp:ListItem Value="IXU">AURANGABAD</asp:ListItem>
                                                    <asp:ListItem Value="IXB">BAGDOGRA</asp:ListItem>
                                                    <asp:ListItem Value="RGH">BALURGHAT</asp:ListItem>
                                                    <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                    <asp:ListItem Value="IXG">BELGAUM</asp:ListItem>
                                                    <asp:ListItem Value="BEP">BELLARY</asp:ListItem>
                                                    <asp:ListItem Value="BUP">BHATINDA</asp:ListItem>
                                                    <asp:ListItem Value="BHU">BHAVNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="BHO">BHOPAL</asp:ListItem>
                                                    <asp:ListItem Value="BBI">BHUBANESHWAR</asp:ListItem>
                                                    <asp:ListItem Value="BHJ">BHUJ</asp:ListItem>
                                                    <asp:ListItem Value="KUU">BHUNTAR</asp:ListItem>
                                                    <asp:ListItem Value="BKB">BIKANER</asp:ListItem>
                                                    <asp:ListItem Value="PAB">BILASPUR</asp:ListItem>
                                                    <asp:ListItem Value="CCJ">CALICUT</asp:ListItem>
                                                    <asp:ListItem Value="CBD">CAR NICOBAR</asp:ListItem>
                                                    <asp:ListItem Value="IXC">CHANDIGARH</asp:ListItem>
                                                    <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                    <asp:ListItem Value="COK">COCHIN</asp:ListItem>
                                                    <asp:ListItem Value="CJB">COIMBATORE</asp:ListItem>
                                                    <asp:ListItem Value="COH">COOCH BEHAR</asp:ListItem>
                                                    <asp:ListItem Value="CDP">CUDDAPAH</asp:ListItem>
                                                    <asp:ListItem Value="NMB">DAMAN</asp:ListItem>
                                                    <asp:ListItem Value="DAE">DAPARIZO</asp:ListItem>
                                                    <asp:ListItem Value="DAI">DARJEELING</asp:ListItem>
                                                    <asp:ListItem Value="DED">DEHRA DUN</asp:ListItem>
                                                    <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                    <asp:ListItem Value="DEP">DEPARIZO</asp:ListItem>
                                                    <asp:ListItem Value="DBD">DHANBAD</asp:ListItem>
                                                    <asp:ListItem Value="DHM">DHARAMSALA</asp:ListItem>
                                                    <asp:ListItem Value="DIB">DIBRUGARH</asp:ListItem>
                                                    <asp:ListItem Value="DMU">DIMAPUR</asp:ListItem>
                                                    <asp:ListItem Value="DIU">DIU</asp:ListItem>
                                                    <asp:ListItem Value="GAY">GAYA</asp:ListItem>
                                                    <asp:ListItem Value="GOI">GOA</asp:ListItem>
                                                    <asp:ListItem Value="GOP">GORAKHPUR</asp:ListItem>
                                                    <asp:ListItem Value="GUX">GUNA</asp:ListItem>
                                                    <asp:ListItem Value="GAU">GUWAHATI</asp:ListItem>
                                                    <asp:ListItem Value="GWL">GWALIOR</asp:ListItem>
                                                    <asp:ListItem Value="HSS">HISSAR</asp:ListItem>
                                                    <asp:ListItem Value="HBX">HUBLI</asp:ListItem>
                                                    <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                    <asp:ListItem Value="IMF">IMPHAL</asp:ListItem>
                                                    <asp:ListItem Value="IDR">INDORE</asp:ListItem>
                                                    <asp:ListItem Value="JLR">JABALPUR</asp:ListItem>
                                                    <asp:ListItem Value="JGB">JAGDALPUR</asp:ListItem>
                                                    <asp:ListItem Value="JAI">JAIPUR</asp:ListItem>
                                                    <asp:ListItem Value="JSA">JAISALMER</asp:ListItem>
                                                    <asp:ListItem Value="IXJ">JAMMU</asp:ListItem>
                                                    <asp:ListItem Value="JGA">JAMNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="IXW">JAMSHEDPUR</asp:ListItem>
                                                    <asp:ListItem Value="PYB">JEYPORE</asp:ListItem>
                                                    <asp:ListItem Value="JDH">JODHPUR</asp:ListItem>
                                                    <asp:ListItem Value="JRH">JORHAT</asp:ListItem>
                                                    <asp:ListItem Value="IXH">KAILASHAHAR</asp:ListItem>
                                                    <asp:ListItem Value="IXQ">KAMALPUR</asp:ListItem>
                                                    <asp:ListItem Value="IXY">KANDLA</asp:ListItem>
                                                    <asp:ListItem Value="KNU">KANPUR</asp:ListItem>
                                                    <asp:ListItem Value="IXK">KESHOD</asp:ListItem>
                                                    <asp:ListItem Value="HJR">KHAJURAHO</asp:ListItem>
                                                    <asp:ListItem Value="IXN">KHOWAI</asp:ListItem>
                                                    <asp:ListItem Value="KLH">KOLHAPUR</asp:ListItem>
                                                    <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                    <asp:ListItem Value="KTU">KOTA</asp:ListItem>
                                                    <asp:ListItem Value="KUU">KULU</asp:ListItem>
                                                    <asp:ListItem Value="LTU">LATUR</asp:ListItem>
                                                    <asp:ListItem Value="IXL">LEH</asp:ListItem>
                                                    <asp:ListItem Value="IXI">LILABARI</asp:ListItem>
                                                    <asp:ListItem Value="LKO">LUCKNOW</asp:ListItem>
                                                    <asp:ListItem Value="LUH">LUDHIANA</asp:ListItem>
                                                    <asp:ListItem Value="IXM">MADURAI</asp:ListItem>
                                                    <asp:ListItem Value="LDA">MALDA</asp:ListItem>
                                                    <asp:ListItem Value="IXE">MANGALORE</asp:ListItem>
                                                    <asp:ListItem Value="MOH">MOHANBARI</asp:ListItem>
                                                    <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                    <asp:ListItem Value="MZA">MUZAFFARNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="MZU">MUZAFFARPUR</asp:ListItem>
                                                    <asp:ListItem Value="MYQ">MYSORE</asp:ListItem>
                                                    <asp:ListItem Value="NAG">NAGPUR</asp:ListItem>
                                                    <asp:ListItem Value="NDC">NANDED</asp:ListItem>
                                                    <asp:ListItem Value="ISK">NASIK</asp:ListItem>
                                                    <asp:ListItem Value="NVY">NEYVELI</asp:ListItem>
                                                    <asp:ListItem Value="OMN">OSMANABAD</asp:ListItem>
                                                    <asp:ListItem Value="PGH">PANTNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="IXT">PASIGHAT</asp:ListItem>
                                                    <asp:ListItem Value="IXP">PATHANKOT</asp:ListItem>
                                                    <asp:ListItem Value="PAT">PATNA</asp:ListItem>
                                                    <asp:ListItem Value="PNY">PONDICHERRY</asp:ListItem>
                                                    <asp:ListItem Value="PBD">PORBANDAR</asp:ListItem>
                                                    <asp:ListItem Value="IXZ">PORTBLAIR</asp:ListItem>
                                                    <asp:ListItem Value="PNQ">PUNE</asp:ListItem>
                                                    <asp:ListItem Value="PUT">PUTTAPARTHI</asp:ListItem>
                                                    <asp:ListItem Value="BEK">PUTTAPARTHY</asp:ListItem>
                                                    <asp:ListItem Value="RPR">RAIPUR</asp:ListItem>
                                                    <asp:ListItem Value="RJA">RAJAHMUNDRY</asp:ListItem>
                                                    <asp:ListItem Value="RAJ">RAJKOT</asp:ListItem>
                                                    <asp:ListItem Value="RJI">RAJOURI</asp:ListItem>
                                                    <asp:ListItem Value="RMD">RAMAGUNDAM</asp:ListItem>
                                                    <asp:ListItem Value="IXR">RANCHI</asp:ListItem>
                                                    <asp:ListItem Value="RTC">RATNAGIRI</asp:ListItem>
                                                    <asp:ListItem Value="REW">REWA</asp:ListItem>
                                                    <asp:ListItem Value="RRK">ROURKELA</asp:ListItem>
                                                    <asp:ListItem Value="RUP">RUPSI</asp:ListItem>
                                                    <asp:ListItem Value="SXV">SALEM</asp:ListItem>
                                                    <asp:ListItem Value="TNI">SATNA</asp:ListItem>
                                                    <asp:ListItem Value="SHL">SHILLONG</asp:ListItem>
                                                    <asp:ListItem Value="SSE">SHOLAPUR</asp:ListItem>
                                                    <asp:ListItem Value="IXS">SILCHAR</asp:ListItem>
                                                    <asp:ListItem Value="SLV">SIMLA</asp:ListItem>
                                                    <asp:ListItem Value="SXR">SRINAGAR</asp:ListItem>
                                                    <asp:ListItem Value="STV">SURAT</asp:ListItem>
                                                    <asp:ListItem Value="TEZ">TEZPUR</asp:ListItem>
                                                    <asp:ListItem Value="TEI">TEZU</asp:ListItem>
                                                    <asp:ListItem Value="TJV">THANJAVUR</asp:ListItem>
                                                    <asp:ListItem Value="TRV">TRIVANDRUM</asp:ListItem>
                                                    <asp:ListItem Value="TRZ">TIRUCHIRAPALLI</asp:ListItem>
                                                    <asp:ListItem Value="TIR">TIRUPATI</asp:ListItem>
                                                    <asp:ListItem Value="ICH">TRICHI</asp:ListItem>
                                                    <asp:ListItem Value="TCR">TUTICORIN</asp:ListItem>
                                                    <asp:ListItem Value="UDR">UDAIPUR</asp:ListItem>
                                                    <asp:ListItem Value="BDQ">VADODRA</asp:ListItem>
                                                    <asp:ListItem Value="VNS">VARANASI</asp:ListItem>
                                                    <asp:ListItem Value="VGA">VIJAYAWADA</asp:ListItem>
                                                    <asp:ListItem Value="VTZ">VISHAKHAPATNAM</asp:ListItem>
                                                    <asp:ListItem Value="WGC">WARANGAL</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td valign="bottom" align="left">
                                                <asp:TextBox ID="txtdatesearch" ValidationGroup="Search" runat="server" onKeyPress="javascript: return false;"
                                                    onPaste="javascript: return false;" OnClick="showDateInt();" CssClass="datepicker"
                                                    Width="80px" />
                                                <asp:RequiredFieldValidator ID="rfvtxtdatesearch" ValidationGroup="SearchInt" runat="server"
                                                    ErrorMessage="Enter date." ControlToValidate="txtdatesearch" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceTxtDateSearch" runat="server" TargetControlID="rfvtxtdatesearch">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                            <td valign="bottom" align="left">
                                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tr>
                                                        <td valign="top" align="left">
                                                            <asp:TextBox ID="txtretundatesearch" runat="server" Enabled="false" Width="80px"
                                                                Visible="true" ValidationGroup="SearchInt" onKeyPress="javascript: return false;"
                                                                onPaste="javascript: return false;" OnClick="showDateInt();" />
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td valign="bottom" align="left" height="25">
                                                <asp:DropDownList ID="ddladultsintsearch" class="ft02" runat="server">
                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                    <asp:ListItem Value="6">06</asp:ListItem>
                                                    <asp:ListItem Value="7">07</asp:ListItem>
                                                    <asp:ListItem Value="8">08</asp:ListItem>
                                                    <asp:ListItem Value="9">09</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td valign="bottom" align="center">
                                                <img src="arzoo_search_files/blk.gif" width="40" height="1">
                                                <asp:DropDownList ID="ddlchildintsearch" class="ft02" runat="server">
                                                    <asp:ListItem Value="0">00</asp:ListItem>
                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                    <asp:ListItem Value="6">06</asp:ListItem>
                                                    <asp:ListItem Value="7">07</asp:ListItem>
                                                    <asp:ListItem Value="8">08</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td valign="bottom" align="center">
                                                <img src="arzoo_search_files/blk.gif" width="55" height="1">
                                                <asp:DropDownList ID="ddlinfantsintsearch" class="ft02" runat="server">
                                                    <asp:ListItem Value="0">00</asp:ListItem>
                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                    <asp:ListItem Value="6">06</asp:ListItem>
                                                    <asp:ListItem Value="7">07</asp:ListItem>
                                                    <asp:ListItem Value="8">08</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="ft01" align="left" valign="bottom">
                                                <asp:DropDownList ID="ddlIntCabinTypesearch" Width="130" class="ft02" runat="server">
                                                    <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                    <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                    <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td valign="top" align="right">
                                                <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/images/check-availability-btn.jpg"
                                                    OnClientClick="showDiv2();" ValidationGroup="SearchInt" OnClick="imgsearch_Click" />
                                                <span id="mainDiv2" style="display: none" class="loadingBackground"></span><span
                                                    id="contentDiv2" style="display: none" class="modalContainer">
                                                    <div class="registerhead">
                                                        <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" class="back_bg">
                                                            <tr>
                                                                <td width="9" height="8">
                                                                    <img src="../../images/l1.png" width="9" height="8" />
                                                                </td>
                                                                <td height="8" width="582">
                                                                </td>
                                                                <td width="9" height="8">
                                                                    <img src="../../images/l2.png" width="9" height="8" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center" valign="top">
                                                                    <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td align="center" height="25" valign="top">
                                                                                <img src="../../images/logo.gif" alt="Logo" border="0" title="LoveJourney">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="1">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" class="almost" height="20">
                                                                                Almost there
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <img src="../../images/loading.gif" width="100" height="100" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" class="almost12" height="20">
                                                                                Searching for Flights
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" height="20">
                                                                                <input id="Text10" type="text" style="border-color: #0CF; border: 1px; text-align: right;" />
                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                <input id="Text11" type="text" style="border: 0;" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" height="20">
                                                                                On
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" height="20">
                                                                                <input id="Text12" type="text" style="border: 0; text-align: center;" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="9" height="8">
                                                                    <img src="../../images/l3.png" width="9" height="8" />
                                                                </td>
                                                                <td height="8" width="582">
                                                                </td>
                                                                <td width="9" height="8">
                                                                    <img src="../../images/l4.png" width="9" height="8" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="trFilterSearch" visible="false">
                                <td>
                                    <table width="100%">
                                        <tr id="modifyfilter" runat="server">
                                            <td width="25%" valign="top" align="center" style="border: 1px solid #657600">
                                                <table width="80%">
                                                    <tr>
                                                        <td align="left" style="font-size:medium;">
                                                            Filter Your Search
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td>
                                                            <span style="font-size: 14px;">Price Range</span>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td>
                                                            <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="lbl11" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            <table width="100%">
                                                                <tr valign="middle">
                                                                    <td valign="top" width="20%" style="border-bottom: 0px;">
                                                                        <asp:TextBox ID="sliderTwo" runat="server" OnTextChanged="sliderTwo_TextChanged"
                                                                            AutoPostBack="true" />
                                                                        <asp:MultiHandleSliderExtender ID="multiHandleSliderExtenderTwo" runat="server"
                                                                            BehaviorID="multiHandleSliderExtenderTwo" TargetControlID="sliderTwo" Minimum="1000"
                                                                            Maximum="150000" Increment="50" Length="175" Orientation="Horizontal" EnableHandleAnimation="true"
                                                                            EnableKeyboard="false" EnableMouseWheel="false" EnableRailClick="false" ShowHandleDragStyle="true"
                                                                            ShowHandleHoverStyle="true" ShowInnerRail="true" OnClientDragEnd="ValueChangedHandler">
                                                                            <MultiHandleSliderTargets>
                                                                                <asp:MultiHandleSliderTarget ControlID="HiddenField1" />
                                                                                <asp:MultiHandleSliderTarget ControlID="HiddenField2" />
                                                                            </MultiHandleSliderTargets>
                                                                        </asp:MultiHandleSliderExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="border-bottom: 0px;">
                                                                        <br />
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span id="minPriceLbl" class="runtext">1000 Rs</span>
                                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value="1000" OnValueChanged="filter" />
                                                                        &nbsp; &nbsp;-&nbsp;&nbsp; <span id="maxPriceLbl" class="runtext">150000 Rs</span>
                                                                        <asp:HiddenField ID="HiddenField2" runat="server" Value="150000" OnValueChanged="filter" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server" id="stops2" visible="false">
                                                                    <td>
                                                                        <span style="font-size: 15px;">Stops</span>
                                                                    </td>
                                                                </tr>
                                                                <tr id="stops" runat="server" visible="false">
                                                                    <td>
                                                                        <%--  <asp:CheckBoxList ID="chkstops" runat="server" Width="200" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="ChkStops">
                                                    <asp:ListItem Value="0" >  Zero</asp:ListItem>
                                                    <asp:ListItem Value="1" >  One</asp:ListItem>
                                                    <asp:ListItem Value="2">  Two</asp:ListItem>
                                                    </asp:CheckBoxList>--%>
                                                                        <asp:CheckBox ID="chkstop0" runat="server" Text="Zero" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />
                                                                        <asp:CheckBox ID="Chkstop1" runat="server" Text="One" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />
                                                                        <asp:CheckBox ID="Chkstop2" runat="server" Text="Two" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <span style="font-size: 15px;">Airlines</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkjetlite" runat="server" Text="JetLite" AutoPostBack="true" OnCheckedChanged="filter" /><br />
                                                                        <asp:CheckBox ID="chkJetAirways" runat="server" Text="Jet Airways" AutoPostBack="true"
                                                                            OnCheckedChanged="filter" /><br />
                                                                        <asp:CheckBox ID="chkAirIndia" runat="server" Text="Air India" AutoPostBack="true"
                                                                            OnCheckedChanged="filter" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" style="width: 90%" valign="top" runat="server" id="Oneway">
                                     <asp:GridView ID="gdvFlights" Width="100%" runat="server" AutoGenerateColumns="false" AllowSorting="true"
                                                    OnRowDataBound="gdvFlights_RowDataBound" OnRowCommand="gdvFlights_RowCommand" OnSorting="gdvFlights_Sorting"
                                                    OnPageIndexChanging="gdvFlights_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Airline" SortExpression="airLineName">
                                                            <ItemTemplate>
                                                                <asp:RadioButton ID="rbnAirline" AutoPostBack="true" runat="server" OnCheckedChanged="rbnAirline_CheckedChanged"
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAirlineName" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                                -
                                                                <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label><br />
                                                                <asp:Label ID="lblConnectingFlights" runat="server" Text="Connecting Flights.."></asp:Label><br />
                                                                <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("imageFileName") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Destinations" SortExpression="DepartureAirportCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDepartureAirportCode" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>
                                                                -
                                                                <asp:Label ID="lblConnectingAirportCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblHyphen" runat="server" Text="-" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblArrivalAirportCode" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Departs" SortExpression="DepartureDateTime">
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="lblDepartname" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>--%>
                                                                <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label><br />
                                                                <asp:Label ID="lbldepartdate" runat="server" Visible="false" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                                <asp:LinkButton ID="lnkFareRule" runat="server" CommandName="ViewRules" CommandArgument='<%# Eval("FlightSegment_ID") %>'>Fare Rules</asp:LinkButton>
                                                                <asp:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkFareRule"
                                                                    OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareRules">
                                                                </asp:HoverMenuExtender>
                                                                <asp:Panel ID="pnlFareRules" runat="server" Style="display: none; background-color: White;
                                                                    border: 1px Solid">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblFareRules" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Arrives" SortExpression="ArrivalDateTime">
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="lblArrives" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>--%>
                                                                <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fare" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFare" runat="server"></asp:Label><%--<%# Eval("ActualBaseFare") %>--%>
                                                                <br />
                                                                <asp:LinkButton ID="lnkFareDetails" runat="server">Fare Details</asp:LinkButton>
                                                                <asp:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                    OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                                </asp:HoverMenuExtender>
                                                                <asp:Panel ID="pnlFareDetails" runat="server" Style="display: none; background-color: White;
                                                                    border: 1px Solid">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Base Fare
                                                                                        </td>
                                                                                        <td>
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            Rs.
                                                                                            <asp:Label ID="lblBaseFare" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Airport Tax
                                                                                        </td>
                                                                                        <td>
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            Rs.
                                                                                            <asp:Label ID="lblTax" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Service Tax
                                                                                        </td>
                                                                                        <td>
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            Rs.
                                                                                            <asp:Label ID="lblSTax" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            SCharge
                                                                                        </td>
                                                                                        <td>
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            Rs.
                                                                                            <asp:Label ID="lblSCharge" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Discount
                                                                                        </td>
                                                                                        <td>
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            Rs.
                                                                                            <asp:Label ID="lblTDiscount" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Total
                                                                                        </td>
                                                                                        <td>
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            Rs.
                                                                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                                            <asp:Label ID="lblPartnerComm" runat="server" Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lbladultone" runat="server"></asp:Label>
                                                                                            <asp:Label ID="lblchildone" runat="server"></asp:Label>
                                                                                            <asp:Label ID="lblinfantone" runat="server"></asp:Label>
                                                                                            <asp:Label ID="lblTripone" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnBookNow" runat="server" CssClass="buttonBook" Text="Book Now" OnClick="btnBookNow_Click"
                                                                  CommandName="BoolTicket" CommandArgument='<%# Eval("FlightSegment_ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                      <AlternatingRowStyle CssClass="gridAlter" />
                                                      <RowStyle CssClass="gridAlter" />
                                                    <HeaderStyle BackColor="LightBlue" />
                                                </asp:GridView>
                                            </td>
                                            <td width="90%" valign="top" id="round" runat="server">
                                                <table width="100%">
                                                    <tr id="Tr1" runat="server">
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="1" runat="server" id="tblOnwardFlightDet" visible="false"
                                                                            cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td colspan="7" align="center">
                                                                                    Selected Flight & Fare Details
                                                                                    <br />
                                                                                    Onward Flight
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>
                                                                                    Airline
                                                                                </th>
                                                                                <th>
                                                                                    Departs
                                                                                </th>
                                                                                <th>
                                                                                    Arrives
                                                                                </th>
                                                                                <th>
                                                                                    Travel Date
                                                                                </th>
                                                                                <th>
                                                                                    Origin
                                                                                </th>
                                                                                <th>
                                                                                    Destination
                                                                                </th>
                                                                                <th>
                                                                                    Fare + Taxes
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Image ID="imgOnwardFlight" runat="server" /><br />
                                                                                    <asp:Label ID="lblOnwardAirline" runat="server"></asp:Label>
                                                                                    -
                                                                                    <asp:Label ID="lblOnwardFlightNum" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblOnwardDeparts" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblOnwardArrives" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblOnwardTravelDate" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblOnwardOrigin" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblonwardDestination" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblOnwardTotalFare" runat="server"></asp:Label>
                                                                                    <asp:Label ID="lblonwardFlightSegmentId" runat="server" Visible="False"></asp:Label>
                                                                                    <br />
                                                                                    <asp:LinkButton ID="lnkOnwardFareDetails" runat="server">Fare Details</asp:LinkButton>
                                                                                    <asp:HoverMenuExtender ID="HoverMenuExtender3" runat="server" TargetControlID="lnkOnwardFareDetails"
                                                                                        OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlOnwardFareDetails1">
                                                                                    </asp:HoverMenuExtender>
                                                                                    <asp:Panel ID="pnlOnwardFareDetails1" runat="server" Style="display: none; background-color: White;
                                                                                        border: 1px Solid">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Base Fare
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblOnwardBaseFare" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Airport Tax
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblOnwardAirportTax" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Service Tax
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblOnwardServiceTax" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                SCharge
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblOnwardScharge" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Discount
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblOnwardDiscount" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Total
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblOnwardTotal" runat="server"></asp:Label>
                                                                                                                <asp:Label ID="lblOnwardPartnerComm" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table width="100%" border="1" cellpadding="0" runat="server" visible="false" id="tblReturnFlightDet"
                                                                            cellspacing="0">
                                                                            <tr>
                                                                                <td colspan="7" align="center">
                                                                                    Return Flight
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>
                                                                                    Airline
                                                                                </th>
                                                                                <th>
                                                                                    Departs
                                                                                </th>
                                                                                <th>
                                                                                    Arrives
                                                                                </th>
                                                                                <th>
                                                                                    Travel Date
                                                                                </th>
                                                                                <th>
                                                                                    Origin
                                                                                </th>
                                                                                <th>
                                                                                    Destination
                                                                                </th>
                                                                                <th>
                                                                                    Fare + Taxes
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Image ID="imgReturn" runat="server" /><br />
                                                                                    <asp:Label ID="lblReturnAirline" runat="server"></asp:Label>
                                                                                    -
                                                                                    <asp:Label ID="lblReturnFlightNum" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblReturnDeparts" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblReturnArrives" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblReturnTravelDate" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblReturnOrigin" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblReturnDestination" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblReturnTotalFare" runat="server"></asp:Label>
                                                                                    <asp:Label ID="lblReturnFlightSegment" runat="server" Visible="False"></asp:Label>
                                                                                    <br />
                                                                                    <asp:LinkButton ID="lnkReturnFareDetails" runat="server">Fare Details</asp:LinkButton>
                                                                                    <asp:HoverMenuExtender ID="HoverMenuExtender4" runat="server" TargetControlID="lnkReturnFareDetails"
                                                                                        OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlReturnFareDetails">
                                                                                    </asp:HoverMenuExtender>
                                                                                    <asp:Panel ID="pnlReturnFareDetails" runat="server" Style="display: none; background-color: White;
                                                                                        border: 1px Solid">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Base Fare
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblReturnBaseFare" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Airport Tax
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblReturnAirportTax" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Service Tax
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblReturnServiceTax" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                SCharge
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblReturnSCharge" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Discount
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblReturnDiscount" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                Total
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblReturnTotal" runat="server"></asp:Label>
                                                                                                                <asp:Label ID="lblReturnPartnerComm" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:Label ID="lblTotalFare" runat="server" Text="Total Fare : " Visible="false"></asp:Label> <asp:Label ID="lblTotalOnwardReturn" runat="server" Text=""></asp:Label>
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnRoundTripBook" CssClass="buttonBook" runat="server" Text="Book" Visible="false" CommandName="submit"
                                                                            OnClick="btnRoundTripBook_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trroundTrip">
                                                        <td width="100%">
                                                            <table runat="server" width="100%" id="tblRoundTrip">
                                                                <tr>
                                                                    <td >
                                                                        <asp:Label ID="lblOnwardDepartureAirportCode" runat="server" Text=""></asp:Label>
                                                                        &nbsp;<asp:Label ID="lblOnwardTO" runat="server" Text="TO" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblOnwardArrivalAirportCode" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td >
                                                                        <asp:Label ID="lblReturnDepartureAirportCode" runat="server" Text=""></asp:Label>
                                                                        &nbsp;<asp:Label ID="lblReturnTO" runat="server" Text="TO" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblReturnArrivalAirportCode" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" valign="top" >
                                                                        <asp:GridView ID="gdvOnward" Width="100%" runat="server" AutoGenerateColumns="false"
                                                                            OnRowDataBound="gdvOnward_RowDataBound" EmptyDataText="No Flights" EditRowStyle-Width="500">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Airline">
                                                                                    <ItemTemplate>
                                                                                        <asp:RadioButton ID="rbnAirline" AutoPostBack="true" GroupName="two" runat="server" OnCheckedChanged="rbnAirlineonward_CheckedChanged" />
                                                                                        <asp:Label ID="lblAirlineName" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                                                        -
                                                                                        <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label><br />
                                                                                        <asp:Label ID="lblConnectingFlights" runat="server" Text="Connecting Flights.."></asp:Label><br />
                                                                                        <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("imageFileName") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Destinations">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDepartureAirportCode" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>
                                                                                        -
                                                                                        <asp:Label ID="lblConnectingAirportCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblHyphen" runat="server" Text="-" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblArrivalAirportCode" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Departs">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Label ID="lblDepartname" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>--%>
                                                                                        <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label><br />
                                                                                        <asp:Label ID="lbldepartdate" runat="server" Visible="false" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                                                        <asp:LinkButton ID="lnkFareRule" runat="server" CommandName="ViewRules" CommandArgument='<%# Eval("FlightSegment_ID") %>'>Fare Rules</asp:LinkButton>
                                                                                        <asp:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkFareRule"
                                                                                            OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareRules">
                                                                                        </asp:HoverMenuExtender>
                                                                                        <asp:Panel ID="pnlFareRules" runat="server" Style="display: none; background-color: White;
                                                                                            border: 1px Solid">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblFareRules" runat="server"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Arrives">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Label ID="lblArrives" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>--%>
                                                                                        <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                        <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Fare">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFare" runat="server"></asp:Label><%--<%# Eval("ActualBaseFare") %>--%>
                                                                                        <br />
                                                                                        <asp:LinkButton ID="lnkFareDetails" runat="server">Fare Details</asp:LinkButton>
                                                                                        <asp:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                                            OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                                                        </asp:HoverMenuExtender>
                                                                                        <asp:Panel ID="pnlFareDetails" runat="server" Style="display: none; background-color: White;
                                                                                            border: 1px Solid">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Base Fare
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblBaseFare" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Airport Tax
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblTax" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Service Tax
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblSTax" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    SCharge
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblSCharge" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Discount
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblTDiscount" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Total
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                                                                    <asp:Label ID="lblPartnerComm" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lbladultone" runat="server"></asp:Label>
                                                                                                                    <asp:Label ID="lblchildone" runat="server"></asp:Label>
                                                                                                                    <asp:Label ID="lblinfantone" runat="server"></asp:Label>
                                                                                                                    <asp:Label ID="lblTripone" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--     <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnBookNow" runat="server" Text="Book Now" OnClick="btnBookNow_Click"
                                                                    BackColor="LightBlue" ForeColor="White" CommandName="BoolTicket" CommandArgument='<%# Eval("FlightSegment_ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                                            </Columns>
                                                                              <AlternatingRowStyle CssClass="gridAlter" />
                                                                              <RowStyle CssClass="gridAlter" />
                                                                            <HeaderStyle BackColor="LightBlue" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        <asp:GridView ID="gdvReturn" Width="100%" runat="server" AutoGenerateColumns="false"
                                                                            OnRowDataBound="gdvReturn_RowDataBound" EmptyDataText="No Flights" EmptyDataRowStyle-Width="90%">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Airline">
                                                                                    <ItemTemplate>
                                                                                        <asp:RadioButton ID="rbnAirline" AutoPostBack="true" GroupName="one" runat="server" OnCheckedChanged="rbnAirlineReturn_CheckedChanged" />
                                                                                        <asp:Label ID="lblAirlineName" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                                                        -
                                                                                        <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label><br />
                                                                                        <asp:Label ID="lblConnectingFlights" runat="server" Text="Connecting Flights.."></asp:Label><br />
                                                                                        <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("imageFileName") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Destinations">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDepartureAirportCode" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>
                                                                                        -
                                                                                        <asp:Label ID="lblConnectingAirportCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblHyphen" runat="server" Text="-" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblArrivalAirportCode" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Departs">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Label ID="lblDepartname" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>--%>
                                                                                        <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label><br />
                                                                                        <asp:Label ID="lbldepartdate" runat="server" Visible="false" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                                                        <asp:LinkButton ID="lnkFareRule" runat="server" CommandName="ViewRules" CommandArgument='<%# Eval("FlightSegment_ID") %>'>Fare Rules</asp:LinkButton>
                                                                                        <asp:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkFareRule"
                                                                                            OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareRules">
                                                                                        </asp:HoverMenuExtender>
                                                                                        <asp:Panel ID="pnlFareRules" runat="server" Style="display: none; background-color: White;
                                                                                            border: 1px Solid">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblFareRules" runat="server"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Arrives">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Label ID="lblArrives" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>--%>
                                                                                        <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                        <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Fare">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFare" runat="server"></asp:Label><%--<%# Eval("ActualBaseFare") %>--%>
                                                                                        <br />
                                                                                        <asp:LinkButton ID="lnkFareDetails" runat="server">Fare Details</asp:LinkButton>
                                                                                        <asp:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                                            OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                                                        </asp:HoverMenuExtender>
                                                                                        <asp:Panel ID="pnlFareDetails" runat="server" Style="display: none; background-color: White;
                                                                                            border: 1px Solid">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Base Fare
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblBaseFare" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Airport Tax
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblTax" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Service Tax
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblSTax" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    SCharge
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblSCharge" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Discount
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblTDiscount" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    Total
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                                                                    <asp:Label ID="lblPartnerComm" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lbladultone" runat="server"></asp:Label>
                                                                                                                    <asp:Label ID="lblchildone" runat="server"></asp:Label>
                                                                                                                    <asp:Label ID="lblinfantone" runat="server"></asp:Label>
                                                                                                                    <asp:Label ID="lblTripone" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--     <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnBookNow" runat="server" Text="Book Now" OnClick="btnBookNow_Click"
                                                                    BackColor="LightBlue" ForeColor="White" CommandName="BoolTicket" CommandArgument='<%# Eval("FlightSegment_ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                                            </Columns>
                                                                          <AlternatingRowStyle CssClass="gridAlter" />
                                                                              <RowStyle CssClass="gridAlter" />
                                                                            <HeaderStyle BackColor="LightBlue" />
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
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                   <asp:Panel ID="pnlPassengerDet" runat="server" Visible="false">
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblRoutetwo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%">
                                    <tr>
                                        <td bgcolor="#0062af" style="color: White">
                                            <b>Passenger Details</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:Table runat="server" ID="tblAdults">
                                                    </asp:Table>
                                                    <asp:Table runat="server" ID="tblChild">
                                                    </asp:Table>
                                                    <asp:Table runat="server" ID="tblInfants">
                                                    </asp:Table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <%--  <table id="tblAdults" runat="server">
                                
                                </table>--%>
                                            <%--<table id="tblInfants" runat="server"></table>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="ALabel1" runat="server" Text="Mobile Number : "></asp:Label>
                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10"></asp:TextBox>&nbsp; (Will be contacted
                                            in case of flight delay etc..)
                                            <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Enter Mobile No"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="0123456789"
                                                     TargetControlID="txtMobileNo">
                                            </asp:FilteredTextBoxExtender>
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                ControlToValidate="txtMobileNo" ErrorMessage="Invalid mobile no" 
                                                ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr>
                                        <td colspan="5" bgcolor="#0062af" style="color: White">
                                            <b>User Information</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            Title <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            First Name<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            Last Name<span style="color: Red">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            User
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dlTitle" runat="server">
                                                <asp:ListItem Value="Mr" Selected="True">Mr</asp:ListItem>
                                                <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFN" runat="server" ErrorMessage="Enter First Name" ControlToValidate="txtFirstname"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                     TargetControlID="txtFirstname">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                     TargetControlID="txtLastName">
                                                     </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Phone Number<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhoneNum" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Phone Number"
                                                ControlToValidate="txtPhoneNum"></asp:RequiredFieldValidator>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789"  TargetControlID="txtPhoneNum">
                                            </asp:FilteredTextBoxExtender>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile Number<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobileNum" runat="server" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Mobile Number"
                                                ControlToValidate="txtMobileNum"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="rgfvalidater" runat="server" 
                                                ControlToValidate="txtMobileNum" ErrorMessage="Invalid mobile no" 
                                                ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789" TargetControlID="txtMobileNum">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email ID<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter Email ID"
                                                ControlToValidate="txtEmailID"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtEmailID" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_" ></asp:FilteredTextBoxExtender>
                                                     <asp:RegularExpressionValidator ID="regularmail" runat="server"  
                                                ControlToValidate="txtEmailID" ErrorMessage="Invalid EmailId" 
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Confirm Email ID<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConfirmEmail" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter Confirm Email ID"
                                                ControlToValidate="txtConfirmEmail"></asp:RequiredFieldValidator>
                                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  
                                                ControlToValidate="txtConfirmEmail" ErrorMessage="Invalid EmailId" 
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtConfirmEmail" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_" ></asp:FilteredTextBoxExtender>
                                                  <asp:CompareValidator ID="vlc" runat="server" Display="None" ControlToValidate="txtConfirmEmail" ErrorMessage="Emailid & Confirm Emailid should be same" ControlToCompare="txtEmailID"  Operator="Equal"></asp:CompareValidator>
                                       <asp:ValidatorCalloutExtender ID="vvvlc" runat="server" TargetControlID="vlc"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr>
                                        <td colspan="3" bgcolor="#0062af" style="color: White">
                                            <b>Address Details</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Enter Address"
                                                ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                                                   
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            City / Town<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Enter City"
                                                ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtCity" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_" ></asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            State
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter State"
                                                ControlToValidate="txtState"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtState" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_" ></asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Postal Code
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Enter Postal Code"
                                                ControlToValidate="txtPostalCode"></asp:RequiredFieldValidator>
                                                 <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="0123456789" TargetControlID="txtPostalCode">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Country
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlcountry" runat="server">
                                                <asp:ListItem Value="India" Selected="True">India</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnBook" runat="server" CssClass="buttonBook" Text="Submit" OnClick="btnBook_Click" />
                                            <asp:Button ID="btnRoundTripSubmit" runat="server" CssClass="buttonBook" Text="Submit" OnClick="btnRoundTripSubmit_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Accordion ID="UserAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
                                                Width="100%" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
                                                FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250"
                                                FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None">
                                                <Panes>
                                                    <asp:AccordionPane ID="AccordionPane2" runat="server">
                                                        <Header>
                                                            <a href="#" class="href">&nbsp;Itinerary</a></Header>
                                                        <Content>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    OnWard<br />
                                                                                    (<asp:Label ID="lblRoute" runat="server" Text=""></asp:Label>)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Airline
                                                                                </td>
                                                                                <td valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="lblairline" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Flight NO
                                                                                </td>
                                                                                <td valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="lblflightno" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Departs
                                                                                </td>
                                                                                <td valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="lbldeparttime" runat="server" Text=""></asp:Label><br />
                                                                                    <asp:Label ID="lbldepart" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Arrives
                                                                                </td>
                                                                                <td valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="lblarrivetime" runat="server" Text=""></asp:Label><br />
                                                                                    <asp:Label ID="lblarrives" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr id="Returnway" runat="server" visible="false">
                                                                    <td>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    Return<br />
                                                                                    (<asp:Label ID="lblRouteReturn" runat="server" Text=""></asp:Label>)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Airline
                                                                                </td>
                                                                                <td valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="lblairlinereturn" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Flight NO
                                                                                </td>
                                                                                <td valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="lblflightnoreturn" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Departs
                                                                                </td>
                                                                                <td valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="lbldeparttimereturn" runat="server" Text=""></asp:Label><br />
                                                                                    <asp:Label ID="lbldepartreturn" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Arrives
                                                                                </td>
                                                                                <td valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="lblarrivetimereturn" runat="server" Text=""></asp:Label><br />
                                                                                    <asp:Label ID="lblarrivesreturn" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </Content>
                                                    </asp:AccordionPane>
                                                    <asp:AccordionPane ID="AccordionPane3" runat="server">
                                                        <Header>
                                                            <a href="#" class="href">Fare Break-Up</a></Header>
                                                        <Content>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    Onward
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Adult
                                                                                </td>
                                                                                <td>
                                                                                    (<asp:Label ID="lbladult" runat="server"></asp:Label>)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Child
                                                                                </td>
                                                                                <td>
                                                                                    (<asp:Label ID="lblchild" runat="server"></asp:Label>)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Infant
                                                                                </td>
                                                                                <td>
                                                                                    (
                                                                                    <asp:Label ID="lblinfant" runat="server"></asp:Label>)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Actual Fare
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblActualFare" runat="server"></asp:Label>
                                                                                    <asp:Label ID="lblTrip" runat="server" Visible="false"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Airport Tax
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblairporttax" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Service Tax
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblServiceTaxthree" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    SCharge
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblServiceCharge" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Discount
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblTotalDiscount" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Total
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblTotalAmt" ForeColor="Red" runat="server"></asp:Label>
                                                                                    <asp:Label ID="ALabel4" runat="server" Visible="false"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr id="Returnwayfare" runat="server" visible="false">
                                                                    <td>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    Return
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Adult
                                                                                </td>
                                                                                <td>
                                                                                    (<asp:Label ID="lbladultreturn" runat="server"></asp:Label>)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Child
                                                                                </td>
                                                                                <td>
                                                                                    (<asp:Label ID="lblchildreturn" runat="server"></asp:Label>)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Infant
                                                                                </td>
                                                                                <td>
                                                                                    (
                                                                                    <asp:Label ID="lblinfantreturn" runat="server"></asp:Label>)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    Actual Fare
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblActualFarereturn" runat="server"></asp:Label>
                                                                                    <asp:Label ID="lblTripreturn" runat="server" Visible="false"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Airport Tax
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblairporttaxreturn" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Service Tax
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblServiceTaxreturn" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    SCharge
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblServiceChargereturn" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Discount
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblTotalDiscountreturn" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Total
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    Rs.
                                                                                    <asp:Label ID="lblTotalAmtreturn" ForeColor="Red" runat="server"></asp:Label>
                                                                                    <asp:Label ID="Label15" runat="server" Visible="false"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </Content>
                                                    </asp:AccordionPane>
                                                </Panes>
                                            </asp:Accordion>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlBookingStatus" runat="server" Visible="false">
                    <asp:Button ID="btnBookStatus" runat="server" Text="Get Booking Status" OnClick="btnBookStatus_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelTicket" runat="server" Text="Cancel Ticket" OnClick="btnCancelTicket_Click" />
                    &nbsp;&nbsp;<asp:Button ID="btnCancelTicketStatus" runat="server" Text="Cancel Ticket Status"
                        OnClick="btnCancelTicketStatus_Click" />
                </asp:Panel>
                <%--<%# Eval("ActualBaseFare") %>--%>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlViewticket" runat="server" Visible="false" Width="900">
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="900" align="center">
                    <table width="900" align="center">
                        <tr>
                            <td width="523" align="left">
                                <%--<span class="actions">
                                    <asp:LinkButton ID="lbtnback" Text="Back" runat="server" OnClick="lbtnback_Click" /></span>--%>
                            </td>
                            <td width="115" align="right">
                                <span class="actions">
                                    <asp:LinkButton ID="lbtnmail" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;
                                    <input type="button" value="Print" onclick="printPage('printdiv');" /></span>
                                <%--<a onclick="printPage('printdiv');" target="_blank">Print</a></span>--%>
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
                                                    <img src="http://lovejourney.in/images/logo.gif" width="143" height="88" border="0"
                                                        title="Love Journey" />&nbsp;&nbsp;
                                                </td>
                                                <td align="right">
                                                    <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="40" align="left">
                                                                <img src="http://lovejourney.in/images/call.jpg" width="30" height="30" />
                                                            </td>
                                                            <td align="left">
                                                                <b>(080) 32 56 17 27</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="40" align="left">
                                                                <img src="http://lovejourney.in/images/messenge.jpg" width="30" height="30" />
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
                                    <td height="5" align="left">
                                        <table width="50%">
                                            <tr>
                                                <td>
                                                    Name :
                                                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tel :
                                                    <asp:Label ID="lblTel" runat="server" Text=""></asp:Label>
                                                </td>
                                                <%--  <td>
                                                                                Mobile No :
                                                                                <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
                                                                            </td>--%>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Email ID :
                                                    <asp:Label ID="lblEmailAddress" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        Eticket
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" style="border: 1px solid; border-color: Blue">
                                            <tr>
                                                <td>
                                                    Your Airline PNR :
                                                    <asp:Label ID="lblPNR" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblOrigin" runat="server" Text=""></asp:Label>
                                        -
                                        <asp:Label ID="lblDestination" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="1" style="border-color: Blue">
                                            <tr>
                                                <th align="left">
                                                    Airline
                                                </th>
                                                <th align="left">
                                                    Flight No
                                                </th>
                                                <th colspan="2">
                                                    Departure Date & Time
                                                </th>
                                                <th colspan="2">
                                                    Arrival Date & Time
                                                </th>
                                                <th>
                                                    PNR No
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Image ID="Image1" runat="server" />
                                                    -
                                                    <asp:Label ID="lblAirlineName" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFlightNumber" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDepartureDate" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDepartureTime" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblArrivalDate" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblArrivalTime" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPNRNo" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                    <tr id="printroundtrip" runat="server" visible="false">
                                    <td>
                                        <table width="100%" border="1" style="border-color: Blue">
                                            <tr>
                                                <th align="left">
                                                  Return Airline
                                                </th>
                                                <th align="left">
                                                  Return  Flight No
                                                </th>
                                                <th colspan="2">
                                                   Return Departure Date & Time
                                                </th>
                                                <th colspan="2">
                                                   Return Arrival Date & Time
                                                </th>
                                                <th>
                                                   Return PNR No
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Image ID="Image2" runat="server" />
                                                    -
                                                    <asp:Label ID="lblAirlineNamereturn" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFlightNumberreturn" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDepartureDatereturn" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDepartureTimereturn" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblArrivalDatereturn" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblArrivalTimereturn" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPNRNoreturn" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Ticket Details
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView Width="100%" ID="gdvPassengerDetails" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr No.">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Passenger Name(s).">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPassengername" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="E-ticket No.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblEticketNo" runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Passenger Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPassengerType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Age">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Passenger. Mobile :
                                        <asp:Label ID="lblPsngrMobileNo" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Fare Details :
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table border="1" width="100%">
                                            <tr>
                                                <td>
                                                    Passenger Type :
                                                    <asp:Label ID="lblPassengerType" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    Passenger Count :
                                                    <asp:Label ID="lblPassengerCnt" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    Basic Fare :
                                                    <asp:Label ID="lblBasicFare" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    Taxes :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTaxes" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    Service Tax & Fees :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblServiceTax" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    Total :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: Red">
                                        <p>
                                            * Passenger is requested to check-in 2hrs prior to scheduled depature (flights departing
                                            from international terminal check-in 3 hrs. prior to scheduled departure).
                                        </p>
                                        <p>
                                            * All Passengers including children and infants, must present valid identity proof
                                            ( Passport / Pan Card / election card or any photo identity proof ) at check-in.
                                            It is your responsibility to ensure you have the appropriate travel documents at
                                            all times.
                                        </p>
                                        <p>
                                            * Changes/Cancellations to booking must be made at least 5 hours prior to scheduled
                                            departure time or else should be cancelled directly from the respective airlines.</p>
                                        <p>
                                            &nbsp;* If any flight is cancelled or rescheduled by the airline authority, passenger
                                            is requested to get a stamped/endorsed copy of the ticket to process the refund.
                                        </p>
                                        <p>
                                            * Passenger travelling from Delhi on Indigo and Spice Jet will have to check-in
                                            at new Terminal 1D.
                                        </p>
                                        <p>
                                            * Passenger travelling on Air India Express from Delhi and Mumbai, will have to
                                            check-in at International Airport.
                                        </p>
                                        <p>
                                            * As per Government guidelines, check-in counters at all Airports will now close
                                            45 minutes before departure with immediate effect. Passengers are informed to plan
                                            their Airport arrival accordingly.
                                        </p>
                                        <p>
                                            * From the midnight of 10th November 2010 (i.e. 0000 hrs of 11th November 2010),all
                                            domestic and international arrivals/departures will be from T3, IGI Airport, Delhi.
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <%--  <tr>
                <td width="900" align="center">
                    <table width="900" align="center">
                        <tr>
                            <td width="523">
                            </td>
                            <td width="115" align="right">
                                <span class="actions">
                                    <asp:LinkButton ID="lblmail1" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
                                        onclick="printPage('printdiv');" target="_blank" >Print</a></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
        </table>
    </asp:Panel>
    <table>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID1" runat="server" Text="OK" CssClass="i2s_jp_status1" />
            </td>
        </tr>
    </table>
    <asp:ModalPopupExtender ID="mp3" runat="server" PopupControlID="pnl" TargetControlID="OpenID1"
        X="350" Y="250" BackgroundCssClass="modalBackground" OkControlID="btnMsg1">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnl" runat="server" Style="display: none; width: 400px; height: 130px;border:10px solid #657866"
        align="center">
        <table width="400" bgcolor="#fff">
        <tr><td>&nbsp;</td></tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
         
            <tr><td align="center"><asp:Button ID="btnMsg1" runat="server" Text="Ok" /></td></tr>
            <tr><td>&nbsp;</td></tr>
        </table>
    </asp:Panel>
    </asp:Panel>
    

 </asp:Panel>
</asp:Content>

