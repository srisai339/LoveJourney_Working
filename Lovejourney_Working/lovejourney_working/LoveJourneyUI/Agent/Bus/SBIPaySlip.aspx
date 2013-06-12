<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SBIPaySlip.aspx.cs" Inherits="Agent_Bus_SBIPaySlip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>SBI Chalan</title>
<link rel="stylesheet" type="text/css" href="../../style/style.css" />
   <script>
        function print() {
            window.print();
            alert('2");
        }
     </script>
</head>

<body>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr><td align="right">
    <table width="170px"><tr><td>
        <a href="Deposits.aspx" >Back</a>
    </td></tr></table>
</td></tr>
  <tr>
    <td align="center">
        <table width="900"  cellspacing="0" cellpadding="0" class="side">
 			 <tr>
    				<td><table width="800" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="400" align="left"><img src="../../images/sbilogo.png"  width="214" height="87"/></td>
    <td align="right"> Site Logo</td>
  </tr>
</table>
</td>
  			</tr>
        <!-------Site Logo------>    
            
            
            <!-------=name branch------>
 			 <tr>
   					<td><table width="800" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" class="Sb_branch">Name Of the Branch</td>
    <td align="left" class="Sb_branch">Branch Code</td>
    <td align="left" class="Sb_branch">Date:</td>
  </tr>
  <tr>
  <td colspan="3" height="5"></td>
  
  </tr>
  
</table>
</td>
  			</tr>
          <!-------=name branch------>    
            
        <!-----agent------->    
            
  <tr>
    <td><table width="800" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="220" align="left">Agent Reg No. FRAG/FRAN/DIST :</td>
    <td width="580" align="left">
    <table width="250" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #666;">
  <tr>
    <td class="sbi_acc">1</td>
                				<td class="sbi_acc">1</td>
                				<td class="sbi_acc">1</td>
                                <td class="sbi_acc">1</td>
                                <td class="sbi_acc">1</td>
                                <td class="sbi_acc">1</td>
                                <td class="sbi_acc">1</td>
                                <td class="sbi_acc" style="border-right:none;">1</td>
  </tr>
</table>

    
    
    
    </td>
  </tr>
</table>
</td>
  </tr>
    <!-----agent-------> 
    <tr>
    <td height="5"></td>
    
    </tr>
    
       <!-------name agent------->
  <tr>
  <td align="left">Name of the Agent:</td>
  
  
  </tr>
   <!-------name agent------->
  <tr><td height="5"></td> </tr>
   <tr>
   <td width="800" align="left">For the Credit of Current A/c 30840908909of FlightRaja Travels Pvt Ltd., Bangalore with State Bank of India,</td>
   
   </tr>
   <tr>
   <td height="5"></td>
   </tr>
   <tr>
   <td width="800" align="left">SanjayNagar, Bangalore (Branch Code: 10500)</td>
   
   </tr>
   <tr>
   <td height="5"></td>
   </tr>
   
   
   
    <!-------name agent------->
  <!------Branch----->
  <tr>
  <td width="800"><table width="800" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #666;">
  <tr>
    <td width="100" align="center" class="agent">Agent</td>
    <td width="200" align="center" class="agent">Agency Name</td>
    <td width="100" align="center" class="agent">Amount</td>
    <td width="200" align="center" class="agent" style="border-right:none;">Amount In words</td>
  </tr>
  <tr>
  <td width="100" align="center" class="agent"  height="100" style="border-bottom:none;"></td>
    <td width="200" align="center" class="agent" height="100" style="border-bottom:none;"></td>
    <td width="100" align="center" class="agent" height="100" style="border-bottom:none;"></td>
    <td width="200" align="center" class="agent" height="100" style="border-bottom:none; border-right:none;"></td>
  </tr>
</table>
</td>
  
  </tr>
  <tr>
  <td height="5"> </td>
  
  </tr>
  
  
  <!------Branch----->
  <!--------Chaque------->
  <tr>
  	<td>
    	<table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="70%">
            	<table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                    	<table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #666;">
                          <tr>
                            <td class="chaqu" height="40" valign="middle" >Cheque No. <br/>
Bank /Branch/Date</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20" ></td>
                          </tr>
                          <tr>
                            <td class="chaqu"  height="20"></td>
                          </tr>
                          <tr>
                            <td class="chaqu"  height="20"></td>
                          </tr>
                          <tr>
                            <td class="chaqu"  height="20"></td>
                          </tr>
                          <tr>
                            <td class="chaqu"  height="20"></td>
                          </tr>
                          <tr>
                            <td class="chaqu"  height="20" style="border-bottom:none; border-right:none;" >&nbsp;</td>
                          </tr>
                        </table>

                    </td>
                    <td>
                    	<table width="100%" border="0" cellspacing="0" cellpadding="0" >
                          <tr>
                            <td><table width="100%" border="0" cellspacing="0" cellpadding="0" height="40" >
  <tr>
    <td colspan="2" class="chaqu" style="border-top:1px solid #666;" >Cash</td>
  </tr>
  <tr>
    <td class="chaqu" style="border-bottom:none; border-right:1px solid #666;border-Bottom:1px solid #666; ">Denomination</td>
    <td class="chaqu" style="border-bottom:none; border-right:none;border-Bottom:1px solid #666; ">Pieces</td>
  </tr>
</table>
</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="19"></td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                        </table>
                    </td>
                    <td>
                    	<table width="100%" border="0" cellspacing="0" cellpadding="0" >
                          <tr>
                            <td class="chaqu" height="40" style="border-top:1px solid #666;border-Left:1px solid #666; ">Rs</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20" style="border-Left:1px solid #666;">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20" style="border-Left:1px solid #666;">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20" style="border-Left:1px solid #666;">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20" style="border-Left:1px solid #666;">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20" style="border-Left:1px solid #666;">&nbsp;</td>
                          </tr>
                          <tr>
                            <td  class="chaqu" height="20" style="border-Left:1px solid #666;">&nbsp;</td>
                          </tr>
                        </table>
                    </td>
                    <td>
                    	<table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #666; ">
                          <tr>
                            <td class="chaqu" height="40">Ps</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20">&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="chaqu" height="20" style="border-bottom:none;">&nbsp;</td>
                          </tr>
                        </table>
                    </td>
                  </tr>
                </table>

            </td>
            <td width="30%" ><table width="100%" border="0" cellspacing="0" cellpadding="0" >
  <tr>
    <td valign="middle" align="center"> If Cash > Rs. 50,000 P AN / GIR</td>
  </tr>
  <tr>
    <td align="center"><table width="200" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #666;">
  <tr>
    <td class="sbi_acc">1</td>
                				<td class="sbi_acc">1</td>
                				<td class="sbi_acc">1</td>
                                <td class="sbi_acc">1</td>
                                <td class="sbi_acc">1</td>
                                <td class="sbi_acc">1</td>
                                <td class="sbi_acc">1</td>
                                <td class="sbi_acc" style="border-right:none;">1</td>
  </tr>
</table></td>
  </tr>
</table>
</td>
          </tr>
        </table>

    </td>
  </tr>
  
  <!--------Chaque------->
  
  <tr>
  <td height="10"> </td>
  
  </tr>
  
  <!------deposti------>
  <tr>
  <td><table width="800" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">Deposited By: </td>
    <td align="left">Contact No./Mobile No.</td>
  </tr>
</table>

  </td>
  
  
  </tr>
  
  <!------deposti------>
  <!-----line---->
  <tr>
  <td height="2"> </td>
  
  </tr>
   <tr>
  <td height="1" bgcolor="#666"> </td>
  
  </tr>
  
  
  
   <!-----line---->
   <!----bank use----->
   <tr>
   <td align="center"> For Bank use Only</td>
   
   
   </tr>
   
   <!----bank use----->
   <!------casher----->
   
   <tr>
  <td><table width="800" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">Cashier's Sl No.: </td>
    <td align="center">Cashier</td>
  </tr>
</table>

  </td>
  
  
  </tr>
   <tr>
  <td height="2"> </td>
  
  </tr>
  <tr>
  <td><table width="800" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">Cashier/Passing Officer: </td>
    <td align="center">Journal No.:</td>
  </tr>
</table>

  </td>
  
  
  </tr>
   
    <!------casher----->
     <!-----line---->
     <tr>
  <td height="5"> </td>
  
  </tr>
     
     
    <tr>
  <td height="1" bgcolor="#666"> </td>
  
  </tr>
   <!-----line---->
   
   <tr>
   <td align="center" class="head">Instructions to Core Banking Branches of State Bank of India:</td>
   
   
   </tr>
    <tr>
  <td align="left">1.  Acceptance of Amount by all Core Banking Branches for direct credit to FlightRaja Travels Pvt Ltd., 
Bangalore, account </td>
  
  </tr>
  <tr>
  <td align="left">2. Please enter the  Agent Code in and Agent Name in the deposit entry of core banking system
 </td>
  
  </tr>
  <tr>
  <td align="left">3. Please write the Journal number on the Challan Copy and hand over a copy to the remitter
 </td>
  
  </tr>
   <tr>
  <td align="left">3. Please write the Journal number on the Challan Copy and hand over a copy to the remitter
 </td>
  
  </tr>
  <tr>
  <td align="left">4. E-circular No. NBG/SMEBU-POWERJYOTHI/60/2009-10Date: 08/01/2010
 </td>
  
  </tr>
   
   
</table>

    
    
    </td>
  </tr>
</table>

<table width="100%" >
    <tr>
        <td align="center">
            <input id="btPrint" type="button" value="PRINT"  onclick="print();"/>
        </td>
    </tr>
</table>

</body>
</html>
