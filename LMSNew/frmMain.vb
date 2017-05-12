Public Class frmMain

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
        frmMemberAdd.Close()
        frmLogin.ShowDialog()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmAbout As New frmAboutBox
        frmAbout.ShowDialog(Me)

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SearchBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBookToolStripMenuItem.Click
        frmBookSearch.Show()
    End Sub

    Private Sub AddMembersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMembersToolStripMenuItem.Click
        frmMemberAdd.ShowDialog()
    End Sub

    Private Sub AddBooksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBooksToolStripMenuItem.Click
        frmBookAdd.ShowDialog()
    End Sub

    Private Sub BookIssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookIssueToolStripMenuItem.Click
        frmBookIssue.ShowDialog()
    End Sub
End Class
