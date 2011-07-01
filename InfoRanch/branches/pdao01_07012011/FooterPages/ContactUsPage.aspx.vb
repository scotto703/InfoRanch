Imports InfoRanch.Util
Imports InfoRanch.DB
Imports System.Net.Mail

Partial Public Class ContactUsPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub sumbitBTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sumbitBTN.Click

        Dim memberStatus As String

        If memberRB.Checked Then
            memberStatus = "Member"
        Else
            memberStatus = "Nonmember"
        End If


        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New  _
            Net.NetworkCredential("emailaddress", "password")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.aol.com"
            mail = New MailMessage()
            mail.From = New MailAddress("emailaddress")
            mail.To.Add("emailaddress")
            mail.Subject = "InfoRanch Contact Request"
            mail.Body = "From: " & emailTB.Text & vbCrLf & "Status: " & memberStatus & vbCrLf & "Message: " & commentsTB.Text
            SmtpServer.Send(mail)
            MsgBox("We will get back to you in a timely manner.")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Server.Transfer("~/InfoRanch.aspx")
    End Sub

    Protected Sub clearBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearBTN.Click

        emailTB.Text = ""
        commentsTB.Text = ""
        memberRB.Checked = False
        nonmemberRB.Checked = False

    End Sub

    Protected Sub returnBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles returnBTN.Click

        Server.Transfer("~/InfoRanch.aspx")

    End Sub

End Class