<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminMarkUp.aspx.cs" Inherits="Agent_Bus_AdminMarkUp"  MasterPageFile="~/Users/Bus/MasterPage.master"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
     <td align="center" class="heading">
        Admin Mark Up
     </td>
    </tr>
    <tr><td>&nbsp;&nbsp;</td></tr>
    <tr>
    <td align="center">
    <table width="990" cellpadding="0" cellspacing="0" border="0">
    <tr>
      <td align="right">
      MarkUp Percentage
      </td>
      <td align="left">
       <asp:TextBox ID="txtMarkUpPercentage" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvMarkuppercentage" runat="server" ControlToValidate="txtMarkUpPercentage" ValidationGroup="submit" ErrorMessage="Please Enter Percentage"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td align="right">
      Type
      </td>
      <td align="left">
       
       <asp:DropDownList ID="ddlType" runat="server">
        <asp:ListItem>--Select--</asp:ListItem>
           <asp:ListItem>Bus</asp:ListItem>
           <asp:ListItem>Flights</asp:ListItem>
           <asp:ListItem>Cars</asp:ListItem>
           </asp:DropDownList>

       <asp:RequiredFieldValidator ID="rfvType" runat="server"  ErrorMessage="Please Enter Type" ValidationGroup="submit" ControlToValidate="ddlType" ></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr><td>&nbsp;&nbsp;</td></tr>
    <tr>
    <td>&nbsp&nbsp;</td>
    
    <td >
     <asp:Button ID="btnSave" runat="server" Text="submit" ValidationGroup="submit"  CssClass="buttonBook"
            onclick="btnSave_Click" />
    </td>
    </tr>
    <tr>
    <td>&nbsp&nbsp;</td>
    
    <td >
     
     <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </td>
    </tr>
    </table>
    </td>
    </tr>
    </table>
    </asp:Content>
   
