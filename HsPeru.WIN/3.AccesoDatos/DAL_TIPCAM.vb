Option Strict On
Imports System.Data.Odbc


Public Class DAL_TIPCAM

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
        Using cmd As New OdbcCommand(ssql, Cn)
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
        Using cmd As New OdbcCommand(ssql, Cn)
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
