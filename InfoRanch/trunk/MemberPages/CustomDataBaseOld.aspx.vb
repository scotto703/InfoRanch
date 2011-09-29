Imports System.Data
Imports Npgsql
Imports InfoRanch.DB



Partial Public Class CustomDataBase
    Inherits System.Web.UI.Page
	Dim DBCmd As New NpgsqlCommand
	Dim name As String
	Dim category As String
	Dim myConn As New DBConnection



	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		NameTB.Focus()
		instructionsDiv.Visible = False
		stallNameLabel.Visible = False
		dataTypeLabel.Visible = False
		dataTypeDropDown.Visible = False
		anotherLabel.Visible = False
		submitCategoryBTN.Visible = False
		submitCategory2BTN.Visible = False
		categoryTB.Visible = False
		YesBTN.Visible = False
		NoBTN.Visible = False
		NameTB.Focus()

	End Sub

	Protected Sub SubmitNameBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitNameBTN.Click

		submitCategoryBTN.Focus()
		instructionsDiv.Visible = True
		coralCnameLabel.Visible = False
		stallNameLabel.Visible = True
		dataTypeLabel.Visible = True
		dataTypeDropDown.Visible = True
		submitCategoryBTN.Visible = True
		NameTB.Visible = False
		categoryTB.Visible = True
		SubmitNameBTN.Visible = False

	End Sub

	Protected Sub SubmitcategoryBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles submitCategoryBTN.Click
		instructionsDiv.Visible = False
		stallNameLabel.Visible = False
		dataTypeLabel.Visible = False
		dataTypeDropDown.Visible = False
		submitCategoryBTN.Visible = False
		categoryTB.Visible = False
		anotherLabel.Visible = True
		YesBTN.Visible = True
		NoBTN.Visible = True

		' connects to the user database
		Dim DBConn As NpgsqlConnection = myConn.connect(Session("user_id"))

		category = categoryTB.Text
		name = Replace(NameTB.Text, " ", "_")

		DBConn.Open()

		' creates the Temporary Field List Table
		DBCmd = New NpgsqlCommand("CREATE TABLE temp" & name & "(" & name & " varchar(50), datatype varchar(50), sortorder serial)", DBConn)
		DBCmd.ExecuteNonQuery()

		' inserts values into FieldList
		DBCmd = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallName, @dataType)", DBConn)
		DBCmd.Parameters.AddWithValue("@stallName", Replace(category, " ", "_"))
		DBCmd.Parameters.AddWithValue("@dataType", dataTypeDropDown.SelectedValue)
		DBCmd.ExecuteNonQuery()

		DBConn.Close()

	End Sub

	Protected Sub YesBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles YesBTN.Click

		' sets visibility to add another field
		instructionsDiv.Visible = True
		stallNameLabel.Visible = True
		dataTypeLabel.Visible = True
		dataTypeDropDown.Visible = True
		anotherLabel.Visible = False
		YesBTN.Visible = False
		NoBTN.Visible = False
		categoryTB.Text = ""
		submitCategoryBTN.Visible = False
		submitCategory2BTN.Visible = True
		categoryTB.Visible = True
		categoryTB.Focus()




	End Sub

	Protected Sub NoBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NoBTN.Click

		name = Replace(NameTB.Text, " ", "_")
		Session("custom_table") = name
		Server.Transfer("~/MemberPages/CustomConfirm.aspx", True)
	End Sub


	Protected Sub Submitcategory2BTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Submitcategory2BTN.Click

		' used to make the addition of new categories look fluid

		instructionsDiv.Visible = False
		stallNameLabel.Visible = False
		dataTypeLabel.Visible = False
		dataTypeDropDown.Visible = False
		submitCategoryBTN.Visible = False
		categoryTB.Visible = False
		anotherLabel.Visible = True
		YesBTN.Visible = True
		NoBTN.Visible = True

		name = Replace(NameTB.Text, " ", "_")
		category = categoryTB.Text

		Dim DBConn As NpgsqlConnection = myConn.connect(Session("user_id"))

		DBConn.Open()

		DBCmd = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallname, @dataType)", DBConn)
		DBCmd.Parameters.AddWithValue("@stallname", Replace(category, " ", "_"))
		DBCmd.Parameters.AddWithValue("@dataType", dataTypeDropDown.SelectedValue)
		DBCmd.ExecuteNonQuery()

		DBConn.Close()

		categoryTB.Text = ""
		categoryTB.Focus()


	End Sub

	Protected Sub cancelBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelBtn.Click

		If name <> "" Then
			Dim dbConn As NpgsqlConnection = myConn.connect(Session("user_id"))
			dbConn.Open()

			DBCmd = New NpgsqlCommand("DROP TABLE temp" & name, dbConn)
			DBCmd.ExecuteNonQuery()
			dbConn.Close()
		End If

		Response.Redirect("~/MemberPages/MemberPageHome.aspx")
	End Sub
End Class