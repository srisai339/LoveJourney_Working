<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HotelSearch.aspx.cs" Inherits="HotelSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LoveJourney - HotelSearch</title>
     <meta name="alexaVerifyID" content="EfFKC3QV_q2bfL-KW7ZhApSHOpg" />

<meta name="keywords" 
content="keyword1,keyword2, EfFKC3QV_q2bfL-KW7ZhApSHOpg" />
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
</head>
<body onload="Load()">
    <form id="Form1" runat="server">
   
    <link href="css/chromestyle1.css" rel="stylesheet" type="text/css" />
    <link href="css/mak_style.css" rel="stylesheet" type="text/css" />
    <link href="css/NewStyle.css" rel="stylesheet" type="text/css" />
    <link href="css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/chromestyle.css" />
    <link href="images/favicon.png" rel="Shortcut Icon" type="text/css" />
    <script type="text/javascript" src="js/chrome.js"></script>
    <script type="text/javascript" src="dropdowntabfiles/dropdowntabs.js"></script>
    <link rel="stylesheet" type="text/css" href="dropdowntabfiles/halfmoontabs.css" />
    <link rel="stylesheet" type="text/css" href="css/Agentstyle.css" />
       <link rel="stylesheet" type="text/css" href="css/lj_style.css" />
    <link rel="stylesheet" type="text/css" href="css/chromestyle_New.css" />
  
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
            $("[id$='check_Inhotel']").datepicker('setDate', 'today');
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
           // $("[id$='check_Outhotel']").datepicker('setDate', '+1d');
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
           // alert("hi");

            var count = 0;

            var count1 = document.forms[0].str_ChildrenRoom1[document.forms[0].str_ChildrenRoom1.selectedIndex].value;
            //alert(count1);
            var countadult1 = document.forms[0].str_AdultsRoom1[document.forms[0].str_AdultsRoom1.selectedIndex].value;
            count = parseInt(count1) + parseInt(countadult1);
            if (parseInt(count1) > 0 && parseInt(countadult1) > 2) {

                alert("No of passengers can't be more than (2 adults and 2 children) OR (3 adults and 1 children)OR (3 adults)in single room");
                return false;
            }
            // 
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
            //
            var count2 = document.forms[0].str_ChildrenRoom2[document.forms[0].str_ChildrenRoom2.selectedIndex].value;
            var countadult2 = document.forms[0].str_AdultsRoom2[document.forms[0].str_AdultsRoom2.selectedIndex].value

            count = parseInt(count2) + parseInt(countadult2);
            if (parseInt(count2) > 0 && parseInt(countadult2) > 2) {

                alert("No of passengers can't be more than (2 adults and 2 children) OR (3 adults and 1 children)OR (3 adults)in single room");
                return false;
            }
            // 
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
    <table width="100%" border="0" align="center" cellspacing="0" cellpadding="0">
        <tr>
    <td valign="top" width="1000" align="center">
    <!--header-->
    <table width="1000" border="0" cellspacing="0" cellpadding="0" id="GuestHeader1" runat="server">
  <tr>
    <td align="left" height="90" valign="middle" width="328">
    <a href="Default.aspx"><img src="Newimages/New_Logo.png" width="226" height="79"  /></a>
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
   
    <li><a href="PrintTicket.aspx">Print</a></li>
     <li><a href="CancelTicket.aspx">Cancel</a></li>
       <li><a href="Careers.aspx">Careers</a></li>
     <li><a href="Login.aspx" style="border-right:none; padding-right:none;">Login</a></li>
     
    </ul>
    
    </td>
  </tr>
  
  <tr>
    <td align="right" valign="top">
    
    <table width="370" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" width="31"><img src="Newimages/contact_icon.png" width="21" height="21"  /></td>
    <td align="left" class="lj_cn">
    080-32561727 / 080-25220265
    </td>
    <td width="33" align="left"><img src="Newimages/mail_icon.png" width="23" height="22"  /></td>
    <td align="left" class="lj_cn"><a href="mailto:info@lovejourney.in">info@lovejourney.in</a> 
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
  </tr>
      
        <tr>
            <td align="center" valign="top" runat="server" id="AdminHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="1004" runat="server">
                    <tr>
                        <td align="left" height="85" valign="bottom">
                            <table cellpadding="0" cellspacing="0" border="0" width="1004">
                                <tr>
                                    <td width="300" align="left">
    <a href="Default.aspx"><img src="Newimages/New_Logo.png" width="226" height="79"  /></a>
                                    </td>
                                    <td align="right" width="704">
                                        <table width="200" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblUsername" runat="server" ForeColor="Black" /><br />
                                                     <asp:Label ID="lblBal" runat="server" ForeColor="Black" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <marquee scrollamount="3" onmouseover="stop()" onmouseout="start()">
                                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Font-Bold="true" 
                                                    Text=" Contact Us : 080-32561727 / 080-25220265"></asp:Label></marquee>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" height="35">
                            <table width="100" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <img src="images/img/logout.png" width="25" height="25" />
                                    </td>
                                    <td class="fli" align="left">
                                        <asp:LinkButton ID="lbtnlogout" runat="server" Text="Logout" OnClick="lbtnlogout_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="1004" border="0" cellspacing="0" cellpadding="0" id="GuestHeader2" runat="server">
                                <tr>
                                    <td width="100" align="left" id="lidashboard" runat="server">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu" align="center">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/home.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href='<%= ResolveUrl("~/")%>/AdminDB/AdminDb.aspx'>Home</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left" id="libuses" runat="server">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu" align="center">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/bus2.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="Default.aspx">Buses</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left" id="liflights" runat="server">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/bus1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="left">
                                                                <div id="moonmenu" class="halfmoon">
                                                                    <ul>
                                                                        <li><a href="#" rel="dropmenu2_d">Flights</a></li>
                                                                    </ul>
                                                                </div>
                                                                <div id="dropmenu2_d" class="dropmenudiv_e">
                                                                    <a href="frmFlightsAvailability.aspx">Domestic Flights</a> <a href="frmIntFlightsAvailability.aspx">
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
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left" id="lihotels" runat="server">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src='<%= ResolveUrl("~/")%>images/img/hotel_i.png' width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="HotelSearch.aspx">Hotels</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left" id="lirecharge" runat="server">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/recharge1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="Users/Recharge/Recharge.aspx">Recharge</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td id="Tddmr" width="93" align="right" runat="server" visible="false">
                                        <table width="92" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="82" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/dmr1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="47" align="left">
                                                                <a href="Users/Bus/DMRReport.aspx">DMR </a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="right" id="movietickets" runat="server" visible="false">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/ticket1.png" width="35" height="25" />
                                                            </td>
                                                            <td valign="middle" width="54" align="center">
                                                                <a href="#">Movie Tickets</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="96" align="center" id="Cars" runat="server" visible="true">
                                        <table width="93" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="84" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/car_s.png" width="35" height="25" />
                                                            </td>
                                                            <td width="48" align="center">
                                                                <div id="cabs" class="halfmoon">
                                                                <ul>
                                                                        <li><a href="Cab.aspx" rel="dropmenucabs">Cabs</a></li>
                                                                </ul>
                                                             </div>
                                                             <div id="dropmenucabs" class="dropmenudiv_e">
                                                                    <a href="frmcity.aspx" id="city" runat="server">City Master</a> 
                                                                        <a href="frmCarMaster.aspx" id="carm" runat="server">Car Master</a>
                                                                    <a href="frmCarDescriptionMaster.aspx" id="description" runat="server">CarDetails Master</a>
                                                                      <a href="Users/Bus/HotelPolicy.aspx" id="policy" runat="server">CarPolicy</a>
                                                                   
                                                                      
                                                                </div>
                                                                  <script type="text/javascript">
                                                                      //SYNTAX: tabdropdown.init("menu_id", [integer OR "auto"])
                                                                      tabdropdown.init("cabs", 3)
                                                                </script>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="98" align="left" id="liReports1" runat="server">
                                        <table width="97" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="87" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/reports.png" width="35" height="25" />
                                                            </td>
                                                            <td width="52" align="center">
                                                                <div id="moonmenu3" class="halfmoon">
                                                                    <ul>
                                                                        <li><a href="#" rel="dropmenu2_r">Reports</a></li>
                                                                    </ul>
                                                                </div>
                                                                <div id="dropmenu2_r" class="dropmenudiv_e">
                                                                    <a href="Users/AdminDashBoard/CommissionSlab.aspx">Commission Slab</a> <a href="Users/AdminDashBoard/AllReports.aspx">
                                                                        All Reports</a>
                                                                </div>
                                                                <script type="text/javascript">
                                                                    //SYNTAX: tabdropdown.init("menu_id", [integer OR "auto"])
                                                                    tabdropdown.init("moonmenu3", 3)
                                                                </script>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left" id="Td2" runat="server">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/setting1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="left">
                                                                <div id="settings1" class="halfmoon">
                                                                    <ul>
                                                                        <li><a href="#" rel="dropmenu2_s">Settings</a></li>
                                                                    </ul>
                                                                </div>
                                                                <div id="dropmenu2_s" class="dropmenudiv_e">
                                                                    <a href="~/Users/Bus/ViewUserInformation.aspx" id="liuserinfo" runat="server">View Users
                                                                    </a><a href="Users/Bus/ChangePassword.aspx" id="lichangepassword" runat="server">Change
                                                                        Password </a><a href="Users/Bus/CashCoupon.aspx" id="Cashcoupon" runat="server">Cash Coupon</a>
                                                                    <a href="Users/Bus/PromoCode.aspx" rel="dropmenu2_p" id="lipromocode" runat="server">Promo Code</a>
                                                                    <a href="Users/Bus/Users.aspx" id="licse" runat="server">CSE</a> <a href="Users/Bus/ViewFeedbacks.aspx"
                                                                        id="lifeedback" runat="server">Feedback</a>
                                                                           <a href="~/Deposits.aspx"  id="DistDeposits" runat="server" visible="false">Deposits</a>
                                                                           <a href="~/DMRReport.aspx"  id="DistDmr" runat="server" visible="false">DMR Requests</a>
                                                                            <a href="~/Profile.aspx"  id="DistProfile" runat="server" visible="false">Profile</a>
                                                                             <a href="~/LoginDetails.aspx"  id="DistLoginHistory" runat="server" visible="false">LoginHistory</a>
                                                                </div>
                                                                <script type="text/javascript">
                                                                    //SYNTAX: tabdropdown.init("menu_id", [integer OR "auto"])
                                                                    tabdropdown.init("settings1", 3)
                                                                </script>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left" id="utilities" runat="server" visible="false">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/setting.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="#">Utilities</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left" id="FeedBack" runat="server" visible="false">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/ticket1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="center">
                                                                <a href="#">FeedBack</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="100" align="left" id="liagents" runat="server">
                                        <table width="99" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" width="5">
                                                    <img src="images/img/l1.png" width="5" height="38" />
                                                </td>
                                                <td class="tmenu">
                                                    <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" align="center">
                                                                <img src="images/img/agent1.png" width="35" height="25" />
                                                            </td>
                                                            <td width="54" align="left">
                                                                <div id="moonmenu1" class="halfmoon">
                                                                    <ul>
                                                                        <li><a href="#" rel="dropmenu2_a">Agents</a></li>
                                                                    </ul>
                                                                </div>
                                                                <div id="dropmenu2_a" class="dropmenudiv_e">
                                                                    <a id="viewagents" runat="server" href="Users/Bus/Agents.aspx">View </a><a id="agentdeposits" runat="server" href="Users/Bus/frmAgentsDeposits.aspx">Deposits
                                                                    </a><a id="agentrequests" runat="server" href="Users/Bus/AgentRequests.aspx">Register Requests </a><a id="fundtransferreport" runat="server" href="Users/Bus/FundTransferReport.aspx">
                                                                        Deposit Requests </a><a id="stopservices" runat="server" href="Users/Bus/StopServices.aspx">Stop Services </a>
                                                                </div>
                                                                <script type="text/javascript">
                                                                    //SYNTAX: tabdropdown.init("menu_id", [integer OR "auto"])
                                                                    tabdropdown.init("moonmenu1", 3)
                                                                </script>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="38" width="5">
                                                    <img src="images/img/l3.png" width="5" height="38" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#4f91cd">
                            <table width="1000" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td bgcolor="#4f91cd" height="30">
                                        <div id="Div1" class="chromestyle">
                                            <ul>
                                                <li id="lisubmenuBooking" runat="server"><a href="HotelSearch.aspx">Book Ticket</a></li>
                                                <li id="lisubmenuprint" runat="server"><a href="Users/Hotel/PrintTicket.aspx">Print Ticket</a></li>
                                                <li id="lisubmenucancel" runat="server"><a href="Users/Hotel/CancelTicket.aspx">Cancel Ticket</a></li>
                                                <li id="lisubmenureports" runat="server"><a href="Users/Hotel/Bookings.aspx">Bookings</a></li>
                                                  <li id="liuserreports" runat="server"><a href="Users/Hotel/Individualreports.aspx">My Reports</a></li>
                                                <li id="lisubmenuAgentReports" runat="server"><a href="Users/Hotel/AgentBookings.aspx">Agent Bookings</a></li>
                                                <li id="li1" runat="server" visible="false"><a href="Users/Hotel/UserReports.aspx" rel="dropmenu3">
                                                    Bookings</a></li>
                                            </ul>
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
            <td align="center" valign="top" runat="server" id="AgentHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="1004" runat="server">
                    <tr>
                        <td>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="0" border="0" width="1004">
                                        <tr>
                                            <td width="250" align="left">
    <a href="Default.aspx"><img src="Newimages/New_Logo.png" width="226" height="79"  /></a>
                                            </td>
                                            <td align="right" width="754">
                                                <table width="200" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblAgentUserName" runat="server" ForeColor="Black" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label3" runat="server" Text="Balance :" ForeColor="Black" />
                                                            &nbsp;&nbsp;
                                                            <asp:Label ID="lblBalance" runat="server" Text="" ForeColor="Black" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <marquee scrollamount="3" onmouseover="stop()" onmouseout="start()"><asp:Label ID="Label4" runat="server" ForeColor="Black" Font-Bold="true" Text=" Contact Us : 080-32561727 / 080-25220265"></asp:Label></marquee>
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
                                                &nbsp;</td>
                                            <td class="fli" align="left">
                                                &nbsp;</td>
                                            <td>
                                                <img src="images/img/logout.png" width="25" height="25" />
                                            </td>
                                            <td class="fli" align="left">
                                                <asp:LinkButton ID="LinkButton5" runat="server" Text="Logout" OnClick="lbtnlogout_Click"></asp:LinkButton>
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
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu" align="center">
                                                            <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/bus2.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="54" align="center">
                                                                        <a href="Default.aspx">Buses</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="100" align="left">
                                                <table width="99" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/bus1.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="54" align="left">
                                                                        <div id="moonmenu" class="halfmoon">
                                                                            <ul>
                                                                                <li><a href="frmFlightsAvailability.aspx" rel="dropmenu2_d">Flights</a></li>
                                                                            </ul>
                                                                        </div>
                                                                        <div id="Div3" class="dropmenudiv_e">
                                                                            <a href="frmFlightsAvailability.aspx">Domestic Flights</a> <a href="frmIntFlightsAvailability.aspx">
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
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="100" align="left">
                                                <table width="99" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/hotel_i.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="54" align="center">
                                                                        <a href="HotelSearch.aspx">Hotels</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="100" align="left">
                                                <table width="99" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/recharge1.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="54" align="center">
                                                                        <a href="Agent/Recharge/Recharge.aspx">Recharge</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="93" align="right">
                                                <table width="92" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="82" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/dmr1.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="47" align="left">
                                                                      <a href="Agent/Bus/DMR.aspx"> DMR</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="100" align="right" id="movietiket" runat="server">
                                                <table width="99" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/ticket1.png" width="35" height="25" />
                                                                    </td>
                                                                    <td valign="middle" width="54" align="center">
                                                                        Movie Tickets
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="96" align="center">
                                                <table width="93" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="84" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/car_s.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="48" align="center">
                                                                       <a href="Cab.aspx"> Cars</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="98" align="left">
                                                <table width="97" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="87" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/reports.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="52" align="center">
                                                                        <a href="Agent/Bus/AllAgentReports.aspx">Reports</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="100" align="left">
                                                <table width="99" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/setting1.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="54" align="center">
                                                                        <div id="halfmoon" class="halfmoon">
                                                                            <ul>
                                                                                <li><a href="#" rel="dropmenu1_e">Settings </a></li>
                                                                            </ul>
                                                                            <div id="dropmenu1_e" class="dropmenudiv_e">
                                                                                <a href="Agent/Bus/Deposits.aspx">Deposits </a><a href="../Bus/Profile.aspx">Profile
                                                                                </a>
                                                                                 <a href="Agent/Bus/Markup.aspx">Mark Up</a>
                                                                                <a href="Agent/Bus/ChangePassword.aspx">Change Password </a><a href="../Bus/LoginDetails.aspx">
                                                                                    Login History </a>
                                                                            </div>
                                                                            <script type="text/javascript">
                                                                                //SYNTAX: tabdropdown.init("menu_id", [integer OR "auto"])
                                                                                tabdropdown.init("halfmoon", 3)
                                                                            </script>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="100" align="left">
                                                <table width="99" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l1.png" width="5" height="38" />
                                                        </td>
                                                        <td class="tmenu">
                                                            <table width="89" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" align="center">
                                                                        <img src="images/img/setting.png" width="35" height="25" />
                                                                    </td>
                                                                    <td width="54" align="center">
                                                                        <a href="Agent/Recharge/Utilities.aspx">Utilities</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="38" width="5">
                                                            <img src="images/img/l3.png" width="5" height="38" />
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
                                                <div id="Div5" class="chromestyle">
                                                    <ul>
                                                        <li><a href="HotelSearch.aspx">Book</a></li>
                                                        <li><a href="Agent/Hotel/PrintTicket.aspx">Print</a></li>
                                                        <li><a href="Agent/Hotel/CancelTicket.aspx">Cancel</a></li>
                                                        <li><a href="Agent/Hotel/Bookings.aspx">Bookings</a></li>
                                                    </ul>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="964" height="10" align="center" valign="top">
            </td>
        </tr>
        <tr>
            <td height="20">
            </td>
        </tr>
        <tr>
            <td width="1004" height="29px" valign="middle" align="center" id="tdmsg" runat="server"
                visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="1000" border="0" cellspacing="0" cellpadding="0"  class="lj_ctnt">
  <tr>
    <td width="540" valign="top" align="right">
    
    
    <table width="500" border="0" cellspacing="0" cellpadding="0" >
  <tr id="User_menu" runat="server" visible="false">
    <td align="left" valign="top">
    <!--form_menu-->
    
    <table width="440" border="0" cellspacing="0" cellpadding="0" id="tblicons" runat="server">
      <tr>
        <td><table width="108" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left"><img src="Newimages/l1.png" width="8" height="37" /></td>
            <td class="lj_tab_bg"><table width="92" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="92" align="left" valign="middle" height="32" class="lj_n_bus"><a href="Default.aspx">Buses</a></td>
              </tr>
            </table></td>
            <td width="8"><img src="Newimages/l2.png" width="8" height="37" /></td>
          </tr>
        </table></td>
        <td><table width="108" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left"><img src="Newimages/l1.png" width="8" height="37" /></td>
            <td class="lj_tab_bg"><table width="92" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="92" align="left" valign="middle" height="32" class="lj_n_flight">
                
                 <div id="ljchromemenu" class="lj_chromestyle">
                      <ul>
                        <li><a href="#" rel="dropmenulj" >Flights</a></li>
                       </ul>
                  </div>
                      <!--1st drop down menu -->
                     <div id="dropmenulj" class="ljdropmenudiv">
                       <a href="frmFlightsAvailability.aspx">Domestic Flights</a> 
                       <a href="frmIntFlightsAvailability.aspx">International Flights</a>
                       
                        </div>
                         
                    <script type="text/javascript">

                        cssdropdown.startchrome("ljchromemenu")

                </script>
             
                
                </td>
              </tr>
            </table></td>
            <td width="8"><img src="Newimages/l2.png" width="8" height="37" /></td>
          </tr>
        </table></td>
        <td align="left"><table width="108" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left"><img src="Newimages/l1.png" width="8" height="37" /></td>
            <td class="lj_tab_bg"><table width="92" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="92" align="left" valign="middle" height="32" class="lj_n_hotel"><a href="HotelSearch.aspx">Hotels</a></td>
              </tr>
            </table></td>
            <td width="8"><img src="Newimages/l2.png" width="8" height="37" /></td>
          </tr>
        </table></td>
        <td><table width="108" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left"><img src="Newimages/l1.png" width="8" height="37" /></td>
            <td class="lj_tab_bg"><table width="92" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="92" align="left" valign="middle" height="32" class="lj_n_car"><a href="Cab.aspx">Cars</a></td>
              </tr>
            </table></td>
            <td width="8"><img src="Newimages/l2.png" width="8" height="37" /></td>
          </tr>
        </table></td>
         <td><table width="108" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left"><img src="Newimages/l1.png" width="8" height="37" /></td>
            <td class="lj_tab_bg"><table width="92" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="92" align="left" valign="middle" height="32" class="lj_men_bg">
              <%--  <a href="#">fgfg</a>--%>
                <div id="chromemenu1" class="panchromestyle">
                                                                    <ul>
                                                                        <li><a href="#" rel="dropmenu2">
                                                                            
                                                                           Pancard</a></li>
                                                                    </ul>
                                                                    <!--1st drop down menu -->
                                                                    <div id="dropmenu2" class="pandropmenudiv">
                                                                        <a href="Downloads/CSF.pdf" target="_blank">Change Request Application</a> 
                                                                        <a href="Downloads/Form 49AA.pdf" target="_blank">New PAN Application ( for NRI F49AA)</a> 
                                                                        <a href="Downloads/Form 49A.pdf" target="_blank">New PAN Application(for Indian Resident F49A)</a> 
                                                                    </div>
                                                                    <script type="text/javascript">

                                                                        cssdropdown.startchrome("chromemenu1")

                                                                    </script>
                                                                </div>
                
                </td>
              </tr>
            </table></td>
            <td width="8"><img src="Newimages/l2.png" width="8" height="37" /></td>
          </tr>
        </table></td>
      </tr>
    </table>

    
    <!--form_menuEnd-->
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="left" valign="top">
    
    
    <table width="480" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" class="lj_srchGo">Hotel Search and Go!</td>
  </tr>
 <tr>
    <td height="10"></td>
  </tr>
  <tr>
    <td align="left">
    
    <table width="480" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="233" align="left">
    <div class="lj_outDiv">
    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
  <tr>
    <td width="70" align="center" class="lj_bdrit"><img src="Newimages/h_i.png" width="56"
     height="32"  /></td>
    <td>
    
                                            <select name="strcity" id="ddlCity" style="width: 150px;" class="lj_inputdropdown" tabindex="1" onchange="showDate();" >
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
</table>

    </div>
    
    </td>
    <td width="10"></td>
    <td width="233" align="left">
   <!-- <div class="lj_outDiv">
    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
  <tr>
    <td width="70" align="center" class="lj_bdrit"><img src="images/h_i.png" width="56"
     height="32"  /></td>
    <td>
    
    <select class="lj_inp">
    <option>Select To Place</option>
    <option>Hyderabad</option>
    </select>
    
    </td>
  </tr>
