Imports System.Data
Imports System.Data.SqlClient
Imports InfoRanch.Util

Partial Public Class RegisterPage
    Inherits System.Web.UI.Page


   

    
    Dim DBCmd As New SqlCommand
    Dim DBAdap As New SqlDataAdapter
    Dim DS As New DataSet
    Dim encrypted As New Encryption




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        ' Connection String to the administration database
        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                   "database=administration;server=localhost;Connect Timeout=30")

        DBConn.Open()

        ' Inserts texbox values into the member_information table
        DBCmd = New SqlCommand("INSERT INTO member_information(f_name, l_name, address_one, address_two, city, state, zip, phone, email, user_name)" & _
                               "VALUES (@f_name, @l_name, @address_one, @address_two, @city, @state, @zip, @phone, @email, @user_name)", DBConn)

        DBCmd.Parameters.Add("@f_name", SqlDbType.NVarChar).Value = f_nameTB.Text
        DBCmd.Parameters.Add("@l_name", SqlDbType.NVarChar).Value = l_nameTB.Text
        DBCmd.Parameters.Add("@address_one", SqlDbType.NVarChar).Value = address_oneTB.Text
        DBCmd.Parameters.Add("@address_two", SqlDbType.NVarChar).Value = address_twoTB.Text
        DBCmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = cityTB.Text
        DBCmd.Parameters.Add("@state", SqlDbType.NVarChar).Value = stateTB.Text
        DBCmd.Parameters.Add("@zip", SqlDbType.NVarChar).Value = zipTB.Text
        DBCmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phoneTB.Text
        DBCmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = emailTB.Text
        DBCmd.Parameters.Add("@user_name", SqlDbType.NVarChar).Value = user_nameTB.Text

        DBCmd.ExecuteNonQuery()



        ' Inserts user name and user password into the member authentication table

        DBCmd = New SqlCommand("INSERT INTO member_authentication(user_name, user_password)VALUES (@user_name, @user_password)", DBConn)

        DBCmd.Parameters.Add("@user_name", SqlDbType.NVarChar).Value = user_nameTB.Text
        DBCmd.Parameters.Add("@user_password", SqlDbType.VarBinary).Value = encrypted.Encrypt(user_passwordTB.Text) 'Runs encryption method to encrypt database password

        DBCmd.ExecuteNonQuery()

        ' Programatically creates a database primary file and log file
        Dim com As SqlCommand
        Dim w As String
        w = "CREATE DATABASE " & user_nameTB.Text & " " _
        & "ON " _
        & "( NAME = " & user_nameTB.Text & "," _
        & " FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\" & user_nameTB.Text & ".mdf')" _
        & " LOG ON" _
        & " ( NAME = '" & user_nameTB.Text & "_log'," _
        & " FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\" & user_nameTB.Text & ".ldf')"

        com = New SqlCommand(w, DBConn)

        com.ExecuteNonQuery()

        DBConn.Close()

        ' connects to the user database
        Dim DBConn1 As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                   "database=" & user_nameTB.Text & ";server=localhost;Connect Timeout=30")

        DBConn1.Open()


        ' creates a table to keep track of the user's "personal databases"
        DBCmd = New SqlCommand("CREATE TABLE TableList(List nvarchar(50))", DBConn1)

        DBCmd.ExecuteNonQuery()

        DBConn1.Close()



        Server.Transfer("~/InfoRanch.aspx", True)


    End Sub
















End Class