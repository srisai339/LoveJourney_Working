<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="frmCarMaster.aspx.cs" Inherits="frmCarMaster" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  style="vertical-align:middle;height: 350px;
        width: 860px;">
    <tr align="center" height="20"><td colspan="2" bgcolor="#0062af">
    <asp:Label ID="lblCarPage" runat="server" Text="CarMaster"  ForeColor="White"  ></asp:Label>
    </td></tr>

    <tr align="center" height="20"><td colspan="2">
    <asp:Label ID="lblCarId" runat="server" Text="CarId" Visible="false"></asp:Label>
    </td>
    </tr>

    <tr height="30">
    <td width="50%" align="right">
    <asp:Label ID="lblCarName" runat="server" Text="CarName"></asp:Label>
    </td>
    <td  width="50%" align="left">
    <asp:TextBox ID="txtCarName" runat="server" ValidationGroup="Name"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RFVCN" runat="server" ControlToValidate="txtCarName" Display="None" ErrorMessage="Please Enter Car Name." ValidationGroup="Submit"></asp:RequiredFieldValidator>
    <ajax:ValidatorCalloutExtender ID="VCECN" runat="server" TargetControlID="RFVCN"></ajax:ValidatorCalloutExtender>
    <ajax:FilteredTextBoxExtender ID="FTECN" runat="server" TargetControlID = "txtCarName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></ajax:FilteredTextBoxExtender>
    </td>
    </tr>

    <tr height="30">
    <td width="50%" align="right">
    <asp:Label ID="Label1" runat="server" Text="Image"></asp:Label>
    </td>
    <td  width="50%" align="left">
    <asp:FileUpload ID="fuImage" runat="server" CssClass="lj_inp"   />
    </td>
    </tr>

    <tr><td colspan="2"></td></tr>

    <tr height="30">
    <td colspan="2" align="center">
        <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="Submit" onclick="btnInsert_Click" CssClass="buttonBook" />
        <asp:Button ID="btnCancel" runat="server" onclick="Cancel_Click" Text="Cancel"  ValidationGroup="Name" CssClass="buttonBook"/>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="Name" onclick="btnUpdate_Click" CssClass="buttonBook" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" ValidationGroup="Name" onclick="btnDelete_Click" CssClass="buttonBook"/>
       
    </td></tr>

    <tr><td colspan="2" align="center" style="color:Blue;">
     <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </td></tr>

    <tr><td colspan="2"></td></tr>

    <tr>
    <td colspan="2" align="center">
   <asp:GridView ID="gvCarName" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            AllowPaging="True" AllowSorting="True" 
            PageSize="10" CellPadding="4" EnableModelValidation="True"
                                            ForeColor="#333333" Width="100%" 
            DataKeyNames="CarName,CarId" 
            onpageindexchanging="gvCarName_PageIndexChanging" 
            onselectedindexchanged="gvCarName_SelectedIndexChanged">
            
           
                                           
                                            
                                            <PagerSettings Mode="Numeric" Position="Bottom" />
                                            <PagerStyle CssClass="transaction_style" BackColor="#2461BF" ForeColor="White"
                                                HorizontalAlign="Center" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle CssClass="transaction_style" BackColor="#507CD1" Font-Bold="True" Font-Size="9"
                                                ForeColor="White" />
                                            <RowStyle Font-Size="12px" Font-Names="Arial" Wrap="true" BackColor="#EFF3FB" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:ButtonField Text="Select" HeaderText="Car Name" DataTextField="CarName"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="CarName" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>

                                                <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" SortExpression="DepartureAirportName"
                                        HeaderStyle-ForeColor="White" HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                      
                                         <asp:Image ID="carimage" runat="server" ImageUrl='<%# Eval("CarImagePath") %>' />
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField HeaderText="CarId" DataField="CarId" HeaderStyle-HorizontalAlign="Left"
                                                    Visible="false" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>  


                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
    </td>
    
    </tr>

    </table>
</asp:Content>

