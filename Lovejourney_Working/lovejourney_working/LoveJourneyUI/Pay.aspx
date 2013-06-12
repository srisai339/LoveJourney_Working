<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>E-Billing Solutions Pvt Ltd - Payment Page</title>
 
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" language="javascript">
        function fnClick() {
            if (document.getElementById("chkAgree").checked == false) {
                alert("Pleae Agree To  Terms & Conditions");
                return false;
            }
            else {
                return true;
            }

        }

    
    </script>
    <%-- <style type="text/css">
        h1
        {
            font-family: Arial,sans-serif;
            font-size: 24pt;
            color: #08185A;
            font-weight: 100;
            margin-bottom: 0.1em;
        }
        h2.co
        {
            font-family: Arial,sans-serif;
            font-size: 24pt;
            color: #FFFFFF;
            margin-top: 0.1em;
            margin-bottom: 0.1em;
            font-weight: 100;
        }
        h3.co
        {
            font-family: Arial,sans-serif;
            font-size: 16pt;
            color: #000000;
            margin-top: 0.1em;
            margin-bottom: 0.1em;
            font-weight: 100;
        }
        h3
        {
            font-family: Arial,sans-serif;
            font-size: 16pt;
            color: #08185A;
            margin-top: 0.1em;
            margin-bottom: 0.1em;
            font-weight: 100;
        }
        body
        {
            font-family: Verdana,Arial,sans-serif;
            font-size: 11px;
            color: #08185A;
        }
        th
        {
            font-size: 12px;
            background: #015289;
            color: #FFFFFF;
            font-weight: bold;
            height: 30px;
        }
        td
        {
            font-size: 12px;
            background: #DDE8F3;
        }
        .pageTitle
        {
            font-size: 24px;
        }
    </style>
    --%>
