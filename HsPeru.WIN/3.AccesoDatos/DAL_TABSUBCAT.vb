Option Strict On
Imports System.Data.Odbc

Public Class DAL_TABSUBCAT
    Public Function Select_all_SubCategoria(ByVal objDato As SUBCATEGORIA) As List(Of SUBCATEGORIA)
        Dim listSubCategoria As New List(Of SUBCATEGORIA)()
        Dim dr As OdbcDataReader
        Dim datSubCategoria As SUBCATEGORIA
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tabsubcat.CIA, tabsubcat.COD, tabsubcat.DESCRI, tabsubcat.CODGRU, tabgru.des DESCAT, tabsubcat.ST FROM tabsubcat "
        Ssql = Ssql & " LEFT JOIN tabgru ON tabgru.COD=tabsubcat.CODGRU And tabsubcat.CIA=" & GCia & " "
        Ssql = Ssql & " WHERE tabsubcat.CIA=? And tabsubcat.DESCRI Like CONCAT('%',?,'%') AND tabsubcat.ST=?; "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cia", OdbcType.Int, 11).Value = GCia
            cmd.Parameters.Add("@criterio", OdbcType.VarChar, 30).Value = objDato.DESCAT
            cmd.Parameters.Add("@st", OdbcType.Int, 11).Value = objDato.ST
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datSubCategoria = New SUBCATEGORIA()
                    row = FetchAsoc(dr)
                    With datSubCategoria
                        .CIA = CType(row("CIA"), Integer)
                        .COD = CType(row("COD"), Integer)
                        .DESCRI = row("DESCRI")
                        .CODGRU = CType(row("CODGRU"), Integer)
                        .DESCAT = row("DESCAT")
                        .ST = CType(row("ST"), Integer)
                        .ESTADO = If(.ST = 0, ACTIVO, INACTIVO)
                    End With
                    listSubCategoria.Add(datSubCategoria)
                End While
            End If

            dr.Close()
        End Using
        Return listSubCategoria
    End Function

    Public Function Insert_SubCategoria(ByVal objDato As SUBCATEGORIA) As SUBCATEGORIA

        Dim datSubCategoria As New SUBCATEGORIA
        Dim Cod As Integer = 0
        If objDato.COD <> 0 Then
            Cod = objDato.COD
        Else
            Ssql = "SELECT IFNULL(MAX(cod),0) + 1  FROM tabsubcat WHERE cia= " & GCia & " ;"
            Using cmd As New OdbcCommand(Ssql, Cn)
                cmd.CommandType = CommandType.Text
                Cod = CType(cmd.ExecuteScalar(), Integer)
            End Using

        End If

        Ssql = "INSERT INTO tabsubcat (CIA, COD, DESCRI, CODGRU, ST) VALUES("
        Ssql = Ssql & GCia & "," & Cod & ",'" & objDato.DESCRI & "'," & objDato.CODGRU & "," & objDato.ST & ") "
        Ssql = Ssql & " ON DUPLICATE KEY UPDATE descri='" & objDato.DESCRI & "',CODGRU=" & objDato.CODGRU & ",ST=" & objDato.ST & ";"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.ExecuteNonQuery()
            objDato.COD = Cod
        End Using
        datSubCategoria = objDato
        Return datSubCategoria
    End Function
End Class
