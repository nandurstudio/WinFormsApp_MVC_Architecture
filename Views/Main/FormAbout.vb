' ============================================================
' Form About - Informasi Aplikasi
' ============================================================
Imports WinFormsApp_Latihan.Models

Public Class FormAbout
   Private Sub FormAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      ' Set form properties
      Me.FormBorderStyle = FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.StartPosition = FormStartPosition.CenterParent
      Me.BackColor = Color.White
      Me.Text = $"About {AppInfo.AppName}"
      Me.ClientSize = New Size(520, 480)

      ' Create main panel with gradient background
      Dim mainPanel As New Panel With {
         .Dock = DockStyle.Fill,
         .BackColor = Color.White
      }

      ' Header Panel
      Dim headerPanel As New Panel With {
         .Dock = DockStyle.Top,
         .Height = 90,
         .BackColor = Color.FromArgb(25, 118, 210)
      }

      ' Application Title
      Dim lblAppTitle As New Label With {
         .Text = AppInfo.AppFullName,
         .Font = New Font("Segoe UI", 16, FontStyle.Bold),
         .ForeColor = Color.White,
         .AutoSize = False,
         .Size = New Size(480, 35),
         .Location = New Point(20, 20),
         .TextAlign = ContentAlignment.MiddleLeft
      }

      ' Version subtitle
      Dim lblVersion As New Label With {
         .Text = $"Version {AppInfo.AppVersion}",
         .Font = New Font("Segoe UI", 10),
         .ForeColor = Color.FromArgb(200, 230, 255),
         .AutoSize = True,
         .Location = New Point(20, 55)
      }

      headerPanel.Controls.AddRange({lblAppTitle, lblVersion})

      ' Content Panel
      Dim contentPanel As New Panel With {
         .Dock = DockStyle.Fill,
         .Padding = New Padding(20, 15, 20, 15),
         .BackColor = Color.White,
         .AutoScroll = True
      }

      ' Description
      Dim lblDescription As New Label With {
         .Text = AppInfo.AppDescription,
         .Font = New Font("Segoe UI", 9.5F),
         .ForeColor = Color.FromArgb(60, 60, 60),
         .AutoSize = False,
         .Size = New Size(460, 50),
         .Location = New Point(20, 10)
      }

      ' Separator Line 1
      Dim separator1 As New Panel With {
         .BackColor = Color.FromArgb(200, 200, 200),
         .Height = 1,
         .Width = 460,
         .Location = New Point(20, 70)
      }

      ' Developer Info Label
      Dim lblDevInfo As New Label With {
         .Text = "DEVELOPER INFORMATION",
         .Font = New Font("Segoe UI", 10, FontStyle.Bold),
         .ForeColor = Color.FromArgb(25, 118, 210),
         .AutoSize = True,
         .Location = New Point(20, 85)
      }

      ' Developer Details Panel
      Dim devPanel As New Panel With {
         .Location = New Point(20, 115),
         .Size = New Size(460, 150),
         .BackColor = Color.FromArgb(245, 248, 252),
         .Padding = New Padding(15),
         .BorderStyle = BorderStyle.FixedSingle
      }

      ' Create info labels using AppInfo
      Dim yPos As Integer = 10
      Dim infoLabels As New List(Of String()) From {
         New String() {"Developer", AppInfo.DeveloperName},
         New String() {"Student ID", AppInfo.DeveloperNIM},
         New String() {"Class", AppInfo.DeveloperClass},
         New String() {"University", AppInfo.University},
         New String() {"Course", AppInfo.Course},
         New String() {"Lecturer", AppInfo.Lecturer}
      }

      For Each info In infoLabels
         Dim lblKey As New Label With {
            .Text = info(0) & ":",
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .ForeColor = Color.FromArgb(80, 80, 80),
            .AutoSize = True,
            .Location = New Point(15, yPos)
         }

         Dim lblValue As New Label With {
            .Text = info(1),
            .Font = New Font("Segoe UI", 9),
            .ForeColor = Color.FromArgb(60, 60, 60),
            .AutoSize = False,
            .Size = New Size(300, 20),
            .Location = New Point(130, yPos)
         }

         devPanel.Controls.Add(lblKey)
         devPanel.Controls.Add(lblValue)
         yPos += 23
      Next

      ' Separator Line 2
      Dim separator2 As New Panel With {
         .BackColor = Color.FromArgb(200, 200, 200),
         .Height = 1,
         .Width = 460,
         .Location = New Point(20, 275)
      }

      ' Features Label
      Dim lblFeatures As New Label With {
         .Text = "Key Features: Inventory Management, Sales & Purchase Transactions, Advanced Reporting, User Management",
         .Font = New Font("Segoe UI", 8.5F),
         .ForeColor = Color.FromArgb(100, 100, 100),
         .AutoSize = False,
         .Size = New Size(460, 30),
         .Location = New Point(20, 285)
      }

      ' Copyright Label
      Dim lblCopyright As New Label With {
         .Text = AppInfo.Copyright,
         .Font = New Font("Segoe UI", 9, FontStyle.Bold),
         .ForeColor = Color.FromArgb(25, 118, 210),
         .AutoSize = True,
         .Location = New Point(20, 325)
      }

      ' Close Button
      Dim btnClose As New Button With {
         .Text = "Close",
         .Font = New Font("Segoe UI", 10, FontStyle.Bold),
         .Size = New Size(120, 38),
         .Location = New Point(360, 350),
         .BackColor = Color.FromArgb(25, 118, 210),
         .ForeColor = Color.White,
         .FlatStyle = FlatStyle.Flat,
         .Cursor = Cursors.Hand
      }
      btnClose.FlatAppearance.BorderSize = 0
      AddHandler btnClose.Click, Sub() Me.Close()

      ' Add hover effect
      AddHandler btnClose.MouseEnter, Sub(s, ev)
                                         btnClose.BackColor = Color.FromArgb(30, 136, 229)
                                      End Sub
      AddHandler btnClose.MouseLeave, Sub(s, ev)
                                         btnClose.BackColor = Color.FromArgb(25, 118, 210)
                                      End Sub

      ' Add all controls to content panel
      contentPanel.Controls.AddRange({lblDescription, separator1, lblDevInfo, devPanel, separator2, lblFeatures, lblCopyright, btnClose})

      ' Add panels to main panel
      mainPanel.Controls.Add(contentPanel)
      mainPanel.Controls.Add(headerPanel)

      ' Add main panel to form
      Me.Controls.Add(mainPanel)
   End Sub
End Class
