Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class AssignEmp
    Dim rec_mail As String
    Dim emp_mail As String
    Private Sub AssignEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        BackCol()
        Me.MaximizeBox = False

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * from parcel where emp_assign= '0'"
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr("id"))
        Loop
        dr.Close()
        cmd.CommandText = "SELECT * from employee where p_assign= 0"
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox2.Items.Add(dr("id"))
        Loop
        dr.Close()
        con.Close()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
    End Sub

    Public Sub BackCol()
        Panel1.BackColor = Color.FromArgb(36, 36, 69)
        Panel2.BackColor = Color.FromArgb(237, 242, 255)

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

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
        ParcelRecords.Show()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        updateStatus.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Me.Close()
        Profile.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim id As Integer = ComboBox1.SelectedItem
        Dim type As String
        Dim name As String
        Dim del_type As String
        Dim dt As Date
        Dim exp_dt As Date


        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * from parcel where id=" & id
        dr = cmd.ExecuteReader
        dr.Read()
        name = dr("name")
        type = dr("type")
        del_type = dr("del_type")
        dt = dr("dt")


        exp_dt = dt.AddDays(7)

        Label15.Text = type
        Label16.Text = name
        If del_type = 0 Then

            Label17.Text = "General Delivery"
        Else
            Label17.Text = "Express Delivery"
        End If
        Label18.Text = dt
        Label19.Text = exp_dt

        dr.Close()
        con.Close()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader


        Dim rec_mail As String
        Dim emp_mail As String


        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Update parcel set emp_assign = '" & ComboBox2.SelectedItem & "' where id = " & ComboBox1.SelectedItem
        cmd.ExecuteNonQuery()

        cmd.CommandText = "Update employee set p_assign='" & ComboBox1.SelectedItem & "' where id = " & ComboBox2.SelectedItem
        cmd.ExecuteNonQuery()


        cmd.CommandText = "Select email from employee where id= " & ComboBox2.SelectedItem
        dr = cmd.ExecuteReader
        dr.Read()
        emp_mail = dr("email")
        dr.Close()

        cmd.CommandText = "Select email from receiver_det where p_id= " & ComboBox1.SelectedItem
        dr = cmd.ExecuteReader
        dr.Read()
        rec_mail = dr("email")
        dr.Close()

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("logisticservicekjc@gmail.com", "apoorv.sharat@123")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("logisticservicekjc@gmail.com")
            e_mail.To.Add(rec_mail)
            e_mail.Subject = "Your parcel is out for delivery"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<html>
                            <body>
                                <h3>Dear customer, your parcel with parcel number " & ComboBox1.SelectedItem & " is out for delivery. <br>
                                 Thank you for chosing us. </h3>
                            </body>
                            </html>"

            Smtp_Server.Send(e_mail)


            e_mail = New MailMessage()
            e_mail.From = New MailAddress("logisticservicekjc@gmail.com")
            e_mail.To.Add(emp_mail)
            e_mail.Subject = "New parcel assigned"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<html>
                            <body>
                                <h3>Dear employee, you have been assigned a new parcel with parcel ID " & ComboBox1.SelectedItem & ". <br>
                                    Please try to deliver it as soon as possible. <br>
                                 Thank you for chosing us. </h3>
                            </body>
                            </html>"

            Smtp_Server.Send(e_mail)
            MsgBox("Employee Assigned Successfully")
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

End Class