<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Hotels.aspx.cs" Inherits="Hotels" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/is_style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function showDiv2() {
            document.getElementById('mainDiv').style.display = "";
            document.getElementById('contentDiv').style.display = "";
            setTimeout('document.images["myAnimatedImage"].src = "images/roller_big.gif"', 200);
        } 
    </script>
    <script type="text/javascript">
        function showDiv() {
            Page_ClientValidate("modify");
            if (Page_ClientValidate("modify")) {
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "images/roller_big.gif"', 200);
            }
            else
                return false;
        }
        function go() {
            var DropdownList = document.getElementById('ddlCity');
            var SelectedIndex = DropdownList.selectedIndex;
            var SelectedValue = DropdownList.value;
            alert(SelectedValue);
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            //document.getElementById('Text3').value = SelectedText;
            alert("go");
        }
        function go1() {
            //document.getElementById('Text1').value = document.getElementById('check_Inhotel').value;
            alert("go1");
        }
        function go2() {
            //document.getElementById('Text2').value = document.getElementById('check_Outhotel').value;
            alert("go2");
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
                    minDate: dateToday
                });
                $("[id$='txtFromDate']").datepicker('setDate', 'today');
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
                minDate: dateToday
            });
            $("[id$='txtFromDate']").datepicker('setDate', 'today');
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
        });
    </script>
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
            if (parseInt(count2) > 1 && parseInt(countadult2) > 2) {
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

            var city = document.forms[0].ddlCity.value;
            if (city == "") {
                alert("Please select city");
                document.forms[0].ddlCity.focus();
                return false;
            }
            if (city == "line") {
                alert("Select valid city location");
                document.forms[0].ddlCity.focus();
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

            $("#<%= hdnValues.ClientID %>").val(

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
            alert($("#<%= hdnValues.ClientID %>").val());

            showDiv();

            return true;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" name="currentdate" value="08-09-109-13-17-00" />
    <input type="hidden" name="partnerid" value="222073" />
    <input type="hidden" name="depart1" />
    <input type="hidden" name="return1" />
    <input type="hidden" name="corporate_user_id" value="null" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnValues" runat="server" />
            <table width="100%" bgcolor="#ffffff">
                <tr>
                    <td width="100%" align="center">
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                        <asp:Panel ID="pnlModifySearch" runat="server">
                            <table width="980" border="0" cellspacing="0" cellpadding="0" class="is_tp">
                                <tr>
                                    <td width="5%" class="lj_hd" align="center">
                                        City:
                                    </td>
                                    <td width="15%" align="left" valign="top">
                                        <asp:DropDownList ID="ddlCity" runat="server" ValidationGroup="modify" CssClass="lj_inp">
                                            <asp:ListItem Value="line">--Select City-- </asp:ListItem>
                                            <asp:ListItem Value="AGRA">AGRA </asp:ListItem>
                                            <asp:ListItem Value="BANGALORE">BANGALORE </asp:ListItem>
                                            <asp:ListItem Value="CHENNAI">CHENNAI </asp:ListItem>
                                            <asp:ListItem Value="GOA">GOA </asp:ListItem>
                                            <asp:ListItem Value="HYDERABAD">HYDERABAD </asp:ListItem>
                                            <asp:ListItem Value="JAIPUR">JAIPUR </asp:ListItem>
                                            <asp:ListItem Value="KOLKATA">KOLKATA </asp:ListItem>
                                            <asp:ListItem Value="MUMBAI">MUMBAI / BOMBAY </asp:ListItem>
                                            <asp:ListItem Value="NEW DELHI">NEW DELHI </asp:ListItem>
                                            <asp:ListItem Value="line">-------------- </asp:ListItem>
                                            <asp:ListItem Value="AGARTALA">AGARTALA </asp:ListItem>
                                            <asp:ListItem Value="AGRA">AGRA </asp:ListItem>
                                            <asp:ListItem Value="AHMEDABAD">AHMEDABAD </asp:ListItem>
                                            <asp:ListItem Value="AIZAWL">AIZAWL </asp:ListItem>
                                            <asp:ListItem Value="AJMER">AJMER </asp:ListItem>
                                            <asp:ListItem Value="AKOLA">AKOLA </asp:ListItem>
                                            <asp:ListItem Value="ALIBAG">ALIBAG </asp:ListItem>
                                            <asp:ListItem Value="ALLAHABAD">ALLAHABAD </asp:ListItem>
                                            <asp:ListItem Value="ALLEPPEY">ALLEPPEY </asp:ListItem>
                                            <asp:ListItem Value="ALMORA">ALMORA </asp:ListItem>
                                            <asp:ListItem Value="ALSISAR">ALSISAR </asp:ListItem>
                                            <asp:ListItem Value="ALWAR">ALWAR </asp:ListItem>
                                            <asp:ListItem Value="AMBALA">AMBALA </asp:ListItem>
                                            <asp:ListItem Value="AMLA">AMLA </asp:ListItem>
                                            <asp:ListItem Value="AMRITSAR">AMRITSAR </asp:ListItem>
                                            <asp:ListItem Value="ANAND">ANAND </asp:ListItem>
                                            <asp:ListItem Value="ANKLESWAR">ANKLESWAR </asp:ListItem>
                                            <asp:ListItem Value="ARONDA">ARONDA </asp:ListItem>
                                            <asp:ListItem Value="ASHTAMUDI">ASHTAMUDI </asp:ListItem>
                                            <asp:ListItem Value="AULI">AULI </asp:ListItem>
                                            <asp:ListItem Value="AUNDH">AUNDH </asp:ListItem>
                                            <asp:ListItem Value="AURANGABAD">AURANGABAD </asp:ListItem>
                                            <asp:ListItem Value="BADAMI">BADAMI </asp:ListItem>
                                            <asp:ListItem Value="BADDI">BADDI </asp:ListItem>
                                            <asp:ListItem Value="BADRINATH">BADRINATH </asp:ListItem>
                                            <asp:ListItem Value="BALASINOR">BALASINOR </asp:ListItem>
                                            <asp:ListItem Value="BALRAMPUR">BALRAMPUR </asp:ListItem>
                                            <asp:ListItem Value="BAMBORA">BAMBORA </asp:ListItem>
                                            <asp:ListItem Value="BANDHAVGARH">BANDHAVGARH </asp:ListItem>
                                            <asp:ListItem Value="BANDIPUR">BANDIPUR </asp:ListItem>
                                            <asp:ListItem Value="BANGALORE">BANGALORE </asp:ListItem>
                                            <asp:ListItem Value="BARBIL">BARBIL </asp:ListItem>
                                            <asp:ListItem Value="BAREILY">BAREILY </asp:ListItem>
                                            <asp:ListItem Value="BARKOT">BARKOT </asp:ListItem>
                                            <asp:ListItem Value="BARODA">BARODA </asp:ListItem>
                                            <asp:ListItem Value="BATHINDA">BATHINDA </asp:ListItem>
                                            <asp:ListItem Value="BEHROR">BEHROR </asp:ListItem>
                                            <asp:ListItem Value="BELGAUM">BELGAUM </asp:ListItem>
                                            <asp:ListItem Value="BERHAMPUR">BERHAMPUR </asp:ListItem>
                                            <asp:ListItem Value="BETALGHAT">BETALGHAT </asp:ListItem>
                                            <asp:ListItem Value="BHANDARDARA">BHANDARDARA </asp:ListItem>
                                            <asp:ListItem Value="BHARATPUR">BHARATPUR </asp:ListItem>
                                            <asp:ListItem Value="BHARUCH">BHARUCH </asp:ListItem>
                                            <asp:ListItem Value="BHAVANGADH">BHAVANGADH </asp:ListItem>
                                            <asp:ListItem Value="BHAVNAGAR">BHAVNAGAR </asp:ListItem>
                                            <asp:ListItem Value="BHILAI">BHILAI </asp:ListItem>
                                            <asp:ListItem Value="BHILWARA">BHILWARA </asp:ListItem>
                                            <asp:ListItem Value="BHIMTAL">BHIMTAL </asp:ListItem>
                                            <asp:ListItem Value="BHOPAL">BHOPAL </asp:ListItem>
                                            <asp:ListItem Value="BHUBANESHWAR">BHUBANESHWAR </asp:ListItem>
                                            <asp:ListItem Value="BHUJ">BHUJ </asp:ListItem>
                                            <asp:ListItem Value="BIKANER">BIKANER </asp:ListItem>
                                            <asp:ListItem Value="BINSAR">BINSAR </asp:ListItem>
                                            <asp:ListItem Value="BODHGAYA">BODHGAYA </asp:ListItem>
                                            <asp:ListItem Value="BUNDI">BUNDI </asp:ListItem>
                                            <asp:ListItem Value="CALICUT">CALICUT </asp:ListItem>
                                            <asp:ListItem Value="CHAIL">CHAIL </asp:ListItem>
                                            <asp:ListItem Value="CHAMBA">CHAMBA </asp:ListItem>
                                            <asp:ListItem Value="CHAMUNDA DEVI">CHAMUNDA DEVI </asp:ListItem>
                                            <asp:ListItem Value="CHANDIGARH">CHANDIGARH </asp:ListItem>
                                            <asp:ListItem Value="CHENNAI">CHENNAI </asp:ListItem>
                                            <asp:ListItem Value="CHHOTA UDEPUR">CHHOTA UDEPUR </asp:ListItem>
                                            <asp:ListItem Value="CHICKMAGALUR">CHICKMAGALUR </asp:ListItem>
                                            <asp:ListItem Value="CHIDAMBARAM">CHIDAMBARAM </asp:ListItem>
                                            <asp:ListItem Value="CHIPLUN">CHIPLUN </asp:ListItem>
                                            <asp:ListItem Value="CHITRAKOOT">CHITRAKOOT </asp:ListItem>
                                            <asp:ListItem Value="CHITTORGARH">CHITTORGARH </asp:ListItem>
                                            <asp:ListItem Value="COIMBATORE">COIMBATORE </asp:ListItem>
                                            <asp:ListItem Value="COONOOR">COONOOR </asp:ListItem>
                                            <asp:ListItem Value="COORG">COORG </asp:ListItem>
                                            <asp:ListItem Value="CORBETT">CORBETT </asp:ListItem>
                                            <asp:ListItem Value="CUTTACK">CUTTACK </asp:ListItem>
                                            <asp:ListItem Value="DABHOSA">DABHOSA </asp:ListItem>
                                            <asp:ListItem Value="DALHOUSIE">DALHOUSIE </asp:ListItem>
                                            <asp:ListItem Value="DAMAN">DAMAN </asp:ListItem>
                                            <asp:ListItem Value="DANDELI">DANDELI </asp:ListItem>
                                            <asp:ListItem Value="DAPOLI">DAPOLI </asp:ListItem>
                                            <asp:ListItem Value="DARJEELING">DARJEELING </asp:ListItem>
                                            <asp:ListItem Value="DASADA">DASADA </asp:ListItem>
                                            <asp:ListItem Value="DAUSA">DAUSA </asp:ListItem>
                                            <asp:ListItem Value="DEHRADUN">DEHRADUN </asp:ListItem>
                                            <asp:ListItem Value="DEOGARH">DEOGARH </asp:ListItem>
                                            <asp:ListItem Value="DHARAMSHALA">DHARAMSHALA </asp:ListItem>
                                            <asp:ListItem Value="DISTT. SEONI">DISTT. SEONI </asp:ListItem>
                                            <asp:ListItem Value="DISTT. UMARIA">DISTT. UMARIA </asp:ListItem>
                                            <asp:ListItem Value="DHOLPUR">DHOLPUR </asp:ListItem>
                                            <asp:ListItem Value="DIBRUGARH">DIBRUGARH </asp:ListItem>
                                            <asp:ListItem Value="DIGHA">DIGHA </asp:ListItem>
                                            <asp:ListItem Value="DIU">DIU </asp:ListItem>
                                            <asp:ListItem Value="DIVE AGAR">DIVE AGAR </asp:ListItem>
                                            <asp:ListItem Value="DOOARS">DOOARS </asp:ListItem>
                                            <asp:ListItem Value="DUNGARPUR">DUNGARPUR </asp:ListItem>
                                            <asp:ListItem Value="DURGAPUR">DURGAPUR </asp:ListItem>
                                            <asp:ListItem Value="DURSHET">DURSHET </asp:ListItem>
                                            <asp:ListItem Value="DWARKA">DWARKA </asp:ListItem>
                                            <asp:ListItem Value="FARIDABAD">FARIDABAD </asp:ListItem>
                                            <asp:ListItem Value="FIROZABAD">FIROZABAD </asp:ListItem>
                                            <asp:ListItem Value="GANDHIDHAM">GANDHIDHAM </asp:ListItem>
                                            <asp:ListItem Value="GANDHINAGAR">GANDHINAGAR </asp:ListItem>
                                            <asp:ListItem Value="GANGOTRI">GANGOTRI </asp:ListItem>
                                            <asp:ListItem Value="GANGTOK">GANGTOK </asp:ListItem>
                                            <asp:ListItem Value="GANPATIPULE">GANPATIPULE </asp:ListItem>
                                            <asp:ListItem Value="GARHMUKTESHWAR">GARHMUKTESHWAR </asp:ListItem>
                                            <asp:ListItem Value="GARHWAL">GARHWAL </asp:ListItem>
                                            <asp:ListItem Value="GAYA">GAYA </asp:ListItem>
                                            <asp:ListItem Value="GHANERAO">GHANERAO </asp:ListItem>
                                            <asp:ListItem Value="GHANGARIA">GHANGARIA </asp:ListItem>
                                            <asp:ListItem Value="GHAZIABAD">GHAZIABAD </asp:ListItem>
                                            <asp:ListItem Value="GOA">GOA </asp:ListItem>
                                            <asp:ListItem Value="GOKARNA">GOKARNA </asp:ListItem>
                                            <asp:ListItem Value="GONDAL">GONDAL </asp:ListItem>
                                            <asp:ListItem Value="GOPALPUR">GOPALPUR </asp:ListItem>
                                            <asp:ListItem Value="GORAKHPUR">GORAKHPUR </asp:ListItem>
                                            <asp:ListItem Value="GULMARG">GULMARG </asp:ListItem>
                                            <asp:ListItem Value="GURGAON">GURGAON </asp:ListItem>
                                            <asp:ListItem Value="GURUVAYOOR">GURUVAYOOR </asp:ListItem>
                                            <asp:ListItem Value="GUWAHATI">GUWAHATI </asp:ListItem>
                                            <asp:ListItem Value="GWALIOR">GWALIOR </asp:ListItem>
                                            <asp:ListItem Value="HALDWANI">HALDWANI </asp:ListItem>
                                            <asp:ListItem Value="HAMPI">HAMPI </asp:ListItem>
                                            <asp:ListItem Value="HANSI">HANSI </asp:ListItem>
                                            <asp:ListItem Value="HARIDWAR">HARIDWAR </asp:ListItem>
                                            <asp:ListItem Value="HASSAN">HASSAN </asp:ListItem>
                                            <asp:ListItem Value="HISSAR">HISSAR </asp:ListItem>
                                            <asp:ListItem Value="HOSPET">HOSPET </asp:ListItem>
                                            <asp:ListItem Value="HOSUR">HOSUR </asp:ListItem>
                                            <asp:ListItem Value="HUBLI">HUBLI </asp:ListItem>
                                            <asp:ListItem Value="HYDERABAD">HYDERABAD </asp:ListItem>
                                            <asp:ListItem Value="IDUKKI">IDUKKI </asp:ListItem>
                                            <asp:ListItem Value="IGATPURI">IGATPURI </asp:ListItem>
                                            <asp:ListItem Value="IMPHAL">IMPHAL </asp:ListItem>
                                            <asp:ListItem Value="INDORE">INDORE </asp:ListItem>
                                            <asp:ListItem Value="JABALPUR">JABALPUR </asp:ListItem>
                                            <asp:ListItem Value="JAGDALPUR">JAGDALPUR </asp:ListItem>
                                            <asp:ListItem Value="JAIPUR">JAIPUR </asp:ListItem>
                                            <asp:ListItem Value="JAISALMER">JAISALMER </asp:ListItem>
                                            <asp:ListItem Value="JAISAMAND">JAISAMAND </asp:ListItem>
                                            <asp:ListItem Value="JALANDHAR">JALANDHAR </asp:ListItem>
                                            <asp:ListItem Value="JALGAON">JALGAON </asp:ListItem>
                                            <asp:ListItem Value="JAMBUGODHA">JAMBUGODHA </asp:ListItem>
                                            <asp:ListItem Value="JAMMU">JAMMU </asp:ListItem>
                                            <asp:ListItem Value="JAMNAGAR">JAMNAGAR </asp:ListItem>
                                            <asp:ListItem Value="JAMSHEDPUR">JAMSHEDPUR </asp:ListItem>
                                            <asp:ListItem Value="JHANSI">JHANSI </asp:ListItem>
                                            <asp:ListItem Value="JODHPUR">JODHPUR </asp:ListItem>
                                            <asp:ListItem Value="JOJAWAR">JOJAWAR </asp:ListItem>
                                            <asp:ListItem Value="JORHAT">JORHAT </asp:ListItem>
                                            <asp:ListItem Value="JOSHIMATH">JOSHIMATH </asp:ListItem>
                                            <asp:ListItem Value="JUNAGADH">JUNAGADH </asp:ListItem>
                                            <asp:ListItem Value="KALIMPONG">KALIMPONG </asp:ListItem>
                                            <asp:ListItem Value="KANAM">KANAM </asp:ListItem>
                                            <asp:ListItem Value="KANATAL">KANATAL </asp:ListItem>
                                            <asp:ListItem Value="KANCHIPURAM">KANCHIPURAM </asp:ListItem>
                                            <asp:ListItem Value="KANHA">KANHA </asp:ListItem>
                                            <asp:ListItem Value="KANPUR">KANPUR </asp:ListItem>
                                            <asp:ListItem Value="KANHA">KANHA </asp:ListItem>
                                            <asp:ListItem Value="KANNUR">KANNUR </asp:ListItem>
                                            <asp:ListItem Value="KANPUR">KANPUR </asp:ListItem>
                                            <asp:ListItem Value="KANYAKUMARI">KANYAKUMARI </asp:ListItem>
                                            <asp:ListItem Value="KARAULI">KARAULI </asp:ListItem>
                                            <asp:ListItem Value="KARGIL">KARGIL </asp:ListItem>
                                            <asp:ListItem Value="KARWAR">KARWAR </asp:ListItem>
                                            <asp:ListItem Value="KASAULI">KASAULI </asp:ListItem>
                                            <asp:ListItem Value="KASHID">KASHID </asp:ListItem>
                                            <asp:ListItem Value="KASHIPUR">KASHIPUR </asp:ListItem>
                                            <asp:ListItem Value="KATRA">KATRA </asp:ListItem>
                                            <asp:ListItem Value="KALIMPONG">KALIMPONG </asp:ListItem>
                                            <asp:ListItem Value="KAUSANI">KAUSANI </asp:ListItem>
                                            <asp:ListItem Value="KAZA">KAZA </asp:ListItem>
                                            <asp:ListItem Value="KAZIRANGA">KAZIRANGA </asp:ListItem>
                                            <asp:ListItem Value="KEDARNATH">KEDARNATH </asp:ListItem>
                                            <asp:ListItem Value="KHAJURAHO">KHAJURAHO </asp:ListItem>
                                            <asp:ListItem Value="KHANDALA">KHANDALA </asp:ListItem>
                                            <asp:ListItem Value="KHAJIAR">KHAJIAR </asp:ListItem>
                                            <asp:ListItem Value="KHARAPUR">KHARAPUR </asp:ListItem>
                                            <asp:ListItem Value="KHEJARLA">KHEJARLA </asp:ListItem>
                                            <asp:ListItem Value="KHIMSAR">KHIMSAR </asp:ListItem>
                                            <asp:ListItem Value="KOCHI">KOCHI </asp:ListItem>
                                            <asp:ListItem Value="KOCHIN">KOCHIN </asp:ListItem>
                                            <asp:ListItem Value="KODAIKANAL">KODAIKANAL </asp:ListItem>
                                            <asp:ListItem Value="KOLHAPUR">KOLHAPUR </asp:ListItem>
                                            <asp:ListItem Value="KOLKATA">KOLKATA </asp:ListItem>
                                            <asp:ListItem Value="KOLLAM">KOLLAM </asp:ListItem>
                                            <asp:ListItem Value="KONNI">KONNI </asp:ListItem>
                                            <asp:ListItem Value="KOSI">KOSI </asp:ListItem>
                                            <asp:ListItem Value="KOTA">KOTA </asp:ListItem>
                                            <asp:ListItem Value="KOVALAM">KOVALAM </asp:ListItem>
                                            <asp:ListItem Value="KOTAGIRI">KOTAGIRI </asp:ListItem>
                                            <asp:ListItem Value="KOTTAYAM">KOTTAYAM </asp:ListItem>
                                            <asp:ListItem Value="KOZHIKODE / CALICUT">KOZHIKODE / CALICUT </asp:ListItem>
                                            <asp:ListItem Value="KULLU">KULLU </asp:ListItem>
                                            <asp:ListItem Value="KUMARAKOM">KUMARAKOM </asp:ListItem>
                                            <asp:ListItem Value="KUMBAKONAM">KUMBAKONAM </asp:ListItem>
                                            <asp:ListItem Value="KUMBALGARH">KUMBALGARH </asp:ListItem>
                                            <asp:ListItem Value="KURSEONG">KURSEONG </asp:ListItem>
                                            <asp:ListItem Value="KURUMBADI">KURUMBADI </asp:ListItem>
                                            <asp:ListItem Value="KUTCH">KUTCH </asp:ListItem>
                                            <asp:ListItem Value="KUSHINAGAR">KUSHINAGAR </asp:ListItem>
                                            <asp:ListItem Value="LACHUNG">LACHUNG </asp:ListItem>
                                            <asp:ListItem Value="LAKSHADWEEP">LAKSHADWEEP </asp:ListItem>
                                            <asp:ListItem Value="LEH">LEH </asp:ListItem>
                                            <asp:ListItem Value="LONAVALA">LONAVALA </asp:ListItem>
                                            <asp:ListItem Value="LOTHAL">LOTHAL </asp:ListItem>
                                            <asp:ListItem Value="LUCKNOW">LUCKNOW </asp:ListItem>
                                            <asp:ListItem Value="LUDHIANA">LUDHIANA </asp:ListItem>
                                            <asp:ListItem Value="MADURAI">MADURAI </asp:ListItem>
                                            <asp:ListItem Value="MAHABALESHWAR">MAHABALESHWAR </asp:ListItem>
                                            <asp:ListItem Value="MAHABALIPURAM">MAHABALIPURAM </asp:ListItem>
                                            <asp:ListItem Value="MALSHEJ GHAT">MALSHEJ GHAT </asp:ListItem>
                                            <asp:ListItem Value="MALVAN">MALVAN </asp:ListItem>
                                            <asp:ListItem Value="MAMALLAPURAM">MAMALLAPURAM </asp:ListItem>
                                            <asp:ListItem Value="MANALI">MANALI </asp:ListItem>
                                            <asp:ListItem Value="MANDAVI">MANDAVI </asp:ListItem>
                                            <asp:ListItem Value="MANDAWA">MANDAWA </asp:ListItem>
                                            <asp:ListItem Value="MANDI">MANDI </asp:ListItem>
                                            <asp:ListItem Value="MANDORMONI">MANDORMONI </asp:ListItem>
                                            <asp:ListItem Value="MANDU">MANDU </asp:ListItem>
                                            <asp:ListItem Value="MANESAR">MANESAR </asp:ListItem>
                                            <asp:ListItem Value="MANGALORE">MANGALORE </asp:ListItem>
                                            <asp:ListItem Value="MANIPAL">MANIPAL </asp:ListItem>
                                            <asp:ListItem Value="MANVAR">MANVAR </asp:ListItem>
                                            <asp:ListItem Value="MARCHULA">MARCHULA </asp:ListItem>
                                            <asp:ListItem Value="MASHOBRA">MASHOBRA </asp:ListItem>
                                            <asp:ListItem Value="MATHERAN">MATHERAN </asp:ListItem>
                                            <asp:ListItem Value="MATHURA">MATHURA </asp:ListItem>
                                            <asp:ListItem Value="MCLEODGANJ">MCLEODGANJ </asp:ListItem>
                                            <asp:ListItem Value="MEERUT">MEERUT </asp:ListItem>
                                            <asp:ListItem Value="MOHALI">MOHALI </asp:ListItem>
                                            <asp:ListItem Value="MORADABAD">MORADABAD </asp:ListItem>
                                            <asp:ListItem Value="MOUNT ABU">MOUNT ABU </asp:ListItem>
                                            <asp:ListItem Value="MUKTESHWAR">MUKTESHWAR </asp:ListItem>
                                            <asp:ListItem Value="MUKUNDGARH">MUKUNDGARH </asp:ListItem>
                                            <asp:ListItem Value="MUMBAI">MUMBAI / BOMBAY </asp:ListItem>
                                            <asp:ListItem Value="MUNDRA">MUNDRA </asp:ListItem>
                                            <asp:ListItem Value="MUNNAR">MUNNAR </asp:ListItem>
                                            <asp:ListItem Value="MURUD">MURUD </asp:ListItem>
                                            <asp:ListItem Value="MURUD JANJIRA">MURUD JANJIRA </asp:ListItem>
                                            <asp:ListItem Value="MUSSOORIE">MUSSOORIE </asp:ListItem>
                                            <asp:ListItem Value="MYSORE">MYSORE </asp:ListItem>
                                            <asp:ListItem Value="NADUKANI">NADUKANI </asp:ListItem>
                                            <asp:ListItem Value="NAGAPATTINAM">NAGAPATTINAM </asp:ListItem>
                                            <asp:ListItem Value="NAGAUR">NAGAUR </asp:ListItem>
                                            <asp:ListItem Value="NAGARHOLE">NAGARHOLE </asp:ListItem>
                                            <asp:ListItem Value="NAGAUR FORT">NAGAUR FORT </asp:ListItem>
                                            <asp:ListItem Value="NAGPUR">NAGPUR </asp:ListItem>
                                            <asp:ListItem Value="NAINITAL">NAINITAL </asp:ListItem>
                                            <asp:ListItem Value="NALAGARH">NALAGARH </asp:ListItem>
                                            <asp:ListItem Value="NALDEHRA">NALDEHRA </asp:ListItem>
                                            <asp:ListItem Value="NANDED">NANDED </asp:ListItem>
                                            <asp:ListItem Value="NAPNE">NAPNE </asp:ListItem>
                                            <asp:ListItem Value="NARLAI">NARLAI </asp:ListItem>
                                            <asp:ListItem Value="NASIK">NASIK </asp:ListItem>
                                            <asp:ListItem Value="NATHDWARA">NATHDWARA </asp:ListItem>
                                            <asp:ListItem Value="NAUKUCHIYATAL">NAUKUCHIYATAL </asp:ListItem>
                                            <asp:ListItem Value="NAVI MUMBAI">NAVI MUMBAI </asp:ListItem>
                                            <asp:ListItem Value="NERAL">NERAL </asp:ListItem>
                                            <asp:ListItem Value="NEW DELHI">NEW DELHI </asp:ListItem>
                                            <asp:ListItem Value="NILGIRI">NILGIRI </asp:ListItem>
                                            <asp:ListItem Value="NOIDA">NOIDA </asp:ListItem>
                                            <asp:ListItem Value="OOTY">OOTY </asp:ListItem>
                                            <asp:ListItem Value="ORCHHA">ORCHHA </asp:ListItem>
                                            <asp:ListItem Value="PACHEWAR">PACHEWAR </asp:ListItem>
                                            <asp:ListItem Value="PACHMARHI">PACHMARHI </asp:ListItem>
                                            <asp:ListItem Value="PAHALGAM">PAHALGAM </asp:ListItem>
                                            <asp:ListItem Value="PALAKKAD">PALAKKAD </asp:ListItem>
                                            <asp:ListItem Value="PALAMPUR">PALAMPUR </asp:ListItem>
                                            <asp:ListItem Value="PALANPUR">PALANPUR </asp:ListItem>
                                            <asp:ListItem Value="PALI">PALI </asp:ListItem>
                                            <asp:ListItem Value="PALITANA">PALITANA </asp:ListItem>
                                            <asp:ListItem Value="PANCHGANI">PANCHGANI </asp:ListItem>
                                            <asp:ListItem Value="PANCHKULA">PANCHKULA </asp:ListItem>
                                            <asp:ListItem Value="PANCHMARHI">PANCHMARHI </asp:ListItem>
                                            <asp:ListItem Value="PANHALA">PANHALA </asp:ListItem>
                                            <asp:ListItem Value="PANNA">PANNA </asp:ListItem>
                                            <asp:ListItem Value="PANTNAGAR">PANTNAGAR </asp:ListItem>
                                            <asp:ListItem Value="PANVEL">PANVEL </asp:ListItem>
                                            <asp:ListItem Value="PARADEEP">PARADEEP </asp:ListItem>
                                            <asp:ListItem Value="PARWANOO">PARWANOO </asp:ListItem>
                                            <asp:ListItem Value="PATHANKOT">PATHANKOT </asp:ListItem>
                                            <asp:ListItem Value="PATIALA">PATIALA </asp:ListItem>
                                            <asp:ListItem Value="PATNA">PATNA </asp:ListItem>
                                            <asp:ListItem Value="PATNITOP">PATNITOP </asp:ListItem>
                                            <asp:ListItem Value="PELLING">PELLING </asp:ListItem>
                                            <asp:ListItem Value="PENCH">PENCH </asp:ListItem>
                                            <asp:ListItem Value="PERIYAR">PERIYAR </asp:ListItem>
                                            <asp:ListItem Value="PHAGWARA">PHAGWARA </asp:ListItem>
                                            <asp:ListItem Value="PHALODI">PHALODI </asp:ListItem>
                                            <asp:ListItem Value="PINJORE">PINJORE </asp:ListItem>
                                            <asp:ListItem Value="PONDICHERRY">PONDICHERRY </asp:ListItem>
                                            <asp:ListItem Value="POOVAR">POOVAR </asp:ListItem>
                                            <asp:ListItem Value="PORBANDAR">PORBANDAR </asp:ListItem>
                                            <asp:ListItem Value="PORT BLAIR">PORT BLAIR </asp:ListItem>
                                            <asp:ListItem Value="POSHINA">POSHINA </asp:ListItem>
                                            <asp:ListItem Value="PRAGPUR">PRAGPUR </asp:ListItem>
                                            <asp:ListItem Value="PUNE">PUNE </asp:ListItem>
                                            <asp:ListItem Value="PURI">PURI </asp:ListItem>
                                            <asp:ListItem Value="PUSKHAR">PUSKHAR </asp:ListItem>
                                            <asp:ListItem Value="PUTTAPURTHY">PUTTAPURTHY </asp:ListItem>
                                            <asp:ListItem Value="RAIBARELLY">RAIBARELLY </asp:ListItem>
                                            <asp:ListItem Value="RAICHAK">RAICHAK </asp:ListItem>
                                            <asp:ListItem Value="RAIPUR">RAIPUR </asp:ListItem>
                                            <asp:ListItem Value="RAJAMUNDRY">RAJAMUNDRY </asp:ListItem>
                                            <asp:ListItem Value="RAJASTHAN">RAJASTHAN </asp:ListItem>
                                            <asp:ListItem Value="RAJGIR">RAJGIR </asp:ListItem>
                                            <asp:ListItem Value="RAJKOT">RAJKOT </asp:ListItem>
                                            <asp:ListItem Value="RAJPIPLA">RAJPIPLA </asp:ListItem>
                                            <asp:ListItem Value="RAJSAMAND">RAJSAMAND </asp:ListItem>
                                            <asp:ListItem Value="RAM NAGAR">RAM NAGAR </asp:ListItem>
                                            <asp:ListItem Value="RAMESHWARAM">RAMESHWARAM </asp:ListItem>
                                            <asp:ListItem Value="RAMGARH">RAMGARH </asp:ListItem>
                                            <asp:ListItem Value="RANAKPUR">RANAKPUR </asp:ListItem>
                                            <asp:ListItem Value="RANCHI">RANCHI </asp:ListItem>
                                            <asp:ListItem Value="RANIKHET">RANIKHET </asp:ListItem>
                                            <asp:ListItem Value="RANNY">RANNY </asp:ListItem>
                                            <asp:ListItem Value="RANTHAMBORE">RANTHAMBORE </asp:ListItem>
                                            <asp:ListItem Value="RATNAGIRI">RATNAGIRI </asp:ListItem>
                                            <asp:ListItem Value="RAVANGLA">RAVANGLA </asp:ListItem>
                                            <asp:ListItem Value="RISHIKESH">RISHIKESH </asp:ListItem>
                                            <asp:ListItem Value="RISHYAP">RISHYAP </asp:ListItem>
                                            <asp:ListItem Value="ROHETGARH">ROHETGARH </asp:ListItem>
                                            <asp:ListItem Value="ROPAR">ROPAR </asp:ListItem>
                                            <asp:ListItem Value="ROURKELA">ROURKELA </asp:ListItem>
                                            <asp:ListItem Value="RUDRAPRAYAG">RUDRAPRAYAG </asp:ListItem>
                                            <asp:ListItem Value="SAJAN">SAJAN </asp:ListItem>
                                            <asp:ListItem Value="SALEM">SALEM </asp:ListItem>
                                            <asp:ListItem Value="SAMODE">SAMODE </asp:ListItem>
                                            <asp:ListItem Value="SAPUTARA">SAPUTARA </asp:ListItem>
                                            <asp:ListItem Value="SARISKA">SARISKA </asp:ListItem>
                                            <asp:ListItem Value="SASAN GIR">SASAN GIR </asp:ListItem>
                                            <asp:ListItem Value="SATTAL">SATTAL </asp:ListItem>
                                            <asp:ListItem Value="SAWAI MADHOPUR">SAWAI MADHOPUR </asp:ListItem>
                                            <asp:ListItem Value="SAWANTWADI">SAWANTWADI </asp:ListItem>
                                            <asp:ListItem Value="SECUNDERABAD">SECUNDERABAD </asp:ListItem>
                                            <asp:ListItem Value="SERVICE ISSUE">SERVICE ISSUE </asp:ListItem>
                                            <asp:ListItem Value="SHEKAVATI">SHEKAVATI </asp:ListItem>
                                            <asp:ListItem Value="SHILLONG">SHILLONG </asp:ListItem>
                                            <asp:ListItem Value="SHIMLA">SHIMLA </asp:ListItem>
                                            <asp:ListItem Value="SHIRDI">SHIRDI </asp:ListItem>
                                            <asp:ListItem Value="SHUT DOWN HOTEL">SHUT DOWN HOTEL </asp:ListItem>
                                            <asp:ListItem Value="SIANA">SIANA </asp:ListItem>
                                            <asp:ListItem Value="SILIGURI">SILIGURI </asp:ListItem>
                                            <asp:ListItem Value="SILVASSA">SILVASSA </asp:ListItem>
                                            <asp:ListItem Value="SIVAGANGA DISTRICT">SIVAGANGA DISTRICT </asp:ListItem>
                                            <asp:ListItem Value="SOLAN">SOLAN </asp:ListItem>
                                            <asp:ListItem Value="SONAULI">SONAULI </asp:ListItem>
                                            <asp:ListItem Value="SRAVASTI">SRAVASTI </asp:ListItem>
                                            <asp:ListItem Value="SRINAGAR">SRINAGAR </asp:ListItem>
                                            <asp:ListItem Value="STARCRUISE">STARCRUISE </asp:ListItem>
                                            <asp:ListItem Value="SUNDERBAN">SUNDERBAN </asp:ListItem>
                                            <asp:ListItem Value="SURAT">SURAT </asp:ListItem>
                                            <asp:ListItem Value="TAPOLA">TAPOLA </asp:ListItem>
                                            <asp:ListItem Value="TARAPITH">TARAPITH </asp:ListItem>
                                            <asp:ListItem Value="THANE">THANE </asp:ListItem>
                                            <asp:ListItem Value="THANJAVUR">THANJAVUR </asp:ListItem>
                                            <asp:ListItem Value="THATTEKKAD">THATTEKKAD </asp:ListItem>
                                            <asp:ListItem Value="THEKKADY">THEKKADY </asp:ListItem>
                                            <asp:ListItem Value="THIRUVANNAMALAI">THIRUVANNAMALAI </asp:ListItem>
                                            <asp:ListItem Value="TIRUCHIRAPALLI">TIRUCHIRAPALLI </asp:ListItem>
                                            <asp:ListItem Value="THIRUVANANTHAPURAM">THIRUVANANTHAPURAM </asp:ListItem>
                                            <asp:ListItem Value="TIRUPATI">TIRUPATI </asp:ListItem>
                                            <asp:ListItem Value="TIRUPUR">TIRUPUR </asp:ListItem>
                                            <asp:ListItem Value="TRICHUR / THRISSUR">TRICHUR / THRISSUR </asp:ListItem>
                                            <asp:ListItem Value="UDHAMPUR">UDHAMPUR </asp:ListItem>
                                            <asp:ListItem Value="UDAIPUR">UDAIPUR </asp:ListItem>
                                            <asp:ListItem Value="UJJAIN">UJJAIN </asp:ListItem>
                                            <asp:ListItem Value="VADODARA">VADODARA </asp:ListItem>
                                            <asp:ListItem Value="VAGAMON">VAGAMON </asp:ListItem>
                                            <asp:ListItem Value="VALSAD">VALSAD </asp:ListItem>
                                            <asp:ListItem Value="VAPI">VAPI </asp:ListItem>
                                            <asp:ListItem Value="VARANASI">VARANASI </asp:ListItem>
                                            <asp:ListItem Value="VARKALA">VARKALA </asp:ListItem>
                                            <asp:ListItem Value="VELANKANNI">VELANKANNI </asp:ListItem>
                                            <asp:ListItem Value="VELLORE">VELLORE </asp:ListItem>
                                            <asp:ListItem Value="VERAVAL">VERAVAL </asp:ListItem>
                                            <asp:ListItem Value="VIJAYAWADA">VIJAYAWADA </asp:ListItem>
                                            <asp:ListItem Value="VIKRAMGADH">VIKRAMGADH </asp:ListItem>
                                            <asp:ListItem Value="VILLAGE TIPPI">VILLAGE TIPPI </asp:ListItem>
                                            <asp:ListItem Value="VISHAKAPATNAM">VISHAKAPATNAM </asp:ListItem>
                                            <asp:ListItem Value="WANKANER">WANKANER </asp:ListItem>
                                            <asp:ListItem Value="WAYANAD">WAYANAD </asp:ListItem>
                                            <asp:ListItem Value="WEST KEMENG">WEST KEMENG </asp:ListItem>
                                            <asp:ListItem Value="YAMUNOTRI">YAMUNOTRI </asp:ListItem>
                                            <asp:ListItem Value="YERCAUD">YERCAUD </asp:ListItem>
                                            <asp:ListItem Value="YUKSOM">YUKSOM </asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select city."
                                            ControlToValidate="ddlCity" ValidationGroup="modify" InitialValue="line" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td width="5%" valign="middle" class="lj_hd" align="center">
                                        Check In:
                                    </td>
                                    <td width="20%" align="left" valign="top">
                                        <asp:TextBox ID="check_Inhotel" runat="server" Width="130px" onKeyPress="javascript: return false;"
                                            onPaste="javascript: return false;" class="datepicker" OnClick="showDate();"
                                            ValidationGroup="modify"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="modify"
                                            Display="None" ErrorMessage="Please enter check in date." ControlToValidate="check_Inhotel"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="vceCheckIn" runat="server" TargetControlID="RequiredFieldValidator2">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td width="5%" valign="middle" class="lj_hd" align="center">
                                        Check Out:
                                    </td>
                                    <td width="20%" align="left" valign="top">
                                        <asp:TextBox ID="check_Outhotel" Width="130px" OnClick="showDate1();" onKeyPress="javascript: return false;"
                                            onPaste="javascript: return false;" ValidationGroup="modify" class="datepicker1"
                                            runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="modify"
                                            Display="None" runat="server" ErrorMessage="Please enter check out date." ControlToValidate="check_Outhotel"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="vceCheckOut" runat="server" TargetControlID="RequiredFieldValidator3">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td valign="top">
                                        <asp:Button ID="btnModify" runat="server" ValidationGroup="modify" Text="Modify"
                                            CssClass="buttonBook" OnClick="btnModify_Click" OnClientClick="showDiv();" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlSorting" runat="server">
                            <table width="980" border="0" cellspacing="0" cellpadding="0" class="is_tp">
                                <tr>
                                    <td width="200" valign="middle" class="">
                                        <table width="200" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="center" class="is_tp_hd">
                                                    SortBy: &nbsp;
                                                    <asp:LinkButton ID="lbtnHotelNameSort" runat="server" OnClick="lbtnHotelNameSort_Click">Name</asp:LinkButton>
                                                    &nbsp;
                                                    <asp:LinkButton ID="lbtnHotelRatingSort" runat="server" OnClick="lbtnHotelRatingSort_Click">Star</asp:LinkButton>
                                                    &nbsp;
                                                    <asp:LinkButton ID="lbtnHotelMinRateSort" runat="server" OnClick="lbtnHotelMinRateSort_Click">Fare</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="center" class="" width="245">
                                        <table width="245" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="center" class="is_tp_hd">
                                                    Hotel: &nbsp;<asp:DropDownList ID="ddlHotelName" runat="server" Width="150px" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlHotelName_SelectedIndexChanged" CssClass="lj_inp">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="195" align="center" class="">
                                        <table width="195" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="center" class="is_tp_hd">
                                                    Star: &nbsp;<asp:DropDownList ID="ddlHotelStar" runat="server" Width="120px" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlHotelStar_SelectedIndexChanged" CssClass="lj_inp">
                                                        <asp:ListItem>ALL</asp:ListItem>
                                                        <asp:ListItem Value="1">1 Star And Above</asp:ListItem>
                                                        <asp:ListItem Value="2">2 Star And Above</asp:ListItem>
                                                        <asp:ListItem Value="3">3 Star And Above</asp:ListItem>
                                                        <asp:ListItem Value="4">4 Star And Above</asp:ListItem>
                                                        <asp:ListItem Value="5">5 Star And Above</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <asp:GridView ID="gvHotels" runat="server" BorderWidth="0" AutoGenerateColumns="false"
                            Width="100%" ShowFooter="false" ShowHeader="false" AllowPaging="True" EmptyDataText="No Hotels Found."
                            OnPageIndexChanging="gvHotels_PageIndexChanging" OnRowCommand="gvHotels_RowCommand"
                            OnRowDataBound="gvHotels_RowDataBound" DataKeyNames="hotelid,hotelname,starrating,address,
        hoteldesc,facilities,webService,citywiselocation,locationinfo,checkintime,checkouttime,imagepath"
                            PageSize="20" RowStyle-BorderWidth="0">
                            <FooterStyle CssClass="link_buttons" />
                            <PagerStyle CssClass="link_buttons" />
                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red"
                                Font-Bold="true" />
                            <Columns>
                                <asp:TemplateField ItemStyle-BorderWidth="0">
                                    <ItemTemplate>
                                        <table width="100%" border="0" style="border-bottom: 0px;" cellspacing="0" cellpadding="0"
                                            class="is_tp">
                                            <tr>
                                                <td align="left" width="178" valign="top">
                                                    <asp:Image ID="imgHotel" runat="server" ImageUrl='<%# "http://"+Eval("imagepath") %>'
                                                        Width="178" Height="137" ToolTip='<%# Eval("imagedesc") %>' AlternateText="ImageNotFound" />
                                                    <br />
                                                    <br />
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
                                                                                    <img src="images/logo.gif" alt="Logo" border="0" title="LoveJourney">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="1" bgcolor="#c6c6c6">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" class="almost" height="20">
                                                                                    Please Dont Refresh
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <img src="images/roller_big.gif" width="100" height="100" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" class="almost12" height="20">
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
                                                <td width="650" align="center" valign="top">
                                                    <table width="630" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left" class="is_tp_red_hd" valign="top">
                                                                <%# Eval("hotelname") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <strong><u><span style="color: Red;">
                                                                    <%# Eval("starrating")%> </strong></span>Star </u>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#f9f9f9" height="40" align="left" class="is_bdr">
                                                                <table width="280" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td align="left" width="80" valign="top">
                                                                            <strong>Facilities: &nbsp;</strong>
                                                                        </td>
                                                                        <td width="28" class="is_inclusion_hs">
                                                                        </td>
                                                                        <td width="194" align="center">
                                                                            <asp:Label ID="lblfacilities" runat="server" Text='<%# Eval("facilities")%>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" height="25">
                                                                <b>Address:&nbsp;</b>
                                                                <%# Eval("address")%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <b>Description:&nbsp;</b>
                                                                <%# Eval("hoteldesc")%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="130" valign="top" align="center">
                                                    <table width="110" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <div class="is_dropshadow">
                                                                    Starting From <span class="is_price">
                                                                        <asp:Label ID="lblStartingPrice" CssClass="is_price" runat="server" Text='<%# "Rs "+Eval("minRate") %>'></asp:Label>
                                                                    </span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="40" align="center">
                                                                <asp:Button ID="btnViewPhotos" runat="server" CommandName="HotelDetails" CommandArgument='<%# Eval("hotelid") %>'
                                                                    OnClientClick="showDiv2();" CssClass="is_vd" Text="View Photos" /><br />
                                                                <br />
                                                                <asp:Button ID="btnViewRooms" runat="server" CommandName="ViewHotelRooms" CommandArgument='<%# Eval("hotelid") %>'
                                                                    OnClientClick="showDiv2();" CssClass="is_vd" Text="View Rooms" />
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
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Panel ID="pnlHotelRooms" runat="server" Visible="false">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lbtnShowNetFare" CommandName="ShowNetFares" CommandArgument='<%# Eval("hotelid") %>'
                                                                        runat="server" ToolTip="Show Net Fare">SNF</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:GridView ID="gvHotelRooms" BorderColor="GrayText" runat="server" AutoGenerateColumns="false"
                                                            Width="100%" RowStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="Gray"
                                                            HeaderStyle-BorderWidth="1" RowStyle-BorderColor="Gray" RowStyle-BorderWidth="1"
                                                            RowStyle-VerticalAlign="Middle" DataKeyNames="ratetype,hotelPackage,roomtype,roombasis,roomTypeCode,ratePlanCode,hotelid,
                                                validdays,wsKey,extGuestTotal,roomTotal,servicetaxTotal,discount,commission" OnRowCommand="gvHotelRooms_RowCommand"
                                                            OnRowDataBound="gvHotelRooms_RowDataBound">
                                                            <FooterStyle CssClass="link_buttons" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="RoomType" HeaderStyle-BorderColor="Gray" ItemStyle-Width="178px"
                                                                    ItemStyle-BorderColor="Gray">
                                                                    <ItemTemplate>
                                                                        <%# Eval("roomtype")%>
                                                                        <br />
                                                                        <asp:LinkButton ID="lbtnHotelPolicy" runat="server" Visible="false" CommandName="HotelPolicy"
                                                                            CommandArgument='<%# Eval("hotelid") %>'>Hotel Policy</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Inclusions" HeaderStyle-BorderColor="Gray" ItemStyle-Width="650px"
                                                                    ItemStyle-BorderColor="Gray">
                                                                    <ItemTemplate>
                                                                        <%# Eval("roombasis")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Incl Tax" HeaderStyle-BorderColor="Gray" ItemStyle-Width="130px"
                                                                    ItemStyle-BorderColor="Gray">
                                                                    <ItemTemplate>
                                                                        INR
                                                                        <asp:LinkButton ID="lbtnFare" Text='<%# Eval("roomTotal")%>' runat="server"></asp:LinkButton>
                                                                        <br />
                                                                        <asp:LinkButton ID="lbtnNetFare" Text='<%# Eval("roomTotal")%>' runat="server"></asp:LinkButton>
                                                                        <br />
                                                                        <asp:Button ID="btnBook" runat="server" CommandName="BookRoom" CommandArgument='<%# Eval("hotelid") %>'
                                                                            CssClass="buttonBook" Text="Book Now" OnClientClick="showDiv2();" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" style="border-bottom: 0px;" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="3">
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <div style="text-align: left; display: none;">
                            <asp:Button ID="btnPopId" runat="server" CssClass="buttonBook" Height="1px" Width="1px" /></div>
                        <asp:ModalPopupExtender ID="modalPopUp" TargetControlID="btnPopId" PopupControlID="Panel1"
                            runat="server" BackgroundCssClass="loadingBackground" DropShadow="false" Drag="false"
                            OkControlID="btnClose" />
                        <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="400" Width="800"
                            Style="display: none; color: Black; border: 5px solid #3e6cc4; border-radius: 5px;
                            -moz-border-radius: 5px;">
                            <table width="780" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnClose" runat="server" Text="X" CssClass="buttonclose" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel2" runat="server" BackColor="White" ScrollBars="Both" Height="370"
                                            Width="780" Style="color: Black; border: 1px;">
                                            <asp:DataList ID="dlPhotos" runat="server" RepeatColumns="2">
                                                <ItemTemplate>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "http://"+Eval("imagepath") %>' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <br />
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
