<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="ViewUserInformation.aspx.cs" Inherits="Users_Bus_ViewUserInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="Label7" runat="server" ForeColor="Maroon" Text="No permission to this page. Please contact Administrator for further details."></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" id="tblMain" runat="server" bgcolor="#ffffff">
        <tr>
                                    <td colspan="2" align="center" class="heading">
                                        All Users
                                    </td>
                                </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
       
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
       
       <tr>
                                    <td width="100%" align="right" valign="top" class="busoperator_text_head">
                                        <%--Search&nbsp;:&nbsp;--%><asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                                            ID="btnSearch" Text="GO" runat="server" CssClass="buttonBook" ValidationGroup="search"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td width="50%" align="left" valign="top">
                                                    <asp:Label ID="lblSelectpage" Text="Select Page Size" runat="server"></asp:Label>&nbsp;:&nbsp;
                                                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
                                                        CssClass="DDL" onselectedindexchanged="ddlPageSize_SelectedIndexChanged"
                                                      >
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <asp:ListItem Text="40" Value="1" />
                                                        <asp:ListItem Text="80" Value="2" />
                                                        <asp:ListItem Text="120" Value="3" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50%" align="right">
                                                    <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClientClick="ExportGridviewtoExcel();"
                                                        OnClick="lbtnXport2Xcel_Click" />&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
       
        <tr>
            <td width="100%">
                <div id="divAgents" runat="server" visible="true">
                 <%--   <fieldset>
                        <legend>View Users</legend>--%>
                        <table width="100%">
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAgents" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="100"
                                        AllowSorting="true" OnPageIndexChanging="gvAgents_PageIndexChanging" 
                                        OnRowDataBound="gvAgents_RowDataBound" OnSorting="gvAgents_Sorting" Width="100%"
                                        DataKeyNames="AgentId,UserId" EmptyDataText="No Data Found">
                                         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="AgentName" HeaderText="Name" SortExpression="AgentName" />
                                          
                                          <%--  <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />--%>
                                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" SortExpression="MobileNo" />
                                            <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />
                                            <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="Username" />
                                            <asp:BoundField DataField="Password" HeaderText="Password" />
                                            <%--   <asp:BoundField DataField="Status" HeaderText="Status" />--%>
                                         
                                        
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                    <asp:RadioButton ID="rbtnApproved" runat="server" Text="Approved" GroupName="Status"
                                                        ForeColor="Green" AutoPostBack="true" OnCheckedChanged="rbtnStatus_CheckedChanged"
                                                        ValidationGroup='<%# Eval("AgentId") %>' />
                                                    <asp:RadioButton ID="rbtnHold" runat="server" Text="Hold" GroupName="Status" ForeColor="Red"
                                                        AutoPostBack="true" OnCheckedChanged="rbtnStatus_CheckedChanged" ValidationGroup='<%# Eval("AgentId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnViewAgent" runat="server" CommandName="ViewAgent" Style="cursor: pointer;"
                                                        CssClass="buttonBook" CommandArgument='<%# Eval("AgentId") %>' Text="View" ToolTip="Click to view or update agent" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                 <%--   </fieldset>--%>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
                &nbsp;
            </td>
        </tr>
        
        <tr>
            <td width="100%">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

