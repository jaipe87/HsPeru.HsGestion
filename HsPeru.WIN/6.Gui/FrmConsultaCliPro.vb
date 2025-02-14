Option Strict On
Public Class FrmConsultaCliPro
    Public form_datclipro As CLIPRO
    Public form_lstClipro As New List(Of CLIPRO)
    Private EsRapida As Boolean = False
    Public BsqExitosa As Boolean = False
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#Region "Métodos"

    Sub ConsultaRapida(ByVal Criterio As String, ByVal TipReg As Integer)
        EsRapida = True
        Panel3.Visible = False
        txtCriterio.Text = Criterio
        Buscar(TipReg)
    End Sub
    Sub Buscar(ByVal Optional TipReg As Integer = 0)
        Dim oCliente As New DAL_CLIPRO
        Dim Filas As Integer = 0
        form_lstClipro = oCliente.SelectAll_clipro(New CLIPRO With {.RAZSOC = txtCriterio.Text.Trim, .TIPREG = TipReg}, If(rbdInicioRazon.Checked, 0, 1))
        DgCliente.Rows.Clear()

        If Not IsNothing(form_lstClipro) Then
            If form_lstClipro.Count > 0 Then
                For Each item As CLIPRO In form_lstClipro
                    With DgCliente
                        .Rows.Add()
                        .Rows(Filas).Cells(colTipReg.Index).Value = item.DESTIPREG
                        .Rows(Filas).Cells(colcodigo.Index).Value = item.CODIGO
                        .Rows(Filas).Cells(colDesdoc.Index).Value = item.DESTIPDOC
                        .Rows(Filas).Cells(colNroDoc.Index).Value = item.NRODOC
                        .Rows(Filas).Cells(colRazsoc.Index).Value = item.TRAZSOC
                        .Rows(Filas).Cells(coDirecc.Index).Value = item.DIRECC
                        .Rows(Filas).Cells(colEstado.Index).Value = item.ESTADO
                    End With
                    Filas = Filas + 1
                Next
            End If
        End If

        btnModificar.Enabled = (DgCliente.RowCount) > 0
        lblTotreg.Text = (DgCliente.RowCount).ToString
        GetEntidad()
    End Sub
    Sub Nuevo()
        Dim Frm As New FrmTabCliPro
        Frm.ShowDialog()
        If Not IsNothing(Frm.form_datclipro) Then
            Frm.Close()
            Frm.Dispose()
        End If
    End Sub
    Sub Modificar()
        If DgCliente.CurrentRow Is Nothing Then Return
        Dim Frm As New FrmTabCliPro
        Dim Xcodigo As Long = 0
        If Long.TryParse(NothingToString(DgCliente.CurrentRow.Cells(colcodigo.Index).Value), Xcodigo) Then
            Xcodigo = Convert.ToInt64(DgCliente.CurrentRow.Cells(colcodigo.Index).Value)
        End If
        If Not IsNothing(Frm.Editar(Xcodigo)) Then
            Frm.ShowDialog()
            If Not IsNothing(Frm.form_datclipro) Then
                Frm.Close()
                Frm.Dispose()
            End If
        End If
    End Sub
    Sub GetEntidad()
        If DgCliente.CurrentRow Is Nothing Then Return
        Dim Xcodigo As Long = 0
        If Long.TryParse(NothingToString(DgCliente.CurrentRow.Cells(colcodigo.Index).Value), Xcodigo) Then
            Xcodigo = Convert.ToInt64(DgCliente.CurrentRow.Cells(colcodigo.Index).Value)
        End If
        If form_lstClipro.Where(Function(X) X.CIA = GCia And X.CODIGO = Xcodigo).Count > 0 Then
            form_datclipro = form_lstClipro.Where(Function(X) X.CIA = GCia And X.CODIGO = Xcodigo).First()
        Else
            form_datclipro = Nothing
        End If

    End Sub

#End Region
#Region "Eventos"
    Private Sub FrmConsultaCliPro_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown


        txtCriterio.Focus()
        txtCriterio.SelectionStart = 0
        txtCriterio.SelectionLength = Len(txtCriterio.Text.Trim)


    End Sub

    Private Sub txtCriterio_GotFocus(sender As Object, e As EventArgs) Handles txtCriterio.GotFocus

        txtCriterio.SelectionStart = 0
        txtCriterio.SelectionLength = Len(txtCriterio.Text.Trim)
    End Sub

    Private Sub txtCriterio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCriterio.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SendKeys.Send("{tab}")
        End If
        If e.KeyCode = Keys.Down Then
            DgCliente.Focus()
        End If
    End Sub
    Private Sub rbdDentroRazsoc_CheckedChanged(sender As Object, e As EventArgs) Handles rbdDentroRazsoc.CheckedChanged
        txtCriterio.Focus()
    End Sub
    Private Sub rbdInicioRazon_CheckedChanged(sender As Object, e As EventArgs) Handles rbdInicioRazon.CheckedChanged
        txtCriterio.Focus()
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub
    Private Sub DgCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles DgCliente.KeyDown

        If e.KeyCode = Keys.Enter Then

            If Not EsRapida Then
                Modificar()
            Else
                BsqExitosa = True
                Hide()
            End If
        End If
    End Sub
    Private Sub DgCliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgCliente.CellClick
        GetEntidad()
    End Sub
    Private Sub DgCliente_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgCliente.CellDoubleClick
        If Not EsRapida Then
            Modificar()
        Else
            BsqExitosa = True
            Hide()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnReniec_Click(sender As Object, e As EventArgs) Handles btnReniec.Click
        form_datclipro = ConsultaReniec(txtCriterio.Text.Trim)
        If Not IsNothing(form_datclipro) Then
            txtCriterio.Text = form_datclipro.NRODOC

        End If
    End Sub

    Private Sub btnSunat_Click(sender As Object, e As EventArgs) Handles btnSunat.Click
        form_datclipro = ConsultaRuc(txtCriterio.Text.Trim)
        If Not IsNothing(form_datclipro) Then
            txtCriterio.Text = form_datclipro.NRODOC

        End If
    End Sub





    Private Sub DgCliente_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DgCliente.RowEnter
        GetEntidad()
    End Sub









#End Region

End Class