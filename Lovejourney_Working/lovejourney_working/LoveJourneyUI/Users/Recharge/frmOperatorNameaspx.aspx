<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="frmOperatorNameaspx.aspx.cs" Inherits="Users_frmOperatorNameaspx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <table id="tbCnMain" class="tbnormal" style="background-color: White; height: 350px;
        width: 860px;">
          <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" id="tdoperator" runat="server">
                <table align="center" width="100%">
                    <tr>
                        <td class="heading" valign="middle" colspan="3" align="center" >
                            Operators Name 
                        </td>
                    </tr>
                
                  
                    <tr>
                        <td>
                            <asp:Panel ID="pnlMessages" runat="server">
                                <asp:Label ID="lblMsg1" runat="server" CssClass="labelconfirm"></asp:Label>
                                <asp:Label ID="lblMsg2" runat="server" CssClass="labelconfirmmsg"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table>
                                <tr id="trCCode" runat="server">
                                    <td class="labelboldleft" style="width: 20%">
                                    </td>
                                    <td class="labelboldleft" align="center" style="width: 2%">
                                    </td>
                                    <td class="labelboldleft">
                                        <asp:Label ID="lblCCode" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelboldleft">
                                        Operator's type
                                    </td>
                                    <td class="labelboldleft" align="center">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddltype" runat="server" CssClass="i2s_jp_seats" Height="20px"
                                            ValidationGroup="Name" Width="130px">
                                            <asp:ListItem Value="0" Selected="True">Select Service</asp:ListItem>
                                            <asp:ListItem Value="1">Mobile </asp:ListItem>
                                            <asp:ListItem Value="2">DTH </asp:ListItem>
                                             <asp:ListItem Value="3">DataCard </asp:ListItem>
                                               <asp:ListItem Value="4">LandLine </asp:ListItem>
                                                 <asp:ListItem Value="5">PostPaid </asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Operators Type"
                                            Display="None" ControlToValidate="ddltype" InitialValue="0" ValidationGroup="Name"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1"
                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelboldleft">
                                        Operator's Name
                                    </td>
                                    <td class="labelboldleft" align="center">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtOperatorsName" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvoperatorsName" runat="server" ErrorMessage="Enter Operators Name"
                                            Display="None" ControlToValidate="txtOperatorsName" ValidationGroup="Name"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" TargetControlID="rfvoperatorsName"
                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelboldleft">
                                        Operator'sKeyword
                                    </td>
                                    <td class="labelboldleft" align="center">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtOperatorsKeyword" runat="server" CssClass="i2s_jp_seats" ValidationGroup="Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvOperatorkeywrd" runat="server" ErrorMessage="Enter Operators keyword Name"
                                            Display="None" ControlToValidate="txtOperatorsKeyword" ValidationGroup="Name"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvOperatorkeywrd"
                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                 <tr id="trtypeoftran" runat="server" visible="false">
                                    <td class="labelboldleft">
                                        Type Of Transaction
                                    </td>
                                    <td class="labelboldleft" align="center">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddltypeoftransaction" runat="server" CssClass="i2s_jp_seats" Height="20px"
                                            ValidationGroup="Name" Width="130px">
                                            <asp:ListItem Value="Please Select" >Please Select</asp:ListItem>
                                            <asp:ListItem Value="1">TopUp </asp:ListItem>
                                            <asp:ListItem Value="2">Single </asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select  Type of transaction"
                                            Display="None" ControlToValidate="ddltypeoftransaction" InitialValue="Please Select" ValidationGroup="Name"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2"
                                            WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Button ID="btnAdd" runat="server"  Text="Add" OnClick="btnAdd_Click" CssClass="buttonBook"
                                            ValidationGroup="Name" />
                                        <asp:Button ID="btnUpdate" runat="server"  Text="Update" CssClass="buttonBook"
                                            ValidationGroup="Name" OnClick="btnUpdate_Click" />
                                        <asp:Button ID="btnDelete" runat="server"  Text="Delete" CssClass="buttonBook"
                                            ValidationGroup="Name" OnClick="btnDelete_Click" />
                                        <asp:Button ID="btnCancel" runat="server"  Text="Cancel" CssClass="buttonBook"
                                            ValidationGroup="Name" OnClick="btnCancel_Click" CausesValidation="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:GridView ID="gvOperators" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            AllowPaging="True" AllowSorting="True" PageSize="15" CellPadding="4" EnableModelValidation="True"
                                            ForeColor="#333333" Width="100%" DataKeyNames="NetworkName,OperatorKeyword,NetworkId"
                                            OnSelectedIndexChanged="gvOperators_SelectedIndexChanged" OnPageIndexChanging="gvOperators_PageIndexChanging"
                                            OnSorting="gvOperators_Sorting" >
                                            <PagerSettings Mode="Numeric" Position="Bottom" />
                                            <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White"
                                                HorizontalAlign="Center" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" Font-Size="9"
                                                ForeColor="White" />
                                            <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:ButtonField Text="Select" HeaderText="Operator Name" DataTextField="NetworkName"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="NetworkName" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>
                                                <asp:BoundField HeaderText="NetworkId" DataField="NetworkId" HeaderStyle-HorizontalAlign="Left"
                                                    Visible="false" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:ButtonField Text="Select" HeaderText="Operators Keyword" DataTextField="OperatorKeyword"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Center" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:ButtonField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Export" CausesValidation="false"
                                            CssClass="i2s_jp_status1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
