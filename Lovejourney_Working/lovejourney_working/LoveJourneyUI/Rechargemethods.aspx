<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rechargemethods.aspx.cs" Inherits="Rechargemethods" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
    </div>
    </form>
</body>
</html>
