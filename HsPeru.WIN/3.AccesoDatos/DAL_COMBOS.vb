
Imports System.Data.Odbc
Imports System.Reflection
Public Class DAL_COMBOS
    ''' <summary>
    ''' FILTRA LOS DOC PARA EL MANTENIMIENTO DE FACTURA/BOLETA DE VENTA /NOTA DE VENTA/NOTA PEDIDO
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaTipdocCPE() As List(Of TG_TABDOC)
        Dim dr As OdbcDataReader
        Dim datTabdoc As TG_TABDOC
        Dim lstTabdoc As New List(Of TG_TABDOC)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  COD, DESCRI, DESABR,CODSUN,STELEC FROM tg_tabdoc WHERE cod in (1,3,40,41);"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabdoc = New TG_TABDOC()
                    datTabdoc.COD = Convert.ToInt32(Row("COD"))
                    datTabdoc.DESCRI = Row("DESCRI")
                    datTabdoc.DESABR = Row("DESABR")
                    datTabdoc.CODSUN = Convert.ToInt32(Row("CODSUN"))
                    datTabdoc.STELEC = Convert.ToInt32(Row("STELEC"))
                    lstTabdoc.Add(datTabdoc)
                End While
                Return lstTabdoc
            Else
                Return Nothing
            End If
        End Using
    End Function



    ''' <summary>
    ''' FILTRA LOS DOC REF PARA EL MANTENIMIENTO DE FACTURA/BOLETA DE VENTA /NOTA DE VENTA/NOTA PEDIDO 
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaTipdocREF() As List(Of TG_TABDOC)
        Dim dr As OdbcDataReader
        Dim datTabdoc As TG_TABDOC
        Dim lstTabdoc As New List(Of TG_TABDOC)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  COD, DESCRI, DESABR,CODSUN,STELEC FROM tg_tabdoc WHERE cod in (40,70);"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabdoc = New TG_TABDOC()
                    datTabdoc.COD = Convert.ToInt32(Row("COD"))
                    datTabdoc.DESCRI = Row("DESCRI")
                    datTabdoc.DESABR = Row("DESABR")
                    datTabdoc.CODSUN = Convert.ToInt32(Row("CODSUN"))
                    datTabdoc.STELEC = Convert.ToInt32(Row("STELEC"))
                    lstTabdoc.Add(datTabdoc)
                End While
                Return lstTabdoc
            Else
                Return Nothing
            End If
        End Using
    End Function



    ''' <summary>
    ''' LISTA LOS DOCUMENTOS DE VENTA PARA LOS COMBOS DE FITROS PARA VENTA
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaTipdocCPEALL() As List(Of TG_TABDOC)
        Dim dr As OdbcDataReader
        Dim datTabdoc As TG_TABDOC
        Dim lstTabdoc As New List(Of TG_TABDOC)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  COD, DESCRI DESABR,CODSUN FROM tg_tabdoc WHERE cod in (1,3,7,8,40,41);"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabdoc = New TG_TABDOC()
                    datTabdoc.COD = Convert.ToInt32(Row("COD"))
                    datTabdoc.DESCRI = Row("DESCRI")
                    datTabdoc.DESABR = Row("DESABR")
                    datTabdoc.CODSUN = Convert.ToInt32(Row("CODSUN"))
                    lstTabdoc.Add(datTabdoc)
                End While
                Return lstTabdoc
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' CARGA LAS SERIE DEPENDIENDO DEL TIPO DE CPE [NORMAL O ELECTRÓNICO], ADEMÁS DE CONSIDERAR LA SUCURSAL
    ''' </summary>
    ''' <param name="oTipoCPE"></param>
    ''' <returns></returns>
    Public Function CargaSerie(ByVal oTipoCPE As Integer, Optional ByVal TipDoc As Integer = 0, Optional DirTipDoc As Integer = 0) As List(Of TABSER)

        Dim dr As OdbcDataReader
        Dim datTabSer As TABSER
        Dim lstTabSer As New List(Of TABSER)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  CIA, NROSER, CODSUC, ELEC_TIPDOC, DIR_TIPDOC, STSER, STENVIA FROM tabser WHERE cia=" & GCia & " "
        If GCodSuc > 0 Then
            Ssql = Ssql & " AND CODSUC=" & GCodSuc
        End If
        If oTipoCPE = 1 Then   'Electrónico
            Ssql = Ssql & " AND ELEC_TIPDOC =" & TipDoc & " "
            If DirTipDoc > 0 Then
                Ssql = Ssql & " AND DIRTIPDOC = " & DirTipDoc & " "
            End If
        End If
        If oTipoCPE = 0 Then  'Numérico
            Ssql = Ssql & " AND ELEC_TIPDOC = 0 "
        End If


        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabSer = New TABSER()

                    With datTabSer
                        .CIA = Convert.ToInt32(Row("CIA"))
                        .NROSER = Row("NROSER")
                        .CODSUC = Convert.ToInt32(Row("CODSUC"))
                        .ELEC_TIPDOC = Convert.ToInt32(Row("ELEC_TIPDOC"))
                        .DIR_TIPDOC = Convert.ToInt32(Row("DIR_TIPDOC"))
                        .STSER = Convert.ToInt32(Row("STSER"))
                        .STENVIA = Convert.ToInt32(Row("STENVIA"))
                    End With
                    lstTabSer.Add(datTabSer)
                End While
                Return lstTabSer
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' LISTA LAS FORMAS DE PAGO PARA LOS COMPROBANTES DE VENTA
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaFormaPago() As List(Of TABPAG_CPE)
        Dim dr As OdbcDataReader
        Dim datTabpag_cpe As TABPAG_CPE
        Dim lstTabpag_cpe As New List(Of TABPAG_CPE)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT    COD, DESCRI, DESABR, CTASOL, CTADOL, CODSUN, ST FROM tabpag_cpe WHERE st=0;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabpag_cpe = New TABPAG_CPE()
                    datTabpag_cpe.COD = Convert.ToInt32(Row("COD"))
                    datTabpag_cpe.DESCRI = Row("DESCRI")
                    datTabpag_cpe.DESABR = Row("DESABR")
                    datTabpag_cpe.CTASOL = Row("CTASOL")
                    datTabpag_cpe.CTADOL = Row("CTADOL")
                    datTabpag_cpe.CODSUN = Convert.ToInt32(Row("CODSUN"))
                    datTabpag_cpe.ST = Convert.ToInt32(Row("ST"))
                    lstTabpag_cpe.Add(datTabpag_cpe)
                End While
                Return lstTabpag_cpe
            Else
                Return Nothing
            End If
        End Using

    End Function
    ''' <summary>
    ''' CARGA LOS TIPO DE MONEDA SOLES/ DÓLARES
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaMoneda() As List(Of TABMON)
        Dim dr As OdbcDataReader
        Dim datTabmon As TABMON
        Dim lstTabmon As New List(Of TABMON)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT    COD, DES, DESABR,ST FROM tabmon WHERE st=0 AND cod in (1,2);"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabmon = New TABMON()
                    datTabmon.COD = Convert.ToInt32(Row("COD"))
                    datTabmon.DES = Row("DES")
                    datTabmon.DESABR = Row("DESABR")

                    lstTabmon.Add(datTabmon)
                End While
                Return lstTabmon
            Else
                Return Nothing
            End If
        End Using

    End Function
    ''' <summary>
    ''' CARGA LOS VENDEDORES EN LOS COMBOS DE DOCUMENTOS
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaVendedor() As List(Of VENDEDOR)
        Dim dr As OdbcDataReader
        Dim datTabven As VENDEDOR
        Dim lstTabven As New List(Of VENDEDOR)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT   CIA, COD, DES, CODSUC, SIT, PWDVEN, STSUP FROM  tg_tabven  WHERE CIA =" & GCia & " AND SIT=0  "
        If GcodVen > 0 Then
            Ssql = Ssql & " AND COD=" & GcodVen
        End If
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabven = New VENDEDOR()
                    datTabven.COD = Convert.ToInt32(Row("COD"))
                    datTabven.DES = Row("DES")
                    datTabven.CODSUC = Convert.ToInt32(Row("CODSUC"))
                    datTabven.SIT = Convert.ToInt32(Row("SIT"))
                    datTabven.PWDVEN = Row("PWDVEN")
                    datTabven.STSUP = Convert.ToInt32(Row("STSUP"))

                    lstTabven.Add(datTabven)
                End While
                Return lstTabven
            Else
                Return Nothing
            End If
        End Using

    End Function
    ''' <summary>
    ''' CARGA LA LISTA DE TIPO DE DOCUMENTO DEL CLIENTE (DNI,RUC,PAS,EXT,OTROS)
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaTipdocCliente() As List(Of TG_TIPDOC)
        Dim dr As OdbcDataReader
        Dim datTabTipdoc As TG_TIPDOC
        Dim lstTipdoc As New List(Of TG_TIPDOC)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT COD, DESCRI, DESABR,CSUN FROM tg_tipdoc;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabTipdoc = New TG_TIPDOC()
                    datTabTipdoc.COD = Convert.ToInt32(Row("COD"))
                    datTabTipdoc.DESCRI = Row("DESCRI")
                    datTabTipdoc.DESABR = Row("DESABR")
                    datTabTipdoc.CSUN = Convert.ToInt32(Row("CSUN"))
                    lstTipdoc.Add(datTabTipdoc)
                End While
                Return lstTipdoc
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' CARGA LA LISTA DE TIPO DE REGISTROS PARA LA TABLA DE CLIENTES (PROVEEDOR, CLIENTE,OBRERO , ETC)
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaTipRegCliente() As List(Of TG_TIPREG)
        Dim dr As OdbcDataReader
        Dim datTabTipreg As TG_TIPREG
        Dim lstTipreg As New List(Of TG_TIPREG)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT COD, DES, DESABR FROM tg_tipreg;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabTipreg = New TG_TIPREG()
                    datTabTipreg.COD = Convert.ToInt32(Row("COD"))
                    datTabTipreg.DES = Row("DES")
                    datTabTipreg.DESABR = Row("DESABR")
                    lstTipreg.Add(datTabTipreg)
                End While
                Return lstTipreg
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' LISTA EL GRUPO DE CLIENTES 
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaGrupoCliente() As List(Of GRUPOCLIENTE)
        Dim dr As OdbcDataReader
        Dim datGrupCliente As GRUPOCLIENTE
        Dim lstGrupoCliente As New List(Of GRUPOCLIENTE)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT CIA, COD, DES FROM cliprogrupos;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datGrupCliente = New GRUPOCLIENTE()
                    datGrupCliente.COD = Convert.ToInt32(Row("COD"))
                    datGrupCliente.DES = Row("DES")
                    datGrupCliente.CIA = Convert.ToInt32(Row("CIA"))
                    lstGrupoCliente.Add(datGrupCliente)
                End While
                Return lstGrupoCliente
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' LISTA LOS DEPARTAMENTOS
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaDepartamento() As List(Of UBIGEO.DEPARTAMENTO)
        Dim dr As OdbcDataReader
        Dim datDep As UBIGEO.DEPARTAMENTO
        Dim lstDepartamento As New List(Of UBIGEO.DEPARTAMENTO)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT CODDEP, NOMDEP FROM tg_tabdep;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datDep = New UBIGEO.DEPARTAMENTO()
                    datDep.CODDEP = Row("CODDEP")
                    datDep.NOMDEP = Row("NOMDEP")

                    lstDepartamento.Add(datDep)
                End While
                Return lstDepartamento
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' LISTA LAS PROVINCIAS
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaProvincia(CODDEP As String) As List(Of UBIGEO.PROVINCIA)
        Dim dr As OdbcDataReader
        Dim datProv As UBIGEO.PROVINCIA
        Dim lstProvincia As New List(Of UBIGEO.PROVINCIA)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT CODDEP,CODPRO, NOMPRO FROM tg_tabpro "
        Ssql = Ssql & " WHERE CODDEP='" & CODDEP & "' "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datProv = New UBIGEO.PROVINCIA()
                    datProv.CODDEP = Row("CODDEP")
                    datProv.CODPRO = Row("CODPRO")
                    datProv.NOMPRO = Row("NOMPRO")
                    lstProvincia.Add(datProv)
                End While
                Return lstProvincia
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' LISTA DE DISTRITOS
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaDistrito(CODDEP As String, CODPRO As String) As List(Of UBIGEO.DISTRITO)
        Dim dr As OdbcDataReader
        Dim datDistrito As UBIGEO.DISTRITO
        Dim lstDistrito As New List(Of UBIGEO.DISTRITO)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT   CODDEP, CODPRO, CODDIS, NOMDIS FROM tg_tabdis "
        Ssql = Ssql & " WHERE CODDEP='" & CODDEP & "' AND CODPRO ='" & CODPRO & "' "
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datDistrito = New UBIGEO.DISTRITO()
                    datDistrito.CODDEP = Row("CODDEP")
                    datDistrito.CODPRO = Row("CODPRO")
                    datDistrito.CODDIS = Row("CODDIS")
                    datDistrito.NOMDIS = Row("NOMDIS")
                    lstDistrito.Add(datDistrito)
                End While
                Return lstDistrito
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' LISTA LAS CIUDADES
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaCiudad(CODDEP As String, CODPRO As String, CODDIS As String) As List(Of UBIGEO.CIUDAD)
        Dim dr As OdbcDataReader
        Dim datCiudad As UBIGEO.CIUDAD
        Dim lstCiudad As New List(Of UBIGEO.CIUDAD)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT    CODDEP, CODPRO, CODDIS, CODCIU, NOMCIU FROM tg_tabciu "
        Ssql = Ssql & " WHERE CODDEP='" & CODDEP & "' AND CODPRO ='" & CODPRO & "' AND CODDIS='" & CODDIS & "'"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
            While dr.Read()
                Row = FetchAsoc(dr)
                datCiudad = New UBIGEO.CIUDAD()
                datCiudad.CODDEP = Row("CODDEP")
                datCiudad.CODPRO = Row("CODPRO")
                datCiudad.CODDIS = Row("CODDIS")
                datCiudad.CODCIU = Row("CODCIU")
                datCiudad.NOMCIU = Row("NOMCIU")
                lstCiudad.Add(datCiudad)
            End While
            Return lstCiudad
        Else
            Return Nothing
        End If
        End Using
    End Function
    ''' <summary>
    ''' LISTA DE PAISES
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaPais() As List(Of UBIGEO.PAIS)
        Dim dr As OdbcDataReader
        Dim datPais As UBIGEO.PAIS
        Dim lstPais As New List(Of UBIGEO.PAIS)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  COD, DES FROM tg_tabpais;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datPais = New UBIGEO.PAIS()
                    datPais.COD = Convert.ToInt32(Row("COD"))
                    datPais.DES = Row("DES")
                    lstPais.Add(datPais)
                End While
                Return lstPais
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' LISTA CARGOS
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaCargos() As List(Of TABCARGO)
        Dim dr As OdbcDataReader
        Dim datCargo As TABCARGO
        Dim lstCargo As New List(Of TABCARGO)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  COD, DES FROM tabcar;"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datCargo = New TABCARGO()
                    datCargo.COD = Convert.ToInt32(Row("COD"))
                    datCargo.DES = Row("DES")
                    lstCargo.Add(datCargo)
                End While
                Return lstCargo
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' LISTA LA UNIDADES REGISTRADAS EN BD
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaUnidades(ByVal Optional Estado As Integer = 0) As List(Of UNIDAD)
        Dim dr As OdbcDataReader
        Dim datUnidad As UNIDAD
        Dim lstUnidades As New List(Of UNIDAD)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  COD, DESCRI, DESABR, CANUNI, ST FROM tabuni WHERE st=" & Estado & ";"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datUnidad = New UNIDAD()
                    datUnidad.COD = Convert.ToInt32(Row("COD"))
                    datUnidad.DESCRI = Row("DESCRI")
                    datUnidad.DESABR = Row("DESABR")
                    datUnidad.CANUNI = Convert.ToDouble(Row("CANUNI"))
                    datUnidad.ST = Convert.ToInt32(Row("ST"))
                    lstUnidades.Add(datUnidad)
                End While
                Return lstUnidades
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' LISTA LAS CATEGORIAS REGISTRADAS
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaCategoria(ByVal Optional Estado As Integer = 0) As List(Of CATEGORIA)
        Dim dr As OdbcDataReader
        Dim datCategoria As CATEGORIA
        Dim lstCategoria As New List(Of CATEGORIA)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  CIA, COD, DES, STOCK, ST, CODWEB FROM tabgru WHERE cia=" & GCia & " AND  st=" & Estado & ";"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datCategoria = New CATEGORIA()
                    datCategoria.COD = Convert.ToInt32(Row("COD"))
                    datCategoria.DES = Row("DES")
                    datCategoria.STOCK = Row("STOCK")
                    datCategoria.ST = Convert.ToInt32(Row("ST"))
                    datCategoria.CODWEB = Convert.ToInt32(Row("CODWEB"))
                    lstCategoria.Add(datCategoria)
                End While
                Return lstCategoria
            Else
                Return Nothing
            End If
        End Using
    End Function
    ''' <summary>
    ''' LISTA LAS SUBCATEGORIAS
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaSubCategoria(ByVal codcat As Integer, ByVal Optional Estado As Integer = 0) As List(Of SUBCATEGORIA)
        Dim dr As OdbcDataReader
        Dim datSubCategoria As SUBCATEGORIA
        Dim lstSubCategoria As New List(Of SUBCATEGORIA)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  CIA, COD, CODGRU, DESCRI, ST, CODWEB FROM tabsubcat WHERE cia=" & GCia & " AND CODGRU=" & codcat & " AND st=" & Estado & ";"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datSubCategoria = New SUBCATEGORIA()
                    datSubCategoria.CIA = Convert.ToInt32(Row("CIA"))
                    datSubCategoria.COD = Convert.ToInt32(Row("COD"))
                    datSubCategoria.CODGRU = Convert.ToInt32(Row("CODGRU"))
                    datSubCategoria.DESCRI = Row("DESCRI")
                    datSubCategoria.ST = Convert.ToInt32(Row("ST"))
                    datSubCategoria.CODWEB = Convert.ToInt32(Row("CODWEB"))
                    lstSubCategoria.Add(datSubCategoria)
                End While
                Return lstSubCategoria
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' LISTA LAS MARCA
    ''' </summary>
    ''' <param name="Estado"></param>
    ''' <returns></returns>
    Public Function CargaMarca(ByVal Optional Estado As Integer = 0) As List(Of MARCA)
        Dim dr As OdbcDataReader
        Dim datMarca As MARCA
        Dim lstMarca As New List(Of MARCA)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  CIA, COD, DES, ST, CODWEB FROM tabmar WHERE cia=" & GCia & "  AND st=" & Estado & ";"
        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datMarca = New MARCA()
                    datMarca.CIA = Convert.ToInt32(Row("CIA"))
                    datMarca.COD = Convert.ToInt32(Row("COD"))
                    datMarca.DES = Row("DES")
                    datMarca.ST = Convert.ToInt32(Row("ST"))
                    datMarca.CODWEB = Convert.ToInt32(Row("CODWEB"))
                    lstMarca.Add(datMarca)
                End While
                Return lstMarca
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' LISTA LAS SUCURSALES
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaSucursal(ByVal Optional Estado As Integer = 0) As List(Of TABSUC)
        Dim dr As OdbcDataReader
        Dim datTabsuc As TABSUC
        Dim lstTabsuc As New List(Of TABSUC)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  CIA, COD, DES, DIRSUC, TELEFONO, CELULAR, EMAIL, DESABR, NUMSER, FECINI, SIT  FROM tabsuc WHERE cia=" & GCia & " AND SIT=" & Estado & ""
        Using cmd As New OdbcCommand(Ssql, Cn)
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
    ''' <summary>
    ''' CARGA LAS SUCURSALES AGREGADAS DEL CLIENTE 
    ''' </summary>
    ''' <param name="codigo"></param>
    ''' <returns></returns>
    Public Function CargaSucursalesClientes(ByVal codigo As Long) As List(Of CLIPROSUCURSAL)
        Dim dr As OdbcDataReader
        Dim datTabsuc As CLIPROSUCURSAL
        Dim lstTabsuc As New List(Of CLIPROSUCURSAL)

        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT cliprosucursales.CIA, CODIGO, 0 CODSUC, 'PRINCIPAL' RAZSOC,'' NOMCON, DIRECC, cliprosucursales.CODDEP,tg_tabdep.NOMDEP, cliprosucursales.CODPRO,tg_tabpro.NOMPRO,
                        cliprosucursales.CODDIS,tg_tabdis.NOMDIS, cliprosucursales.CODCIU, tg_tabciu.NOMCIU,cliprosucursales.SIT 
                        FROM clipro cliprosucursales INNER JOIN tg_tabdep ON tg_tabdep.CODDEP=cliprosucursales.CODDEP 
                                              INNER JOIN tg_tabpro ON tg_tabpro.CODDEP=cliprosucursales.CODDEP  AND tg_tabpro.CODPRO= cliprosucursales.CODPRO
                                              INNER JOIN tg_tabdis ON tg_tabdis.CODDEP=cliprosucursales.CODDEP  AND tg_tabdis.CODPRO= cliprosucursales.CODPRO  AND tg_tabdis.CODDIS= cliprosucursales.CODDIS
                                              INNER JOIN tg_tabciu ON tg_tabciu.CODDEP=cliprosucursales.CODDEP  AND tg_tabciu.CODPRO= cliprosucursales.CODPRO  AND tg_tabciu.CODDIS= cliprosucursales.CODDIS and tg_tabciu.CODCIU= cliprosucursales.CODCIU
                                              WHERE cliprosucursales.CIA=" & GCia & " and codigo=" & codigo & " UNION ALL "
        Ssql = Ssql & "SELECT cliprosucursales.CIA, CODIGO, cliprosucursales.CODSUC, RAZSOC, NOMCON, DIRECC, cliprosucursales.CODDEP,tg_tabdep.NOMDEP, cliprosucursales.CODPRO,tg_tabpro.NOMPRO,
                        cliprosucursales.CODDIS,tg_tabdis.NOMDIS, cliprosucursales.CODCIU, tg_tabciu.NOMCIU, cliprosucursales.SIT 
                        FROM cliprosucursales INNER JOIN tg_tabdep ON tg_tabdep.CODDEP=cliprosucursales.CODDEP 
                                              INNER JOIN tg_tabpro ON tg_tabpro.CODDEP=cliprosucursales.CODDEP  AND tg_tabpro.CODPRO= cliprosucursales.CODPRO
                                              INNER JOIN tg_tabdis ON tg_tabdis.CODDEP=cliprosucursales.CODDEP  AND tg_tabdis.CODPRO= cliprosucursales.CODPRO  AND tg_tabdis.CODDIS= cliprosucursales.CODDIS
                                              INNER JOIN tg_tabciu ON tg_tabciu.CODDEP=cliprosucursales.CODDEP  AND tg_tabciu.CODPRO= cliprosucursales.CODPRO  AND tg_tabciu.CODDIS= cliprosucursales.CODDIS and tg_tabciu.CODCIU= cliprosucursales.CODCIU
                                              WHERE cliprosucursales.CIA=" & GCia & " and codigo=" & codigo



        Using cmd As New OdbcCommand(Ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datTabsuc = New CLIPROSUCURSAL()
                    With datTabsuc
                        .CIA = Convert.ToInt32(Row("CIA"))
                        .CODIGO = Convert.ToInt32(Row("CODIGO"))
                        .CODSUC = Convert.ToInt32(Row("CODSUC"))
                        .NOMDEP = Row("NOMDEP")
                        .NOMDIS = Row("NOMDIS")
                        .NOMPRO = Row("NOMPRO")
                        .DIRECC = Row("DIRECC")
                        .RAZSOC = Row("RAZSOC")
                    End With
                    lstTabsuc.Add(datTabsuc)
                End While
                Return lstTabsuc
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Function Obtener_Numdoc(Numser As String, Tipdoc As Integer) As TABFAC
        Dim oTabfac As New TABFAC
        Dim dr As OdbcDataReader
        Dim Row As Dictionary(Of String, String)
        Ssql = "call sp_numdoc('" & GCia & "','" & Numser & "','" & Tipdoc & "',@xnumdoc,@xcodsuc,@xdessuc); "
        Using cmd As New OdbcCommand
            cmd.Connection = Cn
            cmd.CommandText = Ssql
            cmd.ExecuteNonQuery()


            Ssql = "SELECT  cast(@xnumdoc as char) numdoc, cast(@xcodsuc as char) codsuc, cast(@xdessuc as char) dessuc;"
            cmd.CommandText = Ssql
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    With oTabfac
                        .NUMDOC = Row("numdoc").ToString()
                        .DESSUC = Row("dessuc").ToString()
                        .CODSUC = Convert.ToInt32(Row("codsuc"))
                    End With

                End While
                Return oTabfac
            Else
                Return Nothing
            End If
            dr.Close()
        End Using

    End Function


End Class
