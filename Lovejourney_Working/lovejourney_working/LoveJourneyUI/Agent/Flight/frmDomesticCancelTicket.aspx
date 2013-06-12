<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Flight/MasterPage.master"
    AutoEventWireup="true" CodeFile="frmDomesticCancelTicket.aspx.cs" Inherits="Agent_Flight_frmDomesticCancelTicket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>LoveJourney - Cancel Ticket Online</title>
    <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table width="100%">
        <tr>
         
                <td align="left" >
                    <asp:Panel ID="pnlCancel" runat="server">
                        <%--<table >
                           
                           
                            <tr>
                                
                            </tr>
                            <tr>
                                <td align="left">
                                    Enter Booking Reference Number
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Email ID
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Reason
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                   
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    
                                </td>
                            </tr>
                        </table>--%>

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
    <td width="50"><img src="../../images/cancel_tick.png" width="37" height="37" /></td>
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
                                <td colspan="3">
                                    <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>

     
     <tr>
                                <td align="center" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                                <tr>
                                  <td colspan="3">
                                    <asp:RadioButtonList ID="rbtnDomesticInt" RepeatDirection="Horizontal" runat="server"
                                        OnSelectedIndexChanged="rbtnDomesticInt_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="Domestic" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="International" Value="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                </tr>
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        LoveJourney Ref No
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                    <asp:TextBox ID="txtBookingReferenceNo" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Ref No" ControlToValidate="txtBookingReferenceNo"
                                        Display="None" runat="server" ValidationGroup="signin" />
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvUsername">
                                    </ajax:ValidatorCalloutExtender>
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
                                    <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Email ID"
                                        ControlToValidate="txtEmailAddress" Display="None" runat="server" ValidationGroup="signin" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Enter a Valid Email ID"
                                        ControlToValidate="txtEmailAddress" Display="None" runat="server" ValidationGroup="signin"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator1">
                                    </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Reason
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                     <asp:TextBox ID="txtReason" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                      <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                        ValidationGroup="signin" CssClass="buttonBook" />
                                    <asp:Button ID="btnCancelInt" runat="server" Text="Cancel" OnClick="btnCancelInt_Click"
                                        ValidationGroup="signin" Width="59px" Visible="False" 
                                        CssClass="buttonBook" />
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
    <td align="center" valign="top" width="24" height="32"><img src="../../images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="../../images/formright_bottom.png" /></td>
  </tr>

</table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
