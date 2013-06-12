<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Flight/MasterPage.master" AutoEventWireup="true" CodeFile="frmStatus.aspx.cs" Inherits="Agent_Flight_frmStatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>LoveJourney - Status</title>
    <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="panelBookingStatus" runat="server">
        <table width="100%">
            
            <tr>
                <td align="left">
                    <div>
                        <asp:Panel ID="pnlBookingStatus" runat="server">
                            <%--<table>
                               
                                <tr>
                                    
                                </tr>
                                <tr>
                                    <td>
                                   
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        
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
    <td align="center" valign="middle" class="online_booking">Ticket Status</td>
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
                                             Enter Booking Reference Number
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                      <asp:TextBox ID="txtBookingReferenceNo" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookingReferenceNo"
                                            Display="None" ErrorMessage="Please enter ref no." ValidationGroup="submit1"></asp:RequiredFieldValidator>
                                        <ajax:validatorcalloutextender id="vceRef" runat="server" targetcontrolid="RequiredFieldValidator1"></ajax:validatorcalloutextender>
                                    </td>
                                </tr>
                                
                                
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                      <asp:Button ID="btnGet" runat="server" Text="Get Status" ValidationGroup="submit1" 
                                            OnClick="btnGet_Click" CssClass="buttonBook" />
                                        <asp:Button ID="btnGetInt" runat="server" Text="Get Status" ValidationGroup="submit1"
                                            OnClick="btnGetInt_Click" Visible="False" CssClass="buttonBook" />
                                          <%--  <asp:Button ID="btnget1" runat="server" Text="Get Status1" 
                                            ValidationGroup="submit1" onclick="btnget1_Click" />--%>
                                            
                                 <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                        

                                    </td>
                                 </tr>


                                   <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Text=""></asp:Label>
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
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
