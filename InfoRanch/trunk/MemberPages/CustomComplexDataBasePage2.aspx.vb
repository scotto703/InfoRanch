Imports System.Data
Imports Npgsql
Imports InfoRanch.DB

Public Class CustomComplexDataBasePage2
    Inherits System.Web.UI.Page
    Dim myConn As New DBConnection
    Dim DBCmd As New NpgsqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("selected_model") = "inventory" Then
            model.ImageUrl = "inventory.jpg"
            modelLabel.Text = "Inventory Database Model"
        End If
        If Session("selected_model") = "corporate_employee" Then
            model.ImageUrl = "corporate_employee.jpg"
            modelLabel.Text = "Corporate_Employee Database Model"
            model.Height = 350
            model.Width = 500
        End If
        If Session("selected_model") = "acquaintance_information" Then
            model.ImageUrl = "acquaintance_information.jpg"
            modelLabel.Text = "Acquaintance_Information Database Model"
            model.Height = 320
            model.Width = 500
        End If
    End Sub

    Protected Sub continueBTN_Click(sender As Object, e As EventArgs) Handles continueBTN.Click
        Response.Redirect("~/MemberPages/CustomComplexDataBasePage3.aspx")
    End Sub

    Protected Sub CancelBTN_Click(sender As Object, e As EventArgs) Handles CancelBTN.Click
        ' connects to the user database
        Dim DBConn As NpgsqlConnection = myConn.connect(Session("user_id"))

        DBConn.Open()

        ' delete New complex database 'table' from tablelist
        DBCmd = New NpgsqlCommand("DELETE FROM tablelist WHERE list = '" & Session("complex_database") & "'", DBConn)
        DBCmd.ExecuteNonQuery()
        ' drop 'customComplexDatabasE Tablelist' table 
        DBCmd = New NpgsqlCommand("DROP TABLE " & Session("complex_database"), DBConn)
        DBCmd.ExecuteNonQuery()

        Response.Redirect("~/MemberPages/MemberPageHome.aspx")
    End Sub
End Class