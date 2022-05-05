Imports System.Data.SqlClient
Public Class Customer
    Private Sub Customer_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        BackCol()


        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * from customer"
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr("id"))
        Loop
        dr.Close()
        con.Close()
        ComboBox1.SelectedIndex = 0
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

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
        Employee.Show()
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
        Dim name As String
        Dim email As String
        Dim phone As String
        Dim address As String
        Dim city As String
        Dim pin As Integer

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * from customer where id=" & id
        dr = cmd.ExecuteReader
        dr.Read()
        name = dr("name")
        phone = dr("phone")
        email = dr("email")
        address = dr("address")
        city = dr("city")
        pin = dr("pin")

        TextBox1.Text = name
        TextBox2.Text = email
        TextBox3.Text = phone
        TextBox4.Text = address
        TextBox5.Text = city
        TextBox6.Text = pin
        dr.Close()
            con.Close()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox4.Text = "" Then
            MsgBox("All fields are mandatory")
        ElseIf Not Char.Isdigit(TextBox3.Text) Or CStr(TextBox3.Text).Length() <> 10 Then
            MsgBox("Enter valid 10 digits phone number")
        ElseIf Not Char.IsDigit(TextBox6.Text) Or CStr(TextBox6.Text).Length() <> 6 Then
            MsgBox("Enter valid 6 digits pin code")
        Else
                Dim con As New SqlConnection
                Dim cmd As New SqlCommand
                Dim phone As Long = TextBox3.Text


                Dim id As Integer = ComboBox1.SelectedItem
                con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "Update customer set name = '" & TextBox1.Text & " ',  phone = '" & phone & "' , email = '" & TextBox3.Text & "', address = '" & TextBox4.Text & "', city = '" & TextBox5.Text & "', pin = '" & TextBox6.Text & "' where id = " & ComboBox1.SelectedItem
                cmd.ExecuteNonQuery()
                MsgBox("Data Updated Successfully")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""

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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim id As Integer = ComboBox1.SelectedItem
        Dim dr As SqlDataReader
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "DELETE from customer where id=" & id
        cmd.ExecuteNonQuery()
        MsgBox("Customer Details deleted successfully")
        ComboBox1.Items.Clear()
        cmd.CommandText = "SELECT * from customer"
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr("id"))
        Loop
        dr.Close()
        con.Close()
        ComboBox1.SelectedIndex = 0
    End Sub
End Class