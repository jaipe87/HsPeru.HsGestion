Public Class FrmTabSubCatArticulos
    Dim oSubCategoria As DAL_TABSUBCAT, oCategoria As DAL_TABCATART
    Dim datSubCategoria As SUBCATEGORIA, parSubCategoria As SUBCATEGORIA
    Dim lstSubCategoria As New List(Of SUBCATEGORIA)
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
        utbSubCat.Tabs(0).Selected = True
        utbSubCat.Tabs(0).Enabled = True
        utbSubCat.Tabs(1).Enabled = False
    End Sub

    Private Sub cboCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles cboCategoria.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub
    Private Sub DgvSubCat_SelectionChanged(sender As Object, e As EventArgs) Handles DgvSubCat.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvSubCat_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSubCat.CellDoubleClick
        Modificar()
    End Sub
#End Region

#Region "Métodos"
    Sub SeleccionarRow()
        Dim xCodven As Integer = 0
        datSubCategoria = New SUBCATEGORIA
        xCodven = NothingToInteger(DgvSubCat.CurrentRow.Cells(colcod.Index).Value)

        If lstSubCategoria.Where(Function(x) x.COD = xCodven).Count > 0 Then
            datSubCategoria = lstSubCategoria.Where(Function(x) x.COD = xCodven).First
        End If
    End Sub

    Sub Inicia()
        oCategoria = New DAL_TABCATART
        oSubCategoria = New DAL_TABSUBCAT
        CargarComboBox(oCategoria.Select_all_Categoria(New CATEGORIA With {.DES = "", .ST = 1}), "COD", "DES", cboCategoria, SELECCIONAR)
        lstSubCategoria = oSubCategoria.Select_all_SubCategoria(New SUBCATEGORIA)
        DgvSubCat.AutoGenerateColumns = False
        DgvSubCat.DataSource = lstSubCategoria
        utbSubCat.Tabs(0).Selected = True
        utbSubCat.Tabs(1).Enabled = False
    End Sub

    Sub Nuevo()
        utbSubCat.Tabs(0).Enabled = False
        utbSubCat.Tabs(1).Selected = True
        utbSubCat.Tabs(1).Enabled = True
        txtDes.Text = ""
        txtDes.Focus()
        cboCategoria.SelectedValue = 0
    End Sub
    Sub Modificar()

        If Not IsNothing(datSubCategoria) Then
            lblCodigo.Text = datSubCategoria.COD.ToString
            txtDes.Text = datSubCategoria.DESCRI
            cboCategoria.SelectedValue = datSubCategoria.CODGRU
            utbSubCat.Tabs(0).Enabled = False
            utbSubCat.Tabs(1).Selected = True
            utbSubCat.Tabs(1).Enabled = True
        End If

    End Sub

    Private Sub DgvSubCat_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvSubCat.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabSubCatArticulos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SeleccionarRow()
    End Sub

    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtDes.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre de la subcategoria", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        'If CType(cboCategoria.SelectedValue, Integer) = 0 Then MessageBox.Show("Seleccione una categoria para la subcategoria", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oSubCategoria = New DAL_TABSUBCAT
        datSubCategoria = New SUBCATEGORIA
        parSubCategoria = New SUBCATEGORIA

        With parSubCategoria
            .CIA = GCia
            .COD = CInt(Val(lblCodigo.Text))
            .DESCRI = txtDes.Text.Trim
            .CODGRU = Convert.ToInt32(cboCategoria.SelectedValue)
        End With
        datSubCategoria = oSubCategoria.Insert_SubCategoria(parSubCategoria)

        If Not IsNothing(datSubCategoria) Then
            MessageBox.Show("Registro existoso del vendedor con código " & datSubCategoria.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbSubCat.Tabs(0).Selected = True
            utbSubCat.Tabs(0).Enabled = True
            utbSubCat.Tabs(1).Enabled = False
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region
End Class