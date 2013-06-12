<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/Bus/MasterPage.master" AutoEventWireup="true" CodeFile="AgentQueries.aspx.cs" Inherits="Agent_Masters_AgentQueries" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../css/dashboard-style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
<script language="javascript" type="text/javascript">
    function showDiv(arg) {
        if (arg == 'val') {
            if (Page_ClientValidate("Save")) {
                document.getElementById('mainDiv').style.display = "";
                document.getElementById('contentDiv').style.display = "";
                setTimeout('document.images["myAnimatedImage"].src = "images/loaderd.gif"', 200);
            }
            else {
                alert('hi');
                return false;
            }
        }
        else {
            document.getElementById('mainDiv').style.display = "";
            document.getElementById('contentDiv').style.display = "";
            setTimeout('document.images["myAnimatedImage"].src = "images/loaderd.gif"', 200);
        }
    }
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
      <tr>
      <td align="right">
        <asp:LinkButton ID="lnkButtonBack" runat="server" Text="Back" onclick="lnkButtonBack_Click"  ForeColor="#006699"
                                        ></asp:LinkButton>
      </td>
      </tr>
    <tr>
       <td align="center">

          <table id="tbRegister" runat="server" border="0" cellspacing="0" cellpadding="0" >
        <tr>
           <%-- <td width="21" align="left" valign="top">
                <asp:Image ID="searchresultstopleft" runat="server" ImageUrl="~/images/searchreultstopleft.gif"
                    Width="21" Height="40" />
            </td>
            <td align="left" valign="middle" class="searchresultstopbg">
                <span class="innerheading">
                    <asp:Label ID="lblRegister" runat="server">Send/Receive Messages</asp:Label></span>
            </td>
            <td width="21" align="left" valign="top">
                <asp:Image ID="searchresultstopright" runat="server" ImageUrl="~/images/searchresultstopright.gif"
                    Width="21" Height="40" />
            </td>--%>
            <td align="center" class="lj_dbrd_hd">
                <b>Send/Receive Messages</b>
            </td>
        </tr>

        <tr>
            

            <td align="left" valign="top"  class="searchresultsbg">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <%--ModalPopUp Profile Starts  --%>
                        <asp:Button ID="Button1" runat="server" Text="" Style="display: none" />
                        <ajaxtoolkit:ModalPopupExtender ID="mpeViewProfile" BackgroundCssClass="modalBackground"
                            runat="server" CancelControlID="ibtnCancel" TargetControlID="Button1" PopupControlID="PopupHeader1"
                            PopupDragHandleControlID="PopupHeader1" Drag="true">
                        </ajaxtoolkit:ModalPopupExtender>
                        <asp:Panel ID="PopupHeader1" runat="server" CssClass="modalContainer" Style="display: none">
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="images/Close1.bmp" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <div class="central">
                                            <iframe id="iframeProfile" runat="server" class="border" src="" height="500px" 
                                                frameborder="0" scrolling="auto" align="left" name="myInlineFrame"></iframe>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%--ModalPopUp Profile Ends  --%>
                        <%--ModalPopUp Starts  --%>
                        <asp:Button ID="Button2" runat="server" Text="" Style="display: none" />
                        <ajaxtoolkit:ModalPopupExtender ID="mpeTypeCheck" BackgroundCssClass="modalBackground"
                            runat="server" CancelControlID="ibtnClose" TargetControlID="Button2" PopupControlID="PopupHeader2"
                            PopupDragHandleControlID="PopupHeader2" Drag="true">
                        </ajaxtoolkit:ModalPopupExtender>
                        <asp:Panel ID="PopupHeader2" runat="server" CssClass="modalContainer" Style="display: none">
                            <table id="Table1" runat="server" width="250px" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="21" align="left" valign="top">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/searchreultstopleft.gif"
                                            Width="21" Height="40" />
                                    </td>
                                    <td align="left" valign="middle" class="searchresultstopbg">
                                        <span class="innerheading">
                                            <asp:Label ID="Label11" runat="server">Alert</asp:Label>
                                        </span>
                                    </td>
                                    <td width="21" align="left" valign="top">
                                        <asp:Image ID="Image31" runat="server" ImageUrl="~/images/searchresultstopright.gif"
                                            Width="21" Height="40" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" class="searchresultsleftbg">
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" class="searchresultsbg">
                                        <table>
                                            <tr>
                                                <td id="tdTypeChk" runat="server" align="center" class="registertxtfiled">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:ImageButton ID="ibtnClose" runat="server" CausesValidation="false" ImageUrl="images/Close1.bmp"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" valign="top" class="searchresultsrightbg">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:Image ID="image2" runat="server" Width="21" Height="22" ImageUrl="~/images/searchresultsbottomleft.gif" />
                                    </td>
                                    <td align="left" valign="top" class="searchbottombg">
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Image ID="Image5" runat="server" Width="21" Height="22" ImageUrl="~/images/searchresultsbottomright.gif" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%--ModalPopUp Ends  --%>
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label5" runat="server" Font-Underline="true" Text="" CssClass="registerhead"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkMessages" runat="server" OnClick="lnkMessages_Click" Visible="False"
                                        ToolTip="Click here to check new messages" Text="" OnClientClick="return showDiv('');"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table runat="server" id="tbGrid" width="100%" visible="false">
                            <tr>
                                <td align="center" colspan="4">
                                    <br />
                                    <asp:GridView ID="grddetails" SkinID="gridview" runat="server" AllowPaging="True"
                                        AllowSorting="True" AutoGenerateColumns="False" Font-Size="9pt" Height="1px"
                                        OnRowCommand="grddetails_RowCommand" PageSize="5" Width="100%" OnPageIndexChanging="grddetails_PageIndexChanging"
                                        OnRowDataBound="grddetails_RowDataBound" OnRowUpdating="grddetails_RowUpdating"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        OnDataBound="grddetails_DataBound" >
                                        <PagerSettings Mode="Numeric" Position="Bottom" />
                                        <PagerStyle CssClass="pgr" />
                                        <RowStyle Font-Size="Small" />
                                        <%--<AlternatingRowStyle ForeColor="#C0C0C0" />--%>
                                        <Columns>
                                            <asp:BoundField DataField="QueryID" HeaderText="Query ID">
                                                <ItemStyle Width="20%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="UserName">
                                                <ItemStyle Wrap="true" />
                                                <ItemTemplate>
                                                   <%-- <asp:LinkButton ID="lbtnViewProfile" runat="server" Text='<%# Bind("UserName") %>'
                                                        CommandName="ViewProfile" CommandArgument='<%# Eval("FromID") %>' OnClientClick="showDiv();"></asp:LinkButton>
