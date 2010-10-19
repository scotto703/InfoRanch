Imports System.Data
Imports System.Data.SqlClient



Partial Public Class TemplatePage
    Inherits System.Web.UI.Page

    Dim FieldArray As New ArrayList
    Dim DBCmd As New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' connection to DB
        ' changed database string to templates_databse from Database_Templates - JF 10/15
        SqlDataSource1.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;" & _
                                  "database=templates_database;server=localhost;Connect Timeout=30"


        ' selects the template names and loads the results to the checkbox list
        SqlDataSource1.SelectCommand = "SELECT fields FROM " & Session("template_selection") & ""

        Label2.Text = "Please check the items below that you"
        Label3.Text = "want to include with your " & Session("template_selection") & " information."
    End Sub

    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        ' connects to the user's DB
        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                 "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")





        Dim itemCount As Integer

        'counts the number of checked items
        itemCount = CheckBoxList1.Items.Count

        ' adds item values to the array
        Dim i As Integer
        For i = 0 To (itemCount - 1)
            If CheckBoxList1.Items(i).Selected = True Then
                Dim newString = Replace(CheckBoxList1.Items(i).Value, " ", "")
                FieldArray.Add(newString)
            End If
        Next i

        Dim count = FieldArray.Count

        DBConn.Open()

        ' creates table
        DBCmd = New SqlCommand("CREATE TABLE " & Session("template_selection") & "(" & FieldArray(0) & " nvarchar(50))", DBConn)
        DBCmd.ExecuteNonQuery()

        ' creates table fieldlist
        DBCmd = New SqlCommand("CREATE TABLE FieldList" & Session("template_selection") & "(" & Session("template_selection") & " nvarchar(50))", DBConn)
        DBCmd.ExecuteNonQuery()

        ' interts the check box values to table
        For i = 0 To count - 1

            DBCmd = New SqlCommand("INSERT INTO FieldList" & Session("template_selection") & " VALUES ('" & FieldArray(i) & "')", DBConn)
            DBCmd.ExecuteNonQuery()
        Next

        ' inserts check box values to table
        For i = 1 To count - 1

            DBCmd = New SqlCommand("ALTER TABLE " & Session("template_selection") & " ADD " & FieldArray(i) & " nvarchar(50)", DBConn)
            DBCmd.ExecuteNonQuery()
        Next


        DBCmd = New SqlCommand("INSERT INTO FieldList" & Session("template_selection") & " VALUES ('ID')", DBConn)
        DBCmd.ExecuteNonQuery()

        DBCmd = New SqlCommand("INSERT INTO TableList VALUES ('" & Session("template_selection") & "')", DBConn)
        DBCmd.ExecuteNonQuery()

        DBCmd = New SqlCommand("ALTER TABLE " & Session("template_selection") & " ADD ID int", DBConn)
        DBCmd.ExecuteNonQuery()

        DBConn.Close()

        Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)



    End Sub






End Class