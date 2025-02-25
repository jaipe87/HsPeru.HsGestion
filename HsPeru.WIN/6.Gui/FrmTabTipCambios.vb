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

    End Sub

    Private Sub btnBloqCobranzas_Click(sender As Object, e As EventArgs) Handles btnBloqCobranzas.Click

    End Sub

    Private Sub btnBloqVentas_Click(sender As Object, e As EventArgs) Handles btnBloqVentas.Click

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

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
    'FALTA TODO LO DEMÁS
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