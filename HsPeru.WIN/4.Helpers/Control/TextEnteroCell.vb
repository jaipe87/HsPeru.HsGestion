Public Class TextEnteroCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides ReadOnly Property EditType As Type
        Get
            Return GetType(TextEnteroEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType As Type
        Get
            Return GetType(String)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue As Object
        Get
            Dim defaultValue As Object = MyBase.DefaultNewRowValue
            If TypeOf defaultValue Is String Then
                Return defaultValue
            Else
                Return ""
            End If
        End Get
    End Property

    Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object,
                                                  dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As TextEnteroEditingControl = CType(DataGridView.EditingControl, TextEnteroEditingControl)
        Try
            If Me.Value = Nothing Then
                ctl.Text = CType(Me.DefaultNewRowValue, String)
            Else
                ctl.Text = CType(Me.Value, String)
            End If
        Catch ex As Exception
            ctl.Text = CType(Me.DefaultNewRowValue, String)
        End Try

    End Sub
End Class
