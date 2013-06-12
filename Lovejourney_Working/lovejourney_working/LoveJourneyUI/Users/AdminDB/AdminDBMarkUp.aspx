<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="AdminDBMarkUp.aspx.cs" Inherits="Users_AdminDB_AdminDBMarkUp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
  <tr>
     <td align="center" width="990">

        <table width="990" cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td align="right" >
          <asp:LinkButton ID="btnMarkupback" Text="Back" runat="server"  PostBackUrl="~/Users/AdminDB/AdminDb.aspx"
           ></asp:LinkButton>
          </td>
        </tr>
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
                                <tr id="trCCode1" runat="server">
                                    <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                                        <asp:Label ID="lblType" runat="server" Text="Type :"></asp:Label>
                                        <strong style="color: Red">*</strong>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddltype" runat="server" Width="130" 
                                            AutoPostBack="True">
                                       <asp:ListItem>--Select--</asp:ListItem>
                                       <asp:ListItem Value="Bus">Bus</asp:ListItem>
                                       <asp:ListItem Value="Domestic Flights">Domestic Flights</asp:ListItem>
                                        <asp:ListItem Value="International Flights">International Flights</asp:ListItem>
                                       <asp:ListItem Value="Hotels">Hotels</asp:ListItem>
                                       <asp:ListItem Value="Utilities">Utilities</asp:ListItem>
                                       </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddltype" ErrorMessage="Please Select" ValidationGroup="submit" Display="None"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceType" runat="server" TargetControlID="rfvType"></ajax:ValidatorCalloutExtender>
                                    
                                    </td>
                                </tr>
                                




                                

                                

                                 


                                <tr id="Amount" runat="server">
                                    <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Mark Up Price :"></asp:Label>
                                        <strong style="color: Red">*</strong>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAmount" runat="server" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvAmount" runat="server"  ErrorMessage="Please Enter Amount" ValidationGroup="submit" ControlToValidate="txtAmount"  Display="None"></asp:RequiredFieldValidator>
                                       <ajax:ValidatorCalloutExtender ID="vceAmount" runat="server" TargetControlID="rfvAmount"></ajax:ValidatorCalloutExtender>
                                      

                                    </td>
                                </tr>
                                
                                  <tr id="AddSubtract" runat="server">
                                    <td class="labelboldleft" style="width: 40%" visible="true" align="right">
                                        <asp:Label ID="lblAddSubtract" runat="server" Text="Amount should be :"></asp:Label>
                                        <strong style="color: Red">*</strong>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlAddSubtract" runat="server" Width="130">
                                       <asp:ListItem>--Select--</asp:ListItem>
                                       <asp:ListItem Value="Add">Add</asp:ListItem>
                                       <asp:ListItem Value="Subtract">Subtract</asp:ListItem>
                                       </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvAddSub" runat="server" ControlToValidate="ddlAddSubtract" ErrorMessage="Please Select" ValidationGroup="submit" Display="None"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvAddSub"></ajax:ValidatorCalloutExtender>
                                      

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
                                        <asp:Button ID="Button1" runat="server"  onclick="Button1_Click" Text="Add" CssClass="lj_dbrd_link1"/>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
       <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false"   CssClass="lj_dbrd_link1" onclick="btnUpdate_Click"
                                             />
       <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="lj_dbrd_link1" onclick="btnCancel_Click"
                                             />
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
                         
                          
                            

                         



                        <asp:TemplateField HeaderText="Mark Up Price">
                            <ItemTemplate>
                                 <asp:Label ID="lblMarkupAmount" Text='<%#Eval("MarkUpAmount") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="Add/Subtract">
                            <ItemTemplate>
                                 <asp:Label ID="lblAddSubtract" Text='<%#Eval("AddSubtract") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action"  Visible="true" >
                           <ItemTemplate>
                                
                                <%--<asp:Button ID="btnEdit" runat="server" Text="Edit"  CommandName="Edit" CommandArgument='<%#Eval("Id") %>' CssClass="lj_dbrd_link1"/>--%>
                                 <asp:Button ID="btnDelete" runat="server" Text="Delete"  CommandName="Delete" CommandArgument='<%#Eval("Id ") %>' CssClass="lj_dbrd_link1"/>

                                 

                            </ItemTemplate>
                        </asp:TemplateField>
                       

                       


                    </Columns>
                    

                </asp:GridView>

                        </td>
                    </tr>



       </table>
        









     </td>
    </tr>
   
   <%-- <tr>
    <td align="center">
    <table width="990" cellpadding="0" cellspacing="0" border="0">
    

    <tr>
      <td align="right">
      Type
      </td>
      <td align="left">
       <asp:DropDownList ID="ddltype" runat="server" Width="130" 
              onselectedindexchanged="ddltype_SelectedIndexChanged" AutoPostBack="True" 
              >
          <asp:ListItem>--Select--</asp:ListItem>
           <asp:ListItem>Bus</asp:ListItem>
           <asp:ListItem>Flights</asp:ListItem>
           <asp:ListItem>Hotels</asp:ListItem>
       </asp:DropDownList>
       </td>
       </tr>
    <tr id="flights" runat="server" visible="false">
       <td align="right">
       Flights
       </td>
          <td>
            <asp:DropDownList Id="ddlFlightType" runat="server" width="130" 
              AutoPostBack="True" 
              onselectedindexchanged="ddlFlightType_SelectedIndexChanged" >
             </asp:DropDownList>

       <asp:DropDownList ID="ddlDomestic" runat="server" Width="130" AutoPostBack="True">
       </asp:DropDownList>
        <asp:DropDownList ID="ddlInterNational" runat="server" Width="130" 
              AutoPostBack="True">
       </asp:DropDownList>

      </td>
      </tr>
    <tr>
      <td align="right">
      MarkUp Amount
      </td>
      <td align="left">
      
      <asp:TextBox ID="txtAmount" runat="server" ></asp:TextBox>
     <asp:RequiredFieldValidator ID="rfvAmount" runat="server"  ErrorMessage="Please Enter Amount" ValidationGroup="submit" ControlToValidate="txtAmount" ></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td align="right">
      MarkUp Percentage
      </td>
      <td align="left">
      
      <asp:TextBox ID="txtPercentage" runat="server" ></asp:TextBox>
     <asp:RequiredFieldValidator ID="rfvPercentage" runat="server"  ErrorMessage="Please Enter Percentage" ValidationGroup="submit" ControlToValidate="txtAmount" ></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
       <asp:Button ID="btnAdd" runat="server" Text="Add"  ValidationGroup="submit" 
              onclick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
       <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" onclick="btnUpdate_Click" 
                                             />
       <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" onclick="btnCancel_Click" 
                                             />
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
    

        <tr>
      <asp:GridView ID="gvMarkUp" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="100%" CellPadding="3" EnableModelValidation="True"  
                    AllowPaging="True" EmptyDataText="No Remainders" 
                     BackColor="White"  PageSize="40"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    AllowSorting="True" onrowcommand="gvMarkUp_RowCommand" 
                onrowdeleting="gvMarkUp_RowDeleting" onrowediting="gvMarkUp_RowEditing" 
                    
                      >
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True"  ForeColor="White" Height="30px" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="center" Height="20" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                    <Columns>
                        <asp:TemplateField HeaderText="Mid" Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("Mid") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                            <ItemStyle Width="" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" >
                            <ItemTemplate>
                                <asp:Label ID="lblFlightsName" Text='<%#Eval("FlightsName") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MarkUpAmount">
                            <ItemTemplate>
                                 <asp:Label ID="lblMarkupAmount" Text='<%#Eval("MarkupAmount") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="MarkupPercentage">
                            <ItemTemplate>
                                <asp:Label ID="lblMarkupPercentage" Text='<%#Eval("MarkupPercentage") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action"  Visible="true" >
                           <ItemTemplate>
                                
                                <asp:Button ID="btnEdit" runat="server" Text="Edit"  CommandName="Edit" CommandArgument='<%#Eval("Mid") %>'/>
                                 <asp:Button ID="btnDelete" runat="server" Text="Delete"  CommandName="Delete" CommandArgument='<%#Eval("Mid") %>'/>

                                 

                            </ItemTemplate>
                        </asp:TemplateField>
                       

                       


                    </Columns>
                    

                </asp:GridView>
    </tr>--%>
    </table>
</asp:Content>

