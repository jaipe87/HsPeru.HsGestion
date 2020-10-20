Public Class TABART
    Public Property CIA As Integer
    Public Property CODLIN As String = "00"
    Public Property CODART As String
    Public Property CODREF As String
    Public Property CODFAB As String
    Public Property DESCRI As String
    Public Property CODMAR As Integer

    Public Property CODGRU As Integer
    Public Property CODSUBCAT As Integer
    Public Property MODELO As String
    Public Property GARANTIA As String
    Public Property COSDOL As Double
    Public Property COSSOL As Double
    Public Property PRECOM As Double
    Public Property CODPRO As Integer
    Public Property FECCOM As String = "0000-00-00"
    Public Property AFECTO As Integer
    Public Property STVEN As Integer
    Public Property STWEB As Integer
    Public Property STOFE As Integer
    Public Property STLIS As Integer
    Public Property TIPMON As Integer
    Public Property ESPECI As String
    Public Property FECALT As String
    Public Property USRALT As Integer
    Public Property FECACT As String
    Public Property USRMOD As Integer
    Public Property FECMOD As String
    Public Property SIT As Integer
    Public Property STICBPER As Integer
    Public Property ISC As Double
    '===============================================================
    Public Property DESCAT As String
    Public Property DESSUBCAT As String
    Public Property DESMAR As String
    Public Property DESEST As String
    Public Property DESMON As String
    Public Property LISTAPRECIOS As List(Of TABART_SUCURSAL)
    Public Property LISTASUBICACION As List(Of TABART_UBICACION)
    Sub New()
        LISTAPRECIOS = New List(Of TABART_SUCURSAL)
        LISTASUBICACION = New List(Of TABART_UBICACION)
    End Sub
End Class
