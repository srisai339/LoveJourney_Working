<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RDefault.aspx.cs" Inherits="RDefault" MasterPageFile="~/MasterPage.master"   %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Online mobile recharge,DTH recharge online,DATA CARD recharge online available</title>
   
    <meta name="description" content="LoveJourney offers Online mobile recharge,DTH recharge online,DATA CARD recharge services.Get attractive discounts and great deals on mobile/dth/data card recharge services through online." />
    <meta name="keywords" content="Online mobile recharge,DTH recharge online,DATA CARD recharge online,mobile recharge,airtel online mobile recharge,easy mobile recharge,tata docomo online recharge,online recharge,idea online recharge,bsnl online recharge,recharge,airtel online recharge,recharge it now,mobile recharge online,recharge online,airtel digital tv recharge online,dth recharge,dish tv recharge online,airtel dish tv,airtel digital,airtel dish tv recharge online,mts data card recharge,bsnl data card,data card,mts data card,data card plans,bsnl data card plans,tata photon data card plans" />
    <meta name="author" content="lovejourney.in" />
    <meta name="robots" content="index, follow" />
    <link href="css/r_styles.css" type="text/css" rel="stylesheet" />
    <!--tabsStart-->
    <link rel="stylesheet" href="css/jquery.ui.all.css" />
    <script src="js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="js/jquery.ui.core.js" type="text/javascript"></script>
    <script src="js/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="js/jquery.ui.tabs.js" type="text/javascript"></script>
    <link href="css/abcd-home.css" rel="stylesheet" type="text/css" /> 
    <link href="css/NewStyle.css" rel="stylesheet" type="text/css" />

    <link href="css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="http://jquery.malsup.com/block/jquery.blockUI.js?v2.38" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs({
                event: "click"/*click*/
            });
        });
    </script>
    <!--menu-->
    <!--menuEnd-->
    <script type="text/javascript" language="javascript">
        function showDiv() {
            Page_ClientValidate("btnnext");
            if (Page_ClientValidate("btnnext")) {
                document.getElementById('SignupMain').style.display = "";
                document.getElementById('SignUpContent').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "images/loader2.gif"', 200);
            }
            else
                return false;
        }
    </script>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <%--</head>
