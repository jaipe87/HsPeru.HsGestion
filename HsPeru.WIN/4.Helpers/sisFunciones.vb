
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Math
Module sisFunciones
    ''' <summary>
    ''' Llena el control ComboBox con objetos de negocio +  reflexión
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="ListaFuente"></param>
    ''' <param name="Valor"></param>
    ''' <param name="Texto"></param>
    ''' <param name="objComboBox"></param>
    ''' <param name="ItemAdicional"></param>
    Public Sub CargarComboBox(Of T As New)(ByVal ListaFuente As List(Of T),
                                                  ByVal Valor As String,
                                                  ByVal Texto As String,
                                                  ByRef objComboBox As ComboBox,
                                                  ByVal ItemAdicional As String)

        Dim lisAuxiliar As New List(Of T)
        Dim objAuxiliar As New T

        If ItemAdicional.Trim.Length > 0 Then

            Dim dato2(0) As Object
            dato2(0) = ItemAdicional

            objAuxiliar.GetType.InvokeMember(Texto, Reflection.BindingFlags.SetProperty, Nothing, objAuxiliar, dato2)

            lisAuxiliar.Add(objAuxiliar)
        End If
        If ListaFuente Is Nothing Then Return
        lisAuxiliar.AddRange(ListaFuente)

        objComboBox.DataSource = lisAuxiliar
        objComboBox.DisplayMember = Texto
        objComboBox.ValueMember = Valor

    End Sub

    ''' <summary>
    ''' Llena el control ComboBox con objetos de negocio
    ''' </summary>
    ''' <typeparam name="T">Tipo de la fuente de datos del ComboBox</typeparam>
    ''' <param name="ListaFuente">Fuente de datos</param>
    ''' <param name="Valor">Nombre de la propiedad a mostrar como valor del control</param>
    ''' <param name="Texto">Nombre de la propiedad a mostrar como texto del control</param>
    ''' <param name="objComboBox">objeto ComboBox a llenar</param>
    Public Sub CargarComboBox(Of T As New)(ByVal ListaFuente As List(Of T),
                                           ByVal Valor As String,
                                           ByVal Texto As String,
                                           ByRef objComboBox As ComboBox)

        If ListaFuente Is Nothing Then Return
        objComboBox.DataSource = ListaFuente
        objComboBox.DisplayMember = Texto
        objComboBox.ValueMember = Valor
        objComboBox.SelectedValue = DBNull.Value

    End Sub
    ''' <summary>
    ''' Para carga DataGridview
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="ListaFuente">Fuente de Datos</param>
    ''' <param name="objGrid">objeto Grid</param>
    ''' <remarks></remarks>
    Public Sub CargaDatagrid(Of T As New)(ByVal ListaFuente As List(Of T), ByVal objGrid As DataGridView, Optional ByVal autoGen As Boolean = False)

        objGrid.AutoGenerateColumns = autoGen
        objGrid.DataSource = ListaFuente
        objGrid.ClearSelection()
    End Sub

    Public Sub VerificaCombo(Of T)(ByVal objcombo As ComboBox, ByVal Valor As T)
        If objcombo.Items.Count = 1 Then
            objcombo.SelectedIndex = 0
            objcombo.Enabled = False
        Else
            objcombo.Enabled = True
            objcombo.SelectedValue = Valor
        End If
    End Sub

