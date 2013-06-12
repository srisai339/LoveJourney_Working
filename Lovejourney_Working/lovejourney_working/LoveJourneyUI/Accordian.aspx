<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Accordian.aspx.cs" Inherits="Accordian" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
.accordionContent {
background-color: #D3DEEF;
border-color: -moz-use-text-color #2F4F4F #2F4F4F;
border-right: 1px dashed #2F4F4F;
border-style: none dashed dashed;
border-width: medium 1px 1px;
padding: 10px 5px 5px;
width:20%;
}
.accordionHeaderSelected {
background-color: #5078B3;
border: 1px solid #2F4F4F;
color: white;
cursor: pointer;
font-family: Arial,Sans-Serif;
font-size: 12px;
font-weight: bold;
margin-top: 5px;
padding: 5px;
width:20%;
}
.accordionHeader {
background-color: #2E4D7B;
border: 1px solid #2F4F4F;
color: white;
cursor: pointer;
font-family: Arial,Sans-Serif;
font-size: 12px;
font-weight: bold;
margin-top: 5px;
padding: 5px;
width:20%;
}
.href
{
color:White; 
font-weight:bold;
text-decoration:none;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <ajax:ToolkitScriptManager ID="Scriptmanager1" runat="server"/>
<div >
<ajax:Accordion ID="UserAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None" >
<Panes>
<ajax:AccordionPane ID="AccordionPane1" runat="server">
<Header><a href="#" class="href">New User</a></Header>
<Content>
<asp:Panel ID="UserReg" runat="server">
<table align="center">
<tr>
<td></td>
<td align="right" >
</td>
<td align="center">
<b>Registration Form</b>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
UserName:
</td>
<td>
<asp:TextBox ID="txtuser" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Password:
</td>
<td>
<asp:TextBox ID="txtpwd" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
FirstName:
</td>
<td>
<asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
LastName:
</td>
<td>
<asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Email:
</td>
<td>
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Phone No:
</td>
<td>
<asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Location:
</td>
<td align="left">
<asp:TextBox ID="txtlocation" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td></td>
<td align="left" ><asp:Button ID="btnsubmit" runat="server" Text="Save"/>
<input type="reset" value="Reset" />
</td>
</tr>
</table>
</asp:Panel>
</Content>
</ajax:AccordionPane>
<ajax:AccordionPane ID="AccordionPane2" runat="server">
<Header><a href="#" class="href">User Detail</a></Header>
<Content>
<asp:Panel ID="Panel1" runat="server">
<table align="center">
<tr>
<td align="right" colspan="2">
UserName:
</td>
<td>
<b>Suresh Dasari</b>
</td>
</tr>
<tr>
<td align="right" colspan="2">
FirstName:
</td>
<td>
<b>Suresh</b>
</td>
</tr>
<tr>
<td align="right" colspan="2">
LastName:
</td>
<td>
<b>Dasari</b>
</td>
</tr>
<tr>
<td align="right" colspan="2">
Email:
</td>
<td>
<b>sureshbabudasari@gmail.com</b>
</td>
</tr>
<tr>
<td align="right" colspan="2" >
Phone No:
</td>
<td>
<b>1234567890</b>
</td>
</tr>
<tr>
<td align="right" colspan="2" >
Location:
</td>
<td align="left">
<b>Hyderabad</b>
</td>
</tr>
</table>
</asp:Panel>
</Content>
</ajax:AccordionPane>
<ajax:AccordionPane ID="AccordionPane3" runat="server">
<Header><a href="#" class="href">Job Details</a> </Header>
<Content>
<asp:Panel ID="Panel2" runat="server">
<table align="center">
<tr>
<td></td>
<td align="right">
Job Type:
</td>
<td>
<b>Software</b>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Industry:
</td>
<td>
<b>IT</b>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Designation:
</td>
<td>
<b>Software Engineer</b>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Company:
</td>
<td>
<b>aspdotnet-suresh</b>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Phone No:
</td>
<td>
<b>1234567890</b>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Location:
</td>
<td align="left">
<b>Hyderabad</b>
</td>
</tr>
</table>
</asp:Panel>
</Content>
</ajax:AccordionPane>
</Panes>
</ajax:Accordion>
    </div>
    </form>
</body>
</html>
