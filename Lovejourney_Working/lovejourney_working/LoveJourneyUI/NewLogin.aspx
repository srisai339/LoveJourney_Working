<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewLogin.aspx.cs" Inherits="NewLogin" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .lj_inputbox
{
	border:none;
	outline:none;
	background:#fff;
	width:159px;
	padding:9px 5px;
	font-size:14px;
	color:#ba211a;
	line-height:18px;
}
    .style1
    {
        border-top: #057db9 solid 3px;
        height: 12px;
    }
</style>
<%--<script type="text/javascript">
    $(function () {

        $("input").live("keypress", function (keyarg) {
            if (keyarg.keyCode == 13) { //Enter keycodex
                return false;
            }
        });

    });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <asp:UpdatePanel ID="uppanel" runat="server">
   <ContentTemplate>--%>
  <table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
     <td>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
     <tr>
       <td height="320" valign="top">
    
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
    <td width="50"><img src="images/agent_reg.png"  width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Corporate  Login</td>
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
                                       <asp:TextBox ID="txtCorlogname" runat="server" CssClass="lj_inp" MaxLength="50" TabIndex="1" 
                                             />
                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtCorlogname" Display="None" ErrorMessage="Enter Username" 
                                ValidationGroup="submit4" />
                            <ajax:ValidatorCalloutExtender ID="vcerfv2" runat="server" 
                                TargetControlID="RequiredFieldValidator2">
                            </ajax:ValidatorCalloutExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                  Password
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtcorlogPasword" runat="server" CssClass="lj_inp" MaxLength="50"  TabIndex="2"
                                TextMode="Password" />
                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtcorlogPasword" Display="None" ErrorMessage="Enter Password" 
                                ValidationGroup="submit4" />
                            <ajax:ValidatorCalloutExtender ID="vcerfv1" runat="server" 
                                TargetControlID="RequiredFieldValidator1">
                            </ajax:ValidatorCalloutExtender>--%>
                                    </td>
                                </tr>

                              
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                       <asp:Button ID="btncorlog" runat="server" Text="Submit" CssClass="buttonBook" TabIndex="3"
                                                                                ValidationGroup="submit4" 
                                            onclick="btncorlog_Click" />
                                                                          
                                                           

                                                        

                                    </td>
                                    </tr>
                                    <tr>
                                        <td  height="40"  valign="middle"  align="center" colspan="3">
                                      <asp:LinkButton ID="lbtnNewUser" runat="server" Text="New Corporate"  TabIndex="4"
                                                onclick="lbtnNewUser_Click" ></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                       <asp:LinkButton ID="lnkUserForget" runat="server" Text="Forgot password?" PostBackUrl="~/ForgotPassword.aspx" TabIndex="5"></asp:LinkButton>
                                       </td>
                                                                          
                                    </tr>
                                   
                                                           

                                                        

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
    <td align="center" valign="top" width="24" height="32"><img src="images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="images/formright_bottom.png" /></td>
  </tr>

</table>                                      

        </td>
        
        <td height="320" valign="top">
    
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
    <td width="50"><img src="images/agent_reg.png"  width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Employee Login</td>
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
                                <asp:Label ID="lblEmpMsg" runat="server" />
                            </td>
                        </tr>

     
     <tr>
                                <td align="center" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                       Employee Name
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtEmpLoginName" runat="server" CssClass="lj_inp" MaxLength="50" TabIndex="6" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtEmpLoginName" Display="None" ErrorMessage="Enter Username" 
                                ValidationGroup="submit3" />
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                TargetControlID="RequiredFieldValidator5">
                            </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                  Password
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtEmpPassword" runat="server" CssClass="lj_inp"  AutoPostBack="true"
                                              MaxLength="50"  TabIndex="7"
                                TextMode="Password" ontextchanged="txtEmpPassword_TextChanged" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtEmpPassword" Display="None" ErrorMessage="Enter Password" 
                                ValidationGroup="submit3" />
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                                TargetControlID="RequiredFieldValidator6">
                            </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>

                              
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                       <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="buttonBook" TabIndex="8" 
                                                                                ValidationGroup="submit3" 
                                            onclick="Button2_Click" />
                                                                          
                                                           

                                                        

                                    </td>
                                 </tr>
                                 <tr>
                                        <td  height="40"  valign="middle"  align="center" colspan="3">
                                      <asp:LinkButton ID="lnkNewEmployee" runat="server" Text="New Employee"  TabIndex="9"
                                                onclick="lnkNewEmployee_Click" ></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                       <asp:LinkButton ID="LinkButton4" runat="server" Text="Forgot password?" PostBackUrl="~/ForgotPassword.aspx" TabIndex="10"></asp:LinkButton>
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
    <td align="center" valign="top" width="24" height="32"><img src="images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="images/formright_bottom.png" /></td>
  </tr>

