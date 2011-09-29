Imports System.Data
Imports Npgsql
Imports InfoRanch.DB
Public Class CustomComplexDataBasePage4
    Inherits System.Web.UI.Page
    Dim DBCmd As New NpgsqlCommand
    Dim DBCmd2 As New NpgsqlCommand
    Dim DBCmd3 As New NpgsqlCommand
    Dim DBCmd4 As New NpgsqlCommand
    Dim DBCmd5 As New NpgsqlCommand
    Dim DBCmd6 As New NpgsqlCommand
    Dim DBCmd7 As New NpgsqlCommand
    Dim DBCmd8 As New NpgsqlCommand
    Dim name As String
    Dim category As String
    Dim category2 As String
    Dim category3 As String
    Dim category4 As String
    Dim category5 As String
    Dim category6 As String
    Dim category7 As String
    Dim category8 As String
    Dim myConn As New DBConnection
    Dim dbStructure As New DBTemplate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NameTB.Focus()
        stallNameLabel.Visible = True
        dataTypeLabel.Visible = True
        dataTypeDropDown.Visible = True
        categoryTB.Visible = True
        Submit.Visible = True
        categoryTB.Text = Session("foreign_key")
        categoryTB.Enabled = False
        NameTB.Focus()

        If Session("selected_model") = "inventory" Then
            NameTB.Text = "supplier"
            'categoryTB.Text = "supplier ID"
            Session("user_table2_model") = "supplier_ID"
            categoryTB2.Text = "name"
            categoryTB3.Text = "phone"
            categoryTB4.Text = "address"
            categoryTB5.Text = "city"
            categoryTB6.Text = "state"
            categoryTB7.Text = "zip"
            categoryTB8.Text = "manufacturer ID"
            categoryTB3.Visible = True
            categoryTB4.Visible = True
            categoryTB5.Visible = True
            categoryTB6.Visible = True
            categoryTB7.Visible = True
            categoryTB8.Visible = True
            dataTypeDropDown3.Visible = True
            dataTypeDropDown4.Visible = True
            dataTypeDropDown5.Visible = True
            dataTypeDropDown6.Visible = True
            dataTypeDropDown7.Visible = True
            dataTypeDropDown8.Visible = True
            fieldnameLabel4.Visible = True
        End If

        If Session("selected_model") = "corporate_employee" Then
            NameTB.Text = "department"
            'categoryTB.Text = "department number"
            Session("user_table2_model") = "department_number"
            categoryTB2.Text = "department name"
            categoryTB3.Visible = False
            categoryTB4.Visible = False
            categoryTB5.Visible = False
            categoryTB6.Visible = False
            categoryTB7.Visible = False
            categoryTB8.Visible = False
            dataTypeDropDown3.Visible = False
            dataTypeDropDown4.Visible = False
            dataTypeDropDown5.Visible = False
            dataTypeDropDown6.Visible = False
            dataTypeDropDown7.Visible = False
            dataTypeDropDown8.Visible = False
            fieldnameLabel4.Visible = False
        End If

        If Session("selected_model") = "acquaintance_information" Then
            NameTB.Text = "acquaintance name"
            'categoryTB.Text = "acquaintanceID"
            Session("user_table2_model") = "acquaintanceID"
            categoryTB2.Text = "acquaintance name"
            categoryTB3.Visible = False
            categoryTB4.Visible = False
            categoryTB5.Visible = False
            categoryTB6.Visible = False
            categoryTB7.Visible = False
            categoryTB8.Visible = False
            dataTypeDropDown3.Visible = False
            dataTypeDropDown4.Visible = False
            dataTypeDropDown5.Visible = False
            dataTypeDropDown6.Visible = False
            dataTypeDropDown7.Visible = False
            dataTypeDropDown8.Visible = False
            fieldnameLabel4.Visible = False
        End If

    End Sub

    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Submit.Click



        ' connects to the user database
        Dim DBConn As NpgsqlConnection = myConn.connect(Session("user_id"))

        name = Replace(NameTB.Text, " ", "_")

        category = Session("foreign_key")
        category2 = categoryTB2.Text
        category3 = categoryTB3.Text
        category4 = categoryTB4.Text
        category5 = categoryTB5.Text
        category6 = categoryTB6.Text
        category7 = categoryTB7.Text
        category8 = categoryTB8.Text

        DBConn.Open()

        If name IsNot Nothing Then
            ' creates the Temporary Field List Table
            DBCmd = New NpgsqlCommand("CREATE TABLE temp" & name & "(" & name & " varchar(50), datatype varchar(50), sortorder serial)", DBConn)
            DBCmd.ExecuteNonQuery()
        End If

        ' inserts values into FieldList
        If category IsNot String.Empty Then
            DBCmd = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallName, @dataType)", DBConn)
            DBCmd.Parameters.AddWithValue("@stallName", Replace(category, " ", "_"))
            DBCmd.Parameters.AddWithValue("@dataType", dataTypeDropDown.SelectedValue)
            DBCmd.ExecuteNonQuery()
        End If

        If category2 IsNot String.Empty Then
            DBCmd2 = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallname, @dataType)", DBConn)
            DBCmd2.Parameters.AddWithValue("@stallname", Replace(category2, " ", "_"))
            DBCmd2.Parameters.AddWithValue("@dataType", dataTypeDropDown2.SelectedValue)
            DBCmd2.ExecuteNonQuery()
        End If

        If categoryTB3.Visible = True Then
            If category3 IsNot String.Empty Then
                DBCmd3 = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallname, @dataType)", DBConn)
                DBCmd3.Parameters.AddWithValue("@stallname", Replace(category3, " ", "_"))
                DBCmd3.Parameters.AddWithValue("@dataType", dataTypeDropDown3.SelectedValue)
                DBCmd3.ExecuteNonQuery()
            End If
        End If

        If categoryTB4.Visible = True Then
            If category4 IsNot String.Empty Then
                DBCmd4 = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallname, @dataType)", DBConn)
                DBCmd4.Parameters.AddWithValue("@stallname", Replace(category4, " ", "_"))
                DBCmd4.Parameters.AddWithValue("@dataType", dataTypeDropDown4.SelectedValue)
                DBCmd4.ExecuteNonQuery()
            End If
        End If

        If categoryTB5.Visible = True Then
            If category5 IsNot String.Empty Then
                DBCmd5 = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallname, @dataType)", DBConn)
                DBCmd5.Parameters.AddWithValue("@stallname", Replace(category5, " ", "_"))
                DBCmd5.Parameters.AddWithValue("@dataType", dataTypeDropDown5.SelectedValue)
                DBCmd5.ExecuteNonQuery()
            End If
        End If

        If categoryTB6.Visible = True Then
            If category6 IsNot String.Empty Then
                DBCmd6 = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallname, @dataType)", DBConn)
                DBCmd6.Parameters.AddWithValue("@stallname", Replace(category6, " ", "_"))
                DBCmd6.Parameters.AddWithValue("@dataType", dataTypeDropDown6.SelectedValue)
                DBCmd6.ExecuteNonQuery()
            End If
        End If

        If categoryTB7.Visible = True Then
            If category7 IsNot String.Empty Then
                DBCmd7 = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallname, @dataType)", DBConn)
                DBCmd7.Parameters.AddWithValue("@stallname", Replace(category7, " ", "_"))
                DBCmd7.Parameters.AddWithValue("@dataType", dataTypeDropDown7.SelectedValue)
                DBCmd7.ExecuteNonQuery()
            End If
        End If

        If categoryTB8.Visible = True Then
            If category8 IsNot String.Empty Then
                DBCmd8 = New NpgsqlCommand("INSERT INTO temp" & name & " (" & name & ",datatype) VALUES (@stallname, @dataType)", DBConn)
                DBCmd8.Parameters.AddWithValue("@stallname", Replace(category8, " ", "_"))
                DBCmd8.Parameters.AddWithValue("@dataType", dataTypeDropDown8.SelectedValue)
                DBCmd8.ExecuteNonQuery()
            End If
        End If

        DBConn.Close()
        'categoryTB.Text = ""
        'categoryTB2.Text = ""
        'categoryTB3.Text = ""
        'categoryTB4.Text = ""
        'categoryTB5.Text = ""
        Session("custom_table") = name

        '--------------------------------------------------------------------------------------------------
        Dim tempName As String = ""

        If Session("custom_table") IsNot Nothing Then
            tempName = Session("custom_table")
        Else
            Response.Redirect("~/MemberPages/MemberPageHome.aspx")
        End If

        dbStructure.setName(tempName)

        DBConn = myConn.connect(Session("user_id"))
        DBConn.Open()

        DBCmd = New NpgsqlCommand("SELECT " & tempName & " as ""Stall Name"", datatype as ""Critter Type"", sortorder FROM temp" & tempName, DBConn)
        Dim dbReader As NpgsqlDataReader = DBCmd.ExecuteReader()

        While dbReader.Read()
            dbStructure.addItem(dbReader(0), dbReader(1), dbReader(2) * 10)
        End While
        dbReader.Close()

        '---------------------------------------------------------------------------------------------------

        dbStructure.addItem("ID", "serial", 10000)

        ' New table to tablelist
        DBCmd = New NpgsqlCommand("INSERT INTO " & Session("complex_database") & " VALUES ('" & dbStructure.getName() & "')", DBConn)
        DBCmd.ExecuteNonQuery()

        ' Set up field list table
        DBCmd = New NpgsqlCommand("CREATE TABLE fieldlist" & dbStructure.getName() & " (" & dbStructure.getName() & " varchar(50), datatype varchar(50), sortorder int)", DBConn)
        DBCmd.ExecuteNonQuery()

        ' Add data to field list

        For i As Integer = 0 To dbStructure.length - 1
            DBCmd = New NpgsqlCommand("INSERT INTO fieldlist" & dbStructure.getName() & " VALUES (@field, @datatype, @sortorder)", DBConn)
            DBCmd.Parameters.AddWithValue("@field", dbStructure.getField(i))
            'If dbStructure.getDataType(i) = "money" Then
            'dbCmd.Parameters.AddWithValue("@datatype", "numeric(15,2)")
            'Else
            DBCmd.Parameters.AddWithValue("@datatype", dbStructure.getDataType(i))
            'End If

            DBCmd.Parameters.AddWithValue("@sortorder", dbStructure.getSortOrder(i))
            DBCmd.ExecuteNonQuery()
        Next

        ' Create database table

        Dim dbCreate As String = "CREATE TABLE " & dbStructure.getName() & " ("

        For i As Integer = 0 To dbStructure.length - 1

            'If dbStructure.getField(i) = "ID" Then
            'dbCreate &= ", " & dbStructure.getField(i) & " " & dbStructure.getDataType(i) & " PRIMARY KEY"
            'Else

            If i = 0 Then
                dbCreate &= Replace(dbStructure.getField(i), " ", "_") & " " & dbStructure.getDataType(i) & " PRIMARY KEY"
            ElseIf i = 7 Then
                Session("foreign_key") = dbStructure.getField(i)
                dbCreate &= ", " & Replace(dbStructure.getField(i), " ", "_") & " " & dbStructure.getDataType(i)
            Else
                dbCreate &= ", " & Replace(dbStructure.getField(i), " ", "_") & " " & dbStructure.getDataType(i)
            End If

            'End If

        Next

        dbCreate &= ")"

        DBCmd = New NpgsqlCommand(dbCreate, DBConn)
        DBCmd.ExecuteNonQuery()

        ' Delete temp table

        'deleteTempTable(DBConn)
        DBConn.Close()

        'Session("custom_table") = Nothing
        '---------------------------------------------------------------------------------------------------
        Session("table_level") = "two"
        Server.Transfer("~/MemberPages/CustomComplexConfirm.aspx", True)
        'Server.Transfer("~/MemberPages/CustomComplexDataBasePage5.aspx", True)

    End Sub

    Private Sub deleteTempTable()
        Dim dbConn As NpgsqlConnection

        dbConn = myConn.connect(Session("user_id"))
        dbConn.Open()
        dbCmd = New NpgsqlCommand("DROP TABLE temp" & dbStructure.getName(), dbConn)
        dbCmd.ExecuteNonQuery()

        dbConn.Close()

    End Sub

    Private Sub deleteTempTable(ByRef conn As NpgsqlConnection)

        dbCmd = New NpgsqlCommand("DROP TABLE temp" & dbStructure.getName(), conn)
        dbCmd.ExecuteNonQuery()

    End Sub

    Protected Sub cancelBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelBtn.Click
        ' connects to the user database
        Dim DBConn As NpgsqlConnection = myConn.connect(Session("user_id"))
        Dim reader As NpgsqlDataReader
        Dim tableList(3) As String
        Dim j As Integer
        Dim Table As String
        Dim fieldlistTable As String
        Dim deleteCmd As NpgsqlCommand

        DBConn.Open()

        DBCmd = New NpgsqlCommand("SELECT list from " & Session("complex_database"), DBConn)
        reader = DBCmd.ExecuteReader()

        If Session("table_level") = "one" Then
            j = 0
        ElseIf Session("table_level") = "two" Then
            j = 1
        ElseIf Session("table_level") = "three" Then
            j = 2
        End If

        Dim k As Integer
        k = 0

        While reader.Read()
            tableList(k) = reader(0)
            k = k + 1
        End While

        reader.Close()

        For i = 0 To j
            Table = tableList(i)
            deleteCmd = New NpgsqlCommand("DROP TABLE " & Table, DBConn)
            deleteCmd.ExecuteNonQuery()
            fieldlistTable = "fieldlist" & Table
            deleteCmd = New NpgsqlCommand("DROP TABLE " & fieldlistTable, DBConn)
            deleteCmd.ExecuteNonQuery()
        Next

        ' delete New complex database 'table' from tablelist
        DBCmd = New NpgsqlCommand("DELETE FROM tablelist WHERE list = '" & Session("complex_database") & "'", DBConn)
        DBCmd.ExecuteNonQuery()
        ' drop 'customComplexDatabasE Tablelist' table 
        DBCmd = New NpgsqlCommand("DROP TABLE " & Session("complex_database"), DBConn)
        DBCmd.ExecuteNonQuery()

        If name <> "" Then
            DBCmd = New NpgsqlCommand("DROP TABLE temp" & name, DBConn)
            DBCmd.ExecuteNonQuery()
            DBConn.Close()
        End If

        Response.Redirect("~/MemberPages/MemberPageHome.aspx")

    End Sub

End Class