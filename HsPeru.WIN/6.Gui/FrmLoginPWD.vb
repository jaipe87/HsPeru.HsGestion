Option Strict On
Public Class FrmLoginPWD
    Public PSup As Integer = 0
    Public PCodAut As Integer = 0
    Public PDesAut As String = ""
    Public form_datVendedor As VENDEDOR
    Private oVendedor As DAL_VENDEDOR
    Private PCount As Integer = 0

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        PCount = 0
        PSup = 0
        PCodAut = 0
        PDesAut = ""
        form_datVendedor = New VENDEDOR
        oVendedor = New DAL_VENDEDOR
    End Sub
    Private Sub txtPWD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            form_datVendedor = oVendedor.Select_pwd_Supervisor(New VENDEDOR With {.PWDVEN = txtPWD.Text.Trim, .STSUP = PSup})
            If form_datVendedor IsNot Nothing Then
                PCodAut = form_datVendedor.COD
                PDesAut = form_datVendedor.DES
                Hide()
            Else
                PCodAut = 0
                PDesAut = ""
                MessageBox.Show("Password Errado...", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPWD.Focus()
                PCount = +1
                If PCount >= 3 Then
                    Hide()
                End If

            End If

        End If
    End Sub
End Class