--%>

                                                    <asp:Label ID="lbtnViewProfile" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:BoundField DataField="UserName" HeaderText="From" SortExpression="UserName">
                                                <HeaderStyle ForeColor="White" />
                                                <ItemStyle Width="20%" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Mail Body">
                                                <ControlStyle Width="155px" />
                                                <ItemStyle Width="155px" Wrap="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("MailBody") %>' Width="150px"></asp:Label>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("MailBody") %>' Visible="False"></asp:Label>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ToID") %>' Visible="False"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DateTimeStamp" HeaderText="Date" SortExpression="DateTimeStamp">
                                                <HeaderStyle ForeColor="White" />
                                                <ItemStyle Width="20%" />
                                            </asp:BoundField>
                                            <asp:ButtonField ButtonType="Button" CommandName="View" ShowHeader="True" Text="View"
                                                ControlStyle-CssClass="buttonBook">
                                                <ControlStyle Font-Bold="True" Font-Size="XX-Small" />
                                                <ItemStyle Font-Bold="True" Font-Size="X-Small" />
                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="Button" CommandName="Update" ShowHeader="True" Text="Reply"
                                                ControlStyle-CssClass="buttonBook">
                                                <ControlStyle Font-Bold="True" Font-Size="XX-Small" />
                                                <ItemStyle Font-Bold="True" Font-Size="X-Small" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="Read_UnRead" HeaderText="R">
                                                <HeaderStyle ForeColor="Transparent" />
                                                <ItemStyle Width="2%" ForeColor="Transparent" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ReplySequence" HeaderText="RS">
                                                <HeaderStyle ForeColor="Transparent" />
                                                <ItemStyle Width="2%" ForeColor="Transparent" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FromID" HeaderText="FromID">
                                                <ItemStyle Width="2%" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        No messages!
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr><td><asp:Label ID="lblid" runat="server" ></asp:Label></td></tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:LinkButton ID="lbtnShowtTxtbox" runat="server" OnClick="lbtnShowtTxtbox_Click"
                                        OnClientClick="return showDiv('');">Send message to Administrator</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <table runat="server" id="tbMain" width="100%" visible="false">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:TextBox ID="txtSolution" runat="server" Height="145px" TextMode="MultiLine"
                                        Width="100%" Columns="100" Rows="10" MaxLength="1000"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvsol" runat="server" ErrorMessage="Message content is required."
                                        SetFocusOnError="True" ControlToValidate="txtSolution" Font-Size="10px" Display="None"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    <ajaxtoolkit:ValidatorCalloutExtender ID="vceLastName" runat="server" TargetControlID="rfvsol"
                                        WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/Closing.png" Width="200px">
                                    </ajaxtoolkit:ValidatorCalloutExtender>
                                    <br />
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Green" Text="Saved Successfully"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" style="height: 7px">
                                    <asp:Button ID="btnSave" runat="server" CssClass="buttonBook" OnClick="btnSave_Click"
                                        TabIndex="11" Text="Send" ValidationGroup="Save" OnClientClick="return showDiv('val');"
                                        CausesValidation="true" ToolTip="Click here to Save the Details" />
                                </td>
                            </tr>
                        </table>
                        <span id="mainDiv" style="display: none" class="loadingBackground"></span><span id="contentDiv"
                            style="display: none; background-color: Transparent" class="modalContainer">
                            <div class="processing">
                                Processing... Please wait!<br />
                                <img src="~/images/loaderd.gif" id="myAnimatedImage" alt="Processing... Please wait!" />
                            </div>
                        </span>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            

        </tr>
        <tr>
            

            <td align="left" valign="top" class="searchbottombg">
                &nbsp;
            </td>
            

        </tr>
    </table>
       </td>
    </tr>
    </table>
</asp:Content>

