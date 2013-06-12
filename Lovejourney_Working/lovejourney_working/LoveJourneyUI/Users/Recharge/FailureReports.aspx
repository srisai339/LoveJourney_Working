<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="FailureReports.aspx.cs" Inherits="Users_Recharge_FailureReports" %>

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
  
    <asp:UpdatePanel ID="updatereport3" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlSearch" runat="server" Style="background-color: White; 
                width: 1000px;">
                 <table >
              <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
            </table>
                <table width="950px" id="tdfailurereport" runat="server" align="center">
                    <tr>
                        <td class="heading" colspan="5" align="center" >
                            Failure Transactions Report
                        </td>
                    </tr>
                  
                    <tr>
                        <td align="left" valign="middle" colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%"  valign="middle">
                            <asp:Label ID="Label2" runat="server" Text="Service:"></asp:Label>
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
                         <td align="right" valign="middle" width="32%">
                            <asp:Label ID="lblFrom" runat="server" Text="From Date :"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="25%">
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
                        <td align="right" width="10%">
                            <asp:Label ID="Label1" runat="server" Text="ToDate:"></asp:Label>
                        </td>
                        <td align="left" valign="bottom" width="35%">
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
                       <%-- <td align="right" valign="middle" width="32%">
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
                        <td align="right" width="10%">
                            <asp:Label ID="Label1" runat="server" Text="ToDate:"></asp:Label>
                        </td>
                        <td align="left" valign="bottom" width="35%">
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
                                Text="Search Services" ValidationGroup="Search" Width="100px" />&nbsp;&nbsp;
                                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel" Visible="true"
                                                    CssClass="buttonBook" Style="cursor: pointer;" />
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
                                OnSorting="gvMobile_Sorting" CellPadding="4" EnableModelValidation="True">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" Font-Size="9"
                                    ForeColor="White"/>
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                  <asp:BoundField HeaderText="Type" DataField="Type" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Recharge Date" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="MobileNo" 
                                        HeaderStyle-ForeColor="white" >
                                    <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="EmailID" DataField="E_Mail" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="E_Mail" 
                                        HeaderStyle-ForeColor="white" >
                                           <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
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
                                    <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
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
                                OnSorting="gvD2HRecharge_Sorting" CellPadding="4" EnableModelValidation="True" 
                                ForeColor="#333333">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True"  Font-Size="9"
                                    ForeColor="White"/>
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <%--     <asp:BoundField HeaderText="ID" DataField="ID" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />--%>
                                  <asp:BoundField HeaderText="Type" DataField="Type" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Date of Recharge" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="EmailID" DataField="E_Mail" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="E_Mail" 
                                        HeaderStyle-ForeColor="white" >
                                    <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Customer Num" DataField="MobileNO" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" >
                                           <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                           <asp:BoundField HeaderText="Request ID" DataField="RequestID" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField HeaderText="Prfit" DataField="Commission" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-HorizontalAlign="Right" />--%>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <br />
                            <table align="right">
                                <tr>
                                    <td width="50px" align="right">
                                        <asp:Label ID="lblD2HProvider" runat="server" Font-Size="10px" Font-Bold="true" Visible="false"></asp:Label>
                                    </td>
                                    <td width="50px" align="right">
                                        <asp:Label ID="lblD2HTotal" runat="server" Font-Size="10px" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="50px" align="right">
                                        <asp:Label ID="lblD2HTotalProfit" runat="server" Font-Size="10px" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Label ID="lblD2HMsg1" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Label ID="lblD2HMsg" runat="server" ForeColor="Red" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:Button ID="Button1" runat="server" Text="Export" CausesValidation="false" Visible="false"
                                CssClass="i2s_jp_status1" />
                        </td>
                    </tr>
                    <tr id="trDataCardRecharge" runat="server" >
                        <td colspan="5">
                            <asp:GridView ID="gvDataCard" runat="server" AutoGenerateColumns="False" GridLines="None"
                                PageSize="50" AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="i2s_jp_bustext"
                                AlternatingRowStyle-CssClass="alt" AllowSorting="True" Width="100%" OnPageIndexChanging="gvDataCard_PageIndexChanging"
                                OnSorting="gvDataCard_Sorting" CellPadding="4" 
                                EnableModelValidation="True" ForeColor="#333333">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True"  Font-Size="9"
                                    ForeColor="White"/>
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                  <asp:BoundField HeaderText="Type" DataField="Type" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Provider Name" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Recharge Date" DataField="CreatedDate" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="EmailID" DataField="E_Mail" HeaderStyle-HorizontalAlign="Center" Visible="false"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="E_Mail" 
                                        HeaderStyle-ForeColor="white" >
                                    <HeaderStyle ForeColor="white" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mobile Num" DataField="MobileNo" HeaderStyle-HorizontalAlign="Center"
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
                                    <asp:BoundField HeaderText="Recharge Amount" DataField="Amount" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <br />
                            <asp:Label ID="lblDataCard" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                            <table align="right">
                                <tr>
                                    <td width="50px" align="right">
                                        <asp:Label ID="Label3" runat="server" Font-Size="10px" Font-Bold="true" Visible="false"></asp:Label>
                                    </td>
                                    <td width="50px" align="right">
                                        <asp:Label ID="Label4" runat="server" Font-Size="10px" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="50px" align="right">
                                        <asp:Label ID="Label5" runat="server" Font-Size="10px" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Label ID="Label6" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Label ID="lblDataCardmsg" runat="server" ForeColor="Red" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
