Imports System.Data
Imports Npgsql
Imports InfoRanch.DB


Public Class DataBasePage
    Inherits System.Web.UI.Page

    Dim DBConn As New NpgsqlConnection
    Dim DBCom As New NpgsqlCommand
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userID As String = Session("user_id")
        Dim userTable As String = Session("user_table")
		Dim myCon As New DBConnection

		DBConn = myCon.connect(userID)
        DBConn.Open()

        DBCom = New NpgsqlCommand("SELECT " & userTable & " FROM FieldList" & userTable & " ORDER BY sortorder", DBConn)
		Dim dbReader As NpgsqlDataReader = DBCom.ExecuteReader()

        dbReader.Read()

        Dim titleField As String = dbReader(0)

		dbReader.Close()

		DBCom = New NpgsqlCommand("SELECT ID, " & titleField & " FROM " & userTable, DBConn)

		Dim tableValues As NpgsqlDataReader = DBCom.ExecuteReader
		Dim dt As DataTable = New DataTable()

		dt.Load(tableValues)
		stallContents.DataSource = dt
		stallContents.DataBind()

		tableValues.Close()
		DBConn.Close()

        'SqlDataSource1.ConnectionString = "Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" & userID & ";Timeout=30"
        'SqlDataSource1.ProviderName = "Npgsql"
        'SqlDataSource1.SelectCommand = "SELECT ID, " & titleField & " FROM " & userTable


    End Sub


	Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles stallContents.RowCreated

		If e.Row.RowType = DataControlRowType.Header Then
			e.Row.Cells(1).Visible = False
			e.Row.Cells(2).Text = StrConv(e.Row.Cells(2).Text, VbStrConv.ProperCase)
		End If

		If e.Row.RowType = DataControlRowType.DataRow Then
			e.Row.Cells(1).Visible = False
		End If

	End Sub


	Protected Sub addItemBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addItemBtn.Click
		Server.Transfer("~/MemberPages/AddEdit.aspx", True)
	End Sub

	Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles stallContents.SelectedIndexChanged
		Dim row As GridViewRow = stallContents.SelectedRow

		Server.Transfer("~/MemberPages/AddEdit.aspx?ID=" & row.Cells(1).Text, True)
	End Sub

	Protected Sub returnButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles returnButton.Click
		Server.Transfer("~/MemberPages/MemberPageHome.aspx")
	End Sub

	Protected Sub queryBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles queryBtn.Click
		Server.Transfer("~/MemberPages/Query.aspx")
	End Sub
End Class