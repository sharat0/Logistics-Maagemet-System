Imports System.Data.SqlClient
Public Class Profile
    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Me.MaximizeBox = False

        Dim cust_count As Integer
        Dim p_count As Integer
        Dim emp_count As Integer
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT count(id) as cust_count from customer"
        dr = cmd.ExecuteReader
        dr.Read()
        cust_count = dr("cust_count")
        Label6.Text = cust_count
        dr.Close()

        cmd.CommandText = "SELECT count(id) as p_count from Parcel"
        dr = cmd.ExecuteReader
        dr.Read()
        p_count = dr("p_count")
        Label5.Text = p_count
        dr.Close()

        cmd.CommandText = "SELECT count(id) as emp_count from employee"
        dr = cmd.ExecuteReader
        dr.Read()
        emp_count = dr("emp_count")
        Label4.Text = emp_count
        dr.Close()
    End Sub


    Public Sub Panel3_MouseHover(sender As Object, e As EventArgs) Handles Panel3.MouseHover
        Panel3.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label7.BackColor = Color.Transparent
        Label7.ForeColor = Color.Black
        PictureBox2.BackColor = Color.Transparent
    End Sub

    Public Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Panel3.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label7.BackColor = Color.Transparent
        Label7.ForeColor = Color.Black
        PictureBox2.BackColor = Color.Transparent
    End Sub

    Public Sub Label7_MouseHover(sender As Object, e As EventArgs) Handles Label7.MouseHover
        Panel3.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label7.BackColor = Color.Transparent
        Label7.ForeColor = Color.Black
        PictureBox2.BackColor = Color.Transparent
    End Sub

    Public Sub Panel3_MouseLeave(sender As Object, e As EventArgs) Handles Panel3.MouseLeave
        Panel3.BackColor = Color.FromArgb(150, 255, 255, 255)
    End Sub



    Public Sub Panel4_MouseHover(sender As Object, e As EventArgs) Handles Panel4.MouseHover
        Panel4.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label8.BackColor = Color.Transparent
        Label8.ForeColor = Color.Black
        PictureBox3.BackColor = Color.Transparent
    End Sub

    Public Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        Panel4.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label8.BackColor = Color.Transparent
        Label8.ForeColor = Color.Black
        PictureBox3.BackColor = Color.Transparent
    End Sub

    Public Sub Label8_MouseHover(sender As Object, e As EventArgs) Handles Label8.MouseHover
        Panel4.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label8.BackColor = Color.Transparent
        Label8.ForeColor = Color.Black
        PictureBox3.BackColor = Color.Transparent
    End Sub

    Public Sub Panel4_MouseLeave(sender As Object, e As EventArgs) Handles Panel4.MouseLeave
        Panel4.BackColor = Color.FromArgb(150, 255, 255, 255)
    End Sub



    Public Sub Panel5_MouseHover(sender As Object, e As EventArgs) Handles Panel5.MouseHover
        Panel5.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label9.BackColor = Color.Transparent
        Label9.ForeColor = Color.Black
        PictureBox4.BackColor = Color.Transparent
    End Sub

    Public Sub PictureBox4_MouseHover(sender As Object, e As EventArgs) Handles PictureBox4.MouseHover
        Panel5.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label9.BackColor = Color.Transparent
        Label9.ForeColor = Color.Black
        PictureBox4.BackColor = Color.Transparent
    End Sub

    Public Sub Label9_MouseHover(sender As Object, e As EventArgs) Handles Label9.MouseHover
        Panel5.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label9.BackColor = Color.Transparent
        Label9.ForeColor = Color.Black
        PictureBox4.BackColor = Color.Transparent
    End Sub

    Public Sub Panel5_MouseLeave(sender As Object, e As EventArgs) Handles Panel5.MouseLeave
        Panel5.BackColor = Color.FromArgb(150, 255, 255, 255)
    End Sub




    Public Sub Panel6_MouseHover(sender As Object, e As EventArgs) Handles Panel6.MouseHover
        Panel6.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label10.BackColor = Color.Transparent
        Label10.ForeColor = Color.Black
        PictureBox5.BackColor = Color.Transparent
    End Sub

    Public Sub PictureBox5_MouseHover(sender As Object, e As EventArgs) Handles PictureBox5.MouseHover
        Panel6.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label10.BackColor = Color.Transparent
        Label10.ForeColor = Color.Black
        PictureBox5.BackColor = Color.Transparent
    End Sub

    Public Sub Label10_MouseHover(sender As Object, e As EventArgs) Handles Label10.MouseHover
        Panel6.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label10.BackColor = Color.Transparent
        Label10.ForeColor = Color.Black
        PictureBox5.BackColor = Color.Transparent
    End Sub

    Public Sub Panel6_MouseLeave(sender As Object, e As EventArgs) Handles Panel6.MouseLeave
        Panel6.BackColor = Color.FromArgb(150, 255, 255, 255)
    End Sub



    Public Sub Panel7_MouseHover(sender As Object, e As EventArgs) Handles Panel7.MouseHover
        Panel7.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label11.BackColor = Color.Transparent
        Label11.ForeColor = Color.Black
        PictureBox6.BackColor = Color.Transparent
    End Sub

    Public Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        Panel7.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label11.BackColor = Color.Transparent
        Label11.ForeColor = Color.Black
        PictureBox6.BackColor = Color.Transparent
    End Sub

    Public Sub Label11_MouseHover(sender As Object, e As EventArgs) Handles Label11.MouseHover
        Panel7.BackColor = Color.FromArgb(180, 255, 255, 255)
        Label11.BackColor = Color.Transparent
        Label11.ForeColor = Color.Black
        PictureBox6.BackColor = Color.Transparent
    End Sub

    Public Sub Panel7_MouseLeave(sender As Object, e As EventArgs) Handles Panel7.MouseLeave
        Panel7.BackColor = Color.FromArgb(150, 255, 255, 255)
    End Sub




    'Change Password Click
    Public Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        ChangePassword.Show()
    End Sub

    Public Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Me.Hide()
        ChangePassword.Show()
    End Sub

    Public Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()
        ChangePassword.Show()
    End Sub


    'change password ends

    'Change Email Click
    Public Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        ChangeEmail.Show()
    End Sub

    Public Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Me.Hide()
        ChangeEmail.Show()
    End Sub

    Public Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Me.Hide()
        ChangeEmail.Show()
    End Sub


    'Change Email Ends

    'Employee Click
    Public Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Employee.Show()
    End Sub

    Public Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        Me.Hide()
        Employee.Show()
    End Sub

    Public Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Me.Hide()
        Employee.Show()
    End Sub
    'Employee Ends




    'Customer Click
    Public Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Customer.Show()
    End Sub

    Public Sub panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        Me.Hide()
        Customer.Show()
    End Sub

    Public Sub label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.Hide()
        Customer.Show()
    End Sub

    'Customer Ends


    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Public Sub PictureBox7_click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Public Sub Label11_click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Hide()
        Form1.Show()
    End Sub

End Class