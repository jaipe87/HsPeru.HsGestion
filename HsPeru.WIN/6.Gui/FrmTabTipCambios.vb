Public Class FrmTabTipCambios
    Dim oTipcam As DAL_TIPCAM
    Dim datTipcam As TIPCAM, parTipcam As TIPCAM
    Dim lstTipcam As New List(Of TIPCAM)
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Inicia()
    End Sub

#Region "Eventos"
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub btnBloqCompras_Click(sender As Object, e As EventArgs) Handles btnBloqCompras.Click
        SeleccionarRow()
        If datTipcam IsNot Nothing Then
            datTipcam.ST = If(datTipcam.ST = 0, 1, 0)
            ActualizarEstado("ST", datTipcam.ST)
        End If
    End Sub

    Private Sub btnBloqCobranzas_Click(sender As Object, e As EventArgs) Handles btnBloqCobranzas.Click
        SeleccionarRow()
        If datTipcam IsNot Nothing Then
            datTipcam.ST2 = If(datTipcam.ST2 = 0, 1, 0)
            ActualizarEstado("ST2", datTipcam.ST2)
        End If
    End Sub

    Private Sub btnBloqVentas_Click(sender As Object, e As EventArgs) Handles btnBloqVentas.Click
        SeleccionarRow()
        If datTipcam IsNot Nothing Then
            datTipcam.ST3 = If(datTipcam.ST3 = 0, 1, 0)
            ActualizarEstado("ST3", datTipcam.ST3)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        utbTipCam.Tabs(0).Selected = True
        utbTipCam.Tabs(0).Enabled = True
        utbTipCam.Tabs(1).Enabled = False
    End Sub
    Private Sub cboAnio_TextChanged(sender As Object, e As EventArgs) Handles cboAnio.TextChanged
        Buscar()
    End Sub

    Private Sub DgvTipCam_SelectionChanged(sender As Object, e As EventArgs) Handles DgvTipCam.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvTipCam_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipCam.CellDoubleClick
        Modificar()
    End Sub

    Private Sub cboAnio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboAnio.KeyPress
        e.Handled = True ' Bloquea cualquier entrada de teclado
    End Sub
#End Region

#Region "Métodos"
    Sub SeleccionarRow()
        Dim xCod As Integer = 0
        datTipcam = New TIPCAM
        xCod = NothingToInteger(DgvTipCam.CurrentRow.Cells(colcod.Index).Value)
        If lstTipcam.Where(Function(x) x.COD = xCod).Count > 0 Then
            datTipcam = lstTipcam.Where(Function(x) x.COD = xCod).First
        End If
    End Sub

    Sub Buscar()
        oTipcam = New DAL_TIPCAM
        lstTipcam = oTipcam.Select_all_Tipcam(New TIPCAM With {.FECHA = New Date(Convert.ToInt32(cboAnio.SelectedItem), 1, 1)})
        DgvTipCam.AutoGenerateColumns = False
        DgvTipCam.DataSource = lstTipcam
    End Sub

    Sub Inicia()
        oTipcam = New DAL_TIPCAM
        cboAnio.DataSource = oCombo.CargaAnios()
        cboAnio.SelectedItem = DateTime.Now.Year.ToString()
        lstTipcam = oTipcam.Select_all_Tipcam(New TIPCAM With {.FECHA = New Date(Convert.ToInt32(cboAnio.Text), 1, 1)})
        DgvTipCam.AutoGenerateColumns = False
        DgvTipCam.DataSource = lstTipcam
        utbTipCam.Tabs(0).Selected = True
        utbTipCam.Tabs(1).Enabled = False
    End Sub

    Sub Nuevo()
        utbTipCam.Tabs(0).Enabled = False
        utbTipCam.Tabs(1).Selected = True
        utbTipCam.Tabs(1).Enabled = True
        cboAnio.SelectedItem = DateTime.Now.ToString()
        txtCompra.Text = ""
        txtVenta.Text = 3.5
        txtParalelo.Text = 3.5
        txtCompra.Focus()
    End Sub

    Sub Modificar()

        If Not IsNothing(datTipcam) Then
            txtCompra.Text = datTipcam.COMPRA
            txtVenta.Text = datTipcam.VENTA
            txtParalelo.Text = datTipcam.PARALE
            dtFecha.Value = datTipcam.FECHA

            utbTipCam.Tabs(0).Enabled = False
            utbTipCam.Tabs(1).Selected = True
            utbTipCam.Tabs(1).Enabled = True
        End If

    End Sub

    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtCompra.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre del vendedor", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oTipcam = New DAL_TIPCAM
        datTipcam = New TIPCAM
        parTipcam = New TIPCAM

        With parTipcam
            .CIA = GCia
            '.COD = CInt(Val(lblCodigo.Text))
            .FECHA = dtFecha.Value.ToString("yyyy-MM-dd")
            .COMPRA = txtCompra.Text.Trim
            .VENTA = txtVenta.Text.Trim
            .PARALE = txtParalelo.Text.Trim
        End With
        datTipcam = oTipcam.Insert_TipCambio(parTipcam)

        If Not IsNothing(datTipcam) Then
            MessageBox.Show("Registro existoso del vendedor con código " & datTipcam.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbTipCam.Tabs(0).Selected = True
            utbTipCam.Tabs(0).Enabled = True
            utbTipCam.Tabs(1).Enabled = False
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub ActualizarEstado(ByVal campo As String, ByVal nuevoEstado As Integer)
        oTipcam = New DAL_TIPCAM
        parTipcam = New TIPCAM

        With parTipcam
            .CIA = datTipcam.CIA
            .FECHA = datTipcam.FECHA
        End With

        Dim actualizado As Boolean = oTipcam.Update_TipCambio(parTipcam, campo, nuevoEstado)

        If actualizado Then
            MessageBox.Show("Estado actualizado correctamente.", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No se pudo actualizar el estado.", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    'Sub GrabaBloqCobranza(st2Value As Integer)
    '    If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

    '    oTipcam = New DAL_TIPCAM
    '    parTipcam = New TIPCAM

    '    With parTipcam
    '        .CIA = GCia
    '        '.COD = codigo
    '        .ST2 = st2Value
    '    End With

    '    oTipcam.Insert_BloqCobranzas_TipCambio(parTipcam)

    '    If Not IsNothing(datTipcam) Then
    '        MessageBox.Show("Registro actualizado exitosamente.", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    Else
    '        MessageBox.Show("No se pudo completar la actualización.", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    'End Sub

    'Private Sub GuardaBloqCobranzas()
    '    If DgvTipCam.CurrentRow Is Nothing Then Exit Sub

    '    Dim nuevoEstado As Integer = 1 - NothingToInteger(DgvTipCam.CurrentRow.Cells("colCobranza").Value)

    '    If MessageBox.Show(If(nuevoEstado = 1, "¿Desea bloquear cobranzas?", "¿Desea desbloquear cobranzas?"),
    '                   "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

    '    Dim objTipcam As New TIPCAM With {.CIA = GCia, .ST2 = nuevoEstado}

    '    If New DAL_TIPCAM().Insert_BloqCobranzas_TipCambio(objTipcam) IsNot Nothing Then Buscar()
    'End Sub


    Private Sub DgvTipCam_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipCam.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub


    Private Sub FrmTabTipCambios_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SeleccionarRow()
    End Sub

#End Region

End Class