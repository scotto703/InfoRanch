<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="CustomConfirm.aspx.vb" Inherits="InfoRanch.CustomConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="titleLabel" runat="server" Font-Bold="True" Font-Names="Arial" 
        Font-Size="Larger" ForeColor="Maroon" Text="Coral Creation Confirmation"></asp:Label>
    <br />
    <br />
    <asp:Label ID="instructLabel" runat="server" Font-Bold="True" 
        Font-Names="Arial" Font-Size="Medium" ForeColor="Maroon" 
        Text="Look over the Coral details"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="customCoralGrid" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <br />
    <asp:Label ID="yesNoLael" runat="server" Font-Bold="True" Font-Names="Arial" 
        Font-Size="Medium" ForeColor="Maroon" Text="Is this correct?  "></asp:Label>
    <asp:Button ID="yesButton" runat="server" Text="Yes" />
    <asp:Button ID="noButton" runat="server" Text="No" />
    <asp:Button ID="cancelButton" runat="server" Text="Cancel" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
