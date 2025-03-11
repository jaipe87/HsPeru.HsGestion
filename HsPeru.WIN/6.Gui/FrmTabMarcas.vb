Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FrmTabMarcas
    Dim oMarca As DAL_MARCA
    Dim datMarca As MARCA, parMarca As MARCA
    Dim lstMarca As New List(Of MARCA)
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        utbMarca.Tabs(0).Selected = True
        utbMarca.Tabs(0).Enabled = True
        utbMarca.Tabs(1).Enabled = False
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

    End Sub


    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click
        oMarca = New DAL_MARCA
        Dim listaMarcas As List(Of MARCA) = oMarca.Select_all_Marca(New MARCA)

        ' Verificar si la lista tiene elementos
        If listaMarcas Is Nothing OrElse listaMarcas.Count = 0 Then
            MessageBox.Show("No hay datos para generar el PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        GenerarPDF(listaMarcas)
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
    Private Sub DgvMarca_SelectionChanged(sender As Object, e As EventArgs) Handles DgvMarca.SelectionChanged
        SeleccionarRow()
    End Sub

    Private Sub DgvMarca_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMarca.CellDoubleClick
        Modificar()
    End Sub
#End Region

#Region "Métodos"
    Sub SeleccionarRow()
        Dim xCod As Integer = 0
        datMarca = New MARCA
        xCod = NothingToInteger(DgvMarca.CurrentRow.Cells(colcod.Index).Value)

        If lstMarca.Where(Function(x) x.COD = xCod).Count > 0 Then
            datMarca = lstMarca.Where(Function(x) x.COD = xCod).First
        End If


    End Sub
    Sub Inicia()
        oMarca = New DAL_MARCA
        lstMarca = oMarca.Select_all_Marca(New MARCA)
        DgvMarca.AutoGenerateColumns = False
        DgvMarca.DataSource = lstMarca
        utbMarca.Tabs(0).Selected = True
        utbMarca.Tabs(1).Enabled = False
    End Sub

    Sub Nuevo()
        utbMarca.Tabs(0).Enabled = False
        utbMarca.Tabs(1).Selected = True
        utbMarca.Tabs(1).Enabled = True
        lblCodigo.Text = "?"
        txtDes.Text = ""
        txtDes.Focus()
        chkActivo.Checked = False
        chkInactivo.Checked = False
    End Sub

    Sub Modificar()

        If Not IsNothing(datMarca) Then
            lblCodigo.Text = datMarca.COD.ToString
            txtDes.Text = datMarca.DES
            chkActivo.Checked = (datMarca.ST = 0)
            chkInactivo.Checked = (datMarca.ST = 1)
            utbMarca.Tabs(0).Enabled = False
            utbMarca.Tabs(1).Selected = True
            utbMarca.Tabs(1).Enabled = True
        End If

    End Sub

    Private Sub DgvMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvMarca.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Modificar()
        End If
    End Sub

    Private Sub FrmTabMarca_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SeleccionarRow()
    End Sub

    Sub Graba()
        If MessageBox.Show("¿Seguro de Grabar el Registro?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        If txtDes.Text.Trim.Length = 0 Then MessageBox.Show("Ingrese el nombre del vendedor", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information) : Return

        oMarca = New DAL_MARCA
        datMarca = New MARCA
        parMarca = New MARCA

        With parMarca
            .CIA = GCia
            .COD = CInt(Val(lblCodigo.Text))
            .DES = txtDes.Text.Trim
            .ST = If(chkActivo.Checked, 0, 1)
        End With
        datMarca = oMarca.Insert_Marca(parMarca)

        If Not IsNothing(datMarca) Then
            MessageBox.Show("Registro existoso del vendedor con código " & datMarca.COD, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            utbMarca.Tabs(0).Selected = True
            utbMarca.Tabs(0).Enabled = True
            utbMarca.Tabs(1).Enabled = False
        Else
            MessageBox.Show("No se pudo completar el registro", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Public Sub GenerarPDF(ByVal listaMarcas As List(Of MARCA))
        Try
            Dim ruta As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Marcas.pdf"

            Dim doc As New Document(PageSize.A4, 10, 10, 10, 10)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(ruta, FileMode.Create))

            doc.Open()

            ' Agregar la fecha y hora actual
            Dim fechaHora As New Paragraph("Fecha: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), FontFactory.GetFont(FontFactory.HELVETICA, 10))
            fechaHora.Alignment = Element.ALIGN_RIGHT
            doc.Add(fechaHora)

            Dim empresa As New Paragraph("Hard System Perú S.A.C.", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))
            empresa.Alignment = Element.ALIGN_CENTER
            doc.Add(empresa)
            doc.Add(New Paragraph(" "))

            ' Agregar título
            Dim titulo As New Paragraph("Lista de Marcas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
            titulo.Alignment = Element.ALIGN_CENTER
            doc.Add(titulo)
            doc.Add(New Paragraph(" "))


            doc.Add(New Paragraph(" "))

            ' Crear la tabla con 4 columnas
            Dim tabla As New PdfPTable(4)
            tabla.WidthPercentage = 100 ' Ocupar el 100% del ancho de la página
            tabla.SetWidths(New Single() {10, 10, 50, 20}) ' Ajustar tamaños de columnas

            ' Agregar encabezados
            Dim negrita As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)
            tabla.AddCell(New PdfPCell(New Phrase("CIA", negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})
            tabla.AddCell(New PdfPCell(New Phrase("COD", negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})
            tabla.AddCell(New PdfPCell(New Phrase("DES", negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})
            tabla.AddCell(New PdfPCell(New Phrase("ESTADO", negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})

            ' Llenar la tabla con datos
            For Each datMarca In listaMarcas
                tabla.AddCell(New PdfPCell(New Phrase(datMarca.CIA.ToString())) With {.HorizontalAlignment = Element.ALIGN_CENTER})
                tabla.AddCell(New PdfPCell(New Phrase(datMarca.COD.ToString())) With {.HorizontalAlignment = Element.ALIGN_CENTER})
                tabla.AddCell(New PdfPCell(New Phrase(If(datMarca.DES Is Nothing, "", datMarca.DES.ToString()))) With {.HorizontalAlignment = Element.ALIGN_LEFT})
                tabla.AddCell(New PdfPCell(New Phrase(If(datMarca.ESTADO Is Nothing, "", datMarca.ESTADO.ToString()))) With {.HorizontalAlignment = Element.ALIGN_CENTER})

            Next


            doc.Add(tabla)
            doc.Close()

            MessageBox.Show("PDF generado con éxito en: " & ruta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Abrir el PDF automáticamente
            Process.Start("explorer.exe", ruta)
        Catch ex As Exception
            MessageBox.Show("Error al generar PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class