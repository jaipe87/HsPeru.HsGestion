
Imports System.IO
Imports ClosedXML.Excel
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
    Public Function ExportarPDF(data As DataTable) As Byte()
        Dim doc As New Document(PageSize.A4)
        Using ms As New MemoryStream()
            Dim writer = PdfWriter.GetInstance(doc, ms)
            doc.Open()

            ' Agregar imagen (logo)
            Dim logo As Image = Image.GetInstance("C:\ruta\logo.png")
            logo.ScaleAbsolute(100, 50)
            doc.Add(logo)

            ' Título
            Dim titulo As New Paragraph("Reporte de Datos") With {.Alignment = Element.ALIGN_CENTER}
            doc.Add(titulo)

            ' Información de la empresa
            doc.Add(New Paragraph("Empresa: Mi Empresa"))
            doc.Add(New Paragraph("RUC: 123456789"))
            doc.Add(New Paragraph("Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")))
            doc.Add(New Paragraph(" "))

            ' Crear tabla PDF
            Dim table As New PdfPTable(data.Columns.Count)
            For Each col As DataColumn In data.Columns
                table.AddCell(New PdfPCell(New Phrase(col.ColumnName)))
            Next
            For Each row As DataRow In data.Rows
                For Each item In row.ItemArray
                    table.AddCell(New PdfPCell(New Phrase(item.ToString())))
                Next
            Next
            doc.Add(table)

            doc.Close()
            Return ms.ToArray()
        End Using
    End Function
End Class
