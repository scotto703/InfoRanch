Public Class testCustomDatabase
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PrintLabel.Attributes.Add("onClick", "window.print();")
    End Sub

End Class