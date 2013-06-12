<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cab.aspx.cs" Inherits="Cab" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js "></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <%--<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />--%>
    <script src="Scripts/ajaxservice.js" type="text/javascript"></script>
    <script src="Scripts/validationsscript.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/chrome.js"></script>
    <link href="css/chromestyle_New.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Jquery.cookie.js" type="text/javascript"></script>
    <style type="text/css">
        .slideshowheader
        {
            height: 372px;
            width: 441px;
            margin: 0px;
        }
    </style>
     <link href="css/lj_style.css" rel="stylesheet" type="text/css" />
    <!-- include Cycle plugin -->
    <script type="text/javascript" src="js/jquery.cycle.all.2.74.js"></script>
    <!--  initialize the slideshow when the DOM is ready -->
    <script type="text/javascript">
        $(document).ready(function () {

            $('.slideshowheader').cycle({
                fx: 'fade', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
                autostop: false,
                timeout: 5000
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
                 $(".datepicker1").datepicker({
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
             $(".datepicker1").datepicker("show");
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
                     $(".datepicker1").datepicker("show");
                 }
             });
             //            $("[id$='check_Inhotel']").datepicker('setDate', 'today');
         });
         $(function () {
             var dateToday = new Date();
             $(".datepicker1").datepicker({
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center" valign="top">
                    <!--MainTable-->
                    <table width="1000" border="0" cellspacing="0" cellpadding="0">
                        <%--<tr>
                            <td valign="top">
                                <!--header-->
                                <table width="1000" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" height="90" valign="middle" width="328">
                                            <img height="79" src="Newimages/New_Logo.png" width="226" />
                                        </td>
                                        <td align="right">
                                            <table width="500" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                 <td valign="middle" align="right" height="34" style="padding-right:10px;">

                                   <a href="http://www.facebook.com/pages/Love-Journey-Techno-Pvt-Ltd/121356568035694"> <img src="images/facebook_New.png" width="24" height="24" /></a>
                                  
                                   <a href="https://twitter.com/Lovejourneyin"><img src="images/Twitter_New.png" width="24" height="24" /></a>
                                 </td>
                                </tr>
                                                <tr>
                                                    <td class="lj_Tmenu">
                                                        <ul>
                                                            <li><a href="BecomeAnAgent.aspx">Agent Registration</a></li>
                                                            <li><a href="UserRegistration.aspx">User Registration</a></li>
                                                          
                                                            <li><a href="PrintTicket.aspx" >Print</a></li>
                                                              <li><a href="CancelTicket.aspx">Cancel</a></li>
                                                               <li><a href="Careers.aspx">Careers</a></li>
                                                            <li><a href="Login.aspx" style="border-right: none; padding-right: none;">Login</a></li>
                                                        </ul>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td align="right" valign="top">
                                                        <table width="370" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="left" width="31">
                                                                    <img src="Newimages/contact_icon.png" width="21" height="21" />
                                                                </td>
                                                                <td align="left" class="lj_cn">
                                                                    080-32561727 / 080-25220265
                                                                </td>
                                                                <td width="33" align="left">
                                                                    <img src="Newimages/mail_icon.png" width="23" height="22" />
                                                                </td>
                                                                <td align="left" class="lj_cn">
                                                                    <a href="mailto:info@lovejourney.in">info@lovejourney.in</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!--headerEnd-->
                            </td>
                        </tr>--%>
                        <tr>
                            <td valign="top">
                                <!--content-->
                                <table width="1000" border="0" cellspacing="0" cellpadding="0" height="372" class="lj_ctnt">
                                    <tr>
                                        <td width="540" valign="top" align="right">
                                            <table width="500" border="0" cellspacing="0" cellpadding="0">
                                                <tr id="User_menu" runat="server" visible="false">
                                                    <td align="left" valign="top">
                                                        <!--form_menu-->
                                                        <table width="440" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <table width="90" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="8" align="left">
                                                                                <img src="Newimages/l1.png" width="8" height="37" />
                                                                            </td>
                                                                            <td class="lj_tab_bg">
                                                                                <table width="80" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="80" align="left" valign="middle" height="32" class="lj_n_bus">
                                                                                            <a href="Default.aspx">Buses</a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="8">
                                                                                <img src="Newimages/l2.png" width="8" height="37" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table width="96" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="8" align="left">
                                                                                <img src="Newimages/l1.png" width="8" height="37" />
                                                                            </td>
                                                                            <td class="lj_tab_bg">
                                                                                <table width="82" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="82" align="left" valign="middle" height="32">
                                                                                            <div id="chromemenu123" class="lj_chromestyle">
                                                                                                <ul>
                                                                                                    <li><a href="#" rel="dropmenunew">Flights</a></li>
                                                                                                </ul>
                                                                                            </div>
                                                                                            <!--1st drop down menu -->
                                                                                            <div id="dropmenunew" class="ljdropmenudiv">
                                                                                                <a href="frmFlightsAvailability.aspx">Domestic Flights</a> <a href="frmIntFlightsAvailability.aspx">
                                                                                                    International Flights</a>
                                                                                            </div>
                                                                                            <script type="text/javascript">

                                                                                                cssdropdown.startchrome("chromemenu123")

                                                                                            </script>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="8">
                                                                                <img src="Newimages/l2.png" width="8" height="37" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="left">
                                                                    <table width="90" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="8" align="left">
                                                                                <img src="Newimages/l1.png" width="8" height="37" />
                                                                            </td>
                                                                            <td class="lj_tab_bg">
                                                                                <table width="82" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="82" align="left" valign="middle" height="32" class="lj_n_hotel">
                                                                                            <a href="HotelSearch.aspx">Hotels</a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="8">
                                                                                <img src="Newimages/l2.png" width="8" height="37" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table width="86" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="8" align="left">
                                                                                <img src="Newimages/l1.png" width="8" height="37" />
                                                                            </td>
                                                                            <td class="lj_tab_bg">
                                                                                <table width="75" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="75" align="left" valign="middle" height="32" class="lj_n_car">
                                                                                            <a href="Cab.aspx">Cars</a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="8">
                                                                                <img src="Newimages/l2.png" width="8" height="37" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table width="108" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="8" align="left">
                                                                                <img src="Newimages/l1.png" width="8" height="37" />
                                                                            </td>
                                                                            <td class="lj_tab_bg">
                                                                                <table width="90" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="90" align="left" valign="middle" height="32" class="lj_men_bg">
                                                                                            <%--  <a href="#">fgfg</a>--%>
                                                                                            <div id="chromemenu1" class="panchromestyle">
                                                                                                <ul>
                                                                                                    <li><a href="#" rel="dropmenu2">Pancard</a></li>
                                                                                                </ul>
                                                                                                <!--1st drop down menu -->
                                                                                                <div id="dropmenu2" class="pandropmenudiv">
                                                                                                    <a href="Downloads/CSF.pdf" target="_blank">Change Request Application</a> <a href="Downloads/Form 49AA.pdf" target="_blank">
                                                                                                        New PAN Application ( for NRI F49AA)</a> <a href="Downloads/Form 49A.pdf" target="_blank">New PAN Application(for
                                                                                                            Indian Resident F49A)</a>
                                                                                                </div>
                                                                                                <script type="text/javascript">

                                                                                                    cssdropdown.startchrome("chromemenu1")

                                                                                                </script>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="8">
                                                                                <img src="Newimages/l2.png" width="8" height="37" />
                                                                            </td>
                                                                            <td>
                                                                                <table width="95" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="8" align="left">
                                                                                            <img src="Newimages/l1.png" width="8" height="37" />
                                                                                        </td>
                                                                                        <td class="lj_tab_bg">
                                                                                            <table width="70" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td width="35" align="left" valign="middle">
                                                                                                        <img src="Newimages/packages.jpg" width="32" height="32" />
                                                                                                    </td>
                                                                                                    <td width="35" align="left" valign="middle" height="32">
                                                                                                        <a href="Default.aspx?Type=Tours">Tours</a>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td width="8">
                                                                                            <img src="Newimages/l2.png" width="8" height="37" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <!--form_menuEnd-->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <table width="480" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="left" class="lj_srchGo">
                                                                   
                                                                    <asp:Label ID="seachbus" runat="server" Text="Search your Cab Here"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10">
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td height="10">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <table width="480" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="233" align="left">
                                                                                <div class="lj_outDiv">
                                                                                    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                        <tr>
                                                                                            <td width="70" align="center" class="lj_bdrit">
                                                                                                <img src="Newimages/b_i.png" width="56" height="32" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="DDLCity" runat="server" style="border:none;"></asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Please select city" Display="None" ValidationGroup="submit" InitialValue="--Select--" ControlToValidate="DDLCity"></asp:RequiredFieldValidator>
                                                                                                <ajax:ValidatorCalloutExtender ID="vcecity" runat="server" TargetControlID="rfvCity"></ajax:ValidatorCalloutExtender>
                                                                                               
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                            <td width="5">
                                                                            </td>
                                                                            <td width="249" align="left">
                                                                                
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <table width="480" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="233" align="left">
                                                                                <div class="lj_outDiv" style="width:252;">
                                                                                    <table width="235" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                        <tr>
                                                                                            <td width="55" align="center" class="lj_bdrit">
                                                                                                <img src="Newimages/calender.png" width="48" height="32" />
                                                                                            </td>
                                                                                            <td align="center">
                                                                                             <asp:TextBox ID="txtDate" runat="server" style="border:none;" CssClass="datepicker1" ></asp:TextBox>
                                                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Date" Display="None" ValidationGroup="submit"  ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>

                                                                                            
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                            <td width="5">
                                                                            </td>
                                                                            <td width="249" align="left">
                                                                               
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <table width="480" border="0" cellspacing="0" cellpadding="0" height="40">
                                                                        <tr>
                                                                            <td width="400" valign="top" align="right" style="padding-right:35px;">
                                                                               <asp:Button ID="btnSearch" runat="server" Text="Search Cabs" onclick="btnSearch_Click"  class="lj_button" />
                                                                            </td>
                                                                            <td width="80" valign="bottom">
                                                                                <%--<input type="button" value="Search Cabs" class="lj_button" onclick="return fnGetTrips()" />--%>
                                                                                 
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
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="457" class="lj_banner_bg" align="left">
                                            <script type="text/javascript">
$(document).ready(function() {
  


    $('.slideshowheader').cycle({
		fx: 'fade', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
		autostop: false,
		timeout:5000, 
	});
});
                                            </script>
                                            <div class="slideshowheader" style="z-index: 0;">
                                                <img src="Newimages/hotel1.png" width="441" height="372" />
                                                <img src="Newimages/flight1.png" width="441" height="372" />
                                                <img src="Newimages/car1.png" width="441" height="372" />
                                                <img src="Newimages/bus1.png" width="441" height="372" />
                                            </div>
                                            <!-- slideshowheader -->
                                        </td>
                                    </tr>
                                </table>
                                <!--contentEnd-->
                            </td>
                        </tr>
                        <tr>
                            <td height="5">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <%--<table width="1000" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="480" valign="top">
                                            <table width="480" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="left" width="54" height="65">
                                                        <img src="Newimages/best_office.png" width="44" height="48" />
                                                    </td>
                                                    <td align="left">
                                                        <span class="lj_choice">Choice!</span>
                                                        <br />
                                                        Over 100,000<br />
                                                        Hotels & Activities
                                                    </td>
                                                    <td width="140">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="54">
                                                        <img src="Newimages/rupees_tag.png" width="44" height="48" />
                                                    </td>
                                                    <td align="left">
                                                        <span class="lj_choice">Price!</span>
                                                        <br />
                                                        Guaranteed<br />
                                                        Low Prices Every
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" height="1" bgcolor="#aaabad">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="54" height="65">
                                                        <img src="Newimages/trust.png" width="44" height="48" />
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <span class="lj_choice">Trust!</span>
                                                        <br />
                                                        Need a trip Brand<br />
                                                        that you can trust
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="54">
                                                        <img src="Newimages/points.png" width="44" height="48" />
                                                    </td>
                                                    <td align="left">
                                                        <span class="lj_choice">Points!</span>
                                                        <br />
                                                        Earn BIGGIES!<br />
                                                        (Loyalty Points)
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="400" class="lj_offer" valign="top">
                                            <table width="400" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td colspan="2" height="34" bgcolor="#ef9c00" class="lj_hd" align="left">
                                                        Offers and Promotions
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="lj_end">
                                                        <span class="lj_choice">End of Year Sale</span>
                                                        <br />
                                                        Up to Rs 5000 Off on<br />
                                                        International Flights.
                                                        <br />
                                                        <a href="#">Know More</a>
                                                    </td>
                                                    <td align="center" width="120" height="100">
                                                        <img src="Newimages/sp_offer.png" width="80" height="78" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>--%>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                            </td>
                        </tr>
                        <tr>
                            <%--<td>
                                <!--footer-->
                                <table width="1000" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="lj_foot" align="center">
                                            <ul>
                                                <li><a href="Bus.aspx">Home</a></li>
                                                <li><a href="PrintTicket.aspx">Print Ticket</a></li>
                                                <li><a href="CancelTicket.aspx">Cancel Ticket</a></li>
                                                <li><a href="BecomeAnAgent.aspx">Agent Registration</a></li>
                                                    <li><a href="Login.aspx">Login</a></li>
                                                    <li><a href="ContactUs.aspx" style="border-right: none;">Contact Us</a> </li>
                                            </ul>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            © Copyright 2012 - 2013 | www.Lovejourney.in. All Rights Reserved.
                                        </td>
                                    </tr>
                                </table>
                                <!--footerEnd-->
                            </td>--%>
                        </tr>
                    </table>
                    <!--MainTable-->
                </td>
            </tr>
        </table>

    </table>

</asp:Content>

