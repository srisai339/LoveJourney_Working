<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="Commission.aspx.cs" Inherits="Users_Commission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ExportGridviewtoExcel() {
            __doPostBack("<%=lbtnXport2Xcel.UniqueID %>", '');
        }


        $(document).ready(function () {
            $("input:text").mouseover(function (event) {

                $("input:text").addClass("searchBoxHover")
            });
        }
                );
        $(document).ready(function () {
            $("input:text").mouseout(function (event) {

                $("input:text").removeClass("searchBoxHover")
            });
        }
                );
        $(document).ready(function () {
            $("input:text").focusin(function (event) {

                $("input:text").addClass("searchBoxHover")
            });
        }
                );
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveCD" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
            <asp:AsyncPostBackTrigger ControlID="btnUpdateCD" />
        </Triggers>
        <ContentTemplate>
            <table width="900">
                <tr>
                    <td width="100%" height="30px" align="left" class="tr" id="tdmsg" runat="server"
                        visible="false" valign="middle">
                        &nbsp;<asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        <asp:MultiView ID="MVUsers" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table width="100%">
                                    <tr>
                                     <td class="heading" align="center">
      Commission
        </td>
                                       <%-- <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                            font-weight: bold; color: Maroon;">
                                            Commission
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="right" style="padding-right: 50px;">
                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Enter Search item"
                                                ControlToValidate="txtSearch" runat="server" ValidationGroup="search" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="right" valign="top" class="busoperator_text_head">
                                            <%--Search&nbsp;:&nbsp;--%><asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                                                ID="btnSearch" Text="GO" runat="server" CssClass="buttonBook" ValidationGroup="search"
                                                OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="right">
                                            <table width="100%">
                                                <tr>
                                                    <td width="50%" align="left" valign="top">
                                                        Select Page size&nbsp;:&nbsp;
                                                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="DDL"
                                                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="40" Value="1" />
                                                            <asp:ListItem Text="80" Value="2" />
                                                            <asp:ListItem Text="120" Value="3" />
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="50%" align="right">
                                                        <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                            Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClientClick="ExportGridviewtoExcel();"
                                                            OnClick="lbtnXport2Xcel_Click" />&nbsp;|&nbsp;
                                                        <asp:LinkButton ID="lbtnNewCommission" Text="New Commission" CssClass="qw" runat="server"
                                                            Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClick="lbtnNewCommission_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="center">
                                            <asp:GridView ID="GvCommissions" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
                                                runat="server" CellPadding="3" EnableModelValidation="True" PageSize="40" EmptyDataText="No Apis Added "
                                                OnRowDeleting="GvCommissions_RowDeleting" OnRowEditing="GvCommissions_RowEditing"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                AllowSorting="true" OnPageIndexChanging="GvCommissions_PageIndexChanging" OnSorting="GvCommissions_Sorting">
                                                <AlternatingRowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" Text='<%#Eval("CommisssionId") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <%-- <EditItemTemplate>
                                                            <asp:Label ID="lblIDE" Text='<%#Eval("CommisssionId") %>' runat="server" />
                                                        </EditItemTemplate>--%>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="API" ItemStyle-Width="25%" SortExpression="Api">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApi" Text='<%#Eval("Api") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <%-- <EditItemTemplate>
                                                            <asp:Label ID="lblApiE" Text='<%#Eval("Percentage") %>' runat="server" />
                                                        </EditItemTemplate>--%>
                                                        <ItemStyle Width="25%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Percentage" ItemStyle-Width="20%" SortExpression="Percentage">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPercentage" Text='<%#Eval("Percentage") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <%-- <EditItemTemplate>
                                                            <asp:Label ID="lblPercentageE" Text='<%#Eval("Percentage") %>' runat="server" />
                                                        </EditItemTemplate>--%>
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="buttonBook"
                                                                CausesValidation="false" CommandArgument='<%#Eval("CommisssionId") %>' CommandName="Edit" />
                                                            <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="buttonBook"
                                                                CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" CssClass="menugv" ForeColor="White"
                                                    HorizontalAlign="Center" Height="25px" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="30px" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                    Height="30px" />
                                                <EmptyDataRowStyle ForeColor="Maroon" HorizontalAlign="Center" Height="30px" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                            font-weight: bold; color: Maroon;">
                                            Add Commission
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            Complete the Page below to create a new Commission
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 13px;
                                            font-weight: bold; color: Maroon; padding-left: 360px;">
                                            Commission Details
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="center">
                                            <asp:Panel runat="server" Width="60%">
                                                <table width="80%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="30%" align="center">
                                                            API
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:TextBox ID="txtApi" CssClass="textfield_2" runat="server" MaxLength="100" />
                                                            <asp:RequiredFieldValidator ID="rfvApi" ErrorMessage="Enter Api" ControlToValidate="txtApi"
                                                                runat="server" Display="None" ValidationGroup="save" />
                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvApi"
                                                                WarningIconImageUrl="~/images/icon-warning.png" CloseImageUrl="~/images/icon-close4.png"
                                                                CssClass="CustomValidatorCalloutStyle" PopupPosition="Right">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="ftbUsername" runat="server" TargetControlID="txtApi"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                                            </ajax:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="30%" align="center">
                                                            Percentage&nbsp;(%)&nbsp;
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:TextBox ID="txtPercentage" CssClass="textfield_2" runat="server" MaxLength="3" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Percentage"
                                                                ControlToValidate="txtPercentage" runat="server" Display="None" ValidationGroup="save" />
                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                                WarningIconImageUrl="~/images/icon-warning.png" CloseImageUrl="~/images/icon-close4.png"
                                                                CssClass="CustomValidatorCalloutStyle" PopupPosition="Right">
                                                            </ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="ftbPercentage" runat="server" TargetControlID="txtPercentage"
                                                                ValidChars="1234567890.">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="only value between 1 to 100 accepted"
                                                                Display="None" MaximumValue="100" MinimumValue="0" Type="Double" ControlToValidate="txtPercentage"
                                                                ValidationGroup="save"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="30%" align="center">
                                                            <asp:Label ID="lblCommissionID" runat="server" Visible="false" />
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:Button ID="btnSaveCD" Text="Save" runat="server" CssClass="selectseats_input"
                                                                ValidationGroup="save" OnClick="btnSaveCD_Click" />
                                                            &nbsp;<asp:Button ID="btnUpdateCD" Text="Update" runat="server" CssClass="selectseats_input1"
                                                                ValidationGroup="save" OnClick="btnUpdateCD_Click" />&nbsp;
                                                            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="selectseats_input1"
                                                                CausesValidation="false" OnClick="btnCancel_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
