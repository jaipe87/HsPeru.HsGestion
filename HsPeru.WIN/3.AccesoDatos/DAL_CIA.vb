Option Strict On
Imports System.Data
Imports System.Data.Odbc


Public Class DAL_CIA
    Public Function SelectAll_Cia(ByVal objDato As CIA) As List(Of CIA)
        Dim listCia As New List(Of CIA)()
        Dim dr As OdbcDataReader
        Dim datcia As CIA
        Dim row As Dictionary(Of String, String)

        Ssql = "SELECT CIA,DES,RUC,ST,DIRECCION,UBIGEO,CODIGO,CTADET,MONTOBOL FROM tabcia where st=0"
        If GCia > 0 Then
            ssql = ssql & " AND cia=" & objDato.CIA
        End If
        Using cmd As New OdbcCommand(ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datcia = New CIA()
                    row = FetchAsoc(dr)
                    datcia.CIA = CType(row("CIA"), Integer)
                    datcia.DES = row("DES")
                    datcia.RUC = row("RUC")
                    datcia.ST = CType(row("ST"), Integer)
                    datcia.DIRECCION = row("DIRECCION")
                    datcia.UBIGEO = row("UBIGEO")
                    datcia.CODIGO = CType(row("CODIGO"), Integer)
                    datcia.CTADET = row("CTADET")
                    datcia.MONTOBOLETA = CType(row("MONTOBOL"), Decimal)
                    listCia.Add(datcia)
                End While
            End If
            dr.Close()
        End Using
        Return listCia
    End Function
End Class
