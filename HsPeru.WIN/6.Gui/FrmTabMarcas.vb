Public Class FrmTabMarcas
    Dim oMarca As DAL_MARCA
    Dim datMarca As MARCA, parMarca As MARCA
    Dim lstMarca As New List(Of MARCA)
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        utbMarca.Tabs(0).Selected = True
        utbMarca.Tabs(0).Enabled = True
        utbMarca.Tabs(1).Enabled = False
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click
        Dim reporte As New GeneraReporte()
        Dim datos As DataTable = oMarca.Select_all_Marca()
        Dim archivo As Byte() = reporte.ExportarPDF(datos)

        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment; filename=Reporte.pdf")
        Response.BinaryWrite(archivo)
        Response.End()
    End Sub

    Private Sub chkActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged
        If chkActivo.Checked Then
            chkInactivo.Checked = False
        End If
    End Sub

    Private Sub chkInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkInactivo.CheckedChanged
        If chkInactivo.Checked Then
            chkActivo.Checked = False
        End If
    End Sub
    Private Sub DgvMarca_SelectionChanged(sender As Object, e As EventArgs) Handles DgvMarca.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvMarca_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMarca.CellDoubleClick
        Modificar()
    End Sub
#End Region

#Region "Métodos"
    Sub SeleccionarRow()
        Dim xCod As Integer = 0
        datMarca = New MARCA
        xCod = NothingToInteger(DgvMarca.CurrentRow.Cells(colcod.Index).Value)

        If lstMarca.Where(Function(x) x.COD = xCod).Count > 0 Then
            datMarca = lstMarca.Where(Function(x) x.COD = xCod).First
        End If


    End Sub
    Sub Inicia()
        oMarca = New DAL_MARCA
        lstMarca = oMarca.Select_all_Marca(New MARCA)
        DgvMarca.AutoGenerateColumns = False
        DgvMarca.DataSource = lstMarca
        utbMarca.Tabs(0).Selected = True
        utbMarca.Tabs(1).Enabled = False
    End Sub

    Sub Nuevo()
        utbMarca.Tabs(0).Enabled = False
        utbMarca.Tabs(1).Selected = True
        utbMarca.Tabs(1).Enabled = True
        lblCodigo.Text = "?"
        txtDes.Text = ""
        txtDes.Focus()
        chkActivo.Checked = False
        chkInactivo.Checked = False
    End Sub

    Sub Modificar()

        If Not IsNothing(datMarca) Then
            lblCodigo.Text = datMarca.COD.ToString
            txtDes.Text = datMarca.DES
            chkActivo.Checked = (datMarca.ST = 0)
            chkInactivo.Checked = (datMarca.ST = 1)
            utbMarca.Tabs(0).Enabled = False
            utbMarca.Tabs(1).Selected = True
            utbMarca.Tabs(1).Enabled = True
        End If

    End Sub

    Private Sub DgvMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvMarca.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabMarca_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SeleccionarRow()
    End Sub

    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtDes.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre del vendedor", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oMarca = New DAL_MARCA
        datMarca = New MARCA
        parMarca = New MARCA

        With parMarca
            .CIA = GCia
            .COD = CInt(Val(lblCodigo.Text))
            .DES = txtDes.Text.Trim
            .ST = If(chkActivo.Checked, 0, 1)
        End With
        datMarca = oMarca.Insert_Marca(parMarca)

        If Not IsNothing(datMarca) Then
            MessageBox.Show("Registro existoso del vendedor con código " & datMarca.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbMarca.Tabs(0).Selected = True
            utbMarca.Tabs(0).Enabled = True
            utbMarca.Tabs(1).Enabled = False
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region
End Class