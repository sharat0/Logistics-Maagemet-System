Imports System.Data.SqlClient
'For sending emails
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Public Class Courier

    Private Sub Courier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackCol()
        fetchCity()
        Me.MaximizeBox = False
        ComboBox1.SelectedIndex = 0
    End Sub

    Public Sub BackCol()
        Panel1.BackColor = Color.FromArgb(36, 36, 69)
        Panel2.BackColor = Color.FromArgb(237, 242, 255)
        Label9.BackColor = Color.FromArgb(0, 36, 199)
        Label9.ForeColor = Color.White
        Label10.BackColor = Color.FromArgb(255, 250, 235)
        Label11.BackColor = Color.FromArgb(255, 250, 235)
        Label12.BackColor = Color.FromArgb(255, 250, 235)
        Label13.BackColor = Color.FromArgb(255, 250, 235)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
        calculateRate.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        TrackPar.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
        ParcelRecords.Show()

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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Dim name As String


        Dim address As String
        Dim city As String

        name = TextBox1.Text
        address = TextBox3.Text
        city = ComboBox1.SelectedItem

        If TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("All fields are mandatory")
        ElseIf name = "" Or address = "" Or city = "" Then

            MsgBox("All fields are compulsory")
        ElseIf Not Char.IsDigit(CStr(TextBox2.Text)) Or CStr(TextBox2.Text).Length() <> 10 Then

            MsgBox("Enter valid 10 digits phone number")
        ElseIf Not Char.IsDigit(CStr(TextBox4.Text)) Or CStr(TextBox4.Text).Length() <> 6 Then

            MsgBox("Enter Valid 6 Digits PIN code")
        Else
            Dim phone As Long = CLng(TextBox2.Text)
            Dim pin As Integer = CInt(TextBox4.Text)
            phone = CLng(phone)
            pin = CInt(pin)
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
            con.Open()
            cmd.Connection = con


            cmd.CommandText = "insert into customer (name, phone,email, address, city, pin) values (@name, @phone,@email, @address, @city, @pin)"
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@phone", SqlDbType.BigInt).Value = TextBox2.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox5.Text
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = TextBox3.Text
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = ComboBox1.SelectedItem
            cmd.Parameters.Add("@pin", SqlDbType.Int).Value = TextBox4.Text
            cmd.ExecuteNonQuery()

            sendMail()

            Me.Hide()
            parcel_det.Show()

            con.Close()

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.SelectedIndex = -1
        TextBox4.Text = ""
    End Sub

    Public Sub fetchCity()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        Dim dr As SqlDataReader
        cmd.CommandText = "Select city from cities"
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr("city"))
        Loop
        dr.Close()
        con.Close()
    End Sub


    Public Sub sendMail()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim name As String
        Dim cid As Integer = 0
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con

        cmd.CommandText = "SELECT max(id) as cid from customer"
        dr = cmd.ExecuteReader
        dr.Read()
        cid = dr("cid")
        dr.Close()

        cmd.CommandText = "Select name from customer where id=" & cid
        dr = cmd.ExecuteReader
        dr.Read()
        name = dr("name")
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
            e_mail.To.Add(TextBox5.Text)
            e_mail.Subject = "Account Registration Successful"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<html>
                            <body>
                                <h2>Welcome to our logistics service</h2>
                                <h3> Dear " & name & " your customer unique id is " & cid & "</h3>
                            </body>
                            </html>"

            Smtp_Server.Send(e_mail)
            MsgBox("Customer added Successfully")
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim email As String = TextBox5.Text
        Dim cid As Integer
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con

        cmd.CommandText = "select * from customer where email ='" & email & "'"
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            cid = dr("id")
            TextBox2.Text = dr("phone")
            TextBox3.Text = dr("address")
            TextBox2.Text = dr("pin")
            TextBox1.Text = dr("name")
            TextBox4.Text = dr("pin")
            ComboBox1.SelectedItem = dr("city")
            MsgBox("Existing Account. Redirecting to parcel details page.")

            parcel_det.cust_id = cid
            payment.uid = cid


            Me.Close()
            parcel_det.Show()

        Else
            MsgBox("No existing data found")
        End If
    End Sub


End Class

