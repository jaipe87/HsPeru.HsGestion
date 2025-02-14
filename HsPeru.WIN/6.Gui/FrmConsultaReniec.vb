
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Web

Public Class FrmConsultaReniec
    Public form_datclipro As New CLIPRO

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
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
    Sub Nuevo(ByVal Dni As String)
        txtnumDni.Text = Dni

        ConsultaReniec()

    End Sub
#End Region
#Region "Eventos"
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Graba()
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
        Dim uri As String = "http://www.amkdelivery.com/Reniec/consultaReniec.php?dni=" & numDni
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
            If _resul.Count > 0 Then
                state = Resul.Ok
            Else
                state = Resul.NoResul
            End If

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

End Class