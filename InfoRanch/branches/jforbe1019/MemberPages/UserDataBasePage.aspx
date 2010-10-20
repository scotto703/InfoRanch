<%@ Page Language="vb" Debug ="false"  AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/MemberPage.master" CodeBehind="UserDataBasePage.aspx.vb" Inherits="InfoRanch.UserDataBasePage" 
    title="User Database Page" %>
<%@ Register assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.DynamicData" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
        Font-Size="Large" ForeColor="Maroon" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Maroon"></asp:Label>
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
        Font-Size="X-Large" ForeColor="Maroon"></asp:Label>
&nbsp;<asp:Button ID="YesBTN" runat="server" Text="Yes" />
&nbsp;<asp:Button ID="NoBTN" runat="server" Text="No" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;<table style="width: 100%">
        <tr>
            <td style="width: 41px" colspan="6">
                <asp:Panel ID="Panel1" runat="server" Width="607px">
                    <asp:Button ID="AddRecordBTN" runat="server" Text="Add Information" 
                        ToolTip="Press this button to add information to your table." 
                        Width="95px" />
                    <asp:Button ID="DeleteRecordBTN" runat="server" Text="Delete Information" 
                        ToolTip="Press this button to remove information from your table." 
                        Width="108px" />
                    <asp:Button ID="QueryTable" runat="server" Text="Search Information" 
                        Width="112px" />
                    <asp:Button ID="DifferentTable" runat="server" Text="Different Database" 
                        Width="110px" />
                    <asp:Button ID="DeleteTable" runat="server" Text="Delete Database" 
                        Width="102px" />
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 102px">
                &nbsp;</td>
            <td style="width: 9px">
                &nbsp;</td>
            <td style="width: 102px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 102px; height: 26px" colspan="6">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
                    RepeatDirection="Horizontal">
                    <ItemTemplate>
                        
                        <asp:Label ID="fieldsLabel" runat="server" Text='<%# Eval(Session("user_table")) %>'></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td style="width: 102px; height: 26px">
                &nbsp;</td>
            <td style="width: 102px; height: 26px">
                &nbsp;</td>
            <td style="width: 9px; height: 26px">
                &nbsp;</td>
            <td style="width: 67px; height: 26px">
                &nbsp;</td>
            <td style="height: 26px">
                &nbsp;</td>
        </tr>
        <tr>
        <td style="width: 125px; height: 26px" rowspan="2">
                <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" DataSourceID="SqlDataSource2" 
                    Width="404px" BorderColor="Black" CellPadding="1" 
                    HorizontalAlign="Center" BorderStyle="Double" CellSpacing="1" 
                    Font-Bold="True" Font-Names="Arial">
                    <RowStyle BorderColor="Maroon" BorderStyle="Double" />
                    <Columns>
                        <asp:TemplateField>
                         <ItemTemplate>
                        <asp:CheckBox ID="chkRows" runat="server"/>
                        </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <SelectedRowStyle BackColor="Black" />
                    <HeaderStyle BorderColor="Black" ForeColor="Maroon" HorizontalAlign="Center" 
                        VerticalAlign="Middle" />
                    <EditRowStyle BorderStyle="Double" BorderWidth="5px" />
                    <AlternatingRowStyle BorderStyle="Groove" />
                </asp:GridView>
                
        
        </td>
        
        
        
        
       
        
        
        
        
        <td style="width: 61px; height: 26px">
                &nbsp;</td>
        
        
        
        
       
        
        
        
        
        <td style="width: 145px; height: 26px">
                &nbsp;</td>
        
        
        
        
       
        
        
        
        
        <td style="width: 135px; height: 26px">
                &nbsp;</td>
        
        
        
        
       
        
        
        
        
        <td style="width: 113px; height: 26px" rowspan="2">
                &nbsp;</td>
        
        
        
        
       
        
        
        
        
        </tr>
        <tr>
        <td style="width: 61px; height: 26px">
                &nbsp;</td>
        
        
        
        
       
        
        
        
        
        <td style="width: 145px; height: 26px">
                &nbsp;</td>
        
        
        
        
       
        
        
        
        
        <td style="width: 135px; height: 26px">
                &nbsp;</td>
        
        
        
        
       
        
        
        
        
        </tr>
        <tr>
        
               
            <td style="width: 102px; height: 27px" colspan="6">
                <asp:Button ID="AddBTN" runat="server" Text="Add" Width="55px" />
                <asp:Button ID="DeleteBTN" runat="server" Text="Delete" />
            </td>
            
        </tr>
        <tr>
            <td style="width: 113px; height: 26px" colspan="5">
                <br />
            </td>
            <td style="width: 41px; height: 26px">
                &nbsp;</td>
            <td style="height: 26px" rowspan="3">
                &nbsp;</td>
            <td style="width: 109px; height: 26px" rowspan="3">
                &nbsp;</td>
            <td style="width: 9px; height: 26px" rowspan="3">
                &nbsp;</td>
            <td style="width: 67px; height: 26px" rowspan="3">
                &nbsp;</td>
            <td style="height: 26px" rowspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 41px; height: 26px" colspan="6">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                   
                     ProviderName="System.Data.SqlClient">
                  
                   


                    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                 InsertCommand="INSERT INTO [Books] ([Author], [Title], [ID]) VALUES (@Author, @Title, @ID)" 
                    ProviderName="System.Data.SqlClient" >
                    <InsertParameters>
                        <asp:Parameter Name="Author" Type="String" />
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter Name="ID" Type="Int32" />
                    </InsertParameters>
                    <DeleteParameters>
           <asp:Parameter Name="ID" />
       </DeleteParameters>
</asp:SqlDataSource>            
              
               
        
            </td>
        </tr>
        <tr>
            <td style="width: 41px; height: 26px" colspan="6">
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
