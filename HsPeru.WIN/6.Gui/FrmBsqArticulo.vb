Option Strict On
Public Class FrmBsqArticulo

    Public form_lstArticulo As New List(Of TABART)
    Public form_lstdetarticulo As List(Of TABART_SUCURSAL)
    Public form_lstdetSucursales As List(Of TABART_UBICACION)
    Public form_datArticulo As TABART
    Private oArticulo As DAL_TABART
    Public bsqExistosa As Boolean = False
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Inicia()
    End Sub
#Region "Método"

    Sub Buscar()
        Dim Fila As Integer = 0
        oArticulo = New DAL_TABART
        form_lstArticulo = oArticulo.SelectAll_Articulo(New TABART_SUCURSAL With {.DESCRI = txtCriterio.Text.Trim, .CODSUC = CInt(cboSuc.SelectedValue), .SIT = ESTADO_ACTIVO}, False, Today.ToString("yyyy-MM-dd"), Today.ToString("yyyy-MM-dd"))

        DgArticulos.Rows.Clear()

        If Not IsNothing(form_lstArticulo) Then
            If form_lstArticulo.Count > 0 Then
                For Each item As TABART In form_lstArticulo
                    With DgArticulos
                        .Rows.Add()
                        .Rows(Fila).Cells(colcodart.Index).Value = item.CODART
                        .Rows(Fila).Cells(colcodfab.Index).Value = item.CODFAB
                        .Rows(Fila).Cells(colDescri.Index).Value = item.DESCRI
                        .Rows(Fila).Cells(colCategoria.Index).Value = item.DESCAT
                        .Rows(Fila).Cells(colsubcategoria.Index).Value = item.DESSUBCAT
                        .Rows(Fila).Cells(colMarca.Index).Value = item.DESMAR

                    End With
                    Fila = Fila + 1
                Next
            End If
        End If

        DetalleArticulo()

        lblReg.Text = DgArticulos.Rows.Count.ToString




    End Sub

    Sub Inicia()

        GTipcam = GetTipCambio(Date.Today)
        lblTipcam.Text = GTipcam.ToString("N2")
        CargarComboBox(oCombo.CargaSucursal, "COD", "DES", cboSuc, TODAS)
        VerificaCombo(cboSuc, GCodSuc)
        cboSuc.Enabled = GCodSuc = 0

    End Sub
    Sub DetalleArticulo()
        If DgArticulos.CurrentRow IsNot Nothing Then
            Dim Fila As Integer = 0
            Dim codart As String
            form_datArticulo = New TABART
            oArticulo = New DAL_TABART
            form_lstdetarticulo = New List(Of TABART_SUCURSAL)

            codart = NothingToString(DgArticulos.CurrentRow.Cells(colcodart.Index).Value)

            form_datArticulo = oArticulo.Select_tabart_by_cod(New TABART With {.CODART = codart})


            dgDetallePrecios.Rows.Clear()

            If Not IsNothing(form_datArticulo) Then
                form_lstdetarticulo = oArticulo.SelectAll_tabart_precios(form_datArticulo)
                If form_lstdetarticulo IsNot Nothing Then
                    Dim ListaMaestra = (From R In form_lstdetarticulo Group R By R.CIA, R.CODLIN, R.CODSUC, R.DESSUC Into Group).ToList()

                    For Each item In ListaMaestra
                        dgDetallePrecios.Rows.Add()
                        dgDetallePrecios.Rows(Fila).Cells(colDessuc.Index).Value = item.CODSUC & ".-" & item.DESSUC.ToString
                        For Each i In item.Group

                            dgDetallePrecios.Rows(Fila).Cells(colDes_uni.Index).Value = i.DESUNI

                            If form_datArticulo.TIPMON = MON_SOLES Then
                                dgDetallePrecios.Rows(Fila).Cells(colprecio_publi.Index).Value = i.PRECIO_PUBLI.ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(colpublicod.Index).Value = (i.PRECIO_PUBLI / GTipcam).ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(colprec_distri.Index).Value = i.PRECIO_DISTRI.ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(coldistrid.Index).Value = (i.PRECIO_DISTRI / GTipcam).ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(colprecio_min.Index).Value = i.PRECIO_MIN.ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(colpmind.Index).Value = (i.PRECIO_MIN / GTipcam).ToString("N2")
                            Else
                                dgDetallePrecios.Rows(Fila).Cells(colpublicod.Index).Value = i.PRECIO_PUBLI.ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(colprecio_publi.Index).Value = (i.PRECIO_PUBLI * GTipcam).ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(colprec_distri.Index).Value = (i.PRECIO_DISTRI * GTipcam).ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(coldistrid.Index).Value = i.PRECIO_DISTRI.ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(colpmind.Index).Value = i.PRECIO_MIN.ToString("N2")
                                dgDetallePrecios.Rows(Fila).Cells(colprecio_min.Index).Value = (i.PRECIO_MIN * GTipcam).ToString("N2")
                            End If


                            dgDetallePrecios.Rows(Fila).Cells(colEquivalente.Index).Value = i.EQUIVA.ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colSaldo.Index).Value = i.SALDO.ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colEsMin.Index).Value = i.ESMIN
                            Fila += 1
                            dgDetallePrecios.Rows.Add()
                        Next

                    Next
                    For Each item As DataGridViewRow In dgDetallePrecios.Rows
                        item.Visible = NothingToString(item.Cells(colDes_uni.Index).Value) <> "" And NothingToString(item.Cells(colprecio_publi.Index).Value) <> ""
                    Next
                End If
            End If
        End If
    End Sub

    Sub ConsultaRapida(criterio As String, codsuc As Integer)
        txtCriterio.Text = criterio
        VerificaCombo(cboSuc, codsuc)
        cboSuc.Enabled = codsuc = 0
        bsqExistosa = False
        Buscar()
    End Sub
    Sub GetEntidad()
        If DgArticulos.CurrentRow Is Nothing Then Return
        Dim Xcodigo As String = ""

        Xcodigo = NothingToString(DgArticulos.CurrentRow.Cells(colcodart.Index).Value.ToString)

        If form_lstArticulo.Where(Function(X) X.CIA = GCia And X.CODART = Xcodigo).Count > 0 Then
            form_datArticulo = form_lstArticulo.Where(Function(X) X.CIA = GCia And X.CODART = Xcodigo).First()
        Else
            form_datArticulo = Nothing
        End If

        Hide()
    End Sub
