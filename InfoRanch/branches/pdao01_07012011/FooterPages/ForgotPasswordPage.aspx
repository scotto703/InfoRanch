<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/InfoRanchGlobal.Master" CodeBehind="ForgotPasswordPage.aspx.vb" Inherits="InfoRanch.ForgotPasswordPage" 
    title="Forgot Password Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="InfoRanchGlobalContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="UserNameTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="UserName" runat="server" Text="Email:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="EmailTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Button ID="SubmitBTN" runat="server" Text="Submit" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