</table>

    </div>-->
    
    </td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td height="10"></td>
  </tr>
  <tr>
    <td align="left"><table width="480" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="233" align="left"><div class="lj_outDiv">
          <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
            <tr>
              <td width="70" align="center" class="lj_bdrit"><img src="Newimages/calender.png" width="56"
     height="32"  /></td>
              <td align="left" >
                  <%--<input id="check_Inhotel" class="datepicker" name="check_Inhotel" onchange="showDate1();"
                      onclick="showDate();" onfocus="this.blur();" onkeyup="return tabE(this,event)" 
                      size="15" tabindex="2" type="text" value="" />--%>
                  <input size="15" type="text"  id="check_Inhotel" name="check_Inhotel" onclick="showDate();" onchange="showDate1();" 
                                                                    class="datepicker1"  value="DD-MM-YYYY" />

                 
              </td>
            </tr>
          </table>
        </div></td>
        <td width="10"></td>
        <td width="233" align="left"><div class="lj_outDiv">
          <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
            <tr>
              <td width="70" align="center" class="lj_bdrit"><img src="Newimages/calender.png" width="56"
     height="32"  /></td>
              <td align="left">
              <%--<input type="text" size="15" name="check_Outhotel" onfocus="this.blur();" onclick="showDate1();" onkeyup="return tabE1(this,event)"
                                            class="datepicker1" id="check_Outhotel" value=""  tabindex="3"/>--%>
                <input type="text" size="15" name="check_Outhotel" onclick="showDate1();" class="datepicker1"
                                                                    id="check_Outhotel" value="DD-MM-YYYY" />
              </td>
            </tr>
          </table>
        </div></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="5"></td>
  </tr>
  <tr>
    <td align="left" valign="top">
    
    <table width="480" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="400" valign="top">
    
    <table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" class="lj_rooms" height="20">Rooms</td>
    
  </tr>
  <tr>
    <td><div class="lj_outroom">
    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
  <tr>
    <td width="70" align="center" class="lj_bdrit"><img src="Newimages/room.png" width="56"
     height="32"  /></td>
    <td>
    
                                            <%--<select size="1" name="no_ofrooms"  onchange="javascript:changeRows();" class="lj_inp1" tabindex="5" onkeyup="return tabE3(this,event)">
                                            <option value="1" selected="selected">1 </option>
                                            <option value="2">2 </option>
                                            <option value="3">3 </option>
                                            <option value="4"   >4 </option>
                                        </select>--%>
                                        <select size="1" name="no_ofrooms" style="width: 50px;" onchange="javascript:changeRows();"
                                                                    class="lj_inp1" tabindex="5" onkeyup="return tabE3(this,event)">
                                                                    <option value="1" selected="selected">1 </option>
                                                                    <option value="2">2 </option>
                                                                    <option value="3">3 </option>
                                                                    <option value="4">4 </option>
                                                                </select>
    
    </td>
  </tr>
