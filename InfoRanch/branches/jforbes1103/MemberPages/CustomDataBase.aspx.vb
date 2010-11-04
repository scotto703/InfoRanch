Imports System.Data
Imports System.Data.SqlClient


Partial Public Class CustomDataBase
    Inherits System.Web.UI.Page
    Dim DBCmd As New SqlCommand
    Dim Name As String
    Dim Catagory As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        NameTB.Focus()
        Label4.Visible = False
        Label5.Visible = False
        SubmitCatagoryBTN.Visible = False
        SubmitCatagory2BTN.Visible = False
        CatagoryTB.Visible = False
        YesBTN.Visible = False
        NoBTN.Visible = False
        NameTB.Focus()









    End Sub

    Protected Sub SubmitNameBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitNameBTN.Click

        SubmitCatagoryBTN.Focus()
        Label3.Visible = False
        Label4.Visible = True
        SubmitCatagoryBTN.Visible = True
        NameTB.Visible = False
        CatagoryTB.Visible = True
        SubmitNameBTN.Visible = False







    End Sub

    Protected Sub SubmitCatagoryBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitCatagoryBTN.Click
        Label4.Visible = False
        SubmitCatagoryBTN.Visible = False
        CatagoryTB.Visible = False
        Label5.Visible = True
        YesBTN.Visible = True
        NoBTN.Visible = True

        ' connects to the user database
        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
        "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")

        Catagory = CatagoryTB.Text
        Name = NameTB.Text

        DBConn.Open()
        ' creates a new table
        DBCmd = New SqlCommand("CREATE TABLE " & Name & " (" & Catagory & " nvarchar(50))", DBConn)
        DBCmd.ExecuteNonQuery()

        ' creates the FieldList table
        DBCmd = New SqlCommand("CREATE TABLE FieldList" & Name & "(" & Name & " nvarchar(50))", DBConn)
        DBCmd.ExecuteNonQuery()

        ' inserts values into FieldList
        DBCmd = New SqlCommand("INSERT INTO FieldList" & Name & " VALUES ('" & Catagory & "')", DBConn)
        DBCmd.ExecuteNonQuery()

        ' Inserts value into TableList
        DBCmd = New SqlCommand("INSERT INTO TableList VALUES ('" & Name & "')", DBConn)
        DBCmd.ExecuteNonQuery()

        DBConn.Close()


        Label4.Visible = False
        SubmitCatagoryBTN.Visible = False
        CatagoryTB.Visible = False
        Label5.Visible = True
        YesBTN.Visible = True
        NoBTN.Visible = True


    End Sub

    Protected Sub YesBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles YesBTN.Click

        ' sets visibility to add another field
        Label4.Visible = True
        Label5.Visible = False
        YesBTN.Visible = False
        NoBTN.Visible = False
        CatagoryTB.Text = ""
        SubmitCatagoryBTN.Visible = False
        SubmitCatagory2BTN.Visible = True
        CatagoryTB.Visible = True
        CatagoryTB.Focus()




    End Sub

    Protected Sub NoBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NoBTN.Click

        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                                 "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")

        DBConn.Open()

        Name = NameTB.Text

        ' adds field ID to the table
        DBCmd = New SqlCommand("ALTER TABLE " & Name & " ADD ID int", DBConn)
        DBCmd.ExecuteNonQuery()

        DBConn.Close()



        Server.Transfer("~/MemberPages/MemberPageHome.aspx", True)
    End Sub


    Protected Sub SubmitCatagory2BTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitCatagory2BTN.Click

        ' used to make the addition of new categories look fluid


        Label4.Visible = False
        SubmitCatagoryBTN.Visible = False
        CatagoryTB.Visible = False
        Label5.Visible = True
        YesBTN.Visible = True
        NoBTN.Visible = True

        Name = NameTB.Text
        Catagory = CatagoryTB.Text




        Dim DBConn As New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
                               "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30")

        DBConn.Open()



        DBCmd = New SqlCommand("ALTER TABLE " & Name & " ADD " & Catagory & " nvarchar(50)", DBConn)
        DBCmd.ExecuteNonQuery()
        DBCmd = New SqlCommand("INSERT INTO FieldList" & Name & " VALUES ('" & Catagory & "')", DBConn)
        DBCmd.ExecuteNonQuery()

        DBConn.Close()

        CatagoryTB.Text = ""
        CatagoryTB.Focus()


    End Sub
End Class