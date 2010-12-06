' Simple class that creates a Npgsql Connection and returns it
' This allows for the keeping of the server name, port, user name, and password
' all in one place in the code so that it can be easily changed if the application is moved and a new
' connection string is required without changing every page

Imports Npgsql

Namespace DB

	Public Class DBConnection
		Private Const DB_USER As String = "inforanch"
		Private Const DB_PWD As String = "inforanch"
		Private Const DB_SERVER As String = "localhost"
		Private Const DB_PORT As String = "5432"

		' Function connect
		' The function that creates the connection and returns it
		' Parameters
		' dbName - String - the name of the database to be connected to
		Public Function connect(ByVal dbName As String) As NpgsqlConnection
			Dim myConnection As NpgsqlConnection
			Dim connectString As String

			connectString = "Server=" & DB_SERVER & ";Port=" & DB_PORT & ";userid=" & DB_USER & ";password=" & DB_PWD & ";Database=" & dbName & ";Timeout=30"
			myConnection = New NpgsqlConnection(connectString)

			Return myConnection
		End Function
	End Class

End Namespace