</table>

    </div></td>
    
  </tr>
  

  


  
</table>

    
    </td>
    <td width="80" valign="bottom">
    
     <%--<asp:Button ID="btnSearch" runat="server" Text="Go" OnClientClick="return startsearch();" CssClass="lj_button"   ValidationGroup="Search"
                                            OnClick="btnSearch_Click" />--%>

                                                         <asp:Button ID="btnSearch" runat="server" Text="Go" OnClientClick="return startsearch();"
                                                        CssClass="lj_button" ValidationGroup="Search" OnClick="btnSearch_Click" />
                                                    
      <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                                style="display: none" class="modalContainer">
                                                <div class="registerhead">
                                                    <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
                                                        <tr>
                                                            <td width="9" height="8">
                                                                <img src="images/l1.png" width="9" height="8" />
                                                            </td>
                                                            <td height="8" width="582" bgcolor="#ffffff">
                                                            </td>
                                                            <td width="9" height="8">
                                                                <img src="images/l2.png" width="9" height="8" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" bgcolor="#ffffff" align="center" valign="top">
                                                                <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td align="center" height="25" valign="top">
                                                                            <img src="Newimages/New_Logo.png" width="226" height="79" alt="Logo" border="0" title="LoveJourney"  />
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
                                                                            <img src="images/loading14.gif" width="60" height="60" />
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
                                                                                        <input id="Text3" type="text" style="border: 0;background-color:White;font-size:20; font-weight:bold; color:Black;"  disabled="disabled"  class="hfont"/>&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="100%" align="center">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td width="50%" align="center">
                                                                                                    CheckIn&nbsp;&nbsp;
                                                                                                    <input id="Text1" type="text" style="border: 0;background-color:White; font-size:20; font-weight:bold;color:Black;"  disabled="disabled"  class="hfont" />
                                                                                                </td>
                                                                                                <td width="50%" align="center">
                                                                                                    CheckOut&nbsp;&nbsp;
                                                                                                    <input id="Text2" type="text" style="border: 0;background-color:White;font-size:20; font-weight:bold; color:Black"  disabled="disabled" class="hfont" />
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
                                                                <img src="images/l3.png" width="9" height="8" />
                                                            </td>
                                                            <td height="8" width="582" bgcolor="#ffffff">
                                                            </td>
                                                            <td width="9" height="8">
                                                                <img src="images/l4.png" width="9" height="8" />
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
  <tr>
    <td>
    
    <table cellpadding="0" cellspacing="0" border="0" width="480">
      <tr>
    <td height="8"></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    <tr>
    <td class="lj_rooms" align="left" height="25">Room</td>
    <td align="center" class="lj_rooms">Adults (Age 12+)</td>
    <td align="center" class="lj_rooms">Children (Age 12+)</td>
    <td align="center" class="lj_rooms">Child1 (Age 12+)</td>
    <td align="center" class="lj_rooms">Child2 (Age 12+)</td>
    </tr>

     <tr id="row1">
    <td align="center" class="lj_rooms">1</td>
    <td align="center" >
        <select class="ddladults" name="str_AdultsRoom1" 
            onkeyup="return tabE4(this,event)" size="1">
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
        </select>
     </td>
    <td align="center">
     <%--<select size="1" name="str_ChildrenRoom1" onchange="javascript:showRoomsChildren1();"
                                                                    class="lj_outroom_n" onkeyup="return tabE5(this,event)">
                                                                    <option value="0" checked>0 </option>
                                                                    <option value="1">1 </option>
                                                                    <option value="2">2 </option>
                                                                </select>--%>
                                                                <select class="ddladults" name="str_ChildrenRoom1" 
            onchange="javascript:showRoomsChildren1();" onkeyup="return tabE5(this,event)" 
            size="1">
                                                                    <option checked value="0">0</option>
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
        </select>
       </td>
    <td align="center" id="child11">
        <select class="ddladults" name="str_AgeChild1Room1" 
            onkeyup="return tabE6(this,event)" size="1">
            <option value="-1">--</option>
            <option value="0">&lt;1</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
            <option value="11">11</option>
            <option value="12">12</option>
        </select></td>
    <td id="child12" align="center">
        <select class="ddladults" name="str_AgeChild2Room1" 
            onkeyup="return tabE7(this,event)" size="1">
            <option value="-1">--</option>
            <option value="0">&lt;1</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
            <option value="11">11</option>
            <option value="12">12</option>
        </select></td>
    </tr> 

     <tr id="row2" style="display:none;">
    <td align="center" class="lj_rooms">2</td>
    <td align="center"> 
                                                                     <select size="1" name="str_AdultsRoom2" class="ddladults">
                                                                    <option value="1" selected="selected">1 </option>
                                                                    <option value="2">2 </option>
                                                                    <option value="3">3 </option>
                                                                    <option value="4">4 </option>
                                                                </select>
                                                                </td>
    <td align="center">
        <select class="ddladults" name="str_ChildrenRoom2" 
            onchange="javascript:showRoomsChildren2();" size="1">
            <option checked value="0">0</option>
            <option value="1">1</option>
            <option value="2">2</option>
        </select>
    </td>
    <td align="center" id="child21">
        <select class="ddladults" name="str_AgeChild1Room2" size="1">
            <option value="-1">--</option>
            <option value="0">&lt;1</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
            <option value="11">11</option>
            <option value="12">12</option>
        </select>
    </td>
    <td align="center" id="child22">
        <select class="ddladults" name="str_AgeChild2Room2" size="1">
            <option value="-1">--</option>
            <option value="0">&lt;1</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
            <option value="11">11</option>
            <option value="12">12</option>
        </select>
    </td>
    </tr>
     <tr id="row3" style="display:none;">
    <td align="center" class="lj_rooms">3</td>
    <td align="center"  >
                                                                <select class="ddladults" name="str_AdultsRoom3" size="1">
                                                                    <option selected="selected" value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                </select>
                                                            </td>
    <td align="center">
        <select class="ddladults" name="str_ChildrenRoom3" 
            onchange="javascript:showRoomsChildren3();" size="1">
            <option checked value="0">0</option>
            <option value="1">1</option>
            <option value="2">2</option>
        </select>
    </td>
    <td align="center" id="child31">
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
     <td align="center" id="child32">
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
     <tr id="row4" style="display:none;">
    <td align="center" class="lj_rooms">4</td>
    <td align="center">
                                                                    <select class="ddladults" name="str_AdultsRoom4" size="1">
                                                                        <option selected="selected" value="1">1</option>
                                                                        <option value="2">2</option>
                                                                        <option value="3">3</option>
                                                                        <option value="4">4</option>
                                                                    </select>
    </td>
    <td align="center">                                                                
        <select class="ddladults" name="str_ChildrenRoom4" 
            onchange="javascript:showRoomsChildren4();" size="1">
            <option checked value="0">0</option>
            <option value="1">1</option>
            <option value="2">2</option>
        </select></td>
    <td align="center" id="child41">                                                                           <select size="1" name="str_AgeChild1Room4" class="ddladults">
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
    <td align="center" id="child42">                                                                            <select size="1" name="str_AgeChild2Room4" class="ddladults">
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
                                                                            </select></td>
    </tr>

    </table>
    
    </td>
  </tr>
  <tr>
    <td><tr style="display: none;">
                                                <td colspan="3" align="center" class="ft01">
                                                    &nbsp;<b>Are you a resident of India ?</b>
                                                    <br>
                                                    <input type="radio" class="ft01" name="c_urrency" value="INR" checked />
                                                    &nbsp;<b>Yes</b>&nbsp;
                                                    <input type="radio" class="ft01" name="c_urrency" value="USD" />
                                                    &nbsp;<b>No</b>
                                                </td>
                                            </tr></td>
  </tr>
  <tr style="display: none;">
                                                            <td height="28" align="left" class="lj_hd12">
                                                                Hotel Rating
                                                            </td>
                                                            <td height="28" align="center" class="ft01">
                                                                :
                                                            </td>
                                                            <td height="28" align="left">
                                                                <select style="width: 120px;" size="1" name="hotelPreference" class="lj_inp" tabindex="4"
                                                                    onkeyup="return tabE2(this,event)">
                                                                    <option value="0">All </option>
                                                                    <option value="5">5 Star and above </option>
                                                                    <option value="4">4 Star and above </option>
                                                                    <option value="3">3 Star and above </option>
                                                                    <option value="2">2 Star and above </option>
                                                                </select>
                                                            </td>
                                                        </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>

    
    
    </td>
  </tr>
