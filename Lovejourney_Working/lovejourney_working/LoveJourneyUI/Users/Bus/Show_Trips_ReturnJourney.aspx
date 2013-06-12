<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Show_Trips_ReturnJourney.aspx.cs"
    Inherits="Users_Show_Trips_ReturnJourney" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>LoveJourney - Bus - SelectBus</title>
    <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <link href="../../images/favicon.png" rel="Shortcut Icon" type="text/css" />
    <link href="../../css/mak_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../css/chromestyle.css" />
    <script type="text/javascript" src="../../js/chrome.js"></script>
    <script src="../../Scripts/ShowTripsUsersReturn.js" type="text/javascript"></script> 

    
        <script src="../../Scripts/jquery.multiselect.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.multiselect.filter.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.multiselect.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/jquery.multiselect.filter.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function pageLoad() {
            fnSetSliders();

            LoadRoutes(this, 'none~none');
        }
        $(function () {
            $(".datepicker").datepicker({
                dateFormat: 'dd-MM-yy',
                numberOfMonths: 2,
                showOn: "button",
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: new Date()
            });
        });
        function showDate() {
            $(".datepicker").datepicker("show");
        }
    </script>
    <%--StyleClass--%>
    <style type="text/css">
        .loadingBackground
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            filter: Alpha(Opacity=30);
            -moz-opacity: 0.3;
            opacity: 0.6;
            width: 100%;
            height: 100%;
            background-color: #000;
            position: fixed;
            z-index: 500;
            top: 0px;
            left: 0px;
        }
        .rate_widget
        {
            overflow: visible;
            padding: 0px;
            position: relative;
            height: 18px;
            margin: 0px;
        }
        .ratings_stars
        {
            background: url('../../images/star_empty.png') no-repeat;
            float: left;
            background-position: left;
            height: 22px;
            padding: 0px;
            width: 22px;
            margin-left: -5px;
        }
        .ratings_stars2
        {
            background: url('../../images/star_empty.png') no-repeat;
            float: left;
            background-position: left;
            height: 22px;
            padding: 0px;
            width: 22px;
            margin-left: 3px;
        }
        .ratings_vote
        {
            background: url('../../images/star_full.png') no-repeat;
            background-position: left;
        }
        .ratings_over
        {
            background: url('../../images/star_highlight.png') no-repeat;
            background-position: left;
        }
        .total_votes
        {
            background: #eaeaea;
            top: 58px;
            left: 0;
            padding: 5px;
            position: absolute;
        }
        .movie_choice
        {
            font: 10px verdana, sans-serif;
            margin: 0 auto 40px auto;
            width: 180px;
        }
        .slider_line
        {
            background-color: Red;
        }
        .CloseModify
        {
            border-style: solid;
            border-color: #d9d8cc;
            border-width: 2px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
        }
        body
        {
            margin: 10px;
            color: #000000;
        }
        #UpdateProgress1
        {
            top: 0px;
            right: 0px;
            position: fixed;
            background-color: Blue;
        }
        #UpdateProgress1 img
        {
            vertical-align: middle;
            margin: 2px;
        }
        
        .slider
        {
            display: none;
        }
        .collapseSlider
        {
            display: none;
        }
        .sliderExpanded .collapseSlider
        {
            display: block;
        }
        .sliderExpanded .expandSlider
        {
            display: none;
        }
        .closeSlider
        {
            background-image: url(../../images/close.png);
            cursor: pointer;
            width: 16px;
            height: 16px;
            margin-top: -25px;
            margin-right: -5px;
            border: 0px;
            float: right;
        }
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .empty_seat
        {
            width: 24px;
            height: 22px;
        }
        .empty_bay
        {
            width: 24px;
            height: 5px;
        }
        .empty_sleeper
        {
            width: 42px;
            height: 19px;
        }
        .available_seat
        {
            background-image: url('../../images/available_seat.png');
            background-repeat: no-repeat;
            width: 24px;
            height: 22px;
        }
        .available_sleeper
        {
            background-image: url('../../images/available_sleeper.png');
            background-repeat: no-repeat;
            width: 42px;
            height: 19px;
        }
        
        .availableladies_seat
        {
            background-image: url('../../images/availableladies_seat.png');
            background-repeat: no-repeat;
            width: 24px;
            height: 22px;
        }
        
        .availableladies_sleeper
        {
            background-image: url('../images/availableladies_sleeper.png');
            background-repeat: no-repeat;
            width: 43px;
            height: 19px;
        }
        
        .booked_seat
        {
            background-image: url('../../images/booked_seat.png');
            background-repeat: no-repeat;
            width: 24px;
            height: 22px;
        }
        .booked_sleeper
        {
            background-image: url('../../images/booked_sleeper.png');
            background-repeat: no-repeat;
            width: 42px;
            height: 19px;
        }
        
        .selected_seat
        {
            background-image: url('../../images/selected_seat.png');
            background-repeat: no-repeat;
            width: 24px;
            height: 22px;
        }
        .selected_sleeper
        {
            background-image: url('../../images/selected_sleeper.png');
            background-repeat: no-repeat;
            width: 42px;
            height: 19px;
        }
        #seat_info, #boardingpoint_info, #details_info
        {
            display: none;
            min-height: 40px; /*min height of DIV should be set to at least 2x the width of the arrow*/
            border: 1px Solid #2E9AFE;
            font-size: 12px;
            padding: 5px;
            position: relative;
            word-wrap: break-word;
            -moz-border-radius: 5px; /*add some nice CSS3 round corners*/
            -webkit-border-radius: 5px;
            border-radius: 5px;
            margin-bottom: 2em;
            background-color: #CEF6F5;
        }
        #seat_info:after, #details_info:after
        {
            /*arrow added to seat_info DIV*/
            content: '';
            display: block;
            position: absolute;
            top: -20px; /*should be set to -border-width x 2 */
            left: 30px;
            width: 0;
            height: 0;
            border-color: transparent transparent #2E9AFE transparent; /*border color should be same as div div background color*/
            border-style: solid;
            border-width: 10px;
        }
        
        #boardingpoint_info:after
        {
            /*arrow added to leftarrowdiv DIV*/
            content: '';
            display: block;
            position: absolute;
            top: 10px;
            left: -20px; /*should be set to -border-width x 2 */
            width: 0;
            height: 0;
            border-color: transparent #2E9AFE transparent transparent; /*border color should be same as div div background color*/
            border-style: solid;
            border-width: 10px;
        }
        
        ul.seat_map
        {
            height: 35px;
            margin: 10px;
        }
        
        ul.seat_map li
        {
            list-style-type: none;
            float: left;
            margin-right: 15px;
            text-align: center;
            cursor: pointer;
        }
        
        ul.seat_map a
        {
            color: #000000;
            font-size: 10px;
            overflow: hidden;
            cursor: pointer;
            text-decoration: none;
        }
        
        .clearFix:after
        {
            clear: both;
            content: ".";
            display: block;
            height: 0;
            line-height: 0;
            visibility: hidden;
        }
        
        ul.boardingpoints
        {
            float: left;
            border: 4px Solid #AAA;
            -moz-border-radius: 5px; /*add some nice CSS3 round corners*/
            -webkit-border-radius: 5px;
            border-radius: 5px;
            width: 250px;
            padding: 0px;
            max-height: 200px;
            overflow: auto;
            background: #F5F5F5;
        }
        
        ul.boardingpoints li
        {
            cursor: pointer;
            padding: 5px 3px 3px 2px;
            font-size: 11px;
            list-style-type: none;
            border: 1px Solid #CCC;
        }
        
        ul.busfacilities
        {
            background-color: #FFEBCD;
            border: 1px Solid #FF8C00;
            margin-top: 25px;
            margin-left: 20px;
            float: left; /*border: 4px Solid #AAA;*/
            -moz-border-radius: 5px; /*add some nice CSS3 round corners*/
            -webkit-border-radius: 5px;
            border-radius: 5px;
            width: 125px;
            padding: 0px;
            max-height: 200px;
            overflow: auto; /*background: #F5F5F5;*/
        }
        
        ul.busfacilities li
        {
            cursor: text;
            padding: 0px 3px 3px 2px;
            font-size: 11px;
            list-style-type: none;
        }
        .normal
        {
            background-color: white;
        }
        .highlight
        {
            background-color: #cccccc;
        }
        .fg-button
        {
            color: Black;
            clear: left;
            margin: 0 4px 10px 20px;
            padding: .2em 1em;
            text-decoration: none !important;
            cursor: pointer;
            position: relative;
            text-align: center;
            zoom: 1;
        }
        .fg-button .ui-icon
        {
            position: absolute;
            top: 50%;
            margin-top: -8px;
            left: 50%;
            margin-left: -8px;
        }
        a.fg-button
        {
            float: left;
        }
        button.fg-button
        {
            width: auto;
            overflow: visible;
        }
        /* removes extra button width in IE */
        .fg-button-icon-left
        {
            padding-left: 2.1em;
        }
        .fg-button-icon-right
        {
            padding-right: 2.1em;
        }
        .fg-button-icon-left .ui-icon
        {
            right: auto;
            left: .2em;
            margin-left: 0;
        }
        .fg-button-icon-right .ui-icon
        {
            left: auto;
            right: .2em;
            margin-left: 0;
        }
        .fg-button-icon-solo
        {
            display: block;
            width: 8px;
            text-indent: -9999px;
        }
        /* solo icon buttons must have block properties for the text-indent to work */
        
        .fg-button.ui-state-loading .ui-icon
        {
            background: url(spinner_bar.gif) no-repeat 0 0;
        }
        #Cancel1
        {
            position: absolute;
            left: 0px;
            top: 0px;
            display: none;
            color: #000;
            margin: 30% 0% 0% 30%;
            z-index: 999;
            font-family: Arial;
            font-size: 12px;
            background-color: #FFEBCD;
            border: 1px Solid #FF8C00;
        }
        #Cancel2
        {
            position: absolute;
            left: 0px;
            top: 0px;
            display: none;
            color: #000;
            margin: 30% 0% 0% 30%;
            z-index: 999;
            font-family: Arial;
            font-size: 12px;
            background-color: #FFEBCD;
            border: 1px Solid #FF8C00;
        }
        .Info22
        {
            font-family: Verdana;
            font-size: 11px;
            font-weight: normal;
        }
    </style>
    <style type="text/css">
        .travel_main
        {
            border-bottom: 1px solid #d7d7d7;
            margin-top: 3px;
            width: 880px;
            height: 65px;
        }
        
        .travel_main_sub
        {
            height: 50px;
            width: 880px;
            padding: 5px;
        }
        
        .travel_main_sub:hover
        {
            height: 55px;
            width: 880px;
            background: #cccccc;
        }
        .travel_name
        {
            width: 170px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            float: left;
            color: #003b72;
            min-width: 170px;
        }
        
        .travel_name_cap
        {
            width: 170px;
            color: blue;
            float: left;
            font-family: Verdana;
            font-size: 11px;
            font-weight: normal;
            color: #000;
            margin: 0px;
            height: 13px;
            min-width: 170px;
        }
        
        .travea_sleep
        {
            width: 175px;
            float: left;
            font-family: Verdana;
            font-size: 11px;
            margin: 0px;
            min-width: 175px;
        }
        
        .travea_time
        {
            width: 72px;
            float: left;
            font-family: Verdana;
            font-size: 12px;
            min-width: 72px;
        }
        
        .travea_time a
        {
            text-decoration: underline;
            color: #000;
        }
        
        .travea_duration
        {
            width: 72px;
            float: left;
            font-family: Verdana;
            font-size: 10px;
            text-align: center;
            margin: 0px;
            min-width: 72px;
        }
        
        
        .travel_price
        {
            float: left;
            width: 80px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            color: #003b72;
            min-width: 80px;
        }
        
        .t_cancellation a
        {
            color: #000;
            text-decoration: underline;
            font-weight: normal;
            cursor: pointer;
        }
        
        .t_avail
        {
            font-size: 11px;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: normal;
            float: left;
            text-align: center;
            width: 80px;
            margin-bottom: 5px;
            min-width: 80px;
        }
        
        .t_srch
        {
            cursor: pointer;
            background: #003B77;
            text-align: center;
            color: #fff;
            font-size: 12px;
            font-weight: bold;
            border: none;
            font-family: Arial;
            padding: 2px;
            float: left;
        }
        
        
        
        
        
        
        .travel_main_sub1
        {
            height: 5px;
            width: 880px;
            padding: 5px;
            font-family: Verdana;
            font-size: 12px;
            font-weight: bold;
        }
        
        
        .travel_name1
        {
            width: 170px;
            font-family: Verdana;
            font-size: 12px;
            float: left;
            font-weight: bold;
        }
        
        
        .travea_sleep1
        {
            width: 175px;
            float: left;
            font-family: Verdana;
            font-size: 12px;
            margin: 0px;
            font-weight: bold;
        }
        
        
        .travea_time1
        {
            width: 72px;
            float: left;
            font-family: Verdana;
            font-size: 12px;
            font-weight: bold;
        }
        
        .travea_duration1
        {
            width: 72px;
            float: left;
            font-family: Verdana;
            font-size: 12px;
            margin: 0px;
            font-weight: bold;
        }
        
        
        .travel_price1
        {
            float: left;
            width: 80px;
            text-align: center;
            font-family: Verdana;
            font-size: 12px;
            font-weight: bold;
        }
        
        
        .t_avail1
        {
            font-family: Verdana;
            font-size: 12px;
            float: left;
            text-align: center;
            width: 80px;
            margin-bottom: 5px;
            font-weight: bold;
            height: 10px;
        }
        
        
        
        
        
        
        
        .slideTitle
        {
            font-weight: bold;
            font-size: small;
            font-style: italic;
        }
        
        .slideDescription
        {
            font-size: small;
            font-weight: bold;
        }
        
        .validatorCalloutHighlight
        {
            background-color: lemonchiffon;
        }
        
        .ListSearchExtenderPrompt
        {
            font-style: italic;
            color: Gray;
            background-color: white;
        }
        
        .ajax__multi_slider_custom .outer_rail_horizontal
        {
            position: absolute;
            background: url('../../Images/line.jpg') repeat-x;
            width: 175px;
            height: 25px;
            z-index: 100;
        }
        
        .ajax__multi_slider_custom .inner_rail_horizontal
        {
            position: absolute;
            background: url('../../Images/line.jpg') repeat-x;
            width: 175px;
            height: 25px;
            z-index: 100;
        }
        
        .ajax__multi_slider_custom .handle_horizontal_left
        {
            position: absolute;
            background: url('../../Images/bus.jpg') no-repeat;
            width: 22px;
            height: 25px;
            z-index: 200;
            cursor: w-resize;
        }
        
        .ajax__multi_slider_custom .handle_horizontal_right
        {
            position: absolute;
            background: url('../../Images/bus.jpg') no-repeat;
            width: 16px;
            height: 25px;
            z-index: 200;
            cursor: w-resize;
        }
    </style>
    <%--StyleClassEnd--%>
