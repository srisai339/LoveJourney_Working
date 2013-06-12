<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="Users.aspx.cs" Inherits="Users_Users" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ExportGridviewtoExcel() {
            __doPostBack("<%=lbtnXport2Xcel.UniqueID %>", '');
        }

        $(document).ready(function () {
            $("[id$='txtSearch']").mouseover(function (event) {

                $("[id$='txtSearch']").addClass("searchBoxHover")
            });
        }
                );
        $(document).ready(function () {
            $("[id$='txtSearch']").mouseout(function (event) {

                $("[id$='txtSearch']").removeClass("searchBoxHover")
            });
        }
                );
        $(document).ready(function () {
            $("[id$='txtSearch']").focusin(function (event) {

                $("[id$='txtSearch']").addClass("searchBoxHover")
            });
        }
                );
       
    </script>
    <style type="text/css">
        .menugv
        {
            background-image: url(../images/modify_menu.jpg);
            background-repeat: no-repeat;
            height: 20px;
        }
        .DDL
        {
            border: 1px solid Blue;
            font-family: Arial;
            font-size: 13px;
            background-color: ActiveBorder;
            color: Black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveUD" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
        <ContentTemplate>
            <table width="900">
                <tr>
                    <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                        runat="server" visible="false">
                        <asp:Label ID="lblMainMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="100%" height="30px" valign="middle" align="left" class="tr" 
                        runat="server" >
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        <asp:MultiView ID="MVUsers" runat="server">
                            <asp:View runat="server">
                                <table width="100%" bgcolor="#ffffff">
                                    <tr>
                                        <td class="heading" align="center" colspan="2">
                                            CSE
                                        </td>
                                        <%--   <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                            font-weight: bold; color: Maroon;">
                                            CSE
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="right" valign="top">
                                            <asp:TextBox ID="txtSearch" CssClass="searchBox" runat="server" />&nbsp;&nbsp;<asp:Button
                                                ID="btnSearch" Text="GO" runat="server" CssClass="buttonBook" ValidationGroup="search"
                                                OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%">
                                            <table width="100%">
                                                <tr>
                                                    <td width="50%" align="left" valign="top">
                                                        Select Page size&nbsp;:&nbsp;
                                                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="Dropdownlist "
                                                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="100px">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="40" Value="1" />
                                                            <asp:ListItem Text="80" Value="2" />
                                                            <asp:ListItem Text="120" Value="3" />
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="50%" align="right">
                                                        <asp:LinkButton ID="lbtnXport2Xcel" Text="Export to Excel" CssClass="qw" runat="server"
                                                            Font-Underline="false" ForeColor="Brown" Font-Bold="true" OnClick="lbtnXport2Xcel_Click"
                                                            OnClientClick="ExportGridviewtoExcel();" />&nbsp;|&nbsp;
                                                        <asp:LinkButton ID="lbtnNewUser" Text="New User" CssClass="qw" runat="server" Font-Underline="false"
                                                            ForeColor="Brown" Font-Bold="true" OnClick="lbtnNewUser_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="right" style="padding-right: 50px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="center">
                                            <asp:GridView ID="GvUsers" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
                                                runat="server" CellPadding="3" EnableModelValidation="True" PageSize="50" EmptyDataText="No Users Added Yet"
                                                OnRowCommand="GvUsers_RowCommand" OnRowEditing="GvUsers_RowEditing" OnRowDataBound="GvUsers_RowDataBound"
                                                OnSorting="GvUsers_Sorting" AllowSorting="True" OnPageIndexChanging="GvUsers_PageIndexChanging"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                                <AlternatingRowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" Visible="false" SortExpression="ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" Text='<%#Eval("ID") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Username" ItemStyle-Width="25%" SortExpression="UserName">
                                                        <%-- <HeaderTemplate>
                                                            <asp:Image ID="ImgUp" ImageUrl="~/images/arrowup.png" runat="server" Visible="true" />
                                                            <asp:Image ID="ImgDown" ImageUrl="~/images/arrowdown.png" runat="server" Visible="false" />&nbsp;
                                                            UserName
                                                        </HeaderTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserName" Text='<%#Eval("UserName") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="25%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="20%" SortExpression="Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" Text='<%#Eval("Name") %>' runat="server" />
                                                            <asp:Label ID="lblPassword" Text='<%#Eval("Password") %>' runat="server" Visible="false" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Role" ItemStyle-Width="15%" SortExpression="Role">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRole" Text='<%#Eval("Role") %>' runat="server" />
                                                            <asp:LinkButton ID="lblRoleID" Text='<%#Eval("Role") %>' runat="server" Visible="false" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="EMailID" ItemStyle-Width="15%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmailId" Text='<%#Eval("EmailId") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="15%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAddress" Text='<%#Eval("Address") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="City" ItemStyle-Width="15%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCity" Text='<%#Eval("City") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="15%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblState" Text='<%#Eval("State") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Country" ItemStyle-Width="15%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCountry" Text='<%#Eval("Country") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PinCode" ItemStyle-Width="15%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPinCode" Text='<%#Eval("PinCode") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MobileNo" ItemStyle-Width="15%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMobileNo" Text='<%#Eval("MobileNo") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="buttonBook" CausesValidation="false"
                                                                CommandArgument='<%#Eval("ID") %>' CommandName="Change" />
                                                            <asp:Button ID="btnDelete" runat="server" CommandName="Remove" Text="Delete" CssClass="buttonBook"
                                                                CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                                            <asp:Button ID="btnPermissions" runat="server" CommandName="Permissions" Text="Permissions"
                                                                CssClass="buttonBook" CausesValidation="false" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                    Height="25px" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="30px" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                    Height="30px" />
                                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" Height="30px" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View runat="server">
                                <table width="100%" cellpadding="0" cellspacing="0" style="background-color:White;">
                                    <tr>
                                        <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                            font-weight: bold; color: Maroon;">
                                            Add Users
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td width="100%" align="left">
                                            Complete the Page below to create a new State
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td width="100%" align="left">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 13px;
                                            font-weight: bold; color: Maroon; padding-left: 360px;">
                                            User Details
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="center">
                                            <table width="60%">
                                                <tr>
                                                    <td width="30%" align="left">
                                                        Username:
                                                    </td>
                                                    <td width="70%" align="left">
                                                        <asp:TextBox ID="txtUsername" CssClass="textfield_2" runat="server" Enabled="true" />
                                                        <asp:RequiredFieldValidator ID="rfvUsername" ErrorMessage="Enter Username" ControlToValidate="txtUsername"
                                                            runat="server" Display="None" ValidationGroup="save" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvUsername">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <%-- <ajax:FilteredTextBoxExtender ID="ftbUsername" runat="server" TargetControlID="txtUsername"
                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789">
                                                        </ajax:FilteredTextBoxExtender>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" align="left">
                                                        Password:
                                                    </td>
                                                    <td width="70%" align="left">
                                                        <asp:TextBox ID="txtPassword" CssClass="textfield_2" runat="server" TextMode="Password" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Password"
                                                            ControlToValidate="txtPassword" runat="server" Display="None" ValidationGroup="save" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" align="left">
                                                        Confirm Password:
                                                    </td>
                                                    <td width="70%" align="left">
                                                        <asp:TextBox ID="txtCnfrmPswd" CssClass="textfield_2" runat="server" TextMode="Password" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Enter Confirm Password"
                                                            ControlToValidate="txtCnfrmPswd" runat="server" Display="None" ValidationGroup="save" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <asp:CompareValidator ID="cmvPassword" ErrorMessage="Password & Confirm password must match"
                                                            ControlToValidate="txtCnfrmPswd" ControlToCompare="txtPassword" runat="server"
                                                            Display="None" ValidationGroup="save" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="cmvPassword">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="35%" class="p_nme">
                                                        EmailId:&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="65%">
                                                        <asp:TextBox ID="txtEmailId" MaxLength="500" runat="server" CssClass="textfield_sleep" />
                                                        <asp:RequiredFieldValidator ID="rfvmailid" runat="server" ControlToValidate="txtEmailId"
                                                            Display="None" ErrorMessage="Please enter your email id." ValidationGroup="save"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="rfvmailid">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId"
                                                            Display="None" ErrorMessage="Please enter correct email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="save"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" align="left">
                                                        Name
                                                    </td>
                                                    <td width="70%" align="left">
                                                        <asp:TextBox ID="txtName" CssClass="textfield_2" runat="server" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Enter Name"
                                                            ControlToValidate="txtName" runat="server" Display="None" ValidationGroup="save" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtName"
                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                                        </ajax:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="p_nme" width="35%">
                                                        MobileNo:&nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="65%">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="textfield_sleep" MaxLength="10"
                                                            ValidationGroup="Submit"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
                                                            Display="None" ErrorMessage="Please enter mobile no." ValidationGroup="save"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceMobileNo" runat="server" TargetControlID="RequiredFieldValidator4">
                                                        </ajax:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNo"
                                                            Display="None" ErrorMessage="Please enter valid mobile no." ValidationGroup="save"
                                                            ValidationExpression="[7-9][0-9]{9}"></asp:RegularExpressionValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceMobileNo1" runat="server" TargetControlID="RegularExpressionValidator2">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="p_nme" width="35%">
                                                        Address:&nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="65%">
                                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="textfield_sleep" TextMode="MultiLine"
                                                            ValidationGroup="save"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAddress"
                                                            Display="None" ErrorMessage="Please enter address." ValidationGroup="save"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceAddress" runat="server" TargetControlID="RequiredFieldValidator8">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="p_nme" width="35%">
                                                        City:&nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="65%">
                                                        <asp:TextBox ID="txtCity" runat="server" CssClass="textfield_sleep" MaxLength="100"
                                                            ValidationGroup="save"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvcity" runat="server" ControlToValidate="txtCity"
                                                            Display="None" ErrorMessage="Please enter city name." ValidationGroup="save"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="rfvcity">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="p_nme" width="35%">
                                                        State:&nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="65%">
                                                        <asp:DropDownList ID="ddlState" runat="server" ValidationGroup="save">
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
                                                        <asp:RequiredFieldValidator ID="rfvstate" runat="server" ControlToValidate="ddlState"
                                                            Display="None" ErrorMessage="Please select state." InitialValue="Please Select"
                                                            ValidationGroup="save"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="rfvstate">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="p_nme" width="35%">
                                                        Country:&nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="65%">
                                                        <asp:DropDownList ID="ddlcountry" runat="server" ValidationGroup="save" Width="200px">
                                                            <asp:ListItem Value="Please Select">Please Select</asp:ListItem>
                                                            <asp:ListItem Value="ABW">Aruba</asp:ListItem>
                                                            <asp:ListItem Value="AFG">Afghanistan</asp:ListItem>
                                                            <asp:ListItem Value="AGO">Angola</asp:ListItem>
                                                            <asp:ListItem Value="AIA">Anguilla</asp:ListItem>
                                                            <asp:ListItem Value="ALA">Åland Islands</asp:ListItem>
                                                            <asp:ListItem Value="ALB">Albania</asp:ListItem>
                                                            <asp:ListItem Value="AND">Andorra</asp:ListItem>
                                                            <asp:ListItem Value="ANT">Netherlands Antilles</asp:ListItem>
                                                            <asp:ListItem Value="ARE">United Arab Emirates</asp:ListItem>
                                                            <asp:ListItem Value="ARG">Argentina</asp:ListItem>
                                                            <asp:ListItem Value="ARM">Armenia</asp:ListItem>
                                                            <asp:ListItem Value="ASM">American Samoa</asp:ListItem>
                                                            <asp:ListItem Value="ATA">Antarctica</asp:ListItem>
                                                            <asp:ListItem Value="ATF">French Southern Territories</asp:ListItem>
                                                            <asp:ListItem Value="ATG">Antigua and Barbuda</asp:ListItem>
                                                            <asp:ListItem Value="AUS">Australia</asp:ListItem>
                                                            <asp:ListItem Value="AUT">Austria</asp:ListItem>
                                                            <asp:ListItem Value="AZE">Azerbaijan</asp:ListItem>
                                                            <asp:ListItem Value="BDI">Burundi</asp:ListItem>
                                                            <asp:ListItem Value="BEL">Belgium</asp:ListItem>
                                                            <asp:ListItem Value="BEN">Benin</asp:ListItem>
                                                            <asp:ListItem Value="BFA">Burkina Faso</asp:ListItem>
                                                            <asp:ListItem Value="BGD">Bangladesh</asp:ListItem>
                                                            <asp:ListItem Value="BGR">Bulgaria</asp:ListItem>
                                                            <asp:ListItem Value="BHR">Bahrain</asp:ListItem>
                                                            <asp:ListItem Value="BHS">Bahamas</asp:ListItem>
                                                            <asp:ListItem Value="BIH">Bosnia and Herzegovina</asp:ListItem>
                                                            <asp:ListItem Value="BLM">Saint Barthélemy</asp:ListItem>
                                                            <asp:ListItem Value="BLR">Belarus</asp:ListItem>
                                                            <asp:ListItem Value="BLZ">Belize</asp:ListItem>
                                                            <asp:ListItem Value="BMU">Bermuda</asp:ListItem>
                                                            <asp:ListItem Value="BOL">Bolivia</asp:ListItem>
                                                            <asp:ListItem Value="BRA">Brazil</asp:ListItem>
                                                            <asp:ListItem Value="BRB">Barbados</asp:ListItem>
                                                            <asp:ListItem Value="BRN">Brunei Darussalam</asp:ListItem>
                                                            <asp:ListItem Value="BTN">Bhutan</asp:ListItem>
                                                            <asp:ListItem Value="BVT">Bouvet Island</asp:ListItem>
                                                            <asp:ListItem Value="BWA">Botswana</asp:ListItem>
                                                            <asp:ListItem Value="CAF">Central African Republic</asp:ListItem>
                                                            <asp:ListItem Value="CAN">Canada</asp:ListItem>
                                                            <asp:ListItem Value="CCK">Cocos (Keeling) Islands</asp:ListItem>
                                                            <asp:ListItem Value="CHE">Switzerland</asp:ListItem>
                                                            <asp:ListItem Value="CHL">Chile</asp:ListItem>
                                                            <asp:ListItem Value="CHN">China</asp:ListItem>
                                                            <asp:ListItem Value="CIV">Côte d`Ivoire</asp:ListItem>
                                                            <asp:ListItem Value="CMR">Cameroon</asp:ListItem>
                                                            <asp:ListItem Value="COD">Congo, the Democratic Republic of the</asp:ListItem>
                                                            <asp:ListItem Value="COG">Congo</asp:ListItem>
                                                            <asp:ListItem Value="COK">Cook Islands</asp:ListItem>
                                                            <asp:ListItem Value="COL">Colombia</asp:ListItem>
                                                            <asp:ListItem Value="COM">Comoros</asp:ListItem>
                                                            <asp:ListItem Value="CPV">Cape Verde</asp:ListItem>
                                                            <asp:ListItem Value="CRI">Costa Rica</asp:ListItem>
                                                            <asp:ListItem Value="CUB">Cuba</asp:ListItem>
                                                            <asp:ListItem Value="CXR">Christmas Island</asp:ListItem>
                                                            <asp:ListItem Value="CYM">Cayman Islands</asp:ListItem>
                                                            <asp:ListItem Value="CYP">Cyprus</asp:ListItem>
                                                            <asp:ListItem Value="CZE">Czech Republic</asp:ListItem>
                                                            <asp:ListItem Value="DEU">Germany</asp:ListItem>
                                                            <asp:ListItem Value="DJI">Djibouti</asp:ListItem>
                                                            <asp:ListItem Value="DMA">Dominica</asp:ListItem>
                                                            <asp:ListItem Value="DNK">Denmark</asp:ListItem>
                                                            <asp:ListItem Value="DOM">Dominican Republic</asp:ListItem>
                                                            <asp:ListItem Value="DZA">Algeria</asp:ListItem>
                                                            <asp:ListItem Value="ECU">Ecuador</asp:ListItem>
                                                            <asp:ListItem Value="EGY">Egypt</asp:ListItem>
                                                            <asp:ListItem Value="ERI">Eritrea</asp:ListItem>
                                                            <asp:ListItem Value="ESH">Western Sahara</asp:ListItem>
                                                            <asp:ListItem Value="ESP">Spain</asp:ListItem>
                                                            <asp:ListItem Value="EST">Estonia</asp:ListItem>
                                                            <asp:ListItem Value="ETH">Ethiopia</asp:ListItem>
                                                            <asp:ListItem Value="FIN">Finland</asp:ListItem>
                                                            <asp:ListItem Value="FJI">Fiji</asp:ListItem>
                                                            <asp:ListItem Value="FLK">Falkland Islands (Malvinas)</asp:ListItem>
                                                            <asp:ListItem Value="FRA">France</asp:ListItem>
                                                            <asp:ListItem Value="FRO">Faroe Islands</asp:ListItem>
                                                            <asp:ListItem Value="FSM">Micronesia, Federated States of</asp:ListItem>
                                                            <asp:ListItem Value="GAB">Gabon</asp:ListItem>
                                                            <asp:ListItem Value="GBR">United Kingdom</asp:ListItem>
                                                            <asp:ListItem Value="GEO">Georgia</asp:ListItem>
                                                            <asp:ListItem Value="GGY">Guernsey</asp:ListItem>
                                                            <asp:ListItem Value="GHA">Ghana</asp:ListItem>
                                                            <asp:ListItem Value="GI">N Guinea</asp:ListItem>
                                                            <asp:ListItem Value="GIB">Gibraltar</asp:ListItem>
                                                            <asp:ListItem Value="GLP">Guadeloupe</asp:ListItem>
                                                            <asp:ListItem Value="GMB">Gambia</asp:ListItem>
                                                            <asp:ListItem Value="GNB">Guinea-Bissau</asp:ListItem>
                                                            <asp:ListItem Value="GNQ">Equatorial Guinea</asp:ListItem>
                                                            <asp:ListItem Value="GRC">Greece</asp:ListItem>
                                                            <asp:ListItem Value="GRD">Grenada</asp:ListItem>
                                                            <asp:ListItem Value="GRL">Greenland</asp:ListItem>
                                                            <asp:ListItem Value="GTM">Guatemala</asp:ListItem>
                                                            <asp:ListItem Value="GUF">French Guiana</asp:ListItem>
                                                            <asp:ListItem Value="GUM">Guam</asp:ListItem>
                                                            <asp:ListItem Value="GUY">Guyana</asp:ListItem>
                                                            <asp:ListItem Value="HKG">Hong Kong</asp:ListItem>
                                                            <asp:ListItem Value="HMD">Heard Island and McDonald Islands</asp:ListItem>
                                                            <asp:ListItem Value="HND">Honduras</asp:ListItem>
                                                            <asp:ListItem Value="HRV">Croatia</asp:ListItem>
                                                            <asp:ListItem Value="HTI">Haiti</asp:ListItem>
                                                            <asp:ListItem Value="HUN">Hungary</asp:ListItem>
                                                            <asp:ListItem Value="IDN">Indonesia</asp:ListItem>
                                                            <asp:ListItem Value="IMN">Isle of Man</asp:ListItem>
                                                            <asp:ListItem Value="IND">India</asp:ListItem>
                                                            <asp:ListItem Value="IOT">British Indian Ocean Territory</asp:ListItem>
                                                            <asp:ListItem Value="IRL">Ireland</asp:ListItem>
                                                            <asp:ListItem Value="IRN">Iran, Islamic Republic of</asp:ListItem>
                                                            <asp:ListItem Value="IRQ">Iraq</asp:ListItem>
                                                            <asp:ListItem Value="ISL">Iceland</asp:ListItem>
                                                            <asp:ListItem Value="ISR">Israel</asp:ListItem>
                                                            <asp:ListItem Value="ITA">Italy</asp:ListItem>
                                                            <asp:ListItem Value="JAM">Jamaica</asp:ListItem>
                                                            <asp:ListItem Value="JEY">Jersey</asp:ListItem>
                                                            <asp:ListItem Value="JOR">Jordan</asp:ListItem>
                                                            <asp:ListItem Value="JPN">Japan</asp:ListItem>
                                                            <asp:ListItem Value="KAZ">Kazakhstan</asp:ListItem>
                                                            <asp:ListItem Value="KEN">Kenya</asp:ListItem>
                                                            <asp:ListItem Value="KGZ">Kyrgyzstan</asp:ListItem>
                                                            <asp:ListItem Value="KHM">Cambodia</asp:ListItem>
                                                            <asp:ListItem Value="KIR">Kiribati</asp:ListItem>
                                                            <asp:ListItem Value="KNA">Saint Kitts and Nevis</asp:ListItem>
                                                            <asp:ListItem Value="KOR">Korea, Republic of</asp:ListItem>
                                                            <asp:ListItem Value="KWT">Kuwait</asp:ListItem>
                                                            <asp:ListItem Value="LAO">Lao People`s Democratic Republic</asp:ListItem>
                                                            <asp:ListItem Value="LBN">Lebanon</asp:ListItem>
                                                            <asp:ListItem Value="LBR">Liberia</asp:ListItem>
                                                            <asp:ListItem Value="LBY">Libyan Arab Jamahiriya</asp:ListItem>
                                                            <asp:ListItem Value="LCA">Saint Lucia</asp:ListItem>
                                                            <asp:ListItem Value="LIE">Liechtenstein</asp:ListItem>
                                                            <asp:ListItem Value="LKA">Sri Lanka</asp:ListItem>
                                                            <asp:ListItem Value="LSO">Lesotho</asp:ListItem>
                                                            <asp:ListItem Value="LTU">Lithuania</asp:ListItem>
                                                            <asp:ListItem Value="LUX">Luxembourg</asp:ListItem>
                                                            <asp:ListItem Value="LVA">Latvia</asp:ListItem>
                                                            <asp:ListItem Value="MAC">Macao</asp:ListItem>
                                                            <asp:ListItem Value="MAF">Saint Martin (French part)</asp:ListItem>
                                                            <asp:ListItem Value="MAR">Morocco</asp:ListItem>
                                                            <asp:ListItem Value="MCO">Monaco</asp:ListItem>
                                                            <asp:ListItem Value="MDA">Moldova</asp:ListItem>
                                                            <asp:ListItem Value="MDG">Madagascar</asp:ListItem>
                                                            <asp:ListItem Value="MDV">Maldives</asp:ListItem>
                                                            <asp:ListItem Value="MEX">Mexico</asp:ListItem>
                                                            <asp:ListItem Value="MHL">Marshall Islands</asp:ListItem>
                                                            <asp:ListItem Value="MKD">Macedonia, the former Yugoslav Republic of</asp:ListItem>
                                                            <asp:ListItem Value="MLI">Mali</asp:ListItem>
                                                            <asp:ListItem Value="MLT">Malta</asp:ListItem>
                                                            <asp:ListItem Value="MMR">Myanmar</asp:ListItem>
                                                            <asp:ListItem Value="MNE">Montenegro</asp:ListItem>
                                                            <asp:ListItem Value="MNG">Mongolia</asp:ListItem>
                                                            <asp:ListItem Value="MNP">Northern Mariana Islands</asp:ListItem>
                                                            <asp:ListItem Value="MOZ">Mozambique</asp:ListItem>
                                                            <asp:ListItem Value="MRT">Mauritania</asp:ListItem>
                                                            <asp:ListItem Value="MSR">Montserrat</asp:ListItem>
                                                            <asp:ListItem Value="MTQ">Martinique</asp:ListItem>
                                                            <asp:ListItem Value="MUS">Mauritius</asp:ListItem>
                                                            <asp:ListItem Value="MWI">Malawi</asp:ListItem>
                                                            <asp:ListItem Value="MYS">Malaysia</asp:ListItem>
                                                            <asp:ListItem Value="MYT">Mayotte</asp:ListItem>
                                                            <asp:ListItem Value="NAM">Namibia</asp:ListItem>
                                                            <asp:ListItem Value="NCL">New Caledonia</asp:ListItem>
                                                            <asp:ListItem Value="NER">Niger</asp:ListItem>
                                                            <asp:ListItem Value="NFK">Norfolk Island</asp:ListItem>
                                                            <asp:ListItem Value="NGA">Nigeria</asp:ListItem>
                                                            <asp:ListItem Value="NIC">Nicaragua</asp:ListItem>
                                                            <asp:ListItem Value="NO">R Norway</asp:ListItem>
                                                            <asp:ListItem Value="NIU">Niue</asp:ListItem>
                                                            <asp:ListItem Value="NLD">Netherlands</asp:ListItem>
                                                            <asp:ListItem Value="NPL">Nepal</asp:ListItem>
                                                            <asp:ListItem Value="NRU">Nauru</asp:ListItem>
                                                            <asp:ListItem Value="NZL">New Zealand</asp:ListItem>
                                                            <asp:ListItem Value="OMN">Oman</asp:ListItem>
                                                            <asp:ListItem Value="PAK">Pakistan</asp:ListItem>
                                                            <asp:ListItem Value="PAN">Panama</asp:ListItem>
                                                            <asp:ListItem Value="PCN">Pitcairn</asp:ListItem>
                                                            <asp:ListItem Value="PER">Peru</asp:ListItem>
                                                            <asp:ListItem Value="PHL">Philippines</asp:ListItem>
                                                            <asp:ListItem Value="PLW">Palau</asp:ListItem>
                                                            <asp:ListItem Value="PNG">Papua New Guinea</asp:ListItem>
                                                            <asp:ListItem Value="POL">Poland</asp:ListItem>
                                                            <asp:ListItem Value="PRI">Puerto Rico</asp:ListItem>
                                                            <asp:ListItem Value="PRK">Korea, Democratic People`s Republic of</asp:ListItem>
                                                            <asp:ListItem Value="PRT">Portugal</asp:ListItem>
                                                            <asp:ListItem Value="PRY">Paraguay</asp:ListItem>
                                                            <asp:ListItem Value="PSE">Palestinian Territory, Occupied</asp:ListItem>
                                                            <asp:ListItem Value="PYF">French Polynesia</asp:ListItem>
                                                            <asp:ListItem Value="QAT">Qatar</asp:ListItem>
                                                            <asp:ListItem Value="REU">Réunion</asp:ListItem>
                                                            <asp:ListItem Value="ROU">Romania</asp:ListItem>
                                                            <asp:ListItem Value="RUS">Russian Federation</asp:ListItem>
                                                            <asp:ListItem Value="RWA">Rwanda</asp:ListItem>
                                                            <asp:ListItem Value="SAU">Saudi Arabia</asp:ListItem>
                                                            <asp:ListItem Value="SDN">Sudan</asp:ListItem>
                                                            <asp:ListItem Value="SEN">Senegal</asp:ListItem>
                                                            <asp:ListItem Value="SGP">Singapore</asp:ListItem>
                                                            <asp:ListItem Value="SGS">South Georgia and the South Sandwich Islands</asp:ListItem>
                                                            <asp:ListItem Value="SHN">Saint Helena</asp:ListItem>
                                                            <asp:ListItem Value="SJM">Svalbard and Jan Mayen</asp:ListItem>
                                                            <asp:ListItem Value="SLB">Solomon Islands</asp:ListItem>
                                                            <asp:ListItem Value="SLE">Sierra Leone</asp:ListItem>
                                                            <asp:ListItem Value="SLV">El Salvador</asp:ListItem>
                                                            <asp:ListItem Value="SMR">San Marino</asp:ListItem>
                                                            <asp:ListItem Value="SOM">Somalia</asp:ListItem>
                                                            <asp:ListItem Value="SPM">Saint Pierre and Miquelon</asp:ListItem>
                                                            <asp:ListItem Value="SRB">Serbia</asp:ListItem>
                                                            <asp:ListItem Value="STP">Sao Tome and Principe</asp:ListItem>
                                                            <asp:ListItem Value="SUR">Suriname</asp:ListItem>
                                                            <asp:ListItem Value="SVK">Slovakia</asp:ListItem>
                                                            <asp:ListItem Value="SVN">Slovenia</asp:ListItem>
                                                            <asp:ListItem Value="SWE">Sweden</asp:ListItem>
                                                            <asp:ListItem Value="SWZ">Swaziland</asp:ListItem>
                                                            <asp:ListItem Value="SYC">Seychelles</asp:ListItem>
                                                            <asp:ListItem Value="SYR">Syrian Arab Republic</asp:ListItem>
                                                            <asp:ListItem Value="TCA">Turks and Caicos Islands</asp:ListItem>
                                                            <asp:ListItem Value="TCD">Chad</asp:ListItem>
                                                            <asp:ListItem Value="TGO">Togo</asp:ListItem>
                                                            <asp:ListItem Value="THA">Thailand</asp:ListItem>
                                                            <asp:ListItem Value="TJK">Tajikistan</asp:ListItem>
                                                            <asp:ListItem Value="TKL">Tokelau</asp:ListItem>
                                                            <asp:ListItem Value="TKM">Turkmenistan</asp:ListItem>
                                                            <asp:ListItem Value="TLS">Timor-Leste</asp:ListItem>
                                                            <asp:ListItem Value="TON">Tonga</asp:ListItem>
                                                            <asp:ListItem Value="TTO">Trinidad and Tobago</asp:ListItem>
                                                            <asp:ListItem Value="TUN">Tunisia</asp:ListItem>
                                                            <asp:ListItem Value="TUR">Turkey</asp:ListItem>
                                                            <asp:ListItem Value="TUV">Tuvalu</asp:ListItem>
                                                            <asp:ListItem Value="TWN">Taiwan, Province of China</asp:ListItem>
                                                            <asp:ListItem Value="TZA">Tanzania, United Republic of</asp:ListItem>
                                                            <asp:ListItem Value="UGA">Uganda</asp:ListItem>
                                                            <asp:ListItem Value="UKR">Ukraine</asp:ListItem>
                                                            <asp:ListItem Value="UMI">United States Minor Outlying Islands</asp:ListItem>
                                                            <asp:ListItem Value="URY">Uruguay</asp:ListItem>
                                                            <asp:ListItem Value="USA">United States</asp:ListItem>
                                                            <asp:ListItem Value="UZB">Uzbekistan</asp:ListItem>
                                                            <asp:ListItem Value="VAT">Holy See (Vatican City State)</asp:ListItem>
                                                            <asp:ListItem Value="VCT">Saint Vincent and the Grenadines</asp:ListItem>
                                                            <asp:ListItem Value="VEN">Venezuela</asp:ListItem>
                                                            <asp:ListItem Value="VGB">Virgin Islands, British</asp:ListItem>
                                                            <asp:ListItem Value="VIR">Virgin Islands, U.S.</asp:ListItem>
                                                            <asp:ListItem Value="VNM">Viet Nam</asp:ListItem>
                                                            <asp:ListItem Value="VUT">Vanuatu</asp:ListItem>
                                                            <asp:ListItem Value="WLF">Wallis and Futuna</asp:ListItem>
                                                            <asp:ListItem Value="WSM">Samoa</asp:ListItem>
                                                            <asp:ListItem Value="YEM">Yemen</asp:ListItem>
                                                            <asp:ListItem Value="ZAF">South Africa</asp:ListItem>
                                                            <asp:ListItem Value="ZMB">Zambia</asp:ListItem>
                                                            <asp:ListItem Value="ZWE">Zimbabwe</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlcountry"
                                                            Display="None" ErrorMessage="Please select Country." InitialValue="Please Select"
                                                            ValidationGroup="save"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vceCountry1" TargetControlID="RequiredFieldValidator7"
                                                            runat="server">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="p_nme" width="35%">
                                                        PinCode:&nbsp;
                                                    </td>
                                                    <td align="left" height="34" width="65%">
                                                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="textfield_sleep" MaxLength="500"
                                                            ValidationGroup="Submit"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvpincode" runat="server" ControlToValidate="txtPinCode"
                                                            Display="None" ErrorMessage="Please enter Pincode." ValidationGroup="save"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="vcePoncode" runat="server" TargetControlID="rfvpincode">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" align="center">
                                                        <%-- Role--%>
                                                    </td>
                                                    <td width="70%" align="left">
                                                        <asp:DropDownList ID="ddlRole" runat="server" Visible="false">
                                                            <asp:ListItem Text="CSE" Value="CSE"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Select Role"
                                                            InitialValue="--Select--" ControlToValidate="ddlRole" runat="server" Display="None"
                                                            ValidationGroup="save" />
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" align="center">
                                                        <asp:Label ID="lblID" runat="server" Visible="false" />
                                                    </td>
                                                    <td width="70%" align="left">
                                                        <asp:Button ID="btnSaveUD" Text="Save" runat="server" CssClass="buttonBook" ValidationGroup="save"
                                                            OnClick="btnSaveUD_Click" />
                                                        <asp:Button ID="btnUpdateUD" Text="Update" runat="server" CssClass="buttonBook" ValidationGroup="save"
                                                            OnClick="btnUpdateUD_Click" />&nbsp;
                                                        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="buttonBook" CausesValidation="false"
                                                            OnClick="btnCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View runat="server">
                                <table width="100%" cellpadding="0" cellspacing="0" style="background-color:White;">
                                    <tr>
                                        <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 16px;
                                            font-weight: bold; color: Maroon;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left" style="text-align: left; font-family: Verdana; font-size: 13px;
                                            font-weight: bold; color: Maroon;">
                                            Set Permissions
                                        </td>
                                    </tr>
                                    <%--   <tr id="td11" runat="server">
                                        <td width="100%" align="center">
                                            <asp:Label ID="lbltype" runat="server" Text="Type :"></asp:Label>
                                            &nbsp;<asp:DropDownList ID="ddltype" runat="server" Width="150px">
                                                <asp:ListItem Text="Please Select" Value="Please Select"></asp:ListItem>
                                                <asp:ListItem Text="Buses" Value="Buses"></asp:ListItem>
                                                <asp:ListItem Text="Hotel" Value="Hotel"></asp:ListItem>
                                                <asp:ListItem Text="Flights" Value="Flights"></asp:ListItem>
                                                <asp:ListItem Text="Recharge" Value="Recharge"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvtype" runat="server" ControlToValidate="ddltype" InitialValue="Please Select" ErrorMessage="Please Select Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td width="100%" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td width="50%" align="left">
                                                        Role&nbsp;:&nbsp;<asp:Label ID="lblRolePer" runat="server" Font-Bold="true" />
                                                    </td>
                                                    <td width="50%" align="right">
                                                        UserName&nbsp;:&nbsp;<asp:Label ID="lblUserNamePer" runat="server" Font-Bold="true" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td  align="right">
                                                        <asp:Label ID="lblservice" runat="server" Text="Belongs To :  "></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlservice" runat="server" AutoPostBack="true"
                                                            onselectedindexchanged="ddlservice_SelectedIndexChanged">
                                                            <asp:ListItem Text="Bus" Value="Bus"></asp:ListItem>
                                                            <asp:ListItem Text="Flights" Value="Flights"></asp:ListItem>
                                                            <asp:ListItem Text="Hotels" Value="Hotels"></asp:ListItem>
                                                            <asp:ListItem Text="Recharge" Value="Recharge"></asp:ListItem>
                                                            <asp:ListItem Text="Common" Value="Common"></asp:ListItem>
                                                            <asp:ListItem Text="ALL" Value="ALL" Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            &nbsp;<asp:Label ID="lblUserID" runat="server" Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" align="left">
                                            <asp:GridView ID="GvPermissions" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
                                                runat="server" ShowHeader="true" CellPadding="3" EnableModelValidation="True"
                                                PageSize="50" EmptyDataText="No Screens toset Permissions.." OnRowDataBound="GvPermissions_RowDataBound"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                GridLines="None">
                                                <AlternatingRowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblScreenID" Text='<%#Eval("ScreenID") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkAdd" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="15%" HeaderText="ScreenName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblScreenName" Text='<%#Eval("ScreenName") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Belongs To">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltypegv" Text='<%#Eval("Type") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <%--  <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkEdit" Text="Edit" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkView" Text="View" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkDelete" Text="Delete" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permissions" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkPermissions" Text="Permissions" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reports" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkReports" Text="Reports" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" Height="30px" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                    Height="30px" />
                                                <EmptyDataRowStyle ForeColor="Maroon" HorizontalAlign="Center" Height="30px" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left" style="padding-left: 300px;">
                                            <asp:Button Text="Save" runat="server" ID="btnSavePermissions" CssClass="buttonBook"
                                                OnClick="btnSavePermissions_Click" />
                                            &nbsp;<asp:Button Text="Cancel" runat="server" ID="btnCancelPermissions" CssClass="buttonBook"
                                                OnClick="btnCancelPermissions_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
