<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true"
    CodeFile="Deposits.aspx.cs" Inherits="Agent_Deposits" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css" >

.lj_ax
{
	font-family:arial;
	font-size:12px;
	color:#000;
	font-weight:normal;
	line-height:18px;
	border:1px solid #646363;
}

.lj_rt

{
	border-right:1px #ccc solid;
	
}

.lj_rtbt

{
	border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;
	
}
</style>
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
                <asp:LinkButton ID="lbtnDepositProcess" runat="server" Font-Bold="false" OnClick="lbtnDepositProcess_Click"
                    Visible="false">Deposit Process</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtnDeposits" runat="server" OnClick="lbtnDeposits_Click" Font-Bold="true">My Deposits</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtnDepositUpdateRequest" runat="server" OnClick="lbtnDepositUpdateRequest_Click"
                    Font-Bold="false">View Bank Details</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr id="tdheading" runat="server">
            <td width="100%" align="center" class="heading">
                <asp:Label ID="lblheading" runat="server" Text="Deposits"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <div id="divDeposits" runat="server" visible="true">
                    <%--  <fieldset>
                        <legend>Deposits</legend>--%>
                    <br />
                    <asp:GridView ID="gvDeposits" runat="server" AllowPaging="true" AllowSorting="true"
                        OnPageIndexChanging="gvDeposits_PageIndexChanging" Width="100%" PageSize="20"
                        OnSorting="gvDeposits_Sorting" EmptyDataText="No Data Found" ShowFooter="True"
                        OnRowDataBound="gvDeposits_RowDataBound" AutoGenerateColumns="false">
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
                             <asp:TemplateField HeaderText="Type" SortExpression="Credit_Debit">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreditDebit" runat="server" Text='<%# Eval("Credit_Debit") %>' />
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
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px"
                            HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                        <RowStyle ForeColor="#000066" Height="25px" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Height="25px"
                            HorizontalAlign="Center" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Maroon"
                            Height="25px" />
                        <AlternatingRowStyle CssClass="gridAlter" />
                    </asp:GridView>
                    <%-- </fieldset>--%>
                    <br />
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr id="tdhead" runat="server" visible="false">
            <td width="100%" align="center" class="heading">
                <asp:Label ID="Label1" runat="server" Text="Deposit Update Request"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="90%">
                <div id="divDepositUpdateRequest" runat="server" visible="false">
                    <%--   <fieldset>
                        <legend>Deposit Update Request</legend>--%>
                    <br />
                    <table width="100%" border="1">
                    <tr><td colspan="5" align="center"><h2 >Account Name: </h2><h2 style="font-weight:bold;color:#386bb8;">Love Journey Techno Pvt. Ltd.,</h2> </td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl1" runat="server" Text="Bank Name" Font-Bold="true" Font-Size="13px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Account Number" Font-Bold="true" Font-Size="13px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Branch Name" Font-Bold="true" Font-Size="13px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label2" runat="server" Text="IFSC Code" Font-Bold="true" Font-Size="13px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Download" Font-Bold="true" Font-Size="13px"></asp:Label>
                            </td>
                        </tr>
                       <tr>
                            <td>
                                Axis Bank
                            </td>
                            <td>
                                 909020041685998
                            </td>
                             <td>
                               
                                P L Puram
                            </td>
                             <td>
                                UTIB0000732
                            </td>
                            <td>
                                    <asp:LinkButton ID="lnkAxis" runat="server" 
                                    Text="Axis Bank Deposit Slip" ForeColor="Blue" OnClick="lnkAxis_Click" ></asp:LinkButton>
                            
                            </td>
                        </tr>
                        <tr>
                            <td>
                                SBI Bank
                            </td>
                            <td>
                                32747233847
                            </td>
                            <td>
                                DODDANEKUNDI</td>
                            <td>
                                SBIN0015615
                            </td>
                            <td>
                             <asp:LinkButton ID="lnksbi" runat="server" Text="SBI Bank Deposit  Slip" ForeColor="Blue"
                                    OnClick="lnksbi_Click"></asp:LinkButton>
                            
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ICICI Bank
                            </td>
                            <td>
                                141705000534
                            </td>
                            <td>
                                MARATHALLI
                            </td>
                            <td>
                                ICIC0001417
                            </td>
                            <td>
                            <asp:LinkButton ID="lnkICICI" runat="server" 
                                    Text="ICICI Bank Deposit Slip" ForeColor="Blue" OnClick="lnkICICI_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table width="100%">
                        <tr>
                            <td align="right" width="30%">
                                Deposit Type:
                            </td>
                            <td align="left" width="30%">
                                <asp:RadioButtonList ID="rbtnDepositType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                    OnSelectedIndexChanged="rbtnDepositType_SelectedIndexChanged" ValidationGroup="UpdateRequest">
                                      <asp:ListItem Selected="True">Cheque</asp:ListItem>
                                    <asp:ListItem >Cash</asp:ListItem>
                                     <asp:ListItem>NetTransfer</asp:ListItem>
                                  
                                   
                                </asp:RadioButtonList>
                            </td>
                            <td align="left" width="40%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="30%">
                                &nbsp;
                            </td>
                            <td align="left" width="30%">
                                &nbsp;
                            </td>
                            <td align="left" width="40%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                                <asp:Label ID="lbldeposit" runat="server" Text="Deposited Amount"></asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtDepositAmount" runat="server" MaxLength="50" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDepositAmount"
                                    Display="None" ErrorMessage="Please enter deposit amount." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDeposit1" runat="server" TargetControlID="RequiredFieldValidator1">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDepositAmount"
                                    Display="None" ErrorMessage="Please enter numeric values." Operator="DataTypeCheck"
                                    Type="Integer" ValidationGroup="UpdateRequest"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDeposit2" runat="server" TargetControlID="CompareValidator2">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtDepositAmount"
                                    Display="None" ErrorMessage="Value should be greater than zero" Operator="GreaterThanEqual"
                                    Type="Integer" ValidationGroup="UpdateRequest" ValueToCompare="1"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDepositAmount3" runat="server" TargetControlID="CompareValidator3">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                                Mobile Number:
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="10" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNumber"
                                    Display="None" ErrorMessage="Please enter mobile number." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobile1" TargetControlID="RequiredFieldValidator2"
                                    runat="server">
                                </ajax:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNumber"
                                    Display="None" ErrorMessage="Please enter valid mobile number." ValidationExpression="[7-9][0-9]{9}"
                                    ValidationGroup="UpdateRequest"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobile2" runat="server" TargetControlID="RegularExpressionValidator1">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr id="trtransid" runat="server">
                            <td align="left" width="30%">
                                Transaction Id:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTransactionId" runat="server" MaxLength="500" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtTransactionId"
                                    ErrorMessage="Enter Transaction Id" ValidationGroup="UpdateRequest" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceTransaction" runat="server" TargetControlID="rfv">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                                <asp:Label ID="lblChequeBank" runat="server" Text="Cheque Drawn Bank:"></asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtChequeDrawnBank" runat="server" MaxLength="500" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="txtChequeDrawnBank"
                                    Display="None" ErrorMessage="Please cheque drawn bank." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceChq" runat="server" TargetControlID="r1">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                                <asp:Label ID="lblChequeIssueDate" runat="server" Text="Cheque Issue Date:"></asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtChequeIssueDate" runat="server" MaxLength="10" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.jpg" />
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                    TargetControlID="txtChequeIssueDate" PopupButtonID="ImageButton2">
                                </ajax:CalendarExtender>
                                <asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="txtChequeIssueDate"
                                    Display="None" ErrorMessage="Please cheque issue date." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCheque1" runat="server" TargetControlID="r2">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="c1" runat="server" ControlToValidate="txtChequeIssueDate"
                                    Display="None" ErrorMessage="Please enter valid date." Operator="DataTypeCheck"
                                    Type="Date" ValidationGroup="UpdateRequest"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCheque2" runat="server" TargetControlID="c1">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="30%">
                                <asp:Label ID="lblChequeNumber" runat="server" Text="Cheque Number:"></asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txtChequeNumber" runat="server" MaxLength="100" CssClass="Textbox"
                                    ValidationGroup="UpdateRequest"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="r3" runat="server" ControlToValidate="txtChequeNumber"
                                    Display="None" ErrorMessage="Please enter cheque number." ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCheque3" runat="server" TargetControlID="r3">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr id="trnsferedfrom" runat="server" visible="false">
                            <td align="left" width="30%">
                               Transfered From
                            </td>
                            <td align="left" width="30%">
                            <asp:TextBox ID="txtTransferfrom" runat="server"></asp:TextBox>
                              
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="left" width="30%">
                                <asp:Label ID="lblbank" runat="server" Text="Deposited In Bank:"></asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:DropDownList ID="ddlDepositedBank" runat="server" ValidationGroup="UpdateRequest">
                                    <asp:ListItem Selected="True">Please Select</asp:ListItem>
                                    <asp:ListItem>HDFC Bank</asp:ListItem>
                                    <asp:ListItem>SBI Bank</asp:ListItem>
                                    <asp:ListItem>ICICI Bank</asp:ListItem>
                                    <asp:ListItem>Axis Bank</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDepositedBank"
                                    Display="None" ErrorMessage="Please select deposited bank." InitialValue="Please Select"
                                    ValidationGroup="UpdateRequest"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDeposit" runat="server" TargetControlID="RequiredFieldValidator6">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        
                        
                        <tr>
                            <td align="right" width="30%">
                                &nbsp;
                            </td>
                            <td align="left" width="30%">
                                <asp:Button ID="btnDepositUpdate" runat="server" OnClick="btnDepositUpdate_Click"
                                    Text="Submit" CssClass="buttonBook" Style="cursor: pointer;" ValidationGroup="UpdateRequest" />
                            </td>
                            <td align="left" width="40%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="true"
                                    OnPageIndexChanging="gvDeposits_PageIndexChanging" Width="100%" PageSize="20"
                                    EmptyDataText="No Data Found" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound"
                                    AutoGenerateColumns="false">
                                    <EmptyDataRowStyle ForeColor="#CC0000" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No" SortExpression="">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <asp:Label ID="lblDepositRequestId" runat="server" Visible="false" Text='<%# Eval("Id") %>' />
                                                <asp:Label ID="lblAgentId" runat="server" Visible="false" Text='<%# Eval("AgentId") %>' />
                                                <asp:Label ID="lblDepositBank" runat="server" Visible="false" Text='<%# Eval("DepositBank") %>' />
                                                <asp:Label ID="lblChequeDrawnBank" runat="server" Visible="false" Text='<%# Eval("ChequeDrawnBank") %>' />
                                                <asp:Label ID="lblChequeIssueDate" runat="server" Visible="false" Text='<%# Eval("ChequeIssueDate") %>' />
                                                <asp:Label ID="lblChequeNo" runat="server" Visible="false" Text='<%# Eval("ChequeNo") %>' />
                                                <asp:Label ID="lblemailId" runat="server" Visible="false" Text='<%# Eval("EmailId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agent Name" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgentname" runat="server" Text='<%# Eval("AgentName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("UserName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requested Date" FooterStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("CreatedDate") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                Total:
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("DepositAmount") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotal" runat="server" ForeColor="Red" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DepositType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDepositType" runat="server" Text='<%# Eval("Type") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transaction No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTransactionNumber" runat="server" Text='<%# Eval("TransactionId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Details">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDetails" runat="server" Text='<%# Eval("Details") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="ddlStatus" runat="server" />
                                                <asp:Label ID="lblStatus" runat="server" Visible="false" Text='<%# Eval("Status") %>' />
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
                    <br />
                    <%-- </fieldset>--%>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td width="100%">
                <div id="divDepositProcess" runat="server" visible="false">
                    <fieldset>
                        <legend>Deposit Process</legend>
                        <br />
                        Our Bank AC Details As Follows...
                        <br />
                        <br />
                        <br />
                        <br />
                    </fieldset>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlsbi" runat="server" Visible="false">
                    ghghgh
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" runat="server" visible="false">
                <asp:Panel ID="pnlaxis" runat="server" >
                  <table width="100%" border="0" cellspacing="0" cellpadding="0" style="font-family:Arial;font-size:12px;">
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="center">
    
    <!--axis--->
    <table width="744" border="0" cellspacing="0" style="font-family:Arial; color:#000000; font-size:12px; font-weight:normal;line-height:18px;border:1px solid #646363;" cellpadding="0">
  <tr>
    <td height="54" align="center" valign="top">
    <!--row1-->
    
    <table width="724" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="160"><img src="http://lovejourney.in/images/axis.png" width="138" height="40"  /></td>
    <td width="70" valign="bottom"><hr /></td>
    <td align="left" valign="bottom"><strong>Branch</strong></td>
    <td width="80" valign="bottom"><hr /></td>
    <td align="left" valign="bottom"><strong>City</strong></td>
    <td width="20"></td>
    <td valign="bottom" align="left" style="font-family:arial; font-size:12px;"><strong>Trans ID NO</strong></td>
    <td width="200" valign="bottom"><hr /></td>
    <td>&nbsp;</td>
    <td>Bank Copy</td>
  </tr>