</table>                                      

        </td>
    </tr>
    <tr>
       <td  colspan="3" align="center" >
        <asp:Panel ID="pnlEmployee" runat="server" Visible="false">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
     <tr>
       <td height="520" valign="top" align="center">
    
        <table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="images/formtop_left.png" /></td>
    <td class="form_top" width="347"></td>
    <td align="left" valign="bottom" width="29" height="23"><img src="images/formright_top.png" /></td>
  </tr>


  <tr>
    <td class="form_left"></td>
    <td width="347" align="center" valign="top"  bgcolor="#ffffff" >
    
    <table width="347" cellpadding="0" cellspacing="0" border="0">
     <tr>
                                    <td valign="top" height="20" align="center">
                                       <table width="347" height="45" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50"><img src="images/user_reg.png" width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Employee Registration</td>
  </tr>
</table>
                                    </td>
                                </tr>


       <tr>
           <td colspan="2" class="style1">
                  </td>
        </tr>
        <tr>
                            <td colspan="2"  align="center">
                                <asp:Label ID="lblEmp" runat="server" />
                            </td>
                        </tr>

     
     <tr>
                                <td align="center" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Name
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtEmpName" MaxLength="50" runat="server" CssClass="lj_inp"
                                                                                ValidationGroup="Submit" />
                                                                            <asp:RequiredFieldValidator ID="rfvEmpName" runat="server" ControlToValidate="txtEmpName"
                                                                                Display="None" ErrorMessage="Please enter your name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender id="vceName" runat="server" TargetControlID="rfvEmpName"></ajax:ValidatorCalloutExtender>
                                                                                <ajax:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID = "txtEmpName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
                                                                                
                                                      

                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Qualification
                                        </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtQualification" MaxLength="50" runat="server" CssClass="lj_inp"
                                                                                ValidationGroup="Submit" />
                                                                            <asp:RequiredFieldValidator ID="rfvQualification" runat="server" ControlToValidate="txtQualification"
                                                                                Display="None" ErrorMessage="Please enter your Qualification." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender id="ValidatorCalloutExtender6" runat="server" TargetControlID="rfvQualification"></ajax:ValidatorCalloutExtender>
                                                                           
                                                                                
                                                      

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
                                         <asp:TextBox ID="txtEmpEmail" MaxLength="500" runat="server" CssClass="lj_inp"
                                                                                ValidationGroup="Submit" />
                                                                            <asp:RequiredFieldValidator ID="rfvEmpMail" runat="server" ControlToValidate="txtEmpEmail"
                                                                                Display="None" ErrorMessage="Please enter your email id." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceEmailid1" runat="server" TargetControlID="rfvEmpMail"></ajax:ValidatorCalloutExtender>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmpEmail"
                                                                                Display="Dynamic" ErrorMessage="Please enter correct email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceEmailid12" runat="server" TargetControlID="RegularExpressionValidator1"></ajax:ValidatorCalloutExtender>
                                                       
                                    </td>
                                </tr>

                               <%-- <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                   User Name
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtEmpUserName" runat="server" CssClass="lj_inp" MaxLength="500"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvEmpUserName" runat="server" ControlToValidate="txtEmpUserName"
                                                                                Display="None" ErrorMessage="Please Enter User Name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceOrganization" runat="server" TargetControlID="rfvEmpUserName"></ajax:ValidatorCalloutExtender>
                                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                   Password
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                           <asp:TextBox ID="txtEmpPassword1" runat="server" CssClass="lj_inp" MaxLength="500" TextMode="Password"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvEmpPassword" runat="server" ControlToValidate="txtEmpPassword1"
                                                                                Display="None" ErrorMessage="Please Enter Password." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="rfvEmpPassword"></ajax:ValidatorCalloutExtender>
                                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                   Confirm Password
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                           <asp:TextBox ID="txtEmpconfirmPassword" runat="server" CssClass="lj_inp" MaxLength="500" TextMode="Password"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvEmpConfirmPassword" runat="server" ControlToValidate="txtEmpconfirmPassword"
                                                                                Display="None" ErrorMessage="Please Enter Confirm  Password." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rfvEmpConfirmPassword"></ajax:ValidatorCalloutExtender>
                                                                            <asp:CompareValidator ID="cmpConfirmpassword" runat="server" ControlToValidate="txtEmpconfirmPassword"
                                                                                ValidationGroup="Submit" ControlToCompare="txtEmpPassword1" ErrorMessage="Password And Confirm Password must be match"
                                                                                Display="None"></asp:CompareValidator>
                                                                             <ajax:ValidatorCalloutExtender ID="vceCompare" TargetControlID="cmpConfirmpassword" runat="server"></ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>--%>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                   Mobile No
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtEmpMobileNo" runat="server" CssClass="lj_inp" MaxLength="10"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvEmpMobileNo" runat="server" ControlToValidate="txtEmpMobileNo"
                                                                                Display="None" ErrorMessage="Please enter mobile no." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceMobileNo" runat="server" TargetControlID="rfvEmpMobileNo"></ajax:ValidatorCalloutExtender>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmpMobileNo"
                                                                                Display="None" ErrorMessage="Please enter valid mobile no." ValidationGroup="Submit"
                                                                                ValidationExpression="[7-9][0-9]{9}"></asp:RegularExpressionValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceRegularExpression" runat="server" TargetControlID="RegularExpressionValidator2"></ajax:ValidatorCalloutExtender>
                                                                            <ajax:FilteredTextBoxExtender ID="ftemob" runat="server" TargetControlID="txtEmpMobileNo" ValidChars="0123456789"></ajax:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                 
                               <tr>
                                    <td height="28" align="left" class="lj_hd12">
                         Address
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                           <asp:TextBox ID="txtEmpAddress" runat="server" CssClass="lj_inp"  MaxLength="100"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvEmpAddress" runat="server" ControlToValidate="txtEmpAddress"
                                                                                Display="None" ErrorMessage="Please Enter Address." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="vceCity" TargetControlID="rfvEmpAddress" runat="server"></ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>


                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                   City
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtEmpCity" runat="server" CssClass="lj_inp"  MaxLength="100"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvEmpCity" runat="server" ControlToValidate="txtEmpCity"
                                                                                Display="None" ErrorMessage="Please Enter City Name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" TargetControlID="rfvEmpCity" runat="server"></ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
            State
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="30" align="left">
                                          <asp:DropDownList ID="ddlState" runat="server" ValidationGroup="Submit" CssClass="lj_inp" Width="170">
                                                                                <asp:ListItem>Please Select</asp:ListItem>
                                                                                <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                                                                                <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Assam</asp:ListItem>
                                                                                <asp:ListItem>Bihar</asp:ListItem>
                                                                                <asp:ListItem>Chandigarh</asp:ListItem>
                                                                                <asp:ListItem>Chattisgarh</asp:ListItem>
                                                                                <asp:ListItem>Dadra and Nagar Haveli</asp:ListItem>
                                                                                <asp:ListItem>Daman and Diu</asp:ListItem>
                                                                                <asp:ListItem>Delhi</asp:ListItem>
                                                                                <asp:ListItem>Goa</asp:ListItem>
                                                                                <asp:ListItem>Gujarat</asp:ListItem>
                                                                                <asp:ListItem>Haryana</asp:ListItem>
                                                                                <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                                                                <asp:ListItem>Jharkhand</asp:ListItem>
                                                                                <asp:ListItem>Karnataka</asp:ListItem>
                                                                                <asp:ListItem>Kerala</asp:ListItem>
                                                                                <asp:ListItem>Lakshadweep</asp:ListItem>
                                                                                <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Maharashtra</asp:ListItem>
                                                                                <asp:ListItem>Manipur</asp:ListItem>
                                                                                <asp:ListItem>Meghalaya</asp:ListItem>
                                                                                <asp:ListItem>Mizoram</asp:ListItem>
                                                                                <asp:ListItem>Nagaland</asp:ListItem>
                                                                                <asp:ListItem>Orissa</asp:ListItem>
                                                                                <asp:ListItem>Puducherry</asp:ListItem>
                                                                                <asp:ListItem>Punjab</asp:ListItem>
                                                                                <asp:ListItem>Rajasthan</asp:ListItem>
                                                                                <asp:ListItem>Sikkim</asp:ListItem>
                                                                                <asp:ListItem>Tamil Nadu</asp:ListItem>
                                                                                <asp:ListItem>Tripura</asp:ListItem>
                                                                                <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Uttarakhand</asp:ListItem>
                                                                                <asp:ListItem>West Bengal</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvEmpState" runat="server" ControlToValidate="ddlState"
                                                                                Display="None" ErrorMessage="Please select state." InitialValue="Please Select"
                                                                                ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vcestate" runat="server" TargetControlID="rfvEmpState"></ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>


                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                Country
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="35" align="left">
                                          <asp:DropDownList ID="ddlEmpcountry" runat="server" ValidationGroup="Submit" CssClass="lj_inp" Width="170">
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
                                                                            <asp:RequiredFieldValidator ID="rfvEmpCountry" runat="server" ControlToValidate="ddlEmpcountry"
                                                                                Display="None" ErrorMessage="Please select Country." InitialValue="Please Select"
                                                                                ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="rfvEmpCountry"></ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                

                                <tr>
                                    <td height="28" align="left" class="lj_hd12" valign="top">
                   Pin Code
                                    </td>
                                    <td height="28" align="center" class="ft01" valign="top">
                                        :
                                    </td>
                                    <td height="28" align="left"  valign="bottom">
                                         <asp:TextBox ID="txtEmpPinCode" MaxLength="6" runat="server" CssClass="lj_inp"
                                                                                ValidationGroup="Submit" 
                                              />
                                                                            <asp:RequiredFieldValidator ID="rfvEmpPincode" runat="server" ControlToValidate="txtEmpPinCode"
                                                                                Display="None" ErrorMessage="Please Enter Pincode." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender id="ValidatorCalloutExtender9" runat="server" TargetControlID="rfvEmpPincode"></ajax:ValidatorCalloutExtender>
                                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID = "txtEmpPinCode" ValidChars="1234567890"></ajax:FilteredTextBoxExtender>
                                                                          
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12" valign="top">
                 Upload your Scanned Resume
                                    </td>
                                    <td height="28" align="center" class="ft01" valign="top">
                                        :
                                    </td>
                                    <td height="28" align="left"  valign="bottom">
                                          <asp:FileUpload ID="fuImage" runat="server" CssClass="lj_inp"   /><br />
                                    <asp:RequiredFieldValidator ID="rfvResume" runat="server" ControlToValidate="fuImage"
                                        Display="None" ErrorMessage="Please Upload your Resume." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vce7" runat="server" TargetControlID="rfvResume"></ajax:ValidatorCalloutExtender>
                                  
                                    </td>

                                    
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12" valign="top">
                 Upload  Qualification Document
                                    </td>
                                    <td height="28" align="center" class="ft01" valign="top">
                                        :
                                    </td>
                                    <td height="28" align="left"  valign="bottom">
                                          <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="lj_inp"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1"
                                        Display="None" ErrorMessage="Please Upload Your Latest Document." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator3"></ajax:ValidatorCalloutExtender>
                                    
                                    </td>
                                </tr>


                                 <tr>
                                 




                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                       <asp:Button ID="btnEmp" runat="server" Text="Submit" CssClass="buttonBook"
                                                                                ValidationGroup="Submit" onclick="btnEmp_Click" 
                                             />&nbsp;&nbsp;
                                                           

                                                        
                                                        <asp:Button ID="btnEmpCancel" runat="server" Text="Cancel" CssClass="buttonBook" CausesValidation="false"
                                                                               
                                            onclick="btnEmpCancel_Click"  />
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
    <td align="center" valign="top" width="24" height="32"><img src="images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="images/formright_bottom.png" /></td>
  </tr>

