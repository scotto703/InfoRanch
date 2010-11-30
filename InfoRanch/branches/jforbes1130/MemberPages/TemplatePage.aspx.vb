Imports System.Data
Imports Npgsql
Imports InfoRanch.DB



Partial Public Class TemplatePage
    Inherits System.Web.UI.Page

    Dim newDB As New DBTemplate
    Dim dataTypeList As New ArrayList
    Dim sortOrderList As New List(Of Integer)
    Dim DBCmd As New NpgsqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'set newDB name field to session variable "template_selection"
        newDB.setName(Session("template_selection"))

        ' connection to DB to list fields in fieldList checkboxes
        SqlDataSource1.ConnectionString = "Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=templates_database;Timeout=30"
        SqlDataSource1.ProviderName = "Npgsql"

        ' selects the template field names and loads the results to the checkbox list
        SqlDataSource1.SelectCommand = "SELECT fields FROM " & newDB.getName() & " ORDER BY sortorder"

        fieldSelectHeader1.Text = "Please check the items below that you"
        fieldSelectHeader2.Text = "want to include with your " & newDB.getName() & " information."

        'Connect to templates_database to get the list of datatypes for the fields
        Dim DBConn As New NpgsqlConnection("Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=templates_database;Timeout=30")

        DBConn.Open()

        'Select the datatypes from the database
        DBCmd = New NpgsqlCommand("SELECT datatypes,sortorder FROM " & newDB.getName() & " ORDER BY sortorder", DBConn)

        'Read data from database
        Dim dataTypesReader As NpgsqlDataReader = DBCmd.ExecuteReader()

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
        Dim DBConn As New NpgsqlConnection("Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=" & _
                                           Session("user_id") & ";Timeout=30")

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
        DBCmd = New NpgsqlCommand("INSERT INTO TableList VALUES('" & newDB.getName() & "')", DBConn)
        DBCmd.ExecuteNonQuery()

        'Generate string for user database table creation
        Dim createDB As String = "CREATE TABLE " & newDB.getName() & "("
        For i = 0 To count - 1
            createDB &= newDB.getField(i) & " " & newDB.getDataType(i) & ","
        Next
        createDB &= "ID serial PRIMARY KEY)"

        'Create new table for user DB
        DBCmd = New NpgsqlCommand(createDB, DBConn)
        DBCmd.ExecuteNonQuery()

        'Create FieldList table for new user db
        DBCmd = New NpgsqlCommand("CREATE TABLE FieldList" & newDB.getName() & "(" & newDB.getName() & " varchar(50), datatype varchar(50), sortorder int)", DBConn)
        DBCmd.ExecuteNonQuery()

        'Populate FieldList
        For i = 0 To count - 1
            DBCmd = New NpgsqlCommand("INSERT INTO FieldList" & newDB.getName() & " VALUES('" & newDB.getField(i) & "', '" & _
                                      newDB.getDataType(i) & "', " & newDB.getSortOrder(i) & ")", DBConn)
            DBCmd.ExecuteNonQuery()
        Next

        DBCmd = New NpgsqlCommand("INSERT INTO FieldList" & newDB.getName() & " Values('ID', 'serial', 200)", DBConn)
        DBCmd.ExecuteNonQuery()

        DBConn.Close()

        Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)



    End Sub






End Class