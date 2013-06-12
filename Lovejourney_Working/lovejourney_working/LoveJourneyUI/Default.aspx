<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Bus"
    MasterPageFile="~/MasterPage.master" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="alexaVerifyID" content="EfFKC3QV_q2bfL-KW7ZhApSHOpg" />

<meta name="keywords" 
content="keyword1,keyword2, EfFKC3QV_q2bfL-KW7ZhApSHOpg" />--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-37274655-1']);
        _gaq.push(['_setDomainName', 'lovejourney.in']);
        _gaq.push(['_setAllowLinker', true]);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'stats.g.doubleclick.net/dc.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>
    <script type="text/javascript">
        function fnclear() {
            // if ($("#txtsource").va() != "") {
            $("#txtSource").val('');
           //  }

        }

        function fnclear1() {
            //if ($("#txtDestination").va() != "") {
            $("#txtDestination").val('');
            // }

        }

        
    </script>
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
    <%--<style type="text/css">
.lj_chromestyle{
width:100%;
background-color:none;
}



.lj_chromestyle:after{ /*Add margin between menu and rest of content in Firefox*/
content: "."; 
display: block; 
height: 0; 
clear: both; 
visibility: hidden;
}

.lj_chromestyle ul{
border: 0px solid #BBB;
width: 100%;
background: url(chromebg.gif) center center repeat-x; /*THEME CHANGE HERE*/
padding:0;
margin: 0;
text-align: left; /*set value to "left", "center", or "right"*/
}

.lj_chromestyle ul li{
display: inline;
}

.lj_chromestyle ul li a{
 width:50px;
    height:35px;
    background:url(Newimages/flight_i.png) no-repeat center left ;
    display:block;
    padding:0px 0px 0px 42px;
    line-height:35px;
float:left;
}

.lj_chromestyle ul li a:hover, .chromestyle ul li a.selected{
	 width:50px;
    height:35px;
    background:url(Newimages/flight_i.png) no-repeat center left ;
    display:block;
    padding:0px 0px 0px 42px;
    line-height:35px;
	color:#000;
}

/* ######### Style for Drop Down Menu ######### */

.dropmenudiv1{
position:absolute;
top: 0px;
border: 1px solid #f29b22; /*THEME CHANGE HERE*/
border-bottom-width: 0;
font:normal 12px Verdana;
line-height:18px;
z-index:100;
background-color:#e8ae42;
width:150px;
color:#000;
font-weight:bold;
visibility: hidden;
text-align:left;
margin-top:1px;

}


.dropmenudiv1 a{
width: auto;
display: block;
text-indent: 3px;
border-bottom: 1px solid #f29b22; /*THEME CHANGE HERE*/
padding:1px 3px;
text-decoration: none;
font-weight:normal;
color:#000;
font-weight:bold;
font-family:Arial, Helvetica, sans-serif;
background-image:none;
}

.dropmenudiv1 a:hover{ /*THEME CHANGE HERE*/
background-color: #9c2019;
color:#ffffff;
font-weight:bold;
padding:1px 3px;
background-image:none;
}

.rt_img img
{
	border-color:black 1px solid;
}
    </style>--%>
    <!--slides-->
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
    <!--slidesEnd-->
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
    <%--</head>
