<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="AgentLogin.aspx.cs" Inherits="AgentLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphSearch" runat="Server">

    <script type="text/javascript" language="javascript">
        function chkAgeDate(source, args) {
            if (document.getElementById('ctl00_cphSearch_txtDOB').value.trim() != '') {
                var dob = document.getElementById('ctl00_cphSearch_txtDOB').value;
                var input = dob;
                var dayfield = input.split("/")[0];
                var monthfield = input.split("/")[1];
                var yearfield = input.split("/")[2];
                var dayobj = new Date(yearfield, monthfield - 1, dayfield);
                var today = new Date();
                var nowyear = today.getFullYear() - 15;
                if (yearfield > nowyear) {
                    //                    document.getElementById('ctl00_cphSearch_txtDOB').value = "";
                    args.IsValid = false;
                    return;

                }
            }
        }
    </script>
    <table width="900" border="0" cellspacing="0" cellpadding="0" style="background-color: White;">
        <tr>
            <td align="left" valign="top">
                <table align="center">
                   
                    <tr>
                        <td align="center">
                            <asp:Panel ID="AgentPanel" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td align="center" class="a_hding" valign="middle" width="100%" colspan="3">
                                                        <asp:Label ID="lblHead" runat="server" Text="Agents/Distributors Login"></asp:Label>
                                                    </td>
                                                </tr>
                                             
                                                <tr>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr id="trCCode" runat="server">
                                                    <td align="right" class="aclass" valign="bottom">
                                                        Email ID:
                                                    </td>
                                                    <td align="left" valign="bottom">
                                                        <asp:TextBox ID="txtEmailID" runat="server" CausesValidation="false" CssClass="i2s_jp_seats"
                                                            TabIndex="1" ValidationGroup="Submit" Width="180px"></asp:TextBox>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender22" runat="server"
                                                            TargetControlID="txtEmailID" WatermarkText="Email Address">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" TargetControlID="rfvEmail" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" TargetControlID="RevEmail" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmailID"
                                                            Display="None" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="i2s_TextBold" valign="bottom">
                                                        <asp:Label ID="lblPassword" runat="server" ForeColor="Black" Text="Password: "></asp:Label>
                                                        &nbsp;</td>
                                                    <td align="left" valign="bottom">
                                                        <asp:TextBox ID="txtPassword" runat="server" CausesValidation="false" CssClass="i2s_jp_seats"
                                                            TabIndex="2" TextMode="Password" ValidationGroup="Submit" Width="180px"></asp:TextBox>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtwaterPassword" runat="server" TargetControlID="txtPassword"
                                                            WatermarkText="Password">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                                            Display="None" ErrorMessage="*" ValidationGroup="LoginBus"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" TargetControlID="rfvPassword" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="i2s_jp_status4" OnClick="btnSubmit_Click"
                                                            TabIndex="3" Text="Submit" ValidationGroup="Submit" />
                                                        <asp:Label ID="lblPWD" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblMessage" runat="server" CssClass="i2s_TextBold"></asp:Label>
                                                        <br />
                                                        <asp:RegularExpressionValidator ID="RevEmail" runat="server" 
                                                            ControlToValidate="txtEmailID" Display="None" 
                                                            ErrorMessage="Please enter valid email address&lt;br /&gt; format is abc@yahoo.com" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                            ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" valign="top">
                                                        <asp:LinkButton ID="lnkbtnForgotPassword" runat="server" ForeColor="#3399ff" OnClick="lnkbtnForgotPassword_Click"
                                                            Text="Forgot Password?"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table id="pnlContact" runat="server" align="right" border="0" cellpadding="0" cellspacing="3"
                                                class="sing_innr_txt" visible="true" width="100%">
                                                <tr>
                                                    <td align="center" class="a_hding" colspan="6" valign="middle" width="100%">
                                                        <asp:Label ID="lblRegistration" runat="server" Text="Agent/Distributors Registration"></asp:Label>
                                                    </td>
                                                </tr>
                                            
                                                <tr id="trUserID" runat="server" visible="false">
                                                    <td align="right" class="aclass">
                                                        User ID
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lblUserID" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                    <tr align="left">
                                                    <td align="char" class="aclass" valign="middle">
                                                        Type <span style="color: Red">*</span>
                                                    </td>
                                                    <td align="left" class="style1" valign="middle">
                                                        <asp:DropDownList ID="ddltype" runat="server" CausesValidation="true" CssClass="i2s_jp_seats"
                                                            TabIndex="4" Width="150px">
                                                            <asp:ListItem Text="Please Select" Value="Please Select"></asp:ListItem>
                                                            <asp:ListItem Text="Distributor" Value="DB"></asp:ListItem>
                                                            <asp:ListItem Text="Agent" Value="AG"></asp:ListItem>
                                                          
                                                        </asp:DropDownList>
                                                       <%-- <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="CompareValidator2"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddltype"
                                                            Display="None" ErrorMessage="Please select Type" Operator="NotEqual" Type="Integer"
                                                            ValidationGroup="Register" ValueToCompare="0"></asp:CompareValidator>--%>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="rfvddltype"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvddltype" runat="server" ControlToValidate="ddltype" InitialValue="Please Select"
                                                            Display="None" ErrorMessage="Please Select Type" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                     <td>&nbsp;
                                                    </td>
                                                  
                                                </tr>
                                                <tr align="left">
                                                    <td align="left" class="aclass" valign="middle">
                                                        Title <span style="color: Red">*</span>
                                                    </td>
                                                    <td align="left" class="style1" valign="middle">
                                                        <asp:DropDownList ID="ddlTitle" runat="server" CausesValidation="true" CssClass="i2s_jp_seats"
                                                            TabIndex="4" Width="150px">
                                                            <asp:ListItem Text="Title" Value="Please select"></asp:ListItem>
                                                            <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Mrs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Ms" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Dr" Value="4"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="RequiredFieldValidator1"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTitle" InitialValue="Please select"
                                                            Display="None" ErrorMessage="*" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="left" class="aclass">
                                                        EmailID:<span style="color: Red">*</span>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtEmailIDAgent" runat="server" CausesValidation="true" CssClass="i2s_jp_seats"
                                                            TabIndex="5" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                            TargetControlID="txtEmailIDAgent" WatermarkText="Email Address">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="rfvEmail1"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="RevEmail1"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvEmail1" runat="server" ControlToValidate="txtEmailIDAgent"
                                                            Display="None" ErrorMessage="Please enter email address" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RevEmail1" runat="server" ControlToValidate="txtEmailIDAgent"
                                                            Display="None" ErrorMessage="Please enter valid email address&lt;br /&gt; format is abc@yahoo.com"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>
                                                        <asp:LinkButton ID="lnkBtnCheckUser" runat="server" CausesValidation="false" CssClass="menutext" Font-Size="10px"
                                                            ForeColor="DarkOrange" OnClick="lBtnCheckUser_Click">Check Email availability</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="aclass" height="30" valign="middle">
                                                        First Name <strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="left" class="style1" valign="middle">
                                                        <asp:TextBox ID="txtFirstName" runat="server" CausesValidation="True" CssClass="i2s_jp_seats"
                                                            TabIndex="6" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName"
                                                            WatermarkText="First Name">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" TargetControlID="rfvFirstName" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                            Display="None" ErrorMessage="Please enter first name" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbefirstname" runat="server" TargetControlID = "txtFirstName" ValidChars ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                    <td align="left" class="aclass" valign="middle">
                                                        LastName<span style="color: Red">*</span>
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        <asp:TextBox ID="txtLastName" runat="server" CausesValidation="True" CssClass="i2s_jp_seats"
                                                            TabIndex="7" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                                        <br />
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server"
                                                            TargetControlID="txtLastName" WatermarkText="Last Name">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="rfvLastName"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                                                            Display="None" ErrorMessage="Please enter Last name" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID = "txtFirstName" ValidChars ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="aclass" style="width: 20%" valign="top">
                                                        Date of Birth<span style="color: Red">*</span>
                                                    </td>
                                                    <td align="left" class="style1" valign="top">
                                                        <asp:TextBox ID="txtDOB" runat="server" CausesValidation="True" CssClass="i2s_jp_seats"
                                                            OnTextChanged="txtDOB_TextChanged" TabIndex="8" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtwmeDOB" runat="server" TargetControlID="txtDOB"
                                                            WatermarkText="MM/DD/YYYY">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <ajaxToolkit:CalendarExtender ID="ceDoj" runat="server" Format="MM/dd/yyyy" PopupPosition="Right"
                                                            TargetControlID="txtDOB">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vceDOB" runat="server" CloseImageUrl="~/images/Closing.png"
                                                            TargetControlID="rfvDOB" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                                                            Display="None" ErrorMessage="Please enter Date of birth" Font-Size="11px" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
                                                            Display="None" ErrorMessage="Please enter valid Date, Format (mm/dd/yyyy)" Font-Size="11px"
                                                            ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$"
                                                            ValidationGroup="Register"></asp:RegularExpressionValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender34" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" TargetControlID="revDOB" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txtDOB"
                                                            ValidChars="0123456789/">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                       <%-- <asp:CustomValidator ID="cvDOB" ClientValidationFunction="chkAgeDate" runat="server"
                                                            ControlToValidate="txtDOB" Display="None" SetFocusOnError="true" ErrorMessage="Age cannot be less than 15 years."
                                                            ValidationGroup="Register">
                                                        </asp:CustomValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcedobchk" runat="server" TargetControlID="cvDOB"
                                                            Width="200px" CloseImageUrl="~/images/Closing.png" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>--%>
                                                    </td>
                                                    <td align="left" class="aclass" style="width: 20%">
                                                        Country<span style="color: Red">*</span>
                                                    </td>
                                                    <td align="left" height="24">
                                                        <asp:DropDownList ID="ddlCountry" runat="server" class="i2s_jp_seats" ValidationGroup="Register" TabIndex="9"
                                                            Width="150px" Height="20px">
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
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender38" runat="server"
                                                            TargetControlID="rfvddlCountry" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvddlCountry" runat="server" ControlToValidate="ddlCountry"
                                                            ErrorMessage="Please select Country" Display="None" ForeColor="Red" Font-Size="11px"
                                                            InitialValue="Please Select" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <%--<td align="left" class="style1">
                                                     
                                                        <asp:TextBox ID="ddlCountry" runat="server" CausesValidation="True" CssClass="i2s_jp_seats"
                                                            TabIndex="9" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                               
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vceddlCountry" runat="server" CloseImageUrl="~/images/Closing.png"
                                                            PopupPosition="Left" TargetControlID="rfvddlCountry" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvddlCountry" runat="server" ControlToValidate="ddlCountry"
                                                            Display="None" ErrorMessage="Please Select Country" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="aclass" valign="middle">
                                                       Pin Code<span style="color: Red">*</span>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtPinCode" runat="server" CausesValidation="True" CssClass="i2s_jp_seats"
                                                            MaxLength="6" TabIndex="10" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                                     <%--   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                            TargetControlID="txtPinCode" ValidChars="0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                                         <ajaxToolkit:ValidatorCalloutExtender ID="vcerfvtxtPinCode" runat="server" CloseImageUrl="~/images/Closing.png"
                                                            PopupPosition="Left" TargetControlID="rfvtxtPinCode" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvtxtPinCode" runat="server" ControlToValidate="txtPinCode"
                                                            Display="None" ErrorMessage="Please Enter Pin Code" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="left" class="aclass">
                                                        State<strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <%--<asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" CausesValidation="True"
                                                            CssClass="i2s_jp_seats" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"
                                                            TabIndex="11" Width="150px">
                                                        </asp:DropDownList>--%>
                                                        <asp:TextBox ID="ddlState" runat="server" CausesValidation="True" CssClass="i2s_jp_seats"
                                                            TabIndex="11" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                                        <%-- <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="cvddlState"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:CompareValidator ID="cvddlState" runat="server" ControlToValidate="ddlState"
                                                            Display="None" ErrorMessage="Please select State" Operator="NotEqual" Type="Integer"
                                                            ValidationGroup="Register" ValueToCompare="0"></asp:CompareValidator>--%>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vceddlState" runat="server" CloseImageUrl="~/images/Closing.png"
                                                            PopupPosition="Left" TargetControlID="rfvddlState" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvddlState" runat="server" ControlToValidate="ddlState"
                                                            Display="None" ErrorMessage="Please enter State" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="aclass" style="width: 33%">
                                                        Mobile<strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtMobile" runat="server" CausesValidation="True" CssClass="i2s_jp_seats"
                                                            MaxLength="10" TabIndex="12" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                                        <br />
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcetxtMobile" runat="server" CloseImageUrl="~/images/Closing.png"
                                                            TargetControlID="rfvtxtMobile" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" TargetControlID="REVMobileNum" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="REVMobileNum" runat="server" ControlToValidate="txtMobile"
                                                            Display="None" ErrorMessage="Please enter valid mobile number &lt;br/&gt; it allows exactly 10 numerical values"
                                                            Font-Size="11px" ValidationExpression="\d{10}" ValidationGroup="Register" />
                                                        <asp:RequiredFieldValidator ID="rfvtxtMobile" runat="server" ControlToValidate="txtMobile"
                                                            Display="None" ErrorMessage="Please Enter Mobile Number" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftxteMobile" runat="server" TargetControlID="txtMobile"
                                                            ValidChars="0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                    <td align="left" class="aclass">
                                                        City<strong style="color: Red">*</strong>
                                                    </td>
                                                    <td align="left">
                                                        <%--<asp:DropDownList ID="ddlCity" runat="server" CssClass="i2s_jp_seats" TabIndex="13"
                                                            Width="150px">
                                                        </asp:DropDownList>--%>
                                                        <asp:TextBox ID="ddlCity" runat="server" CausesValidation="True" CssClass="i2s_jp_seats"
                                                            TabIndex="13" ValidationGroup="Register" Width="150px"></asp:TextBox>
                                                        <%-- <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="cvddlCity"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:CompareValidator ID="cvddlCity" runat="server" ControlToValidate="ddlCity" Display="None"
                                                            ErrorMessage="Please select City" Operator="NotEqual" Type="Integer" ValidationGroup="Register"
                                                            ValueToCompare="0"></asp:CompareValidator>--%>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vceddlCity" runat="server" CloseImageUrl="~/images/Closing.png"
                                                            PopupPosition="Left" TargetControlID="rfvddlCity" WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <asp:RequiredFieldValidator ID="rfvddlCity" runat="server" ControlToValidate="ddlCity"
                                                            Display="None" ErrorMessage="Please enter City" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="aclass" style="width: 33%">
                                                        Landline
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtLandLine" runat="server" CssClass="i2s_jp_seats" MaxLength="12"
                                                            TabIndex="14" Width="150px"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                            TargetControlID="txtLandLine" ValidChars="0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="aclass" style="width: 33%" valign="middle">
                                                        Fax</td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtFax" runat="server" CssClass="i2s_jp_seats" MaxLength="15" TabIndex="15"
                                                            Width="150px"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                            TargetControlID="txtFax" ValidChars="0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                    <td align="left" class="aclass" style="width: 20%" valign="top">
                                                        Address<span style="color: Red">*</span>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtAddress" runat="server" CausesValidation="True" Columns="27"
                                                            CssClass="i2s_jp_seats" Height="50px" Rows="5" TabIndex="16" TextMode="MultiLine"
                                                            ValidationGroup="Register" Width="160px"></asp:TextBox>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server"
                                                            TargetControlID="txtAddress" WatermarkText="Address">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server"
                                                            CloseImageUrl="~/images/Closing.png" PopupPosition="Left" TargetControlID="rfvtxtAddress"
                                                            WarningIconImageUrl="~/images/warning.png">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="rfvtxtAddress" runat="server" ControlToValidate="txtAddress"
                                                            Display="None" ErrorMessage="Please enter first address" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2" height="15" width="100%">
                                                        <asp:Button ID="btnRegister" runat="server" CssClass="i2s_jp_status4" OnClick="btnRegister_Click"
                                                            TabIndex="17" Text="Sign Up" ValidationGroup="Register" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="style1" colspan="3" valign="middle">
                                                        &nbsp;
                                                        <asp:Label ID="lblmsg" runat="server" CssClass="labelconfirm" Font-Size="Medium"
                                                            ForeColor="Red" Visible="False"></asp:Label>
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
                        <td align="center">
                            <asp:Panel ID="pnlMessages" runat="server">
                                <asp:Label ID="lblMsg1" runat="server" CssClass="i2s_TextBold"></asp:Label>
                                <asp:Label ID="lblMsg2" runat="server" CssClass="i2s_TextBold"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
