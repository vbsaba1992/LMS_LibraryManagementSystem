Imports System.Data.OleDb
Public Class frmChangePassword

    Dim cs As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LMS_DB.accdb")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        Try
            Dim RowsAffected As Integer = 0
            If Len(Trim(txtChPassUserID.Text)) = 0 Then
                MessageBox.Show("Please enter user id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtChPassUserID.Focus()
                Exit Sub
            End If
            If Len(Trim(txtChPassOldPass.Text)) = 0 Then
                MessageBox.Show("Please enter old password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtChPassOldPass.Focus()
                Exit Sub
            End If
            If Len(Trim(txtChPassNewPass.Text)) = 0 Then
                MessageBox.Show("Please enter new password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtChPassNewPass.Focus()
                Exit Sub
            End If
            If Len(Trim(txtChPassConfirm.Text)) = 0 Then
                MessageBox.Show("Please confirm new password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtChPassConfirm.Focus()
                Exit Sub
            End If
            If txtChPassNewPass.TextLength < 5 Then
                MessageBox.Show("The New Password Should be of Atleast 5 Characters", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtChPassNewPass.Text = ""
                txtChPassConfirm.Text = ""
                txtChPassNewPass.Focus()
                Exit Sub
            ElseIf txtChPassNewPass.Text <> txtChPassConfirm.Text Then
                MessageBox.Show("Password do not match", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtChPassNewPass.Text = ""
                txtChPassOldPass.Text = ""
                txtChPassConfirm.Text = ""
                txtChPassOldPass.Focus()
                Exit Sub
            ElseIf txtChPassOldPass.Text = txtChPassNewPass.Text Then
                MessageBox.Show("Password is same..Re-enter new password", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtChPassNewPass.Text = ""
                txtChPassConfirm.Text = ""
                txtChPassNewPass.Focus()
                Exit Sub
            End If
            cs = New OleDbConnection()
            cs.Open()
            Dim co As String = "UPDATE tblUser SET [password] = '" & (txtChPassNewPass.Text) & "'WHERE username='" & txtChPassUserID.Text & "' AND [password] = '" & (txtChPassOldPass.Text) & "'"
            Dim cmd = New OleDbCommand(co)
            cmd.Connection = cs
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then

                MessageBox.Show("Successfully changed", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                frmLogin.Show()
                frmLogin.txtUserName.Text = ""
                frmLogin.txtPassword.Text = ""
                frmLogin.txtUserName.Focus()
            Else

                MessageBox.Show("invalid user name or password", "input error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtChPassUserID.Text = ""
                txtChPassNewPass.Text = ""
                txtChPassOldPass.Text = ""
                txtChPassConfirm.Text = ""
                txtChPassUserID.Focus()
            End If
            cs.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmChangePassword1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        frmLogin.Show()
        frmLogin.txtUserName.Text = ""
        frmLogin.txtPassword.Text = ""
        frmLogin.txtUserName.Focus()

    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtChPassConfirm.PasswordChar = Chr(149)
        txtChPassNewPass.PasswordChar = Chr(149)
        txtChPassOldPass.PasswordChar = Chr(149)
    End Sub
End Class