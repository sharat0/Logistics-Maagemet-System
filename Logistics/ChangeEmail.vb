Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class ChangeEmail
    Dim otp As String
    Private Sub ChangeEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackCol()
        Me.MaximizeBox = False
        TextBox1.Focus()
        TextBox2.Enabled = "False"
        TextBox3.Enabled = "False"
        Guna2Button3.Hide()
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


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
        ChangePassword.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        Employee.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
        Customer.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim pass As String
        Dim email As String

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select * from login"
        dr = cmd.ExecuteReader
        dr.Read()
        pass = dr("password")
        email = dr("email")
        dr.Close()

        If TextBox1.Text = "" Then
            MsgBox("Please enter a valid email to continue.")

        ElseIf TextBox1.Text <> email Then
            MsgBox("Incorrect Current email")

        Else


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
                                <h3>Your one time password for changing email is " & otp & ". If not requested by you, please contact support team immediately </h3>
                            </body>
                            </html>"

                Smtp_Server.Send(e_mail)
                MsgBox("OTP sent successfully")
                TextBox2.Enabled = "true"
                Guna2Button2.Hide()
                Guna2Button3.Show()
                TextBox2.Focus()

            Catch error_t As Exception
                MsgBox(error_t.ToString)
                MsgBox("We are facing some technical issue. Please come back later.")
            End Try
        End If

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If TextBox2.Text = "" Then
            MsgBox("Please enter otp to continue")

        ElseIf TextBox2.Text = otp Then
            TextBox3.Enabled = True
            Guna2Button3.Hide()
            TextBox3.Focus()
        Else
            MsgBox("Incorrect OTP")
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        If TextBox3.Text = "" Then
            MsgBox("Please enter new email to continue")
        Else

            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            Dim old_email As String
            Dim new_mail As String = TextBox3.Text

            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Select email from login"
            dr = cmd.ExecuteReader
            dr.Read()
            old_email = dr("email")
            dr.Close()

            cmd.CommandText = "Update login set email ='" & new_mail & "'"
            cmd.ExecuteNonQuery()


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
                e_mail.To.Add(old_email)
                e_mail.Subject = "OTP"
                e_mail.IsBodyHtml = True
                e_mail.Body = "<html>
                            <body>
                                <h3>Your new email for loging in to logistics service is " & new_mail & ". If not changed by you, contact our support team immediately.</h3>
                            </body>
                            </html>"

                Smtp_Server.Send(e_mail)

            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try


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
                e_mail.To.Add(new_mail)
                e_mail.Subject = "OTP"
                e_mail.IsBodyHtml = True
                e_mail.Body = "<html>
                            <body>
                                <h3>Hello Admin. Welcome to our logistics system with new email. Please use this email as login credentials and old password to login to your account</h3>
                            </body>
                            </html>"

                Smtp_Server.Send(e_mail)
                MsgBox("Email updated successfully.")
            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try

        End If
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Me.Hide()
        home.Show()

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Me.Hide()
        home.Show()
    End Sub
End Class