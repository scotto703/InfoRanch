﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="DataBasePage.aspx.vb" Inherits="InfoRanch.DataBasePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        DataKeyNames="ID" DataSourceID="SqlDataSource1">
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
