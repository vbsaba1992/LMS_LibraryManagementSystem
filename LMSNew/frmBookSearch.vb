Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable

Public Class frmBookSearch

    Dim myConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LMS_DB.accdb")
    Dim dset As DataSet
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()

    Private Sub frmBookSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBookSearch.Focus()
        da = New OleDbDataAdapter("SELECT [BookID], [Title], [Author], [Publisher], [Category], [Price], [ISBN] FROM tblBooks", myConnection)
        da.Fill(ds, "tblBooks")
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        DataGridView1.DataSource = view1
        DataGridView1.Refresh()

    End Sub

    Private Sub txtBoxNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBookSearch.KeyPress
        source1.Filter = String.Format("[Title] LIKE'" & txtBookSearch.Text & "%'")
        DataGridView1.Refresh()
    End Sub

End Class