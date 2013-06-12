<%@ Page Title="" Language="C#"MasterPageFile="~/Agent/Recharge/MasterPage.master"
    AutoEventWireup="true" CodeFile="RechargeSucces.aspx.cs" Inherits="Agent_Recharge_RechargeSucces" %>
      <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <table width="900" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center">
                <table width="900" border="0" cellspacing="0" cellpadding="0" bgcolor="" class="header">
                    <tr>
                        <td valign="top" align="center">
                            <table width="900" class="master_content" border="0" cellspacing="0" cellpadding="0"
                                bgcolor="#ffffff">
                                <tr>
                                    <td class="heading" valign="middle" colspan="3" align="center" >
                                        Recharge Status
                                    </td>
                                </tr>
                             
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                               
                               
                                <tr>
                                    <td colspan="3" height="20" align="center">
                                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true" Font-Size="15px"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan="3" height="20" align="center">
                                        <asp:Label ID="lblreqid" runat="server" Font-Bold="true" Font-Size="15px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="test" valign="middle" colspan="3" align="center" height="30">
                                        <%--<asp:Image ID="rechargesucess" runat="server" ImageUrl="images/rs.jpg" />--%>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Please Click Here To check the status"
                                            PostBackUrl="~/Agent/Recharge/RechargeStatus.aspx" ForeColor="Black" OnClick="LinkButton1_Click"></asp:LinkButton>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="test" valign="middle" colspan="3" align="center">
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td class="test" valign="middle" colspan="3" align="center" height="30">
                                        Thank You For Using lovejourney.in
                                        <%--<asp:LinkButton ID="lnkbtnhome" runat="server" Text="Click Here To Go Home" PostBackUrl="~/Default.aspx" ForeColor="Black"></asp:LinkButton>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!--footerEnd-->
        <tr>
            <td style="display: none">
                <asp:Button ID="Button1" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID9" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="Button2" runat="server" Text="OK" />
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <asp:Button ID="OpenID11" runat="server" Text="OK" />
            </td>
        </tr>
    </table>
</asp:Content>
