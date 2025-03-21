Option Strict On
Imports System.Data.Odbc

Public Class DAL_PORCIGV
    Public Function Select_all_PorcIgv(ByVal objDato As PORCIGV) As List(Of PORCIGV)
        Dim listPorc As New List(Of PORCIGV)()
        Dim dr As OdbcDataReader
        Dim datPorc As PORCIGV
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tg_igv.VIGENCIA, tg_igv.PORC FROM tg_igv ORDER BY tg_igv.VIGENCIA ASC;"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datPorc = New PORCIGV()
                    row = FetchAsoc(dr)
                    With datPorc
                        .VIGENCIA = CType(row("VIGENCIA"), Date).Date
                        .PORC = CType(row("PORC"), Double)
                        .COD = CInt(CType(row("VIGENCIA"), Date).ToString("yyyyMMdd"))
                    End With
                    listPorc.Add(datPorc)
                End While
            End If

            dr.Close()
        End Using
        Return listPorc
    End Function

    Public Function Insert_PorcIgv(ByVal objDato As PORCIGV) As PORCIGV

        Dim datPorc As New PORCIGV
        Dim Cod As Integer = 0
        If objDato.COD <> 0 Then
            Cod = objDato.COD
        Else
            Ssql = "SELECT COUNT(*) + 1 FROM tg_igv ;"
            Using cmd As New OdbcCommand(Ssql, Cn)
                cmd.CommandType = CommandType.Text
                Cod = CType(cmd.ExecuteScalar(), Integer)
            End Using
        End If

        Ssql = "INSERT INTO tg_igv (VIGENCIA, PORC) VALUES ("
        Ssql &= "'" & objDato.VIGENCIA.ToString("yyyy-MM-dd") & "', " & objDato.PORC & ") "
        Ssql &= "ON DUPLICATE KEY UPDATE PORC=" & objDato.PORC & ";"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.ExecuteNonQuery()
        End Using
        datPorc = objDato
        Return datPorc
    End Function
End Class