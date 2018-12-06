
Partial Class CreateProgram
    Inherits System.Web.UI.Page

    Private Sub CreateProgram_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load


    End Sub
    'Protected Sub SubmitButton_Click(sender As Object, e As EventArgs)

    'End Sub
    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        Dim programCode As String = ProgramCodeTextBox.Text
        Dim description As String = DescriptionTextBox.Text

        Try

            Dim RequestDirector As BCS = New BCS()
            Dim Confirmation As Boolean = RequestDirector.CreateProgram(programCode, description)

            If Confirmation Then
                MessagesLabel.Text = "Create program was successful"
                MessagesLabel.ForeColor = Drawing.Color.Green
            Else
                MessagesLabel.Text = "Create program was not successful"
                MessagesLabel.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception
            MessagesLabel.Text = ex.Message & "<br />"
            MessagesLabel.ForeColor = Drawing.Color.DarkRed
        End Try




    End Sub
End Class
