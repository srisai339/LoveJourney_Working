<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="PendingRequests.aspx.cs" Inherits="Users_Bus_PendingRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
            <asp:Panel ID="pnlMain" runat="server">

    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" class="heading" align="center">
               
                   Pending Requests
                  
            </td>
        </tr>
        <tr>
                                    <td width="100%" align="right" valign="top" class="busoperator_text_head">
                                        <%--Search&nbsp;:&nbsp;--%><asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                                            ID="btnSearch" Text="GO" runat="server" CssClass="buttonBook" 
                                            ValidationGroup="search" onclick="btnSearch_Click" 
                                             />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td width="50%" align="left" valign="top">
                                                    <asp:Label ID="lblSelectpage" Text="Select Page Size" runat="server"></asp:Label>&nbsp;:&nbsp;
                                                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
                                                        CssClass="DDL" >
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <asp:ListItem Text="200" Value="1" />
                                                        <asp:ListItem Text="400" Value="2" />
                                                        <asp:ListItem Text="600" Value="3" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50%" align="right">
                                                    <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" 
                                                        OnClientClick="ExportGridviewtoExcel();" onclick="lbtnXport2Xcel_Click"
                                                         />&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
        <tr>
            <td>
                <div>
                   
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvAgentRequests" runat="server" AllowPaging="True" 
                                    Width="100%" AutoGenerateColumns="false" PageSize="100"
                                    >
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                      

                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="EmailId" HeaderText="EmailId" />
                                       
                                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                        <asp:BoundField DataField="City" HeaderText="City" />
                                        <asp:BoundField DataField="district" HeaderText="District" />
                                        <asp:BoundField DataField="State" HeaderText="State" />
                                        <asp:BoundField DataField="Comments" HeaderText="Comments" />
                                          <asp:BoundField DataField="AppointmentDate" HeaderText="AppointmentDate" />
                                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelete" runat="server" CommandName="Remove" Text="Delete" CssClass="buttonBook"
                                                                CommandArgument='<%#Eval("Id") %>' CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%"></ItemStyle>
                                                    </asp:TemplateField>

                                    </Columns>
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

