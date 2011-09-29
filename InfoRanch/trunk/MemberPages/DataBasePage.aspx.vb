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
    Dim coralTemplate As New DBTemplate


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userID As String = Session("user_id")
        Dim userTable As String = Session("user_table")
        Dim myCon As New DBConnection
        Dim complexDatabaseRegex As New Regex("_complex$")
        welcomeMsg.Text = "'" & Session("user_table") & "'" & " table"
        DBConn = myCon.connect(userID)
        DBConn.Open()

        If complexDatabaseRegex.IsMatch(userTable) Then
            Response.Redirect("~/MemberPages/CustomComplexDataBasePage.aspx")
        Else
            DBCom = New NpgsqlCommand("SELECT " & userTable & " FROM FieldList" & userTable & " ORDER BY sortorder", DBConn)

        End If

        If Session("database_status") IsNot Nothing Then
            If complexDatabaseRegex.IsMatch(Session("database_status")) Then
                deleteButton.Enabled = False
            End If
        End If

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
        Dim pk As String = ""
        Dim fk1 As String = ""
        Dim fk2 As String = ""
        Dim mode As String = "add"

        coralTemplate.setName(Session("user_table"))

        ' Check to see if the ID parameter is set in the query string
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
        DBConn = myConn.connect(Session("user_id"))

        DBCom = New NpgsqlCommand("SELECT " & coralTemplate.getName() & ", datatype, sortorder FROM fieldlist" & coralTemplate.getName() & " WHERE " & _
          coralTemplate.getName() & "<> 'ID' ORDER BY sortorder", DBConn)

        DBConn.Open()

        Dim dbReader As NpgsqlDataReader = DBCom.ExecuteReader()

        'Read the query
        While dbReader.Read()
            coralTemplate.addItem(dbReader(0), dbReader(1), dbReader(2))
        End While

        If Session("table_number_used") = "table1" Then
            If Session("user_table1_model") = "stock_item" Then
                pk = coralTemplate.getField(0) & ", "
                fk1 = coralTemplate.getField(3)
            End If
            If Session("user_table1_model") = "employee_record" Then
                pk = coralTemplate.getField(0) & ", "
                fk1 = coralTemplate.getField(2) & ", "
                fk2 = coralTemplate.getField(3)
            End If
            If Session("user_table1_model") = "acquaintance_address" Then
                pk = coralTemplate.getField(0) & ", "
                fk1 = coralTemplate.getField(3)
            End If
        End If
        If Session("table_number_used") = "table2" Then
            If Session("user_table2_model") = "supplier" Then
                pk = coralTemplate.getField(0) & ", "
                fk1 = coralTemplate.getField(7)
            End If
            If Session("user_table2_model") = "department" Then
                pk = coralTemplate.getField(0) & ", "
            End If
            If Session("user_table2_model") = "acquaintance_name" Then
                pk = coralTemplate.getField(0) & ", "
            End If
        End If
        If Session("table_number_used") = "table3" Then
            If Session("user_table3_model") = "manufacturer" Then
                pk = coralTemplate.getField(0) & ", "
            End If
            If Session("user_table3_model") = "corporate" Then
                pk = coralTemplate.getField(0) & ", "
            End If
            If Session("user_table3_model") = "acquaintance_phone" Then
                pk = coralTemplate.getField(0) & ", "
                fk1 = coralTemplate.getField(1)
            End If
        End If

        'Close connectin
        dbReader.Close()
        DBConn.Close()

        MsgBox("Warnings - When entering 'Primary Key' (PK) value and 'Foreign Key' (FK) value(s) of a record or an item into a table, make sure the entered value of the PK " & _
               "is not as same as the PK value of the previous record or previous item, and also take notes of the FK value(s), to enter them again in a different table later. " & _
               "In this case those PK, FK value(s) is/are: " & pk & fk1 & fk2, MsgBoxStyle.Information)
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