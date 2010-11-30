' DataTemplate Class
' This Class is a template class for the display of database information in a
' usable format.  It will add the appropriate textboxes and labels.
' New(ListItemType, DBTemplate, String) - Constructor that takes a list type item, dbtemplate item, and string for mode)
' InstantiateIn(Control) - Sets up the template
' Item_DataBinding(Object, EventArgs) - Adds data when it is bound to the control

Namespace DB

	Public Class DataTemplate
		Implements System.Web.UI.ITemplate

		Dim templateType As ListItemType
		Dim fieldTemplate As New DBTemplate
		Dim templateMode As String

		' Constructor
		' Paramaters
		' type - ListItemType such as a Repeater.Header, Repeater.Item, or other template items
		' database - DBTemplate object that holds the information for the database to be bound to the control
		' mode - String that sets the mode, should be either "add", "view", "edit"

		Sub New(ByVal type As ListItemType, ByRef database As DBTemplate, ByVal mode As String)
			templateType = type
			fieldTemplate.setName(database.getName())
			templateMode = mode

			For i As Integer = 0 To database.length - 1
				fieldTemplate.addItem(database.getField(i), database.getDataType(i), database.getSortOrder(i))
			Next

		End Sub

		'This subroutine instantiates the template based control

		Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) _
		  Implements System.Web.UI.ITemplate.InstantiateIn

			Dim ph As New PlaceHolder()
			Dim labelList = New List(Of Label)
			Dim textBoxesList = New List(Of TextBox)
			Dim textLabel = New List(Of Label)

			' Select the case based on the mode that the page is in

			Select Case (templateMode)
				Case "view"

					' For the view mode the controls in the template all labels
					' add the field name and a suffex to each control

					For i As Integer = 0 To fieldTemplate.length - 1
						labelList.Add(New Label())
						textLabel.Add(New Label())
						labelList(i).ID = fieldTemplate.getField(i) & "Label"
						textLabel(i).ID = fieldTemplate.getField(i) & "Text"
					Next

				Case Else

					' for the other two modes the controls are a label and textbox

					For i As Integer = 0 To fieldTemplate.length - 1
						labelList.Add(New Label())
						textBoxesList.Add(New TextBox())
						labelList(i).ID = fieldTemplate.getField(i) & "Label"
						textBoxesList(i).ID = fieldTemplate.getField(i) & "Text"
					Next

			End Select

			' Set up the template by adding HTML for the table and then add the proper controls
			' based on mode

			Select Case (templateType)
				Case ListItemType.Header
					ph.Controls.Add(New LiteralControl("<table border=""1"">"))
				Case ListItemType.Item

					Select Case (templateMode)
						Case "view"

							For i As Integer = 0 To labelList.Count - 1
								ph.Controls.Add(New LiteralControl("<tr><td>"))
								ph.Controls.Add(labelList(i))
								ph.Controls.Add(New LiteralControl("</td><td>"))
								ph.Controls.Add(textLabel(i))
								ph.Controls.Add(New LiteralControl("</td></tr>"))
							Next

						Case Else

							For i As Integer = 0 To labelList.Count - 1
								ph.Controls.Add(New LiteralControl("<tr><td>"))
								ph.Controls.Add(labelList(i))
								ph.Controls.Add(New LiteralControl("</td><td>"))
								ph.Controls.Add(textBoxesList(i))
								ph.Controls.Add(New LiteralControl("</td></tr>"))
							Next

					End Select

					AddHandler ph.DataBinding, New EventHandler(AddressOf Item_DataBinding)

				Case ListItemType.Footer
					ph.Controls.Add(New LiteralControl("</table>"))
			End Select

			'Add the placeholder controls to the actual container

			container.Controls.Add(ph)
		End Sub

		' Adds information from the datasource when the data is bound to the control

		Public Sub Item_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim ph As PlaceHolder = CType(sender, PlaceHolder)
			Dim ri As RepeaterItem = CType(ph.NamingContainer, RepeaterItem)

			Select Case (templateMode)
				Case "view"

					For i As Integer = 0 To fieldTemplate.length - 1
						Dim dataValue As String = Convert.ToString(DataBinder.Eval(ri.DataItem, fieldTemplate.getField(i)))

						If fieldTemplate.getDataType(i) = "text" Then
							dataValue = Replace(dataValue, vbNewLine, "<br />")
						End If

						Dim labelValue As String = StrConv(fieldTemplate.getField(i), VbStrConv.ProperCase)

						CType(ph.FindControl(fieldTemplate.getField(i) & "Label"), Label).Text = labelValue
						CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), Label).Text = dataValue
					Next

				Case "add"

					For i As Integer = 0 To fieldTemplate.length - 1
						Dim labelValue As String = StrConv(fieldTemplate.getField(i), VbStrConv.ProperCase)
						CType(ph.FindControl(fieldTemplate.getField(i) & "Label"), Label).Text = labelValue
						CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).Text = ""

						If fieldTemplate.getDataType(i) = "text" Then
							CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).TextMode = TextBoxMode.MultiLine
						End If

					Next

				Case "edit"

					For i As Integer = 0 To fieldTemplate.length - 1
						Dim dataValue As String = Convert.ToString(DataBinder.Eval(ri.DataItem, fieldTemplate.getField(i)))
						Dim labelValue As String = StrConv(fieldTemplate.getField(i), VbStrConv.ProperCase)
						CType(ph.FindControl(fieldTemplate.getField(i) & "Label"), Label).Text = labelValue
						CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).Text = dataValue

						If fieldTemplate.getDataType(i) = "text" Then
							CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).TextMode = TextBoxMode.MultiLine
						End If

					Next

			End Select

		End Sub

	End Class

End Namespace
