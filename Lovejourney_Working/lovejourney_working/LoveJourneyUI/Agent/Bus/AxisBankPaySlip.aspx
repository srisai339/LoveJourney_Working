<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AxisBankPaySlip.aspx.cs" Inherits="Agent_Bus_AxisBankPaySlip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script>

        //        function print() {
        //            window.print();
        //            alert('2");
        //        }

    </script>
</head>
<body>
<center>
<table>
<tr>
    <td align="center">
    
    <!--axis---><table width="744" >
<tr><td align="right">
<a href="Deposits.aspx" >Back</a>
</td></tr></table>
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
    <td align="left" style="border-right:1px #ccc solid;font-family:arial; font-size:12px;font-family:arial; font-size:10px;"><strong><h2 id="hdngAgentName" runat="server">SSD Technologies</h2></strong></td>
    <td align="center">Agent Code</td>
    <td align="center"><strong><H3 id="hdngAgentCode" runat="server">MAA 00 022 CV</H3></strong></td>
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
  
</table><table width="744" ><tr><td align="center"><input id="btPrint" type="button" value="PRINT"  onclick="print();"/></td></tr></table>
</center>
</body>
</html>
