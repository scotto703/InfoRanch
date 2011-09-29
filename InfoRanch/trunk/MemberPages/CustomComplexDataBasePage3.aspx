<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="CustomComplexDataBasePage3.aspx.vb" Inherits="InfoRanch.CustomComplexDataBasePage3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 509px; background-color:#99CCFF;">
        <tr>
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="coralCnameLabel" runat="server" Font-Names="Arial" Font-Size="Small" 
                    ForeColor="Maroon" 
                    Text="Please enter the name for the first table (or accept the default): "></asp:Label>
                &nbsp;
                <asp:TextBox ID="NameTB" 
                    runat="server" Width="257px">stock_item</asp:TextBox>
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
            <td style="width: 800px; height: 23px">
                &nbsp;
                <asp:Label ID="stallNameLabel" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="X-Small" ForeColor="Maroon" 
                    
                    Text="Please enter the name for each data field in each textbox below (or accept the default):"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="dataTypeLabel" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="X-Small" ForeColor="Maroon" 
                    Text="Please select a data type for each data field:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
            <td style="width: 800px; height: 23px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="fieldnameLabel1" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="primary key:"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="categoryTB" runat="server" Width="260px">record number</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="height: 23px; width: 800px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB2" runat="server" Width="260px">name</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown2" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="fieldnameLabel5" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="foreign key:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB3" runat="server" Width="260px">description</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown3" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="fieldnameLabel4" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="foreign key:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB4" runat="server" Width="260px">supplier ID</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown4" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB5" runat="server" Width="260px">order price</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown5" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="height: 23px; width: 800px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB6" runat="server" Width="260px">sale price</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown6" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB7" runat="server" Width="260px">units in stock</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown7" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB8" runat="server" Width="260px">units on order</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown8" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB9" runat="server" Width="260px">discontinued</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown9" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB10" runat="server" Width="260px">discontinued</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown10" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="categoryTB11" runat="server" Width="260px">discontinued</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dataTypeDropDown11" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
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
            <td style="width: 800px; height: 23px;">
                <asp:Button ID="Submit" runat="server" Text="Submit" Width="68px" />
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" />
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
    </table>
</asp:Content>