</head>
<body>
    <form runat="server" name="frmTransaction" id="frmTransaction">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <%-- <div>--%>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center" valign="top">
                <table width="900" border="0" cellspacing="0" cellpadding="0" bgcolor="" class="header">
                    <tr>
                        <td align="center" valign="top">
                            <!--header-->
                            <table width="1004" border="0" cellspacing="0" cellpadding="0" height="117">
                                <tr>
                                    <td align="left" width="285" valign="top">
                                        <a href="Default.aspx" title="Logo">
                                            <img src="images/logo.gif" width="285" height="117" alt="Logo" title="Logo" /></a>
                                    </td>
                                    <td valign="top" align="right">
                                        <table width="700" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="right" height="42" valign="middle">
                                                    <table width="600" border="0" cellspacing="0" cellpadding="0" height="42">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                                <td align="right" height="24" class="pmenu">
                                                    <!--menu-->
                                                    <div id="chromemenu" class="chromestyle">
                                                        <ul>
                                                        </ul>
                                                    </div>
                                                    <script type="text/javascript">

                                                        cssdropdown.startchrome("chromemenu")

                                                    </script>
                                                    <!--menuEnd-->
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" align="center" colspan="4" class="mbl">
                                        Payment
                                    </td>
                                </tr>
                              
                            </table>
                        </td>
                    </tr>
                    <!--headerend-->
                    <tr>
                        <td valign="top" class="master_content1" align="center" bgcolor="#ffffff">
                            <table cellpadding="0" cellspacing="0" border="0" width="400" height="400" align="center">
                                <tr>
                                    <td valign="top" align="center">
                                        <table cellspacing="0" cellpadding="0" border="0" width="400">
                                            <tr>
                                                <td align="left" height="40">
                                                    <asp:Label ID="lblRechargNumber" runat="server" Text="Recharge Amount " ForeColor="Black"
                                                        Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="center" width="20">
                                                    :
                                                </td>
                                                <td align="center" height="40">
                                                    <asp:TextBox ID="txtRechargeamount" runat="server" Width="150px" CssClass="i2s_jp_seats"
                                                        Height="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                             <tr id="trprovidername" runat="server">
                                                <td align="left" height="40">
                                                    <asp:Label ID="lblprovidername" runat="server" Text="Provider Name" ForeColor="Black"
                                                        Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="center" width="20">
                                                    :
                                                </td>
                                                <td align="center" height="40">
                                                    <asp:TextBox ID="txtprovidername" runat="server" Width="150px" CssClass="i2s_jp_seats"
                                                        Height="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                            <td align="left" height="40">
                                                                <asp:Label ID="Label1" runat="server" Text="Provider Name "></asp:Label>
                                                            </td>
                                                            <td align="center" width="20">
                                                                :
                                                            </td>
                                                            <td align="center" height="40">
                                                                <asp:TextBox ID="TextBox1" runat="server" Width="150px" CssClass="i2s_jp_seats" Height="20"></asp:TextBox>
                                                            </td>
                                                        </tr>--%>
                                           
                                            <tr id="trmobilenumber" runat="server">
                                                <td align="left" height="40">
                                                    <asp:Label ID="Label2" runat="server" Text="Mobile Number " Height="20" ForeColor="Black"
                                                        Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="center" width="20">
                                                    :
                                                </td>
                                                <td align="center" height="40">
                                                    <asp:TextBox ID="TextBox2" runat="server" Width="150px" CssClass="i2s_jp_seats" Height="20"
                                                        Font-Bold="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="40" align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="Email ID :" ForeColor="Black" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="center" width="20">
                                                    :
                                                </td>
                                                <td height="40" align="center">
                                                    <asp:TextBox ID="TextBox3" runat="server" Width="150px" CssClass="i2s_jp_seats" Height="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" height="40">
                                                    <asp:CheckBox ID="chkAgree" runat="server" Text="" Font-Bold="true" ForeColor="Black" />
                                                    I agree to The
                                                    <%-- <asp:LinkButton ID="lnktermscond" runat="Server" Text="Terms&Conditions" PostBackUrl="~/TermsandConditions.aspx" />--%>
                                                    <%--<asp:HyperLink ID="hltermcond" runat="server" Text="Terms & Conditions" NavigateUrl="~/TermsandConditions.aspx" />--%>
                                                    <%--<asp:HyperLink ID="hltermcond" runat="server" Text="Terms & Conditions" NavigateUrl="~/TermsandConditions.aspx" />--%>
                                                    <asp:LinkButton ID="hltermconds" Style="color: Black;" runat="server" Text="Terms and Conditions "
                                                        OnClick="hltermconds_Click"></asp:LinkButton>of LoveJourney
                                                    <%--  <asp:RequiredFieldValidator ID="refagree" runat="server" ControlToValidate="chkAgree"
                                                                    ErrorMessage="Please Check" ValidationGroup="agree"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <%--<input id="Submit1" type="submit" value="PROCEED" runat="server" class="i2s_jp_status5"
                                                                    onclick="javascript:return fnClick();" validationgroup="Agree" />--%>
                                                    <asp:Button ID="btnproceed" runat="server" Text="Proceed" 
                                                        CssClass="i2s_jp_status4" OnClientClick="javascript:return fnClick();" />
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
                            <!--advertisements-->
                            
                            <!--advertisementsEnd-->
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" width="600" cellpadding="2" cellspacing="2" border="0" style="visibility: collapse">
                                <tr>
                                    <td class="fieldName" width="50%">
                                        Account Id
                                    </td>
                                    <td align="left" width="50%">
                                        <input name="account_id" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="2">
                                        Transaction Details
                                    </th>
                                </tr>
                                <tr>
                                    <td class="fieldName" width="50%">
                                        Reference No
                                    </td>
                                    <td align="left" width="50%">
                                        <input name="reference_no" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName" width="50%">
                                        Sale Amount
                                    </td>
                                    <td align="left" width="50%">
                                        <input name="amount" type="text" value="" />INR
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName" width="50%">
                                        Description
                                    </td>
                                    <td align="left" width="50%">
                                        <input name="description" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="2">
                                        Billing Address
                                    </th>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span> Name
                                    </td>
                                    <td align="left">
                                        <input name="name" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>Address
                                    </td>
                                    <td align="left">
                                        <input name="address" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>City
                                    </td>
                                    <td align="left">
                                        <input name="city" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        State/Province
                                    </td>
                                    <td align="left">
                                        <input name="state" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>ZIP/Postal Code
                                    </td>
                                    <td align="left">
                                        <input name="postal_code" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>Country
                                    </td>
                                    <td align="left">
                                        <select name="country" id="country" runat="server">
                                            <option value=""></option>
                                            <option value="ABW">Aruba</option>
                                            <option value="AFG">Afghanistan</option>
                                            <option value="AGO">Angola</option>
                                            <option value="AIA">Anguilla</option>
                                            <option value="ALA">Åland Islands</option>
                                            <option value="ALB">Albania</option>
                                            <option value="AND">Andorra</option>
                                            <option value="ANT">Netherlands Antilles</option>
                                            <option value="ARE">United Arab Emirates</option>
                                            <option value="ARG">Argentina</option>
                                            <option value="ARM">Armenia</option>
                                            <option value="ASM">American Samoa</option>
                                            <option value="ATA">Antarctica</option>
                                            <option value="ATF">French Southern Territories</option>
                                            <option value="ATG">Antigua and Barbuda</option>
                                            <option value="AUS">Australia</option>
                                            <option value="AUT">Austria</option>
                                            <option value="AZE">Azerbaijan</option>
                                            <option value="BDI">Burundi</option>
                                            <option value="BEL">Belgium</option>
                                            <option value="BEN">Benin</option>
                                            <option value="BFA">Burkina Faso</option>
                                            <option value="BGD">Bangladesh</option>
                                            <option value="BGR">Bulgaria</option>
                                            <option value="BHR">Bahrain</option>
                                            <option value="BHS">Bahamas</option>
                                            <option value="BIH">Bosnia and Herzegovina</option>
                                            <option value="BLM">Saint Barthélemy</option>
                                            <option value="BLR">Belarus</option>
                                            <option value="BLZ">Belize</option>
                                            <option value="BMU">Bermuda</option>
                                            <option value="BOL">Bolivia</option>
                                            <option value="BRA">Brazil</option>
                                            <option value="BRB">Barbados</option>
                                            <option value="BRN">Brunei Darussalam</option>
                                            <option value="BTN">Bhutan</option>
                                            <option value="BVT">Bouvet Island</option>
                                            <option value="BWA">Botswana</option>
                                            <option value="CAF">Central African Republic</option>
                                            <option value="CAN">Canada</option>
                                            <option value="CCK">Cocos (Keeling) Islands</option>
                                            <option value="CHE">Switzerland</option>
                                            <option value="CHL">Chile</option>
                                            <option value="CHN">China</option>
                                            <option value="CIV">Côte d`Ivoire</option>
                                            <option value="CMR">Cameroon</option>
                                            <option value="COD">Congo, the Democratic Republic of the</option>
                                            <option value="COG">Congo</option>
                                            <option value="COK">Cook Islands</option>
                                            <option value="COL">Colombia</option>
                                            <option value="COM">Comoros</option>
                                            <option value="CPV">Cape Verde</option>
                                            <option value="CRI">Costa Rica</option>
                                            <option value="CUB">Cuba</option>
                                            <option value="CXR">Christmas Island</option>
                                            <option value="CYM">Cayman Islands</option>
                                            <option value="CYP">Cyprus</option>
                                            <option value="CZE">Czech Republic</option>
                                            <option value="DEU">Germany</option>
                                            <option value="DJI">Djibouti</option>
                                            <option value="DMA">Dominica</option>
                                            <option value="DNK">Denmark</option>
                                            <option value="DOM">Dominican Republic</option>
                                            <option value="DZA">Algeria</option>
                                            <option value="ECU">Ecuador</option>
                                            <option value="EGY">Egypt</option>
                                            <option value="ERI">Eritrea</option>
                                            <option value="ESH">Western Sahara</option>
                                            <option value="ESP">Spain</option>
                                            <option value="EST">Estonia</option>
                                            <option value="ETH">Ethiopia</option>
                                            <option value="FIN">Finland</option>
                                            <option value="FJI">Fiji</option>
                                            <option value="FLK">Falkland Islands (Malvinas)</option>
                                            <option value="FRA">France</option>
                                            <option value="FRO">Faroe Islands</option>
                                            <option value="FSM">Micronesia, Federated States of</option>
                                            <option value="GAB">Gabon</option>
                                            <option value="GBR">United Kingdom</option>
                                            <option value="GEO">Georgia</option>
                                            <option value="GGY">Guernsey</option>
                                            <option value="GHA">Ghana</option>
                                            <option value="GI">N Guinea</option>
                                            <option value="GIB">Gibraltar</option>
                                            <option value="GLP">Guadeloupe</option>
                                            <option value="GMB">Gambia</option>
                                            <option value="GNB">Guinea-Bissau</option>
                                            <option value="GNQ">Equatorial Guinea</option>
                                            <option value="GRC">Greece</option>
                                            <option value="GRD">Grenada</option>
                                            <option value="GRL">Greenland</option>
                                            <option value="GTM">Guatemala</option>
                                            <option value="GUF">French Guiana</option>
                                            <option value="GUM">Guam</option>
                                            <option value="GUY">Guyana</option>
                                            <option value="HKG">Hong Kong</option>
                                            <option value="HMD">Heard Island and McDonald Islands</option>
                                            <option value="HND">Honduras</option>
                                            <option value="HRV">Croatia</option>
                                            <option value="HTI">Haiti</option>
                                            <option value="HUN">Hungary</option>
                                            <option value="IDN">Indonesia</option>
                                            <option value="IMN">Isle of Man</option>
                                            <option value="IND" selected="selected">India</option>
                                            <option value="IOT">British Indian Ocean Territory</option>
                                            <option value="IRL">Ireland</option>
                                            <option value="IRN">Iran, Islamic Republic of</option>
                                            <option value="IRQ">Iraq</option>
                                            <option value="ISL">Iceland</option>
                                            <option value="ISR">Israel</option>
                                            <option value="ITA">Italy</option>
                                            <option value="JAM">Jamaica</option>
                                            <option value="JEY">Jersey</option>
                                            <option value="JOR">Jordan</option>
                                            <option value="JPN">Japan</option>
                                            <option value="KAZ">Kazakhstan</option>
                                            <option value="KEN">Kenya</option>
                                            <option value="KGZ">Kyrgyzstan</option>
                                            <option value="KHM">Cambodia</option>
                                            <option value="KIR">Kiribati</option>
                                            <option value="KNA">Saint Kitts and Nevis</option>
                                            <option value="KOR">Korea, Republic of</option>
                                            <option value="KWT">Kuwait</option>
                                            <option value="LAO">Lao People`s Democratic Republic</option>
                                            <option value="LBN">Lebanon</option>
                                            <option value="LBR">Liberia</option>
                                            <option value="LBY">Libyan Arab Jamahiriya</option>
                                            <option value="LCA">Saint Lucia</option>
                                            <option value="LIE">Liechtenstein</option>
                                            <option value="LKA">Sri Lanka</option>
                                            <option value="LSO">Lesotho</option>
                                            <option value="LTU">Lithuania</option>
                                            <option value="LUX">Luxembourg</option>
                                            <option value="LVA">Latvia</option>
                                            <option value="MAC">Macao</option>
                                            <option value="MAF">Saint Martin (French part)</option>
                                            <option value="MAR">Morocco</option>
                                            <option value="MCO">Monaco</option>
                                            <option value="MDA">Moldova</option>
                                            <option value="MDG">Madagascar</option>
                                            <option value="MDV">Maldives</option>
                                            <option value="MEX">Mexico</option>
                                            <option value="MHL">Marshall Islands</option>
                                            <option value="MKD">Macedonia, the former Yugoslav Republic of</option>
                                            <option value="MLI">Mali</option>
                                            <option value="MLT">Malta</option>
                                            <option value="MMR">Myanmar</option>
                                            <option value="MNE">Montenegro</option>
                                            <option value="MNG">Mongolia</option>
                                            <option value="MNP">Northern Mariana Islands</option>
                                            <option value="MOZ">Mozambique</option>
                                            <option value="MRT">Mauritania</option>
                                            <option value="MSR">Montserrat</option>
                                            <option value="MTQ">Martinique</option>
                                            <option value="MUS">Mauritius</option>
                                            <option value="MWI">Malawi</option>
                                            <option value="MYS">Malaysia</option>
                                            <option value="MYT">Mayotte</option>
                                            <option value="NAM">Namibia</option>
                                            <option value="NCL">New Caledonia</option>
                                            <option value="NER">Niger</option>
                                            <option value="NFK">Norfolk Island</option>
                                            <option value="NGA">Nigeria</option>
                                            <option value="NIC">Nicaragua</option>
                                            <option value="NO">R Norway</option>
                                            <option value="NIU">Niue</option>
                                            <option value="NLD">Netherlands</option>
                                            <option value="NPL">Nepal</option>
                                            <option value="NRU">Nauru</option>
                                            <option value="NZL">New Zealand</option>
                                            <option value="OMN">Oman</option>
                                            <option value="PAK">Pakistan</option>
                                            <option value="PAN">Panama</option>
                                            <option value="PCN">Pitcairn</option>
                                            <option value="PER">Peru</option>
                                            <option value="PHL">Philippines</option>
                                            <option value="PLW">Palau</option>
                                            <option value="PNG">Papua New Guinea</option>
                                            <option value="POL">Poland</option>
                                            <option value="PRI">Puerto Rico</option>
                                            <option value="PRK">Korea, Democratic People`s Republic of</option>
                                            <option value="PRT">Portugal</option>
                                            <option value="PRY">Paraguay</option>
                                            <option value="PSE">Palestinian Territory, Occupied</option>
                                            <option value="PYF">French Polynesia</option>
                                            <option value="QAT">Qatar</option>
                                            <option value="REU">Réunion</option>
                                            <option value="ROU">Romania</option>
                                            <option value="RUS">Russian Federation</option>
                                            <option value="RWA">Rwanda</option>
                                            <option value="SAU">Saudi Arabia</option>
                                            <option value="SDN">Sudan</option>
                                            <option value="SEN">Senegal</option>
                                            <option value="SGP">Singapore</option>
                                            <option value="SGS">South Georgia and the South Sandwich Islands</option>
                                            <option value="SHN">Saint Helena</option>
                                            <option value="SJM">Svalbard and Jan Mayen</option>
                                            <option value="SLB">Solomon Islands</option>
                                            <option value="SLE">Sierra Leone</option>
                                            <option value="SLV">El Salvador</option>
                                            <option value="SMR">San Marino</option>
                                            <option value="SOM">Somalia</option>
                                            <option value="SPM">Saint Pierre and Miquelon</option>
                                            <option value="SRB">Serbia</option>
                                            <option value="STP">Sao Tome and Principe</option>
                                            <option value="SUR">Suriname</option>
                                            <option value="SVK">Slovakia</option>
                                            <option value="SVN">Slovenia</option>
                                            <option value="SWE">Sweden</option>
                                            <option value="SWZ">Swaziland</option>
                                            <option value="SYC">Seychelles</option>
                                            <option value="SYR">Syrian Arab Republic</option>
                                            <option value="TCA">Turks and Caicos Islands</option>
                                            <option value="TCD">Chad</option>
                                            <option value="TGO">Togo</option>
                                            <option value="THA">Thailand</option>
                                            <option value="TJK">Tajikistan</option>
                                            <option value="TKL">Tokelau</option>
                                            <option value="TKM">Turkmenistan</option>
                                            <option value="TLS">Timor-Leste</option>
                                            <option value="TON">Tonga</option>
                                            <option value="TTO">Trinidad and Tobago</option>
                                            <option value="TUN">Tunisia</option>
                                            <option value="TUR">Turkey</option>
                                            <option value="TUV">Tuvalu</option>
                                            <option value="TWN">Taiwan, Province of China</option>
                                            <option value="TZA">Tanzania, United Republic of</option>
                                            <option value="UGA">Uganda</option>
                                            <option value="UKR">Ukraine</option>
                                            <option value="UMI">United States Minor Outlying Islands</option>
                                            <option value="URY">Uruguay</option>
                                            <option value="USA">United States</option>
                                            <option value="UZB">Uzbekistan</option>
                                            <option value="VAT">Holy See (Vatican City State)</option>
                                            <option value="VCT">Saint Vincent and the Grenadines</option>
                                            <option value="VEN">Venezuela</option>
                                            <option value="VGB">Virgin Islands, British</option>
                                            <option value="VIR">Virgin Islands, U.S.</option>
                                            <option value="VNM">Viet Nam</option>
                                            <option value="VUT">Vanuatu</option>
                                            <option value="WLF">Wallis and Futuna</option>
                                            <option value="WSM">Samoa</option>
                                            <option value="YEM">Yemen</option>
                                            <option value="ZAF">South Africa</option>
                                            <option value="ZMB">Zambia</option>
                                            <option value="ZWE">Zimbabwe</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>Email
                                    </td>
                                    <td align="left">
                                        <input name="email" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>Telephone
                                    </td>
                                    <td align="left">
                                        <input name="phone" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="2">
                                        Delivery Address
                                    </th>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span> Name
                                    </td>
                                    <td align="left">
                                        <input name="ship_name" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>Address
                                    </td>
                                    <td align="left">
                                        <input name="ship_address" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>City
                                    </td>
                                    <td align="left">
                                        <input name="ship_city" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        State/Province
                                    </td>
                                    <td align="left">
                                        <input name="ship_state" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>ZIP/Postal Code
                                    </td>
                                    <td align="left">
                                        <input name="ship_postal_code" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        <span class="error">*</span>Country
                                    </td>
                                    <td align="left">
                                        <select name="ship_country" runat="server" id="ship_country">
                                            <option value=""></option>
                                            <option value="ABW">Aruba</option>
                                            <option value="AFG">Afghanistan</option>
                                            <option value="AGO">Angola</option>
                                            <option value="AIA">Anguilla</option>
                                            <option value="ALA">Åland Islands</option>
                                            <option value="ALB">Albania</option>
                                            <option value="AND">Andorra</option>
                                            <option value="ANT">Netherlands Antilles</option>
                                            <option value="ARE">United Arab Emirates</option>
                                            <option value="ARG">Argentina</option>
                                            <option value="ARM">Armenia</option>
                                            <option value="ASM">American Samoa</option>
                                            <option value="ATA">Antarctica</option>
                                            <option value="ATF">French Southern Territories</option>
                                            <option value="ATG">Antigua and Barbuda</option>
                                            <option value="AUS">Australia</option>
                                            <option value="AUT">Austria</option>
                                            <option value="AZE">Azerbaijan</option>
                                            <option value="BDI">Burundi</option>
                                            <option value="BEL">Belgium</option>
                                            <option value="BEN">Benin</option>
                                            <option value="BFA">Burkina Faso</option>
                                            <option value="BGD">Bangladesh</option>
                                            <option value="BGR">Bulgaria</option>
                                            <option value="BHR">Bahrain</option>
                                            <option value="BHS">Bahamas</option>
                                            <option value="BIH">Bosnia and Herzegovina</option>
                                            <option value="BLM">Saint Barthélemy</option>
                                            <option value="BLR">Belarus</option>
                                            <option value="BLZ">Belize</option>
                                            <option value="BMU">Bermuda</option>
                                            <option value="BOL">Bolivia</option>
                                            <option value="BRA">Brazil</option>
                                            <option value="BRB">Barbados</option>
                                            <option value="BRN">Brunei Darussalam</option>
                                            <option value="BTN">Bhutan</option>
                                            <option value="BVT">Bouvet Island</option>
                                            <option value="BWA">Botswana</option>
                                            <option value="CAF">Central African Republic</option>
                                            <option value="CAN">Canada</option>
                                            <option value="CCK">Cocos (Keeling) Islands</option>
                                            <option value="CHE">Switzerland</option>
                                            <option value="CHL">Chile</option>
                                            <option value="CHN">China</option>
                                            <option value="CIV">Côte d`Ivoire</option>
                                            <option value="CMR">Cameroon</option>
                                            <option value="COD">Congo, the Democratic Republic of the</option>
                                            <option value="COG">Congo</option>
                                            <option value="COK">Cook Islands</option>
                                            <option value="COL">Colombia</option>
                                            <option value="COM">Comoros</option>
                                            <option value="CPV">Cape Verde</option>
                                            <option value="CRI">Costa Rica</option>
                                            <option value="CUB">Cuba</option>
                                            <option value="CXR">Christmas Island</option>
                                            <option value="CYM">Cayman Islands</option>
                                            <option value="CYP">Cyprus</option>
                                            <option value="CZE">Czech Republic</option>
                                            <option value="DEU">Germany</option>
                                            <option value="DJI">Djibouti</option>
                                            <option value="DMA">Dominica</option>
                                            <option value="DNK">Denmark</option>
                                            <option value="DOM">Dominican Republic</option>
                                            <option value="DZA">Algeria</option>
                                            <option value="ECU">Ecuador</option>
                                            <option value="EGY">Egypt</option>
                                            <option value="ERI">Eritrea</option>
                                            <option value="ESH">Western Sahara</option>
                                            <option value="ESP">Spain</option>
                                            <option value="EST">Estonia</option>
                                            <option value="ETH">Ethiopia</option>
                                            <option value="FIN">Finland</option>
                                            <option value="FJI">Fiji</option>
                                            <option value="FLK">Falkland Islands (Malvinas)</option>
                                            <option value="FRA">France</option>
                                            <option value="FRO">Faroe Islands</option>
                                            <option value="FSM">Micronesia, Federated States of</option>
                                            <option value="GAB">Gabon</option>
                                            <option value="GBR">United Kingdom</option>
                                            <option value="GEO">Georgia</option>
                                            <option value="GGY">Guernsey</option>
                                            <option value="GHA">Ghana</option>
                                            <option value="GI">N Guinea</option>
                                            <option value="GIB">Gibraltar</option>
                                            <option value="GLP">Guadeloupe</option>
                                            <option value="GMB">Gambia</option>
                                            <option value="GNB">Guinea-Bissau</option>
                                            <option value="GNQ">Equatorial Guinea</option>
                                            <option value="GRC">Greece</option>
                                            <option value="GRD">Grenada</option>
                                            <option value="GRL">Greenland</option>
                                            <option value="GTM">Guatemala</option>
                                            <option value="GUF">French Guiana</option>
                                            <option value="GUM">Guam</option>
                                            <option value="GUY">Guyana</option>
                                            <option value="HKG">Hong Kong</option>
                                            <option value="HMD">Heard Island and McDonald Islands</option>
                                            <option value="HND">Honduras</option>
                                            <option value="HRV">Croatia</option>
                                            <option value="HTI">Haiti</option>
                                            <option value="HUN">Hungary</option>
                                            <option value="IDN">Indonesia</option>
                                            <option value="IMN">Isle of Man</option>
                                            <option value="IND">India</option>
                                            <option value="IOT">British Indian Ocean Territory</option>
                                            <option value="IRL">Ireland</option>
                                            <option value="IRN">Iran, Islamic Republic of</option>
                                            <option value="IRQ">Iraq</option>
                                            <option value="ISL">Iceland</option>
                                            <option value="ISR">Israel</option>
                                            <option value="ITA">Italy</option>
                                            <option value="JAM">Jamaica</option>
                                            <option value="JEY">Jersey</option>
                                            <option value="JOR">Jordan</option>
                                            <option value="JPN">Japan</option>
                                            <option value="KAZ">Kazakhstan</option>
                                            <option value="KEN">Kenya</option>
                                            <option value="KGZ">Kyrgyzstan</option>
                                            <option value="KHM">Cambodia</option>
                                            <option value="KIR">Kiribati</option>
                                            <option value="KNA">Saint Kitts and Nevis</option>
                                            <option value="KOR">Korea, Republic of</option>
                                            <option value="KWT">Kuwait</option>
                                            <option value="LAO">Lao People`s Democratic Republic</option>
                                            <option value="LBN">Lebanon</option>
                                            <option value="LBR">Liberia</option>
                                            <option value="LBY">Libyan Arab Jamahiriya</option>
                                            <option value="LCA">Saint Lucia</option>
                                            <option value="LIE">Liechtenstein</option>
                                            <option value="LKA">Sri Lanka</option>
                                            <option value="LSO">Lesotho</option>
                                            <option value="LTU">Lithuania</option>
                                            <option value="LUX">Luxembourg</option>
                                            <option value="LVA">Latvia</option>
                                            <option value="MAC">Macao</option>
                                            <option value="MAF">Saint Martin (French part)</option>
                                            <option value="MAR">Morocco</option>
                                            <option value="MCO">Monaco</option>
                                            <option value="MDA">Moldova</option>
                                            <option value="MDG">Madagascar</option>
                                            <option value="MDV">Maldives</option>
                                            <option value="MEX">Mexico</option>
                                            <option value="MHL">Marshall Islands</option>
                                            <option value="MKD">Macedonia, the former Yugoslav Republic of</option>
                                            <option value="MLI">Mali</option>
                                            <option value="MLT">Malta</option>
                                            <option value="MMR">Myanmar</option>
                                            <option value="MNE">Montenegro</option>
                                            <option value="MNG">Mongolia</option>
                                            <option value="MNP">Northern Mariana Islands</option>
                                            <option value="MOZ">Mozambique</option>
                                            <option value="MRT">Mauritania</option>
                                            <option value="MSR">Montserrat</option>
                                            <option value="MTQ">Martinique</option>
                                            <option value="MUS">Mauritius</option>
                                            <option value="MWI">Malawi</option>
                                            <option value="MYS">Malaysia</option>
                                            <option value="MYT">Mayotte</option>
                                            <option value="NAM">Namibia</option>
                                            <option value="NCL">New Caledonia</option>
                                            <option value="NER">Niger</option>
                                            <option value="NFK">Norfolk Island</option>
                                            <option value="NGA">Nigeria</option>
                                            <option value="NIC">Nicaragua</option>
                                            <option value="NO">R Norway</option>
                                            <option value="NIU">Niue</option>
                                            <option value="NLD">Netherlands</option>
                                            <option value="NPL">Nepal</option>
                                            <option value="NRU">Nauru</option>
                                            <option value="NZL">New Zealand</option>
                                            <option value="OMN">Oman</option>
                                            <option value="PAK">Pakistan</option>
                                            <option value="PAN">Panama</option>
                                            <option value="PCN">Pitcairn</option>
                                            <option value="PER">Peru</option>
                                            <option value="PHL">Philippines</option>
                                            <option value="PLW">Palau</option>
                                            <option value="PNG">Papua New Guinea</option>
                                            <option value="POL">Poland</option>
                                            <option value="PRI">Puerto Rico</option>
                                            <option value="PRK">Korea, Democratic People`s Republic of</option>
                                            <option value="PRT">Portugal</option>
                                            <option value="PRY">Paraguay</option>
                                            <option value="PSE">Palestinian Territory, Occupied</option>
                                            <option value="PYF">French Polynesia</option>
                                            <option value="QAT">Qatar</option>
                                            <option value="REU">Réunion</option>
                                            <option value="ROU">Romania</option>
                                            <option value="RUS">Russian Federation</option>
                                            <option value="RWA">Rwanda</option>
                                            <option value="SAU">Saudi Arabia</option>
                                            <option value="SDN">Sudan</option>
                                            <option value="SEN">Senegal</option>
                                            <option value="SGP">Singapore</option>
                                            <option value="SGS">South Georgia and the South Sandwich Islands</option>
                                            <option value="SHN">Saint Helena</option>
                                            <option value="SJM">Svalbard and Jan Mayen</option>
                                            <option value="SLB">Solomon Islands</option>
                                            <option value="SLE">Sierra Leone</option>
                                            <option value="SLV">El Salvador</option>
                                            <option value="SMR">San Marino</option>
                                            <option value="SOM">Somalia</option>
                                            <option value="SPM">Saint Pierre and Miquelon</option>
                                            <option value="SRB">Serbia</option>
                                            <option value="STP">Sao Tome and Principe</option>
                                            <option value="SUR">Suriname</option>
                                            <option value="SVK">Slovakia</option>
                                            <option value="SVN">Slovenia</option>
                                            <option value="SWE">Sweden</option>
                                            <option value="SWZ">Swaziland</option>
                                            <option value="SYC">Seychelles</option>
                                            <option value="SYR">Syrian Arab Republic</option>
                                            <option value="TCA">Turks and Caicos Islands</option>
                                            <option value="TCD">Chad</option>
                                            <option value="TGO">Togo</option>
                                            <option value="THA">Thailand</option>
                                            <option value="TJK">Tajikistan</option>
                                            <option value="TKL">Tokelau</option>
                                            <option value="TKM">Turkmenistan</option>
                                            <option value="TLS">Timor-Leste</option>
                                            <option value="TON">Tonga</option>
                                            <option value="TTO">Trinidad and Tobago</option>
                                            <option value="TUN">Tunisia</option>
                                            <option value="TUR">Turkey</option>
                                            <option value="TUV">Tuvalu</option>
                                            <option value="TWN">Taiwan, Province of China</option>
                                            <option value="TZA">Tanzania, United Republic of</option>
                                            <option value="UGA">Uganda</option>
                                            <option value="UKR">Ukraine</option>
                                            <option value="UMI">United States Minor Outlying Islands</option>
                                            <option value="URY">Uruguay</option>
                                            <option value="USA">United States</option>
                                            <option value="UZB">Uzbekistan</option>
                                            <option value="VAT">Holy See (Vatican City State)</option>
                                            <option value="VCT">Saint Vincent and the Grenadines</option>
                                            <option value="VEN">Venezuela</option>
                                            <option value="VGB">Virgin Islands, British</option>
                                            <option value="VIR">Virgin Islands, U.S.</option>
                                            <option value="VNM">Viet Nam</option>
                                            <option value="VUT">Vanuatu</option>
                                            <option value="WLF">Wallis and Futuna</option>
                                            <option value="WSM">Samoa</option>
                                            <option value="YEM">Yemen</option>
                                            <option value="ZAF">South Africa</option>
                                            <option value="ZMB">Zambia</option>
                                            <option value="ZWE">Zimbabwe</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        Telephone
                                    </td>
                                    <td align="left">
                                        <input name="ship_phone" type="text" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        Return Url
                                    </td>
                                    <td align="left">
                                        <input name="return_url" type="text" size="60" value="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldName">
                                        Mode
                                    </td>
                                    <td align="left">
                                        <select id="mode" name="mode" runat="server">
                                            <option value="TEST"  >TEST</option>
                                            <option value="LIVE" selected="selected" >LIVE</option>
                                        </select>
                                    </td>
                                </tr>
                               
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlButton1" runat="server" Style="display: none">
        <asp:Button ID="Button1" runat="server" Text="OK" />
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MpeInsert" PopupControlID="pnlterms" runat="server"
        TargetControlID="Button1" BackgroundCssClass="modalBackground" CancelControlID="lnkok">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlterms" runat="server" align="center" CssClass="modalContainer"  Style="display: none; width: 800px; background-color: White;
        border: Solid 4px #3399ff;"
 
        ScrollBars="Auto">
        <table width="80%" align="center">
            <tr>
                <td align="center" width="80%">
                   <br />
                   
                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 700;
                            font-style: normal; text-decoration: underline;"> Terms and&nbsp; Conditions</span>
                        <p style="text-align: left;  padding-left: 0pt; padding-right: 0pt;
                            padding-top: 0pt; padding-bottom: 0pt;">
                            <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                font-style: normal; text-decoration: none;">1. LoveJourney Recharge* is ONLY a 
                            Mobile recharge agent. It does not operate Mobile services of its own. In order 
                            to provide a comprehensive </span>
                        </p>
                        <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                            padding-top: 0pt; padding-bottom: 0pt;">
                            &nbsp;&nbsp;&nbsp;
                            <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                font-style: normal; text-decoration: none;">choice of 
                            &nbsp;&nbsp;&nbsp;&nbsp;online&nbsp;recharge,DTH,DataCard it has tied up with many Mobile operators.<br /> 
                            &nbsp;&nbsp;&nbsp;&nbsp;LoveJourney advice to customers is to choose Mobile operators they are aware 
                            of and whose service they are comfortable with.</span></p>
                        <p style="text-align: left;  padding-left: 0pt; padding-right: 0pt;
                            padding-top: 0pt; padding-bottom: 0pt;">
                            &nbsp;</p>
                        <p style="text-align: left;  padding-left: 0pt; padding-right: 0pt;
                            padding-top: 0pt; padding-bottom: 0pt;">
                            <span style="font-family: Arial; color: #000000; font-size: 8pt; font-weight: 700;
                                font-style: normal; text-decoration: none;">LoveJourney Recharge' 
                            &nbsp;responsibilities include: </span>
                        </p>
                        <p style="text-align: left;  padding-left: 0pt; padding-right: 0pt;
                            padding-top: 0pt; padding-bottom: 0pt;">
                            &nbsp;</p>
                        <ul style="padding-left: 30px;">
                            <li style="text-align: left;  padding-left: 0pt; padding-right: 0pt;
                                padding-top: 0pt; padding-bottom: 0pt;"><span 
                                    style="font-family: Arial; color: #000000;
                                    font-size: 9pt; font-weight: 400; font-style: normal; text-decoration: none;">
                                Issuing a valid online recharge (a recharge that will be accepted by the mobile 
                                operator) for its' &nbsp;network of Mobile operators&nbsp;&nbsp; </span></li>
                            <li style="text-align: left;  padding-left: 0pt; padding-right: 0pt;
                                padding-top: 0pt; padding-bottom: 0pt;"><span 
                                    style="font-family: Arial; color: #000000;
                                    font-size: 9pt; font-weight: 400; font-style: normal; text-decoration: none;">
                                Providing refund and support in the event of cancellation</span></li>
                            <li style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                padding-top: 0pt; padding-bottom: 0pt;"><span 
                                    style="font-family: Arial; color: #000000;
                                    font-size: 9pt; font-weight: 400; font-style: normal; text-decoration: none;">
                                Providing customer support and information in case of any delays / inconvenience</span></li>
                            <br />
                        </ul>
                        <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                            padding-top: 0pt; padding-bottom: 0pt;">
                            <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                font-style: normal; text-decoration: none;">2.The time mentioned on the 
                            recharge are only tentative timings. gs. </span>
                        </p>
                        <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                            padding-top: 0pt; padding-bottom: 0pt;">
                            &nbsp;</p>
                        <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                            padding-top: 0pt; padding-bottom: 0pt;">
                            <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                font-style: normal; text-decoration: none;">3. Customers are required to 
                            furnish the following at the time of Mobile operators:<%--  A valid identity proof
                                                    <br />
                                                    Failing to do so, they may not be allowed to board the bus.</span></p>--%></span><p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                        padding-top: 0pt; padding-bottom: 0pt;">
                                &nbsp;<p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                            padding-top: 0pt; padding-bottom: 0pt;">
                                    <span style="font-family: Arial; color: #000000; font-size: 8pt; font-weight: 400;
                                                                font-style: normal; text-decoration: none;">
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                                                        font-style: normal; text-decoration: none;">4. 
                                        Change of Operator: In case the Mobile recharge operator changes the type of 
                                        operator due to some reason, LoveJourney will refund the</span></p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                                                        font-style: normal; text-decoration: none;">&nbsp;&nbsp;&nbsp; 
                                        differential amount to&nbsp;&nbsp;the customer upon being intimated by the customers in 24 
                                        hours of the journey.</span></p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        &nbsp;</p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                                                        font-style: normal; text-decoration: none;">5. 
                                        This recharge is not cancellable.</span></p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        &nbsp;</p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                                                        font-style: normal; text-decoration: none;">6. 
                                        In case one needs the refund to be credited back to his/her bank account, please 
                                        write your cash coupon details to <a href="mailto:info@lovejourney.in">
                                        info@lovejourney.in</a> </span>
                                    </p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        &nbsp;</p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                                                        font-style: normal; text-decoration: none;">7. 
                                        In case a online recharge confirmation e-mail and sms gets delayed or fails 
                                        because of technical reasons or as a result of incorrect </span>
                                    </p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                                                        font-style: normal; text-decoration: none;">
                                        &nbsp;&nbsp;&nbsp; e-mail ID / phone &nbsp;&nbsp;&nbsp;number provided by the user etc, a online recharge will 
                                        be considered 'recharge' as long as the recharge shows </span></p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                                                        font-style: normal; text-decoration: none;">up 
                                        on the confirmation page of <a href="http://www.lovejourney.in">www.lovejourney.in</a></span></p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        &nbsp;</p>
                                    <p style="text-align: left; textindent: 0pt; padding-left: 0pt; padding-right: 0pt;
                                                                    padding-top: 0pt; padding-bottom: 0pt;">
                                        <span style="font-family: Arial; color: #000000; font-size: 9pt; font-weight: 400;
                                                                        font-style: normal; text-decoration: none;">For 
                                        any queries call at : </span>
                                        <span style="font-family: Verdana; color: #000000; font-size: 10pt; font-weight: 700;
                                                                        font-style: normal; text-decoration: none;">
                                        0091-8008419101 / 0091-40-40209894</span></p>
                                    </span>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                </p>
                            </p>
                        </p>
                   
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="lnkok" runat="server" Text="OK" CssClass="i2s_jp_status4" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%-- </div>--%>
    </form>
    <script language="JavaScript" type="text/javascript">
        function validate() {

            var frm = document.forms[0];
            var optFields = Array('description[delivery_address_2]', 'description[delivery_state]', 'description[delivery_telephone]', 'description[delivery_fax]', 'description[billing_address_2]', 'description[billing_state]', 'description[billing_telephone]', 'description[billing_fax]');
            var aName = Array();
            aName['account_id'] = 'Account ID';
            aName['reference_no'] = 'Reference No';
            aName['description'] = 'Description';
            aName['name'] = 'First Name';
            aName['name_2'] = 'Last Name';
            aName['address'] = 'Address 1';
            aName['city'] = 'City';
            aName['state'] = 'State';
            aName['postal_code'] = 'Post Code';
            aName['country'] = 'Country';
            aName['email'] = 'Email';
            aName['phone'] = 'Phone';

            for (var i = 0; i < frm.elements.length; i++) {

                if (!optFields.inArray(frm.elements[i].name)) {
                    if (frm.elements[i].value.length == 0) {
                        alert("Invalid input for " + aName[frm.elements[i].name]);
                        frm.elements[i].focus();
                        return false;
                    }

                    if (frm.elements[i].name == 'email]') {
                        if (!validateEmail(frm.elements[i].value)) {
                            alert("Invalid input for " + aName[frm.elements[i].name]);
                            frm.elements[i].focus();
                            return false;
                        }
                    }
                    if (frm.elements[i].name == 'reference_no]') {
                        var d = new Date();
                        frm.elements[i].value = d.getTime();
                    }
                }
            }
            return true;
        }

        function validateEmail(email) {
            //Validating the email field
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            //"
            if (!email.match(re)) {
                return (false);
            }
            return (true);
        }


        Array.prototype.inArray = function (value)
        // Returns true if the passed value is found in the
        // array.  Returns false if it is not.
        {
            var i;
            for (i = 0; i < this.length; i++) {
                // Matches identical (===), not just similar (==).
                if (this[i] === value) {
                    return true;
                }
            }
            return false;
        };

        function submitted_onclick() {

        }

        function submitted1_onclick() {

        }

        function submitted1_onclick() {

        }

    </script>
</body>
</html>
