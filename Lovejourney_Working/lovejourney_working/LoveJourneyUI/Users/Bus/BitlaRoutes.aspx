<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master"
    AutoEventWireup="true" CodeFile="BitlaRoutes.aspx.cs" Inherits="Users_BitlaRoutes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<table width="100%" cellpadding="0" cellspacing="0" border="0">
 <tr>
   <td height="450" valign="top">

    <table width="100%" >
       <tr>
            <td width="100%" class="heading" align="center"  >
                <asp:Label ID="Label1" runat="server" Text="Bitla Routes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
            <asp:Panel ID="pnlMain" runat="server" BackColor="#ffffff">

    <div align="center" id="divroutes" runat="server">
        <br />
        Date:<asp:TextBox ID="txtDate" runat="server" ValidationGroup="Search" onkeypress="javascript: return false;"
            onpaste="javascript: return false;"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.jpg" />
        <ajax:CalendarExtender ID="txtDateOfJourney_CalendarExtender" runat="server" FirstDayOfWeek="Sunday"
            Format="yyyy-MM-dd" TargetControlID="txtDate" PopupButtonID="ImageButton1">
        </ajax:CalendarExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Search"
            runat="server" ErrorMessage="Please enter date." ControlToValidate="txtDate"
            Display="None">
        </asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="Search"
            Display="None" ErrorMessage="Please enter valid format (yyyy-mm-dd)." ControlToValidate="txtDate"
            Type="Date" Operator="DataTypeCheck">
        </asp:CompareValidator>
        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" WarningIconImageUrl="~/Images/001_111.png"
            CloseImageUrl="~/Images/001_051.png" TargetControlID="RequiredFieldValidator3">
        </ajax:ValidatorCalloutExtender>
        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" WarningIconImageUrl="~/Images/001_111.png"
            CloseImageUrl="~/Images/001_051.png" TargetControlID="CompareValidator1">
        </ajax:ValidatorCalloutExtender>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn" runat="server" Text="  Submit  " OnClick="btn_Click" OnClientClick="this.disabled = true; this.value = ' Submitting... ';"
            UseSubmitBehavior="false" ValidationGroup="Search" CssClass="buttonBook"/><br />
        <%--<asp:Button ID="btnDelete" runat="server" Text=" Delete Past Dates Routes " 
            onclick="btnDelete_Click" />--%>
        <br />
        <br />
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <br />
    </div>
    </asp:Panel>
    </td>
    </tr>
    </table>
</asp:Content>
