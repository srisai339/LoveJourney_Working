<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cities.aspx.cs" Inherits="Cities"
    MaintainScrollPositionOnPostback="true" MasterPageFile="~/Users/Bus/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-color: White;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlMain" runat="server">
                    <table width="100%">
                        <tr>
                            <td>
                                First Letter:
                                <asp:DropDownList ID="ddlLetter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLetter_SelectedIndexChanged">
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>H</asp:ListItem>
                                    <asp:ListItem>I</asp:ListItem>
                                    <asp:ListItem>J</asp:ListItem>
                                    <asp:ListItem>K</asp:ListItem>
                                    <asp:ListItem>L</asp:ListItem>
                                    <asp:ListItem>M</asp:ListItem>
                                    <asp:ListItem>N</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                    <asp:ListItem>P</asp:ListItem>
                                    <asp:ListItem>Q</asp:ListItem>
                                    <asp:ListItem>R</asp:ListItem>
                                    <asp:ListItem>S</asp:ListItem>
                                    <asp:ListItem>T</asp:ListItem>
                                    <asp:ListItem>U</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>W</asp:ListItem>
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>Y</asp:ListItem>
                                    <asp:ListItem>Z</asp:ListItem>
                                    <asp:ListItem>Others</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td width="50%" valign="top">
                                            <asp:GridView ID="gvCities" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCities_RowCommand"
                                                OnRowDataBound="gvCities_RowDataBound" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OriginalID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOriginalID" runat="server" Text='<%# Eval("OriginalID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SourceName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSourceName" runat="server" Text='<%# Eval("SourceName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TRUE/FALSE">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnMakeIt" runat="server" CommandName="TRUEorFALSE" CommandArgument='<%# Eval("OriginalID") %>'
                                                                ToolTip='<%# Eval("Status") %>'>Click</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OriginalIDtoID">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnOriginalIDtoID" runat="server" CommandName="OriginalIDtoID"
                                                                CommandArgument='<%# Eval("OriginalID") %>' ToolTip='<%# Eval("Status") %>'>OId - Id</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnSelect" runat="server" CommandName="SELECT" CommandArgument='<%# Eval("OriginalID") %>'>Select</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td width="50%" valign="top">
                                            <asp:Panel ID="Panel1" runat="server">
                                                <asp:GridView ID="gv" runat="server" Width="100%" AutoGenerateColumns="false" OnRowDataBound="gv_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OriginalID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOriginalID" runat="server" Text='<%# Eval("OriginalID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SourceName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSourceName" runat="server" Text='<%# Eval("SourceName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="True/False" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddl" runat="server" AutoPostBack="true">
                                                                    <asp:ListItem>True</asp:ListItem>
                                                                    <asp:ListItem>False</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
