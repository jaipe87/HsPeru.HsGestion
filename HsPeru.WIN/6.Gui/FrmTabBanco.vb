Option Strict On
Public Class FrmTabBanco
    Dim oBanco As DAL_TABBANCO
    Dim datBanco As TABBANCO, parBanco As TABBANCO
    Dim lstBanco As New List(Of TABBANCO)
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
        utbBanco.Tabs(0).Selected = True
        utbBanco.Tabs(0).Enabled = True
        utbBanco.Tabs(1).Enabled = False
    End Sub

    Private Sub rbdSoles_CheckedChanged(sender As Object, e As EventArgs) Handles rbdSoles.CheckedChanged
        If rbdSoles.Checked Then
            rbdDolares.Checked = False
        End If
    End Sub

    Private Sub rbdDolares_CheckedChanged(sender As Object, e As EventArgs) Handles rbdDolares.CheckedChanged
        If rbdDolares.Checked Then
            rbdSoles.Checked = False
        End If
    End Sub

    Private Sub DgvBanco_SelectionChanged(sender As Object, e As EventArgs) Handles DgvBanco.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvBanco_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvBanco.CellDoubleClick
        Modificar()
    End Sub
#End Region

#Region "Métodos"

    Sub SeleccionarRow()
        Dim xCod As Integer = 0
        datBanco = New TABBANCO
        xCod = NothingToInteger(DgvBanco.CurrentRow.Cells(colcod.Index).Value)

        If lstBanco.Where(Function(x) x.COD = xCod).Count > 0 Then
            datBanco = lstBanco.Where(Function(x) x.COD = xCod).First
        End If


    End Sub
    Sub Inicia()
        oBanco = New DAL_TABBANCO
        lstBanco = oBanco.Select_all_Banco(New TABBANCO)
        DgvBanco.AutoGenerateColumns = False
        DgvBanco.DataSource = lstBanco
        utbBanco.Tabs(0).Selected = True
        utbBanco.Tabs(1).Enabled = False
    End Sub

    Sub Nuevo()
        utbBanco.Tabs(0).Enabled = False
        utbBanco.Tabs(1).Selected = True
        utbBanco.Tabs(1).Enabled = True
        lblCodigo.Text = "?"
        txtDes.Text = ""
        txtDes.Focus()
        txtNroCta.Text = ""
        txtFuncio.Text = ""
        rbdSoles.Checked = False
        rbdDolares.Checked = False
    End Sub
    Sub Modificar()

        If Not IsNothing(datBanco) Then
            lblCodigo.Text = datBanco.COD.ToString
            txtDes.Text = datBanco.DES
            txtNroCta.Text = datBanco.NROCTA
            txtFuncio.Text = datBanco.FUNCIO
            rbdSoles.Checked = (datBanco.TIPMON = 1)
            rbdDolares.Checked = (datBanco.TIPMON = 2)
            utbBanco.Tabs(0).Enabled = False
            utbBanco.Tabs(1).Selected = True
            utbBanco.Tabs(1).Enabled = True
        End If

    End Sub

    Private Sub DgvBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvBanco.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabBanco_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SeleccionarRow()
    End Sub


    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtDes.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese la cuenta de banco", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If Not (rbdSoles.Checked Or rbdDolares.Checked) Then MessageBox.Show("Seleccione una tipo de moneda para su cuenta de banco", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oBanco = New DAL_TABBANCO
        datBanco = New TABBANCO
        parBanco = New TABBANCO

        With parBanco
            .CIA = GCia
            .COD = CInt(Val(lblCodigo.Text))
            .DES = txtDes.Text.Trim
            .NROCTA = txtNroCta.Text.Trim
            .FUNCIO = txtFuncio.Text.Trim
            .TIPMON = If(rbdSoles.Checked, 1, 2)
        End With
        datBanco = oBanco.Insert_Banco(parBanco)

        If Not IsNothing(datBanco) Then
            MessageBox.Show("Registro existoso de la cuenta de banco con código " & datBanco.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbBanco.Tabs(0).Selected = True
            utbBanco.Tabs(0).Enabled = True
            utbBanco.Tabs(1).Enabled = False
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
#End Region
End Class