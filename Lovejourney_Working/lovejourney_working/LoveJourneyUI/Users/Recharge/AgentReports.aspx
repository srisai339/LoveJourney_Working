<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="AgentReports.aspx.cs" Inherits="Users_Recharge_AgentReports" %>

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
    <asp:UpdatePanel ID="UpdateReport2" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlSearch" runat="server" Style="background-color: White; width: 860px;">
            <table>
              <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
            </table>
                <table width="860px" id="tdagentReports" runat="server">
                    <tr>
                        <td class="heading" colspan="5" align="center" >
                            Agent/CSE/User Reports
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr colspan="6">
                        <td width="100%" align="center">
                            <table>
                            <tr width="100%">
                                    <td align="left" valign="top">
                                        <asp:Label ID="label4" runat="server" Text="Role"></asp:Label>
                                    </td>
                                    <td width="1%">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddltype" runat="server" CssClass="i2s_jp_seats" AutoPostBack="True"
                                            Width="120px" onselectedindexchanged="ddltype_SelectedIndexChanged">
                                            <asp:ListItem Text="Please Select" Value="Please Select"></asp:ListItem>
                                              <asp:ListItem Text="Agent" Value="Agent"></asp:ListItem>
                                                <asp:ListItem Text="CSE" Value="CSE"></asp:ListItem>
                                                  <asp:ListItem Text="User" Value="User"></asp:ListItem>
                                        </asp:DropDownList>
                                          <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" SkinID="mstVCE"
                                            TargetControlID="rfvrole">
                                        </ACT:ValidatorCalloutExtender>
                                        <asp:RequiredFieldValidator ID="rfvrole" runat="server" ControlToValidate="ddltype" InitialValue="Please Select"
                                            Display="None" ErrorMessage="Please select Role" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="middle">
                                      
                                    </td>
                                    <td width="1%">
                                       
                                    </td>
                                    <td>
                                     
                                    </td>
                                </tr>
                                <tr width="100%">
                                    <td align="left" valign="top">
                                        <asp:Label ID="labelAgentname" runat="server" Text="Agent Name"></asp:Label>
                                    </td>
                                    <td width="1%">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlAgentName" runat="server" CssClass="i2s_jp_seats" AutoPostBack="True"
                                            Width="120px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="middle">
                                        <asp:Label ID="Label2" runat="server" Text="Service"></asp:Label>
                                    </td>
                                    <td width="1%">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlservice" runat="server" CssClass="i2s_jp_seats" AutoPostBack="True">
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
                                </tr>
                                <tr id="tr" runat="server">
                                    <td align="left" valign="middle" width="20%">
                                        <asp:Label ID="lblFrom" runat="server" Text="From Date"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="txtDF" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Search"
                                            Width="120px" onkeyup="javascript:Adddob();"></asp:TextBox>
                                        <ACT:CalendarExtender ID="txtDF0_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            TargetControlID="txtDF">
                                        </ACT:CalendarExtender>
                                        <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" SkinID="mstVCE"
                                            TargetControlID="rfvDOJ">
                                        </ACT:ValidatorCalloutExtender>
                                        <asp:RequiredFieldValidator ID="rfvDOJ" runat="server" ControlToValidate="txtDF"
                                            Display="None" ErrorMessage="Please select From Date" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                    </td>
                                     <td width="4%">
                                        &nbsp;
                                    </td>
                                    <td align="left" width="20%">
                                        <asp:Label ID="Label1" runat="server" Text="ToDate"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left" valign="bottom" width="35%">
                                        <asp:TextBox ID="txtDT" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Search" Width="110px" onkeyup="javascript:Adddob1();"></asp:TextBox>
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
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button ID="btnSearch" runat="server"  OnClick="btnSearch_Click" CssClass="buttonBook"
                                Text="Search Services" ValidationGroup="Search" Width="100px" />&nbsp;
                             <asp:Button ID="btnExport" runat="server" Text="Export To Excel" Visible="true"
                                                    CssClass="buttonBook" Style="cursor: pointer;" onclick="btnExport_Click" />
                                                    
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
                        <td colspan="6">
                            <asp:GridView ID="gvMobile" runat="server" AutoGenerateColumns="False" GridLines="None"
                                PageSize="50" AllowPaging="True" PagerStyle-CssClass="i2s_jp_bustext" AlternatingRowStyle-CssClass="alt"
                                AllowSorting="True" ForeColor="#333333" Width="100%" OnPageIndexChanging="gvMobile_PageIndexChanging"
                                OnSorting="gvMobile_Sorting" OnRowDataBound="gvMobile_RowDataBound" CellPadding="4"
                                EnableModelValidation="True">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White"
                                    Font-Size="8" />
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="Name" DataField="FirstName" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="FirstName">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Recharge Date" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="MobileNo">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Commission" DataField="Commission" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Request Id" DataField="RequestID" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="RequestID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                   
                                    <%-- <asp:BoundField HeaderText="State" DataField="State" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="State" />
                                    <asp:BoundField HeaderText="City" DataField="City" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="City" />--%>
                                   <%-- <asp:BoundField HeaderText="Balance" DataField="BalanceAmount" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="BalanceAmount">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <br />
                            <table align="right" width="100%">
                                <tr>
                                    <%-- <td width="50px" align="right">
                                        <asp:Label ID="lblProviderName" runat="server" Font-Size="10px" Font-Bold="true"
                                            Visible="false"></asp:Label>
                                    </td>--%>
                                    <td width="100px" align="right">
                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Size="11px" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="100px" align="right">
                                        <asp:Label ID="lblTotalProfit" runat="server" Font-Size="11px" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="lblMobileMsg" runat="server" ForeColor="Red" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trD2HRecharge" runat="server">
                        <td colspan="4">
                            <asp:GridView ID="gvD2HRecharge" runat="server" AutoGenerateColumns="False" GridLines="None"
                                PageSize="50" AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="i2s_jp_bustext"
                                AlternatingRowStyle-CssClass="alt" AllowSorting="True" Width="100%" OnSorting="gvD2HRecharge_Sorting"
                                OnRowDataBound="gvD2HRecharge_RowDataBound" CellPadding="4" EnableModelValidation="True"
                                ForeColor="#333333">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="9"/>
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <%--     <asp:BoundField HeaderText="ID" DataField="ID" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />--%>
                                    <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Date of Recharge" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Customer Num" DataField="MobileNO" HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="Left" SortExpression="Customer_ID">
                                        <HeaderStyle ForeColor="white" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Request Id" DataField="RequestID" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="Center" SortExpression="RequestID">
                                        <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                      <asp:BoundField HeaderText="Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Commission" DataField="Commission" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                  
                                    <asp:BoundField HeaderText="Name" DataField="FirstName" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="Center" SortExpression="FirstName">
                                        <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <%-- <asp:BoundField HeaderText="State" DataField="State" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-ForeColor="Black" ItemStyle-HorizontalAlign="Center" SortExpression="State" />
                                    <asp:BoundField HeaderText="City" DataField="City" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-ForeColor="Black" ItemStyle-HorizontalAlign="Center" SortExpression="City" />--%>
                                   <%-- <asp:BoundField HeaderText="Balance" DataField="BalanceAmount" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-ForeColor="Black" ItemStyle-HorizontalAlign="Center" SortExpression="BalanceAmount">
                                        <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <br />
                            <table align="right" width="100%">
                                <tr>
                                    <td width="100px" align="right">
                                        <asp:Label ID="Label3DEH" runat="server" Font-Size="11px" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="100px" align="right">
                                        <asp:Label ID="Label4D2hComm" runat="server" Font-Size="11px" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Label ID="lblD2HMsg1" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="lblD2HMsg" runat="server" ForeColor="Red" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="Button1" runat="server" Text="Export" CausesValidation="false" Visible="false"
                                CssClass="i2s_jp_status1" />
                        </td>
                    </tr>
                    <tr id="trDataCardRecharge" runat="server">
                        <td colspan="4">
                            <asp:GridView ID="gvDataCard" runat="server" AutoGenerateColumns="False" GridLines="None"
                                PageSize="50" AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="i2s_jp_bustext"
                                AlternatingRowStyle-CssClass="alt" AllowSorting="True" Width="100%" OnPageIndexChanging="gvDataCard_PageIndexChanging"
                                OnSorting="gvDataCard_Sorting" OnRowDataBound="gvDataCard_RowDataBound" CellPadding="4"
                                EnableModelValidation="True" ForeColor="#333333">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="Provider Names" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Recharge Date" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="MobileNo" HeaderStyle-ForeColor="white">
                                        <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Request Id" DataField="RequestID" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="E_Mail" HeaderStyle-ForeColor="white">
                                        <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Commission" DataField="Commission" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Name" DataField="FirstName" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="FirstName" HeaderStyle-ForeColor="white">
                                        <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <%--  <asp:BoundField HeaderText="State" DataField="State" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="State" HeaderStyle-ForeColor="Black" />
                                    <asp:BoundField HeaderText="City" DataField="City" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="City" HeaderStyle-ForeColor="Black" />--%>
                                   <%-- <asp:BoundField HeaderText="Balance" DataField="BalanceAmount" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-ForeColor="Black" ItemStyle-HorizontalAlign="Center" SortExpression="BalanceAmount">
                                        <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <br />
                            <asp:Label ID="lblDataCard" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                            <table align="right" width="100%">
                                <tr>
                                    <td width="100px" align="right">
                                        <asp:Label ID="Label3" runat="server" Font-Size="10px" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="100px" align="right">
                                        <asp:Label ID="Label4dataCommi" runat="server" Font-Size="10px" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Label ID="Label6" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="lblDataCardmsg" runat="server" ForeColor="Red" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
