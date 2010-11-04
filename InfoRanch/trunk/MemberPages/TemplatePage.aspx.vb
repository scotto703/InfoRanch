Imports System.Data
Imports System.Data.SqlClient
Imports InfoRanch.DB



Partial Public Class TemplatePage
    Inherits System.Web.UI.Page

    Dim newDB As New DBTemplate
    Dim dataTypeList As New ArrayList
    Dim sortOrderList As New List(Of Integer)
    Dim DBCmd As New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'set newDB name field to session variable "template_selection"
        newDB.setName(Session("template_selection"))

        ' connection to DB to list fields in fieldList checkboxes
        SqlDataSource1.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;" & _
                                  "database=templates_database;server=localhost;Connect Timeout=30"


        ' selects the template field names and loads the results to the checkbox list
        SqlDataSource1.SelectCommand = "SELECT fields FROM " & newDB.getName() & " ORDER BY sortorder"

        fieldSelectHeader1.Text = "Please check the items below that you"
        fieldSelectHeader2.Text = "want to include with your " & newDB.getName() & " information."

        'Connect to templates_database to get the list of datatypes for the fields
        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                        "database=templates_database;server=localhost;Connect Timeout=30")

        DBConn.Open()

        'Select the datatypes from the database
        DBCmd = New SqlCommand("SELECT datatypes,sortorder FROM " & newDB.getName() & " ORDER BY sortorder", DBConn)

        'Read data from database
        Dim dataTypesReader As SqlDataReader = DBCmd.ExecuteReader()

        'Populate dataTypeList
        While dataTypesReader.Read()
            dataTypeList.Add(dataTypesReader(0))
            sortOrderList.Add(dataTypesReader(1))
        End While

        'Close reader and connection
        dataTypesReader.Close()
        DBConn.Close()
    End Sub

    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        ' connects to the user's DB
        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                 "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")





        Dim itemCount As Integer

        'counts the number of checked items
        itemCount = fieldList.Items.Count

        ' Populates the member varialbes of newDB
        Dim i As Integer
        For i = 0 To (itemCount - 1)
            If fieldList.Items(i).Selected = True Then
                Dim newString = Replace(fieldList.Items(i).Value, " ", "")
                newDB.addItem(newString, dataTypeList(i), sortOrderList(i))
            End If
        Next i

        Dim count = newDB.length

        'Open Connection set up new user database from template
        DBConn.Open()

        'Add new DB into TableList
        DBCmd = New SqlCommand("INSERT INTO TableList VALUES('" & newDB.getName() & "')", DBConn)
        DBCmd.ExecuteNonQuery()

        'Generate string for user database table creation
        Dim createDB As String = "CREATE TABLE " & newDB.getName() & "("
        For i = 0 To count - 1
            createDB &= newDB.getField(i) & " " & newDB.getDataType(i) & ","
        Next
        createDB &= "ID int)"

        'Create new table for user DB
        DBCmd = New SqlCommand(createDB, DBConn)
        DBCmd.ExecuteNonQuery()

        'Create FieldList table for new user db
        DBCmd = New SqlCommand("CREATE TABLE FieldList" & newDB.getName() & "(" & newDB.getName() & " nvarchar(50), sortorder int)", DBConn)
        DBCmd.ExecuteNonQuery()

        'Populate FieldList
        For i = 0 To count - 1
            DBCmd = New SqlCommand("INSERT INTO FieldList" & newDB.getName() & " VALUES('" & newDB.getField(i) & "'," & newDB.getSortOrder(i) & ")", DBConn)
            DBCmd.ExecuteNonQuery()
        Next

        DBCmd = New SqlCommand("INSERT INTO FieldList" & newDB.getName() & " Values('ID', 200)", DBConn)
        DBCmd.ExecuteNonQuery()

        DBConn.Close()

        Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)



    End Sub






End Class