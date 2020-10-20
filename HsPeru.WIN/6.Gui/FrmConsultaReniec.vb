
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Web

Public Class FrmConsultaReniec
    Public form_datclipro As New CLIPRO
#Region "Métodos"
    Async Sub ConsultaReniec()
        Dim DatCliente As CLIPRO

        Dim oReniec As New wsReniec
        DatCliente = Await oReniec.GetInfo(txtnumDni.Text.Trim)


        If Not IsNothing(DatCliente) Then
            txtNombre.Text = DatCliente.NOMBRE
            txtMaterno.Text = DatCliente.APEMAT
            txtpaterno.Text = DatCliente.RAZSOC
        End If
    End Sub
    Sub Graba()
        Dim oCliente As New DAL_CLIPRO
        Dim datCliente As New CLIPRO
        If txtnumDni.Text.Trim.Length = 0 Or txtnumDni.Text.Trim.Length < 8 Then
            MessageBox.Show("Ingrese un Nro. DNI correcto", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If txtpaterno.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Apellido Paterno", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If txtMaterno.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Apellido Materno", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If txtNombre.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese los Nombres", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If txtCorreo.Text.Trim.Length > 0 Then
            If Not CMail(txtCorreo.Text.Trim) Then
                MessageBox.Show("Ingrese un formato correcto de E-mail", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If

        datCliente = oCliente.Insert_wsReniec(New CLIPRO With {
                                 .NRODOC = txtnumDni.Text.Trim,
                                 .RAZSOC = txtpaterno.Text.Trim,
                                 .APEMAT = txtMaterno.Text.Trim,
                                 .NOMBRE = txtNombre.Text.Trim,
                                 .DIRECC = txtDirección.Text.Trim,
                                 .TELEFO = txtTelefonos.Text.Trim,
                                 .CELULAR = txtCelular.Text.Trim,
                                 .OTROS = txtCorreo.Text.Trim
                                 })


        If Not IsNothing(datCliente) Then
            form_datclipro = datCliente
            MessageBox.Show("Se registró el cliente con código " & datCliente.CODIGO, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Hide()
        Else
            form_datclipro = Nothing
            MessageBox.Show("No se registró el cliente", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
#End Region
#Region "Eventos"
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
    End Sub
    Sub Nuevo(ByVal Dni As String)
        txtnumDni.Text = Dni
    End Sub
    Private Sub SaltoControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelefonos.KeyDown, txtpaterno.KeyDown, txtnumDni.KeyDown, txtNombre.KeyDown, txtMaterno.KeyDown, txtDirección.KeyDown, txtCorreo.KeyDown, txtCelular.KeyDown, btnGuardar.KeyDown, btnConsultar.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TryCast(sender, TextBox).Name = txtnumDni.Name Then
                ConsultaReniec()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtnumDni_Click(sender As Object, e As EventArgs) Handles txtTelefonos.Click, txtpaterno.Click, txtnumDni.Click, txtNombre.Click, txtMaterno.Click, txtDirección.Click, txtCorreo.Click, txtCelular.Click
        TryCast(sender, TextBox).SelectAll()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        ConsultaReniec()
    End Sub

    Private Sub FrmConsultaReniec_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtnumDni.Focus()
    End Sub
#End Region

End Class

Public Class wsReniec
    Public Enum Resul
        Ok = 0
        NoResul = 1
        [Error] = 3
    End Enum

    Private state As Resul
    Private myCookie As CookieContainer
    Private mCliente As CLIPRO

    Public Property oCliente() As CLIPRO
        Get
            Return mCliente
        End Get
        Set(value As CLIPRO)
            mCliente = value
        End Set
    End Property

    Public Sub New()
        Try
            mCliente = New CLIPRO
            myCookie = Nothing
            myCookie = New CookieContainer()
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function ValidarCertificado(sender As Object, certificate As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslPolicyErrors As System.Net.Security.SslPolicyErrors) As [Boolean]
        Return True
    End Function
    Public Async Function GetInfo(numDni As String) As Task(Of CLIPRO)
        Dim uri As String = "http://www.hsperu.pe/Reniec/consultaReniec.php?dni=" & numDni
        Dim Datos As String = ""
        Try

            Dim request As HttpWebRequest = TryCast(WebRequest.Create(uri), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate

            Using response As HttpWebResponse = TryCast(Await request.GetResponseAsync(), HttpWebResponse)

                Using stream As Stream = response.GetResponseStream()

                    Using reader As StreamReader = New StreamReader(stream)
                        Datos = Await reader.ReadToEndAsync()
                    End Using
                End Using
            End Using


            Dim _resul As String() = Datos.Split("|")
            Select Case _resul.Count

                Case 5
                    state = Resul.Ok
                    Exit Select

                Case Else
                    state = Resul.NoResul
                    Exit Select
            End Select

            If state = Resul.Ok Then
                mCliente.NOMBRE = _resul(1)
                mCliente.RAZSOC = _resul(2)
                mCliente.APEMAT = _resul(3)
            End If
       

            Return mCliente

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Function GetInfo(numDni As String) As CLIPRO

    '    Try
    '        Dim myUrl As String = "http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano"
    '        Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create(myUrl), HttpWebRequest)
    '        Dim Data As String = "DNI=" & numDni
    '        Dim dataStream As Byte() = Encoding.UTF8.GetBytes(Data)

    '        myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0"
    '        myWebRequest.CookieContainer = myCookie
    '        myWebRequest.Credentials = CredentialCache.DefaultCredentials
    '        myWebRequest.Proxy = Nothing
    '        myWebRequest.Method = "POST"
    '        myWebRequest.ContentType = "application/x-www-form-urlencoded"
    '        myWebRequest.ContentLength = dataStream.Length

    '        Dim newStream As Stream = myWebRequest.GetRequestStream()
    '        newStream.Write(dataStream, 0, dataStream.Length)
    '        newStream.Close()

    '        Dim myHttpWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
    '        Dim myStream As Stream = myHttpWebResponse.GetResponseStream()
    '        Dim myStreamReader As New StreamReader(myStream)


    '        Dim Datos As String = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd())
    '        Dim _resul As String() = Datos.Split("|")

    '        Select Case _resul.Count

    '            Case 3
    '                state = Resul.Ok
    '                Exit Select

    '            Case Else
    '                state = Resul.NoResul
    '                Exit Select
    '        End Select

    '        If state = Resul.Ok Then
    '            mCliente.NOMBRE = _resul(2)
    '            mCliente.RAZSOC = _resul(0)
    '            mCliente.APEMAT = _resul(1)
    '        End If
    '        myHttpWebResponse.Close()
    '        Return mCliente

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
End Class