<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrintTicket.aspx.cs" Inherits="Users_PrintTicket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function showDiv1() {
            Page_ClientValidate("signin");
            if (Page_ClientValidate("signin")) {
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "../images/loading.gif"', 200);
            }
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<table width="100%" cellpadding="0" cellspacing="0" border="0">
 <tr>
   <td height="450" valign="top">
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="Label7" runat="server" ForeColor="Maroon" Text="No permission to this page. Please contact Administrator for further details."></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlMain" runat="server">
        <table width="900" border="0" cellspacing="0" cellpadding="0">
           
                 
           
            <tr>
                <td valign="top" align="left">
                    <asp:Panel ID="Panel1" Width="501" runat="server" DefaultButton="btnSignIn">
                        <%--<table width="501" cellspacing="0" cellpadding="0" align="center" style="background-color: White;">
                            <tr>
                                <td colspan="2" height="20" align="center">
                                    <asp:Label ID="Label1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <table width="400" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="50%" align="right">
                                                LoveJourney Ref No&nbsp;&nbsp;&nbsp;:&nbsp;
                                            </td>
                                            <td align="left" height="34" width="60%">
                                                <asp:TextBox ID="txtMBRefNo" MaxLength="50" runat="server" CssClass="textfield_sleep" />
                                                <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Ref No" ControlToValidate="txtMBRefNo"
                                                    Display="None" runat="server" ValidationGroup="signin" />
                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvUsername"
                                                    
                                                     >
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="40%" class="p_nme">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="60%">
                                                <asp:Button ID="btnSignIn" runat="server" Text="Search" CssClass="buttonBook"
                                                    ValidationGroup="signin" OnClick="btnSignIn_Click" OnClientClick="showDiv1();" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="20">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="20">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>--%>
                        <table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="24" height="23"><img src="../../images/formtop_left.png" /></td>
    <td class="form_top" width="347"></td>
    <td align="left" valign="bottom" width="29" height="23"><img src="../../images/formright_top.png" /></td>
  </tr>


  <tr>
    <td class="form_left"></td>
    <td width="347" align="left" valign="top" bgcolor="#ffffff" >
    
    <table width="347" cellpadding="0" cellspacing="0" border="0">
     <tr>
                                    <td valign="top" height="20" align="left">
                                       <table width="347" height="45" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50"><img src="../../images/print_t.png" width="37" height="37" /></td>
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
                                        LoveJourney Ref No
                                    </td>
                                    <td width="5%" height="28" align="center" class="ft01">
                                        :
                                    </td>
                                    <td height="28" align="left">
                                       <asp:TextBox ID="txtMBRefNo" MaxLength="50" runat="server" CssClass="lj_inp" />
                                                        

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



                                 
                                  <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblMainMSg" runat="server" />
                 
                                    <asp:Label ID="Label1" runat="server" />
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
    <td align="center" valign="top" width="24" height="32"><img src="../../images/formbottom_left.png" /></td>
    <td class="form_bottom" width="347"></td>
    <td align="left" valign="top" width="29" height="32"><img src="../../images/formright_bottom.png" /></td>
  </tr>

</table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="900" valign="top" align="center" bgcolor="#ffffff">
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
                                                                    <img src="../../Newimages/New_Logo.png" width="226" height="79" border="0"
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
                                                                                                            <b>Operator PNR</b>
                                                                                                        </td>
                                                                                                        <td width="15%" align="left">
                                                                                                            <asp:Label ID="lblTravelOpPNR" Text='<%# Eval("PNRTicketIDs") %>' runat="server" />
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
                                                                                                 
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                               <td width="50%">
                                                                                                            <b>Boarding Point :</b>
                                                                                                            <asp:Label ID="lblBordingTime" runat="server" Text='<%#Eval("BoardingPointName") %>' />
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
                                                                <td>
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
        </table>
    </asp:Panel>
    </td>
    </tr>
    </table>
</asp:Content>
