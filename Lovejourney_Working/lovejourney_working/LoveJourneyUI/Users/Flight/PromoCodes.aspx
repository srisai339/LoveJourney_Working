<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Flight/MasterPage.master" AutoEventWireup="true" CodeFile="PromoCodes.aspx.cs" Inherits="Users_Flight_PromoCodes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">      $(document).ready(function () {
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
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
            <table width="100%">
            
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
                            ID="btnSearch" Text="GO" runat="server" CssClass="lj_inp"
                            ValidationGroup="search" onclick="btnSearch_Click"
                            />
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
                                  <td align="left" width="50%"  valign="top">
                                                    Operater Name
                                                </td>
                                                <td width="50%" align="left" valign="bottom">
                                                    <asp:DropDownList ID="ddlserviceName" runat="server" Width="160">
                                                        <asp:ListItem Value="-Please Select-">-Please Select-</asp:ListItem>
                                                        <asp:ListItem Value="Flights">Flights</asp:ListItem>                                                        
                                                        <asp:ListItem Value="Hotels">Hotels</asp:ListItem>
                                                        <asp:ListItem Value="Bus">Bus</asp:ListItem>
                                                        <%--<asp:ListItem Value="Recharge">Recharge</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="one"
                                                        InitialValue="-Please Select-" ControlToValidate="ddlserviceName" ErrorMessage="Please enter Service Name"
                                                        Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                 </tr>
                                  <tr>
                                    <td width="50%" align="left" valign="top">
                                        Promo Code&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtpromocode"  runat="server" CssClass="textfield_2" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Enter Promocode" ControlToValidate="txtpromocode"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                        </asp:ValidatorCalloutExtender>
                                         <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtpromocode"
                                          ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSUVWXYZ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" align="left" valign="top">
                                        Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtAmount" MaxLength="3" runat="server" CssClass="textfield_2" />
                                        <asp:RequiredFieldValidator ID="rfvAmt" ErrorMessage="Enter Amount" ControlToValidate="txtAmount"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvAmt">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="ftbUsername" runat="server" TargetControlID="txtAmount"
                                            ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
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
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="ftbtxtMonthstoexpire" runat="server" TargetControlID="txtMonthstoexpire"
                                            ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                      <tr>
                                    <td width="50%" align="left" valign="top">
                                       Min Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtminamt" MaxLength="3" runat="server" CssClass="textfield_2" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Enter Min Amount" ControlToValidate="txtminamt"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator4">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtminamt"
                                            ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr
                                      <tr>
                                    <td width="50%" align="left" valign="top">
                                       Max Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtmaxamt" MaxLength="3" runat="server" CssClass="textfield_2" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Enter Max Amount" ControlToValidate="txtmaxamt"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator5">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtmaxamt"
                                            ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr
                                <tr>
                                <tr>
                                <td>&nbsp;&nbsp;</td>
                                   <td  colspan="3">
                                   <asp:CheckBox ID="chkSingleUser" runat="server" Text="Single User" />
                                   

                                    <asp:CheckBox ID="chkMultipleUser" runat="server" Text="Multiple User" />
                                   </td>
                                </tr>
                                 
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
                                                        Width="100px" onselectedindexchanged="ddlPageSize_SelectedIndexChanged" >
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <asp:ListItem Text="40" Value="1" />
                                                        <asp:ListItem Text="80" Value="2" />
                                                        <asp:ListItem Text="120" Value="3" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50%" align="right" style="padding-right:50px;">
                                                    <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" 
                                                        OnClientClick="ExportGridviewtoExcel();" onclick="lbtnXport2Xcel_Click"
                                                         />
                                                </td>
                                            </tr       </td>
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
                                            Width="90%" EmptyDataText="No Promo Codes Added yet" runat="server" 
                                            onpageindexchanging="gvPromoCodes_PageIndexChanging" 
                                            onrowcommand="gvPromoCodes_RowCommand" 
                                            onrowdatabound="gvPromoCodes_RowDataBound" onsorting="gvPromoCodes_Sorting">
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
                                                     <asp:TemplateField HeaderText="Operater Name" SortExpression="OperaterName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOperaterName" Text='<%#Eval("OperaterName") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount" Text='<%#"Rs. "+Eval("Amount") %>' runat="server" />
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

