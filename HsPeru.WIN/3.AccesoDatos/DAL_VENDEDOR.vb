Option Strict On
Imports System.Data.Odbc

Public Class DAL_VENDEDOR

    Public Function Select_all_Vendedor(ByVal objDato As VENDEDOR) As List(Of VENDEDOR)
        Dim listVendedor As New List(Of VENDEDOR)()
        Dim dr As OdbcDataReader
        Dim datVendedor As VENDEDOR
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tg_tabven.CIA, tg_tabven.COD, tg_tabven.DES, tg_tabven.CODSUC, tabsuc.des DESSUC, tg_tabven.SIT, tg_tabven.PWDVEN, tg_tabven.STSUP FROM tg_tabven "
        Ssql = Ssql & " LEFT JOIN tabsuc ON tabsuc.cod=tg_tabven.codsuc And tg_tabven.cia=" & GCia & " "
        Ssql = Ssql & " WHERE tg_tabven.cia=? And tg_tabven.des Like CONCAT('%',?,'%') AND tg_tabven.sit=?; "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cia", OdbcType.Int, 11).Value = GCia
            cmd.Parameters.Add("@criterio", OdbcType.VarChar, 30).Value = objDato.DES
            cmd.Parameters.Add("@sit", OdbcType.Int, 11).Value = objDato.SIT
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    datVendedor = New VENDEDOR()
                    row = FetchAsoc(dr)
                    With datVendedor
                        .CIA = CType(row("CIA"), Integer)
                        .COD = CType(row("COD"), Integer)
                        .DES = row("DES")
                        .CODSUC = CType(row("CODSUC"), Integer)
                        .DESSUC = row("DESSUC")
                        .SIT = CType(row("SIT"), Integer)
                        .ESTADO = If(.SIT = 0, ACTIVO, INACTIVO)
                        .STSUP = CType(row("STSUP"), Integer)
                        .SUPERVISOR = If(.STSUP = 1, "SI", "NO")
                    End With

                    listVendedor.Add(datVendedor)
                End While
            End If

            dr.Close()
        End Using
        Return listVendedor
    End Function

    Public Function Insert_Vendedor(ByVal objDato As VENDEDOR) As VENDEDOR

        Dim datvendedor As New VENDEDOR
        Dim Cod As Integer = 0
        If objDato.COD <> 0 Then
            Cod = objDato.COD
        Else
            Ssql = "SELECT IFNULL(MAX(cod),0) + 1  FROM tg_tabven WHERE cia= " & GCia & " ;"
            Using cmd As New OdbcCommand(Ssql, Cn)
                cmd.CommandType = CommandType.Text
                Cod = CType(cmd.ExecuteScalar(), Integer)
            End Using

        End If

        If objDato.PWDVEN.Trim.Length > 0 And objDato.STSUP = 1 Then
            Ssql = "INSERT INTO tg_tabven (CIA, COD, DES, CODSUC, SIT, PWDVEN, stsup)VALUES("
            Ssql = Ssql & GCia & "," & Cod & ",'" & objDato.DES & "'," & objDato.CODSUC & "," & objDato.SIT & ",MD5('" & objDato.PWDVEN & "')," & objDato.STSUP & ") "
            Ssql = Ssql & " ON DUPLICATE KEY UPDATE des='" & objDato.DES & "',CODSUC=" & objDato.CODSUC & ",SIT=" & objDato.SIT & ",PWDVEN=MD5('" & objDato.PWDVEN & "'),STSUP=" & objDato.STSUP & ";"
        Else
            Ssql = "INSERT INTO tg_tabven (CIA, COD, DES, CODSUC, SIT, stsup)VALUES("
            Ssql = Ssql & GCia & "," & Cod & ",'" & objDato.DES & "'," & objDato.CODSUC & "," & objDato.SIT & "," & objDato.STSUP & ") "
            Ssql = Ssql & " ON DUPLICATE KEY UPDATE des='" & objDato.DES & "',CODSUC=" & objDato.CODSUC & ",SIT=" & objDato.SIT & ",STSUP=" & objDato.STSUP & ";"
        End If

        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.ExecuteNonQuery()
            objDato.COD = Cod
        End Using
        datvendedor = objDato
        Return datvendedor
    End Function

    Public Function Select_pwd_Supervisor(ByVal objDato As VENDEDOR) As VENDEDOR

        Dim dr As OdbcDataReader
        Dim datVendedor As New VENDEDOR
        Dim row As Dictionary(Of String, String)
        Ssql = "SELECT tg_tabven.CIA, tg_tabven.COD, tg_tabven.DES, tg_tabven.CODSUC, tabsuc.des DESSUC, tg_tabven.SIT, tg_tabven.PWDVEN, tg_tabven.STSUP FROM tg_tabven "
        Ssql = Ssql & " LEFT JOIN tabsuc ON tabsuc.cod=tg_tabven.codsuc And tabsuc.cia=tg_tabven.cia "
        Ssql = Ssql & " WHERE tg_tabven.cia=" & GCia & " AND tg_tabven.sit=0 AND  PWDVEN=MD5('" & objDato.PWDVEN & "')"
        If objDato.STSUP = 0 Then
            Ssql = Ssql & " AND STSUP=1"
        End If
        If objDato.STSUP = 1 Then
            Ssql = Ssql & " AND PWDVEN<>'' "
        End If
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                row = FetchAsoc(dr)
                With datVendedor
                    .CIA = CType(row("CIA"), Integer)
                    .COD = CType(row("COD"), Integer)
                    .DES = row("DES")
                    .CODSUC = CType(row("CODSUC"), Integer)
                    .DESSUC = row("DESSUC")
                    .SIT = CType(row("SIT"), Integer)
                    .ESTADO = If(.SIT = 0, ACTIVO, INACTIVO)
                    .STSUP = CType(row("STSUP"), Integer)
                    .SUPERVISOR = If(.STSUP = 1, "SI", "NO")
                    .PWDVEN = row("PWDVEN")
                End With
            End If

            dr.Close()
        End Using
        Return datVendedor

    End Function

End Class
