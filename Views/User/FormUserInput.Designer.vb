<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUserInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Label1 = New Label()
        Label2 = New Label()
        txtUsername = New TextBox()
        Label3 = New Label()
        txtEmail = New TextBox()
        Label4 = New Label()
        txtPassword = New TextBox()
        Label5 = New Label()
        txtConfirmPassword = New TextBox()
        Label6 = New Label()
        cboRole = New ComboBox()
        btnSave = New Button()
        btnCancel = New Button()
        chkShowPassword = New CheckBox()
        lblPasswordNote = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(14, 24)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(470, 27)
        Label1.TabIndex = 0
        Label1.Text = "Add/Update User"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(37, 70)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(71, 15)
        Label2.TabIndex = 1
        Label2.Text = "Username"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtUsername.Location = New Point(37, 95)
        txtUsername.Margin = New Padding(4, 3, 4, 3)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(410, 23)
        txtUsername.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(37, 130)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(41, 15)
        Label3.TabIndex = 3
        Label3.Text = "Email"
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmail.Location = New Point(37, 155)
        txtEmail.Margin = New Padding(4, 3, 4, 3)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(410, 23)
        txtEmail.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(37, 190)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(69, 15)
        Label4.TabIndex = 5
        Label4.Text = "Password"
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtPassword.Location = New Point(37, 215)
        txtPassword.Margin = New Padding(4, 3, 4, 3)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(410, 23)
        txtPassword.TabIndex = 6
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(37, 250)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(126, 15)
        Label5.TabIndex = 7
        Label5.Text = "Confirm Password"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtConfirmPassword.Location = New Point(37, 275)
        txtConfirmPassword.Margin = New Padding(4, 3, 4, 3)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(410, 23)
        txtConfirmPassword.TabIndex = 8
        txtConfirmPassword.UseSystemPasswordChar = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(37, 310)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(36, 15)
        Label6.TabIndex = 9
        Label6.Text = "Role"
        ' 
        ' cboRole
        ' 
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        cboRole.FormattingEnabled = True
        cboRole.Items.AddRange(New Object() {"user", "admin"})
        cboRole.Location = New Point(37, 335)
        cboRole.Margin = New Padding(4, 3, 4, 3)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(200, 24)
        cboRole.TabIndex = 10
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
        btnSave.Location = New Point(273, 432)
        btnSave.Margin = New Padding(4, 3, 4, 3)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(88, 31)
        btnSave.TabIndex = 11
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
        btnCancel.Location = New Point(369, 432)
        btnCancel.Margin = New Padding(4, 3, 4, 3)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(88, 31)
        btnCancel.TabIndex = 12
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        chkShowPassword.Location = New Point(37, 375)
        chkShowPassword.Margin = New Padding(4, 3, 4, 3)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(109, 17)
        chkShowPassword.TabIndex = 13
        chkShowPassword.Text = "Show Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' lblPasswordNote
        ' 
        lblPasswordNote.Font = New Font("Microsoft Sans Serif", 7.5F, FontStyle.Italic, GraphicsUnit.Point)
        lblPasswordNote.ForeColor = Color.Gray
        lblPasswordNote.Location = New Point(37, 399)
        lblPasswordNote.Margin = New Padding(4, 0, 4, 0)
        lblPasswordNote.Name = "lblPasswordNote"
        lblPasswordNote.Size = New Size(410, 25)
        lblPasswordNote.TabIndex = 14
        lblPasswordNote.Text = "Kosongkan password jika tidak ingin mengubah"
        lblPasswordNote.Visible = False
        ' 
        ' FormUserInput
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(484, 481)
        Controls.Add(lblPasswordNote)
        Controls.Add(chkShowPassword)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(cboRole)
        Controls.Add(Label6)
        Controls.Add(txtConfirmPassword)
        Controls.Add(Label5)
        Controls.Add(txtPassword)
        Controls.Add(Label4)
        Controls.Add(txtEmail)
        Controls.Add(Label3)
        Controls.Add(txtUsername)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FormUserInput"
        StartPosition = FormStartPosition.CenterParent
        Text = "Add - Edit User Form"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboRole As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents lblPasswordNote As System.Windows.Forms.Label
End Class
