<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PinbleCustomService.aspx.cs"
    Inherits="Pbzx.Web.PinbleCustomService" %>

<script language="javascript" type="text/javascript">
if (document.all)
document.write(' <layer class="NS" onmouseover="move(580,0)" onmouseout="move(-580, 0)" left="0" name="object1" visibility="hide" top="20"> ')

</script>




    
   


   <!-- ×óÒþ²Ø²Ëµ¥¿ªÊ¼ -->
<script language="javascript" type="text/javascript">
function move(x, y) {
if (document.all) {
object1.style.pixelLeft += x;
object1.style.pixelTop  += y;}
else
if (document.layers) {
document.object1.left += x;
document.object1.top  += y;
}};

function position() {
document.object1.left += -200;
document.object1.top  += 0;
document.object1.visibility = "show"
};

function makeStatic() {
if (document.all) {object1.style.pixelTop=document.body.scrollTop+100}
else {eval('document.object1.top=eval(window.pageYOffset+20)');}
setTimeout("makeStatic()",0);}
function ShowKF(myWidth,myHeight)
{    
    window.open('http://www.pinble.com/kfclient.htm','newwindow','height='+myHeight+', width='+myWidth+', top='+(screen.height-500)/2+',left='+(screen.width-800)/2+',toolbar=no,menubar=no,scrollbars=no,center=yes, resizable=no,location=no, status=no');  
}
    </script>
<!-- ×óÒþ²Ø²Ëµ¥½áÊø -->
  
   
<script language="javascript" type="text/javascript">
if (document.all)
document.write('<DIV ID="object1" style="Position : Absolute ;Left : -125px ;Top : 20px ;Width : 0px ;Z-Index : 20"><TABLE onmouseover="move(120,0)" onMouseOut="move(-120, 0)" cellSpacing="1" cellPadding="2" border="0"> <TR><TD><IMG height="160" alt="" src="/Images/Web/servicepic_01.jpg" width="118"  border="0" name="servicepic_01" onclick="ShowKF(696,566)"> </TD> <TD valign="top" align=middle width=12><IMG height=109 src="/Images/Web/kefu.gif" width=20> </TD></TR> </TABLE>')
</script>

 
<script language="javascript" type="text/javascript">
if (document.all)
document.write('<\/DIV>')
</script>


<script language="javascript" type="text/javascript">
if (document.all)
document.write('</layer> ')

</script>
