<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="RemaindersMasters.aspx.cs" Inherits="Agent_Masters_RemaindersMasters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table width="990"  bgcolor="#ffffff">
   <tr>
   <td align="right">
              <asp:LinkButton ID="btnRemainderBack" runat="server" Text="Back"  ForeColor="#006699"
                    onclick="btnRemainderBack_Click" ></asp:LinkButton>
            </td>
   </tr>
        <tr>
            <td class="lj_dbrd_hd" valign="middle" align="center">
                &nbsp;&nbsp;
              <asp:Label ID="lblHead" runat="server" Font-Size="16px" Text="Remainder Master"  ></asp:Label>
            </td>
            
        </tr>
       
    </table>
    <table width="990" cellpadding="0" cellspacing="0" border="0">
      <tr>
        <td align="center">

    <table>
        <tr id="trCCode1" runat="server">
            <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                <asp:Label ID="lblAgentname" runat="server" Text="Description :"></asp:Label>
                <strong style="color: Red">*</strong>
            </td>
            <td align="left">
               
               <asp:TextBox ID="txtDescription" runat="server"  TextMode="MultiLine" ></asp:TextBox>
               <asp:RequiredFieldValidator ID="rfvDescription" ControlToValidate="txtDescription"  runat="server" ValidationGroup="submit" ErrorMessage="Enter Reminder" Display="None"></asp:RequiredFieldValidator>
               <ajax:ValidatorCalloutExtender ID="vceDescription" runat="server" TargetControlID="rfvDescription"></ajax:ValidatorCalloutExtender>
             
               

            </td>
        </tr>
       

        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnAdd" runat="server" Text="Add"  OnClick="btnAdd_Click"  CssClass="lj_dbrd_link1" ValidationGroup="submit"/>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                    onclick="btnUpdate_Click" Visible="false" CssClass="lj_dbrd_link1" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel"  Visible="false"
                    onclick="btnCancel_Click" CssClass="lj_dbrd_link1" />
               

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblmsg" runat="server" Visible="false" Width="100%" ForeColor="SaddleBrown"></asp:Label>
                <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        

        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    </td>
    </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                
                <asp:GridView ID="gvRemainders" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="100%" CellPadding="3" EnableModelValidation="True"  
                    AllowPaging="True" EmptyDataText="No Remainders" 
                     BackColor="White"  PageSize="40"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    AllowSorting="True" onrowcommand="gvRemainders_RowCommand" 
                    onrowediting="gvRemainders_RowEditing"  onrowdeleting="gvRemainders_RowDeleting" 
                      >
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#025aa2" Font-Bold="True"  ForeColor="White" Height="30px"  CssClass="lJ_gv"/>
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="center" Height="20" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                    <Columns>
                        <asp:TemplateField HeaderText="Rid" Visible="false" SortExpression="Rid">
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("Rid") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                            <ItemStyle Width="" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remainders"  SortExpression="Description" >
                            <ItemTemplate>
                                <asp:Label ID="Description" Text='<%#Eval("Description") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action"  Visible="true" >
                           <ItemTemplate>
                                
                                <asp:Button ID="btnEdit" runat="server" Text="Edit"  CommandName="Edit" CommandArgument='<%#Eval("Rid") %>'  CssClass="lj_dbrd_link1"/>
                                 <asp:Button ID="btnDelete" runat="server" Text="Delete"  CommandName="Delete" CommandArgument='<%#Eval("Rid") %>'  CssClass="lj_dbrd_link1"  OnClientClick="return confirm('Are you sure you want to Delete?');"/>

                            </ItemTemplate>
                        </asp:TemplateField>
                       

                       


                    </Columns>
                    

                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

