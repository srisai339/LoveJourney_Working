<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Hotel/MasterPage.master"
    AutoEventWireup="true" CodeFile="AgentBookings.aspx.cs" Inherits="Users_Hotel_AgentBookings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlMain" runat="server">
        <table width="100%" style="table-layout: fixed;" bgcolor="#ffffff">
            <tr>
                <td width="100%" align="center" class="heading">
                    <asp:Label ID="Label1" runat="server" Text="Agent Hotel Bookings" Font-Size="13px"></asp:Label>
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
                            <tr id="source2" runat="server" visible="false">
                                <td width="15%" align="left">
                                    Hotel City
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
                                    <asp:TextBox ID="txtManabusRefNo" runat="server" CssClass="Textbox" />
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="left">
                                    From Date
                                </td>
                                <td width="35%" align="left">
                                    <asp:TextBox ID="txtfromdate" runat="server" onkeyup="javascript:Adddob();" CssClass="lj_inp" />
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                        Format="yyyy-MM-dd" TargetControlID="txtfromdate" PopupButtonID="ImageButton2">
                                    </ajax:CalendarExtender>
                                </td>
                                <td width="18%" align="left">
                                    To Date
                                </td>
                                <td width="32%" align="left">
                                    <asp:TextBox ID="txttodate" runat="server" onkeyup="javascript:Adddob1();"  CssClass="lj_inp"/>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" FirstDayOfWeek="Sunday"
                                        Format="yyyy-MM-dd" TargetControlID="txttodate" PopupButtonID="ImageButton1">
                                    </ajax:CalendarExtender>
                                </td>
                            </tr>
                            <tr id="date" runat="server" visible="false">
                                <td width="15%" align="left">
                                    CheckIn Date
                                </td>
                                <td width="35%" align="left">
                                    <asp:TextBox ID="txtDOJ" runat="server" />
                                    <%--          <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                    Format="yyyy-MM-dd" TargetControlID="txtDOJ" PopupButtonID="ImageButton2">
                                </ajax:CalendarExtender>--%>
                                </td>
                                <td width="18%" align="left">
                                    CheckOut Date
                                </td>
                                <td width="32%" align="left">
                                    <asp:TextBox ID="txtDateOfIssue" runat="server" />
                                    <%--     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" FirstDayOfWeek="Sunday"
                                    Format="yyyy-MM-dd" TargetControlID="txtDateOfIssue" PopupButtonID="ImageButton1">
                                </ajax:CalendarExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="left">
                                    User Name
                                </td>
                                <td width="35%" align="left">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="lj_inp" />
                                    <ajax:AutoCompleteExtender ID="txtFrom_AutoCompleteExtender" runat="server" TargetControlID="txtName"
                                        ServiceMethod="GetAgentNames" MinimumPrefixLength="1" CompletionInterval="10"
                                        CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                        ServicePath="">
                                    </ajax:AutoCompleteExtender>
                                    <asp:DropDownList ID="ddlagent1" runat="server" Visible="false">
                                    </asp:DropDownList>
                                </td>
                                <td width="18%" align="left">
                                    Reference No
                                </td>
                                <td width="32%" align="left">
                                    <asp:TextBox ID="txtreferenceno" runat="server"   CssClass="lj_inp"/>
                                </td>
                            </tr>
                            <tr id="source" runat="server" visible="false">
                                <td width="15%" align="left">
                                    <%--  Agent UserName--%>
                                </td>
                                <td width="35%" align="left">
                                    <%--   <asp:TextBox ID="txtName" runat="server" CssClass="Textbox" />--%>
                                </td>
                                <td width="18%" align="left">
                                    Email Id
                                </td>
                                <td width="32%" align="left">
                                    <asp:TextBox ID="txtEmailID" runat="server" CssClass="Textbox" />
                                </td>
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
                            <tr>
                                <td width="15%" align="left">
                                    Page Size
                                </td>
                                <td width="35%" align="left">
                                    <asp:DropDownList ID="ddlPageSize" runat="server" Width="85px" CssClass="lj_inp">
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
                                    <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="buttonBook" OnClick="btnSearch_Click"
                                        Style="cursor: pointer;"/>
                                    &nbsp;
                                    <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="buttonBook" OnClick="btnReset_Click"
                                        Style="cursor: pointer;"/>
                                    &nbsp;
                                </td>
                                <td width="32%" align="left">
                                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel"
                                        CssClass="buttonBook" Style="cursor: pointer;" />
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
                                        PageSize="20" OnPageIndexChanging="gvBookings_PageIndexChanging" OnRowCommand="gvBookings_RowCommand"
                                        OnRowDataBound="gvBookings_RowDataBound" OnSorting="gvBookings_Sorting" ShowFooter="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="BookingId" Visible="false" SortExpression="BookingId">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBookingId" Text='<%# Eval("BookingId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ref No" SortExpression="ReferenceNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManaBusRefNo" Text='<%# Eval("ReferenceNo") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hotel City" SortExpression="HotelCity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTravel" Text='<%# Eval("HotelCity") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="HotelName " SortExpression="HotelName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHotelName" Text='<%# Eval("HotelName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CheckInDate <br/> CheckOutDate" SortExpression="CheckInDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCheckInDate" Text='<%# Eval("CheckInDate") %>' runat="server" /><br />
                                                    <asp:Label ID="lblCheckOutDate" Text='<%# Eval("CheckOutDate") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="CheckOutDate" SortExpression="CheckOutDate">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EmailId <br/> MobileNo" SortExpression="EmailId">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbLEmailId" Text='<%# Eval("EmailId") %>' runat="server" />
                                                    <br />
                                                    <asp:Label ID="lblMobileNumber" Text='<%# Eval("MobileNumber") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="MobileNumber" SortExpression="MobileNumber">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Total Fare" SortExpression="ActualFare">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActualFare" Text='<%# Eval("ActualFare") %>' runat="server" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblActualFareTotal" ForeColor="Red" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LJ Fare" SortExpression="MBFare" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMBFare" Text='<%# Eval("MBFare") %>' runat="server" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblMBFareTotal" ForeColor="Red" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Com (Rs)" SortExpression="CommisionFare" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommisionFare" Text='<%# Eval("CommisionFare") %>' runat="server" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblCommisionFareTotal" ForeColor="Red" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Com (%)" SortExpression="CommisionPercentage" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommisionPercentage" Text='<%# Eval("CommisionPercentage") %>'
                                                        runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Refund Amt" SortExpression="RefundAmount" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRefundAmount" Text='<%# Eval("RefundAmount") %>' runat="server" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblRefundAmountTotal" ForeColor="Red" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cancel Charge" SortExpression="CancellationCharges"
                                                Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCancellationCharges" Text='<%# Eval("CancellationCharges") %>'
                                                        runat="server" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblCancellationChargesTotal" ForeColor="Red" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MarkUp" SortExpression="Comment" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMarkUp" Text='<%# Eval("Comment") %>' runat="server" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblMarkUpTotal" ForeColor="Red" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Closing Bal" SortExpression="ClosingBalance" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClosingBalance" Text='<%# Eval("ClosingBalance") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Booking Date & Time" SortExpression="BookingTime">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBookingTime" Text='<%# Eval("BookingTime") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserName" Text='<%# Eval("UserName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCBStatus" Text='<%# Eval("Status") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" Text="View" runat="server" CssClass="buttonBook" CommandName="View"
                                                        CommandArgument='<%# Eval("ReferenceNo") %>' />
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
                <td width="100%">
                    <asp:Panel ID="pnlViewTicket" runat="server" Visible="False">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <table width="100%" align="center">
                            <tr>
                                <td width="50%" align="left">
                                    <asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click">Back</asp:LinkButton>
                                </td>
                                <td width="50%" align="right">
                                    <span>
                                        <asp:LinkButton ID="lbtnMail" Text="Mail" runat="server" OnClick="lbtnMail_Click" />&nbsp;&nbsp;|&nbsp;&nbsp;
                                        <a onclick="printPage('printdiv');" target="_blank">Print</a></span>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Panel ID="pnlTicket" runat="server">
                        <div id="printdiv">
                            <table border="1" cellspacing="0" rules="all" style="width: 100%; border-collapse: collapse;">
                                <tr>
                                    <td width="100%">
                                        <table width="900" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="left" width="300" height="96" valign="top">
                                                    <img alt="imag" src="http://www.lovejourney.in/images/logo.gif" width="143" height="88"
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
                                                    <asp:Label ID="lblHotelRefNo" runat="server" Text=""></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; <strong>Ref No: </strong>
                                                    <asp:Label ID="lblarzoorefno" runat="server" Text=""></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<strong>Status: </strong>
                                                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <hr />
                                                    <strong><span style="color: Red;">Hotel Details</span></strong>
                                                    <table width="100%" id="SelectedHotel" border="0px">
                                                        <thead>
                                                            <tr>
                                                                <td width="20%">
                                                                    <strong>Hotel Name</strong>
                                                                </td>
                                                                <td width="20%">
                                                                    <strong>Address</strong>
                                                                </td>
                                                                <td width="10%">
                                                                    <strong>City</strong>
                                                                </td>
                                                                <td width="10%">
                                                                    <strong>Check-in</strong>
                                                                </td>
                                                                <td width="10%">
                                                                    <strong>Check-out</strong>
                                                                </td>
                                                                <td width="20%">
                                                                    <strong>Room Type</strong>
                                                                </td>
                                                                <td width="10%">
                                                                    <strong>Category</strong>
                                                                </td>
                                                            </tr>
                                                        </thead>
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblHotelName" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:Label ID="lblHotelCity" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:Label ID="lblCheckIn" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:Label ID="lblCheckOut" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:Label ID="lblRoomType" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:Label ID="lblStar" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong><span>Hotel Contact Details: </span></strong>
                                                                <asp:Label ID="lblHotelContactDetails" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <hr />
                                                    <table width="100%" id="TravellerDetails" border="0px">
                                                        <tr>
                                                            <td width="100%" colspan="4">
                                                                <strong><span style="color: Red;">Traveller Details</span> </strong>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td width="40%">
                                                                <strong>No. of Room(s): </strong>
                                                                <asp:Label ID="lblNoOfRooms" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="15%">
                                                                <strong>Pax > 12 yrs.: </strong>
                                                                <asp:Label ID="lblPaxGreaterThan12" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="15%">
                                                                <strong>Pax <= 12 yrs.: </strong>
                                                                <asp:Label ID="lblPaxLessThan12" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td width="30%" align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" colspan="4">
                                                                <strong>Total INR:</strong>
                                                                <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" colspan="4">
                                                                <strong><span>Booked Date: </span></strong>
                                                                <asp:Label ID="lblBookedDate" runat="server" Text=""></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <hr />
                                                    <strong><span style="color: Red;">User Details</span></strong>
                                                    <table width="100%" id="UserDetails" border="0px">
                                                        <tr>
                                                            <td width="15%" valign="top">
                                                                Title:
                                                            </td>
                                                            <td width="85%" valign="top" colspan="3">
                                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="15%" valign="top">
                                                                First Name:
                                                            </td>
                                                            <td width="35%" valign="top">
                                                                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="15%" valign="top">
                                                                Middle Name:
                                                            </td>
                                                            <td width="35%" valign="top">
                                                                <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="15%" valign="top">
                                                                Last Name:
                                                            </td>
                                                            <td width="35%" valign="top">
                                                                <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                                            </td>
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
                                                    <asp:GridView ID="gvPolicy" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        HeaderStyle-ForeColor="Red" Visible="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Hotel Policy" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPolicyText" runat="server" Text='<%# Eval("policyText") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <hr />
                                                    <br />
                                                    <div>
                                                        <table id="ctl00_ContentPlaceHolder1_gvPolicy" border="1" cellspacing="0" rules="all"
                                                            style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <th align="left" scope="col" style="color: Red;">
                                                                    Policy
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl06_lblPolicyText">You must be 18 to
                                                                        check in to this hotel.</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl07_lblPolicyText">Your credit card is
                                                                        charged the total cost above at time of purchase. Prices and room availability are
                                                                        not guaranteed until full payment is received.</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl08_lblPolicyText">Failure to check into
                                                                        the hotel, will attract the full cost of stay at the hotel being charged to your
                                                                        credit card.</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl09_lblPolicyText">Changes or cancellation
                                                                        may result in fees from INR 0 up to full cost of your stay as per rules</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl10_lblPolicyText">All hotels charge
                                                                        a compulsory Gala Dinner Supplement for the Christmas eve and New Year&#39;s eve
                                                                        on the stay during respective periods. Besides, other special supplements may be
                                                                        applicable during festival periods such as Diwali, Dusshera etc.</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl11_lblPolicyText">The charge for the
                                                                        same as applicable at the hotel would have to be cleared directly at the hotel.</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl12_lblPolicyText">We shall not be responsible
                                                                        for any such additional charges levied by the hotel other than the room charges.</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
