<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="Cancellations.aspx.cs" Inherits="Agent_Cancellations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <div id="divCancelledReport" runat="server" visible="true">
                    <fieldset>
                        <legend runat="server" id="legendBookedReport">Cancelled Tickets</legend>
                        <br />
                    </fieldset>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
    </table>
</asp:Content>