</table>

    
    <!--row1End-->
    </td>
  </tr>
  
  <tr>
  <td height="1" bgcolor="#cccccc"></td>
  </tr>
  
  
  
  <tr>
    <td align="center">
    
    <table width="724" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="524" style="border-right:1px #ccc solid; font-family:arial; font-size:12px;">
    
    <strong>Note :</strong> Please use Seperate slips for Local/Outstation cheque for DD (Other than Axis Bank)
    
    </td>
    <td width="200">
    
    <table width="200"  border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="30" valign="bottom" align="center"><strong>Date :</strong></td>
    <td width="150" valign="bottom" ><hr /></td>
  </tr>
  <tr>
    <td height="35" valign="middle" align="center"><strong>Form :</strong></td>
    <td align="right" valign="middle"><strong><h2>03</h2></strong></td>
  </tr>
</table>

    
    </td>
  </tr>
</table>

    
    </td>
  </tr>
  
  
<tr>
  <td height="1" bgcolor="#cccccc"></td>
  </tr>
  
  <tr>
    <td>
    
    <table width="724" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="100" height="30" align="left">&nbsp;&nbsp;<strong>Agent Name</strong></td>
    <td align="left" style="border-right:1px #ccc solid;font-family:arial; font-size:12px;font-family:arial; font-size:10px;"><strong><h2>SSD Technologies</h2></strong></td>
    <td align="center">Agent Code</td>
    <td align="center"><strong><H3>MAA 00 022 CV</H3></strong></td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
  <td height="1" bgcolor="#cccccc"></td>
  </tr>
  
  <tr>
    <td>
    
    
    <table width="724" border="0" height="30" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" >&nbsp;&nbsp;<strong>For Credit of Current Account</strong></td>
    <td align="center"><strong><H3>Account No: 909020041685998</H3></strong></td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
  <td height="1" bgcolor="#cccccc"></td>
  </tr>
  
  <tr>
    <td align="left" height="30">&nbsp;&nbsp;<strong>Name</strong>&nbsp;&nbsp;&nbsp;&nbsp;
    <strong style="font-size:18px;">Love Journey Techno Pvt Ltd.</strong></td>
  </tr>
  
  <tr>
  <td height="1" bgcolor="#cccccc"></td>
  </tr>
  
  <tr>
  <td valign="top" align="center">
  
  
  <table width="724" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="550">
    
    <table width="550" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="3" align="center" height="35" style="border-right:1px #ccc solid;font-family:arial; font-size:10px;"><strong><h2>Cheque Details</h2></strong></td>
  </tr>
  <tr>
    <td  colspan="3" height="1" bgcolor="#cccccc"></td>
  </tr>
  <tr>
    <td width="224" align="center" style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;"><strong>Bank</strong></td>
    <td width="111" align="center" style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;"><strong>Branch</strong></td>
    <td width="215" align="center" style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;"><strong>Cheque no. Date</strong></td>
  </tr>
  <tr>
  <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
   <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
   <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
  <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
   <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
  <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
  <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;" colspan="3" align="center" height="28"><strong>Rupees in Words</strong></td>
 
  </tr>
