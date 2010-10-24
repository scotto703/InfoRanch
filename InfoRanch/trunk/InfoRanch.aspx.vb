Imports System.Data
Imports System.Data.SqlClient

Partial Public Class InfoRanch
    Inherits System.Web.UI.Page

    ' Connection string to the administration DB
    Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;database=administration;server=localhost;Connect Timeout=30")

    Dim DBCmd As New SqlCommand
    Dim DBAdap As New SqlDataAdapter
    Dim DS As New DataSet
    Dim encrypted As New Encryption


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        Dim dr As SqlDataReader



        DBConn.Open()

        ' query the member authentication table
        Dim sql As SqlCommand = New SqlCommand("SELECT * FROM member_authentication WHERE user_name ='" _
        & user_nameTB.Text & "' and user_password = @password", DBConn)
        sql.Parameters.Add("@password", SqlDbType.VarBinary).Value = encrypted.Encrypt(user_passwordTB.Text)

        dr = sql.ExecuteReader

        ' if the user id and password match, then the Session variable is assigned
        ' the user id value and re-directs to MemberPageHome.aspx
        If dr.HasRows Then

            Session("user_id") = user_nameTB.Text

            
           

            Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)



        Else
            LoginError.Visible = True
            user_nameTB.Text = String.Empty
            user_passwordTB.Text = String.Empty
            user_nameTB.Focus()




        End If
        dr.Close()
        DBConn.Close()

    End Sub
End Class