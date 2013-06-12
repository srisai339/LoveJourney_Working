<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Flight/MasterPage.master" AutoEventWireup="true" CodeFile="frmSalesReport.aspx.cs" Inherits="Users_Flight_frmSalesReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <table>
     <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblmsg1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
     <asp:Panel ID="panelBookingStatus" runat="server">
    <table width="100%">
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" class="heading">
                <asp:Label ID="Label1" runat="server" Text="Sales Report" Font-Size="13px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="right">
                            From Date
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtdate" Width="150" runat="server" onkeypress="javascript:return false;">
                            </asp:TextBox>
                            <asp:ImageButton runat="Server" ID="Image1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate"
                                Enabled="True" PopupButtonID="Image1">
                            </ajax:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            To Date
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtrefno" Width="150" runat="server" onkeypress="javascript:return false;">
                            </asp:TextBox>
                            <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtrefno"
                                Enabled="True" PopupButtonID="ImageButton1">
                            </ajax:CalendarExtender>
                        </td>
                    </tr>
                
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />&nbsp;
                                                                         <asp:Button ID="btnExport" runat="server" Text="Export To Excel" Visible="true"
                                                    CssClass="buttonBook" Style="cursor: pointer;" onclick="btnExport_Click" />
                                                    
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:Label ID="lblerrormsg" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="right" colspan="2" id="trpaging" runat="server">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblpaging" runat="server" Text="Paging  :" CssClass="label"></asp:Label>
                            <asp:DropDownList ID="ddlpaging" runat="server" CssClass="picklist" AutoPostBack="true"
                                Width="100px" OnSelectedIndexChanged="ddlpaging_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="40"></asp:ListItem>
                                <asp:ListItem Value="2" Text="80"></asp:ListItem>
                                <asp:ListItem Value="3" Text="120"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center">
                            <div id="divDeposits" runat="server" visible="true">
                                <asp:GridView ID="gvDeposits" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" OnPageIndexChanging="gvDeposits_PageIndexChanging"
                                    Width="100%" PageSize="20" EmptyDataText="No Data Found" ShowFooter="True" OnRowDataBound="gvDeposits_RowDataBound"
                                    OnSorting="gvDeposits_Sorting">
                                    <EmptyDataRowStyle ForeColor="#CC0000" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No" SortExpression="">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Booking Date" SortExpression="BookingDate" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookingDate" runat="server" Text='<%# Eval("BookingDate") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No. Adults" SortExpression="NoOfAdults" FooterStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfAdults" runat="server" Text='<%# Eval("NoOfAdults") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No. Childs" SortExpression="NoOfChilds" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfChilds" runat="server" Text='<%# Eval("NoOfChilds") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No. Infants" SortExpression="NoofInfants">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoofInfants" runat="server" Text='<%# Eval("NoofInfants") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agent Amount" SortExpression="AgentAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgentAmount" runat="server" Text='<%# Eval("AgentAmount") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                               <asp:Label ID="lblTotal" runat="server" Text="" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commision Fare" SortExpression="CommisionFare">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCommisionFare" runat="server" Text='<%# Eval("CommisionFare") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            <asp:Label ID="lblCommisionFareTotal" runat="server" Text="" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px"
                                        HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <RowStyle ForeColor="#000066" Height="25px" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="25px"
                                        HorizontalAlign="Center" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                                        Height="25px" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>