</table>

    
    </td>
    <td width="224" valign="top">
    
    <table width="224" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="2" align="center" height="35"><strong><h2>Amount</h2></strong></td>
  </tr>
  <tr>
    <td  colspan="2" height="1" bgcolor="#cccccc"></td>
  </tr>
  <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;" align="center"><strong>Rs</strong></td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;" align="center"><strong>Ps</strong></td>
  </tr>
 <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
   <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
   <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
   <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
 <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
   <tr>
     <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;" height="28">&nbsp;</td>
    <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
</table>

    
    </td>
  </tr>
  
</table>

  
  
  </td>
  </tr>
  
  <tr>
  <td>&nbsp;</td>
  </tr>
  
  <tr>
  <td>&nbsp;</td>
  </tr>
  
  <tr>
  <td>&nbsp;</td>
  </tr>
  
  <tr>
  <td align="center">
  <table width="724" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="100" align="center"><strong>Entered by</strong></td>
    <td width="176" align="center"><strong>Validated by</strong></td>
    <td width="245" align="center"><strong>Acknowledgement From Agency</strong></td>
    <td width="203" align="center"><strong>Depositors Signature</strong></td>
  </tr>
</table>

  
  </td>
  </tr>
  
  <tr>
  <td>&nbsp;</td>
  </tr>
