Public Class FrmPreciosUnidad
    Public form_listPreciosLista As List(Of TABART_SUCURSAL) = New List(Of TABART_SUCURSAL)
    Private form_InilstPreciosLista As List(Of TABART_SUCURSAL)
    Private mtipmon As Integer = 0
    Dim Fila As Integer = 0

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If GTipcam = 0 Then
            GTipcam = GetTipCambio(Today)
        End If

    End Sub
    Sub CargaLista(ByVal objDato As TABART, ByVal Tipmon As Integer)
        mtipmon = Tipmon
        dgDetallePrecios.Rows.Clear()
        form_InilstPreciosLista = objDato.LISTAPRECIOS
        If Not form_InilstPreciosLista Is Nothing Then
            If form_InilstPreciosLista.Count > 0 Then
                For Each i As TABART_SUCURSAL In form_InilstPreciosLista



                    With dgDetallePrecios
                        .Rows.Add()
                        dgDetallePrecios.Rows(Fila).Cells(colcodsuc.Index).Value = i.CODSUC
                        dgDetallePrecios.Rows(Fila).Cells(colDessuc.Index).Value = i.DESSUC
                        dgDetallePrecios.Rows(Fila).Cells(colcoduni.Index).Value = i.CODUNI
                        dgDetallePrecios.Rows(Fila).Cells(colDes_uni.Index).Value = i.DESUNI
                        If objDato.TIPMON = MON_SOLES Then
                            dgDetallePrecios.Rows(Fila).Cells(colprecio_publi.Index).Value = i.PRECIO_PUBLI.ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colpublicod.Index).Value = (i.PRECIO_PUBLI / GTipcam).ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colprec_distri.Index).Value = i.PRECIO_DISTRI.ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(coldistrid.Index).Value = (i.PRECIO_DISTRI / GTipcam).ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colprecio_min.Index).Value = i.PRECIO_MIN.ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colpmind.Index).Value = (i.PRECIO_MIN / GTipcam).ToString("N2")
                        Else
                            dgDetallePrecios.Rows(Fila).Cells(colpublicod.Index).Value = i.PRECIO_PUBLI.ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colprecio_publi.Index).Value = (i.PRECIO_PUBLI * GTipcam).ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(coldistrid.Index).Value = i.PRECIO_DISTRI.ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colprec_distri.Index).Value = (i.PRECIO_DISTRI * GTipcam).ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colpmind.Index).Value = i.PRECIO_MIN.ToString("N2")
                            dgDetallePrecios.Rows(Fila).Cells(colprecio_min.Index).Value = (i.PRECIO_MIN * GTipcam).ToString("N2")
                        End If
                        dgDetallePrecios.Rows(Fila).Cells(colEsMin.Index).Value = i.ESMIN
                    End With
                    Fila = Fila + 1
                Next
            End If
            If mtipmon = MON_SOLES Then
                colprecio_publi.Visible = True
                colpublicod.Visible = False
                colprec_distri.Visible = True
                coldistrid.Visible = False
                colprecio_min.Visible = True
                colpmind.Visible = False
            Else
                colprecio_publi.Visible = False
                colpublicod.Visible = True
                colprec_distri.Visible = False
                coldistrid.Visible = True
                colprecio_min.Visible = False
                colpmind.Visible = True
            End If
        End If


    End Sub
    Sub GetEntidad()

        Dim datListaPrecio As New TABART_SUCURSAL
        If dgDetallePrecios.CurrentRow Is Nothing Then
            Close()
            Dispose()
            Return
        End If
        Dim xcoduni As Integer
        xcoduni = NothingToInteger(dgDetallePrecios.CurrentRow.Cells(colcoduni.Index).Value)
        If form_InilstPreciosLista.Where(Function(X) X.CODUNI = xcoduni).Count > 0 Then
            datListaPrecio = form_InilstPreciosLista.Where(Function(X) X.CODUNI = xcoduni).First()

            If mtipmon = MON_SOLES Then
                datListaPrecio.PRECIO_PUBLI = NothingToDouble(dgDetallePrecios.CurrentRow.Cells(colprecio_publi.Index).Value)
                datListaPrecio.PRECIO_DISTRI = NothingToDouble(dgDetallePrecios.CurrentRow.Cells(colprec_distri.Index).Value)
                datListaPrecio.PRECIO_MIN = NothingToDouble(dgDetallePrecios.CurrentRow.Cells(colprecio_min.Index).Value)
            Else
                datListaPrecio.PRECIO_PUBLI = NothingToDouble(dgDetallePrecios.CurrentRow.Cells(colpublicod.Index).Value)
                datListaPrecio.PRECIO_DISTRI = NothingToDouble(dgDetallePrecios.CurrentRow.Cells(coldistrid.Index).Value)
                datListaPrecio.PRECIO_MIN = NothingToDouble(dgDetallePrecios.CurrentRow.Cells(colpmind.Index).Value)
            End If


            form_listPreciosLista.Add(datListaPrecio)
        Else
            datListaPrecio = Nothing
        End If
        Hide()
    End Sub
    Private Sub FrmPreciosUnidad_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            form_listPreciosLista = Nothing
            Hide()
        End If
    End Sub

    Private Sub dgDetallePrecios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetallePrecios.CellDoubleClick
        GetEntidad()

    End Sub

    Private Sub dgDetallePrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles dgDetallePrecios.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            GetEntidad()

        End If
    End Sub
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
End Class