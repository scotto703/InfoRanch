<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="DatabaseTemplates.aspx.vb" Inherits="InfoRanch.DatabaseTemplates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <table style="width: 100%">
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            <asp:Label ID="selectDBHeader" runat="server" Font-Bold="True" Font-Names="Arial" 
                Font-Size="Large" ForeColor="Maroon" Text="Please select your database:"></asp:Label>
        </td>
        <td style="width: 194px">
            &nbsp;</td>
        <td style="width: 174px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            &nbsp;</td>
        <td style="width: 194px">
            &nbsp;</td>
        <td rowspan="6" style="width: 174px">
            &nbsp;</td>
        <td rowspan="6">
            &nbsp;</td>
        <td rowspan="6">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            
               
   
  <asp:RadioButtonList ID="templateList" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="fields" 
                DataValueField="fields">
            </asp:RadioButtonList>
                        
   
 
 </td>
   
   
   
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            &nbsp;</td>
        <td style="width: 194px">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            <asp:Button ID="SubmitBTN" runat="server" Text="Submit" />
            </td>
        <td style="width: 194px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            &nbsp;</td>
        <td style="width: 194px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            &nbsp;</td>
        <td style="width: 194px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            &nbsp;</td>
        <td style="width: 194px">
            &nbsp;</td>
        <td style="width: 174px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            &nbsp;</td>
        <td style="width: 194px">
            &nbsp;</td>
        <td style="width: 174px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 35px">
            &nbsp;</td>
        <td style="width: 703px">
            &nbsp;</td>
        <td style="width: 194px">
            &nbsp;</td>
        <td style="width: 174px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
</asp:Content>
