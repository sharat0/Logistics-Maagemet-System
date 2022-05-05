Imports System.Data.SqlClient
Public Class ParcelRecords
    Private Sub ParcelRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackCol()
        Me.MaximizeBox = False

        fillData()
    End Sub

    Public Sub BackCol()
        Panel1.BackColor = Color.FromArgb(36, 36, 69)
        Panel2.BackColor = Color.FromArgb(237, 242, 255)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
        calculateRate.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        TrackPar.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
        Courier.Show()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        updateStatus.Show()

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Close()
        AssignEmp.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Me.Close()
        Profile.Show()
    End Sub

    Private Sub Lael1_MouseHover(sender As Object, e As EventArgs) Handles Label1.MouseHover
        Label1.ForeColor = Color.FromArgb(255, 140, 120)
    End Sub

    Private Sub label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.White
    End Sub


    Private Sub Label2_MouseHover(sender As Object, e As EventArgs) Handles Label2.MouseHover
        Label2.ForeColor = Color.FromArgb(255, 140, 120)
    End Sub

    Private Sub label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.White
    End Sub


    Private Sub Label3_MouseHover(sender As Object, e As EventArgs) Handles Label3.MouseHover
        Label3.ForeColor = Color.FromArgb(255, 140, 120)
    End Sub

    Private Sub label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.White
    End Sub


    Private Sub Lael4_MouseHover(sender As Object, e As EventArgs) Handles Label4.MouseHover
        Label4.ForeColor = Color.FromArgb(255, 140, 120)
    End Sub

    Private Sub label4_MouseLeave(sender As Object, e As EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.White
    End Sub

    Private Sub Label5_MouseHover(sender As Object, e As EventArgs) Handles Label5.MouseHover
        Label5.ForeColor = Color.FromArgb(255, 140, 120)
    End Sub

    Private Sub label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.White
    End Sub

    Private Sub Label6_MouseHover(sender As Object, e As EventArgs) Handles Label6.MouseHover
        Label6.ForeColor = Color.FromArgb(255, 140, 120)
    End Sub

    Private Sub label6_MouseLeave(sender As Object, e As EventArgs) Handles Label6.MouseLeave
        Label6.ForeColor = Color.White
    End Sub


    Private Sub Label8_MouseHover(sender As Object, e As EventArgs) Handles Label8.MouseHover
        Label8.ForeColor = Color.FromArgb(255, 140, 120)
    End Sub

    Private Sub label8_MouseLeave(sender As Object, e As EventArgs) Handles Label8.MouseLeave
        Label8.ForeColor = Color.White
    End Sub

    Public Sub fillData()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * from Parcel"
        Using da As New SqlDataAdapter(cmd)

            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        End Using
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click

        If TextBox1.Text = "" Then
            MsgBox("Enter customer ID to fetch data")

        Else

            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * from Parcel where cid= " & TextBox1.Text
            Using da As New SqlDataAdapter(cmd)
                ds.Clear()
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
            End Using
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        fillData()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Hide()
        home.Show()
    End Sub
End Class