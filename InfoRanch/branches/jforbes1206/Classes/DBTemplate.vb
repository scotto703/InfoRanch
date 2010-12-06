﻿'Class to hold a database item template
'name = Database name
'field = field name
'dataType = datatype of field
'sortOrder = sort order of the fields in the DB
'length = number of fields in template
'setName(string) = sets the name variable
'addItem(string,string,integer) = adds the field name and datatype
'getName() = returns the name variable
'getField(int) = returns the field name at the specified index
'getDataType(int) = returns the data type for the field at the specified index
'getSortOrder(int) = returns the sort order number for the field at the specified index

Namespace DB

    Public Class DBTemplate
        'Member variables
        Private name As String
        Private field As New ArrayList
        Private dataType As New ArrayList
        Private sortOrder As New List(Of Integer)
        Public length As Integer = 0

        'Member Functions
        'Sets the name of the database
        'Parameters:
        ' dbName (string)
        Public Sub setName(ByVal dbName As String)
            name = dbName 'Set name variable to parameter
        End Sub

        'Adds an item to the database template
        'Parameters:
        ' fName (string) - holds the field name
        ' dType (string) - holds the datatype for the field
        ' sO (Int) - holds the sort order for the field
        Public Sub addItem(ByVal fName As String, ByVal dType As String, ByVal sO As Integer)
            'Takes 2 strings, the field name, and the data type and stores them in the
            'correct ArrayList.  Increments the length by 1.
            field.Add(fName)
            dataType.Add(dType)
            sortOrder.Add(sO)
            length = length + 1
        End Sub

        'Returns the value stored in name
        Public Function getName() As String
            Return name
        End Function

        'Returns the value of field at the specified index
        'Parameters:
        ' index (Int)
        Public Function getField(ByVal index As Integer) As String
            Return field(index)
        End Function

        'Returns the datatype at the specified index
        'Parameters:
        ' index (Int)
        Public Function getDataType(ByVal index As Integer) As String
            Return dataType(index)
        End Function

        'Returns the sort order at the specified index
        'Parameters:
        ' index (Int)
        Public Function getSortOrder(ByVal index As Integer) As Integer
            Return sortOrder(index)
        End Function
    End Class
End Namespace

