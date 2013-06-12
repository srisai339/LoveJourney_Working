<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CancelHTicket.aspx.cs" Inherits="CancelHTicket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cancel Ticket</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="1px">
            <tr>
                <td width="1000%" align="left" colspan="2">
                    <strong>Cancel Ticket </strong>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    Booking Ref No:
                </td>
                <td width="80%">
                    <asp:TextBox ID="txtBookingRefNo" runat="server" ValidationGroup="cancel"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookingRefNo"
                        Display="Dynamic" ErrorMessage="Please enter reference number." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    Email Id:
                </td>
                <td width="80%">
                    <asp:TextBox ID="txtEmailId" runat="server" ValidationGroup="cancel"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailId"
                        Display="Dynamic" ErrorMessage="Please enter email id." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId"
                        Display="Dynamic" ErrorMessage="Please enter valid email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="cancel"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    &nbsp;
                </td>
                <td width="80%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    &nbsp;
                </td>
                <td width="80%">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                        ValidationGroup="cancel" />
                    &nbsp;&nbsp;
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
