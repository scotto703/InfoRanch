Imports System.Data
Imports System.Data.SqlClient

Partial Public Class DatabaseTemplates
    Inherits System.Web.UI.Page

    Dim DBCmd = New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        ' connects to the templates database

        SqlDataSource1.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;" & _
                                  "database=templates_;server=localhost;Connect Timeout=30"


        ' queries the database names and loads the results to the radio button list
        SqlDataSource1.SelectCommand = "SELECT fields FROM template_names"




       
    End Sub

    

    Protected Sub SubmitBTN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitBTN.Click

        ' assigns the value to the session variable

        Session("template_selection") = RadioButtonList1.SelectedValue

        Server.Transfer("~/MemberPages/TemplatePage.aspx", True)




    End Sub
End Class





