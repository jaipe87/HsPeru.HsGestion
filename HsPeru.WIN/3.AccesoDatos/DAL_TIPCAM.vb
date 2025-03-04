Option Strict On
Imports System.Data.Odbc


Public Class DAL_TIPCAM

    Public Function Select_all_Tipcam(ByVal objDato As TIPCAM) As List(Of TIPCAM)
        Dim listTipcam As New List(Of TIPCAM)()
        Dim dr As OdbcDataReader
        Dim datTipcam As TIPCAM
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tabcam.CIA, tabcam.FECHA, tabcam.COMPRA, tabcam.VENTA, tabcam.PARALE, tabcam.ST, tabcam.ST2, tabcam.ST3 FROM tabcam "
        Ssql = Ssql & " WHERE tabcam.CIA=? And YEAR(tabcam.FECHA) = ?; "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cia", OdbcType.Int, 11).Value = GCia
            cmd.Parameters.Add("@criterio", OdbcType.VarChar, 30).Value = objDato.FECHA.Year
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datTipcam = New TIPCAM()
                    row = FetchAsoc(dr)
                    With datTipcam
                        .CIA = CType(row("CIA"), Integer)
                        .COMPRA = CType(row("COMPRA"), Double)
                        .FECHA = CType(row("FECHA"), Date).Date
                        .VENTA = CType(row("VENTA"), Double)
                        .PARALE = CType(row("PARALE"), Double)
                        .ST = CType(row("ST"), Integer)
                        .ST2 = CType(row("ST2"), Integer)
                        .ST3 = CType(row("ST3"), Integer)
                        .ESTADO = If(.ST = 0, ABIERTO, CERRADO)
                        .ESTADO2 = If(.ST2 = 0, ABIERTO, CERRADO)
                        .ESTADO3 = If(.ST3 = 0, ABIERTO, CERRADO)
                        .COD = CInt(CType(row("FECHA"), Date).ToString("yyyyMMdd"))
                    End With

                    listTipcam.Add(datTipcam)
                End While
            End If

            dr.Close()
        End Using
        Return listTipcam
    End Function


    'Public Function Insert_TipCambio(ByVal objDato As TIPCAM) As TIPCAM

    '    Dim datTipCam As New TIPCAM
    '    Dim Cod As Integer = 0
    '    If objDato.COD <> 0 Then
    '        Cod = objDato.COD
    '    Else
    '        Ssql = "SELECT IFNULL(MAX(COD),0) + 1  FROM tabcam WHERE CIA= " & GCia & " ;"
    '        Using cmd As New OdbcCommand(Ssql, Cn)
    '            cmd.CommandType = CommandType.Text
    '            Cod = CType(cmd.ExecuteScalar(), Integer)
    '        End Using

    '    End If

    '    Ssql = "INSERT INTO tabcam (CIA, FECHA, COMPRA, VENTA, PARALE, ST) VALUES ("
    '    Ssql = Ssql & GCia & "," & "," & objDato.FECHA & "," & objDato.COMPRA & "," & objDato.VENTA & "," & objDato.PARALE & "," & objDato.ST & ") "
    '    Ssql = Ssql & " ON DUPLICATE KEY UPDATE FECHA =" & objDato.FECHA & ", COMPRA =" & objDato.COMPRA & ", VENTA =" & objDato.VENTA & ", PARALE =" & objDato.PARALE & ",ST=" & objDato.ST & ";"

    '    Using cmd As New OdbcCommand(Ssql, Cn)
    '        cmd.ExecuteNonQuery()
    '        objDato.COD = Cod
    '    End Using
    '    datTipCam = objDato
    '    Return datTipCam
    'End Function

    Public Function Insert_TipCambio(ByVal objDato As TIPCAM) As TIPCAM

        Dim datTipCam As New TIPCAM
        Dim Cod As Integer = 0
        If objDato.COD <> 0 Then
            Cod = objDato.COD
        Else
            Ssql = "SELECT COUNT(*) + 1 FROM tabcam WHERE cia = " & GCia & ";"
            Using cmd As New OdbcCommand(Ssql, Cn)
                cmd.CommandType = CommandType.Text
                Cod = CType(cmd.ExecuteScalar(), Integer)
            End Using

        End If

        Ssql = "INSERT INTO tabcam (CIA, FECHA, COMPRA, VENTA, PARALE, ST) VALUES ("
        Ssql = Ssql & GCia & ", '" & objDato.FECHA.ToString("yyyy-MM-dd") & "', " & objDato.COMPRA & ", " & objDato.VENTA & ", " & objDato.PARALE & ", " & objDato.ST & ") "
        Ssql = Ssql & "ON DUPLICATE KEY UPDATE FECHA = '" & objDato.FECHA.ToString("yyyy-MM-dd") & "', COMPRA = " & objDato.COMPRA & ", VENTA = " & objDato.VENTA & ", PARALE = " & objDato.PARALE & ", ST = " & objDato.ST & ";"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
        End Using

        datTipCam = objDato
        Return datTipCam

    End Function
    Public Function Update_TipCambio(ByVal objDato As TIPCAM, ByVal campo As String, ByVal nuevoEstado As Integer) As Boolean
        Dim resultado As Integer
        Dim Ssql As String = "UPDATE tabcam SET " & campo & " = ? WHERE CIA = ? AND FECHA = ?"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.Parameters.Add("?", OdbcType.Int).Value = nuevoEstado
            cmd.Parameters.Add("?", OdbcType.Int).Value = objDato.CIA
            cmd.Parameters.Add("?", OdbcType.Date).Value = objDato.FECHA

            resultado = cmd.ExecuteNonQuery()
        End Using

        Return resultado > 0 ' Devuelve True si se actualizó al menos una fila
    End Function



    'Public Function Insert_BloqTipCambio(ByVal objDato As TIPCAM) As TIPCAM

    '    Dim datTipCam As New TIPCAM

    '    Ssql = "INSERT INTO tabcam (CIA, ST, ST2, ST3) VALUES ("
    '    Ssql = Ssql & GCia & ", '" & objDato.ST & "', " & objDato.ST2 & ", " & objDato.ST3 & ") "
    '    Ssql = Ssql & "ON DUPLICATE KEY UPDATE ST = " & objDato.ST & ", ST2 = " & objDato.ST2 & ", ST3 = " & objDato.ST3 & ";"

    '    Using cmd As New OdbcCommand(Ssql, Cn)
    '        cmd.CommandType = CommandType.Text
    '        cmd.ExecuteNonQuery()
    '    End Using

    '    datTipCam = objDato
    '    Return datTipCam

    'End Function


    'Public Function Insert_BloqCobranzas_TipCambio(ByVal objDato As TIPCAM) As TIPCAM
    '    Dim datTipCam As New TIPCAM

    '    Ssql = "INSERT INTO tabcam (CIA, ST2) VALUES ("
    '    Ssql = Ssql & GCia & ", " & objDato.ST2 & ") "
    '    Ssql = Ssql & "ON DUPLICATE KEY UPDATE ST2 = " & objDato.ST2 & ";"

    '    Using cmd As New OdbcCommand(Ssql, Cn)
    '        cmd.CommandType = CommandType.Text
    '        cmd.ExecuteNonQuery()
    '    End Using

    '    datTipCam = objDato
    '    Return datTipCam
    'End Function

    'Public Function Insert_BloqCobranzas_TipCambio(ByVal objDato As TIPCAM) As TIPCAM
    '    Dim datTipCam As New TIPCAM
    '    Dim Cod As Integer = 0
    '    If objDato.COD <> 0 Then
    '        Cod = objDato.COD
    '    Else
    '        Ssql = "SELECT COUNT(*) + 1 FROM tabcam WHERE cia = " & GCia & ";"
    '        Using cmd As New OdbcCommand(Ssql, Cn)
    '            cmd.CommandType = CommandType.Text
    '            Cod = CType(cmd.ExecuteScalar(), Integer)
    '        End Using

    '    End If
    '    'Ssql = "INSERT INTO tabcam (CIA, ST2) VALUES ( " & GCia & ", " & objDato.ST2 & " ) " &
    '    '   "ON DUPLICATE KEY UPDATE ST2 = " & objDato.ST2 & ";"
    '    Ssql = "UPDATE tabcam " & "SET ST2 = " & objDato.ST2 & " WHERE CIA = " & GCia & " AND FECHA = '" & objDato.FECHA & "';"

    '    Try
    '        Using cmd As New OdbcCommand(Ssql, Cn)
    '            cmd.CommandType = CommandType.Text
    '            cmd.ExecuteNonQuery()
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("Error en la consulta SQL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return Nothing
    '    End Try

    '    datTipCam = objDato
    '    Return datTipCam
    'End Function





    '===================================================0
    'CÓDIGO ANTERIOR


    ''' ============================= CÓDIGO ANTERIOR ==================================
    Public Function Insert_Tipcam(ByVal objDato As TIPCAM) As Boolean
        Dim datTipCam As New TIPCAM
        Dim ind As Boolean = False
        Ssql = "REPLACE INTO tabcam(CIA,FECHA,COMPRA,VENTA,PARALE)VALUES(" & GCia & ",'" & objDato.FECHA.ToString("yyyy-MM-dd") & "',"
        Ssql = Ssql & objDato.COMPRA & "," & objDato.VENTA & "," & objDato.PARALE & ");"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            ind = (cmd.ExecuteNonQuery() > 0)
            Return ind
        End Using
    End Function


    Public Function Select_TipCam_ultimo() As TIPCAM

        Dim dr As OdbcDataReader
        Dim row As Dictionary(Of String, String)
        Dim datTipCam As New TIPCAM

        Ssql = "SELECT  FECHA, COMPRA, VENTA, PARALE FROM tabcam order by fecha desc limit 1;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                row = FetchAsoc(dr)
                datTipCam.FECHA = CType(row("FECHA"), Date)
                datTipCam.COMPRA = CType(row("COMPRA"), Double)
                datTipCam.VENTA = CType(row("VENTA"), Double)
                datTipCam.PARALE = CType(row("PARALE"), Double)

            End If
            dr.Close()
        End Using
        Return datTipCam
    End Function





    Public Function Select_TipCam(ByVal objDato As TIPCAM) As TIPCAM

        Dim dr As OdbcDataReader
        Dim row As Dictionary(Of String, String)
        Dim datTipCam As New TIPCAM

        Ssql = "SELECT  FECHA, COMPRA, VENTA, PARALE FROM tabcam WHERE fecha=?;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@fecha", objDato.FECHA.ToString("yyyy-MM-dd"))
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                row = FetchAsoc(dr)
                datTipCam.FECHA = CType(row("FECHA"), Date)
                datTipCam.COMPRA = CType(row("COMPRA"), Double)
                datTipCam.VENTA = CType(row("VENTA"), Double)
                datTipCam.PARALE = CType(row("PARALE"), Double)

            End If
            dr.Close()
        End Using
        Return datTipCam
    End Function
End Class
