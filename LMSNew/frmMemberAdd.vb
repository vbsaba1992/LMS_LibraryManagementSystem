Imports System.Data.OleDb

Public Class frmMemberAdd

    Dim provider As String
    Dim dataFile As String
    Dim connString As String

    Dim myConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LMS_DB.accdb")


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtAddress.Clear()
        txtClass.Clear()
        txtContact.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtStudentId.Clear()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Len(Trim(txtStudentId.Text)) = 0 Or Len(Trim(txtFirstName.Text)) = 0 Or Len(Trim(txtContact.Text)) = 0 Then
            MessageBox.Show("Please fill mandatory Fields", "Error Generated", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtStudentId.Focus()
        Else

            myConnection.Open()
            Dim str As String
            str = "INSERT INTO tblMembers ([MemberID], [FirstName], [LastName], [Address], [Class], [ContactNo]) VALUES (?, ?, ?, ?, ?, ?)"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            cmd.Parameters.Add(New OleDbParameter("MemberID", CType(txtStudentId.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("FirstName", CType(txtFirstName.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("LastName", CType(txtLastName.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Address", CType(txtAddress.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Class", CType(txtClass.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("ContactNo", CType(txtContact.Text, String)))
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                myConnection.Close()
                MessageBox.Show("New Item Added", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txtAddress.Clear()
                txtClass.Clear()
                txtContact.Clear()
                txtFirstName.Clear()
                txtLastName.Clear()
                txtStudentId.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub frmMemberAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtStudentId.Focus()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        frmMemberUpdate.ShowDialog()
    End Sub

 
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (txtStudentId.Text = "") Then
            MessageBox.Show("Please enter the StudentID", "Student Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtStudentId.Focus()
        Else
            Dim okToDelete As MsgBoxResult = MsgBox("Are you sure you want to delete the current record?", MsgBoxStyle.YesNo)
            If okToDelete = MsgBoxResult.Yes Then

                myConnection.Open()
                Dim str As String
                str = "DELETE FROM tblMembers WHERE [MemberID] = " & txtStudentId.Text & ""
                Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
                Try
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    MessageBox.Show("The student (MemberID: " + txtStudentId.Text + ") was deleted.", "Success", MessageBoxButtons.OK)
                    txtStudentId.Text = ""
                    myConnection.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf okToDelete = MsgBoxResult.No Then
            End If
        End If

    End Sub
End Class