</head>
<body>
    <form runat="server" id="frm1">
    <script type="text/javascript">
        function ModifySearch() {
            var ddlSources = document.getElementById('<%=ddlSources.ClientID %>');
            var ddlSourcesIndex = ddlSources.selectedIndex;
            var ddlSourcesValue = ddlSources.value;
            var ddlSourcesText = ddlSources.options[ddlSources.selectedIndex].text;

            var ddlDestinationsValue = $("#ddldestinationsDiv option:selected").val();
            var ddlDestinationsText = $("#ddldestinationsDiv option:selected").text();

            var journeyDate = document.getElementById('<%=lblJD.ClientID %>');

            var today = new Date();
            today.setDate(today.getDate() - 1);
            var a = today.getFullYear() + today.getMonth() + today.getDate();

            var jDate = new Date(Date.parse(journeyDate.value, "yyyy-MM-dd"));
            var b = jDate.getFullYear() + jDate.getMonth() + jDate.getDate();

            if (ddlSourcesText != "----------") {
                if (ddlDestinationsText != "----------") {
                    if (ddlSourcesText != ddlDestinationsText) {

                        setTimeout(function () {
                            $("#hdnValue").val(0);
                            LoadRoutes(this, 'modify' + '~' + ddlSourcesValue + '*' + ddlDestinationsValue + '*' + journeyDate.value + '*' + ddlSourcesText + '*' + ddlDestinationsText);
                            document.getElementById('lblRoute').innerHTML = ddlSourcesText + "<span style='color:Black;'> <i>to</i> </span>" + ddlDestinationsText
                            + "<span style='color:Black;'> <i>on</i> </span>" + journeyDate.value;
                        }, 400);

                        resetControls();
                        return false;
                    } else { alert('Source and Destination should not be same.'); return false; }
                } else { alert('Please select the destination.'); return false; }
            } else { alert('Please select the source.'); return false; }
        }
    </script>
    <div id="Cancel1">
    </div>
    <div id="SeatLayoutJQ">
        <div id="address_info" style="display: none; z-index: 3000; position: absolute;">
        </div>
        <div id="modalbackground" class="loadingBackground" style="display: none;">
        </div>
        <div id="SeatLayout" style="display: none; z-index: 3000; background-color: #FFF;
            vertical-align: middle; text-align: center; border: 2px solid #cac9c6; position: absolute;
            left: 15%; top: 35%;">
            <div>
                <table width="100%">
                    <tr>
                        <td style="border-bottom: 0px;">
                            <div id="TravelInfo" class="fg-button fg-button-icon-right ui-widget ui-state-default ui-corner-all">
                            </div>
                        </td>
                        <td style="border-bottom: 0px;" valign="top">
                            <img alt="img" src="../../images/closeseatlayout.png" style="float: right;" onclick="closePanel('SeatLayout'); closePanel('modalbackground');" />
                        </td>
                    </tr>
                </table>
            </div>
            <input id="seatsSelected1" type="hidden" value="" name="TBSelectedSeats1" />
            <input id="seatsSelected" type="hidden" value="" name="TBSelectedSeats" />
            <span style="font-family: Verdana; font-size: 11px; font-weight: normal;">Selected Seat(s):
                <strong><span id="seatList"></span></strong></span>&nbsp;&nbsp;&nbsp;<span class="flL fare"
                    style="font-family: Verdana; font-size: 11px; font-weight: normal;">Total Fare:</span>
            <span class="flL amount" style="font-family: Verdana; font-size: 11px; font-weight: normal;">
                Rs. <strong><span id="totalFareDetails" style="color: Red; font-family: Verdana;
                    font-size: 11px; font-weight: normal;"></span></strong></span>&nbsp;&nbsp;&nbsp;<a
                        class="flL details" onmouseout="closePanel('details_info');" onmouseover="showPanel(event,'details_info',null);"
                        href="javascript:void(0);">Details</a>
            <div>
                <table width="100%">
                    <tr>
                        <td style="border-bottom: 0px;" align="center">
                            <div id="layout">
                            </div>
                        </td>
                        <td style="border-bottom: 0px;" valign="top">
                            <img src="../../images/desc.png" />
                            <br />
                            <br />
                            <asp:Button ID="btnContinue" runat="server" CssClass="buttonBook" Text=" Continue "
                                Style="padding: 3px; float: left; font-family: verdana; font-size: 11px;" OnClick="btnContinue_Click"
                                OnClientClick="return SetValues();" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="seat_info">
            <span class="arrow"></span>
            <div class="tool_tip">
                <p class="info1 clearFix">
                    <strong>Seat No:</strong> <span id="seatNo_ttip"></span>
                </p>
                <p class="info1 clearFix">
                    <strong>Seat Type:</strong> <span id="seatType_ttip"></span>
                </p>
                <p class="info1">
                    <strong>Fare:</strong> Rs. <span id="seatFare_ttip"></span>
                </p>
            </div>
        </div>
        <div id="details_info" style="display: none; z-index: 3000;">
            <div class="tool_tip">
                <span id="seat_details_info" style="display: inline;">
                    <p class="clearFix">
                        Fare of <strong><span id="seatCount"></span></strong>Seat(s) = Rs. <span id="seatFareTotal">
                        </span>
                    </p>
                </span>
                <p class="total">
                    <strong>Total Fare: Rs. <span id="fareTotal"></span></strong>
                </p>
            </div>
        </div>
        <div id="boardingpoint_info" style="position: relative; left: 100px; width: 300px;">
            <em>More Information</em>
            <div class="tool_tip">
                <p class="info1">
                    <strong>ContactNumber:</strong> <span id="bpContactNumber_ttip"></span>
                </p>
                <p class="info1">
                    <strong>Landmark:</strong> <span id="bpLandmark_ttip"></span>
                </p>
                <p class="info1 clearFix">
                    <strong>Address:</strong> <span id="bpAddress_ttip"></span>
                </p>
            </div>
        </div>
        <asp:HiddenField ID="hdnBoardingPointIdJQ" runat="server" />
        <asp:HiddenField ID="hdnSeatListJQ" runat="server" />
        <asp:HiddenField ID="hdnFareJQ" runat="server" />
        <asp:HiddenField ID="hdnTravelInfoJQ" runat="server" />
        <asp:HiddenField ID="hdnBoardingPointNameJQ" runat="server" />
        <asp:HiddenField ID="hdnlblBJQ" runat="server" />
        <asp:HiddenField ID="hdnFromCityIdJQ" runat="server" />
        <asp:HiddenField ID="hdnFromCityNameJQ" runat="server" />
        <asp:HiddenField ID="hdnToCityIdJQ" runat="server" />
        <asp:HiddenField ID="hdnToCityNameJQ" runat="server" />
        <asp:HiddenField ID="hdnJourneyDateJQ" runat="server" />
        <asp:HiddenField ID="hdnJourneyDetailsJQ" runat="server" />
        <asp:HiddenField ID="hdnValue" Value="0" runat="server" />
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ToolkitScriptManager>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
         
        <tr>
            <td align="center" bgcolor="#013e7f">
                <table width="990" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="250" height="75" align="left">
                            <a href="../AdminDashBoard/AdminDashBoard.aspx">
                                <img src="../../images/logo.gif" width="228" height="75" /></a>
                        </td>
                        <td width="740" valign="top">
                            <table width="700" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblUsername" runat="server" ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" style="padding-bottom: 8px;">
                                        <div id="chromemenu1" class="chromestyle1">
                                            <ul>
                                                <li id="lidashboard" runat="server"><a href="../AdminDB/AdminDb.aspx">Home</a></li>
                                                <li><a href="Bus_Search.aspx">Buses</a></li>
                                                <li><a href="#" rel="drflights">Flights</a></li>
                                                <li><a href="../Hotel/HotelSearch.aspx">Hotels</a></li>
                                                <li><a href="../Recharge/Recharge.aspx">Recharge</a></li>
                                                <li><a href="../Bus/Users.aspx">CSE</a></li>
                                                <li><a href="#" rel="dragents">Agents</a></li>
                                                <li><a href="../Bus/PromoCode.aspx">Promocode</a></li>
                                                <li><a href="../Bus/ViewFeedbacks.aspx">Feedback</a></li>
                                                <li><a href="../Bus/ChangePassword.aspx">Change Password</a></li>
                                                <li>
                                                    <asp:LinkButton ID="lbtnlogout" runat="server" Text="Logout" OnClick="lbtnlogout_Click"></asp:LinkButton></li>
                                            </ul>
                                            <div id="drflights" class="dropmenudiv1">
                                                <a href="../Flight/frmDomesticAvailability.aspx">Domestic Flights </a><a href="../Flight/frmInternationalAvailablity.aspx">
                                                    International Flights </a>
                                            </div>
                                            <div id="dragents" class="dropmenudiv1">
                                                <a href="../Bus/Agents.aspx">View </a><a href="../Bus/frmAgentsDeposits.aspx">Deposits
                                                </a><a href="../Bus/AgentRequests.aspx">Register Requests </a><a href="../Bus/FundTransferReport.aspx">
                                                    Deposit Requests </a><a href="../Bus/StopServices.aspx">Stop Services </a><a href="../AdminDB/RoleMaster.aspx">
                                                        Role Master </a>
                                            </div>
                                            <script type="text/javascript">

                                                cssdropdown.startchrome("chromemenu1")

                                            </script>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" class="md_menu">
                <table width="1000" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="md_menu" height="30">
                            <div id="chromemenu" class="chromestyle">
                                <ul>
                                    <li><a href="#" rel="dropmenu1">ManageBooking</a></li>
                                    <li><a href="#" rel="dropmenu2">Reports</a></li>
                                    <li><a href="#" rel="dropmenu3">Settings</a></li>
                                </ul>
                            </div>
                            <div id="dropmenu1" class="dropmenudiv">
                                <a href="Bus_Search.aspx">Book Ticket </a><a href="PrintTicket.aspx">Print Ticket
                                </a><a href="CancelTicket.aspx">Cancel Ticket </a>
                            </div>
                            <div id="dropmenu2" class="dropmenudiv">
                                <a href="CustomerEnquiry.aspx">Bookings</a> <a href="AgentReports.aspx">AgentBookings
                                </a>
                            </div>
                            <div id="dropmenu3" class="dropmenudiv">
                                <%--        <a href="Rating.aspx">Rating</a>--%>
                                <a href="CancellationPolicy.aspx">Cancellation Policy </a><a href="BitlaRoutes.aspx">
                                    Bitla Routes </a>
                            </div>
                            <script type="text/javascript">

                                cssdropdown.startchrome("chromemenu")

                            </script>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="85%" border="0">
                    <tr>
                        <td valign="top">
                            <div id="Route">
                                <fieldset>
                                    <legend><span style="color: Red;">Route</span></legend>
                                    <table width="100%" border="1px">
                                        <tr>
                                            <td align="center" width="70%" style="border-bottom-width: 0px;">
                                                <asp:Label ID="lblOnwardJourneyHeader" runat="server" Text="<span style='color:#003B77;'> Return Journey :: </span>"
                                                    Font-Bold="True" Font-Size="14px" ForeColor="Red" Font-Names="Verdana"></asp:Label>
                                                <asp:Label ID="lblRoute" runat="server" Text="" Font-Bold="True" Font-Size="14px"
                                                    ForeColor="Red" Font-Names="Verdana"></asp:Label>&nbsp; &nbsp; &nbsp;
                                            </td>
                                            <td align="left" width="30%">
                                                <input id="btnModifySearch" type="submit" value="Modify Search" onclick="VisiblePanel(); return false;"
                                                    class="buttonBook" style="cursor: pointer;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:Panel ID="pnlModifyBox" Width="100%" runat="server" Style="display: none;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="30%" valign="top" align="left">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="5px">
                                                                            From:
                                                                        </td>
                                                                        <td width="5px">
                                                                            <asp:DropDownList ID="ddlSources" Enabled="false" onchange="LoadDestinations(); return false;"
                                                                                ValidationGroup="Modify" runat="server" Width="130px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td width="30%" valign="top" align="left">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="5px">
                                                                            To:
                                                                        </td>
                                                                        <td width="5px">
                                                                            <div id="destinationsDiv" runat="server" style="width: 130px;">
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td width="40%" valign="top" align="left">
                                                                <asp:Label ID="Label6" runat="server" Text="On:" CssClass="runtext"></asp:Label>
                                                                <asp:TextBox ID="lblJD" runat="server" onKeyPress="javascript: return false;" onPaste="javascript: return false;"
                                                                    ReadOnly="true" onclick="showDate();" Width="120px" CssClass="datepicker"></asp:TextBox>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <input id="btnMdySearch" type="submit" value=" Modify " title=" Click to modify search "
                                                                    class="buttonBook" style="cursor: pointer;" onclick="ModifySearch();return false;" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Label ID="lblUPDOWNDate" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                                                    <asp:Label ID="lblUPDOWNDateReturn" runat="server" Font-Size="X-Small" ForeColor="Red"> </asp:Label>
                                                    <asp:DropDownList ID="ddlDestinations" Visible="false" ValidationGroup="Modify" runat="server">
                                                    </asp:DropDownList>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <div id="Filters" style="display: none;">
                                <fieldset>
                                    <legend>Filters</legend>
                                    <table width="100%" border="1px">
                                        <tr>
                                            <td width="20%">
                                                <span class="runtext_lineheight">Price Range</span>
                                                <table width="100%">
                                                    <tr valign="middle">
                                                        <td valign="top" width="20%" style="border-bottom: 0px;">
                                                            <asp:TextBox ID="sliderTwo" runat="server" Style="display: none;" />
                                                            <asp:MultiHandleSliderExtender ID="multiHandleSliderExtenderTwo" runat="server" BehaviorID="multiHandleSliderExtenderTwo"
                                                                TargetControlID="sliderTwo" Minimum="1" Maximum="2500" Increment="50" Length="175"
                                                                Orientation="Horizontal" EnableHandleAnimation="true" EnableKeyboard="false"
                                                                EnableMouseWheel="false" EnableRailClick="false" ShowHandleDragStyle="true" ShowHandleHoverStyle="true"
                                                                OnClientDragEnd="ValueChangedHandler" ShowInnerRail="true">
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
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span id="minPriceLbl" class="runtext">1 Rs</span>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value="1" />
                                                            &nbsp; &nbsp;-&nbsp;&nbsp; <span id="maxPriceLbl" class="runtext">2500 Rs</span>
                                                            <asp:HiddenField ID="HiddenField2" runat="server" Value="2500" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="20%">
                                                <span class="runtext_lineheight">Departure Time</span>
                                                <table width="100%">
                                                    <tr valign="middle">
                                                        <td valign="top" width="20%" style="border-bottom: 0px;">
                                                            <asp:TextBox ID="TextBox2" runat="server" Style="display: none;" />
                                                            <asp:MultiHandleSliderExtender ID="multiHandleSliderExtenderTwo1" runat="server"
                                                                BehaviorID="multiHandleSliderExtenderTwo1" TargetControlID="TextBox2" Minimum="0"
                                                                Maximum="23" Increment="1" Length="175" Orientation="Horizontal" EnableHandleAnimation="true"
                                                                EnableKeyboard="false" EnableMouseWheel="false" EnableRailClick="false" ShowHandleDragStyle="true"
                                                                ShowHandleHoverStyle="true" OnClientDragEnd="ValueChangedHandler1" ShowInnerRail="true">
                                                                <MultiHandleSliderTargets>
                                                                    <asp:MultiHandleSliderTarget ControlID="HiddenField3" />
                                                                    <asp:MultiHandleSliderTarget ControlID="HiddenField4" />
                                                                </MultiHandleSliderTargets>
                                                            </asp:MultiHandleSliderExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-bottom: 0px;">
                                                            <br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span id="minTimeLbl" class="runtext">12:00 AM</span>
                                                            <asp:HiddenField ID="HiddenField3" runat="server" Value="0" />
                                                            &nbsp; &nbsp;-&nbsp;&nbsp; <span id="maxTimeLbl" class="runtext">11:59 PM</span>
                                                            <asp:HiddenField ID="HiddenField4" runat="server" Value="23" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="20%">
                                            </td>
                                            <td width="20%">
                                            </td>
                                            <td width="20%">
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <table width="100%">
                                <tr>
                                    <td width="100%" align="center">
                                        <div id="BusesSorting" style="display:none;">
                                            <fieldset>
                                                <legend><span style="color: Red;">Filters</span></legend>
                                                <table width="100%">
                                                    <tr>
                                                        <td width="28%" valign="top">
                                                            <div id="TravelsFilter_dropdown" style="margin-left:15px;" ><%--class="fg-button fg-button-icon-right ui-widget ui-state-default ui-corner-all"--%>
                                                                <%--<select id="ddlOperator" name="ddlOperator" class="Dropdownlist" onchange="LoadFilteredRoutes(event,''); return false;">
                                                                    <option value=''>Loading Operators</option>
                                                                </select>--%>
                                                            </div>
                                                        </td>
                                                        <td width="20%" valign="top">
                                                            <div>
                                                                <a href='' id="refBusFacilities" class="fg-button fg-button-icon-right ui-widget ui-state-default ui-corner-all"
                                                                    onclick="$('#ulBusFacilities').toggle('fast'); return false;"><span class="ui-icon ui-icon-triangle-1-s">
                                                                    </span>Bus Facilities</a>
                                                                <ul id='ulBusFacilities' class="busfacilities" style="display: none; position: absolute;">
                                                                    <li id="liAC">
                                                                        <input type="checkbox" name="cbAC" id="cbAC" value="AC" title="AC" onchange="LoadFilteredRoutes(event,'');" />AC
                                                                    </li>
                                                                    <li id="liNONAC">
                                                                        <input type="checkbox" name="cbNONAC" id="cbNONAC" value="Non AC" title="Non AC"
                                                                            onchange="LoadFilteredRoutes(event,'');" />Non AC </li>
                                                                    <li id="liSleeper">
                                                                        <input type="checkbox" name="cbSleeper" id="cbSleeper" value="Sleeper" title="Sleeper"
                                                                            onchange="LoadFilteredRoutes(event,'');" />Sleeper </li>
                                                                    <li id="liSemiSleeper">
                                                                        <input type="checkbox" name="cbSemiSleeper" id="cbSemiSleeper" value="SemiSleeper"
                                                                            title="SemiSleeper" onchange="LoadFilteredRoutes(event,'');" />SemiSleeper
                                                                    </li>
                                                                    <li>
                                                                        <label onclick="$('#cbAC').attr('checked', false);    $('#cbNONAC').attr('checked', false);    $('#cbSleeper').attr('checked', false);
                                        $('#cbSemiSleeper').attr('checked', false);LoadFilteredRoutes(event,''); $('#ulBusFacilities').hide('meduim');" title='clear'
                                                                            style="float: left; cursor: pointer;">
                                                                            Clear</label>
                                                                        <img src='../../images/icon-close4.png' onclick="$('#ulBusFacilities').hide('meduim');"
                                                                            title='close' style="float: right; cursor: pointer;" alt="Close" />
                                                                    </li>
                                                                </ul>
                                                                <script type="text/javascript">
                                                                    function fnCloseBusFacilities() {
                                                                        LoadFilteredRoutes('', '');
                                                                        return false;
                                                                    }
                                                                </script>
                                                            </div>
                                                        </td>
                                                        <td width="50%" valign="top" align="left">
                                                            <table width="100%">
                                                                <tr width="100%">
                                                                    <td width="8%" valign="top">
                                                                        <b>Fare:</b>
                                                                    </td>
                                                                    <td width="60%" valign="top">
                                                                        <div id="slider-range" style="width: 180px; margin-left: 15px;">
                                                                        </div>
                                                                        &nbsp;<input type="text" readonly="readonly" id="amount" style="border: 0; font-weight: bold;
                                                                            width: 175px; margin-left: 15px;" onkeypress="javascript: return false;" onpaste="javascript: return false;"
                                                                            oncontextmenu="javascript: return false;" onclick="javascript: return false;" />
                                                                        <input id="hdnMinFare" type="hidden" value="1" />
                                                                        <input id="hdnMaxFare" type="hidden" value="2500" />
                                                                    </td>
                                                                    <td width="32%" valign="top">
                                                                        <input id="BTNreSET" onclick="ResetFilters(); return false;" type="submit" value="Reset Filters"
                                                                            class="buttonBook" style="cursor: pointer;" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td width="100%" align="center">
                                        <div id="Buses">
                                            <fieldset>
                                                <legend><span style="color: Red;">Buses</span></legend>
                                                <div class="travel_main_sub1">
                                                    <div class="travel_name1">
                                                        <a onclick="LoadFilteredRoutes(event,'Travels');" style="cursor: pointer; font-weight: bold;">
                                                            Operator</a>
                                                    </div>
                                                    <div class="travea_sleep1">
                                                        <a onclick="LoadFilteredRoutes(event,'BusType');" style="cursor: pointer; font-weight: bold;">
                                                            Type</a>
                                                    </div>
                                                    <div class="travea_time1">
                                                        <a onclick="LoadFilteredRoutes(event,'DepTimeInMins');" style="cursor: pointer; font-weight: bold;">
                                                            Dep</a>
                                                    </div>
                                                    <div class="travea_time1">
                                                        <a style="font-weight: bold; cursor: pointer;" onclick="LoadFilteredRoutes(event,'ArrTimeInMins');">
                                                            Arr</a>
                                                    </div>
                                                    <div class="travea_duration1">
                                                        <a onclick="LoadFilteredRoutes(event,'Duration');" style="cursor: pointer; font-weight: bold;">
                                                            Duration</a>
                                                    </div>
                                                    <%-- <div class="t_avail1" style="vertical-align: text-bottom;">
                                                        Rating
                                                    </div>--%>
                                                    <div class="t_avail1">
                                                        <a onclick="LoadFilteredRoutes(event,'AvailableSeats');" style="cursor: pointer;
                                                            font-weight: bold;">Seats</a>
                                                    </div>
                                                    <div class="travel_price1">
                                                        <a onclick="LoadFilteredRoutes(event,'Fare');" style="cursor: pointer; font-weight: bold;">
                                                            Fare</a>
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 100%">
                                                    <hr />
                                                    <br />
                                                    <div id="div_routes_loading" style="display: none; width: 100%;">
                                                    </div>
                                                    <div id="div_routes" style="display: none; width: 100%;">
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="footer_bg" align="center">
                <table height="79" width="990" border="0" cellspacing="0" cellpadding="0" bgcolor="#4f91cd">
                    <tr>
                        <td>
                            <table width="824" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <%--<ul>
                                            <li><a href="PrintTicket.aspx">Print Ticket</a></li>
                                            <li><a href="CancelTicket.aspx">Cancel Ticket</a></li>
                                            <li><a href="ContactUs.aspx" style="border-right: none;">Contact Us</a></li>
                                        </ul>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="cpy" height="30">
                                        © Copyright 2012 - 2013 | www.Lovejourney.in. All Rights Reserved.
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="166" align="center">
                            <img src="../../images/payments.jpg" width="144" height="62" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
