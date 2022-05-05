Imports System.Data.SqlClient
Public Class seders_add
    Private Sub seders_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackCol()
        fetchCity()
        ComboBox1.SelectedIndex = 0
        Me.MaximizeBox = False
    End Sub
    Public Sub BackCol()
        Panel1.BackColor = Color.FromArgb(36, 36, 69)
        Panel2.BackColor = Color.FromArgb(237, 242, 255)
        Label9.BackColor = Color.FromArgb(255, 250, 235)
        Label10.BackColor = Color.FromArgb(255, 250, 235)
        Label11.BackColor = Color.FromArgb(0, 36, 199)
        Label11.ForeColor = Color.White
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
        Dim phone As Long
        Dim address As String
        Dim city As String
        Dim pin As Integer
        name = TextBox1.Text
        address = TextBox3.Text
        city = ComboBox1.SelectedItem

        phone = CLng(TextBox2.Text)
        pin = CInt(TextBox4.Text)

        If name = "" Or address = "" Or city = "" Then

            MsgBox("All fields are compulsory")

        ElseIf Not Char.IsDigit(CStr(phone)) Or CStr(phone).length() <> 10 Then

            MsgBox("Enter valid 10 digits phone number")
        ElseIf Not Char.IsDigit(CStr(pin)) Or CStr(pin).length() <> 6 Then

            MsgBox("Enter Valid 6 Digits PIN code")
        Else
            phone = CLng(phone)
            pin = CInt(pin)
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select max(id) as pid from Parcel"
            dr = cmd.ExecuteReader
            dr.Read()
            Dim pid As Integer
            pid = dr("pid")
            dr.Close()
            cmd.CommandText = "select max(id) as uid from customer"
            dr = cmd.ExecuteReader
            dr.Read()
            Dim uid As Integer
            uid = dr("uid")
            dr.Close()


            cmd.CommandText = "insert into sender_det (p_id, u_id, name, phone, address, city, pin) values (" & pid & "," & uid & ",@name, @phone, @address, @city, @pin)"
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@phone", SqlDbType.BigInt).Value = TextBox2.Text
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = TextBox3.Text
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = ComboBox1.SelectedItem
            cmd.Parameters.Add("@pin", SqlDbType.Int).Value = TextBox4.Text
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Sender added Successfully")
            Me.Close()
            receiver_det.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.SelectedIndex = -1
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
End Class