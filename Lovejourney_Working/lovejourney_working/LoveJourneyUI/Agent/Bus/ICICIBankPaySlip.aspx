<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ICICIBankPaySlip.aspx.cs" Inherits="Agent_Bus_ICICIBankPaySlip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script>
        function print() {
            window.print();
            alert('2");
        }
     </script>
</head>
<body>
<center>
<table width="744" >
<tr><td align="right">
<a href="Deposits.aspx" >Back</a>
</td></tr>
<table width="744" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #646363;">
  <tr>
    <td>
        
    </td>
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
    <td width="170" align="left" style="font-size:18px; font-weight:bold;" id="Code" runat="server">00000000000000</td>
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
    <td width="180" align="left" style="font-size:18px; font-weight:bold;" id="Code1" runat="server">00000000000000</td>
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
<table width="744" >
    <tr>
        <td align="center">
            <input id="btPrint" type="button" value="PRINT"  onclick="print();"/>
        </td>
    </tr>
</table>
</center>
</body>
</html>
