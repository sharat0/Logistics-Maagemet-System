Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class payment
    Public uid As Integer = 0
    Dim obj As New calc_payment
    Dim amt As Integer = obj.amount()
    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackCol()
        Me.MaximizeBox = False

        Label19.Text = amt
        Label20.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label18.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        DateTimePicker1.Visible = False

        If Label20.Visible = False Then
            Label17.Location = New Point(234, 235)
            Label19.Location = New Point(404, 235)
        End If

    End Sub
    Public Sub BackCol()
        Panel1.BackColor = Color.FromArgb(36, 36, 69)
        Panel2.BackColor = Color.FromArgb(237, 242, 255)
        Label9.BackColor = Color.FromArgb(255, 250, 235)
        Label10.BackColor = Color.FromArgb(255, 250, 235)
        Label11.BackColor = Color.FromArgb(255, 250, 235)
        Label12.BackColor = Color.FromArgb(255, 250, 235)
        Label13.BackColor = Color.FromArgb(0, 36, 199)
        Label13.ForeColor = Color.White
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim pid As Integer
        Dim weight As Integer
        Dim type As String
        Dim p_mode As Integer
        Dim deltype As Integer
        Dim city As String
        Dim name As String = ""
        Dim card As Long = 0
        Dim cvv As Integer = 0
        Dim dt As Date = Date.Today
        Dim amt As Double
        amt = obj.amount()



        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select max(id) as pid from Parcel"
        dr = cmd.ExecuteReader
        dr.Read()
        pid = dr("pid")
        dr.Close()
        cmd.CommandText = "Select * from Parcel where id=" & pid
        dr = cmd.ExecuteReader
        dr.Read()
        weight = dr("weight")
        type = dr("type")
        deltype = dr("del_type")
        dr.Close()
        If uid = 0 Then

            cmd.CommandText = "Select max(id) as uid from customer"
            dr = cmd.ExecuteReader
            dr.Read()
            uid = dr("uid")
            dr.Close()
        End If
        cmd.CommandText = "Select city from receiver_det where p_id=" & pid
        dr = cmd.ExecuteReader
        dr.Read()
        city = dr("city")
        dr.Close()

        If Label20.Visible = True Then

            name = TextBox1.Text
            card = CLng(TextBox2.Text)
            cvv = CInt(TextBox3.Text)
            dt = DateTimePicker1.Value
            p_mode = 1

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
                MsgBox("Please emter all the details")
            ElseIf Not Char.IsDigit(CStr(TextBox2.Text)) Or CStr(TextBox2.Text).Length() <> 10 Then

                MsgBox("Enter valid 10 digits card number")
            ElseIf Not Char.IsDigit(CStr(TextBox3.Text)) Or CStr(TextBox3.Text).Length() <> 3 Then

                MsgBox("Enter Valid 3 Digits CVV")
            End If


            cmd.CommandText = "Insert into payment (u_id, p_id, card_name, card_no, cvv, exp_date, amt) values (@user_id, @par_id,@user, @card_no, @cvv, @exp, @amt)"
                cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = uid
                cmd.Parameters.Add("@par_id", SqlDbType.Int).Value = pid
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = name
                cmd.Parameters.Add("@card_no", SqlDbType.BigInt).Value = card
                cmd.Parameters.Add("@cvv", SqlDbType.Int).Value = cvv
                cmd.Parameters.Add("@exp", SqlDbType.Date).Value = dt
                cmd.Parameters.Add("@amt", SqlDbType.Int).Value = amt
                cmd.ExecuteNonQuery()
                con.Close()

            Else
                p_mode = 0
            cmd.CommandText = "Insert into payment (u_id, p_id,p_mode, amt) values (@user_id, @par_id, @p_mode, @amt)"
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = uid
            cmd.Parameters.Add("@par_id", SqlDbType.Int).Value = pid
            cmd.Parameters.Add("@p_mode", SqlDbType.Int).Value = p_mode
            cmd.Parameters.Add("@amt", SqlDbType.Float).Value = amt
            cmd.ExecuteNonQuery()
            con.Close()
        End If
        Dim send_mail As New calc_payment
        send_mail.sendMail()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label19.Text = amt
        Label20.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label18.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        DateTimePicker1.Visible = False

        If Label20.Visible = False Then
            Label17.Location = New Point(234, 235)
            Label19.Location = New Point(404, 235)
        End If

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        DateTimePicker1.Value = Date.Today
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Label20.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label18.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        DateTimePicker1.Visible = False

        Label17.Location = New Point(222, 236)
        Label19.Location = New Point(394, 236)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Label20.Visible = True
        Label15.Visible = True
        Label16.Visible = True
        Label18.Visible = True
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        DateTimePicker1.Visible = True
        Label17.Location = New Point(116, 479)
        Label19.Location = New Point(288, 479)
    End Sub

