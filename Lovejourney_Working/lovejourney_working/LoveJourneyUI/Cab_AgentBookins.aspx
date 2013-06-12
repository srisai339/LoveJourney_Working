<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMasterPage.master" AutoEventWireup="true" CodeFile="Cab_AgentBookins.aspx.cs" Inherits="Cab_AgentBookins" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function printPage(id) {

        var html = "<html>";

        html += document.getElementById(id).innerHTML;
        html += "</html>";

        var printWin = window.open('', '', 'left=0,top=0,toolbar=0,scrollbars=0,status  =0');
        printWin.document.write(html);
        printWin.document.close();
        printWin.focus();
        printWin.print();

    }
    </script>
 <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr></table>
    <asp:Panel ID="pnlMain" runat="server">
    <table width="100%" style="table-layout: fixed;"  bgcolor="#ffffff">
        <tr>
         <td width="100%" align="center" class="heading">
                <asp:Label ID="Label1" runat="server" Text="Bookings" Font-Size="13px"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td valign="bottom">
            <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSearch" runat="server">
                    <table width="100%">
                        <tr id="source" runat="server" visible="false">
                            <td width="15%" align="left">
                                City
                            </td>
                            <td width="35%" align="left">
                                <select name="strcity" id="ddlCity" style="width: 120px;" runat="server">
                                    <option value="line">--Select City-- </option>
                                    <option value="AGRA">AGRA </option>
                                    <option value="BANGALORE">BANGALORE </option>
                                    <option value="CHENNAI">CHENNAI </option>
                                    <option value="GOA">GOA </option>
                                    <option value="HYDERABAD">HYDERABAD </option>
                                    <option value="JAIPUR">JAIPUR </option>
                                    <option value="KOLKATA">KOLKATA </option>
                                    <option value="MUMBAI">MUMBAI / BOMBAY </option>
                                    <option value="NEW DELHI">NEW DELHI </option>
                                    <option value="line">-------------- </option>
                                    <option value="AGARTALA">AGARTALA </option>
                                    <option value="AGRA">AGRA </option>
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
                                    <option value="BANGALORE">BANGALORE </option>
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
                                    <option value="CHENNAI">CHENNAI </option>
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
                                    <option value="GOA">GOA </option>
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
                                    <option value="HYDERABAD">HYDERABAD </option>
                                    <option value="IDUKKI">IDUKKI </option>
                                    <option value="IGATPURI">IGATPURI </option>
                                    <option value="IMPHAL">IMPHAL </option>
                                    <option value="INDORE">INDORE </option>
                                    <option value="JABALPUR">JABALPUR </option>
                                    <option value="JAGDALPUR">JAGDALPUR </option>
                                    <option value="JAIPUR">JAIPUR </option>
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
                                    <option value="KANHA">KANHA </option>
                                    <option value="KANNUR">KANNUR </option>
                                    <option value="KANPUR">KANPUR </option>
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
                                    <option value="KOLKATA">KOLKATA </option>
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
                                    <option value="MUMBAI">MUMBAI / BOMBAY </option>
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
                                    <option value="NEW DELHI">NEW DELHI </option>
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
                            <td width="18%" align="left">
                                Ref No
                            </td>
                            <td width="32%" align="left">
                                <asp:TextBox ID="txtManabusRefNo1" runat="server" CssClass="Textbox" />
                            </td>
                        </tr>
                        <tr>
                            <td width="15%" align="left">
                               <%-- CheckIn Date--%> From Date
                            </td>
                            <td width="35%" align="left">
                            <asp:TextBox ID="txtfromdate" runat="server"  onkeyup="javascript:Adddob();"/>
                                <asp:TextBox ID="txtDOJ" runat="server"  Visible="false"/>
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                    Format="yyyy-MM-dd" TargetControlID="txtfromdate" PopupButtonID="ImageButton2">
                                </ajax:CalendarExtender>
                            </td>
                            <td width="18%" align="left">
                                To Date
                            </td>
                            <td width="32%" align="left">
                            <asp:TextBox ID="txttodate" runat="server" onkeyup="javascript:Adddob1();" />
                                <asp:TextBox ID="txtDateOfIssue" runat="server" Visible="false" />
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" FirstDayOfWeek="Sunday"
                                    Format="yyyy-MM-dd" TargetControlID="txttodate" PopupButtonID="ImageButton1">
                                </ajax:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%" align="left">
                                User Name
                            </td>
                            <td width="35%" align="left">
                                <asp:TextBox ID="txtName" runat="server" CssClass="Textbox" />
                            </td>
                                    <td width="18%" align="left">
                                Ref No
                            </td>
                            <td width="32%" align="left">
                                <asp:TextBox ID="txtRefNo" runat="server" CssClass="Textbox" />
                            </td>
                          <%--  <td width="18%" align="left">
                                Email Id
                            </td>--%>
                            <%--<td width="32%" align="left">--%>
                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="Textbox" Visible="false" />
                          <%--  </td>--%>
                        </tr>
                        <tr id="source1" runat="server" visible="false">
                            <td width="15%" align="left">
                                Contact No
                            </td>
                            <td width="35%" align="left">
                                <asp:TextBox ID="txtContact" runat="server" CssClass="Textbox" />
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789"
                                    TargetControlID="txtContact">
                                </ajax:FilteredTextBoxExtender>
                            </td>
                            <td width="18%" align="left">
                                Status
                            </td>
                            <td width="32%" align="left">
                                <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                    style="display: none" class="modalContainer">
                                    <div class="registerhead">
                                        <img src="../../images/loading.gif" width="150" height="150" alt="Loading" />
                                    </div>
                                </span>
                                <asp:DropDownList ID="ddlStatus" runat="server" Width="85px">
                                    <asp:ListItem Selected="True">ALL</asp:ListItem>
                                    <asp:ListItem>Booked</asp:ListItem>
                                    <asp:ListItem>Cancelled</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr >
                            <td width="15%" align="left">
                                Page Size
                            </td>
                            <td width="35%" align="left">
                                <asp:DropDownList ID="ddlPageSize" runat="server" Width="85px">
                                    
                                    <asp:ListItem Selected="True">100</asp:ListItem>
                                    <asp:ListItem>200</asp:ListItem>
                                    <asp:ListItem>300</asp:ListItem>
                                    <asp:ListItem>400</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="18%" align="left">
                                &nbsp;
                            </td>
                            <td width="32%" align="left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="15%" align="left">
                                &nbsp;
                            </td>
                            <td width="35%" align="left">
                                &nbsp;
                            </td>
                            <td width="18%" align="left">
                                <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="buttonBook"
                                     Style="cursor: pointer;" onclick="btnSearch_Click" />
                                &nbsp;
                                <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="buttonBook"
                                    Style="cursor: pointer;" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td width="32%" align="left">
                                <asp:Button ID="btnExport" runat="server"  Text="Export To Excel" CssClass="buttonBook"
                                    Style="cursor: pointer;" onclick="btnExport_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Panel ID="pnlSearchResults" runat="server" ScrollBars="Horizontal" Width="100%">
                    <table width="100%" style="table-layout: fixed;">
                        <tr>
                            <td width="100%">
                                <asp:GridView ID="gvBookings" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                    Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3" EnableModelValidation="True" EmptyDataText="No Data Found" AllowPaging="True"
                                    PageSize="100"  ShowFooter="true" onrowcommand="gvBookings_RowCommand" 
                                    onrowediting="gvBookings_RowEditing" 
                                    onrowdatabound="gvBookings_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="BookingId" Visible="false" SortExpression="BookingId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookingId" Text='<%# Eval("PassengerId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ref No" SortExpression="ReferenceNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManaBusRefNo" Text='<%# Eval("ReferanceId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City" SortExpression="HotelCity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCity" Text='<%# Eval("City_Car") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Car Name " SortExpression="HotelName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" Text='<%# Eval("CarName") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Travel Date" SortExpression="CheckInDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTravelDate" Text='<%# Eval("TravelDate") %>' runat="server" /><br />
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirstName" Text='<%# Eval("Name") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EmailId <br/> MobileNo" SortExpression="EmailId">
                                            <ItemTemplate>
                                                <asp:Label ID="lbLEmailId" Text='<%# Eval("EmailId") %>' runat="server" />
                                                <br />
                                                <asp:Label ID="lblMobileNumber" Text='<%# Eval("MobileNo") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Fare" SortExpression="HotelTotalFare">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActualFare" Text='<%# Eval("BasicFare") %>' runat="server" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblActualFareTotal" ForeColor="Red" runat="server" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserName" Text='<%# Eval("AgentName") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Booking Date & Time" SortExpression="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbookingtime" Text='<%# Eval("CreatedDate") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCBStatus" Text='<%# Eval("Status") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" Text="View" runat="server" CssClass="buttonBook"
                                                    CommandName="View" CommandArgument='<%# Eval("ReferanceId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px"
                                        HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <RowStyle ForeColor="#000066" Height="25px" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="25px"
                                        HorizontalAlign="Center" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                                        Height="25px" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
                <td style="background-color:White;">
                    <asp:Panel ID="pnlViewTicket" runat="server" Visible="False">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <table width="100%" align="center">
                        <tr>
                             <td width="503" align="left">
                                        <span class="actions">
                                            <asp:LinkButton ID="lbtnback" Text="Back" runat="server" 
                                                OnClientClick="showDiv();" onclick="lbtnback_Click" /></span>
                                    </td>
                            <td width="50%" align="right">
                                <span>

                                    <asp:LinkButton ID="lbtnMail" Text="Mail" runat="server" onclick="lbtnMail_Click" 
                                     />&nbsp;&nbsp;|&nbsp;&nbsp;
                                    <a onclick="printPage('printdiv');" target="_blank">
                                                <input id="Radio1" type="radio" runat="server" />Print </a>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="pnlTicket" runat="server">
                        
                            <table border="1" cellspacing="0" rules="all" style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td width="100%">
                            <div id="printdiv">
                                <table width="900" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" width="300" height="96" valign="top">
                                            <img alt="imag" src="http://Lovejourney.in/Newimages/New_Logo.png" width="243" height="88"
                                                border="0" title="LJ" />&nbsp;&nbsp;
                                        </td>
                                        <td align="right">
                                            <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="40" align="left">
                                                        <img src="http://www.lovejourney.in/images/call.jpg" width="30" height="30" />
                                                    </td>
                                                    <td align="left">
                                                        <b>(080) 32 56 17 27</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="40" align="left">
                                                        <img src="http://www.lovejourney.in/images/messenge.jpg" width="30" height="30" />
                                                    </td>
                                                    <td align="left">
                                                        <a href="#">info@lovejourney.in</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0px">
                                    <tr>
                                        <td width="100%">
                                            <hr />
                                            <strong>Lovejourney Ref No: </strong>
                                            <asp:Label ID="lblCarRefNo" runat="server" Text=""></asp:Label>
                                          
                                            &nbsp;&nbsp;&nbsp;&nbsp;<strong>Status: </strong>
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                            <br />
                                            <hr />
                                            <strong><span style="color: Red;">Car Details</span></strong>
                                            <table width="100%" id="SelectedHotel" border="0px">
                                                <thead>
                                                    <tr>
                                                        <td width="20%">
                                                            <strong>Car Name</strong>
                                                        </td>
                                                         <td width="20%">
                                                            <strong>Pickup Time</strong>
                                                        </td>
                                                        <td width="20%">
                                                            <strong>Address</strong>
                                                        </td>
                                                        <td width="10%">
                                                            <strong>City</strong>
                                                        </td>
                                                        <td width="10%">
                                                            <strong>Journey Date</strong>
                                                        </td>
                                                      
                                                       
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="20%">
                                                        <asp:Label ID="lblCarName" runat="server" Text=""></asp:Label>
                                                    </td>
                                                     <td width="20%">
                                                        <asp:Label ID="lblPickupTime" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblCity1" runat="server" Text=""></asp:Label>
                                                    </td>
                                                     <td width="20%">
                                                        <asp:Label ID="lblJourneyDate" runat="server" Text=""></asp:Label>
                                                    </td>
                                                   
                                                 
                                                </tr>
                                               
                                            </table>
                                            <hr />
                                            
                                            <hr />
                                            <strong><span style="color: Red;">User Details</span></strong>
                                            <table width="100%" id="UserDetails" border="0px">
                                               
                                                <tr>
                                                    <td width="15%" valign="top">
                                                      Name:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                   
                                                    <td width="15%" valign="top">
                                                        Mobile Number:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        91<asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        Email Id:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        &nbsp;
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        Address:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblAdd" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        City:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        State:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblState" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        PinCode:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblPinCode" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            <hr />
                                            <br />
                                            
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                 </div>
                            </td>
                        </tr>
                    </table>
                       
                    </asp:Panel>
                </asp:Panel>
                </td>
            </tr>


        
    </table></asp:Panel>
</asp:Content>