</table>
<!--axisEnd-->
    
    
    </td>
  </tr>
  <tr>
    <td align="center"><img src="http://lovejourney.in/images/cut.png" width="724" height="42"  /></td>
  </tr>
  <tr>
    <td align="center"><table width="744" border="0" cellspacing="0" style="font-family:arial;	font-size:12px;color:#000;font-weight:normal;line-height:18px;border:1px solid #646363;"  cellpadding="0">
      <tr>
        <td height="54" align="center" valign="top"><!--row1-->
          <table width="740" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="160"><img src="http://lovejourney.in/images/axis.png" width="138" height="40"  /></td>
              <td width="70" valign="bottom"><hr /></td>
              <td width="41" align="left" valign="bottom"><strong>Branch</strong></td>
              <td width="80" valign="bottom"><hr /></td>
              <td width="21" align="left" valign="bottom"><strong>City</strong></td>
              <td width="20"></td>
              <td width="62" align="left" valign="bottom" style="font-family:arial; font-size:12px;"><strong>Trans ID NO</strong></td>
              <td width="193" valign="bottom"><hr /></td>
             
              <td >Customer Copy</td>
            </tr>
          </table>
          <!--row1End--></td>
      </tr>
      <tr>
        <td height="1" bgcolor="#cccccc"></td>
      </tr>
      <tr>
        <td align="center"><table width="724" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="524" style="border-right:1px #ccc solid;"><strong>Note :</strong> Please use Seperate slips for Local/Outstation cheque for DD (Other than Axis Bank) </td>
            <td width="200"><table width="200"  border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="30" valign="bottom" align="center"><strong>Date :</strong></td>
                <td width="150" valign="bottom" ><hr /></td>
              </tr>
              <tr>
                <td height="35" valign="middle" align="center"><strong>Form :</strong></td>
                <td align="right" valign="middle"><strong>
                  <h2>03</h2>
                </strong></td>
              </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="1" bgcolor="#cccccc"></td>
      </tr>
      <tr>
        <td><table width="724" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="100" height="30" align="left">&nbsp;&nbsp;<strong>Agent Name</strong></td>
            <td align="left" style="border-right:1px #ccc solid;font-family:arial; font-size:10px;"><strong>
              <h2>SSD Technologies</h2>
            </strong></td>
            <td align="center">Agent Code</td>
            <td align="center"><strong>
              <h3>MAA 00 022 CV</h3>
            </strong></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="1" bgcolor="#cccccc"></td>
      </tr>
      <tr>
        <td><table width="724" border="0" height="30" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" >&nbsp;&nbsp;<strong>For Credit of Current Account</strong></td>
            <td align="center"><strong>
              <h3>Account No: 909020041685998</h3>
            </strong></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="1" bgcolor="#cccccc"></td>
      </tr>
      <tr>
        <td align="left" height="30">&nbsp;&nbsp;<strong>Name</strong>&nbsp;&nbsp;&nbsp;&nbsp; <strong style="font-size:16px;">Love Journey Techno Pvt Ltd.</strong></td>
      </tr>
      <tr>
        <td height="1" bgcolor="#cccccc"></td>
      </tr>
      <tr>
        <td valign="top" align="center"><table width="724" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="550"><table width="550" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td colspan="3" align="center" height="35" style="border-right:1px #ccc solid;"><strong>
                  <h2>Cheque Details</h2>
                </strong></td>
              </tr>
              <tr>
                <td  colspan="3" height="1" bgcolor="#cccccc"></td>
              </tr>
              <tr>
                <td width="224" align="center" style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;"><strong>Bank</strong></td>
                <td width="111" align="center" style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;"><strong>Branch</strong></td>
                <td width="215" align="center" style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;"><strong>Cheque no. Date</strong></td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;" colspan="3" align="center" height="28"><strong>Rupees in Words</strong></td>
              </tr>
            </table></td>
            <td width="224" valign="top"><table width="224" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td colspan="2" align="center" height="35"><strong>
                  <h2>Amount</h2>
                </strong></td>
              </tr>
              <tr>
                <td  colspan="2" height="1" bgcolor="#cccccc"></td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;" align="center"><strong>Rs</strong></td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;" align="center"><strong>Ps</strong></td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
              <tr>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;" height="28">&nbsp;</td>
                <td style="border-right:1px #ccc solid;border-bottom:1px #ccc solid;">&nbsp;</td>
              </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td align="center"><table width="724" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="100" align="center"><strong>Entered by</strong></td>
            <td width="176" align="center"><strong>Validated by</strong></td>
            <td width="245" align="center"><strong>Acknowledgement From Agency</strong></td>
            <td width="203" align="center"><strong>Depositors Signature</strong></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>

                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlicici" runat="server" Visible="false">
                 <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="center" valign="top">
    
    <table width="744" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #646363;">
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="center" valign="top">
    
    <table width="744" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" width="150"><img src="http://lovejourney.in/images/icicilogo.jpg" width="138" height="40"  /></td>
    <td width="100" align="center" style="font-family:Verdana, Geneva, sans-serif; font-size:13px; font-weight:bold;">PAY-IN-SLIP</td>
    <td width="150"><img src="http://lovejourney.in/images/icicilogo.jpg" width="138" height="40"  /></td>
    <td width="200" align="center" style="font-family:Verdana, Geneva, sans-serif; font-size:13px; font-weight:bold;">PAY-IN-SLIP</td>
    <td width="144" align="right" valign="middle">
    
    <table width="100" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="32" style="font-family:Arial, Helvetica, sans-serif; font-size:12px;"><strong>Date</strong></td>
    <td width="50" style="border-bottom:2px solid #000;">&nbsp;</td>
  </tr>
