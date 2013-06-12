<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Recharge/MasterPage.master" AutoEventWireup="true" CodeFile="Utilities.aspx.cs" Inherits="Agent_Recharge_Utilities" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="800" class="container" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="100%" height="30px" valign="middle" align="center" class="tr" id="tdmsg"
                runat="server" visible="false"  >
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="tdmob" runat="server">
                <table width="800" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="center">
                            <!--contentTabs-->
                            <table width="850" border="0" cellspacing="0" cellpadding="0">
                            <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="../../images/formtop_left.png" /></td>
    <td class="form_top" width="395">&nbsp;</td>
    <td align="left" valign="bottom" width="29" height="23"><img src="../../images/formright_top.png" /></td>
  </tr>
                                <tr>
                                 <td class="form_left">&nbsp;</td>
                                    <!--CLEFT-->
                                    <td width="500" align="left" bgcolor="#ffffff">
                                        <!--tabsTart-->
                                        <div id="tabs" style ="width:420px;">
                                            <ul>
                                                <li><a href="#tabs-1">
                                                    <img src="../../images/postpaid.png" width="90" height="90"></a></li>
                                                <li><a href="#tabs-2">
                                                    <img src="../../images/landline.png" width="90" height="90"></a></li>
                                             
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
                                                                TabIndex="1" ValidationGroup="postpaid" MaxLength="10" 
                                                                > </asp:TextBox><ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender15"
                                                                    runat="server" TargetControlID="RequiredFieldValidator8" WarningIconImageUrl="~/images/warning.png"
                                                                    CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                ValidChars="1234567890." TargetControlID="txtMobile">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMobile"
                                                                ValidationGroup="postpaid" ErrorMessage="Please enter mobile number" Display="None"></asp:RequiredFieldValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server"
                                                                TargetControlID="RegularExpressionValidator2" WarningIconImageUrl="~/images/warning.png"
                                                                CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                                                                ValidationGroup="postpaid" ErrorMessage="Please enter valid mobile number" Display="None"
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
                                                            <asp:DropDownList ID="ddlProvider" class="sel123" runat="server" TabIndex="2">
                                                            </asp:DropDownList>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server"
                                                                TargetControlID="rfvprovider" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="rfvprovider" runat="server" ControlToValidate="ddlProvider"
                                                                InitialValue="Please Select" Display="None" ErrorMessage="Please Select Service Provider"
                                                                ValidationGroup="postpaid"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="cmpProvider" runat="server" ControlToValidate="ddlProvider"
                                                                ValueToCompare="--Select Operator--" ErrorMessage="Please Select Operator" Display="None"
                                                                ValidationGroup="postpaid" Type="String" Operator="NotEqual"></asp:CompareValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="VCEprovider1" runat="server" TargetControlID="cmpProvider"
                                                                WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="trpop" runat="server" visible ="false">
                                                        <td align="left" height="20" valign="middle">
                                                            <asp:LinkButton ID="lnkpopularrecharges" runat="server" Text="Popular Recharges" ForeColor="Blue"
                                                                OnClick="lnkpopularrecharges_Click"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr id="td1" runat="server" visible="false">
                                                        <td align="left" height="30">
                                                            Email ID
                                                        </td>
                                                    </tr>
                                                    <tr id="td2" runat="server" visible="false">
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmailMobile" runat="server" class="inp" ValidationGroup="postpaid"
                                                                MaxLength="100"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender37"
                                                                    runat="server" TargetControlID="rfvEmailMobile" WarningIconImageUrl="~/images/warning.png"
                                                                    CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="rfvEmailMobile" runat="server" ControlToValidate="txtEmailMobile"
                                                                ValidationGroup="postpaid" ErrorMessage="Please enter email" Display="None"></asp:RequiredFieldValidator><ajaxToolkit:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender39" runat="server" TargetControlID="revEmailMobile"
                                                                    WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="revEmailMobile" runat="server" ControlToValidate="txtEmailMobile"
                                                                ValidationGroup="postpaid" ErrorMessage="Please enter valid email <br/> format is abc@cba.com"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                            <tr id="trrechargeopt" runat="server" visible = "false">
                                                        <td align="left" height="40">
                                                           Recharge Options
                                                        </td>
                                                    </tr>
                                                    <tr id="trrechargeoption" runat="server" visible = "false">
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlrechargeoption" class="sel123" runat="server" TabIndex="2">
                                                            <asp:ListItem Text="TalkTime Topup" Value="TalkTime Topup"></asp:ListItem>
                                                               <asp:ListItem Text="Special Recharge" Value="Special Recharge"></asp:ListItem>
                                                            </asp:DropDownList>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="70">
                                                            <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="84" align="left">
                                                                        Amount
                                                                    </td>
                                                                    <td width="70" align="left">
                                                                        <asp:TextBox ID="ddlMobilerechargeamount" class="inp" runat="server" ValidationGroup="submit"
                                                                            MaxLength="5" TabIndex="3" Width="150px"> </asp:TextBox>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                                            TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/images/warning.png"
                                                                            CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMobilerechargeamount"
                                                                            ValidationGroup="postpaid" ErrorMessage="Please select Recharge Amount" Display="None"> </asp:RequiredFieldValidator>
                                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vceddlrechargeamount" runat="server" CloseImageUrl="~/images/Closing.png"
                                                                            TargetControlID="CompareValidator4" WarningIconImageUrl="~/images/warning.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlMobilerechargeamount"
                                                                            Display="None" ErrorMessage="Please select Recharge Amount" Operator="NotEqual"
                                                                            Type="Integer" ValidationGroup="postpaid" ValueToCompare="0"></asp:CompareValidator>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="fgt" runat="server" TargetControlID="ddlMobilerechargeamount"
                                                                            ValidChars="0123456789.">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td width="35" align="left">
                                                                        
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                  <td colspan="2" align="center" height="50">
                                                                  <asp:Button ID="btnMobileRecharge" runat="server" CssClass="buttonBook" Text="Proceed"
                                                                            ValidationGroup="postpaid" TabIndex="4" OnClick="btnMobileRecharge_Click" />
                                                                          
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
                                                <!--tab1End-->
                                            </div>
                                            <div id="tabs-2" style="background-color: White;">
                                                <!--tab2-->
                                                <asp:UpdatePanel ID="up2" runat="server">
                                                    <ContentTemplate>
                                                        <table width="450" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="left" height="35">
                                                                    Landline Operator
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddllandlineProvider" runat="server" class="sel123" TabIndex="1">
                                                                    </asp:DropDownList>
                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server"
                                                                        TargetControlID="rfvddld2h" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvddld2h" runat="server" Display="None" ControlToValidate="ddllandlineProvider"
                                                                        InitialValue="Please Select" ValidationGroup="D2H" ErrorMessage="Please select service Provider"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddllandlineProvider"
                                                                        ValueToCompare="--Select Operator--" ErrorMessage="Please Select Operator" Display="None"
                                                                        ValidationGroup="D2H" Type="String" Operator="NotEqual"></asp:CompareValidator>
                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" runat="server"
                                                                        TargetControlID="CompareValidator1" WarningIconImageUrl="~/images/warning.png"
                                                                        CloseImageUrl="~/images/Closing.png">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr id="td3" runat="server" visible="false">
                                                                <td align="left" height="30">
                                                                    Email ID
                                                                </td>
                                                            </tr>
                                                            <tr id="td4" runat="server" visible="false">
                                                                <td align="left" height="30">
                                                                    <asp:TextBox ID="txtEmaillandline" runat="server" class="inp" MaxLength="50"></asp:TextBox><ajaxToolkit:ValidatorCalloutExtender
                                                                        ID="ValidatorCalloutExtender44" runat="server" TargetControlID="rfvEmailD2H"
                                                                        WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvEmailD2H" runat="server" ControlToValidate="txtEmaillandline"
                                                                        ValidationGroup="D2H" ErrorMessage="Please enter email" Display="None"></asp:RequiredFieldValidator><ajaxToolkit:ValidatorCalloutExtender
                                                                            ID="ValidatorCalloutExtender45" runat="server" TargetControlID="revEmailD2H"
                                                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator ID="revEmailD2H" runat="server" ControlToValidate="txtEmaillandline"
                                                                        ValidationGroup="D2H" ErrorMessage="Please enter valid email <br/> format is abc@cba.com"
                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" height="40">
                                                                  Landline Number
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
                                                                        ValidationGroup="D2H" ErrorMessage="Please enter landline number" Display="None"></asp:RequiredFieldValidator><%--<asp:RegularExpressionValidator
                                                                            ID="rfvCustID1" runat="server" ControlToValidate="txtCustID" ValidationGroup="D2H"
                                                                            ErrorMessage="Please enter valid Customer ID" Display="None" ValidationExpression="[0-9]{10,12}"></asp:RegularExpressionValidator>--%>
                                                                         <ajaxToolkit:FilteredTextBoxExtender ID="ftbecutid" runat="server"
                                                                                    TargetControlID="txtCustID" ValidChars="0123456789">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>     
                                                                            

                                                                </td>
                                                            </tr>
                                                             <tr id="trpop1" runat="server" visible ="false">
                                                        <td align="left" height="20" valign="middle">
                                                            <asp:LinkButton ID="lnldthpop" runat="server" Text="Popular Recharges" 
                                                                ForeColor="Blue" onclick="lnldthpop_Click"
                                                               ></asp:LinkButton>
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
                                                                                <asp:TextBox ID="ddllandlineAmount" runat="server" class="inp" Width="150px" MaxLength="5"
                                                                                    TabIndex="3">
                                                                                  
                                                                                </asp:TextBox>
                                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                                                                    TargetControlID="RequiredFieldValidator2" WarningIconImageUrl="~/images/warning.png"
                                                                                    CloseImageUrl="~/images/Closing.png">
                                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddllandlineAmount"
                                                                                    ValidationGroup="D2H" ErrorMessage="Please select recharge Amount" Display="None"></asp:RequiredFieldValidator>
                                                                                <%--<ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender36" runat="server"
                                                                                    PopupPosition="Right" CloseImageUrl="~/images/Closing.png" TargetControlID="CompareValidator2"
                                                                                    WarningIconImageUrl="~/images/warning.png">
                                                                                </ajaxToolkit:ValidatorCalloutExtender>--%>
                                                                                <%--<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlD2HAmount"
                                                                                    Display="None" ErrorMessage="Please select Recharge Amount" Operator="NotEqual"
                                                                                    Type="Integer" ValidationGroup="D2H" ValueToCompare="0"></asp:CompareValidator>--%>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                                    TargetControlID="ddllandlineAmount" ValidChars="0123456789.">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </td>
                                                                            <td width="28" align="left">
                                                                               
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                         <td width="28" align="center" height="50" colspan="2">
                                                                          <asp:Button ID="btnlandlineRecharge" runat="server" ValidationGroup="D2H" CssClass="buttonBook" 
                                                                                    TabIndex="4" Text="Proceed" OnClick="btnlandlineRecharge_Click" CausesValidation="true" />
                                                                         </td>
                                                                        </tr>
                                                                    </table>
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
                                                                                                           Landline Number
                                                                                                        </td>
                                                                                                        <td align="center" height="24">
                                                                                                            <asp:TextBox ID="txtagntd2hcustomerid" onkeypress="return isNumberEvt(event)" class="p_frm1"
                                                                                                                Enabled="false" runat="server" ValidationGroup="submit" Width="150px" Height="15px"
                                                                                                                MaxLength="10"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" class="p_nme1">
                                                                                                           Operator:
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
                                                         <asp:Panel ID="pnlDThpopular" runat="server" Style="display: none">
                                                            <asp:Button ID="pnlpopularDTH" runat="server" Text="OK" />
                                                        </asp:Panel>

                                                         <ajaxToolkit:ModalPopupExtender ID="mpepopDTH" runat="server" PopupControlID="pnlpopDTH"
        BackgroundCssClass="modalBackground" OkControlID="imgpopularDTH" TargetControlID="pnlpopularDTH">
    </ajaxToolkit:ModalPopupExtender>
                                       <asp:Panel ID="pnlpopDTH" runat="server" Style="display: none; width: 525px;
        height: 250px; color: Black;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
       
            <tr>
               
                <td align="left" valign="top" class="main_tab1" bgcolor="#f3faf3">
                    <table width="501" border="0" cellspacing="0" cellpadding="0" align="center" >
                        <tr>
                            <td>
                                <table width="600" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="25" align="left" class="hd2">
                                            &nbsp;
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:ImageButton ID="imgpopularDTH" Width="26" Height="26" runat="server" ImageUrl="../../images/close_but.png" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                      
                        <tr>
                            <td height="30" align="left" class="hd2" bgcolor="#4f91cd">
                                &nbsp; Popular Recharges
                            </td>
                        </tr>
                     
                        <tr>
                            <td align="center">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table width="600" border="0" cellspacing="0" cellpadding="0" bgcolor="">
                                                <tr>
                                                    <td valign="top" >
                                                        <table width="100%">
                                                            <tr align="left">
                                                                
                                                                        <td align="right" class="aclass" valign="middle" width="50%">
                                                                            Operator Name <span style="color: Red">*</span>
                                                                        </td>
                                                                        <td align="left" class="style1" valign="middle" width="50%">
                                                                            <asp:DropDownList ID="ddlpopDTH" runat="server" CausesValidation="true" 
                                                                                CssClass="i2s_jp_seats" TabIndex="4" Width="150px">
                                                                                <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" 
                                                                                runat="server" CloseImageUrl="~/images/Closing.png" PopupPosition="Left" 
                                                                                TargetControlID="cvddlpopDTH" WarningIconImageUrl="~/images/warning.png">
                                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                                            <asp:CompareValidator ID="cvddlpopDTH" runat="server" 
                                                                                ControlToValidate="ddlpopDTH" Display="None" 
                                                                                ErrorMessage="Please select Operator Name" Operator="NotEqual" Type="Integer" 
                                                                                ValidationGroup="POPDTH" ValueToCompare="0"></asp:CompareValidator>
                                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" 
                                                                                runat="server" CloseImageUrl="~/images/Closing.png" PopupPosition="Left" 
                                                                                TargetControlID="rfvcvddlpopDTH" WarningIconImageUrl="~/images/warning.png">
                                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                                            <asp:RequiredFieldValidator ID="rfvcvddlpopDTH" runat="server" 
                                                                                ControlToValidate="ddlpopDTH" Display="None" 
                                                                                ErrorMessage="Please Select Operator Name" ValidationGroup="POPDTH"></asp:RequiredFieldValidator>
                                                                        </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" height="15" width="100%">
                                                                    <asp:Button ID="btnDTHpop" runat="server" CssClass="buttonBook" 
                                                                        OnClick="btnDTHpop_Click" TabIndex="17" Text="Show" 
                                                                        ValidationGroup="POPDTH" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td align="center" class="style1" colspan="3" valign="middle">
                                                        &nbsp;
                                                        <asp:Label ID="lbldthpop" runat="server" CssClass="labelconfirm" 
                                                            Font-Size="Medium" ForeColor="Red" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr ID="tr1" runat="server" align="center">
                                                    <td colspan="4">
                                                        <asp:GridView ID="gvdthpopo" runat="server" AllowPaging="True" 
                                                            AllowSorting="True" AlternatingRowStyle-CssClass="alt" 
                                                            AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" 
                                                            ForeColor="#333333" GridLines="None" PagerStyle-CssClass="i2s_jp_bustext" 
                                                            PageSize="20" Width="70%">
                                                            <PagerSettings Mode="Numeric" Position="Bottom" />
                                                            <PagerStyle BackColor="#2461BF" CssClass="transaction_style" ForeColor="White" 
                                                                HorizontalAlign="Center" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#507CD1" CssClass="transaction_style" Font-Bold="True" 
                                                                ForeColor="White" />
                                                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="12px" Wrap="true" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:BoundField DataField="NetworkName" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="NetworkName" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Denomination" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="Denomination" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TalkTime" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="TalkTime" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Validity" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="Validity" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Description" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="Description" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
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
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <!--tab2End-->
                                            </div>
                                            
                                        </div>
                                        <!--TabsEnd-->
                                    </td>
                                     <td class="form_right">&nbsp;</td>
                                    <!--CLEFTend-->
                                    <td width="450" valign="middle" align="right">
                                       <%-- <img src="../../images/recharge_image.jpg" width="350" height="350" />--%>
                                       <table width="340" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="link_rt" valign="top">
    
    
    <table width="320" border="0" cellspacing="0" cellpadding="0">
  
  <tr>
    <td colspan="3" height="10"></td>
   
  </tr>
  <tr>
    <td align="center"><a href="../Flight/frmDomesticAvailability.aspx" target="_blank"><img src="../../img/flight.png" width="86" height="76"  /></a></td>
    <td align="center"><a href="../Hotel/HotelSearch.aspx" target="_blank"><img src="../../img/hotel.png" width="86" height="76"  /></a></td>
    <td align="center"><a href="../Bus/Default.aspx" target="_blank"><img src="../../img/bus.png" width="86" height="76"  /></a></td>
  </tr>
  <tr>
    <td align="center" class="flights"><a href="../Flight/frmDomesticAvailability.aspx" target="_blank">Flights</a></td>
    <td align="center" class="flights"><a href="../Hotel/HotelSearch.aspx" target="_blank">Hotels</a></td>
    <td align="center" class="flights"><a href="../Bus/Default.aspx" target="_blank">Bus</a></td>
  </tr>
  
  <tr>
    <td colspan="3" height="10"></td>
   
  </tr>
  <tr>
    <td align="center"><img src="../../img/TRAIN.png" width="86" height="76"  /></td>
    <td align="center"><a href="Recharge.aspx" target="_blank"><img src="../../img/RECHARGE.png" width="86" height="76"  /></a></td>
    <td align="center"><img src="../../img/TICKET.png" width="86" height="76"  /></td>
  </tr>
  <tr>
    <td align="center" class="flights">Train</td>
    <td align="center" class="flights"><a href="Recharge.aspx" target="_blank">Recharge</a></td>
    <td align="center" class="flights">Tickets</td>
  </tr>
  
  
  <tr>
    <td colspan="3" height="10"></td>
   
  </tr>
  <tr>
    <td align="center"><img src="../../img/CAR.png" width="86" height="76"  /></td>
    <td align="center"><img src="../../img/UTILITIES.png" width="86" height="76"  /></td>
    <td align="center"><img src="../../img/DMR.png" width="86" height="76"  /></td>
  </tr>
  <tr>
    <td align="center" class="flights">Car</td>
    <td align="center" class="flights">Utilities</td>
    <td align="center" class="flights">Dmr</td>
  </tr>
 

  
