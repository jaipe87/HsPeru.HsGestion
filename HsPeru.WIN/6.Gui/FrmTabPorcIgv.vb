Public Class FrmTabPorcIgv
    Dim oPorc As DAL_PORCIGV
    Dim datPorc As PORCIGV, parPorc As PORCIGV
    Dim lstPorc As New List(Of PORCIGV)
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
        utbPorcIgv.Tabs(0).Selected = True
        utbPorcIgv.Tabs(0).Enabled = True
        utbPorcIgv.Tabs(1).Enabled = False
    End Sub

    Private Sub DgvPorcIgv_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPorcIgv.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvPorcIgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPorcIgv.CellDoubleClick
        Modificar()
    End Sub
#End Region

#Region "Métodos"

    Sub SeleccionarRow()
        Dim xCod As Integer = 0
        datPorc = New PORCIGV
        xCod = NothingToInteger(DgvPorcIgv.CurrentRow.Cells(colid.Index).Value)
        If lstPorc.Where(Function(x) x.COD = xCod).Count > 0 Then
            datPorc = lstPorc.Where(Function(x) x.COD = xCod).First
        End If

    End Sub


    Sub Inicia()
        oPorc = New DAL_PORCIGV
        lstPorc = oPorc.Select_all_PorcIgv(New PORCIGV)

        DgvPorcIgv.AutoGenerateColumns = False
        DgvPorcIgv.DataSource = lstPorc
        utbPorcIgv.Tabs(0).Selected = True
        utbPorcIgv.Tabs(1).Enabled = False
    End Sub

    Sub Nuevo()
        utbPorcIgv.Tabs(0).Enabled = False
        utbPorcIgv.Tabs(1).Selected = True
        utbPorcIgv.Tabs(1).Enabled = True
        dtFecha.Value = Date.Today
        txtPorc.Text = ""
        txtPorc.Focus()
    End Sub

    Sub Modificar()
        If Not IsNothing(datPorc) Then
            dtFecha.Value = datPorc.VIGENCIA
            txtPorc.Text = datPorc.PORC.ToString()
            utbPorcIgv.Tabs(0).Enabled = False
            utbPorcIgv.Tabs(1).Selected = True
            utbPorcIgv.Tabs(1).Enabled = True
        End If
    End Sub

    Private Sub DgvPorcIgv_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPorcIgv.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabPorcIgv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SeleccionarRow()
    End Sub


    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtPorc.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el porcentaje", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oPorc = New DAL_PORCIGV
        datPorc = New PORCIGV
        parPorc = New PORCIGV

        With parPorc
            .VIGENCIA = dtFecha.Value.ToString("yyyy-MM-dd")
            .PORC = Convert.ToDouble(txtPorc.Text.Trim)
        End With
        datPorc = oPorc.Insert_PorcIgv(parPorc)

        If Not IsNothing(datPorc) Then
            MessageBox.Show("Registro existoso del vendedor con el porcentaje " & datPorc.PORC, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbPorcIgv.Tabs(0).Selected = True
            utbPorcIgv.Tabs(0).Enabled = True
            utbPorcIgv.Tabs(1).Enabled = False
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Sub Graba()
    '    If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
    '    If txtPorc.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el porcentaje", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

    '    oPorc = New DAL_PORCIGV
    '    datPorc = New PORCIGV
    '    parPorc = New PORCIGV

    '    With parPorc
    '        .VIGENCIA = dtFecha.Value.Date
    '        .PORC = Convert.ToDouble(txtPorc.Text.Trim)
    '    End With
    '    datPorc = oPorc.Insert_PorcIgv(parPorc)

    '    If Not IsNothing(datPorc) Then
    '        MessageBox.Show("Registro exitoso con el porcentaje " & datPorc.PORC, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        utbPorcIgv.Tabs(0).Selected = True
    '        utbPorcIgv.Tabs(0).Enabled = True
    '        utbPorcIgv.Tabs(1).Enabled = False
    '    Else
    '        MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    'End Sub

#End Region
End Class