</table>

    
    </td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td align="center" valign="top">
    
    <table width="744" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" valign="bottom" width="32" style="font-family:Arial, Helvetica, sans-serif; font-size:12px;"><strong>Date:</strong></td>
    <td width="50" style="border-bottom:2px solid #000;">&nbsp;</td>
    <td align="right" valign="bottom" width="110" style="font-family:Arial, Helvetica, sans-serif; font-size:12px;"><strong>Deposited Branch:</strong></td>
    <td width="50" style="border-bottom:2px solid #000;">&nbsp;</td>
    <td align="right" valign="bottom" width="110" style="font-family:Arial, Helvetica, sans-serif; font-size:12px;"><strong>Deposited Branch:</strong></td>
    <td width="50" style="border-bottom:2px solid #000;">&nbsp;</td>
    <td>&nbsp;</td>
    <td align="right" valign="bottom" width="170" style="font-family:Arial, Helvetica, sans-serif; font-size:12px;"><strong>My Account is with Branch:</strong></td>
    <td width="50" style="border-bottom:2px solid #000;">&nbsp;</td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td align="center" valign="top">
    
    <table width="744" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>&nbsp;</td>
    <td width="280" align="left" style="font-size:13px; font-weight:bold;">FULL NAME:  Love Journey Techno Pvt Ltd.</td>
    <td width="25">&nbsp;</td>
    <td align="left" width="100" style=" font-family:Arial, Helvetica, sans-serif; font-size:12px;">Agency Code</td>
    <td width="170" align="left" style="font-size:18px; font-weight:bold;">00000000000000</td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td align="center" valign="top">
    <table width="744" border="0" cellspacing="0" cellpadding="0">
  <tr>
  	<td width="5">&nbsp;</td>
    <td width="300" align="center" valign="top">
    
    <table width="300" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="top">
    
    <table width="300" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="120" align="left">Agency Code</td>
    <td width="180" align="left" style="font-size:18px; font-weight:bold;">00000000000000</td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td align="center" valign="top">
    
    <table width="300" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="150" align="right" valign="bottom">ACCOUNT NUMBER:</td>
    <td width="150" align="center" valign="top" height="22">
    <table width="150" border="1" cellspacing="0" cellpadding="0">
  <tr>
    <td height="22" width="12">1</td>
    <td>4</td>
    <td width="12">1</td>
    <td>7</td>
    <td width="12">0</td>
    <td>5</td>
    <td width="12">0</td>
    <td width="12">0</td>
    <td>0</td>
    <td width="12">5</td>
    <td>3</td>
    <td width="12">4</td>
  </tr>
