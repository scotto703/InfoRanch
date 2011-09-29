Imports System.Data
Imports Npgsql
Imports InfoRanch.DB

Public Class CustomComplexConfirm
    Inherits System.Web.UI.Page
    Dim myConn As New DBConnection
    Dim dbStructure As New DBTemplate
    Dim dbCmd As New NpgsqlCommand
    Dim deleteCmd As New NpgsqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tempName As String = ""
        Dim dbConn As NpgsqlConnection

        If Session("custom_table") IsNot Nothing Then
            tempName = Session("custom_table")
        Else
            Response.Redirect("~/MemberPages/MemberPageHome.aspx")
        End If

        dbStructure.setName(tempName)

        dbConn = myConn.connect(Session("user_id"))
        dbConn.Open()

        dbCmd = New NpgsqlCommand("SELECT " & tempName & " as ""Stall Name"", datatype as ""Critter Type"", sortorder FROM temp" & tempName, dbConn)
        Dim dbReader As NpgsqlDataReader = dbCmd.ExecuteReader()

        While dbReader.Read()
            dbStructure.addItem(dbReader(0), dbReader(1), dbReader(2) * 10)
        End While
        dbReader.Close()

        dbReader = dbCmd.ExecuteReader()

        Dim dt As DataTable = New DataTable()
        dt.Load(dbReader)
        customCoralGrid.DataSource = dt
        customCoralGrid.DataBind()

        dbReader.Close()
        dbConn.Close()
    End Sub
    Private Sub deleteTempTable()
        Dim dbConn As NpgsqlConnection

        dbConn = myConn.connect(Session("user_id"))
        dbConn.Open()
        dbCmd = New NpgsqlCommand("DROP TABLE temp" & dbStructure.getName(), dbConn)
        dbCmd.ExecuteNonQuery()

        dbConn.Close()

    End Sub

    Private Sub deleteTempTable(ByRef conn As NpgsqlConnection)

        dbCmd = New NpgsqlCommand("DROP TABLE temp" & dbStructure.getName(), conn)
        dbCmd.ExecuteNonQuery()

    End Sub

    Protected Sub noButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles noButton.Click
        ' connects to the user database
        Dim DBConn As NpgsqlConnection = myConn.connect(Session("user_id"))
        Dim reader As NpgsqlDataReader
        Dim tableList(3) As String
        Dim j As Integer
        Dim Table As String
        Dim fieldlistTable As String

        DBConn.Open()

        dbCmd = New NpgsqlCommand("SELECT list from " & Session("complex_database"), DBConn)
        reader = dbCmd.ExecuteReader()

        If Session("table_level") = "one" Then
            j = 0
        ElseIf Session("table_level") = "two" Then
            j = 1
        ElseIf Session("table_level") = "three" Then
            j = 2
        End If

        Dim k As Integer
        k = 0

        While reader.Read()
            tableList(k) = reader(0)
            k = k + 1
        End While

        reader.Close()

        For i = 0 To j
            Table = tableList(i)
            deleteCmd = New NpgsqlCommand("DROP TABLE " & Table, DBConn)
            deleteCmd.ExecuteNonQuery()
            fieldlistTable = "fieldlist" & Table
            deleteCmd = New NpgsqlCommand("DROP TABLE " & fieldlistTable, DBConn)
            deleteCmd.ExecuteNonQuery()
        Next

        ' delete New complex database 'table' from tablelist
        dbCmd = New NpgsqlCommand("DELETE FROM tablelist WHERE list = '" & Session("complex_database") & "'", DBConn)
        dbCmd.ExecuteNonQuery()
        ' drop 'customComplexDatabasE Tablelist' table 
        dbCmd = New NpgsqlCommand("DROP TABLE " & Session("complex_database"), DBConn)
        dbCmd.ExecuteNonQuery()

        deleteTempTable()
        Response.Redirect("~/MemberPages/MemberPageHome.aspx")
    End Sub

    Protected Sub yesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles yesButton.Click
        ' Delete temp table

        deleteTempTable()

        If Session("table_level") = "one" Then
            Server.Transfer("~/MemberPages/CustomComplexDataBasePage4.aspx", True)
        ElseIf Session("table_level") = "two" Then
            Server.Transfer("~/MemberPages/CustomComplexDataBasePage5.aspx", True)
        ElseIf Session("table_level") = "three" Then
            Response.Redirect("~/MemberPages/MemberPageHome.aspx")
        End If

    End Sub

    Private Sub customCoralGrid_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles customCoralGrid.RowCreated

        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(2).Visible = False
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(2).Visible = False
        End If
    End Sub

    Private Sub customCoralGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles customCoralGrid.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(0).Text = Replace(e.Row.Cells(0).Text, "_", " ")

            Select Case (e.Row.Cells(1).Text)
                Case "varchar(50)"
                    e.Row.Cells(1).Text = "Short Text"
                Case "text"
                    e.Row.Cells(1).Text = "Long Text"
                Case "int"
                    e.Row.Cells(1).Text = "Whole Number"
                Case "real"
                    e.Row.Cells(1).Text = "Decimal"
                Case "numeric(15,2)"
                    e.Row.Cells(1).Text = "Money"
                Case "date"
                    e.Row.Cells(1).Text = "Date"
            End Select

        End If
    End Sub
End Class