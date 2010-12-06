<%@ Page Title="Search Information Page" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="Query.aspx.vb" Inherits="InfoRanch.Query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 683px">
                <asp:Label ID="welcomeLbl" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 683px">
                &nbsp;</td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;<asp:Label ID="searchByLbl" runat="server" Text="Search By: "></asp:Label>
&nbsp;
                <asp:DropDownList ID="fieldDropDown" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            &nbsp;
                <asp:Label ID="thatLabel" runat="server" Text="That "></asp:Label>
            &nbsp;<asp:DropDownList ID="limitDropDown" runat="server" AutoPostBack="True">
                </asp:DropDownList>
&nbsp;<asp:TextBox ID="searchTB" runat="server"></asp:TextBox>
                <asp:GridView ID="searchResults" runat="server" Width="404px" CellPadding="1" 
                    CellSpacing="1" Font-Bold="False" 
                    Font-Names="Arial" AllowPaging="True" AutoGenerateSelectButton="True">
                    <RowStyle BorderColor="Maroon" />
                    <HeaderStyle BorderColor="Maroon" ForeColor="Maroon" />
                    <EditRowStyle BorderColor="Maroon" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 683px">
                &nbsp;</td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 683px">
                <asp:Button ID="SubmitBTN" runat="server" Text="Submit" />
            &nbsp;
                <asp:Button ID="Cancel1" runat="server" Text="Cancel" />
            &nbsp;
                <asp:Button ID="NewSearchBTN" runat="server" Text="New Search" />
            &nbsp;
                <asp:Button ID="Cancel2BTN" runat="server" Text="Cancel" />
           
            &nbsp;</td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            
            <td style="width: 102px; height: 26px" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 41px; height: 26px" colspan="4">
               
        
            &nbsp;
               
        
            </td>
        </tr>
        <tr>
            <td style="width: 683px">
            &nbsp;
                </td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 683px">
                &nbsp;</td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 683px">
                &nbsp;</td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 683px">
                &nbsp;</td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 683px">
                &nbsp;</td>
            <td style="width: 114px">
                &nbsp;</td>
            <td style="width: 209px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        
       
        
        
        
        
        
    </table>
</asp:Content>
