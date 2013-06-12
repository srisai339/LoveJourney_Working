<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmFlightsAvailability.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="frmFlightsAvailability" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LoveJourney - Book Flight Tickets Online. </title>
    <link href="css/lj_style.css" type="text/css" rel="stylesheet" />
    <link href="css/mak_style.css" rel="stylesheet" type="text/css" />
    <!--  initialize the slideshow when the DOM is ready -->
    <%--<style type="text/css">
        <%--.gridLines td
        {
            border-top: 1px solid Gray;
        }--%>
    <%--</style>--%>
    <style type="text/css">
        .clsFind
        {
        }
    </style>

     <style type="text/css">
        .autoextender
        {
           /* font-family : Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 2px;
            background-color: White;
            z-index:1000;
            height:auto;*/
             font-size: 11px;
    color:Red;
    
    border: 1px solid #999;
    background: #fff;
    width:175px;
  
    z-index: 1;
    position:absolute;
    margin-left:0px;
          
          
        }
        .autoextender1
        {
              font-size: 11px;
    color: #000;
   
    border: 1px solid #999;
    background: #fff;
    width: 200px;
   
    z-index: 1;
    position:absolute;
    margin-left:0px;
          
        }
    </style>

    <script type="text/javascript">
        function fnrbtnroundtriponeway() {
            $("#divReturnDate").hide();
        }
       
    </script>
    <script type="text/javascript">
        function fnrbtnroundtrip() {          
            $("#divReturnDate").show();
            $("#divReturnDate").css("class", "datepicker1");
        }
       
    </script>
      <script type="text/javascript">
          function fnrbtnroundtriponewaymodify() {
              $("#divreturndatemodify").hide();
          }
       
    </script>
    <script type="text/javascript">
        function fnrbtnroundtripmodify() {
            $("#divreturndatemodify").show();
            $("#divreturndatemodify").css("class", "datepicker1");
        }
       
    </script>
    <script language="javascript" type="text/javascript">


        function showHNF() {


            if (document.getElementById("<%=lnkSNFFare.ClientID %>").text == "SNF") {
               
                document.getElementById("<%=lnkSNFFare.ClientID %>").text = "";
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
    <script language="javascript" type="text/javascript">


        function showHNFRoundtrip() {

            if (document.getElementById("<%=lnkSNFFareroundtrip.ClientID %>").text == "SNF") {
                document.getElementById("<%=lnkSNFFareroundtrip.ClientID %>").text = "HNF";
                var con = $(".clsFind");
                con.show();
                return false;

            }
            else if (document.getElementById("<%=lnkSNFFareroundtrip.ClientID %>").text == "HNF") {
                var con = $(".clsFind");
                con.hide();
                document.getElementById("<%=lnkSNFFareroundtrip.ClientID %>").text = "SNF";

                return false;
            }
        }
     
  
    </script>
    <link href="css/accordian.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/chromestyle_New.css" />
    <link href="css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="http://jquery.malsup.com/block/jquery.blockUI.js?v2.38" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function SelectSingleRadiobutton(rbnAirline) {
            var rdBtn = document.getElementById(rbnAirline);
            var rdBtnList = document.getElementsByTagName("input");
            for (i = 0; i < rdBtnList.length; i++) {
                if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                    rdBtnList[i].checked = false;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function tabE(obj, e) {

            // alert('hi');

            var e = (typeof event != 'undefined') ? window.event : e; // IE : Moz 

            if (e.keyCode == 13) {
                var ele = document.forms[0].elements;
                for (var i = 0; i < ele.length; i++) {
                    var q = (i == ele.length - 1) ? 0 : i + 1; // if last element : if any other 
                    if (obj == ele[i]) { ele[q].focus(); break }
                }
                return false;
            }
            document.getElementById('<%=txtFromDate.ClientID %>').value = "";
            document.getElementById('<%=txtdatesearch.ClientID %>').value = "";
            alert(document.getElementById('<%=txtdatesearch.ClientID %>').value);
        }
        function tabE1(obj, e) {
            // alert('hi');

            var e = (typeof event != 'undefined') ? window.event : e; // IE : Moz 

            if (e.keyCode == 13) {
                var ele = document.forms[0].elements;
                for (var i = 0; i < ele.length; i++) {
                    var q = (i == ele.length - 1) ? 0 : i + 1; // if last element : if any other 
                    if (obj == ele[i]) { ele[q].focus(); break }
                }
                return false;
            }
            document.getElementById('<%=txtReturnDate.ClientID %>').value = "";
            document.getElementById('<%=txtretundatesearch.ClientID %>').value = "";
            // alert(document.getElementById('<%=txtFromDate.ClientID %>').value);
        }
        function tabE2(obj, e) {
            //  alert('hi');

            var e = (typeof event != 'undefined') ? window.event : e; // IE : Moz 

            if (e.keyCode == 13) {
                var ele = document.forms[0].elements;
                for (var i = 0; i < ele.length; i++) {
                    var q = (i == ele.length - 1) ? 0 : i + 1; // if last element : if any other 
                    if (obj == ele[i]) { ele[q].focus(); break }
                }
                return false;
            }

            document.getElementById('<%=txtdatesearch.ClientID %>').value = "";
            //  alert(document.getElementById('<%=txtdatesearch.ClientID %>').value);
        }
        function tabE3(obj, e) {
            //   alert('hi');

            var e = (typeof event != 'undefined') ? window.event : e; // IE : Moz 

            if (e.keyCode == 13) {
                var ele = document.forms[0].elements;
                for (var i = 0; i < ele.length; i++) {
                    var q = (i == ele.length - 1) ? 0 : i + 1; // if last element : if any other 
                    if (obj == ele[i]) { ele[q].focus(); break }
                }
                return false;
            }

            document.getElementById('<%=txtretundatesearch.ClientID %>').value = "";
            // alert(document.getElementById('<%=txtretundatesearch.ClientID %>').value);
        }
        function InfantDate(txtBirthDateClientId) {


            var selectedBirthDate = txtBirthDateClientId.value;

            var month1 = selectedBirthDate.split("-");
            var mm = month1[1].toString();
            var dd = month1[0].toString();
            var yy = month1[2].toString();

            var nowdatetime = new Date();
            var myCars = new Array();
            myCars["Jan"] = "1";
            myCars["Feb"] = "2";
            myCars["Mar"] = "3";
            myCars["Apr"] = "4";
            myCars["May"] = "5";
            myCars["Jun"] = "6";
            myCars["Jul"] = "7";
            myCars["Aug"] = "8";
            myCars["Sep"] = "9";
            myCars["Oct"] = "10";
            myCars["Nov"] = "11";
            myCars["Dec"] = "12";
            var name = myCars[mm];

            var date2 = name + "/" + dd + "/" + yy;

            //            var found = $.inArray(mm, monthShortNames) > -1;
            //            var monthShortNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
            //            alert(found);
            var month = nowdatetime.getMonth() + 1;
            var day = nowdatetime.getDate();
            var year = nowdatetime.getFullYear();
            var nowdate = day + "/" + month + "/" + year;

            var date1 = new Date(date2);
            var date3 = new Date(nowdate);
            // alert("date:"+date1);
            //alert("sys"+nowdatetime);
            // alert(date3);
            if (date1 > nowdatetime) {
                txtBirthDateClientId.value = null;
                alert("Birthdate must be less than or equal to Current date.");
                return false;
            }
            else {

                return true;
            }



        }
         
    </script>
    <script type="text/javascript">

        //        function CheckMinChars(txtclientId) {
        //            alert('hi'); alert(txtclientId);
        //            var v = document.getElementById("ctl00_ContentPlaceHolder1_"+ txtclientId).value;
        //            alert(v);
        //            if (v.length < 2) {
        //                alert('Last Name should be minimum 2 characters');
        //            }
        //        }


        function InfantDate(txtBirthDateClientId) {

            //alert('hi');
            alert(txtBirthDateClientId);


            var selectedBirthDate = document.getElementById("ctl00_ContentPlaceHolder1_" + txtBirthDateClientId).value            //this is the selected Date

            var nowdatetime = new Date();
            var month = nowdatetime.getMonth() + 1;
            var day = nowdatetime.getDate();
            var year = nowdatetime.getFullYear();
            var nowdate = month + "/" + day + "/" + year;


            if (selectedBirthDate > nowdate) {
                alert("Birthdate must be less than or equal to Current date.");
                return false;
            }

        }






        function txttextchanged() {

            document.getElementById("ctl00_ContentPlaceHolder1_txtFirstname").value = document.getElementById("ctl00_ContentPlaceHolder1_txtFn1").value;
            document.getElementById("ctl00_ContentPlaceHolder1_txtLastName").value = document.getElementById("ctl00_ContentPlaceHolder1_txtLn1").value;
            document.getElementById("ctl00_ContentPlaceHolder1_dlTitle").options[document.getElementById("ctl00_ContentPlaceHolder1_dlTitle").selectedIndex].Text = document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle1").options[document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle1").selectedIndex].Text;
        }
        function ValueChangedHandler(sender, args) {

            document.getElementById("ctl00_ContentPlaceHolder1_lbl11").innerHTML = document.getElementById('<%= HiddenField2.ClientID %>').value;

            document.getElementById("lbl").innerHTML = document.getElementById('<%= HiddenField1.ClientID %>').value;

        }

        function vtxtEmailId() {

            var v = document.getElementById('<%=txtEmailID.ClientID %>').value;
            if (v == "") {
                alert('Please Enter Email Id');
            }


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
            //alert(document.getElementById('<%=txtFromDate.ClientID %>').value);

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


        function showDiv() {
            Page_ClientValidate("Search");
            if (Page_ClientValidate("Search")) {
                go();
                go1();
                go2();
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "Images/loading14.gif.gif"', 200);
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
                setTimeout('document.images["myAnimatedImage"].src = "../../Images/loading14.gif.gif"', 200);
            }
            else {
                return false;
            }
        }

        function showDiv3() {
            Page_ClientValidate("Search");
            if (Page_ClientValidate("Search")) {
                gor();
                gor1();
                gor2();


                gor3();
                gor4();
                gor5();
                document.getElementById('mainDiv3').style.display = "";
                document.getElementById('contentDiv3').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "Images/loading14.gif.gif"', 200);
            }
            else {
                return false;
            }
        }

        function showDiv4() {
            Page_ClientValidate("SearchInt");
            if (Page_ClientValidate("SearchInt")) {
                gorint();
                gor1int();
                gor2int();

                gor3int();
                gor4int();
                gor5int();
                document.getElementById('mainDiv4').style.display = "";
                document.getElementById('contentDiv4').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "Images/loading14.gif.gif"', 200);
            }
            else {
                return false;
            }
        }







        function startsearch() {


            var Source = document.getElementById('<%=ddlSources.ClientID%>').value;

            // var val = Source.options[Source.selectedIndex].text;

            var Destination = document.getElementById('<%=ddlDestinations.ClientID%>').value;
            // var val2 = Destination.options[Destination.selectedIndex].text;
            if (Source == 'Enter Your Source') {
                alert('Please enter Source');
                return false;
            }
            else if (Destination == 'Enter Your Destination') {
                alert('Please enter destination');
                return false;
            }
            else if (Source == Destination) {
                alert('Source and Destination Can not  be Same');
                return false;
            }

            var rbtnOneWay = document.getElementById('<%=rbtnOneWay.ClientID %>');

            var Date1 = document.getElementById('<%=txtFromDate.ClientID %>').value;
            document.getElementById('<%=hdnfromdate.ClientID %>').value = Date1;




            if (rbtnOneWay.checked) {

                if (Date1 == 'DD-MM-YYYY') {
                    alert('Please Enter From Date');
                    return false;
                }
                else {



                    showDiv();
                }


            }
            else {
                var Date2 = document.getElementById('<%=txtReturnDate.ClientID %>').value;
                document.getElementById('<%=hdnTodate.ClientID %>').value = Date2;
                if (Date1 == 'DD-MM-YYYY') {
                    alert('Please Enter From Date');
                    return false;
                }
                else if (Date2 == 'DD-MM-YYYY') {
                    alert('Please Enter Return Date');
                    return false;
                }
                else {

                 
                    var datearray = Date1.split("-");

                    Date1 = datearray[1] + '-' + datearray[0] + '-' + datearray[2];

                    var datearray1 = Date2.split("-");

                    Date2 = datearray1[1] + '-' + datearray1[0] + '-' + datearray1[2];



                    if (Date1 > Date2) {
                        alert('Return date can not before the Depart date');
                        return false;


                    }
                    else {
                        showDiv3();
                    }
                }
            }

        }

        function startsearch1() {
            var Source = document.getElementById('<%=ddlSourcesSearch.ClientID%>').value;
            //alert(Source);
            // var val = Source.options[Source.selectedIndex].text;

            //alert(val);
            var Destination = document.getElementById('<%=ddlDestinationsSearch.ClientID%>').value;
            //var val2 = Destination.options[Destination.selectedIndex].text;
            //alert(val2);
            if (Source == Destination) {
                alert('Source and Destination Can not  be Same');
                return false;
            }

            var rbtnOneWaySearch = document.getElementById('<%=rbonesearch.ClientID %>');
            var Date3 = document.getElementById('<%=txtdatesearch.ClientID %>').value;

            var Date4 = document.getElementById('<%=txtretundatesearch.ClientID%>').value;


            if (rbtnOneWaySearch.checked) {


                showDiv2();


            }
            else
                if (Date4 == '') {
                    alert('Please Enter Return Date');
                    return false;
                }
                else {

                    var datearray3 = Date3.split("-");

                    Date3 = datearray3[1] + '-' + datearray3[0] + '-' + datearray3[2];

                    var datearray4 = Date4.split("-");

                    Date4 = datearray4[1] + '-' + datearray4[0] + '-' + datearray4[2];

                    if (Date3 > Date4) {

                        alert('Return date can not before the Depart date');
                        return false;


                    }
                    else {
                        showDiv4();
                    } 
                }



        }



        function AddLetters(obj) {
            document.getElementById('<%=txtFirstname.ClientID %>').value = obj.value;

        }
        function AddLettersLn(obj) {
            document.getElementById('<%=txtLastName.ClientID %>').value = obj.value;

        }

        function AddTitle(obj) {
            //  alert(obj.options[obj.selectedIndex].text);
            document.getElementById('<%=dlTitle.ClientID %>').value = obj.options[obj.selectedIndex].text;

        }
        function Adddob(obj) {
            //alert('hi');
            obj.value = "";

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
        }
        .back_bg1
        {
            background: url(images/Love.png) no-repeat top;
        }
    </style>
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type="text/javascript">
        $(function () {
            $("#<%=dvModifySearch.ClientID %>").accordion({
                collapsible: true

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="updatepanel" runat="server">
<ContentTemplate>--%>
    <script type="text/javascript">
        function go() {

            var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;

            var strAr = DropdownList.value.split("-");

            document.getElementById('Text1').value = strAr[0];
        }
        function go1() {

            var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;

            var strAr = DropdownList.value.split("-");
            document.getElementById('Text2').value = strAr[0];
        }
        function go2() {
            var SelectedText = document.getElementById('<%=txtFromDate.ClientID %>');

            var strAr = SelectedText.value.split("-");
            var sel = strAr[0] + "-" + strAr[1] + "-" + strAr[2];
            document.getElementById('Text3').value = sel;
        }

        function goInt() {
            var DropdownList = document.getElementById('<%=ddlSourcesSearch.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text4').value = strAr[0];
        }
        function go1Int() {
            var DropdownList = document.getElementById('<%=ddlDestinationsSearch.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text5').value = strAr[0];
        }
        function go2Int() {
            var SelectedText = document.getElementById('<%=txtdatesearch.ClientID %>');
            var strAr = SelectedText.value.split("-");
            var sel = strAr[0] + "-" + strAr[1] + "-" + strAr[2];
            document.getElementById('Text6').value = sel;
        }

        function gor() {
            var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text7').value = strAr[0];
        }
        function gor1() {
            var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text8').value = strAr[0];
        }
        function gor2() {
            var SelectedText = document.getElementById('<%=txtFromDate.ClientID %>');

            var strAr = SelectedText.value.split("-");
            var sel = strAr[0] + "-" + strAr[1] + "-" + strAr[2];
            document.getElementById('Text9').value = sel;
        }



        function gor3() {
            var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text10').value = strAr[0];
        }
        function gor4() {
            var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text11').value = strAr[0];
        }
        function gor5() {
            var SelectedText = document.getElementById('<%=txtReturnDate.ClientID %>');

            var strAr = SelectedText.value.split("-");
            var sel = strAr[0] + "-" + strAr[1] + "-" + strAr[2];
            document.getElementById('Text12').value = sel;
        }



        function gorint() {
            //            var DropdownList = document.getElementById('<%=ddlSourcesSearch.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text13').value = strAr[0];
        }
        function gor1int() {
            var DropdownList = document.getElementById('<%=ddlDestinationsSearch.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text14').value = strAr[0];
            //document.getElementById('Text14').value = SelectedText;
        }
        function gor2int() {
            var SelectedText = document.getElementById('<%=txtdatesearch.ClientID %>');

            var strAr = SelectedText.value.split("-");
            var sel = strAr[0] + "-" + strAr[1] + "-" + strAr[2];
            document.getElementById('Text15').value = sel;
        }



        function gor3int() {
            var DropdownList = document.getElementById('<%=ddlDestinationsSearch.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text16').value = strAr[0];
        }
        function gor4int() {
            var DropdownList = document.getElementById('<%=ddlSourcesSearch.ClientID %>');
            //            var SelectedIndex = DropdownList.selectedIndex;
            //            var SelectedValue = DropdownList.value;
            //            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var strAr = DropdownList.value.split("-");
            document.getElementById('Text17').value = strAr[0];
        }
        function gor5int() {
            var SelectedText = document.getElementById('<%=txtretundatesearch.ClientID %>');

            var strAr = SelectedText.value.split("-");
            var sel = strAr[0] + "-" + strAr[1] + "-" + strAr[2];
            document.getElementById('Text18').value = sel;
        }





    </script>
    <script type="text/javascript">

function CalculateAge(birthday) {

var re=/^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d+$/;

if (birthday.value != '') {

if(re.test(birthday.value ))
{
birthdayDate = new Date(birthday.value);
dateNow = new Date();

var years = dateNow.getFullYear() - birthdayDate.getFullYear();
var months=dateNow.getMonth()-birthdayDate.getMonth();
var days=dateNow.getDate()-birthdayDate.getDate();
if (isNaN(years)) {

document.getElementById('lblAge').innerHTML = '';
document.getElementById('lblError').innerHTML = 'Input date is incorrect!';
return false;

}

else {
document.getElementById('lblError').innerHTML = '';

if(months < 0 || (months == 0 && days < 0)) {
years = parseInt(years) -1;
document.getElementById('lblAge').innerHTML = years +' Years '
}
else {
document.getElementById('lblAge').innerHTML = years +' Years '
}
}
}
else
{
document.getElementById('lblError').innerHTML = 'Date must be mm/dd/yyyy format';
return false;
}
}
}
    </script>
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            alert(div.value);
            //  var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                alert("ins");
                div.style.display = "inline";
                // img.src = "minus.gif";
            } else {
                alert("ins1");
                div.style.display = "none";
                // img.src = "plus.gif";
            }
        }
    </script>
    <asp:HiddenField ID="hdnfromdate" runat="server" />
    <asp:HiddenField ID="hdnTodate" runat="server" />
    <asp:Panel ID="pnlflights" runat="server">
        <table width="1004" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td valign="top">
                    <table width="1004" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td width="1004" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                                            runat="server" visible="false">
                                            <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="18">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <div>
                                    <asp:Panel ID="pnlSearch" runat="server">
                                        <table width="1000" border="0" cellspacing="0" cellpadding="0" height="372" class="lj_ctnt"
                                            id="tblSearch" runat="server">
                                            <tr>
                                                <td width="540" valign="top" align="right">
                                                    <table width="500" border="0" cellspacing="0" cellpadding="0">
                                                        <tr id="User_menu" runat="server" visible="false">
                                                            <td align="left" valign="top">
                                                                <!--form_menu-->
                                                                <table width="440" border="0" cellspacing="0" cellpadding="0" id="tblicons" runat="server">
                                                                    <tr>
                                                                        <td>
                                                                            <table width="108" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="8" align="left">
                                                                                        <img src="Newimages/l1.png" width="8" height="37" />
                                                                                    </td>
                                                                                    <td class="lj_tab_bg">
                                                                                        <table width="92" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="92" align="left" valign="middle" height="32" class="lj_n_bus">
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
                                                                            <table width="108" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="8" align="left">
                                                                                        <img src="Newimages/l1.png" width="8" height="37" />
                                                                                    </td>
                                                                                    <td class="lj_tab_bg">
                                                                                        <table width="92" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="92" align="left" valign="middle" height="32" class="lj_n_flight">
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
                                                                            <table width="108" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="8" align="left">
                                                                                        <img src="Newimages/l1.png" width="8" height="37" />
                                                                                    </td>
                                                                                    <td class="lj_tab_bg">
                                                                                        <table width="92" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="92" align="left" valign="middle" height="32" class="lj_n_hotel">
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
                                                                            <table width="108" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="8" align="left">
                                                                                        <img src="Newimages/l1.png" width="8" height="37" />
                                                                                    </td>
                                                                                    <td class="lj_tab_bg">
                                                                                        <table width="92" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="92" align="left" valign="middle" height="32" class="lj_n_car">
                                                                                                    <a href="#">Cars</a>
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
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <table width="480" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td align="left" class="lj_srchGo">
                                                                            Search your Domestic Flight Here
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
                                                                                        <asp:RadioButton ID="rbtnOneWay" Text="One Way" runat="server" Checked="true" AutoPostBack="false"
                                                                                            TabIndex="0" GroupName="ONE" OnCheckedChanged="rbtnOneWay_CheckedChanged" Font-Names="Arial" onclick="fnrbtnroundtriponeway();"/>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:RadioButton ID="rbtnRoundTrip" runat="server" AutoPostBack="false" TabIndex="1" onclick="fnrbtnroundtrip();"
                                                                                            Visible="true" Text="Roundtrip" GroupName="ONE" OnCheckedChanged="rbtnRoundTrip_CheckedChanged"
                                                                                            Font-Names="Arial" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
                                                                                                        <img src="Newimages/f_i.png" width="56" height="32" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="ddlSources" runat="server" ToolTip="Type the first 3 letters of airport or city name"
                                                                                                            CssClass="lj_inputbox" TabIndex="2"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="rfvFrom" Display="None" ValidationGroup="SearchInt"
                                                                                                            runat="server" ErrorMessage="Enter Source" ControlToValidate="ddlSources"></asp:RequiredFieldValidator>
                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvFrom">
                                                                                                        </ajax:ValidatorCalloutExtender>
                                                                                                        <ajax:AutoCompleteExtender ID="ddlSources_AutoCompleteExtender" runat="server" TargetControlID="ddlSources"
                                                                                                            ServiceMethod="GetAirportCodes1" MinimumPrefixLength="2" CompletionInterval="10"
                                                                                                            CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"    CompletionListItemCssClass="autoextender1"  CompletionListCssClass="autoextender"
                                                                                                            ServicePath="">
                                                                                                        </ajax:AutoCompleteExtender>
                                                                                                        <ajax:TextBoxWatermarkExtender ID="tbe" runat="server" WatermarkText="Enter Your Source" TargetControlID="ddlSources"></ajax:TextBoxWatermarkExtender>
                                                                                                        
                                                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ValidationGroup="Search"
                                                                                                                                runat="server" ErrorMessage="Select source." ControlToValidate="ddlSources" InitialValue="----------"></asp:RequiredFieldValidator>
                                                                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                                                                                                            </ajax:ValidatorCalloutExtender>--%>
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
                                                                                                        <img src="Newimages/f_i.png" width="56" height="32" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="ddlDestinations" runat="server" ToolTip="Type the first 3 letters of airport or city name"
                                                                                                            CssClass="lj_inputbox" TabIndex="2"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="rfvddlDestinations" Display="None" ValidationGroup="SearchInt"
                                                                                                            runat="server" ErrorMessage="Enter Source" ControlToValidate="ddlDestinations"></asp:RequiredFieldValidator>
                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvddlDestinations">
                                                                                                        </ajax:ValidatorCalloutExtender>
                                                                                                        <ajax:AutoCompleteExtender ID="ddlDestinations_AutoCompleteExtender" runat="server"
                                                                                                            TargetControlID="ddlDestinations" ServiceMethod="GetAirportCodes1" MinimumPrefixLength="2"
                                                                                                            CompletionInterval="10" CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" CompletionListItemCssClass="autoextender1"  CompletionListCssClass="autoextender"
                                                                                                            Enabled="True" ServicePath="">
                                                                                                        </ajax:AutoCompleteExtender>
                                                                                                          <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkText="Enter Your Destination" TargetControlID="ddlDestinations"></ajax:TextBoxWatermarkExtender>
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
                                                                                                        <img src="images/calender.png" width="56" height="32" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:TextBox ID="txtFromDate" runat="server" class="datepicker1" onclick="showDate();"
                                                                                                            onkeyup="return tabE(this,event)" onPaste="javascript: return false;" TabIndex="4"
                                                                                                            ValidationGroup="Search" Width="100px" />
                                                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFromDate"
                                                                                                            Display="None" ErrorMessage="Enter date." ValidationGroup="Search"></asp:RequiredFieldValidator>
                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                                                                                        </ajax:ValidatorCalloutExtender>--%>
                                                                                                        <ajax:TextBoxWatermarkExtender ID="txtwtbe" runat="server" TargetControlID="txtFromDate"
                                                                                                            WatermarkText="DD-MM-YYYY">
                                                                                                        </ajax:TextBoxWatermarkExtender>
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td width="10">
                                                                                    </td>
                                                                                    <td width="233" align="left" id="tdround" runat="server">
                                                                                       
                                                                                        <div class="lj_outDiv" id="divReturnDate" style="display:none;">
                                                                                            <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                                <tr>
                                                                                                    <td width="70" align="center" class="lj_bdrit">
                                                                                                        <img src="images/calender.png" width="56" height="32" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:TextBox ID="txtReturnDate" runat="server" Enabled="False" Visible="true" ValidationGroup="Search"
                                                                                                            onclick="showDate1();" class="datepicker1" onkeyup="return tabE1(this,event)"
                                                                                                            TabIndex="5" onPaste="javascript: return false;" Width="100px" />
                                                                                                        <%--<asp:RequiredFieldValidator ID="RequiredReturn" ControlToValidate="txtReturnDate"
                                                                                                            runat="server" Visible="false" ErrorMessage="Enter return date." Display="None"
                                                                                                            ValidationGroup="Search"></asp:RequiredFieldValidator>--%>
                                                                                                        <%--                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredReturn">
                                                                                                        </ajax:ValidatorCalloutExtender>--%>
                                                                                                        <ajax:TextBoxWatermarkExtender ID="txtboxextender" runat="server" TargetControlID="txtReturnDate"
                                                                                                            WatermarkText="DD-MM-YYYY">
                                                                                                        </ajax:TextBoxWatermarkExtender>
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
                                                                                                        <img src="Newimages/f_i.png" width="56" height="32" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:DropDownList ID="ddlCabin_type" runat="server" TabIndex="9" class="lj_inputdropdown">
                                                                                                            <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                                                                            <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                                                                            <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td width="10">
                                                                                    </td>
                                                                                    <td width="233" align="left">
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
                                                                            <table width="480" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="100%" valign="top">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td class="lj_rooms" align="center">
                                                                                                    Adults
                                                                                                </td>
                                                                                                <td class="lj_rooms" align="center">
                                                                                                    Children
                                                                                                </td>
                                                                                                <td class="lj_rooms" align="center">
                                                                                                    Infant
                                                                                                </td>
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div class="lj_outroom">
                                                                                                        <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                                            <tr>
                                                                                                                <td width="70" align="center" class="lj_bdrit">
                                                                                                                    <img src="images/adult.png" width="56" height="32" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="ddlAdult" runat="server" Width="50px" CssClass="lj_inputdropdown"
                                                                                                                        TabIndex="6">
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
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <div class="lj_outroom">
                                                                                                        <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                                            <tr>
                                                                                                                <td width="70" align="center" class="lj_bdrit">
                                                                                                                    <img src="images/adult.png" width="56" height="32" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="ddlChild" class="ft02" runat="server" Width="50px" CssClass="lj_inputdropdown"
                                                                                                                        TabIndex="7">
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
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <div class="lj_outroom">
                                                                                                        <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                                                                                                            <tr>
                                                                                                                <td width="70" align="center" class="lj_bdrit">
                                                                                                                    <img src="Newimages/child.png" width="56" height="32" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="ddlInfant" class="ft02" runat="server" Width="50px" CssClass="lj_inputdropdown"
                                                                                                                        TabIndex="8">
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
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="ibtnSearch" runat="server" Text="Search" class="lj_button_chk" TabIndex="10"
                                                                                                        OnClientClick="return startsearch();" ValidtionGroup="Search" OnClick="ibtnSearch_Click1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="3" class="lj_rooms" height="30">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td width="80" valign="bottom">
                                                                                        &nbsp;<span id="mainDiv" style="display: none" class="loadingBackground"></span><span
                                                                                            id="contentDiv" style="display: none" class="modalContainer"><div class="registerhead">
                                                                                                <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: White">
                                                                                                    <tr>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="images/l1.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                        <td height="8" width="582">
                                                                                                        </td>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="images/l2.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3" align="center" valign="top">
                                                                                                            <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                                                                <tr>
                                                                                                                    <td align="center" height="25" valign="top">
                                                                                                                        <img src="Newimages/New_Logo.png" width="226" height="79" alt="Logo" border="0" title="LoveJourney" />
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
                                                                                                                        <img src="images/loading14.gif" width="37" height="36" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" class="almost12" height="20">
                                                                                                                        Searching for Flights
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20" class="lj_hdload">
                                                                                                                        <input id="Text1" type="text" style="text-align: right; border: 0; background-color: white;"
                                                                                                                            readonly="readonly" class="progress" />
                                                                                                                        To
                                                                                                                        <input id="Text2" type="text" style="border: 0; text-align: left; background-color: White"
                                                                                                                            disabled="disabled" class="progress" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20">
                                                                                                                        On
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20" class="lj_hdload">
                                                                                                                        <input id="Text3" type="text" style="border: 0; text-align: center; background-color: White"
                                                                                                                            disabled="disabled" class="progress" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="images/l3.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                        <td height="8" width="582">
                                                                                                        </td>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="images/l4.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>
                                                                                        </span><span id="mainDiv3" style="display: none" class="loadingBackground"></span>
                                                                                        <span id="contentDiv3" style="display: none" class="modalContainer">
                                                                                            <div class="registerhead">
                                                                                                <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: White">
                                                                                                    <tr>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="images/l1.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                        <td height="8" width="582">
                                                                                                        </td>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="images/l2.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3" align="center" valign="top">
                                                                                                            <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                                                                <tr>
                                                                                                                    <td align="center" height="25" valign="top">
                                                                                                                        <img src="Newimages/New_Logo.png" width="226" height="79" alt="Logo" border="0" title="LoveJourney" />
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
                                                                                                                        <img src="images/loading14.gif" width="37" height="36" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" class="almost12" height="20">
                                                                                                                        Searching for Flights
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20" class="lj_hdload">
                                                                                                                        <input id="Text7" type="text" style="text-align: right; border: 0; background-color: white;"
                                                                                                                            readonly="readonly" class="progress" />
                                                                                                                        To
                                                                                                                        <input id="Text8" type="text" style="text-align: left; border: 0; background-color: White"
                                                                                                                            disabled="disabled" class="progress" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20">
                                                                                                                        On
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20" class="lj_hd">
                                                                                                                        <input id="Text9" type="text" style="border: 0; text-align: center; background-color: White"
                                                                                                                            disabled="disabled" class="progress" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td height="20px">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20" class="lj_hdload">
                                                                                                                        <input id="Text10" type="text" style="text-align: right; border: 0; background-color: white;"
                                                                                                                            readonly="readonly" class="progress" />
                                                                                                                        To
                                                                                                                        <input id="Text11" type="text" style="text-align: left; border: 0; background-color: White"
                                                                                                                            disabled="disabled" class="progress" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20">
                                                                                                                        On
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20" class="lj_hdload">
                                                                                                                        <input id="Text12" type="text" style="border: 0; text-align: center; background-color: White"
                                                                                                                            disabled="disabled" class="progress" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="images/l3.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                        <td height="8" width="582">
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
                                                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="3">
                                                </td>
                                                <td width="457" class="lj_banner_bg" align="left" valign="top">
                                                    <iframe src="frame.html" scrolling="no" frameborder="0" width="457" height="372">
                                                    </iframe>
                                                </td>
                                            </tr>
                                        </table>
                                       <%-- <table width="100%">
                                            <tr>
                                                <td height="20">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>--%>
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
                                                                <asp:LinkButton ID="lnkFareDet" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                                <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDet"
                                                                    OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareDetails1">
                                                                </ajax:HoverMenuExtender>
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
                                                                                    <tr runat="server" visible="false">
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
                                                                                    <tr runat="server" visible="false">
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
                                                                                            Trn Chg / Fees
                                                                                        </td>
                                                                                        <td>
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            Rs.
                                                                                            <asp:Label ID="lblTCharge1" runat="server"></asp:Label>
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
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" class="lj_fntbldsze">
                                                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lnkModifySearch" runat="server" Visible="false">Modify Search</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="ModifySearch" runat="server" visible="false">
                                                <td align="center">
                                                    <div id="dvModifySearch" visible="false" runat="server">
                                                        <h3>
                                                            Modify Search</h3>
                                                        <asp:Panel ID="pnlModSearch" runat="server">
                                                        </asp:Panel>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                            </td>
                        </tr>
                        <tr runat="server" id="trFilterSearch" visible="false" valign="top">
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr id="modifyfilter" runat="server">
                                        <td width="25%" valign="top" align="left" id="FilterBlock" runat="server">
                                            <table width="25%" style="border: 0px solid #657600" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3" align="right">
                                                        <img src="images/lb1.png" width="3" height="29" />
                                                    </td>
                                                    <td width="232" class="lj_ms_blu">
                                                        Modify Search
                                                    </td>
                                                    <td width="3">
                                                        <img src="images/lb2.png" width="3" height="29" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" class="lj_ms_bdr" align="center">
                                                        <table width="232" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="center" height="30" class="lj_radionutton">
                                                                    <asp:RadioButton ID="rbonesearch" Text="One Way" runat="server" Checked="true" AutoPostBack="false"
                                                                        GroupName="ONE" OnCheckedChanged="rbonesearch_CheckedChanged" onclick="fnrbtnroundtriponewaymodify();"/>
                                                                </td>
                                                                <td align="center" class="lj_radionutton">
                                                                    <asp:RadioButton ID="rbreturnsearch" Text="Round Trip" runat="server" AutoPostBack="false"
                                                                        GroupName="ONE" OnCheckedChanged="rbreturnsearch_CheckedChanged" onclick="fnrbtnroundtripmodify();"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="8" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="center">
                                                                    <table width="230" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="lj_ms_fr" align="left" height="30">
                                                                                Leaving From
                                                                            </td>
                                                                            <td width="140">
                                                                                <asp:TextBox ID="ddlSourcesSearch" runat="server" ToolTip="Type the first 3 letters of airport or city name"
                                                                                    CssClass="lj_ms_in"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvtxtfromsearch" Display="None" ValidationGroup="SearchInt1"
                                                                                    runat="server" ErrorMessage="Enter Source" ControlToValidate="ddlSourcesSearch"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvtxtfromsearch">
                                                                                </ajax:ValidatorCalloutExtender>
                                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="ddlSourcesSearch"
                                                                                    ServiceMethod="GetAirportCodes1" MinimumPrefixLength="2" CompletionInterval="10"
                                                                                    CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                                    ServicePath="">
                                                                                </ajax:AutoCompleteExtender>
                                                                                
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lj_ms_fr" align="left" height="30">
                                                                                Leaving To
                                                                            </td>
                                                                            <td width="140">
                                                                                <asp:TextBox ID="ddlDestinationsSearch" runat="server" ToolTip="Type the first 3 letters of airport or city name"
                                                                                    CssClass="lj_ms_in"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvtxtleavingtosearch" Display="None" ValidationGroup="SearchInt1"
                                                                                    runat="server" ErrorMessage="Enter Destination" ControlToValidate="ddlDestinationsSearch"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rfvtxtleavingtosearch">
                                                                                </ajax:ValidatorCalloutExtender>
                                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="ddlDestinationsSearch"
                                                                                    ServiceMethod="GetAirportCodes1" MinimumPrefixLength="2" CompletionInterval="10"
                                                                                    CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                                    ServicePath="">
                                                                                </ajax:AutoCompleteExtender>
                                                                                
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lj_ms_fr" align="left" height="30">
                                                                                Departure On
                                                                            </td>
                                                                            <td width="140">
                                                                                <%--    <input type="text" class="lj_ms_in" />--%>
                                                                                <asp:TextBox ID="txtdatesearch" runat="server" CssClass="datepicker" OnClick="showDateInt();" Width="90"
                                                                                    onkeyup="return tabE2(this,event)" onPaste="javascript: return false;" ValidationGroup="Search" />
                                                                                <asp:RequiredFieldValidator ID="rfvtxtdatesearch" runat="server" ControlToValidate="txtdatesearch"
                                                                                    Display="None" ErrorMessage="Enter date." ValidationGroup="SearchInt"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="rfvtxtdatesearch">
                                                                                </ajax:ValidatorCalloutExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                        <td colspan="2" id="return1" runat="server">
                                                                         <%--<div <%--class="lj_outDiv"--%> <%--id="divreturndatemodify"  >--%> 
                                                                        <table>
                                                                        <tr>
                                                                        <td class="lj_ms_fr" align="left" height="30">
                                                                                Return On
                                                                            </td>
                                                                            <td width="155" align="right">
                                                                                <%-- <input type="text" class="lj_ms_in" />--%>
                                                                                <asp:TextBox ID="txtretundatesearch" runat="server" Enabled="true" Width="90" 
                                                                                    OnClick="showDateInt();" onkeyup="return tabE3(this,event)" onPaste="javascript: return false;"
                                                                                    ValidationGroup="SearchInt" Visible="true"  class="datepicker" />
                                                                            </td>
                                                                        </tr>
                                                                        </table>
                                                                       <%-- </div>--%>
                                                                        </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lj_ms_fr" align="left" height="30">
                                                                                Adult
                                                                            </td>
                                                                            <td width="140">
                                                                                <%--  <input type="text" class="lj_ms_in" />--%>
                                                                                <asp:DropDownList ID="ddladultsintsearch" runat="server" CssClass="lj_ms_in" Width="50">
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
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lj_ms_fr" align="left" height="30">
                                                                                Child
                                                                            </td>
                                                                            <td width="140">
                                                                                <%--<input type="text" class="lj_ms_in" />--%>
                                                                                <%--<img src="arzoo_search_files/blk.gif" width="40" height="1">--%>
                                                                                <asp:DropDownList ID="ddlchildintsearch" runat="server" CssClass="lj_ms_in" Width="50">
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
                                                                            <td class="lj_ms_fr" align="left" height="30">
                                                                                Infant
                                                                            </td>
                                                                            <td width="140">
                                                                                <%-- <input type="text" class="lj_ms_in" />--%>
                                                                                <%--<img src="arzoo_search_files/blk.gif" width="55" height="1">--%>
                                                                                <asp:DropDownList ID="ddlinfantsintsearch" runat="server" CssClass="lj_ms_in" Width="50">
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
                                                                            <td class="lj_ms_fr" align="left" height="30">
                                                                                Cabin
                                                                            </td>
                                                                            <td width="140">
                                                                                <%--  <input type="text" class="lj_ms_in" />--%>
                                                                                <asp:DropDownList ID="ddlIntCabinTypesearch" runat="server" CssClass="lj_ms_in">
                                                                                    <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                                                    <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                                                    <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="center">
                                                                                <%--<input type="submit" class="lj_ms_but" value="Check Availability" />--%>
                                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/check-availability-btn.jpg"
                                                                                    Width="159" OnClientClick="return startsearch1();" ValidationGroup="SearchInt"
                                                                                    OnClick="imgsearch_Click" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <span id="mainDiv2" style="display: none" class="loadingBackground"></span><span
                                                            id="contentDiv2" style="display: none" class="modalContainer">
                                                            <div class="registerhead">
                                                                <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: White">
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
                                                                                        <img src="Newimages/New_Logo.png" width="226" height="79" alt="Logo" border="0" title="LoveJourney" />
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
                                                                                        <img src="images/loading14.gif" width="37" height="36" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" class="almost12" height="20">
                                                                                        Searching for Flights
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20">
                                                                                        <input id="Text4" type="text" style="border: 0px; text-align: right; background-color: White;"
                                                                                            disabled="disabled" class="progress" />
                                                                                        &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                        <input id="Text5" type="text" style="border: 0; text-align: left; background-color: White"
                                                                                            disabled="disabled" class="progress" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20">
                                                                                        On
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20">
                                                                                        <input id="Text6" type="text" style="border: 0; text-align: center; background-color: White;"
                                                                                            class="progress" disabled="disabled" />
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
                                                        <%--  rajini--%>
                                                        <span id="mainDiv4" style="display: none" class="loadingBackground"></span><span
                                                            id="contentDiv4" style="display: none" class="modalContainer">
                                                            <div class="registerhead">
                                                                <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: White">
                                                                    <tr>
                                                                        <td width="9" height="8">
                                                                            <img src="images/l1.png" width="9" height="8" />
                                                                        </td>
                                                                        <td height="8" width="582">
                                                                        </td>
                                                                        <td width="9" height="8">
                                                                            <img src="images/l2.png" width="9" height="8" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" align="center" valign="top">
                                                                            <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td align="center" height="25" valign="top">
                                                                                        <img src="Newimages/New_Logo.png" width="226" height="79" alt="Logo" border="0" title="LoveJourney" />
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
                                                                                        <img src="images/loading14.gif" width="37" height="36" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" class="almost12" height="20">
                                                                                        Searching for Flights
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20" class="lj_hd">
                                                                                        <input id="Text13" type="text" style="text-align: right; border: 0; background-color: white;"
                                                                                            readonly="readonly" class="progress" />
                                                                                        &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                        <input id="Text14" type="text" style="border: 0; background-color: White" disabled="disabled"
                                                                                            class="progress" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20">
                                                                                        On
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20" class="lj_hd">
                                                                                        <input id="Text15" type="text" style="border: 0; text-align: center; background-color: White"
                                                                                            disabled="disabled" class="progress" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="20px">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20" class="lj_hd">
                                                                                        <input id="Text16" type="text" style="text-align: right; border: 0; background-color: white;"
                                                                                            readonly="readonly" class="progress" />
                                                                                        &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                        <input id="Text17" type="text" style="border: 0; background-color: White" disabled="disabled"
                                                                                            class="progress" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20">
                                                                                        On
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" height="20" class="lj_hd">
                                                                                        <input id="Text18" type="text" style="border: 0; text-align: center; background-color: White"
                                                                                            disabled="disabled" class="progress" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="9" height="8">
                                                                            <img src="images/l3.png" width="9" height="8" />
                                                                        </td>
                                                                        <td height="8" width="582">
                                                                        </td>
                                                                        <td width="9" height="8">
                                                                            <img src="images/l4.png" width="9" height="8" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </span>
                                                        <%--  rajini--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="7">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                                        <td  align="center" style="font-size:medium;border-bottom-color: Black; " bgcolor="#f1f1f1">
                                                            Filter Your Search
                                                        </td>
                                                    </tr>--%>
                                                <tr>
                                                    <td colspan="3" id="trfiltersearch1" runat="server">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="3" align="right">
                                                                    <img src="images/lb1.png" width="3" height="29" />
                                                                </td>
                                                                <td width="232" class="lj_ms_blu">
                                                                    Filter Your Search
                                                                </td>
                                                                <td width="3">
                                                                    <img src="images/lb2.png" width="3" height="29" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" width="100%" class="lj_ms_bdr" colspan="3">
                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td align="left" style="border-bottom: 1px solid #f1f1f1; height: 30px" valign="top">
                                                                                <span style="font-size: 14px; padding-left: 10px;">Price</span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="20%">
                                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td width="50%">
                                                                                            <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lbl11" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="20%">
                                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr valign="middle">
                                                                                        <td valign="top" width="15%" style="border-bottom: 0px;">
                                                                                            <asp:TextBox ID="sliderTwo" runat="server" OnTextChanged="sliderTwo_TextChanged"
                                                                                                AutoPostBack="true" />
                                                                                            <ajax:MultiHandleSliderExtender ID="multiHandleSliderExtenderTwo" runat="server"
                                                                                                BehaviorID="multiHandleSliderExtenderTwo" TargetControlID="sliderTwo" Increment="10"
                                                                                                Length="175" Orientation="Horizontal" EnableHandleAnimation="true" EnableKeyboard="false"
                                                                                                EnableMouseWheel="false" EnableRailClick="false" ShowHandleDragStyle="true" ShowHandleHoverStyle="true"
                                                                                                ShowInnerRail="true" OnClientDragEnd="ValueChangedHandler">
                                                                                                <MultiHandleSliderTargets>
                                                                                                    <ajax:MultiHandleSliderTarget ControlID="HiddenField1" />
                                                                                                    <ajax:MultiHandleSliderTarget ControlID="HiddenField2" />
                                                                                                </MultiHandleSliderTargets>
                                                                                            </ajax:MultiHandleSliderExtender>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border-bottom: 0px;">
                                                                                            <br />
                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span id="minPriceLbl" runat="server" class="runtext">
                                                                                            </span>Rs
                                                                                            <asp:HiddenField ID="HiddenField1" runat="server" OnValueChanged="filter" />
                                                                                            &nbsp; &nbsp;-&nbsp;&nbsp; <span id="maxPriceLbl" runat="server" class="runtext">
                                                                                            </span>Rs
                                                                                            <asp:HiddenField ID="HiddenField2" runat="server" OnValueChanged="filter" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border-bottom: 1px solid #657600">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="stops2">
                                                                                        <td style="border-bottom: 1px solid #f1f1f1; height: 30px;" valign="top" align="left">
                                                                                            <span style="font-size: 15px; padding-left: 10px;">Stops</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="stops" runat="server">
                                                                                        <td style="padding-left: 10px;">
                                                                                            <asp:CheckBoxList ID="ChkStops" AutoPostBack="true" runat="server" OnSelectedIndexChanged="filter">
                                                                                            </asp:CheckBoxList>
                                                                                            <%--<asp:CheckBox ID="chkstop0" runat="server" Text="Zero" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />
                                                                        <asp:CheckBox ID="Chkstop1" runat="server" Text="One" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />
                                                                        <asp:CheckBox ID="Chkstop2" runat="server" Text="Two" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border-bottom: 1px solid #657600">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border-bottom: 1px solid #f1f1f1; height: 30px;" valign="top" align="left">
                                                                                            <span style="font-size: 15px; padding-left: 10px;">Airlines</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding-left: 10px;">
                                                                                            <asp:CheckBoxList ID="chkAirlines" AutoPostBack="true" runat="server" OnSelectedIndexChanged="filter">
                                                                                            </asp:CheckBoxList>
                                                                                            <%--  <asp:CheckBox ID="chkjetlite" runat="server" Text="JetLite" AutoPostBack="true" OnCheckedChanged="filter" /><br />
                                                                        <asp:CheckBox ID="chkJetAirways" runat="server" Text="Jet Airways" AutoPostBack="true"
                                                                            OnCheckedChanged="filter" /><br />
                                                                        <asp:CheckBox ID="chkAirIndia" runat="server" Text="Air India" AutoPostBack="true"
                                                                            OnCheckedChanged="filter" />--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border-bottom: 1px solid #657600">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 10px;">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnResetFilters" runat="server" Text="Reset Filters" CssClass="buttonBook"
                                                                                    OnClick="btnResetFilters_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 10px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="left" valign="top" runat="server" id="Oneway">
                                            <table width="100%">
                                                <tr>
                                                    <td align="right">
                                                        <asp:LinkButton ID="lnkSNFFare" runat="server" OnClientClick="return showHNF();">SNF</asp:LinkButton>
                                                       
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td width="25%">
                                                        &nbsp;
                                                    </td>
                                                    <td width="25%">
                                                        <asp:LinkButton ID="lnkDepart" runat="server" Text="Depart" ToolTip="ASC" OnClick="lnkDepart_Click" style="font-size:18px;font-family:Arial;color:#0092EC;"></asp:LinkButton>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:LinkButton ID="lnkarrives" runat="server" Text="Arrives" ToolTip="ASC" OnClick="lnkarrives_Click" style="font-size:18px;font-family:Arial;color:#0092EC;"></asp:LinkButton>
                                                    </td>
                                                     <td width="22%" align="right">
                                                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Duration" ToolTip="ASC"  style="font-size:18px;font-family:Arial;color:#0092EC;"></asp:LinkButton>
                                                    </td>
                                                    <td width="20%" align="center">
                                                        <asp:LinkButton ID="lnkfare" runat="server" Text="Fare" ToolTip="ASC" OnClick="lnkfare_Click"  style="font-size:18px;font-family:Arial;color:#0092EC;"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:GridView ID="gdvFlights" Width="100%" runat="server" AutoGenerateColumns="false"
                                                ShowHeader="false" AllowSorting="true" GridLines="Horizontal" OnRowDataBound="gdvFlights_RowDataBound"
                                                CellPadding="1" CellSpacing="0" OnRowCommand="gdvFlights_RowCommand" OnSorting="gdvFlights_Sorting"
                                                OnPageIndexChanging="gdvFlights_PageIndexChanging" >
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFlightSegments_ID" runat="server" Text='<%# Eval("FlightSEgments_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbladulttaxbreakup" runat="server" Text='<%# Eval("adultTaxBreakUp") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAirlineNameMrk" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField ItemStyle-Width="93%">
                                                        <ItemTemplate>
                                                            <asp:GridView GridLines="None" ID="gdvconnectingflights" CellPadding="1" CellSpacing="0"
                                                                OnRowDataBound="gdvconnectingflights_RowDataBound" runat="server" AutoGenerateColumns="false"
                                                                Width="93%" CssClass="gridLines">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("imageFileName") %>'  />
                                                                            <br />
                                                                             <asp:Label ID="lblrph" runat="server" Text='<%# Eval("RPH") %>' ForeColor="Brown"></asp:Label><br />

                                                                             <asp:Label ID="lblAirlineName" runat="server" Text='<%# Eval("airLineName") %>' style="font-weight:bold;font-size:12px;font-family:Arial;"></asp:Label>-
                                                                            <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField  HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="20%"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblConnectingAirportCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblHyphen" runat="server" Text="-" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField  HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="28%"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="28%" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>' style="font-weight:bold;font-size:16px;"></asp:Label><br />
                                                                            <asp:Label ID="lbldepartdate" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                                            <br />
                                                                            <asp:Label ID="lblDepartureAirportCode" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField  HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="28%"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="28%" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>' style="font-weight:bold;font-size:16px;"></asp:Label>
                                                                            <br />
                                                                            <asp:Label ID="lblarrivaldate" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                            <br />
                                                                            <asp:Label ID="lblArrivalAirportCode" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField  HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="10%"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblduration" runat="server" Font-Bold="true"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNoofstops" runat="server" Text='<%# Eval("StopQuantity") %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblviaflight" runat="server" Font-Bold="true" Text='<%# Eval("viaFlight") %>'
                                                                                Visible="false"></asp:Label>
                                                                            <ajax:HoverMenuExtender ID="hme1" runat="server" TargetControlID="lnkNoofstops" OffsetX="10"
                                                                                PopupPosition="Left" OffsetY="20" PopupControlID="pnlstops">
                                                                            </ajax:HoverMenuExtender>
                                                                            <asp:Panel ID="pnlstops" runat="server" Style="display: none; background-color: White;
                                                                                border: 1px Solid">
                                                                                <table width="300">
                                                                                    <tr>
                                                                                        <th>
                                                                                            Flight
                                                                                        </th>
                                                                                        <th>
                                                                                            Departure
                                                                                        </th>
                                                                                        <th>
                                                                                            Arrival
                                                                                        </th>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblStartFlight" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblstartDepart" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblstopArrival" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblStartFlight1" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblstartDepart1" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblstopArrival1" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFare" runat="server" CssClass="lj_fare" Text='<%# Eval("Fare") %>'></asp:Label>
                                                            <br />
                                                              <asp:Label ID="lblHNFFare" runat="server" Font-Bold="true" Style="display: none;" ></asp:Label><br />
                                                                <asp:Label ID="lblagentcomm1" runat="server" Font-Bold="true" Style="display: none;font-weight:bold;font-size:16px;color:#CC006E;" CssClass="clsFind" ></asp:Label>

                                                            <br />
                                                            <asp:Button ID="btnBookNow" runat="server" CssClass="buttonBook" Text="Book Now"
                                                                OnClick="btnBookNow_Click" CommandName="BoolTicket" CommandArgument='<%# Eval("FlightSegment_ID") %>' />
                                                            <br />
                                                            <asp:LinkButton ID="lnkFareDetails" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                            <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                OffsetX="30" PopupPosition="Left" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                            </ajax:HoverMenuExtender>
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
                                                                                <tr id="trscharge" runat="server" visible="false">
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
                                                                                <tr id="Tr2" runat="server" visible="false">
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
                                                                                        Trn Chg / Fees
                                                                                    </td>
                                                                                    <td>
                                                                                        :
                                                                                    </td>
                                                                                    <td>
                                                                                        Rs.
                                                                                        <asp:Label ID="lblTCharge" runat="server"></asp:Label>
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
                                                                                        <asp:Label ID="lbladultone" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblchildone" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblinfantone" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblTripone" runat="server" Visible="false"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Airline" SortExpression="airLineName">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbnAirline" AutoPostBack="true" runat="server" OnCheckedChanged="rbnAirline_CheckedChanged"
                                                                Visible="false" />
                                                            <asp:Label ID="lblAirlineName" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                            -
                                                            <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label><br />
                                                            <asp:Label ID="lblConnectingFlights" runat="server" Text="Connecting Flights.."></asp:Label><br />
                                                            <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("imageFileName") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%-- <asp:TemplateField HeaderText="Destinations" SortExpression="DepartureAirportCode">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartureAirportCode" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>
                                                            -
                                                            <asp:Label ID="lblConnectingAirportCode" runat="server" Text="" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblHyphen" runat="server" Text="-" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblArrivalAirportCode" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderText="Departs" SortExpression="DepartureDateTime">
                                                        <ItemTemplate>
                                                          
                                                            <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label><br />
                                                            <asp:Label ID="lbldepartdate" runat="server" Visible="false" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                            <asp:LinkButton ID="lnkFareRule" runat="server" CommandName="ViewRules" CommandArgument='<%# Eval("FlightSegment_ID") %>'>Fare Rules</asp:LinkButton>
                                                            <ajax:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkFareRule"
                                                                OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareRules">
                                                            </ajax:HoverMenuExtender>
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
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderText="Arrives" SortExpression="ArrivalDateTime">
                                                        <ItemTemplate>
                                                           
                                                            <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                            <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderText="Fare" SortExpression="Fare">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFare" runat="server" Text='<%# Eval("Fare") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblHNFFare" runat="server" Font-Bold="true" Style="display: none;"
                                                                CssClass="clsFind"></asp:Label>
                                                            <br />
                                                            <asp:LinkButton ID="lnkFareDetails" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                            <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                            </ajax:HoverMenuExtender>
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
                                                                                <tr id="trscharge" runat="server" visible="false">
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
                                                                                <tr runat="server" visible="false">
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
                                                                                        Trn Chg / Fees
                                                                                    </td>
                                                                                    <td>
                                                                                        :
                                                                                    </td>
                                                                                    <td>
                                                                                        Rs.
                                                                                        <asp:Label ID="lblTCharge" runat="server"></asp:Label>
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
                                                                                        <asp:Label ID="lbladultone" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblchildone" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblinfantone" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblTripone" runat="server" Visible="false"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderText="Duration" HeaderStyle-ForeColor="Blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblduration" runat="server" Font-Bold="true"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderText="No Of Stops" HeaderStyle-ForeColor="Blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstops" runat="server" Font-Bold="true" Text='<%# Eval("StopQuantity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderText="StopPlace" HeaderStyle-ForeColor="Blue" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblviaflight" runat="server" Font-Bold="true" Text='<%# Eval("viaFlight") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnBookNow" runat="server" CssClass="buttonBook" Text="Book Now"
                                                                OnClick="btnBookNow_Click" CommandName="BoolTicket" CommandArgument='<%# Eval("FlightSegment_ID") %>' /><br />
                                                            <asp:LinkButton ID="lnkDetails" runat="server" CommandName="View Details" CommandArgument='<%# Eval("FlightSegment_ID") %>'
                                                                OnClick="lnkDummy_Click">Details</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                                <AlternatingRowStyle CssClass="gridAlter" />
                                                <RowStyle CssClass="gridAlter" />
                                                <%-- <HeaderStyle BackColor="LightBlue" />--%>
                                            </asp:GridView>
                                            <asp:LinkButton ID="lnkDummy" runat="server" Style="display: none" CausesValidation="false"></asp:LinkButton>
                                            <ajax:ModalPopupExtender ID="mpeAirlineDet" runat="server" PopupControlID="pnlAirlineDetails"
                                                TargetControlID="lnkDummy" X="350" Y="250" BackgroundCssClass="modalBackground"
                                                OkControlID="btnok">
                                            </ajax:ModalPopupExtender>
                                            <asp:Panel ID="pnlAirlineDetails" runat="server" Style="position: fixed; top: 0px;
                                                left: 0px; display: none; border: background:url(images/overlay1.png); width: 600;
                                                height: 200; padding-top: 10px; text-align: center; z-index: 1; padding-left: 10px;
                                                padding-right: 10px; padding-right: 10px" align="center">
                                                <table width="600" bgcolor="#eefaff" style="border: #222 5px solid;" height="100">
                                                    <tr>
                                                        <th>
                                                            Image
                                                        </th>
                                                        <th>
                                                            Airline Name
                                                        </th>
                                                        <th>
                                                            Departs
                                                        </th>
                                                        <th>
                                                            Arrival
                                                        </th>
                                                        <th>
                                                            Duration
                                                        </th>
                                                        <th>
                                                            Stops
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Image ID="imgDet" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAirlineNameDet" runat="server"></asp:Label><br />
                                                            <asp:Label ID="lblFlightNumberDet" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDepartureAirportNameDet" runat="server"></asp:Label><br />
                                                            <asp:Label ID="lblDepartureDateTimeDet" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblArrivalAirportNameDet" runat="server"></asp:Label><br />
                                                            <asp:Label ID="lblArrivalDateTimeDet" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblduration1" runat="server"></asp:Label><br />
                                                            <asp:Label ID="lblduratindetails" runat="server"></asp:Label><br />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lnkNoofstops" runat="server"></asp:Label>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <%--  <ajax:HoverMenuExtender ID="hme1" runat="server" TargetControlID="lnkNoofstops" OffsetX="10"
                                                                            PopupPosition="Right" OffsetY="20" PopupControlID="pnlstops">
                                                                        </ajax:HoverMenuExtender>
                                                                        <asp:Panel ID="pnlstops" runat="server" Style="display: none; background-color: White;
                                                                            border: 1px Solid">
                                                                            <table width="300">
                                                                                <tr>
                                                                                    <th>
                                                                                        Flight
                                                                                    </th>
                                                                                    <th>
                                                                                        Departure
                                                                                    </th>
                                                                                    <th>
                                                                                        Arrival
                                                                                    </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblStartFlight" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblstartDepart" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblstopArrival" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblStartFlight1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblstartDepart1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblstopArrival1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trConnecting" visible="false">
                                                        <td align="left">
                                                            <asp:Image ID="imgDet1" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAirlineNameDet1" runat="server"></asp:Label><br />
                                                            <asp:Label ID="lblFlightNumberDet1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDepartureAirportNameDet1" runat="server"></asp:Label><br />
                                                            <asp:Label ID="lblDepartureDateTimeDet1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblArrivalAirportNameDet1" runat="server"></asp:Label><br />
                                                            <asp:Label ID="lblArrivalDateTimeDet1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblduration2" runat="server"></asp:Label><br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trlayovertime" visible="false">
                                                        <td align="right" colspan="5">
                                                            <asp:Label ID="lbllayover" runat="server" Text="LayOver Time : "></asp:Label>&nbsp;
                                                            <asp:Label ID="lbllayovertime" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="6">
                                                            <asp:Button ID="btnok" runat="server" Text="Ok" CssClass="buttonBook" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td valign="top" id="round" runat="server">
                                            <table width="100%">
                                                <tr id="Tr1" runat="server">
                                                    <td valign="top">
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
                                                                                <asp:LinkButton ID="lnkOnwardFareDetails" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                                                <ajax:HoverMenuExtender ID="HoverMenuExtender3" runat="server" TargetControlID="lnkOnwardFareDetails"
                                                                                    OffsetX="30" PopupPosition="Left" OffsetY="-100" PopupControlID="pnlOnwardFareDetails1">
                                                                                </ajax:HoverMenuExtender>
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
                                                                                                    <tr runat="server" visible="false">
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
                                                                                                    <tr runat="server" visible="false">
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
                                                                                                            Trn Chg / Fees
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            Rs.
                                                                                                            <asp:Label ID="lblonwardTChargeRet1" runat="server"></asp:Label>
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
                                                                                <asp:LinkButton ID="lnkReturnFareDetails" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                                                <ajax:HoverMenuExtender ID="HoverMenuExtender4" runat="server" TargetControlID="lnkReturnFareDetails"
                                                                                    OffsetX="30" PopupPosition="Left" OffsetY="-100" PopupControlID="pnlReturnFareDetails">
                                                                                </ajax:HoverMenuExtender>
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
                                                                                                    <tr runat="server" visible="false">
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
                                                                                                    <tr runat="server" visible="false">
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
                                                                                                            Trn Chg / Fees
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            Rs.
                                                                                                            <asp:Label ID="lblTChargeRet2" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="lblTotalFare" runat="server" Text="Total Fare : " Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblTotalOnwardReturn" runat="server" Text=""></asp:Label>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:Button ID="btnRoundTripBook" CssClass="buttonBook" runat="server" Text="Book"
                                                                        Visible="false" CommandName="submit" OnClick="btnRoundTripBook_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trroundTrip">
                                                    <td width="100%" valign="top">
                                                        <table runat="server" width="100%" id="tblRoundTrip">
                                                            <tr>
                                                                <td align="center" class="lj_hd">
                                                                    <asp:Label ID="lblOnwardDepartureAirportCode" runat="server" Text=""></asp:Label>
                                                                    &nbsp;<asp:Label ID="lblOnwardTO" runat="server" Text="TO" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblOnwardArrivalAirportCode" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td align="center" class="lj_hd">
                                                                    <asp:Label ID="lblReturnDepartureAirportCode" runat="server" Text=""></asp:Label>
                                                                    &nbsp;<asp:Label ID="lblReturnTO" runat="server" Text="TO" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblReturnArrivalAirportCode" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="right">
                                                                    <asp:LinkButton ID="lnkSNFFareroundtrip" runat="server" OnClientClick="return showHNFRoundtrip();">SNF</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                            <td>
                                                            <table width="100%">
                                                            <tr>
                                                             <td width="17%">
                                                        &nbsp;
                                                    </td>
                                                    <td width="20%">
                                                        <asp:LinkButton ID="lnkDepartonward" runat="server" Text="Depart" ToolTip="ASC" OnClick="lnkDepartonward_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:LinkButton ID="lnkarrivesonward" runat="server" Text="Arrives" ToolTip="ASC" OnClick="lnkarrivesonward_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="35%" align="right">
                                                        <asp:LinkButton ID="lnkfareonward" runat="server" Text="Fare" ToolTip="ASC" OnClick="lnkfareonward_Click"></asp:LinkButton>
                                                    </td>
                                                            </tr>
                                                            </table>
                                                            </td>
                                                            <td>
                                                            <table width="100%">
                                                            <tr>
                                                            <td width="17%">
                                                        &nbsp;
                                                    </td>
                                                    <td width="20%">
                                                        <asp:LinkButton ID="lnkDepartreturn" runat="server" Text="Depart" ToolTip="ASC" OnClick="lnkDepartreturn_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:LinkButton ID="lnkarrivesreturn" runat="server" Text="Arrives" ToolTip="ASC" OnClick="lnkarrivesreturn_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="35%" align="right">
                                                        <asp:LinkButton ID="lnkfarereturn" runat="server" Text="Fare" ToolTip="ASC" OnClick="lnkfarereturn_Click"></asp:LinkButton>
                                                    </td>
                                                            </tr>
                                                            </table>
                                                            </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" valign="top">
                                                                    <asp:GridView ID="gdvOnward" Width="100%" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                                                        GridLines="Horizontal" EmptyDataText="No Flights" EditRowStyle-Width="500" OnRowDataBound="gdvOnward_RowDataBound">
                                                                        <Columns>
                                                                        <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                         <asp:RadioButton ID="rbnAirline" AutoPostBack="true" GroupName="two" runat="server"
                                                                                                        OnCheckedChanged="rbnAirlineonward_CheckedChanged" />
                                                                        </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            <asp:TemplateField Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFlightSegments_ID" runat="server" Text='<%# Eval("FlightSEgments_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbladulttaxbreakup" runat="server" Text='<%# Eval("adultTaxBreakUp") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="93%">
                                                                                <ItemTemplate>
                                                                                    <asp:GridView GridLines="None" ID="gdvonwardconflights" CellPadding="1" CellSpacing="0"
                                                                                        runat="server" OnRowDataBound="gdvonwardconflights_RowDataBound" AutoGenerateColumns="false" Width="93%" CssClass="gridLines">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%"
                                                                                                HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                   
                                                                                                    <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("imageFileName") %>' /><br />
                                                                                                     <asp:Label ID="lblAirlineName" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                                                                    <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                             <asp:TemplateField Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAirlineNameonwardMrk" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                                            <%--<asp:TemplateField HeaderText="Airline" HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="20%"
                                                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                   
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>--%>
                                                                                            <asp:TemplateField Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblConnectingAirportCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="lblHyphen" runat="server" Text="-" Visible="false"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Departs" HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="24%"
                                                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="24%" HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label><br />
                                                                                                    <asp:Label ID="lbldepartdate" runat="server"  Text='<%# Eval("DepartureDateTime") %>' Visible="false"></asp:Label>
                                                                                                    <br />
                                                                                                    <asp:Label ID="lblDepartureAirportCode" runat="server" Text='<%# Eval("DepartureAirportCode") %>' CssClass="lj_cityname" Visible="false"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Arrival" HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="24%"
                                                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="24%" HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                                    <br />
                                                                                                    <asp:Label ID="lblarrivaldate" runat="server"  Text='<%# Eval("ArrivalDateTime") %>' Visible="false"></asp:Label>
                                                                                                    <br />
                                                                                                    <asp:Label ID="lblArrivalAirportCode" runat="server" Text='<%# Eval("ArrivalAirportCode") %>' CssClass="lj_cityname" Visible="false"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="10%"
                                                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblduration" runat="server" Font-Bold="true"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkNoofstops" runat="server" Text='<%# Eval("StopQuantity") %>'></asp:LinkButton>
                                                                                                    <asp:Label ID="lblviaflight" runat="server" Font-Bold="true" Text='<%# Eval("viaFlight") %>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <ajax:HoverMenuExtender ID="hme1" runat="server" TargetControlID="lnkNoofstops" OffsetX="10"
                                                                                                        PopupPosition="Left" OffsetY="20" PopupControlID="pnlstops">
                                                                                                    </ajax:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlstops" runat="server" Style="display: none; background-color: White;
                                                                                                        border: 1px Solid">
                                                                                                        <table width="300">
                                                                                                            <tr>
                                                                                                                <th>
                                                                                                                    Flight
                                                                                                                </th>
                                                                                                                <th>
                                                                                                                    Departure
                                                                                                                </th>
                                                                                                                <th>
                                                                                                                    Arrival
                                                                                                                </th>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblStartFlight" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblstartDepart" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblstopArrival" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblStartFlight1" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblstartDepart1" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblstopArrival1" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFare" CssClass="lj_fare" runat="server"></asp:Label><br />
                                                                                      
                                                                               <asp:Label ID="lblHNFFareonward" Style="display: none;font-weight:bold;font-size:16px;color:#CC006E;" CssClass="clsFind" runat="server" Font-Bold="true"
                                                                                        ></asp:Label><br />

                                                                                         <asp:Label ID="lblAgentcommonward" Style="display: none;" runat="server" Font-Bold="true"
                                                                                        CssClass="clsFind"></asp:Label>



                                                                                    <br />
                                                                                 
                                                                                    <asp:LinkButton ID="lnkFareDetails" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                                                    <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                                        OffsetX="30" PopupPosition="Left" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                                                    </ajax:HoverMenuExtender>
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
                                                                                                        <tr id="Tr3" runat="server" visible="false">
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
                                                                                                        <tr id="Tr4" runat="server" visible="false">
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
                                                                                                                Trn Chg / Fees
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblTChargeRet3" runat="server"></asp:Label>
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
                                                                                                                <asp:Label ID="lbladultone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblchildone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblinfantone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblTripone" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                    <br />
                                                                                     <asp:LinkButton ID="lnkFareRule" runat="server" CommandName="ViewRules" CommandArgument='<%# Eval("FlightSegment_ID") %>'>Fare Rules</asp:LinkButton>
                                                                                    <ajax:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkFareRule"
                                                                                        OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareRules">
                                                                                    </ajax:HoverMenuExtender>
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
                                                                            <%-- <asp:TemplateField HeaderText="Airline">
                                                                                <ItemTemplate>
                                                                                    <asp:RadioButton ID="rbnAirline" AutoPostBack="true" GroupName="two" runat="server"
                                                                                        OnCheckedChanged="rbnAirlineonward_CheckedChanged" />
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
                                                                                  
                                                                                    <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label><br />
                                                                                    <asp:Label ID="lbldepartdate" runat="server" Visible="false" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                                                    <asp:LinkButton ID="lnkFareRule" runat="server" CommandName="ViewRules" CommandArgument='<%# Eval("FlightSegment_ID") %>'>Fare Rules</asp:LinkButton>
                                                                                    <ajax:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkFareRule"
                                                                                        OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareRules">
                                                                                    </ajax:HoverMenuExtender>
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
                                                                                  
                                                                                    <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                    <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Fare">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFare" runat="server"></asp:Label>
                                                                                    <br />
                                                                                    <asp:Label ID="lblHNFFareonward" Style="display: none;" runat="server" Font-Bold="true"
                                                                                        CssClass="clsFind"></asp:Label>
                                                                                    <br />
                                                                                    <asp:LinkButton ID="lnkFareDetails" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                                                    <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                                        OffsetX="30" PopupPosition="Right" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                                                    </ajax:HoverMenuExtender>
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
                                                                                                        <tr runat="server" visible="false">
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
                                                                                                        <tr runat="server" visible="false">
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
                                                                                                                Trn Chg / Fees
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblTChargeRet3" runat="server"></asp:Label>
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
                                                                                                                <asp:Label ID="lbladultone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblchildone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblinfantone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblTripone" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>--%>
                                                                        </Columns>
                                                                        <AlternatingRowStyle CssClass="gridAlter" />
                                                                        <RowStyle CssClass="gridAlter" />
                                                                        <HeaderStyle BackColor="LightBlue" />
                                                                    </asp:GridView>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    <asp:GridView ID="gdvReturn" Width="100%" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                                                        GridLines="Horizontal" OnRowDataBound="gdvReturn_RowDataBound" EmptyDataText="No Flights"
                                                                        EmptyDataRowStyle-Width="90%">
                                                                        <Columns>
                                                                        <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                         <asp:RadioButton ID="rbnAirline" AutoPostBack="true" GroupName="one" runat="server"
                                                                                        OnCheckedChanged="rbnAirlineReturn_CheckedChanged" />
                                                                        </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFlightSegments_ID" runat="server" Text='<%# Eval("FlightSEgments_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbladulttaxbreakup" runat="server" Text='<%# Eval("adultTaxBreakUp") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                               <asp:TemplateField Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAirlineNamereturn" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField ItemStyle-Width="93%">
                                                                                <ItemTemplate>
                                                                                    <asp:GridView GridLines="None" ID="gdvreturnconflights" CellPadding="1" CellSpacing="0"
                                                                                        runat="server" OnRowDataBound="gdvreturnconflights_RowDataBound" AutoGenerateColumns="false" Width="93%" CssClass="gridLines">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%"
                                                                                                HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    
                                                                                                    <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("imageFileName") %>' />
                                                                                                      <asp:Label ID="lblAirlineName" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                                                    <br />
                                                                                    <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label><br />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                           <%-- <asp:TemplateField HeaderText="Airline" HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="20%"
                                                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                   
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>--%>
                                                                                            <asp:TemplateField Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblConnectingAirportCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="lblHyphen" runat="server" Text="-" Visible="false"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Departs" HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="24%"
                                                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="24%" HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label><br />
                                                                                    <asp:Label ID="lbldepartdate" runat="server"  Text='<%# Eval("DepartureDateTime") %>' Visible="false"></asp:Label>
                                                                                                    <br />
                                                                                                    <asp:Label ID="lblDepartureAirportCode" runat="server" Text='<%# Eval("DepartureAirportCode") %>' CssClass="lj_cityname" Visible="false"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Arrival" HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="24%"
                                                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="24%" HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                                    <br />
                                                                                    <asp:Label ID="lblarrivaldate" runat="server"  Text='<%# Eval("ArrivalDateTime") %>' Visible="false"></asp:Label>
                                                                                                    <br />
                                                                                                    <asp:Label ID="lblArrivalAirportCode" runat="server" Text='<%# Eval("ArrivalAirportCode") %>' Visible="false" CssClass="lj_cityname"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="lj_Headerstyle" ItemStyle-Width="10%"
                                                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblduration" runat="server" Font-Bold="true"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkNoofstops" runat="server" Text='<%# Eval("StopQuantity") %>'></asp:LinkButton>
                                                                                                    <asp:Label ID="lblviaflight" runat="server" Font-Bold="true" Text='<%# Eval("viaFlight") %>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <ajax:HoverMenuExtender ID="hme1" runat="server" TargetControlID="lnkNoofstops" OffsetX="10"
                                                                                                        PopupPosition="Left" OffsetY="20" PopupControlID="pnlstops">
                                                                                                    </ajax:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlstops" runat="server" Style="display: none; background-color: White;
                                                                                                        border: 1px Solid">
                                                                                                        <table width="300">
                                                                                                            <tr>
                                                                                                                <th>
                                                                                                                    Flight
                                                                                                                </th>
                                                                                                                <th>
                                                                                                                    Departure
                                                                                                                </th>
                                                                                                                <th>
                                                                                                                    Arrival
                                                                                                                </th>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblStartFlight" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblstartDepart" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblstopArrival" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblStartFlight1" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblstartDepart1" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblstopArrival1" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                   <asp:Label ID="lblFare" runat="server" CssClass="lj_fare"></asp:Label>
                                                                                      <br />
                                                                                   <%-- <asp:Label ID="lblHNFFarereturn" Style="display: none;" runat="server" Font-Bold="true"
                                                                                        CssClass="clsFind"></asp:Label>--%>
                                                                                         <asp:Label ID="lblAgentcommreturn" Style="display: none;font-weight:bold;font-size:16px;color:#CC006E;" CssClass="clsFind" runat="server" Font-Bold="true"
                                                                                       ></asp:Label>
                                                                                    <br />
                                                                                 
                                                                                 <asp:LinkButton ID="lnkFareDetails" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                                                    <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                                        OffsetX="30" PopupPosition="Left" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                                                    </ajax:HoverMenuExtender>
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
                                                                                                        <tr id="Tr5" runat="server" visible="false">
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
                                                                                                        <tr id="Tr6" runat="server" visible="false">
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
                                                                                                                Trn Chg / Fees
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblTChargeRet" runat="server"></asp:Label>
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
                                                                                                                <asp:Label ID="lbladultone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblchildone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblinfantone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblTripone" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                    <br />
                                                                                     <asp:LinkButton ID="lnkFareRule" runat="server" CommandName="ViewRules" CommandArgument='<%# Eval("FlightSegment_ID") %>'>Fare Rules</asp:LinkButton>
                                                                                    <ajax:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkFareRule"
                                                                                        OffsetX="30" PopupPosition="Left" OffsetY="-100" PopupControlID="pnlFareRules">
                                                                                    </ajax:HoverMenuExtender>
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
                                                                          <%--  <asp:TemplateField HeaderText="Airline">
                                                                                <ItemTemplate>
                                                                                    <asp:RadioButton ID="rbnAirline" AutoPostBack="true" GroupName="one" runat="server"
                                                                                        OnCheckedChanged="rbnAirlineReturn_CheckedChanged" />
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
                                                                                    <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label><br />
                                                                                    <asp:Label ID="lbldepartdate" runat="server" Visible="false" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                                                    <asp:LinkButton ID="lnkFareRule" runat="server" CommandName="ViewRules" CommandArgument='<%# Eval("FlightSegment_ID") %>'>Fare Rules</asp:LinkButton>
                                                                                    <ajax:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkFareRule"
                                                                                        OffsetX="30" PopupPosition="Left" OffsetY="-100" PopupControlID="pnlFareRules">
                                                                                    </ajax:HoverMenuExtender>
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
                                                                                    <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                    <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Fare">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFare" runat="server"></asp:Label>
                                                                                    <br />
                                                                                    <asp:Label ID="lblHNFFarereturn" Style="display: none;" runat="server" Font-Bold="true"
                                                                                        CssClass="clsFind"></asp:Label>
                                                                                    <br />
                                                                                    <asp:LinkButton ID="lnkFareDetails" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                                                    <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDetails"
                                                                                        OffsetX="30" PopupPosition="Left" OffsetY="-100" PopupControlID="pnlFareDetails">
                                                                                    </ajax:HoverMenuExtender>
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
                                                                                                        <tr runat="server" visible="false">
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
                                                                                                        <tr runat="server" visible="false">
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
                                                                                                                Trn Chg / Fees
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                :
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                Rs.
                                                                                                                <asp:Label ID="lblTChargeRet" runat="server"></asp:Label>
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
                                                                                                                <asp:Label ID="lbladultone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblchildone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblinfantone" runat="server" Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblTripone" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
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
    <asp:Panel ID="pnlPassengerDet" runat="server" Visible="false" BackColor="White">
        <table width="100%" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
            <tr>
                <td colspan="2" class="lj_fntbldsze">
                    <asp:Label ID="lblRoutetwo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="padding: 5px;">
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
                            <td height="30px">
                                <asp:Label ID="Label1" runat="server" Text="Mobile Number : "></asp:Label>
                                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" onchange="javascript:txttextchanged();"
                                    CssClass="lj_inp"></asp:TextBox>&nbsp; (Will be contacted in case of flight
                                delay etc..)
                                <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                    Display="None" ValidationGroup="SubmitBook" ErrorMessage="Enter Mobile No"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobileNo" runat="server" TargetControlID="rfvtxtMobileNo">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="0123456789"
                                    TargetControlID="txtMobileNo">
                                </ajax:FilteredTextBoxExtender>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                                    ControlToValidate="txtMobileNo" ErrorMessage="Invalid mobile no" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobileNo1" runat="server" TargetControlID="RegularExpressionValidator1">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding: 5px;">
                        <tr>
                            <td colspan="9" bgcolor="#0062af" style="color: White">
                                <b>User Information</b>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                                Title<span style="color: Red;">*</span>
                            </td>
                            <td width="5%" align="center">
                                :
                            </td>
                            <td align="left" height="30px">
                                <asp:DropDownList ID="dlTitle" runat="server" Width="50px" CssClass="lj_inp">
                                    <asp:ListItem Value="Mr" Selected="True">Mr</asp:ListItem>
                                    <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                    <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="15%" style="padding-left: 6px;">
                                First Name<span style="color: Red;">*</span>
                            </td>
                            <td width="5%" align="center">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstname" runat="server" CssClass="lj_inp" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFN" runat="server" ErrorMessage="Enter First Name"
                                    ControlToValidate="txtFirstname" Display="None" ValidationGroup="SubmitBook"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceFirstName" runat="server" TargetControlID="rfvFN">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                    TargetControlID="txtFirstname">
                                </ajax:FilteredTextBoxExtender>
                            </td>
                            <td width="15%" style="padding-left: 6px;">
                                Last Name<span style="color: Red;">*</span>
                            </td>
                            <td width="5%" align="center">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="lj_inp" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Enter Last Name"
                                    Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceLastName" runat="server" TargetControlID="rfvLastName">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                    TargetControlID="txtLastName">
                                </ajax:FilteredTextBoxExtender>
                                <asp:RegularExpressionValidator ID="rexprLastName" runat="server" ControlToValidate="txtLastName"
                                    ErrorMessage="Minimum 2 Characters Required" ValidationExpression="^[\s\S]{2,}$"
                                    Display="None"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceLastName1" runat="server" TargetControlID="rexprLastName">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="15%" valign="top">
                                LandLine No
                            </td>
                            <td align="center" width="15" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="lj_inp" MaxLength="12"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Phone Number" Display="None" ValidationGroup="SubmitBook"
                                                ControlToValidate="txtPhoneNum"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vcePhoneNo" runat="server" TargetControlID="RequiredFieldValidator4"></ajax:ValidatorCalloutExtender>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  Display="None" 
                                                ControlToValidate="txtPhoneNum" ErrorMessage="Invalid Phone no" 
                                                ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
                                            <ajax:ValidatorCalloutExtender ID="vcePhoneNo1" runat="server" TargetControlID="RegularExpressionValidator3"></ajax:ValidatorCalloutExtender>--%>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789"
                                    TargetControlID="txtPhoneNum">
                                </ajax:FilteredTextBoxExtender>
                            </td>
                            <td align="left" width="20%" valign="top" style="padding-left: 6px;">
                                Mobile Number<span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="15" valign="top">
                                :
                            </td>
                            <td align="left" valign="bottom">
                                <asp:TextBox ID="txtMobileNum" runat="server" MaxLength="10" CssClass="lj_inp"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Mobile Number"
                                    Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtMobileNum"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobileNum" runat="server" TargetControlID="RequiredFieldValidator5">
                                </ajax:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="rgfvalidater" runat="server" ControlToValidate="txtMobileNum"
                                    ErrorMessage="Invalid mobile no" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobileNum1" runat="server" TargetControlID="rgfvalidater">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789"
                                    TargetControlID="txtMobileNum">
                                </ajax:FilteredTextBoxExtender>
                            </td>
                            <td align="left" width="15%" valign="top" style="padding-left: 6px;">
                                Email ID<span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="15" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="lj_inp"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Email ID"
                                    Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtEmailID"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceEmail2" runat="server" TargetControlID="RequiredFieldValidator6">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtEmailID"
                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                </ajax:FilteredTextBoxExtender>
                                <asp:RegularExpressionValidator ID="regularmail" runat="server" Display="None" ValidationGroup="SubmitBook"
                                    ControlToValidate="txtEmailID" ErrorMessage="Invalid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceEmail3" runat="server" TargetControlID="regularmail">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%">
                                Confirm Email ID<span style="color: Red;">*</span>
                            </td>
                            <td width="5%" align="center">
                                :
                            </td>
                            <td valign="top" height="30px">
                                <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="lj_inp" onclick="javascript:vtxtEmailId();"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Confirm Email ID"
                                    Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtConfirmEmail"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="RequiredFieldValidator7">
                                </ajax:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="None"
                                    ControlToValidate="txtConfirmEmail" ErrorMessage="Invalid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceEmail4" runat="server" TargetControlID="RegularExpressionValidator2">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtConfirmEmail"
                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                </ajax:FilteredTextBoxExtender>
                                <asp:CompareValidator ID="vlc" runat="server" Display="None" ControlToValidate="txtConfirmEmail"
                                    ErrorMessage="Emailid & Confirm Emailid should be same" ControlToCompare="txtEmailID"
                                    Operator="Equal"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceEmail5" runat="server" TargetControlID="vlc">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="padding: 5px;">
                        <tr>
                            <td colspan="9" bgcolor="#0062af" style="color: White">
                                <b>Address Details</b>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%" align="left">
                                Address<span style="color: Red;">*</span>
                            </td>
                            <td width="5%" align="center">
                                :
                            </td>
                            <td align="left" height="30px">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="lj_inp"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Address"
                                    Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceAddress" runat="server" TargetControlID="RequiredFieldValidator8">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                            <td align="left" width="15%" style="padding-left: 6px;">
                                City / Town<span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="5%">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="lj_inp"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter City"
                                    Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtCity"
                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ">
                                </ajax:FilteredTextBoxExtender>
                                <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="RequiredFieldValidator9">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                            <td align="left" width="15%" style="padding-left: 6px;">
                                State<span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="5%">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtState" runat="server" CssClass="lj_inp"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter State"
                                    Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtState"></asp:RequiredFieldValidator>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtState"
                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ">
                                </ajax:FilteredTextBoxExtender>
                                <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="RequiredFieldValidator10">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%" align="left">
                                Postal Code<span style="color: Red;">*</span>
                            </td>
                            <td width="5%" align="center">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="6" CssClass="lj_inp"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter Postal Code"
                                    ValidationGroup="SubmitBook" Display="None" ControlToValidate="txtPostalCode"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcePincode" runat="server" TargetControlID="RequiredFieldValidator11">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="0123456789"
                                    TargetControlID="txtPostalCode">
                                </ajax:FilteredTextBoxExtender>
                            </td>
                            <td width="15%" style="padding-left: 6px;">
                                Country<span style="color: Red;">*</span>
                            </td>
                            <td width="5%" align="center">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="lj_inp">
                                    <asp:ListItem Value="ABW">Aruba</asp:ListItem>
                                    <asp:ListItem Value="AFG">Afghanistan</asp:ListItem>
                                    <asp:ListItem Value="AGO">Angola</asp:ListItem>
                                    <asp:ListItem Value="AIA">Anguilla</asp:ListItem>
                                    <asp:ListItem Value="ALA">Åland Islands</asp:ListItem>
                                    <asp:ListItem Value="ALB">Albania</asp:ListItem>
                                    <asp:ListItem Value="AND">Andorra</asp:ListItem>
                                    <asp:ListItem Value="ANT">Netherlands Antilles</asp:ListItem>
                                    <asp:ListItem Value="ARE">United Arab Emirates</asp:ListItem>
                                    <asp:ListItem Value="ARG">Argentina</asp:ListItem>
                                    <asp:ListItem Value="ARM">Armenia</asp:ListItem>
                                    <asp:ListItem Value="ASM">American Samoa</asp:ListItem>
                                    <asp:ListItem Value="ATA">Antarctica</asp:ListItem>
                                    <asp:ListItem Value="ATF">French Southern Territories</asp:ListItem>
                                    <asp:ListItem Value="ATG">Antigua and Barbuda</asp:ListItem>
                                    <asp:ListItem Value="AUS">Australia</asp:ListItem>
                                    <asp:ListItem Value="AUT">Austria</asp:ListItem>
                                    <asp:ListItem Value="AZE">Azerbaijan</asp:ListItem>
                                    <asp:ListItem Value="BDI">Burundi</asp:ListItem>
                                    <asp:ListItem Value="BEL">Belgium</asp:ListItem>
                                    <asp:ListItem Value="BEN">Benin</asp:ListItem>
                                    <asp:ListItem Value="BFA">Burkina Faso</asp:ListItem>
                                    <asp:ListItem Value="BGD">Bangladesh</asp:ListItem>
                                    <asp:ListItem Value="BGR">Bulgaria</asp:ListItem>
                                    <asp:ListItem Value="BHR">Bahrain</asp:ListItem>
                                    <asp:ListItem Value="BHS">Bahamas</asp:ListItem>
                                    <asp:ListItem Value="BIH">Bosnia and Herzegovina</asp:ListItem>
                                    <asp:ListItem Value="BLM">Saint Barthélemy</asp:ListItem>
                                    <asp:ListItem Value="BLR">Belarus</asp:ListItem>
                                    <asp:ListItem Value="BLZ">Belize</asp:ListItem>
                                    <asp:ListItem Value="BMU">Bermuda</asp:ListItem>
                                    <asp:ListItem Value="BOL">Bolivia</asp:ListItem>
                                    <asp:ListItem Value="BRA">Brazil</asp:ListItem>
                                    <asp:ListItem Value="BRB">Barbados</asp:ListItem>
                                    <asp:ListItem Value="BRN">Brunei Darussalam</asp:ListItem>
                                    <asp:ListItem Value="BTN">Bhutan</asp:ListItem>
                                    <asp:ListItem Value="BVT">Bouvet Island</asp:ListItem>
                                    <asp:ListItem Value="BWA">Botswana</asp:ListItem>
                                    <asp:ListItem Value="CAF">Central African Republic</asp:ListItem>
                                    <asp:ListItem Value="CAN">Canada</asp:ListItem>
                                    <asp:ListItem Value="CCK">Cocos (Keeling) Islands</asp:ListItem>
                                    <asp:ListItem Value="CHE">Switzerland</asp:ListItem>
                                    <asp:ListItem Value="CHL">Chile</asp:ListItem>
                                    <asp:ListItem Value="CHN">China</asp:ListItem>
                                    <asp:ListItem Value="CIV">Côte d`Ivoire</asp:ListItem>
                                    <asp:ListItem Value="CMR">Cameroon</asp:ListItem>
                                    <asp:ListItem Value="COD">Congo, the Democratic Republic of the</asp:ListItem>
                                    <asp:ListItem Value="COG">Congo</asp:ListItem>
                                    <asp:ListItem Value="COK">Cook Islands</asp:ListItem>
                                    <asp:ListItem Value="COL">Colombia</asp:ListItem>
                                    <asp:ListItem Value="COM">Comoros</asp:ListItem>
                                    <asp:ListItem Value="CPV">Cape Verde</asp:ListItem>
                                    <asp:ListItem Value="CRI">Costa Rica</asp:ListItem>
                                    <asp:ListItem Value="CUB">Cuba</asp:ListItem>
                                    <asp:ListItem Value="CXR">Christmas Island</asp:ListItem>
                                    <asp:ListItem Value="CYM">Cayman Islands</asp:ListItem>
                                    <asp:ListItem Value="CYP">Cyprus</asp:ListItem>
                                    <asp:ListItem Value="CZE">Czech Republic</asp:ListItem>
                                    <asp:ListItem Value="DEU">Germany</asp:ListItem>
                                    <asp:ListItem Value="DJI">Djibouti</asp:ListItem>
                                    <asp:ListItem Value="DMA">Dominica</asp:ListItem>
                                    <asp:ListItem Value="DNK">Denmark</asp:ListItem>
                                    <asp:ListItem Value="DOM">Dominican Republic</asp:ListItem>
                                    <asp:ListItem Value="DZA">Algeria</asp:ListItem>
                                    <asp:ListItem Value="ECU">Ecuador</asp:ListItem>
                                    <asp:ListItem Value="EGY">Egypt</asp:ListItem>
                                    <asp:ListItem Value="ERI">Eritrea</asp:ListItem>
                                    <asp:ListItem Value="ESH">Western Sahara</asp:ListItem>
                                    <asp:ListItem Value="ESP">Spain</asp:ListItem>
                                    <asp:ListItem Value="EST">Estonia</asp:ListItem>
                                    <asp:ListItem Value="ETH">Ethiopia</asp:ListItem>
                                    <asp:ListItem Value="FIN">Finland</asp:ListItem>
                                    <asp:ListItem Value="FJI">Fiji</asp:ListItem>
                                    <asp:ListItem Value="FLK">Falkland Islands (Malvinas)</asp:ListItem>
                                    <asp:ListItem Value="FRA">France</asp:ListItem>
                                    <asp:ListItem Value="FRO">Faroe Islands</asp:ListItem>
                                    <asp:ListItem Value="FSM">Micronesia, Federated States of</asp:ListItem>
                                    <asp:ListItem Value="GAB">Gabon</asp:ListItem>
                                    <asp:ListItem Value="GBR">United Kingdom</asp:ListItem>
                                    <asp:ListItem Value="GEO">Georgia</asp:ListItem>
                                    <asp:ListItem Value="GGY">Guernsey</asp:ListItem>
                                    <asp:ListItem Value="GHA">Ghana</asp:ListItem>
                                    <asp:ListItem Value="GI">N Guinea</asp:ListItem>
                                    <asp:ListItem Value="GIB">Gibraltar</asp:ListItem>
                                    <asp:ListItem Value="GLP">Guadeloupe</asp:ListItem>
                                    <asp:ListItem Value="GMB">Gambia</asp:ListItem>
                                    <asp:ListItem Value="GNB">Guinea-Bissau</asp:ListItem>
                                    <asp:ListItem Value="GNQ">Equatorial Guinea</asp:ListItem>
                                    <asp:ListItem Value="GRC">Greece</asp:ListItem>
                                    <asp:ListItem Value="GRD">Grenada</asp:ListItem>
                                    <asp:ListItem Value="GRL">Greenland</asp:ListItem>
                                    <asp:ListItem Value="GTM">Guatemala</asp:ListItem>
                                    <asp:ListItem Value="GUF">French Guiana</asp:ListItem>
                                    <asp:ListItem Value="GUM">Guam</asp:ListItem>
                                    <asp:ListItem Value="GUY">Guyana</asp:ListItem>
                                    <asp:ListItem Value="HKG">Hong Kong</asp:ListItem>
                                    <asp:ListItem Value="HMD">Heard Island and McDonald Islands</asp:ListItem>
                                    <asp:ListItem Value="HND">Honduras</asp:ListItem>
                                    <asp:ListItem Value="HRV">Croatia</asp:ListItem>
                                    <asp:ListItem Value="HTI">Haiti</asp:ListItem>
                                    <asp:ListItem Value="HUN">Hungary</asp:ListItem>
                                    <asp:ListItem Value="IDN">Indonesia</asp:ListItem>
                                    <asp:ListItem Value="IMN">Isle of Man</asp:ListItem>
                                    <asp:ListItem Value="IND" Selected="True">India</asp:ListItem>
                                    <asp:ListItem Value="IOT">British Indian Ocean Territory</asp:ListItem>
                                    <asp:ListItem Value="IRL">Ireland</asp:ListItem>
                                    <asp:ListItem Value="IRN">Iran, Islamic Republic of</asp:ListItem>
                                    <asp:ListItem Value="IRQ">Iraq</asp:ListItem>
                                    <asp:ListItem Value="ISL">Iceland</asp:ListItem>
                                    <asp:ListItem Value="ISR">Israel</asp:ListItem>
                                    <asp:ListItem Value="ITA">Italy</asp:ListItem>
                                    <asp:ListItem Value="JAM">Jamaica</asp:ListItem>
                                    <asp:ListItem Value="JEY">Jersey</asp:ListItem>
                                    <asp:ListItem Value="JOR">Jordan</asp:ListItem>
                                    <asp:ListItem Value="JPN">Japan</asp:ListItem>
                                    <asp:ListItem Value="KAZ">Kazakhstan</asp:ListItem>
                                    <asp:ListItem Value="KEN">Kenya</asp:ListItem>
                                    <asp:ListItem Value="KGZ">Kyrgyzstan</asp:ListItem>
                                    <asp:ListItem Value="KHM">Cambodia</asp:ListItem>
                                    <asp:ListItem Value="KIR">Kiribati</asp:ListItem>
                                    <asp:ListItem Value="KNA">Saint Kitts and Nevis</asp:ListItem>
                                    <asp:ListItem Value="KOR">Korea, Republic of</asp:ListItem>
                                    <asp:ListItem Value="KWT">Kuwait</asp:ListItem>
                                    <asp:ListItem Value="LAO">Lao People`s Democratic Republic</asp:ListItem>
                                    <asp:ListItem Value="LBN">Lebanon</asp:ListItem>
                                    <asp:ListItem Value="LBR">Liberia</asp:ListItem>
                                    <asp:ListItem Value="LBY">Libyan Arab Jamahiriya</asp:ListItem>
                                    <asp:ListItem Value="LCA">Saint Lucia</asp:ListItem>
                                    <asp:ListItem Value="LIE">Liechtenstein</asp:ListItem>
                                    <asp:ListItem Value="LKA">Sri Lanka</asp:ListItem>
                                    <asp:ListItem Value="LSO">Lesotho</asp:ListItem>
                                    <asp:ListItem Value="LTU">Lithuania</asp:ListItem>
                                    <asp:ListItem Value="LUX">Luxembourg</asp:ListItem>
                                    <asp:ListItem Value="LVA">Latvia</asp:ListItem>
                                    <asp:ListItem Value="MAC">Macao</asp:ListItem>
                                    <asp:ListItem Value="MAF">Saint Martin (French part)</asp:ListItem>
                                    <asp:ListItem Value="MAR">Morocco</asp:ListItem>
                                    <asp:ListItem Value="MCO">Monaco</asp:ListItem>
                                    <asp:ListItem Value="MDA">Moldova</asp:ListItem>
                                    <asp:ListItem Value="MDG">Madagascar</asp:ListItem>
                                    <asp:ListItem Value="MDV">Maldives</asp:ListItem>
                                    <asp:ListItem Value="MEX">Mexico</asp:ListItem>
                                    <asp:ListItem Value="MHL">Marshall Islands</asp:ListItem>
                                    <asp:ListItem Value="MKD">Macedonia, the former Yugoslav Republic of</asp:ListItem>
                                    <asp:ListItem Value="MLI">Mali</asp:ListItem>
                                    <asp:ListItem Value="MLT">Malta</asp:ListItem>
                                    <asp:ListItem Value="MMR">Myanmar</asp:ListItem>
                                    <asp:ListItem Value="MNE">Montenegro</asp:ListItem>
                                    <asp:ListItem Value="MNG">Mongolia</asp:ListItem>
                                    <asp:ListItem Value="MNP">Northern Mariana Islands</asp:ListItem>
                                    <asp:ListItem Value="MOZ">Mozambique</asp:ListItem>
                                    <asp:ListItem Value="MRT">Mauritania</asp:ListItem>
                                    <asp:ListItem Value="MSR">Montserrat</asp:ListItem>
                                    <asp:ListItem Value="MTQ">Martinique</asp:ListItem>
                                    <asp:ListItem Value="MUS">Mauritius</asp:ListItem>
                                    <asp:ListItem Value="MWI">Malawi</asp:ListItem>
                                    <asp:ListItem Value="MYS">Malaysia</asp:ListItem>
                                    <asp:ListItem Value="MYT">Mayotte</asp:ListItem>
                                    <asp:ListItem Value="NAM">Namibia</asp:ListItem>
                                    <asp:ListItem Value="NCL">New Caledonia</asp:ListItem>
                                    <asp:ListItem Value="NER">Niger</asp:ListItem>
                                    <asp:ListItem Value="NFK">Norfolk Island</asp:ListItem>
                                    <asp:ListItem Value="NGA">Nigeria</asp:ListItem>
                                    <asp:ListItem Value="NIC">Nicaragua</asp:ListItem>
                                    <asp:ListItem Value="NO">R Norway</asp:ListItem>
                                    <asp:ListItem Value="NIU">Niue</asp:ListItem>
                                    <asp:ListItem Value="NLD">Netherlands</asp:ListItem>
                                    <asp:ListItem Value="NPL">Nepal</asp:ListItem>
                                    <asp:ListItem Value="NRU">Nauru</asp:ListItem>
                                    <asp:ListItem Value="NZL">New Zealand</asp:ListItem>
                                    <asp:ListItem Value="OMN">Oman</asp:ListItem>
                                    <asp:ListItem Value="PAK">Pakistan</asp:ListItem>
                                    <asp:ListItem Value="PAN">Panama</asp:ListItem>
                                    <asp:ListItem Value="PCN">Pitcairn</asp:ListItem>
                                    <asp:ListItem Value="PER">Peru</asp:ListItem>
                                    <asp:ListItem Value="PHL">Philippines</asp:ListItem>
                                    <asp:ListItem Value="PLW">Palau</asp:ListItem>
                                    <asp:ListItem Value="PNG">Papua New Guinea</asp:ListItem>
                                    <asp:ListItem Value="POL">Poland</asp:ListItem>
                                    <asp:ListItem Value="PRI">Puerto Rico</asp:ListItem>
                                    <asp:ListItem Value="PRK">Korea, Democratic People`s Republic of</asp:ListItem>
                                    <asp:ListItem Value="PRT">Portugal</asp:ListItem>
                                    <asp:ListItem Value="PRY">Paraguay</asp:ListItem>
                                    <asp:ListItem Value="PSE">Palestinian Territory, Occupied</asp:ListItem>
                                    <asp:ListItem Value="PYF">French Polynesia</asp:ListItem>
                                    <asp:ListItem Value="QAT">Qatar</asp:ListItem>
                                    <asp:ListItem Value="REU">Réunion</asp:ListItem>
                                    <asp:ListItem Value="ROU">Romania</asp:ListItem>
                                    <asp:ListItem Value="RUS">Russian Federation</asp:ListItem>
                                    <asp:ListItem Value="RWA">Rwanda</asp:ListItem>
                                    <asp:ListItem Value="SAU">Saudi Arabia</asp:ListItem>
                                    <asp:ListItem Value="SDN">Sudan</asp:ListItem>
                                    <asp:ListItem Value="SEN">Senegal</asp:ListItem>
                                    <asp:ListItem Value="SGP">Singapore</asp:ListItem>
                                    <asp:ListItem Value="SGS">South Georgia and the South Sandwich Islands</asp:ListItem>
                                    <asp:ListItem Value="SHN">Saint Helena</asp:ListItem>
                                    <asp:ListItem Value="SJM">Svalbard and Jan Mayen</asp:ListItem>
                                    <asp:ListItem Value="SLB">Solomon Islands</asp:ListItem>
                                    <asp:ListItem Value="SLE">Sierra Leone</asp:ListItem>
                                    <asp:ListItem Value="SLV">El Salvador</asp:ListItem>
                                    <asp:ListItem Value="SMR">San Marino</asp:ListItem>
                                    <asp:ListItem Value="SOM">Somalia</asp:ListItem>
                                    <asp:ListItem Value="SPM">Saint Pierre and Miquelon</asp:ListItem>
                                    <asp:ListItem Value="SRB">Serbia</asp:ListItem>
                                    <asp:ListItem Value="STP">Sao Tome and Principe</asp:ListItem>
                                    <asp:ListItem Value="SUR">Suriname</asp:ListItem>
                                    <asp:ListItem Value="SVK">Slovakia</asp:ListItem>
                                    <asp:ListItem Value="SVN">Slovenia</asp:ListItem>
                                    <asp:ListItem Value="SWE">Sweden</asp:ListItem>
                                    <asp:ListItem Value="SWZ">Swaziland</asp:ListItem>
                                    <asp:ListItem Value="SYC">Seychelles</asp:ListItem>
                                    <asp:ListItem Value="SYR">Syrian Arab Republic</asp:ListItem>
                                    <asp:ListItem Value="TCA">Turks and Caicos Islands</asp:ListItem>
                                    <asp:ListItem Value="TCD">Chad</asp:ListItem>
                                    <asp:ListItem Value="TGO">Togo</asp:ListItem>
                                    <asp:ListItem Value="THA">Thailand</asp:ListItem>
                                    <asp:ListItem Value="TJK">Tajikistan</asp:ListItem>
                                    <asp:ListItem Value="TKL">Tokelau</asp:ListItem>
                                    <asp:ListItem Value="TKM">Turkmenistan</asp:ListItem>
                                    <asp:ListItem Value="TLS">Timor-Leste</asp:ListItem>
                                    <asp:ListItem Value="TON">Tonga</asp:ListItem>
                                    <asp:ListItem Value="TTO">Trinidad and Tobago</asp:ListItem>
                                    <asp:ListItem Value="TUN">Tunisia</asp:ListItem>
                                    <asp:ListItem Value="TUR">Turkey</asp:ListItem>
                                    <asp:ListItem Value="TUV">Tuvalu</asp:ListItem>
                                    <asp:ListItem Value="TWN">Taiwan, Province of China</asp:ListItem>
                                    <asp:ListItem Value="TZA">Tanzania, United Republic of</asp:ListItem>
                                    <asp:ListItem Value="UGA">Uganda</asp:ListItem>
                                    <asp:ListItem Value="UKR">Ukraine</asp:ListItem>
                                    <asp:ListItem Value="UMI">United States Minor Outlying Islands</asp:ListItem>
                                    <asp:ListItem Value="URY">Uruguay</asp:ListItem>
                                    <asp:ListItem Value="USA">United States</asp:ListItem>
                                    <asp:ListItem Value="UZB">Uzbekistan</asp:ListItem>
                                    <asp:ListItem Value="VAT">Holy See (Vatican City State)</asp:ListItem>
                                    <asp:ListItem Value="VCT">Saint Vincent and the Grenadines</asp:ListItem>
                                    <asp:ListItem Value="VEN">Venezuela</asp:ListItem>
                                    <asp:ListItem Value="VGB">Virgin Islands, British</asp:ListItem>
                                    <asp:ListItem Value="VIR">Virgin Islands, U.S.</asp:ListItem>
                                    <asp:ListItem Value="VNM">Viet Nam</asp:ListItem>
                                    <asp:ListItem Value="VUT">Vanuatu</asp:ListItem>
                                    <asp:ListItem Value="WLF">Wallis and Futuna</asp:ListItem>
                                    <asp:ListItem Value="WSM">Samoa</asp:ListItem>
                                    <asp:ListItem Value="YEM">Yemen</asp:ListItem>
                                    <asp:ListItem Value="ZAF">South Africa</asp:ListItem>
                                    <asp:ListItem Value="ZMB">Zambia</asp:ListItem>
                                    <asp:ListItem Value="ZWE">Zimbabwe</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" Display="None" ErrorMessage="Enter Country"
                                    ValidationGroup="SubmitBook" ControlToValidate="ddlcountry"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCountry" runat="server" TargetControlID="rfvCity">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="padding-left: 5px">
                                <asp:Button ID="btnBook" runat="server" CssClass="buttonBook" Text="Submit" OnClick="btnBook_Click"
                                    ValidationGroup="SubmitBook" />
                                <asp:Button ID="btnRoundTripSubmit" runat="server" CssClass="buttonBook" ValidationGroup="SubmitBook"
                                    Text="Submit" OnClick="btnRoundTripSubmit_Click" />
                                <asp:Button ID="btnBack" runat="server" CssClass="buttonBook" Text="Back" OnClick="btnBack_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="20%" valign="top">
                    <table width="100%">
                        <tr>
                            <td>
                                <ajax:Accordion ID="UserAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
                                    Width="100%" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
                                    FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250"
                                    FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None">
                                    <Panes>
                                        <ajax:AccordionPane ID="AccordionPane2" runat="server">
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
                                        </ajax:AccordionPane>
                                        <ajax:AccordionPane ID="AccordionPane3" runat="server">
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
                                                                <tr runat="server" visible="false">
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
                                                                <tr runat="server" visible="false">
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
                                                                        Trn Chg / Fees
                                                                    </td>
                                                                    <td>
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        Rs.
                                                                        <asp:Label ID="lblTChargeRet5" runat="server"></asp:Label>
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
                                                                        <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>
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
                                                                <tr runat="server" visible="false">
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
                                                                <tr runat="server" visible="false">
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
                                                                        Trn Chg / Fees
                                                                    </td>
                                                                    <td>
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        Rs.
                                                                        <asp:Label ID="lblTChargeRet6" runat="server"></asp:Label>
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
                                        </ajax:AccordionPane>
                                    </Panes>
                                </ajax:Accordion>
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
    <asp:Panel ID="pnlViewticket" runat="server" Visible="false" Width="900">
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr id="downlink" runat="server">
                <td width="900" align="center">
                    <table width="900" align="center">
                        <tr>
                            <td width="523" align="left">
                                <%--<span class="actions">
                                    <asp:LinkButton ID="lbtnback" Text="Back" runat="server" OnClick="lbtnback_Click" /></span>--%>
                            </td>
                            <td width="115" align="right">
                                <span class="actions">
                                    <asp:LinkButton ID="lbtnmail" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />
                                    <asp:LinkButton ID="LinkButton1" Text="Download" runat="server" OnClick="btnExportTOWord_Click" />&nbsp;&nbsp;|&nbsp;&nbsp;
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
                                                    <img src="http://Lovejourney.in/Newimages/New_Logo.png" width="143" height="88" border="0"
                                                        title="Love Journey" />&nbsp;&nbsp;
                                                </td>
                                                <td align="right">
                                                    <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="40" align="left">
                                                                <img src="http://Lovejourney.in/images/call.jpg" width="30" height="30" />
                                                            </td>
                                                            <td align="left">
                                                                <b>(080) 32 56 17 27</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="40" align="left">
                                                                <img src="http://Lovejourney.in/images/messenge.jpg" width="30" height="30" />
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
                                        <asp:Label ID="lblEticket" runat="server" Text="Eticket" Style="padding-left: 200px;"></asp:Label>
                                        <asp:Label ID="lblBookingTimeDate" runat="server" Text="Booking Date:" Style="padding-left: 200px;"></asp:Label>
                                        <asp:Label ID="lblBookingTime" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" style="border: 1px solid; border-color: Blue">
                                            <tr>
                                                <td>
                                                    Your Airline PNR :
                                                    <asp:Label ID="lblAirlinePNR" runat="server"></asp:Label>
                                                </td>
                                                 <td>
                                                   Love Journey Ref no.
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
                                                <%--  <th>
                                                    PNR No
                                                </th>--%>
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
                                                <%-- <td>
                                                    <asp:Label ID="lblPNRNo" runat="server"></asp:Label>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="printroundtrip" runat="server" visible="false">
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblOriginRet" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="lblDestinationRet" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="1" style="border-color: Blue">
                                                        <tr>
                                                            <th align="left">
                                                                Return Airline
                                                            </th>
                                                            <th align="left">
                                                                Return Flight No
                                                            </th>
                                                            <th colspan="2">
                                                                Return Departure Date & Time
                                                            </th>
                                                            <th colspan="2">
                                                                Return Arrival Date & Time
                                                            </th>
                                                            <%--   <th>
                                                   Return PNR No
                                                </th>--%>
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
                                                            <%--   <td>
                                                    <asp:Label ID="lblPNRNoreturn" runat="server"></asp:Label>
                                                </td>--%>
                                                        </tr>
                                                    </table>
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
    <ajax:ModalPopupExtender ID="mp3" runat="server" PopupControlID="pnl" TargetControlID="OpenID1"
        X="350" Y="250" BackgroundCssClass="modalBackground" OkControlID="btnMsg1">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnl" runat="server" Style="position: fixed; top: 0px; left: 0px; display: none;
        border: background:url(images/overlay1.png); width: 200; height: 200; padding-top: 10px;
        text-align: center; z-index: 1;" align="center">
        <table width="500" bgcolor="#eefaff" style="border: #222 5px solid;" height="100">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnMsg1" runat="server" Text="Ok" CssClass="buttonBook" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    </asp:panel>
    <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnl"
        TargetControlID="OpenID1" X="350" Y="250" BackgroundCssClass="modalBackground"
        OkControlID="btnMsg1">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" Style="position: fixed; top: 0px; left: 0px;
        display: none; border: background:url(images/overlay1.png); width: 100; height: 200;
        padding-top: 10px; text-align: center; z-index: 1;" align="center">
        <table width="300" bgcolor="#eefaff" style="border: #222 5px solid;" height="100">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="Button1" runat="server" Text="Ok" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%--    </ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
