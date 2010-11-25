<%@ Page Language="VB" %>
<%@ Import Namespace="Npgsql" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    Public Class MyTemplate
        Implements System.Web.UI.ITemplate

        Dim templateType As ListItemType
        Dim fieldList As List(Of String) = New List(Of String)
        
        Sub New(ByVal type As ListItemType, ByRef fields As List(Of String))
            templateType = type
            For i As Integer = 0 To fields.Count - 1
                fieldList.Add(fields(i))
            Next
            
        End Sub

        Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) _
          Implements System.Web.UI.ITemplate.InstantiateIn

            Dim ph As New PlaceHolder()
            'Dim item1 As New Label()
            'Dim item2 As New Label()
            'item1.ID = "item1"
            'item2.ID = "item2"
            Dim labelList = New List(Of Label)
            Dim textBoxesList = New List(Of TextBox)
            For i As Integer = 0 To fieldList.Count - 1
                labelList.Add(New Label())
                textBoxesList.Add(New TextBox())
                labelList(i).ID = fieldList(i) & "Label"
                textBoxesList(i).ID = fieldList(i) & "TB"
            Next
            Select Case (templateType)
                Case ListItemType.Header
                    ph.Controls.Add(New LiteralControl("<table border=""1"">" & _
                        "<tr><td><b>&nbsp;</b></td>" & _
                        "<td><b>&nbsp;</b></td></tr>"))
                Case ListItemType.Item
                    'ph.Controls.Add(New LiteralControl("<tr><td>"))
                    'ph.Controls.Add(item1)
                    'ph.Controls.Add(New LiteralControl("</td><td>"))
                    'ph.Controls.Add(item2)
                    'ph.Controls.Add(New LiteralControl("</td></tr>"))
                    For i As Integer = 0 To labelList.Count - 1
                        ph.Controls.Add(New LiteralControl("<tr><td>"))
                        ph.Controls.Add(labelList(i))
                        ph.Controls.Add(New LiteralControl("</td><td>"))
                        ph.Controls.Add(textBoxesList(i))
                        ph.Controls.Add(New LiteralControl("</td></tr>"))
                    Next
                    
                    
                    AddHandler ph.DataBinding, New EventHandler(AddressOf Item_DataBinding)
                    'Case ListItemType.AlternatingItem
                    '    ph.Controls.Add(New LiteralControl("<tr bgcolor=""lightblue""><td>"))
                    '    ph.Controls.Add(item1)
                    '    ph.Controls.Add(New LiteralControl("</td><td>"))
                    '    ph.Controls.Add(item2)
                    '    ph.Controls.Add(New LiteralControl("</td></tr>"))
                    '    AddHandler ph.DataBinding, New EventHandler(AddressOf Item_DataBinding)
                Case ListItemType.Footer
                    ph.Controls.Add(New LiteralControl("</table>"))
            End Select
            container.Controls.Add(ph)
        End Sub
        Public Sub Item_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim ph As PlaceHolder = CType(sender, PlaceHolder)
            Dim ri As RepeaterItem = CType(ph.NamingContainer, RepeaterItem)
            'Dim item1Value As Integer = _
            '    Convert.ToInt32(DataBinder.Eval(ri.DataItem, "SortOrder"))
            'Dim item2Value As String = _
            '    Convert.ToString(DataBinder.Eval(ri.DataItem, "Books"))
            'CType(ph.FindControl("item1"), Label).Text = item1Value.ToString()
            'CType(ph.FindControl("item2"), Label).Text = item2Value
            For i As Integer = 0 To fieldList.Count - 1
                Dim dataValue As String = Convert.ToString(DataBinder.Eval(ri.DataItem, fieldList(i)))
                Dim labelValue As String = StrConv(fieldList(i), VbStrConv.ProperCase)
                CType(ph.FindControl(fieldList(i) & "Label"), Label).Text = labelValue
                CType(ph.FindControl(fieldList(i) & "TB"), TextBox).Text = dataValue
                CType(ph.FindControl("publisherTB"), TextBox).TextMode = TextBoxMode.MultiLine
                
                
            Next
        End Sub
     
    End Class

    Protected Sub Page_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Dim fields = New List(Of String)
        Dim conn As New NpgsqlConnection("Server=localhost;Port=5432;Userid=inforanch;password=inforanch;Database=jforbes;Timeout=30")
        Dim cmd As NpgsqlCommand = New NpgsqlCommand("Select books from fieldlistbooks", conn)
        conn.Open()
        Dim reader As NpgsqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            fields.Add(reader(0))
        End While
        reader.Close()
        conn.Close()
        
        Dim sqlDataAdapter1 As NpgsqlDataAdapter
        Dim dsCategories1 As System.Data.DataSet

        sqlDataAdapter1 = New NpgsqlDataAdapter( _
            "SELECT title, author, publisher, genre, ID from books where ID = 1", conn)
        dsCategories1 = New System.Data.DataSet()

        Repeater1.HeaderTemplate = New MyTemplate(ListItemType.Header, fields)
        Repeater1.ItemTemplate = New MyTemplate(ListItemType.Item, fields)
        'Repeater1.AlternatingItemTemplate = New MyTemplate(ListItemType.AlternatingItem)
        Repeater1.FooterTemplate = New MyTemplate(ListItemType.Footer, fields)
        sqlDataAdapter1.Fill(dsCategories1, "books")
        Repeater1.DataSource = dsCategories1.Tables("books")
        Repeater1.DataBind()

    End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Dynamically Creating Templates</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Repeater id="Repeater1" runat="server"></asp:Repeater>    
    </div>
    </form>
</body>
</html>