</table>

    
    
    </td>
  </tr>
</table>
                                    </td>
                                   
                                </tr>
                                <tr>
    <td align="center" valign="top" width="24" height="32"><img src="../../images/formbottom_left.png" /></td>
    <td class="form_bottom">&nbsp;</td>
    <td align="left" valign="top" width="29" height="32"><img src="../../images/formright_bottom.png" /></td>
  </tr>
                            </table>
                            <!--contentTabsEnd-->
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
                            <asp:Button ID="popular" runat="server" Text="OK" />
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
                                            <asp:ImageButton ID="ImageButton1" Width="26" Height="26" runat="server" ImageUrl="../images/close_but.png" />
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
                                            <asp:ImageButton ID="ImageButton12" Width="26" Height="26" runat="server" ImageUrl="../images/close_but.png" />
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
    <ajaxToolkit:ModalPopupExtender ID="mpepopularrecharges" runat="server" PopupControlID="pnlpopularrecharges"
        BackgroundCssClass="modalBackground" OkControlID="imgpopular" TargetControlID="popular">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlpopularrecharges" runat="server" Style="display: none; width: 525px;
        height: 250px; color: Black;">
        <table width="525" border="0" cellspacing="0" cellpadding="0">
         <%--   <tr>
                <td colspan="3" valign="bottom">
                    <img src="../../images/up_arrow.png" width="600" height="13" style="padding: 0px;
                        margin: 0px;" />
                </td>
            </tr>--%>
            <tr>
                <%--<td width="12" align="right" valign="top" bgcolor="#fe8b0f">
                </td>--%>
                <td align="left" valign="top" class="main_tab1" bgcolor="#f3faf3">
                    <table width="501" border="0" cellspacing="0" cellpadding="0" align="center" style="border: 3px Solid #4f91cd;">
                        <tr>
                            <td>
                                <table width="600" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="25" align="left" class="hd2">
                                            &nbsp;
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:ImageButton ID="imgpopular" Width="26" Height="26" runat="server" ImageUrl="../../images/close_but.png" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td height="7" align="left">
                            </td>
                        </tr>--%>
                        <tr>
                            <td height="30" align="left" class="hd2" bgcolor="#4f91cd">
                                &nbsp; Popular Recharges
                            </td>
                        </tr>
                       <%-- <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="center">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table width="600" border="0" cellspacing="0" cellpadding="0" bgcolor="">
                                                <tr>
                                                    <td valign="top" >
                                                        <table width="100%">
                                                            <tr align="left">
                                                                
                                                                        <td align="right" class="aclass" valign="middle" width="50%">
                                                                            Operator Name <span style="color: Red">*</span>
                                                                        </td>
                                                                        <td align="left" class="style1" valign="middle" width="50%">
                                                                            <asp:DropDownList ID="ddlpopular" runat="server" CausesValidation="true" 
                                                                                CssClass="i2s_jp_seats" TabIndex="4" Width="150px">
                                                                                <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" 
                                                                                runat="server" CloseImageUrl="~/images/Closing.png" PopupPosition="Left" 
                                                                                TargetControlID="cvrfvddlpopular" WarningIconImageUrl="~/images/warning.png">
                                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                                            <asp:CompareValidator ID="cvrfvddlpopular" runat="server" 
                                                                                ControlToValidate="ddlpopular" Display="None" 
                                                                                ErrorMessage="Please select Operator Name" Operator="NotEqual" Type="Integer" 
                                                                                ValidationGroup="Register" ValueToCompare="0"></asp:CompareValidator>
                                                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" 
                                                                                runat="server" CloseImageUrl="~/images/Closing.png" PopupPosition="Left" 
                                                                                TargetControlID="rfvddlpopular" WarningIconImageUrl="~/images/warning.png">
                                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                                            <asp:RequiredFieldValidator ID="rfvddlpopular" runat="server" 
                                                                                ControlToValidate="ddlpopular" Display="None" 
                                                                                ErrorMessage="Please Select Operator Name" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                                        </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" height="15" width="100%">
                                                                    <asp:Button ID="btnRegisterpopular" runat="server" CssClass="buttonBook" 
                                                                        OnClick="btnRegisterpopular_Click" TabIndex="17" Text="Show" 
                                                                        ValidationGroup="Register" />
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
                                                    <td align="center" class="style1" colspan="3" valign="middle">
                                                        &nbsp;
                                                        <asp:Label ID="lblmsg" runat="server" CssClass="labelconfirm" 
                                                            Font-Size="Medium" ForeColor="Red" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr ID="trMobileService" runat="server" align="center">
                                                    <td colspan="4">
                                                        <asp:GridView ID="gvMobile" runat="server" AllowPaging="True" 
                                                            AllowSorting="True" AlternatingRowStyle-CssClass="alt" 
                                                            AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" 
                                                            ForeColor="#333333" GridLines="None" PagerStyle-CssClass="i2s_jp_bustext" 
                                                            PageSize="20" Width="70%">
                                                            <PagerSettings Mode="Numeric" Position="Bottom" />
                                                            <PagerStyle BackColor="#2461BF" CssClass="transaction_style" ForeColor="White" 
                                                                HorizontalAlign="Center" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#507CD1" CssClass="transaction_style" Font-Bold="True" 
                                                                ForeColor="White" />
                                                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="12px" Wrap="true" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:BoundField DataField="NetworkName" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="NetworkName" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Denomination" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="Denomination" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TalkTime" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="TalkTime" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Validity" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="Validity" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Description" HeaderStyle-HorizontalAlign="Center" 
                                                                    HeaderText="Description" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
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
                   <%-- <td align="left" bgcolor="#fe8b0f" valign="top" width="12">
        </td>--%>
            </tr>
          
     
      
    
      <%--
        <tr>
            <td colspan="3" valign="top">
                <img src="../../images/down_arrow.png" width="600" height="13" />
            </td>
        </tr>--%>
    </table>
        
    </asp:Panel>
</asp:Content>

