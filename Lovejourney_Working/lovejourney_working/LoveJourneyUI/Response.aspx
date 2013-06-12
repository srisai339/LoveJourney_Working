<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Response.aspx.cs" Inherits="EBS.Response" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
<HEAD>
<TITLE>E-Billing Solutions Pvt Ltd - Payment Page</TITLE>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=iso-8859-1">
<style>
	h1       { font-family:Arial,sans-serif; font-size:24pt; color:#08185A; font-weight:100; margin-bottom:0.1em}
    h2.co    { font-family:Arial,sans-serif; font-size:24pt; color:#FFFFFF; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
    h3.co    { font-family:Arial,sans-serif; font-size:16pt; color:#000000; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
    h3       { font-family:Arial,sans-serif; font-size:16pt; color:#08185A; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
    body     { font-family:Verdana,Arial,sans-serif; font-size:11px; color:#08185A;}
	th 		 { font-size:12px;background:#015289;color:#FFFFFF;font-weight:bold;height:30px;}
	td 		 { font-size:12px;background:#DDE8F3}
	.pageTitle { font-size:24px;}
</style>
</HEAD>
<BODY LEFTMARGIN=0 TOPMARGIN=0 MARGINWIDTH=0 MARGINHEIGHT=0 bgcolor="#ECF1F7">
<center>
   <!--<table width='100%' cellpadding='0' cellspacing="0" ><tr><th width='90%'><h2 class='co'>&nbsp;EBS Payment Integration Page</h2></th></tr></table>-->
	
</center>
<table width='100%' cellpadding='0' cellspacing="0" ><tr><th width='90%'>&nbsp;</th></tr></table>
</body>
</html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Label ID="Message" runat="server" />
        <asp:Label ID="lblRequestID" runat="server" Visible="false"></asp:Label>
        <asp:Button ID="OpenID" runat="server" Visible="false" />
        <asp:Button ID="Button11" runat="server" Visible="false" />
        <ajaxToolkit:ModalPopupExtender ID="Mpe1" PopupControlID="pnldialog" runat="server"
        TargetControlID="OpenID" BackgroundCssClass="modalBackground" OkControlID="Button2">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnldialog" runat="server" Style="display: none; width: 500px; height: 150px;"
        align="center" DefaultButton="Button2">
        <table id="Table1" runat="server" width="500px" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="21" align="left" valign="top">
                    <asp:Image ID="Image1" runat="server" ImageUrl="images/ModelPopub/searchreultstopleft.gif"
                        Width="21" />
                </td>
                <td align="left" valign="middle" class="searchresultstopbg">
                    <span class="innerheading">
                        <asp:Label ID="Label8" runat="server">Message</asp:Label>
                    </span>
                </td>
                <td width="21" align="left" valign="top">
                    <asp:Image ID="Image31" runat="server" ImageUrl="images/ModelPopub/searchresultstopright.gif"
                        Width="21" Height="40" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" class="searchresultsleftbg">
                    &nbsp;
                </td>
                <td align="center" valign="top" class="searchresultsbg">
                    <table>
                        <caption>
                            <br />
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblMessage" runat="server" CssClass="tabtext"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button2" runat="server" CausesValidation="false" CssClass="i2s_jp_status1"
                                        Text="OK" />
                                </td>
                            </tr>
                        </caption>
                    </table>
                </td>
                <td align="left" class="searchresultsrightbg" valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <asp:Image ID="image2" runat="server" Height="22" ImageUrl="~/images/ModelPopub/searchresultsbottomleft.gif"
                        Width="21" />
                </td>
                <td align="left" class="searchbottombg" valign="top">
                    &nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:Image ID="Image5" runat="server" Height="22" ImageUrl="~/images/ModelPopub/searchresultsbottomright.gif"
                        Width="21" />
                </td>
            </tr>
        </table>
    </asp:Panel>
        
    </div>
    </form>
</body>
</html>
