<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/InfoRanchGlobal.Master" CodeBehind="RegisterPage.aspx.vb" Inherits="InfoRanch.RegisterPage" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="InfoRanchGlobalContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label2" runat="server" Text="First Name:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="f_nameTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label3" runat="server" Text="Last Name:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="l_nameTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label4" runat="server" Text="Address 1:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="address_oneTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label5" runat="server" Text="Address2"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="address_twoTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label6" runat="server" Text="City:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="cityTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px; height: 23px">
                <asp:Label ID="Label7" runat="server" Text="State:"></asp:Label>
            </td>
            <td style="height: 23px; width: 169px">
                <asp:TextBox ID="stateTB" runat="server"></asp:TextBox>
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label8" runat="server" Text="Zip Code:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="zipTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label9" runat="server" Text="Phone Number:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="phoneTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="emailTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label11" runat="server" Text="Username:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="user_nameTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="Label13" runat="server" Text="Password:"></asp:Label>
            </td>
            <td style="width: 169px">
                <asp:TextBox ID="user_passwordTB" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label12" runat="server" 
                    Text="I am at least 18 years of age and I accept the "></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" 
                    ForeColor="Maroon" 
                    NavigateUrl="~/FooterPages/Inforanch_Terms_and_Conditions.pdf">Terms and 
                Conditions</asp:HyperLink>
&nbsp;&nbsp;
                <asp:CheckBox ID="AgreeCB" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                &nbsp;</td>
            <td style="width: 169px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Button ID="SubmitBTN" runat="server" 
                    Text="Submit" />
            </td>
            <td style="width: 169px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    
     </asp:Content>
