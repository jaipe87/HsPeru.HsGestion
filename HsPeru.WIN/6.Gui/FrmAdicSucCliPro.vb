Option Strict On
Public Class FrmAdicSucCliPro
    Public form_datCliproSucursal As CLIPROSUCURSAL
    Sub New()
        InitializeComponent()
        inicia()
    End Sub
#Region "Métodos"
    Sub inicia()
        CargarComboBox(oCombo.CargaVendedor(), "COD", "DES", cboTabven, SELECCIONAR)
        VerificaCombo(cboTabven, 1)
        CargarComboBox(oCombo.CargaDepartamento(), "CODDEP", "NOMDEP", cboDepartamento, SELECCIONAR)
        VerificaCombo(cboDepartamento, "15")
    End Sub
    Sub CargaProvincia()
        cboProvincia.DataSource = Nothing
        If cboDepartamento.SelectedValue IsNot Nothing Then CargarComboBox(oCombo.CargaProvincia(cboDepartamento.SelectedValue.ToString), "CODPRO", "NOMPRO", cboProvincia, SELECCIONAR)
    End Sub
    Sub CargaDistrito()
        cboDistrito.DataSource = Nothing
        If cboProvincia.SelectedValue IsNot Nothing Then CargarComboBox(oCombo.CargaDistrito(cboDepartamento.SelectedValue.ToString, cboProvincia.SelectedValue.ToString), "CODDIS", "NOMDIS", cboDistrito, SELECCIONAR)
    End Sub
    Sub CargaCiudad()
        cboCiudad.DataSource = Nothing
        If cboDistrito.SelectedValue IsNot Nothing Then CargarComboBox(oCombo.CargaCiudad(cboDepartamento.SelectedValue.ToString, cboProvincia.SelectedValue.ToString, cboDistrito.SelectedValue.ToString), "CODCIU", "NOMCIU", cboCiudad, SELECCIONAR)
    End Sub
    Sub Nuevo(ByVal cod As Integer)
        lblCodigo.Text = cod.ToString

    End Sub
    Sub Cargasucursal(ByVal oSucursal As CLIPROSUCURSAL)
        form_datCliproSucursal = New CLIPROSUCURSAL
        With oSucursal
            lblCodigo.Text = .CODSUC.ToString
            txtNomSucursal.Text = .RAZSOC
            txtDireccion.Text = .DIRECC
            cboDepartamento.SelectedValue = .CODDEP
            '  AddHandler cboDepartamento.SelectedIndexChanged, AddressOf cboDepartamento_SelectedIndexChanged
            cboProvincia.SelectedValue = .CODPRO
            cboDistrito.SelectedValue = .CODDIS
            cboCiudad.SelectedValue = .CODCIU
            txtTelefo.Text = .TELEFO
            txtCelular.Text = .CELULAR
            txtContacto.Text = .NOMCON
            cboTabven.SelectedValue = .CODVEN
        End With
    End Sub
    Sub Anadir()
        If txtNomSucursal.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el nombre de la sucursal", TITULO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Return
        End If
        If txtDireccion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la dirección de la sucursal", TITULO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Return
        End If
        If cboDepartamento.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un departamento", TITULO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Return
        End If
        If cboProvincia.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una Provincia", TITULO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Return
        End If
        If cboDistrito.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un Distrito", TITULO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Return
        End If
        If cboCiudad.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una ciudad/Caserio", TITULO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Return
        End If
        form_datCliproSucursal = New CLIPROSUCURSAL
        With form_datCliproSucursal
            .CIA = GCia
            .CODSUC = Convert.ToInt32(lblCodigo.Text)
            .RAZSOC = txtNomSucursal.Text.Trim
            .DIRECC = txtDireccion.Text.Trim
            .CODDEP = cboDepartamento.SelectedValue.ToString
            .NOMDEP = cboDepartamento.Text.Trim
            .CODPRO = cboProvincia.SelectedValue.ToString
            .NOMPRO = cboProvincia.Text.Trim
            .CODDIS = cboDistrito.SelectedValue.ToString
            .NOMDIS = cboDistrito.Text.Trim
            .CODCIU = cboCiudad.SelectedValue.ToString
            .NOMCIU = cboCiudad.Text.Trim
            .TELEFO = txtTelefo.Text.Trim
            .CELULAR = txtCelular.Text.Trim
            .NOMCON = txtContacto.Text.Trim
            .CODVEN = Convert.ToInt32(cboTabven.SelectedValue)
            .VENDEDOR = cboTabven.Text.Trim
        End With
        Hide()
    End Sub
#End Region
#Region "Eventos"
    Private Sub cboProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProvincia.SelectedIndexChanged
        CargaDistrito()
    End Sub
    Private Sub cboDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartamento.SelectedIndexChanged
        CargaProvincia()
    End Sub
    Private Sub cboDistrito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDistrito.SelectedIndexChanged
        CargaCiudad()
    End Sub
    Private Sub SaltaControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelefo.KeyDown, txtNomSucursal.KeyDown, txtDireccion.KeyDown, txtContacto.KeyDown, txtCelular.KeyDown, cboTabven.KeyDown, cboProvincia.KeyDown, cboDistrito.KeyDown, cboDepartamento.KeyDown, cboCiudad.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Hide()
    End Sub
    Private Sub btnAnadir_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click
        Anadir()
    End Sub

    Private Sub FrmAdicSucCliPro_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtNomSucursal.Focus()
        VerificaCombo(cboProvincia, "01")
        VerificaCombo(cboDistrito, "01")
        VerificaCombo(cboCiudad, "0001")
    End Sub
#End Region

End Class