<body>
    <form id="formrecharge" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>--%>
    <table border="0" cellpadding="0" cellspacing="0">
     <tr>
            <td width="100%" height="30px" valign="middle" align="center" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
   <table width="964" border="0" cellpadding="0" cellspacing="0"  id="tdmob" runat="server">   
                     <tr>
                        <td height="18">
                        </td>
                    </tr>

                    <tr>
                        <td align="left">
                          
        <table width="400" border="0"  cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="images/formtop_left.png" /></td>
    <td class="form_top" width="395">&nbsp;</td>
    <td align="left" valign="bottom" width="29" height="23"><img src="images/formright_top.png" /></td>
  </tr>
  <tr>
    <td class="form_left">&nbsp;</td>
    <td align="left">
                            <!--contentTabs-->
                            <table width="347" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <!--CLEFT-->
                                    <td width="350" align="left" bgcolor="#ffffff"  >
                                        <!--tabsTart-->
                                        <div id="tabs" style="background:#ffffff; border:none;">
                                            <ul id="ul">
                                                <li><a href="#tabs-1">
                                                    <img src="images/mobile.jpg" width="70" height="70"></a></li>
                                                <li><a href="#tabs-2">
                                                    <img src="images/dth.jpg" width="70" height="70"></a></li>
                                                <li><a href="#tabs-3">
                                                    <img src="images/datacard.jpg" width="70" height="70"></a></li>
                                            </ul>
                                            <div id="tabs-1" style="background-color:White;">
                                                <!--tab1-->
                                                  <asp:UpdatePanel ID="up1" runat="server">
                                                <ContentTemplate>
                                                <table width="350" border="0" cellspacing="0" cellpadding="0" >
                                                    <tr>
                                                        <td align="left" height="30" >
                                                        <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                          Name
                                                        </td>
                                                        <td width="50%" align="left">
                                                        <asp:TextBox ID="txtGuestname" class="lj_inp1" runat="server">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txtGuestname">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvtxtGuestname" runat="server" ControlToValidate="txtGuestname"
                                                                ValidationGroup="submit" ErrorMessage="Please enter your name" Display="None"></asp:RequiredFieldValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server"
                                                                TargetControlID="rfvtxtGuestname" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                        </td>
                                                        </tr>
                                                        </table>
                                                          
                                                        </td>
                                                       
                                                    </tr>
                                                  <%--  <tr>
                                                 
                                                        <td align="left">
                                                          
                                                        </td>
                                                    </tr>--%>
                                                    <tr > 
                                                        <td align="left" height="40">
                                                          <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Mobile Operator
                                                            </td>
                                                            <td width="50%" align="left">
                                                             <asp:DropDownList ID="ddlProvider" class="lj_inp1" runat="server" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlProvider_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server"
                                                                TargetControlID="rfvprovider" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="rfvprovider" runat="server" ControlToValidate="ddlProvider" InitialValue="Please Select" Display="None" ErrorMessage="Please Select Operator Name"
                                                                ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="cmpProvider" runat="server" ControlToValidate="ddlProvider"
                                                                ValueToCompare="--Select Operator--" ErrorMessage="Please Select Operator" Display="None"
                                                                ValidationGroup="submit" Type="String" Operator="NotEqual"></asp:CompareValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="VCEprovider1" runat="server" TargetControlID="cmpProvider"
                                                                WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                  <%--  <tr>
                                                        <td align="left">
                                                           
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="35">
                                                          <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Mobile Number
                                                        </td>
                                                          <td width="50%" align="left">
                                                            <asp:TextBox ID="txtMobile" onkeypress="return isNumberEvt(event)" class="lj_inp1" runat="server"
                                                                ValidationGroup="submit" MaxLength="10">
                                                            </asp:TextBox><ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender15"
                                                                runat="server" TargetControlID="RequiredFieldValidator8" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                ValidChars="1234567890." TargetControlID="txtMobile">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMobile"
                                                                ValidationGroup="submit" ErrorMessage="Please enter mobile number" Display="None"></asp:RequiredFieldValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server"
                                                                TargetControlID="RegularExpressionValidator2" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                                                                ValidationGroup="submit" ErrorMessage="Please enter valid mobile number" Display="None"
                                                                ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                                                        </td>
                                                        </tr>
                                                        </table>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td align="left">
                                                           
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="30">
                                                         <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Email ID
                                                            </td>
                                                              <td width="50%" align="left">
                                                         <asp:TextBox ID="txtEmailMobile" runat="server" class="lj_inp1" ValidationGroup="submit"
                                                                MaxLength="100"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender37"
                                                                    runat="server" TargetControlID="rfvEmailMobile" WarningIconImageUrl="~/images/warning.png"
                                                                    CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="rfvEmailMobile" runat="server" ControlToValidate="txtEmailMobile"
                                                                ValidationGroup="submit" ErrorMessage="Please enter email" Display="None"></asp:RequiredFieldValidator><ajaxToolkit:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender39" runat="server" TargetControlID="revEmailMobile"
                                                                    WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="revEmailMobile" runat="server" ControlToValidate="txtEmailMobile"
                                                                ValidationGroup="submit" ErrorMessage="Please enter valid email <br/> format is abc@cba.com"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                  <%--  <tr>
                                                        <td align="left">
                                                           
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="30">
                                                           <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Address
                                                            </td>
                                                              <td width="50%" align="left">
                                                          <asp:TextBox ID="txtmobileguestaddress" class="lj_inp1" runat="server" TextMode="MultiLine">
                                                            </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtmobileguestaddress" runat="server" ControlToValidate="txtmobileguestaddress"
                                                                ValidationGroup="submit" ErrorMessage="Please enter address" Display="None"></asp:RequiredFieldValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtmobileguestaddress" runat="server"
                                                                TargetControlID="rfvtxtmobileguestaddress" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                 <%--   <tr>
                                                        <td align="left">
                                                            
                                                        </td>
                                                    </tr>--%>
                                                    <%--<tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                            <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" width="15%"  style="font-weight:bold;color:Black;">
                                                                        City
                                                                    </td>
                                                                    <td width="50%" align="left" valign="middle">
                                                                        <asp:TextBox ID="txtMobileCity" class="lj_inp1" runat="server" >
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txtMobileCity">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtMobileCity" runat="server" ControlToValidate="txtMobileCity"
                                                                            ValidationGroup="submit" ErrorMessage="Please enter  city name" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtMobileCity" runat="server" TargetControlID="rfvtxtMobileCity"
                                                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                    </td>
                                                                    
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" height="30">
                                                           <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                           State
                                                            </td>
                                                              <td width="50%" align="left">
                                                          <asp:TextBox ID="txtMobileState" class="lj_inp1" runat="server" >
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txtMobileState">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtMobileState" runat="server" ControlToValidate="txtMobileState"
                                                                            ValidationGroup="submit" ErrorMessage="Please enter  state name" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtMobileState" runat="server" TargetControlID="rfvtxtMobileState"
                                                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" height="40" width="15%" style="font-weight:bold;color:Black;">
                                                                        Country
                                                                    </td>
                                                                    <td width="50%" align="left" valign="middle">
                                                                        <asp:DropDownList ID="ddlmobileguestscountry" runat="server" class="lj_inp1" ValidationGroup="submit"
                                                                            >
                                                                            <asp:ListItem Value="Please Select">Please Select</asp:ListItem>
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
                                                                            <asp:ListItem Value="IND">India</asp:ListItem>
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
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender40" runat="server"
                                                                            TargetControlID="rfvddlmobileguestscountry" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvddlmobileguestscountry" runat="server" ControlToValidate="ddlmobileguestscountry"
                                                                            ErrorMessage="Please select Country" Display="None" ForeColor="Red" Font-Size="11px"
                                                                            InitialValue="Please Select" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" height="30">
                                                           <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                           Postal Code
                                                            </td>
                                                              <td width="50%" align="left">
                                                                 <asp:TextBox ID="txtMobilePostalCode" class="lj_inp1" runat="server"  MaxLength="6">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftebtxtMobilePostalCode" runat="server"
                                                                            ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtMobilePostalCode">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtMobilePostalCode" runat="server" ControlToValidate="txtMobilePostalCode"
                                                                            ValidationGroup="submit" ErrorMessage="Please enter your postal code" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtMobilePostalCode" runat="server"
                                                                            TargetControlID="rfvtxtMobilePostalCode" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                                        Amount
                                                                    </td>
                                                                    <td width="50%" align="left" >
                                                                        <asp:DropDownList ID="ddlrechargeamount" class="lj_inp1" runat="server" ValidationGroup="submit"
                                                                            Width="150px">
                                                                            <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                                            TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlrechargeamount"
                                                                            InitialValue="0" ValidationGroup="submit" ErrorMessage="Please select Recharge Amount"
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vceddlrechargeamount" runat="server" CloseImageUrl="~/images/Closing.png"
                                                                            TargetControlID="CompareValidator4" WarningIconImageUrl="~/images/warning.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlrechargeamount"
                                                                            Display="None" ErrorMessage="Please select Recharge Amount" Operator="NotEqual"
                                                                            Type="Integer" ValidationGroup="submit" ValueToCompare="0"></asp:CompareValidator>
                                                                    </td>
                                                                   

                                                                </tr>
                                                                <tr>
                                                                  <td colspan="2" align="center" height="40" >
                                                                   <asp:Button ID="btnMobileRecharge" runat="server" CssClass="buttonBook" Text="Proceed" ValidationGroup="submit"
                                                                            CausesValidation="true" OnClick="btnMobileRecharge_Click" />
                                                                  </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="center">
                                                                        <asp:Label ID="lblRequestID" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblOrderID" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblTime" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="center">
                                                                        <asp:Label ID="lblBalance" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                  </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <!--tab1End-->
                                            </div>

                                            <div id="tabs-2" style="background-color:White;">
                                                <!--tab2-->
                                                <asp:UpdatePanel ID="up2" runat="server">
                                                <ContentTemplate>
                                              
                                                <table width="450" border="0" cellspacing="0" cellpadding="0" >
                                                    <tr>
                                                        <td align="left" height="30">
                                                         <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Name
                                                            </td>
                                                              <td width="50%" align="left">
                                                           <asp:TextBox ID="txtGusetdthname" class="lj_inp1" runat="server">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txtGusetdthname">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvtxtGusetdthname" runat="server" ControlToValidate="txtGusetdthname"
                                                                ValidationGroup="D2H" ErrorMessage="Please enter your name" Display="None"></asp:RequiredFieldValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtGusetdthname" runat="server" TargetControlID="rfvtxtGusetdthname"
                                                                WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td align="left">
                                                         
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                          <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            DTH Operator
                                                            </td>
                                                               <td width="50%" align="left">
                                                          <asp:DropDownList ID="ddlD2HProvider" runat="server" class="lj_inp1" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlD2HProvider_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server"
                                                                TargetControlID="rfvddld2h" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="rfvddld2h" runat="server" Display="None" ControlToValidate="ddlD2HProvider" InitialValue="Please Select"
                                                                ValidationGroup="D2H" ErrorMessage="Please select service Provider"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlD2HProvider"
                                                                ValueToCompare="--Select Operator--" ErrorMessage="Please Select Operator" Display="None"
                                                                ValidationGroup="D2H" Type="String" Operator="NotEqual"></asp:CompareValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" runat="server"
                                                                TargetControlID="CompareValidator1" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td align="left">
                                                         
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="35">
                                                            <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Email ID
                                                            </td>
                                                             <td width="50%" align="left">
                                                           <asp:TextBox ID="txtEmailD2H" runat="server" class="lj_inp1" MaxLength="50"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender
                                                                ID="ValidatorCalloutExtender44" runat="server" TargetControlID="rfvEmailD2H"
                                                                WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="rfvEmailD2H" runat="server" ControlToValidate="txtEmailD2H"
                                                                ValidationGroup="D2H" ErrorMessage="Please enter email" Display="None"></asp:RequiredFieldValidator><ajaxToolkit:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender45" runat="server" TargetControlID="revEmailD2H"
                                                                    WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="revEmailD2H" runat="server" ControlToValidate="txtEmailD2H"
                                                                ValidationGroup="D2H" ErrorMessage="Please enter valid email <br/> format is abc@cba.com"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                 <%--   <tr>
                                                        <td align="left" height="30">
                                                           
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="30">
                                                           <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Subscriber ID
                                                            </td>
                                                             <td width="50%" align="left">
                                                             <asp:TextBox ID="txtCustID" runat="server" class="lj_inp1" onkeypress="return isNumberEvt(event)"
                                                                MaxLength="12"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender10"
                                                                    runat="server" TargetControlID="rfvCustID" WarningIconImageUrl="~/images/warning.png"
                                                                    CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server"
                                                                TargetControlID="rfvCustID1" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="rfvCustID" runat="server" ControlToValidate="txtCustID"
                                                                ValidationGroup="D2H" ErrorMessage="Please enter Customer ID" Display="None"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                    ID="rfvCustID1" runat="server" ControlToValidate="txtCustID" ValidationGroup="D2H"
                                                                    ErrorMessage="Please enter valid Customer ID" Display="None" ValidationExpression="[0-9]{10,12}"></asp:RegularExpressionValidator>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td align="left">
                                                          
                                                         
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                         <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Address
                                                            </td>
                                                              <td width="50%" align="left">
                                                          <asp:TextBox ID="txtdthguestaddress" class="lj_inp1" runat="server" TextMode="MultiLine">
                                                            </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtdthguestaddress" runat="server" ControlToValidate="txtdthguestaddress"
                                                                ValidationGroup="D2H" ErrorMessage="Please enter address" Display="None"></asp:RequiredFieldValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtdthguestaddress" runat="server"
                                                                TargetControlID="rfvtxtdthguestaddress" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td align="left">
                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" height="40" width="15%" style="font-weight:bold;color:Black;">
                                                                        City
                                                                    </td>
                                                                    <td width="50%" align="left" valign="middle">
                                                                        <asp:TextBox ID="txtDTHCity" class="lj_inp1" runat="server"  >
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txtDTHCity">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtDTHCity" runat="server" ControlToValidate="txtDTHCity"
                                                                            ValidationGroup="D2H" ErrorMessage="Please enter city name" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtDTHCity" runat="server" TargetControlID="rfvtxtDTHCity"
                                                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                    </td>
                                                                   
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left" height="30">
                                                         <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                          State
                                                            </td>
                                                              <td width="50%" align="left">
                                                         <asp:TextBox ID="txtDTHState" class="lj_inp1" runat="server"  >
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txtDTHState">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtDTHState" runat="server" ControlToValidate="txtDTHState"
                                                                            ValidationGroup="D2H" ErrorMessage="Please enter state name" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtDTHState" runat="server" TargetControlID="rfvtxtDTHState"
                                                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                   <%-- <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" height="40" width="15%" style="font-weight:bold;color:Black;">
                                                                        Country
                                                                    </td>
                                                                    <td width="50%" align="left" valign="middle">
                                                                        <asp:DropDownList ID="ddlDTHguestscountry" runat="server" class="lj_inp1" ValidationGroup="D2H"
                                                                             >
                                                                            <asp:ListItem Value="Please Select">Please Select</asp:ListItem>
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
                                                                            <asp:ListItem Value="IND">India</asp:ListItem>
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
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender41" runat="server"
                                                                            TargetControlID="rfvddlDTHguestscountry" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvddlDTHguestscountry" runat="server" ControlToValidate="ddlDTHguestscountry"
                                                                            ErrorMessage="Please select Country" Display="None" ForeColor="Red" Font-Size="11px"
                                                                            InitialValue="Please Select" ValidationGroup="D2H"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                   
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left" height="30">
                                                         <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                        Postal Code
                                                            </td>
                                                              <td width="50%" align="left">
                                                        <asp:TextBox ID="txtPostalCodeDTH" class="lj_inp1" runat="server" 
                                                                            MaxLength="6">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbetxtPostalCodeDTH" runat="server" ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                                                            TargetControlID="txtPostalCodeDTH">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtPostalCodeDTH" runat="server" ControlToValidate="txtPostalCodeDTH"
                                                                            ValidationGroup="D2H" ErrorMessage="Please enter postal code" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtPostalCodeDTH" runat="server"
                                                                            TargetControlID="rfvtxtPostalCodeDTH" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                                        Amount
                                                                    </td>
                                                                    <td width="50%" align="left">
                                                                        <asp:DropDownList ID="ddlD2HAmount" runat="server" class="lj_inp1" Width="150px">
                                                                            <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                                                            TargetControlID="RequiredFieldValidator2" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlD2HAmount"
                                                                            ValidationGroup="D2H" ErrorMessage="Please select recharge Amount" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender36" runat="server"
                                                                            PopupPosition="Left" CloseImageUrl="~/images/Closing.png" TargetControlID="CompareValidator2"
                                                                            WarningIconImageUrl="~/images/warning.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlD2HAmount"
                                                                            Display="None" ErrorMessage="Please select Recharge Amount" Operator="NotEqual"
                                                                            Type="Integer" ValidationGroup="D2H" ValueToCompare="0"></asp:CompareValidator>
                                                                      
                                                                    </td>
                                                                    
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr><td colspan="2" align="center" height="40" ><asp:Button ID="btnD2HRecharge" runat="server" ValidationGroup="D2H" CssClass="buttonBook"
                                                                            Text="Proceed" OnClick="btnD2HRecharge_Click" CausesValidation="true" /></td></tr>
                                                                           
                                                </table>
                                                
                                                  </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <!--tab2End-->
                                            </div>
                                            <div id="tabs-3"  style="background-color:White;">
                                              <asp:UpdatePanel ID="up3" runat="server">
                                                <ContentTemplate>
                                                <table width="450" border="0" cellspacing="0" cellpadding="0" >
                                                    <tr>
                                                        <td align="left" height="30">
                                                          <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Name
                                                            </td>
                                                              <td width="50%" align="left">
                                                          <asp:TextBox ID="txtdcguestname" class="lj_inp1" runat="server">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txtdcguestname">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvtxtdcguestname" runat="server" ControlToValidate="txtdcguestname"
                                                                ValidationGroup="submit123" ErrorMessage="Please enter your name" Display="None"></asp:RequiredFieldValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtdcguestname" runat="server" TargetControlID="rfvtxtdcguestname"
                                                                WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td align="left">
                                                          
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                        <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Mobile Operator
                                                            </td>
                                                              <td width="50%" align="left">
                                                             <asp:DropDownList ID="ddlNetConnect" class="lj_inp1" runat="server" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlNetConnect_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="server"
                                                                TargetControlID="RequiredFieldValidator7" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlNetConnect" InitialValue="Please Select"
                                                                ValidationGroup="Submit123"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="cvddlNetConnect" runat="server" ControlToValidate="ddlNetConnect"
                                                                ValueToCompare="--Select Operator--" ErrorMessage="Please Select Operator" Display="None"
                                                                ValidationGroup="submit123" Type="String" Operator="NotEqual"></asp:CompareValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender34" runat="server"
                                                                TargetControlID="cvddlNetConnect" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                  <%--  <tr>
                                                        <td align="left">

                                                         
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="35">
                                                          <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Mobile Number
                                                            </td>
                                                                <td width="50%" align="left">
                                                          <asp:TextBox ID="TextBox123" onkeypress="return isNumberEvt(event)" class="lj_inp1" runat="server"
                                                                ValidationGroup="submit123" MaxLength="10">
                                                            </asp:TextBox><ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender20"
                                                                runat="server" TargetControlID="RequiredFieldValidator6" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server"
                                                                TargetControlID="RegularExpressionValidator4" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox123"
                                                                ValidationGroup="submit123" ErrorMessage="Please enter mobile number" Display="None"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                    ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMobile"
                                                                    ValidationGroup="submit123" ErrorMessage="Please enter valid mobile number" Display="None"
                                                                    ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                                ValidChars="1234567890." TargetControlID="TextBox123">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender35" runat="server"
                                                                TargetControlID="RegularExpressionValidator8" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBox123"
                                                                ValidationGroup="submit123" ErrorMessage="Please enter valid mobile number" Display="None"
                                                                ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                  <%--  <tr>
                                                        <td align="left">
                                                          
                                                          
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="30">
                                                          <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Email ID
                                                            </td>
                                                              <td width="50%" align="left">
                                                       <asp:TextBox ID="txtEmailnet" runat="server" class="lj_inp1" ValidationGroup="submit"
                                                                MaxLength="100"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender26"
                                                                    runat="server" TargetControlID="RequiredFieldValidator10" WarningIconImageUrl="~/images/warning.png"
                                                                    CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmailnet"
                                                                ValidationGroup="submit123" ErrorMessage="Please enter email" Display="None"></asp:RequiredFieldValidator><ajaxToolkit:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender27" runat="server" TargetControlID="RegularExpressionValidator6"
                                                                    WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtEmailnet"
                                                                ValidationGroup="submit123" ErrorMessage="Please enter valid email <br/> format is abc@cba.com"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                  <%--  <tr>
                                                        <td align="left" height="30">
                                                            
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                           <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                            Address
                                                            </td>
                                                              <td width="50%" align="left">
                                                           <asp:TextBox ID="txtdcguestadddress" class="lj_inp1" runat="server" TextMode="MultiLine">
                                                            </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtdcguestadddress" runat="server" ControlToValidate="txtdcguestadddress"
                                                                ValidationGroup="submit123" ErrorMessage="Please enter address" Display="None"></asp:RequiredFieldValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtdcguestadddress" runat="server"
                                                                TargetControlID="rfvtxtdcguestadddress" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left">
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" height="40" width="15%" style="font-weight:bold;color:Black;" >
                                                                        City
                                                                    </td>
                                                                    <td width="50%" align="left" valign="middle" >
                                                                        <asp:TextBox ID="txtDataCardCity" class="lj_inp1" runat="server" >
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbetxtDataCardCity" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
                                                                            TargetControlID="txtDataCardCity">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtDataCardCity" runat="server" ControlToValidate="txtDataCardCity"
                                                                            ValidationGroup="submit123" ErrorMessage="Please enter city name" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtDataCardCity" runat="server" TargetControlID="rfvtxtDataCardCity"
                                                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                    </td>
                                                                    
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" height="30">
                                                           <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                          State
                                                            </td>
                                                              <td width="50%" align="left">
                                                          <asp:TextBox ID="txtdatacardState" runat="server" class="lj_inp1">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTBEtxtdatacardState" runat="server" TargetControlID="txtdatacardState"
                                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtdatacardState" runat="server" ControlToValidate="txtdatacardState"
                                                                            Display="None" ErrorMessage="Please enter state name" ValidationGroup="submit123"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtdatacardState" runat="server"
                                                                            CloseImageUrl="~/images/Closing.png" TargetControlID="rfvtxtdatacardState" WarningIconImageUrl="~/images/warning.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" height="40">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" height="40" width="15%" style="font-weight:bold;color:Black;">
                                                                        Country
                                                                    </td>
                                                                    <td width="50%" align="left" valign="middle">
                                                                        <asp:DropDownList ID="ddlDatacardcountry" runat="server" class="lj_inp1" ValidationGroup="submit123"
                                                                             >
                                                                            <asp:ListItem Value="Please Select">Please Select</asp:ListItem>
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
                                                                            <asp:ListItem Value="IND">India</asp:ListItem>
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
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender42" runat="server"
                                                                            TargetControlID="rfvddlDatacardcountry" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvddlDatacardcountry" runat="server" ControlToValidate="ddlDatacardcountry"
                                                                            ErrorMessage="Please select Country" Display="None" ForeColor="Red" Font-Size="11px"
                                                                            InitialValue="Please Select" ValidationGroup="submit123"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" height="30">
                                                           <table width="100%">
                                                        <tr>
                                                        <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                          Postal Code
                                                            </td>
                                                              <td width="50%" align="left">
                                                        <asp:TextBox ID="txtDataCardPostalCode" class="lj_inp1" runat="server" 
                                                                            MaxLength="6">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbetxtDataCardPostalCode" runat="server"
                                                                            ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtDataCardPostalCode">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtDataCardPostalCode" runat="server" ControlToValidate="txtDataCardPostalCode"
                                                                            ValidationGroup="submit123" ErrorMessage="Please enter postal code" Display="None"></asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtDataCardPostalCode" runat="server"
                                                                            TargetControlID="rfvtxtDataCardPostalCode" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="15%" align="left" style="font-weight:bold;color:Black;">
                                                                        Amount
                                                                    </td>
                                                                    <td width="50%" align="left">
                                                                        <asp:DropDownList ID="ddlDatacardRechargeAmount" class="lj_inp1" runat="server" ValidationGroup="submit"
                                                                            Width="150px">
                                                                        </asp:DropDownList>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server"
                                                                            TargetControlID="RequiredFieldValidator9" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDatacardRechargeAmount"
                                                                            ValidationGroup="submit123" ErrorMessage="Please enter Amount" Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server"
                                                                            PopupPosition="Left" CloseImageUrl="~/images/Closing.png" TargetControlID="CompareValidator3"
                                                                            WarningIconImageUrl="~/images/warning.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlDatacardRechargeAmount"
                                                                            Display="None" ErrorMessage="Please select Recharge Amount" Operator="NotEqual"
                                                                            Type="Integer" ValidationGroup="submit123" ValueToCompare="0"></asp:CompareValidator>
                                                                    </td>
                                                                   
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr><td colspan="2" align="center" height="40"><asp:Button ID="btnNetConnectRecharge" runat="server" CssClass="buttonBook" Text="Proceed"
                                                                            ValidationGroup="submit123" CausesValidation="true" OnClick="btnNetConnectRecharge_Click" /></td></tr>
                                                                            
                                                </table>
                                                 </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                        <!--TabsEnd-->
                                    </td>
                                    <!--CLEFTend-->
                                    <td width="450" valign="middle" align="right" id="td1" runat="server" >
                                        <%--<img src="images/recharge_image.jpg" width="440" height="350" />--%>
                                    </td>
                                </tr>
                            </table>
                            <!--contentTabsEnd-->
                            </td>
                         <td class="form_right">&nbsp;</td>
  </tr>
  <tr>
    <td align="center" valign="top" width="24" height="32"><img src="images/formbottom_left.png" /></td>
    <td class="form_bottom">&nbsp;</td>
    <td align="left" valign="top" width="29" height="32"><img src="images/formright_bottom.png" /></td>
  </tr>
