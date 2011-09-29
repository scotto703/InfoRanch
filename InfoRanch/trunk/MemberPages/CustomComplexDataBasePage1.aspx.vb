Imports System.Data
Imports Npgsql
Imports InfoRanch.DB
Public Class CustomComplexDataBase

    Inherits System.Web.UI.Page
    Dim DBCmd As New NpgsqlCommand
    Dim name As String
    Dim myConn As New DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("selected_model") = "inventory" Then
            NameTB.Text = "inventory"
        End If
        If Session("selected_model") = "corporate_employee" Then
            NameTB.Text = "corporate_employee"
        End If
        If Session("selected_model") = "acquaintance_information" Then
            NameTB.Text = "acquaintance_information"
        End If

    End Sub

    Protected Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        ' connects to the user database
        Dim DBConn As NpgsqlConnection = myConn.connect(Session("user_id"))

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
            If Replace(NameTB.Text, " ", "_") & "_complex" = curDBReader(0) Then
                MsgBox("'" & Replace(NameTB.Text, " ", "_") & "'" & " was already used before, please choose a different name", MsgBoxStyle.Information)
                NameTB.Text = ""
                curDBReader.Close()
                Response.Redirect("~/MemberPages/CustomComplexDataBasePage1.aspx")
            End If
        End While

        Conn.Close()
        '==================================================================

        name = Replace(NameTB.Text, " ", "_")
        DBConn.Open()
        ' New complex database 'table' to tablelist
        DBCmd = New NpgsqlCommand("INSERT INTO tablelist VALUES ('" & name & "_complex" & "')", DBConn)
        DBCmd.ExecuteNonQuery()
        ' creates 'customComplexDatabasE Tablelist' table 
        DBCmd = New NpgsqlCommand("CREATE TABLE " & name & "_complex" & "(list varchar(50))", DBConn)
        DBCmd.ExecuteNonQuery()
        Session("complex_database") = name & "_complex"
        DBConn.Close()
        Response.Redirect("~/MemberPages/CustomComplexDataBasePage2.aspx")
    End Sub

    Protected Sub Cancel_Click(sender As Object, e As EventArgs) Handles BTN.Click
        Response.Redirect("~/MemberPages/MemberPageHome.aspx")
    End Sub
End Class