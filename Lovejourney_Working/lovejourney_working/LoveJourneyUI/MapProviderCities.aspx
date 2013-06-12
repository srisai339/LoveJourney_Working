<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MapProviderCities.aspx.cs" Inherits="MapProviderCities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <h2>
            Selecting a provider will get the list of cities from API, maps it with cities list in
            database and shows the unmapped cities list</h2>
        <table>
            <tr>
                <td>
                    Provider
                </td>
                <td>
                    <asp:DropDownList ID="ddlProviders" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProviders_SelectedIndexChanged" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <b>Unmapped cities &nbsp;&nbsp;<label id="lblCount" runat="server"></label></b>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvUnmappedItems" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     <%--   <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                        <RowStyle HorizontalAlign="Left" />
                        <AlternatingRowStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
