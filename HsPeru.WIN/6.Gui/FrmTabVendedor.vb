Option Strict On
Public Class FrmTabVendedor
    Dim oVendedor As DAL_VENDEDOR, oSucursal As DAL_TABSUC
    Dim datVendedor As VENDEDOR, parVendedor As VENDEDOR
    Dim lstVendedor As New List(Of VENDEDOR)
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        utbVendedor.Tabs(0).Selected = True
        utbVendedor.Tabs(0).Enabled = True
        utbVendedor.Tabs(1).Enabled = False
        txtCriterio.Focus()
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub cboSucursal_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSucursal.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub cboSituacion_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSituacion.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub txtcontrasena_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcontrasena.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub txtRepcontrasenia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRepcontrasenia.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub
    Private Sub txtCriterio_Click(sender As Object, e As EventArgs) Handles txtCriterio.Click
        txtCriterio.SelectAll()
    End Sub
    Private Sub DgvVendedor_SelectionChanged(sender As Object, e As EventArgs) Handles DgvVendedor.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvVendedor_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvVendedor.CellDoubleClick
        Modificar()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
    End Sub
#End Region

#Region "Métodos"
    Sub SeleccionarRow()
        Dim xCodven As Integer = 0
        datVendedor = New VENDEDOR
        xCodven = NothingToInteger(DgvVendedor.CurrentRow.Cells(colcod.Index).Value)

        If lstVendedor.Where(Function(x) x.COD = xCodven).Count > 0 Then
            datVendedor = lstVendedor.Where(Function(x) x.COD = xCodven).First
        End If


    End Sub
    Sub Inicia()
        oSucursal = New DAL_TABSUC
        oVendedor = New DAL_VENDEDOR
        CargarComboBox(oSucursal.SeleccionaAll_Sucursal(), "COD", "DES", cboSucursal, SELECCIONAR)
        cboSituacion.SelectedIndex = 0
        txtCriterio.Focus()
        lstVendedor = oVendedor.Select_all_Vendedor(New VENDEDOR With {.DES = txtCriterio.Text})
        DgvVendedor.AutoGenerateColumns = False
        DgvVendedor.DataSource = lstVendedor
        utbVendedor.Tabs(0).Selected = True
        utbVendedor.Tabs(1).Enabled = False

    End Sub
    Sub Buscar()
        oVendedor = New DAL_VENDEDOR
        lstVendedor = oVendedor.Select_all_Vendedor(New VENDEDOR With {.DES = txtCriterio.Text})
        DgvVendedor.AutoGenerateColumns = False
        DgvVendedor.DataSource = lstVendedor
    End Sub
    Sub Nuevo()
        utbVendedor.Tabs(0).Enabled = False
        utbVendedor.Tabs(1).Selected = True
        utbVendedor.Tabs(1).Enabled = True
        lblCodigo.Text = "?"
        txtcontrasena.Text = ""
        txtRepcontrasenia.Text = ""
        txtCriterio.Text = ""
        txtNombre.Text = ""
        txtNombre.Focus()
        cboSituacion.SelectedIndex = 0
        cboSucursal.SelectedValue = 0
        chkSup.Checked = False
    End Sub
    Sub Modificar()

        If Not IsNothing(datVendedor) Then
            lblCodigo.Text = datVendedor.COD.ToString
            txtNombre.Text = datVendedor.DES
            cboSituacion.SelectedIndex = datVendedor.SIT
            cboSucursal.SelectedValue = datVendedor.CODSUC
            chkSup.Checked = If(datVendedor.STSUP = 1, True, False)
            utbVendedor.Tabs(0).Enabled = False
            utbVendedor.Tabs(1).Selected = True
            utbVendedor.Tabs(1).Enabled = True
        End If


    End Sub

    Private Sub txtCriterio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCriterio.KeyDown
        If e.KeyCode = Keys.Down Then
            DgvVendedor.Focus()
        End If
    End Sub

    Private Sub DgvVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabVendedor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCriterio.Focus()
        SeleccionarRow()
    End Sub

    Private Sub chkSup_CheckedChanged(sender As Object, e As EventArgs) Handles chkSup.CheckedChanged
        txtcontrasena.Enabled = chkSup.Checked
        txtRepcontrasenia.Enabled = chkSup.Checked
    End Sub



    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtNombre.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre del vendedor", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If CType(cboSucursal.SelectedValue, Integer) = 0 Then MessageBox.Show("Seleccione una sucursal para el vendedor", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If txtcontrasena.Text.Trim.Length > 0 And chkSup.Checked Then If Not txtcontrasena.Text.Trim.Equals(txtRepcontrasenia.Text.Trim) Then MessageBox.Show("Las contraseñas ingresadas no son iguales", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oVendedor = New DAL_VENDEDOR
        datVendedor = New VENDEDOR
        parVendedor = New VENDEDOR

        With parVendedor
            .CIA = GCia
            .COD = CInt(Val(lblCodigo.Text))
            .DES = txtNombre.Text.Trim
            .CODSUC = Convert.ToInt32(cboSucursal.SelectedValue)
            .SIT = cboSituacion.SelectedIndex
            .PWDVEN = txtcontrasena.Text.Trim
            .STSUP = If(chkSup.Checked, 1, 0)
        End With
        datVendedor = oVendedor.Insert_Vendedor(parVendedor)

        If Not IsNothing(datVendedor) Then
            MessageBox.Show("Registro existoso del vendedor con código " & datVendedor.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbVendedor.Tabs(0).Selected = True
            utbVendedor.Tabs(0).Enabled = True
            utbVendedor.Tabs(1).Enabled = False
            txtCriterio.Focus()
            Buscar()
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



#End Region


End Class
