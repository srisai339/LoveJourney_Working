<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Flight/MasterPage.master"
    AutoEventWireup="true" CodeFile="frmInternationalAvailablity.aspx.cs" Inherits="Users_Flight_frmInternationalAvailablity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
    function Adddob(obj) {
        //alert('hi');
        obj.value = "";

    }
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
        document.getElementById('<%=txtIntDeptDate.ClientID %>').value = "";

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
        document.getElementById('<%=txtIntReturnDate.ClientID %>').value = "";

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
</script>
    <script type="text/javascript">

        function ValueChangedHandler(sender, args) {


            document.getElementById("ctl00_ContentPlaceHolder1_lbl11").innerHTML = document.getElementById('<%= HiddenField2.ClientID %>').value;

            document.getElementById("lbl").innerHTML = document.getElementById('<%= HiddenField1.ClientID %>').value;

            //  $("#maxPriceLbl").text($('#HiddenField2').val() + ' Rs');
        }
        function txttextchanged() {


            document.getElementById("ctl00_ContentPlaceHolder1_txtFirstnameInt").value = document.getElementById("ctl00_ContentPlaceHolder1_txtFnInt1").value;

            document.getElementById("ctl00_ContentPlaceHolder1_txtLastNameInt").value = document.getElementById("ctl00_ContentPlaceHolder1_txtLnInt1").value;

            document.getElementById("ctl00_ContentPlaceHolder1_ddlTitleInt").options[document.getElementById("ctl00_ContentPlaceHolder1_ddlTitleInt").selectedIndex].Text = document.getElementById("ctl00_ContentPlaceHolder1_ddlTitleInt").options[document.getElementById("ctl00_ContentPlaceHolder1_ddlTitleInt1").selectedIndex].Text;
        }

        function CheckMinChars(txtclientId) {
            alert('hi'); alert(txtclientId);
            var v = document.getElementById(txtclientId).text;
            alert(v);
            if (v.length < 2) {
                alert('Last Name should be minimum 2 characters');
            }
        }
        function Load() {

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                var dateToday = new Date();
                $(".datepicker").datepicker({
                    dateFormat: 'yy-mm-dd',
                    numberOfMonths: 2,
                    showOn: "button",
                    buttonImage: "~/images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday
                });

                $(".datepicker1").datepicker({
                    dateFormat: 'yy-mm-dd',
                    showOn: "button",
                    numberOfMonths: 2,
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday
                });
            }
        }
        function showDateInt() {
            $(".datepicker").datepicker("show");
        }
        function showDateInt1() {
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
                numberOfMonths: 2,
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: dateToday
            });
        });


        function showDivInt() {
            Page_ClientValidate("SearchInt");
            if (Page_ClientValidate("SearchInt")) {

                goInt();
                go1Int();
                go2Int();
                document.getElementById('mainDivInt').style.display = "";
                document.getElementById('contentDivInt').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "~/images/roller_big.gif"', 200);
            }
            else {
                return false;
            }

        }

        function startsearch() {
            var source = document.getElementById('<%=txtFrom.ClientID %>').value;
            var Destination = document.getElementById('<%=txtTo.ClientID %>').value;
            if (source == Destination) {
                alert('Source and Destination Can not be same');
                return false;
            }
            var rbtnOneWay = document.getElementById('<%=rbnIntOneWay.ClientID %>');

            var Date1 = document.getElementById('<%=txtIntDeptDate.ClientID %>').value;

            var Date2 = document.getElementById('<%=txtIntReturnDate.ClientID %>').value;



            if (rbtnOneWay.checked) {


                showDivInt();

            }
            else
                if (Date1 > Date2) {

                    alert('Return date can not before the Depart date');
                    return false;


                }
                else {
                    showDiv3();
                }



        }


        function startsearch1() {
            var source = document.getElementById('<%=txtfromsearch.ClientID %>').value;
            var Destination = document.getElementById('<%=txtleavingtosearch.ClientID %>').value;
            if (source == Destination) {
                alert('Source and Destination Can not be same');
                return false;
            }
            var rbtnOneWay = document.getElementById('<%=rradiooneway.ClientID %>');

            var Date3 = document.getElementById('<%=txtdatesearch.ClientID %>').value;

            var Date4 = document.getElementById('<%=txtretundatesearch.ClientID %>').value;



            if (rbtnOneWay.checked) {


                showDiv2();

            }
            else
                if (Date4 == '') {
                    alert('Please Enter Return Date');
                    return false;
                }
                else
                if (Date3 > Date4) {

                    alert('Return date can not before the Depart date');
                    return false;


                }
                else {
                    showDiv4();
                }



        }

      




    </script>
    <script type="text/javascript">
        function AddLetters(obj) {
            document.getElementById('<%=txtFirstnameInt.ClientID %>').value = obj.value;

        }
        function AddLettersLn(obj) {
            document.getElementById('<%=txtLastNameInt.ClientID %>').value = obj.value;

        }

        function AddTitle(obj) {
            //  alert(obj.options[obj.selectedIndex].text);
            document.getElementById('<%=ddlTitleInt.ClientID %>').value = obj.options[obj.selectedIndex].text;

        }
        function Adddob(obj) {
            //alert('hi');
            obj.value = "";

        }
        function CheckChildMinChars(txtclientId) {
            //  alert('hi'); alert(txtclientId);

            // alert(v);
            if (txtclientId.value.length < 2) {
                txtclientId.value = "";
                alert('Last Name should be minimum 2 characters');

            }
        }

        function CheckMinChars(txtclientId) {
            //  alert('hi'); alert(txtclientId);
            var v = document.getElementById('<%=txtLastNameInt.ClientID %>').value;
            // alert(v);
            if (v.length < 2) {
                txtclientId.value = "";
                alert('Last Name should be minimum 2 characters');

            }
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
        function showDiv2() {
            Page_ClientValidate("SearchInt1");
            if (Page_ClientValidate("SearchInt1")) {
                goInt1();
                go1Int1();
                go2Int1();
                document.getElementById('mainDiv2').style.display = "";
                document.getElementById('contentDiv2').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "../../Images/roller_big.gif"', 200);
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
                setTimeout('document.images["myAnimatedImage"].src = "Images/roller_big.gif"', 200);
            }
            else {
                return false;
            }
        }
        function showDiv4() {
            Page_ClientValidate("Search");
            if (Page_ClientValidate("Search")) {

                gm();
                gm1();
                gm2();


                gm3();
                gm4();
                gm5();
                document.getElementById('mainDiv4').style.display = "";
                document.getElementById('contentDiv4').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "Images/roller_big.gif"', 200);
            }
            else {
                return false;
            }
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
      
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script>
        $(function () {
            $("#<%=dvModifySearch.ClientID %>").accordion({
                collapsible: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function goInt() {

            var SelectedText = document.getElementById('<%=txtFrom.ClientID %>');
            var strAr = SelectedText.value.split(",");
            document.getElementById('Text4').value = strAr[0];
        }
        function go1Int() {

            var SelectedText = document.getElementById('<%=txtTo.ClientID %>');
            var strAr = SelectedText.value.split(",");
            document.getElementById('Text5').value = strAr[0].toUpperCase();
        }
        function go2Int() {

            var SelectedText = document.getElementById('<%=txtIntDeptDate.ClientID %>');
            var strAr = SelectedText.value.split("-");
            var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
            document.getElementById('Text6').value = sel;
        }
        function goInt1() {
            var SelectedText = document.getElementById('<%=txtfromsearch.ClientID %>');
            var strAr = SelectedText.value.split(",");
            //var SelectedIndex = DropdownList.selectedIndex;
            //var SelectedValue = DropdownList.value;
            //var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            document.getElementById('Text1').value = strAr[0];
        }
        function go1Int1() {
            var SelectedText = document.getElementById('<%=txtleavingtosearch.ClientID %>');
            var strAr = SelectedText.value.split(",");
            //var SelectedIndex = DropdownList.selectedIndex;
            // var SelectedValue = DropdownList.value;
            //var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            document.getElementById('Text2').value = strAr[0].toUpperCase();
        }
        function go2Int1() {
            var SelectedText = document.getElementById('<%=txtdatesearch.ClientID %>');
            var strAr = SelectedText.value.split("-");
            var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
            document.getElementById('Text3').value = sel;
        }
        function gor() {

            var SelectedText = document.getElementById('<%=txtFrom.ClientID %>');
            var strAr = SelectedText.value.split(",");
            document.getElementById('Text7').value = strAr[0];
        }
        function gor1() {
            var SelectedText = document.getElementById('<%=txtTo.ClientID %>');
            var strAr = SelectedText.value.split(",");
            document.getElementById('Text8').value = strAr[0].toUpperCase();
        }
        function gor2() {
            var SelectedText = document.getElementById('<%=txtIntDeptDate.ClientID %>');
            var strAr = SelectedText.value.split("-");
            var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
            document.getElementById('Text9').value = sel;
        }



        function gor3() {
            var SelectedText = document.getElementById('<%=txtTo.ClientID %>');
            var strAr = SelectedText.value.split(",");
            document.getElementById('Text10').value = strAr[0].toUpperCase();
        }
        function gor4() {
            var SelectedText = document.getElementById('<%=txtFrom.ClientID %>');
            var strAr = SelectedText.value.split(",");
            document.getElementById('Text11').value = strAr[0];
        }
        function gor5() {
            var SelectedText = document.getElementById('<%=txtIntReturnDate.ClientID %>');
            var strAr = SelectedText.value.split("-");
            var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
            document.getElementById('Text12').value = sel;
        }


        function gm() {


            var SelectedText = document.getElementById('<%=txtfromsearch.ClientID %>');

            var strAr = SelectedText.value.split(",");
            document.getElementById('Text13').value = strAr[0];
        }
        function gm1() {

            var SelectedText = document.getElementById('<%=txtleavingtosearch.ClientID %>');

            var strAr = SelectedText.value.split(",");
            document.getElementById('Text14').value = strAr[0].toUpperCase();
        }
        function gm2() {

            var SelectedText = document.getElementById('<%=txtdatesearch.ClientID %>');

            var strAr = SelectedText.value.split("-");
            var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
            document.getElementById('Text15').value = sel;
        }



        function gm3() {

            var SelectedText = document.getElementById('<%=txtleavingtosearch.ClientID %>');

            var strAr = SelectedText.value.split(",");
            document.getElementById('Text16').value = strAr[0].toUpperCase();
        }
        function gm4() {

            var SelectedText = document.getElementById('<%=txtfromsearch.ClientID %>');

            var strAr = SelectedText.value.split(",");
            document.getElementById('Text17').value = strAr[0];
        }
        function gm5() {

            var SelectedText = document.getElementById('<%=txtretundatesearch.ClientID %>');

            var strAr = SelectedText.value.split("-");
            var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
            document.getElementById('Text18').value = sel;
        }


    </script>
    
        
    
    <asp:Panel ID="panelBookingStatus" runat="server">
        <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
            <%--<tr>
                <td>
                    
                </td>
            </tr>--%>
            <tr>
                <td>
                    <div>
                        <asp:Panel ID="pnlSearch" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td align="center">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="lnkDomesticFlights" runat="server" Visible="false" OnClick="lnkDomesticFlights_Click">Domestic Flights</asp:LinkButton>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%">
                                                    <table align="left" id="tblSearch" runat="server" valign="top" width="400px" border="0"
                                                        cellpadding="0" cellspacing="0">
                                                        <tbody>
                                                            <tr>
                                                                <%--<td align="left" width="100%">
                                                                    <table width="350" align="center" border="0" cellspacing="0" id="tbl_InternationalFlights"
                                                                        runat="server" cellpadding="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="center" colspan="3" valign="top">
                                                                                    <h3 style="color: #336699; font-size: 21px; margin-left: 32px; margin-top: 10px;
                                                                                        margin-bottom: 10px;">
                                                                                        <span style="color: #cc0000;">International Flights </span>Booking</h3>
                                                                                </td>
                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%" border="0" cellpadding="1" cellspacing="1" height="280">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td valign="top" align="center" bgcolor="#ffffff">
                                                                                                    <div id="Div2" style="display: block;">
                                                                                                        <table width="98%" border="0" cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td valign="top" height="28" align="left">
                                                                                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                        <tr>
                                                                                                                            <td width="155" valign="middle" align="center" class="lj_one">
                                                                                                                                <asp:RadioButton ID="rbnIntOneWay" Text="One Way" runat="server" Checked="true" AutoPostBack="True" TabIndex="0" 
                                                                                                                                    GroupName="ONE1" OnCheckedChanged="rbnIntOneWay_CheckedChanged" Font-Names="Arial" />
                                                                                                                            </td>
                                                                                                                            <td valign="middle" align="left" class="lj_one">
                                                                                                                                <asp:RadioButton ID="rbnIntRoundTrip" Text="Round Trip" runat="server" AutoPostBack="True" TabIndex="1" 
                                                                                                                                    GroupName="ONE1" OnCheckedChanged="rbnIntRoundTrip_CheckedChanged" Font-Names="Arial" />
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td width="155" height="28" valign="top" align="left" class="lj_hd" >
                                                                                                                                Leaving From :
                                                                                                                            </td>
                                                                                                                            <td valign="top" height="28" align="left">
                                                                                                                                <asp:TextBox ID="txtFrom" runat="server" ToolTip="Type the first 3 letters of airport or city name" TabIndex="2" 
                                                                                                                                    CssClass="lj_inp"></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvFrom" Display="None" ValidationGroup="SearchInt"
                                                                                                                                    runat="server" ErrorMessage="Enter Source" ControlToValidate="txtFrom"></asp:RequiredFieldValidator>
                                                                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvFrom">
                                                                                                                                </ajax:ValidatorCalloutExtender>
                                                                                                                                <ajax:AutoCompleteExtender ID="txtFrom_AutoCompleteExtender" runat="server" TargetControlID="txtFrom"
                                                                                                                                    ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                                                                                    CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                                                                                    ServicePath="">
                                                                                                                                </ajax:AutoCompleteExtender>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td valign="top" height="28" align="left">
                                                                                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                        <tr>
                                                                                                                            <td width="155" valign="top" align="left" class="lj_hd" >
                                                                                                                                Leaving To :
                                                                                                                            </td>
                                                                                                                            <td valign="top" align="left">
                                                                                                                                <asp:TextBox ID="txtTo" runat="server" ToolTip="Type the first 3 letters of airport or city name" TabIndex="3" 
                                                                                                                                    CssClass="lj_inp" onchange="Javascript:GetReturnDate();"></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvTo" Display="None" ValidationGroup="SearchInt"
                                                                                                                                    runat="server" ErrorMessage="Enter Destination" ControlToValidate="txtTo"></asp:RequiredFieldValidator>
                                                                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rfvTo">
                                                                                                                                </ajax:ValidatorCalloutExtender>
                                                                                                                                <ajax:AutoCompleteExtender ID="txtTo_AutoCompleteExtender" runat="server" TargetControlID="txtTo"
                                                                                                                                    ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                                                                                    CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                                                                                    ServicePath="">
                                                                                                                                </ajax:AutoCompleteExtender>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td valign="top" height="28" align="left">
                                                                                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                        <tr>
                                                                                                                            <td width="155" valign="top" align="left" class="lj_hd" >
                                                                                                                                Departure On :
                                                                                                                            </td>
                                                                                                                            <td valign="top" align="left">
                                                                                                                                <asp:TextBox ID="txtIntDeptDate" ValidationGroup="Search" runat="server" onkeyup="return tabE(this,event)"
                                                                                                                                                            onPaste="javascript: return false;" CssClass="datepicker" OnClick="showDateInt();"
                                                                                                                                                            TabIndex="4"   />
                                                                                                                                                        <asp:RequiredFieldValidator ID="rfvDepOn" ValidationGroup="SearchInt" runat="server"
                                                                                                                                                            ErrorMessage="Enter date." ControlToValidate="txtIntDeptDate" Display="None"></asp:RequiredFieldValidator>
                                                                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="rfvDepOn">
                                                                                                                                                        </ajax:ValidatorCalloutExtender>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td valign="top" height="28" align="left">
                                                                                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                        <tr>
                                                                                                                            <td width="158" valign="top" align="left">
                                                                                                                                <asp:Label ID="lblReturningOnInt" Text="Return On :" runat="server" class="lj_hd" ></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td valign="top" align="left">
                                                                                                                               <asp:TextBox ID="txtIntReturnDate" runat="server" Enabled="False" Visible="true"
                                                                                                                                                            TabIndex="5" ValidationGroup="SearchInt" onkeyup="return tabE1(this,event)"
                                                                                                                                                            onPaste="javascript: return false;" CssClass="datepicker1" OnClick="showDateInt1();"
                                                                                                                                                             />
                                                                                                                                                        <asp:RequiredFieldValidator ID="RequiredReturnInt" ControlToValidate="txtIntReturnDate"
                                                                                                                                                            runat="server" Visible="false" ErrorMessage="Enter return date." Display="None"
                                                                                                                                                            ValidationGroup="SearchInt"></asp:RequiredFieldValidator>
                                                                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RequiredReturnInt">
                                                                                                                                                        </ajax:ValidatorCalloutExtender>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                               

                                                                                                                <td  style="padding-left:30px;" align="left" height="25">
                                                                                                               <table width="300" cellspacing="0" cellpadding="0">
                                                                                                               <tr>
                                                                                                                  <td class="lj_hd">
                                                                                                                  Adult
                                                                                                                  </td>
                                                                                                                  <td class="lj_hd">
                                                                                                                  Child (2-11 yrs)
                                                                                                                  </td>
                                                                                                                  <td class="lj_hd">
                                                                                                                  Infant (<2 yrs)
                                                                                                                  </td>
                                                                                                               </tr>
                                                                                                               </table>
                                                                                                            </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                
                                                                                                                <td  style="padding-left:30px;" align="left" height="25">
                                                                                                               <table width="300" cellspacing="0" cellpadding="0">
                                                                                                                  <tr>
                                                                                                                    <td>
                                                                                                                       <asp:DropDownList ID="ddlAdultsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                                    <td>
                                                                                                                          <img src="arzoo_search_files/blk.gif" width="40" height="1">
                                                                                                                                            <asp:DropDownList ID="ddlChildsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                                    <td>
                                                                                                                       <img src="arzoo_search_files/blk.gif" width="55" height="1">
                                                                                                                                            <asp:DropDownList ID="ddlInfantsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                            </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="4" align="left" class="lj_hd" style="padding-left:30px;" height="30px" >
                                                                                                                    Cabin:
                                                                                                                    <asp:DropDownList ID="ddlIntCabinType" CssClass="lj_inp" runat="server" TabIndex="9" Width="180px" >
                                                                                                                        <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                                                                                        <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                                                                                        <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td valign="top" height="28" align="left">
                                                                                                                    <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td valign="top" align="right">
                                                                                                                    <asp:ImageButton ID="ibtnSearchInt" runat="server" CssClass="check-availability-btn" TabIndex="10" 
                                                                                                                        ImageUrl="~/images/check-availability-btn.jpg" OnClick="ibtnSearchInt_Click"
                                                                                                                        OnClientClick="return startsearch();"  ValidationGroup="SearchInt" />
                                                                                                                    <span id="mainDivInt" style="display: none" class="loadingBackground"></span><span
                                                                                                                        id="contentDivInt" style="display: none" class="modalContainer">
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
                                                                                                                                                    <img src="../../images/loading.gif" width="60" height="60" />
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td align="center" class="almost12" height="20">
                                                                                                                                                    Searching for Flights
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td align="center" height="20">
                                                                                                                                                    <input id="Text4" type="text" style=" border: 0px; text-align: right; background-color:White;" disabled="disabled" class="progress"/>
                                                                                                                                                    &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                    <input id="Text5" type="text" style="border: 0px; text-align:left;background-color:White" class="progress"/>
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td align="center" height="20">
                                                                                                                                                    On
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td align="center" height="20">
                                                                                                                                                    <input id="Text6" type="text" style="border: 0; text-align: center; background-color:White;" disabled="disabled" class="progress" />
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
                                                                                                                    <span id="mainDiv3" style="display: none" class="loadingBackground"></span><span id="contentDiv3"
                                                                                                                    style="display: none" class="modalContainer">
                                                                                                                    <div class="registerhead">
                                                                                                                        <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color:White">
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
                                                                                                                                                <img src="../../images/loading.gif" width="60" height="60" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" class="almost12" height="20">
                                                                                                                                                Searching for Flights
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text7" type="text" style="text-align: right; border:0; background-color:white;"   readonly="readonly" class="progress" />
                                                                                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                <input id="Text8" type="text" style="border: 0; background-color:White"  disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                On
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text9" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr><td height="20px">&nbsp;</td></tr>

                                                                                                                                         <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text10" type="text" style="text-align: right; border:0; background-color:white;"   readonly="readonly" class="progress" />
                                                                                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                <input id="Text11" type="text" style="border: 0; background-color:White"  disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                On
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text12" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
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
                                                                </td>--%>

                                                                <td>
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
                                                                                        <td align="left" width="347" bgcolor="#ffffff">
                                                                                            <table width="347" align="center" border="0" cellspacing="0" id="tbl_InternationalFlights"
                                                                                                runat="server" cellpadding="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td width="50">
                                                                                                            <img src="../../Image/flight_button.png" width="50" height="37" />
                                                                                                        </td>
                                                                                                        <td align="left" valign="middle" class="online_booking">
                                                                                                             International Flight Tickets Booking
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="12" colspan="2" class="border_top">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2">
                                                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                                                                                                                <tbody>
                                                                                                                    <tr>
                                                                                                                        <td valign="top" align="center" bgcolor="#ffffff">
                                                                                                                            <div id="Div2" style="display: block;">
                                                                                                                                <table width="98%" border="0" cellpadding="0" cellspacing="0">
                                                                                                                                    <tr>
                                                                                                                                        <td valign="top" height="28" align="left">
                                                                                                                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td width="155" valign="middle" align="left" class="lj_one" colspan="2">
                                                                                                                                                        <asp:RadioButton ID="rbnIntOneWay" Text="One Way" runat="server" Checked="true" AutoPostBack="True"
                                                                                                                                                            TabIndex="1" GroupName="ONE1" OnCheckedChanged="rbnIntOneWay_CheckedChanged"
                                                                                                                                                            Font-Names="Arial" />
                                                                                                                                                    </td>
                                                                                                                                                    <td valign="middle" align="left" class="lj_one">
                                                                                                                                                        <asp:RadioButton ID="rbnIntRoundTrip" Text="Round Trip" runat="server" AutoPostBack="True"
                                                                                                                                                            GroupName="ONE1" OnCheckedChanged="rbnIntRoundTrip_CheckedChanged" Font-Names="Arial" />
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td height="10px">
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td width="150" height="28" valign="top" align="left" class="lj_hd">
                                                                                                                                                        Leaving From
                                                                                                                                                    </td>
                                                                                                                                                    <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                    <td valign="top" height="28" align="left">
                                                                                                                                                        <asp:TextBox ID="txtFrom" runat="server" ToolTip="Type the first 3 letters of airport or city name"
                                                                                                                                                            CssClass="lj_inp" TabIndex="2"></asp:TextBox>
                                                                                                                                                        <asp:RequiredFieldValidator ID="rfvFrom" Display="None" ValidationGroup="SearchInt"
                                                                                                                                                            runat="server" ErrorMessage="Enter Source" ControlToValidate="txtFrom"></asp:RequiredFieldValidator>
                                                                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvFrom">
                                                                                                                                                        </ajax:ValidatorCalloutExtender>
                                                                                                                                                        <ajax:AutoCompleteExtender ID="txtFrom_AutoCompleteExtender" runat="server" TargetControlID="txtFrom"
                                                                                                                                                            ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                                                                                                            CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                                                                                                            ServicePath="">
                                                                                                                                                        </ajax:AutoCompleteExtender>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td valign="top" height="28" align="left">
                                                                                                                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td width="150" valign="top" align="left" class="lj_hd">
                                                                                                                                                        Leaving To
                                                                                                                                                    </td>
                                                                                                                                                    <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                    <td valign="top" align="left">
                                                                                                                                                        <asp:TextBox ID="txtTo" runat="server" ToolTip="Type the first 3 letters of airport or city name"
                                                                                                                                                            CssClass="lj_inp" onchange="Javascript:GetReturnDate();" TabIndex="3"></asp:TextBox>
                                                                                                                                                        <asp:RequiredFieldValidator ID="rfvTo" Display="None" ValidationGroup="SearchInt"
                                                                                                                                                            runat="server" ErrorMessage="Enter Destination" ControlToValidate="txtTo"></asp:RequiredFieldValidator>
                                                                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rfvTo">
                                                                                                                                                        </ajax:ValidatorCalloutExtender>
                                                                                                                                                        <ajax:AutoCompleteExtender ID="txtTo_AutoCompleteExtender" runat="server" TargetControlID="txtTo"
                                                                                                                                                            ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                                                                                                            CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                                                                                                            ServicePath="">
                                                                                                                                                        </ajax:AutoCompleteExtender>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td valign="top" height="28" align="left">
                                                                                                                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td width="150" valign="top" align="left" class="lj_hd">
                                                                                                                                                        Departure On :
                                                                                                                                                    </td>
                                                                                                                                                    <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                    <td valign="top" align="left">
                                                                                                                                                        <asp:TextBox  Width="120px"  ID="txtIntDeptDate" ValidationGroup="Search" runat="server" onkeyup="return tabE(this,event)"
                                                                                                                                                            onPaste="javascript: return false;" CssClass="datepicker" OnClick="showDateInt();"
                                                                                                                                                            TabIndex="4"   />
                                                                                                                                                        <asp:RequiredFieldValidator ID="rfvDepOn" ValidationGroup="SearchInt" runat="server"
                                                                                                                                                            ErrorMessage="Enter date." ControlToValidate="txtIntDeptDate" Display="None"></asp:RequiredFieldValidator>
                                                                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="rfvDepOn">
                                                                                                                                                        </ajax:ValidatorCalloutExtender>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td valign="top" height="35" align="left">
                                                                                                                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td width="150" valign="top" align="left" class="lj_hd">
                                                                                                                                                        <asp:Label ID="lblReturningOnInt" Text="Return On" runat="server"></asp:Label>
                                                                                                                                                    </td>
                                                                                                                                                    <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                    <td valign="top" align="left">
                                                                                                                                                        <asp:TextBox ID="txtIntReturnDate" Width="120px" runat="server" Enabled="False" Visible="true"
                                                                                                                                                            TabIndex="4" ValidationGroup="SearchInt" onkeyup="return tabE1(this,event)"
                                                                                                                                                            onPaste="javascript: return false;" CssClass="datepicker1" OnClick="showDateInt1();"
                                                                                                                                                             />
                                                                                                                                                        <asp:RequiredFieldValidator ID="RequiredReturnInt" ControlToValidate="txtIntReturnDate"
                                                                                                                                                            runat="server" Visible="false" ErrorMessage="Enter return date." Display="None"
                                                                                                                                                            ValidationGroup="SearchInt"></asp:RequiredFieldValidator>
                                                                                                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RequiredReturnInt">
                                                                                                                                                        </ajax:ValidatorCalloutExtender>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td valign="top" height="28" align="left">
                                                                                                                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td width="150" valign="top" align="left" class="lj_hd">
                                                                                                                                                          Cabin
                                                                                                                                                    </td>
                                                                                                                                                    <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                    <td valign="top" align="left">
                                                                                                                                                  <asp:DropDownList ID="ddlIntCabinType" CssClass="lj_inp" runat="server" TabIndex="5">
                                                                                                                                                <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                                                                                                                <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                                                                                                                <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                                                                                                            </asp:DropDownList>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <%--<td colspan="4" align="left" height="25" class="lj_hd" style="padding-left:30px;">
                                                                                                                                            <span class="ft01">Adult&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                                Child</span><span class="ft03">(2-11 yrs)</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                            <span class="ft01">Infant</span><span class="ft03">(&lt;2yrs)</span>
                                                                                                                                        </td>--%>

                                                                                                                                          <td  style="padding-left:30px;" align="left" height="25">
                                                                                                               <table width="300" cellspacing="0" cellpadding="0">
                                                                                                               <tr>
                                                                                                                  <td class="lj_hd">
                                                                                                                  Adult
                                                                                                                  </td>
                                                                                                                  <td class="lj_hd">
                                                                                                                  Child (2-11 yrs)
                                                                                                                  </td>
                                                                                                                  <td class="lj_hd">
                                                                                                                  Infant (<2 yrs)
                                                                                                                  </td>
                                                                                                               </tr>
                                                                                                               </table>
                                                                                                            </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <%--<td colspan="4" valign="top" align="left" height="25" class="lj_hd" style="padding-left:30px;">
                                                                                                                                            <asp:DropDownList ID="ddlAdultsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                                                           
                                                                                                                                            <img src="arzoo_search_files/blk.gif" width="40" height="1">
                                                                                                                                            <asp:DropDownList ID="ddlChildsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                                                          
                                                                                                                                            <img src="arzoo_search_files/blk.gif" width="55" height="1">
                                                                                                                                            <asp:DropDownList ID="ddlInfantsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                                                        </td>--%>

                                                                                                                                        <td  style="padding-left:30px;" align="left" height="25">
                                                                                                               <table width="300" cellspacing="0" cellpadding="0">
                                                                                                                  <tr>
                                                                                                                    <td>
                                                                                                                       <asp:DropDownList ID="ddlAdultsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                                    <td>
                                                                                                                          <img src="arzoo_search_files/blk.gif" width="40" height="1">
                                                                                                                                            <asp:DropDownList ID="ddlChildsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                                    <td>
                                                                                                                       <img src="arzoo_search_files/blk.gif" width="55" height="1">
                                                                                                                                            <asp:DropDownList ID="ddlInfantsInt" class="ft02" runat="server" Width="50px" CssClass="lj_inp"
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
                                                                                                            </td>
                                                                                                                                    </tr>
                                                                                                                                    
                                                                                                                                    <tr>
                                                                                                                                        <td valign="top" height="28" align="left">
                                                                                                                                            <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td valign="top" align="center" height="60">
                                                                                                                                            <%-- <asp:ImageButton ID="ibtnSearchInt" runat="server" CssClass="check-availability-btn"
                                                                                                                        ImageUrl="~/images/check-availability-btn.jpg" OnClick="ibtnSearchInt_Click"
                                                                                                                        OnClientClick="showDivInt();" ValidationGroup="SearchInt" />--%>
                                                                                                                                            <asp:ImageButton ID="ibtnSearchInt" runat="server" CssClass="check-availability-btn"
                                                                                                                                                TabIndex="10" ImageUrl="~/images/check-availability-btn.jpg" OnClick="ibtnSearchInt_Click"
                                                                                                                                                OnClientClick="return startsearch();"  ValidationGroup="SearchInt" />
                                                                                                                                            <span id="mainDivInt" style="display: none" class="loadingBackground"></span><span
                                                                                                                                                id="contentDivInt" style="display: none" class="modalContainer">
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
                                                                                                                                                                            <img src="../../images/loading.gif" width="60" height="60" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" class="almost12" height="20">
                                                                                                                                                                            Searching for Flights
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" height="20">
                                                                                                                                                                            <input id="Text4" type="text" style="border:0; text-align: right; background-color:White" disabled="disabled" class="progress" />
                                                                                                                                                                            &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                                            <input id="Text5" type="text" style="border: 0; background-color:White" disabled="disabled" class="progress" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" height="20">
                                                                                                                                                                            On
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" height="20">
                                                                                                                                                                            <input id="Text6" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
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

                                                                                                                                             <span id="mainDiv3" style="display: none" class="loadingBackground"></span><span id="contentDiv3"
                                                                                                                    style="display: none" class="modalContainer">
                                                                                                                    <div class="registerhead">
                                                                                                                        <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color:White">
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
                                                                                                                                                <img src="../../images/loading.gif" width="60" height="60" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" class="almost12" height="20">
                                                                                                                                                Searching for Flights
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text7" type="text" style="text-align: right; border:0; background-color:white;"   readonly="readonly" class="progress" />
                                                                                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                <input id="Text8" type="text" style="border: 0; background-color:White"  disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                On
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text9" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr><td height="20px">&nbsp;</td></tr>

                                                                                                                                         <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text10" type="text" style="text-align: right; border:0; background-color:white;"   readonly="readonly" class="progress" />
                                                                                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                <input id="Text11" type="text" style="border: 0; background-color:White"  disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                On
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text12" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
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
                                                                <td style="width: 100px">
                                                                </td>
                                                                <td align="right" valign="middle">
                                                                   <%-- <asp:Image ID="imgFlight" Width="367" Height="366" ImageUrl="~/images/flight.jpg"
                                                                        runat="server" />--%>
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
                        </asp:Panel>
                    </div>
                    <asp:Panel ID="InternationalFlightsPanel" runat="server">
                        <table width="90%">
                            <tr>
                                <td align="left" class="lj_fntbldsze">
                                    <asp:Label ID="lblRouteFromTo" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                       <tr>
                                            <td align="right">
                                                <asp:LinkButton ID="lnkModifySearch" runat="server" Visible="false">Modify Search</asp:LinkButton>
                                                <%-- <ajax:collapsiblepanelextender id="cpe" runat="Server" targetcontrolid="pnlModSearch"
                                                    collapsedsize="0" expandedsize="180" collapsed="True" expandcontrolid="lnkModifySearch"
                                                    collapsecontrolid="lnkModifySearch" autocollapse="False" autoexpand="False" scrollcontents="false"
                                                    textlabelid="Label1"  
                                                    imagecontrolid="lnkModifySearch" expandedimage="~/images/up_arrow.png" collapsedimage="~/images/down_arrow.png"
                                                    expanddirection="Vertical" />--%>
                                            </td>
                                        </tr>
                                        
                                        <tr id="ModifySearch"  runat="server" visible="false">
                                            <td align="center" width="900" style="padding-left:10px">
                                                <div id="dvModifySearch" visible="false" runat="server" style="margin-left:5px;width:800;">
                                                    <h3>
                                                        Modify Search</h3>
                                                    <asp:Panel ID="pnlModSearch" runat="server">
                                                        <%--<table width="90%">
                                                            <tr>
                                                                <td width="155" valign="middle" align="center">
                                                                    <asp:RadioButton ID="rradiooneway" Text="One Way" runat="server" Checked="true" AutoPostBack="True"
                                                                        GroupName="ONE2" OnCheckedChanged="rradiooneway_CheckedChanged" Font-Names="Arial" />
                                                                </td>
                                                                <td valign="middle" align="left">
                                                                    <asp:RadioButton ID="rradioround" Text="Round Trip" runat="server" AutoPostBack="True"
                                                                        GroupName="ONE2" OnCheckedChanged="rradioround_CheckedChanged" Font-Names="Arial" />
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
                                                                    <asp:Label ID="Label1" Text="Return On :" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="bottom" height="28" align="left">
                                                                    <asp:TextBox ID="txtfromsearch" runat="server" Width="110" ToolTip="Type the first 3 letters of airport or city name" CssClass="lj_inp"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtfromsearch" Display="None" ValidationGroup="SearchInt1"
                                                                        runat="server" ErrorMessage="Enter Source" ControlToValidate="txtfromsearch"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvtxtfromsearch">
                                                                    </ajax:ValidatorCalloutExtender>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtfromsearch"
                                                                        ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                        CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                        ServicePath="">
                                                                    </ajax:AutoCompleteExtender>
                                                                </td>
                                                                <td valign="bottom" align="left">
                                                                    <asp:TextBox ID="txtleavingtosearch" runat="server" Width="110" ToolTip="Type the first 3 letters of airport or city name" CssClass="lj_inp"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtleavingtosearch" Display="None" ValidationGroup="SearchInt1"
                                                                        runat="server" ErrorMessage="Enter Destination" ControlToValidate="txtleavingtosearch"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvtxtleavingtosearch">
                                                                    </ajax:ValidatorCalloutExtender>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtleavingtosearch"
                                                                        ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                        CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                        ServicePath="">
                                                                    </ajax:AutoCompleteExtender>
                                                                </td>
                                                                <td valign="bottom" align="left">
                                                                    <asp:TextBox ID="txtdatesearch" ValidationGroup="Search" runat="server" onKeyPress="javascript: return false;"
                                                                        onPaste="javascript: return false;" OnClick="showDateInt();" CssClass="datepicker"
                                                                        Width="70px" />
                                                                    <asp:RequiredFieldValidator ID="rfvtxtdatesearch" ValidationGroup="SearchInt1" runat="server"
                                                                        ErrorMessage="Enter date." ControlToValidate="txtdatesearch" Display="None"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvtxtdatesearch">
                                                                    </ajax:ValidatorCalloutExtender>
                                                                </td>
                                                                <td valign="bottom" align="left">
                                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tr>
                                                                            <td valign="top" align="left">
                                                                                <asp:TextBox ID="txtretundatesearch" runat="server" Enabled="false" Width="70px"
                                                                                    Visible="true" ValidationGroup="SearchInt" onKeyPress="javascript: return false;"
                                                                                    onPaste="javascript: return false;" OnClick="showDateInt();" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" height="25" valign="top">
                                                                    Adult
                                                                </td>
                                                                <td valign="top" width="140">
                                                                    Child(2-11yrs)
                                                                </td>
                                                                <td valign="top" width="130">
                                                                    Infant(&lt;2yrs)
                                                                </td>
                                                                <td valign="top">
                                                                    Cabin:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="bottom" align="left" height="25">
                                                                    <asp:DropDownList ID="ddladultsintsearch" class="ft02" runat="server" CssClass="lj_inp" Width="50px">
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
                                                                    <asp:DropDownList ID="ddlchildintsearch"  runat="server" CssClass="lj_inp" Width="50px" >
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
                                                                    <asp:DropDownList ID="ddlinfantsintsearch" runat="server" Width="50px" CssClass="lj_inp" >
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
                                                                    <asp:DropDownList ID="ddlIntCabinTypesearch" Width="130"  runat="server" CssClass="lj_inp">
                                                                        <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                                        <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                                        <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                    <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/images/check-availability-btn.jpg"
                                                                        OnClick="imgsearch_Click" OnClientClick="showDiv2();" ValidationGroup="SearchInt1" />
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
                                                                                                    <input id="Text1" type="text" style="border-color: #0CF; border: 1px; text-align: right;" />
                                                                                                    &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                    <input id="Text2" type="text" style="border: 0;" />
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
                                                        </table>--%>

                                                        <%--<table width="800" cellpadding="0" cellspacing="0" border="0" align="center">
                                                      <tr>
                                                          <td width="200" align="center">
                                                          
                                                          <table>
                                                          <tr>
                                                          <td class="lj_hd"> 
                                                        <asp:RadioButton ID="rradiooneway" Text="One Way" runat="server" Checked="true" AutoPostBack="True"  Font-Size="Medium"
                                                                        GroupName="ONE2" OnCheckedChanged="rradiooneway_CheckedChanged" Font-Names="Arial" />
                                                           </td>
                                                          </tr>
                                                          <tr>

                                                          <td class="lj_hd">
                                                          <asp:RadioButton ID="rradioround" Text="Round Trip" runat="server" AutoPostBack="True" Font-Size="Medium"
                                                                        GroupName="ONE2" OnCheckedChanged="rradioround_CheckedChanged" Font-Names="Arial" />
                                                                
                                                          </td>
                                                          </tr>

                                                          
                                                          
                                                          </table>

                                                          </td>
                                                          <td width="600">

                                                          <table cellpadding="0" cellspacing="0" border="0">
                                                          <tr>
                                                          
                                                          <td width="150" align="left" class="lj_hd" height="30">Leaving From :</td>
                                                          <td width="150" align="left"  class="lj_hd"> Leaving To :</td>
                                                          <td width="150" align="left" class="lj_hd"> Departure On :</td>
                                                          <td width="150" align="left" class="lj_hd"> <asp:Label ID="Label1" runat="server" Text="Return On :"></asp:Label></td>
                                                          
                                                          </tr>

                                                           <tr>
                                                          
                                                          <td width="150" align="left">
                                                          
                                                          <asp:TextBox ID="txtfromsearch" runat="server" Width="110" ToolTip="Type the first 3 letters of airport or city name" CssClass="lj_inp"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtfromsearch" Display="None" ValidationGroup="SearchInt1"
                                                                        runat="server" ErrorMessage="Enter Source" ControlToValidate="txtfromsearch"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvtxtfromsearch">
                                                                    </ajax:ValidatorCalloutExtender>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtfromsearch"
                                                                        ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                        CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                        ServicePath="">
                                                                    </ajax:AutoCompleteExtender>
                                                          </td>
                                                          <td width="150">
                                                              
                                                               
                                                                <asp:TextBox ID="txtleavingtosearch" runat="server" Width="110" ToolTip="Type the first 3 letters of airport or city name" CssClass="lj_inp"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtleavingtosearch" Display="None" ValidationGroup="SearchInt1"
                                                                        runat="server" ErrorMessage="Enter Destination" ControlToValidate="txtleavingtosearch"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvtxtleavingtosearch">
                                                                    </ajax:ValidatorCalloutExtender>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtleavingtosearch"
                                                                        ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                        CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                        ServicePath="">
                                                                    </ajax:AutoCompleteExtender>
                                                          </td>
                                                          <td width="150">
                                                           <asp:TextBox ID="txtdatesearch" ValidationGroup="Search" runat="server" onkeyup="return tabE2(this,event)"
                                                                        onPaste="javascript: return false;" OnClick="showDateInt();" CssClass="datepicker"
                                                                        Width="70px" />
                                                                    <asp:RequiredFieldValidator ID="rfvtxtdatesearch" ValidationGroup="SearchInt1" runat="server"
                                                                        ErrorMessage="Enter date." ControlToValidate="txtdatesearch" Display="None"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvtxtdatesearch">
                                                                    </ajax:ValidatorCalloutExtender>
                                                          </td>
                                                          <td width="150">
                                                           <asp:TextBox ID="txtretundatesearch" runat="server" Enabled="false" Width="70px"  class="lj_inp" CssClass="datepicker1"
                                                                                    Visible="true" ValidationGroup="SearchInt" onkeyup="return tabE3(this,event)"
                                                                                    onPaste="javascript: return false;" OnClick="showDateInt();" />
                                                          </td>
                                                          
                                                          </tr>


                                                           <tr>
                                                          
                                                          <td width="150" height="30" class="lj_hd">
                                                           Adult
                                                          </td>
                                                          <td width="150" class="lj_hd">
                                                          Child(2-11 Years)
                                                          </td>
                                                          <td width="150" class="lj_hd">
                                                          Infant(<2Years)
                                                          </td>
                                                          <td width="150" class="lj_hd">
                                                          Cabin:
                                                          </td>
                                                          </tr>


                                                           <tr>
                                                          
                                                          <td width="150">
                                                           <asp:DropDownList ID="ddladultsintsearch" CssClass="lj_inp" runat="server" Width="50px">
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
                                                          <td width="150">
                                                           <img src="arzoo_search_files/blk.gif" width="40" height="1">
                                                                    <asp:DropDownList ID="ddlchildintsearch" CssClass="lj_inp" runat="server" Width="50px">
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
                                                          <td width="150">
                                                           <img src="arzoo_search_files/blk.gif" width="55" height="1">
                                                <asp:DropDownList ID="ddlinfantsintsearch" runat="server" CssClass="lj_inp" Width="50">
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
                                                          <td width="150">
                                                         <asp:DropDownList ID="ddlIntCabinTypesearch" Width="180" CssClass="lj_inp" runat="server">
                                                                        <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                                        <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                                        <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                                    </asp:DropDownList>

                                                          </td>
                                                          
                                                          </tr>
                                                          
                                                          <tr>
                                                      <td colspan="4" height="40" align="right" valign="bottom">
                                                      <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/images/check-availability-btn.jpg"
                                                                        OnClick="imgsearch_Click"  OnClientClick="return startsearch1();" ValidationGroup="SearchInt1" />
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
                                                                                                    <img src="../../images/loading.gif" width="60" height="60" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" class="almost12" height="20">
                                                                                                    Searching for Flights
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" height="20">
                                                                                                    <input id="Text1" type="text" style=" border:0px; text-align: right; background-color:White;"  disabled="disabled" class="progress"/>
                                                                                                    &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                    <input id="Text2" type="text" style="border: 0;background-color:White;text-align:left;"  disabled="disabled" class="progress"/>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" height="20">
                                                                                                    On
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" height="20">
                                                                                                    <input id="Text3" type="text" style="border: 0; text-align: center; background-color:White;" disabled="disabled" class="progress"/>
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
                                                </span>
                                                      </td>
                                                      </tr>
                                                          
                                                          </table>
                                                          
                                                          </td>
                                                           
                                                      </tr>
                                                      
                                                    </table>--%>
                                                    </asp:Panel>
                                                </div>
                                            </td>
                                        </tr>
                            <tr runat="server" id="trFilterSearch" visible="false">
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td width="25%" valign="top" >
                                                <table width="25%" style="border: 0px solid #657600" cellpadding="0" cellspacing="0">
                                                  <tr>
    <td width="3" align="right"><img src="../../images/lb1.png" width="3" height="29"  /></td>
    <td width="232" class="lj_ms_blu">Modify Search</td>
    <td width="3"><img src="../../images/lb2.png" width="3" height="29"  /></td>
  </tr>
  <tr>
    <td colspan="3" class="lj_ms_bdr" align="center">
    
    
    <table width="232"  border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" height="30" class="lj_fntbldsze">
     <asp:RadioButton ID="rradiooneway" Text="One Way" runat="server" Checked="true" AutoPostBack="True"
                                                                        GroupName="ONE2" OnCheckedChanged="rradiooneway_CheckedChanged"  />
   
      <asp:RadioButton ID="rradioround" Text="Round Trip" runat="server" AutoPostBack="True"
                                                                        GroupName="ONE2" OnCheckedChanged="rradioround_CheckedChanged"  />
                                                                </td>
  </tr>
  <tr>

    <td height="8" colspan="2"></td>
  </tr>
  <tr>
    <td colspan="2" align="center">
    
    
    
    <table width="230" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="lj_ms_fr" align="left" height="30">Leaving From</td>
    <td width="140">

     <asp:TextBox ID="txtfromsearch" runat="server" ToolTip="Type the first 3 letters of airport or city name" CssClass="lj_ms_in"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtfromsearch" Display="None" ValidationGroup="SearchInt1"
                                                                        runat="server" ErrorMessage="Enter Source" ControlToValidate="txtfromsearch"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvtxtfromsearch">
                                                                    </ajax:ValidatorCalloutExtender>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtfromsearch"
                                                                        ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                        CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                        ServicePath="">
                                                                    </ajax:AutoCompleteExtender>
    
    </td>
  </tr>
  
   <tr>
    <td class="lj_ms_fr" align="left" height="30">Leaving To</td>
    <td width="140">
      <asp:TextBox ID="txtleavingtosearch" runat="server"  ToolTip="Type the first 3 letters of airport or city name" CssClass="lj_ms_in"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtleavingtosearch" Display="None" ValidationGroup="SearchInt1"
                                                                        runat="server" ErrorMessage="Enter Destination" ControlToValidate="txtleavingtosearch"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvtxtleavingtosearch">
                                                                    </ajax:ValidatorCalloutExtender>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtleavingtosearch"
                                                                        ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                        CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                        ServicePath="">
                                                                    </ajax:AutoCompleteExtender>

    
    </td>
  </tr>
  
  <tr>
    <td class="lj_ms_fr" align="left" height="30">Departure On</td>
    <td width="140">

   <asp:TextBox ID="txtdatesearch" ValidationGroup="Search" runat="server" onkeyup="return tabE2(this,event)"
                                                                        onPaste="javascript: return false;" OnClick="showDateInt();" CssClass="datepicker"
                                                                        Width="90px" />
                                                                    <asp:RequiredFieldValidator ID="rfvtxtdatesearch" ValidationGroup="SearchInt1" runat="server"
                                                                        ErrorMessage="Enter date." ControlToValidate="txtdatesearch" Display="None"></asp:RequiredFieldValidator>
                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvtxtdatesearch">
                                                                    </ajax:ValidatorCalloutExtender>
    
    </td>
  </tr>
  
  
    <tr>
    <td class="lj_ms_fr" align="left" height="30">Return On</td>
    <td width="140">

    <asp:TextBox ID="txtretundatesearch" runat="server" Enabled="false" Width="90px" CssClass="datepicker1" 
                                                                                    Visible="true" ValidationGroup="SearchInt" onkeyup="return tabE3(this,event)"
                                                                                    onPaste="javascript: return false;" OnClick="showDateInt();" />
    
    </td>
  </tr>
  
  
  
   <tr>
    <td class="lj_ms_fr" align="left" height="30">Adult</td>
    <td width="140">

   <asp:DropDownList ID="ddladultsintsearch" CssClass="lj_ms_in" runat="server" Width="50px">
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
    <td class="lj_ms_fr" align="left" height="30">Child</td>
    <td width="140">
   
   <%-- <img src="arzoo_search_files/blk.gif" width="40" height="1">--%>
                                                                    <asp:DropDownList ID="ddlchildintsearch" CssClass="lj_ms_in" runat="server" Width="50px">
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
    <td class="lj_ms_fr" align="left" height="30">Infant</td>
    <td width="140">

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
    <td class="lj_ms_fr" align="left" height="30">Cabin</td>
    <td width="140">

    <asp:DropDownList ID="ddlIntCabinTypesearch"  CssClass="lj_ms_in" runat="server">
                                                                        <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                                        <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                                        <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                                    </asp:DropDownList>
    </td>
  </tr>
  <tr>

    <td colspan="2" align="center">

       <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/images/check-availability-btn.jpg" CssClass="lj_ms_in" Width="159"
                                                                        OnClick="imgsearch_Click"  OnClientClick="return startsearch1();"  ValidationGroup="SearchInt1" />
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
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
                                                                                                    <img src="../../images/loading.gif" width="60" height="60" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" class="almost12" height="20">
                                                                                                    Searching for Flights
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" height="20">
                                                                                                    <input id="Text1" type="text" style=" border:0px; text-align:right;background-color:White;" class="progress" />
                                                                                                    &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                    <input id="Text2" type="text" style="border: 0px; background-color:White;text-align:left"  class="progress"/>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" height="20">
                                                                                                    On
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" height="20">
                                                                                                    <input id="Text3" type="text" style="border: 0; text-align: center; background-color:White;" class="progress" />
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
    
     <span id="mainDiv4" style="display: none" class="loadingBackground"></span><span id="contentDiv4"
                                                                                                                    style="display: none" class="modalContainer">
                                                                                                                    <div class="registerhead">
                                                                                                                        <table width="600" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color:White">
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
                                                                                                                                                <img src="../../images/loading.gif" width="60" height="60" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" class="almost12" height="20">
                                                                                                                                                Searching for Flights
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text13" type="text" style="text-align: right; border:0; background-color:white;"   readonly="readonly" class="progress" />
                                                                                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                <input id="Text14" type="text" style="border: 0; background-color:White"  disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                On
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text15" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr><td height="20px">&nbsp;</td></tr>

                                                                                                                                         <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text16" type="text" style="text-align: right; border:0; background-color:white;"   readonly="readonly" class="progress" />
                                                                                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                <input id="Text17" type="text" style="border: 0; background-color:White"  disabled="disabled" class="progress" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20">
                                                                                                                                                On
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="20" class="lj_hd">
                                                                                                                                                <input id="Text18" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
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
   <tr>
    <td height="7"></td>
    <td></td>
    <td></td>
  </tr>
                                                  <%--  <tr>
                                                        <td align="center" style="border-bottom:1px solid #657600" bgcolor="#f1f1f1">
                                                            Filter Your Search
                                                        </td>
                                                    </tr>--%>
                                                     <tr>
                                                    <td colspan="3" id="trfiltersearch1" runat="server">
                                                    <table cellpadding="0" cellspacing="0">
                                                     <tr>
    <td width="3" align="right"><img src="../../images/lb1.png" width="3" height="29"  /></td>
    <td width="232" class="lj_ms_blu">Filter Your Search</td>
    <td width="3"><img src="../../images/lb2.png" width="3" height="29"  /></td>
  </tr>
                                                       
                                                                             <tr><td align="center" width="100%" colspan="3" class="lj_ms_bdr">
                                                  <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td   align="left" style="border-bottom:1px solid #f1f1f1;height:30px" valign="top">
                                                            <span style="font-size: 15px;padding-left:10px;">Price Range</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-left:20px;">
                                                            <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="lbl11" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            <table width="100%">
                                                                <tr valign="middle">
                                                                    <td valign="top" width="20%" style="border-bottom: 0px;padding-left:15px;">
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
                                                                                <td  style="border-bottom:1px solid #657600">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                <%--  <tr>
                                                                <td>
                                                                    <span style="font-size: 15px;">Stops</span>
                                                                </td>
                                                            </tr>
                                                       <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkstop0" runat="server" Text="Zero" Width="65" OnCheckedChanged="filter"
                                                                        AutoPostBack="true" />
                                                                    <asp:CheckBox ID="Chkstop1" runat="server" Text="One" Width="65" OnCheckedChanged="filter"
                                                                        AutoPostBack="true" />
                                                                    <asp:CheckBox ID="Chkstop2" runat="server" Text="Two" Width="65" OnCheckedChanged="filter"
                                                                        AutoPostBack="true" />
                                                                </td>
                                                            </tr>--%>
                                                               <tr>
                                                                                <td style="height:10px;">
                                                                                   
                                                                                </td>
                                                                            </tr>
                                                                <tr>
                                                                    <td  style="border-bottom:1px solid #f1f1f1;height:30px;" valign="top">
                                                                        <span style="font-size: 15px;padding-left:10px;">Airlines</span>
                                                                    </td>
                                                                </tr>
                                                                <tr><td style="height:10px;"></td></tr>
                                                                <tr>
                                                                    <td style="padding-left:10px;">
                                                                        <asp:CheckBoxList ID="chkAirlines" runat="server" OnSelectedIndexChanged="filter"
                                                                            AutoPostBack="true">
                                                                        </asp:CheckBoxList>
                                                                        <%--       <asp:CheckBox ID="chkjetlite" runat="server" Text="Jet Lite" AutoPostBack="true"
                                                                        OnCheckedChanged="filter" /><br />
                                                                    <asp:CheckBox ID="chkJetAirways" runat="server" Text="Jet Airways" AutoPostBack="true"
                                                                        OnCheckedChanged="filter" /><br />
                                                                    <asp:CheckBox ID="chkAirIndia" runat="server" Text="Air India" AutoPostBack="true"
                                                                        OnCheckedChanged="filter" />--%>
                                                                    </td>
                                                                </tr>
                                                                              <tr>
                                                                                <td  style="border-bottom:1px solid #657600">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                                <tr>
                                                                                <td style="height:10px;">
                                                                                   
                                                                                </td>
                                                                            </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Button ID="btnResetFilters" runat="server" OnClick="btnResetFilters_Click" CssClass="buttonBook"
                                                                            Text="Reset Filters" />
                                                                    </td>
                                                                </tr>
                                                                     <tr>
                                                                                <td  style="height:10px;">
                                                                                   
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
                                            </td>
                                            <td align="center" style="width: 75%" id="oneway" runat="server" valign="top">
                                                <asp:GridView ID="gdvIntFlights" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="false" GridLines="Horizontal"
                                                    AllowSorting="true" OnRowDataBound="gdvIntFlights_RowDataBound" OnRowCommand="gdvIntFlights_RowCommand"
                                                    PageSize="20" OnPageIndexChanging="gdvIntFlights_PageIndexChanging" OnSorting="gdvIntFlights_Sorting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Airline" SortExpression="OperatingAirlineName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOperatingAirlineName" runat="server" Text='<%# Eval("OperatingAirlineName") %>'></asp:Label>
                                                                -
                                                                <asp:Label ID="lblOperatingAirlineFlightNumber" runat="server" Text='<%# Eval("OperatingAirlineFlightNumber") %>'></asp:Label><br />
                                                                 <asp:Label ID="lblConnectingFlights" runat="server" Text="Connecting Flights..." Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Destinations">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDestinations" runat="server" Text=""></asp:Label>
                                                                   <asp:Label ID="lblConx" runat="server" Text='<%# Eval("Conx") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Departs" SortExpression="DepartureDateTime">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDeparts" runat="server" Text='<%# Eval("DepartureDateTime") %>' Font-Bold="true"></asp:Label>
                                                                <asp:Label ID="lbldepartdate" runat="server" Visible="false" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                                <asp:Label ID="lblFlightSegment_ID" runat="server" Text='<%# Eval("FlightSegment_ID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Arrives" SortExpression="ArrivalDateTime">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblArrives" runat="server" Text='<%# Eval("ArrivalDateTime") %>' Font-Bold="true"></asp:Label>
                                                                <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Duration">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDuration" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Stops" SortExpression="NumStops" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNumStops" runat="server" Text='<%# Eval("NumStops") %>'></asp:Label>
                                                                Stops
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fare" SortExpression="Fare">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFare" runat="server" Text='<%# Eval("Fare") %>' Font-Bold="true"></asp:Label>
                                                                <br />
                                                                <asp:LinkButton ID="lnkFareRule" runat="server" CommandArgument='<%# Eval("FlightSegment_ID") %>'
                                                                    CommandName="ViewRules" Font-Underline="false">Fare Rules</asp:LinkButton>
                                                                <ajax:HoverMenuExtender ID="HoverMenuExtender1" runat="server" OffsetX="30" OffsetY="-100"
                                                                    PopupControlID="pnlFareRules" PopupPosition="Right" TargetControlID="lnkFareRule">
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
                                                                <br />
                                                                <asp:Button ID="btnIntBookNow" runat="server" CssClass="buttonBook" CommandArgument='<%# Eval("FlightSegment_ID") %>'
                                                                    CommandName="BookTicket" OnClick="btnIntBookNow_Click" Text="Book Now" /><br />
                                                                         <asp:LinkButton ID="lnkDetails" runat="server" CommandName="View Details" CommandArgument='<%# Eval("FlightSegment_ID") %>' 
                                                                                OnClick="lnkDummy_Click">Details</asp:LinkButton>
                                                                <br />&nbsp;&nbsp;
                                                    <!-- Not Using Currently -->
                                                                <asp:LinkButton ID="lnkFareDetails" runat="server" >Fare Details</asp:LinkButton>
                                                                <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" OffsetX="30" OffsetY="-100"
                                                                    PopupControlID="pnlFareDetails" PopupPosition="Right" TargetControlID="lnkFareDetails">
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
                                                                                    <tr >
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
                                                                <!-- End -->
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <AlternatingRowStyle CssClass="gridAlter" />
                                                    <RowStyle CssClass="gridAlter" />
                                                    <HeaderStyle BackColor="LightBlue" />
                                                </asp:GridView>

                                                <asp:LinkButton ID="lnkDummy" runat="server" Style="display: none" CausesValidation="false"></asp:LinkButton>
     <ajax:ModalPopupExtender ID="mpeAirlineDet" runat="server" PopupControlID="pnlAirlineDetails"
     TargetControlID="lnkDummy" X="350" Y="250" BackgroundCssClass="modalBackground" OkControlID="btnok">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlAirlineDetails" runat="server" style="position:fixed; top:0px; left:0px; display:none; border:background:url(images/overlay1.png);  width:600;height:200;padding-top:10px;text-align:center; z-index:1; padding-left:10px; padding-right:10px;padding-right:10px" 
align="center">
         <table width="600" bgcolor="#eefaff"  style="border:#222 5px solid;" height="100">
        <tr><th>Airline</th><th>Departs</th><th>Arrives</th><th>Duration</th></tr>
        <tr><td>
        <asp:Label ID="lblOperatingAirlineNameDet" runat="server"></asp:Label><br />                                                       
        <asp:Label ID="lblMarketingAirlineno" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDet" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDet" runat="server" ></asp:Label><br/>
              </td>
        </tr>
       <tr runat="server" id="trConnecting1"><td>
        <asp:Label ID="lblOperatingAirlineNameDet1" runat="server"></asp:Label><br />                                                       
         <asp:Label ID="lblMarketingAirlineno1" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDet1" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet1" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet1" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet1" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet1" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDet1" runat="server" ></asp:Label><br/>
              </td>
        </tr>
      
        <tr runat="server" id="trConnecting2"><td>
        <asp:Label ID="lblOperatingAirlineNameDet2" runat="server"></asp:Label><br />                                                       
         <asp:Label ID="lblMarketingAirlineno2" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDet2" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet2" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet2" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet2" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet2" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDet2" runat="server" ></asp:Label><br/>
              </td>
        </tr>
      
        <tr><td>&nbsp;</td></tr>
        <tr><td align="center" colspan="4">
            <asp:Button ID="btnok" runat="server" Text="Ok" CssClass="buttonBook" /></td></tr>
        </table>
    </asp:Panel>
                                            </td>
                                            <td width="75%" id="trroundTrip1" runat="server" visible="false" valign="top">
                                                <table width="100%">
                                                    <tr runat="server" id="trroundTrip">
                                                        <td style="width: 100%">
                                                            <asp:Label ID="lblOriginDestinationRoundTrip" runat="server" Text="" Visible="false"></asp:Label>
                                                            <asp:GridView ID="gdvRoundtrip" Width="100%" runat="server" AutoGenerateColumns="False"
                                                                OnRowDataBound="gdvRoundtrip_RowDataBound" OnRowCommand="gdvRoundtrip_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table width="100%">
                                                                                <th width="20%" align="left">
                                                                                    Airline
                                                                                </th>
                                                                                <th width="20%" align="left">
                                                                                    Destinations
                                                                                </th>
                                                                                <th width="20%" align="left">
                                                                                    Departs
                                                                                </th>
                                                                                <th width="20%" align="left">
                                                                                    Arrives
                                                                                </th>
                                                                                <th width="20%" align="left">
                                                                                    Duration
                                                                                </th>
                                                                                <th width="20%" align="left">
                                                                                    Fare
                                                                                </th>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOriginDestiantionOptionid" Visible="false" runat="server" Text='<%# Eval("OriginDestinationOption_Id") %>'></asp:Label>
                                                                                        <asp:Label ID="lblOnwardAirline" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardDestinations" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardDeparts" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardArrives" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardDuration" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblTotalPrice" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                                                                                        <asp:Button ID="btnBookNowRoundTrip" runat="server" Text="Book Now" CommandName="BookTicket"
                                                                                            CssClass="buttonBook" CommandArgument='<%# Eval("OriginDestinationOption_Id") %>' />
                                                                                                  <asp:LinkButton ID="lnkDetails" runat="server" CommandName="View Details" CommandArgument='<%# Eval("OriginDestinationOption_Id") %>'  OnClick="lnkDummyRound_Click">Details</asp:LinkButton>
                                                                                                  <br />
                                                                                                    <asp:LinkButton ID="lnkFareDet" runat="server" Font-Underline="false">Fare Details</asp:LinkButton>
                                                                                        <ajax:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkFareDet"
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
                                                                                                                    <asp:Label ID="lblBaseFarereturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblflighno" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblflighnoreturn" runat="server" Visible="false"></asp:Label>
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
                                                                                                                    <asp:Label ID="lblTaxreturn" runat="server" Visible="false"></asp:Label>
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
                                                                                                                    <asp:Label ID="lblSTaxreturn" runat="server" Visible="false"></asp:Label>
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
                                                                                                                    <asp:Label ID="lblSChargereturn" runat="server" Visible="false"></asp:Label>
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
                                                                                                                    <asp:Label ID="lblTDiscountreturn" runat="server" Visible="false"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                             <tr >
                                                                                                                <td>
                                                                                                                   Trn Chrg/fees
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    Rs.
                                                                                                                    <asp:Label ID="lblTcharge" runat="server"></asp:Label>
                                                                                                                  
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
                                                                                                                    <asp:Label ID="lblTotalreturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblPartnerCommreturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lbladultonereturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblchildonereturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblinfantonereturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblTriponereturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblAirlineNamereturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblarrivaldate" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lbldepartdate" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblarrivaldatereturn" runat="server" Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lbldepartdatereturn" runat="server" Visible="false"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trConnectingFlights" runat="server">
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardConnectingFlights" runat="server" Visible="false" Text="Connecting Flights"></asp:Label>
                                                                                        <asp:Label ID="lblOnwardConnectingAirline" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardConnectingDestinations" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardConnectingDeparts" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardConnectingArrives" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblOnwardConnectingDuration" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="tr1" runat="server">
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnConnectingFlights" runat="server" Visible="false" Text="Connecting Flights"></asp:Label>
                                                                                        <asp:Label ID="lblReturnConnectingAirline" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnConnectingDestinations" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnConnectingDeparts" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnConnectingArrives" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnConnectingDuration" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnAirline" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnDestinations" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnDeparts" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnArrives" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:Label ID="lblReturnDuration" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <AlternatingRowStyle CssClass="gridAlter" />
                                                                <RowStyle CssClass="gridAlter" />
                                                                <HeaderStyle BackColor="LightBlue" />
                                                            </asp:GridView>


                                                              <asp:LinkButton ID="lnkDummyOnward" runat="server" Style="display: none" CausesValidation="false">
                                                              </asp:LinkButton>
     <ajax:ModalPopupExtender ID="mpeAirlineDetOnward" runat="server" PopupControlID="pnlAirlineDetailsonward"
     TargetControlID="lnkDummyOnward" X="350" Y="250" BackgroundCssClass="modalBackground" OkControlID="btnokonward">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlAirlineDetailsonward" runat="server" style="position:fixed; top:0px; left:0px; display:none; border:background:url(images/overlay1.png);  width:600;height:200;padding-top:10px;text-align:center; z-index:1; padding-left:10px; padding-right:10px;padding-right:10px" 
align="center">
         <table width="600" bgcolor="#eefaff"  style="border:#222 5px solid;" height="100">
         <tr>
         <td colspan="4" align="left" >
         Onward Flights
         </td>
         </tr>
        <tr><th>Airline</th><th>Departs</th><th>Arrives</th><th>Duration</th></tr>
        <tr><td>
        <asp:Label ID="lblOperatingAirlineNameDetonward" runat="server"></asp:Label><br />                                                       
        <asp:Label ID="lblMarketingAirlinenoonward" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDetonward" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDetonward" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDetonward" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDetonward" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDetonward" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDetonward" runat="server" ></asp:Label><br/>
              </td>
        </tr>
       <tr runat="server" id="trConnecting1onward" visible="false"><td>
        <asp:Label ID="lblOperatingAirlineNameDet1onward" runat="server"></asp:Label><br />                                                       
         <asp:Label ID="lblMarketingAirlineno1onward" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDet1onward" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet1onward" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet1onward" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet1onward" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet1onward" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDet1onward" runat="server" ></asp:Label><br/>
              </td>
        </tr>
      
        <tr runat="server" id="trConnecting2onward" visible="false"><td>
        <asp:Label ID="lblOperatingAirlineNameDet2onward" runat="server"></asp:Label><br />                                                       
         <asp:Label ID="lblMarketingAirlineno2onward" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDet2onward" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet2onward" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet2onward" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet2onward" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet2onward" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDet2onward" runat="server" ></asp:Label><br/>
              </td>
        </tr>

        <tr>
        <td colspan="4" style="border-bottom:1px Solid Black;">

        </td>
        </tr>
         <tr>
         <td colspan="4" align="left">
         Return Flights
         </td>
         </tr>

         <tr><td>
        <asp:Label ID="lblOperatingAirlineNameDetreturn" runat="server"></asp:Label><br />                                                       
        <asp:Label ID="lblMarketingAirlinenoreturn" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDetreturn" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDetreturn" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDetreturn" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDetreturn" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDetreturn" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDetreturn" runat="server" ></asp:Label><br/>
              </td>
        </tr>
       <tr runat="server" id="trConnecting1return" visible="false"><td>
        <asp:Label ID="lblOperatingAirlineNameDet1return" runat="server"></asp:Label><br />                                                       
         <asp:Label ID="lblMarketingAirlineno1return" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDet1return" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet1return" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet1return" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet1return" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet1return" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDet1return" runat="server" ></asp:Label><br/>
              </td>
        </tr>
      
        <tr runat="server" id="trConnecting2return" visible="false"><td>
        <asp:Label ID="lblOperatingAirlineNameDet2return" runat="server"></asp:Label><br />                                                       
         <asp:Label ID="lblMarketingAirlineno2return" runat="server" ></asp:Label> 
        <asp:Label ID="lblOperatingAirlineFlightNumberDet2return" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet2return" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet2return" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet2return" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet2return" runat="server" ></asp:Label>
        </td>
           <td>
           <br />
        <asp:Label ID="lblDurationDet2return" runat="server" ></asp:Label><br/>
              </td>
        </tr>


      
        <tr><td>&nbsp;</td></tr>
        <tr><td align="center" colspan="4">
            <asp:Button ID="btnokonward" runat="server" Text="Ok" CssClass="buttonBook" /></td></tr>
        </table>
    </asp:Panel>
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
                    <div>
                        <asp:Label ID="lblIntFlightSegmentId" runat="server" Visible="false"></asp:Label></div>
                    <%--<asp:Panel ID="pnlIntPassengerDet" runat="server" Visible="false">
                        <table width="100%">
                            <tr>
                                <td width="80%" valign="top">
                                    <table width="100%" border="1px">
                                        <tr>
                                            <td>
                                                <b>
                                                    <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red"></asp:Label></b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#0062af" style="color: White">
                                                <b>Passenger Details</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Table runat="server" ID="tblAdultsInt">
                                                        </asp:Table>
                                                        <asp:Table runat="server" ID="tblChildInt">
                                                        </asp:Table>
                                                        <asp:Table runat="server" ID="tblInfantsInt">
                                                        </asp:Table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Mobile Number : "></asp:Label>
                                                <asp:TextBox ID="txtMobileNumInt" runat="server" MaxLength="10"></asp:TextBox>&nbsp;
                                                (Will be contacted in case of flight delay etc..)
                                                <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNumInt"
                                                    ErrorMessage="Enter Mobile Number" Display="Dynamic" ValidationGroup="Submitint"></asp:RequiredFieldValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="0123456789"
                                                    TargetControlID="txtMobileNumInt">
                                                </ajax:FilteredTextBoxExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNumInt"
                                                    ErrorMessage="Invalid mobile no" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1px">
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
                                                <asp:DropDownList ID="ddlTitleInt" runat="server">
                                                    <asp:ListItem Value="Mr" Selected="True">Mr</asp:ListItem>
                                                    <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                    <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFirstnameInt" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvFirstNameInt" ValidationGroup="Submitint" runat="server"
                                                    ErrorMessage="Enter First Name" ControlToValidate="txtFirstnameInt" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    TargetControlID="txtFirstnameInt">
                                                </ajax:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLastNameInt" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvLastNameInt" runat="server" ValidationGroup="Submitint"
                                                    Display="Dynamic" ErrorMessage="Enter Last Name" ControlToValidate="txtFirstnameInt"></asp:RequiredFieldValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    TargetControlID="txtLastNameInt">
                                                </ajax:FilteredTextBoxExtender>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="TextValidate"
                                                    Display="None" ControlToValidate="txtLastNameInt" ErrorMessage="Text must be 2 or more characters."
                                                    ValidationGroup="Submitint">
                                                </asp:CustomValidator>
                                                <ajax:ValidatorCalloutExtender ID="compare" runat="server" TargetControlID="CustomValidator1">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                LandLine No
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPhoneNumInt" runat="server" MaxLength="15"></asp:TextBox>
                                               

                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789"
                                                    TargetControlID="txtPhoneNumInt">
                                                </ajax:FilteredTextBoxExtender>
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
                                                <asp:TextBox ID="txtMobileNumberInt" runat="server" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvMobileNumInt" runat="server" ErrorMessage="Enter Mobile Number"
                                                    ValidationGroup="Submitint" Display="Dynamic" ControlToValidate="txtMobileNumInt"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rgfvalidater" runat="server" ControlToValidate="txtMobileNumberInt"
                                                    ErrorMessage="Invalid mobile no" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789"
                                                    TargetControlID="txtMobileNumberInt">
                                                </ajax:FilteredTextBoxExtender>
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
                                                <asp:TextBox ID="txtEmailIDInt" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvMobileInt" runat="server" ErrorMessage="Enter Email ID"
                                                    Display="Dynamic" ValidationGroup="Submitint" ControlToValidate="txtEmailIDInt"></asp:RequiredFieldValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtEmailIDInt"
                                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                </ajax:FilteredTextBoxExtender>
                                                <asp:RegularExpressionValidator ID="regularmail" runat="server" ControlToValidate="txtEmailIDInt"
                                                    Display="Dynamic" ValidationGroup="Submitint" ErrorMessage="Invalid EmailId"
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
                                                <asp:TextBox ID="txtConfirmEmailInt" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtConfirmEmailInt" runat="server" ErrorMessage="Enter Confirm Email ID"
                                                    Display="Dynamic" ValidationGroup="Submitint" ControlToValidate="txtConfirmEmailInt"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtConfirmEmailInt"
                                                    Display="Dynamic" ValidationGroup="Submitint" ErrorMessage="Invalid EmailId"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtConfirmEmailInt"
                                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                </ajax:FilteredTextBoxExtender>
                                                <asp:CompareValidator ID="vlc" runat="server" Display="None" ControlToValidate="txtConfirmEmailInt"
                                                    ValidationGroup="Submitint" ErrorMessage="Emailid & Confirm Emailid should be same"
                                                    ControlToCompare="txtEmailIDInt" Operator="Equal"></asp:CompareValidator>
                                                <ajax:ValidatorCalloutExtender ID="vvvlc" runat="server" TargetControlID="vlc">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1px">
                                        <tr>
                                            <td bgcolor="#0062af" style="color: White" colspan="3">
                                                <b>Address Details</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                Address<span style="color: Red">*</span>
                                            </td>
                                            <td width="5">
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAddressInt" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAddressInt" runat="server" ErrorMessage="Enter Address"
                                                    Display="Dynamic" ControlToValidate="txtAddressInt" ValidationGroup="Submitint"></asp:RequiredFieldValidator>
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
                                                <asp:TextBox ID="txtCityInt" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtCityInt" runat="server" ErrorMessage="Enter City"
                                                    ValidationGroup="Submitint" ControlToValidate="txtCityInt"></asp:RequiredFieldValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtCityInt"
                                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                </ajax:FilteredTextBoxExtender>
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
                                                <asp:TextBox ID="txtStateInt" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtStateInt" runat="server" ErrorMessage="Enter State"
                                                    ValidationGroup="Submitint" ControlToValidate="txtStateInt"></asp:RequiredFieldValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtStateInt"
                                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                </ajax:FilteredTextBoxExtender>
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
                                                <asp:TextBox ID="txtPostalCodeInt" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtPostalCodeInt" runat="server" ErrorMessage="Enter Postal Code"
                                                    ValidationGroup="Submitint" ControlToValidate="txtPostalCodeInt"></asp:RequiredFieldValidator>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="0123456789"
                                                    TargetControlID="txtPostalCodeInt">
                                                </ajax:FilteredTextBoxExtender>
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
                                                <asp:DropDownList ID="ddlCountryInt" runat="server">
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
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnIntBook" runat="server" CssClass="buttonBook" Text="Submit" OnClick="btnIntBook_Click" />
                                                <asp:Button ID="btnIntBookRoundTrip" runat="server" CssClass="buttonBook" Text="Submit"
                                                    OnClick="btnIntBookRoundTrip_Click" />
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
                                                                                        <asp:Label ID="lblServiceTaxreturn" runat="server"></asp:Label>
                                                                                        <asp:Label ID="lblServiceTax" Visible="false" runat="server"></asp:Label>
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
                                                                                        <asp:Label ID="lblPartnerComm1" runat="server" Visible="false"></asp:Label>
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
                    </asp:Panel>--%>
                    <asp:Panel ID="pnlIntPassengerDet" runat="server" Visible="false" BackColor="White">
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td width="100%" valign="top">
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="padding:5px;">
                                                    <tr>
                                                        <td>
                                                            <b>
                                                                <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td bgcolor="#0062af" style="color: White" >
                                                            <b>Passenger Details</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Table runat="server" ID="tblAdultsInt">
                                                                    </asp:Table>
                                                                    <asp:Table runat="server" ID="tblChildInt">
                                                                    </asp:Table>
                                                                    <asp:Table runat="server" ID="tblInfantsInt">
                                                                    </asp:Table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td Height="30px">
                                                            <asp:Label ID="Label2" runat="server" Text="Mobile Number "></asp:Label><span style="color: Red;">*</span>:
                                                            <asp:TextBox ID="txtMobileNumInt" runat="server" MaxLength="10" CssClass="lj_inp" onchange="javascript:txttextchanged();" ></asp:TextBox>&nbsp;
                                                            (Will be contacted in case of flight delay etc..)
                                                            <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNumInt"
                                                                ErrorMessage="Enter Mobile Number" Display="None" ValidationGroup="SubmitBook"></asp:RequiredFieldValidator>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="0123456789"
                                                                TargetControlID="txtMobileNumInt">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNumInt"
                                                                ValidationGroup="SubmitBook" ErrorMessage="Invalid mobile no" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--<table width="100%" cellpadding="0" cellspacing="0" border="0">
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
                                                            Title
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlTitleInt" runat="server">
                                                                <asp:ListItem Value="Mr" Selected="True">Mr</asp:ListItem>
                                                                <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                                <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFirstnameInt" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvFirstNameInt" ValidationGroup="SubmitBook" runat="server"
                                                                ErrorMessage="Enter First Name" ControlToValidate="txtFirstnameInt" Display="None"></asp:RequiredFieldValidator>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                                TargetControlID="txtFirstnameInt">
                                                            </ajax:FilteredTextBoxExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLastNameInt" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvLastNameInt" runat="server" ValidationGroup="SubmitBook"
                                                                Display="None" ErrorMessage="Enter Last Name" ControlToValidate="txtFirstnameInt"></asp:RequiredFieldValidator>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                                TargetControlID="txtLastNameInt">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="TextValidate"
                                                                Display="None" ControlToValidate="txtLastNameInt" ErrorMessage="Text must be 2 or more characters."
                                                                ValidationGroup="SubmitBook">
                                                            </asp:CustomValidator>
                                                            <ajax:ValidatorCalloutExtender ID="compare" runat="server" TargetControlID="CustomValidator1">
                                                            </ajax:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="15%">
                                                            Mobile Number<span style="color: Red">*</span>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMobileNumberInt" runat="server" MaxLength="10"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvMobileNumInt" runat="server" ErrorMessage="Enter Mobile Number"
                                                                ValidationGroup="SubmitBook" Display="None" ControlToValidate="txtMobileNumInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceMobileNumber" runat="server" TargetControlID="rfvMobileNumInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="rgfvalidater" runat="server" ControlToValidate="txtMobileNumberInt"
                                                                ValidationGroup="SubmitBook" ErrorMessage="Invalid mobile no" ValidationExpression="\d{10}"
                                                                Display="None"></asp:RegularExpressionValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceMobileNumber1" runat="server" TargetControlID="rgfvalidater">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789"
                                                                TargetControlID="txtMobileNumberInt">
                                                            </ajax:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            LandLine No
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPhoneNumInt" runat="server" MaxLength="15"></asp:TextBox>
                                                           

                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789"
                                                                TargetControlID="txtPhoneNumInt">
                                                            </ajax:FilteredTextBoxExtender>
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
                                                            <asp:TextBox ID="txtEmailIDInt" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvMobileInt" runat="server" ErrorMessage="Enter Email ID"
                                                                Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtEmailIDInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceEmailid" runat="server" TargetControlID="rfvMobileInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtEmailIDInt"
                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:RegularExpressionValidator ID="regularmail" runat="server" ControlToValidate="txtEmailIDInt"
                                                                Display="None" ValidationGroup="SubmitBook" ErrorMessage="Invalid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceEmailId1" runat="server" TargetControlID="regularmail">
                                                            </ajax:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="15%" valign="top">
                                                            Confirm Email ID<span style="color: Red">*</span>
                                                        </td>
                                                        <td valign="top">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtConfirmEmailInt" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtConfirmEmailInt" runat="server" ErrorMessage="Enter Confirm Email ID"
                                                                Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtConfirmEmailInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="VceInterEmail" runat="server" TargetControlID="rfvtxtConfirmEmailInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtConfirmEmailInt">
                                                    Display="None" ValidationGroup="SubmitBook" ErrorMessage="Invalid EmailId"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceEmailId2" runat="server" TargetControlID="RegularExpressionValidator2">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtConfirmEmailInt"
                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:CompareValidator ID="vlc" runat="server" Display="None" ControlToValidate="txtConfirmEmailInt"
                                                                ErrorMessage="Emailid & Confirm Emailid should be same" ValidationGroup="SubmitBook"
                                                                ControlToCompare="txtEmailIDInt" Operator="Equal"></asp:CompareValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vvvlc" runat="server" TargetControlID="vlc">
                                                            </ajax:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                </table>--%>

                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding:5px;">
                                    <tr>
                                        <td colspan="10" bgcolor="#0062af" style="color: White">
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
                                        <td align="left" height="35px">
                                              <asp:DropDownList ID="ddlTitleInt" runat="server" CssClass="lj_inp" Width="50px">
                                                                <asp:ListItem Value="Mr" Selected="True">Mr</asp:ListItem>
                                                                <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                                <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                            </asp:DropDownList>
                                        </td>
                                        <td width="15%" style="padding-left:6px;">
                                         First Name<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center">
                                         :
                                        </td>
                                        <td>
                                              <asp:TextBox ID="txtFirstnameInt" runat="server" CssClass="lj_inp" MaxLength="20"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvFirstNameInt" ValidationGroup="SubmitBook" runat="server"
                                                                ErrorMessage="Enter First Name" ControlToValidate="txtFirstnameInt" Display="None"></asp:RequiredFieldValidator>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                                TargetControlID="txtFirstnameInt">
                                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td width="15%" style="padding-left:6px;">
                                         Last Name<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center">
                                         :
                                        </td>
                                        <td>
                                             <asp:TextBox ID="txtLastNameInt" runat="server" CssClass="lj_inp" MaxLength="20"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvLastNameInt" runat="server" ValidationGroup="SubmitBook"
                                                                Display="None" ErrorMessage="Enter Last Name" ControlToValidate="txtFirstnameInt"></asp:RequiredFieldValidator>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                                TargetControlID="txtLastNameInt">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="TextValidate"
                                                                Display="None" ControlToValidate="txtLastNameInt" ErrorMessage="Text must be 2 or more characters."
                                                                ValidationGroup="SubmitBook">
                                                            </asp:CustomValidator>
                                                            <ajax:ValidatorCalloutExtender ID="compare" runat="server" TargetControlID="CustomValidator1">
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
                                            <asp:TextBox ID="txtPhoneNumInt" runat="server" MaxLength="15" CssClass="lj_inp"></asp:TextBox>
                                                           

                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789"
                                                                TargetControlID="txtPhoneNumInt">
                                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left" width="20%" valign="top" style="padding-left:6px;">
                                            Mobile Number<span style="color: Red;">*</span>
                                        </td>
                                        <td align="center" width="15" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                             <asp:TextBox ID="txtMobileNumberInt" runat="server" MaxLength="10" CssClass="lj_inp"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvMobileNumInt" runat="server" ErrorMessage="Enter Mobile Number"
                                                                ValidationGroup="SubmitBook" Display="None" ControlToValidate="txtMobileNumInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceMobileNumber" runat="server" TargetControlID="rfvMobileNumInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="rgfvalidater" runat="server" ControlToValidate="txtMobileNumberInt"
                                                                ValidationGroup="SubmitBook" ErrorMessage="Invalid mobile no" ValidationExpression="\d{10}"
                                                                Display="None"></asp:RegularExpressionValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceMobileNumber1" runat="server" TargetControlID="rgfvalidater">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789"
                                                                TargetControlID="txtMobileNumberInt">
                                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left" width="15%" valign="top" style="padding-left:6px;">
                                            Email ID<span style="color: Red;">*</span>
                                        </td>
                                        <td align="center" width="15" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top" height="30px" >
                                           <asp:TextBox ID="txtEmailIDInt" runat="server" CssClass="lj_inp"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvMobileInt" runat="server" ErrorMessage="Enter Email ID"
                                                                Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtEmailIDInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceEmailid" runat="server" TargetControlID="rfvMobileInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtEmailIDInt"
                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:RegularExpressionValidator ID="regularmail" runat="server" ControlToValidate="txtEmailIDInt"
                                                                Display="None" ValidationGroup="SubmitBook" ErrorMessage="Invalid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceEmailId1" runat="server" TargetControlID="regularmail">
                                                            </ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%"  valign="top" height="35px">
                                            Confirm Email ID<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center" valign="top">
                                            :
                                        </td>
                                        <td valign="top" >
                                           <asp:TextBox ID="txtConfirmEmailInt" runat="server" CssClass="lj_inp" 
                                                
                                                ></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtConfirmEmailInt" runat="server" ErrorMessage="Enter Confirm Email ID"
                                                                Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtConfirmEmailInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="VceInterEmail" runat="server" TargetControlID="rfvtxtConfirmEmailInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtConfirmEmailInt"
                                                    Display="None" ValidationGroup="SubmitBook" ErrorMessage="Invalid EmailId"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceEmailId2" runat="server" TargetControlID="RegularExpressionValidator2">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtConfirmEmailInt"
                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:CompareValidator ID="vlc" runat="server" Display="None" ControlToValidate="txtConfirmEmailInt"
                                                                ErrorMessage="Emailid & Confirm Emailid should be same" ValidationGroup="SubmitBook"
                                                                ControlToCompare="txtEmailIDInt" Operator="Equal"></asp:CompareValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vvvlc" runat="server" TargetControlID="vlc">
                                                            </ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                </table>





                                                <%--<table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td bgcolor="#0062af" style="color: White" colspan="3">
                                                            <b>Address Details</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="15%">
                                                            Address<span style="color: Red">*</span>
                                                        </td>
                                                        <td width="5">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAddressInt" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtAddressInt" runat="server" ErrorMessage="Enter Address"
                                                                Display="None" ControlToValidate="txtAddressInt" ValidationGroup="SubmitBook"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceAddress" runat="server" TargetControlID="rfvtxtAddressInt">
                                                            </ajax:ValidatorCalloutExtender>
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
                                                            <asp:TextBox ID="txtCityInt" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtCityInt" runat="server" ErrorMessage="Enter City"
                                                                Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtCityInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="rfvtxtCityInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtCityInt"
                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                            </ajax:FilteredTextBoxExtender>
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
                                                            <asp:TextBox ID="txtStateInt" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtStateInt" runat="server" ErrorMessage="Enter State"
                                                                Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtStateInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="rfvtxtStateInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtStateInt"
                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                            </ajax:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Pin Code
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPostalCodeInt" runat="server" MaxLength="10"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtPostalCodeInt" runat="server" ErrorMessage="Enter Postal Code"
                                                                ValidationGroup="SubmitBook" ControlToValidate="txtPostalCodeInt" Display="None"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcePostalCode" runat="server" TargetControlID="rfvtxtPostalCodeInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="regularExpressionpincode" runat="server" ValidationExpression="\d{5}(-\d{4})?"
                                                                ErrorMessage="Invalid Pin Code" ControlToValidate="txtPostalCodeInt"></asp:RegularExpressionValidator>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="0123456789"
                                                                TargetControlID="txtPostalCodeInt">
                                                            </ajax:FilteredTextBoxExtender>
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
                                                            <asp:DropDownList ID="ddlCountryInt" runat="server">
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
                                                        </td>
                                                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountryInt"
                                                            ErrorMessage="Please Select Country" Display="None" ValidationGroup="SubmitBook"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceCounty" TargetControlID="rfvCountry" runat="server">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </tr>
                                                </table>--%>


                                                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="padding:5px;">
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
                                             <asp:TextBox ID="txtAddressInt" runat="server" CssClass="lj_inp"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtAddressInt" runat="server" ErrorMessage="Enter Address"
                                                                Display="None" ControlToValidate="txtAddressInt" ValidationGroup="SubmitBook"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceAddress" runat="server" TargetControlID="rfvtxtAddressInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                   
                                        </td>
                                         <td align="left" width="15%" style="padding-left:6px;">
                                            City / Town<span style="color: Red;">*</span>
                                        </td>
                                        <td align="center" width="5%">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCityInt" runat="server" CssClass="lj_inp"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtCityInt" runat="server" ErrorMessage="Enter City"
                                                                Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtCityInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="rfvtxtCityInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtCityInt"
                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                         <td align="left" width="15%" style="padding-left:6px;" >
                                            State<span style="color: Red;">*</span>
                                        </td>
                                        <td align="center" width="5%">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStateInt" runat="server" CssClass="lj_inp"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtStateInt" runat="server" ErrorMessage="Enter State"
                                                                Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtStateInt"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="rfvtxtStateInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtStateInt"
                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_">
                                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                   

                                    <tr>
                                        <td width="15%" align="left" valign="top">
                                            Pin Code<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center" valign="top">
                                            :
                                        </td>
                                        <td>
                                              <asp:TextBox ID="txtPostalCodeInt" runat="server" MaxLength="6" CssClass="lj_inp"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtPostalCodeInt" runat="server" ErrorMessage="Enter Postal Code"
                                                                ValidationGroup="SubmitBook" ControlToValidate="txtPostalCodeInt" Display="None"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcePostalCode" runat="server" TargetControlID="rfvtxtPostalCodeInt">
                                                            </ajax:ValidatorCalloutExtender>
                                                           <%-- <asp:RegularExpressionValidator ID="regularExpressionpincode" runat="server" ValidationExpression="\d{5}(-\d{4})?"
                                                                ErrorMessage="Invalid Pin Code" ControlToValidate="txtPostalCodeInt"></asp:RegularExpressionValidator>--%>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="0123456789"
                                                                TargetControlID="txtPostalCodeInt">
                                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td width="15%" style="padding-left:6px;"  valign="top">
                                            Country<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center" valign="top">
                                            :
                                        </td>
                                        <td valign="top">
                                              <asp:DropDownList ID="ddlCountryInt" runat="server" CssClass="lj_inp">
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
                                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountryInt"
                                                            ErrorMessage="Please Select Country" Display="None" ValidationGroup="SubmitBook"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceCounty" TargetControlID="rfvCountry" runat="server">
                                                        </ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                   

                                </table>



                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnIntBook" runat="server" CssClass="buttonBook" Text="Submit" OnClick="btnIntBook_Click"
                                                                ValidationGroup="SubmitBook" />

                                                          
                                                            <asp:Button ID="btnIntBookRoundTrip" runat="server" CssClass="buttonBook" Text="Submit" Visible="false"
                                                                OnClick="btnIntBookRoundTrip_Click" />
                                                                  <asp:Button ID="btnBack" runat="server" CssClass="buttonBook" Text="Back"  onclick="btnBack_Click"  />
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
                                                                                                    <asp:Label ID="lblServiceTaxreturn" runat="server"></asp:Label>
                                                                                                    <asp:Label ID="lblServiceTax" Visible="false" runat="server"></asp:Label>
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
                                                                                             <tr >
                                                                        <td>
                                                                             Trn Chg / Fees
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            Rs.
                                                                            <asp:Label ID="lblTChargeFareBreak" runat="server"></asp:Label>
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
                                                                                                    <asp:Label ID="lblPartnerComm1" runat="server" Visible="false"></asp:Label>
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
                    <asp:Panel ID="pnlCancelInt" runat="server" Visible="false">
                        <asp:Button ID="btnBookStatusInt" runat="server" Text="Get Booking Status" OnClick="btnBookStatusInt_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCancelTicketInt" runat="server" Text="Cancel Ticket" OnClick="btnCancelTicketInt_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btnCancelTicketStatusInt" runat="server" Text="Cancel Ticket Status"
                            OnClick="btnCancelTicketStatusInt_Click" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlViewticket" runat="server" Visible="false" Width="900">
            <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="900" align="center">
                        <table width="900" align="center">
                            <tr id="downlink" runat="server">
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
                                                        <img src="http://Lovejourney.in/images/logo.gif" width="143" height="88" border="0"
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
                                            <table width="100%">
                                              <tr>
                                        <td  width="40%">
                                        <table  width="90%" class="rightborder">
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
                                                  
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Email ID :
                                                        <asp:Label ID="lblEmailAddress" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                </table>
                                                </td>
                                                 <td  width="30%" class="rightborder">
                                                
                                                  <asp:Label ID="Label5" runat="server"   Text=" Your Airline PNR :" CssClass="pnrbold"></asp:Label>
                                                            <asp:Label ID="lblAirlinePNR" runat="server"  CssClass="pnrbold"></asp:Label>
                                                </td>
                                              <td  width="30%" style="padding-left:10px;">
                                                 <table>
                                                 <tr>
                                                 
                                                 <td>
                                                  <img src="../../images/barcode.png" />
                                                 </td>
                                                 </tr>
                                                 
                                                 <tr>
                                                 <td>
                                                   <asp:Label ID="Label6" runat="server" Text="Love Journey Ref NO :" Visible="false"></asp:Label>
                                             
                                                            <asp:Label ID="lblPNR" runat="server"></asp:Label>
                                                 </td>
                                                 </tr>
                                                 </table>
                                               
                                             
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
                                                        <%--Your Airline PNR :
                                                        <asp:Label ID="lblPNR" runat="server"></asp:Label>--%>
                                                        Eticket No's are :
                                                        <asp:Label ID="lblEticketNo" runat="server"></asp:Label>
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
                                                    <%--   <th>
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
                                                    <%--   <td>
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
                                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
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
        <asp:Panel ID="pnl" runat="server" style="position:fixed; top:0px; left:0px; display:none; border:background:url(images/overlay1.png);  width:100;height:200;padding-top:10px;text-align:center; z-index:1;" 
>
            <table width="300" bgcolor="#eefaff"  style="border:#222 5px solid;" height="100">
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
    </asp:Panel>
</asp:Content>
