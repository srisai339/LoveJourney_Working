<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/NewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<table width="1004" cellpadding="0" cellspacing="0" border="0">
     <tr>
       <td height="520" valign="top">
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSignIn">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: White;">
                     <tr>
                        <td class="heading" valign="top" align="center">
                            <asp:Label ID="lblheadingt" runat="server" Text="Forgot Password" Font-Bold="false"
                                Font-Size="16px"></asp:Label>
                        </td>
                    </tr>
                        <tr>
                            <td colspan="2" height="7" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="20" align="center">
                                <asp:Label ID="lblMsg" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="100%">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="right" width="50%" class="p_nme">
                                                        Username
                                                    </td>
                                                    <td align="left" height="34" width="50%">
                                                        <asp:TextBox ID="txtUsername" MaxLength="50" runat="server" CssClass="lj_inp"/>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Enter Username"
                                                            ControlToValidate="txtUsername" runat="server" Display="None" ValidationGroup="signin" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator2">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="50%" class="p_nme">
                                                        Email Id
                                                    </td>
                                                    <td align="left" height="34" width="50%">
                                                        <asp:TextBox ID="txtPasword" MaxLength="50" runat="server" CssClass="lj_inp" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please enter email id."
                                                            ControlToValidate="txtPasword" runat="server" Display="None" ValidationGroup="signin" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid email id."
                                                            ControlToValidate="txtPasword" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="signin"></asp:RegularExpressionValidator>
                                                        <ajax:ValidatorCalloutExtender ID="RegularExpressionValidator1_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1"
                                                          >
                                                        </ajax:ValidatorCalloutExtender>
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1"
                                                            
                                                           >
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="50%" class="p_nme">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="50%">
                                                        <asp:Button ID="btnSignIn" runat="server" Text="Submit" CssClass="buttonBook"
                                                            ValidationGroup="signin" OnClick="btnSignIn_Click" />
                                                        <br />
                                                        <br />
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Click here to Login.</asp:HyperLink>
                                                        <br />
                                                        <br />
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
            </td>
        </tr>
    </table>
     </td>
    </tr>
    </table>--%>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
     <tr>
       <td height="520" valign="top">
    
        <table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="images/formtop_left.png" /></td>
    <td class="form_top" width="347"></td>
    <td align="left" valign="bottom" width="29" height="23"><img src="images/formright_top.png" /></td>
  </tr>


  <tr>
    <td class="form_left"></td>
    <td width="347" align="left" valign="top"  bgcolor="#ffffff" >
    
    <table width="347" cellpadding="0" cellspacing="0" border="0">
     <tr>
                                    <td valign="top" height="20" align="left">
                                       <table width="347" height="45" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50"><img src="images/fp.png" width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Forgot Password</td>
  </tr>
</table>
                                    </td>
                                </tr>


       <tr>
           <td height="12" colspan="2" class="border_top">
                  &nbsp;</td>
        </tr>
        <tr>
                            <td colspan="2"  align="center">
                            <%--<asp:Label ID="lblheadingt" runat="server" Text="Forgot Password" Font-Bold="false"
                                Font-Size="16px"></asp:Label>--%>
                                <asp:Label ID="lblMsg" runat="server" />
                            </td>
                        </tr>

     
     <tr>
                                <td align="center" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        User Name
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                      <asp:TextBox ID="txtUsername" MaxLength="50" runat="server" CssClass="lj_inp"/>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Enter Username"
                                                            ControlToValidate="txtUsername" runat="server" Display="None" ValidationGroup="signin" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator2">
                                                        </ajax:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                        Email Id
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                         <asp:TextBox ID="txtPasword" MaxLength="50" runat="server" CssClass="lj_inp" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please enter email id."
                                                            ControlToValidate="txtPasword" runat="server" Display="None" ValidationGroup="signin" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid email id."
                                                            ControlToValidate="txtPasword" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="signin"></asp:RegularExpressionValidator>
                                                        <ajax:ValidatorCalloutExtender ID="RegularExpressionValidator1_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1"
                                                          >
                                                        </ajax:ValidatorCalloutExtender>
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1"
                                                            
                                                           >
                                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                     <asp:Button ID="btnSignIn" runat="server" Text="Submit" CssClass="buttonBook"
                                                            ValidationGroup="signin" OnClick="btnSignIn_Click" />

                                    </td>
                                 </tr>



                                 <tr>
                                 <td colspan="3" align="center" class="forgot" >  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Click here to Login.</asp:HyperLink></td>

                        
                                 </tr>
                                 

                                

                                

                                

                                 </table>
                                </td>
                                </tr>


   

    </table>
    </td>
    <td class="form_right"></td>
  </tr>



  <tr>
    <td align="center" valign="top" width="24" height="32"><img src="images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="images/formright_bottom.png" /></td>
  </tr>

</table>                                      

        </td>
    </tr>
    </table>


</asp:Content>
