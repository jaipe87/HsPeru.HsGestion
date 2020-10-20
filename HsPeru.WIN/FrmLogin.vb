Option Strict On
Public Class FrmLogin
    Private datUsuario As New USUARIO, datcia As New CIA, datSucursal As New TABSUC
    Private LogExistoso As Boolean = False
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Inicia()
    End Sub
#Region "Eventos"
    Private Sub FrmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseConexion()
    End Sub
    Private Sub txtTipcam_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipcam.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub
    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            Ingresar()
        End If
    End Sub
    Private Sub txtTipcam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTipcam.KeyPress
        SoloNumerosDecimales(sender, e)
    End Sub
    Private Sub cboTabUsr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTabUsr.SelectedIndexChanged
        SetUsuario()
        If GCia > 0 Then SetCia()
    End Sub
    Private Sub cboTabCia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTabCia.SelectedIndexChanged
        SetCia()
    End Sub
    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        IniTipCambio()
    End Sub
    Private Sub dtpFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub
#End Region

#Region "Métodos"
    Sub Inicia()
        Dim oUsuario As New DAL_USUARIO, oCia As New DAL_CIA
        CargarComboBox(oUsuario.SeleccionaAll_Usuario(), "COD", "USUARIO", cboTabUsr, SELECCIONAR)
        SetUsuario()
        CargarComboBox(oCia.SelectAll_Cia(New CIA With {.CIA = GCia}), "CIA", "DES", cboTabCia, SELECCIONAR)
        If GCia > 0 Then SetCia()
        lblStatus.Text = String.Format("Copyright © {0} Hard System Perú S.A.C. - Versión 1.0.0.0", Year(DateTime.Now))
        dtpFecha.Value = Date.Today
        IniTipCambio()

    End Sub
    Sub SetCia()
        datcia = TryCast(cboTabCia.SelectedItem, CIA)
        If Not IsNothing(datcia) Then
            GCia = datcia.CIA
            GDesCia = datcia.DES
            GRuc = datcia.RUC
            SetSucursal()
        Else
            GCia = 0
            GDesCia = ""
            GRuc = ""
        End If
    End Sub
    Sub SetUsuario(ByVal Optional Inicia As Boolean = False)
        datUsuario = TryCast(cboTabUsr.SelectedItem, USUARIO)
        If Not IsNothing(datUsuario) Then
            GCodUsr = datUsuario.COD
            GUsuario = datUsuario.USUARIO
            GCodGru = datUsuario.CODGRU
            GcodVen = datUsuario.CODVEN
            GCia = datUsuario.CIAACT
            GCodSuc = datUsuario.SUCACT
        Else
            GCodSuc = 0
            GUsuario = ""
            GCodGru = 0
            GcodVen = 0
            GCia = 0
        End If
        If Not Inicia Then
            cboTabCia.SelectedValue = GCia
            cboTabCia.Enabled = (GCia = 0)
            SetSucursal()
        End If

    End Sub
    Sub SetSucursal()
        If GCodSuc > 0 Then
            Dim oSucursal As New DAL_TABSUC
            datSucursal = oSucursal.SeleccionaAll_Sucursal_by_cod(New TABSUC With {.CIA = GCia, .COD = GCodSuc})
            If Not IsNothing(datSucursal) Then
                GSucursal = datSucursal.DES
                GDesSuc = datSucursal.DESABR
                GDirSuc = datSucursal.DIRSUC
                GTelSuc = datSucursal.TELEFONO
                GCelSuc = datSucursal.CELULAR
                GFechaIni = datSucursal.FECINI
                lblSucursal.Text = GSucursal
            Else
                GSucursal = ""
                GDesSuc = ""
                GDirSuc = ""
                GTelSuc = ""
                GCelSuc = ""
            End If

        Else
            lblSucursal.Text = TODAS
        End If
    End Sub



    Sub IniTipCambio()
        Me.txtTipcam.Text = "0.00"
        GetTipCambio(dtpFecha.Value)
        If GTipcam = 0 Then
            GetTipCambio(dtpFecha.Value, 1)
            txtTipcam.Text = GTipcam.ToString("N2")
            txtTipcam.Enabled = True
        Else
            txtTipcam.Text = GTipcam.ToString("N2")
            txtTipcam.Enabled = False
        End If



    End Sub



    Private Function RegistraTipoCambio() As Boolean
        Dim parTipcam As TIPCAM, oTipcam As New DAL_TIPCAM
        parTipcam = New TIPCAM
        With parTipcam
            .FECHA = dtpFecha.Value
            .COMPRA = 0
            .VENTA = Convert.ToDouble(txtTipcam.Text)
            .PARALE = .VENTA
        End With

        RegistraTipoCambio = oTipcam.Insert_Tipcam(parTipcam)
    End Function
    Sub Ingresar()
        Dim oUsuario As New DAL_USUARIO(), datUsu As New USUARIO
        If CInt(cboTabUsr.SelectedValue) = 0 Then MessageBox.Show("Seleccione su Usuario", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If CInt(cboTabCia.SelectedValue) = 0 Then MessageBox.Show("Seleccione una Compañía", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If Val(Me.txtTipcam.Text) = 0 Then MessageBox.Show("Ingrese el tipo de Cambio !!", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        datUsu = oUsuario.Selecciona_Usuario_by_Pwd(New USUARIO With {.COD = CInt(cboTabUsr.SelectedValue), .PWD = txtPass.Text.Trim})
        If Not IsNothing(datUsu) Then

            RegistraTipoCambio()
            Dim Frm As New MdiPrincipal()
            Frm.Show()

            Hide()
        Else
            LogExistoso = False
            MessageBox.Show("La Contraseña ingresada es incorrecta", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPass.Focus()
            txtPass.SelectAll()

        End If

    End Sub
#End Region

End Class