﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmploymentLogin.aspx.cs" Inherits="EmploymentLogin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <td width="50"><img src="images/agent_reg.png"  width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Employment Registration</td>
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
                                        Name
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtName" MaxLength="50" runat="server" CssClass="lj_inp"
                                                                                ValidationGroup="Submit" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                                                                Display="None" ErrorMessage="Please enter your name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender id="vceName" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                                                                <ajax:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID = "txtName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>

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
                                          <asp:TextBox ID="txtEmailId" MaxLength="500" runat="server" CssClass="lj_inp"
                                                                                ValidationGroup="Submit" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmailId"
                                                                                Display="None" ErrorMessage="Please enter your email id." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceEmailid1" runat="server" TargetControlID="RequiredFieldValidator2"></ajax:ValidatorCalloutExtender>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId"
                                                                                Display="Dynamic" ErrorMessage="Please enter correct email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceEmailid12" runat="server" TargetControlID="RegularExpressionValidator1"></ajax:ValidatorCalloutExtender>
                                                       
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
                                          <asp:TextBox ID="txtOrganization" runat="server" CssClass="lj_inp" MaxLength="500"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOrganization"
                                                                                Display="None" ErrorMessage="Please type of organization." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceOrganization" runat="server" TargetControlID="RequiredFieldValidator3"></ajax:ValidatorCalloutExtender>
                                                       
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
                                          <asp:TextBox ID="txtMobileNo" runat="server" CssClass="lj_inp" MaxLength="10"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
                                                                                Display="None" ErrorMessage="Please enter mobile no." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceMobileNo" runat="server" TargetControlID="RequiredFieldValidator4"></ajax:ValidatorCalloutExtender>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNo"
                                                                                Display="None" ErrorMessage="Please enter valid mobile no." ValidationGroup="Submit"
                                                                                ValidationExpression="[7-9][0-9]{9}"></asp:RegularExpressionValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vceRegularExpression" runat="server" TargetControlID="RegularExpressionValidator2"></ajax:ValidatorCalloutExtender>
                                                       
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
                                           <asp:TextBox ID="txtCity" runat="server" CssClass="lj_inp" MaxLength="100"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                                                                                Display="None" ErrorMessage="Please enter city name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="vceCity" TargetControlID="RequiredFieldValidator5" runat="server"></ajax:ValidatorCalloutExtender>
                                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                        District</td>
                                    <td height="28" align="center" class="ft01">
                                        &nbsp;</td>
                                    <td height="28" align="left">
                                           <asp:TextBox ID="txtDistrict" runat="server" CssClass="lj_inp" MaxLength="100"
                                                                                ValidationGroup="Submit"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDistrict"
                                                                                Display="None" ErrorMessage="Please enter district name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator7" runat="server"></ajax:ValidatorCalloutExtender></td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                     State
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                           <asp:DropDownList ID="ddlState" runat="server" ValidationGroup="Submit" CssClass="lj_inp">
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
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlState"
                                                                                Display="None" ErrorMessage="Please select state." InitialValue="Please Select"
                                                                                ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vcestate" runat="server" TargetControlID="RequiredFieldValidator6"></ajax:ValidatorCalloutExtender>
                                                       
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
                                       <asp:Button ID="btnSignIn" runat="server" Text="Submit" CssClass="buttonBook"
                                                                                ValidationGroup="Submit"/>
                                                                          
                                                           

                                                        

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

</asp:Content>

