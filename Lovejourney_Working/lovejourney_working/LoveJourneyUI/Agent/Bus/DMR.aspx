<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="DMR.aspx.cs" Inherits="Agent_Bus_DMR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="center">
<tr>
<td colspan="3" class="heading" align="center">
<asp:Label ID="lblheading" runat="server" Text="DMR"></asp:Label>
</td>
</tr>
                        
                     <tr>
                     <td colspan="2" align="center">
                     <asp:Label ID="lblmsg" runat="server"></asp:Label>
                     </td>
                     </tr>   
                        <tr>
                            <td align="left" width="30%">
                                <asp:Label ID="lbldeposit" runat="server" Text="Amount"></asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtDepositAmount" runat="server" MaxLength="10" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDepositAmount"
                                    Display="None" ErrorMessage="Please enter deposit amount." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDeposit1" runat="server" TargetControlID="RequiredFieldValidator1">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDepositAmount"
                                    Display="None" ErrorMessage="Please enter numeric values." Operator="DataTypeCheck"
                                    Type="Integer" ValidationGroup="UpdateRequest"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDeposit2" runat="server" TargetControlID="CompareValidator2">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtDepositAmount"
                                    Display="None" ErrorMessage="Value should be greater than zero" Operator="GreaterThanEqual"
                                    Type="Integer" ValidationGroup="UpdateRequest" ValueToCompare="1"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDepositAmount3" runat="server" TargetControlID="CompareValidator3">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="ftbeamount" runat="server" TargetControlID="txtDepositAmount" ValidChars="0123456789."></ajax:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                                <asp:Label ID="lblChequeIssueDate" runat="server" Text="Date:"></asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtChequeIssueDate" runat="server" MaxLength="10" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                    TargetControlID="txtChequeIssueDate" PopupButtonID="ImageButton2">
                                </ajax:CalendarExtender>
                                <asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="txtChequeIssueDate"
                                    Display="None" ErrorMessage="Please  date." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCheque1" runat="server" TargetControlID="r2">
                                </ajax:ValidatorCalloutExtender>
                                <%--<asp:CompareValidator ID="c1" runat="server" ControlToValidate="txtChequeIssueDate"
                                    Display="None" ErrorMessage="Please enter valid date." Operator="DataTypeCheck"
                                    Type="Date" ValidationGroup="UpdateRequest"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCheque2" runat="server" TargetControlID="c1">
                                </ajax:ValidatorCalloutExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                                <asp:Label ID="lblholdrename" runat="server" Text="Account Holder Name"></asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtholdername" runat="server" MaxLength="500" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="r1txtholdername" runat="server" ControlToValidate="txtholdername"
                                    Display="None" ErrorMessage="Please account holder name." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceChq" runat="server" TargetControlID="r1txtholdername">
                                </ajax:ValidatorCalloutExtender>
                                  <ajax:FilteredTextBoxExtender ID="ftbdholdername" runat="server" TargetControlID="txtholdername" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                               Account Number
                            </td>
                            <td>
                                <asp:TextBox ID="txtaccountnumber" runat="server" MaxLength="500" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtaccountnumber" runat="server" ControlToValidate="txtaccountnumber"
                                    ErrorMessage="Enter account no" ValidationGroup="UpdateRequest" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceTransaction" runat="server" TargetControlID="rfvtxtaccountnumber">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                              IFSC Code
                            </td>
                            <td>
                                <asp:TextBox ID="ifsccode" runat="server" MaxLength="500" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvifsccode" runat="server" ControlToValidate="ifsccode"
                                    ErrorMessage="Enter IFSC Code" ValidationGroup="UpdateRequest" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvifsccode">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                             Bank Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtbankname" runat="server" MaxLength="500" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtbankname" runat="server" ControlToValidate="txtbankname"
                                    ErrorMessage="Enter bank name" ValidationGroup="UpdateRequest" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvtxtbankname">
                                </ajax:ValidatorCalloutExtender>
                                 <ajax:FilteredTextBoxExtender ID="ftbebankname" runat="server" TargetControlID="txtbankname" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                             Branch Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtbranchname" runat="server" MaxLength="500" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtbranchname" runat="server" ControlToValidate="txtbranchname"
                                    ErrorMessage="Enter branch name" ValidationGroup="UpdateRequest" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvtxtbranchname">
                                </ajax:ValidatorCalloutExtender>
                                   <ajax:FilteredTextBoxExtender ID="ftbebranchname" runat="server" TargetControlID="txtbranchname" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                               Sender Name
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtsendername" runat="server" MaxLength="10" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtsendername" runat="server" ControlToValidate="txtsendername"
                                    Display="None" ErrorMessage="Please enter  sender name." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="rfvtxtsendername"
                                    runat="server">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:FilteredTextBoxExtender ID="ftbesendername" runat="server" TargetControlID="txtsendername" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
                              
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                            Sender Mobile Number:
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="10" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNumber"
                                    Display="None" ErrorMessage="Please enter sender mobile number." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobile1" TargetControlID="RequiredFieldValidator2"
                                    runat="server">
                                </ajax:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNumber"
                                    Display="None" ErrorMessage="Please enter valid mobile number." ValidationExpression="[7-9][0-9]{9}"
                                    ValidationGroup="UpdateRequest"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobile2" runat="server" TargetControlID="RegularExpressionValidator1">
                                </ajax:ValidatorCalloutExtender>
                                 <ajax:FilteredTextBoxExtender ID="ftbemobileno" runat="server" TargetControlID="txtMobileNumber" ValidChars="0123456789"></ajax:FilteredTextBoxExtender>
                            </td>
                        </tr>                 
                        <tr>
                            <td align="right" width="30%">
                                &nbsp;
                            </td>
                            <td align="left" width="30%">
                                &nbsp;
                            </td>
                        </tr>
                         <tr>
                            <td align="left"  colspan="2" width="100%">

                            <table width="100%">
                            <tr>
                            <td width="100%">
                             <asp:Label ID="Label1" runat="server" Text="* Rs.25 Will be charged for every transaction."
                               Font-Bold="true" ForeColor="red"
                              Font-Size="13px"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td width="100%">
                             <asp:Label ID="lblnote" runat="server" Text="* Note : Your transaction amount should be minimum 1000 and maximum 25000."
                               Font-Bold="true" ForeColor="Blue"
                              Font-Size="13px"></asp:Label>
                            </td>
                            </tr>
                            </table>


                             
                            </td>
                            
                        </tr>
                        <tr>
                            <td align="right" width="30%">
                                &nbsp;
                            </td>
                            <td align="left" width="30%">
                                <asp:Button ID="btnDepositUpdate" runat="server" OnClick="btnDepositUpdate_Click"
                                    Text="Submit" CssClass="buttonBook" Style="cursor: pointer;" ValidationGroup="UpdateRequest" />
                            </td>
                            <td align="left" width="40%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
</asp:Content>

