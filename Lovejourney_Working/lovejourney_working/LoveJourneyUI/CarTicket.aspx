<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CarTicket.aspx.cs" Inherits="CarTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
    function printPage(id) {
        var html = "<html>";
        html += document.getElementById(id).innerHTML;
        html += "</html>";
        var printWin = window.open('', '', 'left=0,top=0,toolbar=0,scrollbars=0,status  =0');
        printWin.document.write(html);
        printWin.document.close();
        printWin.focus();
        printWin.print();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="background-color: White;">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlOptions" Visible="true" runat="server">
                                <table width="900" align="center">
                                    <tr>
                                        <td width="623">
                                            <span class="actions"></span>
                                        </td>
                                        <td width="165" align="right">
                                            <span>
                                                <%--<asp:LinkButton ID="lbtnCancel" Text="Cancel" runat="server" OnClick="lbtnCancel_Click" />--%>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton
                                                        ID="lbtnmail" Text="Mail" runat="server" 
                                                onclick="lbtnmail_Click"  />&nbsp;&nbsp;|&nbsp;&nbsp;<a
                                                            onclick="printPage('prntTicket');" target="_blank">Print</a></span>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnlTicket" runat="server">
                 <div id="prntTicket">
                    <table border="1" cellspacing="0" rules="all" style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td width="100%">
                                <table width="900" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" width="300" height="96" valign="top">
                                            <img alt="imag" src="http://Lovejourney.in/Newimages/New_Logo.png" width="243" height="88"
                                                border="0" title="LJ" />&nbsp;&nbsp;
                                        </td>
                                        <td align="right">
                                            <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="40" align="left">
                                                        <img src="http://www.lovejourney.in/images/call.jpg" width="30" height="30" />
                                                    </td>
                                                    <td align="left">
                                                        <b>(080) 32 56 17 27</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="40" align="left">
                                                        <img src="http://www.lovejourney.in/images/messenge.jpg" width="30" height="30" />
                                                    </td>
                                                    <td align="left">
                                                        <a href="#">info@lovejourney.in</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0px">
                                    <tr>
                                        <td width="100%">
                                            <hr />
                                            <strong>Lovejourney Ref No: </strong>
                                            <asp:Label ID="lblCarRefNo" runat="server" Text=""></asp:Label>
                                          
                                            &nbsp;&nbsp;&nbsp;&nbsp;<strong>Status: </strong>
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                            <br />
                                            <hr />
                                            <strong><span style="color: Red;">Car Details</span></strong>
                                            <table width="100%" id="SelectedHotel" border="0px">
                                                <thead>
                                                    <tr>
                                                        <td width="20%">
                                                            <strong>Car Name</strong>
                                                        </td>
                                                         <td width="20%">
                                                            <strong>Pickup Time</strong>
                                                        </td>
                                                        <td width="20%">
                                                            <strong>Address</strong>
                                                        </td>
                                                        <td width="10%">
                                                            <strong>City</strong>
                                                        </td>
                                                        <td width="10%">
                                                            <strong>Journey Date</strong>
                                                        </td>
                                                      <td width="10%">
                                                            <strong>Fare</strong>
                                                        </td>
                                                       
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="20%">
                                                        <asp:Label ID="lblCarName" runat="server" Text=""></asp:Label>
                                                    </td>
                                                     <td width="20%">
                                                        <asp:Label ID="lblPickupTime" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblCity1" runat="server" Text=""></asp:Label>
                                                    </td>
                                                     <td width="20%">
                                                        <asp:Label ID="lblJourneyDate" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblTotalFare" runat="server" Text=""></asp:Label>
                                                    </td>
                                                   
                                                 
                                                </tr>
                                               
                                            </table>
                                            <hr />
                                            
                                            <hr />
                                            <strong><span style="color: Red;">User Details</span></strong>
                                            <table width="100%" id="UserDetails" border="0px">
                                               
                                                <tr>
                                                    <td width="15%" valign="top">
                                                      Name:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                   
                                                    <td width="15%" valign="top">
                                                        Mobile Number:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        91<asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        Email Id:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        &nbsp;
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        Address:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblAdd" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        City:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        State:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblState" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        PinCode:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblPinCode" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            <hr />
                                            <br />
                                            
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

