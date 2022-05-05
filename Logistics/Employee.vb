Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class Employee
    Dim name As String
    Dim email As String
    Dim otp As String
    Dim phone As String
    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximizeBox = False
        BackCol()
        TextBox3.Enabled = False


        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * from employee"
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr("id"))
        Loop

    End Sub

    Public Sub BackCol()
        Panel1.BackColor = Color.FromArgb(36, 36, 69)
        Panel2.BackColor = Color.FromArgb(237, 242, 255)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
        ChangeEmail.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        ChangePassword.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
        Customer.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        Form1.Show()
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim id As Integer = ComboBox1.SelectedItem


        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Please select employee ID")

        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("All fields are mandatory")
            ElseIf Not Char.IsDigit(TextBox4.Text) Or CStr(TextBox4.Text).Length() <> 10 Then
                MsgBox("Enter valid 10 digits phone number")
            Else

                con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
            con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * from employee where id=" & id
        dr = cmd.ExecuteReader
        dr.Read()
        name = dr("name")
            email = dr("email")
            phone = dr("phone")
        dr.Close()
        TextBox1.Text = name
        TextBox2.Text = email
        TextBox4.Text = phone

        End If
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        ComboBox1.Enabled = "false"
        TextBox3.Enabled = True
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("All fields are mandatory except ID")
        Else
            email = TextBox2.Text
            'Generating 6 digits OTP
            Randomize()
            otp = CStr(Int((999999 * Rnd()) + 101111))

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
                e_mail.To.Add(email)
                e_mail.Subject = "OTP"
                e_mail.IsBodyHtml = True
                e_mail.Body = "<html>
                            <body>
                                <h3>Your one time password is " & otp & ". We welcome you as our employee. </h3>
                            </body>
                            </html>"

                Smtp_Server.Send(e_mail)
                MsgBox("OTP sent successfully")
            Catch error_t As Exception
                MsgBox(error_t.ToString)
                MsgBox("We are facing some technical issue. Please come back later.")
            End Try
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If TextBox3.Text = otp Then
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            Dim id As Integer = ComboBox1.SelectedItem
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Insert into employee (name, email, phone) values (@name, @email, @phone) "
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@phone", SqlDbType.BigInt).Value = TextBox4.Text
            cmd.ExecuteNonQuery()
            MsgBox("Added as employee")

            ComboBox1.Items.Clear()
            cmd.CommandText = "SELECT * from employee"
            dr = cmd.ExecuteReader
            Do While dr.Read
                ComboBox1.Items.Add(dr("id"))
            Loop
        Else
            MsgBox("Incorrect OTP")
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        TextBox3.Enabled = False
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("All fields are mandatory")
        Else
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            Dim id As Integer = ComboBox1.SelectedItem
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Update employee set name = '" & TextBox1.Text & " ',  email = '" & TextBox2.Text & "' , phone = '" & TextBox4.Text & "' where id = " & TextBox3.Text

            MsgBox("Data Inserted Successfully")

        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.Close()
        Profile.Show()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Me.Close()
        home.Show()
    End Sub
End Class