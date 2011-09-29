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

        '==================================================================

        Dim userDatabase = Session("user_id").ToString()
        Dim Conn As New NpgsqlConnection
        Dim myCon As New DBConnection

        Conn = myCon.connect(userDatabase)

        Conn.Open()

        ' connection string with the Session variable "user_id"
        Dim cmd As NpgsqlCommand = New NpgsqlCommand("SELECT List from TableList", Conn)

        Dim curDBReader As NpgsqlDataReader

        curDBReader = cmd.ExecuteReader()

        While curDBReader.Read()
            If templateList.SelectedValue = curDBReader(0) Then
                MsgBox("'" & templateList.SelectedValue & "'" & " is already created, please choose a different template", MsgBoxStyle.Information)
                curDBReader.Close()
                Response.Redirect("~/MemberPages/DatabaseTemplates.aspx")
            End If
        End While

        Conn.Close()
        '==================================================================

        ' assigns the value to the session variable

        Session("template_selection") = templateList.SelectedValue

        Server.Transfer("~/MemberPages/TemplatePage.aspx", True)




    End Sub

    Protected Sub BTN_Click(sender As Object, e As EventArgs) Handles BTN.Click
        Response.Redirect("~/MemberPages/MemberPageHome.aspx")
    End Sub
End Class





