<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Flight/MasterPage.master" AutoEventWireup="true" CodeFile="PromoCodeMaster.aspx.cs" Inherits="Users_Flight_PromoCodeMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
            
                <tr>
                 <td class="heading" align="center">
  Promo Code Master
        </td>

                </tr>
                

                <tr>
                    <td width="100%" align="center" valign="top">
                       

                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="100%" align="center" colspan="2">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />
                                        <asp:Label ID="lblCode" runat="server" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                <td align="center">
                                 <table width="30%">
                                 <tr>
                                  <td align="left" width="50%"  valign="top">
                                                    Operater Name
                                                </td>
                                                <td width="50%" align="left" valign="bottom">
                                                    <asp:DropDownList ID="ddlserviceName" runat="server" Width="160" CssClass="lj_inp">
                                                        <asp:ListItem Value="-Please Select-">-Please Select-</asp:ListItem>
                                                        <asp:ListItem Value="Flights">Flights</asp:ListItem>                                                        
                                                        <asp:ListItem Value="Hotels">Hotels</asp:ListItem>
                                                        <asp:ListItem Value="Bus">Bus</asp:ListItem>
                                                        <%--<asp:ListItem Value="Recharge">Recharge</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="one"
                                                        InitialValue="-Please Select-" ControlToValidate="ddlserviceName" ErrorMessage="Please enter Service Name"
                                                        Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                 </tr>
                                  <tr>
                                    <td width="50%" align="left" valign="top">
                                        Promo Code&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                                                            <asp:TextBox ID="txtpromocode"  runat="server"  CssClass="lj_inp" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Enter Promocode" ControlToValidate="txtpromocode"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                        </asp:ValidatorCalloutExtender>
                                         <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtpromocode"
                                          ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSUVWXYZ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" align="left" valign="top">
                                        Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtAmount" MaxLength="3" runat="server" CssClass="lj_inp" />
                                        <asp:RequiredFieldValidator ID="rfvAmt" ErrorMessage="Enter Amount" ControlToValidate="txtAmount"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvAmt">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="ftbUsername" runat="server" TargetControlID="txtAmount"
                                            ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" align="left" valign="top">
                                        Days to Expire&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtDaystoexpire" MaxLength="3" runat="server" CssClass="lj_inp" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Days to expire"
                                            ControlToValidate="txtDaystoexpire" runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="ftbtxtMonthstoexpire" runat="server" TargetControlID="txtDaystoexpire"
                                            ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                      <tr>
                                    <td width="50%" align="left" valign="top">
                                       Min Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtminamt" MaxLength="3" runat="server" CssClass="lj_inp" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Enter Min Amount" ControlToValidate="txtminamt"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator4">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtminamt"
                                            ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr
                                      
                                
                                
                                <tr>
                                    <td width="50%" align="left" valign="top">
                                       Max Amount&nbsp;:&nbsp;
                                    </td>
                                    <td width="50%" align="left" valign="bottom">
                                        <asp:TextBox ID="txtmaxamt" MaxLength="3" runat="server" CssClass="lj_inp" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Enter Max Amount" ControlToValidate="txtmaxamt"
                                            runat="server" Display="None" ValidationGroup="Save" />
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator5">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtmaxamt"
                                            ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                

                                
                                


                                <tr>
                                    <td width="50%" align="right">
                                        &nbsp;
                                    </td>
                                    <td width="50%" align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" align="right">
                                        &nbsp;
                                    </td>
                                    <td width="50%" align="left">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="buttonBook" Text="Add" 
                                            ValidationGroup="Save" onclick="btnAdd_Click"
                                            />
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="buttonBook" Text="Update" 
                                            onclick="btnUpdate_Click" />
                                        <asp:Button ID="btnCancel" runat="server"  CssClass="buttonBook" Text="Cancel" 
                                            onclick="btnCancel_Click" />
                                        <asp:Label ID="lblid" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                
                                </table>
                    </td>
                    </tr>

                <tr>
                        <td align="center">
                           <asp:GridView ID="gvPromocode" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                            Width="990" CellPadding="3" EnableModelValidation="True" AllowPaging="True"
                            GridLines="Both"  EmptyDataText="No Remainders" BackColor="White" PageSize="40"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowSorting="True" 
                                onrowcommand="gvPromocode_RowCommand" onrowdeleting="gvPromocode_RowDeleting" onrowediting="gvPromocode_RowEditing" 
                               
                               >

                           <FooterStyle BackColor="White" ForeColor="#000066" />
                           <HeaderStyle BackColor="#025aa2" Font-Bold="True" Height="30px" CssClass="lJ_gv"  />
                           <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                           <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                           <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                           <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                                <Columns>
                                    <asp:TemplateField HeaderText="RoleId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Text='<%#Eval("Pid") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                        <ItemStyle Width="" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operator">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOperator" Text='<%#Eval("Operator") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Promocode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPromocode" Text='<%#Eval("Promocode") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" Text='<%#Eval("Amount") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="DaystoExpiry">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDaystoExpiry" Text='<%#Eval("DaystoExpiry") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="MinValue">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMinValue" Text='<%#Eval("MinValue") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    
                                     <asp:TemplateField HeaderText="MaxValue">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaxValue" Text='<%#Eval("MaxValue") %>' runat="server" CssClass="text" />
                                        </ItemTemplate>
                                    </asp:TemplateField>




                                    







                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CausesValidation="false" CommandName="Edit" CssClass="buttonBook"  
                                                CommandArgument='<%# Eval("Pid") %>' />
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CausesValidation="false" CommandName="Delete" CssClass="buttonBook"
                                                CommandArgument='<%# Eval("Pid") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                               
                               </table>


</asp:Content>

