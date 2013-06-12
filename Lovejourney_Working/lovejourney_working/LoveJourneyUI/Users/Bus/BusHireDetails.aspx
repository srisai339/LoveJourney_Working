<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="BusHireDetails.aspx.cs" Inherits="Users_BusHireDetails" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
        <ContentTemplate>
            <table width="900">
                <tr>
                    <td width="100%" height="30px" align="left" class="tr" id="tdmsg" runat="server"
                        visible="false" valign="middle">
                        &nbsp;<asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        <asp:Panel ID="pnlBusHires" runat="server" Width="100%">
                            <table width="100%">
                                <tr>
                                    <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                        font-weight: bold; color: Maroon;">
                                        Bus Hires
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="right" style="padding-right: 50px;">
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Enter Search item"
                                        ControlToValidate="txtSearch" runat="server" ValidationGroup="search" />--%>
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
                                                    Select Page size&nbsp;:&nbsp;
                                                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="DDL"
                                                        OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <asp:ListItem Text="40" Value="1" />
                                                        <asp:ListItem Text="80" Value="2" />
                                                        <asp:ListItem Text="120" Value="3" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50%" align="right">
                                                    <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClick="lbtnXport2Xcel_Click"
                                                        OnClientClick="ExportGridviewtoExcel();" />&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="right" style="padding-right: 50px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="center">
                                        <asp:GridView ID="GvBusHires" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
                                            runat="server" CellPadding="3" EnableModelValidation="True" PageSize="40" EmptyDataText="No Bus Hire Requests"
                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                            AllowSorting="true" OnPageIndexChanging="GvBusHires_PageIndexChanging" OnSorting="GvBusHires_Sorting">
                                            <AlternatingRowStyle HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Text='<%#Eval("Id") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" Text='<%#Eval("Name") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email ID" SortExpression="EmailId">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmailID" Text='<%#Eval("EmailId") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile No" SortExpression="MobileNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMobileNo" Text='<%#Eval("MobileNo") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="From" SortExpression="Source">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSource" Text='<%#Eval("Source")%>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="To" SortExpression="Destination">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTo" Text='<%#Eval("Destination")%>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Seats" SortExpression="NoOfSeats">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSeats" Text='<%#Eval("NoOfSeats")%>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription" Text='<%#Eval("Description")%>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" Text="View" CssClass="selectseats_input"
                                                        CausesValidation="false" CommandArgument='<%#Eval("Id") %>' CommandName="View" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" CssClass="menugv" ForeColor="White"
                                                HorizontalAlign="Center" Height="25px" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="30px" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                Height="30px" />
                                            <EmptyDataRowStyle ForeColor="Maroon" HorizontalAlign="Center" Height="30px" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
