<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="CommissionSlab.aspx.cs" Inherits="Users_AdminDashBoard_CommisiionSlab" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td align="center">
                <table width="1000" bgcolor="#ffffff">
                <tr>
                                    <td colspan="2" align="center" class="lj_dbrd_hd">
                                        Commission Slab
                                    </td>
                                </tr>
                    <tr>
                        <td align="center">
                            <table width="500">
                                
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Role
                                    </td>
                                    <td align="left" height="30px">
                                        <asp:DropDownList ID="ddlrole" runat="server">
                                            <asp:ListItem Value="-Please Select-">-Please Select-</asp:ListItem>
                                            <asp:ListItem Value="Agent">Agent</asp:ListItem>
                                            <asp:ListItem Value="Dealers">Dealers</asp:ListItem>
                                            <asp:ListItem Value="Customers">Customers</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvrole" runat="server" ValidationGroup="one" InitialValue="-Please Select-"
                                            ControlToValidate="ddlrole" ErrorMessage="Please enter role" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="vce" runat="server" TargetControlID="rfvrole">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td align="left">
                                        Service Name
                                    </td>
                                    <td align="left" height="30px">
                                        <asp:DropDownList ID="ddlserviceName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlserviceName_SelectedIndexChanged" >
                                            <asp:ListItem Value="-Please Select-">-Please Select-</asp:ListItem>
                                            <asp:ListItem Value="DomesticFlights">Domestic Flights</asp:ListItem>
                                            <asp:ListItem Value="InterNationalFlights">International Flights</asp:ListItem>
                                            <asp:ListItem Value="Hotels">Hotels</asp:ListItem>
                                            <asp:ListItem Value="Bus">Bus</asp:ListItem>
                                            <asp:ListItem Value="Car">Car</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="one"
                                            InitialValue="-Please Select-" ControlToValidate="ddlserviceName" ErrorMessage="Please enter Service Name"
                                            Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>--%>
                                <tr runat="server" id="trOperators" visible="false">
                                    <td align="left">
                                        <asp:Label ID="lblOperators" runat="server" Text="Operators"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddloperators" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td align="left">
                                        Commission
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtcommission" runat="server" Width="145"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="one"
                                            ControlToValidate="txtcommission" ErrorMessage="Please enter commission" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:FilteredTextBoxExtender ID="filtertex" runat="server" ValidChars="0123456789." TargetControlID="txtcommission">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="one" CssClass="lj_dbrd_link1"
                                            OnClick="btnsubmit_Click" />
                                        <asp:Label ID="lblCCode" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:GridView ID="GvFlightsReports" Width="100%" runat="server" AutoGenerateColumns="False"
                                            EmptyDataRowStyle-Height="250" AllowPaging="True" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                            ShowFooter="true" EmptyDataText="No records found" EmptyDataRowStyle-Font-Bold="true"
                                            EmptyDataRowStyle-Font-Size="Small" EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                            EmptyDataRowStyle-HorizontalAlign="Center" AllowSorting="True" CellPadding="4"
                                            DataKeyNames="CommID,Role,ServiceName,OperatorName,Commission,CreatedDate" EnableModelValidation="True"
                                            ForeColor="#333333" OnPageIndexChanging="GvFlightsReports_PageIndexChanging"
                                            OnSelectedIndexChanged="GvFlightsReports_SelectedIndexChanged">
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="CommID" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    Visible="false" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("CommID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ButtonField HeaderText="Role" DataTextField="Role" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px"
                                                    CommandName="Select" ControlStyle-Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                </asp:ButtonField>
                                                <asp:TemplateField HeaderText="Service Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Width="90px" ControlStyle-Width="120px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblServiceName" runat="server" Width="90px" Text='<%# Eval("ServiceName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Operator Name" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="90px"
                                                    ControlStyle-Width="90px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOperatorName" runat="server" Width="90px" Text='<%# Eval("OperatorName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Commission" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Width="130px" ControlStyle-Width="130px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCommission" runat="server" Width="130px" Text='<%# Eval("Commission") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Width="130px" Visible="false" ControlStyle-Width="130px">
                                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreatedDate" runat="server" Width="130px" Text='<%# Eval("CreatedDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <FooterStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