</table>

    </td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td align="center" valign="top">
    
    <table width="300" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" width="200">PARTICULERS</td>
    <td width="60" align="left">Rs.</td>
    <td width="40" align="left">Ps.</td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td align="center" valign="top">
    
    <table width="300" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #646363; line-height:25px;">
  <tr>
    <td width="200" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td width="60" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td width="40" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" style=" font-family:Verdana, Geneva, sans-serif; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">Total</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td align="center" style=" font-family:Verdana, Geneva, sans-serif; font-size:14px; font-weight:bold; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">OFFICER</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr><td colspan="3" align="center" style="font-family:Verdana, Geneva, sans-serif; font-size:12px; font-weight:bold;">CHEQUE(S)SUBJECT TO REALISATION</td></tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td height="95" align="center" valign="middle" style=" font-family:Verdana, Geneva, sans-serif; font-size:12px;">Please mention your Account No. & Name
behind the Cheque.</td>
  </tr>
</table>

    
    </td>
    <td width="10">&nbsp;</td>
    <td width="429" align="left" valign="top">
    
    <table width="429" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="top"> 
    
    <table width="429" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="279" align="left" valign="middle" style="font-family:Verdana, Geneva, sans-serif; font-size:11px;">ACCOUNT NUMBER(For deposit in Bank Account)</td>
    <td width="150" align="center" valign="top" height="22">
    <table width="150" border="1" cellspacing="0" cellpadding="0">
  <tr>
   <td height="22" width="12">1</td>
    <td>4</td>
    <td width="12">1</td>
    <td>7</td>
    <td width="12">0</td>
    <td>5</td>
    <td width="12">0</td>
    <td width="12">0</td>
    <td>0</td>
    <td width="12">5</td>
    <td>3</td>
    <td width="12">4</td>
  </tr>
