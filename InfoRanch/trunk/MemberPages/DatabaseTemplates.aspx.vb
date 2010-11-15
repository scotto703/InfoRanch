Imports System.Data
Imports Npgsql

Partial Public Class DatabaseTemplates
    Inherits System.Web.UI.Page

    Dim DBCmd = New NpgsqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        ' connects to the templates database

        SqlDataSource1.ConnectionString = "Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=templates_database;Timeout=30"
        SqlDataSource1.ProviderName = "Npgsql"

        ' queries the database names and loads the results to the radio button list
        SqlDataSource1.SelectCommand = "SELECT fields FROM template_names"




       
    End Sub

    

    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        ' assigns the value to the session variable

        Session("template_selection") = templateList.SelectedValue

        Server.Transfer("~/MemberPages/TemplatePage.aspx", True)




    End Sub
End Class





