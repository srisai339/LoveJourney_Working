<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master" AutoEventWireup="true" CodeFile="RechargeStatus.aspx.cs" Inherits="Users_Recharge_RechargeStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <table width="900" border="0" cellspacing="0" cellpadding="0">
      <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="3">
            </td>
        </tr>
        <tr>
            <td align="center"  valign="top">
                <table width="900" border="0" cellspacing="0" cellpadding="0" bgcolor="" id="tdrechargestatus" runat="server">
                    <tr>
                        <td class="heading" valign="middle" colspan="3" align="center" >
                            Status
                        </td>
                    </tr>
                 
                    <tr>
                        <td valign="top" bgcolor="#ffffff">
                            <table width="100%">
                                <tr>
                                    <td height="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table id="pnlContact" runat="server" align="right" border="0" cellpadding="0" cellspacing="3"
                                            class="sing_innr_txt" visible="true" width="100%">
                                            <tr align="left">
                                                <td align="right" class="aclass" valign="middle" width="50%">
                                                    Request Id <span style="color: Red">*</span>
                                                </td>
                                                <td align="left" class="style1" valign="middle" width="50%">
                                                    <asp:TextBox ID="txtstatus" runat="server" Width="150" MaxLength="17"></asp:TextBox>
                                                    
                                                    <ajaxtoolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                                                        CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="RequiredFieldValidator1"
                                                        WarningIconImageUrl="~/images/warning.png">
                                                    </ajaxtoolkit:ValidatorCalloutExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstatus"
                                                        Display="None" ErrorMessage="Please enter request id" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" height="15" width="100%">                                                  
                                                    <asp:Button ID="lnlstatus" runat="server" Text="Submit"  CssClass="buttonBook"
                                                        ForeColor="White" ValidationGroup="Save" OnClick="lnlstatus_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span id="mainDiv" class="loadingBackground" style="display: none"></span><span id="contentDiv"
                                            style="display: none;" class="modalContainer">
                                            <div class="registerhead" align="center">
                                                Processing... Please wait!<br />
                                                <br />
                                                <img id="myAnimatedImage" alt="Processing... Please wait!" src="../images/loading123.gif" />
                                            </div>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="style1" colspan="3" valign="middle">
                                        &nbsp;
                                        <asp:Label ID="lblmsg" runat="server" CssClass="labelconfirm" ForeColor="Green" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="4">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function pageLoad() {
            clear();
            //       document.getElementById('ctl00_ContentPlaceHolder1_UserWindow_txtDate').readOnly = false;
        }
        function showDiv(arg) {
            if (arg == 'val') {
                Page_ClientValidate("Save");
                if (Page_ClientValidate("Save")) {
                    document.getElementById('ctl00_ContentPlaceHolder1_UserWindow_hfSearchFromDate').value = document.getElementById('ctl00_ContentPlaceHolder1_UserWindow_txtDate').value;
                    document.getElementById('mainDiv').style.display = "";
                    document.getElementById('contentDiv').style.display = "";
                    setTimeout('document.images["myAnimatedImage"].src = "../images/loading123.gif"', 200);
                }
                else
                    return false;
            }
            else {
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "../images/loading123.gif"', 200);
            }

        }      

       
      
        
    </script>
</asp:Content>

