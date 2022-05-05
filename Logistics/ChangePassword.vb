Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class ChangePassword
    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        BackCol()
        Me.MaximizeBox = False
    End Sub

    Public Sub BackCol()
        Panel1.BackColor = Color.FromArgb(36, 36, 69)
        Panel2.BackColor = Color.FromArgb(237, 242, 255)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
        ChangeEmail.Show()
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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
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

        If TextBox1.Text <> pass Then
            MsgBox("Incorrect Current password")

        ElseIf TextBox2.Text <> TextBox3.Text Then
            MsgBox("New password and confirm new password does not match")
        Else
            cmd.CommandText = "Update login set password= '" & TextBox2.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Password Updates Successfully")


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
                e_mail.Subject = "Password updated successfully"
                e_mail.IsBodyHtml = True
                e_mail.Body = "<html>
                            <body>
                                <h2>Password updated successfully. If not done by you, please contact support team immediately </h2>
                            </body>
                            </html>"

                Smtp_Server.Send(e_mail)

            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try


            Me.Close()
            Profile.Show()

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