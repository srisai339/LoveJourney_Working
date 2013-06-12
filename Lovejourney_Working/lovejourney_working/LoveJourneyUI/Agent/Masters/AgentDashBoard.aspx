<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="AgentDashBoard.aspx.cs" Inherits="Agent_Masters_AgentDashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
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
    height: 21px;
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
    height: 13px;
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
    <script type="text/javascript" language="javascript">
           function showDiv() {
               Page_ClientValidate("Search");
               if (Page_ClientValidate("Search")) {
                   go();
                   go1();
                   go2();
                   document.getElementById('mainDiv').style.display = "";
                   document.getElementById('contentDiv').style.display = "";
                   setTimeout('document.images["myAnimatedImage"].src = "../Images/roller_big.gif"', 200);
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
     <link href="../../css/accordian.css" rel="stylesheet" type="text/css" />
    <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="http://jquery.malsup.com/block/jquery.blockUI.js?v2.38" type="text/javascript"></script>
    

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
        .back_bg3
        {
            background: url(../../images/Love.png) no-repeat top;
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
    <link href="../../css/accordian.css" rel="stylesheet" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
  <td align="center" height="300">
    <table width="984" cellpadding="0" cellspacing="0" border="0" bgcolor="#fff">
      <%--  <tr>
            <td align="center" class="lj_dbrd_hd">
                <b>Agent Dashboard</b>
            </td>
        </tr>--%>
        
        <tr>
          <td align="center">
          <asp:Label ID="lblagentname" runat="server" CssClass="lJ_gv" Font-Size="25px"></asp:Label>
            </td>
        </tr>
        
        
        <tr>
            <td align="right">
              
              
                <asp:Button ID="lbtnRemainder" runat="server" Text="Reminder" CssClass="lj_dbrd_link1" OnClick="lbtnRemainder_Click" />
                <asp:Button ID="lbtnMarkup" runat="server" Text="Markup Management"  CssClass="lj_dbrd_link1"  PostBackUrl="~/Agent/Bus/Markup.aspx"/>

            </td>
        </tr>
        

        
        <tr>
            <td align="center" class="li_tab_bdr" width="980">
               
                <asp:GridView ID="gvNotices" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="980" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                    GridLines="None" EmptyDataText="No Remainders" BackColor="White" PageSize="40"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowSorting="True">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#e4e4e4" Font-Bold="True" Height="30px" CssClass="lJ_gv" />
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
                </asp:GridView>
            </td>
  
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>
         
                

        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="li_tab_bdr" width="980">
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
                                <asp:Label ID="lblID" Text='<%#Eval("Rid") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                            <ItemStyle Width="" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reminder">
                            <ItemTemplate>
                                <asp:Label ID="Description" Text='<%#Eval("Description") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr><td>&nbsp;&nbsp;</td></tr>
        </table> 
    </td>
    </tr>
    
</table>
</asp:Content>

       

                                      



