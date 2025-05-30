﻿Public Class FrmTabSubCatArticulos
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
    Private Sub cboFiltroCat_Click(sender As Object, e As EventArgs) Handles cboFiltroCat.Click
        cboFiltroCat.SelectAll()
    End Sub

    Private Sub cboFiltroCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFiltroCat.SelectedIndexChanged
        Buscar()
    End Sub
    Private Sub DgvSubCat_SelectionChanged(sender As Object, e As EventArgs) Handles DgvSubCat.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvSubCat_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSubCat.CellDoubleClick
        Modificar()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try
            oSubCategoria = New DAL_TABSUBCAT
            Dim listaSubCategoria As List(Of SUBCATEGORIA) = oSubCategoria.Select_all_SubCategoria(New SUBCATEGORIA With {
            .DESCAT = If(cboFiltroCat.SelectedIndex = 0 OrElse cboFiltroCat.Text = "TODAS", "", cboFiltroCat.Text)
        })

            Dim columnas As New Dictionary(Of String, Func(Of SUBCATEGORIA, String)) From {
            {"COD", Function(m) m.COD.ToString()},
            {"DESCRIPCIÓN", Function(m) m.DESCRI},
            {"CATEGORIA", Function(m) m.DESCAT},
            {"ESTADO", Function(m) m.ESTADO}
        }
            Dim ruta As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\SubCategorias.xlsx"

            GeneraReporte.GenerarExcel(listaSubCategoria, ruta, "SubCategorias" & "(" & cboFiltroCat.Text & ")", columnas)

        Catch ex As Exception
            MessageBox.Show("Error al exportar Excel:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click
        oSubCategoria = New DAL_TABSUBCAT
        Dim listaSubCategoria As List(Of SUBCATEGORIA) = oSubCategoria.Select_all_SubCategoria(New SUBCATEGORIA With {
            .DESCAT = If(cboFiltroCat.SelectedIndex = 0 OrElse cboFiltroCat.Text = "TODAS", "", cboFiltroCat.Text)
        })

        If listaSubCategoria Is Nothing OrElse listaSubCategoria.Count = 0 Then
            MessageBox.Show("No hay datos para generar el PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Columnas
        Dim columnas As New Dictionary(Of String, Func(Of SUBCATEGORIA, String)) From {
        {"CODIGO", Function(m) m.COD.ToString()},
        {"DESCRIPCIÓN", Function(m) If(m.DESCRI Is Nothing, "", m.DESCRI.ToString())},
        {"CATEGORIA", Function(m) If(m.DESCAT Is Nothing, "", m.DESCAT.ToString())},
        {"ESTADO", Function(m) If(m.ESTADO Is Nothing, "", m.ESTADO.ToString())}
    }
        Dim ruta As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\SubCategorias.pdf"
        GeneraReporte.GenerarPDF(listaSubCategoria, ruta, "SubCategorias", columnas)
    End Sub
#End Region

#Region "Métodos"

    'Sub Buscar()

    '    oSubCategoria = New DAL_TABSUBCAT
    '    lstSubCategoria = oSubCategoria.Select_all_SubCategoria(New SUBCATEGORIA With {.DESCAT = cboFiltroCat.Text})
    '    DgvSubCat.AutoGenerateColumns = False
    '    DgvSubCat.DataSource = lstSubCategoria
    'End Sub

    Sub Buscar()
        oSubCategoria = New DAL_TABSUBCAT
        lstSubCategoria = oSubCategoria.Select_all_SubCategoria(New SUBCATEGORIA With {
            .DESCAT = If(cboFiltroCat.SelectedIndex = 0 OrElse cboFiltroCat.Text = "TODAS", "", cboFiltroCat.Text)
        })
        DgvSubCat.AutoGenerateColumns = False
        DgvSubCat.DataSource = lstSubCategoria
    End Sub

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
        Dim listaCategorias As List(Of CATEGORIA) = oCategoria.Select_all_Categoria(New CATEGORIA)
        CargarComboBox(listaCategorias, "COD", "DES", cboCategoria, SELECCIONAR)
        CargarComboBox(listaCategorias, "COD", "DES", cboFiltroCat, TODAS)
        cboFiltroCat.SelectedIndex = 0

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
        lblCodigo.Text = "?"
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

    Private Sub cboFiltroCat_KeyDown(sender As Object, e As KeyEventArgs) Handles cboFiltroCat.KeyDown
        If e.KeyCode = Keys.Down Then
            DgvSubCat.Focus()
        End If
    End Sub

    Private Sub DgvSubCat_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvSubCat.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabSubCatArticulos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cboFiltroCat.Focus()
        SeleccionarRow()
    End Sub

    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtDes.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre de la subcategoria", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If CType(cboCategoria.SelectedValue, Integer) = 0 Then MessageBox.Show("Seleccione una categoria para la subcategoria", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oSubCategoria = New DAL_TABSUBCAT
        datSubCategoria = New SUBCATEGORIA
        parSubCategoria = New SUBCATEGORIA

        With parSubCategoria
            .CIA = GCia
            .COD = CInt(Val(lblCodigo.Text))
            .DESCRI = txtDes.Text.Trim
            .CODGRU = CInt(cboCategoria.SelectedValue)
        End With
        datSubCategoria = oSubCategoria.Insert_SubCategoria(parSubCategoria)

        If Not IsNothing(datSubCategoria) Then
            MessageBox.Show("Registro existoso de la subcategoria con código " & datSubCategoria.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbSubCat.Tabs(0).Selected = True
            utbSubCat.Tabs(0).Enabled = True
            utbSubCat.Tabs(1).Enabled = False
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region
End Class