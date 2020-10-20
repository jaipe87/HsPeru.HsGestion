
Option Strict On
Public Class FrmTabArticulos
    Private EstadoArt As Integer = 0
    Public form_lstArticulo As New List(Of TABART)
    Public form_lstdetarticulo As List(Of TABART_SUCURSAL)
    Public form_lstdetSucursales As List(Of TABART_UBICACION)
    Public form_datArticulo As TABART
    Private oArticulo As DAL_TABART
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Inicia()
    End Sub



#Region "Métodos"
    Sub Inicia()

        GTipcam = GetTipCambio(Date.Today)
        lblTipCam.Text = GTipcam.ToString("N2")
        CargarComboBox(oCombo.CargaSucursal, "COD", "DES", cboSuc, TODAS)

        CargarComboBox(oCombo.CargaUnidades(), "COD", "DESCRI", cboUnidadMedida, SELECCIONAR)
        CargarComboBox(oCombo.CargaMarca(), "COD", "DES", cboMarcas, SELECCIONAR)
        CargarComboBox(oCombo.CargaCategoria(), "COD", "DES", cboCategoria, SELECCIONAR)


        CargarComboBox(oCombo.CargaSucursal, "COD", "DES", cboTabSuc)
        VerificaCombo(cboTabSuc, SUC_PRINCIPAL)



        cboSituacion.SelectedIndex = 0
        cboSituacion.Enabled = False

        tbArticulo.Tabs(0).Selected = True
        tbArticulo.Tabs(1).Enabled = False


        tbDetalle.Tabs(0).Selected = True
        tbDetalle.Tabs(1).Enabled = False


    End Sub
    Sub CargaSubCategoria()

        cboSubCategoria.DataSource = Nothing
        If TryCast(cboCategoria.SelectedItem, CATEGORIA).COD <> 0 Then
            CargarComboBox(oCombo.CargaSubCategoria(CInt(cboCategoria.SelectedValue)), "COD", "DESCRI", cboSubCategoria, SELECCIONAR)
        End If
    End Sub

    Sub EstadoArticulo()
        If rbdActivo.Checked Then
            EstadoArt = 0
        End If
        If rbdInactivos.Checked Then
            EstadoArt = 1
        End If
        If rbdTodos.Checked Then
            EstadoArt = 2
        End If
    End Sub
    Sub Buscar()
        oArticulo = New DAL_TABART
        Dim Fila As Integer = 0
        form_lstArticulo = oArticulo.SelectAll_Articulo(New TABART_SUCURSAL With {.DESCRI = txtCriterio.Text.Trim, .CODSUC = CInt(cboSuc.SelectedValue), .SIT = EstadoArt},
                                                        chkxFechaCreacion.Checked,
                                                        dtpFecha.Value.ToString("yyyy-MM-dd"),
                                                        DtpFecha1.Value.ToString("yyyy-MM-dd"))

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
                        .Rows(Fila).Cells(colEstado.Index).Value = item.DESEST
                    End With
                    Fila = Fila + 1
                Next
            End If
        End If

        DetalleArticulo()

        lblReg.Text = DgArticulos.Rows.Count.ToString

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
    Sub Nuevo()

        Dim Fila As Integer
        oArticulo = New DAL_TABART
        GTipcam = GetTipCambio(Date.Today)
        lblTipCam.Text = GTipcam.ToString("N2")
        lblcodart.Text = "?"
        txtCodfab.Clear()
        txtCodfab.Enabled = True
        txtDescri.Clear()
        txtModelo.Clear()
        txtGarantia.Clear()
        txtPrecom.Clear()
        lblcompra.Text = ""
        txtobs.Clear()
        chkICBPER.Checked = False
        txtIsc.Clear()
        chkAfecto.Checked = True
        txtPrecom.Clear()
        chkDesactivaVentas.Checked = False
        chkOferta.Checked = False
        chkListaPrecio.Checked = False

        VerificaCombo(cboMarcas, 0)
        VerificaCombo(cboCategoria, 0)
        VerificaCombo(cboSubCategoria, 0)
        rbdSoles.Checked = True
        cboSituacion.Enabled = False
        cboSituacion.SelectedIndex = 0
        form_lstdetarticulo = New List(Of TABART_SUCURSAL)
        DgUnidades.DataSource = Nothing

        CancelarUnidad()


        form_lstdetSucursales = New List(Of TABART_UBICACION)
        form_lstdetSucursales = oArticulo.SelectAll_tabart_ubicacion(New TABART With {.CIA = GCia, .CODART = lblcodart.Text})
        DgSucursales.Rows.Clear()

        If Not IsNothing(form_lstdetSucursales) Then
            If form_lstdetSucursales.Count > 0 Then

                For Each row As TABART_UBICACION In form_lstdetSucursales
                    DgSucursales.Rows.Add()
                    DgSucursales.Rows(Fila).Cells(colcodsucd.Index).Value = row.CODSUC
                    DgSucursales.Rows(Fila).Cells(coldessucd.Index).Value = row.DESSUC
                    DgSucursales.Rows(Fila).Cells(colubicacion.Index).Value = row.UBICACION
                    DgSucursales.Rows(Fila).Cells(colStockmin.Index).Value = row.STOCKMINIMO
                    DgSucursales.Rows(Fila).Cells(colActivado.Index).Value = row.ST

                    Fila += 1
                Next

            End If

        End If
        tbArticulo.Tabs(1).Selected = True
        tbArticulo.Tabs(0).Enabled = False
        tbArticulo.Tabs(1).Enabled = True
        tbDetallexSuc.Tabs(0).Selected = True
        txtCodfab.Focus()

    End Sub
    Sub Modificar()
        Dim ListaMaestras As List(Of TABART_SUCURSAL)
        Dim Fila As Integer
        Dim Codart As String
        oArticulo = New DAL_TABART
        Dim datArticulo As New TABART
        If DgArticulos.CurrentRow Is Nothing Then Return
        Codart = DgArticulos.CurrentRow.Cells(colcodart.Index).Value.ToString

        datArticulo = oArticulo.Select_tabart_by_cod(New TABART With {.CODART = Codart})

        If Not IsNothing(datArticulo) Then

            lblcodart.Text = datArticulo.CODART
            txtCodfab.Text = datArticulo.CODFAB

            txtDescri.Text = datArticulo.DESCRI
            txtModelo.Text = datArticulo.MODELO
            cboMarcas.SelectedValue = datArticulo.CODMAR
            cboCategoria.SelectedValue = datArticulo.CODGRU
            cboSubCategoria.SelectedValue = datArticulo.CODSUBCAT
            txtGarantia.Text = datArticulo.GARANTIA
            txtIsc.Text = datArticulo.ISC.ToString("N2")
            chkICBPER.Checked = (datArticulo.STICBPER = 1)
            txtobs.Text = datArticulo.ESPECI
            txtPrecom.Text = datArticulo.PRECOM.ToString("N2")
            If datArticulo.TIPMON = MON_SOLES Then
                rbdSoles.Checked = True
                lblcompra.Text = (datArticulo.PRECOM / GTipcam).ToString("N2")
            End If
            If datArticulo.TIPMON = MON_DOLARES Then
                rbdDolares.Checked = True
                lblcompra.Text = (datArticulo.PRECOM * GTipcam).ToString("N2")
            End If
            CambioMoneda()
            cboSituacion.SelectedIndex = datArticulo.SIT
            cboSituacion.Enabled = True
            chkListaPrecio.Checked = (datArticulo.STLIS = 1)
            chkOferta.Checked = (datArticulo.STOFE = 1)
            chkAfecto.Checked = (datArticulo.AFECTO = 1)
            chkDesactivaVentas.Checked = (datArticulo.STVEN = 1)

            form_lstdetarticulo = New List(Of TABART_SUCURSAL)
            form_lstdetSucursales = New List(Of TABART_UBICACION)
            form_lstdetarticulo = datArticulo.LISTAPRECIOS
            form_lstdetSucursales = datArticulo.LISTASUBICACION
            VerificaCombo(cboTabSuc, SUC_PRINCIPAL)
            DgUnidades.AutoGenerateColumns = False
            DgUnidades.DataSource = Nothing
            If Not IsNothing(form_lstdetarticulo) Then

                VerificaCombo(cboTabSuc, SUC_PRINCIPAL)
                ListaMaestras = form_lstdetarticulo.Where(Function(R) R.CODSUC = CInt(cboTabSuc.SelectedValue)).ToList

                If Not IsNothing(ListaMaestras) Then
                    If ListaMaestras.Count > 0 Then

                        DgUnidades.DataSource = ListaMaestras
                    End If

                End If
            End If
            Fila = 0
            DgSucursales.Rows.Clear()
            If Not IsNothing(form_lstdetSucursales) Then
                If form_lstdetSucursales.Count > 0 Then

                    For Each row As TABART_UBICACION In form_lstdetSucursales
                        DgSucursales.Rows.Add()

                        DgSucursales.Rows(Fila).Cells(colcodsucd.Index).Value = row.CODSUC
                        DgSucursales.Rows(Fila).Cells(coldessucd.Index).Value = row.DESSUC
                        DgSucursales.Rows(Fila).Cells(colubicacion.Index).Value = row.UBICACION
                        DgSucursales.Rows(Fila).Cells(colStockmin.Index).Value = row.STOCKMINIMO
                        DgSucursales.Rows(Fila).Cells(colActivado.Index).Value = row.ST

                        Fila += 1
                    Next
                End If
            End If


            CancelarUnidad()

            tbArticulo.Tabs(1).Selected = True
            tbArticulo.Tabs(0).Enabled = False
            tbArticulo.Tabs(1).Enabled = True

            tbDetallexSuc.Tabs(0).Selected = True



        Else
            MensajeSimple("No ha encontrado datos del registro seleccionado")
        End If



    End Sub
    Sub Copiar()
        Dim ListaMaestras As List(Of TABART_SUCURSAL)
        Dim Fila As Integer
        Dim Codart As String
        oArticulo = New DAL_TABART
        Dim datArticulo As New TABART
        If DgArticulos.CurrentRow Is Nothing Then Return
        Codart = DgArticulos.CurrentRow.Cells(colcodart.Index).Value.ToString

        datArticulo = oArticulo.Select_tabart_by_cod(New TABART With {.CODART = Codart})

        If Not IsNothing(datArticulo) Then

            lblcodart.Text = "?"
            txtCodfab.Text = ""
            txtCodfab.Enabled = True
            txtDescri.Text = datArticulo.DESCRI
            txtModelo.Text = datArticulo.MODELO
            cboMarcas.SelectedValue = datArticulo.CODMAR
            cboCategoria.SelectedValue = datArticulo.CODGRU
            cboSubCategoria.SelectedValue = datArticulo.CODSUBCAT
            txtGarantia.Text = datArticulo.GARANTIA
            txtPrecom.Text = datArticulo.PRECOM.ToString("N2")
            txtobs.Text = datArticulo.ESPECI
            txtIsc.Text = datArticulo.ISC.ToString("N2")
            chkICBPER.Checked = (datArticulo.STICBPER = 1)
            If datArticulo.TIPMON = MON_SOLES Then
                rbdSoles.Checked = True
                lblcompra.Text = (datArticulo.PRECOM / GTipcam).ToString("N2")
            End If
            If datArticulo.TIPMON = MON_DOLARES Then
                rbdDolares.Checked = True
                lblcompra.Text = (datArticulo.PRECOM * GTipcam).ToString("N2")
            End If
            CambioMoneda()
            cboSituacion.SelectedIndex = datArticulo.SIT
            cboSituacion.Enabled = True
            chkListaPrecio.Checked = (datArticulo.STLIS = 1)
            chkOferta.Checked = (datArticulo.STOFE = 1)
            chkAfecto.Checked = (datArticulo.AFECTO = 1)
            chkDesactivaVentas.Checked = (datArticulo.STVEN = 1)
            VerificaCombo(cboTabSuc, SUC_PRINCIPAL)
            form_lstdetarticulo = New List(Of TABART_SUCURSAL)
            form_lstdetSucursales = New List(Of TABART_UBICACION)

            form_lstdetarticulo = datArticulo.LISTAPRECIOS
            form_lstdetSucursales = datArticulo.LISTASUBICACION
            DgUnidades.AutoGenerateColumns = False
            DgUnidades.DataSource = Nothing
            If Not IsNothing(form_lstdetarticulo) Then

                VerificaCombo(cboTabSuc, SUC_PRINCIPAL)
                ListaMaestras = form_lstdetarticulo.Where(Function(R) R.CODSUC = CInt(cboTabSuc.SelectedValue)).ToList

                If Not IsNothing(ListaMaestras) Then
                    If ListaMaestras.Count > 0 Then

                        DgUnidades.DataSource = ListaMaestras
                    End If

                End If
            End If

            Fila = 0
            DgSucursales.Rows.Clear()
            If Not IsNothing(form_lstdetSucursales) Then
                If form_lstdetSucursales.Count > 0 Then

                    For Each row As TABART_UBICACION In form_lstdetSucursales
                        DgSucursales.Rows.Add()

                        DgSucursales.Rows(Fila).Cells(colcodsucd.Index).Value = row.CODSUC
                        DgSucursales.Rows(Fila).Cells(coldessucd.Index).Value = row.DESSUC
                        DgSucursales.Rows(Fila).Cells(colubicacion.Index).Value = row.UBICACION
                        DgSucursales.Rows(Fila).Cells(colStockmin.Index).Value = row.STOCKMINIMO
                        DgSucursales.Rows(Fila).Cells(colActivado.Index).Value = row.ST

                        Fila += 1
                    Next
                End If
            End If


            CancelarUnidad()

            tbArticulo.Tabs(1).Selected = True
            tbArticulo.Tabs(0).Enabled = False
            tbArticulo.Tabs(1).Enabled = True
            tbDetallexSuc.Tabs(0).Selected = True
            txtCodfab.Focus()
        Else
            MensajeSimple("No ha encontrado datos del registro seleccionado")
        End If

    End Sub
    Sub Graba()
        oArticulo = New DAL_TABART
        Dim VUNMinima As Integer
        Dim datArticulo = New TABART
        Dim datretorno As datRetorno

        Dim xIsc As Double = 0.00, Xprecom As Double

        Dim datUbicacion As TABART_UBICACION

        If txtDescri.Text.Trim.Length = 0 Then
            MensajeSimple("Ingrese un nombre o descripción del artículo")
            Return
        End If
        If NothingToInteger(cboMarcas.SelectedValue) = 0 Then

            MensajeSimple("Seleccione una marca para el artículo")
            Return
        End If
        If NothingToInteger(cboCategoria.SelectedValue) = 0 Then
            MensajeSimple("Seleccione una categoría para el artículo")
            Return
        End If
        datretorno = oArticulo.ValidaCodFab(New TABART With {.CODART = lblcodart.Text, .CODFAB = txtCodfab.Text})
        If CBool(datretorno.data) Then
            MensajeSimple(datretorno.msg)
            Return
        End If


        If Not IsNothing(form_lstdetarticulo) Then
            If form_lstdetarticulo.Count > 0 Then
                For Each i As TABSUC In TryCast(cboTabSuc.DataSource, List(Of TABSUC))

                    VUNMinima = form_lstdetarticulo.Where(Function(X) X.CODSUC = i.COD And X.STMINIMO = 1).Count

                    If VUNMinima = 0 Then
                        MensajeSimple("No ha seleccionado unidad mínima, para la sucursal " & i.DES)
                        Return
                    End If

                    If VUNMinima > 1 Then
                        MensajeSimple("Solo puede seleccionar una unidad mínima, para la sucursal " & i.DES)
                        Return
                    End If
                Next
            End If
        End If





        With datArticulo
            .CODART = lblcodart.Text
            .CODREF = lblcodart.Text
            .CODFAB = txtCodfab.Text.Trim
            .DESCRI = txtDescri.Text.Trim
            .CODMAR = NothingToInteger(cboMarcas.SelectedValue)
            .CODGRU = NothingToInteger(cboCategoria.SelectedValue)
            .CODSUBCAT = NothingToInteger(cboSubCategoria.SelectedValue)
            .MODELO = txtModelo.Text.Trim
            .GARANTIA = txtGarantia.Text.Trim
            If Double.TryParse(txtPrecom.Text.Trim, Xprecom) Then
                .PRECOM = Convert.ToDouble(txtPrecom.Text.Trim)
            Else
                .PRECOM = 0
            End If

            .AFECTO = If(chkAfecto.Checked, 1, 0)
            .STVEN = If(chkDesactivaVentas.Checked, 1, 0)
            .STWEB = 0
            .STOFE = If(chkOferta.Checked, 1, 0)
            .STLIS = If(chkListaPrecio.Checked, 1, 0)
            If Double.TryParse(txtIsc.Text.Trim, xIsc) Then
                .ISC = Convert.ToDouble(txtIsc.Text.Trim)
            Else
                .ISC = 0
            End If
            .STICBPER = If(chkICBPER.Checked, 1, 0)
            .TIPMON = If(rbdSoles.Checked, MON_SOLES, MON_DOLARES)
            .ESPECI = txtobs.Text.Trim
            .SIT = cboSituacion.SelectedIndex

            If Not IsNothing(form_lstdetarticulo) Then
                If form_lstdetarticulo.Count > 0 Then
                    .LISTAPRECIOS = form_lstdetarticulo
                End If
            End If

            form_lstdetSucursales = New List(Of TABART_UBICACION)
            For Each oRow As DataGridViewRow In DgSucursales.Rows
                datUbicacion = New TABART_UBICACION
                With datUbicacion
                    .CODSUC = NothingToInteger(oRow.Cells(colcodsucd.Index).Value)
                    .DESSUC = NothingToString(oRow.Cells(coldessucd.Index).Value)
                    .UBICACION = NothingToString(oRow.Cells(colubicacion.Index).Value)
                    .STOCKMINIMO = NothingToInteger(oRow.Cells(colStockmin.Index).Value)
                    .ST = NothingToInteger(oRow.Cells(colActivado.Index).Value)
                End With
                form_lstdetSucursales.Add(datUbicacion)
            Next
            If form_lstdetSucursales.Count > 0 Then
                .LISTASUBICACION = form_lstdetSucursales
            End If

            form_datArticulo = oArticulo.Insert_Articulo(datArticulo)

            If Not IsNothing(form_datArticulo) Then
                MensajeSimple("Se registro el artículo, con código " & form_datArticulo.CODART)
                tbArticulo.Tabs(0).Selected = True
                tbArticulo.Tabs(0).Enabled = True
                tbArticulo.Tabs(1).Enabled = False
                Buscar()

            Else
                MensajeSimple("No se puedo registrar el artículo", MessageBoxIcon.Error)
            End If
        End With

    End Sub
    Sub EliminarUnidad()
        If DgUnidades.CurrentRow Is Nothing Then
            MensajeSimple("No ha seleccionado registro alguno")
            Return
        End If
        If MessageBox.Show("¿Seguro de eliminar el registro seleccionado?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        Dim xCodSuc As Integer, xCoduni As Integer
        Dim datPrecioUni As New TABART_SUCURSAL

        xCodSuc = Convert.ToInt32(cboTabSuc.SelectedValue)
        xCoduni = NothingToInteger(DgUnidades.CurrentRow.Cells(colcoduni.Index).Value)

        If form_lstdetarticulo.Where(Function(x) x.CODSUC = xCodSuc And x.CODUNI = xCoduni).Count > 0 Then
            datPrecioUni = form_lstdetarticulo.Where(Function(x) x.CODSUC = xCodSuc And x.CODUNI = xCoduni).ToList().First
            form_lstdetarticulo.Remove(datPrecioUni)

            DgUnidades.AutoGenerateColumns = False
            DgUnidades.DataSource = form_lstdetarticulo

            CargaUnidadesxSuc()
        End If



    End Sub

    Sub AnadirUnidad()
        cboUnidadMedida.Focus()
        Panel8.Enabled = False
        VerificaCombo(cboUnidadMedida, 0)
        chkEsMinima.Checked = False
        txtPeso.Clear()
        txtEquivalente.Clear()
        txtPorDistri.Clear()
        txtPorMinimo.Clear()
        txtPorPublico.Clear()
        txtPublico.Clear()
        txtDistribucion.Clear()
        txtDistribucion.Clear()
        chkUnidadCompra.Checked = False
        cboUnidadMedida.Enabled = True
        cboUnidadMedida.Tag = "Nuevo"
        tbDetalle.Tabs(1).Selected = True
        tbDetalle.Tabs(0).Enabled = False
        tbDetalle.Tabs(1).Enabled = True

    End Sub

    Sub ModificarUnidad()
        Dim datPrecioUni As New TABART_SUCURSAL
        Dim xCodSuc As Integer, xCoduni As Integer
        If DgUnidades.CurrentRow Is Nothing Then
            MensajeSimple("No ha seleccionado registro alguno")
            Return
        End If
        cboUnidadMedida.Enabled = False
        cboUnidadMedida.Tag = "Modifica"
        xCodSuc = Convert.ToInt32(cboTabSuc.SelectedValue)
        xCoduni = NothingToInteger(DgUnidades.CurrentRow.Cells(colcoduni.Index).Value)

        If form_lstdetarticulo.Where(Function(x) x.CODSUC = xCodSuc And x.CODUNI = xCoduni).Count > 0 Then
            datPrecioUni = form_lstdetarticulo.Where(Function(x) x.CODSUC = xCodSuc And x.CODUNI = xCoduni).ToList().First
        End If

        If Not IsNothing(datPrecioUni) Then

            cboUnidadMedida.SelectedValue = datPrecioUni.CODUNI
            chkEsMinima.Checked = (datPrecioUni.STMINIMO = 1)
            txtEquivalente.Text = datPrecioUni.EQUIVA.ToString
            txtPeso.Text = datPrecioUni.PESO.ToString("N2")
            txtPorPublico.Text = datPrecioUni.PORC_PUBLI.ToString("N2")
            txtPorDistri.Text = datPrecioUni.PORC_DISTRI.ToString("N2")
            txtPorMinimo.Text = datPrecioUni.PORC_MIN.ToString("N2")
            txtPublico.Text = datPrecioUni.PRECIO_PUBLI.ToString("N2")
            txtDistribucion.Text = datPrecioUni.PRECIO_DISTRI.ToString("N2")
            txtMinimo.Text = datPrecioUni.PRECIO_MIN.ToString("N2")
            chkUnidadCompra.Checked = (datPrecioUni.STUNIDADCOMPRA = 1)
            CambioMoneda()
        End If

        Panel8.Enabled = False
        tbDetalle.Tabs(1).Selected = True
        tbDetalle.Tabs(0).Enabled = False
        tbDetalle.Tabs(1).Enabled = True

        txtPublico.Focus()
    End Sub
    ''' <summary>
    ''' CALCULA EL PRECIO VENTA  EN BASE AL PORCENTAJE DE UTILIDAD O RENTABILIDAD ASIGNADO
    ''' </summary>
    ''' <param name="TipPrecio"></param>
    Sub calculoUtilidad(ByVal TipPrecio As Integer)
        Dim xCosto As Double = 0, xEquivale As Double = 0, XcostoReal As Double = 0.00
        Dim XPorPublico As Double = 0, XPorDistri As Double = 0, xPorMinimo As Double = 0
        Dim XPrePublico As Double = 0, XPreDistri As Double = 0, xPreMinimo As Double = 0
        If Double.TryParse(txtPrecom.Text, xCosto) Then
            xCosto = Convert.ToDouble(txtPrecom.Text)
        End If
        If Double.TryParse(txtEquivalente.Text, xEquivale) Then
            xEquivale = Convert.ToDouble(txtEquivalente.Text)
        End If
        XcostoReal = xCosto * xEquivale

        Select Case TipPrecio

            Case TipoPrecio.Publico
                If Double.TryParse(txtPorPublico.Text, XPorPublico) Then
                    XPorPublico = Convert.ToDouble(txtPorPublico.Text)
                End If
                If XPorPublico > 0 Then
                    XPrePublico = (XcostoReal / (1 - (XPorPublico / 100)))
                    txtPublico.Text = XPrePublico.ToString("N2")
                End If
            Case TipoPrecio.Distribuidor
                If Double.TryParse(txtPorDistri.Text, XPorDistri) Then
                    XPorDistri = Convert.ToDouble(txtPorDistri.Text)
                End If
                If XPorDistri > 0 Then
                    XPreDistri = (XcostoReal / (1 - (XPorDistri / 100)))
                    txtDistribucion.Text = XPreDistri.ToString("N2")
                End If
            Case TipoPrecio.Minimo
                If Double.TryParse(txtPorMinimo.Text, xPorMinimo) Then
                    xPorMinimo = Convert.ToDouble(txtPorMinimo.Text)
                End If
                If xPorMinimo > 0 Then
                    xPreMinimo = (XcostoReal / (1 - (xPorMinimo / 100)))
                    txtMinimo.Text = xPreMinimo.ToString("N2")
                End If
            Case Else
                If Double.TryParse(txtPorPublico.Text, XPorPublico) Then
                    XPorPublico = Convert.ToDouble(txtPorPublico.Text)
                End If
                If XPorPublico > 0 Then
                    XPrePublico = (XcostoReal / (1 - (XPorPublico / 100)))
                    txtPublico.Text = XPrePublico.ToString("N2")
                End If

                If Double.TryParse(txtPorDistri.Text, XPorDistri) Then
                    XPorDistri = Convert.ToDouble(txtPorDistri.Text)
                End If
                If XPorDistri > 0 Then
                    XPreDistri = (XcostoReal / (1 - (XPorDistri / 100)))
                    txtDistribucion.Text = XPreDistri.ToString("N2")
                End If

                If Double.TryParse(txtPorMinimo.Text, xPorMinimo) Then
                    xPorMinimo = Convert.ToDouble(txtPorMinimo.Text)
                End If
                If xPorMinimo > 0 Then
                    xPreMinimo = (XcostoReal / (1 - (xPorMinimo / 100)))
                    txtMinimo.Text = xPreMinimo.ToString("N2")
                End If
        End Select
        CambioMoneda()
    End Sub
    Sub CancelarUnidad()
        Panel8.Enabled = True

        tbDetalle.Tabs(0).Selected = True
        tbDetalle.Tabs(0).Enabled = True
        tbDetalle.Tabs(1).Enabled = False

    End Sub
    Sub CambioMoneda()
        Dim xPrecom As Double, XPublico As Double, XDistri As Double, XMinimo As Double
        If rbdSoles.Checked Then
            GroupBox3.Text = "Precios de Venta  (" & SOLES & ")"
            GroupBox4.Text = "Precios de Venta  (" & DOLARES & ")"
            Label2.Text = "Prc. Costo " & SOLES & " :"
            Label3.Text = "Prc. Costo " & DOLARES & " :"

            If Double.TryParse(txtPrecom.Text, xPrecom) Then
                lblcompra.Text = (xPrecom / GTipcam).ToString("N2")
            Else
                lblcompra.Text = "0.00"
            End If
            If Double.TryParse(txtPublico.Text, XPublico) Then
                LblPublico.Text = (XPublico / GTipcam).ToString("N2")
            Else
                LblPublico.Text = "0.00"
            End If
            If Double.TryParse(txtDistribucion.Text, XDistri) Then
                lblDistribuidor.Text = (XDistri / GTipcam).ToString("N2")
            Else
                lblDistribuidor.Text = "0.00"
            End If

            If Double.TryParse(txtMinimo.Text, XMinimo) Then
                lblMinimo.Text = (XMinimo / GTipcam).ToString("N2")
            Else
                lblMinimo.Text = "0.00"
            End If

        End If
        If rbdDolares.Checked Then
            GroupBox4.Text = "Precios de Venta  (" & SOLES & ")"
            GroupBox3.Text = "Precios de Venta  (" & DOLARES & ")"
            Label3.Text = "Prc. Costo " & SOLES & " :"
            Label2.Text = "Prc. Costo " & DOLARES & " :"

            If Double.TryParse(txtPrecom.Text, xPrecom) Then
                lblcompra.Text = (xPrecom * GTipcam).ToString("N2")
            Else
                lblcompra.Text = "0.00"
            End If
            If Double.TryParse(txtPublico.Text, XPublico) Then
                LblPublico.Text = (XPublico * GTipcam).ToString("N2")
            Else
                LblPublico.Text = "0.00"
            End If
            If Double.TryParse(txtDistribucion.Text, XDistri) Then
                lblDistribuidor.Text = (XDistri * GTipcam).ToString("N2")
            Else
                lblDistribuidor.Text = "0.00"
            End If

            If Double.TryParse(txtMinimo.Text, XMinimo) Then
                lblMinimo.Text = (XMinimo * GTipcam).ToString("N2")
            Else
                lblMinimo.Text = "0.00"
            End If

        End If

    End Sub
    Sub CargaUnidadesxSuc()
        Dim ListaMaestras As List(Of TABART_SUCURSAL)


        DgUnidades.AutoGenerateColumns = False
        DgUnidades.DataSource = Nothing


        If Not IsNothing(form_lstdetarticulo) Then
            ListaMaestras = form_lstdetarticulo.Where(Function(R) R.CODSUC = CInt(cboTabSuc.SelectedValue)).ToList

            If Not IsNothing(ListaMaestras) Then
                If ListaMaestras.Count > 0 Then
                    DgUnidades.DataSource = ListaMaestras
                End If


            End If
        End If
    End Sub
    Sub GrabaUnidad(ByVal Esnuevo As Boolean)
        Dim datdetalle As New TABART_SUCURSAL
        Dim XEQuiva As Double, XPeso As Double, XPrcPublico As Double, XPrcDistribuidor As Double, XPrMinimo As Double
        Dim XPorcPubli As Double, XPorcDistri As Double, XPorcMinimo As Double
        With datdetalle
            .CIA = GCia
            .CODART = lblcodart.Text
            .CODSUC = Convert.ToInt32(cboTabSuc.SelectedValue)
            .CODUNI = Convert.ToInt32(cboUnidadMedida.SelectedValue)
            .STMINIMO = If(chkEsMinima.Checked, 1, 0)
            .DESUNI = cboUnidadMedida.Text
            .ESMIN = If(.STMINIMO = 1, "SI", "NO")
            If Double.TryParse(txtEquivalente.Text.Trim, XEQuiva) Then
                .EQUIVA = XEQuiva
            Else
                .EQUIVA = 0
            End If
            If Double.TryParse(txtPeso.Text.Trim, XPeso) Then
                .PESO = XPeso
            Else
                .PESO = 0
            End If
            .STUNIDADCOMPRA = If(chkUnidadCompra.Checked, 1, 0)

            If Double.TryParse(txtPorPublico.Text.Trim, XPorcPubli) Then
                .PORC_PUBLI = XPorcPubli
            Else
                .PORC_PUBLI = 0
            End If
            If Double.TryParse(txtPorDistri.Text.Trim, XPorcDistri) Then
                .PORC_DISTRI = XPorcDistri
            Else
                .PORC_DISTRI = 0
            End If
            If Double.TryParse(txtPorMinimo.Text.Trim, XPorcMinimo) Then
                .PORC_MIN = XPorcMinimo
            Else
                .PORC_MIN = 0
            End If

            If Double.TryParse(txtPublico.Text.Trim, XPrcPublico) Then
                .PRECIO_PUBLI = XPrcPublico
            Else
                .PRECIO_PUBLI = 0
            End If

            If Double.TryParse(txtDistribucion.Text.Trim, XPrcDistribuidor) Then
                .PRECIO_DISTRI = XPrcDistribuidor
            Else
                .PRECIO_DISTRI = 0
            End If

            If Double.TryParse(txtMinimo.Text.Trim, XPrMinimo) Then
                .PRECIO_MIN = XPrMinimo
            Else
                .PRECIO_MIN = 0
            End If
            If form_lstdetarticulo Is Nothing Then
                form_lstdetarticulo = New List(Of TABART_SUCURSAL)
            End If

            If Esnuevo Then
                form_lstdetarticulo.Add(datdetalle)
                DgUnidades.DataSource = Nothing
                DgUnidades.AutoGenerateColumns = False
                DgUnidades.DataSource = form_lstdetarticulo
                CargaUnidadesxSuc()
            Else
                ActulizarItemPrecioUnidad(datdetalle)
            End If

            CancelarUnidad()
        End With
    End Sub

    Sub ActulizarItemPrecioUnidad(ByVal objDato As TABART_SUCURSAL)
        Dim cmd As CurrencyManager
        Dim query = (From R In form_lstdetarticulo Where R.CODSUC = objDato.CODSUC And R.CODUNI = objDato.CODUNI Select R)
        For Each item In query

            With item
                .STMINIMO = objDato.STMINIMO
                .ESMIN = If(.STMINIMO = 1, "SI", "NO")
                .EQUIVA = objDato.EQUIVA
                .PESO = objDato.PESO
                .STUNIDADCOMPRA = objDato.STUNIDADCOMPRA
                .PORC_PUBLI = objDato.PORC_PUBLI
                .PORC_DISTRI = objDato.PORC_DISTRI
                .PORC_MIN = objDato.PORC_MIN
                .PRECIO_PUBLI = objDato.PRECIO_PUBLI
                .PRECIO_DISTRI = objDato.PRECIO_DISTRI
                .PRECIO_MIN = objDato.PRECIO_MIN

            End With
        Next
        cmd = DirectCast(BindingContext(form_lstdetarticulo), CurrencyManager)
        cmd.Refresh()
    End Sub
#End Region
#Region "Eventos"
    Private Sub cboCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategoria.SelectedIndexChanged

        CargaSubCategoria()
    End Sub

    Private Sub FrmTabArticulos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCriterio.Focus()
    End Sub



    Private Sub chkxFechaCreacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkxFechaCreacion.CheckedChanged
        dtpFecha.Enabled = chkxFechaCreacion.Checked
        DtpFecha1.Enabled = chkxFechaCreacion.Checked
    End Sub

    Private Sub rbdActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rbdActivo.CheckedChanged
        EstadoArticulo()
    End Sub

    Private Sub rbdInactivos_CheckedChanged(sender As Object, e As EventArgs) Handles rbdInactivos.CheckedChanged
        EstadoArticulo()
    End Sub

    Private Sub rbdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbdTodos.CheckedChanged
        EstadoArticulo()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub





    Private Sub txtCriterio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCriterio.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub DgArticulos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DgArticulos.CellEnter
        DetalleArticulo()
    End Sub

    Private Sub txtCriterio_Click(sender As Object, e As EventArgs) Handles txtCriterio.Click

        txtCriterio.SelectAll()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
        Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        tbArticulo.Tabs(0).Selected = True
        tbArticulo.Tabs(0).Enabled = True
        tbArticulo.Tabs(1).Enabled = False


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba
    End Sub

    Private Sub SaltoControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecom.KeyDown, txtModelo.KeyDown, txtGarantia.KeyDown, txtDescri.KeyDown, txtCodfab.KeyDown, rbdSoles.KeyDown, cboSubCategoria.KeyDown, cboMarcas.KeyDown, cboCategoria.KeyDown, cboUnidadMedida.KeyDown, txtEquivalente.KeyDown, txtPorPublico.KeyDown, txtPorDistri.KeyDown, txtPorMinimo.KeyDown, txtPublico.KeyDown, txtDistribucion.KeyDown, txtMinimo.KeyDown, txtPeso.KeyDown, cboTabSuc.KeyDown, txtIsc.KeyDown, chkUnidadCompra.KeyDown, tbDetalle.KeyDown, chkEsMinima.KeyDown
        If e.KeyCode = Keys.Enter Then


            If Not TryCast(sender, TextBox) Is Nothing Then
                If (TryCast(sender, TextBox).Name = txtPrecom.Name) Or (TryCast(sender, TextBox).Name = txtPublico.Name) Or
                   (TryCast(sender, TextBox).Name = txtDistribucion.Name) Or (TryCast(sender, TextBox).Name = txtMinimo.Name) Then
                    CambioMoneda()
                End If

                If (TryCast(sender, TextBox).Name = txtPrecom.Name) Or (TryCast(sender, TextBox).Name = txtEquivalente.Name) Then
                    calculoUtilidad(TipoPrecio.Todos)
                End If

                If (TryCast(sender, TextBox).Name = txtPorPublico.Name) Then
                    calculoUtilidad(TipoPrecio.Publico)
                End If

                If (TryCast(sender, TextBox).Name = txtPorDistri.Name) Then
                    calculoUtilidad(TipoPrecio.Distribuidor)
                End If

                If (TryCast(sender, TextBox).Name = txtPorMinimo.Name) Then
                    calculoUtilidad(TipoPrecio.Minimo)
                End If
            End If


            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAnadir_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click
        AnadirUnidad()
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        ModificarUnidad()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        EliminarUnidad()
    End Sub

    Private Sub btnCancela_Click(sender As Object, e As EventArgs) Handles btnCancela.Click
        CancelarUnidad()
    End Sub

    Private Sub ControlSelect_Click(sender As Object, e As EventArgs) Handles txtPublico.Click, txtPrecom.Click, txtPorPublico.Click, txtPorMinimo.Click, txtPorDistri.Click, txtModelo.Click, txtMinimo.Click, txtGarantia.Click, txtEquivalente.Click, txtDistribucion.Click, txtDescri.Click, txtCodfab.Click, txtPeso.Click, txtIsc.Click, txtobs.Click
        TryCast(sender, TextBox).SelectAll()
    End Sub



    Private Sub rbdDolares_CheckedChanged(sender As Object, e As EventArgs) Handles rbdDolares.CheckedChanged
        calculoUtilidad(TipoPrecio.Todos)
    End Sub

    Private Sub rbdSoles_CheckedChanged(sender As Object, e As EventArgs) Handles rbdSoles.CheckedChanged
        calculoUtilidad(TipoPrecio.Todos)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub cboTabSuc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTabSuc.SelectedIndexChanged
        CargaUnidadesxSuc()
    End Sub

    Private Sub txtPrecom_TextChanged(sender As Object, e As EventArgs) Handles txtPrecom.TextChanged
        If txtPrecom.Text.Trim.Length = 0 Then lblcompra.Text = "0.00"
    End Sub

    Private Sub txtPublico_TextChanged(sender As Object, e As EventArgs) Handles txtPublico.TextChanged
        If txtPublico.Text.Trim.Length = 0 Then LblPublico.Text = "0.00"
    End Sub

    Private Sub txtDistribucion_TextChanged(sender As Object, e As EventArgs) Handles txtDistribucion.TextChanged
        If txtDistribucion.Text.Trim.Length = 0 Then lblDistribuidor.Text = "0.00"
    End Sub

    Private Sub txtMinimo_TextChanged(sender As Object, e As EventArgs) Handles txtMinimo.TextChanged
        If txtMinimo.Text.Trim.Length = 0 Then lblMinimo.Text = "0.00"
    End Sub

    Private Sub DgArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgArticulos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnAddCopia_Click(sender As Object, e As EventArgs) Handles btnAddCopia.Click
        Copiar()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        GrabaUnidad(If(cboUnidadMedida.Tag.Equals("Nuevo"), True, False))
    End Sub

    Private Sub btnCancela1_Click(sender As Object, e As EventArgs)
        CancelarUnidad()
    End Sub

    Private Sub btnAceptar1_Click(sender As Object, e As EventArgs)
        GrabaUnidad(If(cboUnidadMedida.Tag.Equals("Nuevo"), True, False))
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






#End Region
End Class