<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="Recharge.aspx.cs" Inherits="Users_Recharge_Recharge" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script  type="text/javascript">
    function DTHOperators() {

        var DTHOperator = document.getElementById('<%=ddlD2HProvider.ClientID %>').value;
        var textBox = document.getElementById('<%=txtCustID.ClientID %>');
        var textBoxAmount = document.getElementById('<%=ddlD2HAmount.ClientID %>');
        var textLength = textBox.value.length;
        var mpeDTH = document.getElementById('<%=mpeagentD2h.ClientID %>');
        alert(mpeDTH);
       
        if (DTHOperator == 'BT') {
            if (textLength != '12') {

                alert('Big Tv subscriber id should consists of only 12 digits only');
                return false;
            }
            else {
               
                amount();
            }
        }
        else if (DTHOperator == 'DS') {
            if (textLength != '11') {
                alert('Dish Tv subscriber id should consists of  11 digits only');
                return false;
            }
            else {
                return true;
            }

        }
        else if (DTHOperator == 'SD') {
            if (textLength != '11') {
                alert('Sun Tv subscriber id should consists of  11 digits only');
                return false;
            }
            else {
                return true;
            }

        }
        else if (DTHOperator == 'VD') {
            if (textLength != '8') {
                alert('Videacon D2h  subscriber id should consists of  8 digits only');
                return false;
            }
            else {
                return true;
            }

        }
        else if (DTHOperator == 'TS') {
            if (textLength != '10') {
                alert('Tatasky Tv subscriber id should consists of  10 digits only');
                return false;
            }
            else {
                return true;
            }

        }
        else if (DTHOperator == 'AD') {
            if (textLength != '10') {
                alert('Airtel DTH subscriber id should consists of  10 digits only');
                return false;
            }
            else {
                return true;
            }
        }

        function amount() {
            if (textBoxAmount.value == "") {
                alert('Hi');
                return false;
            }
            else {
                return true;
            }
        }
    }
