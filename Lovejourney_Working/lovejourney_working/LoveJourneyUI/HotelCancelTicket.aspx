<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HotelCancelTicket.aspx.cs" Inherits="HotelCancelTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
       <tr>
                                                        <td align="center" bgcolor="#0062af" style="color: White">
                                                            &nbsp;&nbsp; Cancel Ticket
                                                        </td>
                                                    </tr>
        <tr>
            <td width="100%">
           <%--   <h3 style="color: #336699; font-size: 21px; margin-left: 32px; margin-top: 10px;
                                margin-bottom: 10px;">
                                <span style="color: #cc0000;">Cancel</span> Ticket</h3>--%>
                <table width="100%" >
                   
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td width="40%" align="right">
                            Booking Ref No:
                        </td>
                        <td width="60%">
                            <asp:TextBox ID="txtBookingRefNo" runat="server" ValidationGroup="cancel"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookingRefNo"
                                Display="Dynamic" ErrorMessage="Please enter reference number." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            Email Id:
                        </td>
                        <td width="60%">
                            <asp:TextBox ID="txtEmailId" runat="server" ValidationGroup="cancel"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailId"
                                Display="Dynamic" ErrorMessage="Please enter email id." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId"
                                Display="Dynamic" ErrorMessage="Please enter valid email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="cancel"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;
                        </td>
                        <td width="60%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;
                        </td>
                        <td width="60%">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="buttonBook"
                                ValidationGroup="cancel" />
                            &nbsp;&nbsp;
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
