<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="CustomComplexDataBasePage.aspx.vb" Inherits="InfoRanch.CustomComplexDataBasePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="2" rowspan="2">
                <asp:Label ID="welcomeMsg" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="15pt" ForeColor="Maroon"></asp:Label>
                <br />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="selectDBHead" runat="server" ForeColor="Maroon" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 22px">
                </td>
            <td style="height: 22px">
                </td>
            <td style="height: 22px">
                </td>
            <td style="height: 22px">
                </td>
            <td style="height: 22px">
                </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="userDatabasesDD" runat="server" 
                    Font-Bold="True" Font-Names="Arial" Font-Size="Medium" 
                    Width="151px">
                </asp:DropDownList>
                <asp:Label ID="noDBMsg" runat="server" ForeColor="Maroon" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="SubmitBTN" runat="server" Text="Submit" style="height: 26px" />
    <asp:Button ID="deleteButton" runat="server" style="margin-bottom: 0px" 
        Text="Delete Complex Database" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px">
                </td>
            <td style="height: 23px">
                </td>
            <td style="height: 23px">
                </td>
            <td style="height: 23px">
                </td>
            <td style="height: 23px">
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

