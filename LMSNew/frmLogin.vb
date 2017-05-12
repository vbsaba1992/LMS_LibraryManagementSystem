Imports System.Data.OleDb
Public Class frmLogin

    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LMS_DB.accdb")
    'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & System.Environment.CurrentDirectory & "\LMS.mdb")

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoginCancel.Click
        Me.Close()
    End Sub
    'To display * character
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = Chr(149)
    End Sub
    'If Enter key pressed goto Password
    Private Sub UserID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If e.KeyChar = Chr(13) Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
        frmChangePassword.ShowDialog()
    End Sub

    Private Sub btnLoginOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoginOK.Click

        If Trim(txtUserName.Text) = "" Or Trim(txtPassword.Text) = "" Then
            MsgBox("Please Enter Both Fields!", vbInformation, "Note")
        Else
            con.Open()
            Dim sql = "SELECT * FROM tblUser WHERE username = '" & (txtUserName.Text) & "' AND password = '" & (txtPassword.Text) & "'"

            Dim cmd = New OleDbCommand(sql, con)
            Dim dr As OleDbDataReader = cmd.ExecuteReader

            Try
                If dr.Read = False Then
                    MsgBox("Login Failed!", vbCritical, "Note")
                Else
                    MsgBox("Login Successful!", vbInformation, "Note")


                    Me.Hide()
                    frmMain.ShowDialog()
                    con.Close()


                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()

            End Try


        End If

    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call btnLoginOK_Click(sender, e)
        End If
    End Sub
End Class