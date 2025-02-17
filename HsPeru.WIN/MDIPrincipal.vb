Option Strict On
Public Class MdiPrincipal
    Dim oFrmLogin As FrmLogin

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Inicia()
    End Sub
    Sub Inicia()
        tsDescia.Text = GDesCia
        tsFecha.Text = Date.Today.ToString("dd/MM/yyyy")
        tsHora.Text = Date.Today.TimeOfDay.ToString()
        tsUsuario.Text = GUsuario
        tsLocal.Text = GDesSuc
        tsTipcam.Text = GTipcam.ToString("N2")
        TmTime.Start()
        CargaLogo(Me)
    End Sub
    Private Sub M201_Click(sender As Object, e As EventArgs) Handles M201.Click
        Dim frmIngr As FrmManteIngreso = New FrmManteIngreso
        frmIngr.MdiParent = Me
        frmIngr.Show()
    End Sub

    Private Sub M202_Click(sender As Object, e As EventArgs) Handles M202.Click
        Dim frmDoc As FrmManteFactura = New FrmManteFactura
        frmDoc.MdiParent = Me
        frmDoc.Show()
    End Sub

    Private Sub M203_Click(sender As Object, e As EventArgs) Handles M203.Click
        Dim frmProf As FrmManteProforma = New FrmManteProforma
        frmProf.MdiParent = Me
        frmProf.Show()
    End Sub

    Private Sub M20401_Click(sender As Object, e As EventArgs) Handles M20401.Click
        Dim frmNCDev As FrmManteNCDev = New FrmManteNCDev
        frmNCDev.MdiParent = Me
        frmNCDev.Show()
    End Sub

    Private Sub M20402_Click(sender As Object, e As EventArgs) Handles M20402.Click
        Dim frmNCDes As FrmManteNCDes = New FrmManteNCDes
        frmNCDes.MdiParent = Me
        frmNCDes.Show()
    End Sub

    Private Sub M205_Click(sender As Object, e As EventArgs) Handles M205.Click
        Dim frmND As FrmManteND = New FrmManteND
        frmND.MdiParent = Me
        frmND.Show()
    End Sub

    Private Sub M206_Click(sender As Object, e As EventArgs) Handles M206.Click
        Dim frmRemision As FrmManteGuiaRemision = New FrmManteGuiaRemision
        frmRemision.MdiParent = Me
        frmRemision.Show()
    End Sub

    Private Sub M207_Click(sender As Object, e As EventArgs) Handles M207.Click
        Dim frmEnsamble As FrmManteOrdenEnsamble = New FrmManteOrdenEnsamble
        frmEnsamble.MdiParent = Me
        frmEnsamble.Show()
    End Sub

    Private Sub M208_Click(sender As Object, e As EventArgs) Handles M208.Click
        Dim frmCerrarMes As FrmManteCerrarMes = New FrmManteCerrarMes
        frmCerrarMes.MdiParent = Me
        frmCerrarMes.Show()
    End Sub

    Private Sub M103_Click(sender As Object, e As EventArgs) Handles M103.Click
        Dim frmTabVen As FrmTabVendedor = New FrmTabVendedor
        frmTabVen.MdiParent = Me
        frmTabVen.Show()
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Desea Salir del sistema de Gestión?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CloseConexion()
            End
        End If
    End Sub
    Private Sub MdiPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("¿Desea Salir del sistema de Gestión?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CloseConexion()
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub TmTime_Tick(sender As Object, e As EventArgs) Handles TmTime.Tick
        tsHora.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub M101_Click(sender As Object, e As EventArgs) Handles M101.Click
        Dim FrmTabcli As FrmConsultaCliPro = New FrmConsultaCliPro
        FrmTabcli.MdiParent = Me
        FrmTabcli.Show()
    End Sub

    Private Sub M104_Click(sender As Object, e As EventArgs) Handles M104.Click
        Dim FrmTabart As FrmTabArticulos = New FrmTabArticulos
        FrmTabart.MdiParent = Me
        FrmTabart.Show()
    End Sub

    Private Sub M105_Click(sender As Object, e As EventArgs) Handles M105.Click
        Dim FrmTabMar As FrmTabMarcas = New FrmTabMarcas
        FrmTabMar.MdiParent = Me
        FrmTabMar.Show()
    End Sub
End Class