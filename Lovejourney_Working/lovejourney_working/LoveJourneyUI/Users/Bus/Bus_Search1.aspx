<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="Bus_Search1.aspx.cs" Inherits="Users_Bus_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function showDiv() {
            Page_ClientValidate("Search");
            if (Page_ClientValidate("Search")) {
                go();
                go1();
                go2();
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "../../Images/roller_big.gif"', 200);
            }
            else
                return false;
        }
    </script>
    <style type="text/css">
        .modalContainer
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            position: fixed;
            left: 25%;
            top: 25%;
            z-index: 750;
            background-color: inherit;
            padding: 0px;
        }
        
        .registerhead
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #044cb5;
            padding: 22px 0 10px 0;
        }
        
        
        .loadingBackground
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            filter: Alpha(Opacity=30);
            -moz-opacity: 0.3;
            opacity: 0.6;
            width: 100%;
            height: 1000px;
            background-color: #000;
            position: fixed;
            z-index: 500;
            top: 0px;
            left: 0px;
        }
    </style>
    <script type="text/javascript">
        function Load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                var dateToday = new Date();
                $(".datepicker").datepicker({
                    dateFormat: 'dd-MM-yy',
                    numberOfMonths: 2,
                    showOn: "button",
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday
                });
                $("[id$='txtFromDate']").datepicker('setDate', 'today');
                $(".datepicker1").datepicker({
                    dateFormat: 'dd-MM-yy',
                    showOn: "button",
                    numberOfMonths: 2,
                    buttonImage: "../../images/calendar.jpg",
                    buttonImageOnly: true,
                    showAnim: 'fadeIn',
                    minDate: dateToday
                });
            }
        }
        function showDate() {
            $(".datepicker").datepicker("show");
        }
        function showDate1() {
            $(".datepicker1").datepicker("show");
        }
        $(function () {
            var dateToday = new Date();
            $(".datepicker").datepicker({
                dateFormat: 'dd-MM-yy',
                numberOfMonths: 2,
                showOn: "button",
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: dateToday
            });
            $("[id$='txtFromDate']").datepicker('setDate', 'today');
        });
        $(function () {
            var dateToday = new Date();
            $(".datepicker1").datepicker({
                dateFormat: 'dd-MM-yy',
                showOn: "button",
                numberOfMonths: 2,
                buttonImage: "../../images/calendar.jpg",
                buttonImageOnly: true,
                showAnim: 'fadeIn',
                minDate: dateToday
            });

        });
    </script>
    <style>
        .hhhh
        {
            max-height: 200px;
            overflow-y: scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <script type="text/javascript">
      function go() {
          var DropdownList = document.getElementById('<%=txtFrom.ClientID %>');

          document.getElementById('Text1').value = DropdownList.value;
      }
      function go1() {
          var DropdownList = document.getElementById('<%=txtTo.ClientID %>');

          document.getElementById('Text2').value = DropdownList.value;
      }
      function go2() {
          var SelectedText = document.getElementById('<%=txtFromDate.ClientID %>');
          document.getElementById('Text3').value = SelectedText.value;
      }
    </script>--%>
    <script type="text/javascript">
        function go() {
            var DropdownList = document.getElementById('<%=ddlSources.ClientID %>');
            var SelectedIndex = DropdownList.selectedIndex;
            var SelectedValue = DropdownList.value;
            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            document.getElementById('Text1').value = SelectedText;
        }

        function go1() {
            var DropdownList = document.getElementById('<%=ddlDestinations.ClientID %>');
            var SelectedIndex = DropdownList.selectedIndex;
            var SelectedValue = DropdownList.value;
            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            document.getElementById('Text2').value = SelectedText;
        }

        function go2() {
            var SelectedText = document.getElementById('<%=txtFromDate.ClientID %>');
            document.getElementById('Text3').value = SelectedText.value;
        }
    </script>
    <%--  <body  onload="Load();">--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
        <ContentTemplate>
            <table width="1004" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td height="520" valign="top">
                        <table width="400" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td valign="middle" align="center" class="tr" id="tdmsg" runat="server" visible="false">
                                                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="400" border="0" cellpadding="0" cellspacing="0" id="pnlBook" runat="server"
                                        align="left">
                                        <tr>
                                            <td height="20">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="400" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="right" valign="bottom" width="24" height="23">
                                                            <img src="../../images/formtop_left.png" />
                                                        </td>
                                                        <td class="form_top" width="347">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="bottom" width="29" height="23">
                                                            <img src="../../images/formright_top.png" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="form_left">
                                                            &nbsp;
                                                        </td>
                                                        <td width="347" align="left" valign="top" bgcolor="#ffffff">
                                                            <!--start online bus tickets-->
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <table width="347" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td valign="top" align="left" width="347">
                                                                            <table width="347" cellspacing="0" cellpadding="0" border="0" align="center">
                                                                                <tr>
                                                                                    <td valign="top" height="20" align="left">
                                                                                        <table width="347" height="50" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="50">
                                                                                                    <img src="../../Image/bus_button.png" width="50" height="37" />
                                                                                                </td>
                                                                                                <td align="left" valign="middle" class="online_booking" width="297">
                                                                                                    Bus Tickets Booking
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" height="28" align="center">
                                                                                        <table width="347" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tr>
                                                                                                <td height="12" colspan="2" class="border_top">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td width="104" height="30" valign="middle" align="left" class="lj_one">
                                                                                                    <asp:RadioButton ID="rbtnOneWay" Text="  One Way" runat="server" Checked="true" AutoPostBack="True"
                                                                                                        TabIndex="1" GroupName="ONE" OnCheckedChanged="rbtnOneWay_CheckedChanged" Font-Names="Arial" />
                                                                                                </td>
                                                                                                <td width="196" valign="middle" align="left" class="lj_one">
                                                                                                    <asp:RadioButton ID="rbtnRoundTrip" Text="  Round Trip" runat="server" AutoPostBack="True"
                                                                                                        TabIndex="2" GroupName="ONE" OnCheckedChanged="rbtnRoundTrip_CheckedChanged"
                                                                                                        Font-Names="Arial" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="10" colspan="2">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" height="30" align="left">
                                                                                        <table width="347" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tr>
                                                                                                <td valign="top" width="175" height="30" align="left" class="lj_hd">
                                                                                                    Leaving From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                                                                                                </td>
                                                                                                <td valign="top" align="left" height="30">
                                                                                                    <asp:DropDownList ID="ddlSources" ValidationGroup="Search" runat="server" Visible="true"
                                                                                                        AutoPostBack="True" TabIndex="3" CssClass="lj_inp" OnSelectedIndexChanged="ddlSources_SelectedIndexChanged"
                                                                                                        Width="160px">
                                                                                                    </asp:DropDownList>
                                                                                                    <asp:TextBox ID="txtFrom" runat="server" CssClass="lj_inp" ValidationGroup="Search"
                                                                                                        AutoPostBack="True" OnTextChanged="txtFrom_TextChanged" Visible="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None" ValidationGroup="Search"
                                                                                                        runat="server" ErrorMessage="Select source." ControlToValidate="txtFrom"></asp:RequiredFieldValidator>
                                                                                                    <ajax:AutoCompleteExtender ID="txtFrom_AutoCompleteExtender" runat="server" TargetControlID="txtFrom"
                                                                                                        ServiceMethod="GetCities" MinimumPrefixLength="2" CompletionInterval="10" CompletionSetCount="12"
                                                                                                        FirstRowSelected="True" DelimiterCharacters="" Enabled="True" ServicePath=""
                                                                                                        CompletionListCssClass="hhhh">
                                                                                                    </ajax:AutoCompleteExtender>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ValidationGroup="Search"
                                                                                                        runat="server" ErrorMessage="Select source." ControlToValidate="ddlSources" InitialValue="----------"></asp:RequiredFieldValidator>
                                                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator4">
                                                                                                    </ajax:ValidatorCalloutExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top" align="left" class="lj_hd" width="175">
                                                                                                    Leaving To &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                                                                                                </td>
                                                                                                <td valign="top" align="left">
                                                                                                    <asp:DropDownList ID="ddlDestinations" runat="server" ValidationGroup="Search" Visible="true"
                                                                                                        CssClass="lj_inp" TabIndex="4" onchange="showDate();" Width="160px">
                                                                                                    </asp:DropDownList>
                                                                                                    <asp:TextBox ID="txtTo" runat="server" ValidationGroup="Search" CssClass="lj_inp"
                                                                                                        AutoPostBack="True" OnTextChanged="txtTo_TextChanged" Visible="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Search"
                                                                                                        runat="server" ErrorMessage="Select destination." Display="None" ControlToValidate="txtTo"></asp:RequiredFieldValidator>
                                                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtTo"
                                                                                                        ServiceMethod="GetCities" MinimumPrefixLength="2" CompletionInterval="10" CompletionSetCount="12"
                                                                                                        FirstRowSelected="True" DelimiterCharacters="" Enabled="True" ServicePath=""
                                                                                                        CompletionListCssClass="hhhh">
                                                                                                    </ajax:AutoCompleteExtender>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Search"
                                                                                                        runat="server" ErrorMessage="Select destination." Display="None" ControlToValidate="ddlDestinations"
                                                                                                        InitialValue="----------"></asp:RequiredFieldValidator>
                                                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Source and Destination should not be same."
                                                                                                        Display="None" ControlToValidate="ddlDestinations" ControlToCompare="ddlSources" ValidationGroup="Search"
                                                                                                        Operator="NotEqual" Type="String"></asp:CompareValidator>
                                                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator5">
                                                                                                    </ajax:ValidatorCalloutExtender>
                                                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="CompareValidator1">
                                                                                                    </ajax:ValidatorCalloutExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" height="30" align="left">
                                                                                        <table width="347" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tr>
                                                                                                <td width="175" valign="middle" align="left" class="lj_hd">
                                                                                                    Departure On&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                                                                                                </td>
                                                                                                <td valign="middle" align="left" height="30">
                                                                                                    <asp:TextBox ID="txtFromDate" ValidationGroup="Search" runat="server" onKeyPress="javascript: return false;"
                                                                                                        TabIndex="5" onPaste="javascript: return false;" CssClass="datepicker" OnClick="showDate();"
                                                                                                        Width="150px" />
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Search"
                                                                                                        runat="server" ErrorMessage="Enter date." ControlToValidate="txtFromDate" Display="None"></asp:RequiredFieldValidator>
                                                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                                                                                    </ajax:ValidatorCalloutExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" height="28" align="left">
                                                                                        <table width="347" cellspacing="0" cellpadding="0" border="0" runat="server" id="tblReturn"
                                                                                            visible="false">
                                                                                            <tr>
                                                                                                <td width="175" valign="top" align="left" class="lj_hd">
                                                                                                    <asp:Label ID="lblReturningOn" Text="Return On" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                                                                                                </td>
                                                                                                <td valign="top" align="left">
                                                                                                    <asp:TextBox ID="txtReturnDate" runat="server" Enabled="False" Visible="true" ValidationGroup="Search"
                                                                                                        TabIndex="6" CssClass="datepicker1" onKeyPress="javascript: return false;" onPaste="javascript: return false;"
                                                                                                        OnClick="showDate1();" Width="150px" />
                                                                                                    <asp:RequiredFieldValidator ID="RequiredReturn" ControlToValidate="txtReturnDate"
                                                                                                        runat="server" Visible="false" ErrorMessage="Enter return date." Display="None"
                                                                                                        ValidationGroup="Search"></asp:RequiredFieldValidator>
                                                                                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredReturn">
                                                                                                    </ajax:ValidatorCalloutExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" align="left">
                                                                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        &nbsp;&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" align="center">
                                                                                        <asp:Button ID="btnSearch" runat="server" OnClientClick="showDiv();" Text="Check Availability"
                                                                                            CssClass="buttonBook" OnClick="btnSearch_Click" ValidationGroup="Search" />
                                                                                        <%--    OnClientClick="showDiv();" --%>
                                                                                        <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                                                                            style="display: none" class="modalContainer">
                                                                                            <div class="registerhead">
                                                                                                <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
                                                                                                    <tr>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="../../images/l1.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                        <td height="8" width="582" bgcolor="#ffffff">
                                                                                                        </td>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="../../images/l2.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3" bgcolor="#ffffff" align="center" valign="top">
                                                                                                            <table width="582" border="0" cellspacing="0" cellpadding="0">
                                                                                                                <tr>
                                                                                                                    <td align="center" height="25" valign="top">
                                                                                                                        <img src="../../images/logo.gif" alt="Logo" border="0" title="LoveJourney">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td height="1" bgcolor="#c6c6c6">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" class="almost" height="20">
                                                                                                                        Almost there
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center">
                                                                                                                        <img src="../../images/loading.gif" width="60" height="60" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" class="almost12" height="20">
                                                                                                                        Searching for Buses
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20">
                                                                                                                        <input id="Text1" type="text" style="border: 0px; text-align: right; background-color: White;"
                                                                                                                            disabled="disabled" class="progress" />&nbsp;&nbsp;To&nbsp;&nbsp;<input id="Text2"
                                                                                                                                type="text" style="border: 0px; text-align: left; background-color: White;" class="progress"
                                                                                                                                disabled="disabled" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20">
                                                                                                                        On
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" height="20">
                                                                                                                        <input id="Text3" type="text" style="border: 0px; text-align: center; background-color: White;"
                                                                                                                            class="progress" disabled="disabled" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="../../images/l3.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                        <td height="8" width="582" bgcolor="#ffffff">
                                                                                                        </td>
                                                                                                        <td width="9" height="8">
                                                                                                            <img src="../../images/l4.png" width="9" height="8" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>
                                                                                        </span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <!-- end onlie bus tickets -->
                                                        </td>
                                                        <td class="form_right">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top" width="24" height="32">
                                                            <img src="../../images/formbottom_left.png" />
                                                        </td>
                                                        <td class="form_bottom">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top" width="29" height="32">
                                                            <img src="../../images/formright_bottom.png" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</body>--%>
</asp:Content>
