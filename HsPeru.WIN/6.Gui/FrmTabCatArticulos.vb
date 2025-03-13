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

    Private Sub rbdSi_CheckedChanged(sender As Object, e As EventArgs) Handles rbdSi.CheckedChanged
        If rbdSi.Checked Then rbdNo.Checked = False
    End Sub

    Private Sub rbdNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbdNo.CheckedChanged
        If rbdNo.Checked Then rbdSi.Checked = False
    End Sub

    Private Sub rbdActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rbdActivo.CheckedChanged
        If rbdActivo.Checked Then rbdInactivo.Checked = False
    End Sub

    Private Sub rbdInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rbdInactivo.CheckedChanged
        If rbdInactivo.Checked Then rbdActivo.Checked = False
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
        rbdSi.Checked = False
        rbdNo.Checked = False
        rbdActivo.Checked = False
        rbdInactivo.Checked = False
    End Sub

    Sub Modificar()

        If Not IsNothing(datCategoria) Then
            lblCodigo.Text = datCategoria.COD.ToString
            txtDes.Text = datCategoria.DES
            rbdSi.Checked = (datCategoria.STOCK = "S")
            rbdNo.Checked = (datCategoria.STOCK = "N")
            rbdActivo.Checked = (datCategoria.ST = 0)
            rbdInactivo.Checked = (datCategoria.ST = 1)

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
            '.STOCK
            If rbdSi.Checked Then
                .STOCK = "S"
            ElseIf rbdNo.Checked Then
                .STOCK = "N"
            End If
            'ST
            If rbdActivo.Checked Then
                .ST = 0
            ElseIf rbdInactivo.Checked Then
                .ST = 1
            End If
        End With
        datCategoria = oCategoria.Insert_Categoria(parCategoria)

        If Not IsNothing(datCategoria) Then
            MessageBox.Show("Registro existoso de la categoria con código " & datCategoria.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
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