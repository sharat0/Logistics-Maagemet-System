Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class parcel_det
    Public cust_id As Integer
    Private Sub parcel_det_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximizeBox = False
        BackCol()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        ComboBox1.Items.Add("General")
        ComboBox1.Items.Add("Electric Appliances")
        ComboBox1.Items.Add("Gadgets")
        ComboBox1.Items.Add("House Holds")
        ComboBox1.SelectedIndex = 0

    End Sub


    Public Sub BackCol()
        Panel1.BackColor = Color.FromArgb(36, 36, 69)
        Panel2.BackColor = Color.FromArgb(237, 242, 255)
        Label10.BackColor = Color.FromArgb(0, 36, 199)
        Label10.ForeColor = Color.White
        Label9.BackColor = Color.FromArgb(255, 250, 235)
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
        Dim type As String
        Dim weight As Integer
        Dim del_type As Integer
        Dim dt As DateTime = DateTime.Today
        Dim edate As DateTime
        Dim cid As Integer

        If CheckBox1.Checked = True Then
            del_type = 1
            'edate = DateAdd("d", 3, dt)
            edate = dt.AddDays(3)

        Else
            del_type = 0
            'edate = DateAdd("d", 7, dt)
            edate = dt.AddDays(7)
        End If


        name = TextBox1.Text
        type = ComboBox1.SelectedItem

        Try

            weight = TextBox3.Text
        Catch ex As Exception
            MsgBox("All fields are mandatory")
        End Try

        If TextBox1.Text = "" Or ComboBox1.SelectedIndex = -1 Then
            MsgBox("All fields are mandatory")

        Else
            weight = CInt(weight)
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
            con.Open()
            cmd.Connection = con

            If cust_id = 0 Then
                cmd.CommandText = "SELECT max(id) as cid from customer"
                dr = cmd.ExecuteReader
                dr.Read()
                cid = dr("cid")
                dr.Close()

                cmd.CommandText = "Insert into Parcel (cid, name, type, weight, del_type,expected_dt ) values(" & cid & ", @name, @type, @weight, @del_type, " & edate & ")"
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type
                cmd.Parameters.Add("@weight", SqlDbType.Int).Value = weight
                cmd.Parameters.Add("@del_type", SqlDbType.Int).Value = del_type


            Else
                cmd.CommandText = "Insert into Parcel (cid, name, type, weight, del_type,expected_dt ) values(" & cust_id & ", @name, @type, @weight, @del_type," & edate & ")"
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type
                cmd.Parameters.Add("@weight", SqlDbType.Int).Value = weight
                cmd.Parameters.Add("@del_type", SqlDbType.Int).Value = del_type
            End If

            cmd.ExecuteNonQuery()
            con.Close()
            sendMail()

            Me.Close()
            seders_add.Show()
        End If
    End Sub

    Public Sub sendMail()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim name As String
        Dim email As String
        Dim cid As Integer
        Dim pid As Integer

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        If cust_id = 0 Then

            cmd.CommandText = "SELECT max(id) as cid from customer"
            dr = cmd.ExecuteReader
            dr.Read()
            cid = dr("cid")
            dr.Close()

            cmd.CommandText = "Select * from customer where id=" & cid
            dr = cmd.ExecuteReader
            dr.Read()
            name = dr("name")
            email = dr("email")
            dr.Close()
        Else

            cmd.CommandText = "Select * from customer where id=" & cust_id
            dr = cmd.ExecuteReader
            dr.Read()
            name = dr("name")
            email = dr("email")
            dr.Close()
        End If
        cmd.CommandText = "Select max(id) as pid from Parcel"
        dr = cmd.ExecuteReader
        dr.Read()
        pid = dr("pid")


        MsgBox("Parcel added Successfully")
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
            e_mail.Subject = "Parcel ID"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<html>
                            <body>
                                <h2>Your parcel id is <b>" & pid & "</b></h2>
                                <h3> Dear " & name & " your unique parcel id is " & pid & ". You can use this parcel id for further enquiries.</h3>
                            </body>
                            </html>"

            Smtp_Server.Send(e_mail)
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try

    End Sub

End Class