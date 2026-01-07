<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUtama
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      PanelBottom = New Panel()
      LabelWelcome = New Label()
      LabelUserStatus = New Label()
      ButtonLogin = New Button()
      ButtonSettings = New Button()
      PanelBottom.SuspendLayout()
      SuspendLayout()
      ' 
      ' PanelBottom
      ' 
      PanelBottom.BackColor = Color.FromArgb(45, 45, 48)
      PanelBottom.Controls.Add(LabelWelcome)
      PanelBottom.Controls.Add(LabelUserStatus)
      PanelBottom.Controls.Add(ButtonSettings)
      PanelBottom.Controls.Add(ButtonLogin)
      PanelBottom.Dock = DockStyle.Bottom
      PanelBottom.Location = New Point(0, 400)
      PanelBottom.Name = "PanelBottom"
      PanelBottom.Size = New Size(800, 50)
      PanelBottom.TabIndex = 0
      ' 
      ' LabelWelcome
      ' 
      LabelWelcome.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      LabelWelcome.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
      LabelWelcome.ForeColor = Color.White
      LabelWelcome.Location = New Point(230, 5)
      LabelWelcome.Name = "LabelWelcome"
      LabelWelcome.Size = New Size(560, 20)
      LabelWelcome.TabIndex = 3
      LabelWelcome.Text = "Selamat datang di Aplikasi Penjualan!"
      LabelWelcome.TextAlign = ContentAlignment.MiddleRight
      ' 
      ' LabelUserStatus
      ' 
      LabelUserStatus.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      LabelUserStatus.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
      LabelUserStatus.ForeColor = Color.LightGray
      LabelUserStatus.Location = New Point(230, 25)
      LabelUserStatus.Name = "LabelUserStatus"
      LabelUserStatus.Size = New Size(560, 20)
      LabelUserStatus.TabIndex = 2
      LabelUserStatus.Text = "Status: Not logged in"
      LabelUserStatus.TextAlign = ContentAlignment.MiddleRight
      ' 
      ' ButtonLogin
      ' 
      ButtonLogin.BackColor = Color.ForestGreen
      ButtonLogin.Cursor = Cursors.Hand
      ButtonLogin.FlatStyle = FlatStyle.Flat
      ButtonLogin.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
      ButtonLogin.ForeColor = Color.White
      ButtonLogin.Location = New Point(10, 10)
      ButtonLogin.Name = "ButtonLogin"
      ButtonLogin.Size = New Size(100, 30)
      ButtonLogin.TabIndex = 0
      ButtonLogin.Text = "LOGIN"
      ButtonLogin.UseVisualStyleBackColor = False
      ' 
      ' ButtonSettings
      ' 
      ButtonSettings.BackColor = Color.Orange
      ButtonSettings.Cursor = Cursors.Hand
      ButtonSettings.FlatStyle = FlatStyle.Flat
      ButtonSettings.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
      ButtonSettings.ForeColor = Color.White
      ButtonSettings.Location = New Point(120, 10)
      ButtonSettings.Name = "ButtonSettings"
      ButtonSettings.Size = New Size(100, 30)
      ButtonSettings.TabIndex = 1
      ButtonSettings.Text = "SETTINGS"
      ButtonSettings.UseVisualStyleBackColor = False
      ButtonSettings.Visible = False
      ' 
      ' FormUtama
      ' 
      AutoScaleDimensions = New SizeF(7.0F, 15.0F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(800, 450)
      Controls.Add(PanelBottom)
      IsMdiContainer = True
      mainMenuStrip = Nothing
      Name = "FormUtama"
      StartPosition = FormStartPosition.CenterScreen
      Text = "Form Utama - Aplikasi Penjualan"
      WindowState = FormWindowState.Maximized
      PanelBottom.ResumeLayout(False)
      ResumeLayout(False)
   End Sub

   Friend WithEvents PanelBottom As Panel
   Friend WithEvents LabelWelcome As Label
   Friend WithEvents LabelUserStatus As Label
   Friend WithEvents ButtonLogin As Button
   Friend WithEvents ButtonSettings As Button
End Class