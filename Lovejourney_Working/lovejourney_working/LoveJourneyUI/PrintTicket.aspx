<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrintTicket.aspx.cs" Inherits="PrintTicket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/NewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<table width="100%" cellpadding="0" cellspacing="0" border="0">
     <tr>
       <td height="520" valign="top">
    <table width="100%">
     <tr>
                        <td height="2px">
                            &nbsp;
                        </td>
                    </tr>

        <tr>
            <td align="center">
                <table width="990" border="0" cellspacing="0" cellpadding="0">
                  
                    

                     

                    <tr>
                        <td align="center">
                            <asp:Label ID="lblMainMSg" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" >
                            <asp:Panel ID="Panel1" Width="501" runat="server" >
                                
                                <table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="images/formtop_left.png" /></td>
    <td class="form_top" width="347"></td>
    <td align="left" valign="bottom" width="29" height="23"><img src="images/formright_top.png" /></td>
  </tr>


  <tr>
    <td class="form_left"></td>
    <td width="347" align="left" valign="top" bgcolor="#ffffff" >
    
    <table width="347" cellpadding="0" cellspacing="0" border="0">
     <tr>
                                    <td valign="top" height="20" align="left">
                                       <table width="347" height="45" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50"><img src="images/print_t.png" width="37" height="37" /></td>
    <td align="center" valign="middle" class="online_booking">Print Ticket</td>
  </tr>
</table>
                                    </td>
                                </tr>


       <tr>
           <td height="12" colspan="2" class="border_top">
                  &nbsp;</td>
        </tr>
        <tr>
                            <td colspan="2"  align="center">
                                <asp:Label ID="lblMsg" runat="server" />
                            </td>
                        </tr>

     
     <tr>
                                <td align="center" >
                                <table width="300" cellpadding="0" cellspacing="0" border="0" >
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                        Type
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:DropDownList ID="ddlType" runat="server" ValidationGroup="signin" 
                                            CssClass="lj_inp" >
                                         <asp:ListItem>--Please select--</asp:ListItem>
                                          <asp:ListItem>Bus</asp:ListItem>
                                           <asp:ListItem>Flight</asp:ListItem>
                                           <asp:ListItem>Hotel</asp:ListItem>
                                             <asp:ListItem>Cabs</asp:ListItem>

                                       </asp:DropDownList>
  <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlType" InitialValue="--Please select--" ErrorMessage="Please select Type" Display="None" ValidationGroup="signin"></asp:RequiredFieldValidator>
                                      <ajax:ValidatorCalloutExtender ID="vceType" runat="server" TargetControlID="rfvType"></ajax:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                               
                                <tr>
                                    <td height="28" align="left" width="100" class="lj_hd12" >
                                         Ref No
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtMBRefNo" MaxLength="50" runat="server" CssClass="lj_inp" 
                                             />
                                                        

                                                        <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Ref No"
                                                            ControlToValidate="txtMBRefNo" Display="None"  runat="server" ValidationGroup="signin" />
                                                        <ajax:ValidatorCalloutExtender ID="vceLuserName" runat="server" TargetControlID="rfvUsername"></ajax:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                                

                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                       <asp:Button ID="btnSignIn" runat="server" Text="Submit" CssClass="buttonBook"
                                                            ValidationGroup="signin" OnClick="btnSignIn_Click" />

                                                        

                                    </td>
                                 </tr>



                                 

                                 

                                

                                

                                

                                 </table>
                                </td>
                                </tr>


   

    </table>
    </td>
    <td class="form_right"></td>
  </tr>



  <tr>
    <td align="center" valign="top" width="24" height="32"><img src="images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="images/formright_bottom.png" /></td>
  </tr>

