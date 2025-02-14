Imports System.Data.Odbc
Public Class DAL_TABFAC

    Public Function Insert_Tabfac(ByVal objDato As TABFAC) As TABFAC
        'Dim datTabfac As New TABFAC
        'Using cmd As New OdbcCommand
        '    Try
        '        cmd.Connection = Cn
        '        cmd.CommandText = "START TRANSACTION;" : cmd.ExecuteNonQuery()

        '        If objDato.CODIGO = 0 Then
        '            Ssql = "SELECT  IFNULL(MAX(codigo),0) + 1  FROM CLIPRO WHERE cia=" & GCia & ";"
        '            cmd.CommandText = Ssql
        '            objDato.CODIGO = Convert.ToInt32(cmd.ExecuteScalar)
        '        End If

        '        Ssql = "INSERT INTO CLIPRO(CIA, CODIGO, TIPDOC, NRODOC, CODGRU, RAZSOC, APEMAT, NOMBRE, RAZCOM, DIRECC, CODPAI, CODDEP, CODPRO, CODDIS, CODCIU, CODVEN, TELEFO, CELULAR, LINEA, OTROS, TIPREG, FECINS, USRALT, FECALT)VALUES("
        '        Ssql = Ssql & GCia & "," & objDato.CODIGO & "," & objDato.TIPDOC & ",'" & objDato.NRODOC & "'," & objDato.CODGRU & ",'" & objDato.RAZSOC & "','"
        '        Ssql = Ssql & objDato.APEMAT & "','" & objDato.NOMBRE & "','" & objDato.RAZCOM & "','" & objDato.DIRECC & "'," & objDato.CODPAI & ",'" & objDato.CODDEP & "','" & objDato.CODPRO & "','" & objDato.CODDIS & "','"
        '        Ssql = Ssql & objDato.CODCIU & "'," & objDato.CODVEN & ",'" & objDato.TELEFO & "','" & objDato.CELULAR & "'," & objDato.LINEA & ",'" & objDato.OTROS & "'," & objDato.TIPREG & ",NOW()," & GCodUsr & ",NOW()) ON DUPLICATE KEY UPDATE "
        '        Ssql = Ssql & "TIPDOC=" & objDato.TIPDOC & ",NRODOC='" & objDato.NRODOC & "',CODGRU=" & objDato.CODGRU & ",RAZSOC='" & objDato.RAZSOC & "',APEMAT='" & objDato.APEMAT & "',NOMBRE='" & objDato.NOMBRE & "',RAZCOM='" & objDato.RAZCOM & "',"
        '        Ssql = Ssql & "DIRECC='" & objDato.DIRECC & "',CODPAI=" & objDato.CODPAI & ",CODDEP='" & objDato.CODDEP & "',CODPRO='" & objDato.CODPRO & "',CODDIS='" & objDato.CODDIS & "',CODCIU='" & objDato.CODCIU & "',CODVEN=" & objDato.CODVEN & ",TELEFO='" & objDato.TELEFO & "',"
        '        Ssql = Ssql & "CELULAR='" & objDato.CELULAR & "',LINEA=" & objDato.LINEA & ",OTROS='" & objDato.OTROS & "',TIPREG=" & objDato.TIPREG & ",FECMOD=NOW(),USRMOD=" & GCodUsr & ",SIT=" & objDato.SIT & ";"
        '        cmd.CommandText = Ssql
        '        cmd.ExecuteNonQuery()

        '        If objDato.LISTACORREO.Count > 0 Then
        '            Ssql = "DELETE FROM cliprocorreo WHERE cia=" & GCia & " AND codigo=" & objDato.CODIGO & ";" : cmd.CommandText = Ssql : cmd.ExecuteNonQuery()
        '            For Each item As CLIPROCORREO In objDato.LISTACORREO
        '                Ssql = "INSERT INTO cliprocorreo(cia,codigo,correo)VALUES(" & GCia & "," & objDato.CODIGO & ",'" & item.CORREO & "');"
        '                cmd.CommandText = Ssql
        '                cmd.ExecuteNonQuery()
        '            Next
        '        End If

        '        If objDato.LISTASUCURSAL.Count > 0 Then
        '            Ssql = "DELETE FROM cliprosucursales WHERE cia=" & GCia & " AND codigo=" & objDato.CODIGO & ";" : cmd.CommandText = Ssql : cmd.ExecuteNonQuery()
        '            For Each item As CLIPROSUCURSAL In objDato.LISTASUCURSAL
        '                Ssql = "INSERT INTO cliprosucursales( CIA, CODIGO, CODSUC, RAZSOC, NOMCON, DIRECC, CODDEP, CODPRO, CODDIS, CODCIU, CODVEN, TELEFO, CELULAR, SIT)VALUES("
        '                Ssql = Ssql & GCia & "," & objDato.CODIGO & "," & item.CODSUC & ",'" & item.RAZSOC & "','" & item.NOMCON & "','" & item.DIRECC & "','" & item.CODDEP & "','" & item.CODPRO & "','" & item.CODDIS & "','" & item.CODCIU & "'," & item.CODVEN & ",'" & item.TELEFO & "','" & item.CELULAR & "',0);"
        '                cmd.CommandText = Ssql
        '                cmd.ExecuteNonQuery()
        '            Next
        '        End If
        '        datCliente = objDato
        '        cmd.CommandText = "COMMIT;" : cmd.ExecuteNonQuery()
        '    Catch ex As Exception
        '        datCliente = Nothing
        '        cmd.CommandText = "ROLLBACK;" : cmd.ExecuteNonQuery()

        '    End Try
        'End Using
        'Return datTabfac
    End Function






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
