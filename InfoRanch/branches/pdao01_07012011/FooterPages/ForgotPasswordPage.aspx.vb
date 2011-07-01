Imports System.Data
Imports Npgsql
Imports InfoRanch.Util
Imports InfoRanch.DB
Imports System.Net.Mail



Partial Public Class ForgotPasswordPage
    Inherits System.Web.UI.Page

    Dim DBCmd As New NpgsqlCommand
    Dim DBConn As New NpgsqlConnection
    Dim DBAdap As New NpgsqlDataAdapter
    Dim connect As New DBConnection
    Dim encrypted As New Encryption
    Dim encryptedPassword As Byte()
    Dim decryptedPassword As String
    Dim passwordReturn As NpgsqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Private Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitBTN.Click

        DBConn = connect.connect("administration")
        DBConn.Open()

        Dim userQuery As NpgsqlCommand = New NpgsqlCommand("SELECT user_name from member_authentication WHERE user_name ='" & UserNameTB.Text & "'", DBConn)
        Dim userName As NpgsqlDataReader

        userName = userQuery.ExecuteReader

        If Not userName.HasRows Then
            MsgBox("User name does not exist.")
            UserNameTB.Text = ""
            EmailTB.Text = ""
            UserNameTB.Focus()
            userName.Close()
        Else
            userName.Close()
            Dim sql As NpgsqlCommand = New NpgsqlCommand("SELECT convert_from(user_password,'SQL_ASCII') FROM member_authentication WHERE user_name ='" & UserNameTB.Text & "'", DBConn)
            passwordReturn = sql.ExecuteReader()

            If passwordReturn.HasRows Then
                passwordReturn.Read()
                encryptedPassword = Convert.FromBase64String(passwordReturn.GetValue(0))
                decryptedPassword = encrypted.decrypt(encryptedPassword)
                passwordReturn.Close()


                Dim sql2 As NpgsqlCommand = New NpgsqlCommand("SELECT email FROM member_information WHERE user_id =(SELECT user_id FROM member_authentication WHERE user_name ='" & UserNameTB.Text & "')", DBConn)
                Dim emailReturn As NpgsqlDataReader


                emailReturn = sql2.ExecuteReader()
                emailReturn.Read()
                Dim email As String = emailReturn.GetValue(0)
                emailReturn.Close()

                If email = EmailTB.Text Then
                    Try
                        Dim SmtpServer As New SmtpClient()
                        Dim mail As New MailMessage()
                        SmtpServer.Credentials = New  _
                        Net.NetworkCredential("EmailAccount", "Password")
                        SmtpServer.Port = 587
                        SmtpServer.Host = "smtp.aol.com"
                        mail = New MailMessage()
                        mail.From = New MailAddress("InfoRanchAdminEmailAddress")
                        mail.To.Add(EmailTB.Text)
                        mail.Subject = "Password Recovery"
                        mail.Body = "Your password is: " & decryptedPassword.ToString
                        SmtpServer.Send(mail)
                        MsgBox("Your password has been emailed to you.")
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    DBConn.Close()
                    Server.Transfer("~/InfoRanch.aspx")
                Else
                    MsgBox("The mail you entered does not match the email on file.")
                    UserNameTB.Text = ""
                    EmailTB.Text = ""
                    UserNameTB.Focus()
                End If
            End If
        End If
    End Sub


End Class