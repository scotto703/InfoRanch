﻿Imports System.Data
Imports Npgsql
Imports InfoRanch.Util
Imports InfoRanch.DB

Partial Public Class RegisterPage
    Inherits System.Web.UI.Page

    Dim DBCmd As New NpgsqlCommand
    Dim DBAdap As New NpgsqlDataAdapter
    Dim DS As New DataSet
    Dim encrypted As New Encryption

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles submitBTN.Click

        ' Connection String to the administration database
        Dim DBConn As New NpgsqlConnection
        Dim myCon As New DBConnection

        DBConn = myCon.connect("administration")

        DBConn.Open()

        ' Check to ensure that the user does not already exist

        DBCmd = New NpgsqlCommand("SELECT * FROM member_authentication WHERE user_name = '" & userNameTB.Text & "'", DBConn)

        Dim dr As NpgsqlDataReader = DBCmd.ExecuteReader

        ' If user exists then let user know and stop the creation of a new user

        If dr.HasRows Then
            userExistsError.Visible = True
            DBConn.Close()
            userNameTB.Focus()

            ' If the user does not exist then create the new user and database

        Else

            ' Inserts user name and user password into the member authentication table

            DBCmd = New NpgsqlCommand("INSERT INTO member_authentication(user_name, user_password)VALUES (@user_name, @user_password)", DBConn)

            DBCmd.Parameters.AddWithValue("@user_name", userNameTB.Text)
            Dim password As Byte() = encrypted.encrypt(userPasswordTB.Text)
            DBCmd.Parameters.AddWithValue("@user_password", Convert.ToBase64String(password))   'Runs encryption method to encrypt database password

            DBCmd.ExecuteNonQuery()

            'Get the autogenerated user_id from member_authentication to link member_authentication and member_information
            Dim reader As NpgsqlDataReader
            Dim userID As Integer

            DBCmd = New NpgsqlCommand("SELECT user_id from member_authentication where user_name = '" & userNameTB.Text & "';", DBConn)
            reader = DBCmd.ExecuteReader

            reader.Read()
            userID = reader(0)
            reader.Close()

            ' Inserts texbox values into the member_information table
            DBCmd = New NpgsqlCommand("INSERT INTO member_information(user_id,f_name, l_name, address_one, address_two, city, state, zip, phone, email)" & _
                    "VALUES (@user_id, @f_name, @l_name, @address_one, @address_two, @city, @state, @zip, @phone, @email)", DBConn)

            DBCmd.Parameters.AddWithValue("@user_id", userID)
            DBCmd.Parameters.AddWithValue("@f_name", firstNameTB.Text)
            DBCmd.Parameters.AddWithValue("@l_name", lastNameTB.Text)
            DBCmd.Parameters.AddWithValue("@address_one", addressOneTB.Text)
            DBCmd.Parameters.AddWithValue("@address_two", addressTwoTB.Text)
            DBCmd.Parameters.AddWithValue("@city", cityTB.Text)
            DBCmd.Parameters.AddWithValue("@state", (stateDropDownList1.SelectedItem).ToString)
            DBCmd.Parameters.AddWithValue("@zip", zipTB.Text)
            DBCmd.Parameters.AddWithValue("@phone", phoneTB.Text)
            DBCmd.Parameters.AddWithValue("@email", emailTB.Text)

            DBCmd.ExecuteNonQuery()

            ' Create the user database
            Dim com As NpgsqlCommand
            Dim createString As String

            createString = "CREATE DATABASE " & userNameTB.Text & " OWNER = inforanch"
            com = New NpgsqlCommand(createString, DBConn)
            com.ExecuteNonQuery()
            DBConn.Close()

            ' connects to the user database
            Dim DBConn1 As New NpgsqlConnection("Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" & userNameTB.Text & ";Timeout=30")

            DBConn1.Open()


            ' creates a table to keep track of the user's "personal databases"
            DBCmd = New NpgsqlCommand("CREATE TABLE TableList(List varchar(50))", DBConn1)

            DBCmd.ExecuteNonQuery()

            DBConn1.Close()


            Server.Transfer("~/InfoRanch.aspx", True)
        End If

    End Sub

End Class