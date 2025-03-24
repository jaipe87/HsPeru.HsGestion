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
            Dim rutaFinal As String = ObtenerRutaPDF(ruta)
            Using doc As New Document(PageSize.A4, 20, 20, 20, 20)
                PdfWriter.GetInstance(doc, New FileStream(rutaFinal, FileMode.Create))
                doc.Open()
                AgregarEncabezado(doc, "EMPRESA:   Hard System Perú S.A.C.", titulo)
                doc.Add(CrearTabla(lista, columnas))
                doc.Close()
            End Using
            AbrirArchivo(rutaFinal)

        Catch ex As Exception
            MostrarError("PDF", ex.Message)
        End Try
    End Sub

    Public Shared Sub GenerarExcel(Of T)(listaDatos As List(Of T), ruta As String, nombreHoja As String, columnas As Dictionary(Of String, Func(Of T, String)))
        Try
            Dim rutaFinal As String = ObtenerRutaExcel(ruta)
            Dim workbook As IWorkbook = New XSSFWorkbook()
            Dim sheet As ISheet = workbook.CreateSheet(nombreHoja)
            Dim style As ICellStyle = CrearEstilo(workbook)
            Dim styleBorde As ICellStyle = CrearBorde(workbook)

            AgregarInfoEncabezado(sheet, style, columnas.Count - 1)
            AgregarEncabezados(sheet, columnas.Keys.ToList(), styleBorde)
            AgregarDatos(sheet, listaDatos, columnas.Values.ToList())
            Using fs As New FileStream(rutaFinal, FileMode.Create, FileAccess.Write)
                workbook.Write(fs)
            End Using
            AbrirArchivo(rutaFinal)
        Catch ex As Exception
            MostrarError("Excel", ex.Message)
        End Try
    End Sub

    Private Shared Function ObtenerRutaPDF(baseRuta As String) As String
        Dim contador As Integer = 1
        Dim nuevaRuta As String = baseRuta
        While File.Exists(nuevaRuta)
            nuevaRuta = Path.Combine(Path.GetDirectoryName(baseRuta), $"{Path.GetFileNameWithoutExtension(baseRuta)}_{contador}.pdf")
            contador += 1
        End While
        Return nuevaRuta
    End Function
    Private Shared Function ObtenerRutaExcel(baseRuta As String) As String
        Dim contador As Integer = 1
        Dim nuevaRuta As String = baseRuta
        While File.Exists(nuevaRuta)
            nuevaRuta = Path.Combine(Path.GetDirectoryName(baseRuta), $"{Path.GetFileNameWithoutExtension(baseRuta)}_{contador}.xlsx")
            contador += 1
        End While
        Return nuevaRuta
    End Function

    'CON LOGO
    Private Shared Sub AgregarEncabezado(doc As Document, empresa As String, titulo As String)
        Try
            Dim rutaLogo As String = "C:\VBNET\HsPeru.HsGestion\HsPeru.WIN\Resources\logo.png"

            ' Logo
            Dim logo As Image = Image.GetInstance(rutaLogo)
            logo.ScaleToFit(80, 80)
            logo.Alignment = Image.ALIGN_LEFT

            Dim tablaEncabezado As New PdfPTable(1)
            tablaEncabezado.WidthPercentage = 100

            ' (Logo | Título | Fecha)
            Dim tablaInterna As New PdfPTable(3)
            tablaInterna.WidthPercentage = 100
            tablaInterna.SetWidths(New Single() {1, 2, 1})

            Dim celdaLogo As New PdfPCell(logo) With {
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        }
            tablaInterna.AddCell(celdaLogo)

            Dim celdaTitulo As New PdfPCell(New Phrase(titulo, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) With {
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .VerticalAlignment = Element.ALIGN_MIDDLE
        }
            tablaInterna.AddCell(celdaTitulo)

            Dim celdaFecha As New PdfPCell(New Phrase($"{DateTime.Now:dd/MM/yyyy HH:mm}",
                                    FontFactory.GetFont(FontFactory.HELVETICA, 10))) With {
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .VerticalAlignment = Element.ALIGN_TOP
        }
            tablaInterna.AddCell(celdaFecha)

            Dim celdaEncabezado As New PdfPCell(tablaInterna) With {
            .Border = Rectangle.NO_BORDER
        }
            tablaEncabezado.AddCell(celdaEncabezado)

            Dim infoEmpresa As New PdfPCell(New Phrase(vbCrLf & empresa & vbCrLf & vbCrLf & "RUC:             " & GRuc,
                                    FontFactory.GetFont(FontFactory.HELVETICA, 10))) With {
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .VerticalAlignment = Element.ALIGN_MIDDLE
        }
            tablaEncabezado.AddCell(infoEmpresa)
            doc.Add(tablaEncabezado)
            doc.Add(New Paragraph(" "))

        Catch ex As Exception
            MessageBox.Show("Error al agregar el encabezado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub






    'SIN LOGO
    'Private Shared Sub AgregarEncabezado(doc As Document, empresa As String, titulo As String)
    '    ' Fecha y hora
    '    doc.Add(New Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}  Hora: {DateTime.Now:HH:mm:ss}",
    '                      FontFactory.GetFont(FontFactory.HELVETICA, 10)) With {.Alignment = Element.ALIGN_RIGHT})

    '    doc.Add(New Paragraph(" "))
    '    doc.Add(New Paragraph(titulo, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)) With {.Alignment = Element.ALIGN_CENTER})
    '    doc.Add(New Paragraph(" "))

    '    doc.Add(New Paragraph("EMPRESA: Hard System Perú S.A.C.") With {.Alignment = Element.ALIGN_LEFT})
    '    doc.Add(New Paragraph("RUC: " & GRuc) With {.Alignment = Element.ALIGN_LEFT})
    '    doc.Add(New Paragraph(" ")) ' Espacio
    'End Sub

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
    Private Shared Function CrearBorde(workbook As IWorkbook) As ICellStyle
        Dim font As IFont = workbook.CreateFont()
        font.IsBold = True

        Dim styleBorde As ICellStyle = workbook.CreateCellStyle()
        styleBorde.SetFont(font)
        styleBorde.Alignment = HorizontalAlignment.Center

        styleBorde.BorderTop = BorderStyle.Thin
        styleBorde.BorderBottom = BorderStyle.Thin
        styleBorde.BorderLeft = BorderStyle.Thin
        styleBorde.BorderRight = BorderStyle.Thin
        Return styleBorde
    End Function

    Private Shared Sub AgregarInfoEncabezado(sheet As ISheet, style As ICellStyle, totalColumnas As Integer)
        Dim info As String() = {"Hard System Perú S.A.C.", $"Fecha: {DateTime.Now:yyyy-MM-dd} Hora: {DateTime.Now:HH:mm:ss}", "RUC: " & GRuc}
        For i = 0 To info.Length - 1
            Dim row As IRow = sheet.CreateRow(i)
            Dim cell As ICell = row.CreateCell(0)
            cell.SetCellValue(info(i))
            cell.CellStyle = style
            sheet.AddMergedRegion(New CellRangeAddress(i, i, 0, totalColumnas))
        Next
    End Sub

    Private Shared Sub AgregarEncabezados(sheet As ISheet, encabezados As List(Of String), styleBorde As ICellStyle)
        Dim row As IRow = sheet.CreateRow(4)
        For i = 0 To encabezados.Count - 1
            Dim cell As ICell = row.CreateCell(i)
            cell.SetCellValue(encabezados(i))
            cell.CellStyle = styleBorde
        Next
    End Sub

    Private Shared Sub AgregarDatos(Of T)(sheet As ISheet, lista As List(Of T), columnas As List(Of Func(Of T, String)))
        Dim workbook As IWorkbook = sheet.Workbook
        Dim styleBorde As ICellStyle = workbook.CreateCellStyle()

        ' Bordes 
        styleBorde.BorderTop = BorderStyle.Thin
        styleBorde.BorderBottom = BorderStyle.Thin
        styleBorde.BorderLeft = BorderStyle.Thin
        styleBorde.BorderRight = BorderStyle.Thin

        For rowIndex = 5 To lista.Count + 4
            Dim row As IRow = sheet.CreateRow(rowIndex)

            For colIndex = 0 To columnas.Count - 1
                Dim cell As ICell = row.CreateCell(colIndex)
                cell.SetCellValue(columnas(colIndex)(lista(rowIndex - 5)))
                cell.CellStyle = styleBorde
            Next
        Next

        ' Ancho
        For i = 0 To columnas.Count - 1
            sheet.AutoSizeColumn(i)
            If sheet.GetColumnWidth(i) < 4000 Then
                sheet.SetColumnWidth(i, 4000)
            End If
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
