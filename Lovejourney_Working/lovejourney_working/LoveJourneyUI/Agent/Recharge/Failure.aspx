<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="Failure.aspx.cs" Inherits="Agent_Recharge_Failure" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="900" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="" class="header">
                    <tr>
                        <td valign="top" align="center">
                            <table width="900" class="admintext" border="0" cellspacing="0" cellpadding="0"  height="100"
                                bgcolor="#ffffff">
                                <tr>
                                    <td class="heading" valign="middle" colspan="3" align="center" height="20" width="860px">
                                        Recharge failure
                                    </td>
                                </tr>
                                <tr height="20">
                                    <td class="admintext" valign="middle" align="center">
                                        <asp:Label ID="lblStrmessage" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                  <tr height="20">
                                    <td class="admintext" valign="middle" align="center">
                                        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                  <tr height="20">
                                    <td class="admintext" valign="middle" align="center">
                                        <asp:Label ID="lblreqid" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="admintext" valign="middle" colspan="3" align="center" width="100%">
                                        <table  width="100%">
                                            <tr>
                                                <td align="center">
                                                    Recharge Failed ,May be Due to any of the Following Reasons:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table  width="30%" >
                                                        <tr>
                                                            <td align="left">
                                                                a) Invalid Card Details.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                b) Card has Expired.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                c) Insufficient Funds.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                d) VBV/3D Secure
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                e) Technical Problem
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td align="center">
                                                  Authentication Unsuccessful. Kindly check for the above details and Try Again
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>--%>
                            </table>
                        </td>
                    </tr>
                    <%--  <tr>
                                    <td class="admintext" valign="middle" colspan="3" align="center" height="30">
                                        Recharge Failed ,May be Due to any of the Following Reasons:
                                        <p>
                                        <p</p>
                                        </p>
                                        <p>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a) Invalid Card Details.</p>
                                        <p>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            b) Card has Expired.</p>
                                        <p>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            c)Insufficient Funds.</p>
                                        <p>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            d) VBV/3D Secure</p>
                                        <p>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            e)Technical Problem</p>
                                        <p>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            Authentication Unsuccessful. Kindly check for the above details and Try Again</p>
                                    </td>
                                </tr>--%>
                    <tr>
                        <td class="test" valign="middle"  align="center" height="30">
                            Thank You For Using lovejourney.in
                           <%-- <asp:LinkButton ID="lnkbtnhome" runat="server" Text="Click Here To Go Home" PostBackUrl="~/Masters/HomePage.aspx"
                                ForeColor="Black"></asp:LinkButton>--%>
                        </td>
                    </tr>
                    <tr height="25">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
   
</asp:Content>
