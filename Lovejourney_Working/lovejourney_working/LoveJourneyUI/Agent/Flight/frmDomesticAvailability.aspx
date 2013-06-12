<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Flight/MasterPage.master"
    AutoEventWireup="true" CodeFile="frmDomesticAvailability.aspx.cs" Inherits="Agent_Flight_frmDomesticAvailability" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LoveJourney - Book Flight Tickets Online. </title>
    <link href="../../css/accordian.css" rel="stylesheet" type="text/css" />   
    <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="http://jquery.malsup.com/block/jquery.blockUI.js?v2.38" type="text/javascript"></script>
    <style type ="text/css">
    .clsFind
    {
    }
</style>
  <script language ="javascript" type="text/javascript">


      function showHNF() {

          if (document.getElementById("<%=lnkSNFFare.ClientID %>").text == "SNF") {
              document.getElementById("<%=lnkSNFFare.ClientID %>").text = "HNF";
              var con = $(".clsFind");
              con.show();
              return false;
           
          }
          else if(document.getElementById("<%=lnkSNFFare.ClientID %>").text == "HNF"){
              var con = $(".clsFind");
              con.hide();
              document.getElementById("<%=lnkSNFFare.ClientID %>").text = "SNF";
              document.getElementById('<%=lnkSNFFare.ClientID %>').show();
              return false;
          }
      }
     
  
  </script>

   <script language ="javascript" type="text/javascript">


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
               document.getElementById('<%=lnkSNFFareroundtrip.ClientID %>').show();
               return false;
           }
       }
     
  
  </script>
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
            var v = document.getElementById('<%=txtLastName.ClientID %>').value;
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
            var month = nowdatetime.getMonth()+1;           
            var day = nowdatetime.getDate();
            var year = nowdatetime.getFullYear();
            var nowdate = day + "/" + month + "/" + year;          
           
            var date1 = new Date(date2);
            var date3 = new Date(nowdate);
           // alert("date:"+date1);
            //alert("sys"+nowdatetime);
           // alert(date3);
            if (date1 > nowdatetime) {
                txtBirthDateClientId.value = null ;
                alert("Birthdate must be less than or equal to Current date.");
                return false;
            }
            else {

                return true;
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
</script>
    <script type="text/javascript">
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
        function startsearch() {
           

            var Source = document.getElementById('<%=ddlSources.ClientID%>');
            //alert(Source);
            var val = Source.options[Source.selectedIndex].text;

            //alert(val);
            var Destination = document.getElementById('<%=ddlDestinations.ClientID%>');
            var val2 = Destination.options[Destination.selectedIndex].text;
            //alert(val2);
            if (val == val2) {
                alert('Source and Destination Can not  be Same');
                return false;
            }

            var rbtnOneWay = document.getElementById('<%=rbtnOneWay.ClientID %>');

            var Date1 = document.getElementById('<%=txtFromDate.ClientID %>').value;

            var Date2 = document.getElementById('<%=txtReturnDate.ClientID %>').value;



            if (rbtnOneWay.checked) {


                showDiv();


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
            var Source = document.getElementById('<%=ddlSourcesSearch.ClientID%>');
            //alert(Source);
            var val = Source.options[Source.selectedIndex].text;

            //alert(val);
            var Destination = document.getElementById('<%=ddlDestinationsSearch.ClientID%>');
            var val2 = Destination.options[Destination.selectedIndex].text;
            //alert(val2);
            if (val == val2) {
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
                else
                if (Date3 > Date4) {

                    alert('Return date can not before the Depart date');
                    return false;


                }
                else {
                   
                    showDiv4();
                }
        }
        
        function txttextchanged() {

            document.getElementById("ctl00_ContentPlaceHolder1_txtFirstname").value = document.getElementById("ctl00_ContentPlaceHolder1_txtFn1").value;
            document.getElementById("ctl00_ContentPlaceHolder1_txtLastName").value = document.getElementById("ctl00_ContentPlaceHolder1_txtLn1").value;
            document.getElementById("ctl00_ContentPlaceHolder1_dlTitle").options[document.getElementById("ctl00_ContentPlaceHolder1_dlTitle").selectedIndex].Text = document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle1").options[document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle1").selectedIndex].Text;
        }
        function ChangeUserDetails() {
            document.getElementById("dlTitle").value = document.getElementById("ddlTitle0").value;
            document.getElementById("txtFirstname").value = document.getElementById("txtFn0").value;
            document.getElementById("txtLastName").value = document.getElementById("txtLn0").value;
        }
        function Load() {
           
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
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

                $(".datepicker1").datepicker({
                    dateFormat: 'yy-mm-dd',
                    showOn: "button",
                    numberOfMonths: 2,
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday
                });
                $(".datepicker2").datepicker({
                    dateFormat: 'dd-M-yy',
                    showOn: "button",
                    numberOfMonths: 1,
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    maxDate: dateToday
                });
            }
        }
        function showDate() {
            $(".datepicker").datepicker("show");
        }
        function showDate1() {
            $(".datepicker1").datepicker("show");
        }
        function showDate2() {
                    
          $(".datepicker2").datepicker("show");
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
        $(function () {
            var dateToday = new Date();
            $(".datepicker2").datepicker({
                dateFormat: 'dd-M-yy',
                showOn: "button",
                numberOfMonths: 1,
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                maxDate: dateToday
                
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
                setTimeout('document.images["myAnimatedImage"].src = "../../Images/roller_big.gif"', 200);
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
                setTimeout('document.images["myAnimatedImage"].src = "Images/roller_big.gif"', 200);
            }
            else {
                return false;
            }
        }

        

      
    </script>
     <script type="text/javascript">
         function go() {
             var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text1').value = SelectedText;
         }
         function go1() {
             var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text2').value = SelectedText;
         }
         function go2() {
             var SelectedText = document.getElementById('<%=txtFromDate.ClientID %>');
             var strAr = SelectedText.value.split("-");
             var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
             document.getElementById('Text3').value = sel;


         }

         function goInt() {
             var DropdownList = document.getElementById('<%=ddlSourcesSearch.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text4').value = SelectedText;
         }
         function go1Int() {
             var DropdownList = document.getElementById('<%=ddlDestinationsSearch.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text5').value = SelectedText;
         }
         function go2Int() {
             var SelectedText = document.getElementById('<%=txtdatesearch.ClientID %>');
             var strAr = SelectedText.value.split("-");
             var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
             document.getElementById('Text6').value = sel;
         }

         function gor() {
             var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text7').value = SelectedText;
         }
         function gor1() {
             var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text8').value = SelectedText;
         }
         function gor2() {
             var SelectedText = document.getElementById('<%=txtFromDate.ClientID %>');

             var strAr = SelectedText.value.split("-");
             var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
             document.getElementById('Text9').value = sel;
         }



         function gor3() {
             var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text10').value = SelectedText;
         }
         function gor4() {
             var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text11').value = SelectedText;
         }
         function gor5() {
             var SelectedText = document.getElementById('<%=txtReturnDate.ClientID %>');

             var strAr = SelectedText.value.split("-");
             var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
             document.getElementById('Text12').value = sel;
         }


         function gorint() {
             var DropdownList = document.getElementById('<%=ddlSourcesSearch.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text13').value = SelectedText;
         }
         function gor1int() {
             var DropdownList = document.getElementById('<%=ddlDestinationsSearch.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text14').value = SelectedText;
         }
         function gor2int() {
             var SelectedText = document.getElementById('<%=txtdatesearch.ClientID %>');

             var strAr = SelectedText.value.split("-");
             var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
             document.getElementById('Text15').value = sel;
         }



         function gor3int() {
             var DropdownList = document.getElementById('<%=ddlDestinationsSearch.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text16').value = SelectedText;
         }
         function gor4int() {
             var DropdownList = document.getElementById('<%=ddlSourcesSearch.ClientID %>');
             var SelectedIndex = DropdownList.selectedIndex;
             var SelectedValue = DropdownList.value;
             var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
             document.getElementById('Text17').value = SelectedText;
         }
         function gor5int() {
             var SelectedText = document.getElementById('<%=txtretundatesearch.ClientID %>');

             var strAr = SelectedText.value.split("-");
             var sel = strAr[2] + "-" + strAr[1] + "-" + strAr[0];
             document.getElementById('Text18').value = sel;
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
<table width="100%" cellpadding="0"  cellspacing="0" border="0">
   <tr>
     <td align="center">
    <table width="964" border="0" class="container">  
        <tr>
            <td valign="top">
                <div>  
              <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    <asp:Panel ID="pnlSearch" runat="server">
                     
                        <table style="width: 100%" id="tblSearch" runat="server"  valign="top">
                            <tr>
                                <td>
                                    <table width="100%">                               
                                        <tr>
                                            <td width="100%">
                                                <table align="center"  width="100%" border="0"
                                                    cellpadding="0" cellspacing="0">
                                                    <tbody>
                                                        <table ID="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" 
                                                            width="400">
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                        <tr align="left">
                                                                            <td align="right" height="23" valign="bottom" width="24">
                                                                                <img src="../../images/formtop_left.png" />
                                                                            </td>
                                                                            <td class="form_top" width="347">
                                                                                &nbsp;</td>
                                                                            <td align="left" height="23" valign="bottom" width="29">
                                                                                <img src="../../images/formright_top.png" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="form_left">
                                                                                &nbsp;</td>
                                                                            <td align="left" width="347">
                                                                                <table align="center" bgcolor="#ffffff" border="0" cellpadding="0" 
                                                                                    cellspacing="0" valign="top" width="347">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td align="center" width="347">
                                                                                                <table ID="tbl_domesticFlights" runat="server" align="center" border="0" 
                                                                                                    cellpadding="0" cellspacing="0" width="347">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="left" height="39" valign="top">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" height="50" width="347">
                                                                                                                    <tr>
                                                                                                                        <td width="50">
                                                                                                                            <img src="../../Image/flight_button.png" width="50" height="37" />
                                                                                                                        </td>
                                                                                                                        <td align="left" class="online_booking" valign="middle">
                                                                                                                            Domestic Flight Tickets Booking</td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="border_top" colspan="2" height="12">
                                                                                                                            &nbsp;</td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" height="280" width="100%">
                                                                                                                    <tbody>
                                                                                                                        <tr>
                                                                                                                            <td align="center" bgcolor="#ffffff" valign="top">
                                                                                                                                <div ID="DomesticFlight" style="display: block;">
                                                                                                                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                                                                                                                                        <tr>
                                                                                                                                            <td align="left" height="28" valign="top">
                                                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                                    <tr>
                                                                                                                                                        <td align="left" class="lj_one" valign="middle" width="155" colspan="2">
                                                                                                                                                            <asp:RadioButton ID="rbtnOneWay" runat="server" AutoPostBack="True" 
                                                                                                                                                                Checked="true" Font-Names="Arial" GroupName="ONE" 
                                                                                                                                                                OnCheckedChanged="rbtnOneWay_CheckedChanged" TabIndex="0" Text="  One Way" />
                                                                                                                                                        </td>
                                                                                                                                                        <td align="left" class="lj_one" valign="middle">
                                                                                                                                                            <asp:RadioButton ID="rbtnRoundTrip" runat="server" AutoPostBack="True" 
                                                                                                                                                                Font-Names="Arial" GroupName="ONE" 
                                                                                                                                                                OnCheckedChanged="rbtnRoundTrip_CheckedChanged" TabIndex="1" 
                                                                                                                                                                Text="  Round Trip" />
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                    <tr>
                                                                                                                                                        <td height="10px">
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                    <tr>
                                                                                                                                                        <td align="left" class="lj_hd" height="28" valign="top" width="150">
                                                                                                                                                            Leaving From
                                                                                                                                                        </td>
                                                                                                                                                        <td align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                        <td align="left" height="28" valign="top">
                                                                                                                                                            <asp:DropDownList ID="ddlSources" runat="server" class="lj_inp" TabIndex="2" 
                                                                                                                                                                ValidationGroup="Search" Width="150px">
                                                                                                                                                                <asp:ListItem Selected="True" Value="BOM">MUMBAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="line1">-------------------------------</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXA">AGARTALA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AGX">AGATTI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AGR">AGRA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AMD">AHMEDABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AJL">AIJWAL</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AKD">AKOLA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXD">ALLAHABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXV">ALONG</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="ATQ">AMRITSAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXU">AURANGABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXB">BAGDOGRA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RGH">BALURGHAT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXG">BELGAUM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BEP">BELLARY</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BUP">BHATINDA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BHU">BHAVNAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BHO">BHOPAL</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BBI">BHUBANESHWAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BHJ">BHUJ</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KUU">BHUNTAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BKB">BIKANER</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PAB">BILASPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CCJ">CALICUT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CBD">CAR NICOBAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXC">CHANDIGARH</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="COK">COCHIN</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CJB">COIMBATORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="COH">COOCH BEHAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CDP">CUDDAPAH</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="NMB">DAMAN</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DAE">DAPARIZO</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DAI">DARJEELING</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DED">DEHRA DUN</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DEP">DEPARIZO</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DBD">DHANBAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DHM">DHARAMSALA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DIB">DIBRUGARH</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DMU">DIMAPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DIU">DIU</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GAY">GAYA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GOI">GOA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GOP">GORAKHPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GUX">GUNA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GAU">GUWAHATI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GWL">GWALIOR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HSS">HISSAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HBX">HUBLI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IMF">IMPHAL</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IDR">INDORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JLR">JABALPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JGB">JAGDALPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JAI">JAIPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JSA">JAISALMER</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXJ">JAMMU</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JGA">JAMNAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXW">JAMSHEDPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PYB">JEYPORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JDH">JODHPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JRH">JORHAT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXH">KAILASHAHAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXQ">KAMALPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXY">KANDLA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KNU">KANPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXK">KESHOD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HJR">KHAJURAHO</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXN">KHOWAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KLH">KOLHAPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KTU">KOTA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KUU">KULU</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="LTU">LATUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXL">LEH</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXI">LILABARI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="LKO">LUCKNOW</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="LUH">LUDHIANA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXM">MADURAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="LDA">MALDA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXE">MANGALORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MOH">MOHANBARI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MZA">MUZAFFARNAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MZU">MUZAFFARPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MYQ">MYSORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="NAG">NAGPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="NDC">NANDED</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="ISK">NASIK</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="NVY">NEYVELI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="OMN">OSMANABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PGH">PANTNAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXT">PASIGHAT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXP">PATHANKOT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PAT">PATNA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PNY">PONDICHERRY</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PBD">PORBANDAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXZ">PORTBLAIR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PNQ">PUNE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PUT">PUTTAPARTHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BEK">PUTTAPARTHY</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RPR">RAIPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RJA">RAJAHMUNDRY</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RAJ">RAJKOT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RJI">RAJOURI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RMD">RAMAGUNDAM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXR">RANCHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RTC">RATNAGIRI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="REW">REWA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RRK">ROURKELA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RUP">RUPSI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SXV">SALEM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TNI">SATNA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SHL">SHILLONG</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SSE">SHOLAPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXS">SILCHAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SLV">SIMLA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SXR">SRINAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="STV">SURAT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TEZ">TEZPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TEI">TEZU</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TJV">THANJAVUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TRV">TRIVANDRUM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TRZ">TIRUCHIRAPALLI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TIR">TIRUPATI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="ICH">TRICHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TCR">TUTICORIN</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="UDR">UDAIPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BDQ">VADODRA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="VNS">VARANASI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="VGA">VIJAYAWADA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="VTZ">VISHAKHAPATNAM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="WGC">WARANGAL</asp:ListItem>
                                                                                                                                                            </asp:DropDownList>
                                                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                                                                                                                ControlToValidate="ddlSources" Display="None" ErrorMessage="Select source." 
                                                                                                                                                                InitialValue="----------" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                                                                                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                                                                                                                                                TargetControlID="RequiredFieldValidator1">
                                                                                                                                                            </ajax:ValidatorCalloutExtender>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </table>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="28" valign="top">
                                                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                                    <tr>
                                                                                                                                                        <td align="left" class="lj_hd" valign="top" width="150">
                                                                                                                                                            Leaving To 
                                                                                                                                                        </td>
                                                                                                                                                        <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                        <td align="left" valign="top">
                                                                                                                                                            <asp:DropDownList ID="ddlDestinations" runat="server" CssClass="lj_inp" 
                                                                                                                                                                onchange="showDate();" TabIndex="3" ValidationGroup="Search" Width="150px">
                                                                                                                                                                <asp:ListItem Selected="True" Value="DEL">DELHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="line1">-------------------------------</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXA">AGARTALA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AGX">AGATTI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AGR">AGRA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AMD">AHMEDABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AJL">AIJWAL</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="AKD">AKOLA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXD">ALLAHABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXV">ALONG</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="ATQ">AMRITSAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXU">AURANGABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXB">BAGDOGRA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RGH">BALURGHAT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXG">BELGAUM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BEP">BELLARY</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BUP">BHATINDA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BHU">BHAVNAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BHO">BHOPAL</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BBI">BHUBANESHWAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BHJ">BHUJ</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KUU">BHUNTAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BKB">BIKANER</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PAB">BILASPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CCJ">CALICUT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CBD">CAR NICOBAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXC">CHANDIGARH</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="COK">COCHIN</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CJB">COIMBATORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="COH">COOCH BEHAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CDP">CUDDAPAH</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="NMB">DAMAN</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DAE">DAPARIZO</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DAI">DARJEELING</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DED">DEHRA DUN</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DEP">DEPARIZO</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DBD">DHANBAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DHM">DHARAMSALA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DIB">DIBRUGARH</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DMU">DIMAPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="DIU">DIU</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GAY">GAYA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GOI">GOA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GOP">GORAKHPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GUX">GUNA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GAU">GUWAHATI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="GWL">GWALIOR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HSS">HISSAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HBX">HUBLI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IMF">IMPHAL</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IDR">INDORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JLR">JABALPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JGB">JAGDALPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JAI">JAIPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JSA">JAISALMER</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXJ">JAMMU</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JGA">JAMNAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXW">JAMSHEDPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PYB">JEYPORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JDH">JODHPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="JRH">JORHAT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXH">KAILASHAHAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXQ">KAMALPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXY">KANDLA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KNU">KANPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXK">KESHOD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="HJR">KHAJURAHO</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXN">KHOWAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KLH">KOLHAPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KTU">KOTA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="KUU">KULU</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="LTU">LATUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXL">LEH</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXI">LILABARI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="LKO">LUCKNOW</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="LUH">LUDHIANA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXM">MADURAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="LDA">MALDA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXE">MANGALORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MOH">MOHANBARI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MZA">MUZAFFARNAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MZU">MUZAFFARPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="MYQ">MYSORE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="NAG">NAGPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="NDC">NANDED</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="ISK">NASIK</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="NVY">NEYVELI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="OMN">OSMANABAD</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PGH">PANTNAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXT">PASIGHAT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXP">PATHANKOT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PAT">PATNA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PNY">PONDICHERRY</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PBD">PORBANDAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXZ">PORTBLAIR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PNQ">PUNE</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="PUT">PUTTAPARTHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BEK">PUTTAPARTHY</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RPR">RAIPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RJA">RAJAHMUNDRY</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RAJ">RAJKOT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RJI">RAJOURI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RMD">RAMAGUNDAM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXR">RANCHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RTC">RATNAGIRI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="REW">REWA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RRK">ROURKELA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="RUP">RUPSI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SXV">SALEM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TNI">SATNA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SHL">SHILLONG</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SSE">SHOLAPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="IXS">SILCHAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SLV">SIMLA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="SXR">SRINAGAR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="STV">SURAT</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TEZ">TEZPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TEI">TEZU</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TJV">THANJAVUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TRV">TRIVANDRUM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TRZ">TIRUCHIRAPALLI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TIR">TIRUPATI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="ICH">TRICHI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="TCR">TUTICORIN</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="UDR">UDAIPUR</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="BDQ">VADODRA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="VNS">VARANASI</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="VGA">VIJAYAWADA</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="VTZ">VISHAKHAPATNAM</asp:ListItem>
                                                                                                                                                                <asp:ListItem Value="WGC">WARANGAL</asp:ListItem>
                                                                                                                                                            </asp:DropDownList>
                                                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                                                                                                                ControlToValidate="ddlDestinations" Display="None" 
                                                                                                                                                                ErrorMessage="Select destination." InitialValue="----------" 
                                                                                                                                                                ValidationGroup="Search"></asp:RequiredFieldValidator>
                                                                                                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                                                                                                                                                TargetControlID="RequiredFieldValidator2">
                                                                                                                                                            </ajax:ValidatorCalloutExtender>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </table>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="left" height="28" valign="top">
                                                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                                    <tr>
                                                                                                                                                        <td align="left" class="lj_hd" valign="top" width="150">
                                                                                                                                                            Departure On
                                                                                                                             :
                                                                                                                                                        </td>
                                                                                                                                                        <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                        <td align="left" valign="top">
                                                                                                                                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="datepicker" 
                                                                                                                                                                OnClick="showDate();" onkeyup="return tabE(this,event)" 
                                                                                                                                                                onPaste="javascript: return false;" TabIndex="4" ValidationGroup="Search" 
                                                                                                                                                                Width="120px" />
                                                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                                                                                                                ControlToValidate="txtFromDate" Display="None" ErrorMessage="Enter date." 
                                                                                                                                                                ValidationGroup="Search"></asp:RequiredFieldValidator>
                                                                                                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                                                                                                                                                TargetControlID="RequiredFieldValidator3">
                                                                                                                                                            </ajax:ValidatorCalloutExtender>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </table>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="left" height="35" valign="top">
                                                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                                    <tr>
                                                                                                                                                        <td align="left" class="lj_hd" valign="top" width="150">
                                                                                                                                                            <asp:Label ID="lblReturningOn" runat="server" Text="Return On "></asp:Label> 
                                                                                                                                                        </td>
                                                                                                                                                        <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                                                        <td align="left" valign="top">
                                                                                                                                                            <asp:TextBox ID="txtReturnDate" runat="server" CssClass="datepicker1" 
                                                                                                                                                                Enabled="False" OnClick="showDate1();" onkeyup="return tabE1(this,event)" 
                                                                                                                                                                onPaste="javascript: return false;" TabIndex="5" ValidationGroup="Search" 
                                                                                                                                                                Visible="true" Width="120px" />
                                                                                                                                                            <asp:RequiredFieldValidator ID="RequiredReturn" runat="server" 
                                                                                                                                                                ControlToValidate="txtReturnDate" Display="None" 
                                                                                                                                                                ErrorMessage="Enter return date." ValidationGroup="Search" Visible="false"></asp:RequiredFieldValidator>
                                                                                                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
                                                                                                                                                                TargetControlID="RequiredReturn">
                                                                                                                                                            </ajax:ValidatorCalloutExtender>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </table>
                                                                                                                                            </td>
                                                                                                                                        </tr>

                                                                                                                                        <tr>
                                                                                                            <td valign="top" height="28" align="left">
                                                                                                                <table width="347" cellspacing="0" cellpadding="0" border="0">
                                                                                                                    <tr>
                                                                                                                        <td valign="top" align="left" width="150" class="lj_hd">
                                                                                                                          Cabin
                                                                                                                           
                                                                                                                        </td>
                                                                                                                        <td   align="left" style="font-weight:bold;color:Black;" width="25">:</td>
                                                                                                                        <td valign="top" align="left">
                                                                                                                             <asp:DropDownList ID="ddlCabin_type" runat="server" class="ft02" 
                                                                                                                                                    CssClass="lj_inp" TabIndex="9">
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
                                                                                                                                            <%-- <td colspan="4" align="left" height="25" style="padding-left:30px;">
                                                                                                                <span class="lj_hd">Adult&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                    Child</span><span class="lj_hd">(2-11 yrs)</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                <span class="lj_hd">Infant</span><span class="lj_hd">(&lt;2yrs)</span>
                                                                                                            </td>--%>
                                                                                                                                            <td align="left" height="25" style="padding-left:30px;">
                                                                                                                                                <table cellpadding="0" cellspacing="0" width="300">
                                                                                                                                                    <tr>
                                                                                                                                                        <td class="lj_hd">
                                                                                                                                                            Adult
                                                                                                                                                        </td>
                                                                                                                                                        <td class="lj_hd">
                                                                                                                                                            Child (2-11 yrs)
                                                                                                                                                        </td>
                                                                                                                                                        <td class="lj_hd">
                                                                                                                                                            Infant (&lt;2 yrs)
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </table>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <%--<td colspan="4" valign="top" align="left" height="25" style="padding-left:30px;">
                                                                                                               
                                                                                                             
                                                                                                               
                                                                                                                
                                                                                                            </td>--%>
                                                                                                                                            <td align="left" height="25" style="padding-left:30px;">
                                                                                                                                                <table cellpadding="0" cellspacing="0" width="300">
                                                                                                                                                    <tr>
                                                                                                                                                        <td>
                                                                                                                                                            <asp:DropDownList ID="ddlAdult" runat="server" CssClass="lj_inp" TabIndex="6" 
                                                                                                                                                                width="50px">
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
                                                                                                                                                            <img height="1 " src="arzoo_search_files/blk.gif" width="40">
                                                                                                                                                            <asp:DropDownList ID="ddlChild" runat="server" class="ft02" CssClass="lj_inp" 
                                                                                                                                                                TabIndex="7" width="50px">
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
                                                                                                                                                            </img></td>
                                                                                                                                                        <td>
                                                                                                                                                            <img height="1" src="arzoo_search_files/blk.gif" width="55">
                                                                                                                                                            <asp:DropDownList ID="ddlInfant" runat="server" class="ft02" CssClass="lj_inp" 
                                                                                                                                                                TabIndex="8" width="50px">
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
                                                                                                                                                            </img></td>
                                                                                                                                                    </tr>
                                                                                                                                                </table>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                       
                                                                                                                                        <tr>
                                                                                                                                            <td align="left" height="28" valign="top">
                                                                                                                                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td align="center" height="60" valign="top">
                                                                                                                                                <%--<asp:ImageButton ID="ibtnSearch" runat="server" CssClass="check-availability-btn"
                                                                                                                    ImageUrl="images/check-availability-btn.jpg" OnClick="ibtnSearch_Click" OnClientClick="showDiv();"
                                                                                                                    ValidationGroup="Search" />--%>
                                                                                                                                                <asp:ImageButton ID="ibtnSearch" runat="server" 
                                                                                                                                                    CssClass="check-availability-btn" 
                                                                                                                                                    ImageUrl="~/images/check-availability-btn.jpg" OnClick="ibtnSearch_Click" 
                                                                                                                                                    OnClientClick="return startsearch();" TabIndex="10" ValidationGroup="Search" />
                                                                                                                                                <span ID="mainDiv" class="loadingBackground" style="display: none"></span>
                                                                                                                                                <span ID="contentDiv" class="modalContainer" style="display: none">
                                                                                                                                                <div class="registerhead">
                                                                                                                                                    <table align="center" border="0" cellpadding="0" cellspacing="0" 
                                                                                                                                                        style="background-color:White" width="600">
                                                                                                                                                        <tr>
                                                                                                                                                            <td height="8" width="9">
                                                                                                                                                                <img src="../../images/l1.png" width="9" height="8" />
                                                                                                                                                            </td>
                                                                                                                                                            <td height="8" width="582">
                                                                                                                                                            </td>
                                                                                                                                                            <td height="8" width="9">
                                                                                                                                                                <img src="../../images/l2.png" width="9" height="8" />
                                                                                                                                                            </td>
                                                                                                                                                        </tr>
                                                                                                                                                        <tr>
                                                                                                                                                            <td align="center" colspan="3" valign="top">
                                                                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="582">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" height="25" valign="top">
                                                                                                                                                                            <img alt="Logo" border="0" src="../../images/logo.gif" title="LoveJourney">
                                                                                                                                                                            </img></td>
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
                                                                                                                                                                            <input id="Text1" type="text" style=" border: 0px; text-align:right; background-color:White"  class="progress" disabled="disabled"/>
                                                                                                                                                                            &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                                                                                                            <input id="Text2" type="text" style="border: 0; text-align:left;background-color:White" class="progress" disabled="disabled" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" height="20">
                                                                                                                                                                            On
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" height="20">
                                                                                                                                                                            <input id="Text3" type="text" style="border: 0px; text-align: center;background-color:White" disabled="disabled" class="progress"  />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </table>
                                                                                                                                                            </td>
                                                                                                                                                        </tr>
                                                                                                                                                        <tr>
                                                                                                                                                            <td height="8" width="9">
                                                                                                                                                                <img src="../../images/l3.png" width="9" height="8" />
                                                                                                                                                            </td>
                                                                                                                                                            <td height="8" width="582">
                                                                                                                                                            </td>
                                                                                                                                                            <td height="8" width="9">
                                                                                                                                                                <img src="../../images/l4.png" width="9" height="8" />
                                                                                                                                                            </td>
                                                                                                                                                        </tr>
                                                                                                                                                    </table>
                                                                                                                                                </div>
                                                                                                                                                </span><span ID="mainDiv3" class="loadingBackground" style="display: none">
                                                                                                                                                </span><span ID="contentDiv3" class="modalContainer" style="display: none">
                                                                                                                                                <div class="registerhead">
                                                                                                                                                    <table align="center" border="0" cellpadding="0" cellspacing="0" 
                                                                                                                                                        style="background-color:White" width="600">
                                                                                                                                                        <tr>
                                                                                                                                                            <td height="8" width="9">
                                                                                                                                                                <img src="../../images/l1.png" width="9" height="8" />
                                                                                                                                                            </td>
                                                                                                                                                            <td height="8" width="582">
                                                                                                                                                            </td>
                                                                                                                                                            <td height="8" width="9">
                                                                                                                                                                <img src="../../images/l2.png" width="9" height="8" />
                                                                                                                                                            </td>
                                                                                                                                                        </tr>
                                                                                                                                                        <tr>
                                                                                                                                                            <td align="center" colspan="3" valign="top">
                                                                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="582">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" height="25" valign="top">
                                                                                                                                                                            <img alt="Logo" border="0" src="../../images/logo.gif" title="LoveJourney">
                                                                                                                                                                            </img></td>
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
                                                                                                                                                                        <td align="center" class="lj_hd" height="20">
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
                                                                                                                                                                        <td align="center" class="lj_hd" height="20">
                                                                                                                                                                            <input id="Text9" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td height="20px">
                                                                                                                                                                            &nbsp;</td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="center" class="lj_hd" height="20">
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
                                                                                                                                                                        <td align="center" class="lj_hd" height="20">
                                                                                                                                                                            <input id="Text12" type="text" style="border: 0; text-align: center; background-color:White" disabled="disabled" class="progress" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </table>
                                                                                                                                                            </td>
                                                                                                                                                        </tr>
                                                                                                                                                        <tr>
                                                                                                                                                            <td height="8" width="9">
                                                                                                                                                                <img src="../../images/l3.png" width="9" height="8" />
                                                                                                                                                            </td>
                                                                                                                                                            <td height="8" width="582">
                                                                                                                                                            </td>
                                                                                                                                                            <td height="8" width="9">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                            <td class="form_right">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" height="32" valign="top" width="24">
                                                                                <img src="../../images/formbottom_left.png" />
                                                                            </td>
                                                                            <td class="form_bottom">
                                                                                &nbsp;</td>
                                                                            <td align="left" height="32" valign="top" width="29">
                                                                                <img src="../../images/formright_bottom.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <td style="width:100px">
                                                        </td>
                                                        <td align="right" valign="middle">
                                                            <%--<asp:Image ID="imgFlight" Width="367" Height="366" ImageUrl="~/images/flight.jpg" runat="server" />
                                         --%>
                                                            <table border="0" cellpadding="0" cellspaci   alert('HI');ng="0" width="340">
                                                                <tr>
                                                                    <td class="link_rt" valign="top">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="320">
                                                                            <tr>
                                                                                <td colspan="3" height="10">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <a href="frmDomesticAvailability.aspx" target="_blank"><img src="../../img/flight.png" width="86" height="76"  /></a>
                                                                                </td>
                                                                                <td align="center">
                                                                                   <a href="../Hotel/HotelSearch.aspx" target="_blank"> <img src="../../img/hotel.png" width="86" height="76"  /></a>
                                                                                </td>
                                                                                <td align="center">
                                                                                   <a href="../Bus/Default.aspx" target="_blank"> <img src="../../img/bus.png" width="86" height="76"  /></a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" class="flights">
                                                                                    <a href="frmDomesticAvailability.aspx" target="_blank"> Flights</a></td>
                                                                                <td align="center" class="flights">
                                                                                   <a href="../Hotel/HotelSearch.aspx" target="_blank">  Hotels</a></td>
                                                                                <td align="center" class="flights">
                                                                                   <a href="../Bus/Default.aspx" target="_blank"> Bus</a></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3" height="10">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <img src="../../img/TRAIN.png" width="86" height="76"  />
                                                                                </td>
                                                                                <td align="center">
                                                                                   <a href="../Recharge/Recharge.aspx"> <img src="../../img/RECHARGE.png" width="86" height="76"  /></a>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <img src="../../img/TICKET.png" width="86" height="76"  />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" class="flights">
                                                                                   Train</td>
                                                                                <td align="center" class="flights">
                                                                                   <a href="../Recharge/Recharge.aspx"> Recharge</a></td>
                                                                                <td align="center" class="flights">
                                                                                    Tickets</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3" height="10">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <img src="../../img/CAR.png" width="86" height="76"  />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <img src="../../img/UTILITIES.png" width="86" height="76"  />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <img src="../../img/DMR.png" width="86" height="76"  />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" class="flights">
                                                                                    Car</td>
                                                                                <td align="center" class="flights">
                                                                                    Utilities</td>
                                                                                <td align="center" class="flights">
                                                                                    Dmr</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tbody>
                                                </table>
                                            </td>
                                           
                                        </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                        </div>
                        </td>
                        </tr>
                        </table>
                        <table runat="server" id="tblAirlineDet" visible="false" width="100%" cellpadding="0" cellspacing="0" border="0">
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
                                                                    <tr id="trscahrge" runat="server" visible = "false">
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
                                                                      <tr id="Tr3" runat="server" visible="false">
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
                                                                       <tr >
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
                        <table width="100%" >
                            <tr >
                            <td width="100%">
                            <table width="100%">
                               <tr>
                            <td  align="center" class="lj_fntbldsze">
                                <asp:Label ID="Label3" runat="server" Text="" ></asp:Label>
                            </td>
                                     <td align="right">
                                   
                                      <asp:LinkButton ID="lnkModifySearch" runat="server" Visible="false">Modify Search</asp:LinkButton>
                                </td>
                        </tr>
                            </table>
                            </td>
                          
                            </tr>
                            
                            <tr id="ModifySearch" runat="server" visible="false">
                                <td  align="center" width="980" style="padding-left:10px";>
                                   <div id="dvModifySearch" visible="false" runat="server"  style="margin-left:15px;width:950px;">
                                     <h3>Modify Search</h3>
                                                    <asp:Panel ID="pnlModSearch" runat="server" Visible="false">

                                                    <table width="800" cellpadding="0" cellspacing="0" border="0" align="center">
                                                      <tr>
                                                          <td width="200" align="center">
                                                          
                                                          <table>
                                                          <tr>
                                                          <%--<td class="lj_hd"> <asp:RadioButton ID="rbonesearch" Text="One Way" runat="server" Checked="true" AutoPostBack="True" Font-Size="Medium"
                                                                GroupName="ONE" OnCheckedChanged="rbonesearch_CheckedChanged" Font-Names="Arial" /></td>--%>
                                                          </tr>
                                                          <tr>

                                                          <%--<td class="lj_hd"><asp:RadioButton ID="rbreturnsearch" Text="Round Trip" runat="server" AutoPostBack="True" Font-Size="Medium"
                                                                GroupName="ONE" OnCheckedChanged="rbreturnsearch_CheckedChanged" Font-Names="Arial" />
                                                                
                                                          </td>--%>
                                                          </tr>

                                                          
                                                          
                                                          </table>

                                                          </td>
                                                          <td width="600">

                                                          <table cellpadding="0" cellspacing="0" border="0">
                                                          <tr>
                                                          
                                                          <td width="150" align="left" class="lj_hd" height="30">Leaving From :</td>
                                                          <td width="150" align="left"  class="lj_hd"> Leaving To :</td>
                                                          <td width="150" align="left" class="lj_hd"> Departure On :</td>
                                                          <td width="150" align="left" class="lj_hd"> <asp:Label ID="Label2" runat="server" Text="Return On :"></asp:Label></td>
                                                          
                                                          </tr>

                                                           <tr>
                                                          
                                                          <td width="150" align="left">
                                                          
                                                          </td>
                                                          <td width="150">
                                                              
                                                               
                                                          </td>
                                                          <td width="150">
                                                         
                                                          </td>
                                                          <td width="150">
                                                           
                                                          </td>
                                                          </td>
                                                          
                                                          </tr>


                                                           <tr>
                                                          
                                                          <td width="150" height="30" class="lj_hd">
                                                           Adult
                                                          </td>
                                                          <td width="150" class="lj_hd">
                                                          Child(2-11 Years)
                                                          </td>
                                                          <td width="162" class="lj_hd">
                                                          Infant(<2Years)
                                                          </td>
                                                          <td width="150" class="lj_hd">
                                                          Cabin:
                                                          </td>
                                                          </tr>


                                                           <tr>
                                                          
                                                          <td width="150">
                                                         
                                                          </td>
                                                          <td width="150">
                                                          

                                                          </td>
                                                          <td width="150">
                                                        
                                                          </td>
                                                          <td width="150">
                                                        

                                                          </td>
                                                          
                                                          </tr>
                                                          
                                                          <tr>
                                                      <td colspan="4" height="40" align="right" valign="bottom">
                                                      <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/images/check-availability-btn.jpg"
                                                   OnClientClick="return startsearch1();"  ValidationGroup="SearchInt" OnClick="imgsearch_Click" />
                                                      </td>
                                                      </tr>
                                                          
                                                          </table>
                                                         
                                                         
                                                        </asp:Panel>   
                                                     
                                                      
                                                   
                                              
                                    
                                   </div>
                                            </td>
                                        </tr>
                            <tr runat="server" id="trFilterSearch" visible="false" valign="top">
                                <td valign="top">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr id="modifyfilter" runat="server">
                                            <td width="25%" valign="top" align="left"  id="FilterBlock" runat="server">
                                                <table width="25%" style="border: 0px solid #657600" cellpadding="0" cellspacing="0">

                                                 <tr>
    <td width="3" align="right"><img src="../../images/lb1.png" width="3" height="29"  /></td>
    <td width="232" class="lj_ms_blu" height="29">Modify Search</td>
    <td width="3"><img src="../../images/lb2.png" width="3" height="29"  /></td>
  </tr>
  <tr>
    <td colspan="3" class="lj_ms_bdr" align="center">
    
    
    <table width="232"  border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" height="30" class="lj_radionutton">
    <asp:RadioButton ID="rbonesearch" Text="One Way" runat="server" Checked="true" AutoPostBack="True" 
                                                                GroupName="ONE" OnCheckedChanged="rbonesearch_CheckedChanged" Font-Names="Arial" /></td>
    <td align="center" class="lj_radionutton"><asp:RadioButton ID="rbreturnsearch" Text="Round Trip" runat="server" AutoPostBack="True" 
                                                                GroupName="ONE" OnCheckedChanged="rbreturnsearch_CheckedChanged"  /></td>
  </tr>
  <tr>

    <td height="8" colspan="2"></td>
  </tr>
  <tr>
    <td colspan="2" align="center">
    
    
    
    <table width="230" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="lj_ms_fr" align="left" height="30">From</td>
    <td width="140" align="left">
 
    <asp:DropDownList ID="ddlSourcesSearch" runat="server"  CssClass="lj_ms_in"
                                                                   ValidationGroup="Search" >
                                                                   <asp:ListItem Selected="True" Value="BOM">MUMBAI</asp:ListItem>
                                                                   <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                   <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                   <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                   <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                   <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                   <asp:ListItem Value="line1">-------------------------------</asp:ListItem>
                                                                   <asp:ListItem Value="IXA">AGARTALA</asp:ListItem>
                                                                   <asp:ListItem Value="AGX">AGATTI</asp:ListItem>
                                                                   <asp:ListItem Value="AGR">AGRA</asp:ListItem>
                                                                   <asp:ListItem Value="AMD">AHMEDABAD</asp:ListItem>
                                                                   <asp:ListItem Value="AJL">AIJWAL</asp:ListItem>
                                                                   <asp:ListItem Value="AKD">AKOLA</asp:ListItem>
                                                                   <asp:ListItem Value="IXD">ALLAHABAD</asp:ListItem>
                                                                   <asp:ListItem Value="IXV">ALONG</asp:ListItem>
                                                                   <asp:ListItem Value="ATQ">AMRITSAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXU">AURANGABAD</asp:ListItem>
                                                                   <asp:ListItem Value="IXB">BAGDOGRA</asp:ListItem>
                                                                   <asp:ListItem Value="RGH">BALURGHAT</asp:ListItem>
                                                                   <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                   <asp:ListItem Value="IXG">BELGAUM</asp:ListItem>
                                                                   <asp:ListItem Value="BEP">BELLARY</asp:ListItem>
                                                                   <asp:ListItem Value="BUP">BHATINDA</asp:ListItem>
                                                                   <asp:ListItem Value="BHU">BHAVNAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="BHO">BHOPAL</asp:ListItem>
                                                                   <asp:ListItem Value="BBI">BHUBANESHWAR</asp:ListItem>
                                                                   <asp:ListItem Value="BHJ">BHUJ</asp:ListItem>
                                                                   <asp:ListItem Value="KUU">BHUNTAR</asp:ListItem>
                                                                   <asp:ListItem Value="BKB">BIKANER</asp:ListItem>
                                                                   <asp:ListItem Value="PAB">BILASPUR</asp:ListItem>
                                                                   <asp:ListItem Value="CCJ">CALICUT</asp:ListItem>
                                                                   <asp:ListItem Value="CBD">CAR NICOBAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXC">CHANDIGARH</asp:ListItem>
                                                                   <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                   <asp:ListItem Value="COK">COCHIN</asp:ListItem>
                                                                   <asp:ListItem Value="CJB">COIMBATORE</asp:ListItem>
                                                                   <asp:ListItem Value="COH">COOCH BEHAR</asp:ListItem>
                                                                   <asp:ListItem Value="CDP">CUDDAPAH</asp:ListItem>
                                                                   <asp:ListItem Value="NMB">DAMAN</asp:ListItem>
                                                                   <asp:ListItem Value="DAE">DAPARIZO</asp:ListItem>
                                                                   <asp:ListItem Value="DAI">DARJEELING</asp:ListItem>
                                                                   <asp:ListItem Value="DED">DEHRA DUN</asp:ListItem>
                                                                   <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                   <asp:ListItem Value="DEP">DEPARIZO</asp:ListItem>
                                                                   <asp:ListItem Value="DBD">DHANBAD</asp:ListItem>
                                                                   <asp:ListItem Value="DHM">DHARAMSALA</asp:ListItem>
                                                                   <asp:ListItem Value="DIB">DIBRUGARH</asp:ListItem>
                                                                   <asp:ListItem Value="DMU">DIMAPUR</asp:ListItem>
                                                                   <asp:ListItem Value="DIU">DIU</asp:ListItem>
                                                                   <asp:ListItem Value="GAY">GAYA</asp:ListItem>
                                                                   <asp:ListItem Value="GOI">GOA</asp:ListItem>
                                                                   <asp:ListItem Value="GOP">GORAKHPUR</asp:ListItem>
                                                                   <asp:ListItem Value="GUX">GUNA</asp:ListItem>
                                                                   <asp:ListItem Value="GAU">GUWAHATI</asp:ListItem>
                                                                   <asp:ListItem Value="GWL">GWALIOR</asp:ListItem>
                                                                   <asp:ListItem Value="HSS">HISSAR</asp:ListItem>
                                                                   <asp:ListItem Value="HBX">HUBLI</asp:ListItem>
                                                                   <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                   <asp:ListItem Value="IMF">IMPHAL</asp:ListItem>
                                                                   <asp:ListItem Value="IDR">INDORE</asp:ListItem>
                                                                   <asp:ListItem Value="JLR">JABALPUR</asp:ListItem>
                                                                   <asp:ListItem Value="JGB">JAGDALPUR</asp:ListItem>
                                                                   <asp:ListItem Value="JAI">JAIPUR</asp:ListItem>
                                                                   <asp:ListItem Value="JSA">JAISALMER</asp:ListItem>
                                                                   <asp:ListItem Value="IXJ">JAMMU</asp:ListItem>
                                                                   <asp:ListItem Value="JGA">JAMNAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXW">JAMSHEDPUR</asp:ListItem>
                                                                   <asp:ListItem Value="PYB">JEYPORE</asp:ListItem>
                                                                   <asp:ListItem Value="JDH">JODHPUR</asp:ListItem>
                                                                   <asp:ListItem Value="JRH">JORHAT</asp:ListItem>
                                                                   <asp:ListItem Value="IXH">KAILASHAHAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXQ">KAMALPUR</asp:ListItem>
                                                                   <asp:ListItem Value="IXY">KANDLA</asp:ListItem>
                                                                   <asp:ListItem Value="KNU">KANPUR</asp:ListItem>
                                                                   <asp:ListItem Value="IXK">KESHOD</asp:ListItem>
                                                                   <asp:ListItem Value="HJR">KHAJURAHO</asp:ListItem>
                                                                   <asp:ListItem Value="IXN">KHOWAI</asp:ListItem>
                                                                   <asp:ListItem Value="KLH">KOLHAPUR</asp:ListItem>
                                                                   <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                   <asp:ListItem Value="KTU">KOTA</asp:ListItem>
                                                                   <asp:ListItem Value="KUU">KULU</asp:ListItem>
                                                                   <asp:ListItem Value="LTU">LATUR</asp:ListItem>
                                                                   <asp:ListItem Value="IXL">LEH</asp:ListItem>
                                                                   <asp:ListItem Value="IXI">LILABARI</asp:ListItem>
                                                                   <asp:ListItem Value="LKO">LUCKNOW</asp:ListItem>
                                                                   <asp:ListItem Value="LUH">LUDHIANA</asp:ListItem>
                                                                   <asp:ListItem Value="IXM">MADURAI</asp:ListItem>
                                                                   <asp:ListItem Value="LDA">MALDA</asp:ListItem>
                                                                   <asp:ListItem Value="IXE">MANGALORE</asp:ListItem>
                                                                   <asp:ListItem Value="MOH">MOHANBARI</asp:ListItem>
                                                                   <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                   <asp:ListItem Value="MZA">MUZAFFARNAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="MZU">MUZAFFARPUR</asp:ListItem>
                                                                   <asp:ListItem Value="MYQ">MYSORE</asp:ListItem>
                                                                   <asp:ListItem Value="NAG">NAGPUR</asp:ListItem>
                                                                   <asp:ListItem Value="NDC">NANDED</asp:ListItem>
                                                                   <asp:ListItem Value="ISK">NASIK</asp:ListItem>
                                                                   <asp:ListItem Value="NVY">NEYVELI</asp:ListItem>
                                                                   <asp:ListItem Value="OMN">OSMANABAD</asp:ListItem>
                                                                   <asp:ListItem Value="PGH">PANTNAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXT">PASIGHAT</asp:ListItem>
                                                                   <asp:ListItem Value="IXP">PATHANKOT</asp:ListItem>
                                                                   <asp:ListItem Value="PAT">PATNA</asp:ListItem>
                                                                   <asp:ListItem Value="PNY">PONDICHERRY</asp:ListItem>
                                                                   <asp:ListItem Value="PBD">PORBANDAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXZ">PORTBLAIR</asp:ListItem>
                                                                   <asp:ListItem Value="PNQ">PUNE</asp:ListItem>
                                                                   <asp:ListItem Value="PUT">PUTTAPARTHI</asp:ListItem>
                                                                   <asp:ListItem Value="BEK">PUTTAPARTHY</asp:ListItem>
                                                                   <asp:ListItem Value="RPR">RAIPUR</asp:ListItem>
                                                                   <asp:ListItem Value="RJA">RAJAHMUNDRY</asp:ListItem>
                                                                   <asp:ListItem Value="RAJ">RAJKOT</asp:ListItem>
                                                                   <asp:ListItem Value="RJI">RAJOURI</asp:ListItem>
                                                                   <asp:ListItem Value="RMD">RAMAGUNDAM</asp:ListItem>
                                                                   <asp:ListItem Value="IXR">RANCHI</asp:ListItem>
                                                                   <asp:ListItem Value="RTC">RATNAGIRI</asp:ListItem>
                                                                   <asp:ListItem Value="REW">REWA</asp:ListItem>
                                                                   <asp:ListItem Value="RRK">ROURKELA</asp:ListItem>
                                                                   <asp:ListItem Value="RUP">RUPSI</asp:ListItem>
                                                                   <asp:ListItem Value="SXV">SALEM</asp:ListItem>
                                                                   <asp:ListItem Value="TNI">SATNA</asp:ListItem>
                                                                   <asp:ListItem Value="SHL">SHILLONG</asp:ListItem>
                                                                   <asp:ListItem Value="SSE">SHOLAPUR</asp:ListItem>
                                                                   <asp:ListItem Value="IXS">SILCHAR</asp:ListItem>
                                                                   <asp:ListItem Value="SLV">SIMLA</asp:ListItem>
                                                                   <asp:ListItem Value="SXR">SRINAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="STV">SURAT</asp:ListItem>
                                                                   <asp:ListItem Value="TEZ">TEZPUR</asp:ListItem>
                                                                   <asp:ListItem Value="TEI">TEZU</asp:ListItem>
                                                                   <asp:ListItem Value="TJV">THANJAVUR</asp:ListItem>
                                                                   <asp:ListItem Value="TRV">TRIVANDRUM</asp:ListItem>
                                                                   <asp:ListItem Value="TRZ">TIRUCHIRAPALLI</asp:ListItem>
                                                                   <asp:ListItem Value="TIR">TIRUPATI</asp:ListItem>
                                                                   <asp:ListItem Value="ICH">TRICHI</asp:ListItem>
                                                                   <asp:ListItem Value="TCR">TUTICORIN</asp:ListItem>
                                                                   <asp:ListItem Value="UDR">UDAIPUR</asp:ListItem>
                                                                   <asp:ListItem Value="BDQ">VADODRA</asp:ListItem>
                                                                   <asp:ListItem Value="VNS">VARANASI</asp:ListItem>
                                                                   <asp:ListItem Value="VGA">VIJAYAWADA</asp:ListItem>
                                                                   <asp:ListItem Value="VTZ">VISHAKHAPATNAM</asp:ListItem>
                                                                   <asp:ListItem Value="WGC">WARANGAL</asp:ListItem>
                                                               </asp:DropDownList>
    
    </td>
  </tr>
  
   <tr>
    <td class="lj_ms_fr" align="left" height="30">To</td>
    <td width="140" align="left">
    <asp:DropDownList ID="ddlDestinationsSearch" runat="server" CssClass="lj_ms_in" 
                                                                   onchange="showDate();" ValidationGroup="Search" >
                                                                   <asp:ListItem Selected="True" Value="DEL">DELHI</asp:ListItem>
                                                                   <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                   <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                   <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                   <asp:ListItem Value="CCJ">CALICUT</asp:ListItem>
                                                                   <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                   <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                   <asp:ListItem Value="line1">-------------------------------</asp:ListItem>
                                                                   <asp:ListItem Value="IXA">AGARTALA</asp:ListItem>
                                                                   <asp:ListItem Value="AGX">AGATTI</asp:ListItem>
                                                                   <asp:ListItem Value="AGR">AGRA</asp:ListItem>
                                                                   <asp:ListItem Value="AMD">AHMEDABAD</asp:ListItem>
                                                                   <asp:ListItem Value="AJL">AIJWAL</asp:ListItem>
                                                                   <asp:ListItem Value="AKD">AKOLA</asp:ListItem>
                                                                   <asp:ListItem Value="IXD">ALLAHABAD</asp:ListItem>
                                                                   <asp:ListItem Value="IXV">ALONG</asp:ListItem>
                                                                   <asp:ListItem Value="ATQ">AMRITSAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXU">AURANGABAD</asp:ListItem>
                                                                   <asp:ListItem Value="IXB">BAGDOGRA</asp:ListItem>
                                                                   <asp:ListItem Value="RGH">BALURGHAT</asp:ListItem>
                                                                   <asp:ListItem Value="BLR">BANGALORE</asp:ListItem>
                                                                   <asp:ListItem Value="IXG">BELGAUM</asp:ListItem>
                                                                   <asp:ListItem Value="BEP">BELLARY</asp:ListItem>
                                                                   <asp:ListItem Value="BUP">BHATINDA</asp:ListItem>
                                                                   <asp:ListItem Value="BHU">BHAVNAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="BHO">BHOPAL</asp:ListItem>
                                                                   <asp:ListItem Value="BBI">BHUBANESHWAR</asp:ListItem>
                                                                   <asp:ListItem Value="BHJ">BHUJ</asp:ListItem>
                                                                   <asp:ListItem Value="KUU">BHUNTAR</asp:ListItem>
                                                                   <asp:ListItem Value="BKB">BIKANER</asp:ListItem>
                                                                        <asp:ListItem Value="CBD">CAR NICOBAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXC">CHANDIGARH</asp:ListItem>
                                                                   <asp:ListItem Value="MAA">CHENNAI</asp:ListItem>
                                                                   <asp:ListItem Value="COK">COCHIN</asp:ListItem>
                                                                   <asp:ListItem Value="CJB">COIMBATORE</asp:ListItem>
                                                                   <asp:ListItem Value="COH">COOCH BEHAR</asp:ListItem>
                                                                   <asp:ListItem Value="CDP">CUDDAPAH</asp:ListItem>
                                                                   <asp:ListItem Value="NMB">DAMAN</asp:ListItem> 
                                                                   <asp:ListItem Value="PAB">BILASPUR</asp:ListItem>
                                                                   <asp:ListItem Value="DAE">DAPARIZO</asp:ListItem>
                                                                   <asp:ListItem Value="DAI">DARJEELING</asp:ListItem>
                                                                   <asp:ListItem Value="DED">DEHRA DUN</asp:ListItem>
                                                                   <asp:ListItem Value="DEL">DELHI</asp:ListItem>
                                                                   <asp:ListItem Value="DEP">DEPARIZO</asp:ListItem>
                                                                   <asp:ListItem Value="DBD">DHANBAD</asp:ListItem>
                                                                   <asp:ListItem Value="DHM">DHARAMSALA</asp:ListItem>
                                                                   <asp:ListItem Value="DIB">DIBRUGARH</asp:ListItem>
                                                                   <asp:ListItem Value="DMU">DIMAPUR</asp:ListItem>
                                                                   <asp:ListItem Value="DIU">DIU</asp:ListItem>
                                                                   <asp:ListItem Value="GAY">GAYA</asp:ListItem>
                                                                   <asp:ListItem Value="GOI">GOA</asp:ListItem>
                                                                   <asp:ListItem Value="GOP">GORAKHPUR</asp:ListItem>
                                                                   <asp:ListItem Value="GUX">GUNA</asp:ListItem>
                                                                   <asp:ListItem Value="GAU">GUWAHATI</asp:ListItem>
                                                                   <asp:ListItem Value="GWL">GWALIOR</asp:ListItem>
                                                                   <asp:ListItem Value="HSS">HISSAR</asp:ListItem>
                                                                   <asp:ListItem Value="HBX">HUBLI</asp:ListItem>
                                                                   <asp:ListItem Value="HYD">HYDERABAD</asp:ListItem>
                                                                   <asp:ListItem Value="IMF">IMPHAL</asp:ListItem>
                                                                   <asp:ListItem Value="IDR">INDORE</asp:ListItem>
                                                                   <asp:ListItem Value="JLR">JABALPUR</asp:ListItem>
                                                                   <asp:ListItem Value="JGB">JAGDALPUR</asp:ListItem>
                                                                   <asp:ListItem Value="JAI">JAIPUR</asp:ListItem>
                                                                   <asp:ListItem Value="JSA">JAISALMER</asp:ListItem>
                                                                   <asp:ListItem Value="IXJ">JAMMU</asp:ListItem>
                                                                   <asp:ListItem Value="JGA">JAMNAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXW">JAMSHEDPUR</asp:ListItem>
                                                                   <asp:ListItem Value="PYB">JEYPORE</asp:ListItem>
                                                                   <asp:ListItem Value="JDH">JODHPUR</asp:ListItem>
                                                                   <asp:ListItem Value="JRH">JORHAT</asp:ListItem>
                                                                   <asp:ListItem Value="IXH">KAILASHAHAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXQ">KAMALPUR</asp:ListItem>
                                                                   <asp:ListItem Value="IXY">KANDLA</asp:ListItem>
                                                                   <asp:ListItem Value="KNU">KANPUR</asp:ListItem>
                                                                   <asp:ListItem Value="IXK">KESHOD</asp:ListItem>
                                                                   <asp:ListItem Value="HJR">KHAJURAHO</asp:ListItem>
                                                                   <asp:ListItem Value="IXN">KHOWAI</asp:ListItem>
                                                                   <asp:ListItem Value="KLH">KOLHAPUR</asp:ListItem>
                                                                   <asp:ListItem Value="CCU">KOLKATA</asp:ListItem>
                                                                   <asp:ListItem Value="KTU">KOTA</asp:ListItem>
                                                                   <asp:ListItem Value="KUU">KULU</asp:ListItem>
                                                                   <asp:ListItem Value="LTU">LATUR</asp:ListItem>
                                                                   <asp:ListItem Value="IXL">LEH</asp:ListItem>
                                                                   <asp:ListItem Value="IXI">LILABARI</asp:ListItem>
                                                                   <asp:ListItem Value="LKO">LUCKNOW</asp:ListItem>
                                                                   <asp:ListItem Value="LUH">LUDHIANA</asp:ListItem>
                                                                   <asp:ListItem Value="IXM">MADURAI</asp:ListItem>
                                                                   <asp:ListItem Value="LDA">MALDA</asp:ListItem>
                                                                   <asp:ListItem Value="IXE">MANGALORE</asp:ListItem>
                                                                   <asp:ListItem Value="MOH">MOHANBARI</asp:ListItem>
                                                                   <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
                                                                   <asp:ListItem Value="MZA">MUZAFFARNAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="MZU">MUZAFFARPUR</asp:ListItem>
                                                                   <asp:ListItem Value="MYQ">MYSORE</asp:ListItem>
                                                                   <asp:ListItem Value="NAG">NAGPUR</asp:ListItem>
                                                                   <asp:ListItem Value="NDC">NANDED</asp:ListItem>
                                                                   <asp:ListItem Value="ISK">NASIK</asp:ListItem>
                                                                   <asp:ListItem Value="NVY">NEYVELI</asp:ListItem>
                                                                   <asp:ListItem Value="OMN">OSMANABAD</asp:ListItem>
                                                                   <asp:ListItem Value="PGH">PANTNAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXT">PASIGHAT</asp:ListItem>
                                                                   <asp:ListItem Value="IXP">PATHANKOT</asp:ListItem>
                                                                   <asp:ListItem Value="PAT">PATNA</asp:ListItem>
                                                                   <asp:ListItem Value="PNY">PONDICHERRY</asp:ListItem>
                                                                   <asp:ListItem Value="PBD">PORBANDAR</asp:ListItem>
                                                                   <asp:ListItem Value="IXZ">PORTBLAIR</asp:ListItem>
                                                                   <asp:ListItem Value="PNQ">PUNE</asp:ListItem>
                                                                   <asp:ListItem Value="PUT">PUTTAPARTHI</asp:ListItem>
                                                                   <asp:ListItem Value="BEK">PUTTAPARTHY</asp:ListItem>
                                                                   <asp:ListItem Value="RPR">RAIPUR</asp:ListItem>
                                                                   <asp:ListItem Value="RJA">RAJAHMUNDRY</asp:ListItem>
                                                                   <asp:ListItem Value="RAJ">RAJKOT</asp:ListItem>
                                                                   <asp:ListItem Value="RJI">RAJOURI</asp:ListItem>
                                                                   <asp:ListItem Value="RMD">RAMAGUNDAM</asp:ListItem>
                                                                   <asp:ListItem Value="IXR">RANCHI</asp:ListItem>
                                                                   <asp:ListItem Value="RTC">RATNAGIRI</asp:ListItem>
                                                                   <asp:ListItem Value="REW">REWA</asp:ListItem>
                                                                   <asp:ListItem Value="RRK">ROURKELA</asp:ListItem>
                                                                   <asp:ListItem Value="RUP">RUPSI</asp:ListItem>
                                                                   <asp:ListItem Value="SXV">SALEM</asp:ListItem>
                                                                   <asp:ListItem Value="TNI">SATNA</asp:ListItem>
                                                                   <asp:ListItem Value="SHL">SHILLONG</asp:ListItem>
                                                                   <asp:ListItem Value="SSE">SHOLAPUR</asp:ListItem>
                                                                   <asp:ListItem Value="IXS">SILCHAR</asp:ListItem>
                                                                   <asp:ListItem Value="SLV">SIMLA</asp:ListItem>
                                                                   <asp:ListItem Value="SXR">SRINAGAR</asp:ListItem>
                                                                   <asp:ListItem Value="STV">SURAT</asp:ListItem>
                                                                   <asp:ListItem Value="TEZ">TEZPUR</asp:ListItem>
                                                                   <asp:ListItem Value="TEI">TEZU</asp:ListItem>
                                                                   <asp:ListItem Value="TJV">THANJAVUR</asp:ListItem>
                                                                   <asp:ListItem Value="TRV">TRIVANDRUM</asp:ListItem>
                                                                   <asp:ListItem Value="TRZ">TIRUCHIRAPALLI</asp:ListItem>
                                                                   <asp:ListItem Value="TIR">TIRUPATI</asp:ListItem>
                                                                   <asp:ListItem Value="ICH">TRICHI</asp:ListItem>
                                                                   <asp:ListItem Value="TCR">TUTICORIN</asp:ListItem>
                                                                   <asp:ListItem Value="UDR">UDAIPUR</asp:ListItem>
                                                                   <asp:ListItem Value="BDQ">VADODRA</asp:ListItem>
                                                                   <asp:ListItem Value="VNS">VARANASI</asp:ListItem>
                                                                   <asp:ListItem Value="VGA">VIJAYAWADA</asp:ListItem>
                                                                   <asp:ListItem Value="VTZ">VISHAKHAPATNAM</asp:ListItem>
                                                                   <asp:ListItem Value="WGC">WARANGAL</asp:ListItem>
                                                               </asp:DropDownList>
   <%-- <select class="lj_ms_in">
    <option>Select</option>
    <option>HYderabad</option>
    </select>--%>
    
    </td>
  </tr>
  
  <tr>
    <td class="lj_ms_fr" align="left" height="30">Departure On</td>
    <td width="140" align="left">

  <asp:TextBox ID="txtdatesearch" runat="server" CssClass="datepicker" 
                                                                   OnClick="showDateInt();"   onkeyup="return tabE2(this,event)"
                                                                   onPaste="javascript: return false;" ValidationGroup="Search" Width="90px" />
                                                               <asp:RequiredFieldValidator ID="rfvtxtdatesearch" runat="server" 
                                                                   ControlToValidate="txtdatesearch" Display="None" ErrorMessage="Enter date." 
                                                                   ValidationGroup="SearchInt"></asp:RequiredFieldValidator>
                                                               <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" 
                                                                   TargetControlID="rfvtxtdatesearch">
                                                               </ajax:ValidatorCalloutExtender>
    
    </td>
  </tr>
  
  
    <tr>
    <td class="lj_ms_fr" align="left" height="30">Return On</td>
    <td width="140" align="left">
  
    <asp:TextBox ID="txtretundatesearch" runat="server" Enabled="false"   CssClass="datepicker1"
                                                                               OnClick="showDateInt();"   onkeyup="return tabE3(this,event)" 
                                                                               onPaste="javascript: return false;" ValidationGroup="SearchInt" Visible="true" 
                                                                               Width="90px" class="lj_ms_in" />
    
    </td>
  </tr>
  
  
  
   <tr>
    <td class="lj_ms_fr" align="left" height="30">Adult</td>
    <td width="140" align="left">

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
    <td class="lj_ms_fr" align="left" height="30">Child</td>
    <td width="140" align="left">

                                                <asp:DropDownList ID="ddlchildintsearch" class="ft02" runat="server" CssClass="lj_ms_in" Width="50">
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
    <td width="140" align="left">

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
    <td width="140" align="left">
  <%--  <input type="text" class="lj_ms_in" />--%>
    <asp:DropDownList ID="ddlIntCabinTypesearch"   runat="server" CssClass="lj_ms_in">
                                                    <asp:ListItem Selected="True" Value="E">Economy Lowest Fare</asp:ListItem>
                                                    <asp:ListItem Value="ER">Economy Refundable Fare</asp:ListItem>
                                                    <asp:ListItem Value="B">Business / First Class</asp:ListItem>
                                                </asp:DropDownList>
    
    </td>
  </tr>
  <tr>
    <%--<td>&nbsp;</td>--%>
    <td colspan="2" align="center">
    <%--<input type="submit" class="lj_ms_but" value="Check Availability" />--%>
       <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/check-availability-btn.jpg" Width="159"
                                                   OnClientClick="return startsearch1();"  ValidationGroup="SearchInt" OnClick="imgsearch_Click" />
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
                                                                            <td align="center" height="20">
                                                                                <input id="Text4" type="text" style=" border: 0px; text-align: right; background-color:White;"  disabled="disabled" class="progress"/>
                                                                                &nbsp;&nbsp;To&nbsp;&nbsp;
                                                                                <input id="Text5" type="text" style="border: 0; text-align:left;background-color:White" disabled="disabled" class="progress" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" height="20">
                                                                                On
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" height="20">
                                                                                <input id="Text6" type="text" style="border: 0; text-align: center; background-color:White;" class="progress" disabled="disabled" />
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
                                               <span id="mainDiv4"  style="display: none"  class="loadingBackground"></span><span id="contentDiv4"
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
                                                                                                                                                <input id="Text13" type="text" style=" text-align: right;border:0; background-color:white;"    class="progress" />
                                                                                                                                              
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
                                              <%--  rajini--%>
    
    
    </td>
  </tr>
   <tr>
    <td height="7"></td>
    <td></td>
    <td></td>
  </tr>
                                                   <%-- <tr>
                                                        <td align="center" style="font-size:medium;border-bottom-color: Black; " bgcolor="#f1f1f1" colspan="3">
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
                                                        <td  align="left" style="border-bottom:1px solid #f1f1f1;height:30px" valign="top">
                                                            <span style="font-size: 14px;padding-left:10px;">Price</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl" runat="server" Text="" ></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="lbl11" runat="server" Text="" ></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            <table width="100%">
                                                                 <tr valign="middle">
                                                                    <td valign="top" width="20%" style="border-bottom: 0px;">
                                                                        <asp:TextBox ID="sliderTwo" runat="server" OnTextChanged="sliderTwo_TextChanged"
                                                                            AutoPostBack="true" />
                                                                     <ajax:MultiHandleSliderExtender ID="multiHandleSliderExtenderTwo" runat="server"  
                                                                            BehaviorID="multiHandleSliderExtenderTwo" TargetControlID="sliderTwo"  Increment="10" Length="175" Orientation="Horizontal" EnableHandleAnimation="true"
                                                                            EnableKeyboard="false" EnableMouseWheel="false" EnableRailClick="false" ShowHandleDragStyle="true"
                                                                            ShowHandleHoverStyle="true" ShowInnerRail="true" OnClientDragEnd="ValueChangedHandler">
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
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span id="minPriceLbl" runat="server" class="runtext"> </span>Rs
                                                                        <asp:HiddenField ID="HiddenField1" runat="server"  OnValueChanged="filter" />
                                                                        &nbsp; &nbsp;-&nbsp;&nbsp; <span id="maxPriceLbl"  runat="server" class="runtext"></span>Rs
                                                                        <asp:HiddenField ID="HiddenField2" runat="server"   OnValueChanged="filter" />
                                                                    </td>
                                                                </tr> 
                                                                <tr>
                                                                                <td  style="border-bottom:1px solid #657600">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                <tr runat="server" id="stops2" >
                                                                    <td style="border-bottom:1px solid #f1f1f1;height:30px;" valign="top" align="left">
                                                                        <span style="font-size: 15px;padding-left:10px;">Stops</span>
                                                                    </td>
                                                                </tr>
                                                                <tr id="stops" runat="server" >
                                                                    <td  style="padding-left:10px;padding-right:40px;">
                                                                       <asp:CheckBoxList ID="ChkStops" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="filter">  
                                                                                                                                      
                                                                    </asp:CheckBoxList>
                                                                      <%--  <asp:CheckBox ID="chkstop0" runat="server" Text="Zero" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />
                                                                        <asp:CheckBox ID="Chkstop1" runat="server" Text="One" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />
                                                                        <asp:CheckBox ID="Chkstop2" runat="server" Text="Two" Width="65" OnCheckedChanged="filter"
                                                                            AutoPostBack="true" />--%>
                                                                    </td>
                                                                </tr>
                                                                   <tr>
                                                                                <td  style="border-bottom:1px solid #657600">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                <tr>
                                                                    <td  style="border-bottom:1px solid #f1f1f1;height:30px;" valign="top" align="left">
                                                                        <span style="font-size: 15px;padding-left:10px;">Airlines</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td  style="padding-left:10px;">
                                                                      <asp:CheckBoxList ID="chkAirlines" AutoPostBack="true" runat="server" OnSelectedIndexChanged="filter">  
                                                                                                                                      
                                                                    </asp:CheckBoxList>
                                                                       <%-- <asp:CheckBox ID="chkjetlite" runat="server" Text="JetLite" AutoPostBack="true" OnCheckedChanged="filter" /><br />
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
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr><td align="center">
                                                        <asp:Button ID="btnResetFilters" runat="server" Text="Reset Filters" 
                                                            CssClass="buttonBook" onclick="btnResetFilters_Click" /></td></tr>
                                                    </table></td></tr>
                                                    
                                                    
                                                    </table>
                                                    
                                                    </td>
                                                    </tr>
                                                    
                                                      <tr>
                                                                                <td style="height:10px;" colspan="3">
                                                                                   
                                                                                </td>
                                                                            </tr>
                                                </table>



                                            </td>
                                            
                                            <td align="left" valign="top" runat="server" id="Oneway">
                                            <table width="100%">
                                            <tr>
                                            <td align="right">
                                               <asp:LinkButton ID="lnkSNFFare" runat="server" OnClientClick = "return showHNF();" 
                                             >SNF</asp:LinkButton>
                                            </td>
                                            </tr>
                                            </table>
                                                <asp:GridView ID="gdvFlights" Width="740" runat="server" AutoGenerateColumns="false" AllowSorting="true"  GridLines="Horizontal" CssClass="lj_ms_txt"
                                                    OnRowDataBound="gdvFlights_RowDataBound" OnRowCommand="gdvFlights_RowCommand" OnSorting="gdvFlights_Sorting"
                                                    OnPageIndexChanging="gdvFlights_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Airline" SortExpression="airLineName">
                                                            <ItemTemplate>
                                                                <asp:RadioButton ID="rbnAirline" AutoPostBack="true" runat="server" OnCheckedChanged="rbnAirline_CheckedChanged"
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAirlineName" runat="server" Text='<%# Eval("airLineName") %>'></asp:Label>
                                                                -
                                                                <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label><br />
                                                                <asp:Label ID="lblConnectingFlights" runat="server" Text="Connecting Flights.."></asp:Label><br />
                                                                <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("imageFileName") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Destinations" SortExpression="DepartureAirportCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDepartureAirportCode" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>
                                                                -
                                                                <asp:Label ID="lblConnectingAirportCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblHyphen" runat="server" Text="-" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblArrivalAirportCode" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Departs" SortExpression="DepartureDateTime" >
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="lblDepartname" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>--%>
                                                                <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>' Font-Bold="true"></asp:Label><br />
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
                                                        <asp:TemplateField HeaderText="Arrives" SortExpression="ArrivalDateTime" ItemStyle-Font-Bold="true" >
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="lblArrives" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>--%>
                                                                <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Fare" SortExpression="Fare" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFare" runat="server" Text='<%# Eval("Fare") %>' Font-Bold="true"></asp:Label><%--<%# Eval("ActualBaseFare") %>--%>
                                                                <br />
                                                                <asp:Label ID="lblHNFFare" runat="server"  Font-Bold="true" style="display:none;"  CssClass ="clsFind"></asp:Label>
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
                                                                                    <tr id="trscahrge" runat="server" visible="false">
                                                                                        <td >
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
                                                                                            <asp:Label ID="lbladultone" runat="server"  Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblchildone" runat="server"  Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblinfantone" runat="server"  Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblTripone" runat="server"  Visible="false"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Duration" HeaderStyle-ForeColor="Blue">
                                                        <ItemTemplate>
                                                        <asp:Label ID="lblduration" runat="server" Font-Bold="true"></asp:Label>
                                                        </ItemTemplate>
                                                        
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnBookNow" runat="server" CssClass="buttonBook" Text="Book Now" OnClick="btnBookNow_Click"
                                                                  CommandName="BoolTicket" CommandArgument='<%# Eval("FlightSegment_ID") %>' /><br />
                                                                     <asp:LinkButton ID="lnkDetails" runat="server" CommandName="View Details" CommandArgument='<%# Eval("FlightSegment_ID") %>' OnClick="lnkDummy_Click">Details</asp:LinkButton>
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
        <tr><th>Image</th><th>Airline Name</th><th>Departs</th><th>Arrival</th><th>Duration</th></tr>
        <tr><td align="left">                                             
        <asp:Image ID="imgDet" runat="server"/>   
        </td><td>
        <asp:Label ID="lblAirlineNameDet" runat="server"></asp:Label><br />                                                           

        <asp:Label ID="lblFlightNumberDet" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet" runat="server" ></asp:Label>
        </td>
        <td>
           <asp:Label ID="lblduration1" runat="server" ></asp:Label><br/>
        <asp:Label ID="lbldurationdetails" runat="server" ></asp:Label><br/>
     
        </td>

        </tr>
       <tr runat="server" id="trConnecting" visible="false">
       <td align="left">                                             
        <asp:Image ID="imgDet1" runat="server"/>   
        </td>
        <td>
        <asp:Label ID="lblAirlineNameDet1" runat="server"></asp:Label><br /> 
        <asp:Label ID="lblFlightNumberDet1" runat="server" ></asp:Label> 
        </td>
        <td><asp:Label ID="lblDepartureAirportNameDet1" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblDepartureDateTimeDet1" runat="server" ></asp:Label></td>
        <td>
        <asp:Label ID="lblArrivalAirportNameDet1" runat="server" ></asp:Label><br/>
        <asp:Label ID="lblArrivalDateTimeDet1" runat="server" ></asp:Label>
        </td>
        <td>
          <asp:Label ID="lblduration2" runat="server" ></asp:Label><br/>
        </td>

        </tr>
          <tr><td>&nbsp;</td></tr>
        <tr runat="server" id="trlayovertime" visible="false">
       
       <td  align="right" colspan="5">
       <asp:Label ID="lbllayover" runat="server" Text = "LayOver Time : "></asp:Label>&nbsp;
       <asp:Label ID="lbllayovertime" runat="server" ></asp:Label>
       </td>

        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td align="center" colspan="4">
            <asp:Button ID="btnok" runat="server" Text="Ok" CssClass="buttonBook" /></td></tr>
        </table>
    </asp:Panel>
                                            </td>
                                            <td valign="top" id="round" runat="server">
                                                <table width="100%">
                                                    <tr id="Tr1" runat="server">
                                                        <td valign="top" >
                                                            <table width="100%" >
                                                                <tr>
                                                                    <td >
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
                                                                                                        <tr id="trdiscount" runat="server" visible="false">
                                                                                                            <td >
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
                                                                                            <asp:Label ID="lblTChargeonwardtbl" runat="server"></asp:Label>
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
                                                                                                        <tr id="Trdis" runat="server" visible="false">
                                                                                                            <td >
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
                                                                                            <asp:Label ID="lblTchargeReturntbl" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="lblTotalFare" runat="server" Text="Total Fare : " Visible="false"></asp:Label> <asp:Label ID="lblTotalOnwardReturn" runat="server" Text=""></asp:Label>
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnRoundTripBook" CssClass="buttonBook" runat="server" Text="Book" Visible="false" CommandName="submit"
                                                                            OnClick="btnRoundTripBook_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trroundTrip">
                                                        <td width="100%" valign="top">
                                                            <table runat="server" width="100%" id="tblRoundTrip">
                                                                <tr>
                                                                    <td >
                                                                        <asp:Label ID="lblOnwardDepartureAirportCode" runat="server" Text=""></asp:Label>
                                                                        &nbsp;<asp:Label ID="lblOnwardTO" runat="server" Text="TO" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblOnwardArrivalAirportCode" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td >
                                                                        <asp:Label ID="lblReturnDepartureAirportCode" runat="server" Text=""></asp:Label>
                                                                        &nbsp;<asp:Label ID="lblReturnTO" runat="server" Text="TO" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblReturnArrivalAirportCode" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                <td colspan="2" align="right">
                                                                  <asp:LinkButton ID="lnkSNFFareroundtrip" runat="server" OnClientClick = "return showHNFRoundtrip();" 
                                             >SNF</asp:LinkButton>
                                                                </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" valign="top" >
                                                                        <asp:GridView ID="gdvOnward" Width="100%" runat="server" AutoGenerateColumns="false"
                                                                            OnRowDataBound="gdvOnward_RowDataBound" EmptyDataText="No Flights" EditRowStyle-Width="500">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Airline">
                                                                                    <ItemTemplate>
                                                                                        <asp:RadioButton ID="rbnAirline" AutoPostBack="true" GroupName="two" runat="server" OnCheckedChanged="rbnAirlineonward_CheckedChanged" />
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
                                                                                        <%-- <asp:Label ID="lblDepartname" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>--%>
                                                                                        <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>' Font-Bold="true"></asp:Label><br />
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
                                                                                        <%-- <asp:Label ID="lblArrives" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>--%>
                                                                                        <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>' Font-Bold="true"></asp:Label>
                                                                                        <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Fare">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFare" runat="server" Font-Bold="true"></asp:Label><%--<%# Eval("ActualBaseFare") %>--%>
                                                                                        <br />
                                                                                         <asp:Label ID="lblHNFFareonward" Style="display: none;" runat="server"  Font-Bold="true" CssClass ="clsFind"></asp:Label>
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
                                                                                                            <tr id="discount" runat="server" visible="false">
                                                                                                                <td >
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
                                                                                            <asp:Label ID="lblTChargeonwardgv" runat="server"></asp:Label>
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
                                                                                <%--     <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnBookNow" runat="server" Text="Book Now" OnClick="btnBookNow_Click"
                                                                    BackColor="LightBlue" ForeColor="White" CommandName="BoolTicket" CommandArgument='<%# Eval("FlightSegment_ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                                            </Columns>
                                                                              <AlternatingRowStyle CssClass="gridAlter" />
                                                                              <RowStyle CssClass="gridAlter" />
                                                                            <HeaderStyle BackColor="LightBlue" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        <asp:GridView ID="gdvReturn" Width="100%" runat="server" AutoGenerateColumns="false"
                                                                            OnRowDataBound="gdvReturn_RowDataBound" EmptyDataText="No Flights" EmptyDataRowStyle-Width="90%">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Airline">
                                                                                    <ItemTemplate>
                                                                                        <asp:RadioButton ID="rbnAirline" AutoPostBack="true" GroupName="one" runat="server" OnCheckedChanged="rbnAirlineReturn_CheckedChanged" />
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
                                                                                        <%-- <asp:Label ID="lblDepartname" runat="server" Text='<%# Eval("DepartureAirportCode") %>'></asp:Label>--%>
                                                                                        <asp:Label ID="lblDepartTime" runat="server" Text='<%# Eval("DepartureDateTime") %>' Font-Bold="true"></asp:Label><br />
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
                                                                                        <%-- <asp:Label ID="lblArrives" runat="server" Text='<%# Eval("ArrivalAirportCode") %>'></asp:Label>--%>
                                                                                        <asp:Label ID="lblArrivalTime" runat="server" Text='<%# Eval("ArrivalDateTime") %>' Font-Bold="true"></asp:Label>
                                                                                        <asp:Label ID="lblarrivaldate" runat="server" Visible="false" Text='<%# Eval("ArrivalDateTime") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Fare">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFare" runat="server" Font-Bold="true"></asp:Label><%--<%# Eval("ActualBaseFare") %>--%>
                                                                                        <br />
                                                                                         <asp:Label ID="lblHNFFarereturn" Style="display: none;" runat="server" Font-Bold="true" CssClass ="clsFind"></asp:Label>
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
                                                                                                            <tr id="Trdis12" runat="server" visible="false">
                                                                                                                <td >
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
                                                                                            <asp:Label ID="lblTChargereturngv" runat="server"></asp:Label>
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
                                                                                                                    <asp:Label ID="lbladultone" runat="server"  Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblchildone" runat="server"  Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblinfantone" runat="server"  Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="lblTripone" runat="server"  Visible="false"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--     <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnBookNow" runat="server" Text="Book Now" OnClick="btnBookNow_Click"
                                                                    BackColor="LightBlue" ForeColor="White" CommandName="BoolTicket" CommandArgument='<%# Eval("FlightSegment_ID") %>' />
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
                         
                   
                
                
                <asp:Panel ID="pnlPassengerDet" runat="server" Visible="false"  BackColor="White">
                    <table width="100%" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblRoutetwo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="padding:5px;">
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
                                            <asp:Label ID="Label1" runat="server" Text="Mobile Number : "></asp:Label><span style="color: Red;">*</span>
                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" onchange="javascript:txttextchanged();" CssClass="lj_inp" ></asp:TextBox>&nbsp; (Will be contacted
                                            in case of flight delay etc..)
                                            <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ValidationGroup="SubmitBook" ErrorMessage="Enter Mobile No"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceMobileNo" runat="server" TargetControlID="rfvtxtMobileNo"></ajax:ValidatorCalloutExtender>
                                                   <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="0123456789"
                                                     TargetControlID="txtMobileNo">
                                            </ajax:FilteredTextBoxExtender>
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  Display="None"
                                                ControlToValidate="txtMobileNo" ErrorMessage="Invalid mobile no" 
                                                ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                                <ajax:ValidatorCalloutExtender ID="vceMobileNo1" runat="server" TargetControlID="RegularExpressionValidator1"></ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding:5px;">
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
                                            <asp:DropDownList ID="dlTitle" runat="server" Width="50px"  CssClass="lj_inp">
                                                <asp:ListItem Value="Mr." Selected="True">Mr.</asp:ListItem>
                                                <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
                                                <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="15%" style="padding-left:6px;">
                                         First Name<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center">
                                         :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFirstname" runat="server" CssClass="lj_inp" MaxLength="20"
                                                ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFN" runat="server" ErrorMessage="Enter First Name" ControlToValidate="txtFirstname" Display="None" ValidationGroup="SubmitBook"></asp:RequiredFieldValidator>
                                           <ajax:ValidatorCalloutExtender ID="vceFirstName" runat="server" TargetControlID="rfvFN"></ajax:ValidatorCalloutExtender>
                                                   <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                     TargetControlID="txtFirstname">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td width="15%" style="padding-left:6px;">
                                         Last Name<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center">
                                         :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="lj_inp" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Enter Last Name" Display="None" ValidationGroup="SubmitBook" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceLastName" runat="server" TargetControlID="rfvLastName"></ajax:ValidatorCalloutExtender>
                                             <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                     TargetControlID="txtLastName">
                                                     </ajax:FilteredTextBoxExtender>
                                            <asp:RegularExpressionValidator ID="rexprLastName" runat="server"  ControlToValidate="txtLastName" ErrorMessage="Minimum 2 Characters Required" ValidationExpression = "^[\s\S]{2,}$"  Display="None" ></asp:RegularExpressionValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceLastName1" runat="server" TargetControlID="rexprLastName" ></ajax:ValidatorCalloutExtender>
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
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789"  TargetControlID="txtPhoneNum" >
                                            </ajax:FilteredTextBoxExtender>
                                            
                                        </td>
                                        <td align="left" width="20%" valign="top" style="padding-left:6px;">
                                            Mobile Number<span style="color: Red;">*</span>
                                        </td>
                                        <td align="center" width="15" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="bottom">
                                            <asp:TextBox ID="txtMobileNum" runat="server" MaxLength="10" CssClass="lj_inp"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Mobile Number" Display="None" ValidationGroup="SubmitBook"
                                                ControlToValidate="txtMobileNum"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceMobileNum" runat="server" TargetControlID="RequiredFieldValidator5"></ajax:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="rgfvalidater" runat="server" 
                                                ControlToValidate="txtMobileNum" ErrorMessage="Invalid mobile no" 
                                                ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                             <ajax:ValidatorCalloutExtender ID="vceMobileNum1" runat="server" TargetControlID="rgfvalidater"></ajax:ValidatorCalloutExtender>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789" TargetControlID="txtMobileNum">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left" width="15%" valign="top" style="padding-left:6px;">
                                            Email ID<span style="color: Red;">*</span>
                                        </td>
                                        <td align="center" width="15" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtEmailID" runat="server" CssClass="lj_inp"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Email ID" Display="None" ValidationGroup="SubmitBook"
                                                ControlToValidate="txtEmailID"></asp:RequiredFieldValidator>
                                           <ajax:ValidatorCalloutExtender ID="vceEmail2" runat="server" TargetControlID="RequiredFieldValidator6"></ajax:ValidatorCalloutExtender>
                                                   <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtEmailID" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_" ></ajax:FilteredTextBoxExtender>
                                                     <asp:RegularExpressionValidator ID="regularmail" runat="server"  Display="None" ValidationGroup="SubmitBook"
                                                ControlToValidate="txtEmailID" ErrorMessage="Invalid EmailId" 
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <ajax:ValidatorCalloutExtender ID="vceEmail3" runat="server" TargetControlID="regularmail"></ajax:ValidatorCalloutExtender>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" >
                                            Confirm Email ID<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center">
                                            :
                                        </td>
                                        <td valign="top" height="30px">
                                            <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="lj_inp" onclick="javascript:vtxtEmailId();"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Confirm Email ID" Display="None" ValidationGroup="SubmitBook"
                                                ControlToValidate="txtConfirmEmail"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="RequiredFieldValidator7"></ajax:ValidatorCalloutExtender>
                                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  Display="None" 
                                                ControlToValidate="txtConfirmEmail" ErrorMessage="Invalid EmailId" 
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <ajax:ValidatorCalloutExtender ID="vceEmail4" runat="server" TargetControlID="RegularExpressionValidator2"></ajax:ValidatorCalloutExtender>

                                                  <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtConfirmEmail" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz @.1234567890_" ></ajax:FilteredTextBoxExtender>
                                                  <asp:CompareValidator ID="vlc" runat="server" Display="None" ControlToValidate="txtConfirmEmail" ErrorMessage="Emailid & Confirm Emailid should be same" ControlToCompare="txtEmailID"  Operator="Equal"></asp:CompareValidator>
                                             <ajax:ValidatorCalloutExtender ID="vceEmail5" runat="server" TargetControlID="vlc"></ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                </table>
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
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="lj_inp"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Address" Display="None" ValidationGroup="SubmitBook"
                                                ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceAddress" runat="server" TargetControlID="RequiredFieldValidator8"></ajax:ValidatorCalloutExtender>
                                                   
                                        </td>
                                         <td align="left" width="15%" style="padding-left:6px;">
                                            City / Town<span style="color: Red;">*</span>
                                        </td>
                                        <td align="center" width="5%">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="lj_inp"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter City" Display="None" ValidationGroup="SubmitBook"
                                                ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                                                   <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtCity" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz " ></ajax:FilteredTextBoxExtender>
                                                   <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="RequiredFieldValidator9"></ajax:ValidatorCalloutExtender>
                                        </td>
                                         <td align="left" width="15%" style="padding-left:6px;">
                                            State<span style="color: Red;">*</span>
                                        </td>
                                        <td align="center" width="5%">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtState" runat="server" CssClass="lj_inp"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter State" Display="None"  ValidationGroup="SubmitBook"
                                                ControlToValidate="txtState"></asp:RequiredFieldValidator>
                                                   <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtState" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz " ></ajax:FilteredTextBoxExtender>
                                                   <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="RequiredFieldValidator10"></ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                   

                                    <tr>
                                        <td width="15%" align="left">
                                            Pin Code<span style="color: Red;">*</span>
                                        </td>
                                        <td width="5%" align="center">
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="6" CssClass="lj_inp"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter Pin Code" ValidationGroup="SubmitBook" Display="None"
                                                ControlToValidate="txtPostalCode"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vcePincode" runat="server" TargetControlID="RequiredFieldValidator11"></ajax:ValidatorCalloutExtender>
                                                 <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="0123456789" TargetControlID="txtPostalCode">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td width="15%" style="padding-left:6px;">
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
                                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" Display="None" ErrorMessage="Enter Country" ValidationGroup="SubmitBook"  ControlToValidate="ddlcountry"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceCountry" runat="server" TargetControlID="rfvCity"></ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                   

                                </table>
                                <table>
                                    <tr>
                                        <td style="padding-left:5px">
                                            <asp:Button ID="btnBook" runat="server" CssClass="buttonBook" Text="Submit" OnClick="btnBook_Click" ValidationGroup="SubmitBook"  />
                                                              
                                            <asp:Button ID="btnRoundTripSubmit" runat="server" CssClass="buttonBook" ValidationGroup="SubmitBook" Text="Submit" OnClick="btnRoundTripSubmit_Click"  />
                                              <asp:Button ID="btnBack" runat="server" CssClass="buttonBook" Text="Back" onclick="btnBack_Click" />
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
                                                                            <tr id="Trdis23" runat="server" visible="false">
                                                                                <td >
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
                                                                                            <asp:Label ID="lblTchargeOnward" runat="server"></asp:Label>
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
                                                                            <tr id="Trdis34" runat="server" visible="false">
                                                                                <td >
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
                                                                                            <asp:Label ID="lblTchargeReturn" runat="server"></asp:Label>
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
            <tr  id="downlink" runat="server">
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
                                <%--<tr>
                                    <td>
                                        <table width="100%" style="border: 1px solid; border-color: Blue">
                                            <tr>
                                                <td>
                                                    Your Airline PNR :
                                                    <asp:Label ID="lblPNR" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>--%>
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
                                    <tr><td>
                                        <table width="100%" border="1" style="border-color: Blue">
                                            <tr>
                                                <th align="left">
                                                  Return Airline
                                                </th>
                                                <th align="left">
                                                  Return  Flight No
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
                                        </td></tr></table>
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
   <asp:Panel ID="pnl" runat="server" style="position:fixed; top:0px; left:0px; display:none; border:background:url(images/overlay1.png);  width:100;height:200;padding-top:10px;text-align:center; z-index:1;" 
align="center">
       <table width="300" bgcolor="#eefaff"  style="border:#222 5px solid;" height="100">
        <tr><td>&nbsp;</td></tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
         
            <tr><td align="center"><asp:Button ID="btnMsg1" runat="server" Text="Ok" CssClass="buttonBook"/></td></tr>
            <tr><td>&nbsp;</td></tr>
        </table>
    </asp:Panel>
    </td>
    </tr>
    </table>
</asp:Content>
