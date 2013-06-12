<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewAgentCommission.aspx.cs" Inherits="Agent_Recharge_ViewAgentCommission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="900px" height="350px" align="center">
        <tr>
            <td width="900px" valign="top" align="center" bgcolor="#fff">
                <table width="100%" align="center">
                    <tr>
                        <td align="center" colspan="2" class="heading" >
                            <asp:Label ID="labelHeading" runat="server" Font-Size="16px" Text="Commission"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:GridView ID="gvOperators" runat="server" AutoGenerateColumns="False" GridLines="None"
                                HorizontalAlign="Center" AllowPaging="True" AllowSorting="True" PageSize="15"
                                CellPadding="4" EnableModelValidation="True" ForeColor="#333333" Width="70%"
                                OnPageIndexChanging="gvOperators_PageIndexChanging" OnSorting="gvOperators_Sorting">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                <%--  <asp:BoundField HeaderText="Name" DataField="FirstName" HeaderStyle-HorizontalAlign="Center"
                                       ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>--%>
                                    <asp:BoundField HeaderText="Operator Name" DataField="OperatorType" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="OperatorType">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="NetworkId" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="OperatorsID" DataField="OperatorsID" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Network Name " DataField="OperatorsName" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="OperatorsName" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Commission" DataField="AgentCommission" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="AgentCommission" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Left" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
