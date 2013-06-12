<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMasterPage.master" AutoEventWireup="true" CodeFile="Cab_Cancel.aspx.cs" Inherits="Cab_Cancel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr></table>
    <asp:Panel ID="pnlMain" runat="server">
    <table width="100%">
     
        <tr>
        <td align="left" height="420" valign="top">
            <%--<td width="100%">
          
                <table width="100%">
                    <tr>
                        <td width="40%" align="right">
                           
                        </td>
                        <td width="60%">
                           
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            Booking Ref No:
                        </td>
                        <td width="60%">
                            <asp:TextBox ID="txtBookingRefNo" runat="server" ValidationGroup="cancel"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookingRefNo"
                                Display="None" ErrorMessage="Please enter reference number." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceBookingRefNo" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;
                        </td>
                        <td width="60%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;
                        </td>
                        <td width="60%">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="buttonBook"
                                ValidationGroup="cancel" />
                            &nbsp;&nbsp;
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>--%>
            <table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="images/formtop_left.png" /></td>
    <td class="form_top" width="347"></td>
    <td align="left" valign="bottom" width="29" height="23"><img src="images/formright_top.png" /></td>
  </tr>


  <tr>
    <td class="form_left"></td>
    <td width="347" align="left" valign="top" bgcolor="#ffffff" >
    
    <table width="347" cellpadding="0" cellspacing="0" border="0">
     <tr>
                                    <td valign="top" height="20" align="left">
                                       <table width="347" height="45" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50"><img src="images/cancel_tick.png" width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Cancel Ticket</td>
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
                                <asp:Label ID="lblCancel" runat="server" />
                            </td>
                        </tr>

     
     <tr>
                                <td align="center" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Ref No
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                     <asp:TextBox ID="txtBookingRefNo" runat="server" ValidationGroup="cancel"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookingRefNo"
                                Display="None" ErrorMessage="Please enter reference number." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceBookingRefNo" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Email Id
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                     <asp:TextBox ID="txtEmailId" runat="server" ValidationGroup="cancel"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailId"
                                Display="Dynamic" ErrorMessage="Please enter email id." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId"
                                Display="Dynamic" ErrorMessage="Please enter valid email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="cancel"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                      <asp:Button ID="btnSubmit" runat="server"  Text="Submit" CssClass="buttonBook"
                                onclick="btnSubmit_Click" />
                                 <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                        

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
</asp:Content>

