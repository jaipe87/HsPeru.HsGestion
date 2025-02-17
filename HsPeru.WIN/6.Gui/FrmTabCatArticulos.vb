Public Class FrmTabCatArticulos
    Dim oCategoria As DAL_TABCATART
    Dim datCategoria As CATEGORIA, parCategoria As CATEGORIA
    Dim lstCategoria As New List(Of CATEGORIA)
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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        utbCategoria.Tabs(0).Selected = True
        utbCategoria.Tabs(0).Enabled = True
        utbCategoria.Tabs(1).Enabled = False
    End Sub
    Private Sub txtCriterio_Click(sender As Object, e As EventArgs) Handles txtCriterio.Click
        txtCriterio.SelectAll()
    End Sub
    Private Sub txtCriterio_TextChanged(sender As Object, e As EventArgs) Handles txtCriterio.TextChanged
        Buscar()
    End Sub
    Private Sub DgvVendedor_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCatArt.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvVendedor_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCatArt.CellDoubleClick
        Modificar()
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

    Private Sub chkSi_CheckedChanged(sender As Object, e As EventArgs) Handles chkSi.CheckedChanged
        If chkSi.Checked Then chkNo.Checked = False
    End Sub

    Private Sub chkNo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNo.CheckedChanged
        If chkNo.Checked Then chkSi.Checked = False
    End Sub

#End Region

#Region "Métodos"
    Sub SeleccionarRow()
        Dim xCodven As Integer = 0
        datCategoria = New CATEGORIA
        xCodven = NothingToInteger(DgvCatArt.CurrentRow.Cells(colcod.Index).Value)

        If lstCategoria.Where(Function(x) x.COD = xCodven).Count > 0 Then
            datCategoria = lstCategoria.Where(Function(x) x.COD = xCodven).First
        End If
    End Sub

    Private Sub Inicia()
        oCategoria = New DAL_TABCATART
        txtCriterio.Focus()
        lstCategoria = oCategoria.Select_all_Categoria(New CATEGORIA With {.DES = txtCriterio.Text})
        DgvCatArt.AutoGenerateColumns = False
        DgvCatArt.DataSource = lstCategoria
        utbCategoria.Tabs(0).Selected = True
        utbCategoria.Tabs(1).Enabled = False
    End Sub

    Sub Buscar()
        oCategoria = New DAL_TABCATART
        lstCategoria = oCategoria.Select_all_Categoria(New CATEGORIA With {.DES = txtCriterio.Text})
        DgvCatArt.AutoGenerateColumns = False
        DgvCatArt.DataSource = lstCategoria
    End Sub

    Sub Nuevo()
        utbCategoria.Tabs(0).Enabled = False
        utbCategoria.Tabs(1).Selected = True
        utbCategoria.Tabs(1).Enabled = True
        lblCodigo.Text = "?"
        txtCriterio.Text = ""
        txtDes.Text = ""
        txtDes.Focus()
        chkSi.Checked = False
        chkNo.Checked = False
        chkActivo.Checked = False
        chkInactivo.Checked = False
    End Sub

    Sub Modificar()

        If Not IsNothing(datCategoria) Then
            lblCodigo.Text = datCategoria.COD.ToString
            txtDes.Text = datCategoria.DES
            chkSi.Checked = (datCategoria.STOCK = "S")
            chkNo.Checked = (datCategoria.STOCK = "N")
            chkActivo.Checked = (datCategoria.ST = 0)
            chkInactivo.Checked = (datCategoria.ST = 1)

            utbCategoria.Tabs(0).Enabled = False
            utbCategoria.Tabs(1).Selected = True
            utbCategoria.Tabs(1).Enabled = True
        End If

    End Sub

    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtDes.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre de la categoria", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oCategoria = New DAL_TABCATART
        datCategoria = New CATEGORIA
        parCategoria = New CATEGORIA

        With parCategoria
            .CIA = GCia
            .COD = CInt(Val(lblCodigo.Text))
            .DES = txtDes.Text.Trim
            .STOCK = If(chkSi.Checked, "S", "N")
            .ST = If(chkActivo.Checked, 0, 1)
        End With
        datCategoria = oCategoria.Insert_Categoria(parCategoria)

        If Not IsNothing(datCategoria) Then
            MessageBox.Show("Registro existoso del vendedor con código " & datCategoria.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbCategoria.Tabs(0).Selected = True
            utbCategoria.Tabs(0).Enabled = True
            utbCategoria.Tabs(1).Enabled = False
            txtCriterio.Focus()
            Buscar()
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub DgvVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCatArt.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabCatArticulos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCriterio.Focus()
        SeleccionarRow()
    End Sub


#End Region
End Class