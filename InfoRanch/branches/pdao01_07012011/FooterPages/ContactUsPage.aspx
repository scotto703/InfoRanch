<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/InfoRanchGlobal.Master" CodeBehind="ContactUsPage.aspx.vb" Inherits="InfoRanch.ContactUsPage" 
    title="Contact Us Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="InfoRanchGlobalContent" runat="server">

<h5 align=center style='text-align:center'><span style='font-size:14.0pt;
mso-fareast-font-family:"Times New Roman"'>You can contact us by filling out the 
    following:<o:p></o:p></span></h5>

<form>

<h5 align=center style='text-align:center'><span style='font-size:14.0pt;
mso-fareast-font-family:"Times New Roman"'>I am a: <br>
    <asp:RadioButton ID="memberRB" runat="server" Text="Member" />
    <br>
    <asp:RadioButton ID="nonmemberRB" runat="server" Text="Non Member" />
    <o:p></o:p></span></h5>

<h5 align=center style='text-align:center'><span style='font-size:14.0pt;
mso-fareast-font-family:"Times New Roman"'><br>
Email address: 
    <asp:TextBox ID="emailTB" runat="server"></asp:TextBox>
    <o:p></o:p></span></h5>

<h5 align=center style='text-align:center'><span style='font-size:14.0pt;
mso-fareast-font-family:"Times New Roman"'>What can we help you with, partner? <o:p></o:p></span></h5>

<h5 align=center style='text-align:center'><span style='font-size:14.0pt;
mso-fareast-font-family:"Times New Roman"'><br>
    <asp:TextBox ID="commentsTB" runat="server" Height="106px" Width="338px"></asp:TextBox>
    <o:p></o:p></span></h5>

<h5 align=center style='text-align:center'><span style='font-size:14.0pt;
mso-fareast-font-family:"Times New Roman"'><br>
    <asp:Button ID="sumbitBTN" runat="server" Text="Submit" />
    <asp:Button ID="clearBTN" runat="server" Text="Clear" />
    <asp:Button ID="returnBTN" runat="server" Text="Home" />
    <o:p></o:p></span></h5>

</form>

    <p>
    
</p>

</asp:Content>
