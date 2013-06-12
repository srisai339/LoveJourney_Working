<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="CancelTicket.aspx.cs" Inherits="Users_CancelTicket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function showDiv1() {
            Page_ClientValidate("signin");
            if (Page_ClientValidate("signin")) {
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "../../images/loading.gif"', 200);
            }
            else
                return false; 
        }
        function showDiv2() {
            Page_ClientValidate("Cancel");
            if (Page_ClientValidate("Cancel")) {
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "../../images/loading.gif"', 200);
            }
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg" runat="server"
                visible="false">
                <asp:Label ID="Label7" runat="server" ForeColor="Maroon" Text="No permission to this page. Please contact Administrator for further details."></asp:Label>
            </td>
        </tr>
    </table>
   <asp:UpdatePanel ID="up1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSignIn" />
            <asp:AsyncPostBackTrigger ControlID="btnConfrmCancel" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="pnlMain" runat="server">
                <table width="900" border="0" cellspacing="0" cellpadding="0">
                  
                <tr>
                   <td align="center">
                      <asp:Label ID="lblCancelMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                   </td>
                </tr>
                    <tr>
                        <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg1"
                            runat="server" visible="false" colspan="2">
                            <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left">
                            <asp:Panel ID="pnlcancel" Width="801" runat="server" DefaultButton="btnSignIn">
                                <table width="801" border="0" cellspacing="0" cellpadding="0" align="center" >
                                    <tr>
                                        <td colspan="2" height="20" align="center">
                                            <asp:Label ID="lblCode" runat="server" Visible="false" />
                                            <asp:Label ID="lblMsg" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <%--<table width="600" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="35%" align="right">
                                                        LoveJourney Ref No&nbsp;&nbsp;<span style="color: Red;">*</span>&nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="65%" valign="top">
                                                        :&nbsp;<asp:TextBox ID="txtMBRefNo" MaxLength="50" runat="server" CssClass="textfield_sleep" />
                                                        <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Ref No" ControlToValidate="txtMBRefNo"
                                                            Display="None" runat="server" ValidationGroup="signin" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvUsername"
                                                            >
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="35%" align="left" valign="top" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 16px; color: #003a73;">
                                                   
                                                    </td>
                                                    <td width="65%" align="left" valign="top">
                                                        &nbsp;<asp:TextBox ID="txtEmailID" Visible="false" MaxLength="50" runat="server"
                                                            CssClass="textfield_sleep" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Email ID"
                                                            ControlToValidate="txtEmailID" Display="None" runat="server" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Enter a Valid Email ID"
                                                            ControlToValidate="txtEmailID" Display="None" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                            WarningIconImageUrl="../../images/icon-warning.png" CloseImageUrl="~/images/icon-close4.png"
                                                            CssClass="CustomValidatorCalloutStyle" PopupPosition="Right">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator1"
                                                            WarningIconImageUrl="../../images/icon-warning.png" CloseImageUrl="~/images/icon-close4.png"
                                                            CssClass="CustomValidatorCalloutStyle" PopupPosition="Right">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" width="35%" class="p_nme">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="65%" valign="top">
                                                        &nbsp;&nbsp;<asp:Button ID="btnSignIn" runat="server" Text="Submit" CssClass="buttonBook"
                                                            ValidationGroup="signin" OnClick="btnSignIn_Click" OnClientClick="showDiv1();" />
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
    <td width="347" align="left" valign="top"  bgcolor="#ffffff" >
    
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
                                <td align="left" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        LoveJourney Ref No
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                      <asp:TextBox ID="txtMBRefNo" MaxLength="50" runat="server" CssClass="lj_inp" />
                                                                <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Ref No" ControlToValidate="txtMBRefNo"
                                                                    Display="None" runat="server" ValidationGroup="signin" />
                                                               <ajax:ValidatorCalloutExtender ID="vceRuname" runat="server" TargetControlID="rfvUsername"></ajax:ValidatorCalloutExtender>

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
                                        <asp:TextBox ID="txtEmailID" MaxLength="50" runat="server" CssClass="lj_inp" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Email ID"
                                                                    ControlToValidate="txtEmailID" Display="None" runat="server" ValidationGroup="signin" />
                                                                <ajax:ValidatorCalloutExtender ID="vceRFV1" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Enter a Valid Email ID"
                                                                    ControlToValidate="txtEmailID" Display="None" runat="server" ValidationGroup="signin"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                                <ajax:ValidatorCalloutExtender ID="vcerge" runat="server" TargetControlID="RegularExpressionValidator1"></ajax:ValidatorCalloutExtender>
                                                              
                                    </td>
                                </tr>

                                <tr>
                                    <td height="28" align="left" class="lj_hd12">
                                        
                                        <span id="Span1" style="display: none" class="loadingBackground"></span><span id="Span2"
                                                                    style="display: none" class="modalContainer">
                                                                    <div class="registerhead">
                                                                        <img src="../../images/loading.gif" width="150" height="150" alt="Loading" />
                                                                    </div>
                                                                </span>
                                                              
                                    </td>
                                </tr>
                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                       <asp:Button ID="btnSignIn" runat="server" Text="Submit" CssClass="buttonBook"
                                                                    ValidationGroup="signin" OnClick="btnSignIn_Click" OnClientClick="showDiv();" />

                                                        

                                    </td>
                                 </tr>

                                 <tr>
                                 
                                 


                                    
                                    <td  height="40"  valign="middle"  align="left" colspan="3"  class="lj_hd12">
                                       
                                     <p style="padding-left: 20px;">
                                        &nbsp;</p>
                                    <p style="padding-left: 20px;">
                                        <span style="line-height: 20px; font-family: Arial,Verdana; color: Red; font-size: 13px;
                                            font-weight: bold;"><u>Notes:</u></span><br />
                                        <br />
                                        <span style="line-height: 20px; font-family: Arial,Verdana; font-size: 13px;">1. In
                                            case you’re unable to cancel your ticket online, please reach out to us. Click <a
                                                href="../../ContactUs.aspx" style="color: Blue;">here</a> for our contact details.</span><br />
                                        <br />
                                        <span style="line-height: 20px; font-family: Arial,Verdana; font-size: 13px;">2. Cancellation
                                            policies differ for each operator and is not set by LoveJourney.</span>
                                    </p>

                                                        

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
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td colspan="2" align="center">
                                            &nbsp;<asp:RadioButtonList ID="rbtnlstCancelType" runat="server" Visible="false"
                                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnlstCancelType_SelectedIndexChanged"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="Total Cancellation" Value="0" Selected="True" />
                                                <asp:ListItem Text="Partial Cancellation" Value="1" />
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="rfvcanType" ErrorMessage="Requiured" ControlToValidate="rbtnlstCancelType"
                                                runat="server" ValidationGroup="Cancel" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr  style="display:none;">
                                        <td colspan="2" align="center">
                                            <asp:GridView ID="gvPartialCancellation" AutoGenerateColumns="False" runat="server"
                                                OnRowDataBound="gvPartialCancellation_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"
                                                Width="60%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkSelectAll" Text="All" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkChild" runat="server" Checked="true"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Seat Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSeatNo" Text='<%#Eval("SeatNo") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" Text='<%#Eval("Status") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#003a73" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                                style="display: none" class="modalContainer">
                                                <div class="registerhead">
                                                    <img src="../../images/loading.gif" width="150" height="150" alt="Loading" />
                                                </div>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr  style="display:none;">
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnConfrmCancel" Text="Confirm To Cancel" runat="server" CssClass="selectseats_input"
                                                ValidationGroup="Cancel" Visible="false" OnClick="btnConfrmCancel_Click" OnClientClick="showDiv2();" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
