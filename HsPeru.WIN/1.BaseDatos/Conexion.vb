Imports System.Data
Imports System.Data.Odbc
Module Conexion
    Public Cn As OdbcConnection

    Public Sub SetConexion()
        Dim connectionString As String = "Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;port=3306;Database=dbhsgestion;Uid=root;Pwd=samanthafox;"

        Cn = New OdbcConnection(connectionString)
        If Cn.State = System.Data.ConnectionState.Open Then
            Cn.Close()


        End If
        Cn.Open()
    End Sub

    Public Sub CloseConexion()
        Cn.Close()
    End Sub


End Module
