﻿Public Class TextEnteroGridColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New TextEnteroCell())
    End Sub

    Public Overrides Property CellTemplate As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(value As DataGridViewCell)
            If value IsNot Nothing AndAlso
                Not value.GetType().IsAssignableFrom(GetType(TextEnteroCell)) Then
                Throw New InvalidCastException("Debe especificar una instancia de TextFloatCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class
