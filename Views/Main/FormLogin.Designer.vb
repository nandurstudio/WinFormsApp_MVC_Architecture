<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
		LabelUserLogin = New Label()
		PictureBox1 = New PictureBox()
		LabelUserName = New Label()
		LabelPassword = New Label()
		TextBoxUserName = New TextBox()
		TextBoxPassword = New TextBox()
		CheckBoxShowPassword = New CheckBox()
		ButtonLogin = New Button()
		ButtonCancel = New Button()
		ButtonSetting = New Button()
		LabelCopyRight = New Label()
		CheckBoxRememberMe = New CheckBox()
		ButtonAbout = New Button()
		LabelAppSubtitle = New Label()
		CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' LabelUserLogin
		' 
		LabelUserLogin.BackColor = Color.FromArgb(CByte(46), CByte(125), CByte(50))
		LabelUserLogin.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold, GraphicsUnit.Point)
		LabelUserLogin.ForeColor = SystemColors.ControlLight
		LabelUserLogin.Location = New Point(12, 9)
		LabelUserLogin.Name = "LabelUserLogin"
		LabelUserLogin.Size = New Size(396, 50)
		LabelUserLogin.TabIndex = 0
		LabelUserLogin.Text = "SALES MANAGEMENT"
		LabelUserLogin.TextAlign = ContentAlignment.MiddleCenter
		' 
		' PictureBox1
		' 
		PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
		PictureBox1.Location = New Point(12, 102)
		PictureBox1.Name = "PictureBox1"
		PictureBox1.Size = New Size(150, 145)
		PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
		PictureBox1.TabIndex = 1
		PictureBox1.TabStop = False
		' 
		' LabelUserName
		' 
		LabelUserName.AutoSize = True
		LabelUserName.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
		LabelUserName.Location = New Point(168, 102)
		LabelUserName.Name = "LabelUserName"
		LabelUserName.Size = New Size(76, 19)
		LabelUserName.TabIndex = 2
		LabelUserName.Text = "Username"
		LabelUserName.TextAlign = ContentAlignment.MiddleRight
		' 
		' LabelPassword
		' 
		LabelPassword.AutoSize = True
		LabelPassword.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
		LabelPassword.Location = New Point(168, 156)
		LabelPassword.Name = "LabelPassword"
		LabelPassword.Size = New Size(73, 19)
		LabelPassword.TabIndex = 3
		LabelPassword.Text = "Password"
		LabelPassword.TextAlign = ContentAlignment.MiddleRight
		' 
		' TextBoxUserName
		' 
		TextBoxUserName.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
		TextBoxUserName.Location = New Point(168, 124)
		TextBoxUserName.Name = "TextBoxUserName"
		TextBoxUserName.Size = New Size(240, 25)
		TextBoxUserName.TabIndex = 4
		' 
		' TextBoxPassword
		' 
		TextBoxPassword.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
		TextBoxPassword.Location = New Point(168, 178)
		TextBoxPassword.Name = "TextBoxPassword"
		TextBoxPassword.PasswordChar = "*"c
		TextBoxPassword.Size = New Size(240, 25)
		TextBoxPassword.TabIndex = 5
		' 
		' CheckBoxShowPassword
		' 
		CheckBoxShowPassword.AutoSize = True
		CheckBoxShowPassword.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
		CheckBoxShowPassword.Location = New Point(168, 209)
		CheckBoxShowPassword.Name = "CheckBoxShowPassword"
		CheckBoxShowPassword.Size = New Size(108, 19)
		CheckBoxShowPassword.TabIndex = 6
		CheckBoxShowPassword.Text = "Show Password"
		CheckBoxShowPassword.UseVisualStyleBackColor = True
		' 
		' ButtonLogin
		' 
		ButtonLogin.BackColor = Color.FromArgb(CByte(46), CByte(125), CByte(50))
		ButtonLogin.Cursor = Cursors.Hand
		ButtonLogin.FlatStyle = FlatStyle.Flat
		ButtonLogin.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
		ButtonLogin.ForeColor = SystemColors.ControlLight
		ButtonLogin.Location = New Point(230, 260)
		ButtonLogin.Name = "ButtonLogin"
		ButtonLogin.Size = New Size(85, 36)
		ButtonLogin.TabIndex = 8
		ButtonLogin.Text = "LOGIN"
		ButtonLogin.UseVisualStyleBackColor = False
		' 
		' ButtonCancel
		' 
		ButtonCancel.BackColor = Color.FromArgb(CByte(198), CByte(40), CByte(40))
		ButtonCancel.Cursor = Cursors.Hand
		ButtonCancel.FlatStyle = FlatStyle.Flat
		ButtonCancel.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
		ButtonCancel.ForeColor = SystemColors.ControlLight
		ButtonCancel.Location = New Point(323, 260)
		ButtonCancel.Name = "ButtonCancel"
		ButtonCancel.Size = New Size(85, 36)
		ButtonCancel.TabIndex = 9
		ButtonCancel.Text = "CANCEL"
		ButtonCancel.UseVisualStyleBackColor = False
		' 
		' ButtonSetting
		' 
		ButtonSetting.BackColor = Color.FromArgb(CByte(69), CByte(90), CByte(100))
		ButtonSetting.Cursor = Cursors.Hand
		ButtonSetting.FlatStyle = FlatStyle.Flat
		ButtonSetting.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
		ButtonSetting.ForeColor = SystemColors.ControlLight
		ButtonSetting.Location = New Point(87, 260)
		ButtonSetting.Name = "ButtonSetting"
		ButtonSetting.Size = New Size(70, 36)
		ButtonSetting.TabIndex = 11
		ButtonSetting.Text = "SETTING"
		ButtonSetting.UseVisualStyleBackColor = False
		ButtonSetting.Visible = False
		' 
		' LabelCopyRight
		' 
		LabelCopyRight.AutoSize = True
		LabelCopyRight.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
		LabelCopyRight.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		LabelCopyRight.Location = New Point(12, 310)
		LabelCopyRight.Name = "LabelCopyRight"
		LabelCopyRight.Size = New Size(155, 13)
		LabelCopyRight.TabIndex = 10
		LabelCopyRight.Text = "© 2025 Nandang Duryat v1.0"
		' 
		' CheckBoxRememberMe
		' 
		CheckBoxRememberMe.AutoSize = True
		CheckBoxRememberMe.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
		CheckBoxRememberMe.Location = New Point(168, 234)
		CheckBoxRememberMe.Name = "CheckBoxRememberMe"
		CheckBoxRememberMe.Size = New Size(110, 19)
		CheckBoxRememberMe.TabIndex = 7
		CheckBoxRememberMe.Text = "Remember Me"
		CheckBoxRememberMe.UseVisualStyleBackColor = True
		' 
		' ButtonAbout
		' 
		ButtonAbout.BackColor = Color.FromArgb(CByte(66), CByte(66), CByte(66))
		ButtonAbout.Cursor = Cursors.Hand
		ButtonAbout.FlatStyle = FlatStyle.Flat
		ButtonAbout.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
		ButtonAbout.ForeColor = SystemColors.ControlLight
		ButtonAbout.Location = New Point(12, 260)
		ButtonAbout.Name = "ButtonAbout"
		ButtonAbout.Size = New Size(70, 36)
		ButtonAbout.TabIndex = 12
		ButtonAbout.Text = "ABOUT"
		ButtonAbout.UseVisualStyleBackColor = False
		' 
		' LabelAppSubtitle
		' 
		LabelAppSubtitle.BackColor = Color.FromArgb(CByte(46), CByte(125), CByte(50))
		LabelAppSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
		LabelAppSubtitle.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
		LabelAppSubtitle.Location = New Point(12, 59)
		LabelAppSubtitle.Name = "LabelAppSubtitle"
		LabelAppSubtitle.Size = New Size(396, 25)
		LabelAppSubtitle.TabIndex = 13
		LabelAppSubtitle.Text = "Inventory && Transaction System"
		LabelAppSubtitle.TextAlign = ContentAlignment.MiddleCenter
		' 
		' FormLogin
		' 
		AutoScaleDimensions = New SizeF(7.0F, 15.0F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.WhiteSmoke
		ClientSize = New Size(421, 335)
		Controls.Add(LabelAppSubtitle)
		Controls.Add(ButtonAbout)
		Controls.Add(CheckBoxRememberMe)
		Controls.Add(ButtonSetting)
		Controls.Add(LabelCopyRight)
		Controls.Add(ButtonCancel)
		Controls.Add(ButtonLogin)
		Controls.Add(CheckBoxShowPassword)
		Controls.Add(TextBoxPassword)
		Controls.Add(TextBoxUserName)
		Controls.Add(LabelPassword)
		Controls.Add(LabelUserName)
		Controls.Add(PictureBox1)
		Controls.Add(LabelUserLogin)
		MaximizeBox = False
		MinimizeBox = False
		Name = "FormLogin"
		StartPosition = FormStartPosition.CenterScreen
		Text = "Login - Sales Management System"
		CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents LabelUserLogin As Label
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents LabelUserName As Label
	Friend WithEvents LabelPassword As Label
	Friend WithEvents TextBoxUserName As TextBox
	Friend WithEvents TextBoxPassword As TextBox
	Friend WithEvents CheckBoxShowPassword As CheckBox
	Friend WithEvents ButtonLogin As Button
	Friend WithEvents ButtonCancel As Button
	Friend WithEvents LabelCopyRight As Label
	Friend WithEvents ButtonSetting As Button
	Friend WithEvents CheckBoxRememberMe As CheckBox
	Friend WithEvents ButtonAbout As Button
	Friend WithEvents LabelAppSubtitle As Label

End Class
