<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="coorporaterequest.aspx.cs" Inherits="Users_Bus_coorporaterequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="pnlMain" runat="server">

    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" class="heading" align="center">
               
                  Corporate Requests
                  
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
                                <asp:GridView ID="gvEmpRequests" runat="server" AllowPaging="True" 
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
                                       
                                        <asp:BoundField DataField="State" HeaderText="State" />
                                      
                                      

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