End Class

Public Class calc_payment
    Public price As Double
    Public Function amount() As Integer

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim pid As Integer

        Dim weight As Integer
        Dim type As String
        Dim deltype As Integer
        Dim city As String

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select max(id) as pid from Parcel"
        dr = cmd.ExecuteReader
        dr.Read()
        pid = dr("pid")
        dr.Close()
        cmd.CommandText = "Select * from Parcel where id=" & pid
        dr = cmd.ExecuteReader
        dr.Read()
        weight = dr("weight")
        type = dr("type")
        deltype = dr("del_type")
        dr.Close()
        cmd.CommandText = "Select city from receiver_det where p_id=" & pid
        dr = cmd.ExecuteReader
        dr.Read()
        city = dr("city")
        dr.Close()
        con.Close()

        If weight < 0 Then
            MsgBox("weight can not be negative")
        ElseIf weight <= 2000 Then
            price = 50

        ElseIf weight > 2000 And weight <= 5000 Then
            price = 50 + (weight - 2000) * 0.15
        Else
            price = (50 + (weight - 2000) * 0.15) + ((weight - 5000) * 0.2)
        End If
        If deltype = 1 Then
            price = price + 100
        End If
        If city = "Bangalore" Then
            price = price + 10
        ElseIf city = "Mangalore" Then
            price = price + 25
        ElseIf city = "Mysore" Then
            price = price + 30
        ElseIf city = "Tirupati" Then
            price = price + 35
        ElseIf city = "Hassan" Then
            price = price + 40
        Else
            price = price + 45
        End If


        If type = "Electric Appliances" Then
            price = price + 50
        ElseIf type = "Gadgets" Then
            price = price + 70
        ElseIf type = "House Holds" Then
            price = price + 35
        Else
            price = price + 0
        End If
        Return price

    End Function


    Public Sub sendMail()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim name As String
        Dim email As String
        Dim payid As Integer

        Dim cid As Integer
        Dim parid As Integer
        Dim amt As Double = amount()
        Dim exp_dt As Date
        Dim dt As Date
        Dim r_name As String
        Dim r_email As String

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con

        cmd.CommandText = "SELECT max(pay_id) as payid from payment"
        dr = cmd.ExecuteReader
        dr.Read()
        payid = dr("payid")
        dr.Close()

        cmd.CommandText = "Select * from payment where pay_id=" & payid
        dr = cmd.ExecuteReader
        dr.Read()
        cid = dr("u_id")
        parid = dr("p_id")

        dr.Close()

        cmd.CommandText = "Select * from customer where id=" & cid

        dr = cmd.ExecuteReader
        dr.Read()
        name = dr("name")
        email = dr("email")
        dr.Close()

        cmd.CommandText = "Select * from Parcel where id=" & parid

        dr = cmd.ExecuteReader
        dr.Read()
        Dim parcel_id = dr("id")
        dt = dr("dt")
        Dim del_type = dr("del_type")

        If del_type = 0 Then

            exp_dt = dt.AddDays(7)
        Else

            exp_dt = dt.AddDays(3)
        End If
        dr.Close()


        cmd.CommandText = "Select * from Receiver_det where p_id=" & parid

        dr = cmd.ExecuteReader
        dr.Read()
        r_name = dr("name")
        r_email = dr("email")


        dr.Close()
        con.Close()

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
            e_mail.Subject = "Parcel received successfully"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<html>
                            <body>
                                <h2>Dear " & name & " your payment is completed successfully and we have received your package. </h2>
                                <h3> Your parcel Id is " & parcel_id & " </h3>
                                <h3>Your package will be delivered on" & exp_dt & ". </h3>
                                <h4>Thank You for choosing us.</h4>
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

            e_mail.To.Add(r_email)
            e_mail.Subject = "Parcel received successfully"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<html>
                            <body>
                                <h2>Dear " & r_name & " ,we have received your package. </h2>
                                <h3>Your package will be delivered on" & exp_dt & ". </h3>
                                <h4>Thank You for choosing us.</h4>
                            </body>
                            </html>"

            Smtp_Server.Send(e_mail)
            MsgBox("Payment Successful")


        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
        payment.Close()
        home.Show()
    End Sub

End Class