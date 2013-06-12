<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="OfferZone.aspx.cs" Inherits="OfferZone" %>

<asp:Content ID="content1" ContentPlaceHolderID="cphSearch" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="3">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="1004" border="0" cellspacing="0" cellpadding="0" bgcolor="">
                    <tr>
                        <td class="a_hding" valign="middle" colspan="3" align="center" height="30">
                           Offer Zone
                        </td>
                    </tr>
                    <tr>
                        <td height="4" >
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <table width="1004" border="0" cellspacing="0" cellpadding="0" >
                                <tr>  
                                    <td valign="top" colspan="3" align="left" height="30" bgcolor="#ffffff">
                                    
                                      <asp:Label ID="lblContent" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td valign="top">
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
            </td>
        </tr>
    </table>
    <%--<table width="710">
        <tr>
            <td align="left" valign="bottom" colspan="2">
                <asp:Label ID="lblContent" runat="server"></asp:Label>
            </td>
        </tr>
    </table>--%>
</asp:Content>
