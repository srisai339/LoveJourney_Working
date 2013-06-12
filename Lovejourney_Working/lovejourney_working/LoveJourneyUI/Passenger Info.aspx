<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Passenger Info.aspx.cs" Inherits="Passenger_Info" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
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
    <table style="vertical-align:middle;width: 1000px;">

    <tr >
    <td width="700px"  style="font-family:Arial;font-weight:bold;font-size:17;" align="center">
      <h3><asp:Label ID="lblText" runat="server"></asp:Label></h3>
      </td>
    <td align="center"
   ></td>
    </tr>
    <tr><td colspan="2"><asp:Label ID="lblMsg1" runat="server"  style="color:Red;"></asp:Label></td></tr>
    
    <tr>
   <td align="center" width="700px">
  
     <table style="width:600px; border:1px solid #013ADF;">
   <tr style="background-color:#0062af;font-family:Arial;font-weight:bold;font-size:16;color:White;height:40px;">
   <td colspan="3" align="center">Passenger Details</td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:TextBox ID="txtName" runat="server" ValidationGroup="Submit" CssClass="lj_inp"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RFVName" runat="server" ControlToValidate="txtName" Display="None" ErrorMessage="Please enter your name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender id="VCEName" runat="server" TargetControlID="RFVName"></ajax:ValidatorCalloutExtender>
   <ajax:FilteredTextBoxExtender ID="FTEName" runat="server" TargetControlID = "txtName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
   </td>
   </tr>
   
   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340" style="color:#2E64FE;">
   <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" ValidationGroup="Submit" CssClass="lj_inp" Width="160"></asp:TextBox>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:TextBox ID="txtCity" runat="server" MaxLength="100" ValidationGroup="Submit" CssClass="lj_inp"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RFVCity" runat="server" ControlToValidate="txtCity" Display="None" ErrorMessage="Please Enter City Name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender ID="VCECity" TargetControlID="RFVCity" runat="server"></ajax:ValidatorCalloutExtender>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   
   <asp:DropDownList ID="DDLState" runat="server" ValidationGroup="Submit" CssClass="lj_inp" Width="170" >
                                                                                <asp:ListItem>Please Select</asp:ListItem>
                                                                                <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                                                                                <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Assam</asp:ListItem>
                                                                                <asp:ListItem>Bihar</asp:ListItem>
                                                                                <asp:ListItem>Chandigarh</asp:ListItem>
                                                                                <asp:ListItem>Chattisgarh</asp:ListItem>
                                                                                <asp:ListItem>Dadra and Nagar Haveli</asp:ListItem>
                                                                                <asp:ListItem>Daman and Diu</asp:ListItem>
                                                                                <asp:ListItem>Delhi</asp:ListItem>
                                                                                <asp:ListItem>Goa</asp:ListItem>
                                                                                <asp:ListItem>Gujarat</asp:ListItem>
                                                                                <asp:ListItem>Haryana</asp:ListItem>
                                                                                <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                                                                <asp:ListItem>Jharkhand</asp:ListItem>
                                                                                <asp:ListItem>Karnataka</asp:ListItem>
                                                                                <asp:ListItem>Kerala</asp:ListItem>
                                                                                <asp:ListItem>Lakshadweep</asp:ListItem>
                                                                                <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Maharashtra</asp:ListItem>
                                                                                <asp:ListItem>Manipur</asp:ListItem>
                                                                                <asp:ListItem>Meghalaya</asp:ListItem>
                                                                                <asp:ListItem>Mizoram</asp:ListItem>
                                                                                <asp:ListItem>Nagaland</asp:ListItem>
                                                                                <asp:ListItem>Orissa</asp:ListItem>
                                                                                <asp:ListItem>Puducherry</asp:ListItem>
                                                                                <asp:ListItem>Punjab</asp:ListItem>
                                                                                <asp:ListItem>Rajasthan</asp:ListItem>
                                                                                <asp:ListItem>Sikkim</asp:ListItem>
                                                                                <asp:ListItem>Tamil Nadu</asp:ListItem>
                                                                                <asp:ListItem>Tripura</asp:ListItem>
                                                                                <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                                                                <asp:ListItem>Uttarakhand</asp:ListItem>
                                                                                <asp:ListItem>West Bengal</asp:ListItem>
                                                                            </asp:DropDownList>
   <asp:RequiredFieldValidator ID="RFVState" runat="server" ControlToValidate="DDLState" Display="None" ErrorMessage="Please Select State." InitialValue="Please Select" ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender ID="VCEState" runat="server" TargetControlID="RFVState"></ajax:ValidatorCalloutExtender>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblZipCode" runat="server" Text="Zip Code"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:TextBox ID="txtZipCode" runat="server" CssClass="lj_inp"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RFVZipCode" runat="server" ControlToValidate="txtZipCode" Display="None" ErrorMessage="Please Enter Zip Code." ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender ID="VCEZipCode" runat="server" TargetControlID="RFVZipCode"></ajax:ValidatorCalloutExtender>
   <ajax:FilteredTextBoxExtender ID="FTEZipCode" runat="server" TargetControlID="txtZipCode" ValidChars="1234567890"></ajax:FilteredTextBoxExtender>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:TextBox ID="txtCountry" runat="server" ValidationGroup="Submit" CssClass="lj_inp"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RFVCountry" runat="server" ControlToValidate="txtCountry" Display="None" ErrorMessage="Please Enter Your Country." ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender id="VCECountry" runat="server" TargetControlID="RFVCountry"></ajax:ValidatorCalloutExtender>
   <ajax:FilteredTextBoxExtender ID="FTECountry" runat="server" TargetControlID = "txtCountry" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblEMailId" runat="server" Text="E-Mail Id"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:TextBox ID="txtEMailId" runat="server" ValidationGroup="Submit" CssClass="lj_inp"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RFVEMailId" runat="server" ControlToValidate="txtEMailId" Display="None" ErrorMessage="Please enter your email id." ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender ID="VCEEMailId" runat="server" TargetControlID="RFVEMailId"></ajax:ValidatorCalloutExtender>
   <asp:RegularExpressionValidator ID="REVEMailId" runat="server" ControlToValidate="txtEMailId" Display="Dynamic" ErrorMessage="Please enter correct email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Submit"></asp:RegularExpressionValidator>
   <ajax:ValidatorCalloutExtender ID="VCEEmailid2" runat="server" TargetControlID="REVEMailId"></ajax:ValidatorCalloutExtender>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:TextBox ID="txtMobileNo" runat="server" ValidationGroup="Submit" CssClass="lj_inp"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RFVMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Please Enter Mobile No." ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender ID="VCEMobileNo" runat="server" TargetControlID="RFVMobileNo"></ajax:ValidatorCalloutExtender>
   <asp:RegularExpressionValidator ID="REVMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Please Enter Valid Mobile No." ValidationGroup="Submit" ValidationExpression="[7-9][0-9]{9}"></asp:RegularExpressionValidator>
   <ajax:ValidatorCalloutExtender ID="VCEMobileNo2" runat="server" TargetControlID="REVMobileNo"></ajax:ValidatorCalloutExtender>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblLandMark" runat="server" Text="Land Mark"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:TextBox ID="txtLandMark" runat="server" ValidationGroup="Submit" CssClass="lj_inp"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RFVLandMark" runat="server" ControlToValidate="txtLandMark" Display="None" ErrorMessage="Please Enter LandMArk." ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender ID="VCELandMark" runat="server" TargetControlID="RFVLandMark"></ajax:ValidatorCalloutExtender>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;" height="60px">
   <asp:Label ID="lblPickUpTime" runat="server" Text="Pick-Up Time"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   
   <asp:DropDownList ID="DDLPickUpTime" runat="server" ValidationGroup="Submit" CssClass="lj_inp" Width="170" >
                                                                                <asp:ListItem>Please Select</asp:ListItem>
                                                                                <asp:ListItem>12:00 AM</asp:ListItem>
                                                                                <asp:ListItem>12:15 AM</asp:ListItem>
                                                                                <asp:ListItem>12:30 AM</asp:ListItem>
                                                                                <asp:ListItem>12:45 AM</asp:ListItem>
                                                                                <asp:ListItem>1:00 AM</asp:ListItem>
                                                                                <asp:ListItem>1:15 AM</asp:ListItem>
                                                                                <asp:ListItem>1:30 AM</asp:ListItem>
                                                                                <asp:ListItem>1:45 AM</asp:ListItem>
                                                                                <asp:ListItem>2:00 AM</asp:ListItem>
                                                                                <asp:ListItem>2:15 AM</asp:ListItem>
                                                                                <asp:ListItem>2:30 AM</asp:ListItem>
                                                                                <asp:ListItem>2:45 AM</asp:ListItem>
                                                                                <asp:ListItem>3:00 AM</asp:ListItem>
                                                                                <asp:ListItem>3:15 AM</asp:ListItem>
                                                                                <asp:ListItem>3:30 AM</asp:ListItem>
                                                                                <asp:ListItem>3:45 AM</asp:ListItem>
                                                                                <asp:ListItem>4:00 AM</asp:ListItem>
                                                                                <asp:ListItem>4:15 AM</asp:ListItem>
                                                                                <asp:ListItem>4:30 AM</asp:ListItem>
                                                                                <asp:ListItem>4:45 AM</asp:ListItem>
                                                                                <asp:ListItem>5:00 AM</asp:ListItem>
                                                                                <asp:ListItem>5:15 AM</asp:ListItem>
                                                                                <asp:ListItem>5:30 AM</asp:ListItem>
                                                                                <asp:ListItem>5:45 AM</asp:ListItem>
                                                                                <asp:ListItem>6:00 AM</asp:ListItem>
                                                                                <asp:ListItem>6:15 AM</asp:ListItem>
                                                                                <asp:ListItem>6:30 AM</asp:ListItem>
                                                                                <asp:ListItem>6:45 AM</asp:ListItem>
                                                                                <asp:ListItem>7:00 AM</asp:ListItem>
                                                                                <asp:ListItem>7:15 AM</asp:ListItem>
                                                                                <asp:ListItem>7:30 AM</asp:ListItem>
                                                                                <asp:ListItem>7:45 AM</asp:ListItem>
                                                                                <asp:ListItem>8:00 AM</asp:ListItem>
                                                                                <asp:ListItem>8:15 AM</asp:ListItem>
                                                                                <asp:ListItem>8:30 AM</asp:ListItem>
                                                                                <asp:ListItem>8:45 AM</asp:ListItem>
                                                                                <asp:ListItem>9:00 AM</asp:ListItem>
                                                                                <asp:ListItem>9:15 AM</asp:ListItem>
                                                                                <asp:ListItem>9:30  AM</asp:ListItem>
                                                                                <asp:ListItem>9:45 AM</asp:ListItem>
                                                                                <asp:ListItem>10:00 AM</asp:ListItem>
                                                                                <asp:ListItem>10:15 AM</asp:ListItem>
                                                                                <asp:ListItem>10:30 AM</asp:ListItem>
                                                                                <asp:ListItem>10:45 AM</asp:ListItem>
                                                                                <asp:ListItem>11:00 AM</asp:ListItem>
                                                                                <asp:ListItem>11:15 AM</asp:ListItem>
                                                                                <asp:ListItem>11:30 AM</asp:ListItem>
                                                                                <asp:ListItem>11:45 AM</asp:ListItem>
                                                                                <asp:ListItem>12:00 PM</asp:ListItem>
                                                                                <asp:ListItem>12:15 PM</asp:ListItem>
                                                                                <asp:ListItem>12:30 PM</asp:ListItem>
                                                                                <asp:ListItem>12:45 PM</asp:ListItem>
                                                                                <asp:ListItem>1:00 PM</asp:ListItem>
                                                                                <asp:ListItem>1:15 PM</asp:ListItem>
                                                                                <asp:ListItem>1:30 PM</asp:ListItem>
                                                                                <asp:ListItem>1:45 PM</asp:ListItem>
                                                                                <asp:ListItem>2:00 PM</asp:ListItem>
                                                                                <asp:ListItem>2:15 PM</asp:ListItem>
                                                                                <asp:ListItem>2:30 PM</asp:ListItem>
                                                                                <asp:ListItem>2:45 PM</asp:ListItem>
                                                                                <asp:ListItem>3:00 PM</asp:ListItem>
                                                                                <asp:ListItem>3:15 PM</asp:ListItem>
                                                                                <asp:ListItem>3:30 PM</asp:ListItem>
                                                                                <asp:ListItem>3:45 PM</asp:ListItem>
                                                                                <asp:ListItem>4:00 PM</asp:ListItem>
                                                                                <asp:ListItem>4:15 PM</asp:ListItem>
                                                                                <asp:ListItem>4:30 PM</asp:ListItem>
                                                                                <asp:ListItem>4:45 PM</asp:ListItem>
                                                                                <asp:ListItem>5:00 PM</asp:ListItem>
                                                                                <asp:ListItem>5:15 PM</asp:ListItem>
                                                                                <asp:ListItem>5:30 PM</asp:ListItem>
                                                                                <asp:ListItem>5:45 PM</asp:ListItem>
                                                                                <asp:ListItem>6:00 PM</asp:ListItem>
                                                                                <asp:ListItem>6:15 PM</asp:ListItem>
                                                                                <asp:ListItem>6:30 PM</asp:ListItem>
                                                                                <asp:ListItem>6:45 PM</asp:ListItem>
                                                                                <asp:ListItem>7:00 PM</asp:ListItem>
                                                                                <asp:ListItem>7:15 PM</asp:ListItem>
                                                                                <asp:ListItem>7:30 PM</asp:ListItem>
                                                                                <asp:ListItem>7:45 PM</asp:ListItem>
                                                                                <asp:ListItem>8:00 PM</asp:ListItem>
                                                                                <asp:ListItem>8:15 PM</asp:ListItem>
                                                                                <asp:ListItem>8:30 PM</asp:ListItem>
                                                                                <asp:ListItem>8:45 PM</asp:ListItem>
                                                                                <asp:ListItem>9:00 PM</asp:ListItem>
                                                                                <asp:ListItem>9:15 PM</asp:ListItem>
                                                                                <asp:ListItem>9:30 PM</asp:ListItem>
                                                                                <asp:ListItem>9:45 PM</asp:ListItem>
                                                                                <asp:ListItem>10:00 PM</asp:ListItem>
                                                                                <asp:ListItem>10:15 PM</asp:ListItem>
                                                                                <asp:ListItem>10:30 PM</asp:ListItem>
                                                                                <asp:ListItem>10:45 PM</asp:ListItem>
                                                                                <asp:ListItem>11:00 PM</asp:ListItem>
                                                                                <asp:ListItem>11:15 PM</asp:ListItem>
                                                                                <asp:ListItem>11:30 PM</asp:ListItem>
                                                                                <asp:ListItem>11:45 PM</asp:ListItem>      
                                                                            </asp:DropDownList>
   <asp:RequiredFieldValidator ID="RFVPickUpTime" runat="server" ControlToValidate="DDLState" Display="None" ErrorMessage="Please Select Pick Up Time." InitialValue="Please Select" ValidationGroup="Submit"></asp:RequiredFieldValidator>
   <ajax:ValidatorCalloutExtender ID="VCEPickUpTime" runat="server" TargetControlID="RFVPickUpTime"></ajax:ValidatorCalloutExtender>
   </td>
   </tr>


   

  

  

   <tr align="center" height="40px"><td colspan="3">
   <asp:Button ID="btnGo" Text="Submit" runat="server" onclick="btnGo_Click" CssClass="buttonBook" Visible="true"
           ValidationGroup="Submit" />
           <asp:Button ID="bnBack" Text="Back" runat="server"  CssClass="buttonBook"
           onclick="bnBack_Click" />
           
   </td></tr>

   <tr><td colspan="3" align="center" style="color:#2E64FE;">
     <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </td></tr>

   </table>
  
    
    </td>
    <td valign="top">
    <table style="width:300px; border:1px solid #013ADF;">
    <tr>
   <td width="340"  style="background-color:#0062af;font-family:Arial;font-weight:bold;font-size:16;height:40px; color:White;" height="60px" colspan="3">
   <asp:Label ID="Label1" runat="server" Text="Your Booking Details"></asp:Label>
   </td>
   
   </tr>
    <tr>
   <td width="340" style="color:#2E64FE;" height="60px">
   <asp:Label ID="lblCarName" runat="server" Text="Car Name"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:Label ID="CarName" runat="server" ValidationGroup="Submit"></asp:Label>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;" height="60px">
   <asp:Label ID="lblCityName" runat="server" Text="City"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:Label ID="CityName" runat="server" ValidationGroup="Submit"></asp:Label>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;" height="60px">
   <asp:Label ID="lblTravelDate" runat="server" Text="TravelDate"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:Label ID="TravelDate" runat="server" ValidationGroup="Submit"></asp:Label>
   </td>
   </tr>

   

   <tr>
   <td width="340" style="color:#2E64FE;" height="60px">
   <asp:Label ID="lblBookingType" runat="server" Text="BookingType"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:Label ID="BookingType" runat="server" ValidationGroup="Submit"></asp:Label>
   </td>
  </tr>

  
   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
   <asp:Label ID="Status" runat="server" ValidationGroup="Submit"></asp:Label>
   </td>
   </tr>

   <tr>
   <td width="340" style="color:#2E64FE;height:40px;">
   <asp:Label ID="lblBasicPrice" runat="server" Text="BasicPrice"></asp:Label>
   </td>
   <td>:</td>
   <td  width="340">
  <asp:Label ID="BasicPrice"  runat="server" ValidationGroup="Submit"></asp:Label>
   </td>
  </tr>

   </table>
    </td>
  </tr>

    
   </table>
</asp:Content>

