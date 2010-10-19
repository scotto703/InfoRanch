Imports System.Data
Imports System.Data.SqlClient


Partial Public Class MemberPageHome
    Inherits System.Web.UI.Page

    Dim DBCmd As New SqlCommand
   


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label2.Text = "Welcome " & Session("user_id") & "!"
        Label4.Text = "Please Select A Database"
        Label3.Text = "You Currently Have No Databases. Please Select Template Database Or Custom Database On The Left To Create A Database"
        Label3.Visible = False

        




        Dim UserDatabase = Session("user_id").ToString()
        ' connection string with the Session variable "user_id"
        Dim cmd As SqlCommand = New SqlCommand("SELECT List from TableList", New SqlConnection("Persist Security Info=False;Integrated Security=SSPI;" & _
    "database=" & Session("user_id") & ";server=localhost;Connect Timeout=30"))
        If Not Page.IsPostBack Then

            cmd.Connection.Open()

            ' loads the items into the drop-down list
            UserDatabasesDD.DataSource = cmd.ExecuteReader()
            UserDatabasesDD.DataTextField = "List"

            UserDatabasesDD.DataValueField = "List"


            UserDatabasesDD.DataBind()
        End If

        cmd.Connection.Close()
        cmd.Connection.Dispose()
        
        Dim CountDB = UserDatabasesDD.Items.Count
        
        ' if there are no items in the database, then then label3.text appears
        If CountDB < 1 Then
            UserDatabasesDD.Visible = False
            SubmitBTN.Visible = False
            Label3.Visible = True
            Label4.Visible = False
        End If

    End Sub

    





    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        ' assigns the selected item value to the Session variable and 
        ' redirects to UserDatabasePage.aspx
        Session("user_table") = UserDatabasesDD.SelectedValue.ToString

        Server.Transfer("~/MemberPages/UserDatabasePage.aspx", True)


    End Sub
End Class
