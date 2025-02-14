﻿

Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Web

Public Class FrmConsultaRuc
    Public form_datclipro As New CLIPRO
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#Region "Métodos"

    Async Sub ConsultaRuc()
        Dim DatCliente As CLIPRO

        Dim oReniec As New wsReniec
        DatCliente = Await oReniec.GetInfo(txtnumRuc.Text.Trim)


        If Not IsNothing(DatCliente) Then
            TxtRazsoc.Text = DatCliente.RAZSOC
            TxtRazonComercial.Text = DatCliente.RAZSOC
            txtDirección.Text = DatCliente.DIRECC
            LblEstado.Text = DatCliente.SUNAT_ESTADO
            LblCondicion.Text = DatCliente.SUNAT_CONDICION
            LblFechaBaja.Text = DatCliente.SUNAT_FECBAJA
            LblProfesion.Text = DatCliente.SUNAT_PROFESION
            LblTipo.Text = DatCliente.SUNAT_TIPO
            LblFechaInscripcion.Text = DatCliente.SUNAT_FECINSCRIPCION

        End If
    End Sub


    Sub Nuevo(ByVal Ruc As String)
        txtnumRuc.Text = Ruc

        ConsultaRuc()

    End Sub
#End Region


#Region "Eventos"
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub SaltoControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelefonos.KeyDown, txtnumRuc.KeyDown, txtCorreo.KeyDown, txtDirección.KeyDown, TxtRazonComercial.KeyDown, TxtRazsoc.KeyDown, txtCelular.KeyDown, btnGuardar.KeyDown, btnConsultar.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TryCast(sender, TextBox).Name = txtnumRuc.Name Then
                ConsultaRuc()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtnumRuc_Click(sender As Object, e As EventArgs) Handles txtnumRuc.Click, txtCelular.Click, txtCorreo.Click, txtDirección.Click, TxtRazonComercial.Click, TxtRazsoc.Click, txtTelefonos.Click
        TryCast(sender, TextBox).SelectAll()
    End Sub

    Private Sub FrmConsultaRuc_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtnumRuc.Focus()
    End Sub

#End Region





End Class


Public Class wsRuc
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
    Public Async Function GetInfo(numRuc As String) As Task(Of CLIPRO)
        Dim Ubigeo As String
        Dim uri As String = "http://www.amkdelivery.com/Reniec/consultaSunat.php?ruc=" & numRuc
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
                mCliente.RAZSOC = _resul(1)
                mCliente.RAZCOM = _resul(2)
                mCliente.SUNAT_TIPO = _resul(3)
                mCliente.SUNAT_ESTADO = _resul(4)
                mCliente.SUNAT_CONDICION = _resul(5)
                mCliente.DIRECC = _resul(6)
                mCliente.SUNAT_FECINSCRIPCION = _resul(7)
                mCliente.SUNAT_FECBAJA = _resul(8)
                mCliente.SUNAT_PROFESION = _resul(9)

                mCliente.SUNAT_UBIGEO = If(Val(_resul(10)) = 0, UBIGEO_LIMA, _resul(10))
                Ubigeo = mCliente.SUNAT_UBIGEO

                If Val(Ubigeo) > 0 Then
                    mCliente.CODDEP = Left(Ubigeo, 2)
                    mCliente.CODPRO = Mid(Ubigeo, 3, 2)
                    mCliente.CODDIS = Right(Ubigeo, 2)
                End If
            End If


                Return mCliente

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class