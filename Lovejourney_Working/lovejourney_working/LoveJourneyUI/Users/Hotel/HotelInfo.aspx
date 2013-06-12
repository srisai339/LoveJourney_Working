<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Hotel/MasterPage.master"
    AutoEventWireup="true" CodeFile="HotelInfo.aspx.cs" Inherits="Agent_Hotel_HotelInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/is_style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function showDiv2() {
            Page_ClientValidate("submit");
            if (Page_ClientValidate("submit")) {
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "../../images/loading.gif"', 200);
            }
            else {
                return false;
            }
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="100%">
                <table width="100%" border="0px" style="background-color: White;border:1px Solid #000000;"   cellspacing="0" cellpadding="0" class="is_tp" >
                    <tr>
                        <td>
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <br />
                            <strong><span style="color: Red;">Selected Hotel</span></strong>
                            <table width="100%" id="SelectedHotel" border="0px">
                                <thead>
                                    <tr>
                                        <td width="25%">
                                            <strong>Hotel Name</strong>
                                        </td>
                                        <td width="25%">
                                            <strong>Address</strong>
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
                                    <td width="25%">
                                        <asp:Label ID="lblHotelName" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="25%">
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
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
                            </table>
                            <br />
                            <hr />
                            <table width="100%" id="TravellerDetails" border="0px">
                                <tr>
                                    <td width="100%" colspan="4">
                                        <strong><span style="color: Red;">Traveller Details</span> </strong>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td width="40%">
                                        <strong><span >No. of Room(s): </span></strong>
                                        <asp:Label ID="lblNoOfRooms" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="20%">
                                        <strong>Pax > 12 yrs.: </strong>
                                        <asp:Label ID="lblPaxGreaterThan12" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="20%">
                                        <strong>Pax <= 12 yrs.: </strong>
                                        <asp:Label ID="lblPaxLessThan12" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="20%" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" colspan="4">
                                        <strong>Total INR:</strong>
                                        <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <hr />
                            <strong><span style="color: Red;">User Details</span></strong>
                            <table width="100%" id="UserDetails" border="0px">
                                <tr>
                                    <td width="15%" valign="top">
                                        Title:
                                    </td>
                                    <td width="85%" valign="top" colspan="3">
                                        <asp:DropDownList ID="ddlUserTitle" runat="server" ValidationGroup="submit" width="50" CssClass="lj_inp">
                                            <asp:ListItem>Mr</asp:ListItem>
                                            <asp:ListItem>Ms</asp:ListItem>
                                            <asp:ListItem>Mrs</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" valign="top">
                                        First Name:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtUserFirstName" runat="server" ValidationGroup="submit" MaxLength="20" CssClass="lj_inp"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserFirstName"
                                            Display="None" ErrorMessage="Please enter first name." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceFirstName" runat="server" TargetControlID="RequiredFieldValidator1">
                                        </ajax:ValidatorCalloutExtender>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtUserFirstName"
                                            ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                    <td width="15%" valign="top">
                                        Middle Name:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtUserMiddleName" runat="server" ValidationGroup="submit" MaxLength="20" CssClass="lj_inp" ></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtUserMiddleName"
                                            ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" valign="top">
                                        Last Name:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtUserLastName" runat="server" ValidationGroup="submit" MaxLength="20" CssClass="lj_inp"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtUserLastName"
                                            Display="None" ErrorMessage="Please enter last name." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceLastName" runat="server" TargetControlID="RequiredFieldValidator10">
                                        </ajax:ValidatorCalloutExtender>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtUserLastName"
                                            ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                    <td width="15%" valign="top">
                                        Mobile Number:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtPhone" runat="server" Text="91" Width="20px" CssClass="lj_inp"></asp:TextBox>
                                        <asp:TextBox ID="txtUserPhoneNumber" runat="server" MaxLength="10" ValidationGroup="submit" Width="120px" CssClass="lj_inp"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserPhoneNumber"
                                            Display="None" ErrorMessage="Please enter phone number." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceMobileNo" runat="server" TargetControlID="RequiredFieldValidator2">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUserPhoneNumber"
                                            Display="None" ErrorMessage="Please enter valid number." ValidationExpression="[7-9][0-9]{9}"
                                            ValidationGroup="submit"></asp:RegularExpressionValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceMobileNo1" runat="server" TargetControlID="RegularExpressionValidator2">
                                        </ajax:ValidatorCalloutExtender>
                                          <ajax:FilteredTextBoxExtender ID="ftbe12" runat="server" TargetControlID="txtUserPhoneNumber" ValidChars="0123456789"></ajax:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" valign="top">
                                        Email Id:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtUserEmailId" runat="server" ValidationGroup="submit" CssClass="lj_inp"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserEmailId"
                                            Display="None" ErrorMessage="Please enter email id." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceEmailId" runat="server" TargetControlID="RequiredFieldValidator3">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserEmailId"
                                            Display="None" ErrorMessage="Please enter valid email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="submit"></asp:RegularExpressionValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceEmailId1" runat="server" TargetControlID="RegularExpressionValidator1">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td width="15%" valign="top">
                                        Confirm Email Id:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtUserConfirmEmailId" runat="server" ValidationGroup="submit" CssClass="lj_inp"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCEmail" runat="server" Display="None" ErrorMessage="Please Enter Confirm Mail Id"
                                            ControlToValidate="txtUserConfirmEmailId"    ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vecEmail1" runat="server" TargetControlID="rfvCEmail">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtUserEmailId"
                                            ControlToValidate="txtUserConfirmEmailId" Display="None" ErrorMessage="Invalid confirm email id."
                                            ValidationGroup="submit"></asp:CompareValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceConfirmEmailId" runat="server" TargetControlID="CompareValidator1">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" valign="top">
                                        Address:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtUserAddress" runat="server" ValidationGroup="submit" CssClass="lj_inp"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserAddress"
                                            Display="None" ErrorMessage="Please enter address." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceAddress" TargetControlID="RequiredFieldValidator4"
                                            runat="server">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td width="15%" valign="top">
                                        City:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtUserCity" runat="server" ValidationGroup="submit" CssClass="lj_inp"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUserCity"
                                            Display="None" ErrorMessage="Please enter city." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="RequiredFieldValidator7">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" valign="top">
                                        State:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:DropDownList ID="ddlState" runat="server" ValidationGroup="submit" CssClass="lj_inp">
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlState"
                                            Display="None" ErrorMessage="Please select state." ValidationGroup="submit" InitialValue="Please Select"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="RequiredFieldValidator5">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td width="15%" valign="top">
                                        PinCode:
                                    </td>
                                    <td width="35%" valign="top">
                                        <asp:TextBox ID="txtUserPinCode" runat="server" MaxLength="6" ValidationGroup="submit" CssClass="lj_inp"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUserPinCode"
                                            Display="None" ErrorMessage="Please enter pincode." ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="vcePincode" runat="server" TargetControlID="RequiredFieldValidator6">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtUserPinCode"
                                            Display="None" ErrorMessage="Please enter only numerics." Operator="DataTypeCheck"
                                            Type="Integer" ValidationGroup="submit"></asp:CompareValidator>
                                        <ajax:ValidatorCalloutExtender ID="vcePincode1" runat="server" TargetControlID="CompareValidator2">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <hr />
                            <asp:GridView ID="gvPolicy" runat="server" Width="100%" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Hotel Policy" HeaderStyle-ForeColor="Red" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPolicyText" runat="server" Text='<%# Eval("policyText") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <hr />

                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                CssClass="buttonBook" ValidationGroup="submit" OnClientClick="showDiv2();" />

                                 <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="buttonBook" OnClick="btnBack_Click"
                                CausesValidation="false" />

                            <br />
                           <hr />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
        style="display: none" class="modalContainer">
        <div class="registerhead">
            <img src="../../images/loading.gif" width="150" height="150" alt="Loading" />
        </div>
    </span>
</asp:Content>
