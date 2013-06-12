<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="EmpRequests.aspx.cs" Inherits="Users_Bus_EmpRequests" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%">
        <tr>
            <td width="100%" height="30px" valign="middle" align="center" class="tr" id="tdmsg"
                runat="server" visible="false">
                <asp:Label ID="lblMainMsg" runat="server" ></asp:Label>
            </td>
        </tr>
    </table>
            <asp:Panel ID="pnlMain" runat="server">

    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Green"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" class="heading" align="center" >
               
                  <h3 style="width: 948px"> Emp Requests</h3>
                  
            </td>
        </tr>
        <%--<tr>
                                    <td width="100%" align="right" valign="top" class="busoperator_text_head">
                                        <asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                                            ID="btnSearch" Text="GO" runat="server" CssClass="buttonBook" 
                                            ValidationGroup="search" 
                                             />
                                    </td>
                                </tr>--%>
                                <%--<tr>
                                    <td width="100%" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td width="50%" align="left" valign="top">
                                                    <asp:Label ID="lblSelectpage" Text="Select Page Size" runat="server"></asp:Label>&nbsp;:&nbsp;
                                                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
                                                        CssClass="DDL" >
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <asp:ListItem Text="200" Value="1" />
                                                        <asp:ListItem Text="400" Value="2" />
                                                        <asp:ListItem Text="600" Value="3" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50%" align="right">
                                                    <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                        Font-Underline="false" ForeColor="Brown" Font-Bold="true" 
                                                        OnClientClick="ExportGridviewtoExcel();" 
                                                         />&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>--%>
        <tr>
            <td>
                <div>
                   
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvAgentRequests" runat="server" AllowPaging="True"  DataKeyNames="FilePath,DocPath"
                                    Width="100%" AutoGenerateColumns="false" PageSize="100" 
                                    onrowediting="gvAgentRequests_RowEditing" 
                                    onrowcommand="gvAgentRequests_RowCommand" onrowdatabound="gvAgentRequests_RowDataBound"
                                    >
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="25" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                      
                                      <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="EmailId" HeaderText="EmailId" />
                                       
                                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                         <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:BoundField DataField="City" HeaderText="City" />
                                         <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                                       
                                        <asp:BoundField DataField="State" HeaderText="State" />
                                       
                                        <%-- <asp:BoundField DataField="FilePath" HeaderText="Resume" />
                                          <asp:BoundField DataField="DocPath" HeaderText="Document" />--%>
                                           <asp:BoundField DataField="Qualification" HeaderText="Qualification" />

                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                           <asp:LinkButton ID="lnkDownload" runat="server" Text="Download Resume" OnClick="lnkDownload_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%"></ItemStyle>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                           <asp:LinkButton ID="lnkDownload1" runat="server" Text="Download Doc" OnClick="lnkDownload1_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                           <%--<asp:LinkButton ID="lnkRegister" runat="server" Text="Register"    ></asp:LinkButton>--%>
                                                           <asp:Button ID="lnkRegister" runat="server" Text="Register" CssClass="buttonBook" CommandArgument='<%#Eval("Id") %>' CommandName="Register" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%"></ItemStyle>
                                                    </asp:TemplateField>
                                                   
                                                   <asp:TemplateField HeaderText="Status" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                        <asp:Label ID="lblrc" Text='<%#Eval("Rc") %>' runat="server" CssClass="text" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%"></ItemStyle>
                                                    </asp:TemplateField>
                                                   

                                    </Columns>
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </div>

                
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    </asp:Panel>

    <asp:Button ID="btnid" runat="server" Text="id" Visible="true" />

    <asp:ModalPopupExtender ID="mp3" runat="server" PopupControlID="pnl" TargetControlID="btnid"
        X="200" Y="80" BackgroundCssClass="loadingBackground" OkControlID="btnMsg1">
          
</asp:ModalPopupExtender>
   <asp:Panel ID="pnl" runat="server"  Style="display: none; color: Black; border: 5px solid #3e6cc4; border-radius:5px; -moz-border-radius:5px; "
align="center">
       <table width="900" bgcolor="#ffffff"   height="100">
        <tr><td align="right" valign="top"><asp:Button ID="btnMsg1" runat="server" Text="X" CssClass="buttonclose"/></td></tr>
        <tr><td>&nbsp;</td></tr>
       
            <tr>
                <td align="center">
                  <table width="100%" cellpadding="0" cellspacing="0">
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
                                   

                                    <asp:DropDownList ID="ddlBSD" runat="server" ValidationGroup="Register">
                                       <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Agent</asp:ListItem>
                                        <asp:ListItem>Employee</asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </td>
                                <td class="labelclass">
                                    <asp:RequiredFieldValidator ID="rfvddlRole" runat="server" ControlToValidate="ddlBSD"
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
                            <tr id="dob" runat="server" visible="false">
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
                            <tr id="dist" runat="server" visible="false">
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
                            <tr id="altermobile" runat="server" visible="false">
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
                            <tr id="lln" runat="server" visible="false">
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
                            <tr id="pan" runat="server" visible="false">
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
                            <tr id="det" runat="server" visible="false">
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
                                    <asp:Button ID="btnRegister" runat="server" Text="Register" 
                                        CssClass="buttonBook" ValidationGroup="Register" Style="cursor: pointer;" 
                                        onclick="btnRegister_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Back" Style="cursor: pointer;"
                                        CssClass="buttonBook" Visible="false" />
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
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
         
            
            <tr><td>&nbsp;</td></tr>
        </table>
    </asp:Panel>


</asp:Content>

