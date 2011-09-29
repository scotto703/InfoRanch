<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/InfoRanchGlobal.Master" CodeBehind="testCustomDatabase.aspx.vb" Inherits="InfoRanch.testCustomDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="InfoRanchGlobalContent" runat="server">

    <div id="mainContent">
<table style="width: 100%; height: 509px; background-color:#99CCFF;">
        <tr>
            <td style="width: 766px">
                <asp:Label ID="titleLabel" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="Large" ForeColor="Maroon" Text="Build your custom database"></asp:Label>
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
            <td style="width: 766px">
                <div id = "instructionsDiv" runat="server" 
                    style="font-family: Arial; font-size: medium; color: #800000">
                    <b>Instructions</b><br />
                    Your first data field should be a descriptive one that will help you to know what 
                    kind of data are in it at a glance. For example, for a data field that holding 
                    names of Magazines the &quot;Magazine&quot; word for the field name would be appropriate.<br /><br />
                    Choose a data type for the data that will go in the data field.<br />
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
            <td style="width: 766px; height: 23px;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="Start to build your custom database or data table below now: "></asp:Label>&nbsp;</td>
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
            <td style="height: 30px; width: 766px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="coralCnameLabel" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="Enter Your Database Name below: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td style="height: 30px">
                </td>
            <td style="height: 30px">
                </td>
            <td style="height: 30px">
                </td>
            <td style="height: 30px">
                </td>
            <td style="height: 30px">
                </td>
        </tr>
        <tr>
            <td style="width: 766px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="NameTB" 
                    runat="server" Width="257px"></asp:TextBox>
                &nbsp;<asp:Label ID="wantMoreFieldsLabel" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="Do you want more fields?"></asp:Label>
&nbsp;
                <asp:Button ID="yesBTN" runat="server" Text="Yes" />
                &nbsp;&nbsp;
                <asp:Button ID="noBTN" runat="server" Text="No" />
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
            <td style="width: 766px; height: 31px">
                <asp:Label ID="stallNameLabel" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="Medium" ForeColor="Maroon" 
                    Text="Enter Your First Data Field Names (up to 5) below: "></asp:Label>
                <asp:Label ID="stallNameLabel2" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="Medium" ForeColor="Maroon" 
                    Text="Enter Your Next Data Field Names (up to 5) below: "></asp:Label>
                &nbsp;
                &nbsp;&nbsp;
                <asp:Label ID="dataTypeLabel" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="Medium" ForeColor="Maroon" 
                    Text="Select Data field type below: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td style="height: 31px">
                </td>
            <td style="height: 31px">
                </td>
            <td style="height: 31px">
                </td>
            <td style="height: 31px">
                </td>
            <td style="height: 31px">
                </td>
        </tr>
        <tr>
            <td style="width: 766px; height: 30px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="fieldnameLabel1" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="field name:"></asp:Label>
                <asp:TextBox ID="categoryTB" runat="server" Width="260px"></asp:TextBox>
                <asp:DropDownList ID="dataTypeDropDown" runat="server" Width="216px">
                    <asp:ListItem Value="varchar(50)">Short Text</asp:ListItem>
                    <asp:ListItem Value="text">Long Text</asp:ListItem>
                    <asp:ListItem Value="int">Whole Number</asp:ListItem>
                    <asp:ListItem Value="real">Decimal</asp:ListItem>
                    <asp:ListItem Value="numeric(15,2)">Money</asp:ListItem>
                    <asp:ListItem Value="date">Date</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="height: 30px">
                </td>
            <td style="height: 30px">
                </td>
            <td style="height: 30px">
                </td>
            <td style="height: 30px">
                </td>
            <td style="height: 30px">
                </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 766px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="fieldnameLabel2" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="field name:"></asp:Label>
                <asp:TextBox ID="categoryTB2" runat="server" Width="260px"></asp:TextBox>
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
            <td style="width: 766px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="fieldnameLabel3" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="field name:"></asp:Label>
                <asp:TextBox ID="categoryTB3" runat="server" Width="260px"></asp:TextBox>
                <asp:DropDownList ID="dataTypeDropDown3" runat="server" Width="216px">
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
            <td style="width: 766px; height: 23px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="fieldnameLabel4" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="field name:"></asp:Label>
                <asp:TextBox ID="categoryTB4" runat="server" Width="260px"></asp:TextBox>
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
            <td style="width: 766px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="fieldnameLabel5" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="field name:"></asp:Label>
                <asp:TextBox ID="categoryTB5" runat="server" Width="260px"></asp:TextBox>
                <asp:DropDownList ID="dataTypeDropDown5" runat="server" Width="216px">
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
            <td style="width: 766px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Submit" runat="server" Text="Submit" Width="68px" />
                <asp:Button ID="Submit2" runat="server" Text="Submit" Width="68px" />
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
    </table>
        </div>


<div id="links">
<div id="LinkText">
  
    <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" Font-Bold="True">Site Options</asp:TextBox>
  
    <asp:HyperLink ID="MemberHomePageHL" runat="server" 
        NavigateUrl="~/MemberPages/MemberPageHome.aspx">Member Homepage</asp:HyperLink>
    <br />
    <asp:HyperLink ID="UpdateUserInfoHL" runat="server" 
        NavigateUrl="~/FooterPages/RegisterPage.aspx">Update Your Info</asp:HyperLink>
    <br />
    <asp:HyperLink ID="UpgradeMembershipHL" runat="server" 
    NavigateUrl="~/MemberPages/UpgradeMembershipPage.aspx">Upgrade Membership</asp:HyperLink>
    
    
    
    <br />
    <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" Font-Bold="True" 
        Height="17px" Width="134px">Build New Database</asp:TextBox>
    <br />
    
    
    
    <asp:HyperLink ID="TemplateDatabaseHL" runat="server"
    NavigateUrl="~/MemberPages/DatabaseTemplates.aspx">Template Database</asp:HyperLink>
    <br />
    <asp:HyperLink ID="CustomDatabaseHL" runat="server"
    NavigateUrl="~/MemberPages/CustomDataBase.aspx">Custom Database</asp:HyperLink>
    
    <br />

    <asp:TextBox ID="TextBox3" runat="server" BorderStyle="None" Font-Bold="True">Print Options</asp:TextBox>
    <br />
    <asp:HyperLink ID="HLprintpre" runat="server">Print Preview</asp:HyperLink>
    <br />
    <asp:Label ID="PrintLabel" runat="server" Text="Print"></asp:Label>
    <br />
    
    <br />
    <asp:HyperLink ID="LogOutHL" runat="server"
    NavigateUrl="~/InfoRanch.aspx">Logout</asp:HyperLink>
    
    <br />

</div>
</div>









</asp:Content>