</table>
</td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
         <%--           <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td height="1" align="center">
                            <img src="images/bdr.jpg" height="1" width="969" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
          
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="1" align="center">
                            <img src="images/bdr.jpg" height="1" width="969" />
                        </td>
                    </tr>
              <tr>
            <td width="964" height="30" align="left" valign="top">
                <table width="964" style="border-bottom: 1px solid #669999;">
                    <tr>
                        <td width="260" height="30" align="center" valign="middle" class="footer-menu">
                       
                        </td>
                        <td width="390" height="30" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td width="314" height="30" align="center" valign="middle">
                           
                                Copyright @ All Rights Reserved By LoveJourney.in
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="964" height="28" align="left" valign="top">
                <table width="964" border="0" height="28">
                    <tr>
                        <td width="499" height="28" align="left" valign="top">
                            <div class="image1">
                                <a href="#">
                                    <img src="images/1.jpg" border="0" /></a></div>
                            <div class="image2">
                                <a href="#">
                                    <img src="images/2.jpg" border="0" /></a></div>
                            <div class="image3">
                                <a href="#">
                                    <img src="images/3.jpg" border="0" /></div>
                            <div class="image4">
                                <a href="#">
                                    <img src="images/4.jpg" border="0" /></a></div>
                            <div class="image5">
                                <a href="#">
                                    <img src="images/5.jpg" border="0" /></a></div>
                            <div class="image6">
                                <a href="#">
                                    <img src="images/6.jpg" border="0" /></a></div>
                            <div class="image7">
                                <a href="#">
                                    <img src="images/7.jpg" border="0" /></a></div>
                        </td>
                        <td width="235" height="28" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td width="230" height="28" align="left" valign="top">
                            <div class="facebook">
                                <a href="#">
                                    <img src="images/facebook.gif" border="0" /></a></div>
                            <div class="twitter">
                                <a href="#">
                                    <img src="images/twitter.gif" border="0" /></a></div>
                            <div class="in">
                                <a href="#">
                                    <img src="images/in.gif" border="0" /></a></div>
                            <div class="google-plus">
                                <a href="#">
                                    <img src="images/g+.gif" border="0" /></a></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="964" align="center" valign="bottom" class="footer-nviation">
                <ul>
                     <li><a href="BecomeAnAgent.aspx">Become An Agent</a></li>
                        <li><a href="Testimonial.aspx">Testimonial</a></li>
                        <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                        <li><a href="TermsAndConditions.aspx">Terms and Conditions</a></li>
                        <li><a href="ContactUs.aspx">Contact Us</a></li>
                </ul>
            </td>
        </tr>--%>
    

        <tr>
            <td align="center" valign="middle">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="Button12" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID9" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID1" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID11" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID12" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID14" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenLogin1" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenLogin2" runat="server" Text="OK" />
            </td>
        </tr>
    </table>
    <ajaxToolkit:ModalPopupExtender ID="MpLogin" PopupControlID="PnlLogin" runat="server"
        TargetControlID="OpenID9" BackgroundCssClass="modalBackground" OkControlID="ImageButton1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PnlLogin" runat="server" Style="display: none; width: 500px; height: 280px;
        color: Black;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="images/up_arrow.png" width="525" height="13" style="padding: 0px; margin: 0px;" />
                </td>
            </tr>
            <tr>
                <td width="12" align="right" valign="top" bgcolor="#fe8b0f">
                </td>
                <td align="left" valign="top" class="main_tab1" bgcolor="#f3faf3">
                    <table width="501" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <table width="501" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="25" align="left" class="hd2">
                                            &nbsp;
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:ImageButton ID="ImageButton1" Width="26" Height="26" runat="server" ImageUrl="images/close_but.png" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="7" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="left" class="hd2" bgcolor="#fe8b0f">
                                &nbsp; Proceed to Recharge
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="470" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="10">
                                        </td>
                                        <td width="315">
                                            <table width="315" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                  
                                                    <td align="right" width="220" class="p_nme1">
                                                        <asp:ImageButton ID="imgbtnGuest" runat="server" ImageUrl="images/proceed.png" OnClick="imgbtnGuest_Click" />
                                                    </td>
                                                    <td align="center" height="24">
                                                        <table width="120" border="0" cellspacing="0" cellpadding="0" id="tb1" runat="server" visible="false">
                                                            <tr>
                                                                <td align="right" height="30" valign="bottom">
                                                                    <asp:ImageButton ID="imgbtnsignin" runat="server" ImageUrl="images/signin1.png" Height="26"
                                                                        OnClick="imgbtnsignin_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" height="30" valign="bottom">
                                                                    <asp:ImageButton ID="Imagebtnsignup" runat="server" ImageUrl="images/signup1.png"
                                                                        OnClick="Imagebtnsignup_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <%--<td colspan="2" height="34" align="center">
                                                        <asp:ImageButton ID="Imgbtnptor" runat="server" ImageUrl="images/ptor.png" Visible="false"
                                                            Width="219" Height="54" />
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="145" valign="middle">
                                            <img src="images/guest.png">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="12" align="left" valign="top" bgcolor="#fe8b0f">
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <img src="images/down_arrow.png" width="525" height="13" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MpLogin1" PopupControlID="PnlLogin1" runat="server"
        TargetControlID="OpenLogin1" BackgroundCssClass="modalBackground" OkControlID="clseLogin1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PnlLogin1" runat="server" Style="display: none; width: 525px; height: 250px;
        color: Black;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="images/up_arrow.png" width="525" height="13" style="padding: 0px; margin: 0px;" />
                </td>
            </tr>
            <tr>
                <td width="12" align="right" valign="top" bgcolor="#fe8b0f">
                </td>
                <td align="left" valign="top" class="main_tab1" bgcolor="#f3faf3">
                    <table width="501" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <table width="501" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="25" align="left" class="hd2">
                                            &nbsp;
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:ImageButton ID="clseLogin1" Width="26" Height="26" runat="server" ImageUrl="images/close_but.png" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="7" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="left" class="hd2" bgcolor="#fe8b0f">
                                &nbsp; Proceed to Recharge
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="470" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="10">
                                        </td>
                                        <td width="315">
                                            <table width="315" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="right" width="220" class="p_nme1">
                                                        <asp:ImageButton ID="ImgbtnDTHguests" runat="server" ImageUrl="images/proceed.png"
                                                            OnClick="ImgbtnDTHguests_Click" />
                                                    </td>
                                                    <td align="center" height="24">
                                                        <table width="120" border="0" cellspacing="0" cellpadding="0" id="tb2" runat="server" visible="false">
                                                            <tr>
                                                                <td align="right" height="30" valign="bottom">
                                                                    <asp:ImageButton ID="imgbtnslogin1" runat="server" ImageUrl="images/signin1.png"
                                                                        Height="26" OnClick=" imgbtnsignin1_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" height="30" valign="bottom">
                                                                    <asp:ImageButton ID="imgbtnsignup1" runat="server" ImageUrl="images/signup1.png"
                                                                        OnClick="imgbtnsignup1_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <%--<td colspan="2" height="34" align="center">
                                                        <asp:ImageButton ID="Imgbtnptor" runat="server" ImageUrl="images/ptor.png" Visible="false"
                                                            Width="219" Height="54" />
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="145" valign="middle">
                                            <img src="images/guest.png">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="12" align="left" valign="top" bgcolor="#fe8b0f">
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <img src="images/down_arrow.png" width="525" height="13" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MpLogin2" PopupControlID="PnlLogin2" runat="server"
        TargetControlID="OpenLogin2" BackgroundCssClass="modalBackground" OkControlID="clseLogin2">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PnlLogin2" runat="server" Style="width: 500px; height: 280px; color: Black;
        display: none;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="images/up_arrow.png" width="525" height="13" style="padding: 0px; margin: 0px;" />
                </td>
            </tr>
            <tr>
                <td width="12" align="right" valign="top" bgcolor="#fe8b0f">
                </td>
                <td align="left" valign="top" class="main_tab1" bgcolor="#f3faf3">
                    <table width="501" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <table width="501" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="25" align="left" class="hd2">
                                            &nbsp;
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:ImageButton ID="clseLogin2" Width="26" Height="26" runat="server" ImageUrl="images/close_but.png" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="7" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="left" class="hd2" bgcolor="#fe8b0f">
                                &nbsp; Proceed to Recharge
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="470" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="10">
                                        </td>
                                        <td width="315">
                                            <table width="315" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="right" width="220" class="p_nme1">
                                                        <asp:ImageButton ID="ImgbtnNetguests" runat="server" ImageUrl="images/proceed.png"
                                                            OnClick="ImgbtnNetguests_Click" />
                                                    </td>
                                                    <td align="center" height="24">
                                                        <table width="120" border="0" cellspacing="0"  cellpadding="0" id="tb3" runat="server" visible="false">
                                                            <tr>
                                                                <td align="right" height="30" valign="bottom">
                                                                    <asp:ImageButton ID="Imgbtnsignin2" runat="server" ImageUrl="images/signin1.png"
                                                                        Height="26" OnClick="imgbtnsigninNet_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" height="30" valign="bottom">
                                                                    <asp:ImageButton ID="Imgbtnsignup2" runat="server" ImageUrl="images/signup1.png"
                                                                        OnClick="imgbtnsignupNet_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <%--<td colspan="2" height="34" align="center">
                                                        <asp:ImageButton ID="Imgbtnptor" runat="server" ImageUrl="images/ptor.png" Visible="false"
                                                            Width="219" Height="54" />
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="145" valign="middle">
                                            <img src="images/guest.png">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="12" align="left" valign="top" bgcolor="#fe8b0f">
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <img src="images/down_arrow.png" width="525" height="13" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MpeSignIn1" PopupControlID="panel1" runat="server"
        TargetControlID="OpenID11" BackgroundCssClass="modalBackground" OkControlID="btnclose11">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panel1" runat="server" align="center" DefaultButton="btnLogin11" Style="display: none">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="images/up_arrow.png" width="525" height="13" style="padding: 0px; margin: 0px;">
                </td>
            </tr>
            <tr>
                <td width="12" height="293" align="right" valign="top" bgcolor="#fe8b0f">
                </td>
                <td height="293" align="left" valign="top" bgcolor="#f3faf3">
                    <table width="501" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <table width="501" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td bgcolor="fe8b0f" height="30" align="left" class="hd">
                                            &nbsp;Recharge Raja
                                        </td>
                                        <td bgcolor="#fe8b0f" align="right" valign="middle">
                                            <asp:ImageButton ID="btnclose11" runat="server" ImageUrl="images/close_but.png" Width="26"
                                                Height="26" Style="margin-right: 3px;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="7" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td height="7" align="right">
                                <%-- <img src="images/signinn.jpg" width="199" height="28">--%>
                                  <asp:Label ID="Label2" runat="server" Text="Registerd User SignIn"  Width="100px"></asp:Label>
                            <%--    <asp:Label ID="lbl123" runat="server"  Width="100px" Text="Registerd User SignIn" ></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="470" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="145" valign="middle">
                                            <img src="images/login.jpg">
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="315">
                                            <table width="315" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="Label1" runat="server" Text="Email ID"></asp:Label>
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtEmailID11" runat="server" Height="15px" Width="150px" TabIndex="1"
                                                            CssClass="p_frm"></asp:TextBox>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                            TargetControlID="txtEmailID11" WatermarkText="Email ID">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                                                            ControlToValidate="txtEmailID11" ErrorMessage="Please Enter Email ID" ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server"
                                                            TargetControlID="RequiredFieldValidator3" WarningIconImageUrl="~/images/warning.png"
                                                            CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmailID11"
                                                            ErrorMessage="Please enter valid email address<br /> format is abc@lovejourney.in"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"
                                                            ValidationGroup="Login1"></asp:RegularExpressionValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server"
                                                            TargetControlID="RegularExpressionValidator3" WarningIconImageUrl="~/images/warning.png"
                                                            CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="lblpassword11" runat="server" Text="Password "></asp:Label>
                                                    </td>
                                                    <td align="center" height="24">
                                                        <asp:TextBox ID="txtpassword11" runat="server" Height="15px" Width="150px" TextMode="Password"
                                                            CssClass="p_frm" TabIndex="1"></asp:TextBox>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                                            TargetControlID="txtpassword11" WatermarkText="Password">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None"
                                                            ControlToValidate="txtpassword11" ErrorMessage="Please Enter Password" ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server"
                                                            TargetControlID="RequiredFieldValidator4" WarningIconImageUrl="~/images/warning.png"
                                                            CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" height="34">
                                                        <asp:Button ID="btnLogin11" runat="server" ValidationGroup="Login1" BackColor="#fe8b0f"
                                                            CausesValidation="true" Text="SignIn" OnClick="btnLogin11_Click1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="color: Black">
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkbtnforgotpassword_click"
                                                            Text="Forgot Password?" class="admintext"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="color: Red">
                                                        <asp:Label ID="lblErrormesg" runat="server" Text=""></asp:Label>
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
                <td width="12" height="293" align="left" valign="top" bgcolor="#fe8b0f">
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <img src="images/down_arrow.png" width="525" height="13">
                </td>
            </tr>
        </table>
    </asp:Panel>
 
    <ajaxToolkit:ModalPopupExtender ID="Mpe1" PopupControlID="pnldialog" runat="server"
        TargetControlID="OpenID" BackgroundCssClass="modalBackground" OkControlID="Button2">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnldialog" runat="server" Style="display: none; width: 500px; height: 150px;"
        align="center" DefaultButton="Button2">
        <table id="Table1" runat="server" width="500px" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="21" align="left" valign="top">
                    <asp:Image ID="Image1" runat="server" ImageUrl="images/searchreultstopleft.gif" Width="21" />
                </td>
                <td align="left" valign="middle" class="searchresultstopbg">
                    <span class="innerheading">
                        <asp:Label ID="Label8" runat="server">Message</asp:Label>
                    </span>
                </td>
                <td width="21" align="left" valign="top">
                    <asp:Image ID="Image31" runat="server" ImageUrl="images/searchresultstopright.gif"
                        Width="21px" Height="40px" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    &nbsp;
                </td>
                <td align="center" valign="top">
                    <table>
                        <caption>
                            <br />
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblMessage" runat="server" CssClass="tabtext"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button2" runat="server" CausesValidation="false" CssClass="ca-but1"
                                        Text="OK" />
                                </td>
                            </tr>
                        </caption>
                    </table>
                </td>
                <td align="left" valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <asp:Image ID="image2" runat="server" Height="22" ImageUrl="images/searchresultsbottomleft.gif"
                        Width="21" />
                </td>
                <td align="left" valign="top">
                    &nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:Image ID="Image5" runat="server" Height="22" ImageUrl="images/searchresultsbottomright.gif"
                        Width="21" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MpeSignUP" PopupControlID="pnlsignup" runat="server"
        TargetControlID="Button12" BackgroundCssClass="modalBackground" OkControlID="ClseSignup"
        Y="150">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlsignup" runat="server" DefaultButton="btnSignUp" style="display:none;">
        <table width="525" border="0" cellspacing="0" cellpadding="0" >
            <tr>
                <td colspan="3" valign="bottom"  >
                    <img src="images/up_arrow.png" width="525" height="13" style="padding: 0px; margin: 0px;">
                </td>
            </tr>
            <tr>
                <td width="12" height="293" align="right" valign="top" bgcolor="#fe8b0f">
                </td>
                <td height="293" align="left" valign="top" bgcolor="#f3faf3">
                    <table width="501" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <table width="501" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td bgcolor="fe8b0f" height="30" align="left" class="hd">
                                            &nbsp;LoveJourney
                                        </td>
                                        <td bgcolor="#fe8b0f " align="right" valign="middle">
                                            <asp:ImageButton ID="ClseSignup" runat="server" ImageUrl="images/close_but.png" Width="26"
                                                Height="26" Style="margin-right: 3px;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="7" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td height="10" align="right">
                                <asp:Label ID="Button1" runat="server" Text="New User Signup" CssClass="ca-but" Width="100px"></asp:Label>
                                <%-- <img src="images/sign.jpg" width="199" height="28">--%>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="470" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="145" valign="middle">
                                            <img src="images/pop_icn.png">
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="315">
                                            <table width="315" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="lblEmail1" runat="server" Text="Email:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtEmailID1" runat="server" class="p_frm" Width="150px" ValidationGroup="btnnext"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server"
                                                            TargetControlID="rfvEmail" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server"
                                                            TargetControlID="RegularExpressionValidator1" WarningIconImageUrl="~/images/warning.png"
                                                            CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmailID1"
                                                            Display="None" ErrorMessage="Please enter email address" ValidationGroup="btnnext"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID1"
                                                            ErrorMessage="Please enter valid email address<br /> format is abc@lovejourney.in"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"
                                                            ValidationGroup="btnnext"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="lblName1" runat="server" Text="Name:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="24">
                                                        <asp:TextBox ID="txtFirstName" runat="server" class="p_frm" Width="150px" ValidationGroup="btnnext"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server"
                                                            TargetControlID="rfvFristName" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvFristName" runat="server" ControlToValidate="txtFirstName"
                                                            Display="None" ErrorMessage="Please Enter Your Name" ValidationGroup="btnnext"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtaddress1" runat="server" class="p_frm" Width="150px" TextMode="MultiLine"
                                                            ValidationGroup="btnnext"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server"
                                                            TargetControlID="rfvAddress1" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ControlToValidate="txtaddress1"
                                                            ErrorMessage="Please enter Address" Display="None" ForeColor="Red" Font-Size="11px"
                                                            ValidationGroup="btnnext"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="labelCity" runat="server" Text="City:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtCity" runat="server" class="p_frm" Width="150px" ValidationGroup="btnnext"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender31" runat="server"
                                                            TargetControlID="rfvCity" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                                                            ErrorMessage="Please enter City" Display="None" ForeColor="Red" Font-Size="11px"
                                                            ValidationGroup="btnnext"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FtbeCity" runat="server" TargetControlID="txtCity"
                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtState" runat="server" class="p_frm" Width="150px" ValidationGroup="btnnext"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender30" runat="server"
                                                            TargetControlID="rfvState" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtState"
                                                            ErrorMessage="Please enter State" Display="None" ForeColor="Red" Font-Size="11px"
                                                            ValidationGroup="btnnext"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbestate" runat="server" TargetControlID="txtState"
                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtCountry" runat="server" class="p_frm" Width="150px" ValidationGroup="btnnext"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender38" runat="server"
                                                            TargetControlID="rfvtxtCountry" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvtxtCountry" runat="server" ControlToValidate="txtCountry"
                                                            ErrorMessage="Please enter Country" Display="None" ForeColor="Red" Font-Size="11px"
                                                            ValidationGroup="btnnext"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                            TargetControlID="txtCountry" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="right" width="120" class="p_nme1">
                                                        <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="24">
                                                        <asp:DropDownList ID="ddlCountry" runat="server" class="p_frm1" ValidationGroup="btnnext"
                                                            Width="150px" Height="20px">
                                                            <asp:ListItem Value="Please Select">Please Select</asp:ListItem>
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
                                                            <asp:ListItem Value="IND">India</asp:ListItem>
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
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender38" runat="server"
                                                            TargetControlID="rfvddlCountry" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvddlCountry" runat="server" ControlToValidate="ddlCountry"
                                                            ErrorMessage="Please select Country" Display="None" ForeColor="Red" Font-Size="11px"
                                                            InitialValue="Please Select" ValidationGroup="btnnext"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="lblPassword1" runat="server" Text="Password:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtPassword1" runat="server" class="p_frm" TextMode="Password" MaxLength="15"
                                                            ValidationGroup="btnnext" autocomplete="off" Width="150px"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server"
                                                            TargetControlID="rfvPassword2" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvPassword2" runat="server" ControlToValidate="txtPassword1"
                                                            ValidationGroup="btnnext" ErrorMessage="Please enter Password" Display="None"
                                                            ForeColor="Red" Font-Size="11px"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="Label4" runat="server" Text="ConfirmPassword:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtConformPassword" runat="server" class="p_frm" TextMode="Password"
                                                            ValidationGroup="btnnext" MaxLength="15" autocomplete="off" Width="150px"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender28" runat="server"
                                                            TargetControlID="rfvConformPass" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvConformPass" runat="server" ControlToValidate="txtConformPassword"
                                                            ValidationGroup="btnnext" ErrorMessage="Please enter Confirm Password" Display="None"
                                                            ForeColor="Red" Font-Size="11px"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="cvConNewPwd" runat="server" ControlToCompare="txtPassword1"
                                                            ValidationGroup="btnnext" ControlToValidate="txtConformPassword" Display="None"
                                                            ErrorMessage="Confirm password is not same as  Password, please enter same passwords."></asp:CompareValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender29" runat="server"
                                                            TargetControlID="cvConNewPwd" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="86" class="p_nme">
                                                        <asp:Label ID="lblMobilenumber" runat="server" Text="MobileNumber:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="24">
                                                        <asp:TextBox ID="txtMobileNum" runat="server" class="p_frm" Width="150px" MaxLength="10"
                                                            ValidationGroup="btnnext"></asp:TextBox>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server"
                                                            TargetControlID="RequiredFieldValidator5" WarningIconImageUrl="~/images/warning.png"
                                                            CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMobileNum"
                                                            Display="None" ErrorMessage="Please Enter Your Mobile Number " ValidationGroup="btnnext"
                                                            ValidationExpression="^[0-9]{10}"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbmobile" runat="server" TargetControlID="txtMobileNum"
                                                            ValidChars="1234567890">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender32" runat="server"
                                                            TargetControlID="RegularExpressionValidator7" WarningIconImageUrl="~/images/warning.png"
                                                            CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtMobileNum"
                                                            ValidationGroup="btnnext" ErrorMessage="Please enter valid mobile number" Display="None"
                                                            ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="120" class="p_nme1">
                                                        <asp:Label ID="lbluserpostalcode" runat="server" Text="PostalCode:"></asp:Label>
                                                        <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="center" height="24">
                                                        <asp:TextBox ID="txtUserpostalcode" class="p_frm1" runat="server" Width="150px" 
                                                            MaxLength="6">

                                                        </asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                            ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtUserpostalcode">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender52" runat="server"
                                                            TargetControlID="rfvtxtUserpostalcode" WarningIconImageUrl="~/images/warning.png"
                                                            CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvtxtUserpostalcode" runat="server" ControlToValidate="txtUserpostalcode"
                                                            Display="None" ErrorMessage="Please Enter Your Postal Code " ValidationGroup="btnnext"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" height="34">
                                                        <asp:Button ID="btnSignUp" runat="server" Text="Signup" ValidationGroup="btnnext"
                                                            CausesValidation="true" Width="120px" BackColor="#fe8b0f" OnClick="btnSignUp_Click"
                                                            OnClientClick="showDiv();" />
                                                        <span id="SignupMain" style="display: none" class="loadingBackground"></span><span
                                                            id="SignUpContent" style="display: none" class="modalContainer">
                                                            <div class="registerhead">
                                                                <asp:Literal ID="Literal1" runat="server" Text="Processing"></asp:Literal>
                                                                <br />
                                                                <img src="images/loading.gif" id="Img4" alt="Processing... Please wait!" />
                                                            </div>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" height="20">
                                                        <asp:Label ID="lblMsg1" runat="server" class="p_nme"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" height="20">
                                                        <asp:Label ID="lblMsg2" runat="server" class="p_nme"></asp:Label>
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
                <td width="12" height="293" align="left" valign="top" bgcolor="#fe8b0f">
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top"  >
                    <img src="images/down_arrow.png" width="525" height="13">
                </td>
            </tr>
        </table>
    </asp:Panel>
  </asp:Content>
   <%-- </form>
</body>
</html>
--%>