</script>
    <table width="800" class="container">
        <tr>
            <td width="100%" height="30px" valign="middle" align="center" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="tdmob" runat="server">
                <table width="800">
                    <tr>
                        <td align="center">
                            <!--contentTabs-->
                            <table width="850" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <!--CLEFT-->
                                    <td width="500" align="left">
                                        <!--tabsTart-->
                                        <div id="tabs" style="width:420px;">
                                            <ul>
                                                <li><a href="#tabs-1">
                                                    <img src="../../images/mobile.jpg" width="90" height="90"></a></li>
                                                <li><a href="#tabs-2">
                                                    <img src="../../images/dth.jpg" width="90" height="90"></a></li>
                                                <li><a href="#tabs-3">
                                                    <img src="../../images/datacard.jpg" width="90" height="90"></a></li>
                                            </ul>
                                            <div id="tabs-1" style="background-color: White;">
                                                <!--tab1-->
                                                <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="left" height="35">
                                                            Mobile Number
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtMobile" onkeypress="return isNumberEvt(event)" class="inp" runat="server"
                                                                TabIndex="1" ValidationGroup="submit" MaxLength="10" AutoPostBack="True" OnTextChanged="txtMobile_TextChanged"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender15" runat="server" TargetControlID="RequiredFieldValidator8"
                                                                    WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
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
                                                            <%-- <ajaxToolkit:AutoCompleteExtender ID="txtMobile_AutoCompleteExtender" runat="server" 
                                                                TargetControlID="txtMobile" ServiceMethod="GetOpeartorByMobileSeries" MinimumPrefixLength="4"
                                                                CompletionInterval="10" CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters=""
                                                                Enabled="True" ServicePath="">
                                                            </ajaxToolkit:AutoCompleteExtender>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" height="40">
                                                            Mobile Operator
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlProvider" class="sel123" runat="server" TabIndex="2">
                                                            </asp:DropDownList>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server"
                                                                TargetControlID="rfvprovider" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="rfvprovider" runat="server" ControlToValidate="ddlProvider"
                                                                InitialValue="Please Select" Display="None" ErrorMessage="Please Select Service Provider"
                                                                ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="cmpProvider" runat="server" ControlToValidate="ddlProvider"
                                                                ValueToCompare="--Select Operator--" ErrorMessage="Please Select Operator" Display="None"
                                                                ValidationGroup="submit" Type="String" Operator="NotEqual"></asp:CompareValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="VCEprovider1" runat="server" TargetControlID="cmpProvider"
                                                                WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="tremai" runat="server" visible="false">
                                                        <td align="left" height="30">
                                                            Email ID
                                                        </td>
                                                    </tr>
                                                    <tr id="tremail" runat="server" visible="false">
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmailMobile" runat="server" class="inp" ValidationGroup="submit"
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
                                                    <tr>
                                                        <td height="90">
                                                            <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="84" align="left">
                                                                        Amount
                                                                    </td>
                                                                    <td width="100" align="left">
                                                                        <asp:TextBox ID="ddlMobilerechargeamount" class="inp" runat="server" ValidationGroup="submit"
                                                                     TabIndex="3" MaxLength="5" Width="150px">
                                                                                 <%--   <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>--%>
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                                            TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMobilerechargeamount"
                                                                            ValidationGroup="submit" ErrorMessage="Please select Recharge Amount" Display="None"> </asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vceddlrechargeamount" runat="server" CloseImageUrl="~/images/Closing.png"
                                                                            TargetControlID="CompareValidator4" WarningIconImageUrl="~/images/warning.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlMobilerechargeamount"
                                                                            Display="None" ErrorMessage="Please select Recharge Amount" Operator="NotEqual"
                                                                            Type="Integer" ValidationGroup="submit" ValueToCompare="0"></asp:CompareValidator>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ghtf" runat="server" TargetControlID="ddlMobilerechargeamount"
                                                                            ValidChars="0123456789.">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr id="tronbehalf" runat="server" >
                                                                    <td colspan="2" height="40">
                                                                        <asp:CheckBox ID="chkonbehalfof" runat="server" Text="On Behalf Of Agent" AutoPostBack="true"
                                                                            OnCheckedChanged="chkonbehalfof_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="tragentname" runat="server" visible="false">
                                                                    <td colspan="2" height="30">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td width="100">
                                                                                    <asp:Label ID="lblagentname" runat="server" Text="Agent Username"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtagentname" runat="server" 
                                                                                      ></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvagentname" runat="server" ControlToValidate="txtagentname" ErrorMessage="Please enter Username" Display="None"  ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                                      <ajaxToolkit:AutoCompleteExtender id="Autocompleteextender1" runat="server" targetcontrolid="txtagentname"
                                                        servicemethod="GetAgentNames" minimumprefixlength="1" completioninterval="10"
                                                        completionsetcount="12" firstrowselected="True" delimitercharacters="" enabled="True"
                                                        servicepath=""></ajaxToolkit:AutoCompleteExtender>
                                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceagentname" runat="server" TargetControlID="rfvagentname"  CloseImageUrl="~/images/Closing.png" WarningIconImageUrl="~/images/warning.png"></ajaxToolkit:ValidatorCalloutExtender>
                                                                                    <asp:DropDownList ID="ddlagent1" runat="server" Visible="false">
                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <!--contentTabsEnd-->
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
                                                                <tr >
                                                                    <td width="28" align="center" colspan="2">
                                                                        <asp:Button ID="btnMobileRecharge" runat="server" CssClass="buttonBook" Text="Proceed"
                                                                            TabIndex="4" ValidationGroup="submit" CausesValidation="true" OnClick="btnMobileRecharge_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                <td colspan="2" align="center">
                                                                  <asp:Label ID="lblcommonmsg" runat="server" Visible = "false"></asp:Label>
                                                                </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <!--tab1End-->
                                            </div>
                                            <div id="tabs-2" style="background-color: White;">
                                                <!--tab2-->
                                                <asp:UpdatePanel ID="up2" runat="server">
                                                    <ContentTemplate>
                                                        <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="left" height="35">
                                                                    DTH Operator
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlD2HProvider" runat="server" class="sel123" TabIndex="1">
                                                                    </asp:DropDownList>
                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server"
                                                                        TargetControlID="rfvddld2h" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvddld2h" runat="server" Display="None" ControlToValidate="ddlD2HProvider"
                                                                        InitialValue="Please Select" ValidationGroup="D2H" ErrorMessage="Please select service Provider"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlD2HProvider"
                                                                        ValueToCompare="--Select Operator--" ErrorMessage="Please Select Operator" Display="None"
                                                                        ValidationGroup="D2H" Type="String" Operator="NotEqual"></asp:CompareValidator>
                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" runat="server"
                                                                        TargetControlID="CompareValidator1" WarningIconImageUrl="~/images/warning.png"
                                                                        CloseImageUrl="~/images/Closing.png">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr id="td1" runat="server" visible="false">
                                                                <td align="left" height="30">
                                                                    Email ID
                                                                </td>
                                                            </tr>
                                                            <tr id="td2" runat="server" visible="false">
                                                                <td align="left" height="30">
                                                                    <asp:TextBox ID="txtEmailD2H" runat="server" class="inp" MaxLength="50"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender
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
                                                            <tr>
                                                                <td align="left" height="40">
                                                                    Subscriber ID
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCustID" runat="server" class="inp" onkeypress="return isNumberEvt(event)"
                                                                        TabIndex="2" MaxLength="12"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender10"
                                                                            runat="server" TargetControlID="rfvCustID" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                    <%--<ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server"
                                                                        TargetControlID="rfvCustID1" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>--%>
                                                                    <asp:RequiredFieldValidator ID="rfvCustID" runat="server" ControlToValidate="txtCustID"
                                                                        ValidationGroup="D2H" ErrorMessage="Please enter Customer ID" Display="None"></asp:RequiredFieldValidator><%--<asp:RegularExpressionValidator
                                                                            ID="rfvCustID1" runat="server" ControlToValidate="txtCustID" ValidationGroup="D2H"
                                                                            ErrorMessage="Please enter valid Customer ID" Display="None" ValidationExpression="[0-7]{10,12}"></asp:RegularExpressionValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="90">
                                                                    <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="84" align="left">
                                                                                Amount
                                                                            </td>
                                                                            <td width="100" align="left">
                                                                                <asp:TextBox ID="ddlD2HAmount" runat="server" class="inp" Width="150px" MaxLength="5"
                                                                                    TabIndex="3"    >
                                                                               
                                                                                </asp:TextBox>
                                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                                                                    TargetControlID="RequiredFieldValidator2" WarningIconImageUrl="~/images/warning.png"
                                                                                    CloseImageUrl="~/images/Closing.png">
                                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlD2HAmount"
                                                                                    ValidationGroup="D2H" ErrorMessage="Please select recharge Amount" Display="None"></asp:RequiredFieldValidator>
                                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender36" runat="server"
                                                                                    PopupPosition="Right" CloseImageUrl="~/images/Closing.png" TargetControlID="CompareValidator2"
                                                                                    WarningIconImageUrl="~/images/warning.png">
                                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlD2HAmount"
                                                                                    Display="None" ErrorMessage="Please select Recharge Amount" Operator="NotEqual"
                                                                                    Type="Integer" ValidationGroup="D2H" ValueToCompare="0"></asp:CompareValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                                    TargetControlID="ddlD2HAmount" ValidChars="0123456789.">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </td>
                                                                            <td width="28" align="left">
                                                                                <asp:Button ID="btnD2HRecharge" runat="server" ValidationGroup="D2H"  CssClass="buttonBook"
                                                                                    TabIndex="4" Text="Proceed" OnClick="btnD2HRecharge_Click" CausesValidation="true" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                              <tr id="tr1" runat="server" >
                                                                    <td colspan="2" height="40">
                                                                        <asp:CheckBox ID="chkDthonbehalfof" runat="server" Text="On Behalf Of Agent" 
                                                                            AutoPostBack="true" oncheckedchanged="chkDthonbehalfof_CheckedChanged"
                                                                            />
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr2" runat="server" visible="false">
                                                                    <td colspan="2" height="30">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td width="100">
                                                                                    <asp:Label ID="Label1" runat="server" Text="Agent Username"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtagentnameDTH" runat="server" 
                                                                                      ></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvtxtagentnameDTH" runat="server" ControlToValidate="txtagentnameDTH" ErrorMessage="Please enter Username" Display="None"  ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                                      <ajaxToolkit:AutoCompleteExtender id="Autocompleteextender2" runat="server" targetcontrolid="txtagentnameDTH"
                                                        servicemethod="GetAgentNames" minimumprefixlength="1" completioninterval="10"
                                                        completionsetcount="12" firstrowselected="True" delimitercharacters="" enabled="True"
                                                        servicepath=""></ajaxToolkit:AutoCompleteExtender>
                                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvtxtagentnameDTH"  CloseImageUrl="~/images/Closing.png" WarningIconImageUrl="~/images/warning.png"></ajaxToolkit:ValidatorCalloutExtender>
                                                                                    <asp:DropDownList ID="ddlagentnameDTH" runat="server" Visible="false">
                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <!--contentTabsEnd-->
                                                                    </td>
                                                                </tr>
                                                                  <tr>
                                                                <td colspan="2" align="center">
                                                                  <asp:Label ID="lblcommonmsgdth" runat="server" Visible = "false"></asp:Label>
                                                                </td>
                                                                </tr>
                                                        </table>
                                                        <asp:Panel ID="pnlOpenIDD2H" runat="server" Style="display: none">
                                                            <asp:Button ID="btnOpenIDD2H" runat="server" Text="OK" />
                                                        </asp:Panel>
                                                        <ajaxToolkit:ModalPopupExtender ID="mpeagentD2h" PopupControlID="panelagntd2h1" runat="server"
                                                            TargetControlID="btnOpenIDD2H" BackgroundCssClass="modalBackground" OkControlID="ImageButton5">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <asp:Panel ID="panelagntd2h1" runat="server" Style="display: none; width: 525px;
                                                            height: 250px; color: Black;">
                                                            <table width="525" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td colspan="3" valign="bottom">
                                                                        <img src="../../images/up_arrow.png" width="525" height="13" style="padding: 0px;
                                                                            margin: 0px;" />
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
                                                                                                <asp:ImageButton ID="ImageButton5" Width="26" Height="26" runat="server" ImageUrl="../../images/close_but.png" />
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
                                                                                            <td width="315">
                                                                                                <table width="315" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td align="right" class="p_nme1">
                                                                                                            Customer ID :
                                                                                                        </td>
                                                                                                        <td align="center" height="24">
                                                                                                            <asp:TextBox ID="txtagntd2hcustomerid" onkeypress="return isNumberEvt(event)" class="p_frm1"
                                                                                                                Enabled="false" runat="server" ValidationGroup="submit" Width="150px" Height="15px"
                                                                                                                MaxLength="10"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" class="p_nme1">
                                                                                                            Provider Name :
                                                                                                        </td>
                                                                                                        <td align="center" height="30">
                                                                                                            <asp:TextBox ID="txtagntd2hprovider" class="p_frm1" onkeypress="return isNumberEvt(event)"
                                                                                                                Enabled="false" runat="server" ValidationGroup="submit" Width="150px" Height="15px"
                                                                                                                MaxLength="3"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" class="p_nme1">
                                                                                                            Recharge Amount :
                                                                                                        </td>
                                                                                                        <td align="center" height="30">
                                                                                                            <asp:TextBox ID="txtagntd2hamount" class="p_frm1" onkeypress="return isNumberEvt(event)"
                                                                                                                Enabled="false" runat="server" ValidationGroup="submit" Width="150px" Height="15px"
                                                                                                                MaxLength="3"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" width="320" class="p_nme1" colspan="2">
                                                                                                            <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="../../images/cancel.png"
                                                                                                                ValidationGroup="ProcessingDTH" OnClick="btnD2HRechargecancel_Click" />
                                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                                            <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="../../images/ptor1.png"
                                                                                                                OnClick="imgbtnGuest1_Click" ValidationGroup="ProcessingDTH" />
                                                                                                            <br />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2" align="center">
                                                                                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="false">
                                                                                                                <ProgressTemplate>
                                                                                                                    <img src="../../images/loading.gif" width="40px" height="40px" />
                                                                                                                </ProgressTemplate>
                                                                                                            </asp:UpdateProgress>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="20" colspan="2" width="200px" align="center">
                                                                                                            <asp:Label ID="lnlLowd2hbalance" runat="server"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td width="10">
                                                                                            </td>
                                                                                            <td width="145" valign="middle">
                                                                                                <img src="../images/guest.png">
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
                                                                        <img src="../../images/down_arrow.png" width="525" height="13" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <!--tab2End-->
                                            </div>
                                            <div id="tabs-3" style="background-color: White;">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="left" height="35">
                                                                    Mobile Number
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TextBox ID="TextBox123" onkeypress="return isNumberEvt(event)" class="inp" runat="server"
                                                                        TabIndex="1" ValidationGroup="submit123" MaxLength="10"> </asp:TextBox><ajaxToolkit:ValidatorCalloutExtender
                                                                            ID="ValidatorCalloutExtender20" runat="server" TargetControlID="RequiredFieldValidator6"
                                                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
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
                                                            <tr>
                                                                <td align="left" height="40">
                                                                    Mobile Operator
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlNetConnect" class="sel123" runat="server" TabIndex="2">
                                                                    </asp:DropDownList>
                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="server"
                                                                        TargetControlID="RequiredFieldValidator7" WarningIconImageUrl="~/images/warning.png"
                                                                        CloseImageUrl="~/images/Closing.png">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlNetConnect"
                                                                        InitialValue="0" Display="None" ErrorMessage="Please Select Service Provider"
                                                                        ValidationGroup="Submit123"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="cvddlNetConnect" runat="server" ControlToValidate="ddlNetConnect"
                                                                        ValueToCompare="Please Select" ErrorMessage="Please Select Operator" Display="None"
                                                                        ValidationGroup="submit123" Type="String" Operator="NotEqual"></asp:CompareValidator>
                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender34" runat="server"
                                                                        TargetControlID="cvddlNetConnect" WarningIconImageUrl="~/images/warning.png"
                                                                        CloseImageUrl="~/images/Closing.png">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr id="td111" runat="server" visible="false">
                                                                <td align="left" height="30">
                                                                    Email ID
                                                                </td>
                                                            </tr>
                                                            <tr id="td112" runat="server" visible="false">
                                                                <td align="left" height="30">
                                                                    <asp:TextBox ID="txtEmailnet" runat="server" class="inp" ValidationGroup="submit"
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
                                                            <tr>
                                                                <td height="90">
                                                                    <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="84" align="left">
                                                                                Amount
                                                                            </td>
                                                                            <td width="100" align="left">
                                                                                <asp:TextBox ID="ddlDatacardRechargeAmount" class="inp" runat="server" ValidationGroup="submit"
                                                                                    TabIndex="3" MaxLength="5" Width="150px">
                                                                                </asp:TextBox>
                                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server"
                                                                                    TargetControlID="RequiredFieldValidator9" WarningIconImageUrl="~/images/warning.png"
                                                                                    CloseImageUrl="~/images/Closing.png">
                                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDatacardRechargeAmount"
                                                                                    ValidationGroup="submit123" ErrorMessage="Please enter Amount" Display="None"> </asp:RequiredFieldValidator>
                                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server"
                                                                                    PopupPosition="Left" CloseImageUrl="~/images/Closing.png" TargetControlID="CompareValidator3"
                                                                                    WarningIconImageUrl="~/images/warning.png">
                                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlDatacardRechargeAmount"
                                                                                    Display="None" ErrorMessage="Please select Recharge Amount" Operator="NotEqual"
                                                                                    Type="Integer" ValidationGroup="submit123" ValueToCompare="0"></asp:CompareValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                                                    TargetControlID="ddlDatacardRechargeAmount" ValidChars="0123456789.">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </td>
                                                                            <td width="28" align="left">
                                                                                <asp:Button ID="btnNetConnectRecharge" runat="server" CssClass="buttonBook" Text="Proceed"
                                                                                    TabIndex="4" ValidationGroup="submit123" CausesValidation="true" OnClick="btnNetConnectRecharge_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                                <tr id="tr3" runat="server" >
                                                                    <td colspan="2" height="40">
                                                                        <asp:CheckBox ID="chkdataonbehalfof" runat="server" Text="On Behalf Of Agent" 
                                                                            AutoPostBack="true" oncheckedchanged="chkdataonbehalfof_CheckedChanged" 
                                                                            />
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr4" runat="server" visible="false">
                                                                    <td colspan="2" height="30">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td width="100">
                                                                                    <asp:Label ID="Label2" runat="server" Text="Agent Username"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtagentnameDTCD" runat="server" 
                                                                                      ></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvtxtagentnameDTCD" runat="server" ControlToValidate="txtagentnameDTCD" ErrorMessage="Please enter Username" Display="None"  ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                                      <ajaxToolkit:AutoCompleteExtender id="Autocompleteextender3" runat="server" targetcontrolid="txtagentnameDTCD"
                                                        servicemethod="GetAgentNames" minimumprefixlength="1" completioninterval="10"
                                                        completionsetcount="12" firstrowselected="True" delimitercharacters="" enabled="True"
                                                        servicepath=""></ajaxToolkit:AutoCompleteExtender>
                                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvtxtagentnameDTCD"  CloseImageUrl="~/images/Closing.png" WarningIconImageUrl="~/images/warning.png"></ajaxToolkit:ValidatorCalloutExtender>
                                                                                    <asp:DropDownList ID="ddlagentnameDTCD" runat="server" Visible="false">
                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <!--contentTabsEnd-->
                                                                    </td>
                                                                </tr>
                                                                 <tr>
                                                                <td colspan="2" align="center">
                                                                  <asp:Label ID="lblcommonmsgDTCD" runat="server" Visible = "false"></asp:Label>
                                                                </td>
                                                                </tr>
                                                        </table>
                                                        <asp:Panel ID="Panel111" runat="server" Style="display: none">
                                                            <asp:Button ID="btnagentdatacard" runat="server" Text="OK" />
                                                        </asp:Panel>
                                                        <ajaxToolkit:ModalPopupExtender ID="mpeagentdatacard" PopupControlID="panelagentdatacard"
                                                            runat="server" TargetControlID="btnagentdatacard" BackgroundCssClass="modalBackground"
                                                            OkControlID="ImageButton7">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <asp:Panel ID="panelagentdatacard" runat="server" Style="display: none; width: 525px;
                                                            height: 250px; color: Black;">
                                                            <table width="525" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td colspan="3" valign="bottom">
                                                                        <img src="../../images/up_arrow.png" width="525" height="13" style="padding: 0px;
                                                                            margin: 0px;" />
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
                                                                                                <asp:ImageButton ID="ImageButton7" Width="26" Height="26" runat="server" ImageUrl="../../images/close_but.png" />
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
                                                                                            <td width="315">
                                                                                                <table width="315" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td align="right" class="p_nme1">
                                                                                                            Mobile Number :
                                                                                                        </td>
                                                                                                        <td align="center" height="24">
                                                                                                            <asp:TextBox ID="txtagntdtcdMob" onkeypress="return isNumberEvt(event)" class="p_frm1"
                                                                                                                Enabled="false" runat="server" ValidationGroup="submit" Width="150px" Height="15px"
                                                                                                                MaxLength="10"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" class="p_nme1">
                                                                                                            Provider Name :
                                                                                                        </td>
                                                                                                        <td align="center" height="30">
                                                                                                            <asp:TextBox ID="txtagntdtcdprovider" class="p_frm1" onkeypress="return isNumberEvt(event)"
                                                                                                                Enabled="false" runat="server" ValidationGroup="submit" Width="150px" Height="15px"
                                                                                                                MaxLength="3"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" class="p_nme1">
                                                                                                            Recharge Amount :
                                                                                                        </td>
                                                                                                        <td align="center" height="30">
                                                                                                            <asp:TextBox ID="txtagntdtcdamount" class="p_frm1" onkeypress="return isNumberEvt(event)"
                                                                                                                Enabled="false" runat="server" ValidationGroup="submit" Width="150px" Height="15px"
                                                                                                                MaxLength="3"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" width="320" class="p_nme1" colspan="2">
                                                                                                            <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="../../images/cancel.png"
                                                                                                                ValidationGroup="ProcessingDataCard" OnClick="btnNetConnectRechargecancel_Click" />
                                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                                            <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="../../images/ptor1.png"
                                                                                                                ValidationGroup="ProcessingDataCard" OnClick="imgbtnGuest2Data_Click" />
                                                                                                            <br />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2" align="center">
                                                                                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="false">
                                                                                                                <ProgressTemplate>
                                                                                                                    <img src="../../images/loading.gif" width="40px" height="40px" />
                                                                                                                </ProgressTemplate>
                                                                                                            </asp:UpdateProgress>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="20" colspan="2" width="200px" align="center">
                                                                                                            <asp:Label ID="lbldacdLowbalance" runat="server"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td width="10">
                                                                                            </td>
                                                                                            <td width="145" valign="middle">
                                                                                                <img src="../../images/guest.png">
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
                                                                        <img src="../../images/down_arrow.png" width="525" height="13" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                      
                                        <!--TabsEnd-->
                                    </td>
                                    <!--CLEFTend-->
                                    <td width="450" valign="middle" align="right">
                                        <img src="../../images/recharge_image.jpg" width="350" height="350" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <table>
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
                            <asp:Button ID="btnOpenID1" runat="server" Text="OK" />
                        </td>
                    </tr>
                    <tr>
                        <td style="display: none">
                            <asp:Button ID="OpenID" runat="server" Text="OK" />
                        </td>
                    </tr>
                    <tr>
                        <td style="display: none">
                            <asp:Button ID="OpenID9" runat="server" Text="OK" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <ajaxToolkit:ModalPopupExtender ID="Mpe1" PopupControlID="pnldialog" runat="server"
        TargetControlID="OpenID" BackgroundCssClass="modalBackground" OkControlID="Button2">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnldialog" runat="server" Style="display: none; width: 500px; height: 150px;"
        align="center" DefaultButton="Button2">
        <table id="Table1" runat="server" width="500px" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="21" align="left" valign="top">
                    <asp:Image ID="Image1" runat="server" ImageUrl="images/ModelPopUb/searchreultstopleft.gif"
                        Width="21" />
                </td>
                <td align="left" valign="middle" class="searchresultstopbg">
                    <span class="innerheading">
                        <asp:Label ID="Label8" runat="server">Message</asp:Label>
                    </span>
                </td>
                <td width="21" align="left" valign="top">
                    <asp:Image ID="Image31" runat="server" ImageUrl="images/ModelPopub/searchresultstopright.gif"
                        Width="21" Height="40" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" class="searchresultsleftbg">
                    &nbsp;
                </td>
                <td align="center" valign="top" class="searchresultsbg">
                    <table>
                        <caption>
                            <br />
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblMessage" runat="server" CssClass="tabtext"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button2" runat="server" CausesValidation="false" CssClass="i2s_jp_status1"
                                        Text="OK" />
                                </td>
                            </tr>
                        </caption>
                    </table>
                </td>
                <td align="left" class="searchresultsrightbg" valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <asp:Image ID="image2" runat="server" Height="22" ImageUrl="~/images/ModelPopub/searchresultsbottomleft.gif"
                        Width="21" />
                </td>
                <td align="left" class="searchbottombg" valign="top">
                    &nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:Image ID="Image5" runat="server" Height="22" ImageUrl="~/images/ModelPopub/searchresultsbottomright.gif"
                        Width="21" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MpLogin" PopupControlID="PnlLogin" runat="server"
        TargetControlID="OpenID9" BackgroundCssClass="modalBackground" OkControlID="ImageButton1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PnlLogin" runat="server" Style="display: none; width: 525px; height: 250px;
        color: Black;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="../../images/up_arrow.png" width="525" height="13" style="padding: 0px;
                        margin: 0px;" />
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
                                            <asp:ImageButton ID="ImageButton1" Width="26" Height="26" runat="server" ImageUrl="../../images/close_but.png" />
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
                                                        <asp:ImageButton ID="imgbtnGuest" runat="server" ImageUrl="../images/ptor.png" OnClick="imgbtnGuest_Click" />
                                                    </td>
                                                    <td align="center" height="24">
                                                        <table width="120" border="0" cellspacing="0" cellpadding="0">
                                                            <%--<tr>
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
                                                            </tr>--%>
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
                                            <img src="../images/guest.png">
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
                    <img src="../../images/down_arrow.png" width="525" height="13" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MpLogin1" PopupControlID="PnlLogin1" runat="server"
        TargetControlID="OpenID12" BackgroundCssClass="modalBackground" OkControlID="ImageButton12">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PnlLogin1" runat="server" Style="display: none; width: 500px; height: 280px;
        color: Black;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="../../images/up_arrow.png" width="525" height="13" style="padding: 0px;
                        margin: 0px;" />
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
                                            <asp:ImageButton ID="ImageButton12" Width="26" Height="26" runat="server" ImageUrl="../../images/close_but.png" />
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
                                                        <asp:ImageButton ID="ImageButtonDth" runat="server" ImageUrl="../images/ptor.png"
                                                            OnClick="imgbtnGuest1_Click" />
                                                    </td>
                                                    <td align="center" height="24">
                                                        <table width="120" border="0" cellspacing="0" cellpadding="0">
                                                            <%--<tr>
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
                                                            </tr>--%>
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
                                            <img src="../images/guest.png">
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
                    <img src="../../images/down_arrow.png" width="525" height="13" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MpLogin2" PopupControlID="PnlLogin2" runat="server"
        TargetControlID="OpenID14" BackgroundCssClass="modalBackground" OkControlID="ImageButton14">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PnlLogin2" runat="server" Style="display: none; width: 525px; height: 250px;
        color: Black;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="../../images/up_arrow.png" width="525" height="13" style="padding: 0px;
                        margin: 0px;" />
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
                                            <asp:ImageButton ID="ImageButton14" Width="26" Height="26" runat="server" ImageUrl="../../images/close_but.png" />
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
                                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../images/ptor.png" OnClick="imgbtnGuest2Data_Click" />
                                                    </td>
                                                    <td align="center" height="24">
                                                        <table width="120" border="0" cellspacing="0" cellpadding="0">
                                                            <%--<tr>
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
                                                            </tr>--%>
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
                                            <img src="../images/guest.png">
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
                    <img src="../../images/down_arrow.png" width="525" height="13" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mpeagentproceed" PopupControlID="panelagent"
        runat="server" TargetControlID="btnOpenID1" BackgroundCssClass="modalBackground"
        OkControlID="ImageButton2">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panelagent" runat="server" Style="display: none; width: 525px; height: 250px;
        color: Black;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="../../images/up_arrow.png" width="525" height="13" style="padding: 0px;
                        margin: 0px;" />
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
                                            <asp:ImageButton ID="ImageButton2" Width="26" Height="26" runat="server" ImageUrl="../../images/close_but.png" />
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
                                        <%--<td width="10">
                                        </td>--%>
                                        <td width="315">
                                            <table width="315" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="right" class="p_nme1">
                                                        Mobile Number :
                                                    </td>
                                                    <td align="center" height="24">
                                                        <asp:TextBox ID="txtagentMob" class="p_frm1" Enabled="false" runat="server" ValidationGroup="submit"
                                                            Width="150px" Height="15px" MaxLength="10"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="p_nme1">
                                                        Provider Name :
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtagentprovider" class="p_frm1" Enabled="false" runat="server"
                                                            ValidationGroup="submit" Width="150px" Height="15px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="p_nme1">
                                                        Recharge Amount :
                                                    </td>
                                                    <td align="center" height="30">
                                                        <asp:TextBox ID="txtagentrec" class="p_frm1" Enabled="false" runat="server" ValidationGroup="submit"
                                                            Width="150px" Height="15px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="320" class="p_nme1" colspan="2">
                                                        <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="../../images/cancel.png"
                                                            ValidationGroup="Processing" OnClick="imgbtnGuestcancel_Click" />
                                                        &nbsp;&nbsp;&nbsp;
                                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="../../images/ptor1.png"
                                                            ValidationGroup="Processing" OnClick="imgbtnGuest_Click" />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" DynamicLayout="false">
                                                            <ProgressTemplate>
                                                                <img src="../../images/loading.gif" width="40px" height="40px" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20" width="200px" align="center" colspan="2">
                                                        <asp:Label ID="lbllowbalance" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="145" valign="middle">
                                            <img src="../images/guest.png">
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
                    <img src="../../images/down_arrow.png" width="525" height="13" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
