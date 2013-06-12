<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="AddTarrif.aspx.cs" Inherits="Users_Recharge_AddTarrif" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="960px" height="350px" align="center" bgcolor="#ffffff">
        <tr id="traddpopularrecharge" runat=server>
            <td width="900px" valign="top" align="center" height="400px">
                <table width="100%" align="center">
              <%--  <tr>
                        <td align="right" colspan="2"  height="20px">
                            <asp:LinkButton ID="lnkshow" runat="server" Font-Size="16px" 
                                Text="Show Popular Recharges" onclick="lnkshow_Click" ></asp:LinkButton>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="center" colspan="2" class="heading" height="20px">
                            <asp:Label ID="labelHeading" runat="server" Font-Size="16px" Text="Popular Recharges"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Literal1" runat="server" Text="Operator Name"></asp:Literal>&nbsp;&nbsp;
                        </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlProvider" runat="server" Width="150px" Height="20px" 
                                CssClass="i2s_jp_seats" 
                                onselectedindexchanged="ddlProvider_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">Select Service</asp:ListItem>
                              
                            </asp:DropDownList>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" CloseImageUrl="~/images/Closing.png"
                                PopupPosition="Left" TargetControlID="CompareValidator1" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlProvider"
                                Display="None" ErrorMessage="Please select Operator Name" Operator="NotEqual"
                                Type="Integer" ValidationGroup="Submit" ValueToCompare="0"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" CloseImageUrl="~/images/Closing.png"
                                PopupPosition="Left" TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProvider"
                                Display="None" ErrorMessage="Please Select Operator Name" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Literal2" runat="server" Text="Denomination"></asp:Literal>&nbsp;&nbsp;
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtDenomination" runat="server" CssClass="i2s_jp_seats" Width="150px"
                                MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDenomination"
                                ValidationGroup="Submit" Display="None" ErrorMessage="Please enter Denomination or Amount"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="vcedenomination" runat="server" CloseImageUrl="~/images/Closing.png"
                                TargetControlID="RequiredFieldValidator2" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="ftbeDenominatio" runat="server" TargetControlID="txtDenomination"
                                ValidChars="1234567890.">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Literal3" runat="server" Text="TalkTime"></asp:Literal>&nbsp;&nbsp;
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtTalkTime" runat="server" CssClass="i2s_jp_seats" Width="150px"
                                MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTalkTime"
                                ValidationGroup="Submit" Display="None" ErrorMessage="Please enter Talktime"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="vcetalktime" runat="server" CloseImageUrl="~/images/Closing.png"
                                TargetControlID="RequiredFieldValidator3" WarningIconImageUrl="~/images/warning.png">
                            </asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtTalkTime"
                                ValidChars="1234567890.">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr id="tr123" runat="server" >
                        <td align="right">
                            <asp:Literal ID="Literal6" runat="server" Text="Validity"></asp:Literal>&nbsp;&nbsp;
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtValidity" runat="server" CssClass="i2s_jp_seats" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Literal4" runat="server" Text="Description"></asp:Literal>&nbsp;&nbsp;
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="i2s_jp_seats" Width="192px"
                                Height="31px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnAdd" class="i2s_jp_midbg" ForeColor="White" runat="server" CssClass="buttonBook"
                                Text="ADD" OnClick="btnAdd_Click" ValidationGroup="Submit" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Literal ID="Literal5" runat="server" Text="Status:" Visible="false"></asp:Literal>&nbsp;&nbsp;
                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trpopularrecharges" runat="server" >
            <td >
                <table width="100%">
                    <tr>
                        <td align="center" class="style1" colspan="3" valign="middle">
                            &nbsp;
                            <asp:Label ID="lblmsg" runat="server" CssClass="labelconfirm" Font-Size="Medium"
                                ForeColor="Red" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trMobileService" runat="server" align="center">
                        <td colspan="4">
                            <asp:GridView ID="gvMobile" runat="server" AutoGenerateColumns="False" GridLines="None"
                                PageSize="20" AllowPaging="True" PagerStyle-CssClass="i2s_jp_bustext" AlternatingRowStyle-CssClass="alt"
                                AllowSorting="True" ForeColor="#333333" Width="70%" CellPadding="4" EnableModelValidation="True">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                 <asp:BoundField HeaderText="NetworkName" DataField="NetworkName" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Denomination" DataField="Denomination" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="TalkTime" DataField="TalkTime" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center" >
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Validity" DataField="Validity" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Description" DataField="Description" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
