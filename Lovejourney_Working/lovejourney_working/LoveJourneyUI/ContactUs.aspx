<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/NewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<table width="1004" cellpadding="0" cellspacing="0" border="0">
     <tr>
       <td height="520" valign="top">
    <table width="100%" bgcolor="white">
        <tr>
            <td width="50%" valign="top">
                <table width="100%">
                    <tr>
                        <td width="100%" align="left" class="heading" style="padding-left:5px;">
                            Contact Us<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="left" style="padding-left: 50px; font-family: Arial,verdana;
                            font-size: 12px; line-height: 20px;">
                            <p>
                                <span style="color: Maroon; font-size: 13px; font-family: Arial; font-weight: bold;">
                                    </span><br />
                                Ph: 080 - 32 56 17 27&nbsp;
                                <br />
                                info@lovejourney.in
                                <br />
                                www.lovejourney.in
                            </p>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%" valign="top">
                <asp:UpdatePanel ID="upfeedback" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsubmit" />
                    </Triggers>
                    <ContentTemplate>
                        <script type="text/javascript">

                            function validateLimit(obj, divID, maxchar) {
                                objDiv = get_object(divID);

                                if (this.id) obj = this;

                                var remaningChar = maxchar - trimEnter(obj.value).length;

                                if (objDiv.id) {
                                    objDiv.innerHTML = remaningChar + " characters left of " + maxchar;
                                    //objDiv.innerHTML = remaningChar + " / "+ maxchar;
                                }
                                if (remaningChar <= 0) {
                                    obj.value = obj.value.substring(maxchar, 0);
                                    if (objDiv.id) {
                                        objDiv.innerHTML = "0 characters left";
                                    }
                                    return false;
                                }
                                else
                                { return true; }
                            }

                            function get_object(id) {
                                var object = null;
                                if (document.layers) {
                                    object = document.layers[id];
                                } else if (document.all) {
                                    object = document.all[id];
                                } else if (document.getElementById) {
                                    object = document.getElementById(id);
                                }
                                return object;
                            }

                            function trimEnter(dataStr) {
                                return dataStr.replace(/(\r\n|\r|\n)/g, "");
                            }
                            function nextline(dataStr) {
                                return dataStr.add("/n");
                            }
                        </script>
                        <table width="100%" style="font-family: Arial,verdana; font-size: 12px; line-height: 20px;">
                            <tr>
                                <td width="`100%" valign="baseline" align="left" class="heading" style="padding-left:5px;">
                                    Feedback<br />
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td width="`100%" valign="baseline" align="center">
                                    <asp:Label ID="lblmsg" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="left" valign="top">
                                    <strong>Name</strong><br />
                                    <strong style="color: Red">*</strong>
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="fdbktxt"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvname" ErrorMessage="Please Enter Name" ControlToValidate="txtName"
                                        runat="server" Display="None" ValidationGroup="submit" />
                                    <ajax:ValidatorCalloutExtender ID="vceName" runat="server" TargetControlID="rfvname"></ajax:ValidatorCalloutExtender>
                                    <ajax:FilteredTextBoxExtender ID="ftbename" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
                                        TargetControlID="txtName">
                                    </ajax:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="left" valign="top">
                                    <strong>Email</strong><br />
                                    <strong style="color: Red">*</strong>
                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="fdbktxt"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Enter Email"
                                        ControlToValidate="txtEmail" runat="server" Display="None" ValidationGroup="submit" />
                                    <ajax:ValidatorCalloutExtender id="vceEmail" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid Email Id"
                                        ControlToValidate="txtEmail" runat="server" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="submit" />
                                    <ajax:ValidatorCalloutExtender ID="vceEmail1" runat="server" TargetControlID="RegularExpressionValidator1"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="left" valign="top">
                                    <strong>Phone</strong>
                                    <strong style="color: Red">*</strong>
                                    <br />
                                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" CssClass="fdbktxt"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Please Enter Phone No"
                                        ControlToValidate="txtPhone" runat="server" Display="None" ValidationGroup="submit" />
                                    <ajax:ValidatorCalloutExtender ID="vcePhone" runat="server" TargetControlID="RequiredFieldValidator2"></ajax:ValidatorCalloutExtender>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789"
                                        TargetControlID="txtPhone">
                                    </ajax:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="left" valign="top">
                                    <strong>Comments</strong>
                                    <strong style="color: Red">*</strong>
                                    <br />
                                    <div id="Div2" style="text-align: center; padding-right: 150px;">
                                        1000 characters
                                    </div>
                                    <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="200px"
                                        Width="300px" onkeypress="return validateLimit(this, 'Div2', 1000)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Please Enter Comment"
                                        ControlToValidate="txtComments" runat="server" ValidationGroup="submit" Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="center" valign="top">
                                    <asp:Button ID="btnsubmit" CssClass="buttonBook " Text="Submit" runat="server"
                                        ValidationGroup="submit" OnClick="btnsubmit_Click" />
                                </td>
                                
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
    <td width="50"><img src="images/log_icon.jpg" width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Contact Us</td>
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
                                <asp:Label ID="lblmsg" runat="server" />
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
                                       <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="lj_inp"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvname" ErrorMessage="Please Enter Name" ControlToValidate="txtName"
                                        runat="server" Display="None" ValidationGroup="submit" />
                                    <ajax:ValidatorCalloutExtender ID="vceName" runat="server" TargetControlID="rfvname"></ajax:ValidatorCalloutExtender>
                                    <ajax:FilteredTextBoxExtender ID="ftbename" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
                                        TargetControlID="txtName">
                                    </ajax:FilteredTextBoxExtender>
                                                      

                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                        Email
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="lj_inp"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Enter Email"
                                        ControlToValidate="txtEmail" runat="server" Display="None" ValidationGroup="submit" />
                                    <ajax:ValidatorCalloutExtender id="vceEmail" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid Email Id"
                                        ControlToValidate="txtEmail" runat="server" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="submit" />
                                    <ajax:ValidatorCalloutExtender ID="vceEmail1" runat="server" TargetControlID="RegularExpressionValidator1"></ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>


                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                      Phone
                                    </td>
                                    <td height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                          <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" CssClass="lj_inp"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Please Enter Phone No"
                                        ControlToValidate="txtPhone" runat="server" Display="None" ValidationGroup="submit" />
                                    <ajax:ValidatorCalloutExtender ID="vcePhone" runat="server" TargetControlID="RequiredFieldValidator2"></ajax:ValidatorCalloutExtender>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789"
                                        TargetControlID="txtPhone">
                                    </ajax:FilteredTextBoxExtender>
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
                                         <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" CssClass="lj_inp"
                                        onkeypress="return validateLimit(this, 'Div2', 1000)"></asp:TextBox>
                                    </td>
                                </tr>


                                <tr>
                                    <td height="28" align="center" class="lj_hd12" colspan="3">
                          Corporate Office
                                    </td>
                                   

                                </tr>


                                 <tr>
                                    <td height="20" align="center" class="lj_hd12" colspan="3" valign="top">
                             <p>
                                <span style="color: Maroon; font-size: 13px; font-family: Arial; font-weight: bold;">
                                    </span>
                                <%--Ph: 080 - 32 56 17 27&nbsp;
                                <br />
                                info@lovejourney.in
                                <br />
                                www.lovejourney.in
                                --%>

                                Love Journey Techno Pvt Ltd.
                                <br />
                                #38, SGR Dental College Rd,
                                <br />
                                Munnekollala,
                                <br />
                                Marathahalli,
                                <br />
                                Bangalore-560037.
                                <br />
                                080-32561727,25220265
                                  <br />
                                info@lovejourney.in
                            </p>
                                    </td>
                                   

                                </tr>
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="4" >
                                       <asp:Button ID="btnsubmit" CssClass="buttonBook " Text="Submit" runat="server"
                                        ValidationGroup="submit" OnClick="btnsubmit_Click" />
                                                           

                                                        

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
