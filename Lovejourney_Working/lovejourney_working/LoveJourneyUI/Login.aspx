<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/NewStyle.css" rel="stylesheet" type="text/css" />
    


<!--  initialize the slideshow when the DOM is ready -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr><td height="8"></td></tr>
     <tr>
  <td ><table width="1000" border="0" cellspacing="0" cellpadding="0" height="372" class="lj_ctnt">
    <tr>
      <td width="540" valign="top" align="right"><table width="500" border="0" cellspacing="0" cellpadding="0" >
        <tr>
          <td align="left" valign="top"><!--form_menu-->
            <table width="440" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><table width="168" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="8" align="left"><img src="Newimages/l1.png" width="8" height="37"  /></td>
                    <td class="lj_tab_bg"><table width="152" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="35" align="left" valign="middle"><img src="images/bus.png" width="32" height="32"  /></td>
                        <td align="center" class="lj_srchagt">Admin Login</td>
                      </tr>
                    </table></td>
                    <td width="8"><img src="Newimages/l2.png" width="8" height="37"  /></td>
                  </tr>
                </table></td>
               
              </tr>
            </table>
            <!--form_menuEnd--></td>
        </tr>
     
        <tr>
          <td align="left" valign="top"><table width="480" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="10">
                                    
                                        <asp:Label ID="lblMsg" runat="server" />
                                   
                                </td>
            </tr>
            
            <tr>
              <td align="left"><table width="480" border="0" cellspacing="0" cellpadding="0">
              <tr>
              <td class="lj_user" align="left" height="30" ><strong>Username</strong></td>
              <td ></td>
              <td class="lj_user" align="left" ><strong>Password</strong></td>
            </tr>
                <tr>
                  <td width="233" align="left"><div class="lj_outDiv">
                    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                      <tr>
                        <td width="70" align="center" class="lj_bdrit"><img src="Newimages/u_i.png" width="56"
     height="32"  /></td>
                        <td align="left">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="lj_inputbox" MaxLength="50" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtUsername" Display="None" ErrorMessage="Enter Username" 
                                ValidationGroup="signin" />
                            <ajax:ValidatorCalloutExtender ID="vcerfv2" runat="server" 
                                TargetControlID="RequiredFieldValidator2">
                            </ajax:ValidatorCalloutExtender>
                          </td>
                      </tr>
                    </table>
                  </div></td>
                  <td width="10"></td>
                  <td width="233" align="left"><div class="lj_outDiv">
                    <table width="233" border="0" cellspacing="0" cellpadding="0" height="39">
                      <tr>
                        <td width="70" align="center" class="lj_bdrit">
                            <img src="Newimages/p_i.png" width="56"
     height="32"  /></td>
                        <td align="left">
                            <asp:TextBox ID="txtPasword" runat="server" CssClass="lj_inputbox" MaxLength="50" 
                                TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtPasword" Display="None" ErrorMessage="Enter Password" 
                                ValidationGroup="signin" />
                            <ajax:ValidatorCalloutExtender ID="vcerfv1" runat="server" 
                                TargetControlID="RequiredFieldValidator1">
                            </ajax:ValidatorCalloutExtender>
                          </td>
                      </tr>
                    </table>
                  </div></td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="10"></td>
            </tr>
            <tr>
              <td height="5"></td>
            </tr>
            <tr>
              <td align="left" valign="top"><table width="480" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="400" valign="top">&nbsp;</td>
                  <td width="80" valign="bottom">
                 <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="lj_button" ValidationGroup="signin"
                                                        OnClick="btnSignIn_Click" />
                  </td>
                </tr>

                <tr>
                  <td width="400" valign="top">&nbsp;</td>
                  <td width="80" valign="bottom" height="25">
                  <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ForgotPassword.aspx" ForeColor="White">Forgot Password?</asp:HyperLink>
                  </td>
                </tr>

              </table></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
            </tr>
          </table></td>
        </tr>
      </table></td>
      <td width="3"></td>
      <td width="457" class="lj_banner_bg" align="left">    
     <iframe src="frame.html" scrolling="no" frameborder="0" width="457" height="372" ></iframe>
    
    
 
      
    </td>
    </tr>
  </table></td>
  </tr>
  <tr><td height="10"></td></tr>
  </table>
 </asp:Content>