</table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td width="900" valign="top" align="left" bgcolor="#ffffff">
                            <asp:Panel ID="pnlViewticket" runat="server" Visible="false" Width="900">
                                <table width="900" border="0" align="center" cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td width="900" align="center" >
                                            <table width="900" align="center">
                                                <tr>
                                                    <td width="523" align="left">
                                                        <span class="actions">
                                                            <asp:LinkButton ID="lbtnback" Text="Back" runat="server" OnClick="lbtnback_Click" /></span>
                                                    </td>
                                                    <td width="115" align="right">
                                                        <span class="actions">
                                                            <asp:LinkButton ID="lbtnmail" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
                                                                onclick="printPage('printdiv');" target="_blank">Print</a></span>
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
                                                                            <img src="Newimages/New_Logo.png" width="143" height="88" border="0"
                                                                                title="Love Journey" />&nbsp;&nbsp;
                                                                            <asp:Image ID="imgKesineni" runat="server" ImageUrl="http://lovejourney.in/images/kesineni-Logo.jpg"
                                                                                Width="100" Height="88" Visible="false" />
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
                                                            <td align="left" height="17">
                                                                <b>Note :</b> To initiate your journey, please present your itinerary receipt or
                                                                E-Ticket.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" height="17">
                                                                Waiting list is not a confirmed ticket. Wait listed passengers are requested to
                                                                check for their ticket confirmation with our helpline.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="1" bgcolor="#979595">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gvView" runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                                                AllowSorting="false" PageSize="1" ShowHeader="false" ShowFooter="false" OnRowDataBound="gvView_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                                                        <ItemTemplate>
                                                                                            <table width="900" border="0" cellspacing="0" cellpadding="0" class="ticket_bdr">
                                                                                                <tr>
                                                                                                    <td align="left" height="26" valign="top">
                                                                                                        <b class="man_hd">LoveJourney Reference Number :</b>&nbsp;
                                                                                                        <asp:Label ID="lblManabusRefNo" runat="server" Text='<%#Eval("OnewayMBRefNo") %>' />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td align="left" height="20" width="15%">
                                                                                                                    <b>Journey Date</b>
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <asp:Label ID="lblDOJ" Text='<%#Eval("DateOfJourney") %>' runat="server" />
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <b>Service No</b>
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <asp:Label ID="lblTravelOpPNR" Text='<%#Eval("ServiceNumber") %>' runat="server" />
                                                                                                                </td>
                                                                                                                <td align="left" width="10%">
                                                                                                                    <b>PNR Number</b>
                                                                                                                </td>
                                                                                                                <td width="30%" align="left">
                                                                                                                    <asp:Label ID="lblTicketId" runat="server" Text='<%#Eval("PNRNumber") %>' />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" height="20" width="15%">
                                                                                                                    <b>From </b>
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <asp:Label ID="lblSourceName" runat="server" Text='<%#Eval("SourceName") %>' />
                                                                                                                </td>
                                                                                                                <td align="left" width="15%">
                                                                                                                    <b>To </b>
                                                                                                                </td>
                                                                                                                <td width="15%" align="left">
                                                                                                                    <asp:Label ID="lblDestinationName" runat="server" Text='<%#Eval("DestinationName") %>' />
                                                                                                                </td>
                                                                                                                <td align="left" width="10%">
                                                                                                                    <b>Travels</b>
                                                                                                                </td>
                                                                                                                <td width="30%" align="left">
                                                                                                                    <asp:Label ID="lblTravelName" runat="server" Text='<%#Eval("TravelOPName") %>' />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" height="25">
                                                                                                        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td width="50%">
                                                                                                                    <b>Coach</b>
                                                                                                                    <asp:Label ID="lblBusType" runat="server" Text='<%#Eval("BusType") %>' />
                                                                                                                </td>
                                                                                                                <td width="50%">
                                                                                                                    <b>Boarding Point :</b>
                                                                                                                    <asp:Label ID="lblBordingTime" runat="server" Text='<%#Eval("BoardingPointName") %>' />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" height="25">
                                                                                                        <b>Boarding Point Address :</b>
                                                                                                        <asp:Label ID="lblBoardingPoint" runat="server" Text='<%#Eval("BoardingInfo") %>' />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="1" bgcolor="#000">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td align="left" valign="top">
                                                                                                                    <table border="0" cellspacing="0" cellpadding="0">
                                                                                                                        <tr>
                                                                                                                            <td align="left" height="20">
                                                                                                                                <b class="man_hd">Passenger Details :</b>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left">
                                                                                                                                <asp:Label ID="lblPassengerDetails" runat="server" Text='<%#Eval("PassengerDetails") %>'
                                                                                                                                    BackColor="White"></asp:Label>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                                <td align="center">
                                                                                                                    <table width="580" border="0" cellspacing="0" cellpadding="0">
                                                                                                                        <tr>
                                                                                                                            <td width="82" align="left" height="15">
                                                                                                                                <b>Status</b>
                                                                                                                            </td>
                                                                                                                            <td width="82" align="left">
                                                                                                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("BStatus")%>'></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td width="93" align="left">
                                                                                                                                <b>Contact No</b>
                                                                                                                            </td>
                                                                                                                            <td width="93" align="left">
                                                                                                                                <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo ") %>'></asp:Label>
                                                                                                                                <asp:Label ID="lblEmailID" runat="server" Text='<%#Eval("EmailId ") %>' Visible="false"></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td width="81" align="left">
                                                                                                                                <b>Id Proof</b>
                                                                                                                            </td>
                                                                                                                            <td width="129" align="left">
                                                                                                                                <%#Eval("IDType ")%>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left" height="15">
                                                                                                                                <b>Id Number</b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <%#Eval("IDNumber ")%>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <b>Booked By </b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:Label ID="lblBookedBy" runat="server" Text='<%#Eval("FullName") %>' />
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <b>Booked On</b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("DateOfBooking") %>' />
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td colspan="6">
                                                                                                                                <asp:Panel ID="pnlCancellationDetails" runat="server" Width="100%" Visible="false">
                                                                                                                                    <table width="100%">
                                                                                                                                        <tr>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <strong>Cancelled By</strong>
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <asp:Label ID="lblCancelledBY" runat="server" Text='<%#Eval("cancelledBy") %>' />
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <strong>Cancelled On </strong>
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("CancelledDate") %>' />
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <strong>Cash Coupon Issued</strong>
                                                                                                                                            </td>
                                                                                                                                            <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("CancelCashCoupon") %>' />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                    </table>
                                                                                                                                </asp:Panel>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left" height="15">
                                                                                                                                <b><u>Amount</u></b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("TotalFare") %>' />
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <b><u>Others</u></b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                0.000
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <b><u>Total</u></b>
                                                                                                                            </td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("TotalFare") %>' />
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="8">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="1" bgcolor="#000">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" height="25">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td width="50%">
                                                                                        <b class="man_hd">Cacnellation Policy :</b>
                                                                                    </td>
                                                                                    <td width="50%">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="100%" align="center">
                                                                            <asp:Panel ID="Panel10" runat="server">
                                                                                <asp:GridView ID="gvCancellationDetails" runat="server" AutoGenerateColumns="False"
                                                                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                                                    CellPadding="3" EnableModelValidation="True" Width="100%" EmptyDataText="No cancellation Policy Updated">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Cancellation Time">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblBeforeTime" runat="server" Text='<%# Eval("BeforeTime") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Cancellation Percentage (%)">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPercentage" runat="server" Text='<%# Eval("CancePercentage") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                    <HeaderStyle BackColor="#eeeeee" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                    <RowStyle ForeColor="Black" HorizontalAlign="Left" BackColor="White" />
                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="1" bgcolor="#000">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" height="25">
                                                                           <table id="tblterms" border="0" cellpadding="0" cellspacing="0" style="display: none;">
                                                                                    <tr>
                                                                                        <td align="left" height="25">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="50%">
                                                                                                        <b class="man_hd">Terms & Conditions :</b>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="padding-left: 6px; padding-right: 6px">
                                                                                                        1. Lovejourney.in is ONLY a online ticket booking of buses, flights,hotels and recharge
                                                                                                        . It does not operate travel services of its own. In order to provide a comprehensive
                                                                                                        choice of travel operators, departure times and prices to customers, it has tied
                                                                                                        up with many travel operators.<br />
                                                                                                        lovejourney.in advices customers to choose travel operators they are aware of and
                                                                                                        whose service they are comfortable with.<br />
                                                                                                        <br />
                                                                                                        <span class="Paragraph"><strong>lovejourney.in responsibilities include:</strong></span><br />
                                                                                                        . Issuing a valid ticket (a ticket that will be accepted by the travel operator)
                                                                                                        for its' network of travel operators<br />
                                                                                                        . Providing refund and support in the event of cancellation<br />
                                                                                                        . Providing customer support and information in case of any delays / inconvenience<br />
                                                                                                        <br />
                                                                                                        <span class="Paragraph"><strong>lovejourney.in responsibilities do NOT include:</strong></span><br />
                                                                                                        . The travel operator's bus not departing / reaching on time<br />
                                                                                                        . The travel operator's employees being rude<br />
                                                                                                        . The travel operator's bus seats etc not being up to the customer's expectation<br />
                                                                                                        . The travel operator canceling the trip due to unavoidable reasons<br />
                                                                                                        . The baggage of the customer getting lost / stolen / damaged<br />
                                                                                                        . The travel operator changing a customer's seat at the last minute to accommodate
                                                                                                        a lady / child<br />
                                                                                                        . The customer waiting at the wrong boarding point (please call the bus operator
                                                                                                        to find out the exact boarding point if you are not a regular traveller on that
                                                                                                        particular bus)<br />
                                                                                                        . The travel operator changing the boarding point and/or using a pick-up vehicle
                                                                                                        at the boarding point to take customers to the bus departure point<br />
                                                                                                        2.The departure time mentioned on the ticket are only tentative timings. However
                                                                                                        the bus will not leave the source before the time that is mentioned on the ticket.<br />
                                                                                                        3. Passengers are required to furnish the following at the time of boarding the
                                                                                                        bus:<br />
                                                                                                        A copy of the ticket (A print out of the ticket or the print out of the ticket e-mail).
                                                                                                        <br />
                                                                                                        A valid identity proof
                                                                                                        <br />
                                                                                                        Failing to do so, they may not be allowed to board the bus.<br />
                                                                                                        4. Change of bus: In case the bus operator changes the type of bus due to some reason,
                                                                                                        lovejourney.in will refund the differential amount to the customer upon being intimated
                                                                                                        by the customers in 24 hours of the journey.<br />
                                                                                                        5. This ticket is not cancellable.<br />
                                                                                                        6. In case one needs the refund to be credited back to his/her bank account, please
                                                                                                        write your cash coupon details to info@lovejourney.in<br />
                                                                                                        * The home delivery charges (if any), will not be refunded in the event of ticket
                                                                                                        cancellation<br />
                                                                                                        7. In case a booking confirmation e-mail and sms gets delayed or fails because of
                                                                                                        technical reasons or as a result of incorrect e-mail ID / phone number provided
                                                                                                        by the user etc, a ticket will be considered 'booked' as long as the ticket shows
                                                                                                        up on the confirmation page of www.lovejourney.in<br />
                                                                                                        For any queries call at : 080-32561727,25220265 .<br />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
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

                    <tr>
                    <td width="900" valign="top" align="left" bgcolor="#ffffff">
                      <asp:Panel ID="pnlFlightTicket" runat="server" Visible="false" Width="900">
                                    <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="900" align="center">
                                                <table width="900" align="center">
                                                    <tr>
                                                        <td width="523" align="left">
                                                            <span class="actions">
                                                                <asp:LinkButton ID="LinkButton2" Text="Back" runat="server" OnClick="lbtnback_Click" /></span>
                                                        </td>
                                                        <td width="115" align="right">
                                                            <span class="actions">
                                                                <asp:LinkButton ID="LinkButton3" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;
                                                                <input type="button" value="Print" onclick="printPage('Div1');" />
                                                                <%--<a onclick="printPage('printdiv');" target="_blank">Print</a></span>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="900" align="center">
                                                <asp:Panel ID="Panel3" Width="900" runat="server">
                                                    <div id="Div1" style="float: left;">
                                                        <table width="900" cellspacing="0" cellpadding="0" border="1px solid black;">
                                                            <tr>
                                                                <td>
                                                                    <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td align="left" width="300" height="96" valign="top">
                                                                                <img src="Newimages/New_Logo.png" width="260" height="88" border="0"
                                                                                    title="Love Journey" />&nbsp;&nbsp;
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
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="1" bgcolor="#979595">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" align="left">
                                                                    <table width="100%">
                                                                    <tr>
                                                                    <td  width="40%">
                                                                    <table  width="90%" class="rightborder">

                                                                   
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
                                                                     <td  width="30%" class="rightborder">
                                                
                                                  <asp:Label ID="Label1" runat="server"   Text=" Your Airline PNR :" CssClass="pnrbold"></asp:Label>
                                                            <asp:Label ID="lblAirlinePNR" runat="server"  CssClass="pnrbold"></asp:Label>
                                                </td>
                                                  <td  width="30%" style="padding-left:10px;">
                                                 <table>
                                                 <tr>
                                                 
                                                 <td>
                                                  <img src="../../images/barcode.png" />
                                                 </td>
                                                 </tr>
                                                 
                                                 <tr>
                                                 <td>
                                                   <asp:Label ID="Label2" runat="server" Text="Love Journey Ref NO :" Visible="false"></asp:Label>
                                             
                                                            <asp:Label ID="lblPNR" runat="server"></asp:Label>
                                                 </td>
                                                 </tr>
                                                 </table>
                                               
                                             
                                                </td>
                                                                    </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center">
                                                                   <asp:Label ID="lblEticket" runat="server" Text="Eticket" style="padding-left:200px;" ></asp:Label>
                                                                     <asp:Label ID="lblBookingTimeDate" runat="server" Text="Booking Date:" style="padding-left:200px;"  ></asp:Label>
                                                                    <asp:Label ID="lblBookingTime" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                           <%-- <tr>
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
                                                            </tr>--%>
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
                                                              <tr id="printroundtrip" runat="server" visible="false">
                                                                <td>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblOriginRet" runat="server" Text=""></asp:Label>
                                                                                -
                                                                                <asp:Label ID="lblDestinationRet" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table width="100%" border="1" >
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            Return Airline
                                                                                        </th>
                                                                                        <th align="left">
                                                                                            Return Flight No
                                                                                        </th>
                                                                                        <th colspan="2">
                                                                                            Return Departure Date & Time
                                                                                        </th>
                                                                                        <th colspan="2">
                                                                                            Return Arrival Date & Time
                                                                                        </th>
                                                                                        <%--   <th>
                                                   Return PNR No
                                                </th>--%>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Image ID="img1" runat="server" />
                                                                                            -
                                                                                            <asp:Label ID="lblAirlineNamereturn" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblFlightNumberreturn" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDepartureDatereturn" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDepartureTimereturn" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblArrivalDatereturn" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblArrivalTimereturn" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <%--   <td>
                                                    <asp:Label ID="lblPNRNoreturn" runat="server"></asp:Label>
                                                </td>--%>
                                                                                    </tr>
                                                                                </table>
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
                                                                <asp:LinkButton ID="LinkButton4" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
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

                     <tr>
                     <td valign="top" align="left" bgcolor="#ffffff">
                        <asp:Panel ID="pnlhotelTicket" runat="server" Visible="false">
                    <table border="1" cellspacing="0" rules="all" style="width: 100%; border-collapse: collapse;">
                    <tr>
                     <td width="115" align="right">
                                                            <span class="actions">
                                                                <asp:LinkButton ID="LinkButton5" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
                                                                    onclick="printPage('printdiv');" target="_blank">Print</a></span>
                                                        </td>
                                                        </tr>
                        <tr>
                            <td width="100%">
                                <table width="900" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" width="300" height="96" valign="top">
                                           <img src="Newimages/New_Logo.png" width="260" height="88" border="0"
                                                                                    title="Love Journey" />&nbsp;&nbsp;
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
                                            <asp:Label ID="lblHotelRefNo" runat="server" Text=""></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp; <strong>Ref No: </strong>
                                            <asp:Label ID="lblarzoorefno" runat="server" Text=""></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;<strong>Status: </strong>
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                            <br />
                                            <hr />
                                            <strong><span style="color: Red;">Hotel Details</span></strong>
                                            <table width="100%" id="SelectedHotel" border="0px">
                                                <thead>
                                                    <tr>
                                                        <td width="20%">
                                                            <strong>Hotel Name</strong>
                                                        </td>
                                                        <td width="20%">
                                                            <strong>Address</strong>
                                                        </td>
                                                        <td width="10%">
                                                            <strong>City</strong>
                                                        </td>
                                                        <td width="10%">
                                                            <strong>Check-in</strong>
                                                        </td>
                                                        <td width="10%">
                                                            <strong>Check-out</strong>
                                                        </td>
                                                        <td width="20%">
                                                            <strong>Room Type</strong>
                                                        </td>
                                                        <td width="10%">
                                                            <strong>Category</strong>
                                                        </td>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="20%">
                                                        <asp:Label ID="lblHotelName" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:Label ID="lblHotelCity" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:Label ID="lblCheckIn" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:Label ID="lblCheckOut" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblRoomType" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:Label ID="lblStar" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="7">
                                                        <strong><span>Hotel Contact Details: </span></strong>
                                                        <asp:Label ID="lblHotelContactDetails" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <hr />
                                            <table width="100%" id="TravellerDetails" border="0px">
                                                <tr>
                                                    <td width="100%" colspan="4">
                                                        <strong><span style="color: Red;">Traveller Details</span> </strong>
                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                    <td width="40%">
                                                        <strong>No. of Room(s): </strong>
                                                        <asp:Label ID="lblNoOfRooms" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="15%">
                                                        <strong>Pax > 12 yrs.: </strong>
                                                        <asp:Label ID="lblPaxGreaterThan12" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="15%">
                                                        <strong>Pax <= 12 yrs.: </strong>
                                                        <asp:Label ID="lblPaxLessThan12" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="30%" align="left">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="100%" colspan="4">
                                                        <strong>Total INR:</strong>
                                                        <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="100%" colspan="4">
                                                        <strong><span>Booked Date: </span></strong>
                                                        <asp:Label ID="lblBookedDate" runat="server" Text=""></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <hr />
                                            <strong><span style="color: Red;">User Details</span></strong>
                                            <table width="100%" id="UserDetails" border="0px">
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        Title:
                                                    </td>
                                                    <td width="85%" valign="top" colspan="3">
                                                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        First Name:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        Middle Name:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        Last Name:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                                    </td>
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
                                            <asp:GridView ID="gvPolicy" runat="server" Width="100%" AutoGenerateColumns="false"
                                                HeaderStyle-ForeColor="Red" Visible="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Hotel Policy" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPolicyText" runat="server" Text='<%# Eval("policyText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <hr />
                                            <br />
                                            <div>
                                                <table id="ctl00_ContentPlaceHolder1_gvPolicy" border="1" cellspacing="0" rules="all"
                                                    style="width: 100%; border-collapse: collapse;">
                                                    <tr>
                                                        <th align="left" scope="col" style="color: Red;">
                                                            Policy
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl06_lblPolicyText">You must be 18 to
                                                                check in to this hotel.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl07_lblPolicyText">Your credit card is
                                                                charged the total cost above at time of purchase. Prices and room availability are
                                                                not guaranteed until full payment is received.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl08_lblPolicyText">Failure to check into
                                                                the hotel, will attract the full cost of stay at the hotel being charged to your
                                                                credit card.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl09_lblPolicyText">Changes or cancellation
                                                                may result in fees from INR 0 up to full cost of your stay as per rules</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl10_lblPolicyText">All hotels charge
                                                                a compulsory Gala Dinner Supplement for the Christmas eve and New Year&#39;s eve
                                                                on the stay during respective periods. Besides, other special supplements may be
                                                                applicable during festival periods such as Diwali, Dusshera etc.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl11_lblPolicyText">The charge for the
                                                                same as applicable at the hotel would have to be cleared directly at the hotel.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span id="ctl00_ContentPlaceHolder1_gvPolicy_ctl12_lblPolicyText">We shall not be responsible
                                                                for any such additional charges levied by the hotel other than the room charges.</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <br />
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
                     <td valign="top" align="left" bgcolor="#ffffff">
                        <asp:Panel ID="Panel2" runat="server" Visible="False">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <table width="100%" align="center">
                        <tr>
                            <td width="50%" align="left">
                                
                            </td>
                            <td width="50%" align="right">
                                <span>
                                    <asp:LinkButton ID="lnkCabMail" Text="Mail" runat="server" onclick="lnkCabMail_Click" 
                                     />&nbsp;&nbsp;|&nbsp;&nbsp;
                                     <a onclick="printPage('Div2');" target="_blank">
                                                <input id="Radio1" type="radio" runat="server" />Print </a>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="pnlCabTicket" runat="server">
                        
                            <table border="1" cellspacing="0" rules="all" style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td width="100%">
                            <div id="Div2">
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
                                            <asp:Label ID="lblCabstatus" runat="server" Text=""></asp:Label>
                                            <br />
                                            <hr />
                                            <strong><span style="color: Red;">Car Details</span></strong>
                                            <table width="100%" id="Table1" border="0px">
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
                                                        <asp:Label ID="lblCabAddress1" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblCity1" runat="server" Text=""></asp:Label>
                                                    </td>
                                                     <td width="20%">
                                                        <asp:Label ID="lblJourneyDate" runat="server" Text=""></asp:Label>
                                                    </td>
                                                   
                                                 
                                                </tr>
                                               
                                            </table>
                                            <hr />
                                            
                                            <hr />
                                            <strong><span style="color: Red;">User Details</span></strong>
                                            <table width="100%" id="Table2" border="0px">
                                               
                                                <tr>
                                                    <td width="15%" valign="top">
                                                      Name:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblCabName" runat="server"></asp:Label>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                   
                                                    <td width="15%" valign="top">
                                                        Mobile Number:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        91<asp:Label ID="lblCabMobile" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        Email Id:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblCabEmail" runat="server"></asp:Label>
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
                                                        <asp:Label ID="lblCabAddress" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        City:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblCabCity" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" valign="top">
                                                        State:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblCabState" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="15%" valign="top">
                                                        PinCode:
                                                    </td>
                                                    <td width="35%" valign="top">
                                                        <asp:Label ID="lblCabPincode" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            <hr />
                                            <br />
                                            
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                 </div>
                            </td>
                        </tr>
                    </table>
                       
                    </asp:Panel>
                </asp:Panel>
                     </td>
                     </tr>



                    <tr><td>&nbsp;&nbsp;</td></tr>
                </table>
            </td>
        </tr>
        

        

    </table>
     </td>
    </tr>
    </table>
</asp:Content>
