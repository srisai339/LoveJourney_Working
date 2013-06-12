<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="frmcity.aspx.cs" Inherits="frmcity" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table  style="vertical-align:middle;height: 350px;
        width: 860px;">
        <tr>
        <td colspan="2" align="center" bgcolor="#0062af" style="color: White">
        <asp:Label runat="server" ID="lblCity" Text="City Master" ></asp:Label>
        </td>
        </tr>

   <tr>
   <td colspan="2" align="center">
   <asp:Label ID="lblCityId" runat="server" Text="" Visible="false"></asp:Label>
   </td>
   </tr>

    <tr height="30">
    <td width="50%" align="right"> 
    <asp:Label ID="lblCityName" runat="server" Text="CityName"></asp:Label>
    </td>
    <td align="left">
    <asp:TextBox ID="txtCityName" runat="server" ValidationGroup="Name"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RFVCN" runat="server" ControlToValidate="txtCityName" Display="None" ErrorMessage="Please enter city Name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
    <ajax:ValidatorCalloutExtender ID="VCECN" runat="server" TargetControlID="RFVCN"></ajax:ValidatorCalloutExtender>
    <ajax:FilteredTextBoxExtender ID="FTECN" runat="server" TargetControlID = "txtCityName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
    </td>
    </tr>

    <tr><td colspan="2"></td></tr>

    <tr height="40">
    <td colspan="2" align="center">
        <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="Submit" onclick="btnInsert_Click"  CssClass="buttonBook"/>
        <asp:Button ID="btnCancel" runat="server" onclick="Cancel_Click" Text="Cancel"  ValidationGroup="Name" CssClass="buttonBook"/>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="Name" onclick="btnUpdate_Click" CssClass="buttonBook" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" ValidationGroup="Name" onclick="btnDelete_Click" CssClass="buttonBook"/>
       
    </td></tr>

    <tr><td colspan="2" align="center" style="color:Blue;">
     <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </td></tr>

    <tr><td colspan="2"></td></tr>

    <tr>
    <td colspan="2" align="center">
   <asp:GridView ID="gvCityName" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            AllowPaging="True" AllowSorting="True" 
            PageSize="10" CellPadding="4" EnableModelValidation="True"
                                            ForeColor="#333333" Width="100%" 
            DataKeyNames="CityName,CityId" 
            onpageindexchanging="gvCityName_PageIndexChanging" 
            onselectedindexchanged="gvCityName_SelectedIndexChanged">
                                           
                                            
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
                                                <asp:ButtonField Text="Select" HeaderText="City Name" DataTextField="CityName"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="CityName" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>

                                                <asp:BoundField HeaderText="CityId" DataField="CityId" HeaderStyle-HorizontalAlign="Left"
                                                    Visible="false" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>  
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
    </td>
   
    </td>
    </tr>

    </table>

</asp:Content>

