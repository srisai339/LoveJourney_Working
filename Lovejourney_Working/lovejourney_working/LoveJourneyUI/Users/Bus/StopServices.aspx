<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="StopServices.aspx.cs" Inherits="Users_Bus_StopServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <table width="100%">
                    <tr>
                    <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                        runat="server" visible="false">
                        <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
          </table>
    <table width="100%" align="center" id="tblmain" runat="server" bgcolor="#ffffff">
        <tr>
            <td width="100%" align="center">
                &nbsp;<asp:Label ID="lblmsg" runat="server" Visible="false" />
            </td>
        </tr>
         <tr>
            <td width="100%" align="center" class="heading" valign="top">
                   Stop Services
                    </td>
        </tr>
         <tr>
            <td>
                 &nbsp;
                    </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvstopservices" AllowPaging="True" AutoGenerateColumns="False"
                    Width="50%" runat="server" ShowHeader="true" CellPadding="3" EnableModelValidation="True"
                    PageSize="50" EmptyDataText="No Screens toset Permissions.." BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="None" OnRowDataBound="gvstopservices_RowDataBound">
                    <AlternatingRowStyle CssClass="gridAlter" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblScreenID" Text='<%#Eval("ID") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAdd" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="15%" HeaderText="Service Name">
                            <ItemTemplate>
                                <asp:Label ID="lblScreenName" Text='<%#Eval("Services") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="gridheadercolor" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="30px" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                        Height="30px" />
                    <EmptyDataRowStyle ForeColor="Maroon" HorizontalAlign="Center" Height="30px" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" >
                <asp:Button Text="Update" runat="server" ID="btnSavePermissions" CssClass="buttonBook"
                    OnClick="btnSavePermissions_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
