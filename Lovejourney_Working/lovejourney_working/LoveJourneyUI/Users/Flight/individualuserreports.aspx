<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Flight/MasterPage.master" AutoEventWireup="true" CodeFile="individualuserreports.aspx.cs" Inherits="Users_Flight_individualuserreports" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
    function Adddob() {
        //alert('hi');
        document.getElementById('<%=txtfromdate.ClientID %>').value = "";

    }
    function Adddob1() {
        //alert('hi');
        document.getElementById('<%=txttodate.ClientID %>').value = "";

    }

      
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" bgcolor="#ffffff">
        <tr>
            <td width="100%">
                <table width="100%">
                    <tr id="trtable" runat="server">
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
                                    <td align="left" width="600">
                                        <table width="600">
                                            <tr id="source" runat="server" visible="false">
                                                <td colspan="6" width="600">
                                                    <table width="100%">
                                                        <tr id="IF" runat="server" visible="false">
                                                            <td width="19%">
                                                                Source
                                                            </td>
                                                            <td width="35%" align="left">
                                                                <asp:TextBox ID="txtFrom" Width="150" runat="server" ToolTip="Type the first 3 letters of airport or city name" ></asp:TextBox>
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
                                                            <td align="left" width="11%">
                                                                &nbsp;&nbsp; Destinations
                                                            </td>
                                                            <td align="left" width="35%">
                                                                <asp:TextBox ID="txtTo" runat="server" Width="150" ToolTip="Type the first 3 letters of airport or city name" onkeyup="javascript:Adddob1();"></asp:TextBox>
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
                                                            <td width="19%">
                                                                Source
                                                            </td>
                                                            <td width="35%">
                                                                <asp:DropDownList ID="ddlsource" Width="150" runat="server">
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
                                                            <td width="11%">
                                                                &nbsp;&nbsp; Destinations
                                                            </td>
                                                            <td width="35%">
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
                                            <tr  >
                                                <td>
                                                  From Date
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txtfromdate" Width="150" runat="server" onkeyup="javascript:Adddob();" CssClass="lj_inp" >
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="txtdate" Width="150" runat="server" Visible="false">
                                                    </asp:TextBox>
                                                    <asp:CalendarExtender ID="Calcdate" runat="server" TargetControlID="txtfromdate">
                                                    </asp:CalendarExtender>
                                                </td>
                                                    <td>
                                                  To Date
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txttodate" Width="150" runat="server" onkeyup="javascript:Adddob1();" CssClass="lj_inp">
                                                    </asp:TextBox>
                                                
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate">
                                                    </asp:CalendarExtender>
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
                                                        Page Size
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlpagesize" Width="150" runat="server" CssClass="lj_inp">
                                                            <asp:ListItem Value="100" Selected="True">100</asp:ListItem>
                                                            <asp:ListItem Value="200">200</asp:ListItem>
                                                            <asp:ListItem Value="400">400</asp:ListItem>
                                                            <asp:ListItem Value="800">800</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                
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
                                            <tr  id="source1" runat="server" visible="false">
                                                <td>
                                                    Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtname" Width="150" runat="server" CssClass="lj_inp">
                                                    </asp:TextBox>
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
                                                    </tr>
                                           <%--   <tr>
                                            
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
                                                <tr   id="source6" runat="server" visible="false">
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
                                                <tr>
                                             <td>
                                                   <%-- Name--%>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtusername" Width="150" runat="server" Visible="false">
                                                    </asp:TextBox>
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
                                                    <td colspan="5" align="center">
                                                        <asp:Button ID="btnsearch" runat="server" Text="Search" ValidationGroup="true" 
                                                            OnClick="btnsearch_Click" CssClass="buttonBook" />&nbsp;
                                                        <asp:Button ID="Button1" runat="server" Text="Reset" CausesValidation="false" 
                                                            OnClick="Button1_Click" CssClass="buttonBook" />&nbsp;
                                                         <asp:Button ID="btnExport" runat="server" Text="Export To Excel" Visible="true"
                                                    CssClass="buttonBook" Style="cursor: pointer;" onclick="btnExport_Click" />
                                                    </td>
                                                </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trgv" runat="server">
                        <td>
                            <asp:GridView ID="GvFlightsReports" Width="100%" runat="server" AutoGenerateColumns="False"
                                EmptyDataRowStyle-Height="250" AllowPaging="True" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                ShowFooter="true" EmptyDataText="No records found" EmptyDataRowStyle-Font-Bold="true"
                                EmptyDataRowStyle-Font-Size="Small" EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                EmptyDataRowStyle-HorizontalAlign="Center" AllowSorting="True" CellPadding="4"  
                                EnableModelValidation="True" ForeColor="#333333" OnRowDataBound="GvFlightsReports_RowDataBound"
                                OnSorting="GvFlightsReports_Sorting" OnPageIndexChanging="GvFlightsReports_PageIndexChanging" PageSize="100"
                                OnRowCommand="GvFlightsReports_RowCommand">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Booking Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookingId" runat="server" Text='<%# Eval("Int_Booking_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="ReferenceNo" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                        ControlStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblReferenceNo" runat="server" Text='<%# Eval("ReferenceNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="CustomerDetails" HeaderStyle-ForeColor="White" HeaderStyle-Width="130px"
                                        ControlStyle-Width="130px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomerDetails" runat="server" Width="130px" Text='<%# Eval("CustomerDetails") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Travel Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="ArrivalAirportName" HeaderStyle-ForeColor="White" HeaderStyle-Width="90px"
                                        ControlStyle-Width="90px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblArrivalAirportName" runat="server" Width="90px" Text='<%# Eval("ArrivalAirportName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                              
                                    <asp:TemplateField HeaderText="Email ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="EmailAddress" HeaderStyle-ForeColor="White" HeaderStyle-Width="130px"
                                        ControlStyle-Width="180px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmailAddress" runat="server" Width="180px" Text='<%# Eval("EmailAddress") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false"
                                        SortExpression="Telephone" HeaderStyle-ForeColor="White" HeaderStyle-Width="80px"
                                        ControlStyle-Width="80px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTelephone" runat="server" Text='<%# Eval("Telephone") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Journey Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="DepartureDateTime" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                        ControlStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartureDateTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Flight No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="FlightNumber" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                        ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="ActualBasefare" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                        ControlStyle-Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblActualBasefare" runat="server" Width="70px" Text='<%# Eval("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblactulafare" runat="server" ForeColor="Red"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Scharge" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="Scharge" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                        ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblScharge" runat="server" Text='<%# Eval("Scharge") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblScharge" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="TDiscount" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                        ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTDiscount" runat="server" Text='<%# Eval("TDiscount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbldiscount" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                <%--      <asp:TemplateField HeaderText="LJ Fare (Rs)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="MBFare" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                        ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMBFare" runat="server" Text='<%# Eval("MBFare") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblMBFare" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Comm (Rs)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="TPartnerCommission" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                        ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTPartnerCommission" runat="server" Text='<%# Eval("TPartnerCommission") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblcomm" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                      <%--              <asp:TemplateField HeaderText="TCharge" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="TCharge" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" Visible="false"
                                        ControlStyle-Width="50px" >
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTCharge" runat="server" Width="50" Text='<%# Eval("TCharge") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblcharge" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="MarkUp" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="TMarkUp" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" Visible="false"
                                        ControlStyle-Width="50px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTMarkUp" runat="server" Text='<%# Eval("TMarkUp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblmarkup" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Refund Amount" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-HorizontalAlign="Center" SortExpression="RefundAmount" HeaderStyle-ForeColor="White"
                                        HeaderStyle-Width="50px" ControlStyle-Width="50px" Visible="false">
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
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                        SortExpression="CancellationCharges" ControlStyle-Width="50px" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCancellationCharges" runat="server" Width="50px" Text='<%# Eval("CancellationCharges") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblCancellationCharges1" Width="50px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Booking Date & Time" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="80px"
                                        SortExpression="BookingTime" ControlStyle-Width="80px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookingTime" runat="server" Width="80px" Text='<%# Eval("BookingTime") %>'></asp:Label>
                                        </ItemTemplate>
                                     
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false"
                                        SortExpression="UserName" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                        ControlStyle-Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="Status" HeaderStyle-ForeColor="White" HeaderStyle-Width="70px"
                                        ControlStyle-Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table align="center">
                                                <tr align="left" valign="top">
                                                    <td>
                                                        <%--<asp:LinkButton ID="lbtnprintorder" runat="server" CommandName="print" CommandArgument='<%#Eval("ReferenceNo") %>'
                                                            CausesValidation="false">View</asp:LinkButton>--%>
                                                        <asp:Button ID="lbtnprintorder" runat="server" CommandName="print"  CommandArgument='<%#Eval("ReferenceNo") %>'  CausesValidation="false" Text="View" CssClass="buttonBook" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                   <%--  <asp:TemplateField>
                                        <ItemTemplate>
                                            <table align="center">
                                                <tr align="left" valign="top">
                                                    <td>
                                                        <asp:LinkButton ID="lbtndownload" runat="server" CommandName="Download" CommandArgument='<%#Eval("ReferenceNo") %>'
                                                            CausesValidation="false">Download</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="trback" runat="server" visible ="false">
                        <td align="center">
                            <table width="900" align="center">
                                <tr>
                                    <td width="503" align="left">
                                        <span class="actions">
                                            <asp:LinkButton ID="lbtnback" Text="Back" runat="server" OnClick="lbtnback_Click"
                                                OnClientClick="showDiv();" /></span>
                                    </td>
                                    <td width="135" align="right">
                                        <span class="actions">
                                            <asp:LinkButton ID="lnkdownload" runat="server"  Text="Download" onclick="lnkdownload_Click"  
                                         
                                               
                                            ></asp:LinkButton>
                                          <%--  <asp:LinkButton ID="lbtnCancel" Text="Cancel" runat="server" OnClick="lbtnCancel_Click"
                                                Visible="false" />
                                            &nbsp;&nbsp;|&nbsp;&nbsp;
                                            <asp:RadioButton ID="radioButtonMailUp" runat="server" OnCheckedChanged="radioButtonMail_CheckedChanged"
                                                AutoPostBack="true" Text="Mail" GroupName="radioGroup" />
                                            <asp:LinkButton ID="lbtnmail" Text="Mail" runat="server" OnClick="lbtnmail_Click1"
                                                Visible="false" />--%>
                                            &nbsp;&nbsp;|&nbsp;&nbsp;<a onclick="printPage('printdiv');" target="_blank">
                                                <input id="Radio1" type="radio" runat="server" />Print </a></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center">
                            <asp:Panel ID="pnlmail" Width="900" runat="server" Visible="false">
                                <div id="printdiv" style="float: left;">
                                                        <table width="900" cellspacing="0" cellpadding="0" border="0" >
                                                            <tr>
                                                                <td>
                                                                    <table width="900" border="0" cellspacing="0" cellpadding="0" style="padding:4px; border:1px Solid #000000;">
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
                                                            <td height="5px">
                                                         
                                                            </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="1" bgcolor="#979595">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" align="left">
                                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0" style="border: 1px Solid #000000;">
                                                                    <tr>
                                                                    <td width="40%" style="border-right:1px Solid #000000;padding-left:10px;">
                                                                    <table width="90%">
                                                                  
                                                                        <tr>
                                                                            <td>
                                                                                Name :
                                                                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Mobile No:
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
                                                                    <td  width="30%" style="border-right:1px Solid #000000;padding-left:10px;">
                                                
                                                  <asp:Label ID="Label1" runat="server"   Text=" Your Airline PNR :" CssClass="pnrbold"></asp:Label>
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
                                                   <asp:Label ID="Label2" runat="server" Text="Love Journey Ref NO :" Visible="false"></asp:Label>
                                             
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
                                                                <asp:Label ID="lblEticket" runat="server" Text="Eticket" style="padding-left:200px;" ></asp:Label>
                                                                     <asp:Label ID="lblBookingTimeDate" runat="server" Text="Booking Date:" style="padding-left:200px;"  ></asp:Label>
                                                                    <asp:Label ID="lblBookingTime" runat="server" Text=""></asp:Label>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td>
                                                                    <table width="100%" style="border: 1px solid; ">
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
                                                                    <table width="100%" border="1" >
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
                                                                                <asp:Image ID="img" runat="server" />
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
                                                                                <table width="100%" border="1" >
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
                                                                                            <asp:Image ID="img1" runat="server" />
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
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

