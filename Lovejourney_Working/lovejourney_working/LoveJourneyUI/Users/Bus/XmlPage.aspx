<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="XmlPage.aspx.cs" Inherits="Users_Bus_XmlPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="center">
<tr><td>

Click the button to update the buses.

</td>
</tr>
<tr>
<td>
<asp:Button ID="btnclikc" runat="server" Text="Update." CssClass="buttonBook" 
        onclick="btnclikc_Click"/>
</td>
</tr>
<tr><td>


<asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>

</td>
</tr>
</table>
</asp:Content>

