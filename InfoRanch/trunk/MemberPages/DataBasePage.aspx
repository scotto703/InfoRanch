﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="DataBasePage.aspx.vb" Inherits="InfoRanch.DataBasePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                <asp:Label ID="welcomeMsg" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="15pt" ForeColor="Maroon"></asp:Label>
                <br />
    <br />
    <asp:Button ID="addItemBtn" runat="server" Text="Add New Item" />
    <asp:Button ID="returnButton" runat="server" Text="Change Stall" />
    <asp:Button ID="queryBtn" runat="server" Text="Search Stall" />
    <asp:Button ID="deleteButton" runat="server" style="margin-bottom: 0px" 
        Text="Delete Stall" />
    <asp:GridView ID="stallContents" runat="server" AllowPaging="True" 
        AutoGenerateSelectButton="True" Font-Names="Arial">
    </asp:GridView>
    
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    ForeColor="Maroon" Text="       "><br /></asp:Label>
    
    
    
</asp:Content>
