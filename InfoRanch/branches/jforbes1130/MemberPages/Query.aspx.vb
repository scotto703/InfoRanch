Imports System.Data
Imports Npgsql
Imports System.IO
Imports InfoRanch.DB



Partial Public Class Query
    Inherits System.Web.UI.Page
	Dim dataTemplate As New DBTemplate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim dbConn As New NpgsqlConnection
		Dim myCon As New DBConnection
		Dim dbCom As New NpgsqlCommand

		dataTemplate.setName(Session("user_id"))

		dbConn = myCon.connect(Session("user_id"))

		' Get information about current table to be used determine what limiters are shown

		dbCom = New NpgsqlCommand("SELECT " & Session("user_table") & ",datatype,sortorder FROM fieldlist" & Session("user_table") & " WHERE " & _
		  Session("user_table") & " <> 'ID' ORDER BY sortorder", dbConn)

		dbConn.Open()

		Dim dbReader As NpgsqlDataReader = dbCom.ExecuteReader()

		While dbReader.Read()
			dataTemplate.addItem(dbReader(0), dbReader(1), dbReader(2))
		End While

		dbReader.Close()
		dbConn.Close()

		' Set up page for query

		searchTB.Focus()
		NewSearchBTN.Visible = False
		Cancel2BTN.Visible = False

		welcomeLbl.Text = StrConv(Session("user_table"), VbStrConv.ProperCase) & " Information"

		If Not Page.IsPostBack Then

			fieldDropDown.Visible = True

			' Populate field drop down list

			dbCom = New NpgsqlCommand("SELECT " & Session("user_table") & " From FieldList" & Session("user_table") & " where " & Session("user_table") & " <> 'ID' Order By sortorder", dbConn)
			dbConn.Open()

			fieldDropDown.DataSource = dbCom.ExecuteReader()

			fieldDropDown.DataTextField = "" & Session("user_table") & ""

			fieldDropDown.DataValueField = "" & Session("table_table") & ""


			fieldDropDown.DataBind()

			dbConn.Close()
			dbConn.Dispose()
			

		End If

	End Sub

	Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click
		Dim DBCmd As New NpgsqlCommand

		' Hide and show appropriate controls

		searchResults.Visible = True

		SubmitBTN.Visible = False
		Cancel1.Visible = False
		NewSearchBTN.Visible = True
		Cancel2BTN.Visible = True


		fieldDropDown.Visible = False
		limitDropDown.Visible = False
		thatLabel.Visible = False
		searchByLbl.Visible = False

		searchTB.Visible = False

		' Query logic starts here
		' Initialize required variables

		Dim selectedValue = fieldDropDown.SelectedValue()
		Dim searchValue = searchTB.Text
		Dim whereClause As String
		Dim DBConn As New NpgsqlConnection
		Dim MyCon As New DBConnection
		DBConn = MyCon.connect(Session("user_id"))

		' Determine what limiter is chosen

		Select Case (limitDropDown.SelectedIndex)
			Case 0
				whereClause = "="
			Case 1
				whereClause = "<"
			Case 2
				whereClause = ">"
			Case 3
				whereClause = "<="
			Case 4
				whereClause = ">="
			Case Else
				whereClause = " LIKE "
				searchValue = "%" & searchValue & "%"
		End Select

		' Set up query using parameters

		DBCmd = New NpgsqlCommand("select id, " & dataTemplate.getField(0) & " from " & Session("user_table") & " where " & selectedValue & whereClause & "@searchValue", DBConn)
		DBCmd.Parameters.AddWithValue("@searchValue", searchValue)

		DBConn.Open()

		' Bind data to the searchResults gridview control

		Dim srchResults As NpgsqlDataReader = DBCmd.ExecuteReader()

		Dim dt As DataTable = New DataTable()
		dt.Load(srchResults)
		searchResults.DataSource = dt
		searchResults.DataBind()

		'Closing the data reader & connection object
		srchResults.Close()
		DBConn.Close()
	End Sub

	Protected Sub ClearBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NewSearchBTN.Click
		searchTB.Text = ""
		searchResults.Visible = False
		SubmitBTN.Visible = True
		NewSearchBTN.Visible = False
		fieldDropDown.Visible = True
		thatLabel.Visible = True
		searchByLbl.Visible = True
		limitDropDown.Visible = True
		searchTB.Visible = True

	End Sub

    Protected Sub Cancel1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel1.Click
		Server.Transfer("~/MemberPages/DataBasePage.aspx", True)
    End Sub

    Protected Sub Cancel2BTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel2BTN.Click
		Server.Transfer("~/MemberPages/DataBasePage.aspx", True)
    End Sub

	Private Sub fieldDropDown_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles fieldDropDown.DataBound
		Dim selectedValue = fieldDropDown.SelectedValue

		limitDropDown.Items.Clear()

		limitDropDown.Items.Add("Equals ")
		limitDropDown.Items.Add("Is Less Than ")
		limitDropDown.Items.Add("Is Greater Than ")
		limitDropDown.Items.Add("Is Less Than or Equals ")
		limitDropDown.Items.Add("Is Greater Than or Equals ")

		For i As Integer = 0 To dataTemplate.length - 1

			If selectedValue = dataTemplate.getField(i) Then

				If dataTemplate.getDataType(i).Length > 3 Then

					Select Case (dataTemplate.getDataType(i).Substring(0, 4))
						Case "varc"
							limitDropDown.Items.Add("Contains ")
						Case "text"
							limitDropDown.Items.Add("Contains ")
					End Select

				End If

			End If

		Next
	End Sub

	Private Sub fieldDropDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fieldDropDown.SelectedIndexChanged
		Dim selectedValue = fieldDropDown.SelectedValue

		limitDropDown.Items.Clear()

		limitDropDown.Items.Add("Equals ")
		limitDropDown.Items.Add("Is Less Than ")
		limitDropDown.Items.Add("Is Greater Than ")
		limitDropDown.Items.Add("Is Less Than or Equals ")
		limitDropDown.Items.Add("Is Greater Than or Equals ")

		For i As Integer = 0 To dataTemplate.length - 1

			If selectedValue = dataTemplate.getField(i) Then

				If dataTemplate.getDataType(i).Length > 3 Then

					Select Case (dataTemplate.getDataType(i).Substring(0, 4))
						Case "varc"
							limitDropDown.Items.Add("Contains ")
						Case "text"
							limitDropDown.Items.Add("Contains ")
					End Select

				End If

			End If

		Next
	End Sub

	Private Sub searchResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles searchResults.RowCreated
		If e.Row.RowType = DataControlRowType.Header Then
			e.Row.Cells(1).Visible = False
			e.Row.Cells(2).Text = StrConv(e.Row.Cells(2).Text, VbStrConv.ProperCase)
		End If

		If e.Row.RowType = DataControlRowType.DataRow Then
			e.Row.Cells(1).Visible = False
		End If
	End Sub

	Private Sub searchResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchResults.SelectedIndexChanged
		Dim row As GridViewRow = searchResults.SelectedRow

		Server.Transfer("~/MemberPages/AddEdit.aspx?ID=" & row.Cells(1).Text, True)
	End Sub
End Class