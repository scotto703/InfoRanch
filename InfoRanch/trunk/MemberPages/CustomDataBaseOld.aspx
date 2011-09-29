<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="CustomDataBaseOld.aspx.vb" Inherits="InfoRanch.CustomDataBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="titleLabel" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="Large" ForeColor="Maroon" Text="Build your custom coral"></asp:Label>
            </td>
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
                <div id = "instructionsDiv" runat="server" 
                    style="font-family: Arial; font-size: medium; color: #800000">
                    <b>Instructions</b><br />
                    Your first stall should be a descriptive one that will help you know what critters are in it at a glance.  For example, for a Magazines stall the Magazine Name would be appropriate.<br /><br />
                    Choose a type of critter that will go in the stall.<br />
                    <ul>
                    <li>Short Text - 50 or less characters on a single line</li>
                    <li>Long Text - Any number of characters and can be on multiple lines</li>
                    <li>Whole Number - A non decimal number</li>
                    <li>Decimal - A decimal number</li>
                    <li>Money - Specifically a monetaory amount</li>
                    <li>Date - A date</li>
                    </ul>
                </div>
            </td>
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
                <asp:Label ID="coralCnameLabel" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="Name your coral: "></asp:Label>
&nbsp;<asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
                <asp:Label ID="stallNameLabel" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="Medium" ForeColor="Maroon" Text="Name A stall: "></asp:Label>
                <asp:TextBox ID="categoryTB" runat="server"></asp:TextBox>
                <asp:Label ID="anotherLabel" runat="server" Font-Names="Arial" ForeColor="Maroon" 
                    Text="Would you like to add another stall?"></asp:Label>
                <asp:Button ID="YesBTN" runat="server" Text="Yes" />
&nbsp;
                <asp:Button ID="NoBTN" runat="server" Text="No" />
            </td>
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
                <asp:Label ID="dataTypeLabel" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="Medium" ForeColor="Maroon" Text="Type of Stall: "></asp:Label>
                <asp:DropDownList ID="dataTypeDropDown" runat="server">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
            </td>
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
                <asp:Button ID="SubmitNameBTN" runat="server" Text="Submit" />
                <asp:Button ID="submitCategoryBTN" runat="server" Text="Submit" />
                <asp:Button ID="submitCategory2BTN" runat="server" Text="Submit" />
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" />
            </td>
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
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
