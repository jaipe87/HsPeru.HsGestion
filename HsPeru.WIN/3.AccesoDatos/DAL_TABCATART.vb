Option Strict On
Imports System.Data.Odbc

Public Class DAL_TABCATART
    Public Function Select_all_Categoria(ByVal objDato As CATEGORIA) As List(Of CATEGORIA)
        Dim listCategoria As New List(Of CATEGORIA)()
        Dim dr As OdbcDataReader
        Dim datCategoria As CATEGORIA
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tabgru.CIA, tabgru.COD, tabgru.DES, tabgru.STOCK, tabgru.ST FROM tabgru "
        Ssql = Ssql & " WHERE tabgru.CIA=? And tabgru.DES Like CONCAT('%',?,'%') AND tabgru.ST=?; "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cia", OdbcType.Int, 11).Value = GCia
            cmd.Parameters.Add("@criterio", OdbcType.VarChar, 30).Value = objDato.DES
            cmd.Parameters.Add("@st", OdbcType.Int, 11).Value = objDato.ST
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datCategoria = New CATEGORIA()
                    row = FetchAsoc(dr)
                    With datCategoria
                        .CIA = CType(row("CIA"), Integer)
                        .COD = CType(row("COD"), Integer)
                        .DES = row("DES")
                        .STOCK = row("STOCK")
                        .ST = CType(row("ST"), Integer)
                        .ESTADO = If(.ST = 0, ACTIVO, INACTIVO)
                    End With

                    listCategoria.Add(datCategoria)
                End While
            End If

            dr.Close()
        End Using
        Return listCategoria
    End Function

    Public Function Insert_Categoria(ByVal objDato As CATEGORIA) As CATEGORIA

        Dim datcategoria As New CATEGORIA
        Dim Cod As Integer = 0
        If objDato.COD <> 0 Then
            Cod = objDato.COD
        Else
            Ssql = "SELECT IFNULL(MAX(cod),0) + 1  FROM tabgru WHERE cia= " & GCia & " ;"
            Using cmd As New OdbcCommand(Ssql, Cn)
                cmd.CommandType = CommandType.Text
                Cod = CType(cmd.ExecuteScalar(), Integer)
            End Using

        End If

        Ssql = "INSERT INTO tabgru (CIA, COD, DES, STOCK, ST) VALUES ("
        Ssql = Ssql & GCia & "," & Cod & ",'" & objDato.DES & "','" & objDato.STOCK & "'," & objDato.ST & ") "
        Ssql = Ssql & " ON DUPLICATE KEY UPDATE DES='" & objDato.DES & "',STOCK='" & objDato.STOCK & "',ST=" & objDato.ST & ";"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.ExecuteNonQuery()
            objDato.COD = Cod
        End Using
        datcategoria = objDato
        Return datcategoria
    End Function
End Class
