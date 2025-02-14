Imports System.ComponentModel
Imports System.Reflection

Public Class HsDataGridViewCellNow
    Inherits DataGridView

#Region "Declaraciones"
    Enum ModoGrilla
        Vertical = 0
        Horizontal = 1
    End Enum
    Enum Estilo
        Normal = 0
        Light = 1
    End Enum


    Private EstiloItem As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

    Private dText As DataGridViewTextBoxEditingControl
#End Region
#Region "Propiedades"
    Private m_GrillaModo As ModoGrilla
    <Category("HsPropiedades"), Description("Propiedades personalizadas para la grilla HsPeru")>
    Public Property HsModoSaltoGrilla() As ModoGrilla
        Get
            Return m_GrillaModo
        End Get
        Set(ByVal value As ModoGrilla)
            m_GrillaModo = value
            Me.Invalidate()
        End Set
    End Property


    Private m_StylePersonalizado As Estilo
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Category("HsPropiedades"), Description("Propiedades personalizadas para la grilla HsPeru")>
    Public Property HsSetEstilo() As Estilo
        Get
            Return m_StylePersonalizado
        End Get
        Set(ByVal value As Estilo)
            m_StylePersonalizado = value
            If Estilo.Light = value Then
                EstiloPersonal()
            Else
                EstiloDefecto()
            End If
            Me.Invalidate()
        End Set
    End Property

    Private m_CharacterCasing As CharacterCasing
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Category("HsPropiedades"), Description("Propiedades personalizadas para la grilla HsPeru")>
    Public Property HsCharacterCasing() As CharacterCasing
        Get
            Return m_CharacterCasing

        End Get
        Set(ByVal value As CharacterCasing)
            m_CharacterCasing = value
            Me.Invalidate()
        End Set
    End Property

    Private m_col As Integer
    Public Property HsCol As Integer
        Get
            Return m_col
        End Get
        Set(value As Integer)
            m_col = value

        End Set
    End Property

    Private m_row As Integer
    Public Property HsRow As Integer
        Get
            Return m_row
        End Get
        Set(value As Integer)
            m_row = value
            If m_row = 0 Then
                If Me.CurrentRow IsNot Nothing Then
                    m_row = Me.CurrentRow.Index
                End If
            End If
        End Set
    End Property