</table>                                      

        </td>
    </tr>
    </table>
         
        </asp:Panel>

        <asp:Panel ID="pnlCoorporate" runat="server" Visible="false">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
     <tr>
       <td height="520" valign="top" align="center">
    
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
                                    <td valign="top" height="20" align="center">
                                       <table width="347" height="45" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50"><img src="images/agent_reg.png"  width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Corporate Registration</td>
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
                                <asp:Label ID="lblCorporate" runat="server"/>
                            </td>
                        </tr>

     
     <tr>
                                <td align="center" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Name
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtCorName" MaxLength="50" runat="server" CssClass="lj_inp"
                                                                                ValidationGroup="Submit" />
                                                                            <asp:RequiredFieldValidator ID="rfvCorName" runat="server" ControlToValidate="txtCorName"
                                                                                Display="None" ErrorMessage="Please enter your name." ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender id="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvCorName"></ajax:ValidatorCalloutExtender>
                                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID = "txtCorName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>

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
                                          <asp:TextBox ID="txtCorEmail" MaxLength="500" runat="server" CssClass="lj_inp"
                                                                                ValidationGroup="Submit" />
                                                                            <asp:RequiredFieldValidator ID="rfvCorEmail" runat="server" ControlToValidate="txtCorEmail"
                                                                                Display="None" ErrorMessage="Please enter your email id." ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvCorEmail"></ajax:ValidatorCalloutExtender>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCorEmail"
                                                                                Display="Dynamic" ErrorMessage="Please enter correct email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                ValidationGroup="Submit1"></asp:RegularExpressionValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RegularExpressionValidator3"></ajax:ValidatorCalloutExtender>
                                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                 Organization
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtcorOrganization" runat="server" CssClass="lj_inp" MaxLength="500"
                                                                                ValidationGroup="Submit1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvCorOrganization" runat="server" ControlToValidate="txtcorOrganization"
                                                                                Display="None" ErrorMessage="Please type of organization." ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="rfvCorOrganization"></ajax:ValidatorCalloutExtender>
                                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                           Mobile No
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtCorMobileNo" runat="server" CssClass="lj_inp" MaxLength="10"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvCorMobileNo" runat="server" ControlToValidate="txtCorMobileNo"
                                                                                Display="None" ErrorMessage="Please enter mobile no." ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="rfvCorMobileNo"></ajax:ValidatorCalloutExtender>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCorMobileNo"
                                                                                Display="None" ErrorMessage="Please enter valid mobile no." ValidationGroup="Submit1"
                                                                                ValidationExpression="[7-9][0-9]{9}"></asp:RegularExpressionValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="RegularExpressionValidator4"></ajax:ValidatorCalloutExtender>
                                                                            <ajax:FilteredTextBoxExtender id="ftecormob" runat="server" TargetControlID="txtCorMobileNo" ValidChars="0123456789"></ajax:FilteredTextBoxExtender>
                                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                          City
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                           <asp:TextBox ID="txtCorCity" runat="server" CssClass="lj_inp" MaxLength="100"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvCorCity" runat="server" ControlToValidate="txtCorCity"
                                                                                Display="None" ErrorMessage="Please enter city name." ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" TargetControlID="rfvCorCity" runat="server"></ajax:ValidatorCalloutExtender>
                                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                        District</td>
                                    <td height="28" align="center" class="ft01">
                                        &nbsp;</td>
                                    <td height="28" align="left">
                                           <asp:TextBox ID="txtCorDist" runat="server" CssClass="lj_inp" MaxLength="100"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvCorDist" runat="server" ControlToValidate="txtCorDist"
                                                                                Display="None" ErrorMessage="Please enter district name." ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" TargetControlID="rfvCorDist" runat="server"></ajax:ValidatorCalloutExtender></td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                     State
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                           <asp:DropDownList ID="ddlCorState" runat="server" ValidationGroup="Submit" CssClass="lj_inp">
                                                                                <asp:ListItem>Please Select</asp:ListItem>
                                                                                <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                                                                                <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Assam</asp:ListItem>
                                                                                <asp:ListItem>Bihar</asp:ListItem>
                                                                                <asp:ListItem>Chandigarh</asp:ListItem>
                                                                                <asp:ListItem>Chattisgarh</asp:ListItem>
                                                                                <asp:ListItem>Dadra and Nagar Haveli</asp:ListItem>
                                                                                <asp:ListItem>Daman and Diu</asp:ListItem>
                                                                                <asp:ListItem>Delhi</asp:ListItem>
                                                                                <asp:ListItem>Goa</asp:ListItem>
                                                                                <asp:ListItem>Gujarat</asp:ListItem>
                                                                                <asp:ListItem>Haryana</asp:ListItem>
                                                                                <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                                                                <asp:ListItem>Jharkhand</asp:ListItem>
                                                                                <asp:ListItem>Karnataka</asp:ListItem>
                                                                                <asp:ListItem>Kerala</asp:ListItem>
                                                                                <asp:ListItem>Lakshadweep</asp:ListItem>
                                                                                <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Maharashtra</asp:ListItem>
                                                                                <asp:ListItem>Manipur</asp:ListItem>
                                                                                <asp:ListItem>Meghalaya</asp:ListItem>
                                                                                <asp:ListItem>Mizoram</asp:ListItem>
                                                                                <asp:ListItem>Nagaland</asp:ListItem>
                                                                                <asp:ListItem>Orissa</asp:ListItem>
                                                                                <asp:ListItem>Puducherry</asp:ListItem>
                                                                                <asp:ListItem>Punjab</asp:ListItem>
                                                                                <asp:ListItem>Rajasthan</asp:ListItem>
                                                                                <asp:ListItem>Sikkim</asp:ListItem>
                                                                                <asp:ListItem>Tamil Nadu</asp:ListItem>
                                                                                <asp:ListItem>Tripura</asp:ListItem>
                                                                                <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Uttarakhand</asp:ListItem>
                                                                                <asp:ListItem>West Bengal</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvCorState" runat="server" ControlToValidate="ddlCorState"
                                                                                Display="None" ErrorMessage="Please select state." InitialValue="Please Select"
                                                                                ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="rfvCorState"></ajax:ValidatorCalloutExtender>
                                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                      Comments
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtComments" runat="server" CssClass="lj_inp" TextMode="MultiLine"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                    </td>
                                </tr>
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                       <asp:Button ID="btnCoorporate" runat="server" Text="Submit" CssClass="buttonBook"
                                                                                ValidationGroup="Submit1" onclick="btnCoorporate_Click" 
                                            />&nbsp;&nbsp;

                                            <asp:Button ID="btnCoorporateCancel" runat="server" Text="Cancel" CssClass="buttonBook" CausesValidation="false"
                                                                                onclick="btnCoorporateCancel_Click" 
                                           />
                                                                          
                                                           

                                                            

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
    <td align="center" valign="top" width="24" height="32"><img src="images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="images/formright_bottom.png" /></td>
  </tr>

</table>                                      

        </td>
    </tr>
    </table>
         
        </asp:Panel>
       </td>
    </tr>


    </table>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>

    

   
   

    

   
    </table>

    

   
   

    

   
</asp:Content>

