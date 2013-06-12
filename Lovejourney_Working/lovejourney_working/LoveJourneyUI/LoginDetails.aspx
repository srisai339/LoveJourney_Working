<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="LoginDetails.aspx.cs" Inherits="Agent_Bus_LoginDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" class="view-boders" bgcolor="#ffffff">
        <tr>
            <td colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" width="990">
                    <tr>
                        <td align="center" valign="middle" class="heading" >
                            <b>Login History</b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
           <tr>
            <td align="center"  colspan="3">
            <asp:Panel ID="panel1" runat="server" DefaultButton="btnSearch">
                <table border="0" cellpadding="0" cellspacing="0" width="90%">
                    <%--<tr>
                        <td valign="middle" align="center" >
                            Date :
                        </td>

                        <td align="center" style="padding-right: 10px; height: 25px;">
                            <asp:TextBox ID="txtDate" runat="server"  Width="100px" ToolTip="Please select Date" 
                                TabIndex="9"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="Image1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                Enabled="True" PopupButtonID="Image1">
                            </ajaxtoolkit:calendarextender>
                           
                            <ajaxtoolkit:textboxwatermarkextender ID="tbwmedate" runat="server" TargetControlID="txtDate"
                                WatermarkText="Enter Date(MM/DD/YYYY)" WatermarkCssClass="watermarked" 
                                Enabled="True" />                       
                         
                           
                            <ajaxtoolkit:filteredtextboxextender ID="ftbeDOB" runat="server" TargetControlID="txtDate"
                                ValidChars="0123456789/">
                            </ajaxtoolkit:filteredtextboxextender>
                            <asp:HiddenField ID="hfSearchFromDate" runat="server" />
                       
                            
                        </td>
                    </tr>--%>
                      <tr>
                        <td align="right">
                            From Date
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" Width="150" runat="server">
                            </asp:TextBox>
                            <%-- <ajax:CalendarExtender ID="Calcdate" runat="server" TargetControlID="txtdate">
                            </ajax:CalendarExtender>--%>
                            <asp:ImageButton runat="Server" ID="Image1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                Enabled="True" PopupButtonID="Image1">
                            </ajaxtoolkit:CalendarExtender>
                            <ajaxtoolkit:FilteredTextBoxExtender ID="ftb" runat="server" TargetControlID="txtDate" ValidChars="0123456789/"></ajaxtoolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            To Date
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txttodate" Width="150" runat="server">
                            </asp:TextBox>
                            <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                Enabled="True" PopupButtonID="ImageButton1">
                            </ajaxtoolkit:CalendarExtender>
                               <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txttodate" ValidChars="0123456789/"></ajaxtoolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="8" align="center">
                       <asp:Button ID="btnSearch" runat="server" CssClass="buttonBook" Text="Search"  
                                ValidationGroup="Save" onclick="btnSearch_Click" />
                    </td>
                    </tr>
                    <tr>
                    <td colspan="8" align="center">
                    <asp:Label ID="lblmsg" runat="server" Visible= "false"></asp:Label>
                    </td>
                    </tr>
                  
                </table>
                </asp:Panel>
            </td>
      </tr>
        <tr><td align="center" style="height:5px"></td></tr>
        <tr>
            <td colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" width="770">
                 <tr id="trpaging" runat="server">
                        <td align="center" colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblpaging" runat="server" Text="Paging  :" CssClass="label"></asp:Label>
                            <asp:DropDownList ID="ddlpaging" runat="server" CssClass="picklist" AutoPostBack="true"
                                Width="100px" OnSelectedIndexChanged="ddlpaging_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>                              
                                <asp:ListItem Value="1" Text="40"></asp:ListItem>
                                <asp:ListItem Value="2" Text="80"></asp:ListItem>
                                <asp:ListItem Value="3" Text="120"></asp:ListItem>
                            </asp:DropDownList>
                          
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvLoginHistory" runat="server" AutoGenerateColumns="False" Width="250px"
                                Height="100px" AllowPaging="True" AllowSorting="True" CssClass="label" PageSize="50"
                               EnableModelValidation="True" 
                                onpageindexchanging="gvLoginHistory_PageIndexChanging">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  CssClass="gridheadercolor"
                                    />
                                <AlternatingRowStyle CssClass="gridAlter" />
                                <Columns>
                                 <asp:TemplateField HeaderText="Login Date & Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldateTime" runat="server" Text='<%# Bind("LoginTime") %>'></asp:Label>
                                        </ItemTemplate>
                                          <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                   </Columns>
                                <PagerStyle HorizontalAlign="Center" />
                               
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