</table>

    
    
    </td>
    <td width="3"></td>
    <td width="457" class="lj_banner_bg" align="left"  valign="top">
    
     <iframe src="frame.html" scrolling="no" frameborder="0" width="457" height="372" ></iframe>
    
    
 
      
    </td>
  </tr>
</table>
            </td>
        </tr>
       
       
        <tr>
            <td height="100" align="center" valign="top">
                <!-------fotter-------->
              <table width="1004" border="0" cellspacing="0" cellpadding="0" id="Guestfooter" runat="server">
                <tr>
    <td valign="top">
    
    <table width="1000" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left" width="54" height="72">
                                                                <img src="Newimages/best_office.png" width="44" height="48" />
                                                            </td>
                                                            <td align="left">
                                                                <span class="lj_choice">Choice!</span>
                                                                <br />
                                                                Over 100,000<br />
                                                                Hotels & Activities
                                                            </td>
                                                            <td width="40">
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
                                                            <td align="left" width="54" height="72">
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
  </tr>
        <tr><td height="16"></td></tr>
  <tr>
    <td class="lj_foot" align="center">
    <ul>
    <li><a href="Default.aspx">Home</a></li>
    <li><a href="Print.aspx">Print Ticket</a></li>
    <li><a href="CancelTicket.aspx">Cancel Ticket</a></li>
    <li><a href="BecomeAnAgent.aspx">Agent Registration</a>
    <li><a href="Login.aspx">Login</a></li>
    <li><a href="ContactUs.aspx" style="border-right:none;">Contact Us</a>
    </li> 
    </ul>
    
    </td>
  </tr>
  <tr>
    <td align="center">© Copyright 2012 - 2013 | www.Lovejourney.in. All Rights Reserved. </td>
  </tr>

</table>
                <table width="1004" border="0" cellspacing="0" cellpadding="0" id="LoggedUserFooter"
                    runat="server">
                    <tr>
                        <td height="69" colspan="2" align="center" valign="top" class="footer">
                            © Copyright 2012 - 2013 | <a href="http://www.lovejourney.in/">www.Lovejourney.in</a>
                            All Rights Reserved.
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
