Imports System.Windows.Forms

Public Class CustomMessageDialog
   Inherits Form

   Private lblMessage As Label
   Private btnOption1 As Button
   Private btnOption2 As Button
   Private btnOption3 As Button
   Private result As DialogResult = DialogResult.Cancel

   Public Shared Function Show3Options(message As String, title As String, option1Text As String, option2Text As String, option3Text As String) As DialogResult
      Using dialog As New CustomMessageDialog()
         dialog.Text = title
         dialog.lblMessage.Text = message
         dialog.btnOption1.Text = option1Text
         dialog.btnOption2.Text = option2Text
         dialog.btnOption3.Text = option3Text
         dialog.ShowDialog()
         Return dialog.result
      End Using
   End Function

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub InitializeComponent()
      Me.FormBorderStyle = FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.StartPosition = FormStartPosition.CenterParent
      Me.Size = New Size(500, 220)
      Me.BackColor = Color.White

      ' Icon panel (optional, for visual appeal)
      Dim iconPanel As New Panel With {
            .Location = New Point(20, 20),
            .Size = New Size(60, 60),
            .BackColor = Color.FromArgb(46, 125, 50)
        }

      ' Icon label (checkmark without emoji)
      Dim iconLabel As New Label With {
            .Text = "OK",
            .Font = New Font("Segoe UI", 20, FontStyle.Bold),
            .ForeColor = Color.White,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Dock = DockStyle.Fill
        }
      iconPanel.Controls.Add(iconLabel)

      ' Message label
      lblMessage = New Label With {
            .Location = New Point(100, 20),
            .Size = New Size(370, 80),
            .Font = New Font("Segoe UI", 10),
            .ForeColor = Color.FromArgb(60, 60, 60),
            .AutoSize = False
        }

      ' Button panel
      Dim buttonPanel As New Panel With {
            .Location = New Point(20, 120),
            .Size = New Size(460, 50),
            .BackColor = Color.Transparent
        }

      ' Button 1
      btnOption1 = New Button With {
            .Size = New Size(140, 40),
            .Location = New Point(0, 5),
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = Color.FromArgb(46, 125, 50),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand
        }
      btnOption1.FlatAppearance.BorderSize = 0
      AddHandler btnOption1.Click, Sub()
                                      result = DialogResult.Yes
                                      Me.Close()
                                   End Sub

      ' Button 2
      btnOption2 = New Button With {
            .Size = New Size(140, 40),
            .Location = New Point(160, 5),
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = Color.FromArgb(33, 150, 243),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand
        }
      btnOption2.FlatAppearance.BorderSize = 0
      AddHandler btnOption2.Click, Sub()
                                      result = DialogResult.No
                                      Me.Close()
                                   End Sub

      ' Button 3
      btnOption3 = New Button With {
            .Size = New Size(140, 40),
            .Location = New Point(320, 5),
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = Color.FromArgb(158, 158, 158),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand
        }
      btnOption3.FlatAppearance.BorderSize = 0
      AddHandler btnOption3.Click, Sub()
                                      result = DialogResult.Cancel
                                      Me.Close()
                                   End Sub

      ' Add hover effects
      AddHandler btnOption1.MouseEnter, Sub() btnOption1.BackColor = Color.FromArgb(56, 142, 60)
      AddHandler btnOption1.MouseLeave, Sub() btnOption1.BackColor = Color.FromArgb(46, 125, 50)

      AddHandler btnOption2.MouseEnter, Sub() btnOption2.BackColor = Color.FromArgb(43, 160, 253)
      AddHandler btnOption2.MouseLeave, Sub() btnOption2.BackColor = Color.FromArgb(33, 150, 243)

      AddHandler btnOption3.MouseEnter, Sub() btnOption3.BackColor = Color.FromArgb(178, 178, 178)
      AddHandler btnOption3.MouseLeave, Sub() btnOption3.BackColor = Color.FromArgb(158, 158, 158)

      buttonPanel.Controls.AddRange({btnOption1, btnOption2, btnOption3})

      Me.Controls.AddRange({iconPanel, lblMessage, buttonPanel})
   End Sub
End Class
