Option Strict On
Imports System.Data.Odbc

Public Class DAL_TABBANCO
    Public Function Select_all_Banco(ByVal objDato As TABBANCO) As List(Of TABBANCO)
        Dim listBanco As New List(Of TABBANCO)()
        Dim dr As OdbcDataReader
        Dim datBanco As TABBANCO
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tabban.CIA, tabban.COD, tabban.DES, tabban.TIPMON, tabmon.DES DESMON, tabban.NROCTA, tabban.FUNCIO, tabban.ST FROM tabban "
        Ssql = Ssql & " LEFT JOIN tabmon ON tabmon.COD=tabban.TIPMON And tabban.CIA=" & GCia & " "
        Ssql = Ssql & " WHERE tabban.CIA=? And tabban.DES Like CONCAT('%',?,'%') AND tabban.ST=?; "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cia", OdbcType.Int, 11).Value = GCia
            cmd.Parameters.Add("@criterio", OdbcType.VarChar, 30).Value = objDato.DES
            cmd.Parameters.Add("@st", OdbcType.Int, 11).Value = objDato.ST
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datBanco = New TABBANCO()
                    row = FetchAsoc(dr)
                    With datBanco
                        .CIA = CType(row("CIA"), Integer)
                        .COD = CType(row("COD"), Integer)
                        .DES = row("DES")
                        .NROCTA = row("NROCTA")
                        .TIPMON = CType(row("TIPMON"), Integer)
                        .FUNCIO = row("FUNCIO")
                        .ST = CType(row("ST"), Integer)
                        .ESTADO = If(.ST = 0, ACTIVO, INACTIVO)
                        .ESTADO_TIPMON = If(.TIPMON = 1, SOLES, DOLARES)
                    End With

                    listBanco.Add(datBanco)
                End While
            End If

            dr.Close()
        End Using
        Return listBanco
    End Function
End Class
