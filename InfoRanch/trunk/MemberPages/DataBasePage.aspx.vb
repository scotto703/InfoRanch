Imports System.Data
Imports System.Data.SqlClient
Imports InfoRanch.DB


Public Class DataBasePage
    Inherits System.Web.UI.Page

    'Dim selectedDB As New DBTemplate
    Dim DBConn As New SqlConnection
    Dim DBCom As New SqlCommand
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userID As String = Session("user_id")
        Dim userTable As String = Session("user_table")
        'selectedDB.setName(Session("user_table"))

        DBConn.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;database=" & _
                                userID & ";server=localhost;Connect Timeout=30"
        DBConn.Open()

        'DBcom = New SqlCommand("SELECT " & selectedDB.getName() & ", DATA_TYPE FROM FieldList" & selectedDB.getName() & ", INFORMATION_SCHEMA>COLUMNS WHERE " & _
        '                       "TABLE_SCHEMA='dbo' AND TABLE_NAME='" & selectedDB.getName() & "' AND COLUMN_NAME=" & selectedDB.getName() & " AND " & selectedDB.getName() & _
        '                       " <> 'ID'")

        DBCom = New SqlCommand("SELECT " & userTable & " FROM FieldList" & userTable & " ORDER BY sortorder", DBConn)
        'Dim counter As Integer = 0
        Dim dbReader As SqlDataReader = DBCom.ExecuteReader()

        dbReader.Read()

        Dim titleField As String = dbReader(0)

        'While dbReader.Read()
        '    selectedDB.addItem(dbReader(0), dbReader(1), counter)
        '    counter += 1
        'End While

        dbReader.Close()
        DBConn.Close()

        SqlDataSource1.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;database=" & userID & ";server=localhost;Connect Timeout=30"
        SqlDataSource1.SelectCommand = "SELECT ID, " & titleField & " FROM " & userTable


    End Sub


    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated

        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(1).Visible = False
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(1).Visible = False
        End If

    End Sub

    
End Class