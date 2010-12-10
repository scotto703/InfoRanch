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
			Dim required = New List(Of RequiredFieldValidator)
			Dim validExpression = New List(Of RegularExpressionValidator)

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
					' also add validation controls, the list will contain validation controls for every field
					' later only the ones needed will be added to the template

					For i As Integer = 0 To fieldTemplate.length - 1
						labelList.Add(New Label())
						textBoxesList.Add(New TextBox())
						required.Add(New RequiredFieldValidator())
						validExpression.Add(New RegularExpressionValidator())

						labelList(i).ID = fieldTemplate.getField(i) & "Label"
						textBoxesList(i).ID = fieldTemplate.getField(i) & "Text"
						required(i).ID = fieldTemplate.getField(i) & "Req"
						validExpression(i).ID = fieldTemplate.getField(i) & "Valid"
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
								ph.Controls.Add(New LiteralControl("</td><td>"))
								ph.Controls.Add(required(i))

								' For everything except the text and varchar data types add a regular expression validator
								
								If fieldTemplate.getDataType(i) <> "varchar(50)" And fieldTemplate.getDataType(i) <> "text" Then
									ph.Controls.Add(validExpression(i))
								End If

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
						Dim dataValue As String = ""

						Select Case (fieldTemplate.getDataType(i))
							Case "date"
								dataValue = Convert.ToString(DataBinder.Eval(ri.DataItem, fieldTemplate.getField(i)))
								dataValue = dataValue.Substring(0, dataValue.IndexOf(" "))
							Case "numeric(15,2)"
								Dim money As Decimal = DataBinder.Eval(ri.DataItem, fieldTemplate.getField(i))
								dataValue = FormatCurrency(money, 2, 0, 0)
							Case "text"
								dataValue = Convert.ToString(DataBinder.Eval(ri.DataItem, fieldTemplate.getField(i)))
								dataValue = Replace(dataValue, vbNewLine, "<br />")
							Case Else
								dataValue = Convert.ToString(DataBinder.Eval(ri.DataItem, fieldTemplate.getField(i)))
						End Select

						Dim labelValue As String = StrConv(fieldTemplate.getField(i), VbStrConv.ProperCase)

						CType(ph.FindControl(fieldTemplate.getField(i) & "Label"), Label).Text = labelValue
						CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), Label).Text = dataValue
					Next

				Case "add"

					For i As Integer = 0 To fieldTemplate.length - 1
						Dim labelValue As String = StrConv(fieldTemplate.getField(i), VbStrConv.ProperCase)
						CType(ph.FindControl(fieldTemplate.getField(i) & "Label"), Label).Text = labelValue
						CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).Text = ""

						' Set up controls depending on the data type

						Select Case (fieldTemplate.getDataType(i))
							Case "varchar(50)"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
							Case "text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).TextMode = TextBoxMode.MultiLine
							Case "date"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ValidationExpression = "^([1-9]|0[1-9]|1[012])[- /.]([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([0-9]{2}|[0-9]{4})$"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ErrorMessage = "MM/DD/YYYY Format"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
							Case "int"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ValidationExpression = "^(-)?\d+$"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ErrorMessage = "Only positive or negative whole numbers"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
							Case "real"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ValidationExpression = "^(-)?(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ErrorMessage = "Positive or Negative Number"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
							Case "numeric(15,2)"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ValidationExpression = "^(-)?\d+(\.\d{0,2})?$"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ErrorMessage = "Positive or Negative monetary amount without the $"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
						End Select

					Next

				Case "edit"

					For i As Integer = 0 To fieldTemplate.length - 1
						Dim dataValue As String = ""
						Dim labelValue As String = StrConv(fieldTemplate.getField(i), VbStrConv.ProperCase)

						Select Case (fieldTemplate.getDataType(i))
							Case "date"
								dataValue = Convert.ToString(DataBinder.Eval(ri.DataItem, fieldTemplate.getField(i)))
								dataValue = dataValue.Substring(0, dataValue.IndexOf(" "))
							Case Else
								dataValue = Convert.ToString(DataBinder.Eval(ri.DataItem, fieldTemplate.getField(i)))
						End Select

						CType(ph.FindControl(fieldTemplate.getField(i) & "Label"), Label).Text = labelValue
						CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).Text = dataValue

						If fieldTemplate.getDataType(i) = "text" Then
							CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).TextMode = TextBoxMode.MultiLine
						End If

						' Set up controls depending on the data type

						Select Case (fieldTemplate.getDataType(i))
							Case "varchar(50)"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
							Case "text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Text"), TextBox).TextMode = TextBoxMode.MultiLine
							Case "date"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ValidationExpression = "^([1-9]|0[1-9]|1[012])[- /.]([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([0-9]{2}|[0-9]{4})$"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ErrorMessage = "MM/DD/YYYY Format"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
							Case "int"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ValidationExpression = "^(-)?\d+$"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ErrorMessage = "Only positive or negative whole numbers"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
							Case "real"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ValidationExpression = "^(-)?(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ErrorMessage = "Positive or Negative Number"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
							Case "numeric(15,2)"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ErrorMessage = "All fields required"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Req"), RequiredFieldValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ValidationExpression = "^(-)?\d+(\.\d{0,2})?$"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ErrorMessage = "Positive or Negative monetary amount without the $"
								CType(ph.FindControl(fieldTemplate.getField(i) & "Valid"), RegularExpressionValidator).ControlToValidate = fieldTemplate.getField(i) & "Text"
						End Select

					Next

			End Select

		End Sub

	End Class

End Namespace
