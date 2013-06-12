<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="frmCarDescriptionMaster.aspx.cs" Inherits="frmCarDescriptionMaster" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="vertical-align:middle;width: 860px;">

    <tr align="center" height="20">
    <td colspan="2" bgcolor="#0062af" style="color: White">Car Details Master</td>
    </tr>

    <tr height="20" align="center">
    <td colspan="2">
    <asp:Label ID="lblCarDetailsId" runat="server"></asp:Label>
    </td>
    </tr>

    <tr  height="20">
    <td width="500px" align="left">
    <asp:Label ID="lblSelectCity" runat="server">Select City</asp:Label>
    </td>
    <td width="500px" align="left">
    <asp:DropDownList ID="DDLCity" runat="server" >

    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvCity" runat="server"  ErrorMessage="Please select city" ControlToValidate="DDLCity" ValidationGroup="submit" Display="None" InitialValue="--Select--"></asp:RequiredFieldValidator>
    <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="rfvCity"></ajax:ValidatorCalloutExtender>
    
                                     
        </td>
    </tr>


    <tr height="20">
    <td width="500px" align="left"> 
    <asp:Label ID="lblSelectCar" runat="server">Select Car</asp:Label>
    </td>
    <td width="500px" align="left">
        <asp:DropDownList ID="DDLCar" runat="server">
         </asp:DropDownList>
         <asp:RequiredFieldValidator ID="rfvCar"  runat="server"  ErrorMessage="Please select car" ControlToValidate="DDLCar" ValidationGroup="submit" InitialValue="--Select--" Display="None"></asp:RequiredFieldValidator>
         <ajax:ValidatorCalloutExtender ID="vcecar" runat="server" TargetControlID="rfvCar"></ajax:ValidatorCalloutExtender>
        </td></tr>

    <tr height="20">
    <td width="500px" align="left">
    <asp:Label ID="lblBasicPrice" runat="server" Text="Basic Price"></asp:Label>
    </td>
    <td width="500px" align="left">
        <asp:TextBox ID="txtBasicPrice" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfbBestPrice" runat="server"  ControlToValidate="txtBasicPrice" ErrorMessage="Please Enter Price" ValidationGroup="submit" Display="None"></asp:RequiredFieldValidator>
        <ajax:ValidatorCalloutExtender ID="vceprice" runat="server" TargetControlID="rfbBestPrice"></ajax:ValidatorCalloutExtender>
    </td>
    </tr>

    <tr height="20">
    <td width="500px" align="left">
    <asp:Label ID="Label1" runat="server" Text="Usage"></asp:Label>
    </td>
    <td width="500px" align="left">
        <asp:TextBox ID="txtUsage" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsage" runat="server" ControlToValidate="txtUsage" ErrorMessage="please enter usage" Display="None" ValidationGroup="submit"></asp:RequiredFieldValidator>
        <ajax:ValidatorCalloutExtender ID="vceUsage" runat="server" TargetControlID="rfvUsage"></ajax:ValidatorCalloutExtender>
    </td>
    </tr>

    <tr height="20">
    <td width="500px" align="left">
    <asp:Label ID="Label2" runat="server" Text="Capacity"></asp:Label>
    </td>
    <td width="500px" align="left">
        <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCapacity" runat="server" ControlToValidate="txtCapacity" ErrorMessage="Please enter capacity" ValidationGroup="submit" Display="None"></asp:RequiredFieldValidator>
        <ajax:ValidatorCalloutExtender ID="vcecapacity"  runat="server" TargetControlID="rfvCapacity"></ajax:ValidatorCalloutExtender>
    </td>
    </tr>

    <tr height="20">
    <td width="500px" align="left">
    <asp:Label ID="lblExtraHours" runat="server" Text="Extra Hours"></asp:Label>
    </td>
    <td width="500px" align="left">
        <asp:TextBox ID="txtExtraHours" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvHours" ErrorMessage="Please enter hours"   ControlToValidate="txtExtraHours"  ValidationGroup="submit" Display="None" runat="server"></asp:RequiredFieldValidator>
        <ajax:ValidatorCalloutExtender ID="vcehours" runat="server" TargetControlID="rfvHours"></ajax:ValidatorCalloutExtender>
        <%--<asp:RequiredFieldValidator ID="rfvHours" runat="server" ControlToValidate="txtExtraHours" ErrorMessage="Please enter hours" 
    --%></td>
    </tr>

    <tr height="20">
    <td width="500px" align="left">
    <asp:Label ID="lblExtraKiloMeters" runat="server" Text="Extra KiloMeters"></asp:Label>
    </td>
    <td width="500px" align="left">
        <asp:TextBox ID="txtExtraKM" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvExtraKm" runat="server" ErrorMessage="Please enter km" Display="None" ValidationGroup="submit" ControlToValidate="txtExtraKM"></asp:RequiredFieldValidator>
        <ajax:ValidatorCalloutExtender ID="vcekm" runat="server" TargetControlID="rfvExtraKm"></ajax:ValidatorCalloutExtender>
    </td>
    </tr>

    <tr><td colspan="2"></td></tr>

    <tr height="30">
    <td colspan="2" align="center">
    <asp:Button ID="btnInsert" runat="server" Text="Insert"  onclick="btnInsert_Click" CssClass="buttonBook" />
        <asp:Button ID="btnCancel" runat="server" onclick="Cancel_Click" Text="Cancel"  ValidationGroup="Name" CssClass="buttonBook"/>
        <asp:Button ID="btnUpdate" runat="server" Text="Update"  onclick="btnUpdate_Click" CssClass="buttonBook"  />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" ValidationGroup="Name" onclick="btnDelete_Click" CssClass="buttonBook"/>    
    </td></tr>

     <tr><td colspan="2" align="center" style="color:Blue;">
     <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </td></tr>

    <tr><td colspan="2"></td></tr>

    <tr>
    <td colspan="2">
    <asp:GridView ID="gvCarDetails" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            AllowPaging="True" AllowSorting="True" 
            PageSize="10" CellPadding="4" EnableModelValidation="True"
                                            ForeColor="#333333" Width="100%" 
            DataKeyNames="CityName,CityId,CarName,CarId,BasicPrice,ExtarHours,ExtarKiloMeters,CarDetailsId,Usage,Capacity"
            onpageindexchanging="gvCarDetails_PageIndexChanging" 
            onselectedindexchanged="gvCarDetails_SelectedIndexChanged">

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
                                                <asp:ButtonField Text="Select" HeaderText="City Name" DataTextField="CityName"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="CityName" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>
                                                <asp:ButtonField Text="Select" HeaderText="Car Name" DataTextField="CarName"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="CarName" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>
                                                <asp:ButtonField Text="Select" HeaderText="Basic Price" DataTextField="BasicPrice"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="BasicPrice" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>
                                                <asp:ButtonField Text="Select" HeaderText="Extra Hours" DataTextField="ExtarHours"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="ExtarHours" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>
                                                <asp:ButtonField Text="Select" HeaderText="Extra KiloMeters" DataTextField="ExtarKiloMeters"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="ExtarKiloMeters" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>

                                                 <asp:ButtonField Text="Select" HeaderText="Usage" DataTextField="Usage"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="ExtarKiloMeters" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>
                                                  <asp:ButtonField Text="Select" HeaderText="Capacity" DataTextField="Capacity"
                                                    CommandName="Select" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    SortExpression="ExtarKiloMeters" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:ButtonField>

                                                <asp:BoundField HeaderText="CarDetailsId" DataField="CarDetailsId" HeaderStyle-HorizontalAlign="Left"
                                                    Visible="false" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField> 
                                                <asp:BoundField HeaderText="CityId" DataField="CityId" HeaderStyle-HorizontalAlign="Left"
                                                    Visible="false" >
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>  
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

