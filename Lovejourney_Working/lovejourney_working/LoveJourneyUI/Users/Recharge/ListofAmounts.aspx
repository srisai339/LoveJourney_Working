<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="ListofAmounts.aspx.cs" Inherits="Users_ListofAmounts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <table width="900" height="350px" align="center">
    <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="900" valign="top" align="center" >
                <table width="900" align="center" id="tdlistofamount" runat="server">
                    <tr>
                        <td align="center" colspan="2" class="heading" height="20px">
                            <asp:Label ID="labelHeading" runat="server" Font-Size="16px" Text="List Of Amounts"></asp:Label>
                        </td>
                    </tr>
                
                    <tr>
                        <td>
                        &nbsp;
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Literal7" runat="server" Text="Operator Name"></asp:Literal>&nbsp;&nbsp;
                        </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddloperators" runat="server" Width="150px" Height="20px" CssClass="i2s_jp_seats"
                                AutoPostBack="true" OnSelectedIndexChanged="ddloperators_SelectedIndexChanged">
                                <asp:ListItem Value="Select Service">Select Service</asp:ListItem>
                                <asp:ListItem Value="Mobile">Mobile</asp:ListItem>
                                <asp:ListItem Value="DTH">DTH</asp:ListItem>
                                <asp:ListItem Value="DataCard">DataCard</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ValidatorCalloutExtender ID="vceOpearators" runat="server" CloseImageUrl="~/images/Closing.png"
                                PopupPosition="Left" TargetControlID="cvOperator" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="cvOperator" runat="server" ControlToValidate="ddloperators"
                                Display="None" ErrorMessage="Please select Operator Name" Operator="NotEqual"
                                Type="String" ValidationGroup="Submit" ValueToCompare="Select Service"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" CloseImageUrl="~/images/Closing.png"
                                PopupPosition="Left" TargetControlID="rfvOpearator" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="rfvOpearator" runat="server" ControlToValidate="ddloperators"
                                Display="None" ErrorMessage="Please Select Operator Name" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Literal1" runat="server" Text="Network Name"></asp:Literal>&nbsp;&nbsp;
                        </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlProvider" runat="server" Width="150px" Height="20px" CssClass="i2s_jp_seats">
                                <asp:ListItem Value="Please Select">Please Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" CloseImageUrl="~/images/Closing.png"
                                PopupPosition="Left" TargetControlID="CompareValidator1" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlProvider"
                                Display="None" ErrorMessage="Please select Network Name" Operator="NotEqual"
                                Type="String" ValidationGroup="Submit" ValueToCompare="Please Select"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" CloseImageUrl="~/images/Closing.png"
                                PopupPosition="Left" TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProvider"
                                Display="None" ErrorMessage="Please Select Network Name" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Literal2" runat="server" Text="Recharge Amount"></asp:Literal>&nbsp;&nbsp;
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtRechargeAmount" runat="server" CssClass="i2s_jp_seats" Width="150px"
                                MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRechargeAmount"
                                ValidationGroup="Submit" Display="None" ErrorMessage="Please enter Amount"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="vcedenomination" runat="server" CloseImageUrl="~/images/Closing.png"
                                TargetControlID="RequiredFieldValidator2" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="ftbeDenominatio" runat="server" TargetControlID="txtRechargeAmount"
                                ValidChars="1234567890.">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnAdd" runat="server"  Text="ADD" OnClick="btnAdd_Click" CssClass="buttonBook"
                                ValidationGroup="Submit" />
                            <asp:Button ID="btnUpdate" runat="server"  Text="Update" CssClass="buttonBook"
                                ValidationGroup="Submit" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnDelete" runat="server"  Text="Delete" CssClass="buttonBook"
                                OnClick="btnDelete_Click" />
                            <asp:Button ID="btnCancel" runat="server"  Text="Cancel" CssClass="buttonBook"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:GridView ID="gvOperators" runat="server" AutoGenerateColumns="False" GridLines="None"
                                HorizontalAlign="Center" AllowPaging="True" AllowSorting="True" PageSize="15"
                                CellPadding="4" EnableModelValidation="True" ForeColor="#333333" Width="70%"
                                DataKeyNames="ID,OperatorType,OperatorsName,RechargeAmount,TalkTime,NetworkName,OperatorsID"
                                OnPageIndexChanging="gvOperators_PageIndexChanging" OnRowCommand="gvOperators_RowCommand"
                                OnSelectedIndexChanged="gvOperators_SelectedIndexChanged" OnSorting="gvOperators_Sorting">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="9"/>
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="Operator Name" DataField="OperatorType" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="OperatorType">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="NetworkId" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="OperatorsID" DataField="OperatorsID" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:ButtonField HeaderText="Network Name " DataTextField="OperatorsName" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="OperatorsName" ItemStyle-HorizontalAlign="Center" Text="Selected"
                                        CommandName="Select">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:ButtonField>
                                    <asp:BoundField HeaderText="Recharge Amount(Rs)" DataField="RechargeAmount" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <%--  <asp:BoundField HeaderText="TalkTime(Rs)" DataField="TalkTime" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" />--%>
                                    <asp:BoundField HeaderText="Id" DataField="ID" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Left" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:Button ID="Button1" runat="server" Text="Export" CausesValidation="false" Visible="false"
                                CssClass="i2s_jp_status1" />
                        </td>
                    </tr>
                </table>
                <</td>
                </tr>
    </table>
</asp:Content>
