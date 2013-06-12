<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Users_ChangePassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
         
        <tr>
            <%--<td width="100%" align="center">
                <div id="divChangePassword" runat="server" visible="true">
                  
                        <table width="100%">
                            <tr>
                                <td align="right" width="30%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    Current Password:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtCurrentPassword" MaxLength="50" runat="server" 
                                        Width="200px" ValidationGroup="ChangePassword" TextMode="Password"  CssClass="textfield_sleep" ></asp:TextBox>
                                </td>
                                <td align="left" width="30%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please enter current password."
                                        ControlToValidate="txtCurrentPassword" Display="None" 
                                        ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCurrentPassword" runat="server" TargetControlID="RequiredFieldValidator13"></ajax:ValidatorCalloutExtender>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                   New Password:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtPassword" MaxLength="50" runat="server" Width="200px" 
                                        ValidationGroup="ChangePassword"  CssClass="textfield_sleep"  TextMode="Password"></asp:TextBox>
                                </td>
                                <td align="left" width="30%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please enter password."
                                        ControlToValidate="txtPassword" Display="None" 
                                        ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceNewPassword" runat="server" TargetControlID="RequiredFieldValidator14"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    Confirm Password:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtConfirmPassword"  CssClass="textfield_sleep"  MaxLength="50" runat="server" Width="200px"
                                        ValidationGroup="ChangePassword" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"  Display="None" ValidationGroup="ChangePassword" ErrorMessage="Enter ConFirm Password"></asp:RequiredFieldValidator>
                                         <ajax:ValidatorCalloutExtender ID="vceConfirmPassword1" runat="server" TargetControlID="rfvConfirmPassword"></ajax:ValidatorCalloutExtender>
                                </td>
                                <td align="left" width="30%">
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Confim password and password mismatch."
                                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="None"
                                        ValidationGroup="ChangePassword"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceConfirmPassword" runat="server" TargetControlID="CompareValidator5"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click"
                                        ValidationGroup="ChangePassword" Style="cursor: pointer;"  CssClass="buttonBook"/>
                                </td>
                                <td align="left" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                   <%-- </fieldset>--%>
              
           <td valign="top" align="left">
                <asp:Panel ID="Panel1"  runat="server">
                    
                    <table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="../../images/formtop_left.png" /></td>
    <td class="form_top" width="347"></td>
    <td align="left" valign="bottom" width="29" height="23"><img src="../../images/formright_top.png" /></td>
  </tr>


  <tr>
    <td class="form_left"></td>
    <td width="347" align="left" valign="top" bgcolor="#ffffff" >
    
    <table width="347" cellpadding="0" cellspacing="0" border="0">
     <tr>
                                    <td valign="top" height="20" align="left">
                                       <table width="347" height="45" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50"><img src="../../images/print_t.png" width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Change Password</td>
  </tr>
</table>
                                    </td>
                                </tr>


       <tr>
           <td height="12" colspan="2" class="border_top">
                  &nbsp;</td>
        </tr>
        

     
     <tr>
                                <td align="center" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Current Password:
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                        <asp:TextBox ID="txtCurrentPassword" MaxLength="50" runat="server" 
                                        Width="200px" ValidationGroup="ChangePassword" TextMode="Password"  CssClass="textfield_sleep" ></asp:TextBox>
                                                        

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please enter current password."
                                        ControlToValidate="txtCurrentPassword" Display="None" 
                                        ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCurrentPassword" runat="server" TargetControlID="RequiredFieldValidator13"></ajax:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                                

                                 <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        New  Password:
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtPassword" MaxLength="50" runat="server" Width="200px" 
                                        ValidationGroup="ChangePassword"  CssClass="textfield_sleep"  TextMode="Password"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please enter password."
                                        ControlToValidate="txtPassword" Display="None" 
                                        ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceNewPassword" runat="server" TargetControlID="RequiredFieldValidator14"></ajax:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                               

                               <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Confirm  Password:
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtConfirmPassword"  CssClass="textfield_sleep"  MaxLength="50" runat="server" Width="200px"
                                        ValidationGroup="ChangePassword" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"  Display="None" ValidationGroup="ChangePassword" ErrorMessage="Enter ConFirm Password"></asp:RequiredFieldValidator>
                                         <ajax:ValidatorCalloutExtender ID="vceConfirmPassword1" runat="server" TargetControlID="rfvConfirmPassword"></ajax:ValidatorCalloutExtender>
                                          <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Confim password and password mismatch."
                                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="None"
                                        ValidationGroup="ChangePassword"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceConfirmPassword" runat="server" TargetControlID="CompareValidator5"></ajax:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                                 

                                 

                                <tr>
                                 <td colspan="3">
                                  <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click"
                                        ValidationGroup="ChangePassword" Style="cursor: pointer;"  CssClass="buttonBook"/>
                                 </td>
                                </tr>

                                

                                

                                 </table>
                                </td>
                                </tr>
     

   

    </table>
    </td>
    <td class="form_right"></td>
  </tr>



  <tr>
    <td align="center" valign="top" width="24" height="32"><img src="../../images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="../../images/formright_bottom.png" /></td>
  </tr>

</table>
                </asp:Panel>
              
            </td>


        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
    </table>
</asp:Content>
