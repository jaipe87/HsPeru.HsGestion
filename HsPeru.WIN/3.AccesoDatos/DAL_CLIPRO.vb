Option Strict On
Imports System.Data
Imports System.Data.Odbc
Public Class DAL_CLIPRO

    Public Function Insert_clipro(ByVal objDato As CLIPRO) As CLIPRO
        Dim datCliente As New CLIPRO
        Using cmd As New OdbcCommand
            Try
                cmd.Connection = Cn
                cmd.CommandText = "START TRANSACTION;" : cmd.ExecuteNonQuery()

                If objDato.CODIGO = 0 Then
                    Ssql = "SELECT  IFNULL(MAX(codigo),0) + 1  FROM CLIPRO WHERE cia=" & GCia & ";"
                    cmd.CommandText = Ssql
                    objDato.CODIGO = Convert.ToInt32(cmd.ExecuteScalar)
                End If

                Ssql = "INSERT INTO CLIPRO(CIA, CODIGO, TIPDOC, NRODOC, CODGRU, RAZSOC, APEMAT, NOMBRE, RAZCOM, DIRECC, CODPAI, CODDEP, CODPRO, CODDIS, CODCIU, CODVEN, TELEFO, CELULAR, LINEA, OTROS, TIPREG, FECINS, USRALT, FECALT)VALUES("
                Ssql = Ssql & GCia & "," & objDato.CODIGO & "," & objDato.TIPDOC & ",'" & objDato.NRODOC & "'," & objDato.CODGRU & ",'" & objDato.RAZSOC & "','"
                Ssql = Ssql & objDato.APEMAT & "','" & objDato.NOMBRE & "','" & objDato.RAZCOM & "','" & objDato.DIRECC & "'," & objDato.CODPAI & ",'" & objDato.CODDEP & "','" & objDato.CODPRO & "','" & objDato.CODDIS & "','"
                Ssql = Ssql & objDato.CODCIU & "'," & objDato.CODVEN & ",'" & objDato.TELEFO & "','" & objDato.CELULAR & "'," & objDato.LINEA & ",'" & objDato.OTROS & "'," & objDato.TIPREG & ",NOW()," & GCodUsr & ",NOW()) ON DUPLICATE KEY UPDATE "
                Ssql = Ssql & "TIPDOC=" & objDato.TIPDOC & ",NRODOC='" & objDato.NRODOC & "',CODGRU=" & objDato.CODGRU & ",RAZSOC='" & objDato.RAZSOC & "',APEMAT='" & objDato.APEMAT & "',NOMBRE='" & objDato.NOMBRE & "',RAZCOM='" & objDato.RAZCOM & "',"
                Ssql = Ssql & "DIRECC='" & objDato.DIRECC & "',CODPAI=" & objDato.CODPAI & ",CODDEP='" & objDato.CODDEP & "',CODPRO='" & objDato.CODPRO & "',CODDIS='" & objDato.CODDIS & "',CODCIU='" & objDato.CODCIU & "',CODVEN=" & objDato.CODVEN & ",TELEFO='" & objDato.TELEFO & "',"
                Ssql = Ssql & "CELULAR='" & objDato.CELULAR & "',LINEA=" & objDato.LINEA & ",OTROS='" & objDato.OTROS & "',TIPREG=" & objDato.TIPREG & ",FECMOD=NOW(),USRMOD=" & GCodUsr & ",SIT=" & objDato.SIT & ";"
                cmd.CommandText = Ssql
                cmd.ExecuteNonQuery()

                If objDato.LISTACORREO.Count > 0 Then
                    Ssql = "DELETE FROM cliprocorreo WHERE cia=" & GCia & " AND codigo=" & objDato.CODIGO & ";" : cmd.CommandText = Ssql : cmd.ExecuteNonQuery()
                    For Each item As CLIPROCORREO In objDato.LISTACORREO
                        Ssql = "INSERT INTO cliprocorreo(cia,codigo,correo)VALUES(" & GCia & "," & objDato.CODIGO & ",'" & item.CORREO & "');"
                        cmd.CommandText = Ssql
                        cmd.ExecuteNonQuery()
                    Next
                End If

                If objDato.LISTASUCURSAL.Count > 0 Then
                    Ssql = "DELETE FROM cliprosucursales WHERE cia=" & GCia & " AND codigo=" & objDato.CODIGO & ";" : cmd.CommandText = Ssql : cmd.ExecuteNonQuery()
                    For Each item As CLIPROSUCURSAL In objDato.LISTASUCURSAL
                        Ssql = "INSERT INTO cliprosucursales( CIA, CODIGO, CODSUC, RAZSOC, NOMCON, DIRECC, CODDEP, CODPRO, CODDIS, CODCIU, CODVEN, TELEFO, CELULAR, SIT)VALUES("
                        Ssql = Ssql & GCia & "," & objDato.CODIGO & "," & item.CODSUC & ",'" & item.RAZSOC & "','" & item.NOMCON & "','" & item.DIRECC & "','" & item.CODDEP & "','" & item.CODPRO & "','" & item.CODDIS & "','" & item.CODCIU & "'," & item.CODVEN & ",'" & item.TELEFO & "','" & item.CELULAR & "',0);"
                        cmd.CommandText = Ssql
                        cmd.ExecuteNonQuery()
                    Next
                End If
                datCliente = objDato
                cmd.CommandText = "COMMIT;" : cmd.ExecuteNonQuery()
            Catch ex As Exception
                datCliente = Nothing
                cmd.CommandText = "ROLLBACK;" : cmd.ExecuteNonQuery()

            End Try
        End Using
        Return datCliente
    End Function

    Public Function Select_Clipro_by_codigo(ByVal objDato As CLIPRO) As CLIPRO

        Dim dr As OdbcDataReader
        Dim datClipro As CLIPRO, datCliproCorreo As CLIPROCORREO, datcliproSucursal As CLIPROSUCURSAL
        Dim Row As Dictionary(Of String, String)

        Using cmd As New OdbcCommand
            cmd.Connection = Cn
            Ssql = "SELECT  CIA, CODIGO, TIPDOC, NRODOC, CODGRU, RAZSOC, APEPAT, APEMAT, NOMBRE, RAZCOM, DIRECC, CODPAI, CODDEP, CODPRO,"
            Ssql = Ssql & " CODDIS, CODCIU, CODVEN, TELEFO, CELULAR, LINEA, OTROS, TIPREG, FECINS, USRALT, FECALT, "
            Ssql = Ssql & " USRMOD, FECMOD, SIT, FECCONSUL, ESTSUNAT, CONDSUNAT,tg_tipdoc.desabr DESDOC,tg_tipreg.desabr DESREG FROM clipro INNER JOIN tg_tipdoc ON tg_tipdoc.cod=clipro.tipdoc "
            Ssql = Ssql & " LEFT JOIN tg_tipreg ON tg_tipreg.cod=clipro.tipreg WHERE cia=" & GCia & " AND CODIGO='" & objDato.CODIGO & "'"
            cmd.CommandText = Ssql
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                Row = FetchAsoc(dr)
                datClipro = New CLIPRO()
                With datClipro
                    .CIA = Convert.ToInt32(Row("CIA"))
                    .CODIGO = Convert.ToInt32(Row("CODIGO"))
                    .TIPDOC = Convert.ToInt32(Row("TIPDOC"))
                    .NRODOC = Row("NRODOC")
                    .CODGRU = Convert.ToInt32(Row("CODGRU"))
                    .RAZSOC = Row("RAZSOC")
                    .APEPAT = Row("APEPAT")
                    .APEMAT = Row("APEMAT")
                    .NOMBRE = Row("NOMBRE")
                    .TRAZSOC = .RAZSOC & " " & .APEMAT & " " & .NOMBRE
                    .RAZCOM = Row("RAZCOM")
                    .DIRECC = Row("DIRECC")
                    .CODPAI = Convert.ToInt32(Row("CODPAI"))
                    .CODDEP = Row("CODDEP")
                    .CODPRO = Row("CODPRO")
                    .CODDIS = Row("CODDIS")
                    .CODCIU = Row("CODCIU")
                    .CODVEN = Convert.ToInt32(Row("CODVEN"))
                    .TELEFO = Row("TELEFO")
                    .CELULAR = Row("CELULAR")
                    .LINEA = Convert.ToDouble(Row("LINEA"))
                    .OTROS = Row("OTROS")
                    .TIPREG = Convert.ToInt32(Row("TIPREG"))
                    .FECINS = Row("FECINS")
                    .USRALT = Convert.ToInt32(Row("USRALT"))
                    .FECMOD = Row("FECMOD")
                    .USRMOD = Convert.ToInt32(Row("USRMOD"))
                    .SIT = Convert.ToInt32(Row("SIT"))
                    .FECCONSUL = Row("FECCONSUL")
                    .ESTSUNAT = Row("ESTSUNAT")
                    .CONDSUNAT = Row("CONDSUNAT")
                    .ESTADO = If(.SIT = 0, ACTIVO, INACTIVO)
                    .DESTIPDOC = Row("DESDOC")
                    .DESTIPREG = Row("DESREG")
                End With
                dr.Close()

                Ssql = "SELECT CIA,CODIGO,CORREO FROM cliprocorreo WHERE CIA=" & GCia & " and codigo=" & objDato.CODIGO
                cmd.CommandText = Ssql
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        Row = FetchAsoc(dr)
                        datCliproCorreo = New CLIPROCORREO
                        With datCliproCorreo
                            .CIA = Convert.ToInt32(Row("CIA"))
                            .CODIGO = Convert.ToInt32(Row("CODIGO"))
                            .CORREO = Row("CORREO")
                        End With
                        datClipro.LISTACORREO.Add(datCliproCorreo)
                    End While
                End If
                dr.Close()

                Ssql = "SELECT cliprosucursales.CIA, CODIGO, cliprosucursales.CODSUC, RAZSOC, NOMCON, DIRECC, cliprosucursales.CODDEP,tg_tabdep.NOMDEP, cliprosucursales.CODPRO,tg_tabpro.NOMPRO,
                        cliprosucursales.CODDIS,tg_tabdis.NOMDIS, cliprosucursales.CODCIU, tg_tabciu.NOMCIU,
                        CODVEN, TELEFO, CELULAR, cliprosucursales.SIT ,tg_tabven.des VENDEDOR
                        FROM cliprosucursales INNER JOIN tg_tabdep ON tg_tabdep.CODDEP=cliprosucursales.CODDEP 
                                              INNER JOIN tg_tabpro ON tg_tabpro.CODDEP=cliprosucursales.CODDEP  AND tg_tabpro.CODPRO= cliprosucursales.CODPRO
                                              INNER JOIN tg_tabdis ON tg_tabdis.CODDEP=cliprosucursales.CODDEP  AND tg_tabdis.CODPRO= cliprosucursales.CODPRO  AND tg_tabdis.CODDIS= cliprosucursales.CODDIS
                                              INNER JOIN tg_tabciu ON tg_tabciu.CODDEP=cliprosucursales.CODDEP  AND tg_tabciu.CODPRO= cliprosucursales.CODPRO  AND tg_tabciu.CODDIS= cliprosucursales.CODDIS and tg_tabciu.CODCIU= cliprosucursales.CODCIU
                                              LEFT JOIN tg_tabven ON tg_tabven.cia=cliprosucursales.cia AND tg_tabven.cod=cliprosucursales.codven
                                              WHERE cliprosucursales.CIA=" & GCia & " and codigo=" & objDato.CODIGO
                cmd.CommandText = Ssql
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        Row = FetchAsoc(dr)
                        datcliproSucursal = New CLIPROSUCURSAL
                        With datcliproSucursal
                            .CIA = Convert.ToInt32(Row("CIA"))
                            .CODIGO = Convert.ToInt32(Row("CODIGO"))
                            .CODSUC = Convert.ToInt32(Row("CODSUC"))
                            .RAZSOC = Row("RAZSOC")
                            .NOMCON = Row("NOMCON")
                            .DIRECC = Row("DIRECC")
                            .CODDEP = Row("CODDEP")
                            .NOMDEP = Row("NOMDEP")
                            .CODPRO = Row("CODPRO")
                            .NOMPRO = Row("NOMPRO")
                            .CODDIS = Row("CODDIS")
                            .NOMDIS = Row("NOMDIS")
                            .CODCIU = Row("CODCIU")
                            .NOMCIU = Row("NOMCIU")
                            .CODVEN = Convert.ToInt32(Row("CODVEN"))
                            .VENDEDOR = Row("VENDEDOR")
                            .TELEFO = Row("TELEFO")
                            .CELULAR = Row("CELULAR")
                            .SIT = Convert.ToInt32(Row("SIT"))
                        End With
                        datClipro.LISTASUCURSAL.Add(datcliproSucursal)
                    End While
                End If
                dr.Close()

                Return datClipro
            Else
                Return Nothing
            End If
        End Using
    End Function
    Public Function SelectAll_clipro(ByVal objDato As CLIPRO, ByVal TipBusqueda As Integer) As List(Of CLIPRO)
        Dim dr As OdbcDataReader
        Dim datClipro As CLIPRO
        Dim lstClipro As New List(Of CLIPRO)
        Dim Row As Dictionary(Of String, String)
        Dim Criterio As String()
        Dim Crit As String = objDato.RAZSOC.Trim

        Ssql = "SELECT  CIA, CODIGO, TIPDOC, NRODOC, CODGRU, RAZSOC, APEPAT, APEMAT, NOMBRE, RAZCOM, DIRECC, CODPAI, CODDEP, CODPRO,"
        Ssql = Ssql & " CODDIS, CODCIU, CODVEN, TELEFO, CELULAR, LINEA, OTROS, TIPREG, FECINS, USRALT, FECALT, "
        Ssql = Ssql & " USRMOD, FECMOD, SIT, FECCONSUL, ESTSUNAT, CONDSUNAT,tg_tipdoc.desabr DESDOC,tg_tipreg.desabr DESREG FROM clipro INNER JOIN tg_tipdoc ON tg_tipdoc.cod=clipro.tipdoc "
        Ssql = Ssql & " LEFT JOIN tg_tipreg ON tg_tipreg.cod=clipro.tipreg WHERE cia=" & GCia
        If objDato.TIPREG > 0 Then ' TIPO DE REGISTRO
            Ssql = Ssql & " and SIT=0 AND (tipreg=" & objDato.TIPREG & " or tipreg=3) "
        End If
        If Crit.Length > 0 Then ' BÚSQUEDA DE CRITERIO POR ESPACIOS
            Criterio = Crit.Split(Convert.ToChar(" "))
            For Each item As String In Criterio
                If TipBusqueda = 0 Then ' Búsqueda por inicio
                    Ssql = Ssql & " AND (CODIGO='" & item & "' OR  NRODOC LIKE '" & item & "%' OR RAZSOC LIKE '" & item & "%' OR APEMAT LIKE '" & item & "%' OR NOMBRE LIKE '" & item & "%' OR RAZCOM LIKE '" & item & "%')"
                End If

                If TipBusqueda = 1 Then ' Búsqueda entre 
                    Ssql = Ssql & " AND  (CODIGO='" & item & "' OR NRODOC LIKE '%" & item & "%' OR RAZSOC LIKE '%" & item & "%' OR APEMAT LIKE '%" & item & "%' OR NOMBRE LIKE '%" & item & "%' OR RAZCOM LIKE '%" & item & "%')"
                End If
            Next
        End If

        Ssql = Ssql & " ORDER BY razsoc"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datClipro = New CLIPRO()
                    With datClipro
                        .CIA = Convert.ToInt32(Row("CIA"))
                        .CODIGO = Convert.ToInt32(Row("CODIGO"))
                        .TIPDOC = Convert.ToInt32(Row("TIPDOC"))
                        .NRODOC = Row("NRODOC")
                        .CODGRU = Convert.ToInt32(Row("CODGRU"))
                        .RAZSOC = Row("RAZSOC")
                        .APEPAT = Row("APEPAT")
                        .APEMAT = Row("APEMAT")
                        .NOMBRE = Row("NOMBRE")
                        .TRAZSOC = .RAZSOC & " " & .APEMAT & " " & .NOMBRE
                        .RAZCOM = Row("RAZCOM")
                        .DIRECC = Row("DIRECC")
                        .CODPAI = Convert.ToInt32(Row("CODPAI"))
                        .CODDEP = Row("CODDEP")
                        .CODPRO = Row("CODPRO")
                        .CODDIS = Row("CODDIS")
                        .CODCIU = Row("CODCIU")
                        .CODVEN = Convert.ToInt32(Row("CODVEN"))
                        .TELEFO = Row("TELEFO")
                        .CELULAR = Row("CELULAR")
                        .LINEA = Convert.ToDouble(Row("LINEA"))
                        .OTROS = Row("OTROS")
                        .TIPREG = Convert.ToInt32(Row("TIPREG"))
                        .FECINS = Row("FECINS")
                        .USRALT = Convert.ToInt32(Row("USRALT"))
                        .FECMOD = Row("FECMOD")
                        .USRMOD = Convert.ToInt32(Row("USRMOD"))
                        .SIT = Convert.ToInt32(Row("SIT"))
                        .FECCONSUL = Row("FECCONSUL")
                        .ESTSUNAT = Row("ESTSUNAT")
                        .CONDSUNAT = Row("CONDSUNAT")
                        .ESTADO = If(.SIT = 0, ACTIVO, INACTIVO)
                        .DESTIPDOC = Row("DESDOC")
                        .DESTIPREG = Row("DESREG")
                    End With
                    lstClipro.Add(datClipro)
                End While
                Return lstClipro
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Function ValidaNroDoc(ByVal objDato As CLIPRO) As Boolean

        Dim ind As Boolean = False
        Ssql = "call pa_Valida_NroDoc('" & GCia & "','" & objDato.CODIGO & "','" & objDato.NRODOC & "'); "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            ind = Convert.ToBoolean(cmd.ExecuteScalar)
        End Using
        Return ind
    End Function

    Public Function Insert_wsReniec(ByVal objDato As CLIPRO) As CLIPRO
        Dim datCliente As New CLIPRO
        Dim xCount As Integer = 0
        Using cmd As New OdbcCommand
            Try
                cmd.Connection = Cn
                cmd.CommandText = "START TRANSACTION;" : cmd.ExecuteNonQuery()

                Ssql = "SELECT count(*) FROM CLIPRO WHERE cia=" & GCia & " AND nrodoc='" & objDato.NRODOC & "';"
                cmd.CommandText = Ssql
                xCount = Convert.ToInt32(cmd.ExecuteScalar)


                If xCount = 0 Then
                    Ssql = "SELECT  IFNULL(MAX(codigo),0) + 1  FROM CLIPRO WHERE cia=" & GCia & ";"
                    cmd.CommandText = Ssql
                    objDato.CODIGO = Convert.ToInt32(cmd.ExecuteScalar)
                Else
                    Ssql = "SELECT  CODIGO  FROM CLIPRO WHERE cia=" & GCia & " AND nrodoc='" & objDato.NRODOC & "';"
                    cmd.CommandText = Ssql
                    objDato.CODIGO = Convert.ToInt32(cmd.ExecuteScalar)
                End If
                objDato.TIPDOC = CInt(TipDocClie.DNI)
                objDato.TIPREG = CInt(TipReg.CLI)
                objDato.CODGRU = 1
                objDato.CODPAI = 1
                objDato.CODDEP = "15"
                objDato.CODPRO = "01"
                objDato.CODDIS = "01"
                objDato.CODCIU = "001"
                objDato.CODVEN = 1

                Ssql = "INSERT INTO CLIPRO(CIA, CODIGO, TIPDOC, NRODOC, CODGRU, RAZSOC, APEMAT, NOMBRE, DIRECC, CODPAI, CODDEP, CODPRO, CODDIS, CODCIU, CODVEN, TELEFO, CELULAR, TIPREG, FECINS, USRALT, FECALT)VALUES("
                Ssql = Ssql & GCia & "," & objDato.CODIGO & "," & objDato.TIPDOC & ",'" & objDato.NRODOC & "'," & objDato.CODGRU & ",'" & objDato.RAZSOC & "','"
                Ssql = Ssql & objDato.APEMAT & "','" & objDato.NOMBRE & "','" & objDato.DIRECC & "'," & objDato.CODPAI & ",'" & objDato.CODDEP & "','" & objDato.CODPRO & "','" & objDato.CODDIS & "','"
                Ssql = Ssql & objDato.CODCIU & "'," & objDato.CODVEN & ",'" & objDato.TELEFO & "','" & objDato.CELULAR & "'," & objDato.TIPREG & ",NOW()," & GCodUsr & ",NOW()) ON DUPLICATE KEY UPDATE "
                Ssql = Ssql & "TIPDOC=" & objDato.TIPDOC & ",NRODOC='" & objDato.NRODOC & "',CODGRU=" & objDato.CODGRU & ",RAZSOC='" & objDato.RAZSOC & "',APEMAT='" & objDato.APEMAT & "',NOMBRE='" & objDato.NOMBRE & "',"
                Ssql = Ssql & "DIRECC='" & objDato.DIRECC & "',CODPAI=" & objDato.CODPAI & ",CODDEP='" & objDato.CODDEP & "',CODPRO='" & objDato.CODPRO & "',CODDIS='" & objDato.CODDIS & "',CODCIU='" & objDato.CODCIU & "',CODVEN=" & objDato.CODVEN & ",TELEFO='" & objDato.TELEFO & "',"
                Ssql = Ssql & "CELULAR='" & objDato.CELULAR & "',TIPREG=" & objDato.TIPREG & ",FECMOD=NOW(),USRMOD=" & GCodUsr & ",SIT=" & objDato.SIT & ";"
                cmd.CommandText = Ssql
                cmd.ExecuteNonQuery()

                If objDato.OTROS.Trim.Length > 0 Then
                    Ssql = "REPLACE INTO cliprocorreo(cia,codigo,correo)VALUES(" & GCia & "," & objDato.CODIGO & ",'" & objDato.OTROS & "');"
                    cmd.CommandText = Ssql
                    cmd.ExecuteNonQuery()
                End If

                objDato.TRAZSOC = objDato.RAZSOC & " " & objDato.APEMAT & " " & objDato.NOMBRE
                datCliente = objDato
                cmd.CommandText = "COMMIT;" : cmd.ExecuteNonQuery()
            Catch ex As Exception
                datCliente = Nothing
                cmd.CommandText = "ROLLBACK;" : cmd.ExecuteNonQuery()

            End Try
        End Using
        Return datCliente

    End Function

End Class