<body>--%>
    <%--    <form id="form1" runat="server">--%>
    <div>
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
                                                                   
                                                                    <asp:Label ID="seachbus" runat="server" Text="Search your Bus Here"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="300" height="30" class="lj_trip">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <input id="rbOneWay" name="triptype" type="radio" value="single" checked="checked" />
                                                                                &nbsp;&nbsp;One Way
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td align="left" class="hidden">
                                                                                <input id="rbRoundTrip" name="triptype" type="radio" value="return" />
                                                                                &nbsp;&nbsp;Round Trip
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
                                                                                <div class="lj_outDiv">
                                                                                    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                        <tr>
                                                                                            <td width="70" align="center" class="lj_bdrit">
                                                                                                <img src="Newimages/b_i.png" width="56" height="32" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <input type="text" id="txtSource" name="txtSource" style="width: 150px; padding: 3px;
                                                                                                    border: none" onclick="fnclear();" />
                                                                                                <input type="hidden" id="hdnSources" name="hdnSources" />
                                                                                                <input type="hidden" id="hdnSelectedSource" name="hdnSelectedSource" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                            <td width="10">
                                                                            </td>
                                                                            <td width="233" align="left">
                                                                                <div class="lj_outDiv">
                                                                                    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                        <tr>
                                                                                            <td width="70" align="center" class="lj_bdrit">
                                                                                                <img src="Newimages/b_i.png" width="56" height="32" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <input type="text" id="txtDestination" name="txtDestination" style="width: 150px;
                                                                                                    padding: 3px; border: none;" onclick="fnclear1();" />
                                                                                                <input type="hidden" id="hdnDestinations" name="hdnDestinations" />
                                                                                                <input type="hidden" id="hdnSelectedDestination" name="hdnSelectedDestination" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
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
                                                                                <div class="lj_outDiv">
                                                                                    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                        <tr>
                                                                                            <td width="70" align="center" class="lj_bdrit">
                                                                                                <img src="Newimages/calender.png" width="56" height="32" />
                                                                                            </td>
                                                                                            <td align="left">
                                                                                                <input type="text" id="txtDOJ" name="txtDOJ" style="width: 150px; padding: 3px; border: none;" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                            <td width="10">
                                                                            </td>
                                                                            <td width="233" align="left">
                                                                                <div class="hidden">
                                                                                    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                        <tr>
                                                                                            <td width="70" align="center" class="lj_bdrit">
                                                                                                <img src="Newimages/calender.png" width="56" height="32" />
                                                                                            </td>
                                                                                            <td align="left">
                                                                                                <input type="text" id="txtDOR" name="txtDOR" style="width: 150px; padding: 3px; border: none;" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
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
                                                                            <td width="400" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="80" valign="bottom">
                                                                                <input type="button" value="Search Buses" class="lj_button" onclick="return fnGetTrips()" />
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
        <script runat="server">
            protected String GetServerDate()
            {
                return DateTime.Now.ToString("yyyy/MM/dd");
            }
        </script>
        <script type="text/javascript">
            var baseURL = '';

            var serverDate = "<%= GetServerDate()%>";
            $(document).ready(function () {
                //                $.cookie("SourceUser", $("#txtSource").val(), { expires: 365 });
                //                $.cookie("DestinationUser", $("#txtDestination").val(), { expires: 365 });
                //                $.cookie("SelectedSourceUser", $("#hdnSelectedSource").val(), { expires: 365 });
                //                $.cookie("SelectedDestinationUser", $("#hdnSelectedDestination").val(), { expires: 365 });
            });
            //initialize fields and set default properties
            fnSetFields();
            var url = document.URL.toString().split('=');
            if (url.length > 1) {
                /** load from and to cities autocomplete dropdowns **/
                if (url[1].toString() == "Tours") {
                    fnLoadCitiesTours();
                }
            }
            else {

                fnLoadCities();
            }
            //function to validate user input and redirect user to search results page
            function fnGetTrips() {
                if (url.length > 1) {
                }
                else {

                    if ($.cookie('SourceUser') == null && $.cookie('DestinationUser') == null) {

                        $.cookie("SourceUser", $("#txtSource").val(), { expires: 365 });
                        $.cookie("DestinationUser", $("#txtDestination").val(), { expires: 365 });
                        $.cookie("SelectedSourceUser", $("#hdnSelectedSource").val(), { expires: 365 });
                        $.cookie("SelectedDestinationUser", $("#hdnSelectedDestination").val(), { expires: 365 });

                    }
                    else {
                        $.cookie('SourceUser', $("#txtSource").val());
                        $.cookie('DestinationUser', $("#txtDestination").val());
                        $.cookie('SelectedSourceUser', $("#hdnSelectedSource").val());
                        $.cookie('SelectedDestinationUser', $("#hdnSelectedDestination").val());
                    }
                }

                //check if all required fields are entered
                if ($('#txtSource').val() == '') {
                    alert('Please select source.');
                    return;
                }
                if ($('#txtDestination').val() == '') {
                    alert('Please select destination.');
                    return;
                }
                if ($('#hdnSelectedSource').val() != '' && $('#hdnSelectedDestination').val() != '' && $('#txtDOJ').val() != '') {

                    //check if round trip is selected and validate if return date is selected
                    if ($("input[name=triptype]:checked").val() == 'return' && $('#txtDOR').val() == '') {
                        alert('Please select return journey date');
                        return false;
                    }

                    //set values to window.name and use it in select bus page
                    window.name = "fromCityId=" + $('#hdnSelectedSource').val() +
                                                        "&fromCityName=" + $('#txtSource').val() +
                                                        "&toCityId=" + $('#hdnSelectedDestination').val() +
                                                        "&toCityName=" + $('#txtDestination').val() +
                                                        "&doj=" + $('#txtDOJ').val() +
                                                        "&dor=" + $('#txtDOR').val() +
                                                        "&busType=Any" +
                                                        "&tripType=" + $("input[name=triptype]:checked").val();
                    //redirect user to SelectBus page
                    window.location.href = "SelectBus.aspx";
                }
                else {
                    alert('Please select source, destination.');
                }
            }
            //show/hide round trip date based on triptype selection
            $('input[name=triptype]').change(function () {
                //single trip
                if ($("input[name=triptype]:checked").val() == 'single')
                    $('#trDOR').hide();
                //round trip
                else if ($("input[name=triptype]:checked").val() == 'return') {
                    var myDate = new Date(serverDate);
                    var nextDay = new Date(myDate.getFullYear(), myDate.getMonth(), myDate.getDate() + 1);
                    $('#trDOR').show();
                    $('#txtDOR').val($.datepicker.formatDate('dd-mm-yy', nextDay));
                }
            });

        </script>
    </div>
    <%--   </form>--%>
    <%--</body>
</html>
    --%>
</asp:Content>
