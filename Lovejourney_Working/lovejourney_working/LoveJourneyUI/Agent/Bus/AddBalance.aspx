<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="AddBalance.aspx.cs" Inherits="Agent_Bus_AddBalance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" id="td1" runat="server" visible="false">
                <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
         <tr>
            <td width="100%" align="center" class="heading">
               <asp:Label ID="lblheading" runat="server" Text="Add Amount via Payment Gateway"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <div id="divChangePassword" runat="server" visible="true">
                   <%-- <fieldset>
                        <legend runat="server" id="legendChangePassword">Change Password</legend>--%>
                        <table width="100%">
                            <tr>
                                <td align="right" width="30%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="40%">
                                  Amount:
                                </td>
                                <td align="left" width="40%">
                                    <asp:TextBox ID="txtAmount" MaxLength="50" runat="server" 
                                        Width="200px" ValidationGroup="Submit"  CssClass="textfield_sleep" ></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtAmount" ValidChars="0123456789."></ajax:FilteredTextBoxExtender>
                                </td>
                                <td align="left" width="20%">
                                    <asp:RequiredFieldValidator ID="rfvtxtAmount" runat="server" ErrorMessage="Please Enter Amount."
                                        ControlToValidate="txtAmount" Display="None" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCurrentPassword" runat="server" TargetControlID="rfvtxtAmount"></ajax:ValidatorCalloutExtender>
                                    
                                </td>
                            </tr>
                           
                         
                            <tr>
                                <td align="right" width="30%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    &nbsp;
                                </td>
                                <td align="left" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    &nbsp;
                                </td>
                                <td align="left" width="40%">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                                        ValidationGroup="Submit" Style="cursor: pointer;"  CssClass="buttonBook" 
                                        onclick="btnSubmit_Click"/>
                                </td>
                                <td align="left" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" width="30%" colspan="3">
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                </td>
                               
                            </tr>
                        </table>
                   <%-- </fieldset>--%>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
    </table>
</asp:Content>

