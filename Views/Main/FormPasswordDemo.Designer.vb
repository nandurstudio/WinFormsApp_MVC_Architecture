<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPasswordDemo
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
		GroupBoxDemo = New GroupBox()
		ButtonCopyEncrypted = New Button()
		LabelVerificationResult = New Label()
		LabelDecryptedResult = New Label()
		TextBoxHash = New TextBox()
		LabelHash = New Label()
		TextBoxEncryptedWithSalt = New TextBox()
		LabelEncryptedWithSalt = New Label()
		TextBoxEncrypted = New TextBox()
		LabelEncrypted = New Label()
		TextBoxUsername = New TextBox()
		LabelUsername = New Label()
		TextBoxPlainPassword = New TextBox()
		LabelPlainPassword = New Label()
		GroupBoxTest = New GroupBox()
		LabelTestDecryptResult = New Label()
		ButtonTestDecrypt = New Button()
		TextBoxTestEncrypted = New TextBox()
		LabelTestEncrypted = New Label()
		LabelTitle = New Label()
		ButtonClose = New Button()
		GroupBoxDemo.SuspendLayout()
		GroupBoxTest.SuspendLayout()
		SuspendLayout()
		' 
		' GroupBoxDemo
		' 
		GroupBoxDemo.Controls.Add(ButtonCopyEncrypted)
		GroupBoxDemo.Controls.Add(LabelVerificationResult)
		GroupBoxDemo.Controls.Add(LabelDecryptedResult)
		GroupBoxDemo.Controls.Add(TextBoxHash)
		GroupBoxDemo.Controls.Add(LabelHash)
		GroupBoxDemo.Controls.Add(TextBoxEncryptedWithSalt)
		GroupBoxDemo.Controls.Add(LabelEncryptedWithSalt)
		GroupBoxDemo.Controls.Add(TextBoxEncrypted)
		GroupBoxDemo.Controls.Add(LabelEncrypted)
		GroupBoxDemo.Controls.Add(TextBoxUsername)
		GroupBoxDemo.Controls.Add(LabelUsername)
		GroupBoxDemo.Controls.Add(TextBoxPlainPassword)
		GroupBoxDemo.Controls.Add(LabelPlainPassword)
		GroupBoxDemo.Location = New Point(12, 50)
		GroupBoxDemo.Name = "GroupBoxDemo"
		GroupBoxDemo.Size = New Size(560, 280)
		GroupBoxDemo.TabIndex = 0
		GroupBoxDemo.TabStop = False
		GroupBoxDemo.Text = "Demo Enkripsi Real-time"
		' 
		' ButtonCopyEncrypted
		' 
		ButtonCopyEncrypted.BackColor = Color.Green
		ButtonCopyEncrypted.ForeColor = Color.White
		ButtonCopyEncrypted.Location = New Point(460, 120)
		ButtonCopyEncrypted.Name = "ButtonCopyEncrypted"
		ButtonCopyEncrypted.Size = New Size(80, 23)
		ButtonCopyEncrypted.TabIndex = 12
		ButtonCopyEncrypted.Text = "Copy"
		ButtonCopyEncrypted.UseVisualStyleBackColor = False
		' 
		' LabelVerificationResult
		' 
		LabelVerificationResult.AutoSize = True
		LabelVerificationResult.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point)
		LabelVerificationResult.Location = New Point(15, 250)
		LabelVerificationResult.Name = "LabelVerificationResult"
		LabelVerificationResult.Size = New Size(89, 19)
		LabelVerificationResult.TabIndex = 11
		LabelVerificationResult.Text = "Verification:"
		' 
		' LabelDecryptedResult
		' 
		LabelDecryptedResult.AutoSize = True
		LabelDecryptedResult.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
		LabelDecryptedResult.ForeColor = Color.Blue
		LabelDecryptedResult.Location = New Point(15, 225)
		LabelDecryptedResult.Name = "LabelDecryptedResult"
		LabelDecryptedResult.Size = New Size(64, 15)
		LabelDecryptedResult.TabIndex = 10
		LabelDecryptedResult.Text = "Decrypted:"
		' 
		' TextBoxHash
		' 
		TextBoxHash.Font = New Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point)
		TextBoxHash.Location = New Point(15, 190)
		TextBoxHash.Multiline = True
		TextBoxHash.Name = "TextBoxHash"
		TextBoxHash.ReadOnly = True
		TextBoxHash.Size = New Size(525, 25)
		TextBoxHash.TabIndex = 9
		' 
		' LabelHash
		' 
		LabelHash.AutoSize = True
		LabelHash.Location = New Point(15, 172)
		LabelHash.Name = "LabelHash"
		LabelHash.Size = New Size(81, 15)
		LabelHash.TabIndex = 8
		LabelHash.Text = "SHA256 Hash:"
		' 
		' TextBoxEncryptedWithSalt
		' 
		TextBoxEncryptedWithSalt.Font = New Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point)
		TextBoxEncryptedWithSalt.Location = New Point(15, 120)
		TextBoxEncryptedWithSalt.Multiline = True
		TextBoxEncryptedWithSalt.Name = "TextBoxEncryptedWithSalt"
		TextBoxEncryptedWithSalt.ReadOnly = True
		TextBoxEncryptedWithSalt.Size = New Size(440, 40)
		TextBoxEncryptedWithSalt.TabIndex = 7
		' 
		' LabelEncryptedWithSalt
		' 
		LabelEncryptedWithSalt.AutoSize = True
		LabelEncryptedWithSalt.Location = New Point(15, 102)
		LabelEncryptedWithSalt.Name = "LabelEncryptedWithSalt"
		LabelEncryptedWithSalt.Size = New Size(142, 15)
		LabelEncryptedWithSalt.TabIndex = 6
		LabelEncryptedWithSalt.Text = "AES Encrypted (with Salt):"
		' 
		' TextBoxEncrypted
		' 
		TextBoxEncrypted.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point)
		TextBoxEncrypted.Location = New Point(280, 60)
		TextBoxEncrypted.Name = "TextBoxEncrypted"
		TextBoxEncrypted.ReadOnly = True
		TextBoxEncrypted.Size = New Size(260, 22)
		TextBoxEncrypted.TabIndex = 5
		' 
		' LabelEncrypted
		' 
		LabelEncrypted.AutoSize = True
		LabelEncrypted.Location = New Point(280, 42)
		LabelEncrypted.Name = "LabelEncrypted"
		LabelEncrypted.Size = New Size(86, 15)
		LabelEncrypted.TabIndex = 4
		LabelEncrypted.Text = "AES Encrypted:"
		' 
		' TextBoxUsername
		' 
		TextBoxUsername.Location = New Point(150, 60)
		TextBoxUsername.Name = "TextBoxUsername"
		TextBoxUsername.Size = New Size(120, 23)
		TextBoxUsername.TabIndex = 3
		' 
		' LabelUsername
		' 
		LabelUsername.AutoSize = True
		LabelUsername.Location = New Point(150, 42)
		LabelUsername.Name = "LabelUsername"
		LabelUsername.Size = New Size(63, 15)
		LabelUsername.TabIndex = 2
		LabelUsername.Text = "Username:"
		' 
		' TextBoxPlainPassword
		' 
		TextBoxPlainPassword.Location = New Point(15, 60)
		TextBoxPlainPassword.Name = "TextBoxPlainPassword"
		TextBoxPlainPassword.Size = New Size(120, 23)
		TextBoxPlainPassword.TabIndex = 1
		' 
		' LabelPlainPassword
		' 
		LabelPlainPassword.AutoSize = True
		LabelPlainPassword.Location = New Point(15, 42)
		LabelPlainPassword.Name = "LabelPlainPassword"
		LabelPlainPassword.Size = New Size(89, 15)
		LabelPlainPassword.TabIndex = 0
		LabelPlainPassword.Text = "Plain Password:"
		' 
		' GroupBoxTest
		' 
		GroupBoxTest.Controls.Add(LabelTestDecryptResult)
		GroupBoxTest.Controls.Add(ButtonTestDecrypt)
		GroupBoxTest.Controls.Add(TextBoxTestEncrypted)
		GroupBoxTest.Controls.Add(LabelTestEncrypted)
		GroupBoxTest.Location = New Point(12, 340)
		GroupBoxTest.Name = "GroupBoxTest"
		GroupBoxTest.Size = New Size(560, 100)
		GroupBoxTest.TabIndex = 1
		GroupBoxTest.TabStop = False
		GroupBoxTest.Text = "Test Dekripsi"
		' 
		' LabelTestDecryptResult
		' 
		LabelTestDecryptResult.AutoSize = True
		LabelTestDecryptResult.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
		LabelTestDecryptResult.Location = New Point(15, 70)
		LabelTestDecryptResult.Name = "LabelTestDecryptResult"
		LabelTestDecryptResult.Size = New Size(45, 15)
		LabelTestDecryptResult.TabIndex = 3
		LabelTestDecryptResult.Text = "Result:"
		' 
		' ButtonTestDecrypt
		' 
		ButtonTestDecrypt.BackColor = Color.Orange
		ButtonTestDecrypt.ForeColor = Color.White
		ButtonTestDecrypt.Location = New Point(460, 40)
		ButtonTestDecrypt.Name = "ButtonTestDecrypt"
		ButtonTestDecrypt.Size = New Size(80, 23)
		ButtonTestDecrypt.TabIndex = 2
		ButtonTestDecrypt.Text = "Decrypt"
		ButtonTestDecrypt.UseVisualStyleBackColor = False
		' 
		' TextBoxTestEncrypted
		' 
		TextBoxTestEncrypted.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point)
		TextBoxTestEncrypted.Location = New Point(15, 40)
		TextBoxTestEncrypted.Name = "TextBoxTestEncrypted"
		TextBoxTestEncrypted.Size = New Size(440, 22)
		TextBoxTestEncrypted.TabIndex = 1
		' 
		' LabelTestEncrypted
		' 
		LabelTestEncrypted.AutoSize = True
		LabelTestEncrypted.Location = New Point(15, 22)
		LabelTestEncrypted.Name = "LabelTestEncrypted"
		LabelTestEncrypted.Size = New Size(185, 15)
		LabelTestEncrypted.TabIndex = 0
		LabelTestEncrypted.Text = "Paste Encrypted Password to Test:"
		' 
		' LabelTitle
		' 
		LabelTitle.BackColor = Color.DarkSlateGray
		LabelTitle.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point)
		LabelTitle.ForeColor = Color.White
		LabelTitle.Location = New Point(12, 9)
		LabelTitle.Name = "LabelTitle"
		LabelTitle.Size = New Size(560, 35)
		LabelTitle.TabIndex = 2
		LabelTitle.Text = "DEMO ENKRIPSI PASSWORD - AES + SALT"
		LabelTitle.TextAlign = ContentAlignment.MiddleCenter
		' 
		' ButtonClose
		' 
		ButtonClose.BackColor = Color.Tomato
		ButtonClose.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point)
		ButtonClose.ForeColor = Color.White
		ButtonClose.Location = New Point(497, 450)
		ButtonClose.Name = "ButtonClose"
		ButtonClose.Size = New Size(75, 30)
		ButtonClose.TabIndex = 3
		ButtonClose.Text = "CLOSE"
		ButtonClose.UseVisualStyleBackColor = False
		' 
		' FormPasswordDemo
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(584, 491)
		Controls.Add(ButtonClose)
		Controls.Add(LabelTitle)
		Controls.Add(GroupBoxTest)
		Controls.Add(GroupBoxDemo)
		FormBorderStyle = FormBorderStyle.FixedDialog
		MaximizeBox = False
		MinimizeBox = False
		Name = "FormPasswordDemo"
		StartPosition = FormStartPosition.CenterParent
		Text = "Password Encryption Demo"
		GroupBoxDemo.ResumeLayout(False)
		GroupBoxDemo.PerformLayout()
		GroupBoxTest.ResumeLayout(False)
		GroupBoxTest.PerformLayout()
		ResumeLayout(False)
	End Sub

	Friend WithEvents GroupBoxDemo As GroupBox
    Friend WithEvents LabelPlainPassword As Label
    Friend WithEvents TextBoxPlainPassword As TextBox
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents LabelUsername As Label
    Friend WithEvents TextBoxEncrypted As TextBox
    Friend WithEvents LabelEncrypted As Label
    Friend WithEvents TextBoxEncryptedWithSalt As TextBox
    Friend WithEvents LabelEncryptedWithSalt As Label
    Friend WithEvents TextBoxHash As TextBox
    Friend WithEvents LabelHash As Label
    Friend WithEvents LabelDecryptedResult As Label
    Friend WithEvents LabelVerificationResult As Label
    Friend WithEvents ButtonCopyEncrypted As Button
    Friend WithEvents GroupBoxTest As GroupBox
    Friend WithEvents TextBoxTestEncrypted As TextBox
    Friend WithEvents LabelTestEncrypted As Label
    Friend WithEvents ButtonTestDecrypt As Button
    Friend WithEvents LabelTestDecryptResult As Label
    Friend WithEvents LabelTitle As Label
    Friend WithEvents ButtonClose As Button
End Class