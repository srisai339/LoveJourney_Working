<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="AdminCancelStatus.aspx.cs" Inherits="AdminDashBoard_AdminCancelStatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <title>LoveJourney - Cancelled Ticket Status</title>
  <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%">
        <tr>
          <td align="right">
          <asp:LinkButton ID="btnCancelstatus" runat="server" Text="Back" 
                                        onclick="btnCancelstatus_Click"></asp:LinkButton>
          </td>
        </tr>
        <tr>
            <td align="center">
                <div>
                    <asp:Panel ID="pnlBookingStatus" runat="server">
                        <table cellspacing="0" cellpadding="0" align="center" style="background-color: White;
                                                    border: 1px solid #0062af">
                            <tr>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td align="left" bgcolor="#0062af" style="color: White">
                                    Cancel Ticket Status
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
                                    <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Ref No" ControlToValidate="txtBookingReferenceNo"
                                        runat="server" ValidationGroup="signin" Display="None" />
                                    <ajax:ValidatorCalloutExtender ID="vceRefNo" TargetControlID="rfvUsername" runat="server"></ajax:ValidatorCalloutExtender>
                                  

                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnGet" runat="server" Text="Get Status" OnClick="btnGet_Click" ValidationGroup="signin" CssClass="buttonBook" />
                                      <asp:Button ID="btnGetInt" runat="server" Text="Get Status"  CssClass="buttonBook"
                                        OnClick="btnGetInt_Click" ValidationGroup="signin" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