</table>

    </td>
  </tr>
</table>
    
    </td>
  </tr>
  <tr>
    <td height="10"></td>
  </tr>
  <tr>
    <td align="center" valign="top">
    
    <table width="429" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="189" align="center" valign="top">
    
    <table width="189" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #646363;">
  <tr>
    <td width="109" style=" font-family:Verdana, Geneva, sans-serif; font-size:11px; border-right:1px #646363 solid; font-weight:bold;
	border-bottom:1px #ccc solid;">BANK & BRANCH</td>
    <td width="80" style=" font-family:Verdana, Geneva, sans-serif; font-size:11px; border-right:1px #ccc solid; font-weight:bold;
	border-bottom:1px #ccc solid;">CHEQUE NO</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td height="100" colspan="2" align="left" valign="top" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid; font-family:Arial, Helvetica, sans-serif; font-size:11px;">TOTAL AMOUNT RUPEES(in words)_<br /><br /> _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _<br /><br />_ _ _ _ _ _ _ _ _ _ _ _ _Only</td>
  </tr>
  <tr>
    <td align="center" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">Total</td>
    <td style="border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
</table>

    
    </td>
    <td width="10">&nbsp;</td>
    <td align="center" valign="top" width="230">
    
    <table width="230" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #646363;">
  <tr>
    <td width="50" align="left" style=" font-family:Verdana, Geneva, sans-serif; font-size:12px; font-weight:bold; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">DENO.</td>
    <td width="35" align="left" style="font-family:Verdana, Geneva, sans-serif; font-size:12px; font-weight:bold; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">PIECES</td>
    <td width="150" align="right" style="font-family:Verdana, Geneva, sans-serif; font-size:12px; font-weight:bold; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">Rs.</td>
    <td width="35" align="right" style="font-family:Verdana, Geneva, sans-serif; font-size:12px; font-weight:bold; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">Ps.</td>
  </tr>
  <tr>
    <td align="right" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">1000x</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">500x</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">100x</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">50x</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">20x</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">10x</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">5x</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
  <tr>
    <td height="100" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">coins</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
    <td align="center" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">Rs.</td>
    <td style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">Ps.</td>
  </tr>
  <tr>
    <td colspan="4" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">&nbsp;</td>
  </tr>
