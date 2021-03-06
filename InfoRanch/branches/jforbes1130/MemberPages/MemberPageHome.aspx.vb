﻿Imports System.Data
Imports Npgsql
Imports InfoRanch.DB


Partial Public Class MemberPageHome
    Inherits System.Web.UI.Page

    Dim DBCmd As New NpgsqlCommand
   


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        welcomeMsg.Text = "Welcome " & Session("user_id") & "!"
        selectDBHead.Text = "Please Select A Database"
        noDBMsg.Text = "You Currently Have No Databases. Please Select Template Database Or Custom Database On The Left To Create A Database"
        noDBMsg.Visible = False


        Dim userDatabase = Session("user_id").ToString()
		Dim DbConn As New NpgsqlConnection
		Dim myCon As New DBConnection

		DbConn = myCon.connect(userDatabase)

        ' connection string with the Session variable "user_id"
		Dim cmd As NpgsqlCommand = New NpgsqlCommand("SELECT List from TableList", DbConn)

        If Not Page.IsPostBack Then

			DbConn.Open()

            ' loads the items into the drop-down list
            userDatabasesDD.DataSource = cmd.ExecuteReader()
            userDatabasesDD.DataTextField = "List"

            userDatabasesDD.DataValueField = "List"

            userDatabasesDD.DataBind()
        End If

		DbConn.Close()
		DbConn.Dispose()

        Dim CountDB = userDatabasesDD.Items.Count

        ' if there are no items in the database, then then label3.text appears
        If CountDB < 1 Then
            userDatabasesDD.Visible = False
            SubmitBTN.Visible = False
            noDBMsg.Visible = True
            selectDBHead.Visible = False
        End If

    End Sub







    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        ' assigns the selected item value to the Session variable and 
        ' redirects to UserDatabasePage.aspx
        Session("user_table") = userDatabasesDD.SelectedValue.ToString

        Server.Transfer("~/MemberPages/DataBasePage.aspx", True)


    End Sub
End Class
