<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Users_Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ExportGridviewtoExcel() {
            __doPostBack("<%=lbtnXport2Xcel.UniqueID %>", '');
        }
        $(document).ready(function () {
            $("[id$='txtSearch']").mouseover(function (event) {

                $("[id$='txtSearch']").addClass("searchBoxHover")
            });
        }
                );
        $(document).ready(function () {
            $("[id$='txtSearch']").mouseout(function (event) {

                $("[id$='txtSearch']").removeClass("searchBoxHover")
            });
        }
                );
        $(document).ready(function () {
            $("[id$='txtSearch']").focusin(function (event) {

                $("[id$='txtSearch']").addClass("searchBoxHover")
            });
        }
                );
        //        function printPage(id) {
        //            var html = "<html>";
        //            html += document.getElementById("Roles").innerHTML;
        //            html += "</html>";

        //            var printWin = window.open('', '', 'left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status  =0');
        //            printWin.document.write(html);
        //            printWin.document.close();
        //            printWin.focus();
        //            printWin.print();
        //            printWin.close();
        //        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                        runat="server" visible="false">
                        <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlRoles" runat="server" Width="100%">
                <table width="100%">
                    <tr>
                        <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                            font-weight: bold; color: Maroon;">
                            Role Master
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="right" valign="top" class="busoperator_text_head">
                            <asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                                ID="btnSearch" Text="GO" runat="server" CssClass="selectseats_input" ValidationGroup="search"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table width="100%">
                                <tr>
                                    <td width="50%" align="left" valign="top" style="padding-left: 80px;">
                                        <asp:Label ID="lblSelectpage" Text="Select Page Isze" runat="server"></asp:Label>&nbsp;:&nbsp;
                                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="Dropdownlist "
                                            Width="100px" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                            <asp:ListItem Text="--Select--" Value="0" />
                                            <asp:ListItem Text="10" Value="1" />
                                            <asp:ListItem Text="20" Value="2" />
                                            <asp:ListItem Text="30" Value="3" />
                                        </asp:DropDownList>
                                    </td>
                                    <td width="50%" align="right" style="padding-right: 80px;">
                                        <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                            Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClientClick="ExportGridviewtoExcel();"
                                            OnClick="lbtnXport2Xcel_Click" />&nbsp;&nbsp;|&nbsp;&nbsp;
                                        <%--  <asp:LinkButton ID="lbtnPrint" Text="Print" CssClass="qw" runat="server" Font-Underline="false"
                                        ForeColor="Brown" Font-Bold="true" OnClientClick="javascript:printPage();" />--%>
                                        <%-- <a id="lbtnPrint" runat="server" href="javascript:printPage('Roles');" style="color: Brown;
                                        font-weight: bold;" class="qw">print</a>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center">
                            <div id="Roles" runat="server">
                                <asp:GridView ID="GVRoles" AllowPaging="True" AutoGenerateColumns="False" Width="80%"
                                    runat="server" ShowFooter="true" CellPadding="3" EnableModelValidation="True"
                                    EmptyDataText="No Roles Added Yet" OnPageIndexChanging="GVRoles_PageIndexChanging"
                                    OnRowCancelingEdit="GVRoles_RowCancelingEdit" OnRowDeleting="GVRoles_RowDeleting"
                                    OnRowEditing="GVRoles_RowEditing" OnRowUpdating="GVRoles_RowUpdating" AllowSorting="True"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    OnSorting="GVRoles_Sorting">
                                    <AlternatingRowStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Text='<%#Eval("ID") %>' runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Role" ItemStyle-Width="50%" SortExpression="Role">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRole" Text='<%#Eval("Role") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtRole" Text='<%#Eval("Role") %>' runat="server" MaxLength="50" />
                                                <asp:RequiredFieldValidator ID="rfvRole" ErrorMessage="Required" ControlToValidate="txtRole"
                                                    runat="server" Display="Dynamic" ValidationGroup="update" ForeColor="Red" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRolef" runat="server" MaxLength="50" />
                                                <asp:RequiredFieldValidator ID="rfvRolef" ErrorMessage="Required" ControlToValidate="txtRolef"
                                                    runat="server" Display="Dynamic" ValidationGroup="Add" ForeColor="Red" />
                                            </FooterTemplate>
                                            <ItemStyle Width="45%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="50%">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="selectseats_input"
                                                    CausesValidation="false" />
                                                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="selectseats_input"
                                                    CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this record?');" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" CssClass="selectseats_input"
                                                    ValidationGroup="update" />
                                                <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="selectseats_input"
                                                    CausesValidation="false" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnADD" runat="server" Text="Add" CssClass="selectseats_input" CausesValidation="true"
                                                    ValidationGroup="Add" OnClick="btnRoleAdd" />
                                            </FooterTemplate>
                                            <ItemStyle Width="45%"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                        Height="25px" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="30px" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                        Height="30px" />
                                    <EmptyDataRowStyle ForeColor="Maroon" HorizontalAlign="Center" Height="30px" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
