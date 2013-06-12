<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="PromoCode.aspx.cs" Inherits="Users_PromoCode" %>
     
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">        $(document).ready(function () {
            $("[id$='txtSearch']").mouseover(function (event) {

                $("[id$='txtSearch']").addClass("searchBoxHover")
            });
        }
                );
        $(document).ready(function () {
            $("[id$='txtSearch']").mouseout(function (event) {

                $("[id$='txtSearch']").removeClass("searchBoxHover")
            });
        }
                );
        $(document).ready(function () {
            $("[id$='txtSearch']").focusin(function (event) {

                $("[id$='txtSearch']").addClass("searchBoxHover")
            });
        }
                );
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
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
         <asp:Panel ID="pnlpromocode" runat="server" Width="100%">
            <table width="100%" bgcolor="#ffffff">
            
                <tr>
                 <td class="heading" align="center">
  Promo Codes
        </td>
                   <%-- <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                        font-weight: bold; color: Maroon;">
                        Promo Codes
                    </td>--%>
                </tr>
                <tr>
                    <td width="100%" align="right" valign="top" class="busoperator_text_head">
                        <asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                            ID="btnSearch" Text="GO" runat="server" CssClass="buttonBook" ValidationGroup="search"
                            OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <asp:Panel ID="pnlADD" DefaultButton="btnAdd" runat="server" Width="100%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="100%" align="center" colspan="2">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />
                                        <asp:Label ID="lblCode" runat="server" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                <td align="center">
                                 <table width="30%">
                                <tr>
                                    <td width="50%" align="left" valign="top">
                                        Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtAmount" MaxLength="3" runat="server" CssClass="lj_inp" />
                                        <asp:RequiredFieldValidator ID="rfvAmt" ErrorMessage="Enter Amount" ControlToValidate="txtAmount"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvAmt">
                                        </ajax:ValidatorCalloutExtender>
                                        <ajax:FilteredTextBoxExtender ID="ftbUsername" runat="server" TargetControlID="txtAmount"
                                            ValidChars="1234567890">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" align="left" valign="top">
                                        Days to Expire&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtMonthstoexpire" MaxLength="3" runat="server" CssClass="textfield_2" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Days to expire"
                                            ControlToValidate="txtMonthstoexpire" runat="server" Display="None" ValidationGroup="Save" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                        </ajax:ValidatorCalloutExtender>
                                        <ajax:FilteredTextBoxExtender ID="ftbtxtMonthstoexpire" runat="server" TargetControlID="txtMonthstoexpire"
                                            ValidChars="1234567890">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" align="right">
                                        &nbsp;
                                    </td>
                                    <td width="50%" align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" align="right">
                                        &nbsp;
                                    </td>
                                    <td width="50%" align="left">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="buttonBook" Text="Add" ValidationGroup="Save"
                                            OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="right" colspan="2">
                                        <table width="100%">
                                            <tr>
                                                <td width="50%" align="left" valign="top" style="padding-left:50px;">
                                                    Select Page size&nbsp;:&nbsp;
                                                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="Dropdownlist "
                                                        Width="100px" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <asp:ListItem Text="40" Value="1" />
                                                        <asp:ListItem Text="80" Value="2" />
                                                        <asp:ListItem Text="120" Value="3" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50%" align="right" style="padding-right:50px;">
                                                    <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClientClick="ExportGridviewtoExcel();"
                                                        OnClick="lbtnXport2Xcel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" colspan="2" align="right" style="padding-right: 50px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="center" colspan="2">
                                        <asp:GridView ID="gvPromoCodes" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true"
                                            Width="90%" EmptyDataText="No Promo Codes Added yet" runat="server" OnPageIndexChanging="gvPromoCodes_PageIndexChanging"
                                            OnRowDataBound="gvPromoCodes_RowDataBound" 
                                            OnSorting="gvPromoCodes_Sorting" onrowcommand="gvPromoCodes_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="PromoCodeId" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCouponId" Text='<%#Eval("PromoCodeId") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Promo Code No" SortExpression="PromoCode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPromoCode" Text='<%#Eval("PromoCode") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount" Text='<%#"Rs. "+Eval("Amount") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Days To Expire" SortExpression="MonthsToExpire">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMonthsToExpire" Text='<%#Eval("MonthsToExpire") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date of Creation" SortExpression="CreatedDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreatedDate" Text='<%#Eval("CreatedDate") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Expiry Date" SortExpression="ExpirationDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExpirationDate" Text='<%#Eval("ExpirationDate") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Created By" SortExpression="UserName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserName" Text='<%#Eval("UserName") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnstatus" runat="server" CommandName="status" CommandArgument='<%#Eval("PromoCodeId") %>'
                                                            OnClientClick="return confirm('Are you sure  to Activate/Deactivate Promo Code?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle Height="25px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Height="30px" />
                                            <EmptyDataRowStyle HorizontalAlign="Center" Height="30px" BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
