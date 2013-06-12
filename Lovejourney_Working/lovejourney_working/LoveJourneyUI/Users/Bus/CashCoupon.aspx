<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="CashCoupon.aspx.cs" Inherits="Users_CashCoupon" %>

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
            <asp:Panel ID="pnlCashCoupon" runat="server" Width="100%">
                <table width="100%" bgcolor="#ffffff">
                    <tr>
                    <td width="100%" align="center" class="heading">
                      Cash Coupons
                    </td>
                       <%-- <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                            font-weight: bold; color: Maroon;">
                            Cash Coupons
                        </td>--%>
                    </tr>
                    <tr>
                        <td width="100%" align="right" valign="top" class="busoperator_text_head">
                            <asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                                ID="btnSearch" Text="GO" runat="server" CssClass="buttonBook" ValidationGroup="search" CausesValidation="false"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" valign="top">
                            <asp:Panel ID="pnlAddCoupon" DefaultButton="btnAdd" runat="server" Width="100%">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="100%" align="center" colspan="2">
                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />
                                            <asp:Label ID="lblCode" runat="server" Visible="false" />
                                        </td>
                                    </tr>
                                     <tr>
                                  <td align="right" width="50%"  valign="top">
                                                    Operater Name
                                                </td>
                                                <td width="50%" align="left" valign="bottom">
                                                    <asp:DropDownList ID="ddlserviceName" runat="server" Width="160" Height="25px">
                                                        <asp:ListItem Value="-Please Select-">-Please Select-</asp:ListItem>
                                                        <asp:ListItem Value="Flights">Flights</asp:ListItem>                                                        
                                                        <asp:ListItem Value="Hotels">Hotels</asp:ListItem>
                                                        <asp:ListItem Value="Bus">Bus</asp:ListItem>
                                                        <%--<asp:ListItem Value="Recharge">Recharge</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Add"
                                                        InitialValue="-Please Select-" ControlToValidate="ddlserviceName" ErrorMessage="Please enter Service Name"
                                                        Display="None"></asp:RequiredFieldValidator>
                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" TargetControlID="RequiredFieldValidator1">
                                                    </ajax:ValidatorCalloutExtender>
                                                </td>
                                 </tr>
                                 <tr><td style="height:3px;"></td></tr>
                                  <tr>
                                    <td width="50%" align="right" valign="top">
                                        CashCoupon No&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtcahcoupon"  runat="server" CssClass="textfield_2" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Enter CashCoupon No" ControlToValidate="txtcahcoupon"
                                            runat="server" Display="None" ValidationGroup="Add" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                        </ajax:ValidatorCalloutExtender>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtcahcoupon"
                                            ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSUVWXYZ">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                    <tr>
                                        <td width="50%" align="right" valign="top">
                                            Amount&nbsp;:&nbsp;
                                        </td>
                                        <td width="50%" align="left" valign="bottom">
                                            <asp:TextBox ID="txtAmount" MaxLength="10" runat="server" CssClass="textfield_2" />
                                            <asp:RequiredFieldValidator ID="rfvAmt" ErrorMessage="Enter Amount" ControlToValidate="txtAmount"
                                                runat="server" Display="None" ValidationGroup="Add" /><ajax:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvAmt" WarningIconImageUrl="~/images/icon-warning.png"
                                                    CloseImageUrl="~/images/icon-close4.png" CssClass="CustomValidatorCalloutStyle"
                                                    PopupPosition="Right">
                                                </ajax:ValidatorCalloutExtender>
                                            <ajax:FilteredTextBoxExtender ID="ftbUsername" runat="server" TargetControlID="txtAmount"
                                                ValidChars="1234567890">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" align="right" valign="top">
                                            Email ID&nbsp;:&nbsp;
                                        </td>
                                        <td width="50%" align="left" valign="bottom">
                                            <asp:TextBox ID="txtEmailID" MaxLength="100" runat="server" CssClass="textfield_2" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Email ID"
                                                ControlToValidate="txtEmailID" runat="server" Display="None" ValidationGroup="Add" />
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                WarningIconImageUrl="~/images/icon-warning.png" CloseImageUrl="~/images/icon-close4.png"
                                                CssClass="CustomValidatorCalloutStyle" PopupPosition="Right">
                                            </ajax:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="revEmail" ErrorMessage="Enter a valid Email Id"
                                                ControlToValidate="txtEmailID" runat="server" Display="None" ValidationGroup="Add"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="revEmail"
                                                WarningIconImageUrl="~/images/icon-warning.png" CloseImageUrl="~/images/icon-close4.png"
                                                CssClass="CustomValidatorCalloutStyle" PopupPosition="Right">
                                            </ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                     <tr>
                                    <td width="50%" align="right" valign="top">
                                       Min Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtminamt" MaxLength="3" runat="server" CssClass="textfield_2" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Enter Min Amount" ControlToValidate="txtminamt"
                                            runat="server" Display="None" ValidationGroup="Add" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator4">
                                        </ajax:ValidatorCalloutExtender>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtminamt"
                                            ValidChars="1234567890">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                </tr
                                      <tr>
                                    <td width="50%" align="right" valign="top">
                                       Max Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtmaxamt" MaxLength="3" runat="server" CssClass="textfield_2" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Enter Max Amount" ControlToValidate="txtmaxamt"
                                            runat="server" Display="None" ValidationGroup="Add" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator5">
                                        </ajax:ValidatorCalloutExtender>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtmaxamt"
                                            ValidChars="1234567890">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                </tr
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
                                            <asp:Button ID="btnAdd" runat="server" CssClass="buttonBook" Text="Add" ValidationGroup="Add"
                                                OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="right" colspan="2">
                                            <table width="100%">
                                                <tr>
                                                    <td width="50%" align="left" valign="top" style="padding-left: 50px;">
                                                        Select Page size&nbsp;:&nbsp;
                                                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="Dropdownlist "
                                                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="100px">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="40" Value="1" />
                                                            <asp:ListItem Text="80" Value="2" />
                                                            <asp:ListItem Text="120" Value="3" />
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="50%" align="right" style="padding-right: 50px;">
                                                        <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server" CausesValidation="false"
                                                            Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClick="lbtnXport2Xcel_Click"
                                                            OnClientClick="ExportGridviewtoExcel();" />
                                                    </td>
                                                </tr>
                                            </table>
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
                                        <td width="100%" align="center" colspan="2">
                                            <asp:GridView ID="gvcashcoupons" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true"
                                                Width="90%" EmptyDataText="No Cash Coupons Added yet" runat="server" OnRowDataBound="gvcashcoupons_RowDataBound"
                                                OnSorting="gvcashcoupons_Sorting" OnPageIndexChanging="gvcashcoupons_PageIndexChanging"
                                                OnRowCommand="gvcashcoupons_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="CouponId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCouponId" Text='<%#Eval("CouponId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Coupon No" SortExpression="CouponNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCouponNo" Text='<%#Eval("CouponNo") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Operater Name" SortExpression="OperaterName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOperaterName" Text='<%#Eval("OperaterName") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="EmailID" SortExpression="EmailId">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmailID" Text='<%#Eval("EmailId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" Text='<%#Eval("Amount") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Min Amount" SortExpression="MinAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMinAmount" Text='<%#"Rs. "+Eval("MinAmount") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Max Amount" SortExpression="MaxAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMaxAmount" Text='<%#"Rs. "+Eval("MaxAmount") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Creation" SortExpression="DateOfCreation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateofCreation" Text='<%#Eval("DateOfCreation") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Expiry Date" SortExpression="ExpiryDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExpiryDate" Text='<%#Eval("ExpiryDate") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Created By" SortExpression="CreatedBy">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCreatedBy" Text='<%#Eval("CreatedBy") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Modified By" SortExpression="ModifiedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblModifiedBy" Text='<%#Eval("ModifiedBy") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnstatus" runat="server" CommandName="status" CommandArgument='<%#Eval("CouponId") %>'
                                                                OnClientClick="return confirm('Are you sure  to Activate/Deactivate Coupon?');" />
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
