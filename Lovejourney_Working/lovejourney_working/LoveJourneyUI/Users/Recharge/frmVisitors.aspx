<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="frmVisitors.aspx.cs" Inherits="Users_Recharge_frmVisitors" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ACT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    function Adddob() {
        //alert('hi');
        document.getElementById('<%=txtDF.ClientID %>').value = "";

    }
    function Adddob1() {
        //alert('hi');
        document.getElementById('<%=txtDT.ClientID %>').value = "";

    }

      
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <asp:Panel ID="pnlSearch" runat="server" Style="background-color: White; width: 960px;">
     <table>
              <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
            </table>
        <table width="960px" id="tblpendingRepports" runat="server">
            <tr>
                <td class="heading" colspan="5" align="center" >
                    Pending Reports
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
                    <asp:DropDownList ID="ddlservice" runat="server" CssClass="i2s_jp_seats">
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
                <td align="right" valign="middle" width="20%">
                    <asp:Label ID="lblFrom" runat="server" Text="From Date :"></asp:Label>
                </td>
                <td align="left" valign="middle" width="25%">
                    <asp:TextBox ID="txtDF" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Search" onkeyup="javascript:Adddob();"></asp:TextBox>
                    <ACT:CalendarExtender ID="txtDF0_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtDF">
                    </ACT:CalendarExtender>
                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" SkinID="mstVCE"
                        TargetControlID="rfvDOJ">
                      
                    </ACT:ValidatorCalloutExtender>
                   
                    <asp:RequiredFieldValidator ID="rfvDOJ" runat="server" ControlToValidate="txtDF"
                        Display="None" ErrorMessage="Please select From Date" ValidationGroup="Search"></asp:RequiredFieldValidator>
                </td>
                <td align="right" width="7%" valign="middle">
                    <asp:Label ID="Label1" runat="server" Text="ToDate :"></asp:Label>
                </td>
                <td align="left" valign="middle" width="25%">
                    <asp:TextBox ID="txtDT" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Search" onkeyup="javascript:Adddob1();"></asp:TextBox>
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
                <%-- <td align="right" valign="middle" width="20%">
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
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="buttonBook"
                        Text="Search Services" ValidationGroup="Search" Width="100px" />
                </td>
            </tr>
            <tr id="Tr1" runat="server">
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
                                    <asp:ListItem Value="3">900</asp:ListItem>
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
                        AllowSorting="True" ForeColor="#333333" Width="100%" OnPageIndexChanging="gvMobile_PageIndexChanging"
                        CellPadding="4" EnableModelValidation="True">
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="9"/>
                        <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date of Recharge" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Name" DataField="FirstName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Address" DataField="Address" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
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
                </td>
            </tr>
            <tr>
                <td colspan="5" align="center">
                    <asp:Label ID="lblMobileMsg" runat="server" ForeColor="Red" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr id="trD2HRecharge" runat="server">
                <td colspan="5">
                    <asp:GridView ID="gvD2HRecharge" runat="server" AutoGenerateColumns="False" GridLines="None"
                        PageSize="50" AllowPaging="True" PagerStyle-CssClass="i2s_jp_bustext" AlternatingRowStyle-CssClass="alt"
                        AllowSorting="True" Width="100%" OnPageIndexChanging="gvD2HRecharge_PageIndexChanging"
                        CellPadding="4" EnableModelValidation="True" ForeColor="#333333">
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="9"/>
                        <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date of Recharge" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Customer Num" DataField="MobileNO" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Center"
                                Visible="false" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Name" DataField="FirstName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Address" DataField="Address" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <table align="center">
                        <tr valign="top">
                            <td colspan="5">
                                <asp:Label ID="lblD2HMsg1" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr valign="top" align="center">
                <td colspan="5">
                    <asp:Label ID="lblD2HMsg" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr id="tr2" runat="server">
                <td colspan="5">
                    <asp:GridView ID="gvDataCardRecharge" runat="server" AutoGenerateColumns="False"
                        GridLines="None" PageSize="50" AllowPaging="True" PagerStyle-CssClass="i2s_jp_bustext"
                        AlternatingRowStyle-CssClass="alt" AllowSorting="True" ForeColor="#333333" Width="100%"
                        OnPageIndexChanging="gvDataCard_PageIndexChanging" CellPadding="4" EnableModelValidation="True">
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="9"/>
                        <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date of Recharge" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Name" DataField="FirstName" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Address" DataField="Address" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
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
