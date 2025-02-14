Module sisVariables
    Public GCodUsr As Integer = 0
    Public GUsuario As String = ""
    Public GCodGru As Integer
    Public GcodVen As Integer = 0
    Public GFechaIni As Date
    Public GTipcam As Double
    Public GICBPER As Double = 0
    Public GPorIGV As Double = 0.00

    Public GMac As String
    Public GCia As Integer
    Public GSerCaj As Integer
    Public GDesCia As String
    Public GRuc As String
    Public GMontoBoleta As Double
    Public GDireccion As String
    Public GUbigeo As String
    Public GCtaDet As String
    Public GCodigoCia As Integer
    ' sucursal
    Public GSucursal As String
    Public GDesSuc As String
    Public GCodSuc As Integer
    Public GDirSuc As String
    Public GTelSuc As String
    Public GCelSuc As String

    Public Ssql As String = ""
    Public oCombo As DAL_COMBOS = New DAL_COMBOS

    Public ListaSexo As New Dictionary(Of Integer, String) From {{1, "MASCULINO"}, {2, "FEMENINO"}}
    Public ListaParentesco As New Dictionary(Of Integer, String) From {{1, "ESPOSO(A)"}, {2, "HIJO(A)"}}


End Module
