Public Class CLIPRO
    Public Property CIA As Integer
    Public Property CODIGO As Long
    Public Property TIPDOC As Integer
    Public Property NRODOC As String
    Public Property CODGRU As Integer
    Public Property RAZSOC As String
    Public Property APEPAT As String
    Public Property APEMAT As String
    Public Property NOMBRE As String
    Public Property RAZCOM As String
    Public Property DIRECC As String
    Public Property CODPAI As Integer
    Public Property CODDEP As String
    Public Property CODPRO As String
    Public Property CODDIS As String
    Public Property CODCIU As String
    Public Property CODVEN As Integer
    Public Property TELEFO As String
    Public Property CELULAR As String
    Public Property LINEA As Double
    Public Property OTROS As String
    Public Property TIPREG As Integer
    Public Property FECINS As String
    Public Property USRALT As Integer
    Public Property FECMOD As String
    Public Property USRMOD As Integer
    Public Property SIT As Integer
    Public Property FECCONSUL As String
    Public Property ESTSUNAT As String
    Public Property CONDSUNAT As String


    Public Property LISTACORREO As List(Of CLIPROCORREO)
    Public Property LISTAFAMILIA As List(Of CLIPROFAMILIA)
    Public Property LISTAPERSONAL As List(Of CLIPROPERSONAL)
    Public Property LISTASUCURSAL As List(Of CLIPROSUCURSAL)
    '==================================================================

    Public Property DESTIPDOC As String
    Public Property DESTIPREG As String
    Public Property ESTADO As String
    Public Property TRAZSOC As String

    Public Property SUNAT_TIPO As String
    Public Property SUNAT_ESTADO As String
    Public Property SUNAT_CONDICION As String
    Public Property SUNAT_FECINSCRIPCION As String
    Public Property SUNAT_FECBAJA As String

    Public Property SUNAT_PROFESION As String
    Public Property SUNAT_UBIGEO As String



    Sub New()
        LISTACORREO = New List(Of CLIPROCORREO)
        LISTAPERSONAL = New List(Of CLIPROPERSONAL)
        LISTASUCURSAL = New List(Of CLIPROSUCURSAL)
        LISTAFAMILIA = New List(Of CLIPROFAMILIA)
    End Sub
End Class
