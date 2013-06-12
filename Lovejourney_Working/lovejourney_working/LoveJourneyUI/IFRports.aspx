<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="IFRports.aspx.cs" Inherits="IFRports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="100%">
                <table>
                    <tr>
                        <td width="1000" align="center">
                            <table width="1000">
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdlflights" runat="server" RepeatDirection="Horizontal"
                                            Width="300" OnSelectedIndexChanged="rdlflights_SelectedIndexChanged">
                                            <asp:ListItem Value="DomesticFlights">Domestic Flights</asp:ListItem>
                                            <asp:ListItem Value="InterNationalFlights">InterNational Flights</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="1130">
                                            <asp:GridView ID="GvFlightsReports" Width="100%" runat="server" AutoGenerateColumns="False"
                                                EmptyDataRowStyle-Height="250" AllowPaging="True" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                                ShowFooter="true" EmptyDataText="No records found" EmptyDataRowStyle-Font-Bold="true"
                                                EmptyDataRowStyle-Font-Size="Small" EmptyDataRowStyle-ForeColor="#657600" EmptyDataRowStyle-VerticalAlign="Top"
                                                EmptyDataRowStyle-HorizontalAlign="Center" AllowSorting="True" CellPadding="4"
                                                EnableModelValidation="True" ForeColor="#333333">
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Booking Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        Visible="false" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBookingId" runat="server" Text='<%# Eval("Int_Booking_Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ref No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReferenceNo" runat="server" Text='<%# Eval("ReferenceNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Travel Name" ItemStyle-HorizontalAlign="Center" Visible="false"
                                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-Width="50px"
                                                        ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArrivalAirportName" runat="server" Text='<%# Eval("ArrivalAirportName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="80px" ControlStyle-Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCustomerDetails" runat="server" Text='<%# Eval("CustomerDetails") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="EmailID" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="80px" ControlStyle-Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmailAddress" runat="server" Text='<%# Eval("EmailAddress") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="80px" ControlStyle-Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTelephone" runat="server" Text='<%# Eval("Telephone") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Journey Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartureDateTime" runat="server" Text='<%# Eval("DepartureDateTime") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Flight No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFlightNumber" runat="server" Text='<%# Eval("FlightNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Actual Fare" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblActualBasefare" runat="server" Text='<%# Eval("ActualBasefare") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Scharge" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblScharge" runat="server" Text='<%# Eval("Scharge") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTDiscount" runat="server" Text='<%# Eval("TDiscount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Commission" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTPartnerCommission" runat="server" Text='<%# Eval("TPartnerCommission") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TCharge" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTCharge" runat="server" Width="50" Text='<%# Eval("TCharge") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MarkUp" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTMarkUp" runat="server" Text='<%# Eval("TMarkUp") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <FooterStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </asp:Panel>
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
