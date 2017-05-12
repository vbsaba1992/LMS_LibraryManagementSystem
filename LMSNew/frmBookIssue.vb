Imports System.Data.OleDb

Public Class frmBookIssue
    Dim myConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LMS_DB.accdb")

    Dim count As Integer

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtAuthor.Clear()
        txtBookID.Clear()
        txtBookTitle.Clear()
        'txtClass.Clear()
        cboMemberID.SelectedItem = -1 'txtMemberID.Clear()
        txtMemberName.Clear()
        dtpIssueDate.Text = Today
    End Sub

    Private Sub dtpIssueDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpIssueDate.ValueChanged
        dtpDueDate.Text = dtpIssueDate.Value.Date.AddDays(14)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssue.Click
        If Len(Trim(txtBookID.Text)) = 0 Then
            MessageBox.Show("Please insert Book ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBookID.Focus()
            Exit Sub
        End If
        
        Try

            myConnection.Open()

            Dim str As String
            str = "INSERT INTO tblBookIssue ([BookID], [BookTitle], [Author], [MemberID],  [MemberName], [IssueDate], [DueDate]) VALUES (?, ?, ?, ?, ?, ?, ?)"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            cmd.Parameters.Add(New OleDbParameter("BookID", CType(txtBookID.Text, Integer)))
            cmd.Parameters.Add(New OleDbParameter("BookTitle", CType(txtBookTitle.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Author", CType(txtAuthor.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("MemberID", CType(cboMemberID.Text, Integer)))
            cmd.Parameters.Add(New OleDbParameter("MemberName", CType(txtMemberName.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("IssueDate", CType(dtpIssueDate.Text, Date)))
            cmd.Parameters.Add(New OleDbParameter("DueDate", CType(dtpDueDate.Text, Date)))

            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()

            MessageBox.Show("Successfully issued", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtAuthor.Clear()
            txtBookID.Clear()
            txtBookTitle.Clear()
            txtMemberName.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            myConnection.Close()
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmBookIssue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDueDate.Text = dtpIssueDate.Value.Date.AddDays(14)
        Try
            Dim comd As String = ("SELECT MemberID, FirstName FROM tblMembers ORDER BY MemberID")
            Dim da As New OleDbDataAdapter(comd, myConnection)
            Dim ds As New DataSet
            da.Fill(ds)
            cboMemberID.DisplayMember = "MemberID"
            cboMemberID.ValueMember = "FirstName"
           
            cboMemberID.DataSource = ds.Tables(0)
            cboMemberID.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("ERROR : " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMemberID.SelectedIndexChanged
        txtMemberName.Text = cboMemberID.SelectedValue.ToString
         End Sub
End Class