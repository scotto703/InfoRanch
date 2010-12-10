<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="AddEdit.aspx.vb" Inherits="InfoRanch.AddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="addedLabel" runat="server" Text="Critter Added Successfully" 
        Font-Bold="True" Font-Names="Arial" ForeColor="Maroon"></asp:Label>
    <asp:Repeater ID="coral" runat="server">
    </asp:Repeater><br />
<asp:Button ID="addButton" runat="server" Text="Add Critter" />
<asp:Button ID="updateButton" runat="server" Text="Update Critter" />
    <asp:Button ID="editButton" runat="server" Text="Edit Critter" />
<asp:Button ID="deleteButton" runat="server" Text="Delete Critter" 
        CausesValidation="False" />
    <asp:Button ID="resetButton" runat="server" Text="Reset" 
        CausesValidation="False" />
    <asp:Button ID="cancelButton" runat="server" Text="Leave Stall" 
        CausesValidation="False" />
    <br />
    <br />
    <br />
    <br />
    
    <br />
    <br />
    <br />
    <br />
</asp:Content>

