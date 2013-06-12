<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="BusOperators.aspx.cs" Inherits="Users_BusOperators" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
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
    <asp:Panel ID="pnlbusOperators" runat="server" Width="100%">
        <table width="100%">
            <tr align="center" class="Headding">
                <td>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Label runat="server" ForeColor="#FF3300" Text="" ID="lblErrorMsg" CssClass="i2s_HRP_Text1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <ajax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%"
                        AutoPostBack="true" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
                        <ajax:TabPanel ID="tabPanelView" runat="server" HeaderText="View">
                            <ContentTemplate>
                                <asp:Panel ID="pnlView" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td width="5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="lblViewMsg" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:GridView ID="gvOperators" Font-Size="Small" runat="server" AutoGenerateColumns="False"
                                                    OnPageIndexChanging="gvOperators_PageIndexChanging" OnRowCommand="gvOperators_RowCommand"
                                                    EmptyDataText="No Data Found..." Width="100%" EnableModelValidation="True" AllowSorting="True"
                                                    OnSorting="gvOperators_Sorting">
                                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="API Name" SortExpression="APIName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAPIName" runat="server" Text='<%# Eval("APIName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Operator Name" SortExpression="BusOperatorName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("BusOperatorName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CausesValidation="false" ValidationGroup="Edit"
                                                                    CommandName="EditName" CommandArgument='<%# Eval("BusOperatorId") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="tabPanelAdd" runat="server" HeaderText="Add">
                            <ContentTemplate>
                                <asp:Panel ID="pnlAdd" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" width="50%">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="50%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="50%">
                                                <asp:Label ID="Label2" CssClass="i2s_HRP_Text1" runat="server" Text="Select API :"></asp:Label>
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:DropDownList ID="ddlAPi" runat="server" CssClass="Dropdownlist">
                                                    <asp:ListItem Text="Select" Value="0" />
                                                    <asp:ListItem Text="Abhibus" Value="1" />
                                                    <asp:ListItem Text="Bitla" Value="2" />
                                                    <asp:ListItem Text="Kesineni" Value="3" />
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAPi"
                                                    InitialValue="Select" Display="None" ErrorMessage="Please enter name." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                    TargetControlID="RequiredFieldValidator1">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="50%">
                                                <asp:Label ID="Label1" CssClass="i2s_HRP_Text1" runat="server" Text="OperatorName:"></asp:Label>
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:TextBox ID="txtName" runat="server" ValidationGroup="submit"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                                    Display="None" ErrorMessage="Please enter name." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                    TargetControlID="RequiredFieldValidator1">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="50%">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="50%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="50%">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="i2s_HRP_btn3" OnClick="btnSubmit_Click"
                                                    Text="Submit" ValidationGroup="submit" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnCancelEdit" runat="server" CssClass="i2s_HRP_btn3" OnClick="btnCancelEdit_Click"
                                                    Text="Cancel" Visible="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="50%">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </ajax:TabPanel>
                    </ajax:TabContainer>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
