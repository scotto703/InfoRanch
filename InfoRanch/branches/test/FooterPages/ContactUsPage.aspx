<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/InfoRanchGlobal.Master" CodeBehind="ContactUsPage.aspx.vb" Inherits="InfoRanch.ContactUsPage" 
    title="Contact Us Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="InfoRanchGlobalContent" runat="server">
    <p>
    <table style="width: 100%">
        <tr>
            <td style="width: 93px; height: 40px">
                <asp:Label ID="Label2" runat="server" Text="Your Name:"></asp:Label>
                &nbsp;
            </td>
            <td class="style4" style="height: 40px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 93px; height: 40px">
                <asp:Label ID="Label3" runat="server" Text="Email Address:"></asp:Label>
            </td>
            <td class="style4" style="height: 40px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 93px; height: 29px">
                <asp:Label ID="Label4" runat="server" Text="Comment:"></asp:Label>
            </td>
            <td rowspan="3" style="height: 36px; width: 84px">
                <asp:TextBox ID="TextBox3" runat="server" Height="94px" Width="491px"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/InfoRanch.aspx" 
                    Text="Submit" />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 93px; height: 36px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 93px; height: 36px">
                &nbsp;</td>
        </tr>
        </table>
</p>

</asp:Content>
