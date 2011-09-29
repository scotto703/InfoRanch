Public Partial Class InfoRanchGlobal
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HyperLink1.Attributes.Add("onClick", "window.print();")
    End Sub

End Class