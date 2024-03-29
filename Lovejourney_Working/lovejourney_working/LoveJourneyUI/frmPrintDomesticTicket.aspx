﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPrintDomesticTicket.aspx.cs"
    Inherits="frmPrintDomesticTicket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LoveJourney - Print Ticket</title>
    <link href="css/love_ journey.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function printPage(id) {

            var html = "<html>";

            html += document.getElementById(id).innerHTML;
            html += "</html>";
            alert(html);
            var printWin = window.open('', '', 'left=0,top=0,toolbar=0,scrollbars=0,status  =0');
            printWin.document.write(html);
            printWin.document.close();
            printWin.focus();
            printWin.print();
            //printWin.close();

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <table width="964" border="0" class="container">
        <tr>
            <td align="left" valign="top">
                <table width="964" border="0" height="82" class="header">
                    <tr>
                        <td align="left" valign="top" class="logo">
                            <a href="Default.aspx">
                                <img src="images/logo.gif" border="0" /></a>
                        </td>
                        <td align="left" valign="top">
                            <table width="729" border="0">
                                <tr>
                                    <td width="729" height="41" align="left" valign="top">
                                        <table width="729" height="41" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="318" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td width="30" align="center" valign="middle">
                                                    <div class="call">
                                                        <img src="images/call.jpg" border="0" /></div>
                                                </td>
                                                <td width="122" align="left" valign="top">
                                                    <p>
                                                        For Reservation Queries <span style="font-size: 13px; font-weight: bold;">(080) 32 56
                                                            17 27</span></p>
                                                </td>
                                                <td width="23" align="center" valign="middle">
                                                    <div class="message">
                                                        <img src="images/messenge.jpg" border="0" /></div>
                                                </td>
                                                <td width="103" align="left" valign="top">
                                                    <p>
                                                        For Email Queries <span style="font-size: 13px; font-weight: bold;">info@lovejourney.in</span></p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="729" height="41" align="right" valign="middle" class="menu">
                                        <ul>
                                            <li><a href="Default.aspx">Home</a></li>
                                            <li><a href="PrintTicket.aspx">Print Ticket</a></li>
                                            <li><a href="frmDomesticFlightCancel.aspx">Cancellation</a></li>
                                            <li><a href="Testimonial.aspx">Testimonial</a></li>
                                            <li><a href="BecomeAnAgent.aspx">Become An Agent</a></li>
                                            <li><a href="Login.aspx" style="border-right: none;">Login</a></li>
                                        </ul>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="964">
                <table width="964" style="border-bottom: 1px solid #669999;">
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div>
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="900" border="0" cellspacing="0" cellpadding="0">
                                   <tr>
                                                        <td align="center" bgcolor="#0062af" style="color: White">
                                                            &nbsp;&nbsp; Print Ticket
                                                        </td>
                                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblMainMSg" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="center">
                                            <asp:Panel ID="Panel1" Width="501" runat="server" DefaultButton="btnSignIn">
                                                <table width="501" cellspacing="0" cellpadding="0" align="center" style="background-color: White;">
                                                   
                                                    <tr>
                                                        <td height="20" align="center">
                                                            <asp:Label ID="lblMsg" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table width="400" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="50%" align="right">
                                                                        Reference No&nbsp;&nbsp;<span style="color: Red;">*</span>&nbsp;:&nbsp;
                                                                    </td>
                                                                    <td align="left" height="34" width="60%">
                                                                        <asp:TextBox ID="txtRefNo" MaxLength="50" runat="server" CssClass="textfield_sleep" />
                                                                        <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Reference No" ControlToValidate="txtRefNo"
                                                                            Display="None" runat="server" ValidationGroup="signin" />
                                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvUsername"
                                                                            WarningIconImageUrl="~/images/icon-warning.png" CloseImageUrl="~/images/icon-close4.png"
                                                                            CssClass="CustomValidatorCalloutStyle" PopupPosition="Right">
                                                                        </ajax:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" width="40%" class="p_nme">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="60%">
                                                                        <asp:Button ID="btnSignIn" runat="server" Text="Submit" CssClass="buttonBook"
                                                                            ValidationGroup="signin" OnClick="btnSignIn_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="900" valign="top" align="left">
                                            <asp:Panel ID="pnlViewticket" runat="server" Visible="false" Width="900">
                                                <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="900" align="center">
                                                            <table width="900" align="center">
                                                                <tr>
                                                                    <td width="523" align="left">
                                                                        <span class="actions">
                                                                            <asp:LinkButton ID="lbtnback" Text="Back" runat="server" OnClick="lbtnback_Click" /></span>
                                                                    </td>
                                                                    <td width="115" align="right">
                                                                        <span class="actions">
                                                                            <asp:LinkButton ID="lbtnmail" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;
                                                                            <input type="button" value="Print" onclick="printPage('printdiv');" class="buttonBook"/>
                                                                            <%--<a onclick="printPage('printdiv');" target="_blank">Print</a></span>--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="900" align="center">
                                                            <asp:Panel ID="pnlmail" Width="900" runat="server">
                                                                <div id="printdiv" style="float: left;">
                                                                    <table width="900" cellspacing="0" cellpadding="0" border="1px solid black;">
                                                                        <tr>
                                                                            <td>
                                                                                <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td align="left" width="300" height="96" valign="top">
                                                                                            <img src="http://lovejourney.in/images/logo.gif" width="143" height="88" border="0"
                                                                                                title="Love Journey" />&nbsp;&nbsp;
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td width="40" align="left">
                                                                                                        <img src="http://lovejourney.in/images/call.jpg" width="30" height="30" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <b>(080) 32 56 17 27</b>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="40" align="left">
                                                                                                        <img src="http://lovejourney.in/images/messenge.jpg" width="30" height="30" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <a href="#">info@lovejourney.in</a>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="1" bgcolor="#979595">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" align="left">
                                                                                <table width="50%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            Name :
                                                                                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Tel :
                                                                                            <asp:Label ID="lblTel" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                        <%--  <td>
                                                                                Mobile No :
                                                                                <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
                                                                            </td>--%>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Email ID :
                                                                                            <asp:Label ID="lblEmailAddress" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td align="center">
                                                                                Eticket
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table width="100%" style="border: 1px solid; border-color: Blue">
                                                                                    <tr>
                                                                                        <td>
                                                                                            Your Airline PNR :
                                                                                            <asp:Label ID="lblPNR" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblOrigin" runat="server" Text=""></asp:Label>
                                                                                -
                                                                                <asp:Label ID="lblDestination" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table width="100%" border="1" style="border-color: Blue">
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            Airline
                                                                                        </th>
                                                                                        <th align="left">
                                                                                            Flight No
                                                                                        </th>
                                                                                        <th colspan="2">
                                                                                            Departure Date & Time
                                                                                        </th>
                                                                                        <th colspan="2">
                                                                                            Arrival Date & Time
                                                                                        </th>
                                                                                        <th>
                                                                                            PNR No
                                                                                        </th>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Image ID="img" runat="server" />
                                                                                            -
                                                                                            <asp:Label ID="lblAirlineName" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblFlightNumber" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDepartureDate" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDepartureTime" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblArrivalDate" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblArrivalTime" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblPNRNo" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Ticket Details
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView Width="100%" ID="gdvPassengerDetails" runat="server" AutoGenerateColumns="false">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Sr No.">
                                                                                            <ItemTemplate>
                                                                                                <%# Container.DataItemIndex + 1 %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Passenger Name(s).">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPassengername" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <%--<asp:TemplateField HeaderText="E-ticket No.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblEticketNo" runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>--%>
                                                                                        <asp:TemplateField HeaderText="Passenger Type">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPassengerType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Age">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Passenger. Mobile :
                                                                                <asp:Label ID="lblPsngrMobileNo" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Fare Details :
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <table border="1" width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            Passenger Type :
                                                                                            <asp:Label ID="lblPassengerType" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            Passenger Count :
                                                                                            <asp:Label ID="lblPassengerCnt" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            Basic Fare :
                                                                                            <asp:Label ID="lblBasicFare" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            Taxes :
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblTaxes" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            Service Tax & Fees :
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblServiceTax" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            Total :
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="color: Red">
                                                                                <p>
                                                                                    * Passenger is requested to check-in 2hrs prior to scheduled depature (flights departing
                                                                                    from international terminal check-in 3 hrs. prior to scheduled departure).
                                                                                </p>
                                                                                <p>
                                                                                    * All Passengers including children and infants, must present valid identity proof
                                                                                    ( Passport / Pan Card / election card or any photo identity proof ) at check-in.
                                                                                    It is your responsibility to ensure you have the appropriate travel documents at
                                                                                    all times.
                                                                                </p>
                                                                                <p>
                                                                                    * Changes/Cancellations to booking must be made at least 5 hours prior to scheduled
                                                                                    departure time or else should be cancelled directly from the respective airlines.</p>
                                                                                <p>
                                                                                    &nbsp;* If any flight is cancelled or rescheduled by the airline authority, passenger
                                                                                    is requested to get a stamped/endorsed copy of the ticket to process the refund.
                                                                                </p>
                                                                                <p>
                                                                                    * Passenger travelling from Delhi on Indigo and Spice Jet will have to check-in
                                                                                    at new Terminal 1D.
                                                                                </p>
                                                                                <p>
                                                                                    * Passenger travelling on Air India Express from Delhi and Mumbai, will have to
                                                                                    check-in at International Airport.
                                                                                </p>
                                                                                <p>
                                                                                    * As per Government guidelines, check-in counters at all Airports will now close
                                                                                    45 minutes before departure with immediate effect. Passengers are informed to plan
                                                                                    their Airport arrival accordingly.
                                                                                </p>
                                                                                <p>
                                                                                    * From the midnight of 10th November 2010 (i.e. 0000 hrs of 11th November 2010),all
                                                                                    domestic and international arrivals/departures will be from T3, IGI Airport, Delhi.
                                                                                </p>
                                                                            </td>
                                                                        </tr>
                                                                        <%--       <tr>
                                                                <td>
                                                                    <asp:GridView ID="gdvFareDetails" runat="server" AutoGenerateColumns="false">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <table style="border: 1px">
                                                                                        <tr>
                                                                                            <td>
                                                                                                Passenger Type :
                                                                                                <asp:Label ID="lblPassengerType" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                Passenger Count :
                                                                                                <asp:Label ID="lblPassengerCnt" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                Basic Fare :
                                                                                                <asp:Label ID="lblBasicFare" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td>
                                                                                                Taxes :
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblTaxes" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td>
                                                                                                Service Tax & Fees :
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblServiceTax" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td>
                                                                                                Total :
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>--%>
                                                                    </table>
                                                                </div>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="900" align="center">
                                                            <table width="900" align="center">
                                                                <tr>
                                                                    <td width="523">
                                                                    </td>
                                                                    <td width="115" align="right">
                                                                        <span class="actions">
                                                                            <asp:LinkButton ID="LinkButton1" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
                                                                                onclick="printPage('printdiv');" target="_blank">Print</a></span>
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
                </div>
            </td>
        </tr>
        <tr>
            <td width="964" height="30" align="left" valign="top">
                <table width="964" style="border-bottom: 1px solid #669999;">
                    <tr>
                        <td width="260" height="30" align="center" valign="middle" class="footer-menu">
                            <ul>
                                <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                                <li><a href="TermsAndConditions.aspx">Terms and Conditions</a></li>
                            </ul>
                        </td>
                        <td width="390" height="30" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td width="314" height="30" align="center" valign="middle">
                            <p>
                                Copyright @ All Rights Reserved By LoveJourney.in</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="964" height="28" align="left" valign="top">
                <table width="964" border="0" height="28">
                    <tr>
                        <td width="499" height="28" align="left" valign="top">
                            <div class="image1">
                                <a href="#">
                                    <img src="images/1.jpg" border="0" /></a></div>
                            <div class="image2">
                                <a href="#">
                                    <img src="images/2.jpg" border="0" /></a></div>
                            <div class="image3">
                                <a href="#">
                                    <img src="images/3.jpg" border="0" /></div>
                            <div class="image4">
                                <a href="#">
                                    <img src="images/4.jpg" border="0" /></a></div>
                            <div class="image5">
                                <a href="#">
                                    <img src="images/5.jpg" border="0" /></a></div>
                            <div class="image6">
                                <a href="#">
                                    <img src="images/6.jpg" border="0" /></a></div>
                            <div class="image7">
                                <a href="#">
                                    <img src="images/7.jpg" border="0" /></a></div>
                        </td>
                        <td width="235" height="28" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td width="230" height="28" align="left" valign="top">
                            <div class="facebook">
                                <a href="#">
                                    <img src="images/facebook.gif" border="0" /></a></div>
                            <div class="twitter">
                                <a href="#">
                                    <img src="images/twitter.gif" border="0" /></a></div>
                            <div class="in">
                                <a href="#">
                                    <img src="images/in.gif" border="0" /></a></div>
                            <div class="google-plus">
                                <a href="#">
                                    <img src="images/g+.gif" border="0" /></a></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="964" align="center" valign="bottom" class="footer-nviation">
                <ul>
                    <li><a href="Default.aspx">Home  <li><a href="ContactUs.aspx">Contact US</a></li>
                </ul>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
