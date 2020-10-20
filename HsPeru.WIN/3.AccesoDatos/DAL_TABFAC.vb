Imports System.Data.Odbc
Public Class DAL_TABFAC








#Region "Impuestos"
    Public Function Select_IGV(ByVal Fecha As Date) As Double
        Dim impIGV As Double = 0.00
        Ssql = "SELECT porc FROM tg_igv WHERE vigencia <= '" & Format(Fecha, "yyyy-MM-dd") & "' ORDER BY vigencia DESC LIMIT 1;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            impIGV = Convert.ToDouble(cmd.ExecuteScalar())
        End Using
        Return impIGV
    End Function
    Public Function Select_ICBPER(ByVal Fecha As Date) As Double
        Dim ImpICPER As Double = 0.00
        Ssql = "SELECT  Fn_GetICBPER('" & Fecha.ToString("yyyy-MM-dd") & "') ImpICBPER;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            ImpICPER = Convert.ToDouble(cmd.ExecuteScalar())
        End Using
        Return ImpICPER
    End Function
#End Region

End Class