#End Region
#Region "Evento"
    Private Sub dgDetallePrecios_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgDetallePrecios.CellFormatting
        Dim col As String

        If (dgDetallePrecios.Columns(e.ColumnIndex).Name = colEsMin.Name) Then
            col = NothingToString(dgDetallePrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
            Select Case col
                Case "SI"
                    For Each item As DataGridViewCell In dgDetallePrecios.Rows(e.RowIndex).Cells
                        item.Style.BackColor = Color.FromKnownColor(KnownColor.SeaShell)
                    Next
            End Select

        End If


    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub


    Private Sub DgArticulos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DgArticulos.CellEnter
        DetalleArticulo()
    End Sub
    Private Sub txtCriterio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCriterio.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmBsqArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bsqExistosa = False
            Hide()
        End If
    End Sub

    Private Sub txtCriterio_Click(sender As Object, e As EventArgs) Handles txtCriterio.Click
        txtCriterio.SelectAll()
    End Sub

    Private Sub DgArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgArticulos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            bsqExistosa = True
            GetEntidad()
        End If
    End Sub

    Private Sub DgArticulos_DoubleClick(sender As Object, e As EventArgs) Handles DgArticulos.DoubleClick
        bsqExistosa = True
        GetEntidad()
    End Sub

    Private Sub FrmBsqArticulo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        DgArticulos.Focus()
    End Sub


#End Region


End Class