Imports System.Data.SqlClient
Public Class calculateRate
    Private Sub calculateRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackCol()
        ComboBox1.Items.Add("General")
        ComboBox1.Items.Add("Electric Appliances")
        ComboBox1.Items.Add("Gadgets")
        ComboBox1.Items.Add("House Holds")
        Me.MaximizeBox = False
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anony\source\repos\Logistics\Logistics\parcel.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        Dim dr As SqlDataReader
        cmd.CommandText = "Select city from cities"
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox2.Items.Add(dr("city"))
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
        Courier.Show()
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
        Dim weight As Integer = TextBox2.Text
        Dim price As Double = 0
        Dim type As String = ComboBox1.SelectedItem
        Dim city As String = ComboBox2.SelectedItem
        Dim deltype As Integer = 0
        If CheckBox1.Checked Then
            deltype = 1
        End If

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


        Label12.Text = price
    End Sub
End Class