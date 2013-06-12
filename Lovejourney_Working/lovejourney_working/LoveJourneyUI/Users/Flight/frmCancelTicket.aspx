﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Flight/MasterPage.master" AutoEventWireup="true" CodeFile="frmCancelTicket.aspx.cs" Inherits="Users_Flight_frmCancelTicket" %>


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
                                <td align="center" colspan="3" bgcolor="#0062af" style="color: White">
                                    Cancel Ticket
                                </td>
                            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlCancel" runat="server">
                        <table>
                          
                            <tr>
                                <td colspan="3">
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
                                <td align="left">
                                    Enter Booking Reference Number
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBookingReferenceNo" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Ref No" ControlToValidate="txtBookingReferenceNo"
                                        Display="None" runat="server" ValidationGroup="signin" />
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvUsername">
                                    </ajax:ValidatorCalloutExtender>
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
                                <td align="left">
                                    Reason
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtReason" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                        ValidationGroup="signin" CssClass="buttonBook" />
                                    <asp:Button ID="btnCancelInt" runat="server" Text="Cancel" OnClick="btnCancelInt_Click"
                                        ValidationGroup="signin" Width="59px" Visible="False" 
                                        CssClass="buttonBook" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
</asp:Panel>
</asp:Content>

