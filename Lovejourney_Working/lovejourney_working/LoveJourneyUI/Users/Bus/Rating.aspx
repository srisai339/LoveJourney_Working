<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="Rating.aspx.cs" Inherits="Users_Rating" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
        <ContentTemplate>--%>
          <table width="100%">
                <tr>
                    <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                        runat="server" visible="false">
                        <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                 <td class="heading" align="center" colspan="2">
Rating
        </td>
                 
                </tr>
            </table>
            <asp:Panel ID="pnlMain" runat="server">
            <table width="80%" >
            
                <tr>
                 <td align="center">
                  <table width="80%">
                <tr>
                    <td align="center" valign="top" width="50%">
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    <td align="left" valign="top" width="50%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="50%">
                        &nbsp;
                    </td>
                    <td align="left" valign="top" width="50%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="30%">
                        API :
                    </td>
                    <td align="left" valign="top" >
                        <asp:DropDownList ID="ddlApi" runat="server" AutoPostBack="true" CssClass="lable_bg12_adm"
                            OnSelectedIndexChanged="ddlApi_SelectedIndexChanged">
                            <asp:ListItem Text="Select" Value="0" />
                            <asp:ListItem Text="Abhibus" Value="1" />
                            <asp:ListItem Text="Bitla" Value="2" />
                            <asp:ListItem Text="Kesineni" Value="3" />
                            <asp:ListItem Text="Kallada" Value="4" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvApi" runat="server" ControlToValidate="ddlApi"
                            Display="None" ErrorMessage="Please Select API" InitialValue="0" ValidationGroup="save"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vceAPI" runat="server" TargetControlID="rfvApi"></ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="50%">
                        Operator :
                    </td>
                    <td align="left" valign="top" width="50%">
                        <asp:DropDownList ID="ddlOperator" runat="server" AutoPostBack="true" 
                            CssClass="lable_bg12_adm" 
                            onselectedindexchanged="ddlOperator_SelectedIndexChanged">
                            <asp:ListItem Text="Select" Value="Select" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlOperator"
                            Display="None" ErrorMessage="Please Select Operator" InitialValue="Select" ValidationGroup="save"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vceOperator" TargetControlID="RequiredFieldValidator3" runat="server"></ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="50%">
                        Rating(1-5) :
                    </td>
                    <td align="left" valign="top" width="50%">
                        <asp:TextBox ID="txtRating" runat="server" ValidationGroup="save" MaxLength="1" ></asp:TextBox>
                    </td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRating"
                        Display="None" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="vceRating1" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtRating"
                        Display="None" ErrorMessage="Rating value should be 1 to 5" ValidationGroup="save" Type="Integer" Operator="LessThanEqual"
                        ValueToCompare="5"></asp:CompareValidator>
                    <ajax:ValidatorCalloutExtender ID="vceRating2" TargetControlID="CompareValidator1" runat="server"></ajax:ValidatorCalloutExtender>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtRating"
                        Display="None" ErrorMessage="Rating value should be 1 to 5" ValidationGroup="save" Type="Integer" Operator="GreaterThanEqual"
                        ValueToCompare="1"></asp:CompareValidator>
                    <ajax:ValidatorCalloutExtender ID="vceRating3" runat="server" TargetControlID="CompareValidator2"></ajax:ValidatorCalloutExtender>
                </tr>
                <tr>
                    <td align="left" valign="top" width="50%">
                    </td>
                    <td align="left" valign="top" width="50%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" width="50%">
                        &nbsp;
                    </td>
                    <td align="left" valign="top" width="50%">
                        <asp:Button ID="btnsave" runat="server" CssClass="buttonBook" OnClick="btnsave_Click"
                            Text="Save" ValidationGroup="save" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="50%">
                        &nbsp;</td>
                    <td align="left" valign="top" width="50%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" valign="top" width="100%" colspan="2">
                        <asp:GridView ID="gvRating" AutoGenerateColumns="false" runat="server" 
                            Width="100%"  AllowPaging="true" 
                            AllowSorting="true" onpageindexchanging="gvRating_PageIndexChanging" 
                            PageSize="20" EmptyDataText="No Records Found" 
                            onsorting="gvRating_Sorting"
                            onselectedindexchanged="gvRating_SelectedIndexChanged" 
                            onrowcommand="gvRating_RowCommand1" onrowediting="gvRating_RowEditing" 
                            onrowupdating="gvRating_RowUpdating">
                            <Columns>
                                <asp:BoundField DataField="APIName" HeaderText="APIName" SortExpression="APIName"/>
                                <asp:BoundField DataField="BusOperatorName" HeaderText="BusOperatorName" SortExpression="BusOperatorName"/>
                                <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating"/>
                            
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="lbtnUpdate" runat="server" CommandName="Edit" Text="Edit" CssClass="buttonBook"
                                         CommandArgument='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle CssClass="gridAlter" />
                            <HeaderStyle CssClass="gridheadercolor" ForeColor="White"/>
                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
                </table>
                </td>
                </tr>
            </table>
            </asp:Panel>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
