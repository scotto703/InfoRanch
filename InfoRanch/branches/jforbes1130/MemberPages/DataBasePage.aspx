<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="DataBasePage.aspx.vb" Inherits="InfoRanch.DataBasePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="addItemBtn" runat="server" Text="Add New Item" />
    <asp:Button ID="returnButton" runat="server" Text="Change Stall" />
    <asp:Button ID="queryBtn" runat="server" Text="Search Stall" />
    <asp:GridView ID="stallContents" runat="server" AllowPaging="True" 
        AutoGenerateSelectButton="True" Font-Names="Arial">
    </asp:GridView>
    
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
