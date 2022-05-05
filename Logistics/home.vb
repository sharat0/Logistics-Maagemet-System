Public Class home
    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setting picture size in all 5 panel pictures (buttons)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox7.SizeMode = PictureBoxSizeMode.StretchImage


        'Setting background color for the panels
        Me.BackColor = Color.FromArgb(0, 180, 216)
        Panel1.BackColor = Color.FromArgb(50, 180, 255)
        Panel6.BackColor = Color.FromArgb(50, 180, 255)
        Panel2.BackColor = Color.FromArgb(50, 180, 255)
        Panel3.BackColor = Color.FromArgb(50, 180, 255)
        Panel7.BackColor = Color.FromArgb(50, 180, 255)
        Panel4.BackColor = Color.FromArgb(50, 180, 255)

        Panel5.BackColor = Color.FromArgb(50, 180, 255)

        Me.BackgroundImageLayout = ImageLayout.Stretch

    End Sub


    'Courier
    'Setting background color on mouse hover for panel 1
    Private Sub Panel1_MouseHover(sender As Object, e As EventArgs) Handles Panel1.MouseHover
        Panel1.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        Panel1.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub Label2_MouseHover(sender As Object, e As EventArgs) Handles Label2.MouseHover
        Panel1.BackColor = Color.FromArgb(144, 224, 239)
    End Sub

    Private Sub Panel1_MouseLeave(sender As Object, e As EventArgs) Handles Panel1.MouseLeave
        Panel1.BackColor = Color.FromArgb(50, 180, 255)
    End Sub


    'Courier Ends



    'Rate Calculator
    'Setting background color on mouse hover for panel6
    Private Sub Panel6_MouseHover(sender As Object, e As EventArgs) Handles Panel6.MouseHover
        Panel6.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        Panel6.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub Label7_MouseHover(sender As Object, e As EventArgs) Handles Label7.MouseHover
        Panel6.BackColor = Color.FromArgb(144, 224, 239)
    End Sub

    Private Sub Panel6_MouseLeave(sender As Object, e As EventArgs) Handles Panel6.MouseLeave
        Panel6.BackColor = Color.FromArgb(50, 180, 255)
    End Sub

    'Rate Calculator Ends





    'Track Parcel
    'Setting background color on mouse hover for panel 3
    Private Sub Panel3_MouseHover(sender As Object, e As EventArgs) Handles Panel3.MouseHover
        Panel3.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        Panel3.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub Label4_MouseHover(sender As Object, e As EventArgs) Handles Label4.MouseHover
        Panel3.BackColor = Color.FromArgb(144, 224, 239)
    End Sub

    Private Sub Panel3_MouseLeave(sender As Object, e As EventArgs) Handles Panel3.MouseLeave
        Panel3.BackColor = Color.FromArgb(50, 180, 255)
    End Sub

    'Track Parcel Ends



    'Records
    'Setting background color on mouse hover for panel 4
    Private Sub Panel4_MouseHover(sender As Object, e As EventArgs) Handles Panel4.MouseHover
        Panel4.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub PictureBox4_MouseHover(sender As Object, e As EventArgs) Handles PictureBox4.MouseHover
        Panel4.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub Label5_MouseHover(sender As Object, e As EventArgs) Handles Label5.MouseHover
        Panel4.BackColor = Color.FromArgb(144, 224, 239)
    End Sub

    Private Sub Panel4_MouseLeave(sender As Object, e As EventArgs) Handles Panel4.MouseLeave
        Panel4.BackColor = Color.FromArgb(50, 180, 255)
    End Sub

    'Records Ends




    'Update Status
    'Setting background color on mouse hover for panel7
    Private Sub Panel7_MouseHover(sender As Object, e As EventArgs) Handles Panel7.MouseHover
        Panel7.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub PictureBox7_MouseHover(sender As Object, e As EventArgs) Handles PictureBox7.MouseHover
        Panel7.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub Label8_MouseHover(sender As Object, e As EventArgs) Handles Label8.MouseHover
        Panel7.BackColor = Color.FromArgb(144, 224, 239)
    End Sub

    Private Sub Panel7_MouseLeave(sender As Object, e As EventArgs) Handles Panel7.MouseLeave
        Panel7.BackColor = Color.FromArgb(50, 180, 255)
    End Sub

    'Update Status Ends



    'Assign Employee
    'Setting background color on mouse hover for panel 2
    Private Sub Panel2_MouseHover(sender As Object, e As EventArgs) Handles Panel2.MouseHover
        Panel2.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Panel2.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub Label3_MouseHover(sender As Object, e As EventArgs) Handles Label3.MouseHover
        Panel2.BackColor = Color.FromArgb(144, 224, 239)
    End Sub

    Private Sub Panel2_MouseLeave(sender As Object, e As EventArgs) Handles Panel2.MouseLeave
        Panel2.BackColor = Color.FromArgb(50, 180, 255)
    End Sub

    'Assign Employee Ends







    'Profile    
    'Setting background color on mouse hover for panel5
    Private Sub Panel5_MouseHover(sender As Object, e As EventArgs) Handles Panel5.MouseHover
        Panel5.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub PictureBox5_MouseHover(sender As Object, e As EventArgs) Handles PictureBox5.MouseHover
        Panel5.BackColor = Color.FromArgb(144, 224, 239)
    End Sub
    Private Sub Label6_MouseHover(sender As Object, e As EventArgs) Handles Label6.MouseHover
        Panel5.BackColor = Color.FromArgb(144, 224, 239)
    End Sub

    Private Sub Panel5_MouseLeave(sender As Object, e As EventArgs) Handles Panel5.MouseLeave
        Panel5.BackColor = Color.FromArgb(50, 180, 255)
    End Sub

    'Settings Ends


    'Creating object for CliCKRedirects Class
    Dim clickObj As New ClickRedirects


    'Courier Click
    'When user clicks anything inside panel 1, redirect him/her to Courier Page
    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        clickObj.CourierClick()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        clickObj.CourierClick()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        clickObj.CourierClick()
    End Sub

    'Courier Ends





    'Rate Calculator Click
    'When user clicks anything inside panel 1, redirect him/her to Courier Page
    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        clickObj.RateCalculator()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        clickObj.RateCalculator()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        clickObj.RateCalculator()
    End Sub

    'Courier Ends








    'Track Click
    'When user clicks anything inside panel3, redirect him/her to Track Page
    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        clickObj.TrackParcel()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        clickObj.TrackParcel()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        clickObj.TrackParcel()
    End Sub

    'Track Ends



    'Record Click
    'When user clicks anything inside panel 1, redirect him/her to Record Page
    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        clickObj.Records()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        clickObj.Records()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        clickObj.Records()
    End Sub

    'Record Ends





    'Update Status Click
    'When user clicks anything inside panel 1, redirect him/her to Courier Page
    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        clickObj.StatusUpdate()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        clickObj.StatusUpdate()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        clickObj.StatusUpdate()
    End Sub

    'Courier Ends



    'Assign Employee Click
    'When user clicks anything inside panel2, redirect him/her to Assign Employee Page
    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        clickObj.Assign_Emp()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        clickObj.Assign_Emp()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        clickObj.Assign_Emp()
    End Sub

    'Assign Employee Ends









    'Settings Click
    'When user clicks anything inside panel5, redirect him/her to Settings Page
    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        clickObj.LogisticSettings()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        clickObj.LogisticSettings()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        clickObj.LogisticSettings()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.Close()
    End Sub



    'Settings End

End Class


'Class to have functions for clicking several objects within the form
Public Class ClickRedirects

    'Courier Click
    Public Sub CourierClick()
        home.close()
        Courier.Show()
    End Sub

    'Calculator Click
    Public Sub RateCalculator()
        home.Hide()
        calculateRate.Show()
    End Sub


    'Track Parcel Click
    Public Sub TrackParcel()
        home.Hide()
        TrackPar.Show()
    End Sub


    'Records Click
    Public Sub Records()
        home.Hide()
        ParcelRecords.Show()
    End Sub


    'Update Location
    Public Sub StatusUpdate()
        home.Hide()
        updateStatus.Show()
    End Sub


    'Assign Enployee Click
    Public Sub Assign_Emp()
        home.Hide()
        AssignEmp.Show()
    End Sub



    'Settings Click
    Public Sub LogisticSettings()
        home.Hide()
        Profile.Show()
    End Sub
End Class