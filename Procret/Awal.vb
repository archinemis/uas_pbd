Imports System.Data.SqlClient

Public Class Awal

    Dim koneksi As String = "server=NYAMBEK-PC; database=UTS_PBD; user=pbd; password=123"
    Dim conn As SqlConnection

    Private Sub getData()
        conn = New SqlConnection(koneksi)
        Try
            conn.Open()

            Dim comall As SqlCommand
            comall = New SqlCommand
            comall.Connection = conn
            comall.CommandType = CommandType.Text
            comall.CommandText = "Select * from tb_menu"

            Dim reader As SqlDataReader
            reader = comall.ExecuteReader

            If reader.HasRows Then
                While reader.Read
                    Dim str(2) As String
                    Dim itm As ListViewItem
                    str(0) = reader(0)
                    str(1) = reader(1)
                    str(2) = reader(2)

                    itm = New ListViewItem(str)

                    lvMenu.Items.Add(itm)
                End While
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub Awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getData()
        Timer1.Start()
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

End Class