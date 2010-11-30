Imports System.Data
Imports Npgsql
Imports InfoRanch.Util

Partial Public Class InfoRanch
    Inherits System.Web.UI.Page

    ' Connection string to the administration DB

    Dim DBConn As New NpgsqlConnection("Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=administration;Timeout=30")
    Dim DBCmd As New NpgsqlCommand
    Dim DBAdap As New NpgsqlDataAdapter
    Dim DS As New DataSet
    Dim encrypted As New Encryption


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        Dim dr As NpgsqlDataReader
        DBConn.Open()

        ' query the member authentication table
        Dim sql As NpgsqlCommand = New NpgsqlCommand("SELECT * FROM member_authentication WHERE user_name ='" _
            & userNameTB.Text & "' and user_password = @password", DBConn)
        sql.Parameters.AddWithValue("@password", encrypted.encrypt(userPasswordTB.Text))

        dr = sql.ExecuteReader

        ' if the user id and password match, then the Session variable is assigned
        ' the user id value and re-directs to MemberPageHome.aspx

        If dr.HasRows Then
            Session("user_id") = userNameTB.Text
            Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)
        Else
            LoginError.Visible = True
            userNameTB.Text = String.Empty
            userPasswordTB.Text = String.Empty
            userNameTB.Focus()
        End If

        dr.Close()
        DBConn.Close()

    End Sub
End Class