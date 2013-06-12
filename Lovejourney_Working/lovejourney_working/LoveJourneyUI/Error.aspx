<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error"
    MasterPageFile="~/MainMasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="cnTirupathiUserMst" ContentPlaceHolderID="cphSearch" runat="server">
    <style type="text/css">
        .jp_errorbg
        {
            background: url(images/erroribg.jpg) no-repeat top;
            height: 403px;
        }
        .jp_erro02
        {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 26px;
            font-weight: normal;
            color: #0848bd;
        }
        .jp_erro03
        {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 26px;
            font-weight: normal;
            color: #ff0101;
        }
        .jp_err-text
        {
            font-family: "Tw Cen MT" , "Century Gothic";
            font-size: 16px;
            font-weight: normal;
            line-height: 18px;
            color: #ff0101;
        }
    </style>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" valign="top">
                <table width="1000" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="750" align="center" valign="top" bgcolor="#FFFFFF">
                            <table width="1000" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center" valign="bottom" bgcolor="#FFFFFF" class="jp_errorbg">
                                        <table width="900" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    Go to Home Page, Please <asp:LinkButton ID="lnkbtnClick" runat="server" 
                                                        Text="Click Here" onclick="lnkbtnClick_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="310">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="error" runat="server" visible="false">
                                                <td align="left" valign="top" class="jp_err-text">
                                                    <asp:Literal ID="PageNotFound" runat="server" Text="Page Not Found (404 Error)"></asp:Literal><br />
                                                    <asp:Literal ID="Errorreq" runat="server" Text="The page you requested cannot be found. The page you are looking for might have been removed, had its name changed, or is temporarily unavailable."></asp:Literal>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="bottom">
                                        &nbsp;
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
