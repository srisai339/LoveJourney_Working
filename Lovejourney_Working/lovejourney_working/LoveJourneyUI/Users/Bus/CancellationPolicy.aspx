<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="CancellationPolicy.aspx.cs" Inherits="Users_CancellationPolicy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnsave" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" />
        </Triggers>
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                        runat="server" visible="false">
                        <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlMain" runat="server"  BackColor="#ffffff">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="tb1" runat="server">
                <tr>
                    <td width="100%" align="center" class="heading">
                        Cancellation Policy
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        <asp:Label ID="lblMsg" runat="server" />
                        <asp:Label ID="lblId" runat="server" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        <table width="70%">
                            <tr>
                                <td width="40%" align="left">
                                    API
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlApi" runat="server" CssClass="lable_bg12_adm" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlApi_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0" />
                                        <asp:ListItem Text="Abhibus" Value="1" />
                                        <asp:ListItem Text="Bitla" Value="2" />
                                        <asp:ListItem Text="Kesineni" Value="3" />
                                        <asp:ListItem Text="Kallada" Value="4" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvApi" ErrorMessage="Select API" ControlToValidate="ddlApi"
                                        InitialValue="0" ValidationGroup="save" runat="server" Display="None"></asp:RequiredFieldValidator>
                                   <ajax:ValidatorCalloutExtender ID="vceAPI" runat="server" TargetControlID="rfvApi"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="left">
                                    Select Operator
                                </td>
                                <td  align="left">
                                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="lable_bg12_adm" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="Select" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Please Select Operator" ControlToValidate="ddlOperator"
                                        InitialValue="Select" ValidationGroup="save" runat="server" Display="None"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceSelectOperator" runat="server" TargetControlID="RequiredFieldValidator3"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="left">
                                    Cancellation Percenatge(%)
                                </td>
                                <td  align="left">
                                    <asp:TextBox ID="txtCancelPercenatge" runat="server" MaxLength="3" CssClass="lable_bg12_adm" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Cancel Percentage" ControlToValidate="txtCancelPercenatge"
                                        Display="None" ValidationGroup="save" runat="server"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCancellationPercentage" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="only value between 1 to 100 accepted"
                                        Display="None" MaximumValue="100" MinimumValue="0" Type="Double" ControlToValidate="txtCancelPercenatge"
                                        ValidationGroup="save"></asp:RangeValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCancel" runat="server" TargetControlID="RangeValidator1"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="left">
                                    Before How much time
                                </td>
                                <td  align="left">
                                    <asp:TextBox ID="txtBeforeTime" runat="server" MaxLength="100" CssClass="sele" 
                                        Width="250px" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Enter Before Time" ControlToValidate="txtBeforeTime"
                                        ValidationGroup="save" runat="server" Display="None"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceHow" runat="server" TargetControlID="RequiredFieldValidator2"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="right">
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="left">
                                </td>
                                <td  align="left">
                                    <asp:Button ID="btnsave" Text="save" CssClass="buttonBook" runat="server"
                                        ValidationGroup="save" OnClick="btnsave_Click" />
                                    <asp:Button ID="btnupdate" Text="update" CssClass="buttonBook" runat="server"
                                        ValidationGroup="save" Visible="false" OnClick="btnupdate_Click" />
                                    <asp:Button ID="btnCancel" Text="Cancel" CssClass="buttonBook" runat="server"
                                        CausesValidation="false" Visible="false" OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        <asp:GridView ID="gvCancelPolicy" runat="server" AutoGenerateColumns="False" Width="80%"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" EnableModelValidation="True" EmptyDataText="No Records Added yet"
                            OnRowCommand="gvCancelPolicy_RowCommand" GridLines="Horizontal" 
                            AllowPaging="True" onpageindexchanging="gvCancelPolicy_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCancelPolicyID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBusOperatorId" runat="server" Text='<%#Eval("BusOperatorId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="API">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAPI" runat="server" Text='<%#Eval("APIName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operator Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBusOperatorName" runat="server" Text='<%#Eval("BusOperatorName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Before Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeforeTime" runat="server" Text='<%#Eval("BeforeTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cancel Percentage">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPercentage" runat="server" Text='<%#Eval("CancePercentage") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cancel Percentage">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="buttonBook"
                                            CommandName="CancelEdit" CommandArgument='<%#Eval("Id") %>' />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="buttonBook"
                                            CommandName="DeleteCancelDetails" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('Are you sure to delete this record ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" CssClass="menugv" ForeColor="White"
                                HorizontalAlign="Center" Height="25px" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                            <RowStyle ForeColor="Black" HorizontalAlign="Center" Height="30px" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center"
                                Height="30px" />
                            <EmptyDataRowStyle ForeColor="#d8187c" HorizontalAlign="Center" Height="30px" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
