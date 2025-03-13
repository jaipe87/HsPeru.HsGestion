Option Strict On

Public Class FrmTabTarjetas
    Dim oTarjCredito As DAL_TARJCREDITO
    Dim datTarjCredito As TARJCREDITO, parTarjCredito As TARJCREDITO
    Dim lstTarjCredito As New List(Of TARJCREDITO)
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        utbTarjCredito.Tabs(0).Selected = True
        utbTarjCredito.Tabs(0).Enabled = True
        utbTarjCredito.Tabs(1).Enabled = False
        txtCriterio.Focus()
    End Sub

    Private Sub txtCriterio_Click(sender As Object, e As EventArgs) Handles txtCriterio.Click
        txtCriterio.SelectAll()
    End Sub
    Private Sub DgvTarjCredito_SelectionChanged(sender As Object, e As EventArgs) Handles DgvTarjCredito.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvTarjCredito_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTarjCredito.CellDoubleClick
        Modificar()
    End Sub
#End Region

#Region "Métodos"
    Sub SeleccionarRow()
        Dim xCodven As Integer = 0
        datTarjCredito = New TARJCREDITO
        xCodven = NothingToInteger(DgvTarjCredito.CurrentRow.Cells(colcod.Index).Value)

        If lstTarjCredito.Where(Function(x) x.COD = xCodven).Count > 0 Then
            datTarjCredito = lstTarjCredito.Where(Function(x) x.COD = xCodven).First
        End If


    End Sub
    Sub Inicia()
        oTarjCredito = New DAL_TARJCREDITO
        txtCriterio.Focus()
        lstTarjCredito = oTarjCredito.Select_all_TarjCredito(New TARJCREDITO With {.DES = txtCriterio.Text})
        DgvTarjCredito.AutoGenerateColumns = False
        DgvTarjCredito.DataSource = lstTarjCredito
        utbTarjCredito.Tabs(0).Selected = True
        utbTarjCredito.Tabs(1).Enabled = False
    End Sub

    Sub Buscar()
        oTarjCredito = New DAL_TARJCREDITO
        lstTarjCredito = oTarjCredito.Select_all_TarjCredito(New TARJCREDITO With {.DES = txtCriterio.Text})
        DgvTarjCredito.AutoGenerateColumns = False
        DgvTarjCredito.DataSource = lstTarjCredito
    End Sub

    Sub Nuevo()
        utbTarjCredito.Tabs(0).Enabled = False
        utbTarjCredito.Tabs(1).Selected = True
        utbTarjCredito.Tabs(1).Enabled = True
        lblCodigo.Text = "?"
        txtCriterio.Text = ""
        txtDes.Text = ""
        txtDes.Focus()
    End Sub

    Sub Modificar()

        If Not IsNothing(datTarjCredito) Then
            lblCodigo.Text = datTarjCredito.COD.ToString
            txtDes.Text = datTarjCredito.DES
            utbTarjCredito.Tabs(0).Enabled = False
            utbTarjCredito.Tabs(1).Selected = True
            utbTarjCredito.Tabs(1).Enabled = True
        End If

    End Sub

    Private Sub txtCriterio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCriterio.KeyDown
        If e.KeyCode = Keys.Down Then
            DgvTarjCredito.Focus()
        End If
    End Sub

    Private Sub DgvTarjCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTarjCredito.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabTarjetas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCriterio.Focus()
        SeleccionarRow()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtDes.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre de la tarjeta de crédito", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oTarjCredito = New DAL_TARJCREDITO
        datTarjCredito = New TARJCREDITO
        parTarjCredito = New TARJCREDITO

        With parTarjCredito
            .COD = CInt(Val(lblCodigo.Text))
            .DES = txtDes.Text.Trim

        End With
        datTarjCredito = oTarjCredito.Insert_TarjCredito(parTarjCredito)

        If Not IsNothing(datTarjCredito) Then
            MessageBox.Show("Registro existoso de la tarjeta de crédito con código " & datTarjCredito.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbTarjCredito.Tabs(0).Selected = True
            utbTarjCredito.Tabs(0).Enabled = True
            utbTarjCredito.Tabs(1).Enabled = False
            txtCriterio.Focus()
            Buscar()
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
#End Region
End Class