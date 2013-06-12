<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmAgentsDeposits.aspx.cs" Inherits="Users_Bus_frmAgentsDeposits" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    function ExportGridviewtoExcel() {
        __doPostBack("<%=btnExcel.UniqueID %>", '');
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
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="Label7" runat="server" ForeColor="Maroon" Text="No permission to this page. Please contact Administrator for further details."></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" id="tblMain" runat="server" bgcolor="#ffffff">
        <%--  <tr>
            <td width="100%">
            </td>
        </tr>--%>
        <tr>
            <td width="100%" align="center">
                <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" class="heading" >
                <asp:Label ID="Label1" runat="server" Text="Agent Deposits Report" Font-Size="13px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="right">
                            From Date
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtdate" Width="150" runat="server" CssClass="lj_inp">
                            </asp:TextBox>
                            <%-- <ajax:CalendarExtender ID="Calcdate" runat="server" TargetControlID="txtdate">
                            </ajax:CalendarExtender>--%>
                            <asp:ImageButton runat="Server" ID="Image1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate"
                                Enabled="True" PopupButtonID="Image1">
                            </ajax:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            To Date
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtrefno" Width="150" runat="server" CssClass="lj_inp">
                            </asp:TextBox>
                            <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtrefno"
                                Enabled="True" PopupButtonID="ImageButton1">
                            </ajax:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            User Name
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtAgents" ToolTip="Type the first 3 letters of agent name" runat="server" CssClass="lj_inp">
                            </asp:TextBox>                            
                            <ajax:AutoCompleteExtender ID="txtFrom_AutoCompleteExtender" runat="server" TargetControlID="txtAgents"
                                ServiceMethod="GetAgentNames" MinimumPrefixLength="1" CompletionInterval="10"
                                CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                ServicePath="">
                            </ajax:AutoCompleteExtender>
                            <asp:DropDownList ID="ddlagentname" Width="150" runat="server" Visible="False">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Deposit Type
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddldeposittype" Width="150" runat="server" CssClass="lj_inp">
                                <asp:ListItem Text="Please Select" Value="Please Select"></asp:ListItem>
                                <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                <asp:ListItem Text="Net Banking" Value="Net Banking"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr id="lblpaging" runat="server" visible="true">
                        <td align="right">
                          Paging
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlpaging" runat="server" CssClass="lj_inp" AutoPostBack="true" 
                                Width="100px" OnSelectedIndexChanged="ddlpaging_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="40"></asp:ListItem>
                                <asp:ListItem Value="2" Text="80"></asp:ListItem>
                                <asp:ListItem Value="3" Text="120"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            
                            &nbsp;&nbsp;
                        </td>
                        <td>
                           
                        </td>
                        <td>
                          &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"
                    CssClass="buttonBook" />&nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" 
                    CssClass="buttonBook" onclick="btnReset_Click" />&nbsp;&nbsp;
                     <asp:Button ID="btnExcel" runat="server" Text="Excel" 
                    CssClass="buttonBook" onclick="btnExcel_Click"  />


            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:Label ID="lblerrormsg" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="right" colspan="2" id="trpaging" runat="server">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           
                           
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center">
                           <%-- <div id="divDeposits" runat="server" visible="true">--%>

                                <asp:GridView ID="gvDeposits" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" OnPageIndexChanging="gvDeposits_PageIndexChanging"
                                    Width="100%" PageSize="20" EmptyDataText="No Data Found" ShowFooter="True" OnRowDataBound="gvDeposits_RowDataBound"
                                    OnSorting="gvDeposits_Sorting">
                                    <EmptyDataRowStyle ForeColor="#CC0000" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No" SortExpression="">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <%-- <asp:Label ID="lblDepositRequestId" runat="server" Visible="false" Text='<%# Eval("Id") %>' />
                                                 <asp:Label ID="lblAgentId" runat="server" Visible="false" Text='<%# Eval("AgentId") %>' />
                                                 <asp:Label ID="lblDepositBank" runat="server" Visible="false" Text='<%# Eval("DepositBank") %>' />
                                                 <asp:Label ID="lblChequeDrawnBank" runat="server" Visible="false" Text='<%# Eval("ChequeDrawnBank") %>' />
                                                 <asp:Label ID="lblChequeIssueDate" runat="server" Visible="false" Text='<%# Eval("ChequeIssueDate") %>' />
                                                 <asp:Label ID="lblChequeNo" runat="server" Visible="false" Text='<%# Eval("ChequeNo") %>' />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agent Name" SortExpression="AgentName" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgentname" runat="server" Text='<%# Eval("AgentName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name" SortExpression="UserName" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RequestedDate" SortExpression="CreatedDate" FooterStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("CreatedDate") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                Total:
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DepositType" SortExpression="DepositType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDepositType" runat="server" Text='<%# Eval("DepositType") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transaction No" SortExpression="TransactionNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTransactionNumber" runat="server" Text='<%# Eval("TransactionNumber") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Details" SortExpression="Details">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDetails" runat="server" Text='<%# Eval("Details") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reason" SortExpression="Reason" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReason" runat="server" Text='<%# Eval("Reason") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                 <%--       <asp:TemplateField HeaderText="Total Balance" SortExpression="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotalBal" runat="server" Text='<%# Eval("Amount") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Add/Deducted Amount " SortExpression="TransactionNumber" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddDeductAmt" runat="server" Text='<%# Eval("Amount") %>' />
                                            </ItemTemplate>
                                               <FooterTemplate>
                                                <asp:Label ID="lblTotal" runat="server" ForeColor="Red" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Type" SortExpression="Credit_Debit" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCredit_Debit" runat="server" Text='<%# Eval("Credit_Debit") %>' />
                                            </ItemTemplate>
                                             
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Net Balance" SortExpression="Netbal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNetBalance" runat="server"  Text='<%# Eval("Netbal") %>'  />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblNetTotal" runat="server" ForeColor="Red" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px"
                                        HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <RowStyle ForeColor="#000066" Height="25px" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="25px"
                                        HorizontalAlign="Center" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                                        Height="25px" />
                                </asp:GridView>

                           <%-- </div>--%>
                        </td>
                    </tr>
                </table>
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
            <td width="100%">
            </td>
        </tr>
    </table>
</asp:Content>
