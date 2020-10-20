Public Class TextEnteroEditingControl
    Inherits TextBox
    Implements IDataGridViewEditingControl

    Private m_grid As DataGridView
    Private m_valChanged As Boolean
    Public Sub New()
        Me.Text = "0"
        Me.TextAlign = HorizontalAlignment.Right
    End Sub
    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        SendToGridValueChanged()
    End Sub
    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub SendToGridValueChanged()
        m_valChanged = True
        If m_grid IsNot Nothing Then
            m_grid.NotifyCurrentCellDirty(True)
        End If
    End Sub
    Public Sub ApplyCellStyleToEditingControl(dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
    End Sub
    Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return m_grid
        End Get
        Set(value As DataGridView)
            m_grid = value
        End Set
    End Property
    Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Text
        End Get
        Set(value As Object)
            Try
                Me.Text = Convert.ToString(CType(value, String))
            Catch ex As Exception
                Me.Text = "0"
            End Try
            SendToGridValueChanged()
        End Set
    End Property
    Public Property EditingControlRowIndex As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

    Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return m_valChanged
        End Get
        Set(value As Boolean)
            m_valChanged = value
        End Set
    End Property
    Public ReadOnly Property EditingPanelCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property
    Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean _
        Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property
    Public Sub PrepareEditingControlForEdit(selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
    End Sub

    Public Function EditingControlWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Return Not dataGridViewWantsInputKey
    End Function

    Public Function GetEditingControlFormattedValue(context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return EditingControlFormattedValue
    End Function
End Class
