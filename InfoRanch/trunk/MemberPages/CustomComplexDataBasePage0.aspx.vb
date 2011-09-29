Imports System.Data
Imports Npgsql
Imports InfoRanch.DB

Public Class CustomComplexDataBasePage0
    Inherits System.Web.UI.Page

    Dim DBCmd As New NpgsqlCommand



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("database_status") = ""

        Dim userDatabase = Session("user_id").ToString()
        Dim DbConn As New NpgsqlConnection
        Dim myCon As New DBConnection

        DbConn = myCon.connect(userDatabase)

        ' connection string with the Session variable "user_id"
        Dim cmd As NpgsqlCommand = New NpgsqlCommand("SELECT List from ComplexList", DbConn)

        DbConn.Open()

        Try
            cmd.ExecuteReader()
        Catch ex As Exception
            DBCmd = New NpgsqlCommand("CREATE TABLE complexlist (list varchar(50))", DbConn)
            DBCmd.ExecuteNonQuery()

            DBCmd = New NpgsqlCommand("INSERT INTO complexlist VALUES ('inventory')", DbConn)
            DBCmd.ExecuteNonQuery()

            DBCmd = New NpgsqlCommand("INSERT INTO complexlist VALUES ('corporate_employee')", DbConn)
            DBCmd.ExecuteNonQuery()

            DBCmd = New NpgsqlCommand("INSERT INTO complexlist VALUES ('acquaintance_information')", DbConn)
            DBCmd.ExecuteNonQuery()
        End Try

            DbConn.Close()

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

            End If

    End Sub

    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        ' assigns the selected item value to the Session variable and 
        ' redirects to UserDatabasePage.aspx

        Session("selected_model") = userDatabasesDD.SelectedValue.ToString
        Response.Redirect("~/MemberPages/CustomComplexDataBasePage1.aspx")


    End Sub

    Protected Sub BTN_Click(sender As Object, e As EventArgs) Handles BTN.Click
        Response.Redirect("~/MemberPages/MemberPageHome.aspx")
    End Sub
End Class