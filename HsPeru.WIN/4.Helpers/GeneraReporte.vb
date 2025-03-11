Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class GeneraReporte
    Private Shared ReadOnly negrita As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)

    Public Shared Sub GenerarPDF(Of T)(ByVal lista As List(Of T), ByVal ruta As String, ByVal titulo As String, ByVal columnas As Dictionary(Of String, Func(Of T, String)))
        Try
            Using doc As New Document(PageSize.A4, 10, 10, 10, 10)
                PdfWriter.GetInstance(doc, New FileStream(ruta, FileMode.Create))
                doc.Open()

                AgregarEncabezado(doc, "Hard System Perú S.A.C.", titulo)
                doc.Add(CrearTabla(lista, columnas))
                doc.Close()
            End Using

            MessageBox.Show($"PDF generado con éxito en: {ruta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Process.Start("explorer.exe", ruta)
        Catch ex As Exception
            MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Shared Sub AgregarEncabezado(ByVal doc As Document, ByVal empresa As String, ByVal titulo As String)
        doc.Add(New Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", FontFactory.GetFont(FontFactory.HELVETICA, 10)) With {.Alignment = Element.ALIGN_RIGHT})
        doc.Add(New Paragraph(empresa, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)) With {.Alignment = Element.ALIGN_CENTER})
        doc.Add(New Paragraph(" "))
        doc.Add(New Paragraph(titulo, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)) With {.Alignment = Element.ALIGN_CENTER})
        doc.Add(New Paragraph(" "))
    End Sub

    Private Shared Function CrearTabla(Of T)(ByVal lista As List(Of T), ByVal columnas As Dictionary(Of String, Func(Of T, String))) As PdfPTable
        Dim tabla As New PdfPTable(columnas.Count) With {.WidthPercentage = 100}
        tabla.SetWidths(Enumerable.Repeat(20, columnas.Count).ToArray())

        ' Encabezados
        For Each header In columnas.Keys
            tabla.AddCell(New PdfPCell(New Phrase(header, negrita)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .HorizontalAlignment = Element.ALIGN_CENTER})
        Next

        ' Datos
        For Each item In lista
            For Each column In columnas.Values
                tabla.AddCell(New PdfPCell(New Phrase(column(item))) With {.HorizontalAlignment = Element.ALIGN_CENTER})
            Next
        Next

        Return tabla
    End Function
    ' NO DEJA INSTALAR LA DEPENDENCIA DE CLOSEDXML
    'Public Sub GenerarExcel(Of T)(ByVal listaDatos As List(Of T), ByVal ruta As String, ByVal nombreHoja As String, ByVal columnas As Dictionary(Of String, Func(Of T, String)))
    '    Try
    '        Using wb As New XLWorkbook()
    '            Dim ws = wb.Worksheets.Add(nombreHoja)

    '            ' Encabezados
    '            Dim colIndex As Integer = 1
    '            For Each col In columnas.Keys
    '                ws.Cell(1, colIndex).Value = col
    '                ws.Cell(1, colIndex).Style.Font.Bold = True
    '                ws.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray
    '                colIndex += 1
    '            Next

    '            ' Datos
    '            Dim rowIndex As Integer = 2
    '            For Each item In listaDatos
    '                colIndex = 1
    '                For Each col In columnas.Values
    '                    ws.Cell(rowIndex, colIndex).Value = col(item)
    '                    colIndex += 1
    '                Next
    '                rowIndex += 1
    '            Next

    '            ' Tamaño de columnas
    '            ws.Columns().AdjustToContents()

    '            ' Guardar archivo
    '            wb.SaveAs(ruta)

    '            MessageBox.Show("Excel generado con éxito en: " & ruta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            Process.Start("explorer.exe", ruta)
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("Error al generar Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Class
