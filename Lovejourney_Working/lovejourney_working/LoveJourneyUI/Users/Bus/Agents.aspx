<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="Agents.aspx.cs" Inherits="Users_Agents" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="Label7" runat="server" ForeColor="Maroon" Text="No permission to this page. Please contact Administrator for further details."></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" id="tblMain" runat="server" bgcolor="#ffffff">
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:LinkButton ID="lbtnRegisterAgent" runat="server" OnClick="lbtnRegisterAgent_Click">Register Agent</asp:LinkButton>&nbsp;&nbsp;&nbsp;
               
                <asp:LinkButton ID="lbtnViewAgents" runat="server" OnClick="lbtnViewAgents_Click"
                    Font-Bold="true">View Agents</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;

                  <asp:LinkButton ID="lnkbtnEmployee" runat="server" 
                    Font-Bold="true" onclick="lnkbtnEmployee_Click">View Employee</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtnDeposits" runat="server" OnClick="lbtnDeposits_Click">Deposits</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbntAgentRequests" runat="server" PostBackUrl="~/Users/Bus/AgentRequests.aspx"
                    Visible="false">AgentRequests</asp:LinkButton>
                    <asp:LinkButton ID="lbtnViewDbs" runat="server"  OnClick="lbtnViewDbs_Click"
                    Font-Bold="true">View Distributors</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkViewBSD" runat="server"  
                    Font-Bold="true" onclick="lnkViewBSD_Click">View BSD</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtnDistributorsDeposits" runat="server" OnClick="lbtnDistributorsDeposits_Click">Distributor Deposits</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkAgentRequests" runat="server" PostBackUrl="~/Users/Bus/AgentRequests.aspx">Agent Requests From Emp</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkPendingRequests" runat="server" 
                    onclick="lnkPendingRequests_Click">Pending Requests</asp:LinkButton>
                   

            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <label id="lblMsg" runat="server" style="color:Green;">
                </label>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <div id="divAgentRegistration" runat="server" visible="false">
                    <fieldset>
                        <legend runat="server" id="legendAgentRegistration">Registration</legend>
                        <table width="100%" align="center">
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="trrole" runat="server">
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Role:
                                </td>
                                <td class="labelclass">
                                    <asp:DropDownList ID="ddlRole" runat="server" ValidationGroup="Register">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Distributor</asp:ListItem>
                                        <asp:ListItem>Agent</asp:ListItem>
                                        <asp:ListItem>BSD</asp:ListItem>
                                        <asp:ListItem>Employee</asp:ListItem>
                                       
                                    </asp:DropDownList>

                                    <asp:DropDownList ID="ddlBSD" runat="server" ValidationGroup="Register">
                                       <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Agent</asp:ListItem>
                                        <asp:ListItem>Employee</asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="rfvddlRole" runat="server" ControlToValidate="ddlRole"
                                        Display="None" ErrorMessage="Please select role." InitialValue="Please Select"
                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceType" runat="server" TargetControlID="rfvddlRole">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Agent/Agency Name: <strong style="color: Red">*</strong>
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtAgentName" MaxLength="200" runat="server" Width="250px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAgentName"
                                        Display="None" ErrorMessage="Please enter agent name." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceAgentName" runat="server" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Type:
                                </td>
                                <td class="labelclass">
                                    <asp:DropDownList ID="ddlType" runat="server" ValidationGroup="Register">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Travel Agency</asp:ListItem>
                                        <asp:ListItem>Cyber Cafe</asp:ListItem>
                                        <asp:ListItem>Mobile Store</asp:ListItem>
                                        <asp:ListItem>Kirana Shop</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="labelclass">
                                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlType"
                                        Display="None" ErrorMessage="Please select type of agency." InitialValue="Please Select"
                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceType" runat="server" TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Date Of Birth:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtDateOfBirth" MaxLength="50" runat="server" ValidationGroup="Register"></asp:TextBox>
                           
                                    <asp:CalendarExtender ID="txtDateOfBirth_CalendarExtender" runat="server" TargetControlID="txtDateOfBirth">
                                    </asp:CalendarExtender>
                                </td>
                                <td class="labelclass">
                                    <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateOfBirth"
                                        Display="Dynamic" ErrorMessage="Please enter date of birth." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDateOfBirth"
                                        Display="Dynamic" ErrorMessage="Please enter valid date." Operator="DataTypeCheck"
                                        Type="Date" ValidationGroup="Register"></asp:CompareValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    City:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtCity" MaxLength="100" runat="server" Width="250px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                               <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity"
                                        Display="None" ErrorMessage="Please enter city." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="RequiredFieldValidator4">
                                    </asp:ValidatorCalloutExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    State:
                                </td>
                                <td class="labelclass">
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
                                <td class="labelclass">
                           <%--         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlState"
                                        Display="None" ErrorMessage="Please select state." InitialValue="Please Select"
                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    District:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtDistrict" MaxLength="100" runat="server" Width="250px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                               <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity"
                                        Display="None" ErrorMessage="Please enter city." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="RequiredFieldValidator4">
                                    </asp:ValidatorCalloutExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Address:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" Width="300px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress"
                                        Display="None" ErrorMessage="Please enter address." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceAddress" runat="server" TargetControlID="RequiredFieldValidator6">
                                    </asp:ValidatorCalloutExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Pin Code:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPinCode" MaxLength="6" runat="server" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                         <%--           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPinCode"
                                        Display="None" ErrorMessage="Please enter pin code." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vcePincode1" runat="server" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>--%>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtPinCode"
                                        Display="None" ErrorMessage="Please enter only numerics." Operator="DataTypeCheck"
                                        Type="Integer" ValidationGroup="Register"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vcePincode" runat="server" TargetControlID="CompareValidator2">
                                    </asp:ValidatorCalloutExtender>
                                <asp:FilteredTextBoxExtender ID="ftePincode" runat="server" TargetControlID="txtPinCode" ValidChars="1234567890"></asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Mobile No:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtMobileNo" MaxLength="10" runat="server" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMobileNo"
                                        ErrorMessage="Please enter mobile no." Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceMobileno" runat="server" TargetControlID="RequiredFieldValidator8">
                                    </asp:ValidatorCalloutExtender>--%>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtMobileNo"
                                        Display="None" ErrorMessage="Please enter only numerics." Operator="DataTypeCheck"
                                        Type="Integer" ValidationGroup="Register" Visible="False"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceMobileNo1" runat="server" TargetControlID="CompareValidator3">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNo"
                                        Display="None" ErrorMessage="Please enter valid 10 digit no." ValidationExpression="[7-9][0-9]{9}"
                                        ValidationGroup="Register"></asp:RegularExpressionValidator>
                                    <asp:ValidatorCalloutExtender ID="vceMoNo" runat="server" TargetControlID="RegularExpressionValidator2">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:FilteredTextBoxExtender ID="fteMobileNo" runat="server" TargetControlID="txtMobileNo" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Alternate Mobile No:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtAlternateMobileNo" MaxLength="10" runat="server" ValidationGroup="Register"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="fteAlterNateMobile" runat="server" TargetControlID="txtAlternateMobileNo" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Landline No:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtLandlineNo" MaxLength="12" runat="server" Width="150px" ValidationGroup="Register"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtLandlineNo" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Email Id:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtEmailId" MaxLength="250" runat="server" Width="250px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please enter email id."
                                        ControlToValidate="txtEmailId" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceEmailId" runat="server" TargetControlID="RequiredFieldValidator10">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid email id."
                                        ControlToValidate="txtEmailId" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="Register"></asp:RegularExpressionValidator>
                                    <asp:ValidatorCalloutExtender ID="vceEmailId1" runat="server" TargetControlID="RegularExpressionValidator1">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    PAN:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPAN" MaxLength="10" runat="server" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please enter pan no."
                                        ControlToValidate="txtPAN" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vcePan" runat="server" TargetControlID="RequiredFieldValidator11">
                                    </asp:ValidatorCalloutExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Details:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" Width="300px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Status:
                                </td>
                                <td class="labelclass">
                                    <asp:DropDownList ID="ddlStatus" runat="server" ValidationGroup="Register">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Approved</asp:ListItem>
                                        <asp:ListItem>Hold</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please select status."
                                        ControlToValidate="ddlStatus" Display="None" InitialValue="Please Select" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceStatus" runat="server" TargetControlID="RequiredFieldValidator12">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="agentcomm" runat="server" visible="false">
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Commission(%):
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtCommissionPercentage" runat="server" MaxLength="2" ValidationGroup="Register"
                                        Width="50px"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtCommissionPercentage"
                                        Display="None" ErrorMessage="Please enter commission percentage." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceCommission" runat="server" TargetControlID="RequiredFieldValidator18">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtCommissionPercentage"
                                        Display="None" ErrorMessage="Please enter only numerics." Operator="DataTypeCheck"
                                        Type="Integer" ValidationGroup="Register"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceCommission1" runat="server" TargetControlID="CompareValidator8">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Username:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtUsername" MaxLength="50" runat="server" Width="200px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please enter username."
                                        ControlToValidate="txtUsername" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceUserName" runat="server" TargetControlID="RequiredFieldValidator13">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Password:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPassword" MaxLength="50" runat="server" Width="200px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please enter password."
                                        ControlToValidate="txtPassword" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vcePassword" runat="server" TargetControlID="RequiredFieldValidator14">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Confirm Password:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtConfirmPassword" MaxLength="50" runat="server" Width="200px"
                                        ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Please enter confirm password."
                                        ControlToValidate="txtConfirmPassword" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceConfirmPassword" runat="server" TargetControlID="RequiredFieldValidator20">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Confim password and password mismatch."
                                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="None"
                                        ValidationGroup="Register"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vcePassword1" runat="server" TargetControlID="CompareValidator5">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr id="checkBox" runat="server" visible="true">
                              <td colspan="4" align="center" height="30px">
                                <asp:CheckBox ID="chkDomesticFlights" Text="DomesticFlights" runat="server" />
                                <asp:CheckBox ID="chkInternationalFlights" Text="InterNationalFlights" runat="server" />
                                <asp:CheckBox ID="chkBuses" Text="Buses" runat="server" />
                                <asp:CheckBox ID="chkHotels" Text="Hotels" runat="server" />
                                <asp:CheckBox ID="chkRecharge" Text="Recharge" runat="server" />
                                <asp:Label ID="lblDomesticFlights" runat="server"></asp:Label>
                                <asp:Label ID="lblInterNationalFlights" runat="server"></asp:Label>
                                <asp:Label ID="lblHotels" runat="server"></asp:Label>
                                <asp:Label ID="lblBuses" runat="server"></asp:Label>
                                <asp:Label ID="lblRecharge" runat="server"></asp:Label>









                              </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"
                                        CssClass="buttonBook" ValidationGroup="Register" Style="cursor: pointer;" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Back" Style="cursor: pointer;"
                                        CssClass="buttonBook" Visible="false" OnClick="btnCancel_Click" />
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%">
                <div id="divAgents" runat="server" visible="true">
                    <fieldset>
                        <legend>View</legend>
                        <table width="100%">
                            <tr>
                                <td>
                                </td>
                            </tr>
                             <tr>
                                    <td width="100%" align="right" valign="top" class="busoperator_text_head">
                                        <%--Search&nbsp;:&nbsp;--%><asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                                            ID="btnSearch" Text="GO" runat="server" CssClass="buttonBook" 
                                            ValidationGroup="search" onclick="btnSearch_Click"
                                             />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td width="40%" align="left" valign="top">
                                                    <asp:Label ID="lblSelectpage" Text="Select Page Size" runat="server"></asp:Label>&nbsp;:&nbsp;
                                                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
                                                        CssClass="DDL" onselectedindexchanged="ddlPageSize_SelectedIndexChanged" 
                                                      >
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <asp:ListItem Text="100" Value="1" />
                                                        <asp:ListItem Text="200" Value="2" />
                                                        <asp:ListItem Text="300" Value="3" />
                                                    </asp:DropDownList>
                                                </td>
                                                
                                              
                                                <td width="50%" align="right">
                                                    <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" 
                                                        OnClientClick="ExportGridviewtoExcel();" onclick="lbtnXport2Xcel_Click"
                                                         />&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAgents" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="100"
                                        AllowSorting="true" OnPageIndexChanging="gvAgents_PageIndexChanging" OnRowCommand="gvAgents_RowCommand"
                                        OnRowDataBound="gvAgents_RowDataBound" OnSorting="gvAgents_Sorting" Width="100%"
                                        DataKeyNames="AgentId,UserId" EmptyDataText="No Data Found">
                                         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="AgentName" HeaderText="AgentName" SortExpression="AgentName" />
                                            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                            <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                            <asp:BoundField DataField="District" HeaderText="District" SortExpression="District" />

                                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" SortExpression="MobileNo" />
                                            <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />
                                            <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="Username" />
                                            <asp:BoundField DataField="Password" HeaderText="Password" />
                                            <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" />
                                            <asp:BoundField DataField="CommisionPercentage" HeaderText="Comm(%)" SortExpression="CommisionPercentage" />
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                    <asp:RadioButton ID="rbtnApproved" runat="server" Text="Approved" GroupName="Status"
                                                        ForeColor="Green" AutoPostBack="true" OnCheckedChanged="rbtnStatus_CheckedChanged"
                                                        ValidationGroup='<%# Eval("AgentId") %>' />
                                                    <asp:RadioButton ID="rbtnHold" runat="server" Text="Hold" GroupName="Status" ForeColor="Red"
                                                        AutoPostBack="true" OnCheckedChanged="rbtnStatus_CheckedChanged" ValidationGroup='<%# Eval("AgentId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnViewAgent" runat="server" CommandName="ViewAgent" Style="cursor: pointer;"
                                                        CssClass="buttonBook" CommandArgument='<%# Eval("AgentId") %>' Text="View" ToolTip="Click to view or update agent" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%">
                <div id="divDeposits" runat="server" visible="false">
                    <fieldset>
                        <legend>Deposits</legend>
                        <table width="100%">
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                Agent Username:&nbsp;
                                            </td>
                                            <td class="labelclass">
                                                <asp:TextBox ID="txtAgents" ToolTip="Type the first 3 letters of agent name" runat="server">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvFrom" Display="None" ValidationGroup="SearchInt"
                                                    runat="server" ErrorMessage="Enter agent name" ControlToValidate="txtAgents"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvFrom">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:AutoCompleteExtender ID="txtFrom_AutoCompleteExtender" runat="server" TargetControlID="txtAgents"
                                                    ServiceMethod="GetAgentNames" MinimumPrefixLength="1" CompletionInterval="10"
                                                    CompletionSetCount="12" FirstRowSelected="True" DelimiterCharacters="" Enabled="True"
                                                    ServicePath="">
                                                </asp:AutoCompleteExtender>
                                                <asp:DropDownList ID="ddlAgents" runat="server" 
                                                    OnSelectedIndexChanged="ddlAgents_SelectedIndexChanged" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="labelclass">
                                             <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtAgents"
                                                    Display="None" ErrorMessage="Please enter agent." SetFocusOnError="True" ValidationGroup="Deposit"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceAgentName1" runat="server" TargetControlID="RequiredFieldValidator15">
                                                </asp:ValidatorCalloutExtender>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                Enter Amount:&nbsp;
                                            </td>
                                            <td class="labelclass">
                                                <asp:TextBox ID="txtAmount" runat="server" ValidationGroup="Deposit"></asp:TextBox>
                                            </td>
                                            <td class="labelclass">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtAmount"
                                                    Display="None" ErrorMessage="Please enter amount." SetFocusOnError="True" ValidationGroup="Deposit"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceEnterAmount" runat="server" TargetControlID="RequiredFieldValidator16">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="txtAmount"
                                                    Display="None" ErrorMessage="Please enter numeric values." Operator="DataTypeCheck"
                                                    Type="Double" ValidationGroup="Deposit"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceEnterAAmount1" runat="server" TargetControlID="CompareValidator7">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                Type:&nbsp;
                                            </td>
                                            <td width="30%">
                                                <asp:RadioButtonList ID="rbtnType" runat="server" RepeatDirection="Horizontal" ValidationGroup="Deposit">
                                                    <asp:ListItem>Cash</asp:ListItem>
                                                    <asp:ListItem>Cheque</asp:ListItem>
                                                    <asp:ListItem>Net Banking</asp:ListItem>
                                                      <asp:ListItem>Others</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td class="labelclass">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="rbtnType"
                                                    Display="None" ErrorMessage="Please select type." ValidationGroup="Deposit"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceDeposit" runat="server" TargetControlID="RequiredFieldValidator19">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                Transaction No:&nbsp;
                                            </td>
                                            <td class="labelclass">
                                                <asp:TextBox ID="txtTransactionNo" runat="server" ValidationGroup="Deposit"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvTransactionNumber" runat="server" ValidationGroup="Deposit"
                                                    ErrorMessage="Please Enter Transaction Number" ControlToValidate="txtTransactionNo"
                                                    Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceTransactionNumber" runat="server" TargetControlID="rfvTransactionNumber">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                Details:&nbsp;
                                            </td>
                                            <td class="labelclass">
                                                <asp:TextBox ID="txtDepositDetails" runat="server" TextMode="MultiLine" ValidationGroup="Deposit"></asp:TextBox>
                                            </td>
                                            <td class="labelclass">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtDepositDetails"
                                                    Display="None" ErrorMessage="Please enter deposit details." SetFocusOnError="True"
                                                    ValidationGroup="Deposit"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceDetails" runat="server" TargetControlID="RequiredFieldValidator17">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trReason">
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                Reason
                                            </td>
                                            <td class="labelclass">
                                                <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                            <td class="labelclass">
                                                <asp:Button ID="btnDepositSubmit" runat="server" OnClick="btnDepositSubmit_Click"
                                                    CssClass="buttonBook" Text="Add" Style="cursor: pointer;" ValidationGroup="Deposit" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnDeductAmt" runat="server" CssClass="buttonBook" Text="Deduct"
                                                    Style="cursor: pointer;" ValidationGroup="Deposit" OnClick="btnDeductAmt_Click" />
                                            </td>
                                            <td class="labelclass">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvDeposits" runat="server" AllowPaging="true" AllowSorting="true"
                                        OnPageIndexChanging="gvDeposits_PageIndexChanging" Width="100%" PageSize="20"
                                        OnSorting="gvDeposits_Sorting" EmptyDataText="No Data Found" ShowFooter="true"
                                        AutoGenerateColumns="false" OnRowDataBound="gvDeposits_RowDataBound" Visible="False">
                                        <EmptyDataRowStyle ForeColor="#CC0000" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S No" SortExpression="">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CreatedDate" SortExpression="CreatedDate" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("CreatedDate") %>' />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    Total:
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount" SortExpression="Amount" FooterStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>' />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotal" runat="server" ForeColor="Red" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DepositType" SortExpression="DepositType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDepositType" runat="server" Text='<%# Eval("DepositType") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transaction No" SortExpression="TransactionNumber">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTransactionNumber" runat="server" Text='<%# Eval("TransactionNumber") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Details" SortExpression="Details">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetails" runat="server" Text='<%# Eval("Details") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <br />
                                    <div id="divDepositRequests" style="display: none;">
                                        <fieldset>
                                            <legend>Deposit Requests</legend>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <asp:GridView Visible="false" ID="gvDepositRequests" runat="server" AllowPaging="true"
                                                            AllowSorting="true" AutoGenerateColumns="false" OnPageIndexChanging="gvDepositRequests_PageIndexChanging"
                                                            OnRowCommand="gvDepositRequests_RowCommand" OnRowDataBound="gvDepositRequests_RowDataBound"
                                                            OnSorting="gvDepositRequests_Sorting" ShowFooter="True" Width="100%">
                                                            <EmptyDataRowStyle ForeColor="#CC0000" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Agent Id" SortExpression="UserName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAgentId" runat="server" Text='<%# Eval("UserName") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Deposit Amount" SortExpression="DepositAmount" FooterStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDepositAmount" runat="server" Text='<%# Eval("DepositAmount") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mobile No" SortExpression="MobileNo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("MobileNo") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Transaction Id" SortExpression="TransactionId">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTransactionId" runat="server" Text='<%# Eval("TransactionId") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Deposit Bank" SortExpression="Type">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDepositBank" runat="server" Text='<%# Eval("DepositBank") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cheque Drawn Bank" SortExpression="ChequeDrawnBank">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblChequeDrawnBank" runat="server" Text='<%# Eval("ChequeDrawnBank") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cheque No" SortExpression="ChequeNo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblChequeNo" runat="server" Text='<%# Eval("ChequeNo") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cheque Issue Date" SortExpression="ChequeIssueDate">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblChequeIssueDate" runat="server" Text='<%# Eval("ChequeIssueDate") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedDate" SortExpression="CreatedDate">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Eval("CreatedDate") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
                &nbsp;
            </td>
        </tr>

        <tr>
            <td width="100%" align="center">
                <div id="divPendingRequest" runat="server" visible="false">
                    <fieldset>
                        <legend runat="server" id="legend1">Pending Request</legend>
                        <table width="100%" align="center">
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                 Name: <strong style="color: Red">*</strong>
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendingReqName" MaxLength="200" runat="server" Width="250px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="rfvPendReqName" runat="server" ControlToValidate="txtPendingReqName"
                                        Display="None" ErrorMessage="Please enter agent name." ValidationGroup="pending"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvPendReqName">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    MobileNo
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendingMobileNo" MaxLength="100" runat="server" Width="250px" ValidationGroup="Register1"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                   <asp:RequiredFieldValidator ID="rfvPendingMobileNo" runat="server" ControlToValidate="txtPendingMobileNo"
                                        Display="None" ErrorMessage="Please enter city." ValidationGroup="pending"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="rfvPendingMobileNo">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>

                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                  Email Id
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendEmailid" MaxLength="100" runat="server" Width="250px" ValidationGroup="Register1"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                   <asp:RequiredFieldValidator ID="rfvPendingEmailId" runat="server" ControlToValidate="txtPendEmailid"
                                        Display="None" ErrorMessage="Please enter city." ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvPendingEmailId">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>

                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Appointment Date:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendAppointDate" MaxLength="50" runat="server" ValidationGroup="Register"></asp:TextBox>
                           
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPendAppointDate">
                                    </asp:CalendarExtender>
                                </td>
                                <td class="labelclass">
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateOfBirth"
                                        Display="Dynamic" ErrorMessage="Please enter date of birth." ValidationGroup="pending"></asp:RequiredFieldValidator>
                                   <asp:ValidatorCalloutExtender ID="vcePendAppointdate" runat="server" TargetControlID="RequiredFieldValidator3"></asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    City:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendingCity" MaxLength="100" runat="server" Width="250px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                             <asp:RequiredFieldValidator ID="rfvPendingcity" runat="server" ControlToValidate="txtPendingCity"
                                        Display="None" ErrorMessage="Please enter city." ValidationGroup="pending"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvPendingcity">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>

                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    State:
                                </td>
                                <td class="labelclass">
                                    <asp:DropDownList ID="ddlPendingState" runat="server" ValidationGroup="Register">
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
                                <td class="labelclass">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlPendingState"
                                        Display="None" ErrorMessage="Please select state." InitialValue="Please Select"
                                        ValidationGroup="pending"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    District:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendingDistrict" MaxLength="100" runat="server" Width="250px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                             <asp:RequiredFieldValidator ID="rfvPendingDistrict" runat="server" ControlToValidate="txtPendingDistrict"
                                        Display="None" ErrorMessage="Please enter city." ValidationGroup="pending"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vcedist" runat="server" TargetControlID="rfvPendingDistrict">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Address:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendingAddress" TextMode="MultiLine" runat="server" Width="300px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                  <asp:RequiredFieldValidator ID="rfvPendingAddress" runat="server" ControlToValidate="txtPendingAddress"
                                        Display="None" ErrorMessage="Please enter address." ValidationGroup="pending"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceAddress" runat="server" TargetControlID="rfvPendingAddress">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Pin Code:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendingPincode" MaxLength="6" runat="server" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPendingPincode"
                                        Display="None" ErrorMessage="Please enter pin code." ValidationGroup="pending"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vcePincode1" runat="server" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>
                                    <%--asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPinCode"
                                        Display="None" ErrorMessage="Please enter only numerics." Operator="DataTypeCheck"
                                        Type="Integer" ValidationGroup="Register"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="CompareValidator2">
                                    </asp:ValidatorCalloutExtender>--%>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPendingPincode" ValidChars="1234567890"></asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Landline No:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="txtPendingLandLineno" MaxLength="12" runat="server" Width="150px" ValidationGroup="Register"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtPendingLandLineno" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    Details:
                                </td>
                                <td class="labelclass">
                                    <asp:TextBox ID="TextBox12" runat="server" TextMode="MultiLine" Width="300px" ValidationGroup="Register"></asp:TextBox>
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            
                            
                            
                            
                            
                            
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    <asp:Button ID="btnPendingRegister" runat="server" Text="Register" 
                                        CssClass="buttonBook" ValidationGroup="pending" Style="cursor: pointer;" 
                                        onclick="btnPendingRegister_Click" />
                                   
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                                <td class="labelclass">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </td>
        </tr>
    </table>
                        </table>
</asp:Content>
