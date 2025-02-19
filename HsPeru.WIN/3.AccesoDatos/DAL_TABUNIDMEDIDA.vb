Option Strict On
Imports System.Data.Odbc

Public Class DAL_TABUNIDMEDIDA
    Public Function Select_all_UnidMedida(ByVal objDato As UNIDAD) As List(Of UNIDAD)
        Dim listUnidMedida As New List(Of UNIDAD)()
        Dim dr As OdbcDataReader
        Dim datUnidMedida As UNIDAD
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tabuni.COD, tabuni.DESCRI, tabuni.DESABR, tabuni.ST FROM tabuni;"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cia", OdbcType.Int, 11).Value = GCia
            cmd.Parameters.Add("@criterio", OdbcType.VarChar, 30).Value = objDato.DESCRI
            cmd.Parameters.Add("@st", OdbcType.Int, 11).Value = objDato.ST
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datUnidMedida = New UNIDAD()
                    row = FetchAsoc(dr)
                    With datUnidMedida
                        '.CIA = CType(row("CIA"), Integer)
                        .COD = CType(row("COD"), Integer)
                        .DESCRI = row("DESCRI")
                        .DESABR = row("DESABR")
                        .ST = CType(row("ST"), Integer)
                        '.ESTADO = If(.ST = 0, ACTIVO, INACTIVO)
                    End With

                    listUnidMedida.Add(datUnidMedida)
                End While
            End If

            dr.Close()
        End Using
        Return listUnidMedida
    End Function
    Public Function Insert_UnidMedida(ByVal objDato As UNIDAD) As UNIDAD

        Dim datUnidMedida As New UNIDAD
        Dim Cod As Integer = 0
        If objDato.COD <> 0 Then
            Cod = objDato.COD
        Else
            Ssql = "SELECT IFNULL(MAX(COD),0) + 1  FROM tabuni ;"
            Using cmd As New OdbcCommand(Ssql, Cn)
                cmd.CommandType = CommandType.Text
                Cod = CType(cmd.ExecuteScalar(), Integer)
            End Using

        End If

        Ssql = "INSERT INTO tabuni (COD, DESCRI, DESABR, ST) VALUES ("
        Ssql = Ssql & Cod & ",'" & objDato.DESCRI & "','" & objDato.DESABR & "'," & objDato.ST & ") "
        Ssql = Ssql & " ON DUPLICATE KEY UPDATE DESCRI='" & objDato.DESCRI & "', DESABR='" & objDato.DESABR & "', ST=" & objDato.ST & ";"

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.ExecuteNonQuery()
            objDato.COD = Cod
        End Using
        datUnidMedida = objDato
        Return datUnidMedida
    End Function
End Class
