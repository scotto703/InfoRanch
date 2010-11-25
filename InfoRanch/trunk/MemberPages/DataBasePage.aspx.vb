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

        DBConn.ConnectionString = "Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" &
            userID & ";Timeout=30"
        DBConn.Open()

        DBCom = New NpgsqlCommand("SELECT " & userTable & " FROM FieldList" & userTable & " ORDER BY sortorder", DBConn)
		Dim dbReader As NpgsqlDataReader = DBCom.ExecuteReader()

        dbReader.Read()

        Dim titleField As String = dbReader(0)

        dbReader.Close()
        DBConn.Close()

        SqlDataSource1.ConnectionString = "Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" & userID & ";Timeout=30"
        SqlDataSource1.ProviderName = "Npgsql"
        SqlDataSource1.SelectCommand = "SELECT ID, " & titleField & " FROM " & userTable


    End Sub


	Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles stallContents.RowCreated

		If e.Row.RowType = DataControlRowType.Header Then
			e.Row.Cells(1).Visible = False
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
End Class