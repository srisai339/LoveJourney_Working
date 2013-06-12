<%@ Page Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master" AutoEventWireup="true"
    CodeFile="~/Users/Recharge/frmCheckGain.aspx.cs" Inherits="Users_Recharge_frmCheckGain" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ACT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/abcd-home.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <%-- <link href="../stylesheet/style.css" rel="stylesheet" type="text/css" />--%>
    <asp:Panel ID="pnlSearch" runat="server" Style="background-color: White; width: 860px;">
        <table width="860px">
            <tr>
                <td class="heading" colspan="5" align="center" height="30">
                    Transactions Report
                </td>
            </tr>
          
            <tr>
                <td align="left" valign="middle" colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle">
                    <asp:Label ID="Label2" runat="server" Text="Service:"></asp:Label>
                    <asp:DropDownList ID="ddlservice" runat="server" CssClass="i2s_jp_seats" >
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                        <asp:ListItem Value="1">Mobile Recharge</asp:ListItem>
                        <asp:ListItem Value="2">D2H  Recharge</asp:ListItem>
                        <asp:ListItem Value="3">DataCard Recharge</asp:ListItem>
                           <asp:ListItem Value="4">ALL</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cvservice" runat="server" ControlToValidate="ddlService"
                        ValueToCompare="0" ErrorMessage="Please select Service" Display="None" Type="Integer"
                        ValidationGroup="Search" Operator="NotEqual"></asp:CompareValidator>
                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" SkinID="mstVCE"
                        TargetControlID="cvservice">
                    </ACT:ValidatorCalloutExtender>
                </td>
                <td align="right" valign="middle" width="15%">
                    <asp:Label ID="lblFrom" runat="server" Text="From Date :"></asp:Label>
                </td>
                <td align="left" valign="middle" width="15%">
                    <asp:TextBox ID="txtDF" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Search"></asp:TextBox>
                    <ACT:CalendarExtender ID="txtDF0_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtDF">
                    </ACT:CalendarExtender>
                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" SkinID="mstVCE"
                        TargetControlID="rfvDOJ">
                    </ACT:ValidatorCalloutExtender>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvDOJ" runat="server" ControlToValidate="txtDF"
                        Display="None" ErrorMessage="Please select From Date" ValidationGroup="Search"></asp:RequiredFieldValidator>
                </td>
                <td align="right" width="15%">
                    <asp:Label ID="Label1" runat="server" Text="ToDate :"></asp:Label>
                </td>
                <td align="left" valign="middle" width="25%">
                    <asp:TextBox ID="txtDT" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Search"></asp:TextBox>
                    <ACT:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDT" runat="server"
                        Format="dd/MM/yyyy" PopupButtonID="imgDate">
                    </ACT:CalendarExtender>
                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" SkinID="mstVCE"
                        TargetControlID="rfvfrom">
                    </ACT:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="rfvfrom" runat="server" ControlToValidate="txtDT"
                        Display="None" ErrorMessage="Please select To Date" ValidationGroup="Search"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="tr" runat="server">
                <%--  <td align="right" valign="middle" width="20%">
                    <asp:Label ID="lblFrom" runat="server" Text="From Date :"></asp:Label>
                </td>
                <td align="left" valign="top" width="25%">
                    <asp:TextBox ID="txtDF" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Search"></asp:TextBox>
                    <ACT:CalendarExtender ID="txtDF0_CalendarExtender" runat="server" Format="MM/dd/yyyy"
                        TargetControlID="txtDF">
                    </ACT:CalendarExtender>
                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" SkinID="mstVCE"
                        TargetControlID="rfvDOJ">
                    </ACT:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="rfvDOJ" runat="server" ControlToValidate="txtDF"
                        Display="None" ErrorMessage="Please select From Date" ValidationGroup="Search"></asp:RequiredFieldValidator>
                </td>
                <td align="right" width="5%">
                    <asp:Label ID="Label1" runat="server" Text="ToDate :"></asp:Label>
                </td>
                <td align="left" valign="bottom" width="25%">
                    <asp:TextBox ID="txtDT" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Search"></asp:TextBox>
                    <ACT:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDT" runat="server"
                        Format="MM/dd/yyyy" PopupButtonID="imgDate">
                    </ACT:CalendarExtender>
                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" SkinID="mstVCE"
                        TargetControlID="rfvfrom">
                    </ACT:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="rfvfrom" runat="server" ControlToValidate="txtDT"
                        Display="None" ErrorMessage="Please select To Date" ValidationGroup="Search"></asp:RequiredFieldValidator>
                </td>--%>
            </tr>
           
            <tr>
                <td align="center" colspan="5">
                    <asp:Button ID="btnSearch" runat="server" CssClass="buttonBook" OnClick="btnSearch_Click"
                        Text="Search Services" ValidationGroup="Search" Width="100px" />
                </td>
            </tr>
          
            <tr runat="server">
                <td colspan="5" align="center">
                 
                   
                    <table align="right">
                        <tr id="paging" runat="server" visible="false">
                            <td align="left">
                                <asp:Label ID="lblpagesize" runat="server" Text="Paging Size:"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:DropDownList ID="ddlpagesize" runat="server" CssClass="i2s_jp_seats" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlpagesize_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Please Select</asp:ListItem>
                                    <asp:ListItem Value="1">300</asp:ListItem>
                                    <asp:ListItem Value="2">600</asp:ListItem>
                                    <asp:ListItem Value="2">900</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="lblerrMsg" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr id="trMobileService" runat="server">
                <td colspan="5">
                    <asp:GridView ID="gvMobile" runat="server" AutoGenerateColumns="False" GridLines="None"
                        PageSize="50" AllowPaging="True" PagerStyle-CssClass="i2s_jp_bustext" AlternatingRowStyle-CssClass="alt"
                        AllowSorting="True" ForeColor="#333333" Width="100%" 
                        OnPageIndexChanging="gvMobile_PageIndexChanging" CellPadding="4" 
                        EnableModelValidation="True">
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" 
                            ForeColor="White" />
                        <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date of Recharge" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                                   <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                   <asp:BoundField HeaderText="Request ID" DataField="RequestID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                                 <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                 <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <br />
                    <table align="center">
                        <tr>
                            <td width="50px" align="right">
                                <asp:Label ID="lblProviderName" runat="server" Font-Size="10px" Font-Bold="true"
                                    Visible="false"></asp:Label>
                            </td>
                            <td width="50px" align="right">
                                <asp:Label ID="lblTotalAmount" runat="server" Font-Size="10px" Font-Bold="true"></asp:Label>
                            </td>
                            <td width="50px" align="right">
                                <asp:Label ID="lblTotalProfit" runat="server" Font-Size="10px" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="5" align="center">
                    <asp:Label ID="lblMobileMsg" runat="server" ForeColor="Red" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr id="trD2HRecharge" runat="server" >
                <td colspan="5">
                    <asp:GridView ID="gvD2HRecharge" runat="server" AutoGenerateColumns="False" GridLines="None"
                        PageSize="50" AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="i2s_jp_bustext"
                        AlternatingRowStyle-CssClass="alt" AllowSorting="True" Width="100%" 
                        OnPageIndexChanging="gvD2HRecharge_PageIndexChanging" CellPadding="4" 
                        EnableModelValidation="True" ForeColor="#333333">
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" 
                            ForeColor="White" />
                        <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date of Recharge" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Customer Num" DataField="MobileNO" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                                <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                <asp:BoundField HeaderText="Request ID" DataField="RequestID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                          
                            <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                                  <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                  <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <br />
                    <table align="center">
                        <tr valign="top">
                            <td colspan="4">
                                <asp:Label ID="lblD2HMsg1" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr valign="top" align="center">
                <td colspan="5">
                    <asp:Label ID="lblD2HMsg" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr id="tr1" runat="server">
                <td colspan="5">
                    <asp:GridView ID="gvDataCardRecharge" runat="server" AutoGenerateColumns="False"
                        GridLines="None" PageSize="50" AllowPaging="True" PagerStyle-CssClass="i2s_jp_bustext"
                        AlternatingRowStyle-CssClass="alt" AllowSorting="True" ForeColor="#333333" Width="100%"
                        OnPageIndexChanging="gvDataCard_PageIndexChanging" CellPadding="4" 
                        EnableModelValidation="True">
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" 
                            ForeColor="White" />
                        <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date of Recharge" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                                <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                <asp:BoundField HeaderText="Request ID" DataField="RequestID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                                  <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                  <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5" valign="top" align="center">
                    <asp:Label ID="lblDataCardmsg" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="Button1" runat="server" Text="Export" CausesValidation="false" OnClick="Button1_Click"
                        Visible="false" CssClass="i2s_jp_status1" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