#Region "Combos en DGV"
    ''' <summary>
    ''' Llena el control DataGridViewComboBoxColumn con objetos de negocio
    ''' </summary>
    ''' <typeparam name="T">Tipo de la fuente de datos del ComboBox</typeparam>
    ''' <param name="ListaFuente">Fuente de datos</param>
    ''' <param name="Valor">Nombre de la propiedad a mostrar como valor del control</param>
    ''' <param name="Texto">Nombre de la propiedad a mostrar como texto del control</param>
    ''' <param name="objComboBox">objeto ComboBox a llenar</param>
    ''' <remarks></remarks>
    Public Sub CargarComboBoxColumns(Of T As New)(ByVal ListaFuente As List(Of T),
                                                  ByVal Valor As String,
                                                  ByVal Texto As String,
                                                  ByRef objComboBox As DataGridViewComboBoxColumn)

        objComboBox.DataSource = ListaFuente
        objComboBox.DisplayMember = Texto
        objComboBox.ValueMember = Valor

    End Sub


#End Region

    ''' <summary>
    ''' funciones para validar las cadenas de texto  solo numeros enteros
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SoloNumerosEnteros(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    ''' <summary>
    ''' funciones para validar las cadenas de texto  solo numeros  decimales
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SoloNumerosDecimales(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = False
        End If
    End Sub
    ''' <summary>
    ''' funciones para validar las cadenas de texto  solo letras
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Sololetras(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    ''' <summary>
    ''' Deshabilita los texbox en un formulario   
    ''' </summary>
    ''' <param name="form"></param>
    ''' <remarks></remarks>
    Public Sub deshabilitar_Texbox(ByVal form As Control)
        For Each k As Control In form.Controls
            If k.Controls.Count > 0 Then deshabilitar_Texbox(k)
            If TypeOf k Is TextBox Then DirectCast(k, TextBox).Enabled = False
        Next
    End Sub
    ''' <summary>
    ''' Limpia los texbox enun formulario
    ''' </summary>
    ''' <param name="form"></param>
    ''' <remarks></remarks>
    Public Sub Limpiar_Texbox(ByVal form As Control)
        For Each k As Control In form.Controls
            If k.Controls.Count > 0 Then Limpiar_Texbox(k)
            If TypeOf k Is TextBox Then DirectCast(k, TextBox).Clear()
        Next
    End Sub
    ''' <summary>
    ''' convierte los Nothing en string
    ''' </summary>
    ''' <param name="valor"></param>
    ''' <returns></returns>
    Public Function NothingToString(ByVal valor As Object) As String
        If valor Is Nothing Then
            Return ""
        Else
            Return valor.ToString
        End If
    End Function
    ''' <summary>
    ''' Convierte los nothing en Double
    ''' </summary>
    ''' <param name="valor"></param>
    ''' <returns></returns>
    Public Function NothingToDouble(ByVal valor As Object) As Double
        If valor Is Nothing Then
            Return 0
        Else
            If TypeOf valor Is String Then
                Return StringToDouble(valor)
            Else
                Return Convert.ToDouble(valor)
            End If

        End If
    End Function
    ''' <summary>
    ''' Convierte los nothing en integer
    ''' </summary>
    ''' <param name="valor"></param>
    ''' <returns></returns>
    Public Function NothingToInteger(ByVal valor As Object) As Int32
        If valor Is Nothing Then
            Return 0
        Else
            If TypeOf valor Is String Then
                Return StringToInteger(valor)
            Else
                Return Convert.ToInt32(valor)
            End If

        End If
    End Function
    ''' <summary>
    ''' Convierte los nothing en bool 
    ''' </summary>
    ''' <param name="valor"></param>
    ''' <returns></returns>
    Public Function NothingToBoolean(ByVal valor As Object) As Boolean
        If valor Is Nothing Then
            Return 0
        Else
            If TypeOf valor Is String Then
                Return StringToInteger(valor)
            Else
                Return Convert.ToBoolean(valor)
            End If

        End If
    End Function


    Public Function StringToDouble(ByVal valor As String) As Double
        Dim XDouble As Double = 0

        If Not Double.TryParse(valor, XDouble) Then
            Return 0
        Else
            Return XDouble
        End If
    End Function
    Public Function StringToInteger(ByVal valor As String) As Integer
        Dim xInteger As Integer = 0

        If Not Integer.TryParse(valor, xInteger) Then
            Return 0
        Else
            Return xInteger
        End If
    End Function

    Public Function StringToBoolean(ByVal valor As String) As String
        Dim xBoolean As Boolean = False

        If Not Boolean.TryParse(valor, xBoolean) Then
            Return False
        Else
            Return xBoolean
        End If
    End Function

    ''' <summary>
    ''' Deshabilita  los combobox en el formulario
    ''' </summary>
    ''' <param name="form"></param>
    ''' <remarks></remarks>
    Public Sub deshabilitar_combox(ByVal form As Control)
        For Each k As Control In form.Controls
            If k.Controls.Count > 0 Then deshabilitar_combox(k)
            If TypeOf k Is ComboBox Then DirectCast(k, ComboBox).Enabled = False
        Next
    End Sub
    ''' <summary>
    ''' Inicia los combobox de un formulario
    ''' </summary>
    ''' <param name="form"></param>
    ''' <remarks></remarks>
    Public Sub Limpiar_combox(ByVal form As Control)
        For Each k As Control In form.Controls
            If k.Controls.Count > 0 Then Limpiar_combox(k)
            If TypeOf k Is ComboBox Then DirectCast(k, ComboBox).SelectedIndex = 0
        Next
    End Sub
    Public Sub LimpiarTextbox(miform As Control)
        For Each k As Control In miform.Controls
            If k.Controls.Count > 0 Then
                LimpiarTextbox(k)
            End If
            If TypeOf k Is TextBox Then DirectCast(k, TextBox).Clear()

        Next
    End Sub

    ''' <summary>
    ''' Deshabilita los checkbox de un formulario
    ''' </summary>
    ''' <param name="form"></param>
    ''' <remarks></remarks>
    Public Sub Limpiar_checkbox(ByVal form As Control)
        For Each k As Control In form.Controls
            If k.Controls.Count > 0 Then Limpiar_checkbox(k)
            If TypeOf k Is CheckBox Then DirectCast(k, CheckBox).Checked = False
        Next
    End Sub
    ''' <summary>
    ''' Devuelve el primer día del mes
    ''' </summary>
    ''' <param name="pFecha"></param>
    ''' <returns></returns>
    Function FirstDayMonth(ByVal pFecha As Date) As Date
        Dim wannio As Int32 = pFecha.Year
        Dim wmes As Int32 = pFecha.Month
        FirstDayMonth = DateSerial(wannio, wmes, 1)
    End Function
    ''' <summary>
    ''' Devuelve el último día del Mes
    ''' </summary>
    ''' <param name="pFecha"></param>
    ''' <returns></returns>
    Function LastDayMonth(ByVal pFecha As Date) As Date
        Dim wannio As Int32 = pFecha.Year
        Dim wmes As Int32 = pFecha.Month
        LastDayMonth = DateSerial(wannio, wmes + 1, 0)
    End Function



    ''' <summary>
    ''' Inicia una aplicación de cualquier extencion
    ''' </summary>
    ''' <param name="Aplicacion">nombre de la aplicación si es .exe</param>
    ''' <param name="ruta">si es una ruta especifica</param>
    ''' <remarks></remarks>
    Public Sub LlamarAplicacion(ByVal Aplicacion As String, Optional ByVal ruta As Boolean = False)

        Try
            If ruta = True Then
                Process.Start(Aplicacion)
            Else
                Process.Start(Application.StartupPath & "\" & Aplicacion & ".exe")
            End If
        Catch ex As Exception
            MsgBox("No esta instalado el sistema: " & Aplicacion, MsgBoxStyle.Critical, "ERP")
        End Try
    End Sub
    ''' <summary>
    ''' Extrae la Mac de la PC 
    ''' </summary>
    ''' <returns></returns>
    Public Function GetMAC() As String
        Dim archivo As String
        Dim sr As StreamReader
        Dim Texto As String = ""
        Dim Fila As Int32 = 1
        archivo = Application.StartupPath & "\mac.hs"
        Shell("cmd /c getmac.exe > " & archivo, AppWinStyle.Hide)
        Threading.Thread.Sleep(2000)
        sr = New StreamReader(archivo)

        Do While Not Texto Is Nothing
            Texto = sr.ReadLine()
            If Fila >= 4 Then
                Texto = Left(Texto, 17)
                If Len(Trim(Texto)) = 17 Then
                    Exit Do
                End If
            End If
            Fila = Fila + 1
        Loop
        sr.Close()

        Return Texto

    End Function

    ''' <summary>
    ''' Obtiene la Mac 2
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getMacAddress() As String
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Dim n As Integer = nics.Count - 1
        Return nics(n).GetPhysicalAddress.ToString
    End Function
    ''' <summary>
    ''' Lee el archivo txt del server
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Leer_Server() As String
        Dim fic As String = Application.StartupPath & "\SERVER.txt"
        Dim texto As String
        Dim sr As StreamReader = New StreamReader(fic)
        texto = sr.ReadToEnd()
        sr.Close()
        Return texto
    End Function

    ''' <summary>
    ''' Crea archivos externos con texto 
    ''' </summary>
    ''' <param name="archivo">Archivo a crear, puede ser .dll, .txt, etc</param>
    ''' <param name="texto">Texto que irá en el archivo</param>
    ''' <remarks></remarks>
    Public Sub EscribeArchivo(archivo As String, texto As String)
        Dim path As String = Application.StartupPath & "\" & archivo

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(texto)
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub

    ''' <summary>
    ''' Convierte una ruta especifica de archivo a bytes
    ''' </summary>
    ''' <param name="ImageFilePath">The path of the image file</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Convertir_Imagenes_en_Bytes(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Convierte bytes a archivos fisicos guardados en una determinada carpeta del Path
    ''' </summary>
    ''' <param name="archivo">archivo en bytes</param>
    ''' <param name="nombreArchivo">nombre del archivo con cualquier extención</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GuardaArchivo(archivo As Byte(), nombreArchivo As String) As String
        Dim path As String = Application.StartupPath
        Dim file As String = nombreArchivo

        Try
            path = path & "\documentos\" & file

            Dim archivo_fisico As New FileStream(path, FileMode.Create, FileAccess.Write)
            For Each b As Byte In archivo
                archivo_fisico.WriteByte(b)
            Next
            archivo_fisico.Close()
        Catch ex As Exception
            Throw ex
        End Try

        Return path
    End Function
    ''' <summary>
    ''' Convierte una matriz en Bytes() en una imagen archivo
    ''' </summary>
    ''' <param name="archivo"></param>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Public Function DescargaArchivo(archivo As Byte(), path As String) As String
        Try
            Dim archivo_fisico As New FileStream(path, FileMode.Create, FileAccess.Write)
            For Each b As Byte In archivo
                archivo_fisico.WriteByte(b)
            Next
            archivo_fisico.Close()
        Catch ex As Exception
            Throw ex
        End Try

        Return path
    End Function

    ''' <summary>
    ''' Valida si existe un archivo en particular, indicando su Ruta
    ''' </summary>
    ''' <param name="ruta"></param>
    ''' <returns></returns>
    Function existe_archivo(ByVal ruta As String) As Boolean
        Dim existe As Boolean
        existe = System.IO.File.Exists(ruta)
        Return existe
    End Function
    ''' <summary>
    ''' Elimina aun Archivo, indicando su ruta
    ''' </summary>
    ''' <param name="ruta"></param>
    ''' <returns></returns>
    Function EliminarArchivo(ruta As String) As Boolean
        Try
            My.Computer.FileSystem.DeleteFile(ruta,
            FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Extrae la extensión de un archivo, indicando su ruta
    ''' </summary>
    ''' <param name="ruta"></param>
    ''' <returns></returns>
    Function ExtensionArchivo(ByVal ruta As String) As String
        Return Path.GetExtension(ruta)
    End Function
    ''' <summary>
    ''' Función q recorre los Data reader / Al estilo de Fetchrow de PHP
    ''' </summary>
    ''' <param name="odata"></param>
    ''' <returns></returns>
    Public Function FetchAsoc(ByVal odata As Odbc.OdbcDataReader) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
        Dim nrocampos As Integer = odata.FieldCount
        Dim data As Object() = New Object(nrocampos - 1) {}
        odata.GetValues(data)
        Dim i As Integer = 0

        For Each d In data

            dictionary.Add(odata.GetName(i), d.ToString())
            i = i + 1
        Next

        Return dictionary
    End Function
    ''' <summary>
    '''  Extrae el Tipo de Cambio
    ''' </summary>
    ''' <param name="Fecha">Fecha a consultar el Tipo de Cambio</param>
    ''' <param name="Tipo">Tipo=0  Trae el el tipo de Cambio dela fecha consultada | Tipo = 1  Trae el último tipo de cambio registrado </param>
    ''' <returns></returns>
    Public Function GetTipCambio(ByVal Fecha As Date, Optional ByVal Tipo As Integer = 0) As Double
        Dim datTipcam As New TIPCAM
        Dim oTipcam As New DAL_TIPCAM
        datTipcam = If(Tipo = 0, oTipcam.Select_TipCam(New TIPCAM With {.FECHA = Fecha}), oTipcam.Select_TipCam_ultimo())
        If Not IsNothing(datTipcam) Then
            GTipcam = datTipcam.PARALE
        Else
            GTipcam = 0.00
        End If
        Return GTipcam
    End Function
    ''' <summary>
    ''' Obtiene el importe del impuesto a las bolsas plásticas
    ''' </summary>
    ''' <param name="Fecha"></param>
    ''' <param name="Tipmon">Moneda de impuesto</param>
    Public Sub GetICBPER(ByVal Fecha As Date, ByVal Tipmon As Integer)
        Dim oFac As New DAL_TABFAC
        If GTipcam = 0 Then
            GTipcam = GetTipCambio(Fecha)
            If GTipcam = 0 Then Return
        End If
        GICBPER = oFac.Select_ICBPER(Fecha)
        If Tipmon = MON_DOLARES Then
            GICBPER = Round(GICBPER / GTipcam, 2)
        End If
    End Sub
    ''' <summary>
    ''' Obtiene el IGV de acuerdo a la fecha consultada
    ''' </summary>
    ''' <param name="Fecha"></param>
    Public Sub GetIGV(ByVal Fecha As Date)
        Dim oFac As New DAL_TABFAC
        GPorIGV = oFac.Select_IGV(Fecha)
    End Sub








    ''' <summary>
    ''' Carga la imagen de Fondo del MDI / depende de una imagen cia.jpg
    ''' </summary>
    ''' <param name="Frm"></param>
    Public Sub CargaLogo(ByVal Frm As MdiPrincipal)
        Dim PATHLOGO As String = Application.StartupPath & "\Logo\" & GCia & ".jpg"
        Frm.BackgroundImage = Image.FromFile(PATHLOGO)
        Frm.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    ''' <summary>
    ''' Valida si ya existe un Doc.IDentidad registrado en la BD
    ''' </summary>
    ''' <param name="codigo"></param>
    ''' <param name="Nrodoc"></param>
    ''' <returns></returns>
    Public Function ValidaNrodoc(ByVal codigo As Integer, ByVal Nrodoc As String) As Boolean
        Dim oCliente As New DAL_CLIPRO
        Return oCliente.ValidaNroDoc(New CLIPRO With {.CODIGO = codigo, .NRODOC = Nrodoc.Trim})
    End Function
    ''' <summary>
    ''' Valida la estructura de un correo electrónico
    ''' </summary>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Function CMail(ByVal email As String) As Boolean
        Dim expresion As String
        expresion = "^[a - z0 - 9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$"

        If Regex.IsMatch(email, expresion) Then

            If Regex.Replace(email, expresion, String.Empty).Length = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            expresion = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"

            If Regex.IsMatch(email, expresion) Then

                If Regex.Replace(email, expresion, String.Empty).Length = 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function
    ''' <summary>
    ''' Consulta rápida para Consulta Reniec
    ''' </summary>
    ''' <param name="Dni"></param>
    ''' <returns></returns>
    Function ConsultaReniec(ByVal Dni As String, ByVal Optional TipoReg As Integer = TipReg.CLI) As CLIPRO
        Dim datclipro As CLIPRO
        If Not Dni.Trim.Length = 8 Then
            MessageBox.Show("Ingrese un DNI válido", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End If
        Dim Frm As New FrmConsultaReniec
        Frm.Nuevo(Dni.Trim, TipoReg)
        Frm.ShowDialog()

        datclipro = Frm.form_datclipro
        Frm.Close()
        Frm.Dispose()
        Return datclipro
    End Function
    ''' <summary>
    ''' Consulta rápida para Consulta RUC
    ''' </summary>
    ''' <param name="Ruc"></param>
    ''' <returns></returns>
    Function ConsultaRuc(ByVal Ruc As String, ByVal Optional TipoReg As Integer = TipReg.CLI) As CLIPRO
        Dim datclipro As CLIPRO
        If Not Ruc.Trim.Length = 11 Then
            MessageBox.Show("Ingrese un RUC válido", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End If
        Dim Frm As New FrmConsultaRuc
        Frm.Nuevo(Ruc.Trim, TipoReg)
        Frm.ShowDialog()

        datclipro = Frm.form_datclipro
        Frm.Close()
        Frm.Dispose()
        Return datclipro
    End Function
    ''' <summary>
    ''' Búsqueda Rápida para Clientes
    ''' </summary>
    ''' <param name="Criterio"></param>
    ''' <returns></returns>
    Public Function GetCliente(ByVal Criterio As String, ByVal TipReg As Integer) As CLIPRO
        Dim oCliente As New DAL_CLIPRO
        Dim lstCliente As New List(Of CLIPRO)
        Dim datclipro As New CLIPRO

        If Not IsNumeric(Criterio) Then
            GoTo Salta
        End If
        datclipro = oCliente.Select_Clipro_by_codigo(New CLIPRO With {.CODIGO = Criterio})
        If IsNothing(datclipro) Then
Salta:
            lstCliente = oCliente.SelectAll_clipro(New CLIPRO With {.RAZSOC = Criterio, .TIPREG = TipReg}, 1)
            If lstCliente IsNot Nothing Then
                If lstCliente.Count = 1 Then
                    datclipro = lstCliente.First
                Else
                    Dim Frm As New FrmConsultaCliPro
                    Frm.ConsultaRapida(Criterio, TipReg)
                    Frm.ShowDialog()
                    If Not IsNothing(Frm.form_datclipro) And Frm.BsqExitosa = True Then
                        datclipro = Frm.form_datclipro
                        Frm.Close()
                        Frm.Dispose()
                    End If
                End If
            Else
                Dim Frm As New FrmConsultaCliPro
                Frm.ConsultaRapida(Criterio, TipReg)
                Frm.ShowDialog()
                If Not IsNothing(Frm.form_datclipro) And Frm.BsqExitosa = True Then
                    datclipro = Frm.form_datclipro
                    Frm.Close()
                    Frm.Dispose()
                End If
            End If

        End If
        Return datclipro
    End Function
    ''' <summary>
    ''' Búsqueda rápida de artículos 
    ''' </summary>
    ''' <param name="criterio"></param>
    ''' <param name="CodSuc"></param>
    ''' <param name="Tipmon"></param>
    ''' <returns></returns>
    Public Function GetArticulo(ByVal criterio As String, ByVal CodSuc As Integer, ByVal Tipmon As Integer) As TABART
        Dim oTabart As New DAL_TABART
        Dim lstTabart As New List(Of TABART)
        Dim dattabart As New TABART
        Dim ListaPrecios As New List(Of TABART_SUCURSAL)
        'Busqueda por codigo
        dattabart = oTabart.Select_tabart_by_cod_x_suc(New TABART_SUCURSAL With {.CODART = criterio, .CODSUC = CodSuc})

        If IsNothing(dattabart) Then
            'busqueda por codigo / descri / marca / etc
            lstTabart = oTabart.SelectAll_Articulo_x_Suc(New TABART_SUCURSAL With {.DESCRI = criterio, .CODSUC = CodSuc})
            If lstTabart IsNot Nothing Then
                If lstTabart.Count = 1 Then
                    dattabart = lstTabart.First
                    ListaPrecios = oTabart.SelectAll_tabart_precios(dattabart)

                    If Not IsNothing(ListaPrecios) Then
                        ListaPrecios = ListaPrecios.Where(Function(X) X.CODSUC = CodSuc And (X.PRECIO_DISTRI > 0 Or X.PRECIO_PUBLI > 0 Or X.PRECIO_MIN > 0)).ToList
                        If ListaPrecios.Count > 0 Then
                            dattabart.LISTAPRECIOS = ListaPrecios
                        End If
                    End If
                Else
                    ' Ventana de búsqueda rápida
                    Dim Frm As New FrmBsqArticulo
                    Frm.ConsultaRapida(criterio, CodSuc)
                    Frm.ShowDialog()
                    If Not IsNothing(Frm.form_datArticulo) And Frm.bsqExistosa = True Then
                        dattabart = Frm.form_datArticulo
                        ListaPrecios = oTabart.SelectAll_tabart_precios(dattabart)

                        If Not IsNothing(ListaPrecios) Then
                            ListaPrecios = ListaPrecios.Where(Function(X) X.CODSUC = CodSuc And (X.PRECIO_DISTRI > 0 Or X.PRECIO_PUBLI > 0 Or X.PRECIO_MIN > 0)).ToList
                            If ListaPrecios.Count > 0 Then
                                dattabart.LISTAPRECIOS = ListaPrecios
                            End If
                        End If


                        Frm.Close()
                        Frm.Dispose()
                    Else
                        dattabart = Nothing
                    End If
                End If
            Else

                ' Ventana de búsqueda rápida
                Dim Frm As New FrmBsqArticulo
                Frm.ConsultaRapida(criterio, CodSuc)
                Frm.ShowDialog()
                If Not IsNothing(Frm.form_datArticulo) And Frm.bsqExistosa = True Then
                    dattabart = Frm.form_datArticulo

                    ListaPrecios = oTabart.SelectAll_tabart_precios(dattabart)

                    If Not IsNothing(ListaPrecios) Then
                        ListaPrecios = ListaPrecios.Where(Function(X) X.CODSUC = CodSuc And (X.PRECIO_DISTRI > 0 Or X.PRECIO_PUBLI > 0 Or X.PRECIO_MIN > 0)).ToList
                        If ListaPrecios.Count > 0 Then
                            dattabart.LISTAPRECIOS = ListaPrecios
                        End If
                    End If

                    Frm.Close()
                    Frm.Dispose()
                Else
                    dattabart = Nothing
                End If
            End If
        Else
            ListaPrecios = oTabart.SelectAll_tabart_precios(dattabart)

            If Not IsNothing(ListaPrecios) Then
                ListaPrecios = ListaPrecios.Where(Function(X) X.CODSUC = CodSuc And (X.PRECIO_DISTRI > 0 Or X.PRECIO_PUBLI > 0 Or X.PRECIO_MIN > 0)).ToList
                If ListaPrecios.Count > 0 Then
                    dattabart.LISTAPRECIOS = ListaPrecios
                End If
            End If
        End If

        ' Form de Precios para q el usuario seleccione

        If Not IsNothing(dattabart) Then
            If Not IsNothing(dattabart.LISTAPRECIOS) Then
                'cuando solo tiene un unidad con precios
                If dattabart.LISTAPRECIOS.Count = 1 Then

                    Dim DatPrecios As New TABART_SUCURSAL
                    Dim PPubliSol As Double, PDistriSol As Double, PMiniSol As Double
                    Dim PPubliDol As Double, PDistriDol As Double, PMiniDol As Double
                    DatPrecios = dattabart.LISTAPRECIOS.First

                    If dattabart.TIPMON = MON_SOLES Then
                        PPubliSol = DatPrecios.PRECIO_PUBLI
                        PDistriSol = DatPrecios.PRECIO_DISTRI
                        PMiniSol = DatPrecios.PRECIO_MIN
                        PPubliDol = Math.Round(DatPrecios.PRECIO_PUBLI / GTipcam, 2)
                        PDistriDol = Math.Round(DatPrecios.PRECIO_DISTRI / GTipcam, 2)
                        PMiniDol = Math.Round(DatPrecios.PRECIO_MIN / GTipcam, 2)
                    Else
                        PPubliDol = DatPrecios.PRECIO_PUBLI
                        PDistriDol = DatPrecios.PRECIO_DISTRI
                        PMiniDol = DatPrecios.PRECIO_MIN
                        PPubliSol = Math.Round(DatPrecios.PRECIO_PUBLI * GTipcam, 2)
                        PDistriSol = Math.Round(DatPrecios.PRECIO_DISTRI / GTipcam, 2)
                        PMiniSol = Math.Round(DatPrecios.PRECIO_DISTRI / GTipcam, 2)
                    End If

                    If Tipmon = MON_SOLES Then
                        DatPrecios.PRECIO_PUBLI = PPubliSol
                        DatPrecios.PRECIO_DISTRI = PDistriSol
                        DatPrecios.PRECIO_MIN = PMiniSol
                    Else
                        DatPrecios.PRECIO_PUBLI = PPubliDol
                        DatPrecios.PRECIO_DISTRI = PDistriDol
                        DatPrecios.PRECIO_MIN = PMiniDol
                    End If

                    dattabart.LISTAPRECIOS.Clear()
                    dattabart.LISTAPRECIOS.Add(DatPrecios)

                Else
                    If dattabart.LISTAPRECIOS.Count > 1 Then
                        'cuando tiene varias unidades con precios
                        Dim Frm As New FrmPreciosUnidad
                        Frm.CargaLista(dattabart, Tipmon)
                        Frm.ShowDialog()
                        If Not IsNothing(Frm.form_listPreciosLista) Then
                            If Frm.form_listPreciosLista.Count > 0 Then
                                dattabart.LISTAPRECIOS = Frm.form_listPreciosLista
                                Frm.Close()
                                Frm.Dispose()
                            End If

                        End If
                    Else
                        Return Nothing
                    End If

                End If
            Else
                Return Nothing
            End If

        End If

        Return dattabart
    End Function

    ''' <summary>
    ''' Devuelve la Abreviatura del Tipo de Documento de una persona basado en la lista Enum declarada en el módulo de funcione Globales
    ''' </summary>
    ''' <param name="codTipdoc"></param>
    ''' <returns></returns>
    Public Function GetAbrevDoc(ByVal codTipdoc As Integer) As String
        Dim DesDoc As String = ""
        For Each value In [Enum].GetValues(GetType(TipDocClie))
            If Convert.ToInt32(value) = codTipdoc Then
                DesDoc = value.ToString
            End If
        Next
        Return DesDoc
    End Function
    ''' <summary>
    ''' Devuelve la Abreviatura del Tipo de Documento de referencia para los Doc Venta en la lista Enum declarada en el módulo de funcione Globales
    ''' </summary>
    ''' <param name="codTipdoc"></param>
    ''' <returns></returns>
    Public Function GetAbrevDocRef(ByVal codTipdoc As Integer) As String
        Dim DesDoc As String = ""
        For Each value In [Enum].GetValues(GetType(DocRefFac))
            If Convert.ToInt32(value) = codTipdoc Then
                DesDoc = value.ToString
            End If
        Next
        Return DesDoc
    End Function
    ''' <summary>
    ''' Añadir cliente ventana rápida
    ''' </summary>
    ''' <returns></returns>
    Public Function AddCliente() As CLIPRO
        Dim datclipro As New CLIPRO
        Dim Frm As New FrmTabCliPro
        Frm.ShowDialog()
        datclipro = Frm.form_datclipro
        Frm.Close()
        Frm.Dispose()
        Return datclipro
    End Function
    ''' <summary>
    ''' Modificar Cliente ventana rápida
    ''' </summary>
    ''' <param name="codigo"></param>
    ''' <returns></returns>
    Public Function ModCliente(ByVal codigo As Object) As CLIPRO
        Dim datclipro As New CLIPRO
        Dim Frm As New FrmTabCliPro

        datclipro = Frm.Editar(codigo)
        If Not IsNothing(datclipro) Then
            Frm.ShowDialog()
            datclipro = Frm.form_datclipro
            Frm.Close()
            Frm.Dispose()
        End If

        Return datclipro
    End Function

    Public Sub MensajeSimple(ByVal oMensaje As String, ByVal Optional TipMens As MessageBoxIcon = MessageBoxIcon.Information)

        MessageBox.Show(oMensaje, TITULO, MessageBoxButtons.OK, TipMens)
    End Sub

End Module
