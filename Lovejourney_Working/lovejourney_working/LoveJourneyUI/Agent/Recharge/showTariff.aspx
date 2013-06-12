<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="showTariff.aspx.cs" Inherits="Agent_Recharge_showTariff" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="3">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="1004" border="0" cellspacing="0" cellpadding="0" bgcolor="">
                    <tr>
                        <td class="heading" valign="middle" colspan="3" align="center">
                            Popular Recharges
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" bgcolor="#ffffff">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table id="pnlContact" runat="server" align="right" border="0" cellpadding="0" cellspacing="3"
                                            class="sing_innr_txt" visible="true" width="100%">
                                            <tr align="left">
                                                <td align="right" class="aclass" valign="middle" width="50%">
                                                    Operator Name <span style="color: Red">*</span>
                                                </td>
                                                <td align="left" class="style1" valign="middle" width="50%">
                                                    <asp:DropDownList ID="ddlProvider" runat="server" CausesValidation="true" CssClass="i2s_jp_seats"
                                                        TabIndex="4" Width="150px">
                                                        <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <ajaxtoolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                                        CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="CompareValidator1"
                                                        WarningIconImageUrl="~/images/warning.png">
                                                    </ajaxtoolkit:ValidatorCalloutExtender>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlProvider"
                                                        Display="None" ErrorMessage="Please select Operator Name" Operator="NotEqual"
                                                        Type="Integer" ValidationGroup="Register" ValueToCompare="0"></asp:CompareValidator>
                                                    <ajaxtoolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                                                        CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="RequiredFieldValidator1"
                                                        WarningIconImageUrl="~/images/warning.png">
                                                    </ajaxtoolkit:ValidatorCalloutExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProvider"
                                                        Display="None" ErrorMessage="Please Select Operator Name" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" height="15" width="100%">
                                                    <asp:Button ID="btnRegister" runat="server" CssClass="buttonBook" TabIndex="17" Text="Show"
                                                        ValidationGroup="Register" OnClick="btnRegister_Click" />
                                                </td>
                                            </tr>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="style1" colspan="3" valign="middle">
                                        &nbsp;
                                        <asp:Label ID="lblmsg" runat="server" CssClass="labelconfirm" Font-Size="Medium"
                                            ForeColor="Red" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trMobileService" runat="server" align="center">
                                    <td colspan="4">
                                        <asp:GridView ID="gvMobile" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            PageSize="20" AllowPaging="True" PagerStyle-CssClass="i2s_jp_bustext" AlternatingRowStyle-CssClass="alt"
                                            AllowSorting="True" ForeColor="#333333" Width="70%" CellPadding="4" EnableModelValidation="True">
                                            <PagerSettings Mode="Numeric" Position="Bottom" />
                                            <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField HeaderText="NetworkName" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Denomination" DataField="Denomination" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="TalkTime" DataField="TalkTime" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center" >
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Validity" DataField="Validity" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Description" DataField="Description" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
            </td>
        </tr>
    </table>
</asp:Content>
