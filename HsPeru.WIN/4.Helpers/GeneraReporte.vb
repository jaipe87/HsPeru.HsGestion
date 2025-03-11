Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
'NO DEJA DESCARGAR LAS DEPENDENCIAS!!!!
Public Class GeneraReporte
    'Public Function ExportarExcel(data As DataTable) As Byte()
    '    Using wb As New XLWorkbook()
    '        Dim ws = wb.Worksheets.Add("Reporte")
    '        ws.Cell(1, 1).Value = "Empresa: HARD SYSTEM PERU S.A.C."
    '        ws.Cell(2, 1).Value = "RUC: 123456789"
    '        ws.Cell(3, 1).Value = "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")
    '        ws.Cell(5, 1).InsertTable(data)
    '        Using ms As New MemoryStream()
    '            wb.SaveAs(ms)
    '            Return ms.ToArray()
    '        End Using
    '    End Using
    'End Function

    ' Exportar datos a PDF


    'Public Sub GenerarPDF(ByVal listaMarcas As List(Of MARCA))
    '    Try
    '        Dim ruta As String = "C:\Descargas\Marcas.pdf"
    '        Dim doc As New Document(PageSize.A4, 10, 10, 10, 10)
    '        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(ruta, FileMode.Create))

    '        doc.Open()

    '        ' Agregar título
    '        Dim titulo As New Paragraph("Lista de Marcas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
    '        titulo.Alignment = Element.ALIGN_CENTER
    '        doc.Add(titulo)
    '        doc.Add(New Paragraph(" "))

    '        ' Crear la tabla con 4 columnas
    '        Dim tabla As New PdfPTable(4)
    '        tabla.WidthPercentage = 100 ' Ocupar el 100% del ancho de la página
    '        tabla.SetWidths(New Single() {10, 10, 50, 20}) ' Ajustar tamaños de columnas

    '        ' Agregar encabezados
    '        Dim negrita As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)
    '        tabla.AddCell(New PdfPCell(New Phrase("CIA", negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})
    '        tabla.AddCell(New PdfPCell(New Phrase("COD", negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})
    '        tabla.AddCell(New PdfPCell(New Phrase("DES", negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})
    '        tabla.AddCell(New PdfPCell(New Phrase("ESTADO", negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})

    '        ' Llenar la tabla con datos
    '        For Each marca As MARCA In listaMarcas
    '            tabla.AddCell(New PdfPCell(New Phrase(marca.CIA.ToString())) With {.HorizontalAlignment = Element.ALIGN_CENTER})
    '            tabla.AddCell(New PdfPCell(New Phrase(marca.COD.ToString())) With {.HorizontalAlignment = Element.ALIGN_CENTER})
    '            tabla.AddCell(New PdfPCell(New Phrase(marca.DES)) With {.HorizontalAlignment = Element.ALIGN_LEFT})
    '            tabla.AddCell(New PdfPCell(New Phrase(marca.ESTADO)) With {.HorizontalAlignment = Element.ALIGN_CENTER})
    '        Next

    '        doc.Add(tabla)
    '        doc.Close()

    '        MessageBox.Show("PDF generado con éxito en: " & ruta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        ' Abrir el PDF automáticamente
    '        Process.Start("explorer.exe", ruta)
    '    Catch ex As Exception
    '        MessageBox.Show("Error al generar PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Class
