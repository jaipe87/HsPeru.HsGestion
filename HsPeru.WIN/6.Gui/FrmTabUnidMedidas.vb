Public Class FrmTabUnidMedidas
    Dim oUnidMedida As DAL_TABUNIDMEDIDA
    Dim datUnidMedida As UNIDAD, parUnidMedida As UNIDAD
    Dim lstUnidMedida As New List(Of UNIDAD)
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
        utbUnidMedida.Tabs(0).Selected = True
        utbUnidMedida.Tabs(0).Enabled = True
        utbUnidMedida.Tabs(1).Enabled = False
    End Sub
    Private Sub DgvUnidMedida_SelectionChanged(sender As Object, e As EventArgs) Handles DgvUnidMedida.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvUnidMedida_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvUnidMedida.CellDoubleClick
        Modificar()
    End Sub
    Private Sub txtAbrev_TextChanged(sender As Object, e As EventArgs) Handles txtAbrev.TextChanged
        If txtAbrev.Text.Length > 3 Then
            txtAbrev.Text = txtAbrev.Text.Substring(0, 3)
            txtAbrev.SelectionStart = txtAbrev.Text.Length
        End If
    End Sub


    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click
        oUnidMedida = New DAL_TABUNIDMEDIDA
        Dim listaUnidMedida As List(Of UNIDAD) = oUnidMedida.Select_all_UnidMedida(New UNIDAD)

        If listaUnidMedida Is Nothing OrElse listaUnidMedida.Count = 0 Then
            MessageBox.Show("No hay datos para generar el PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Columnas
        Dim columnas As New Dictionary(Of String, Func(Of UNIDAD, String)) From {
        {"CODIGO", Function(m) m.COD.ToString()},
        {"DESCRIPCIÓN", Function(m) If(m.DESCRI Is Nothing, "", m.DESCRI.ToString())},
        {"ABREVIACIÓN", Function(m) If(m.DESABR Is Nothing, "", m.DESABR.ToString())}
    }
        Dim ruta As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\UnidadMedida.pdf"
        GeneraReporte.GenerarPDF(listaUnidMedida, ruta, "Unidades de Medida", columnas)
    End Sub

#End Region


#Region "Métodos"

    Sub SeleccionarRow()
        Dim xCodunid As Integer = 0
        datUnidMedida = New UNIDAD
        xCodunid = NothingToInteger(DgvUnidMedida.CurrentRow.Cells(colcod.Index).Value)

        If lstUnidMedida.Where(Function(x) x.COD = xCodunid).Count > 0 Then
            datUnidMedida = lstUnidMedida.Where(Function(x) x.COD = xCodunid).First
        End If

    End Sub
    Sub Inicia()
        oUnidMedida = New DAL_TABUNIDMEDIDA
        lstUnidMedida = oUnidMedida.Select_all_UnidMedida(New UNIDAD)
        DgvUnidMedida.AutoGenerateColumns = False
        DgvUnidMedida.DataSource = lstUnidMedida
        utbUnidMedida.Tabs(0).Selected = True
        utbUnidMedida.Tabs(1).Enabled = False
    End Sub
    Sub Nuevo()
        utbUnidMedida.Tabs(0).Enabled = False
        utbUnidMedida.Tabs(1).Selected = True
        utbUnidMedida.Tabs(1).Enabled = True
        lblCodigo.Text = "?"
        txtDes.Text = ""
        txtDes.Focus()
        txtAbrev.Text = ""
    End Sub
    Sub Modificar()

        If Not IsNothing(datUnidMedida) Then
            lblCodigo.Text = datUnidMedida.COD.ToString
            txtDes.Text = datUnidMedida.DESCRI
            txtAbrev.Text = datUnidMedida.DESABR
            utbUnidMedida.Tabs(0).Enabled = False
            utbUnidMedida.Tabs(1).Selected = True
            utbUnidMedida.Tabs(1).Enabled = True
        End If

    End Sub

    Private Sub DgvUnidMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvUnidMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabUnidMedidas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SeleccionarRow()
    End Sub


    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtDes.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre de la unidad de médida", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If txtAbrev.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese la abreviatura de la unidad de médida", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oUnidMedida = New DAL_TABUNIDMEDIDA
        datUnidMedida = New UNIDAD
        parUnidMedida = New UNIDAD

        With parUnidMedida
            .COD = CInt(Val(lblCodigo.Text))
            .DESCRI = txtDes.Text.Trim
            .DESABR = txtAbrev.Text.Trim
        End With
        datUnidMedida = oUnidMedida.Insert_UnidMedida(parUnidMedida)

        If Not IsNothing(datUnidMedida) Then
            MessageBox.Show("Registro existoso de la unidad de médida con código " & datUnidMedida.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbUnidMedida.Tabs(0).Selected = True
            utbUnidMedida.Tabs(0).Enabled = True
            utbUnidMedida.Tabs(1).Enabled = False
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
#End Region

End Class