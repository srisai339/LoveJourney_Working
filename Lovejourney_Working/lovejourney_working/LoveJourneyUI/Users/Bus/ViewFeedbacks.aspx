<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewFeedbacks.aspx.cs" Inherits="Users_ViewFeedbacks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../style/jquery.tooltip.css" />
    <script src="../Scripts/gridview-readonly-script.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        loadJavaScriptFile("../Scripts/jquery-1.4.1.min.js");
        loadJavaScriptFile("../Scripts/jquery.tooltip.min.js");

        function loadJavaScriptFile(jspath) {
            document.write('<script type="text/javascript" src="' +
                   jspath + '"><\/script>');
        }
        $(function () {
            InitializeToolTip();
        });
        function InitializeToolTip() {
            $(".gridViewToolTip").tooltip({
                track: true,
                delay: 0,
                showURL: false,
                fade: 100,
                bodyHandler: function () {
                    return $($(this).next().html());
                }, showURL: false
            });
        }
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                InitializeToolTip();
            }
        }
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
                        <asp:Panel ID="pnlfeedbacks" runat="server" Width="100%">
                            <table width="100%" bgcolor="#ffffff">
                                <tr>
                                <td class="heading" align="center" colspan="2">
Feedbacks
        </td>
                                    <%--<td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                        font-weight: bold; color: Maroon;">
                                        Feedbacks
                                    </td>--%>
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
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClientClick="ExportGridviewtoExcel();"
                                                        OnClick="lbtnXport2Xcel_Click" />&nbsp;
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
                                        <asp:GridView ID="GvFeedbacks" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
                                            runat="server" CellPadding="3" EnableModelValidation="True" PageSize="40" EmptyDataText="No Feedbacks"
                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                            AllowSorting="true" OnPageIndexChanging="GvFeedbacks_PageIndexChanging" OnSorting="GvFeedbacks_Sorting"
                                            OnRowCommand="GvFeedbacks_RowCommand" OnRowDataBound="GvFeedbacks_RowDataBound">
                                            <AlternatingRowStyle HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFeedbackID" Text='<%#Eval("FeedbackId") %>' runat="server" />
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
                                                <asp:TemplateField HeaderText="Comments" SortExpression="Comments" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPartialComments" Text='<%#Eval("Comments") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comments" SortExpression="PartialComments" Visible="false">
                                                    <ItemTemplate>
                                                        <div class="tag">
                                                          <%--  <a id="lblArrival" href="#" class="gridViewToolTip" runat="server">VIEW</a>--%>
                                                            <div id="tooltip" style="display: none; width: 100px;">
                                                                <table width="725" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td colspan="3" valign="bottom">
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="12" align="right" valign="top" bgcolor="#30a8da">
                                                                        </td>
                                                                        <td align="left" valign="top" class="main_tab">
                                                                            <table width="701" border="0" cellspacing="0" cellpadding="0" align="center" bgcolor="#ffffff">
                                                                                <tr>
                                                                                    <td>
                                                                                        <table width="701" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td height="25" align="left" class="hd1">
                                                                                                    &nbsp;&nbsp;&nbsp;Feedback
                                                                                                </td>
                                                                                                
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="7" align="left">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <table width="670" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="670" align="left">
                                                                                                    <asp:GridView ID="GridView1" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
                                                                                                        runat="server" CellPadding="3" EnableModelValidation="True" PageSize="40" EmptyDataText="No Feedbacks"
                                                                                                        ShowHeader="false" ShowFooter="false" BackColor="White" BorderColor="#CCCCCC"
                                                                                                        BorderStyle="None" BorderWidth="1px" AllowSorting="true" OnPageIndexChanging="GvFeedbacks_PageIndexChanging"
                                                                                                        OnSorting="GvFeedbacks_Sorting">
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField ItemStyle-Wrap="true" ItemStyle-Width="100%">
                                                                                                                <ItemTemplate>
                                                                                                                    <table width="670" style="line-height: 30px; padding-left: 20px; padding-right: 20px;">
                                                                                                                        <tr>
                                                                                                                            <td align="left">
                                                                                                                                Name :
                                                                                                                                <asp:Label ID="lblName" Text='<%#Eval("Name") %>' runat="server" />
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left">
                                                                                                                                Email ID :
                                                                                                                                <asp:Label ID="Label1" Text='<%#Eval("EmailId") %>' runat="server" />
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left">
                                                                                                                                Mobile No :
                                                                                                                                <asp:Label ID="Label2" Text='<%#Eval("MobileNo") %>' runat="server" />
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left" width="670">
                                                                                                                                Feedback :<br />
                                                                                                                                <div style="text-align: justify; width: 600px;">
                                                                                                                                    <%#Eval("Comments") %>
                                                                                                                                </div>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="10">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td width="12" align="left" valign="top" bgcolor="#30a8da">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" valign="top">
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
