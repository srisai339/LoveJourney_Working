<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="CheckBalance.aspx.cs" Inherits="Agent_Masters_CheckBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table width="100%" cellpadding="0" cellspacing="0" border="0">
     <tr>
        <td align="center">
        <b>Availability Balance Details</b>
        </td>
        <td align="right">
        <asp:LinkButton ID="btnAvailabilityBack" runat="server" Text="Back"  ForeColor="#006699"
                onclick="btnAvailabilityBack_Click"></asp:LinkButton>
        </td>
     </tr>
     <tr>
        <td width="100%">
         <asp:GridView ID="gvRemainders" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                    Width="100%" CellPadding="3" EnableModelValidation="True"  
                    AllowPaging="True" EmptyDataText="No Remainders" 
                     BackColor="White"  PageSize="40"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    AllowSorting="True" 
                      >
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True"  ForeColor="White" Height="30px" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="center" Height="20" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Maroon" />
                    <Columns>
                       <asp:TemplateField HeaderText="Balance">
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("Balance") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DepositAmount">
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%#Eval("DepositAmount") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CommisionFare" >
                            <ItemTemplate>
                                <asp:Label ID="Description" Text='<%#Eval("CommisionFare") %>' runat="server" CssClass="text" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DepositUsed"  Visible="true" >
                           <ItemTemplate>
                                
                                <asp:Label ID="Description" Text='<%#Eval("DepositUsed") %>' runat="server" CssClass="text" />


                            </ItemTemplate>
                        </asp:TemplateField>
                       

                       


                    </Columns>
                    

                </asp:GridView>
         
        </td>
     </tr>
   </table>

</asp:Content>

