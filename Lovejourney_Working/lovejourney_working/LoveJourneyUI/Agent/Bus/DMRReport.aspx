<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="DMRReport.aspx.cs" Inherits="Agent_Bus_DMRReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%" style="background-color:White;">
        <tr>
            <td width="100%" height="30px" valign="middle" align="left" class="tr" id="tdmsg"
                runat="server" visible="false">
                <label id="lblMainMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
    </table>
    <table width="100%" id="tblMain" runat="server" style="background-color:White;">
        <tr>
            <td width="100%">
            </td>
        </tr>
     
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" id="tblgrid" runat="server">
                   <tr>
            <td width="100%" align="center">
                <label id="lblMsg" runat="server" style="color: Red;">
                </label>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" class="heading">
                <asp:Label ID="Label1" runat="server" Text="DMR Requests Report" Font-Size="13px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" id="tb1" runat="server" visible="false">
                    <tr>
                        <td align="right">
                            From Date
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtdate" Width="150" runat="server" CssClass="lj_inp">
                            </asp:TextBox>
                           
                            <asp:ImageButton runat="Server" ID="Image1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate"
                                Enabled="True" PopupButtonID="Image1">
                            </ajax:CalendarExtender>
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
                            <asp:TextBox ID="txtrefno" Width="150" runat="server" CssClass="lj_inp">
                            </asp:TextBox>
                            <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="../../images/Calendar_scheduleHS.png"
                                AlternateText="Click to select Date " TabIndex="10" />
                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtrefno"
                                Enabled="True" PopupButtonID="ImageButton1">
                            </ajax:CalendarExtender>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                           <asp:Label ID="lblpaging" runat="server" Text="Paging" CssClass="label"></asp:Label>

                        </td>
                        <td>
                            :
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlpaging" runat="server" CssClass="lj_inp" AutoPostBack="true"
                                Width="100px" OnSelectedIndexChanged="ddlpaging_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="40"></asp:ListItem>
                                <asp:ListItem Value="2" Text="80"></asp:ListItem>
                                <asp:ListItem Value="3" Text="120"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                           &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                           &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trsearch" runat="server" visible="false">
            <td width="100%" align="center">
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" CssClass="buttonBook"/>&nbsp;&nbsp;
              

               

            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:Label ID="lblerrormsg" runat="server" />
            </td>
        </tr>
                    <tr>
                        <td align="right" colspan="2" id="trpaging" runat="server">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           
                            
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center">
                          
                                <asp:GridView ID="gvDeposits" runat="server" AllowPaging="true" AllowSorting="true"
                                    OnPageIndexChanging="gvDeposits_PageIndexChanging" Width="100%" PageSize="100"
                                    EmptyDataText="No Data Found" ShowFooter="false" OnRowDataBound="gvDeposits_RowDataBound"
                                    AutoGenerateColumns="false" OnSorting="gvDeposits_Sorting" OnRowCommand="gvDeposits_RowCommand"
                                onrowediting="gvDeposits_RowEditing">
                                    <EmptyDataRowStyle ForeColor="#CC0000" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No" SortExpression="">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <asp:Label ID="lblDepositRequestId" runat="server" Visible="false" Text='<%# Eval("Id") %>' />
                                                 <asp:Label ID="lblAgentId" runat="server" Visible="false" Text='<%# Eval("Createdby") %>' />
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agent Name" SortExpression="Name" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgentname" runat="server" Text='<%# Eval("Name") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="User Name" SortExpression="UserName" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("UserName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requested Date" SortExpression="CreatedDate" FooterStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Eval("CreatedDate") %>' />
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount" SortExpression="Amount" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>' />
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Ext Charges" SortExpression="Extracharges" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExtracharges" runat="server" Text='<%# Eval("Extracharges") %>' />
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account Holder Name" SortExpression="Accountholdername">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAccountholdername" runat="server" Text='<%# Eval("Accountholdername") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account Number" SortExpression="Accountnumber">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAccountnumber" runat="server" Text='<%# Eval("Accountnumber") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="IFSCCode" SortExpression="IFSCCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIFSCCode" runat="server" Text='<%# Eval("IFSCCode") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank /Branch Name" SortExpression="BankName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("BankName") %>' />
                                                <br />
                                                       <asp:Label ID="lblbranchname" runat="server" Text='<%# Eval("BranchName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sender Name" SortExpression="SenderName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSenderName" runat="server" Text='<%# Eval("SenderName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="MobileNo" SortExpression="MobileNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobileNumber" runat="server" Text='<%# Eval("MobileNumber") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px"
                                        HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <RowStyle ForeColor="#000066" Height="25px" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="25px"
                                        HorizontalAlign="Center" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                                        Height="25px" />
                                </asp:GridView>
                         
                        </td>
                    </tr>
                  
                </table>
            </td>
        </tr>
        <tr>
        <td width="100%" align="center">

        <table id="tbldetails" runat="server" visible="false" width="50%">
        <tr>
        <td colspan="2" align="center">

       <asp:Label ID="lblhead" runat="server" Text="Details" Font-Bold="true" Font-Size="15px"></asp:Label>

        </td>
        </tr>
         <tr>
        <td colspan="2" >

       <asp:LinkButton ID="lnkback" runat="server" Text="Back" Font-Bold="true" 
                Font-Size="15px" onclick="lnkback_Click"></asp:LinkButton>

        </td>
        </tr>
        <tr>


         <td>    Amount :
        </td>


        <td>

        


        <asp:Label ID="lblamountd" runat="server"></asp:Label>
        </td>
        </tr>

        <tr>
         <td>    Date :
        </td>
        <td> 


        <asp:Label ID="lbldated" runat="server"></asp:Label>
        </td>
        </tr>


        <tr>
         <td>    Account Holder Name :
        </td>
        <td>

        


        <asp:Label ID="lblholdernamed" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
         <td>    Account Number :
        </td>
        <td>

        


        <asp:Label ID="lblaccountnod" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
         <td>    IFSC Code :
        </td>
        <td>

        


        <asp:Label ID="lblifsccoded" runat="server"></asp:Label>
        </td>
        </tr>

        <tr>
         <td>    Bank Name :
        </td>
        <td>

        


        <asp:Label ID="lblbanknamed" runat="server"></asp:Label>
        </td>
        </tr>

        <tr>

         <td>    Branch Name :
        </td>
        <td>

        


        <asp:Label ID="lblbranchnamed" runat="server"></asp:Label>
        </td>
        </tr>

        <tr>
         <td>    Sender Name :
        </td>
        <td>

        


        <asp:Label ID="lblsendernamed" runat="server"></asp:Label>
        </td>
        </tr>

        <tr>
         <td>    Mobile Number :
        </td>
        <td>

        


        <asp:Label ID="lblmobilenod" runat="server"></asp:Label>
        </td>
        </tr>


        </table>
        </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
    </table>
</asp:Content>

