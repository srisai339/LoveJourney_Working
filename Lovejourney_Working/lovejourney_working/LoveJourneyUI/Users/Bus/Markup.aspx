<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="Markup.aspx.cs" Inherits="Agent_Bus_Markup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
 <link rel="stylesheet" type="text/css" href="../../css/tn_style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
  <tr>
     <td align="center" width="990">

        <table width="990" cellpadding="0" cellspacing="0" border="0" bgcolor="#ffffff">
        
       <tr>
                        <td class="lj_dbrd_hd" valign="middle" align="center">
                            &nbsp;&nbsp;
                            <asp:Label ID="lblHead" runat="server" Font-Size="16px" Text="MarkUp Management"></asp:Label>
                        </td>
                        
       </tr>
       <tr>
                        <td align="center">
                            <table>
                            <tr><asp:Label ID="lblType1" runat="server" ></asp:Label></tr>
                                <tr id="typed" runat="server">
                                    <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                                        <asp:Label ID="lblType" runat="server" Text="Type :"></asp:Label>
                                        <strong style="color: Red">*</strong>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddltype" runat="server" Width="130" 
                                            
                                         >
                                       <asp:ListItem>--Select--</asp:ListItem>
                                       <asp:ListItem>Bus</asp:ListItem>
                                       <asp:ListItem>Domestic Flights</asp:ListItem>
                                       <asp:ListItem>International Flights</asp:ListItem>
                                       <asp:ListItem>Hotels</asp:ListItem>
                                       </asp:DropDownList>
                                     

                                    </td>
                                </tr>
                                

                                <%--<tr id="domestic" runat="server" visible="false">
                                    <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                                        <asp:Label ID="Label9" runat="server" Text="Domestic Flight Type :"></asp:Label>
                                        <strong style="color: Red">*</strong>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlDomesticType" runat="server" Width="130" 
                                         >
                                      <asp:ListItem>--Select--</asp:ListItem>
                                       <asp:ListItem>Air India</asp:ListItem>
                                       <asp:ListItem>Air India Express</asp:ListItem>
                                       <asp:ListItem>GoAir</asp:ListItem>
                                        <asp:ListItem>Indigo</asp:ListItem>
                                         <asp:ListItem>Jet Airways</asp:ListItem>
                                          <asp:ListItem>Jet Lite</asp:ListItem>
                                          <asp:ListItem>King Fisher</asp:ListItem>
                                          <asp:ListItem>Spice Jet</asp:ListItem>
                                          </asp:DropDownList>

                                    </td>
                                </tr>--%>

                                
                                
                                 

                                <tr>
                                    <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                                        <asp:Label ID="Label1" runat="server" Text="MarkUpAmount :"></asp:Label>
                                        <strong style="color: Red">*</strong>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAmount" runat="server" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvAmount" runat="server"  ErrorMessage="Please Enter Amount" ValidationGroup="submit1" ControlToValidate="txtAmount"  Display="None"></asp:RequiredFieldValidator>
                                       
                                      <asp:ValidatorCalloutExtender ID="vceAmount" runat="server" TargetControlID="rfvAmount"></asp:ValidatorCalloutExtender>

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
                                 
               <asp:Button ID="btnAd" runat="server" Text="Add"     ValidationGroup="submit1" CssClass="lj_dbrd_link1"
                                            onclick="btnAd_Click"/>
                                           
                                        <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
       <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" onclick="btnUpdate_Click" class="lj_dbrd_link1"
                                             />
       <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" onclick="btnCancel_Click"  class="lj_dbrd_link1"
                                             />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                       <asp:Label ID="lblDispaly" runat="server" ForeColor="Green"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblmsg" runat="server" Visible="false" Width="100%" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
       <tr>
                        <td align="center">
                            <asp:GridView ID="gvMarkUp" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="100%" CellPadding="3" EnableModelValidation="True"  
                    AllowPaging="True" EmptyDataText="No Remainders" 
                     BackColor="White"  PageSize="40"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    AllowSorting="True" onrowcommand="gvMarkUp_RowCommand" 
                onrowdeleting="gvMarkUp_RowDeleting" onrowediting="gvMarkUp_RowEditing" 
                    
                      >
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#025aa2" Font-Bold="True"  ForeColor="White" Height="30px" CssClass="lJ_gv" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="center" Height="20" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                    <Columns>
                        <asp:TemplateField HeaderText="Mid" Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("Id") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                            

                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Type" >
                            <ItemTemplate>
                                <asp:Label ID="lblType" Text='<%#Eval("Type") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>

                          
                         


                         


                        <asp:TemplateField HeaderText="MarkUp Price">
                            <ItemTemplate>
                            <asp:Label ID="lblMarkupAmount" Text='<%#Eval("MarkupAmount") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Action"  Visible="true" >
                           <ItemTemplate>
                                
                                <asp:Button ID="btnEdit" runat="server" Text="Edit"  CommandName="Edit" CommandArgument='<%#Eval("Id") %>' class="lj_dbrd_link1"/>
                                 <asp:Button ID="btnDelete" runat="server" Text="Delete"  CommandName="Delete" CommandArgument='<%#Eval("Id ") %>' class="lj_dbrd_link1"/>

                                 

                            </ItemTemplate>
                        </asp:TemplateField>
                       

                       


                    </Columns>
                    

                </asp:GridView>

                        </td>
                    </tr>



       </table>
        









     </td>
    </tr>

    
   
  
    <tr><td>&nbsp;&nbsp;&nbsp;</td></tr>
     <tr><td>&nbsp;&nbsp;&nbsp;</td></tr>
    </table>
</asp:Content>

