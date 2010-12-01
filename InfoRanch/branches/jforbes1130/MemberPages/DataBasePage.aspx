<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="DataBasePage.aspx.vb" Inherits="InfoRanch.DataBasePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="addItemBtn" runat="server" Text="Add New Item" />
    <asp:Button ID="returnButton" runat="server" Text="Change Stall" />
    <asp:Button ID="queryBtn" runat="server" Text="Search Stall" />
    <asp:GridView ID="stallContents" runat="server" AllowPaging="True" 
        DataKeyNames="ID" DataSourceID="SqlDataSource1" Font-Names="Arial">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
