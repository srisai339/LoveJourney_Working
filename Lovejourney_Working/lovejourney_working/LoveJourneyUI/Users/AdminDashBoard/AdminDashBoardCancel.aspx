<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="AdminDashBoardCancel.aspx.cs" Inherits="AdminDashBoard_AdminDashBoardCancel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <title>LoveJourney - Cancel Ticket Online</title>
    <link href="../../css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
     <script type="text/javascript" language="javascript">
         function showDiv() {
             Page_ClientValidate("signin");
             if (Page_ClientValidate("signin")) {
                 document.getElementById('mainDiv').style.display = "";
                 document.getElementById('contentDiv').style.display = "";
                 setTimeout('document.images["myAnimatedImage"].src = "images/loading.gif"', 200);
             }
             else
                 return false;
         }
         function showDiv1() {
             Page_ClientValidate("Cancel");
             if (Page_ClientValidate("Cancel")) {
                 document.getElementById('mainDiv').style.display = "";
                 document.getElementById('contentDiv').style.display = "";
                 setTimeout('document.images["myAnimatedImage"].src = "images/loading.gif"', 200);
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%">
<tr>
 <td align="center"  bgcolor="#0062af" style="color: White; font-size: medium;"  >
                       Cancel Ticket
                     </td>
</tr>
      <tr>
      <td>
       <td align="right">
          <asp:LinkButton ID="linkCancel" runat="server" Text="Back" onclick="linkCancel_Click" 
                                        ></asp:LinkButton>
          </td>
      </td>
      </tr>
        <tr>
            <td>
                <table width="1000">
                    <tr>
                        <td width="1000" align="center">
                            <table width="70%">
                                <tr>
                                    <td width="35%" align="center">
                                        <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlType" runat="server" Width="160" AutoPostBack="True" 
                                            onselectedindexchanged="ddlType_SelectedIndexChanged">
                                            <asp:ListItem Value="--PleaseSelect--">--Please Select--</asp:ListItem>
                                            <asp:ListItem Value="DomesticFlights">Flights</asp:ListItem>                                            
                                            <asp:ListItem Value="Hotels">Hotels</asp:ListItem>
                                            <asp:ListItem Value="Buses">Buses</asp:ListItem>                                            
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td align="right">
                                        <asp:Button ID="btnprint" runat="server" Text="Search" OnClick="btnprint_Click" BackColor="#0062af" ForeColor="White" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td height="20" align="center" colspan="2">
                                        <asp:Label ID="lblMsg" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr> 

                    <tr>
                        <td> 
                            <asp:Panel ID="pnldomesticflights" runat="server" Visible="false">
                                <table>
                                   <tr>
                                        <td align="center">
                                            <asp:Label ID="lblMainMSg" runat="server" />
                                        </td>
                                    </tr>
                                   <tr>
                <td align="center">
                    <asp:Panel ID="pnlCancel" runat="server" Width="990">
                        <table cellspacing="0" cellpadding="0" align="center" style="background-color: White;border: 1px solid #0062af" width="990"
                                                    >
                            <tr>
                                <td align="left" colspan="3" bgcolor="#0062af" style="color: White">
                                    Cancel Ticket
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblStatus1" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="rbtnDomesticInt" RepeatDirection="Horizontal" runat="server"
                                        OnSelectedIndexChanged="rbtnDomesticInt_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="Domestic" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="International" Value="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Enter Booking Reference Number
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBookingReferenceNo" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Ref No" ControlToValidate="txtBookingReferenceNo"
                                        Display="None" runat="server" ValidationGroup="signin" />
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvUsername">
                                    </ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Email ID
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Enter Email ID"
                                        ControlToValidate="txtEmailAddress" Display="None" runat="server" ValidationGroup="signin" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Enter a Valid Email ID"
                                        ControlToValidate="txtEmailAddress" Display="None" runat="server" ValidationGroup="signin"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator1"
                                        >
                                    </ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Reason
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtReason" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                        ValidationGroup="signin" CssClass="buttonBook" />
                                    <asp:Button ID="btnCancelInt" runat="server" Text="Cancel" OnClick="btnCancelInt_Click"
                                        ValidationGroup="signin" Width="59px" Visible="False" CssClass="buttonBook" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>

                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlbuses1" runat="server" Visible="false">
                                <table width="100%">
        <tr>
            <td>
               

                        <table width="900" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="center">
                                    <asp:Panel ID="PnlBuses" Width="900" runat="server" DefaultButton="btnSignIn">
                                        <table width="900" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: White;">
                                           
                                            <tr>
                                                <td colspan="2" height="20" align="center">
                                                    <asp:Label ID="lblCode" runat="server" Visible="false" />
                                                    <asp:Label ID="lblMsg1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <table width="500" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="35%" align="left">
                                                                LoveJourney Ref No&nbsp;&nbsp;<span style="color: Red;">*</span>&nbsp;
                                                            </td>
                                                            <td align="left" height="34" width="65%" valign="top">
                                                                :&nbsp;<asp:TextBox ID="txtMBRefNo" MaxLength="50" runat="server" CssClass="textfield_sleep" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Ref No" ControlToValidate="txtMBRefNo"
                                                                    Display="None" runat="server" ValidationGroup="signin" />
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvUsername">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="35%" align="left" valign="top">
                                                                Email Id&nbsp;&nbsp;<span style="color: Red;">*</span>
                                                            </td>
                                                            <td width="65%" align="left" valign="top">
                                                                :&nbsp;<asp:TextBox ID="txtEmailID" MaxLength="50" runat="server" CssClass="textfield_sleep" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Enter Email ID"
                                                                    ControlToValidate="txtEmailID" Display="None" runat="server" ValidationGroup="signin" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ErrorMessage="Enter a Valid Email ID"
                                                                    ControlToValidate="txtEmailID" Display="None" runat="server" ValidationGroup="signin"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator1"
                                                                 >
                                                                </ajax:ValidatorCalloutExtender>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator1"
                                                                 >
                                                                </ajax:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" width="35%" class="p_nme">
                                                                <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                                                    style="display: none" class="modalContainer">
                                                                    <div class="registerhead">
                                                                        <img src="images/loading.gif" width="150" height="150" alt="Loading" />
                                                                    </div>
                                                                </span>
                                                            </td>
                                                            <td align="left" width="65%" valign="top">
                                                                &nbsp;&nbsp;<asp:Button ID="btnSignIn" runat="server" Text="Submit" CssClass="buttonBook"
                                                                    ValidationGroup="signin" OnClick="btnSignIn_Click" OnClientClick="showDiv();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:GridView ID="gvCancelDetails" AutoGenerateColumns="false" runat="server" BackColor="White"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Cancellation Details
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                PNRNumber&nbsp;&nbsp;<%#Eval("PNRNumber")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                FirstName&nbsp;&nbsp;<%#Eval("FirstName")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                SeatNumbers&nbsp;&nbsp;<%#Eval("SeatNumbers")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                JourneyDate&nbsp;&nbsp;<%#Eval("JourneyDate")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                TicketFare&nbsp;&nbsp;<%#Eval("TicketFare")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                TotalTicketFare&nbsp;&nbsp;<%#Eval("TotalTicketFare")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                TicketBasicFareRefunded&nbsp;&nbsp;<%#Eval("TicketBasicFareRefunded")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                TotalDiscountAmount&nbsp;&nbsp;<%#Eval("TotalDiscountAmount")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                TotalServiceTaxRefunded&nbsp;&nbsp;<%#Eval("TotalServiceTaxRefunded")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                GrandTotalRefunded&nbsp;&nbsp;<%#Eval("GrandTotalRefunded")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                CancellationCharges&nbsp;&nbsp;<%#Eval("CancellationCharges")%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" align="left">
                                                                                ResponseDateTime&nbsp;&nbsp;<%#Eval("ResponseDateTime")%></td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                        <HeaderStyle BackColor="#003a73" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                    <asp:GridView ID="gvAlreadyCancelDetails" AutoGenerateColumns="true" runat="server"
                                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                        CellPadding="3" EnableModelValidation="True" Width="100%">
                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                        <HeaderStyle BackColor="#003a73" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" colspan="2" align="left">
                                                    &nbsp;<asp:RadioButtonList ID="rbtnlstCancelType" runat="server" Visible="false"
                                                        RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnlstCancelType_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Text="Total Cancellation" Value="0" />
                                                        <asp:ListItem Text="Partial Cancellation" Value="1" />
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="rfvcanType" ErrorMessage="Requiured" ControlToValidate="rbtnlstCancelType"
                                                        runat="server" ValidationGroup="Cancel" />
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" colspan="2" align="left">
                                                    <asp:GridView ID="gvPartialCancellation" AutoGenerateColumns="False" runat="server"
                                                        OnRowDataBound="gvPartialCancellation_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"
                                                        Width="60%">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkSelectAll" Text="All" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkChild" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Seat Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSeatNo" Text='<%#Eval("SeatNo") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" Text='<%#Eval("Status") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                        <HeaderStyle BackColor="#003a73" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:Button ID="btnConfrmCancel" Text="Confirm To Cancel" runat="server" CssClass="selectseats_input"
                                                        ValidationGroup="Cancel" Visible="false" OnClick="btnConfrmCancel_Click" OnClientClick="showDiv1();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" style="padding-left: 20px; line-height: 20px; font-family: Arial,Verdana;
                                    font-size: 12px;" colspan="2">
                                    <p style="padding-left: 20px;">
                                        &nbsp;</p>
                                    <p style="padding-left: 20px;">
                                        <span style="line-height: 20px; font-family: Arial,Verdana; color: Red; font-size: 13px;
                                            font-weight: bold;"><u>Notes:</u></span><br />
                                        <br />
                                        <span style="line-height: 20px; font-family: Arial,Verdana; font-size: 13px;">1. In
                                            case you’re unable to cancel your ticket online, please reach out to us. Click <a
                                                href="ContactUs.aspx" style="color: Blue;">here</a> for our contact details.</span><br />
                                        <br />
                                        <span style="line-height: 20px; font-family: Arial,Verdana; font-size: 12px;">2. Cancellation
                                            policies differ for each operator and is not set by LoveJourney.</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    

            </td>
        </tr>
    </table>

                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlhotels" runat="server" Visible="false">
                                <table width="100%">
        <tr>
            <td width="100%">
              <h3 style="color: #336699; font-size: 21px; margin-left: 32px; margin-top: 10px;
                                margin-bottom: 10px;">
                                <span style="color: #cc0000;">Cancel</span> Ticket</h3>
                <table width="100%" >
                   
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td width="40%" align="right">
                            Booking Ref No:
                        </td>
                        <td width="60%">
                            <asp:TextBox ID="txtBookingRefNo" runat="server" ValidationGroup="cancel"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBookingRefNo"
                                Display="None" ErrorMessage="Please enter reference number." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceRefNo" TargetControlID="RequiredFieldValidator2" runat="server"></ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            Email Id:
                        </td>
                        <td width="60%">
                            <asp:TextBox ID="txtHotelEmailId" runat="server" ValidationGroup="cancel"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmailId"
                                Display="None" ErrorMessage="Please enter email id." ValidationGroup="cancel"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceEmailid" runat="server" TargetControlID="RequiredFieldValidator5"></ajax:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmailId"
                                Display="None" ErrorMessage="Please enter valid email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="cancel"></asp:RegularExpressionValidator>
                            <ajax:ValidatorCalloutExtender ID="vceEmail1" TargetControlID="RegularExpressionValidator3" runat="server"></ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;
                        </td>
                        <td width="60%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;
                        </td>
                        <td width="60%">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                ValidationGroup="cancel"  CssClass="buttonBook"/>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>

