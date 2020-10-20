Option Strict On
Imports System.Math
Public Class FrmManteFactura
    Private TipoCPE As Integer
    Public form_datclipro As CLIPRO
    Public form_datArti As TABART
    Dim m_tipmon As Integer = 0
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Inicia()
    End Sub


#Region "Métodos"
    Sub Inicia()
        If GcodVen = 0 Then
            CargarComboBox(oCombo.CargaVendedor, "COD", "DES", cboTabVen, SELECCIONAR)
        Else
            CargarComboBox(oCombo.CargaVendedor, "COD", "DES", cboTabVen)
            VerificaCombo(cboTabVen, "")
        End If
        CargarComboBox(oCombo.CargaFormaPago, "COD", "DESCRI", cboForPago)
        VerificaCombo(cboForPago, CInt(TipPago.CONTADO))
        CargarComboBox(oCombo.CargaMoneda, "COD", "DES", cboTabMon)
        VerificaCombo(cboTabMon, CInt(TipMon.SOLES))
        CargarComboBox(oCombo.CargaTipdocCPE, "COD", "DESABR", cboTabdoc)
        VerificaCombo(cboTabdoc, CInt(TipDocCPE.FAC))
        CargarComboBox(oCombo.CargaTipdocREF, "COD", "DESABR", cboDocRef)
        VerificaCombo(cboDocRef, CInt(TipDocCPE.PRO))
        ConfiguraDoc()
        TipCPE()
        lblTipcam.Text = (GetTipCambio(dtpFecha.Value)).ToString("N2")
        GetIGV(dtpFecha.Value)
        GetICBPER(dtpFecha.Value, NothingToInteger(cboTabMon.SelectedValue))
    End Sub
    Sub ConfiguraDoc()
        Dim datTabdoc As New TG_TABDOC
        If cboTabdoc.SelectedItem IsNot Nothing Then
            datTabdoc = TryCast(cboTabdoc.SelectedItem, TG_TABDOC)
            If (datTabdoc.STELEC = CInt(TipElec.NOESELEC)) Then
                rdbDocElectronico.Checked = False
                rdbDocElectronico.Visible = False
                rdbDocNumerico.Visible = False
                rdbDocNumerico.Checked = True
            Else
                rdbDocElectronico.Checked = True
                rdbDocNumerico.Checked = False
                rdbDocElectronico.Visible = True
                rdbDocNumerico.Visible = True
            End If
        End If
    End Sub
    Sub TipCPE()
        If rdbDocElectronico.Checked Then
            TipoCPE = sisEnum.TipCPE.ELECTRO
        End If
        If rdbDocNumerico.Checked Then
            TipoCPE = sisEnum.TipCPE.NORMAL
        End If
        If cboTabdoc.SelectedValue IsNot Nothing Then
            CargarComboBox(oCombo.CargaSerie(TipoCPE, NothingToInteger(TryCast(cboTabdoc.SelectedItem, TG_TABDOC).COD)), "NROSER", "NROSER", cboTabSerie)
            cboTabSerie.SelectedIndex = 0
        End If
    End Sub
    Sub BuscaClienteRapido()
        form_datclipro = GetCliente(txtCodigo.Text.Trim, sisEnum.TipReg.CLI)
        If Not IsNothing(form_datclipro) Then
            txtCodigo.Text = form_datclipro.CODIGO.ToString
            If form_datclipro.CODIGO = CLIENTEVARIOS Then
                txtDireccion.Size = New Size(414, 35)
            Else
                txtDireccion.Size = New Size(551, 35)

            End If
            txtRazsoc.Text = form_datclipro.TRAZSOC
            txtDireccion.Text = form_datclipro.DIRECC
            lblNroDoc.Text = GetAbrevDoc(form_datclipro.TIPDOC) & "-" & form_datclipro.NRODOC
            VerificaCombo(cboTabVen, form_datclipro.CODVEN)
            oCombo.CargaSucursalesClientes(form_datclipro.CODIGO)
            CargarComboBox(oCombo.CargaSucursalesClientes(form_datclipro.CODIGO), "CODSUC", "DIRECC", cboCliSucu)
            VerificaCombo(cboCliSucu, 0)

        End If
    End Sub
    Sub Totales()
        Dim Fila As Integer, Col As Integer
        Dim XBruto As Double, XTotal As Double, XMonto As Double
        Dim XVV As Double, XDescto As Double, XTotDes As Double, XIGV As Double, XICBPER As Double
        Dim XExonerado As Double, XVEX As Double, XDesctoEx As Double
        Dim XISC As Double, XSumTri As Double, XBase As Double, XDsctoBase As Double, XPorISC As Double
        Dim XBIGV As Double, XBISC As Double
        XBruto = 0 : XTotal = 0 : XDescto = 0 : XTotDes = 0 : XICBPER = 0 : XVV = 0 : XIGV = 0
        XISC = 0 : XExonerado = 0 : XVEX = 0 : XDesctoEx = 0 : XSumTri = 0 : XBIGV = 0 : XBISC = 0 : XPorISC = 0




        If dbDetfac.Rows.Count > 0 Then
            Fila = dbDetfac.CurrentCell.RowIndex
            Col = dbDetfac.CurrentCell.ColumnIndex
            For Each row As DataGridViewRow In dbDetfac.Rows
                With dbDetfac
                    If NothingToDouble(row.Cells(colPremin.Index).Value) > NothingToDouble(row.Cells(colPrecioUni.Index).Value) And NothingToInteger(row.Cells(colcodAuto.Index).Value) = 0 Then
                        If MessageBox.Show(NothingToString(row.Cells(colDescri.Index).Value) & "NO SE PUEDE VENDER POR DEBAJO DE " & NothingToDouble(row.Cells(colPremin.Index).Value) & " ¿Desea Ingresar código de autorización?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim Frm As New FrmLoginPWD
                            Frm.PSup = 0
                            Frm.ShowDialog()
                            If Frm.PCodAut = 0 Then
                                row.Cells(colPrecioUni.Index).Value = row.Cells(colPremin.Index).Value
                            Else
                                row.Cells(colcodAuto.Index).Value = Frm.PCodAut
                                row.Cells(coldesAutorizado.Index).Value = Frm.PDesAut
                            End If
                            Frm.Close()
                            Frm.Dispose()
                        Else
                            row.Cells(colPrecioUni.Index).Value = row.Cells(colPremin.Index).Value
                        End If
                    End If
                    XMonto = NothingToDouble(row.Cells(colPrecioUni.Index).Value) * NothingToDouble(row.Cells(colcantid.Index).Value)
                    XDescto = StringToDouble(NothingToString(row.Cells(colDescto.Index).Value))
                    XPorISC = NothingToDouble(row.Cells(colPorISC.Index).Value)
                    row.Cells(colNeto.Index).Value = Format(XMonto, NN)

                    If StringToInteger(NothingToString(row.Cells(colInafecto.Index).Value)) = 1 Then

                        XSumTri = 1 + ((GPorIGV + XPorISC) / 100) 'Suma de tributos IGV + ISC

                        XBase = Round(XMonto / XSumTri, 2) 'Cálculo del valor venta Gravable
                        XDsctoBase = Round(XDescto / XSumTri, 2) ' Cálculo del valor Descuento Gravable

                        XBIGV = (XBase - XDsctoBase) * (GPorIGV / 100) 'Cálculo del IGV por ITEM
                        XBISC = (XBase - XDsctoBase) * (XPorISC / 100) ' Cálculo del ISC por ITEM

                        XIGV += XMonto - ((XBase - XDsctoBase) + XBISC)
                        XISC += XMonto - ((XBase - XDsctoBase) + XBIGV)
                        XBruto += XBase
                        XTotDes += XDsctoBase

                    Else
                        XExonerado += XMonto
                        XDesctoEx += XDescto
                    End If

                    XICBPER += NothingToInteger(row.Cells(colsticbper.Index).Value) * GICBPER * NothingToDouble(row.Cells(colcantid.Index).Value)
                End With
            Next
            dbDetfac.CurrentCell = dbDetfac.Rows(Fila).Cells(Col)

            XVV = (XBruto - XDescto)
            XVEX = (XExonerado - XDesctoEx)

            lblBruto.Text = Format(XBruto, NN)
            lblDescto.Text = Format(XDescto, NN)
            lblVV.Text = Format(XVV, NN)
            lblExonerado.Text = Format(XExonerado, NN)
            lblDesctoExo.Text = Format(XDesctoEx, NN)
            lblVEX.Text = Format(XVEX, NN)
            LblIGV.Text = Format(XIGV, NN)
            LblISC.Text = Format(XISC, NN)
            LblICBPER.Text = Format(XICBPER, NN)

            lblTotal.Text = Format(XVV + XVEX + XIGV + XISC + XICBPER, NN)
        End If
    End Sub
    Sub DiasVencimiento(ByVal Optional FechaToDias As Boolean = True)
        Dim XDias As Long = 0
        Dim XFechaVen As Date
        If FechaToDias Then
            XDias = DateDiff(DateInterval.Day, dtpFecha.Value, dtpVencimiento.Value)
            txtDias.Text = String.Format("{0:00}", XDias)
        Else
            If Long.TryParse(txtDias.Text.Trim, XDias) Then
                XFechaVen = DateAdd(DateInterval.Day, XDias, dtpFecha.Value)
                dtpVencimiento.Value = XFechaVen
            End If

        End If
    End Sub
#End Region

#Region "Eventos"
    Private Sub cboTabdoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTabdoc.SelectedIndexChanged
        ConfiguraDoc()
        TipCPE()
    End Sub
    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscaClienteRapido()
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub rdbDocNumerico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDocNumerico.CheckedChanged
        TipCPE()
    End Sub

    Private Sub rbdDocElectronico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDocElectronico.CheckedChanged
        TipCPE()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        lblTipcam.Text = (GetTipCambio(dtpFecha.Value)).ToString("N2")
        GetIGV(dtpFecha.Value)
        GetICBPER(dtpFecha.Value, NothingToInteger(cboTabMon.SelectedValue))
        DiasVencimiento()
    End Sub

    Private Sub btnReniec_Click(sender As Object, e As EventArgs) Handles btnReniec.Click
        form_datclipro = ConsultaReniec(txtCodigo.Text.Trim)
        If Not IsNothing(form_datclipro) Then
            txtCodigo.Text = form_datclipro.CODIGO.ToString
            txtRazsoc.Text = form_datclipro.TRAZSOC
            txtDireccion.Text = form_datclipro.DIRECC
            lblNroDoc.Text = GetAbrevDoc(form_datclipro.TIPDOC) & "-" & form_datclipro.NRODOC
            VerificaCombo(cboTabVen, form_datclipro.CODVEN)
        End If
    End Sub

    Private Sub btnModCliente_Click(sender As Object, e As EventArgs) Handles btnModCliente.Click
        If txtCodigo.Text.Trim.Length = 0 Then
            MessageBox.Show("El cliente a consultar no existe !!", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        form_datclipro = ModCliente(txtCodigo.Text.Trim)
        If Not IsNothing(form_datclipro) Then
            txtCodigo.Text = form_datclipro.CODIGO.ToString
            txtRazsoc.Text = form_datclipro.TRAZSOC
            txtDireccion.Text = form_datclipro.DIRECC
            lblNroDoc.Text = GetAbrevDoc(form_datclipro.TIPDOC) & "-" & form_datclipro.NRODOC
            VerificaCombo(cboTabVen, form_datclipro.CODVEN)
        End If
    End Sub

    Private Sub btnAddCliente_Click(sender As Object, e As EventArgs) Handles btnAddCliente.Click
        form_datclipro = AddCliente()

        If Not IsNothing(form_datclipro) Then
            txtCodigo.Text = form_datclipro.CODIGO.ToString
            txtRazsoc.Text = form_datclipro.TRAZSOC
            txtDireccion.Text = form_datclipro.DIRECC
            lblNroDoc.Text = GetAbrevDoc(form_datclipro.TIPDOC) & "-" & form_datclipro.NRODOC
            VerificaCombo(cboTabVen, form_datclipro.CODVEN)
        End If
    End Sub

    Private Sub tlbMantenimiento_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles tlbMantenimiento.ButtonClick
        Dim rowindex As Integer
        Select Case tlbMantenimiento.Buttons.IndexOf(e.Button)
            'btnAgregar Fila
            Case 0
                rowindex = dbDetfac.HsAddRow(colitem.Index, True)
                dbDetfac.CurrentCell = dbDetfac.Rows(rowindex).Cells(colcodart.Index)
                Totales()
            Case 1
                If dbDetfac.CurrentRow Is Nothing Then Return
                If (MessageBox.Show("¿Seguro de Eliminar el Item " & dbDetfac.CurrentRow.Index + 1 & "?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    rowindex = dbDetfac.HsDeleteRow(colitem.Index, True)
                    If rowindex > 0 Then
                        dbDetfac.HsRow = rowindex
                        dbDetfac.CurrentCell = dbDetfac.Rows(rowindex).Cells(colcodart.Index)

                    End If
                    Totales()
                End If
            Case 2
            Case 3
            Case 4
            Case 5
        End Select
    End Sub
    ''' <summary>
    ''' Para añadir una fila a la grid cuando de enfoca a la grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dbDetfac_GotFocus(sender As Object, e As EventArgs) Handles dbDetfac.GotFocus
        If dbDetfac.Rows.Count = 0 Then
            Dim rowindex As Integer
            rowindex = dbDetfac.HsAddRow(colitem.Index, True)

            dbDetfac.CurrentCell = dbDetfac.Rows(rowindex).Cells(colcodart.Index)
        End If
    End Sub




    Private Sub dbDetfac_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dbDetfac.CellEndEdit
        Select Case e.ColumnIndex
            Case colcodart.Index
                Dim oSerie As New TABSER
                Dim oDetPrecios As TABART_SUCURSAL
                oSerie = TryCast(cboTabSerie.SelectedItem, TABSER)
                Dim codart As String = NothingToString(dbDetfac.CurrentRow.Cells(e.ColumnIndex).Value)
                If codart.Trim.Length = 0 Then
                    Return
                End If
                If codart.Trim.Length = 6 Then
                    dbDetfac.HsColRow(e.RowIndex, colcantid.Index)
                    Return
                End If
                form_datArti = GetArticulo(NothingToString(dbDetfac.CurrentRow.Cells(e.ColumnIndex).Value), oSerie.CODSUC, NothingToInteger(cboTabMon.SelectedValue))
                If Not IsNothing(form_datArti) Then
                    dbDetfac.CurrentRow.Cells(colcodart.Index).Value = form_datArti.CODART
                    dbDetfac.CurrentRow.Cells(colcodFab.Index).Value = form_datArti.CODFAB
                    dbDetfac.CurrentRow.Cells(colDescri.Index).Value = form_datArti.DESCRI
                    dbDetfac.CurrentRow.Cells(coluni.Index).Value = form_datArti
                    oDetPrecios = New TABART_SUCURSAL
                    oDetPrecios = form_datArti.LISTAPRECIOS.First()
                    dbDetfac.CurrentRow.Cells(coluni.Index).Value = oDetPrecios.CODUNI
                    dbDetfac.CurrentRow.Cells(coldesuni.Index).Value = oDetPrecios.DESUNI
                    dbDetfac.CurrentRow.Cells(colcantid.Index).Value = CANTID_DEFAULT
                    dbDetfac.CurrentRow.Cells(colPreLis.Index).Value = oDetPrecios.PRECIO_PUBLI
                    dbDetfac.CurrentRow.Cells(colPrecioUni.Index).Value = oDetPrecios.PRECIO_PUBLI
                    dbDetfac.CurrentRow.Cells(colDescto.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colNeto.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colDistri.Index).Value = oDetPrecios.PRECIO_DISTRI
                    dbDetfac.CurrentRow.Cells(colPremin.Index).Value = oDetPrecios.PRECIO_MIN
                    dbDetfac.CurrentRow.Cells(colcodAuto.Index).Value = 0
                    dbDetfac.CurrentRow.Cells(coldesAutorizado.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colSaldo.Index).Value = 0
                    dbDetfac.CurrentRow.Cells(colInafecto.Index).Value = form_datArti.AFECTO
                    dbDetfac.CurrentRow.Cells(colPorISC.Index).Value = form_datArti.ISC
                    dbDetfac.CurrentRow.Cells(colsticbper.Index).Value = form_datArti.STICBPER
                Else
                    dbDetfac.CurrentRow.Cells(colcodart.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colcodFab.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colDescri.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(coluni.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(coluni.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(coldesuni.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colcantid.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colPreLis.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colPrecioUni.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colDescto.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colNeto.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colDistri.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colPremin.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colcodAuto.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(coldesAutorizado.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colSaldo.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colInafecto.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colPorISC.Index).Value = ""
                    dbDetfac.CurrentRow.Cells(colsticbper.Index).Value = ""
                End If

                dbDetfac.HsColRow(e.RowIndex, colcantid.Index)
            Case colcantid.Index
                Totales()
            Case colPrecioUni.Index
                Totales()
            Case colDescto.Index, colNeto.Index
                Dim rowindex As Integer = 0
                Totales()
                If dbDetfac.Rows.Count = NothingToInteger(dbDetfac.Rows(e.RowIndex).Cells(colitem.Index).Value) Then
                    rowindex = dbDetfac.HsAddRow(colitem.Index, True)
                    dbDetfac.HsColRow(rowindex, colcodart.Index)
                Else
                    dbDetfac.HsColRow(e.RowIndex + 1, colcodart.Index)
                End If

        End Select

    End Sub



    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text.Trim.Length = 0 Then
            txtDireccion.Clear()
            txtRazsoc.Clear()
            txtDni.Clear()

        End If
    End Sub

    Private Sub cboTabMon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTabMon.SelectedIndexChanged

        If TypeOf cboTabMon.SelectedValue Is TABMON Then
            m_tipmon = TryCast(cboTabMon.SelectedItem, TABMON).COD
        Else
            m_tipmon = NothingToInteger(cboTabMon.SelectedValue)
        End If

        GetICBPER(dtpFecha.Value, m_tipmon)
        Totales()
    End Sub

    Private Sub txtDias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDias.KeyDown
        If e.KeyCode = Keys.Enter Then
            DiasVencimiento(False)
            SendKeys.Send("{tab}")
        End If
    End Sub


    Private Sub dtpVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles dtpVencimiento.ValueChanged
        DiasVencimiento()
    End Sub

    Private Sub txtNumpro1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumpro1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNumpro1.Text = txtNumpro1.Text.PadLeft(4, Convert.ToChar("0"))
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtNumpro2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumpro2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNumpro2.Text = txtNumpro2.Text.PadLeft(8, Convert.ToChar("0"))
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtNumdoc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumdoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNumdoc.Text = txtNumdoc.Text.PadLeft(8, Convert.ToChar("0"))
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cboTabSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTabSerie.SelectedIndexChanged

    End Sub
#End Region

End Class