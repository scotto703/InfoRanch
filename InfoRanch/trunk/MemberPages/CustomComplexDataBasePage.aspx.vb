Imports System.Data
Imports Npgsql
Imports InfoRanch.DB


Public Class CustomComplexDataBasePage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'welcomeMsg.Text = "Welcome " & Session("user_id") & "!"
        welcomeMsg.Text = "'" & Session("user_table") & "'" & " Database"
        selectDBHead.Text = "Please Select A Table from the complex Database " & Session("user_table")
        noDBMsg.Text = "Your complex Database " & Session("user_table") & " Currently Have No Tables. Please Select Complex Database On The Left To Create A Complex Database with Multi Tables"
        noDBMsg.Visible = False

        Dim userDatabase = Session("user_id").ToString()
        Dim DbConn As New NpgsqlConnection
        Dim myCon As New DBConnection

        Session("complexDatabse_table") = Session("user_table")

        Session("database_status") = Session("user_table")

        DbConn = myCon.connect(userDatabase)

        ' connection string with the Session variable "user_id"
        Dim cmd As NpgsqlCommand = New NpgsqlCommand("SELECT List from " & Session("user_table"), DbConn)

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
        If userDatabasesDD.SelectedIndex = 0 Then
            Session("table_number_used") = "table1"
        End If
        If userDatabasesDD.SelectedIndex = 1 Then
            Session("table_number_used") = "table2"
        End If
        If userDatabasesDD.SelectedIndex = 2 Then
            Session("table_number_used") = "table3"
        End If
        Server.Transfer("~/MemberPages/DataBasePage.aspx", True)


    End Sub

    Protected Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click
        Dim userDatabase = Session("user_id").ToString()
        Dim DbConn As New NpgsqlConnection
        Dim myCon As New DBConnection
        Dim tableReader As NpgsqlDataReader
        Dim tableArray(3) As String
        Dim table As String
        Dim fieldlistTable As String
        Dim deleteCmd As NpgsqlCommand
        Dim complexDatabse As String

        complexDatabse = Session("complexDatabse_table")

        DbConn = myCon.connect(userDatabase)

        ' connection string with the Session variable "user_id"
        Dim cmd As NpgsqlCommand = New NpgsqlCommand("SELECT List from " & complexDatabse, DbConn)

        DbConn.Open()

        tableReader = cmd.ExecuteReader()

        Dim i As Integer
        i = 0

        While tableReader.Read()
            tableArray(i) = tableReader(0)
            i = i + 1
        End While

        tableReader.Close()

        For j = 0 To (i - 1)
            table = tableArray(j)
            deleteCmd = New NpgsqlCommand("DROP TABLE " & table, DbConn)
            deleteCmd.ExecuteNonQuery()
            fieldlistTable = "fieldlist" & table
            deleteCmd = New NpgsqlCommand("DROP TABLE " & fieldlistTable, DbConn)
            deleteCmd.ExecuteNonQuery()
        Next

        deleteCmd = New NpgsqlCommand("DROP TABLE " & complexDatabse, DbConn)
        deleteCmd.ExecuteNonQuery()

        deleteCmd = New NpgsqlCommand("DELETE FROM " & "tablelist " & "WHERE list = '" & complexDatabse & "'", DbConn)
        deleteCmd.ExecuteNonQuery()

        Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)

    End Sub
End Class