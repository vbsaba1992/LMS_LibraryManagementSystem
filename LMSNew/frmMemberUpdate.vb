Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable

Public Class frmMemberUpdate

    Dim myConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LMS_DB.accdb")
    Dim con As OleDbConnection
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()




    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        txtAddress.Text = ds.Tables("tblMembers").Rows(i).Item(3)
        txtClass.Text = ds.Tables("tblMembers").Rows(i).Item(4)
        txtContact.Text = ds.Tables("tblMembers").Rows(i).Item(5)
        txtFirstName.Text = ds.Tables("tblMembers").Rows(i).Item(1)
        txtLastName.Text = ds.Tables("tblMembers").Rows(i).Item(2)
        txtMemberID.Text = ds.Tables("tblMembers").Rows(i).Item(0)


    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        myConnection.Open()
        Dim str As String
        str = "UPDATE [tblMembers] SET [FirstName] = '" & txtFirstName.Text & "', [LastName] = '" & txtLastName.Text & "', [Address] = '" & txtAddress.Text & "', [Class] = '" & txtClass.Text & "', [ContactNo] = '" & txtContact.Text & "' WHERE [MemberID] = " & txtMemberID.Text & ""

        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        Try
            cmd.ExecuteNonQuery()

            MessageBox.Show("The Member Updated", "Member Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim da As New OleDbDataAdapter("SELECT [MemberID], [FirstName], [LastName], [Address], [Class],[ContactNo] FROM tblMembers", myConnection)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

        txtAddress.Text = ""
        txtClass.Text = ""
        txtContact.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtMemberID.Text = ""

        myConnection.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub member_update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        da = New OleDbDataAdapter("SELECT [MemberID], [FirstName], [LastName], [Address], [Class],[ContactNo] FROM tblMembers", myConnection)

        da.Fill(ds, "tblMembers")
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        DataGridView1.DataSource = view1
        DataGridView1.Refresh()
        


    End Sub
End Class




