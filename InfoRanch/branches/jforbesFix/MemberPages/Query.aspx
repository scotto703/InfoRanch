<%@ Page Title="Search Information Page" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="Query.aspx.vb" Inherits="InfoRanch.Query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 683px">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" 
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
            <td style="width: 683px">
                &nbsp;<asp:Label ID="Label3" runat="server" Text="Search By: "></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            &nbsp;
                <asp:Label ID="Label2" runat="server" Text="That Equals: "></asp:Label>
            &nbsp;
                <asp:TextBox ID="SearchTB" runat="server"></asp:TextBox>
                <asp:GridView ID="GridView1" runat="server" Width="404px" BorderColor="Black" 
                    BorderStyle="Double" CellPadding="1" CellSpacing="1" Font-Bold="True" 
                    Font-Names="Arial">
                    <RowStyle BorderColor="Maroon" />
                    <HeaderStyle BorderColor="Maroon" ForeColor="Maroon" />
                    <EditRowStyle BorderColor="Maroon" />
                </asp:GridView>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:user_DBConnectionString %>" 
                     SelectCommand="SELECT Books From [FieldList] where Books <> 'ID'" ProviderName="System.Data.SqlClient">
                   
                    </asp:SqlDataSource>
               
        
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
        
       
        
        
        
        
        
    </table>
</asp:Content>
