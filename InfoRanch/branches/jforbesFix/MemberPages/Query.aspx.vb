Imports System.Data
Imports System.Data.SqlClient
Imports System.IO




Partial Public Class Query
    Inherits System.Web.UI.Page
    Dim DBCmd = New SqlCommand





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SearchTB.Focus()
        NewSearchBTN.Visible = False
        Cancel2BTN.Visible = False

        Label4.Text = Session("user_table") & " Information"

        ' connects to the user database
        SqlDataSource1.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;database=" & Session("user_id") & ";server=localhost;Connect Timeout=30"

        ' loads the query results to the drop down list
        SqlDataSource1.SelectCommand = "SELECT " & Session("user_table") & " From FieldList" & Session("user_table") & " where " & Session("user_table") & " <> 'ID'"

        If Not Page.IsPostBack Then
            DropDownList1.Visible = True
            Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                      "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")

            DBCmd = New SqlCommand("SELECT " & Session("user_table") & " From FieldList" & Session("user_table") & " where " & Session("user_table") & " <> 'ID'", DBConn)
            DBConn.Open()


            DropDownList1.DataSource = DBCmd.ExecuteReader()

            DropDownList1.DataTextField = "" & Session("user_table") & ""

            DropDownList1.DataValueField = "" & Session("table_table") & ""


            DropDownList1.DataBind()

            DBConn.Close()
            DBConn.Dispose()

        End If

    End Sub
    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click


        GridView1.Visible = True

        SubmitBTN.Visible = False
        Cancel1.Visible = False
        NewSearchBTN.Visible = True
        Cancel2BTN.Visible = True


        DropDownList1.Visible = False
        Label2.Visible = False
        Label3.Visible = False

        SearchTB.Visible = False



        Dim SelectedValue = DropDownList1.SelectedValue()



        Dim SearchValue = SearchTB.Text


        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                  "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")




        DBCmd = New SqlCommand("select * from " & Session("user_table") & " where " & SelectedValue & " = '" & SearchValue & "'", DBConn)



        DBConn.Open()

        Dim drEmployee As SqlDataReader = DBCmd.ExecuteReader()

        Dim dt As DataTable = New DataTable()
        dt.Load(drEmployee)
        GridView1.DataSource = dt
        GridView1.DataBind()



        '
        'Closing the data reader & connection object
        drEmployee.Close()
        DBConn.Close()



       







    End Sub

    Protected Sub ClearBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NewSearchBTN.Click
        SearchTB.Text = ""
        GridView1.Visible = False
        SubmitBTN.Visible = True
        NewSearchBTN.Visible = False
        DropDownList1.Visible = True
        Label2.Visible = True
        SearchTB.Visible = True

    End Sub

    Protected Sub Cancel1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel1.Click
        Server.Transfer("~/MemberPages/UserDatabasePage.aspx", True)
    End Sub

    Protected Sub Cancel2BTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel2BTN.Click
        Server.Transfer("~/MemberPages/UserDatabasePage.aspx", True)
    End Sub

   
    
    
End Class