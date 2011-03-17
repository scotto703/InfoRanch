Imports System.Data
Imports Npgsql
Imports InfoRanch.DB


Public Class DataBasePage
    Inherits System.Web.UI.Page

    Dim DBConn As New NpgsqlConnection
    Dim DBCom As New NpgsqlCommand
    Dim DBCmd As New NpgsqlCommand
    Dim name As String
    Dim category As String
    Dim myConn As New DBConnection


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
        titleField = Replace(titleField, " ", "_")

        dbReader.Close()

        DBCom = New NpgsqlCommand("SELECT ID, " & titleField & " FROM " & userTable, DBConn)

        Dim tableValues As NpgsqlDataReader = DBCom.ExecuteReader
        Dim dt As DataTable = New DataTable()

        dt.Load(tableValues)
        stallContents.DataSource = dt
        stallContents.DataBind()

        tableValues.Close()
        DBConn.Close()

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

    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteButton.Click

        Dim userResponse As Integer
        userResponse = MsgBox("Are you sure you want to delete this table?", MsgBoxStyle.YesNo)

        If userResponse = 6 Then


            Dim userTable As String = Session("user_table")

            ' connects to the user database
            Dim DBConn As NpgsqlConnection = myConn.connect(Session("user_id"))


            DBConn.Open()

            DBCmd = New NpgsqlCommand("DROP TABLE " & Session("user_table"), DBConn)
            DBCmd.ExecuteNonQuery()

            DBCmd = New NpgsqlCommand("DELETE FROM tableList WHERE list = '" & Session("user_table") & "'", DBConn)
            DBCmd.ExecuteNonQuery()

            DBCmd = New NpgsqlCommand("DROP TABLE fieldlist" & Session("user_table"), DBConn)
            DBCmd.ExecuteNonQuery()

            DBConn.Close()


            Server.Transfer("~/MemberPages/MemberPageHome.aspx")

        End If
    End Sub
End Class