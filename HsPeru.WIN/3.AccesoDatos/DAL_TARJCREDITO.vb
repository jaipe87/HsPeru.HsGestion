Option Strict On
Imports System.Data.Odbc

Public Class DAL_TARJCREDITO
    Public Function Select_all_TarjCredito(ByVal objDato As TARJCREDITO) As List(Of TARJCREDITO)
        Dim listTarjCredito As New List(Of TARJCREDITO)()
        Dim dr As OdbcDataReader
        Dim datTarjCredito As TARJCREDITO
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tabtar.COD, tabtar.DES FROM tabtar "
        Ssql = Ssql & " WHERE tabtar.DES Like CONCAT('%',?,'%'); "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@criterio", OdbcType.VarChar, 30).Value = objDato.DES
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datTarjCredito = New TARJCREDITO()
                    row = FetchAsoc(dr)
                    With datTarjCredito
                        .COD = CType(row("COD"), Integer)
                        .DES = row("DES")
                    End With

                    listTarjCredito.Add(datTarjCredito)
                End While
            End If

            dr.Close()
        End Using
        Return listTarjCredito
    End Function

    Public Function Insert_TarjCredito(ByVal objDato As TARJCREDITO) As TARJCREDITO

        Dim datTarjCredito As New TARJCREDITO
        Dim Cod As Integer = 0
        If objDato.COD <> 0 Then
            Cod = objDato.COD
        Else
            Ssql = "SELECT IFNULL(MAX(cod),0) + 1  FROM tabtar ;"
            Using cmd As New OdbcCommand(Ssql, Cn)
                cmd.CommandType = CommandType.Text
                Cod = CType(cmd.ExecuteScalar(), Integer)
            End Using

        End If


        Ssql = "INSERT INTO tabtar (COD, DES) VALUES ( "
        Ssql = Ssql & Cod & ",'" & objDato.DES & "' ) "
        Ssql = Ssql & " ON DUPLICATE KEY UPDATE DES = '" & objDato.DES & "' ;"


        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.ExecuteNonQuery()
            objDato.COD = Cod
        End Using
        datTarjCredito = objDato
        Return datTarjCredito
    End Function
End Class
