<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Users/Flight/MasterPage.master"
    CodeFile="AgentReports.aspx.cs" Inherits="Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    function Load() {

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            var dateToday = new Date();
            $(".datepicker").datepicker({
                dateFormat: 'dd/mm/yy',
                numberOfMonths: 2,
                showOn: "button",
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: '12-12-1990'
            });

            $(".datepicker1").datepicker({
                dateFormat: 'dd/mm/yy',
                showOn: "button",
                numberOfMonths: 1,
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: '12-12-1990'
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
            dateFormat: 'dd/mm/yy',
            numberOfMonths: 2,
            showOn: "button",
            buttonImage: "../../images/calendar.jpg",
            buttonImageOnly: true,
            showAnim: 'fadeIn',
            minDate: '12-12-1990'
        });

    });
    $(function () {
        var dateToday = new Date();
        $(".datepicker1").datepicker({
            dateFormat: 'dd/mm/yy',
            showOn: "button",
            numberOfMonths: 1,
            buttonImage: "../../images/calendar.jpg",
            buttonImageOnly: true,
            showAnim: 'fadeIn',
            minDate: '12-12-1990'
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
            setTimeout('document.images["myAnimatedImage"].src = "Images/roller_big.gif"', 200);
        }
        else {
            return false;
        }
    }
    function Adddob() {
        //alert('hi');
        document.getElementById('<%=txtfromdate.ClientID %>').value = "";

    }
    function Adddob1() {
        //alert('hi');
        document.getElementById('<%=txttodate.ClientID %>').value = "";

    }

    </script>
<%--<script type="text/javascript">
    function Adddob() {
        //alert('hi');
        document.getElementById('<%=txtfromdate.ClientID %>').value = "";

    }
    function Adddob1() {
        //alert('hi');
        document.getElementById('<%=txttodate.ClientID %>').value = "";

    }

      
       
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" style="background-color:White;">
     <tr>
                                    <td colspan="2" align="center" class="heading">
                                   Agent Reports
                                    </td>
                                </tr>
        <tr>
            <td width="100%" align="center">
                <table>
                    <tr>
                        <td width="600" align="center">
                            <table width="600">
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdlflights" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                            Width="300" OnSelectedIndexChanged="rdlflights_SelectedIndexChanged">
                                            <asp:ListItem Value="DomesticFlights">Domestic Flights</asp:ListItem>
                                            <asp:ListItem Value="InterNationalFlights">International Flights</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="rfvedllist" runat="server" ControlToValidate="rdlflights"
                                            ValidationGroup="true" Display="None" ErrorMessage="Please select Flight Type.">
                                        </asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="vceedllist" runat="server" TargetControlID="rfvedllist">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" width="600">
                                        <table width="600">
                                            <tr id="source1" runat="server" visible="false">
                                                <td colspan="6" width="600">
                                                    <table width="100%">
                                                        <tr id="IF" runat="server" visible="false">
                                                            <td width="21%">
                                                                Source
                                                            </td>
                                                            <td width="31%" align="left">
                                                                &nbsp;<asp:TextBox ID="txtFrom" Width="150" runat="server" ToolTip="Type the first 3 letters of airport or city name"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvFrom" Display="None" ValidationGroup="SearchInt"
                                                                    runat="server" ErrorMessage="Enter Source" ControlToValidate="txtFrom">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvFrom">
                                                                </asp:ValidatorCalloutExtender>
                                                                <asp:AutoCompleteExtender ID="txtFrom_AutoCompleteExtender" runat="server" TargetControlID="txtFrom"
                                                                    ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                    CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                    ServicePath="">
                                                                </asp:AutoCompleteExtender>
                                                            </td>
                                                            <td align="left" width="14%">
                                                                &nbsp;&nbsp; Destinations
                                                            </td>
                                                            <td align="left" width="35%">
                                                                &nbsp;&nbsp;<asp:TextBox ID="txtTo" runat="server" Width="150" ToolTip="Type the first 3 letters of airport or city name"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvTo" Display="None" ValidationGroup="SearchInt"
                                                                    runat="server" ErrorMessage="Enter Destination" ControlToValidate="txtTo">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rfvTo">
                                                                </asp:ValidatorCalloutExtender>
                                                                <asp:AutoCompleteExtender ID="txtTo_AutoCompleteExtender" runat="server" TargetControlID="txtTo"
                                                                    ServiceMethod="GetAirportCodes" MinimumPrefixLength="3" CompletionInterval="10"
                                                                    CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                                    ServicePath="">
                                                                </asp:AutoCompleteExtender>
                                                            </td>
                                                        </tr>
                                                        <tr id="Domestic" runat="server" visible="false">
                                                            <td width="21%">
                                                                Source
                                                            </td>
                                                            <td width="31%">
                                                                &nbsp;<asp:DropDownList ID="ddlsource" Width="150" runat="server">
                                                                    <asp:ListItem Value="0" Selected="True">Please Select</asp:ListItem>
                                                                    <asp:ListItem Value="BOM">MUMBAI</asp:ListItem>
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
                                                            <td width="14%">
                                                                &nbsp;&nbsp; Destinations
                                                            </td>
                                                            <td width="35%">
                                                                &nbsp;&nbsp;
                                                                <asp:DropDownList ID="ddldestinations" Width="150" runat="server">
                                                                    <asp:ListItem Value="0" Selected="True">Please Select</asp:ListItem>
                                                                    <asp:ListItem Value="DEL">DELHI</asp:ListItem>
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
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                  From Date
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txtfromdate" Width="150" runat="server" CssClass="datepicker" onchange="showDate(); return true;" onkeyup="javascript:Adddob();";" >
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="txtdate" Width="150" runat="server" Visible="false">
                                                    </asp:TextBox>
                                                  <%--  <asp:CalendarExtender ID="Calcdate" runat="server" TargetControlID="txtfromdate">
                                                    </asp:CalendarExtender>--%>
                                                </td>
                                                    <td>
                                                  To Date
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txttodate" Width="150" runat="server" CssClass="datepicker" OnClick="showDate1();" onkeyup="javascript:Adddob1();" >
                                                    </asp:TextBox>
                                                
                                                 <%--   <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate">
                                                    </asp:CalendarExtender>--%>
                                                </td>
                                                </tr>
                                                <tr>
                                                
                                               
                                                <td>
                                                    Ref No
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrefno" Width="150" runat="server" CssClass="lj_inp">
                                                    </asp:TextBox>
                                                </td>
                                              <td>
                                                   User Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtname" Width="150" runat="server" CssClass="lj_inp">
                                                    </asp:TextBox>
                                                         <asp:autocompleteextender id="Autocompleteextender1" runat="server" targetcontrolid="txtname"
                                                        servicemethod="GetAgentNames" minimumprefixlength="1" completioninterval="10"
                                                        completionsetcount="12" firstrowselected="True" delimitercharacters="" enabled="True"
                                                        servicepath="">
                                                </asp:autocompleteextender>
                                                    <asp:DropDownList ID="ddlagent1" runat="server" Visible="false">
                                                    </asp:DropDownList>
                                                </td>
                                           <%-- <tr>
                                                <td>
                                                    Date Of Journey
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdate" Width="150" runat="server">
                                                    </asp:TextBox>
                                                    <asp:CalendarExtender ID="Calcdate" runat="server" TargetControlID="txtdate">
                                                    </asp:CalendarExtender>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Ref No
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrefno" Width="150" runat="server">
                                                    </asp:TextBox>
                                                </td>--%>
                                                <%--                <td >
                                                    Date Of Issue
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdateofissue" Width="150" runat="server">
                                                    </asp:TextBox>
                                                    <asp:CalendarExtender ID="calctxtdateofissue" runat="server" TargetControlID="txtdateofissue"
                                                        Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>
                                                </td>--%>
                                            </tr>
                                            <tr id="source" runat="server" visible="false">
                                                <td>
                                                    Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtname1" Width="150" runat="server">
                                                    </asp:TextBox>
                                                         <asp:autocompleteextender id="txtFrom_AutoCompleteExtender1" runat="server" targetcontrolid="txtname"
                                                        servicemethod="GetAgentNames" minimumprefixlength="1" completioninterval="10"
                                                        completionsetcount="12" firstrowselected="True" delimitercharacters="" enabled="True"
                                                        servicepath="">
                                                </asp:autocompleteextender>
                                                    <asp:DropDownList ID="ddlagent11" runat="server" Visible="false">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    EmailID
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtemailId" Width="150" runat="server">
                                                    </asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="rgfexpression" ErrorMessage="Please enter valid email Id"
                                                        Display="None" ControlToValidate="txtemailId" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                    </asp:RegularExpressionValidator>
                                                    <asp:ValidatorCalloutExtender ID="vcstxtemailId" runat="server" TargetControlID="rgfexpression">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <%--      </tr>
                                            <tr>
                                            
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Operator
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddloperator" Width="150" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>--%>
                                            </tr>
                                                <tr id="source2" runat="server" visible="false">
                                                    <td>
                                                        Contact No
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtcontactno" Width="150" runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        Status
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlstatus" Width="150" runat="server">
                                                            <asp:ListItem Value="ALL">ALL</asp:ListItem>
                                                            <asp:ListItem Value="SUCCESS">Booked</asp:ListItem>
                                                            <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="source3" runat="server" visible="false">
                                                    <td>
                                                       <asp:Label ID="lblpaging" runat="server" Text="Paging"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlpagesize" Width="150" runat="server" CssClass="lj_inp">
                                                            <asp:ListItem Value="100" Selected="True">100</asp:ListItem>
                                                            <asp:ListItem Value="200">200</asp:ListItem>
                                                            <asp:ListItem Value="400">400</asp:ListItem>
                                                            <asp:ListItem Value="800">800</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td colspan="5">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" align="center">
                                                        <asp:Button ID="btnsearch" runat="server" Text="Search" ValidationGroup="true" CssClass="buttonBook"  OnClick="btnsearch_Click" />&nbsp;
                                                        <asp:Button ID="Button1" runat="server" Text="Reset" CausesValidation="false" CssClass="buttonBook"  OnClick="Button1_Click" />&nbsp;
                                                         <asp:Button ID="btnExport" runat="server" Text="Export To Excel" Visible="true"
                                                    CssClass="buttonBook" Style="cursor: pointer;" onclick="btnExport_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td colspan="5" align="right">
                                                 
                                                </td>
                                                </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GvFlightsReports" Width="100%" runat="server" AutoGenerateColumns="False"
                                EmptyDataRowStyle-Height="250" AllowPaging="True" 
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                ShowFooter="true" EmptyDataText="No records found" EmptyDataRowStyle-Font-Bold="true"
                                EmptyDataRowStyle-Font-Size="Small" EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                EmptyDataRowStyle-HorizontalAlign="Center" AllowSorting="True" CellPadding="4"
                                EnableModelValidation="True" ForeColor="#333333" OnRowDataBound="GvFlightsReports_RowDataBound"
                                onsorting="GvFlightsReports_Sorting" 
                                onpageindexchanging="GvFlightsReports_PageIndexChanging" PageSize="100">
                                <footerstyle backcolor="White" forecolor="#000066" />
                                <headerstyle backcolor="#006699" font-bold="True" forecolor="White" height="30" />
                                <pagerstyle backcolor="White" forecolor="#000066" horizontalalign="Left" />
                                <rowstyle forecolor="#000066" horizontalalign="Center" height="25" />
                                <selectedrowstyle backcolor="#669999" font-bold="True" forecolor="White" />
                                <columns>
                                    <asp:TemplateField HeaderText="Booking Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookingId" runat="server" Text='<%# Eval("Int_Booking_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="ReferenceNo"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblReferenceNo" runat="server" Text='<%# Eval("ReferenceNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Travel Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="90px" ControlStyle-Width="90px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                         <asp:Label ID="lblDepartureAirportName" runat="server"  Text='<%# Eval("ArrivalAirportName") %>'></asp:Label> 
                                            <asp:Label ID="lblArrivalAirportName" runat="server"  Text='<%# Eval("ArrivalAirportName") %>' Visible="false"></asp:Label>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="CustomerDetails"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="130px" ControlStyle-Width="130px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomerDetails" runat="server" Width="130px" Text='<%# Eval("CustomerDetails") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="EmailAddress"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="200px" ControlStyle-Width="200px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmailAddress" runat="server" Width="170px" Text='<%# Eval("EmailAddress") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="Telephone"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="80px" ControlStyle-Width="80px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTelephone" runat="server" Text='<%# Eval("Telephone") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Journey Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureDateTime"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="70px" ControlStyle-Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartureDateTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Flight No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="FlightNumber"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="ActualBasefare"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="70px" ControlStyle-Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblActualBasefare" runat="server" Width="70px" Text='<%# Eval("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblactulafare" runat="server" ForeColor="Red"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Scharge" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="Scharge"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblScharge" runat="server" Text='<%# Eval("Scharge") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblScharge" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="TDiscount"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTDiscount" runat="server" Text='<%# Eval("TDiscount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbldiscount" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comm (Rs)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="TPartnerCommission"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTPartnerCommission" runat="server" Text='<%# Eval("TPartnerCommission") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblcomm" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TCharge" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="TCharge"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTCharge" runat="server" Width="50" Text='<%# Eval("TCharge") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblcharge" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MarkUp" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="TMarkUp"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTMarkUp" runat="server" Text='<%# Eval("TMarkUp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblmarkup" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Refund Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="RefundAmount"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRefundAmount" runat="server" Width="50px" Text='<%# Eval("RefundAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblRefundAmount1" Width="50px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cancel Charges" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" SortExpression="CancellationCharges"
                                        ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCancellationCharges" runat="server" Width="50px" Text='<%# Eval("CancellationCharges") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblCancellationCharges1" Width="50px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Closing Balance" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="80px" SortExpression="ClosingBalance"
                                        ControlStyle-Width="80px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblClosingBalance" runat="server" Width="80px" Text='<%# Eval("ClosingBalance") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblClosingBalance1" Width="80px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField> 
                                           <asp:TemplateField HeaderText="Booking Date & Time" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="Status"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="70px" ControlStyle-Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookingTime" runat="server" Text='<%# Eval("BookingTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                           <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="UserName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="70px" ControlStyle-Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="Status"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="70px" ControlStyle-Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </columns>
                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                <footerstyle horizontalalign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
