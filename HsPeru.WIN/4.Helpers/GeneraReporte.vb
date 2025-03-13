Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Diagnostics
Imports NPOI.SS.UserModel
Imports NPOI.XSSF.UserModel
Imports NPOI.SS.Util

Public Class GeneraReporte
    Private Shared ReadOnly negrita As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)

    Public Shared Sub GenerarPDF(Of T)(lista As List(Of T), ruta As String, titulo As String, columnas As Dictionary(Of String, Func(Of T, String)))
        Try
            Using doc As New Document(PageSize.A4, 10, 10, 10, 10)
                PdfWriter.GetInstance(doc, New FileStream(ruta, FileMode.Create))
                doc.Open()
                AgregarEncabezado(doc, "Hard System Perú S.A.C.", titulo)
                doc.Add(CrearTabla(lista, columnas))
                doc.Close()
            End Using
            AbrirArchivo(ruta)
        Catch ex As Exception
            MostrarError("PDF", ex.Message)
        End Try
    End Sub

    Public Shared Sub GenerarExcel(Of T)(listaDatos As List(Of T), ruta As String, nombreHoja As String, columnas As Dictionary(Of String, Func(Of T, String)))
        Try
            Dim workbook As IWorkbook = New XSSFWorkbook()
            Dim sheet As ISheet = workbook.CreateSheet(nombreHoja)
            Dim style As ICellStyle = CrearEstilo(workbook)

            AgregarInfoEncabezado(sheet, style, columnas.Count - 1)
            AgregarEncabezados(sheet, columnas.Keys.ToList(), style)
            AgregarDatos(sheet, listaDatos, columnas.Values.ToList())
            Using fs As New FileStream(ruta, FileMode.Create, FileAccess.Write)
                workbook.Write(fs)
            End Using
            AbrirArchivo(ruta)
        Catch ex As Exception
            MostrarError("Excel", ex.Message)
        End Try
    End Sub

    Private Shared Sub AgregarEncabezado(doc As Document, empresa As String, titulo As String)
        doc.Add(New Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}  Hora: {DateTime.Now:HH:mm:ss}", FontFactory.GetFont(FontFactory.HELVETICA, 10)) With {.Alignment = Element.ALIGN_RIGHT})
        doc.Add(New Paragraph(empresa, negrita) With {.Alignment = Element.ALIGN_CENTER})
        doc.Add(New Paragraph(" "))
        doc.Add(New Paragraph(titulo, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)) With {.Alignment = Element.ALIGN_CENTER})
        doc.Add(New Paragraph(" "))
    End Sub

    Private Shared Function CrearTabla(Of T)(lista As List(Of T), columnas As Dictionary(Of String, Func(Of T, String))) As PdfPTable
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

    Private Shared Function CrearEstilo(workbook As IWorkbook) As ICellStyle
        Dim font As IFont = workbook.CreateFont()
        font.IsBold = True
        Dim style As ICellStyle = workbook.CreateCellStyle()
        style.SetFont(font)
        style.Alignment = HorizontalAlignment.Center
        Return style
    End Function

    Private Shared Sub AgregarInfoEncabezado(sheet As ISheet, style As ICellStyle, totalColumnas As Integer)
        Dim info As String() = {"Hard System Perú S.A.C.", $"Fecha: {DateTime.Now:yyyy-MM-dd}", $"Hora: {DateTime.Now:HH:mm:ss}", "Generado por: " & GDesCia}
        For i = 0 To info.Length - 1
            Dim row As IRow = sheet.CreateRow(i)
            Dim cell As ICell = row.CreateCell(0)
            cell.SetCellValue(info(i))
            cell.CellStyle = style
            sheet.AddMergedRegion(New CellRangeAddress(i, i, 0, totalColumnas))
        Next
    End Sub

    Private Shared Sub AgregarEncabezados(sheet As ISheet, encabezados As List(Of String), style As ICellStyle)
        Dim row As IRow = sheet.CreateRow(4)
        For i = 0 To encabezados.Count - 1
            Dim cell As ICell = row.CreateCell(i)
            cell.SetCellValue(encabezados(i))
            cell.CellStyle = style
        Next
    End Sub

    Private Shared Sub AgregarDatos(Of T)(sheet As ISheet, lista As List(Of T), columnas As List(Of Func(Of T, String)))
        For rowIndex = 5 To lista.Count + 4
            Dim row As IRow = sheet.CreateRow(rowIndex)
            For colIndex = 0 To columnas.Count - 1
                row.CreateCell(colIndex).SetCellValue(columnas(colIndex)(lista(rowIndex - 5)))
            Next
        Next
        For i = 0 To columnas.Count - 1
            sheet.AutoSizeColumn(i)
        Next
    End Sub

    Private Shared Sub AbrirArchivo(ruta As String)
        MessageBox.Show($"Archivo generado con éxito en: {ruta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Process.Start("explorer.exe", "/select," & ruta)
    End Sub

    Private Shared Sub MostrarError(tipo As String, mensaje As String)
        MessageBox.Show($"Error al generar {tipo}: {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class
