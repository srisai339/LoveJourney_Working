<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Flight/MasterPage.master" AutoEventWireup="true" CodeFile="frmBookingstatus.aspx.cs" Inherits="Users_Flight_frmBookingstatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>LoveJourney - Booking Status</title>
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
                                   <td align="center" bgcolor="#0062af" style="color: White">
                                    Booking Status
                                </td>
                            </tr>
        <tr>
            <td align="center">
                <div>
                    <asp:Panel ID="pnlBookingStatus" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>
                           
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
                                <td>
                                    Enter Booking Reference Number :
                                    <asp:TextBox ID="txtBookingReferenceNo" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookingReferenceNo"
                                    Display="None" ErrorMessage="Please enter ref no." ValidationGroup="sub"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceRef" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnGet" runat="server" Text="Get Status" 
                                        ValidationGroup="sub"  OnClick="btnGet_Click" CssClass="buttonBook" />
                                     <asp:Button ID="btnGetInt" runat="server" Text="Get Status" ValidationGroup="submit"
                                        OnClick="btnGetInt_Click" Visible="False" CssClass="buttonBook" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
