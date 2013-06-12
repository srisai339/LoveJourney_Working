<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Hotel/MasterPage.master"
    AutoEventWireup="true" CodeFile="PrintTicket.aspx.cs" Inherits="Agent_Hotel_PrintTicket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlMain" runat="server">
        <table width="100%" height="420" valign="top">
            
         
            <tr>
                <td align="left" valign="top">
                    <%--<asp:Panel ID="pnl" runat="server">
                    <table width="100%">
                        <tr>
                            <td width="40%" align="right">
                                &nbsp;
                            </td>
                            <td width="60%" align="left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="40%">
                                Booking Ref No:
                            </td>
                            <td align="left" width="60%">
                                <asp:TextBox ID="txtRefNo" runat="server" ValidationGroup="submit"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRefNo"
                                    Display="Dynamic" ErrorMessage="Please enter ref no." ValidationGroup="submit"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="40%">
                                &nbsp;
                            </td>
                            <td align="left" width="60%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="40%">
                                &nbsp;
                            </td>
                            <td align="left" width="60%">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                    CssClass="buttonBook" ValidationGroup="submit" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>--%>

                   <asp:Panel ID="pnl" runat="server">
                    <%--<table width="100%">
                        <tr>
                            <td width="40%" align="right">
                                &nbsp;
                            </td>
                            <td width="60%" align="left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="40%">
                                Booking Ref No:
                            </td>
                            <td align="left" width="60%">
                                <asp:TextBox ID="txtRefNo" runat="server" ValidationGroup="submit"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRefNo"
                                    Display="Dynamic" ErrorMessage="Please enter ref no." ValidationGroup="submit"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="40%">
                                &nbsp;
                            </td>
                            <td align="left" width="60%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="40%">
                                &nbsp;
                            </td>
                            <td align="left" width="60%">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                    CssClass="buttonBook" ValidationGroup="submit" />
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
                                <asp:Label ID="Label1" runat="server" />
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
                                      <asp:TextBox ID="txtRefNo" runat="server" ValidationGroup="submit"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRefNo"
                                    Display="Dynamic" ErrorMessage="Please enter ref no." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                

                                 
                                 <tr>
                                 
                                 


                                    <td  height="40"  valign="middle"  align="center" colspan="3">
                                       <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                    CssClass="buttonBook" ValidationGroup="submit" />
                                                        

                                    </td>
                                 </tr>


                                    <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
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
                <td style="background-color:White;">
                    <asp:Panel ID="pnlViewTicket" runat="server" Visible="False">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <table width="100%" align="center">
                        <tr>
                            <td width="50%" align="left">
                                <asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click">Back</asp:LinkButton>
                            </td>
                            <td width="50%" align="right">
                                <span>
                                    <asp:LinkButton ID="lbtnMail" Text="Mail" runat="server" OnClick="lbtnMail_Click" />&nbsp;&nbsp;|&nbsp;&nbsp;
                                    <a onclick="printPage('printdiv');" target="_blank">Print</a></span>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="pnlTicket" runat="server">
                        <div id="printdiv">
                            <table border="1" cellspacing="0" rules="all" style="width: 100%; border-collapse: collapse;">
                                <tr>
                                    <td width="100%">
                                        <table width="900" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="left" width="300" height="96" valign="top">
                                                    <img alt="imag" src="http://www.lovejourney.in/images/logo.gif" width="143" height="88"
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
                        </div>
                    </asp:Panel>
                </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
