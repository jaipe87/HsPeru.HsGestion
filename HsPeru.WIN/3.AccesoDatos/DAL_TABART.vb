Option Strict On
Imports System.Data
Imports System.Data.Odbc

Public Class DAL_TABART

    Public Function Insert_Articulo(ByVal objDato As TABART) As TABART
        Dim datArticulo As New TABART
        Dim XCodigo As Integer
        Using cmd As New OdbcCommand
            Try
                cmd.Connection = Cn
                cmd.CommandText = "START TRANSACTION;" : cmd.ExecuteNonQuery()

                If Not Integer.TryParse(objDato.CODART, XCodigo) Then
                    XCodigo = 0
                End If

                If XCodigo = 0 Then
                    Ssql = "SELECT  IFNULL(MAX(CODART),0) + 1  FROM TABART WHERE cia=" & GCia & " AND CODLIN='00';"
                    cmd.CommandText = Ssql
                    objDato.CODART = Convert.ToString(cmd.ExecuteScalar).PadLeft(6, Convert.ToChar("0"))
                End If

                With objDato
                    If .CODFAB.Trim.Equals("") Then
                        .CODFAB = .CODART
                    End If
                    Ssql = "INSERT INTO tabart(CIA, CODLIN, CODART, CODREF, CODFAB, DESCRI, CODMAR, CODGRU, CODSUBCAT, MODELO, GARANTIA, COSDOL, COSSOL, 
                                               PRECOM, CODPRO, FECCOM, AFECTO, STVEN, STWEB, STOFE, STLIS, ISC, STICBPER, TIPMON, 
                                               ESPECI, FECALT, USRALT, FECACT)
                            VALUES(" & GCia & ",'" & .CODLIN & "','" & .CODART & "','" & .CODART & "','" & .CODFAB & "','" & .DESCRI & "','" & .CODMAR & "','" _
                                 & .CODGRU & "','" & .CODSUBCAT & "','" & .MODELO & "','" & .GARANTIA & "','" & .COSDOL & "','" & .COSSOL & "','" _
                                 & .PRECOM & "','" & .CODPRO & "','" & .FECCOM & "','" & .AFECTO & "','" & .STVEN & "','" & .STWEB & "','" & .STOFE & "','" _
                                 & .STLIS & "','" & .ISC & "','" & .STICBPER & "','" & .TIPMON & "','" & .ESPECI & "',NOW(),'" & GCodUsr & "',NOW()) ON DUPLICATE KEY UPDATE 
                                 CODFAB='" & .CODFAB & "',DESCRI='" & .DESCRI & "',CODMAR='" & .CODMAR & "',CODGRU='" & .CODGRU & "',CODSUBCAT='" & .CODSUBCAT & "',MODELO='" & .MODELO & "',GARANTIA='" _
                                 & .GARANTIA & "',COSDOL='" & .COSDOL & "',COSSOL='" & .COSSOL & "',PRECOM='" & .PRECOM & "',CODPRO='" & .CODPRO & "',FECCOM='" & .FECCOM & "',AFECTO='" & .AFECTO & "',STVEN='" _
                                 & .STVEN & "',STWEB='" & .STWEB & "',STOFE='" & .STOFE & "',STLIS='" & .STLIS & "',ISC='" & .ISC & "',STICBPER='" & .STICBPER & "',TIPMON='" & .TIPMON & "',ESPECI='" & .ESPECI & "'," _
                                 & "FECMOD=NOW(),USRMOD='" & GCodUsr & "',SIT='" & .SIT & "';"
                    cmd.CommandText = Ssql
                    cmd.ExecuteNonQuery()
                    Ssql = "DELETE FROM tabart_sucursal WHERE cia=" & GCia & " AND CODLIN='" & .CODLIN & "' AND CODART='" & .CODART & "'" : cmd.CommandText = Ssql : cmd.ExecuteNonQuery()
                    If .LISTAPRECIOS.Count > 0 Then


                        For Each item As TABART_SUCURSAL In .LISTAPRECIOS
                            Ssql = "INSERT INTO tabart_sucursal(CIA, CODLIN, CODART, CODSUC, CODUNI, PORC_PUBLI, PRECIO_PUBLI, PORC_DISTRI,
                                                                 PRECIO_DISTRI, PORC_MIN, PRECIO_MIN, PRECIO_WEB, STMINIMO, EQUIVA, PESO, STUNIDADCOMPRA)VALUES("
                            Ssql = Ssql & GCia & ",'" & .CODLIN & "','" & .CODART & "','" & item.CODSUC & "','" & item.CODUNI & "','" & item.PORC_PUBLI & "','" & item.PRECIO_PUBLI & "','" & item.PORC_DISTRI & "','"
                            Ssql = Ssql & item.PRECIO_DISTRI & "','" & item.PORC_MIN & "','" & item.PRECIO_MIN & "','" & item.PRECIO_WEB & "','" & item.STMINIMO & "','" & item.EQUIVA & "','" & item.PESO & "','" & item.STUNIDADCOMPRA & "') "
                            cmd.CommandText = Ssql
                            cmd.ExecuteNonQuery()
                        Next

                    End If

                    If .LISTASUBICACION.Count > 0 Then


                        For Each item As TABART_UBICACION In .LISTASUBICACION
                            Ssql = "INSERT INTO tabart_ubicacion(CIA, CODLIN, CODART, CODSUC, UBICACION, STOCKMINIMO, ST)VALUES(" & GCia & ",'" & .CODLIN & "','" & .CODART & "','" & item.CODSUC & "','" & item.UBICACION & "','" & item.STOCKMINIMO & "','" & item.ST & "') ON DUPLICATE KEY UPDATE "
                            Ssql = Ssql & " UBICACION='" & item.UBICACION & "',STOCKMINIMO='" & item.STOCKMINIMO & "',ST='" & item.ST & "'"
                            cmd.CommandText = Ssql
                            cmd.ExecuteNonQuery()
                        Next

                    End If
                End With
                datArticulo = objDato
                cmd.CommandText = "COMMIT;" : cmd.ExecuteNonQuery()
            Catch ex As Exception
                datArticulo = Nothing
                cmd.CommandText = "ROLLBACK;" : cmd.ExecuteNonQuery()

            End Try
        End Using
        Return datArticulo
    End Function
    Public Function SelectAll_Articulo(ByVal objDato As TABART_SUCURSAL,
                                       ByVal chkFecha As Boolean, ByVal dtpFecha As String, ByVal dtpFecha1 As String) As List(Of TABART)
        Dim dr As OdbcDataReader
        Dim datArticulo As TABART
        Dim lstArticulo As New List(Of TABART)
        Dim Criterio As String()
        Dim Crit As String = objDato.DESCRI.Trim
        Dim Row As Dictionary(Of String, String)
        Using cmd As New OdbcCommand()
            cmd.Connection = Cn
            Ssql = "SELECT  tabart.CIA, tabart.CODLIN, tabart.CODART, CODREF, CODFAB, tabart.DESCRI, CODMAR, tabart.CODGRU, CODSUBCAT, MODELO, GARANTIA, COSDOL, COSSOL, PRECOM,"
            Ssql = Ssql & " CODPRO, FECCOM, AFECTO, STVEN, STWEB, STOFE, STLIS, TIPMON, ESPECI, FECALT, USRALT, FECACT, USRMOD, FECMOD, SIT,"
            Ssql = Ssql & " tabmar.des DESMAR,tabgru.des DESCAT,tabsubcat.descri DESSUBCAT,ISC,STICBPER "
            Ssql = Ssql & " FROM tabart "
            Ssql = Ssql & " LEFT JOIN tabmar ON tabmar.cia=tabart.cia and tabmar.cod=tabart.codmar "
            Ssql = Ssql & " LEFT JOIN tabgru ON tabgru.cia=tabart.cia and tabart.codgru=tabgru.cod "
            Ssql = Ssql & " LEFT JOIN tabsubcat ON tabsubcat.cia=tabart.cia and tabsubcat.codgru=tabart.codgru and tabsubcat.cod=tabart.CODSUBCAT "
            Ssql = Ssql & " LEFT JOIN tabmon ON tabmon.cod=tabart.tipmon "
            Ssql = Ssql & " LEFT JOIN tabart_sucursal ON tabart.cia=tabart_sucursal.cia AND tabart_sucursal.codlin=tabart.codlin AND tabart_sucursal.codart=tabart.codart"
            Ssql = Ssql & " LEFT JOIN tabart_ubicacion ON  tabart.cia=tabart_ubicacion.cia AND tabart_ubicacion.codlin=tabart.codlin AND tabart_ubicacion.codart=tabart.codart "
            Ssql = Ssql & " WHERE tabart.cia= " & GCia & " "
            If Crit.Length > 0 Then ' BÚSQUEDA DE CRITERIO POR ESPACIOS
                Criterio = Crit.Split(Convert.ToChar(" "))
                For Each item As String In Criterio
                    Ssql = Ssql & " AND (tabart.CODART='%" & item & "%' OR  CODFAB LIKE '%" & item & "%' OR tabart.DESCRI LIKE '%" & item & "%' OR tabmar.des LIKE '%" & item & "%' OR tabgru.des LIKE '%" & item & "%')"
                Next
            End If
            If objDato.SIT <> 2 Then Ssql = Ssql & " AND SIT=" & objDato.SIT & " "
            If chkFecha Then Ssql = Ssql & " AND FECACT BETWEEN '" & dtpFecha & "' AND '" & dtpFecha1 & "'"
            If objDato.CODSUC <> 0 Then
                Ssql = Ssql & " AND tabart_ubicacion.CODSUC=" & objDato.CODSUC & " AND tabart_ubicacion.ST=1"
            End If
            Ssql = Ssql & " GROUP By tabart.cia,tabart.codlin,tabart.codart "
            cmd.CommandText = Ssql
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datArticulo = New TABART()

                    With datArticulo
                        .CIA = Convert.ToInt32(Row("CIA"))
                        .CODLIN = Row("CODLIN")
                        .CODART = Row("CODART")
                        .CODREF = Row("CODREF")
                        .CODFAB = Row("CODFAB")
                        .DESCRI = Row("DESCRI")
                        .CODMAR = Convert.ToInt32(Row("CODMAR"))
                        .DESMAR = Row("DESMAR")
                        .CODGRU = Convert.ToInt32(Row("CODGRU"))
                        .DESCAT = Row("DESCAT")
                        .CODSUBCAT = Convert.ToInt32(Row("CODSUBCAT"))
                        .DESSUBCAT = Row("DESSUBCAT")
                        .MODELO = Row("MODELO")
                        .GARANTIA = Row("GARANTIA")
                        .COSDOL = Convert.ToDouble(Row("COSDOL"))
                        .COSSOL = Convert.ToDouble(Row("COSSOL"))
                        .PRECOM = Convert.ToDouble(Row("PRECOM"))
                        .CODPRO = Convert.ToInt32(Row("CODPRO"))
                        .FECCOM = Row("FECCOM")
                        .AFECTO = Convert.ToInt32(Row("AFECTO"))
                        .STVEN = Convert.ToInt32(Row("STVEN"))
                        .STWEB = Convert.ToInt32(Row("STWEB"))
                        .STOFE = Convert.ToInt32(Row("STOFE"))
                        .STLIS = Convert.ToInt32(Row("STLIS"))
                        .ISC = Convert.ToDouble(Row("ISC"))
                        .STICBPER = Convert.ToInt32(Row("STICBPER"))
                        .TIPMON = Convert.ToInt32(Row("TIPMON"))
                        .DESMON = If(.TIPMON = MON_SOLES, SOLES, DOLARES)
                        .ESPECI = Row("ESPECI")
                        .FECALT = Row("FECALT")
                        .USRALT = Convert.ToInt32(Row("USRALT"))
                        .FECACT = Row("FECACT")
                        .USRMOD = Convert.ToInt32(Row("USRMOD"))
                        .FECMOD = Row("FECMOD")
                        .SIT = Convert.ToInt32(Row("SIT"))
                        .DESEST = If(.SIT = ESTADO_ACTIVO, ACTIVO, INACTIVO)

                    End With

                    lstArticulo.Add(datArticulo)
                End While
                Return lstArticulo
            Else
                Return Nothing
            End If
        End Using
    End Function


    Public Function Select_tabart_by_cod(ByVal objDato As TABART) As TABART
        Dim dr As OdbcDataReader
        Dim datArticulo As TABART
        Dim lstArticulo As New List(Of TABART)
        Dim lstArticuloxDetalle As List(Of TABART_SUCURSAL)
        Dim lstArticuloxUbicac As List(Of TABART_UBICACION)
        Dim Row As Dictionary(Of String, String)
        Using cmd As New OdbcCommand()
            cmd.Connection = Cn
            Ssql = "SELECT  tabart.CIA, CODLIN, CODART, CODREF, CODFAB, tabart.DESCRI, CODMAR, tabart.CODGRU, CODSUBCAT, MODELO, GARANTIA, COSDOL, COSSOL, PRECOM,"
            Ssql = Ssql & " CODPRO, FECCOM, AFECTO, STVEN, STWEB, STOFE, STLIS, TIPMON, ESPECI, FECALT, USRALT, FECACT, USRMOD, FECMOD, SIT,"
            Ssql = Ssql & " tabmar.des DESMAR,tabgru.des DESCAT,tabsubcat.descri DESSUBCAT,ISC,STICBPER "
            Ssql = Ssql & " FROM tabart "
            Ssql = Ssql & " LEFT JOIN tabmar ON tabmar.cia=tabart.cia and tabmar.cod=tabart.codmar "
            Ssql = Ssql & " LEFT JOIN tabgru ON tabgru.cia=tabart.cia and tabart.codgru=tabgru.cod "
            Ssql = Ssql & " LEFT JOIN tabsubcat ON tabsubcat.cia=tabart.cia and tabsubcat.codgru=tabart.codgru and tabsubcat.cod=tabart.CODSUBCAT "
            Ssql = Ssql & " LEFT JOIN tabmon ON tabmon.cod=tabart.tipmon "
            Ssql = Ssql & " WHERE tabart.cia= " & GCia & " AND tabart.codlin='00' AND tabart.codart='" & objDato.CODART & "' "

            cmd.CommandText = Ssql
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Row = FetchAsoc(dr)
                datArticulo = New TABART()
                lstArticuloxDetalle = New List(Of TABART_SUCURSAL)
                With datArticulo
                    .CIA = Convert.ToInt32(Row("CIA"))
                    .CODLIN = Row("CODLIN")
                    .CODART = Row("CODART")
                    .CODREF = Row("CODREF")
                    .CODFAB = Row("CODFAB")
                    .DESCRI = Row("DESCRI")
                    .CODMAR = Convert.ToInt32(Row("CODMAR"))
                    .DESMAR = Row("DESMAR")
                    .CODGRU = Convert.ToInt32(Row("CODGRU"))
                    .DESCAT = Row("DESCAT")
                    .CODSUBCAT = Convert.ToInt32(Row("CODSUBCAT"))
                    .DESSUBCAT = Row("DESSUBCAT")
                    .MODELO = Row("MODELO")
                    .GARANTIA = Row("GARANTIA")
                    .COSDOL = Convert.ToDouble(Row("COSDOL"))
                    .COSSOL = Convert.ToDouble(Row("COSSOL"))
                    .PRECOM = Convert.ToDouble(Row("PRECOM"))
                    .CODPRO = Convert.ToInt32(Row("CODPRO"))
                    .FECCOM = Row("FECCOM")
                    .AFECTO = Convert.ToInt32(Row("AFECTO"))
                    .STVEN = Convert.ToInt32(Row("STVEN"))
                    .STWEB = Convert.ToInt32(Row("STWEB"))
                    .STOFE = Convert.ToInt32(Row("STOFE"))
                    .STLIS = Convert.ToInt32(Row("STLIS"))
                    .TIPMON = Convert.ToInt32(Row("TIPMON"))
                    .ISC = Convert.ToDouble(Row("ISC"))
                    .STICBPER = Convert.ToInt32(Row("STICBPER"))
                    .DESMON = If(.TIPMON = MON_SOLES, SOLES, DOLARES)
                    .ESPECI = Row("ESPECI")
                    .FECALT = Row("FECALT")
                    .USRALT = Convert.ToInt32(Row("USRALT"))
                    .FECACT = Row("FECACT")
                    .USRMOD = Convert.ToInt32(Row("USRMOD"))
                    .FECMOD = Row("FECMOD")
                    .SIT = Convert.ToInt32(Row("SIT"))
                    .DESEST = If(.SIT = ESTADO_ACTIVO, ACTIVO, INACTIVO)

                    lstArticuloxDetalle = SelectAll_tabart_precios(New TABART_SUCURSAL With {.CIA = GCia, .CODLIN = "00", .CODART = objDato.CODART})
                    lstArticuloxUbicac = SelectAll_tabart_ubicacion(New TABART_SUCURSAL With {.CIA = GCia, .CODLIN = "00", .CODART = objDato.CODART})

                    .LISTAPRECIOS = lstArticuloxDetalle
                    .LISTASUBICACION = lstArticuloxUbicac
                End With
                Return datArticulo
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Function SelectAll_tabart_precios(ByVal objDato As TABART) As List(Of TABART_SUCURSAL)
        Dim dr As OdbcDataReader
        Dim datArtSucursal As TABART_SUCURSAL
        Dim lstArtSucursal As New List(Of TABART_SUCURSAL)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT tabart_sucursal.CIA, CODLIN, CODART, CODSUC,tabsuc.des DESSUC, CODUNI,tabuni.DESCRI DESUNI ,PORC_PUBLI, PRECIO_PUBLI, PORC_DISTRI,
                PRECIO_DISTRI, PORC_MIN, PRECIO_MIN, PRECIO_WEB, STMINIMO, EQUIVA, PESO,tabart_sucursal.STUNIDADCOMPRA
                FROM tabart_sucursal INNER JOIN tabsuc ON tabsuc.cia=tabart_sucursal.cia AND tabsuc.cod=tabart_sucursal.codsuc
                LEFT JOIN tabuni ON tabuni.cod=tabart_sucursal.CODUNI WHERE tabart_sucursal.CIA=" & GCia & " AND 
                tabart_sucursal.CODLIN='" & objDato.CODLIN & "' AND tabart_sucursal.codart='" & objDato.CODART & "'  ORDER BY CIA,CODSUC,DESSUC,tabart_sucursal.STMINIMO DESC "



        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datArtSucursal = New TABART_SUCURSAL()
                    With datArtSucursal
                        .CIA = Convert.ToInt32(Row("CIA"))
                        .CODLIN = Row("CODLIN")
                        .CODART = Row("CODART")
                        .CODSUC = Convert.ToInt32(Row("CODSUC"))
                        .DESSUC = Row("DESSUC")
                        .CODUNI = Convert.ToInt32(Row("CODUNI"))
                        .DESUNI = Row("DESUNI")
                        .PORC_PUBLI = Convert.ToDouble(Row("PORC_PUBLI"))
                        .PRECIO_PUBLI = Convert.ToDouble(Row("PRECIO_PUBLI"))
                        .PORC_DISTRI = Convert.ToDouble(Row("PORC_DISTRI"))
                        .PRECIO_DISTRI = Convert.ToDouble(Row("PRECIO_DISTRI"))
                        .PORC_MIN = Convert.ToDouble(Row("PORC_MIN"))
                        .PRECIO_MIN = Convert.ToDouble(Row("PRECIO_MIN"))
                        .PRECIO_WEB = Convert.ToDouble(Row("PRECIO_WEB"))
                        .STMINIMO = Convert.ToInt32(Row("STMINIMO"))
                        .ESMIN = If(.STMINIMO = 1, "SI", "NO")
                        .EQUIVA = Convert.ToInt32(Row("EQUIVA"))
                        .PESO = Convert.ToDouble(Row("PESO"))
                        .STUNIDADCOMPRA = Convert.ToInt32(Row("STUNIDADCOMPRA"))

                    End With
                    lstArtSucursal.Add(datArtSucursal)
                End While
                Return lstArtSucursal
            Else
                Return Nothing
            End If
        End Using
    End Function
    Public Function SelectAll_tabart_ubicacion(ByVal objDato As TABART) As List(Of TABART_UBICACION)
        Dim dr As OdbcDataReader
        Dim datArtSucursal As TABART_UBICACION
        Dim lstArtSucursal As New List(Of TABART_UBICACION)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT Tabsuc.CIA, '00' CODLIN,IFNULL(CODART,'')CODART, tabsuc.cod CODSUC,tabsuc.des DESSUC,IFNULL(UBICACION,'')UBICACION,IFNULL(STOCKMINIMO,0)STOCKMINIMO ,IFNULL(tabart_ubicacion.ST,0) ST
                FROM tabart_ubicacion RIGHT JOIN tabsuc ON tabsuc.cia=tabart_ubicacion.cia AND tabsuc.cod=tabart_ubicacion.codsuc AND  tabart_ubicacion.CODLIN='00' AND tabart_ubicacion.codart='" & objDato.CODART & "'
                WHERE tabsuc.CIA=" & GCia & " ORDER BY CIA,CODSUC,DESSUC "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datArtSucursal = New TABART_UBICACION()
                    With datArtSucursal
                        .CIA = Convert.ToInt32(Row("CIA"))
                        .CODLIN = Row("CODLIN")
                        .CODART = Row("CODART")
                        .CODSUC = Convert.ToInt32(Row("CODSUC"))
                        .DESSUC = Row("DESSUC")
                        .UBICACION = Row("UBICACION")
                        .STOCKMINIMO = Convert.ToDouble(Row("STOCKMINIMO"))
                        .ST = Convert.ToInt32(Row("ST"))
                        .DESACT = If(.ST = ESTADO_ACTIVO, ACTIVO, INACTIVO)
                    End With
                    lstArtSucursal.Add(datArtSucursal)
                End While
                Return lstArtSucursal
            Else
                Return Nothing
            End If
        End Using
    End Function
    Public Function ValidaCodFab(ByVal objDato As TABART) As datRetorno
        Dim ind As String
        Dim odatRetorno As New datRetorno
        Ssql = "call pa_verifica_codfabuni('" & GCia & "','" & objDato.CODART & "','" & objDato.CODFAB & "',@msg); "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            ind = Convert.ToString(cmd.ExecuteScalar)
        End Using
        odatRetorno.data = (Len(ind.Trim) > 0)
        odatRetorno.msg = ind
        Return odatRetorno
    End Function
    Public Function SelectAll_Articulo_x_Suc(ByVal objDato As TABART_SUCURSAL) As List(Of TABART)
        Dim dr As OdbcDataReader
        Dim datArticulo As TABART
        Dim lstArticulo As New List(Of TABART)
        Dim Criterio As String()
        Dim Crit As String = objDato.DESCRI.Trim
        Dim Row As Dictionary(Of String, String)
        Using cmd As New OdbcCommand()
            cmd.Connection = Cn
            Ssql = "SELECT  tabart.CIA, tabart.CODLIN, tabart.CODART, CODREF, CODFAB, tabart.DESCRI, CODMAR, tabart.CODGRU, CODSUBCAT, MODELO, GARANTIA, COSDOL, COSSOL, PRECOM,"
            Ssql = Ssql & " CODPRO, FECCOM, AFECTO, STVEN, STWEB, STOFE, STLIS, TIPMON, ESPECI, FECALT, USRALT, FECACT, USRMOD, FECMOD, SIT,"
            Ssql = Ssql & " tabmar.des DESMAR,tabgru.des DESCAT,tabsubcat.descri DESSUBCAT,ISC,STICBPER "
            Ssql = Ssql & " FROM tabart "
            Ssql = Ssql & " LEFT JOIN tabmar ON tabmar.cia=tabart.cia and tabmar.cod=tabart.codmar "
            Ssql = Ssql & " LEFT JOIN tabgru ON tabgru.cia=tabart.cia and tabart.codgru=tabgru.cod "
            Ssql = Ssql & " LEFT JOIN tabsubcat ON tabsubcat.cia=tabart.cia and tabsubcat.codgru=tabart.codgru and tabsubcat.cod=tabart.CODSUBCAT "
            Ssql = Ssql & " LEFT JOIN tabmon ON tabmon.cod=tabart.tipmon "
            Ssql = Ssql & " LEFT JOIN tabart_sucursal ON tabart.cia=tabart_sucursal.cia AND tabart_sucursal.codlin=tabart.codlin AND tabart_sucursal.codart=tabart.codart AND tabart_sucursal.codsuc=" & objDato.CODSUC & ""
            Ssql = Ssql & " LEFT JOIN tabart_ubicacion ON  tabart.cia=tabart_ubicacion.cia AND tabart_ubicacion.codlin=tabart.codlin AND tabart_ubicacion.codart=tabart.codart AND tabart_ubicacion.codsuc=" & objDato.CODSUC & ""
            Ssql = Ssql & " WHERE tabart.cia= " & GCia & " AND SIT=0 "
            If Crit.Length > 0 Then ' BÚSQUEDA DE CRITERIO POR ESPACIOS
                Criterio = Crit.Split(Convert.ToChar(" "))
                For Each item As String In Criterio
                    Ssql = Ssql & " AND (tabart.CODART='%" & item & "%' OR  CODFAB LIKE '%" & item & "%' OR tabart.DESCRI LIKE '%" & item & "%' OR tabmar.des LIKE '%" & item & "%' OR tabgru.des LIKE '%" & item & "%')"
                Next
            End If



            Ssql = Ssql & " GROUP By tabart.cia,tabart.codlin,tabart.codart "
            cmd.CommandText = Ssql
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datArticulo = New TABART()

                    With datArticulo
                        .CIA = Convert.ToInt32(Row("CIA"))
                        .CODLIN = Row("CODLIN")
                        .CODART = Row("CODART")
                        .CODREF = Row("CODREF")
                        .CODFAB = Row("CODFAB")
                        .DESCRI = Row("DESCRI")
                        .CODMAR = Convert.ToInt32(Row("CODMAR"))
                        .DESMAR = Row("DESMAR")
                        .CODGRU = Convert.ToInt32(Row("CODGRU"))
                        .DESCAT = Row("DESCAT")
                        .CODSUBCAT = Convert.ToInt32(Row("CODSUBCAT"))
                        .DESSUBCAT = Row("DESSUBCAT")
                        .MODELO = Row("MODELO")
                        .GARANTIA = Row("GARANTIA")
                        .COSDOL = Convert.ToDouble(Row("COSDOL"))
                        .COSSOL = Convert.ToDouble(Row("COSSOL"))
                        .PRECOM = Convert.ToDouble(Row("PRECOM"))
                        .CODPRO = Convert.ToInt32(Row("CODPRO"))
                        .FECCOM = Row("FECCOM")
                        .AFECTO = Convert.ToInt32(Row("AFECTO"))
                        .STVEN = Convert.ToInt32(Row("STVEN"))
                        .STWEB = Convert.ToInt32(Row("STWEB"))
                        .STOFE = Convert.ToInt32(Row("STOFE"))
                        .STLIS = Convert.ToInt32(Row("STLIS"))
                        .ISC = Convert.ToDouble(Row("ISC"))
                        .STICBPER = Convert.ToInt32(Row("STICBPER"))
                        .TIPMON = Convert.ToInt32(Row("TIPMON"))
                        .DESMON = If(.TIPMON = MON_SOLES, SOLES, DOLARES)
                        .ESPECI = Row("ESPECI")
                        .FECALT = Row("FECALT")
                        .USRALT = Convert.ToInt32(Row("USRALT"))
                        .FECACT = Row("FECACT")
                        .USRMOD = Convert.ToInt32(Row("USRMOD"))
                        .FECMOD = Row("FECMOD")
                        .SIT = Convert.ToInt32(Row("SIT"))
                        .DESEST = If(.SIT = ESTADO_ACTIVO, ACTIVO, INACTIVO)

                    End With

                    lstArticulo.Add(datArticulo)
                End While
                Return lstArticulo
            Else
                Return Nothing
            End If
        End Using
    End Function
    Public Function Select_tabart_by_cod_x_suc(ByVal objDato As TABART_SUCURSAL) As TABART
        Dim dr As OdbcDataReader
        Dim datArticulo As TABART
        Dim lstArticulo As New List(Of TABART)
        Dim lstArticuloxDetalle As List(Of TABART_SUCURSAL)
        Dim lstArticuloxUbicac As List(Of TABART_UBICACION)
        Dim Row As Dictionary(Of String, String)
        Using cmd As New OdbcCommand()
            cmd.Connection = Cn
            Ssql = "SELECT  tabart.CIA, tabart.CODLIN, tabart.CODART, CODREF, CODFAB, tabart.DESCRI, CODMAR, tabart.CODGRU, CODSUBCAT, MODELO, GARANTIA, COSDOL, COSSOL, PRECOM,"
            Ssql = Ssql & " CODPRO, FECCOM, AFECTO, STVEN, STWEB, STOFE, STLIS, TIPMON, ESPECI, FECALT, USRALT, FECACT, USRMOD, FECMOD, SIT,"
            Ssql = Ssql & " tabmar.des DESMAR,tabgru.des DESCAT,tabsubcat.descri DESSUBCAT,ISC,STICBPER "
            Ssql = Ssql & " FROM tabart "
            Ssql = Ssql & " LEFT JOIN tabmar ON tabmar.cia=tabart.cia and tabmar.cod=tabart.codmar "
            Ssql = Ssql & " LEFT JOIN tabgru ON tabgru.cia=tabart.cia and tabart.codgru=tabgru.cod "
            Ssql = Ssql & " LEFT JOIN tabsubcat ON tabsubcat.cia=tabart.cia and tabsubcat.codgru=tabart.codgru and tabsubcat.cod=tabart.CODSUBCAT "
            Ssql = Ssql & " LEFT JOIN tabmon ON tabmon.cod=tabart.tipmon "
            Ssql = Ssql & " LEFT JOIN tabart_ubicacion ON  tabart.cia=tabart_ubicacion.cia AND tabart_ubicacion.codlin=tabart.codlin AND tabart_ubicacion.codart=tabart.codart AND tabart_ubicacion.codsuc=" & objDato.CODSUC & ""
            Ssql = Ssql & " WHERE tabart.cia= " & GCia & " AND tabart.codlin='00' AND tabart.codart='" & objDato.CODART & "' "

            cmd.CommandText = Ssql
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Row = FetchAsoc(dr)
                datArticulo = New TABART()
                lstArticuloxDetalle = New List(Of TABART_SUCURSAL)
                With datArticulo
                    .CIA = Convert.ToInt32(Row("CIA"))
                    .CODLIN = Row("CODLIN")
                    .CODART = Row("CODART")
                    .CODREF = Row("CODREF")
                    .CODFAB = Row("CODFAB")
                    .DESCRI = Row("DESCRI")
                    .CODMAR = Convert.ToInt32(Row("CODMAR"))
                    .DESMAR = Row("DESMAR")
                    .CODGRU = Convert.ToInt32(Row("CODGRU"))
                    .DESCAT = Row("DESCAT")
                    .CODSUBCAT = Convert.ToInt32(Row("CODSUBCAT"))
                    .DESSUBCAT = Row("DESSUBCAT")
                    .MODELO = Row("MODELO")
                    .GARANTIA = Row("GARANTIA")
                    .COSDOL = Convert.ToDouble(Row("COSDOL"))
                    .COSSOL = Convert.ToDouble(Row("COSSOL"))
                    .PRECOM = Convert.ToDouble(Row("PRECOM"))
                    .CODPRO = Convert.ToInt32(Row("CODPRO"))
                    .FECCOM = Row("FECCOM")
                    .AFECTO = Convert.ToInt32(Row("AFECTO"))
                    .STVEN = Convert.ToInt32(Row("STVEN"))
                    .STWEB = Convert.ToInt32(Row("STWEB"))
                    .STOFE = Convert.ToInt32(Row("STOFE"))
                    .STLIS = Convert.ToInt32(Row("STLIS"))
                    .TIPMON = Convert.ToInt32(Row("TIPMON"))
                    .ISC = Convert.ToDouble(Row("ISC"))
                    .STICBPER = Convert.ToInt32(Row("STICBPER"))
                    .DESMON = If(.TIPMON = MON_SOLES, SOLES, DOLARES)
                    .ESPECI = Row("ESPECI")
                    .FECALT = Row("FECALT")
                    .USRALT = Convert.ToInt32(Row("USRALT"))
                    .FECACT = Row("FECACT")
                    .USRMOD = Convert.ToInt32(Row("USRMOD"))
                    .FECMOD = Row("FECMOD")
                    .SIT = Convert.ToInt32(Row("SIT"))
                    .DESEST = If(.SIT = ESTADO_ACTIVO, ACTIVO, INACTIVO)

                    lstArticuloxDetalle = SelectAll_tabart_precios(New TABART_SUCURSAL With {.CIA = GCia, .CODLIN = "00", .CODART = objDato.CODART})
                    lstArticuloxUbicac = SelectAll_tabart_ubicacion(New TABART_SUCURSAL With {.CIA = GCia, .CODLIN = "00", .CODART = objDato.CODART})

                    .LISTAPRECIOS = lstArticuloxDetalle
                    .LISTASUBICACION = lstArticuloxUbicac
                End With
                Return datArticulo
            Else
                Return Nothing
            End If
        End Using
    End Function

End Class
