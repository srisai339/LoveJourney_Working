<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="RoleMaster.aspx.cs" Inherits="Users_AdminDB_RoleMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="990" align="center" height="460" valign="top">
                <table width="990" cellpadding="0" cellspacing="0" border="0" bgcolor="#ffffff">
                <tr>
                <td align="right" id="ts1" runat="server" visible="false">
                <asp:LinkButton ID="lbtnBack" Text="Back" runat="server"   ></asp:LinkButton>
                </td>
                </tr>
                    <tr>
                        <td class="lj_dbrd_hd" valign="middle" align="center">
                            &nbsp;&nbsp;
                            <asp:Label ID="lblHead" runat="server" Font-Size="16px" Text="Role Master" ></asp:Label>
                        </td>
                        <td>
                         <asp:LinkButton ID="btnBack" runat="server" Text="Back" Visible="false"  CssClass="lj_dbrd_hd"
                                ></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table>
                                <tr id="trCCode1" runat="server">
                                    <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                                        <asp:Label ID="lblNotices" runat="server" Text="Role :"></asp:Label>
                                        <strong style="color: Red">*</strong>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRole" runat="server" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRole" ControlToValidate="txtRole" runat="server" Display="None"
                                            ValidationGroup="submit" ErrorMessage="Please Enter Notices"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceNotices" TargetControlID="rfvRole" runat="server"></asp:ValidatorCalloutExtender>
                                            
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
                                             CssClass="lj_dbrd_link1" onclick="btnUpdate_Click"  />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" 
                                             CssClass="lj_dbrd_link1" onclick="btnCancel_Click"  />
                                       

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
                           <asp:GridView ID="gvRole" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                            Width="990" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                            GridLines="Both"  EmptyDataText="No Remainders" BackColor="White" PageSize="40"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowSorting="True" 
                                onrowcommand="gvRole_RowCommand" onrowdeleting="gvRole_RowDeleting" 
                                onrowediting="gvRole_RowEditing" >
                                

                           <FooterStyle BackColor="White" ForeColor="#000066" />
                           <HeaderStyle BackColor="#025aa2" Font-Bold="True" Height="30px"  ForeColor="White" />
                           <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                           <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                           <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                           <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                                <Columns>
                                    <asp:TemplateField HeaderText="RoleId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Text='<%#Eval("Id") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                        <ItemStyle Width="" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRole" Text='<%#Eval("Role") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CausesValidation="false" CommandName="Edit" CssClass="lj_dbrd_link1"
                                                CommandArgument='<%# Eval("Id") %>' />
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CausesValidation="false" CommandName="Delete" CssClass="lj_dbrd_link1"
                                                CommandArgument='<%# Eval("Id") %>' />
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

