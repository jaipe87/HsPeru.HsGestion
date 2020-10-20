Option Strict On
Imports System.Data.Odbc


Public Class DAL_USUARIO

    Public Function SeleccionaAll_Usuario() As List(Of USUARIO)
        Dim dr As OdbcDataReader
        Dim datUsuario As USUARIO
        Dim lstUsuario As New List(Of USUARIO)
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  COD, USUARIO, NOMUSR, APEUSR, FECALT, FECBAJ, PWD, ST, CIAACT, SUCACT, CODGRU, CODCAR, CODVEN  FROM tabusr WHERE ST=0"
        Using cmd As New OdbcCommand(ssql, Cn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Row = FetchAsoc(dr)
                    datUsuario = New USUARIO()
                    datUsuario.COD = Convert.ToInt32(Row("COD"))
                    datUsuario.USUARIO = Row("USUARIO")
                    datUsuario.NOMUSR = Row("NOMUSR")
                    datUsuario.APEUSR = Row("APEUSR")
                    datUsuario.FECALT = Row("FECALT")
                    datUsuario.FECBAJ = Row("FECBAJ")
                    datUsuario.PWD = Row("PWD")
                    datUsuario.ST = Convert.ToInt32(Row("ST"))
                    datUsuario.CIAACT = Convert.ToInt32(Row("CIAACT"))
                    datUsuario.SUCACT = Convert.ToInt32(Row("SUCACT"))

                    datUsuario.CODGRU = Convert.ToInt32(Row("CODGRU"))
                    datUsuario.CODCAR = Convert.ToInt32(Row("CODCAR"))
                    datUsuario.CODVEN = Convert.ToInt32(Row("CODVEN"))
                    lstUsuario.Add(datUsuario)
                End While
                Return lstUsuario
            Else
                Return Nothing
            End If
        End Using
    End Function
    Public Function Selecciona_Usuario_by_Pwd(ByVal objDato As USUARIO) As USUARIO
        Dim dr As OdbcDataReader
        Dim datUsuario As USUARIO
        Dim Row As Dictionary(Of String, String)

        Ssql = "SELECT  COD, USUARIO, NOMUSR, APEUSR, FECALT, FECBAJ, PWD, ST, CIAACT, SUCACT, CODGRU, CODCAR, CODVEN  FROM tabusr WHERE cod=? AND PWD=MD5(?)"
        Using cmd As New OdbcCommand(ssql, Cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cod", OdbcType.Int, 11).Value = objDato.COD
            cmd.Parameters.Add("@pwd", OdbcType.VarChar, 50).Value = objDato.PWD
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                Row = FetchAsoc(dr)
                datUsuario = New USUARIO()

                datUsuario.COD = Convert.ToInt32(Row("COD"))
                datUsuario.USUARIO = Row("USUARIO")
                datUsuario.NOMUSR = Row("NOMUSR")
                datUsuario.APEUSR = Row("APEUSR")
                datUsuario.FECALT = Row("FECALT")
                datUsuario.FECBAJ = Row("FECBAJ")
                datUsuario.PWD = Row("PWD")
                datUsuario.ST = Convert.ToInt32(Row("ST"))
                datUsuario.CIAACT = Convert.ToInt32(Row("CIAACT"))
                datUsuario.SUCACT = Convert.ToInt32(Row("SUCACT"))

                datUsuario.CODGRU = Convert.ToInt32(Row("CODGRU"))
                datUsuario.CODCAR = Convert.ToInt32(Row("CODCAR"))
                datUsuario.CODVEN = Convert.ToInt32(Row("CODVEN"))
                Return datUsuario
            Else
                Return Nothing
            End If
        End Using
    End Function

End Class
