<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CarResult.aspx.cs" Inherits="CarResult" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .clsFind
        {
        }
        .height1
        {
            
             vertical-align:middle;
             height:20px;
        }
    </style>
    <script language="javascript" type="text/javascript">


        function showHNF() {


            if (document.getElementById("<%=lnkSNFFare.ClientID %>").text == "SNF") {


                document.getElementById("<%=lnkSNFFare.ClientID %>").text = "HNF";

                var con = $(".clsFind");
                con.show();
                return false;

            }
            else if (document.getElementById("<%=lnkSNFFare.ClientID %>").text == "HNF") {
                document.getElementById("<%=lnkSNFFare.ClientID %>").text = "SNF";
                
                var con = $(".clsFind");
                con.hide();


                return false;
            }
        }
     
  
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=dvModifySearch.ClientID %>").accordion({
                collapsible: true

            });
        });
    </script>
    <script type="text/javascript">

        function Load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                var dateToday = new Date();
                $(".datepicker").datepicker({
                    dateFormat: 'dd-MM-yy',
                    numberOfMonths: 2,
                    showOn: "button",
                    buttonImage: "images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday,
                    maxDate: +100
                });
                $("[id$='txtFromDate']").datepicker('setDate', 'today');
                $(".datepicker1").datepicker({
                    dateFormat: 'dd-MM-yy',
                    showOn: "button",
                    numberOfMonths: 2,
                    buttonImage: "images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday,
                    maxDate: +100
                });
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
            setTimeout('document.images["myAnimatedImage"].src = "Images/roller_big.gif"', 200);
        }

        function Load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                var dateToday = new Date();
                $(".datepicker").datepicker({
                    dateFormat: 'dd-mm-yy',
                    numberOfMonths: 2,
                    showOn: "button",
                    buttonImage: "images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday,
                    onSelect: function (date) { $(".datepicker1").datepicker("show"); }
                });
                $(".datepicker3").datepicker({
                    dateFormat: 'dd-mm-yy',
                    showOn: "button",
                    numberOfMonths: 2,
                    buttonImage: "images/calendar.jpg",
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
            $(".datepicker3").datepicker("show");
        }

        $(function () {
            var dateToday = new Date();
            $(".datepicker").datepicker({
                dateFormat: 'dd-mm-yy',
                numberOfMonths: 2,
                showOn: "button",
                buttonImage: "images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: dateToday,
                onSelect: function (date) {
                    $(".datepicker3").datepicker("show");
                }
            });
            //            $("[id$='check_Inhotel']").datepicker('setDate', 'today');
        });
        $(function () {
            var dateToday = new Date();
            $(".datepicker3").datepicker({
                dateFormat: 'dd-mm-yy',
                showOn: "button",
                numberOfMonths: 2,
                buttonImage: "images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: dateToday
            });
            //            $("[id$='check_Outhotel']").datepicker('setDate', '+1d');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
 <ContentTemplate>
<table style="vertical-align:middle;width:984px;">
   
   <tr><td></td></tr>
   <tr><td height="25" align="center"> <h3><asp:Label ID="lblText" runat="server" style="font-family:Arial;font-weight:bold;color:Black;font-size:medium;"></asp:Label></h3></td></tr>
   <tr id="ModifySearch" runat="server">
                                                <td align="center" style="font-family:Arial;font-weight:bold;font-size:14px;color:Black" width="90%">
                                                    <div id="dvModifySearch" visible="true" runat="server">
                                                        <h2 style="font-family:Arial;font-weight:bold;font-size:15px;color:Black;">
                                                            Modify Search</h2>
                                                        <asp:Panel ID="pnlModSearch" runat="server">
                                                           <table width="90%" cellpadding="0" cellspacing="0" border="0">
                                                             <tr>
                                                               <td>City</td>
                                                                <td>
                                                                <asp:DropDownList ID="DDLCity" runat="server" CssClass="lj_inp"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="DDLCity" ErrorMessage="Please enter city" ValidationGroup="submit" Display="None" InitialValue="--Select--"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="vcecity" runat="server" TargetControlID="rfvCity"></ajax:ValidatorCalloutExtender>

                                                                </td>
                                                                 <td>Date</td>
                                                                  <td> 
                                                                   <asp:TextBox ID="txtDate" runat="server"  CssClass="datepicker3" ></asp:TextBox>
                                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="Please enter Date" ValidationGroup="submit" Display="None"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>


                                                                   </td>
                                                             </tr>
                                                             <tr>
                                                               <td colspan="4" align="right">
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search Cabs" 
                                                                       CssClass="buttonBook"  ValidationGroup="submit" onclick="btnSearch_Click"/>
                                                               </td>
                                                             </tr>
                                                           </table>
                                                        </asp:Panel>
                                                    </div>
                                                </td>
                                            </tr>
   <tr>
   <td>
      <table width="100%">
                                                <tr>
                                                    
                                                    <td width="15%" align="center">
                                                        <asp:LinkButton ID="lnkDepart" runat="server" Text="Car Type" ToolTip="ASC"  style="font-size:14px;font-family:Arial;color:Black;font-weight:bold;"></asp:LinkButton>
                                                    </td>
                                                    <td width="15%" align="right">
                                                        <asp:LinkButton ID="lnkarrives" runat="server" Text="Ext.Price/Km" ToolTip="ASC"  style="font-size:14px;font-family:Arial;color:Black;font-weight:bold;"></asp:LinkButton>
                                                    </td>
                                                     <td width="15%" align="right" >
                                                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Ext.Price/Hours" ToolTip="ASC"  style="font-size:14px;font-family:Arial;color:Black;font-weight:bold;"></asp:LinkButton>
                                                    </td>
                                                    <td width="15%" align="center" >
                                                        <asp:LinkButton ID="lnkfare" runat="server" Text="Usage" ToolTip="ASC"  style="font-size:14px;font-family:Arial;color:Black;font-weight:bold;"></asp:LinkButton>
                                                    </td>
                                                     <td width="10%" align="left" >
                                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Capacity" ToolTip="ASC"  style="font-size:14px;font-family:Arial;color:Black;font-weight:bold;"></asp:LinkButton>
                                                    </td>
                                                     <td width="15%"  align="left">
                                                        <asp:LinkButton ID="LinkButton3" runat="server" Text="Booking Type" ToolTip="ASC"   style="font-size:14px;font-family:Arial;color:Black;font-weight:bold;"></asp:LinkButton>
                                                    </td>
                                                     <td width="15%" align="right">
                                                        <asp:LinkButton ID="LinkButton4" runat="server" Text="Fare" ToolTip="ASC"   style="font-size:14px;font-family:Arial;color:Black;font-weight:bold;"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
   </td>
   </tr>
    <tr><td align="right">
   <asp:LinkButton ID="lnkSNFFare" runat="server" Text="SNF"   OnClientClick="return showHNF();" style="padding-right:20px;"
            onclick="lnkbtn_Click"></asp:LinkButton>&nbsp;&nbsp;

       
          
            </td></tr>
   <tr>
   
   <td align="center">
   <asp:GridView ID="gvCarresult" runat="server" AutoGenerateColumns="False"  CssClass="gridLines" 
           GridLines="Horizontal" Width="100%"
                                            EmptyDataRowStyle-Height="250" AllowPaging="True" 
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                ShowFooter="false" 
           EmptyDataText="No Cars found on this City" EmptyDataRowStyle-Font-Bold="true"
                                EmptyDataRowStyle-Font-Size="Small" 
           EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                EmptyDataRowStyle-HorizontalAlign="Center" 
           AllowSorting="false" CellPadding="7"
                                EnableModelValidation="True" ForeColor="#333333" onrowcommand="gvCarresult_RowCommand"
                                 PageSize="100" onsorting="gvCarresult_Sorting" onrowdatabound="gvCarresult_RowDataBound"  
          >
           <AlternatingRowStyle CssClass="gridAlter" />
                                                <RowStyle CssClass="gridAlter" />
                                <footerstyle backcolor="White" forecolor="#000066" />
                                <headerstyle backcolor="#006699" font-bold="True" forecolor="White" height="30" Font-Size="10" />
                                <pagerstyle backcolor="White" forecolor="#000066" horizontalalign="Left"  />
                                <rowstyle forecolor="#000066" horizontalalign="Center" height="120" />
                                <selectedrowstyle backcolor="#669999" font-bold="True" forecolor="White" />
                                             <Columns>


                                              <%--  <asp:ButtonField Text="Select" HeaderText="Car Name" DataTextField="CarName"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="CarName" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>

                                                <asp:ButtonField Text="Select" HeaderText="Ext.Price/KM" DataTextField="ExtarKiloMeters"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="ExtarKiloMeters" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>

                                                <asp:ButtonField Text="Select" HeaderText="Ext.Price/Hours" DataTextField="ExtarHours"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="ExtarHours" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>

                                               <asp:ButtonField Text="Select" HeaderText="Status" DataTextField="Status"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" Visible="false"
                                                    SortExpression="Status" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>

                                                <asp:ButtonField Text="Select" HeaderText="Basic Price" DataTextField="BasicPrice"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="BasicPrice" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>
                                                <asp:ButtonField Text="Select" HeaderText="Booking Type" DataTextField="BookingType"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="BookingType" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>--%>

<%--
                                                 <asp:TemplateField HeaderText="Car Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="130px" ControlStyle-Width="160px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Medium"></ItemStyle>
                                        <ItemTemplate>
                                      <asp:Image ID="img" runat="server"     ImageUrl="images/Swift%20dezire.png" width="85" Height="36" />
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                     <%--<asp:TemplateField HeaderText="Cars" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="130px" ControlStyle-Width="75px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Medium"></ItemStyle>
                                        <ItemTemplate>
                                         
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                 <asp:TemplateField HeaderText="Car Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="130px" ControlStyle-Width="110px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Medium"></ItemStyle>
                                        <ItemTemplate>
                                         <asp:Label ID="lblCarName" runat="server"  Text='<%# Eval("CarName") %>' Font-Bold="true" style="font-family:Times New Roman;font-size:20;color:Black;width:160px;height:40px;"></asp:Label> <br />
                                            <asp:Image ID="carimage" runat="server" ImageUrl='<%# Eval("CarImagePath") %>'  Width="80" Height="35" />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ext.Price/KM" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="100px" ControlStyle-Width="100px" ControlStyle-Height="70"  ControlStyle-CssClass="height1" >
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                         <asp:Label ID="lblExtraKilometer" runat="server"  Text='<%# Eval("ExtarKiloMeters") %>' style="color:Black"></asp:Label> 
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Ext.Price/Hours" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="120px" ControlStyle-Width="100px"  ControlStyle-Height="70" >
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                         <asp:Label ID="lblExtraHours" runat="server"  Text='<%# Eval("ExtarHours") %>' style="color:Black"></asp:Label> 
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="90px" ControlStyle-Width="100px" Visible="false"  ControlStyle-Height="70">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                         <asp:Label ID="lblStatus" runat="server"  Text='<%# Eval("Status") %>' Visible="false"></asp:Label> 
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Basic Price" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="90px" ControlStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                       
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                     <asp:TemplateField HeaderText="Usage" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="90px" ControlStyle-Width="100px"  ControlStyle-Height="70">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                         <asp:Label ID="lblUsage" runat="server"  Text='<%# Eval("Usage") %>' style="color:Black"></asp:Label> 
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Capacity" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="90px" ControlStyle-Width="100px"  ControlStyle-Height="70">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                         <asp:Label ID="lblCapacity" runat="server"  Text='<%# Eval("Capacity") %>' style="color:Black"></asp:Label> 
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="BookingType" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="CustomerDetails"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="100px" ControlStyle-Width="100px"  ControlStyle-Height="70">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookingType" runat="server" Width="130px" Text='<%# Eval("BookingType") %>' style="color:Black"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="CustomerDetails"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="100px" ControlStyle-Width="100px"  ControlStyle-Height="70">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkCarPolicy" runat="server" Text="Policy" OnClick="lnkCarPolicy_Click" ToolTip="Click here to show car policy"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>





                                                <asp:TemplateField HeaderText="Fare" SortExpression="CustomerDetails">
                                                <ItemTemplate >
                                                
                                                  <asp:Label ID="lblBasicPrice" runat="server"  Text='<%# Eval("BasicPrice") %>' Font-Bold="true" Font-Size="Medium" Height="30" style="color:Black;"></asp:Label> <br />
                                                     
                                                  <asp:Label ID="lblHNFFare" runat="server" Font-Bold="true"    style="display:none;"></asp:Label><br />
                                                                <asp:Label ID="lblagentcomm1" runat="server" Font-Bold="true" Style="font-weight:bold;font-size:16px;color:#CC006E;display:none;" CssClass="clsFind" ></asp:Label><br />
                                                                <asp:Button ID="btnBookNow" Text="Book Now" runat="server"  CommandName="BookNow" CssClass="buttonBook"
                                                        CommandArgument='<%# Eval("CarDetailsId") %>'  />

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                                </Columns>

   </asp:GridView>
   </td>
   </tr>
   </table>

   
                        <div style="text-align: left; display: none;">
                         <asp:Button ID="Button2" runat="server" CssClass="buttonBook" Height="1px" Width="1px" />
                         </div>
                         <ajax:modalpopupextender ID="modalpopuphotelpolicy" 
        TargetControlID="Button2" PopupControlID="Panel3"
                            runat="server" BackgroundCssClass="loadingBackground" 
        DropShadow="false" Drag="false"
                            OkControlID="Button1" />
                        <asp:Panel ID="Panel3" runat="server" BackColor="White" Height="550" Width="920" ScrollBars="Vertical"
                            Style="display: none; color: Black; border: 5px solid #3e6cc4; border-radius: 5px;
                            -moz-border-radius: 5px;">
                            <table width="920" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td align="right" style="padding-right:13px;">
                                        <asp:Button ID="Button1" runat="server" Text="X" CssClass="buttonclose" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel4" runat="server" BackColor="White"  Height="370"
                                            Width="900" Style="color: Black; border: 1px;">
                                           
                                               <asp:GridView ID="gvAdminRemainders" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                            Width="900" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                            GridLines="None"  EmptyDataText="No Remainders" BackColor="White" PageSize="40"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowSorting="True" 
                               
                                
                                >
                           <FooterStyle BackColor="White" ForeColor="#000066" />
                           <HeaderStyle BackColor="#025aa2" Font-Bold="True" Height="30px" CssClass="lJ_gv" ForeColor="White" />
                           <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                           <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                           <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                           <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                                <Columns>
                                  
                                    <asp:TemplateField HeaderText="Car Policy">
                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                        <ItemTemplate >
                                            <asp:Label ID="lblAdminRemainders" Text='<%#Eval("CarPolicy") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                                            
                                        </asp:Panel>
                                    </td>   
                                </tr>
                            </table>
                        </asp:Panel>
                        </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>

