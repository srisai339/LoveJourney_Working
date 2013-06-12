<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="Profile.aspx.cs" Inherits="Agent_Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" bgcolor="#ffffff">
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
        <td class="heading" align="center">
        <asp:Label ID="lblheading" runat="server" Text="Profile"></asp:Label>
        </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <div id="divAgentProfile" runat="server" visible="true">
                  <%--  <fieldset>
                        <legend runat="server" id="legendProfile">Profile</legend>--%>
                        <table width="100%">
                            <tr>
                                <td align="right" width="35%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="25%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    &nbsp;Name:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtAgentName" MaxLength="200" runat="server" Width="250px" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAgentName"
                                        Display="None" ErrorMessage="Please enter agent name." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceName" runat="server" TargetControlID="RequiredFieldValidator1"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    Type:
                                </td>
                                <td align="left" width="40%">
                                    <asp:DropDownList ID="ddlType" runat="server" ValidationGroup="Register">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Travel Agency</asp:ListItem>
                                        <asp:ListItem>Cyber Cafe</asp:ListItem>
                                        <asp:ListItem>Mobile Store</asp:ListItem>
                                        <asp:ListItem>Kirana Shop</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlType"
                                        Display="None" ErrorMessage="Please select type of agency." InitialValue="Please Select"
                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceType" runat="server" TargetControlID="RequiredFieldValidator2"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    Date Of Birth:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtDateOfBirth" MaxLength="50" runat="server" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateOfBirth_CalendarExtender" runat="server" TargetControlID="txtDateOfBirth">
                                    </asp:CalendarExtender>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateOfBirth"
                                        Display="None" ErrorMessage="Please enter date of birth." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceDob" runat="server" TargetControlID="RequiredFieldValidator3"></asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDateOfBirth"
                                        Display="None" ErrorMessage="Please enter valid date." Operator="DataTypeCheck"
                                        Type="Date" ValidationGroup="Register"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceCompare" runat="server" TargetControlID="CompareValidator1"></asp:ValidatorCalloutExtender>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    City:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtCity" MaxLength="100" runat="server" Width="250px" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity"
                                        Display="None" ErrorMessage="Please enter city." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceCity" TargetControlID="RequiredFieldValidator4" runat="server"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    State:
                                </td>
                                <td align="left" width="40%">
                                    <asp:DropDownList ID="ddlState" runat="server" ValidationGroup="Register">
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
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlState"
                                        Display="None" ErrorMessage="Please select state." InitialValue="Please Select"
                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="RequiredFieldValidator5"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    Address:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" Width="300px" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress"
                                        Display="None" ErrorMessage="Please enter address." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceAddress" runat="server" TargetControlID="RequiredFieldValidator6"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    Pin Code:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtPinCode" MaxLength="6" runat="server" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPinCode"
                                        Display="None" ErrorMessage="Please enter pin code." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vcePincode" runat="server" TargetControlID="RequiredFieldValidator7"></asp:ValidatorCalloutExtender>

                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtPinCode"
                                        Display="None" ErrorMessage="Please enter only numerics." Operator="DataTypeCheck"
                                        Type="Integer" ValidationGroup="Register"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceComparePincode" runat="server" TargetControlID="CompareValidator2"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    Mobile No:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtMobileNo" MaxLength="10" runat="server" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMobileNo"
                                        ErrorMessage="Please enter mobile no." Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceMobileNo" runat="server" TargetControlID="RequiredFieldValidator8"></asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtMobileNo"
                                        Display="None" ErrorMessage="Please enter only numerics." Operator="DataTypeCheck"
                                        Type="Integer" ValidationGroup="Register" Visible="False"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceVompareMobile" runat="server" TargetControlID="CompareValidator3"></asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNo"
                                        Display="None" ErrorMessage="Please enter valid 10 digit no." ValidationExpression="[7-9][0-9]{9}"
                                        ValidationGroup="Register"></asp:RegularExpressionValidator>
                                    <asp:ValidatorCalloutExtender ID="vceRegular" runat="server" TargetControlID="RegularExpressionValidator2"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    Alternate Mobile No:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtAlternateMobileNo" MaxLength="10" runat="server" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please alternate mobile no."
                                        Display="None" ControlToValidate="txtAlternateMobileNo" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vce1" runat="server" TargetControlID="RequiredFieldValidator9"></asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Please enter only numerics."
                                        ControlToValidate="txtAlternateMobileNo" Display="None" Operator="DataTypeCheck"
                                        Type="Integer" ValidationGroup="Register" Visible="False"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vce2" runat="server" TargetControlID="CompareValidator4"></asp:ValidatorCalloutExtender>


                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="Alternate mobile should not be same as  mobile."
                                        ControlToCompare="txtMobileNo" ControlToValidate="txtAlternateMobileNo" Display="None"
                                        ValidationGroup="Register" Operator="NotEqual"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vce3" runat="server" TargetControlID="CompareValidator6"></asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAlternateMobileNo"
                                        Display="None" ErrorMessage="Please enter valid 10 digit no." ValidationExpression="[7-9][0-9]{9}"
                                        ValidationGroup="Register"></asp:RegularExpressionValidator>
                                    <asp:ValidatorCalloutExtender ID="vce4" runat="server" TargetControlID="RegularExpressionValidator3"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    Landline No:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtLandlineNo" MaxLength="20" runat="server" Width="150px" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    Email Id:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtEmailId" MaxLength="250" runat="server" Width="250px" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please enter email id."
                                        ControlToValidate="txtEmailId" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vce5" runat="server" TargetControlID="RequiredFieldValidator10"></asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid email id."
                                        ControlToValidate="txtEmailId" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="Register"></asp:RegularExpressionValidator>
                                    <asp:ValidatorCalloutExtender ID="vce6" runat="server" TargetControlID="RegularExpressionValidator1"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    PAN:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtPAN" MaxLength="10" runat="server" ValidationGroup="Register"
                                        CssClass="textfield_sleep"></asp:TextBox>
                                </td>
                                <td align="left" width="25%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please enter pan no."
                                        ControlToValidate="txtPAN" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vcePan" runat="server" TargetControlID="RequiredFieldValidator11"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="25%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr11" runat="server" visible="false">
                                <td align="right" width="35%">
                                    Commission(%):
                                </td>
                                <td align="left" width="40%">
                                    <asp:Label ID="txtCommissionPercentage" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                                <td align="left" width="25%">
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="right" width="35%">
                                    Username:
                                </td>
                                <td align="left" width="40%">
                                    <asp:Label ID="txtUsername" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                                <td align="left" width="25%">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="25%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="35%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;<asp:Button ID="btnRegister" runat="server" Text="Update" OnClick="btnRegister_Click"
                                        ValidationGroup="Register" Style="cursor: pointer;" CssClass="buttonBook" />
                                </td>
                                <td align="left" width="25%">
                                    &nbsp;
                                </td>
                            </tr>
                          
                            <tr>
                                <td align="right" width="35%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="25%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" width="25%">
                                    <table width="100%" height="88" border="0" cellspacing="0" cellpadding="0" runat="server"
                                        id="CustomerView" visible="true" style="table-layout: fixed;">
                                        <tr>
                                            <td align="center" style="border: thin solid #C0C0C0"    height="88">
                                                <asp:Image ID="imgAgentLogo" runat="server"  ToolTip="AgentLogo"
                                                    AlternateText="AgentLogo" ImageUrl="~/images/logo.gif" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td align="right" >
                                                &nbsp;
                                            </td>
                                            <td align="left" ">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" >
                                                Photo:</td>
                                            <td align="left" >
                                    <asp:FileUpload ID="fuImage" runat="server" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="fuImage"
                                        Display="None" ErrorMessage="Please browse the image." ValidationGroup="Img"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vce7" runat="server" TargetControlID="RequiredFieldValidator12"></asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" >
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" >
                                                &nbsp;
                                            </td>
                                            <td align="left" >
                                                &nbsp;
                                            <asp:Button ID="btnUploadImage" runat="server" Text="Upload Logo" OnClick="btnUploadImage_Click"
                                        ValidationGroup="Img" Style="cursor: pointer;" CssClass="buttonBook" />
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                            
                        </table>
                    <%--</fieldset>--%>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
    </table>


</asp:Content>

