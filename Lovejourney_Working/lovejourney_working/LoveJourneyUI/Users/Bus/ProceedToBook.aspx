<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProceedToBook.aspx.cs" Inherits="Users_ProceedToBook" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function showDiv1() {
                Page_ClientValidate("ContinueToPassengerList");
                if (Page_ClientValidate("ContinueToPassengerList")) {
                    // go();
                    // go1();
                    //go2();
                    document.getElementById('mainDiv').style.display = "";
                    document.getElementById('contentDiv').style.display = "";
                    setTimeout('document.images["myAnimatedImage"].src = "../../images/roller_big.gif"', 200);
                }
                else {
                    return false;
                }

            }
        }
    </script>
    <style type="text/css">
        .modalContainer
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            position: fixed;
            left: 45%;
            top: 45%;
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
    <asp:MultiView ID="MVIEW" runat="server">
        <asp:View ID="mv2" runat="server">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout: fixed;">
                <tr valign="top">
                    <td valign="top" align="center">
                        <table width="100%" style="background-color: White;" style="table-layout: fixed;">
                            <tr valign="top">
                                <td align="center" width="100%">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td width="100%" align="left">
                                    <table width="100%">
                                        <tr>
                                            <td width="70%" align="left" style="padding-left: 10px; font-weight: bold;">
                                                <span style="font-size: 15px; font-family: Arial; color: Red;">Passenger Information</span>
                                            </td>
                                            <td width="30%" align="left" style="padding-left: 20px;">
                                                <span style="font-size: 15px; font-family: Arial; color: Red; font-weight: bold;">Travel
                                                    Details</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="70%" valign="top" align="left">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="100%" colspan="3">
                                                            <asp:Label ID="lblOnwardJourney" runat="server" Text="Onward Journey Details :"></asp:Label><br />
                                                            <asp:Panel ID="pnlPassengersOnward" runat="server" Width="100%">
                                                                <table width="100%">
                                                                    <asp:Repeater ID="rptPassengersonward" runat="server">
                                                                        <HeaderTemplate>
                                                                            <tr class="boxbluerowheadr">
                                                                                <td width="20%" align="left">
                                                                                    Seat
                                                                                </td>
                                                                                <td width="30%" align="left">
                                                                                    Name
                                                                                </td>
                                                                                <td width="10%" align="left">
                                                                                    Gender
                                                                                </td>
                                                                                <td width="40%" align="left">
                                                                                    Age
                                                                                </td>
                                                                            </tr>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td width="20%" align="left">
                                                                                    <asp:Label ID="lblSeatNo" runat="server" Text='<%#Eval("SeatNos") %>' Font-Bold="true"></asp:Label>
                                                                                </td>
                                                                                <td width="30%" align="left">
                                                                                    <asp:TextBox ID="txtPassengerName" MaxLength="20" runat="server" CssClass="lj_inp"
                                                                                        ValidationGroup="ContinueToPassengerList">
                                                                                    </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvPassengerName" runat="server" ErrorMessage="Enter Name"
                                                                                        ControlToValidate="txtPassengerName" ValidationGroup="ContinueToPassengerList"
                                                                                        Display="None">
                                                                                    </asp:RequiredFieldValidator><ajax:FilteredTextBoxExtender ID="ftbeName" runat="server"
                                                                                        TargetControlID="txtPassengerName" ValidChars=" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"></ajax:FilteredTextBoxExtender>
                                                                                    <ajax:ValidatorCalloutExtender ID="vcePassengerName" runat="server" TargetControlID="rfvPassengerName" ></ajax:ValidatorCalloutExtender>
                                                                                </td>
                                                                                <td width="10%" align="left">
                                                                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="lj_inp" Width="60px" ValidationGroup="ContinueToPassengerList" >
                                                                                        <asp:ListItem Text="Male" Value="M" Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                                                                     <%--   <asp:ListItem Text="Miss" Value="F"></asp:ListItem>--%>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td width="40%" align="left">
                                                                                    <asp:TextBox ID="txtAge" MaxLength="2" runat="server" CssClass="lj_inp" ValidationGroup="ContinueToPassengerList"
                                                                                        Width="80px">
                                                                                    </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Age"
                                                                                        ControlToValidate="txtAge" ValidationGroup="ContinueToPassengerList" Display="None">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="rngAgeo" runat="server" ControlToValidate="txtAge" MinimumValue="1"
                                                                                        MaximumValue="99" Type="Integer" ValidationGroup="ContinueToPassengerList" ErrorMessage="Invalid Age"></asp:RangeValidator>
                                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAge"
                                                                                        ValidChars="0123456789"></ajax:FilteredTextBoxExtender>
                                                                                    <ajax:ValidatorCalloutExtender ID="vceAge" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                                                                </td>
                                                                            </tr>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:Label ID="lblReturnJourney" runat="server" Text="Return Journey Details :" Visible="false"></asp:Label><br />
                                                            <asp:Panel ID="pnlPassengersReturn" runat="server" Width="100%">
                                                                <table width="100%">
                                                                    <asp:Repeater ID="rptrPsgrDetailsReturn" runat="server">
                                                                        <HeaderTemplate>
                                                                            <tr class="boxbluerowheadr">
                                                                                <td width="20%" align="left">
                                                                                    Seat
                                                                                </td>
                                                                                <td width="30%" align="left">
                                                                                    Name
                                                                                </td>
                                                                                <td width="10%" align="left">
                                                                                    Gender
                                                                                </td>
                                                                                <td width="40%" align="left">
                                                                                    Age
                                                                                </td>
                                                                            </tr>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td width="20%" align="left">
                                                                                    <asp:Label ID="lblSeatNo" runat="server" Text='<%#Eval("SeatNosreturn") %>' Font-Bold="true"></asp:Label>
                                                                                </td>
                                                                                <td width="30%" align="left">
                                                                                    <asp:TextBox ID="txtPassengerName" MaxLength="20" runat="server" CssClass="lj_inp"
                                                                                        ValidationGroup="ContinueToPassengerList">
                                                                                    </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvPassengerName" runat="server" ErrorMessage="Enter PassengerName"
                                                                                        ControlToValidate="txtPassengerName" ValidationGroup="ContinueToPassengerList"
                                                                                        Display="None">
                                                                                    <ajax:ValidatorCalloutExtender ID="vcePassengerName" TargetControlID="rfvPassengerName" runat="server"></ajax:ValidatorCalloutExtender>
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <ajax:FilteredTextBoxExtender ID="ftbeName" runat="server" TargetControlID="txtPassengerName"
                                                                                        ValidChars=" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"></ajax:FilteredTextBoxExtender>
                                                                                </td>
                                                                                <td width="10%" align="left">
                                                                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="lj_inp" Width="60px" ValidationGroup="ContinueToPassengerList">
                                                                                        <asp:ListItem Text="Male" Value="M" Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                                                                      <%--  <asp:ListItem Text="Miss" Value="F"></asp:ListItem>--%>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td width="40%" align="left">
                                                                                    <asp:TextBox ID="txtAge" runat="server" MaxLength="2" CssClass="lj_inp" ValidationGroup="ContinueToPassengerList"
                                                                                        Width="80px">
                                                                                    </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Age"
                                                                                        ControlToValidate="txtAge" ValidationGroup="ContinueToPassengerList" Display="None">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <ajax:ValidatorCalloutExtender ID="vceAge" runat="server" TargetControlID="RequiredFieldValidator1"></ajax:ValidatorCalloutExtender>
                                                                                    <asp:RangeValidator ID="rngAgeo" runat="server" ControlToValidate="txtAge" MinimumValue="1" Display="None"
                                                                                        MaximumValue="99" Type="Integer" ValidationGroup="ContinueToPassengerList" ErrorMessage="Invalid Age"></asp:RangeValidator>
                                                                                    <ajax:ValidatorCalloutExtender ID="vceAgeo" runat="server" TargetControlID="rngAgeo"></ajax:ValidatorCalloutExtender>
                                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAge"
                                                                                        ValidChars="0123456789"></ajax:FilteredTextBoxExtender>
                                                                                </td>
                                                                            </tr>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100%" colspan="3">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100%" colspan="3" align="left">
                                                            <span style="padding-left: 10px; font-weight: bold;"><span style="font-size: 15px;
                                                                font-family: Arial; color: Red;">Contact Details</span> (The ticket details
                                                            will be sent to the below mentioned contact details)
                                                        </td>
                                                    </tr>
                                                    <tr valign="top" style="display: none;">
                                                        <td width="20%" align="left">
                                                            <asp:Label ID="Label20" runat="server" Text="Full Name:"></asp:Label>
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:DropDownList ID="ddlGender" runat="server" Width="45px" CssClass="lj_inp">
                                                                <asp:ListItem Value="M">Mr</asp:ListItem>
                                                                <asp:ListItem Value="F">Mrs</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtFullName" runat="server" CssClass="lj_inp" Width="175"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr valign="top" style="display: none;">
                                                        <td width="20%" align="left">
                                                            <asp:Label ID="Label21" runat="server" Text="Age:"></asp:Label>
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:TextBox ID="txtAge" runat="server" CssClass="lj_inp" Width="45px" MaxLength="3"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="20%" align="left">
                                                            <asp:Label ID="Label22" runat="server" Text="Mobile No:"></asp:Label>
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="lj_inp" Width="45px" MaxLength="3"
                                                                Enabled="false" Text="+91"></asp:TextBox>
                                                            <asp:TextBox ID="txtPhoneNo" runat="server" ValidationGroup="ContinueToPassengerList"
                                                                CssClass="lj_inp" MaxLength="10" Width="175px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhoneNo"
                                                                Display="None" ErrorMessage="Enter PhoneNo" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcerf6" TargetControlID="RequiredFieldValidator6" runat="server"></ajax:ValidatorCalloutExtender>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="20%" align="left">
                                                            <asp:Label ID="Label23" runat="server" Text="Email Id:"></asp:Label>
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:TextBox ID="txtEmailId" runat="server" CssClass="lj_inp" Width="225" ValidationGroup="ContinueToPassengerList"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmailId"
                                                                Display="None" ErrorMessage="Enter Emailid" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcerf9" TargetControlID="RequiredFieldValidator9" runat="server"></ajax:ValidatorCalloutExtender>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="20%" align="left">
                                                            <asp:Label ID="Label2" runat="server" Text="Address:"></asp:Label>
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:TextBox ID="txtAddress" MaxLength="200" runat="server" CssClass="lj_inp"
                                                                Width="225" ValidationGroup="ContinueToPassengerList"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                                                                Display="None" ErrorMessage="Enter Address" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcerfv2" TargetControlID="RequiredFieldValidator2"  runat="server"></ajax:ValidatorCalloutExtender>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            &nbsp;
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFullName" ValidationGroup="123"
                                                                Display="None" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAge" ValidationGroup="123"
                                                                Display="None" ErrorMessage="Age"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcephoneno" runat="server" TargetControlID="RequiredFieldValidator7"></ajax:ValidatorCalloutExtender>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtAge" ValidationGroup="123"
                                                                Display="None" ErrorMessage="Age should be numeric." Operator="DataTypeCheck"
                                                                Type="Integer">
                                                            </asp:CompareValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcephoneno2" TargetControlID="CompareValidator2" runat="server"></ajax:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhoneNo" 
                                                                Display="None" ErrorMessage="Phone No should be 10 digits." ValidationExpression="\d{10}"
                                                                ValidationGroup="123"></asp:RegularExpressionValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vceregular" TargetControlID="RegularExpressionValidator2" runat="server"></ajax:ValidatorCalloutExtender>
                                                            <ajax:FilteredTextBoxExtender ID="ftbePhoneNo" runat="server" TargetControlID="txtPhoneNo"
                                                                ValidChars="0123456789"></ajax:FilteredTextBoxExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId" 
                                                                Display="None" ErrorMessage="Invalid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="123"></asp:RegularExpressionValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcerev1" runat="server" TargetControlID="RegularExpressionValidator1"></ajax:ValidatorCalloutExtender>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>

                                                    <tr valign="top">
                                                        <td width="100%" colspan="3">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="100%" colspan="3" align="left">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="15%" align="left">
                                                                        ID Type:
                                                                    </td>
                                                                    <td width="35%" align="left">
                                                                        <asp:DropDownList ID="ddlIDType" runat="server" CssClass="lj_inp">
                                                                            <asp:ListItem Text="Driving License" Value="0" />
                                                                            <asp:ListItem Text="PAN Card" Value="1" />
                                                                            <asp:ListItem Text="Passport" Value="2" />
                                                                            <asp:ListItem Text="Ration Card" Value="3" />
                                                                            <asp:ListItem Text="Voter ID Card" Value="4" />
                                                                            <asp:ListItem Text="Aadhaar Card" Value="5" />
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td width="15%" align="left">
                                                                        ID Number :
                                                                    </td>
                                                                    <td width="35%" align="left">
                                                                        <asp:TextBox ID="txtIDNumber" MaxLength="30" runat="server" CssClass="lj_inp"
                                                                            Width="150" ValidationGroup="ContinueToPassengerList"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIDNumber"
                                                                            Display="None" ErrorMessage="Enter Id Number" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
                                                                            <ajax:ValidatorCalloutExtender ID="vcerf3" runat="server" TargetControlID="RequiredFieldValidator3"></ajax:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="4" width="100%">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td width="18%" align="left" colspan="2">
                                                                                    ID Card Issued By :
                                                                                </td>
                                                                                <td width="82%" align="left" colspan="2" >
                                                                                    <asp:TextBox ID="txtIdIssuedBY" MaxLength="30" runat="server" CssClass="lj_inp" style="padding-right:5px;"
                                                                                        Width="150" ValidationGroup="ContinueToPassengerList"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIdIssuedBY"
                                                                                        Display="None" ErrorMessage="Enter Id Card Issued By" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
                                                                                    <ajax:ValidatorCalloutExtender ID="vceRFV5" TargetControlID="RequiredFieldValidator5" runat="server"></ajax:ValidatorCalloutExtender>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                       
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td width="100%" colspan="3" align="left" style="display:none;">
                                                            <asp:Panel ID="pnlPriamryPassenger" runat="server" Width="100%" Visible="false">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="40%" align="left">
                                                                            Primary Passenger Seat Number
                                                                        </td>
                                                                        <td align="left" width="60%">
                                                                            <asp:DropDownList ID="ddlPrimaryPassenger" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="100%" colspan="3">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%" align="left">
                                                            &nbsp;
                                                        </td> 
                                                        <td width="70%" align="left">
                                                            <asp:CheckBox ID="cbxAgree" runat="server" Text=" I agree to all the" 
                                                                 />&nbsp;<a href="../../TermsAndConditions.aspx" target="_blank">Terms &amp;
                                                                    Conditions</a>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="100%" colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%" align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:CheckBox ID="chkCashCoupon" Text=" I have a cash coupon (optional)" runat="server"
                                                                OnCheckedChanged="chkCashCoupon_CheckedChanged" AutoPostBack="true" />
                                                            <br />
                                                            <asp:TextBox ID="txtcashcoupon" runat="server" MaxLength="30" Visible="false" AutoPostBack="false" CssClass="lj_inp"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcashcoupon"
                                                                ValidationGroup="CashCoupon" ErrorMessage="Enter Cash Coupon Number" Display="None"></asp:RequiredFieldValidator><asp:Button
                                                                    ID="btncashcoupon" runat="server" Visible="false" Text="Apply Code" CssClass="buttonBook"
                                                                    OnClick="btncashcoupon_Click" ValidationGroup="CashCoupon" />
                                                                    <ajax:ValidatorCalloutExtender ID="vcerfv4" TargetControlID="RequiredFieldValidator4" runat="server"></ajax:ValidatorCalloutExtender>
                                                            <asp:Label ID="lblCashcouponErrormsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="100%" colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            &nbsp;
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:CheckBox ID="chkPromoCode" Text=" I have a Promo Code (optional)" runat="server"
                                                                AutoPostBack="true" OnCheckedChanged="chkPromoCode_CheckedChanged" />
                                                            <br />
                                                            <asp:TextBox ID="txtPromoCode" runat="server" MaxLength="30" Visible="false" AutoPostBack="false" CssClass="lj_inp"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvcashcoupon" runat="server" ControlToValidate="txtPromoCode"
                                                                ValidationGroup="PromoCode" ErrorMessage="Enter Promo Code" Display="None"></asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="vcercc" TargetControlID="rfvcashcoupon" runat="server"></ajax:ValidatorCalloutExtender>
                                                                <asp:Button
                                                                    ID="btnPromoCode" runat="server" Visible="false" Text="Apply Code" CssClass="buttonBook"
                                                                    OnClick="btnPromoCode_Click" ValidationGroup="PromoCode" />
                                                            <asp:Label ID="lblPromocodeErrorMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="100%" colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr  style="display:none;">
                                                        <td width="20%">
                                                            &nbsp;
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:RadioButtonList ID="rdbtnlstselct" runat="server" RepeatDirection="Horizontal"
                                                                OnSelectedIndexChanged="rdbtnlstselct_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem Text="Home Delivery" Value="0" />
                                                                <asp:ListItem Text="Office Pickup" Value="1" Selected="True" />
                                                            </asp:RadioButtonList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required"
                                                                ControlToValidate="rdbtnlstselct" runat="server" ValidationGroup="proceed" />
                                                            <ajax:ValidatorCalloutExtender ID="vcerfv1" TargetControlID="RequiredFieldValidator1" runat="server"></ajax:ValidatorCalloutExtender>
                                                            <br />
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="20%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top" width="70%" valign="top">
                                                            Comment:
                                                            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="lj_inp"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            &nbsp;
                                                        </td>
                                                        <td width="70%" align="left">
                                                            <asp:Panel ID="pnlhomedelivery" runat="server" Width="100%" Visible="false" BorderColor="#eeeeee"
                                                                BorderStyle="Solid" BorderWidth="1">
                                                                <center>
                                                                    <table width="95%" cellpadding="0" cellspacing="0" style="line-height: 25px;">
                                                                        <tr>
                                                                            <td width="40%" align="left" valign="top">
                                                                                <span style="font-family: Arial; font-size: 14px; color: Red;">Home Delivery</span>
                                                                            </td>
                                                                            <td width="60%" align="left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" colspan="2">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" colspan="2" align="left" valign="top">
                                                                                Home Delivery Charges Rs.40
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="40%" align="left" valign="top">
                                                                                Address *
                                                                            </td>
                                                                            <td width="60%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtAddressHD" runat="server" TextMode="MultiLine" Width="200px" CssClass="lj_inp"
                                                                                    Height="100"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ErrorMessage="Please Enter Address"
                                                                                    ValidationGroup="proceed" ControlToValidate="txtAddress" Display="None"></asp:RequiredFieldValidator>
                                                                                <ajax:ValidatorCalloutExtender ID="vceaddress" runat="server" TargetControlID="rfvaddress"></ajax:ValidatorCalloutExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="40%" align="left" valign="top">
                                                                                Landmark
                                                                            </td>
                                                                            <td width="60%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtLandmark" runat="server" MaxLength="50" CssClass="lj_inp"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="40%" align="left" valign="top">
                                                                                City
                                                                            </td>
                                                                            <td width="60%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtCity" runat="server" MaxLength="50" CssClass="lj_inp"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="40%" align="left" valign="top">
                                                                                Pin code
                                                                            </td>
                                                                            <td width="60%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtPinCode" runat="server" MaxLength="10" CssClass="lj_inp"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="40%" align="left" valign="top">
                                                                                Preferred Delivery time
                                                                            </td>
                                                                            <td width="60%" align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlHour" runat="server" CssClass="lj_inp" Width="50px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;&nbsp;
                                                                                <asp:DropDownList ID="ddlMinutes" runat="server" CssClass="lj_inp" Width="50px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;&nbsp;
                                                                                <asp:DropDownList ID="ddlAmPm" runat="server" CssClass="lj_inp" Width="50px">
                                                                                    <asp:ListItem Text="AM" Value="A"></asp:ListItem>
                                                                                    <asp:ListItem Text="PM" Value="P" Selected="True"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="40%" align="left" valign="top">
                                                                                Comments
                                                                            </td>
                                                                            <td width="60%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="200px" Height="100" CssClass="lj_inp"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" width="40%">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left" width="60%">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </center>
                                                            </asp:Panel>
                                                        </td>
                                                        <td width="10%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                      
                                                        <td width="70%" align="center" colspan="3">                                                            
                                                            <asp:Button ID="btnProceedToPayment" runat="server" CssClass="buttonBook"
                                                                OnClick="btnProceedToPayment_Click" Text="Proceed" ValidationGroup="ContinueToPassengerList"
                                                                OnClientClick="showDiv1();" />&nbsp;
                                                       
                                                            <asp:Button ID="btnBack" runat="server" CssClass="buttonBook" OnClick="btnBack_Click"
                                                                Text="Back" CausesValidation="false" />
                                                            <%--<span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                                                                style="display: none" class="modalContainer">
                                                                <div class="registerhead">
                                                                    <img src="../../images/loading.gif" width="150" height="150" /></div>
                                                            </span>--%>
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
                                                                        Please don't Refresh
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <img src="../../images/loading.gif" width="100" height="100" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="almost12" height="20">
                                                                       Your Ticket Booking is on Processing
                                                                    </td>
                                                                </tr>
                                                               <%-- <tr>
                                                                    <td align="center" height="20">
                                                                        <input id="Text1" type="text" style="border: 0; text-align: right;" />&nbsp;&nbsp;To&nbsp;&nbsp;<input
                                                                            id="Text2" type="text" style="border: 0;" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" height="20">
                                                                        On
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" height="20">
                                                                        <input id="Text3" type="text" style="border: 0; text-align: center;" />
                                                                    </td>
                                                                </tr>--%>
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
                                                            
                                                        </td>
                                                     
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="30%" valign="top" style="padding-left: 20px;">
                                                <br />
                                                <strong>Total Amount Payable :</strong> &nbsp;
                                                <asp:Label ID="lblTotalAmountPayable" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                <asp:Panel ID="pnlOnwardTicketDetails" runat="server" Width="100%" BorderColor="#cecece"
                                                    BorderWidth="1" BorderStyle="Solid">
                                                    <table width="100%" style="line-height: 20px;">
                                                        <tr>
                                                            <td width="100%" align="left" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="left" valign="top">
                                                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Route:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="left" valign="top">
                                                                <asp:Label ID="lblRouteValue" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="left" valign="top">
                                                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Journey Date:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblJourneyDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Bus Operator:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblBusOperator" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Bus Type:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblBusType" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Seat Nos:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblSeatNos" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Boarding Point:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style1" valign="top" width="100%">
                                                                <asp:Label ID="lblBoardingPoint" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Total Fare:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblFare" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlreturnticketdetails" runat="server" Width="100%" BorderColor="#cecece"
                                                    BorderWidth="1" BorderStyle="Solid">
                                                    <table width="100%" style="line-height: 20px;">
                                                        <tr>
                                                            <td width="100%" align="left" valign="top">
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Route:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="left" valign="top">
                                                                <asp:Label ID="lblRoutereturn" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="left" valign="top">
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Journey Date:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblJourneydatereturn" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Bus Operator:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblbusoperatorreturn" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Bus Type:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblbustypereturn" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Seat Nos:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lblseatNosReturn" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Boarding Point:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style1" valign="top" width="100%">
                                                                <asp:Label ID="lblBoardingpointreturn" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Total Fare:"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <asp:Label ID="lbltotalFarereturn" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="center" style="table-layout: fixed;">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="center">
                                    &nbsp;
                                    <asp:Panel ID="Panel2" runat="server" Width="100%">
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" align="center">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="mv1" runat="server">
            <asp:Panel ID="pnlViewticket" runat="server" Width="900">
                <center>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="ctct" valign="top" align="center">
                                <table width="900" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top">
                                            <table id="Table1" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="center" valign="middle" width="500px">
                                                        <span class="innerheading">
                                                            <asp:Label ID="lblmsg1" runat="server"></asp:Label><br />
                                                            <asp:Label ID="Message" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top" align="center">
                                            <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="900" align="center">
                                                            <tr>
                                                                <td width="623">
                                                                    <span class="actions"></span>
                                                                </td>
                                                                <td width="115" align="right">
                                                                    <span>
                                                                        <asp:LinkButton ID="lbtnCancel" Text="Cancel" runat="server" OnClick="lbtnCancel_Click" Visible="false"/> <asp:LinkButton ID="LinkButton3" Text="Download" runat="server" OnClick="btnExportTOWord_Click" />&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton
                                                                            ID="lbtnmail" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
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
                                                                                        <img src="http://www.lovejourney.in/images/logo.gif" width="143" height="88" border="0"
                                                                                            title="Mana Bus" />&nbsp;&nbsp;
                                                                                        <asp:Image ID="imgKesineni" runat="server" ImageUrl="http://lovejourney.in/images/kesineni-Logo.jpg"
                                                                                            Width="100" Height="88" Visible="false" />
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
                                                                                                                                <asp:Label ID="lblTicketId" runat="server" Text='<%# Eval("PNRNumber") %>' />
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
                                                                    <span>
                                                                        <asp:LinkButton ID="LinkButton1" Text="Cancel" runat="server" OnClick="lbtnCancel_Click" Visible="false"/>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton
                                                                            ID="LinkButton2" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;<a
                                                                                onclick="printPage('printdiv');" target="_blank">Print</a></span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:Panel>
        </asp:View>
    </asp:MultiView>
</asp:Content>
