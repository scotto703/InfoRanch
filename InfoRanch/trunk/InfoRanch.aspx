<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/InfoRanchGlobal.Master" CodeBehind="InfoRanch.aspx.vb" Inherits="InfoRanch.InfoRanch" 
    title="InfoRanch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="InfoRanchGlobalContent" runat="server">
    <table style="width: 99%; background-color: #99CCFF;">
        <tr>
            <td rowspan="1" style="width: 5840px" align="center">
                <asp:Label ID="Label6" runat="server" BackColor="#000099" Font-Bold="True" 
                    Font-Names="Arial" ForeColor="White" Height="29px" style="text-align: center" 
                    Text="Login" Width="292px" Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 5840px; height: 25px;" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 5840px; height: 25px;" align="center">
                <asp:Label ID="Label2" runat="server" style="text-align: right" 
                    Text="Username:" Width="116px"></asp:Label>
                <asp:TextBox ID="user_nameTB" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 5840px" align="center">
                <asp:Label ID="Label3" runat="server" style="text-align: right" 
                    Text="Password:" Width="116px"></asp:Label>
                <asp:TextBox ID="user_passwordTB" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 5840px" align="center">
                <asp:Button ID="SubmitBTN" runat="server" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td style="width: 5840px" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 5840px" align="center">
                <asp:Label ID="Label4" runat="server" style="text-align: right" 
                    Text="Not Registered?" Width="116px" Height="16px"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Overline="False" 
                    Font-Underline="True" NavigateUrl="~/FooterPages/RegisterPage.aspx">Register Now!</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 5840px" align="center">
                <asp:Label ID="Label5" runat="server" style="text-align: right" 
                    Text="Forgot Password?  " Width="116px"></asp:Label>
                <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" 
                    NavigateUrl="~/FooterPages/ForgotPasswordPage.aspx"> Reset Password</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 5840px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 5840px; height: 23px;" align="center">
                <asp:Label ID="LoginError" runat="server" ForeColor="Red" 
                    Text="Username and/or password are incorrect. Please try again." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 5840px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
