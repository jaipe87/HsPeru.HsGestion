Imports System.Data
Imports System.Data.Odbc

Public Class DAL_TABSUC
    Public Function SeleccionaAll_Sucursal() As List(Of TABSUC)
        Dim dr As OdbcDataReader
        Dim datTabsuc As TABSUC
        Dim lstTabsuc As New List(Of TABSUC)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  CIA, COD, DES, DIRSUC, TELEFONO, CELULAR, EMAIL, DESABR, NUMSER, FECINI, SIT  FROM tabsuc WHERE cia=" & GCia & " AND SIT=0"
        Using cmd As New OdbcCommand(ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabsuc = New TABSUC()
                    With datTabsuc
                        .CIA = CType(Row("CIA"), Integer)
                        .COD = CType(Row("COD"), Integer)
                        .DES = Row("DES")
                        .DESABR = Row("DESABR")
                        .DIRSUC = Row("DIRSUC")
                        .EMAIL = Row("EMAIL")
                        .TELEFONO = Row("TELEFONO")
                        .CELULAR = Row("CELULAR")
                        .FECINI = CType(Row("FECINI"), Date)
                        .NUMSER = Row("NUMSER")
                        .SIT = CType(Row("SIT"), Integer)
                    End With
                    lstTabsuc.Add(datTabsuc)
                End While
                Return lstTabsuc
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Function SeleccionaAll_Sucursal_by_cod(ByVal objDato As TABSUC) As TABSUC
        Dim dr As OdbcDataReader
        Dim datTabsuc As TABSUC
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  CIA, COD, DES, DIRSUC, TELEFONO, CELULAR, EMAIL, DESABR, NUMSER, FECINI, SIT  FROM tabsuc WHERE cia=" & objDato.CIA & " AND cod=" & objDato.COD & " AND SIT=0"
        Using cmd As New OdbcCommand(ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                Row = FetchAsoc(dr)
                datTabsuc = New TABSUC()
                With datTabsuc
                    .CIA = CType(Row("CIA"), Integer)
                    .COD = CType(Row("COD"), Integer)
                    .DES = Row("DES")
                    .DESABR = Row("DESABR")
                    .DIRSUC = Row("DIRSUC")
                    .EMAIL = Row("EMAIL")
                    .TELEFONO = Row("TELEFONO")
                    .CELULAR = Row("CELULAR")
                    .FECINI = CType(Row("FECINI"), Date)
                    .NUMSER = Row("NUMSER")
                    .SIT = CType(Row("SIT"), Integer)
                End With
                Return datTabsuc
            Else
                Return Nothing
            End If
        End Using
    End Function
End Class
