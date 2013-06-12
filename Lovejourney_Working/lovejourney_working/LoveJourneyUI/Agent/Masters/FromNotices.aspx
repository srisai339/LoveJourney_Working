<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="FromNotices.aspx.cs" Inherits="Agent_Masters_FromNotices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" bgcolor="#ffffff">
    <tr>
     <td align="right">
                         <asp:LinkButton ID="btnBack" runat="server" Text="Back" Visible="false"  ForeColor="#006699"
                                onclick="btnBack_Click"></asp:LinkButton>
                        </td>
    </tr>
        <tr>
            <td width="990" align="center">
                <table width="990" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td  valign="middle" align="center" class="lj_dbrd_hd">
                            &nbsp;&nbsp;
                            <asp:Label ID="lblHead" runat="server" Font-Size="16px" Text="Notice Master"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="center">
                            <table>
                                <tr id="trCCode1" runat="server">
                                    <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                                        <asp:Label ID="lblAgentname" runat="server" Text="Notices :"></asp:Label>
                                        <strong style="color: Red">*</strong>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNotices" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNotices" ControlToValidate="txtNotices" runat="server"
                                            ValidationGroup="submit" ErrorMessage="Please Enter Notices"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="submit" CssClass="lj_dbrd_link1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" 
                                            onclick="btnUpdate_Click" CssClass="lj_dbrd_link1" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" 
                                            onclick="btnCancel_Click" CssClass="lj_dbrd_link1" />
                                       

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblmsg" runat="server" Visible="false" Width="100%" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvNotices" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                                Width="100%" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                                EmptyDataText="No Remainders" BackColor="White" PageSize="40" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" AllowSorting="True" OnRowCommand="gvNotices_RowCommand"
                                OnRowEditing="gvNotices_RowEditing" onrowdeleting="gvNotices_RowDeleting">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#025aa2" Font-Bold="True" ForeColor="White" Height="30px" CssClass="lJ_gv"/>
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="center" Height="25" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Nid" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Text='<%#Eval("Nid") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                        <ItemStyle Width="" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notices">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHotelName" Text='<%#Eval("Notices") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CausesValidation="false" CommandName="Edit"
                                                CommandArgument='<%# Eval("Nid") %>'  CssClass="lj_dbrd_link1"/>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CausesValidation="false" CommandName="Delete"
                                                CommandArgument='<%# Eval("Nid") %>' CssClass="lj_dbrd_link1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