#End Region
#Region "Eventos"
    ''' <summary>
    ''' Ubica el Foco en la celda q se indica
    ''' </summary>
    ''' <param name="indRow"> fila donde deseamos que se ubique</param>
    ''' <param name="indCol">Columna donde deseamos que se ubique</param>
    Public Sub HsColRow(ByVal indRow As Integer, ByVal indCol As Integer)
        m_row = indRow
        m_col = indCol
    End Sub
    Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If keyData = Keys.Enter Then
            If m_col = 0 Then
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            Else
                Me.CurrentCell = Me.Rows(m_row).Cells(m_col)
                m_col = 0
                Return True
            End If

        Else
            Dim ind As Boolean
            ind = MyBase.ProcessDialogKey(keyData)
            If m_col = 0 Then


                If ind And m_col <> 0 Then
                    Me.CurrentCell = Me.Rows(m_row).Cells(m_col)
                    m_col = 0
                    Return True
                Else
                    Return ind
                End If
            Else
                If ind And m_col <> 0 Then
                    Me.CurrentCell = Me.Rows(m_row).Cells(m_col)
                    m_col = 0
                Else
                    Return MyBase.ProcessDialogKey(keyData)
                End If


            End If

        End If
        Return True
    End Function
    ' en 'OnKeyDown'… cuando no estamos en edicion
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then              'Si es 'enter'
            SendKeys.Send(Chr(Keys.Tab))            'Enviar un 'Tab'
        Else
            MyBase.OnKeyDown(e)                     'Devolver el KeyEventArgs
        End If

    End Sub


    Protected Overrides Sub OnCellEnter(e As DataGridViewCellEventArgs)
        MyBase.OnCellEnter(e)
        Me.BeginEdit(True)

    End Sub


    Protected Overrides Sub OnEditingControlShowing(e As DataGridViewEditingControlShowingEventArgs)
        MyBase.OnEditingControlShowing(e)
        dText = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        If dText IsNot Nothing Then
            dText.CharacterCasing = m_CharacterCasing
        End If


    End Sub



#End Region
#Region "Métodos"
    Private Sub EstiloDefecto()
        Me.AllowUserToAddRows = True
        Me.AllowUserToDeleteRows = True
        Me.BackgroundColor = System.Drawing.SystemColors.AppWorkspace
        Me.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.EnableHeadersVisualStyles = False
        Me.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnHeadersHeight = 30

        Me.MultiSelect = False
        Me.RowHeadersVisible = True
        Me.RowHeadersWidth = 22
        Me.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    End Sub
    Private Sub EstiloPersonal()
        Dim DgMiEstilo As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.BorderStyle = System.Windows.Forms.BorderStyle.None

        DgMiEstilo.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DgMiEstilo.BackColor = System.Drawing.SystemColors.Control
        DgMiEstilo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DgMiEstilo.ForeColor = System.Drawing.SystemColors.WindowText
        DgMiEstilo.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DgMiEstilo.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DgMiEstilo.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnHeadersDefaultCellStyle = DgMiEstilo

        Me.MultiSelect = False
        Me.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.EnableHeadersVisualStyles = False
        Me.RowHeadersVisible = True
        Me.RowHeadersWidth = 22
        Me.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnHeadersHeight = 30
        Me.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    End Sub


    ''' <summary>
    ''' Genera filas por defecto en la Grilla
    ''' </summary>
    ''' <param name="nroFilas">Números de Filas</param>
    Public Sub HsAddLineasGrid(ByVal nroFilas As Integer)
        Me.Rows.Clear()
        For F As Integer = 0 To nroFilas - 1
            Me.Rows.Add()
        Next
    End Sub
    ''' <summary>
    ''' Enumera las filas en el grilla
    ''' </summary>
    ''' <param name="Index">Indice  de la columna</param>
    Public Sub HsEnumerarFilas(ByVal Index As Integer)
        For F As Integer = 0 To Me.Rows.Count - 1
            Me.Rows(F).Cells(Index).Value = (F + 1).ToString.PadLeft(2, "0")
        Next
    End Sub

    ''' <summary>
    ''' Enumera las filas en el grilla
    ''' </summary>
    ''' <param name="Name"> Nombre de la columna</param>
    Public Sub HsEnumerarFilas(ByVal Name As String)
        For F As Integer = 0 To Me.Rows.Count - 1
            Me.Rows(F).Cells(Name).Value = (F + 1).ToString.PadLeft(2, "0")
        Next
    End Sub
    ''' <summary>
    '''  Añade una fila a la grilla
    ''' </summary>
    ''' <param name="Indexcol"></param>
    ''' <param name="EnumerarFila"></param>
    ''' <returns> Retorna el Indice dela fila añadida</returns>
    Public Function HsAddRow(ByVal Indexcol As Integer, ByVal Optional EnumerarFila As Boolean = False) As Integer
        Dim rowindex = 0

        Me.Rows.Add()
        rowindex = Me.Rows.Count - 1
        If EnumerarFila Then Me.HsEnumerarFilas(Indexcol)
        Return rowindex
    End Function
    ''' <summary>
    '''  Añade una fila a la grilla
    ''' </summary>
    ''' <param name="NameCol"></param>
    ''' <param name="EnumerarFila"></param>
    ''' <returns> Retorna el Indice dela fila añadida</returns>
    Public Function HsAddRow(ByVal NameCol As String, ByVal Optional EnumerarFila As Boolean = False) As Integer
        Dim rowindex = 0
        Me.Rows.Add()
        rowindex = Me.Rows.Count - 1
        If EnumerarFila Then Me.HsEnumerarFilas(NameCol)
        Return rowindex
    End Function

    ''' <summary>
    '''  Elimina una fila a la grilla usando el indice de la columna
    ''' </summary>
    ''' <param name="Indexcol">Indice la de la columna</param>
    ''' <param name="EnumerarFila">correlativo de la fila</param>
    ''' <returns></returns>
    Public Function HsDeleteRow(ByVal Indexcol As Integer, ByVal Optional EnumerarFila As Boolean = False) As Integer
        Dim TotalRow As Integer = Me.Rows.Count
        If TotalRow = 0 Then MensajeSimple("No hay Filas a eliminar") : Return 0
        Dim RowIndex As Integer = Me.CurrentRow.Index

        If RowIndex < 0 Then MensajeSimple("No se puede eliminar una fila con indice:" & RowIndex) : Return 0
        Me.Rows.RemoveAt(RowIndex)
        TotalRow = Me.Rows.Count
        If TotalRow = 0 Then
            Return TotalRow
        Else
            TotalRow = Me.Rows.Count - 1

        End If
        If EnumerarFila Then Me.HsEnumerarFilas(Indexcol)
        Return TotalRow

    End Function
    ''' <summary>
    ''' Elimina una fila a la grilla usando el nombre de la columna
    ''' </summary>
    ''' <param name="NameCol">nombre de la columna</param>
    ''' <param name="EnumerarFila">correlativo de la fila</param>
    ''' <returns></returns>
    Public Function HsDeleteRow(ByVal NameCol As String, ByVal Optional EnumerarFila As Boolean = False) As Integer
        Dim TotalRow As Integer = Me.Rows.Count
        If TotalRow < 0 Then MensajeSimple("No hay Filas a eliminar") : Return 0
        Dim RowIndex As Integer = Me.CurrentRow.Index
        If RowIndex < 0 Then MensajeSimple("No se puede eliminar una fila con indice:" & RowIndex) : Return 0
        Me.Rows.RemoveAt(RowIndex)
        TotalRow = Me.Rows.Count
        If TotalRow = 0 Then
            Return TotalRow
        Else
            TotalRow = RowIndex - 1

        End If
        If EnumerarFila Then Me.HsEnumerarFilas(NameCol)
        Return TotalRow

    End Function

#End Region





End Class
