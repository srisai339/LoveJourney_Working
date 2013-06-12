<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Customer Information" CodeFile="CustInfo.aspx.cs" Inherits="CustInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function showDiv1() {
            Page_ClientValidate("ContinueToPassengerList");
            if (Page_ClientValidate("ContinueToPassengerList")) {
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "images/loading.gif"', 200);
                return true;
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
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="Label10" runat="server" ForeColor="Maroon" Text="No permission to this page. Please contact Administrator for further details."></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" border="0"  id="tblMain" runat="server" bgcolor="#ffffff" cellspacing="0" cellpadding="0" style="table-layout: fixed;
        border: 1px solid Black;">
        <tr>
            <td valign="top" align="center">
                <table width="100%" style="background-color: White;" style="table-layout: fixed;">
                    <tr>
                        <td align="center" width="100%">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="left">
                            <table width="100%">
                                <tr>
                                    <td width="30%" align="left" style="padding-left: 10px;">
                                        <span style="font-size: 15px; font-family: Arial; color: Red; font-weight: bold;">Passenger
                                            Information</span>
                                    </td>
                                    <td width="70%" align="left" style="padding-left: 20px; font-weight: bold;">
                                        <span style="font-size: 15px; font-family: Arial; color: Red;">Travel Details</span>
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
                                                            <asp:Repeater ID="rptPassengersonward" runat="server" OnItemDataBound="rptPassengersonward_ItemDataBound">
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
                                                                            <asp:TextBox ID="txtPassengerName" MaxLength="50" runat="server" CssClass="textfield_2"
                                                                                ValidationGroup="ContinueToPassengerList">
                                                                            </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvPassengerName" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="txtPassengerName" ValidationGroup="ContinueToPassengerList"
                                                                                Display="Dynamic">
                                                                            </asp:RequiredFieldValidator><ajax:FilteredTextBoxExtender ID="ftbeName" runat="server"
                                                                                TargetControlID="txtPassengerName" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </td>
                                                                        <td width="10%" align="left">
                                                                            <asp:DropDownList ID="ddlGender" runat="server" Enabled="true" CssClass="sel" Width="70px"
                                                                                ValidationGroup="ContinueToPassengerList">
                                                                                <asp:ListItem Text="MALE" Value="Mr" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="FEMALE" Value="Mrs"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="40%" align="left">
                                                                            <asp:TextBox ID="txtAge" MaxLength="2" runat="server" CssClass="textfield_2" ValidationGroup="ContinueToPassengerList"
                                                                                Width="80px">
                                                                            </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="txtAge" ValidationGroup="ContinueToPassengerList" Display="Dynamic">
                                                                            </asp:RequiredFieldValidator>
                                                                            <asp:RangeValidator ID="rngAgeo" runat="server" ControlToValidate="txtAge" MinimumValue="1"
                                                                                MaximumValue="99" Type="Integer" ValidationGroup="ContinueToPassengerList" ErrorMessage="Invalid Age"></asp:RangeValidator>
                                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAge"
                                                                                ValidChars="0123456789">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Label ID="lblReturnJourney" runat="server" Text="Return Journey Details :" Visible="false"></asp:Label><br />
                                                    <asp:Panel ID="pnlPassengersReturn" runat="server" Width="100%">
                                                        <table width="100%">
                                                            <asp:Repeater ID="rptrPsgrDetailsReturn" runat="server" OnItemDataBound="rptrPsgrDetailsReturn_ItemDataBound">
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
                                                                            <asp:TextBox ID="txtPassengerName" MaxLength="50" runat="server" CssClass="textfield_2"
                                                                                ValidationGroup="ContinueToPassengerList">
                                                                            </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvPassengerName" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="txtPassengerName" ValidationGroup="ContinueToPassengerList"
                                                                                Display="Dynamic">
                                                                            </asp:RequiredFieldValidator>
                                                                            <ajax:FilteredTextBoxExtender ID="ftbeName" runat="server" TargetControlID="txtPassengerName"
                                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz ">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </td>
                                                                        <td width="10%" align="left">
                                                                            <asp:DropDownList ID="ddlGender" runat="server" Enabled="true" CssClass="sel" Width="70px"
                                                                                ValidationGroup="ContinueToPassengerList">
                                                                                <asp:ListItem Text="MALE" Value="Mr" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="FEMALE" Value="Mrs"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="40%" align="left">
                                                                            <asp:TextBox ID="txtAge" runat="server" MaxLength="2" CssClass="textfield_2" ValidationGroup="ContinueToPassengerList"
                                                                                Width="80px">
                                                                            </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="txtAge" ValidationGroup="ContinueToPassengerList" Display="Dynamic">
                                                                            </asp:RequiredFieldValidator>
                                                                            <asp:RangeValidator ID="rngAge" runat="server" ControlToValidate="txtAge" MinimumValue="1"
                                                                                MaximumValue="99" Type="Integer" ValidationGroup="ContinueToPassengerList" ErrorMessage="Invalid Age"></asp:RangeValidator>
                                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAge"
                                                                                ValidChars="0123456789">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </asp:Panel>
                                                    <br />
                                                    <asp:Panel ID="pnlPassengersReturn0" runat="server" Width="100%">
                                                        <table width="100%">
                                                            <asp:Repeater ID="rptrPsgrDetailsReturn0" runat="server" OnItemDataBound="rptrPsgrDetailsReturn0_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <tr class="boxbluerowheadr">
                                                                        <td align="left" width="20%">
                                                                            Seat
                                                                        </td>
                                                                        <td align="left" width="30%">
                                                                            Name
                                                                        </td>
                                                                        <td align="left" width="10%">
                                                                            Gender
                                                                        </td>
                                                                        <td align="left" width="40%">
                                                                            Age
                                                                        </td>
                                                                    </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td align="left" width="20%">
                                                                            <asp:Label ID="lblSeatNo0" runat="server" Font-Bold="true" Text='<%#Eval("SeatNos") %>'></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="30%">
                                                                            <asp:TextBox ID="txtPassengerName0" runat="server" CssClass="textfield_2" MaxLength="50"
                                                                                ValidationGroup="ContinueToPassengerList">
                                                                            </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvPassengerName0" runat="server" ControlToValidate="txtPassengerName0"
                                                                                Display="Dynamic" ErrorMessage="*" ValidationGroup="ContinueToPassengerList">
                                                                            </asp:RequiredFieldValidator>
                                                                            <ajax:FilteredTextBoxExtender ID="ftbeName0" runat="server" TargetControlID="txtPassengerName0"
                                                                                ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz ">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </td>
                                                                        <td align="left" width="10%">
                                                                            <asp:DropDownList ID="ddlGender0" runat="server" Enabled="true" CssClass="sel" ValidationGroup="ContinueToPassengerList"
                                                                                Width="70px">
                                                                                <asp:ListItem Selected="True" Text="MALE" Value="Mr"></asp:ListItem>
                                                                                <asp:ListItem Text="FEMALE" Value="Mrs"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" width="40%">
                                                                            <asp:TextBox ID="txtAge0" runat="server" CssClass="textfield_2" MaxLength="2" ValidationGroup="ContinueToPassengerList"
                                                                                Width="80px">
                                                                            </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAge0"
                                                                                Display="Dynamic" ErrorMessage="*" ValidationGroup="ContinueToPassengerList">
                                                                            </asp:RequiredFieldValidator>
                                                                            <asp:RangeValidator ID="rngAge0" runat="server" ControlToValidate="txtAge0" ErrorMessage="Invalid Age"
                                                                                MaximumValue="99" MinimumValue="1" Type="Integer" ValidationGroup="ContinueToPassengerList"></asp:RangeValidator>
                                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAge0"
                                                                                ValidChars="0123456789">
                                                                            </ajax:FilteredTextBoxExtender>
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
                                            <tr>
                                                <td width="20%">
                                                    &nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFullName"
                                                        Display="None" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAge"
                                                        Display="None" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtAge"
                                                        Display="Dynamic" ErrorMessage="Age should be numeric." Operator="DataTypeCheck"
                                                        Type="Integer">
                                                    </asp:CompareValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhoneNo"
                                                        Display="Dynamic" ErrorMessage="Phone No should be 10 digits." ValidationExpression="\d{10}"
                                                        ValidationGroup="ContinueToPassengerList"></asp:RegularExpressionValidator>
                                                    <ajax:FilteredTextBoxExtender ID="ftbePhoneNo" runat="server" TargetControlID="txtPhoneNo"
                                                        ValidChars="0123456789">
                                                    </ajax:FilteredTextBoxExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId"
                                                        Display="Dynamic" ErrorMessage="Invalid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        ValidationGroup="ContinueToPassengerList"></asp:RegularExpressionValidator>
                                                    <td width="10%">
                                                        &nbsp;
                                                    </td>
                                                </td>
                                            </tr>
                                            <tr valign="top" runat="server" visible="false" id="trNameInfo">
                                                <td width="20%" align="left">
                                                    <asp:Label ID="Label20" runat="server" Text="Full Name:"></asp:Label>
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:DropDownList ID="ddlGender" runat="server" Width="45px">
                                                        <asp:ListItem Value="M">Mr</asp:ListItem>
                                                        <asp:ListItem Value="F">Mrs</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox runat="server" ID="txtFullName" Width="175"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtAge" runat="server" CssClass="textfield_2" Width="45px" MaxLength="3"></asp:TextBox>
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
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textfield_2" Width="45px" MaxLength="3"
                                                        Enabled="false" Text="+91"></asp:TextBox>
                                                    <asp:TextBox ID="txtPhoneNo" runat="server" ValidationGroup="ContinueToPassengerList"
                                                        CssClass="textfield_2" MaxLength="10" Width="175px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhoneNo"
                                                        Display="Dynamic" ErrorMessage="*" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
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
                                                    <asp:TextBox ID="txtEmailId" MaxLength="100" runat="server" CssClass="textfield_2"
                                                        Width="225" ValidationGroup="ContinueToPassengerList"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmailId"
                                                        Display="Dynamic" ErrorMessage="*" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
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
                                                    <asp:TextBox ID="txtAddress" MaxLength="200" runat="server" TextMode="MultiLine"
                                                        CssClass="textfield_2" Width="225" ValidationGroup="ContinueToPassengerList"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                                                        Display="Dynamic" ErrorMessage="*" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
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
                                                    <asp:Panel ID="Panel1" runat="server" Visible="true">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="25%" align="left">
                                                                    ID Type:
                                                                </td>
                                                                <td width="30%" align="left">
                                                                    <asp:DropDownList ID="ddlIDType" runat="server">
                                                                        <asp:ListItem Text="Driving License" Value="0" />
                                                                        <asp:ListItem Text="PAN Card" Value="1" />
                                                                        <asp:ListItem Text="Passport" Value="2" />
                                                                        <asp:ListItem Text="Ration Card" Value="3" />
                                                                        <asp:ListItem Text="Voter ID Card" Value="4" />
                                                                        <asp:ListItem Text="Aadhaar Card" Value="5" />
                                                                        <asp:ListItem Text="Govt Recognised ID" Value="6" />
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="15%" align="left">
                                                                    ID Number :
                                                                </td>
                                                                <td width="35%" align="left">
                                                                    <asp:TextBox ID="txtIDNumber" MaxLength="30" runat="server" CssClass="textfield_2"
                                                                        Width="150" ValidationGroup="ContinueToPassengerList"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIDNumber"
                                                                        Display="Dynamic" ErrorMessage="*" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="4" width="100%">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="20%" align="left" colspan="2">
                                                                                ID Card Issued By :
                                                                            </td>
                                                                            <td width="80%" align="left" colspan="2">
                                                                                <asp:TextBox ID="txtIdIssuedBY" MaxLength="30" runat="server" CssClass="textfield_2"
                                                                                    Width="150" ValidationGroup="ContinueToPassengerList"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIDNumber"
                                                                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="ContinueToPassengerList"></asp:RequiredFieldValidator>
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
                                                <td width="100%" colspan="3" align="left" style="display: none;">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">
                                                    &nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:CheckBox ID="cbxAgree" runat="server" Text=" I agree to all the" ValidationGroup="ContinueToPassengerList" /><a
                                                        href="TermsAndConditions.aspx" target="_blank">Terms &amp; Conditions</a>
                                                </td>
                                                <td width="10%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="Promocode" runat="server">
                                                <td width="20%">
                                                    &nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:CheckBox ID="chkPromoCode" Text=" I have a Promo Code (optional)" runat="server"
                                                        AutoPostBack="true" OnCheckedChanged="chkPromoCode_CheckedChanged" />
                                                    <br />
                                                    <asp:TextBox ID="txtPromoCode" runat="server" MaxLength="20" Visible="false" AutoPostBack="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPromoCode"
                                                        ValidationGroup="PromoCode" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:Button ID="btnPromoCode" runat="server" Visible="false" Text="Apply Code" CssClass="et_srch"
                                                        OnClientClick="confirm('Please verify Promocode?');" OnClick="btnPromoCode_Click"
                                                        ValidationGroup="PromoCode" />
                                                    <asp:Label ID="lblPromocodeErrorMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td width="10%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="cashcoupon" runat="server">
                                                <td width="20%" align="left">
                                                    &nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:CheckBox ID="chkCashCoupon" Text=" I have a Cash Coupon (optional)" runat="server"
                                                        OnCheckedChanged="chkCashCoupon_CheckedChanged" AutoPostBack="true" />
                                                    <br />
                                                    <asp:TextBox ID="txtcashcoupon" runat="server" MaxLength="20" Visible="false" AutoPostBack="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvcashcoupon" runat="server" ControlToValidate="txtcashcoupon"
                                                        ValidationGroup="CashCoupon" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:Button ID="btncashcoupon" runat="server" Visible="false" Text="Apply Code" CssClass="et_srch"
                                                        OnClientClick="confirm('Please verify the cash coupon no and emailID?');" OnClick="btncashcoupon_Click"
                                                        ValidationGroup="CashCoupon" />
                                                    <asp:Label ID="lblCashcouponErrormsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td width="10%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td width="20%" align="left">
                                                    &nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:CheckBox ID="chkDealCode" Text=" I have a Deal Code (optional)" runat="server"
                                                        AutoPostBack="true" OnCheckedChanged="chkDealCode_CheckedChanged" />
                                                    <br />
                                                    <asp:TextBox ID="txtDealCode" runat="server" MaxLength="20" ValidationGroup="DealCode"
                                                        Visible="false" AutoPostBack="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtcashcoupon"
                                                        ValidationGroup="DealCode" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:Button ID="btnDealCode" runat="server" Visible="false" Text="Apply Code" CssClass="et_srch"
                                                        OnClick="btnDealCode_Click" ValidationGroup="DealCode" />
                                                    <asp:Label ID="lblDealCodeErrorMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td width="10%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%">
                                                    &nbsp;
                                                </td>
                                                <td align="left" width="70%">
                                                    &nbsp;
                                                    <asp:Button ID="btnBack" runat="server" CausesValidation="false" CssClass="et_srch"
                                                        OnClick="btnBack_Click" Text="Back" />
                                                    &nbsp;
                                                    <asp:Button ID="btnProceedToPayment" runat="server" CssClass="et_srch" OnClick="btnProceedToPayment_Click"
                                                        Text="Proceed" ValidationGroup="ContinueToPassengerList" OnClientClick="confirm('Please verify the all details?');" />
                                                    <span id="mainDiv" class="loadingBackground" style="display: none"></span><span id="contentDiv"
                                                        class="modalContainer" style="display: none">
                                                        <div class="registerhead">
                                                            <img alt="http://www.lovejourney.in Bus Car Flight Pan Card" src="images/loading.gif" width="150" height="150" />
                                                        </div>
                                                    </span>
                                                </td>
                                                <td width="10%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%">
                                                    &nbsp;
                                                </td>
                                                <td align="left" width="70%">
                                                    &nbsp;
                                                </td>
                                                <td width="10%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="30%" valign="top" style="padding-left: 20px;">
                                        <br />
                                        <strong>Total Amount Payable : </strong>Rs. &nbsp;<asp:Label ID="lblTotalAmountPayable"
                                            runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Panel ID="pnlOnwardTicketDetails" runat="server" Width="100%" BorderColor="#cecece"
                                            BorderWidth="1" BorderStyle="Solid">
                                            <table width="100%" style="line-height: 20px;">
                                                <tr>
                                                    <td width="100%" align="left" valign="top">
                                                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Route:"></asp:Label>
                                                        <asp:Label ID="lblRouteValue" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="100%" align="left" valign="top">
                                                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Journey Date:"></asp:Label>
                                                        <asp:Label ID="lblJourneyDate" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Bus Operator:"></asp:Label>
                                                        <asp:Label ID="lblBusOperator" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Bus Type:"></asp:Label>
                                                        <asp:Label ID="lblBusType" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Seat Nos:"></asp:Label>
                                                        <asp:Label ID="lblSeatNos" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Boarding Point:"></asp:Label>
                                                        <asp:Label ID="lblBoardingPoint" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Total Fare: "></asp:Label>
                                                        <asp:Label ID="lblFare" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <asp:Panel ID="pnlreturnticketdetails" runat="server" Width="100%" BorderColor="#cecece"
                                            BorderWidth="1" BorderStyle="Solid" Visible="False">
                                            <table width="100%" style="line-height: 20px;">
                                                <tr>
                                                    <td width="100%" align="left" valign="top">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Route:"></asp:Label>
                                                        <asp:Label ID="lblRoutereturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="100%" align="left" valign="top">
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Journey Date:"></asp:Label>
                                                        <asp:Label ID="lblJourneydatereturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Bus Operator:"></asp:Label>
                                                        <asp:Label ID="lblbusoperatorreturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Bus Type:"></asp:Label>
                                                        <asp:Label ID="lblbustypereturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Seat Nos:"></asp:Label>
                                                        <asp:Label ID="lblseatNosReturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Boarding Point:"></asp:Label>
                                                        <asp:Label ID="lblBoardingpointreturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Total Fare: "></asp:Label>
                                                        <asp:Label ID="lbltotalFarereturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <asp:Panel ID="pnlreturnticketdetails0" runat="server" BorderColor="#cecece" BorderStyle="Solid"
                                            BorderWidth="1" Visible="False" Width="100%">
                                            <table style="line-height: 20px;" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Route:"></asp:Label>
                                                        <asp:Label ID="lblRoutereturn0" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label34" runat="server" Font-Bold="True" Text="Journey Date:"></asp:Label>
                                                        <asp:Label ID="lblJourneydatereturn0" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label35" runat="server" Font-Bold="True" Text="Bus Operator:"></asp:Label>
                                                        <asp:Label ID="lblbusoperatorreturn0" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label36" runat="server" Font-Bold="True" Text="Bus Type:"></asp:Label>
                                                        <asp:Label ID="lblbustypereturn0" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label37" runat="server" Font-Bold="True" Text="Seat Nos:"></asp:Label>
                                                        <asp:Label ID="lblseatNosReturn0" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label38" runat="server" Font-Bold="True" Text="Boarding Point:"></asp:Label>
                                                        <asp:Label ID="lblBoardingpointreturn0" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label39" runat="server" Font-Bold="True" Text="Total Fare: "></asp:Label>
                                                        <asp:Label ID="lbltotalFarereturn0" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <asp:Panel ID="panelhotelinfo" runat="server" BorderColor="#cecece" BorderStyle="Solid"
                                            BorderWidth="1" Width="100%" Visible="false">
                                            <table style="line-height: 20px;" width="100%">
                                                <tr>
                                                    <td align="left" style="padding-left: 20px; font-weight: bold;" width="70%">
                                                        <span style="font-size: 15px; font-family: Arial; color: Red;">Hotel Details</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Checkin Date:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="lblcheckindate" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Hotel Name:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="lblHotelName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Room Type:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="lblroomtype" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="No.of Persons:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="lblnoofpersons" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="Room No:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style1" valign="top" width="100%">
                                                        <asp:Label ID="lblroomno" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        <asp:Label ID="Label32" runat="server" Font-Bold="True" Text="Total Fare: "></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="100%">
                                                        Rs.<asp:Label ID="lbltotalfare" runat="server"></asp:Label>
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
            </td>
        </tr>
        <tr id="println" runat="server" visible="false">
            <td>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" align="center">
                            <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="900" align="center">
                                        <table width="900" align="center">
                                            <tr>
                                                <td width="523" align="left">
                                                </td>
                                                <td width="115" align="right">
                                                    <span class="actions"><a onclick="printPage('printdiv');" target="_blank" class="et_srch">
                                                        Print</a></span>
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
                                                                        <img src="http://lovejourney.in/Newimages/New_Logo.png" width="249" height="100" border="0"
                                                                            title="" />
                                                                    </td>
                                                                    <td align="right" valign="top">
                                                                        <table width="200" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="40" align="left">
                                                                                </td>
                                                                                <td align="left">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="40" align="left">
                                                                                    <%--<img src="http://lovejourney.in/images/mail.png" width="30" height="30" />--%>
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
                                                            Note: To initiate your journey, please present your itinerary receipt or e-ticket.
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
                                                                                                    lovejourney Ref No: &nbsp;
                                                                                                    <asp:Label ID="lblTicketRefNo" runat="server" Text='<%#Eval("OnewayMBRefNo") %>' />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <table width="900" border="0" cellspacing="0" cellpadding="0">
                                                                                                        <tr>
                                                                                                            <td align="left" height="20" width="10%">
                                                                                                                Journey Date:
                                                                                                            </td>
                                                                                                            <td width="20%" align="left">
                                                                                                                <asp:Label ID="lblDOJ" Text='<%#Eval("DateOfJourney") %>' runat="server" />
                                                                                                            </td>
                                                                                                            <td width="10%" align="left">
                                                                                                                PNR No:
                                                                                                            </td>
                                                                                                            <td width="20%" align="left">
                                                                                                                <asp:Label ID="lblTicketId" runat="server" Text='<%#Eval("PNRNumber") %>' />
                                                                                                            </td>
                                                                                                            <td align="left" width="10%">
                                                                                                            </td>
                                                                                                            <td width="30%" align="left">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" height="20" width="10%">
                                                                                                                From:
                                                                                                            </td>
                                                                                                            <td width="20%" align="left">
                                                                                                                <asp:Label ID="lblSourceName" runat="server" Text='<%#Eval("SourceName") %>' />
                                                                                                            </td>
                                                                                                            <td align="left" width="10%">
                                                                                                                To:
                                                                                                            </td>
                                                                                                            <td width="20%" align="left">
                                                                                                                <asp:Label ID="lblDestinationName" runat="server" Text='<%#Eval("DestinationName") %>' />
                                                                                                            </td>
                                                                                                            <td align="left" width="10%">
                                                                                                                Travels:
                                                                                                            </td>
                                                                                                            <td width="30%" align="left">
                                                                                                                <asp:Label ID="lblTravelName" runat="server" Text='<%#Eval("TravelOPName") %>' />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" height="20" width="10%">
                                                                                                                Coach:
                                                                                                            </td>
                                                                                                            <td width="40%" align="left" colspan="2">
                                                                                                                <asp:Label ID="lblBusType" runat="server" Text='<%#Eval("BusType") %>' />
                                                                                                            </td>
                                                                                                            <td align="left" width="10%">
                                                                                                                Boarding Point:
                                                                                                            </td>
                                                                                                            <td width="40%" align="left" colspan="2">
                                                                                                                <asp:Label ID="lblBordingTime" runat="server" Text='<%#Eval("BoardingPointName") %>' />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="4" align="left">
                                                                                                                Boarding Point Address:
                                                                                                                <asp:Label ID="lblBoardingPoint" runat="server" Text='<%#Eval("BoardingInfo") %>' />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
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
                                                                                                                            Passenger Details:
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
                                                                                                                            Status:
                                                                                                                        </td>
                                                                                                                        <td width="82" align="left">
                                                                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("BStatus")%>'></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td width="93" align="left">
                                                                                                                            Contact No:
                                                                                                                        </td>
                                                                                                                        <td width="93" align="left">
                                                                                                                            <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo ") %>'></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td width="81" align="left">
                                                                                                                            Id Proof:
                                                                                                                        </td>
                                                                                                                        <td width="129" align="left">
                                                                                                                            <%#Eval("IDType ")%>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" height="15">
                                                                                                                            Id Number:
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            <%#Eval("IDNumber ")%>
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            Booked By:
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            <asp:Label ID="lblBookedBy" runat="server" Text='<%#Eval("FullName") %>' />
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            Booked On:
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
                                                                                                                                            Cancelled By:
                                                                                                                                        </td>
                                                                                                                                        <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                            <asp:Label ID="lblCancelledBY" runat="server" Text='<%# Eval("cancelledBy") %>' />
                                                                                                                                        </td>
                                                                                                                                        <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                            Cancelled On:
                                                                                                                                        </td>
                                                                                                                                        <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("CancelledDate") %>' />
                                                                                                                                        </td>
                                                                                                                                        <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                            Cash Coupon Issued:
                                                                                                                                        </td>
                                                                                                                                        <td align="left" valign="middle" bgcolor="#f0efef" class="cont-txt-big-grey">
                                                                                                                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("CancelCashCoupon") %>' />
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </asp:Panel>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" height="15">
                                                                                                                            Amount:
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("TotalFare") %>' />
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            Others:
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                           <asp:Label ID="Label25" runat="server" Text='<%# Eval("Markup") %>' />
                                                                                                                     
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            Total:
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("TotalWithMarkPrice") %>' />
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
                                                                                    Cacnellation Policy:
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
                                                                                <HeaderStyle BackColor="#eeeeee" Font-Bold="false" ForeColor="Black" HorizontalAlign="Left" />
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
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                        <br />
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
                                                        <%-- <asp:LinkButton ID="LinkButton1" Text="Mail" runat="server" OnClick="lbtnmail_Click1" />&nbsp;&nbsp;|&nbsp;&nbsp;--%><a
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
</asp:Content>
