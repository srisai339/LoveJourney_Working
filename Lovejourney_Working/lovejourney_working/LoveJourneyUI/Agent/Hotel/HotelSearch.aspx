﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HotelSearch.aspx.cs" Inherits="Agent_Hotel_HotelSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LoveJourney - HotelSearch</title>
    <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../dropdowntabfiles/dropdowntabs.js"></script>
    <link rel="stylesheet" type="text/css" href="../../dropdowntabfiles/halfmoontabs.css" />
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
    <link href="../../css/mak_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../css/Agentstyle.css" />
    <link rel="stylesheet" type="text/css" href="../../css/chromestyle1.css" />
    <script type="text/javascript" src="../../JS/crawler.js"></script>
    <link rel="stylesheet" type="text/css" href="../../css/chromestyle.css" />
    <link href="../../images/favicon.png" rel="Shortcut Icon" type="text/css" />
    <script type="text/javascript" src="../../js/chrome.js"></script>
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
                minDate: dateToday,
                onSelect: function () {
                    $(".datepicker1").datepicker("show");
                }
            });
            $("[id$='check_Inhotel']").datepicker('setDate', 'today');
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
            $("[id$='check_Outhotel']").datepicker('setDate', '+1d');
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
            if (parseInt(count1) > 0 && parseInt(countadult1) > 2) {
                alert("No of passengers can't be more than (2 adults and 2 children) OR (3 adults and 1 children)OR (3 adults)in single room");
                return false;
            }
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
            var count2 = document.forms[0].str_ChildrenRoom2[document.forms[0].str_ChildrenRoom2.selectedIndex].value;
            var countadult2 = document.forms[0].str_AdultsRoom2[document.forms[0].str_AdultsRoom2.selectedIndex].value

            count = parseInt(count2) + parseInt(countadult2);
            if (parseInt(count2) > 0 && parseInt(countadult2) > 2) {
                alert("No of passengers can't be more than (2 adults and 2 children) OR (3 adults and 1 children)OR (3 adults)in single room");
                return false;
            }
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
            if (parseInt(count3) > 0 && parseInt(countadult3) > 2) {
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
            if (parseInt(count4) > 0 && parseInt(countadult4) > 2) {
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
                //alert($("#hdnValues").val());

                //myfunction();
                showDiv();

                return true;
            }
        }

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
</head>
<body onload="Load()">
    <form id="Form1" runat="server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
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
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" valign="top" height="90" width="1004px">
                <table cellpadding="0" cellspacing="0" border="0" width="1004px" runat="server" id="AgentView"
                    align="center">
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="1004">
                                <tr>
                                    <td width="250" align="left">
                                        <img height="79" src="../../images/logo.gif" width="249" />
                                    </td>
                                    <td align="right" width="754">
                                        <table width="200" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblUsername" runat="server" ForeColor="Black" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Balance :" ForeColor="Black" />
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblBalance" runat="server" Text="" ForeColor="Black" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <marquee scrollamount="3" onmouseover="stop()" onmouseout="start()"><asp:Label ID="lblno" runat="server" ForeColor="Black" Font-Bold="true" Text=" Contact Us : 080-32561727 / 080-25220265"></asp:Label></marquee>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <table width="200" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <img src="../../images/img/feedback.png" width="25" height="25" />
                                    </td>
                                    <td class="fli" align="left">
                                        <asp:LinkButton ID="lnkButtonFeedBack" runat="server" Text="FeedBack" OnClick="lnkButtonFeedBack_Click"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <img src="../../images/img/logout.png" width="25" height="25" />
                                    </td>
                                    <td class="fli" align="left">
                                        <asp:LinkButton ID="lbtnlogout" runat="server" Text="Logout" OnClick="lbtnlogout_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="1004" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="100" align="left">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu" align="center">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/bus2.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="../Bus/Default.aspx">Buses</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/bus1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="left">
                                                                <div id="moonmenu" class="halfmoon">
                                                                    <ul>
                                                                        <li><a href="../../frmFlightsAvailability.aspx" rel="dropmenu2_d">Flights</a></li>
                                                                    </ul>
                                                                </div>
                                                                <div id="dropmenu2_d" class="dropmenudiv_e">
                                                                    <a href="../../frmIntFlightsAvailability.aspx">Domestic Flights</a> <a href="../Flight/frmInternationalAvailablity.aspx">
                                                                        International Flights</a>
                                                                </div>
                                                                <script type="text/javascript">
                                                                    //SYNTAX: tabdropdown.init("menu_id", [integer OR "auto"])
                                                                    tabdropdown.init("moonmenu", 3)
                                                                </script>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/hotel_i.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="../../HotelSearch.aspx">Hotels</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/recharge1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="../Recharge/Recharge.aspx">Recharge</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="93" align="right">
                                        <table width="92" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="82" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/dmr1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="47" align="left">
                                                                Dmr
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="right">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/ticket1.png" width="35" height="25" />
                                                            </td>
                                                            <td valign="middle" width="54" align="center">
                                                                Movie Tickets
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="96" align="center">
                                        <table width="93" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="84" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/car_s.png" width="35" height="25" />
                                                            </td>
                                                            <td width="48" align="center">
                                                                Cars
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="98" align="left">
                                        <table width="97" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="87" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/reports.png" width="35" height="25" />
                                                            </td>
                                                            <td width="52" align="center">
                                                                <a href="../Bus/AllAgentReports.aspx">Reports</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/setting1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <div id="moonmenu1" class="halfmoon">
                                                                    <ul>
                                                                        <li><a href="#" rel="dropmenu1_e">Settings </a></li>
                                                                    </ul>
                                                                    <div id="dropmenu1_e" class="dropmenudiv_e">
                                                                        <a href="../Bus/Deposits.aspx">Deposits </a><a href="../Bus/Profile.aspx">Profile
                                                                        </a><a href="../Bus/ChangePassword.aspx">Change Password </a><a href="../Bus/LoginDetails.aspx">
                                                                            Login History </a>
                                                                    </div>
                                                                    <script type="text/javascript">
                                                                        //SYNTAX: tabdropdown.init("menu_id", [integer OR "auto"])
                                                                        tabdropdown.init("moonmenu1", 3)
                                                                    </script>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="../../images/img/setting.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="../Recharge/Utilities.aspx">Utilities</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="../../images/img/l3.png" width="5" height="38" />
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
                                                <li><a href="HotelSearch.aspx">Book</a></li>
                                                <li><a href="PrintTicket.aspx">Print</a></li>
                                                <li><a href="CancelTicket.aspx">Cancel</a></li>
                                                <li><a href="Bookings.aspx">Bookings</a></li>
                                            </ul>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="964" height="10" align="center" valign="top">
                            <table width="964">
                                <tr>
                                    <td width="964" height="10" align="center">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td width="100%" height="30px" valign="middle" align="center" class="tr" id="tdmsg"
                                        runat="server" visible="false">
                                        <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <br />
                            <table width="964" border="0" id="tblmain" runat="server">
                                <tr>
                                    <td width="437" height="376" align="center" valign="top" id="hotel" runat="server">
                                        <table width="400" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="right" valign="bottom" width="24" height="23">
                                                    <img src="../../images/formtop_left.png" />
                                                </td>
                                                <td class="form_top" width="347">
                                                    &nbsp;
                                                </td>
                                                <td align="left" valign="bottom" width="29" height="23">
                                                    <img src="../../images/formright_top.png" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="form_left">
                                                    &nbsp;
                                                </td>
                                                <td width="347" align="left" valign="top">
                                                    <table width="347" align="center" border="0" cellspacing="0" cellpadding="0" bgcolor="#ffffff">
                                                        <tr>
                                                            <td valign="top" height="20" align="left">
                                                                <table width="347" height="45" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="50">
                                                                            <img src="../../Image/hotels_button.png" width="50" height="37" />
                                                                        </td>
                                                                        <td align="center" valign="middle" class="online_booking">
                                                                            Hotel Tickets Booking
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="12" colspan="2" class="border_top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <table width="360" align="right" cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td height="28" align="left" class="lj_hd12">
                                                                            City
                                                                        </td>
                                                                        <td width="5%" height="28" align="center" class="ft01">
                                                                            :
                                                                        </td>
                                                                        <td height="28" align="left">
                                                                            <select name="strcity" id="ddlCity" style="width: 150px;" onchange="showDate();"
                                                                                class="lj_inp">
                                                                                <option value="">--Select City-- </option>
                                                                                <option value="AGRA">AGRA </option>
                                                                                <option value="BANGALORE">BANGALORE </option>
                                                                                <option value="CHENNAI">CHENNAI </option>
                                                                                <option value="GOA">GOA </option>
                                                                                <option value="HYDERABAD" selected="selected">HYDERABAD </option>
                                                                                <option value="JAIPUR">JAIPUR </option>
                                                                                <option value="KOLKATA">KOLKATA </option>
                                                                                <option value="MUMBAI">MUMBAI / BOMBAY </option>
                                                                                <option value="NEW DELHI">NEW DELHI </option>
                                                                                <option value="line">-------------- </option>
                                                                                <option value="AGARTALA">AGARTALA </option>
                                                                                <%--   <option value="AGRA">AGRA </option>--%>
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
                                                                                <%--   <option value="BANGALORE">BANGALORE </option>--%>
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
                                                                                <%--  <option value="CHENNAI">CHENNAI </option>--%>
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
                                                                                <%--   <option value="GOA">GOA </option>--%>
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
                                                                                <%--  <option value="HYDERABAD">HYDERABAD </option>--%>
                                                                                <option value="IDUKKI">IDUKKI </option>
                                                                                <option value="IGATPURI">IGATPURI </option>
                                                                                <option value="IMPHAL">IMPHAL </option>
                                                                                <option value="INDORE">INDORE </option>
                                                                                <option value="JABALPUR">JABALPUR </option>
                                                                                <option value="JAGDALPUR">JAGDALPUR </option>
                                                                                <%--   <option value="JAIPUR">JAIPUR </option>--%>
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
                                                                                <%--   <option value="KANHA">KANHA </option>--%>
                                                                                <option value="KANNUR">KANNUR </option>
                                                                                <%-- <option value="KANPUR">KANPUR </option>--%>
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
                                                                                <%-- <option value="KOLKATA">KOLKATA </option>--%>
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
                                                                                <%--  <option value="MUMBAI">MUMBAI / BOMBAY </option>--%>
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
                                                                                <%-- <option value="NEW DELHI">NEW DELHI </option>--%>
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
                                                                        <td height="28" align="left" class="lj_hd12">
                                                                            Check In
                                                                        </td>
                                                                        <td height="28" align="center" class="ft01">
                                                                            :
                                                                        </td>
                                                                        <td height="28" align="left">
                                                                            <input size="15" type="text" name="check_Inhotel" onclick="showDate();" class="datepicker"
                                                                                id="check_Inhotel" onchange="$('#check_Outhotel').focus();" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="28" align="left" class="lj_hd12">
                                                                            Check Out
                                                                        </td>
                                                                        <td height="28" align="center" class="ft01">
                                                                            :
                                                                        </td>
                                                                        <td height="28" align="left">
                                                                            <input type="text" size="15" name="check_Outhotel" onclick="showDate1();" class="datepicker1"
                                                                                id="check_Outhotel" onfocus="showDate1();" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none;">
                                                                        <td height="28" align="left" class="lj_hd12">
                                                                            Hotel Rating
                                                                        </td>
                                                                        <td height="28" align="center" class="ft01">
                                                                            :
                                                                        </td>
                                                                        <td height="28" align="left">
                                                                            <select style="width: 120px;" size="1" name="hotelPreference" class="lj_inp">
                                                                                <option value="0">All </option>
                                                                                <option value="5">5 Star and above </option>
                                                                                <option value="4">4 Star and above </option>
                                                                                <option value="3">3 Star and above </option>
                                                                                <option value="2">2 Star and above </option>
                                                                            </select>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="28" align="left" class="lj_hd12">
                                                                            Rooms
                                                                        </td>
                                                                        <td height="28" align="center" class="ft01">
                                                                            :
                                                                        </td>
                                                                        <td height="28" align="left">
                                                                            <select size="1" name="no_ofrooms" style="width: 150px;" onchange="javascript:changeRows();"
                                                                                class="lj_inp" onkeyup="return tabE3(this,event)">
                                                                                <option value="1" selected="selected">1 </option>
                                                                                <option value="2">2 </option>
                                                                                <option value="3">3 </option>
                                                                                <option value="4">4 </option>
                                                                            </select>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <table align="center" cellpadding="0" cellspacing="4" border="0" style="border-collapse: collapse;
                                                                    width: 350px;">
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
                                                                            <select size="1" name="str_AdultsRoom1" class="ddladults" onkeyup="return tabE4(this,event)">
                                                                                <option value="1">1 </option>
                                                                                <option value="2">2 </option>
                                                                                <option value="3">3 </option>
                                                                                <option value="4">4 </option>
                                                                            </select>
                                                                        </td>
                                                                        <td align="center">
                                                                            <select size="1" name="str_ChildrenRoom1" onchange="javascript:showRoomsChildren1();"
                                                                                class="ddladults" onkeyup="return tabE5(this,event)">
                                                                                <option value="0" checked>0 </option>
                                                                                <option value="1">1 </option>
                                                                                <option value="2">2 </option>
                                                                            </select>
                                                                        </td>
                                                                        <td>
                                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse">
                                                                                <tr>
                                                                                    <td align="left" width="50%" id="child11">
                                                                                        <select size="1" name="str_AgeChild1Room1" class="ddladults" onkeyup="return tabE6(this,event)">
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
                                                                                    <td align="left" width="50%" id="child12">
                                                                                        <select size="1" name="str_AgeChild2Room1" class="ddladults" onkeyup="return tabE7(this,event)">
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
                                                                    <tr id="row2" style="display: none;">
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
                                                                            <select size="1" name="str_ChildrenRoom2" onchange="javascript:showRoomsChildren2();"
                                                                                class="ddladults">
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
                                                                                    <td align="left" width="33%" id="child22">
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
                                                                    <tr id="row3" style="display: none;">
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
                                                                            <select size="1" name="str_ChildrenRoom3" onchange="javascript:showRoomsChildren3();"
                                                                                class="ddladults">
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
                                                                                    <td align="left" width="33%" id="child32">
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
                                                                    <tr id="row4" style="display: none;">
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
                                                                            <select size="1" name="str_ChildrenRoom4" onchange="javascript:showRoomsChildren4();"
                                                                                class="ddladults">
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
                                                                                    <td align="left" width="33%" id="child42">
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
                                                                <br>
                                                                <input type="radio" class="ft01" name="c_urrency" value="INR" checked />
                                                                &nbsp;<b>Yes</b>&nbsp;
                                                                <input type="radio" class="ft01" name="c_urrency" value="USD" />
                                                                &nbsp;<b>No</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" height="35" align="center" class="ft01">
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search Hotels" OnClientClick="return startsearch();"
                                                                    CssClass="buttonBook" ValidationGroup="Search" OnClick="btnSearch_Click" />
                                                                <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
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
                                                                                                <img src="../../images/loading.gif" width="60" height="60" />
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
                                                                                                            <input id="Text3" type="text" style="border: 0; background-color: White; font-size: 20;
                                                                                                                font-weight: bold; color: Black;" disabled="disabled" class="hfont" />&nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="100%" align="center">
                                                                                                            <table width="100%">
                                                                                                                <tr>
                                                                                                                    <td width="50%" align="center">
                                                                                                                        CheckIn&nbsp;&nbsp;
                                                                                                                        <input id="Text1" type="text" style="border: 0; background-color: White; font-size: 20;
                                                                                                                            font-weight: bold; color: Black;" disabled="disabled" class="hfont" />
                                                                                                                    </td>
                                                                                                                    <td width="50%" align="center">
                                                                                                                        CheckOut&nbsp;&nbsp;
                                                                                                                        <input id="Text2" type="text" style="border: 0; background-color: White; font-size: 20;
                                                                                                                            font-weight: bold; color: Black" disabled="disabled" class="hfont" />
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
                                                <td class="form_right">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top" width="24" height="32">
                                                    <img src="../../images/formbottom_left.png" />
                                                </td>
                                                <td class="form_bottom">
                                                    &nbsp;
                                                </td>
                                                <td align="left" valign="top" width="29" height="32">
                                                    <img src="../../images/formright_bottom.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="527" height="376" align="right" valign="top" id="hotel1" runat="server">
                                        <table width="340" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="link_rt" valign="top">
                                                    <table width="320" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td colspan="3" height="10">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <a href="../Flight/frmDomesticAvailability.aspx" target="_blank">
                                                                    <img src="../../images/img/flight.png" width="86" height="76" /></a>
                                                            </td>
                                                            <td align="center">
                                                                <a href="HotelSearch.aspx" target="_blank">
                                                                    <img src="../../images/img/hotel.png" width="86" height="76" /></a>
                                                            </td>
                                                            <td align="center">
                                                                <a href="../Bus/Default.aspx" target="_blank">
                                                                    <img src="../../images/img/bus.png" width="86" height="76" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="flights">
                                                                <a href="../Flight/frmDomesticAvailability.aspx" target="_blank">Flights</a>
                                                            </td>
                                                            <td align="center" class="flights">
                                                                <a href="HotelSearch.aspx" target="_blank">Hotels</a>
                                                            </td>
                                                            <td align="center" class="flights">
                                                                <a href="../Bus/Default.aspx" target="_blank">Bus
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" height="10">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <img src="../../images/img/TRAIN.png" width="86" height="76" />
                                                            </td>
                                                            <td align="center">
                                                                <a href="../Recharge/Recharge.aspx" target="_blank">
                                                                    <img src="../../images/img/RECHARGE.png" width="86" height="76" /></a>
                                                            </td>
                                                            <td align="center">
                                                                <img src="../../images/img/TICKET.png" width="86" height="76" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="flights">
                                                              Train
                                                            </td>
                                                            <td align="center" class="flights">
                                                                <a href="../Recharge/Recharge.aspx" target="_blank">Recharge</a>
                                                            </td>
                                                            <td align="center" class="flights">
                                                                Tickets
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" height="10">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <img src="../../images/img/CAR.png" width="86" height="76" />
                                                            </td>
                                                            <td align="center">
                                                                <img src="../../images/img/UTILITIES.png" width="86" height="76" />
                                                            </td>
                                                            <td align="center">
                                                                <img src="../../images/img/DMR.png" width="86" height="76" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="flights">
                                                                Car
                                                            </td>
                                                            <td align="center" class="flights">
                                                                Utilities
                                                            </td>
                                                            <td align="center" class="flights">
                                                                Dmr
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
                    <tr>
                        <td valign="top">
                            <!--scroll-->
                            <div class="thumbs" style="padding-left: 10px;">
                                <div class="scrolling" style="padding: 0px; margin: 0px;">
                                    <%--<div class="marquee" id="mycrawler2">--%>
                                    <table width="990" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center">
                                                <a href="../Flight/frmDomesticAvailability.aspx" target="_blank">
                                                    <img src="../../images/img/fligh1t.png" width="86" height="76" /></a>
                                            </td>
                                            <td align="center">
                                                <a href="HotelSearch.aspx" target="_blank">
                                                    <img src="../../images/img/hotel_o.png" width="86" height="76" /></a>
                                            </td>
                                            <td align="center">
                                                <a href="../Bus/Default.aspx" target="_blank">
                                                    <img src="../../images/img/bus_o.png" width="86" height="76" /></a>
                                            </td>
                                            <td align="center">
                                                <img src="../../images/img/train1.png" width="86" height="76" />
                                            </td>
                                            <td align="center">
                                                <a href="../Recharge/Recharge.aspx" target="_blank">
                                                    <img src="../../images/img/recharge_o.png" width="86" height="76" /></a>
                                            </td>
                                            <td align="center">
                                                <img src="../../images/img/ticket_o.png" width="86" height="76" />
                                            </td>
                                            <td align="center">
                                                <img src="../../images/img/car_o.png" width="86" height="76" />
                                            </td>
                                            <td align="center">
                                                <img src="../../images/img/utilities_o.png" width="86" height="76" />
                                            </td>
                                            <td align="center">
                                                <img src="../../images/img/dmr_o.png" width="86" height="76" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="link_flights">
                                                <a href="../Flight/frmDomesticAvailability.aspx" target="_blank">Flights</a>
                                            </td>
                                            <td align="center" class="link_flights">
                                                <a href="HotelSearch.aspx" target="_blank">Hotels</a>
                                            </td>
                                            <td align="center" class="link_flights">
                                                <a href="../Bus/Default.aspx" target="_blank">Bus</a>
                                            </td>
                                            <td align="center" class="link_flights">
                                                Train
                                            </td>
                                            <td align="center" class="link_flights">
                                                <a href="../Recharge/Recharge.aspx" target="_blank">Recharge</a>
                                            </td>
                                            <td align="center" class="link_flights">
                                                Tickets
                                            </td>
                                            <td align="center" class="link_flights">
                                                Car
                                            </td>
                                            <td align="center" class="link_flights">
                                                Utilities
                                            </td>
                                            <td align="center" class="link_flights">
                                                Dmr
                                            </td>
                                        </tr>
                                    </table>
                                    <script type="text/javascript">
                                        marqueeInit({
                                            uniqueid: 'mycrawler2',
                                            style: {
                                                'padding': '2px',
                                                'width': '1000px',
                                                'height': '132px'

                                            },
                                            inc: 5, //speed - pixel increment for each iteration of this marquee's movement
                                            mouse: 'cursor driven', //mouseover behavior ('pause' 'cursor driven' or false)
                                            moveatleast: 2,
                                            neutral: 150,
                                            savedirection: true,
                                            random: true
                                        });
                                    </script>
                                </div>
                            </div>
                            <!--scroll-->
                        </td>
                    </tr>
                    <tr>
                        <td height="100" align="center" valign="top">
                            <!-------fotter-------->
                            <table width="1004" height="100" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="59" colspan="2" align="center" valign="top" class="footer">
                                        © Copyright 2012 - 2013 | <a href="#">www.lovejourney.in.</a> All Rights Reserved.
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <ajax:ModalPopupExtender ID="mp3" runat="server" PopupControlID="pnl" TargetControlID="lnkButtonFeedBack"
                                X="350" Y="250" BackgroundCssClass="loadingBackground" OkControlID="btnMsg1">
                            </ajax:ModalPopupExtender>
                            <asp:Panel ID="pnl" runat="server" Style="display: none; color: Black; border: 5px solid #3e6cc4;
                                border-radius: 5px; -moz-border-radius: 5px;" align="center">
                                <table width="600" bgcolor="#ffffff" height="100">
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Button ID="btnMsg1" runat="server" Text="X" CssClass="buttonclose" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table width="300" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td width="50" colspan="2">
                                                        <img src="../../images/feed.png" width="37" height="37" />
                                                    </td>
                                                    <td align="center" valign="middle" class="online_booking" colspan="4">
                                                        Feed Back
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="12" colspan="4" class="border_top">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="lj_hd12" height="28" width="100">
                                                        Name
                                                    </td>
                                                    <td align="center" class="ft01" height="28" width="5%">
                                                        :
                                                    </td>
                                                    <td align="left" height="28">
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="lj_inp" MaxLength="50"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtName"
                                                            Display="None" ErrorMessage="Please Enter Name" ValidationGroup="submit" />
                                                        <ajax:ValidatorCalloutExtender ID="vceName" runat="server" TargetControlID="rfvname">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <ajax:FilteredTextBoxExtender ID="ftbename" runat="server" TargetControlID="txtName"
                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ">
                                                        </ajax:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="lj_hd12" height="28">
                                                        Email
                                                    </td>
                                                    <td align="center" class="ft01" height="28">
                                                        :
                                                    </td>
                                                    <td align="left" height="28">
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="lj_inp" MaxLength="100"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                                            Display="None" ErrorMessage="Please Enter Email" ValidationGroup="submit" />
                                                        <ajax:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="RequiredFieldValidator1">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                            Display="None" ErrorMessage="Invalid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="submit" />
                                                        <ajax:ValidatorCalloutExtender ID="vceEmail1" runat="server" TargetControlID="RegularExpressionValidator1">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="lj_hd12" height="28">
                                                        Phone
                                                    </td>
                                                    <td align="center" class="ft01" height="28">
                                                        :
                                                    </td>
                                                    <td align="left" height="28">
                                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="lj_inp" MaxLength="10"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhone"
                                                            Display="None" ErrorMessage="Please Enter Phone No" ValidationGroup="submit" />
                                                        <ajax:ValidatorCalloutExtender ID="vcePhone" runat="server" TargetControlID="RequiredFieldValidator2">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhone"
                                                            ValidChars="0123456789">
                                                        </ajax:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="lj_hd12" height="28">
                                                        Comments
                                                    </td>
                                                    <td align="center" class="ft01" height="28">
                                                        :
                                                    </td>
                                                    <td align="left" height="28">
                                                        <asp:TextBox ID="txtComments" runat="server" CssClass="lj_inp" onkeypress="return validateLimit(this, 'Div2', 1000)"
                                                            TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="40" valign="middle">
                                                        <asp:Button ID="btnsubmit" runat="server" CssClass="buttonBook " Text="Submit" OnClick="btnsubmit_Click"
                                                            ValidationGroup="submit" />
                                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
