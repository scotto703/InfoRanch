Imports System.Data
Imports Npgsql
Imports InfoRanch.DB

Public Class AddEdit
    Inherits System.Web.UI.Page

	Dim coralTemplate As New DBTemplate

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		addButton.Visible = False
		updateButton.Visible = False
		editButton.Visible = False
		deleteButton.Visible = False
		resetButton.Visible = False
		addedLabel.Visible = False

		Dim dbConn As New NpgsqlConnection
		Dim dbCom As New NpgsqlCommand
		Dim mode As String = "add"

		coralTemplate.setName(Session("user_table"))

		' Check to see if teh the ID parameter is set in the query string
		' If it exists then the mode is either edit or view

		If Request.QueryString.Get("ID") IsNot Nothing Then

			'If there is a Mode parameter in the query string then set the mode
			' to edit otherwise set the mode to view

			If Request.QueryString.Get("Mode") IsNot Nothing Then
				mode = "edit"
			Else
				mode = "view"
			End If

		End If

		'Create connection to get list of fields into fieldList string
		dbConn.ConnectionString = "Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" & _
		   Session("user_id") & ";Timeout=30"
		dbCom = New NpgsqlCommand("SELECT " & coralTemplate.getName() & ", datatype, sortorder FROM fieldlist" & coralTemplate.getName() & " WHERE " & _
		  coralTemplate.getName() & "<> 'ID' ORDER BY sortorder", dbConn)
		dbConn.Open()

		Dim dbReader As NpgsqlDataReader = dbCom.ExecuteReader()

		'Read the query
		While dbReader.Read()
			coralTemplate.addItem(dbReader(0), dbReader(1), dbReader(2))
		End While

		'Close connectin
		dbReader.Close()
		dbConn.Close()

		Dim returnedRecord As NpgsqlDataAdapter
		Dim recordSet As DataSet
		Dim table As String = coralTemplate.getName()
		Dim fieldList As String = ""

		For i As Integer = 0 To coralTemplate.length - 2
			fieldList &= coralTemplate.getField(i) & ", "
		Next

		fieldList &= coralTemplate.getField(coralTemplate.length - 1)

		' Use the mode to determine what the query string should be
		' if it is in add then also change the name of the table

		Select Case (mode)
			Case "add"
				returnedRecord = New NpgsqlDataAdapter("SELECT " & table & " FROM fieldlist" & table & " LIMIT 1", dbConn)
				recordSet = New DataSet()
				table = "fieldlist" & table
			Case Else
				Dim recordID As Integer = Convert.ToInt32(Request.QueryString.Get("ID"))
				returnedRecord = New NpgsqlDataAdapter("SELECT " & fieldList & " FROM " & table & " WHERE id = " & recordID, dbConn)
				recordSet = New DataSet()
		End Select

		' Call the template to create the UI by binding data to it

		coral.HeaderTemplate = New DataTemplate(ListItemType.Header, coralTemplate, mode)
		coral.ItemTemplate = New DataTemplate(ListItemType.Item, coralTemplate, mode)
		coral.FooterTemplate = New DataTemplate(ListItemType.Footer, coralTemplate, mode)

		returnedRecord.Fill(recordSet, table)
		coral.DataSource = recordSet.Tables(table)

		coral.DataBind()

		' Set the button visibility based on the mode

		Select Case (mode)
			Case "add"
				addButton.Visible = True
				resetButton.Visible = True
			Case "edit"
				updateButton.Visible = True
				deleteButton.Visible = True
				resetButton.Visible = True
			Case Else
				editButton.Visible = True
				deleteButton.Visible = True
		End Select
	End Sub

	' Transfer the page back to the database home page
	Private Sub goodbye()
		Response.Redirect("~/MemberPages/DataBasePage.aspx")
	End Sub

	' Recursively checks every control to see if it is a textbox and if it is
	' then clear its text

	Private Sub clearTextBox(ByVal root As Control)

		For Each ctrl As Control In root.Controls
			clearTextBox(ctrl)

			If TypeOf ctrl Is TextBox Then
				CType(ctrl, TextBox).Text = String.Empty
			End If

		Next

	End Sub

	Protected Sub cancelButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelButton.Click
		goodbye()
	End Sub

	Protected Sub resetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles resetButton.Click
		clearTextBox(Me)
		
	End Sub

	Protected Sub deleteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteButton.Click
		Dim dbConn As NpgsqlConnection
		Dim dbCom As NpgsqlCommand

		dbConn = New NpgsqlConnection("Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" & _
		   Session("user_id") & ";Timeout=30")
		dbCom = New NpgsqlCommand("DELETE FROM " & coralTemplate.getName() & " WHERE id = " & Request.QueryString.Get("ID"), dbConn)

		dbConn.Open()
		dbCom.ExecuteNonQuery()

		dbConn.Close()

		goodbye()
	End Sub

	Protected Sub editButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editButton.Click
		Dim url As String = "~/MemberPages/AddEdit.aspx?ID=" & Request.QueryString.Get("ID") & "&Mode=edit"
		Response.Redirect(url)
	End Sub

	Protected Sub addButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addButton.Click
		Dim fieldString As String = ""
		Dim paramString As String = ""
		Dim paramList As New List(Of String)

		'Set up the strings necessary to create the query

		For i As Integer = 0 To coralTemplate.length - 2
			fieldString &= coralTemplate.getField(i) & ", "
			paramList.Add("@" & coralTemplate.getField(i))
			paramString &= "@" & coralTemplate.getField(i) & ", "
		Next

		fieldString &= coralTemplate.getField(coralTemplate.length - 1)
		paramList.Add("@" & coralTemplate.getField(coralTemplate.length - 1))
		paramString &= "@" & coralTemplate.getField(coralTemplate.length - 1)

		' Create connection and run query

		Dim dbConn As NpgsqlConnection
		Dim dbCom As NpgsqlCommand

		dbConn = New NpgsqlConnection("Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" & _
		   Session("user_id") & ";Timeout=30")
		dbCom = New NpgsqlCommand("INSERT INTO " & coralTemplate.getName() & " (" & fieldString & ") VALUES (" & _
		  paramString & ")", dbConn)

		' Add values to parameters to be able to run query
		For i As Integer = 0 To paramList.Count - 1
			dbCom.Parameters.AddWithValue(paramList(i), CType(FindControlIterative(coral, coralTemplate.getField(i) & "Text"), TextBox).Text)
		Next

		dbConn.Open()
		dbCom.ExecuteNonQuery()
		dbConn.Close()

		addedLabel.Visible = True

		clearTextBox(coral)

	End Sub

	' Checks every control under the provided control and returns it
	' This adds functionality to the FindControl function and makes it easier
	' to find the various controls and get their values since they do not exist
	' at design time
	' Parameters:
	' root - Control the control to search under
	' id - String the name of the ID of the control to look for

	Private Shared Function FindControlIterative(ByVal root As Control, _
	 ByVal id As String) As Control

		Dim ctl As Control = root
		Dim ctls As LinkedList(Of Control) = New LinkedList(Of Control)

		Do While (ctl IsNot Nothing)
			If ctl.ID = id Then
				Return ctl
			End If
			For Each child As Control In ctl.Controls
				If child.ID = id Then
					Return child
				End If
				If child.HasControls() Then
					ctls.AddLast(child)
				End If
			Next
			ctl = ctls.First.Value
			ctls.Remove(ctl)
		Loop

		Return Nothing

	End Function


	Protected Sub updateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles updateButton.Click
		Dim paramList As New List(Of String)
		Dim updateString As String

		' Create update query string
		' Create List for parameter names

		For i As Integer = 0 To coralTemplate.length - 1
			paramList.Add("@" & coralTemplate.getField(i))
		Next

		' Begin query string

		updateString = "UPDATE " & coralTemplate.getName() & " SET "

		' Add field names and parameters to the string
		For i As Integer = 0 To coralTemplate.length - 2
			updateString &= coralTemplate.getField(i) & "=" & paramList(i) & ", "
		Next

		updateString &= coralTemplate.getField(coralTemplate.length - 1) & "=" & paramList(coralTemplate.length - 1)

		' Set where clause for string

		updateString &= " WHERE ID = " & Request.QueryString.Get("ID")

		' Open database connection and run query

		Dim dbConn As NpgsqlConnection
		Dim dbCom As NpgsqlCommand

		dbConn = New NpgsqlConnection("Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" & _
		   Session("user_id") & ";Timeout=30")
		dbCom = New NpgsqlCommand(updateString, dbConn)


		' Set the parameters

		For i As Integer = 0 To paramList.Count - 1
			dbCom.Parameters.AddWithValue(paramList(i), CType(FindControlIterative(coral, coralTemplate.getField(i) & "Text"), TextBox).Text)
		Next

		dbConn.Open()

		dbCom.ExecuteNonQuery()

		dbConn.Close()
		goodbye()
	End Sub
End Class