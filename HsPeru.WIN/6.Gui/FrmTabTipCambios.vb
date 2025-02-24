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

    End Sub

    Private Sub btnBloqCompras_Click(sender As Object, e As EventArgs) Handles btnBloqCompras.Click

    End Sub

    Private Sub btnBloqCobranzas_Click(sender As Object, e As EventArgs) Handles btnBloqCobranzas.Click

    End Sub

    Private Sub btnBloqVentas_Click(sender As Object, e As EventArgs) Handles btnBloqVentas.Click

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub
    Private Sub cboAnio_TextChanged(sender As Object, e As EventArgs) Handles cboAnio.TextChanged
        Buscar()
    End Sub


#End Region

#Region "Métodos"
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
            'FALTAAAA

            utbTipCam.Tabs(0).Enabled = False
            utbTipCam.Tabs(1).Selected = True
            utbTipCam.Tabs(1).Enabled = True
        End If

    End Sub
    'FALTA TODO LO DEMÁS

#End Region

End Class