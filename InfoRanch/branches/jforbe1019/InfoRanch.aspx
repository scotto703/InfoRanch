<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/InfoRanchGlobal.Master" CodeBehind="InfoRanch.aspx.vb" Inherits="InfoRanch.InfoRanch" 
    title="InfoRanch" %>
    
    
    
    
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="InfoRanchGlobalContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td rowspan="1" style="width: 1039px">
                <asp:Label ID="Label7" runat="server" BackColor="Maroon" Font-Bold="True" 
                    Font-Names="Arial" Font-Size="20pt" ForeColor="White" 
                    Text="Welcome To The InfoRanch!"></asp:Label>
            </td>
            <td colspan="2" style="height: 9px">
                <asp:Label ID="Label6" runat="server" BackColor="Maroon" Font-Bold="True" 
                    Font-Names="Arial" ForeColor="White" Height="21px" style="text-align: center" 
                    Text="Login" Width="292px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 22px">
            </td>
        </tr>
        <tr>
            <td style="width: 1039px">
                &nbsp;</td>
            <td style="width: 16px">
                <asp:Label ID="Label2" runat="server" style="text-align: right" 
                    Text="Username:" Width="116px"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="user_nameTB" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 1039px">
                <asp:Label ID="LoginError" runat="server" ForeColor="Red" 
                    Text="Username and/or password are incorrect. Please try again." 
                    Visible="False"></asp:Label>
            </td>
            <td style="width: 16px">
                <asp:Label ID="Label3" runat="server" style="text-align: right" 
                    Text="Password:" Width="116px"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="user_passwordTB" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 1039px">
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
            <td>
                <asp:Button ID="SubmitBTN" runat="server" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td style="width: 1039px">
                &nbsp;</td>
            <td style="width: 16px">
                <asp:Label ID="Label4" runat="server" style="text-align: right" 
                    Text="Not Registered?" Width="116px"></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Overline="False" 
                    Font-Underline="True" NavigateUrl="~/FooterPages/RegisterPage.aspx">Register Now!</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 1039px">
                &nbsp;</td>
            <td style="width: 16px">
                <asp:Label ID="Label5" runat="server" style="text-align: right" 
                    Text="Forgot Password?" Width="116px"></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" 
                    NavigateUrl="~/FooterPages/ForgotPasswordPage.aspx">Reset 
                Password</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 1039px">
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1039px">
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1039px">
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
