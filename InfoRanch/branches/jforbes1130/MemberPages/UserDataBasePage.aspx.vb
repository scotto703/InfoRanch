Imports System.Data
Imports System.Data.SqlClient


Partial Public Class UserDataBasePage
    Inherits System.Web.UI.Page
    
    Dim DBCmd = New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label3.Text = "You Currently Have No Information. Please Click Add Information"
        Label5.Text = Session("user_table")
        Label3.Visible = False
        Label4.Visible = False
        YesBTN.Visible = False
        NoBTN.Visible = False


        SqlDataSource1.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;database=" & Session("user_id") & ";server=localhost;Connect Timeout=30"
        SqlDataSource1.SelectCommand = "SELECT " & Session("user_table") & " From FieldList" & Session("user_table") & " where " & Session("user_table") & " <> 'ID'"



        SqlDataSource2.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;database=" & Session("user_id") & ";server=localhost;Connect Timeout=30"
        SqlDataSource2.DeleteCommand = "DELETE FROM " & Session("user_table") & " WHERE [ID] = @ID"
        SqlDataSource2.SelectCommand = "SELECT * FROM [" & Session("user_table") & "]"

        Dim CountItems = GridView1.Rows.Count

        If CountItems < 1 Then

            Label3.Visible = True
        Else
            Label3.Visible = False

        End If


        DataList1.Visible = False

        AddBTN.Visible = False
        DeleteBTN.Visible = False





    End Sub


    Protected Sub AddRecordBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AddRecordBTN.Click

        DataList1.Visible = True
        AddBTN.Visible = True

        Label3.Visible = False



    End Sub

    Protected Sub AddBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AddBTN.Click

        Dim allTextBoxValues As String = ""
        Dim c As Control
        Dim childc As Control
        For Each c In DataList1.Controls

            For Each childc In c.Controls
                If TypeOf childc Is TextBox Then
                    allTextBoxValues &= CType(childc, TextBox).Text & "','"
                End If
            Next
        Next
        If allTextBoxValues <> "" Then
            allTextBoxValues = allTextBoxValues.Remove(allTextBoxValues.Length - 3)
        End If


        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                  "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")
        DBConn.Open()


        Dim ID = Int(Rnd() * Now.TimeOfDay.TotalSeconds)

        DBCmd = New SqlCommand("INSERT INTO " & Session("user_table") & " VALUES ('" & allTextBoxValues & "','" & ID & "')", DBConn)
        DBCmd.ExecuteNonQuery()


        DBConn.Close()


        For Each c In DataList1.Controls

            For Each childc In c.Controls

                If TypeOf childc Is TextBox Then
                    CType(childc, TextBox).Text = ""
                End If

            Next

        Next

        DataList1.Visible = False
        AddBTN.Visible = False
        GridView1.Visible = True


        DBCmd = New SqlCommand("select * from " & Session("user_table") & "", DBConn)

        DBConn.Open()

        GridView1.DataBind()


        DBConn.Close()
        DBConn.Dispose()


        Dim CountItems = GridView1.Rows.Count


        If CountItems < 1 Then

            Label3.Visible = True
        Else
            Label3.Visible = False

        End If



    End Sub




    Protected Sub DeleteRecordBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteRecordBTN.Click

        DeleteBTN.Visible = True



    End Sub

    Protected Sub DeleteBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteBTN.Click
        For Each row As GridViewRow In GridView1.Rows

            Dim checkbox As CheckBox = CType(row.FindControl("chkRows"), CheckBox)

            If checkbox.Checked Then

                ' Retreive the Employee ID

                Dim ID As Integer = Convert.ToInt32(GridView1.DataKeys(row.RowIndex).Value)

                ' Pass the value of the selected Employye ID to the Delete //command.

                SqlDataSource2.DeleteParameters("ID").DefaultValue = ID.ToString()

                SqlDataSource2.Delete()



            End If

        Next row
    End Sub




    Protected Sub QueryTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles QueryTable.Click
        Server.Transfer("~/MemberPages/Query.aspx", True)
    End Sub

    Protected Sub DifferentTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DifferentTable.Click
        Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)
    End Sub

   
    Protected Sub DeleteTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteTable.Click

        Label4.Visible = True
        Label4.Text = "Are You Sure You Want To Delete This Database?"
        YesBTN.Visible = True
        NoBTN.Visible = True
        Panel1.Visible = False
        GridView1.Visible = False
        DataList1.Visible = False




    End Sub

    Protected Sub YesBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles YesBTN.Click

        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                  "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")

        DBConn.Open()

        


        DBCmd = New SqlCommand("Drop TABLE FieldList" & Session("user_table") & "", DBConn)
        DBCmd.ExecuteNonQuery()

        DBCmd = New SqlCommand("DELETE FROM TableList WHERE List = '" & Session("user_table") & "'", DBConn)
        DBCmd.ExecuteNonQuery()

        DBCmd = New SqlCommand("Drop TABLE " & Session("user_table") & "", DBConn)
        DBCmd.ExecuteNonQuery()

        DBConn.Close()

        Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)
    End Sub

    Protected Sub NoBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NoBTN.Click

        Label4.Visible = False
        YesBTN.Visible = False
        NoBTN.Visible = False
        Panel1.Visible = True
        GridView1.Visible = True




    End Sub
End Class


