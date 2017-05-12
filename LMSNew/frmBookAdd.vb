Imports System.Data.OleDb

Public Class frmBookAdd

    Dim provider As String
    Dim dataFile As String
    Dim connString As String

    Dim myConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LMS_DB.accdb")

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtAuthor.Clear()
        txtBookID.Clear()
        txtCategory.Clear()
        txtISBN.Clear()
        txtPrice.Clear()
        txtPublisher.Clear()
        txtTitle.Clear()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Len(Trim(txtBookID.Text)) = 0 Or Len(Trim(txtTitle.Text)) = 0 Or Len(Trim(txtAuthor.Text)) = 0 Then
            MessageBox.Show("Please fill mandatory Fields", "Error Generated", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBookID.Focus()
        Else

            myConnection.Open()
            Dim str As String
            str = "INSERT INTO tblBooks ([BookID], [Title], [Author], [Publisher], [Category], [Price], [ISBN]) VALUES (?, ?, ?, ?, ?, ?, ?)"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            cmd.Parameters.Add(New OleDbParameter("BookID", CType(txtBookID.Text, Integer)))
            cmd.Parameters.Add(New OleDbParameter("Title", CType(txtTitle.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Author", CType(txtAuthor.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Publisher", CType(txtPublisher.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Category", CType(txtCategory.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Price", CType(txtPrice.Text, Integer)))
            cmd.Parameters.Add(New OleDbParameter("ISBN", CType(txtISBN.Text, String)))
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MessageBox.Show("New Book Added", "Book Added", MessageBoxButtons.OK, MessageBoxIcon.Information)

                myConnection.Close()

                txtAuthor.Clear()
                txtBookID.Clear()
                txtCategory.Clear()
                txtISBN.Clear()
                txtPrice.Clear()
                txtPublisher.Clear()
                txtTitle.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        frmBooksUpdate.ShowDialog()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (txtBookID.Text = "") Then
            MessageBox.Show("Please enter the BookID", "Book Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBookID.Focus()
        Else
            Dim okToDelete As MsgBoxResult = MsgBox("Are you sure you want to delete the current record?", MsgBoxStyle.YesNo)
            If okToDelete = MsgBoxResult.Yes Then

                myConnection.Open()
                Dim str As String
                str = "DELETE FROM tblBooks WHERE [BookID] = " & txtBookID.Text & ""
                Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
                Try
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    MessageBox.Show("The book (BookID: " + txtBookID.Text + ") was deleted.", "Success", MessageBoxButtons.OK)
                    txtBookID.Text = ""
                    myConnection.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf okToDelete = MsgBoxResult.No Then
            End If
        End If
       
    End Sub
End Class