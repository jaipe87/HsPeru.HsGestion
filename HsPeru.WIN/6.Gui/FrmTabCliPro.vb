Option Strict On
Public Class FrmTabCliPro
    Public lst_formCorreo As List(Of CLIPROCORREO)
    Public lst_formSucursal As New List(Of CLIPROSUCURSAL)
    Public form_datclipro As CLIPRO
    Public datTipdoc As TG_TIPDOC
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Inicia()
    End Sub
#Region "Métodos"

    Sub Inicia()
        CargarComboBox(oCombo.CargaGrupoCliente(), "COD", "DES", cboGrupoclie, SELECCIONAR)
        VerificaCombo(cboGrupoclie, 1)
        CargarComboBox(oCombo.CargaTipRegCliente(), "COD", "DES", cboTipRegistro, SELECCIONAR)
        VerificaCombo(cboTipRegistro, 2)
        CargarComboBox(oCombo.CargaTipdocCliente(), "COD", "DESABR", cboTipdoc, SELECCIONAR)
        VerificaCombo(cboTipdoc, CInt(sisEnum.TipDocClie.DNI))
        CargarComboBox(oCombo.CargaVendedor(), "COD", "DES", cboVendedor, SELECCIONAR)
        VerificaCombo(cboVendedor, 1)
        CargarComboBox(oCombo.CargaDepartamento(), "CODDEP", "NOMDEP", cboDepartamento, SELECCIONAR)
        VerificaCombo(cboDepartamento, "15")
        CargarComboBox(oCombo.CargaPais(), "COD", "DES", cboPais, SELECCIONAR)
        VerificaCombo(cboPais, CInt(sisEnum.Pais.PERU))
        cboSituacion.SelectedIndex = 0
        cboSituacion.Enabled = False
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
    Sub ConfigNroDoc()
        datTipdoc = New TG_TIPDOC
        datTipdoc = TryCast(cboTipdoc.SelectedItem, TG_TIPDOC)
        txtNrodoc.Clear()
        txtNrodoc.Enabled = True
        txtApeMat.Enabled = True
        txtNombre.Enabled = True
        If Not IsNothing(datTipdoc) Then
            If datTipdoc.COD = CInt(sisEnum.TipDocClie.RUC) Then
                txtNrodoc.MaxLength = 11
                Label6.Text = "Razón Social :"
                Label6.Location = New Point(14, 63)
                txtApeMat.Enabled = False
                txtNombre.Enabled = False

            Else
                Label6.Text = "Ape.Pat :"
                Label6.Location = New Point(39, 63)
                If datTipdoc.COD = CInt(sisEnum.TipDocClie.DNI) Then
                    txtNrodoc.MaxLength = 8
                Else
                    If datTipdoc.COD = CInt(sisEnum.TipDocClie.OTRO) Then
                        txtNrodoc.MaxLength = 0
                        txtNrodoc.Enabled = False
                        txtRazoc.Focus()
                    Else
                        txtNrodoc.MaxLength = 20
                    End If
                End If
            End If
        End If
        txtNrodoc.Focus()
    End Sub
    Sub SeleccionaSuc()
        Dim parSucursal As New CLIPROSUCURSAL
        If dgSucursales.CurrentRow Is Nothing Then Return
        Dim xCodsuc As Integer = 0
        If Integer.TryParse(NothingToString(dgSucursales.CurrentRow.Cells(codSuc.Index).Value), xCodsuc) Then
            xCodsuc = Convert.ToInt32(dgSucursales.CurrentRow.Cells(codSuc.Index).Value)
        End If
        If lst_formSucursal.Where(Function(x) x.CODSUC = xCodsuc).Count > 0 Then
            parSucursal = lst_formSucursal.Where(Function(x) x.CODSUC = xCodsuc).First()
            If Not IsNothing(parSucursal) Then
                lblDirecc.Text = parSucursal.DIRECC
                lbldep.Text = parSucursal.NOMDEP
                lblProvincia.Text = parSucursal.NOMPRO
                lbldistrito.Text = parSucursal.NOMDIS
                lblCuidad.Text = parSucursal.NOMCIU
                lblTelefono.Text = parSucursal.TELEFO
                lblCelular.Text = parSucursal.CELULAR
                lblContacto.Text = parSucursal.NOMCON
                lblVendedor.Text = parSucursal.VENDEDOR
            End If
        End If

    End Sub
    Sub AñadeSucursal()
        Dim Frm As New FrmAdicSucCliPro
        Dim Fila As Integer = 0
        Dim Xcodsuc As Integer = 0
        If lst_formSucursal.Count = 0 Then
            Xcodsuc = 1
        Else
            Xcodsuc = (lst_formSucursal.Max(Function(X) X.CODSUC) + 1)
        End If
        Frm.Nuevo(Xcodsuc)
        Frm.ShowDialog()

        If Not IsNothing(Frm.form_datCliproSucursal) Then
            If Frm.form_datCliproSucursal.CODSUC > 0 Then
                dgSucursales.Rows.Clear()
                lst_formSucursal.Add(Frm.form_datCliproSucursal)

                For Each item As CLIPROSUCURSAL In lst_formSucursal
                    dgSucursales.Rows.Add()
                    dgSucursales.Rows(Fila).Cells(codSuc.Index).Value = item.CODSUC
                    dgSucursales.Rows(Fila).Cells(colLocal.Index).Value = item.RAZSOC
                    dgSucursales.Rows(Fila).Cells(colDirecc.Index).Value = item.DIRECC
                    dgSucursales.Rows(Fila).Cells(colTelefono.Index).Value = item.TELEFO
                    dgSucursales.Rows(Fila).Cells(colCelular.Index).Value = item.CELULAR
                    Fila += 1
                Next
            End If

        End If
    End Sub
    Sub ModificaSucursal()
        If dgSucursales.CurrentRow Is Nothing Then MessageBox.Show("No ha seleccionado un registro a modificar", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        Dim Frm As New FrmAdicSucCliPro
        Dim Fila As Integer
        Dim parCliproSucursal As New CLIPROSUCURSAL
        Dim xCodsuc As Integer = 0
        If Integer.TryParse(NothingToString(dgSucursales.CurrentRow.Cells(codSuc.Index).Value), xCodsuc) Then
            xCodsuc = Convert.ToInt32(dgSucursales.CurrentRow.Cells(codSuc.Index).Value)
        End If
        parCliproSucursal = lst_formSucursal.Where(Function(x) x.CODSUC = xCodsuc).First()
        If Not IsNothing(parCliproSucursal) Then
            Frm.Cargasucursal(parCliproSucursal)
            Frm.ShowDialog()
            If Not IsNothing(Frm.form_datCliproSucursal) Then
                If Frm.form_datCliproSucursal.CODSUC > 0 Then
                    parCliproSucursal = New CLIPROSUCURSAL

                    parCliproSucursal = lst_formSucursal.Where(Function(x) x.CODSUC = Frm.form_datCliproSucursal.CODSUC).First()
                    lst_formSucursal.Remove(parCliproSucursal)
                    lst_formSucursal.Add(Frm.form_datCliproSucursal)
                    dgSucursales.Rows.Clear()

                    For Each item As CLIPROSUCURSAL In lst_formSucursal
                        dgSucursales.Rows.Add()
                        dgSucursales.Rows(Fila).Cells(codSuc.Index).Value = item.CODSUC
                        dgSucursales.Rows(Fila).Cells(colLocal.Index).Value = item.RAZSOC
                        dgSucursales.Rows(Fila).Cells(colDirecc.Index).Value = item.DIRECC
                        dgSucursales.Rows(Fila).Cells(colTelefono.Index).Value = item.TELEFO
                        dgSucursales.Rows(Fila).Cells(colCelular.Index).Value = item.CELULAR
                        Fila += 1
                    Next

                End If

            End If
        Else
            MessageBox.Show("No ha seleccionado registro alguno a modificar", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
    End Sub
    Sub EliminarSucursal()
        If dgSucursales.CurrentRow Is Nothing Then MessageBox.Show("No ha seleccionado un registro a eliminar", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        Dim parCliproSucursal As New CLIPROSUCURSAL
        Dim xCodsuc As Integer = 0
        If Integer.TryParse(NothingToString(dgSucursales.CurrentRow.Cells(codSuc.Index).Value), xCodsuc) Then
            xCodsuc = Convert.ToInt32(dgSucursales.CurrentRow.Cells(codSuc.Index).Value)
        End If
        If lst_formSucursal.Where(Function(x) x.CODSUC = xCodsuc).Count > 0 Then
            parCliproSucursal = lst_formSucursal.Where(Function(x) x.CODSUC = xCodsuc).First
            If Not IsNothing(parCliproSucursal) Then
                lst_formSucursal.Remove(parCliproSucursal)
                dgSucursales.AutoGenerateColumns = False
                dgSucursales.DataSource = Nothing
                dgSucursales.DataSource = lst_formSucursal
                lblDirecc.Text = ""
                lbldep.Text = ""
                lblProvincia.Text = ""
                lbldistrito.Text = ""
                lblCuidad.Text = ""
                lblTelefono.Text = ""
                lblCelular.Text = ""
                lblContacto.Text = ""
                lblVendedor.Text = ""
            Else
                MessageBox.Show("No ha seleccionado un registro a eliminar", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If

    End Sub
    Function Valida() As Boolean
        Dim R As Boolean = True

        If CInt(cboGrupoclie.SelectedValue) = 0 Then
            MessageBox.Show("Seleccione un Grupo de cliente", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return False
        End If

        If CInt(cboTipRegistro.SelectedValue) = 0 Then
            MessageBox.Show("Seleccione un Tipo de registro para el cliente", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If CInt(cboTipdoc.SelectedValue) = 0 Then
            MessageBox.Show("Seleccione un Tipo de Documento para el cliente", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If Not ValidaNrodoc(CInt(Val(lblCodigo.Text)), txtNrodoc.Text.Trim) Then
            MessageBox.Show("El Número de Documento de Identidad " & txtNrodoc.Text & " ya está registrado. Por favor de verifíquelo.", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNrodoc.Focus()
            Return False
        End If
        If CInt(cboTipdoc.SelectedValue) = CInt(sisEnum.TipDocClie.RUC) Then
            If txtNrodoc.Text.Trim.Length = 0 Or txtNrodoc.Text.Trim.Length <> 11 Then
                MessageBox.Show("Ingrese el Nro. de RUC Válido", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNrodoc.Focus()
                Return False
            End If
            If txtRazoc.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Razón Social del cliente", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRazoc.Focus()
                Return False
            End If

        Else
            If CInt(cboTipdoc.SelectedValue) = CInt(sisEnum.TipDocClie.DNI) Then
                If txtNrodoc.Text.Trim.Length = 0 Or txtNrodoc.Text.Trim.Length <> 8 Then
                    MessageBox.Show("Ingrese el Nro. de DNI Válido", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNrodoc.Focus()
                    Return False
                End If
            Else
                If txtNrodoc.Text.Trim.Length = 0 And CInt(cboTipdoc.SelectedValue) <> CInt(sisEnum.TipDocClie.OTRO) Then
                    MessageBox.Show("Ingrese el Nro. de " & cboTipdoc.Text & " Válido", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNrodoc.Focus()
                    Return False
                End If
            End If
            If txtRazoc.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el apet.paterno del cliente", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRazoc.Focus()
                Return False
            End If
            If txtApeMat.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el apet.materno del cliente", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtApeMat.Focus()
                Return False
            End If
            If txtNombre.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese los nombres del cliente", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNombre.Focus()
                Return False
            End If
        End If
        If cboDepartamento.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un Departamento", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboDepartamento.Focus()
            Return False
        End If
        If cboProvincia.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una Provincia", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboProvincia.Focus()
            Return False
        End If
        If cboDistrito.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un Distrito", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboDistrito.Focus()
            Return False
        End If

        If cboCiudad.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una ciudad", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboCiudad.Focus()
            Return False
        End If
        If CInt(cboPais.SelectedValue) = 0 Then
            MessageBox.Show("Seleccione un País", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboPais.Focus()
            Return False
        End If
        If CInt(cboVendedor.SelectedValue) = 0 Then
            MessageBox.Show("Seleccione un Vendedor", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboVendedor.Focus()
            Return False
        End If
        If lstCorreo.Items.Count = 0 Then
            MessageBox.Show("Ingrese un correo electrónico", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCorreo.Focus()
            Return False
        End If
        Return R
    End Function
    Sub Graba()
        Dim i As Integer = 0
        Dim xCodigo As Long = 0
        Dim xlinea As Double = 0.00
        Dim datcorreo As CLIPROCORREO
        Dim oClipro As New DAL_CLIPRO
        Dim parClipro As New CLIPRO
        If MessageBox.Show("¿Seguro de Grabar?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If Not Valida() Then Return
        parClipro = New CLIPRO
        With parClipro
            If Long.TryParse(lblCodigo.Text.Trim, xCodigo) Then
                .CODIGO = xCodigo
            Else
                .CODIGO = 0
            End If
            .NRODOC = txtNrodoc.Text.Trim
            .TIPREG = CInt(cboTipRegistro.SelectedValue)
            .CODGRU = CInt(cboGrupoclie.SelectedValue)
            .TIPDOC = CInt(cboTipdoc.SelectedValue)
            .NRODOC = txtNrodoc.Text.Trim
            .RAZSOC = txtRazoc.Text.Trim
            .APEMAT = txtApeMat.Text.Trim
            .NOMBRE = txtNombre.Text.Trim
            .TRAZSOC = .RAZSOC & " " & .APEMAT & " " & .NOMBRE
            .RAZCOM = txtRazComer.Text.Trim
            .DIRECC = txtDireccion.Text.Trim
            .TELEFO = txtTelefo.Text.Trim
            .CELULAR = txtCelular.Text.Trim
            If Double.TryParse(txtLinea.Text.Trim, xlinea) Then
                .LINEA = xlinea
            Else
                .LINEA = 0.00
            End If
            .CODVEN = CInt(cboVendedor.SelectedValue)
            .CODDEP = cboDepartamento.SelectedValue.ToString
            .CODPRO = cboProvincia.SelectedValue.ToString
            .CODDIS = cboDistrito.SelectedValue.ToString
            .CODCIU = cboCiudad.SelectedValue.ToString
            .CODPAI = CInt(cboPais.SelectedValue)
            .OTROS = txtObs.Text.Trim
            .SIT = cboSituacion.SelectedIndex
            lst_formCorreo = New List(Of CLIPROCORREO)
            For i = 0 To lstCorreo.Items.Count - 1
                datcorreo = New CLIPROCORREO
                datcorreo.CORREO = lstCorreo.Items.Item(i).ToString
                lst_formCorreo.Add(datcorreo)
            Next
            .LISTACORREO = lst_formCorreo
            .LISTASUCURSAL = lst_formSucursal
        End With

        form_datclipro = oClipro.Insert_clipro(parClipro)

        If Not IsNothing(form_datclipro) Then
            MessageBox.Show("Se registro el " & cboTipRegistro.Text & ", con Código " & form_datclipro.CODIGO, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Hide()
        Else
            MessageBox.Show("No se puedo registrar el cliente/Proveedor", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Function Editar(ByVal codigo As Long) As CLIPRO
        Dim oClipro As New DAL_CLIPRO
        Dim Fila As Integer = 0
        form_datclipro = oClipro.Select_Clipro_by_codigo(New CLIPRO With {.CODIGO = codigo})
        With form_datclipro
            lblCodigo.Text = .CODIGO.ToString
            cboTipdoc.SelectedValue = .TIPDOC
            txtNrodoc.Text = .NRODOC
            cboTipRegistro.SelectedValue = .TIPREG
            cboGrupoclie.SelectedValue = .CODGRU
            txtRazoc.Text = .RAZSOC
            txtApeMat.Text = .APEMAT
            txtNombre.Text = .NOMBRE
            txtRazComer.Text = .RAZCOM
            txtDireccion.Text = .DIRECC
            txtTelefo.Text = .TELEFO
            txtCelular.Text = .CELULAR
            cboVendedor.SelectedValue = .CODVEN
            txtLinea.Text = .LINEA.ToString("N2")
            cboDepartamento.SelectedValue = .CODDEP
            cboProvincia.SelectedValue = .CODPRO
            cboDistrito.SelectedValue = .CODDIS
            cboCiudad.SelectedValue = .CODCIU
            cboPais.SelectedValue = .CODPAI
            cboSituacion.SelectedValue = .SIT
            txtObs.Text = .OTROS
            For Each item As CLIPROCORREO In .LISTACORREO
                lstCorreo.Items.Add(item.CORREO)
            Next

            lst_formSucursal = .LISTASUCURSAL
            dgSucursales.Rows.Clear()

            For Each item As CLIPROSUCURSAL In lst_formSucursal
                dgSucursales.Rows.Add()
                dgSucursales.Rows(Fila).Cells(codSuc.Index).Value = item.CODSUC
                dgSucursales.Rows(Fila).Cells(colLocal.Index).Value = item.RAZSOC
                dgSucursales.Rows(Fila).Cells(colDirecc.Index).Value = item.DIRECC
                dgSucursales.Rows(Fila).Cells(colTelefono.Index).Value = item.TELEFO
                dgSucursales.Rows(Fila).Cells(colCelular.Index).Value = item.CELULAR
                Fila += 1
            Next


            cboSituacion.Enabled = True
        End With
        Return form_datclipro
    End Function
#End Region
#Region "Eventos"
    Private Sub FrmTabCliPro_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtNrodoc.Focus()
        VerificaCombo(cboProvincia, "01")
        VerificaCombo(cboDistrito, "01")
        VerificaCombo(cboCiudad, "0001")
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        form_datclipro = Nothing
        Close()
    End Sub
    Private Sub cboProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProvincia.SelectedIndexChanged
        CargaDistrito()
    End Sub
    Private Sub cboDistrito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDistrito.SelectedIndexChanged
        CargaCiudad()
    End Sub
    Private Sub cboDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartamento.SelectedIndexChanged
        CargaProvincia()
    End Sub
    Private Sub cboTipdoc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelefo.KeyDown, txtRazoc.KeyDown, txtRazComer.KeyDown, txtNrodoc.KeyDown, txtNombre.KeyDown, txtDireccion.KeyDown, txtCorreo.KeyDown, txtCelular.KeyDown, txtApeMat.KeyDown, cboVendedor.KeyDown, cboTipRegistro.KeyDown, cboTipdoc.KeyDown, cboProvincia.KeyDown, cboPais.KeyDown, cboGrupoclie.KeyDown, cboDistrito.KeyDown, cboDepartamento.KeyDown, cboCiudad.KeyDown, txtLinea.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not CMail(txtCorreo.Text.Trim) Then MessageBox.Show("Ingrese un formato correcto de E-Mail", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Return
        If txtCorreo.Text.Trim.Length = 0 Then Return
        lstCorreo.Items.Add(Me.txtCorreo.Text)
        txtCorreo.Clear()
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lstCorreo.SelectedIndex < 0 Then Return
        lstCorreo.Items.RemoveAt(lstCorreo.SelectedIndex)
        txtCorreo.Focus()
    End Sub
    Private Sub cboTipdoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipdoc.SelectedIndexChanged
        ConfigNroDoc()
    End Sub
    Private Sub btnaddSucursal_Click(sender As Object, e As EventArgs) Handles btnaddSucursal.Click
        AñadeSucursal()
    End Sub
    Private Sub btnModSucursal_Click(sender As Object, e As EventArgs) Handles btnModSucursal.Click
        ModificaSucursal()
    End Sub
    Private Sub btnDelSucursal_Click(sender As Object, e As EventArgs) Handles btnDelSucursal.Click
        EliminarSucursal()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
    End Sub

    Private Sub SelectAll_Click(sender As Object, e As EventArgs) Handles txtTelefo.Click, txtRazoc.Click, txtRazComer.Click, txtNrodoc.Click, txtNombre.Click, txtDireccion.Click, txtCorreo.Click, txtCelular.Click, txtApeMat.Click, txtLinea.Click
        TryCast(sender, TextBox).SelectAll()
    End Sub



    Private Sub dgSucursales_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgSucursales.CellEnter
        SeleccionaSuc()
    End Sub


#End Region


End Class