</table>

    
    </td>
  </tr>
</table>

    
    
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="center" valign="top" width="429">
    
    <table width="429" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #646363;">
  <tr>
    <td width="269" align="center" valign="top">
    
    <table width="269" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="149" align="center" valign="top">
    
    <table width="149" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="25" align="center" style=" font-family:Verdana, Geneva, sans-serif; font-size:12px; font-weight:bold; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">FOR OFFICE USE</td>
  </tr>
  <tr>
    <td height="25" align="left" style=" font-family:Verdana, Geneva, sans-serif; font-size:11px; font-weight:bold; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">Train.ID:</td>
  </tr>
  <tr>
    <td height="25" align="left" style=" font-family:Verdana, Geneva, sans-serif; font-size:10px; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">OFFICER</td>
  </tr>
</table>

    
    </td>
    <td width="120" align="left" valign="bottom" style="font-size:12px; font-weight:bold; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">VERIFYING OFFICER</td>
  </tr>
  <tr>
    <td colspan="2" align="left" style=" font-family:Verdana, Geneva, sans-serif; font-size:10px; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">Fot Cash Deposits above Rs. 10 Lacs give details of cash transactions, 
including source of the Cash, Overleaf(For RBI Reporting)</td>
  </tr>
</table>

    
    </td>
    <td width="160" align="center" valign="top">
    
    <table width="160" border="0" cellspacing="0" cellpadding="0" style="border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">
  <tr>
    <td style="border-bottom:1px #ccc solid;" align="center">PAN(foramount<br />Rs.50.000 & above)<br />
    <table width="120" border="1" cellspacing="0" cellpadding="0">
  <tr>
    <td height="22" width="12"></td>
    <td width="13">&nbsp;</td>
    <td width="12">&nbsp;</td>
    <td width="13">&nbsp;</td>
    <td width="12">&nbsp;</td>
    <td width="13">&nbsp;</td>
    <td width="12">&nbsp;</td>
    <td width="12">&nbsp;</td>
    <td width="13">&nbsp;</td>
    <td width="12">&nbsp;</td>
  </tr>
</table>
    </td>
  </tr>
  <tr>
    <td height="47" align="center" valign="bottom" style=" font-family:Verdana, Geneva, sans-serif; font-size:10px; border-right:1px #ccc solid;
	border-bottom:1px #ccc solid;">SIGNATURE OF DEPOSITOR</td>
  </tr>
</table>

    
    </td>
  </tr>
</table>

    
    </td>
  </tr>
</table>

    
    </td>
    <td width="5">&nbsp;</td>
  </tr>
</table>

    
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>

    
    
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
