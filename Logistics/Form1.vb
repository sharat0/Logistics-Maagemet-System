Imports System.Data.SqlClient
Public Class Form1
    Public Sub Form1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select * from login"
        dr = cmd.ExecuteReader
        dr.Read()
        Dim id As String
        Dim pass As String
        id = dr("email")
        pass = dr("password")

        If TextBox1.Text = id And TextBox2.Text = pass Then
            home.Show()
            Me.Hide()
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("All fields are compulsory")
        Else
            MsgBox("Incorrect id or password")
        End If
        dr.Close()
        con.Close()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Close()
    End Sub
End Class
