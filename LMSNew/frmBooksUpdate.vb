Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable

Public Class frmBooksUpdate

    Dim myConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LMS_DB.accdb")
    Dim con As OleDbConnection
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()

  
    Private Sub frmBookSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        da = New OleDbDataAdapter("SELECT [BookID], [Title], [Author], [Publisher], [Category],[Price], [ISBN] FROM tblBooks", myConnection)

        da.Fill(ds, "tblBooks")
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        DataGridView1.DataSource = view1
        DataGridView1.Refresh()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        txtBookID.Text = ds.Tables("tblBooks").Rows(i).Item(0)
        txtTitle.Text = ds.Tables("tblBooks").Rows(i).Item(1)
        txtAuthor.Text = ds.Tables("tblBooks").Rows(i).Item(2)
        txtPublisher.Text = ds.Tables("tblBooks").Rows(i).Item(3)
        txtCategory.Text = ds.Tables("tblBooks").Rows(i).Item(4)
        txtPrice.Text = ds.Tables("tblBooks").Rows(i).Item(5)
        txtISBN.Text = ds.Tables("tblBooks").Rows(i).Item(6)

    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        myConnection.Open()
        Dim str As String
        str = "UPDATE [tblBooks] SET [Title] = '" & txtTitle.Text & "' , [Author] = '" & txtAuthor.Text & "', [Publisher] = '" & txtPublisher.Text & "', [Category] = '" & txtCategory.Text & "', [Price] = '" & txtPrice.Text & "', [ISBN] = '" & txtISBN.Text & "' WHERE [BookID] = " & txtBookID.Text & ""

        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        Try
            cmd.ExecuteNonQuery()

            MessageBox.Show("The Book Updated", "Book Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim da As New OleDbDataAdapter("SELECT [BookID], [Title], [Author], [Publisher], [Category],[Price], [ISBN] FROM tblBooks", myConnection)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

        txtAuthor.Clear()
        txtBookID.Clear()
        txtCategory.Clear()
        txtISBN.Clear()
        txtPrice.Clear()
        txtPublisher.Clear()
        txtTitle.Clear()

        myConnection.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class