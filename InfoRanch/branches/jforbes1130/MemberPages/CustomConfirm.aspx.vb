Imports System.Data
Imports Npgsql
Imports InfoRanch.DB

Public Class CustomConfirm
	Inherits System.Web.UI.Page

	Dim myConn As New DBConnection
	Dim dbStructure As New DBTemplate
	Dim dbCmd As New NpgsqlCommand

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
		deleteTempTable()
		Response.Redirect("~/MemberPages/CustomDatabase.aspx")
	End Sub

	Protected Sub cancelButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelButton.Click
		deleteTempTable()
		Response.Redirect("~/MemberPages/MemberPageHome.aspx")
	End Sub

	Protected Sub yesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles yesButton.Click
		Dim dbConn As NpgsqlConnection

		dbStructure.addItem("ID", "serial", 10000)

		dbConn = myConn.connect(Session("user_id"))
		dbConn.Open()

		' New table to tablelist
		dbCmd = New NpgsqlCommand("INSERT INTO tablelist VALUES ('" & dbStructure.getName() & "')", dbConn)
		dbCmd.ExecuteNonQuery()

		' Set up field list table
		dbCmd = New NpgsqlCommand("CREATE TABLE fieldlist" & dbStructure.getName() & " (" & dbStructure.getName() & " varchar(50), datatype varchar(50), sortorder int)", dbConn)
		dbCmd.ExecuteNonQuery()

		' Add data to field list

		For i As Integer = 0 To dbStructure.length - 1
			dbCmd = New NpgsqlCommand("INSERT INTO fieldlist" & dbStructure.getName() & " VALUES (@field, @datatype, @sortorder)", dbConn)
			dbCmd.Parameters.AddWithValue("@field", dbStructure.getField(i))
			dbCmd.Parameters.AddWithValue("@datatype", dbStructure.getDataType(i))
			dbCmd.Parameters.AddWithValue("@sortorder", dbStructure.getSortOrder(i))
			dbCmd.ExecuteNonQuery()
		Next

		' Create database table

		Dim dbCreate As String = "CREATE TABLE " & dbStructure.getName() & " ("

		For i As Integer = 0 To dbStructure.length - 1

			If dbStructure.getField(i) = "ID" Then
				dbCreate &= ", " & dbStructure.getField(i) & " " & dbStructure.getDataType(i) & " PRIMARY KEY"
			Else

				If i = 0 Then
					dbCreate &= Replace(dbStructure.getField(i), " ", "_") & " " & dbStructure.getDataType(i)
				Else
					dbCreate &= ", " & Replace(dbStructure.getField(i), " ", "_") & " " & dbStructure.getDataType(i)
				End If

			End If

		Next

		dbCreate &= ")"

		dbCmd = New NpgsqlCommand(dbCreate, dbConn)
		dbCmd.ExecuteNonQuery()

		' Delete temp table

		deleteTempTable(dbConn)
		dbConn.Close()

		Session("custom_table") = Nothing

		Response.Redirect("~/MemberPages/MemberPageHome.aspx")
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
				Case "money"
					e.Row.Cells(1).Text = "Money"
				Case "date"
					e.Row.Cells(1).Text = "Date"
			End Select

		End If
	End Sub
End Class