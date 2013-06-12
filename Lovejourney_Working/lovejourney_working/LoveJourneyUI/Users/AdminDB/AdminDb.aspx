<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="AdminDb.aspx.cs" Inherits="Users_AdminDB_AdminDb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" /> 
     <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <link href="../../css/accordian.css" rel="stylesheet" type="text/css" />
      <link href="../../css/mak_style.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
         <script src="http://jquery.malsup.com/block/jquery.blockUI.js?v2.38" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table width="990" cellpadding="0" cellspacing="0" border="0">
    <tr>
     <td  valign="top">
    <table width="990" cellpadding="0" cellspacing="0" border="0" height="400" align="center" bgcolor="#ffffff">
      <%--<tr>
      <td class="lj_dbrd_hd">AdminDashBoard</td> 
     </tr>
     <tr><td>&nbsp;&nbsp;</td></tr>
     <tr>
     <td align="center"><asp:Button ID="btnAdminQuery" runat="server" Text="AdminQuery"   
             CssClass="lj_dbrd_link1" onclick="btnAdminQuery_Click"/></td>
     </tr>--%>
    <%--  <tr>
            <td align="center" class="lj_dbrd_hd">
                <b>Admin Dashboard</b>
            </td>
        </tr>--%>
        <tr>
            <td height="10">
            </td>
        </tr>


        
        <tr id="Notices" runat="server">
            <td align="right" >
                <asp:Button ID="lbtnNoticeMaster" runat="server" Text="Notices"  
                    CssClass="lj_dbrd_link1" onclick="lbtnNoticeMaster_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="lbtnRemainder" runat="server" Text="Reminder"   
                    CssClass="lj_dbrd_link1" onclick="lbtnRemainder_Click"/>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="lbtnMarkup" runat="server" Text="Markup Management"  
                    CssClass="lj_dbrd_link1" onclick="lbtnMarkup_Click" />
            </td>
        </tr>
        <tr>
            <td height="10">
            
            </td>
        </tr>
      
       

        

        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>

        
        <tr>
         <td align="center">
         <asp:Label ID="lblAdmin"  runat="server" Font-Size="Large" Font-Bold="true"></asp:Label>
         </td>
        </tr>


        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr id="grid" runat="server">
            <td align="center" class="li_tab_bdr" width="990">
                <asp:GridView ID="gvRemainders" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="990" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                    EmptyDataText="No Remainders" BackColor="White" PageSize="40" BorderColor="#CCCCCC"
                    GridLines="None" BorderStyle="None" BorderWidth="1px" AllowSorting="True">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#e4e4e4" Font-Bold="True" Height="30px" CssClass="lJ_gv" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="center" Height="25" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                    <Columns>
                        <asp:TemplateField HeaderText="Rid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("ARid") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                            <ItemStyle Width="" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reminder">
                            <ItemTemplate>
                                <asp:Label ID="Description" Text='<%#Eval("Remainder") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
       
        <tr><td>&nbsp;&nbsp;</td></tr>
        <tr><td>&nbsp;&nbsp;</td></tr>
        

        
      

   </table>
   </td>
   </tr>
   </table>
</asp:Content>

