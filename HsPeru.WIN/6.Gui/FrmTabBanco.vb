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

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub
#End Region

#Region "Métodos"
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
            rbdSoles.Checked = If(datBanco.TIPMON = 1, True, False)
            utbBanco.Tabs(0).Enabled = False
            utbBanco.Tabs(1).Selected = True
            utbBanco.Tabs(1).Enabled = True
        End If

    End Sub

#End Region
End Class