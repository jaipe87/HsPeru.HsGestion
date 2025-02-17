Option Strict On
Imports System.Data.Odbc

Public Class DAL_MARCA
    Public Function Select_all_Marca(ByVal objDato As MARCA) As List(Of MARCA)
        Dim listMarca As New List(Of MARCA)()
        Dim dr As OdbcDataReader
        Dim datMarca As MARCA
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tabmar.CIA, tabmar.COD, tabmar.DES, tabmar.ST FROM tabmar "
        Ssql = Ssql & " WHERE tabmar.CIA=? And tabmar.DES Like CONCAT('%',?,'%') AND tabmar.ST=?;"


        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cia", OdbcType.Int, 11).Value = GCia
            cmd.Parameters.Add("@criterio", OdbcType.VarChar, 30).Value = objDato.DES
            cmd.Parameters.Add("@st", OdbcType.Int, 11).Value = objDato.ST
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datMarca = New MARCA()
                    row = FetchAsoc(dr)
                    With datMarca
                        .CIA = CType(row("CIA"), Integer)
                        .COD = CType(row("COD"), Integer)
                        .DES = row("DES")
                        .ST = CType(row("ST"), Integer)
                        .ESTADO = If(.ST = 0, ACTIVO, INACTIVO)
                    End With

                    listMarca.Add(datMarca)
                End While
            End If

            dr.Close()
        End Using
        Return listMarca
    End Function

    Public Function Insert_Marca(ByVal objDato As MARCA) As MARCA

        Dim datmarca As New MARCA
        Dim Cod As Integer = 0
        If objDato.COD <> 0 Then
            Cod = objDato.COD
        Else
            Ssql = "SELECT IFNULL(MAX(COD),0) + 1  FROM tabmar WHERE CIA= " & GCia & " ;"
            Using cmd As New OdbcCommand(Ssql, Cn)
                cmd.CommandType = CommandType.Text
                Cod = CType(cmd.ExecuteScalar(), Integer)
            End Using

        End If

        Ssql = "INSERT INTO tabmar (CIA, COD, DES, ST) VALUES ("
        Ssql = Ssql & GCia & "," & Cod & ",'" & objDato.DES & "'," & objDato.ST & ") "
        Ssql = Ssql & " ON DUPLICATE KEY UPDATE DES='" & objDato.DES & "',ST=" & objDato.ST & ";"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.ExecuteNonQuery()
            objDato.COD = Cod
        End Using
        datmarca = objDato
        Return datmarca
    End Function

End Class
