<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSetting
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
      Me.LabelTitle = New Label()
      Me.TabControlSettings = New TabControl()
      Me.TabPageDatabase = New TabPage()
      Me.GroupBoxDatabase = New GroupBox()
      Me.ButtonPasswordDemo = New Button()
      Me.ButtonTest = New Button()
      Me.TextBoxPort = New TextBox()
      Me.TextBoxPassword = New TextBox()
      Me.TextBoxUserId = New TextBox()
      Me.TextBoxDatabase = New TextBox()
      Me.TextBoxServer = New TextBox()
      Me.LabelPort = New Label()
      Me.LabelPassword = New Label()
      Me.LabelUserId = New Label()
      Me.LabelDatabase = New Label()
      Me.LabelServer = New Label()
      Me.TabPageAppSettings = New TabPage()
      Me.GroupBoxFormat = New GroupBox()
      Me.ComboBoxCulture = New ComboBox()
      Me.LabelCulture = New Label()
      Me.TextBoxDateFormat = New TextBox()
      Me.LabelDateFormat = New Label()
      Me.TextBoxCurrencySymbol = New TextBox()
      Me.LabelCurrencySymbol = New Label()
      Me.GroupBoxPrint = New GroupBox()
      Me.ComboBoxOrientation = New ComboBox()
      Me.LabelOrientation = New Label()
      Me.NumericPrintFontSize = New NumericUpDown()
      Me.LabelPrintFontSize = New Label()
      Me.CheckBoxAlternatingRows = New CheckBox()
      Me.GroupBoxUI = New GroupBox()
      Me.CheckBoxAutoLoadReport = New CheckBox()
      Me.CheckBoxConfirmDelete = New CheckBox()
      Me.ButtonResetDefaults = New Button()
      Me.ButtonSave = New Button()
      Me.ButtonCancel = New Button()
      Me.TabControlSettings.SuspendLayout()
      Me.TabPageDatabase.SuspendLayout()
      Me.GroupBoxDatabase.SuspendLayout()
      Me.TabPageAppSettings.SuspendLayout()
      Me.GroupBoxFormat.SuspendLayout()
      Me.GroupBoxPrint.SuspendLayout()
      CType(Me.NumericPrintFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBoxUI.SuspendLayout()
      Me.SuspendLayout()

      ' LabelTitle
      Me.LabelTitle.BackColor = Color.FromArgb(25, 118, 210)
      Me.LabelTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
      Me.LabelTitle.ForeColor = Color.White
      Me.LabelTitle.Location = New Point(0, 0)
      Me.LabelTitle.Name = "LabelTitle"
      Me.LabelTitle.Size = New Size(550, 50)
      Me.LabelTitle.TabIndex = 0
      Me.LabelTitle.Text = "⚙️ APPLICATION SETTINGS"
      Me.LabelTitle.TextAlign = ContentAlignment.MiddleCenter

      ' TabControlSettings
      Me.TabControlSettings.Location = New Point(12, 60)
      Me.TabControlSettings.Name = "TabControlSettings"
      Me.TabControlSettings.SelectedIndex = 0
      Me.TabControlSettings.Size = New Size(526, 430)
      Me.TabControlSettings.TabIndex = 1

      ' TabPageDatabase
      Me.TabPageDatabase.Controls.Add(Me.GroupBoxDatabase)
      Me.TabPageDatabase.Location = New Point(4, 24)
      Me.TabPageDatabase.Name = "TabPageDatabase"
      Me.TabPageDatabase.Padding = New Padding(3)
      Me.TabPageDatabase.Size = New Size(518, 402)
      Me.TabPageDatabase.TabIndex = 0
      Me.TabPageDatabase.Text = "🗄️ Database"
      Me.TabPageDatabase.UseVisualStyleBackColor = True

      ' GroupBoxDatabase
      Me.GroupBoxDatabase.Controls.Add(Me.ButtonPasswordDemo)
      Me.GroupBoxDatabase.Controls.Add(Me.ButtonTest)
      Me.GroupBoxDatabase.Controls.Add(Me.TextBoxPort)
      Me.GroupBoxDatabase.Controls.Add(Me.TextBoxPassword)
      Me.GroupBoxDatabase.Controls.Add(Me.TextBoxUserId)
      Me.GroupBoxDatabase.Controls.Add(Me.TextBoxDatabase)
      Me.GroupBoxDatabase.Controls.Add(Me.TextBoxServer)
      Me.GroupBoxDatabase.Controls.Add(Me.LabelPort)
      Me.GroupBoxDatabase.Controls.Add(Me.LabelPassword)
      Me.GroupBoxDatabase.Controls.Add(Me.LabelUserId)
      Me.GroupBoxDatabase.Controls.Add(Me.LabelDatabase)
      Me.GroupBoxDatabase.Controls.Add(Me.LabelServer)
      Me.GroupBoxDatabase.Location = New Point(15, 15)
      Me.GroupBoxDatabase.Name = "GroupBoxDatabase"
      Me.GroupBoxDatabase.Size = New Size(485, 230)
      Me.GroupBoxDatabase.TabIndex = 0
      Me.GroupBoxDatabase.TabStop = False
      Me.GroupBoxDatabase.Text = "Database Connection"

      ' Database controls (existing)
      Me.LabelServer.AutoSize = True
      Me.LabelServer.Location = New Point(15, 30)
      Me.LabelServer.Name = "LabelServer"
      Me.LabelServer.Size = New Size(80, 15)
      Me.LabelServer.Text = "Server:"

      Me.TextBoxServer.Location = New Point(120, 27)
      Me.TextBoxServer.Name = "TextBoxServer"
      Me.TextBoxServer.Size = New Size(350, 23)
      Me.TextBoxServer.TabIndex = 0

      Me.LabelDatabase.AutoSize = True
      Me.LabelDatabase.Location = New Point(15, 60)
      Me.LabelDatabase.Text = "Database:"

      Me.TextBoxDatabase.Location = New Point(120, 57)
      Me.TextBoxDatabase.Size = New Size(350, 23)
      Me.TextBoxDatabase.TabIndex = 1

      Me.LabelUserId.AutoSize = True
      Me.LabelUserId.Location = New Point(15, 90)
      Me.LabelUserId.Text = "User ID:"

      Me.TextBoxUserId.Location = New Point(120, 87)
      Me.TextBoxUserId.Size = New Size(350, 23)
      Me.TextBoxUserId.TabIndex = 2

      Me.LabelPassword.AutoSize = True
      Me.LabelPassword.Location = New Point(15, 120)
      Me.LabelPassword.Text = "Password:"

      Me.TextBoxPassword.Location = New Point(120, 117)
      Me.TextBoxPassword.PasswordChar = "*"c
      Me.TextBoxPassword.Size = New Size(350, 23)
      Me.TextBoxPassword.TabIndex = 3

      Me.LabelPort.AutoSize = True
      Me.LabelPort.Location = New Point(15, 150)
      Me.LabelPort.Text = "Port:"

      Me.TextBoxPort.Location = New Point(120, 147)
      Me.TextBoxPort.Size = New Size(100, 23)
      Me.TextBoxPort.TabIndex = 4
      Me.TextBoxPort.Text = "3306"

      Me.ButtonTest.BackColor = Color.FromArgb(255, 152, 0)
      Me.ButtonTest.ForeColor = Color.White
      Me.ButtonTest.Location = New Point(120, 185)
      Me.ButtonTest.Size = New Size(130, 32)
      Me.ButtonTest.Text = "🔌 Test Connection"
      Me.ButtonTest.UseVisualStyleBackColor = False

      Me.ButtonPasswordDemo.BackColor = Color.FromArgb(156, 39, 176)
      Me.ButtonPasswordDemo.ForeColor = Color.White
      Me.ButtonPasswordDemo.Location = New Point(260, 185)
      Me.ButtonPasswordDemo.Size = New Size(130, 32)
      Me.ButtonPasswordDemo.Text = "🔐 Demo Encryption"
      Me.ButtonPasswordDemo.UseVisualStyleBackColor = False

      ' TabPageAppSettings
      Me.TabPageAppSettings.Controls.Add(Me.GroupBoxFormat)
      Me.TabPageAppSettings.Controls.Add(Me.GroupBoxPrint)
      Me.TabPageAppSettings.Controls.Add(Me.GroupBoxUI)
      Me.TabPageAppSettings.Controls.Add(Me.ButtonResetDefaults)
      Me.TabPageAppSettings.Location = New Point(4, 24)
      Me.TabPageAppSettings.Name = "TabPageAppSettings"
      Me.TabPageAppSettings.Padding = New Padding(3)
      Me.TabPageAppSettings.Size = New Size(518, 402)
      Me.TabPageAppSettings.TabIndex = 1
      Me.TabPageAppSettings.Text = "🎨 Application"
      Me.TabPageAppSettings.UseVisualStyleBackColor = True

      ' GroupBoxFormat
      Me.GroupBoxFormat.Controls.Add(Me.ComboBoxCulture)
      Me.GroupBoxFormat.Controls.Add(Me.LabelCulture)
      Me.GroupBoxFormat.Controls.Add(Me.TextBoxDateFormat)
      Me.GroupBoxFormat.Controls.Add(Me.LabelDateFormat)
      Me.GroupBoxFormat.Controls.Add(Me.TextBoxCurrencySymbol)
      Me.GroupBoxFormat.Controls.Add(Me.LabelCurrencySymbol)
      Me.GroupBoxFormat.Location = New Point(15, 15)
      Me.GroupBoxFormat.Size = New Size(485, 120)
      Me.GroupBoxFormat.Text = "Format & Culture Settings"

      Me.LabelCulture.AutoSize = True
      Me.LabelCulture.Location = New Point(15, 28)
      Me.LabelCulture.Text = "Culture:"

      Me.ComboBoxCulture.DropDownStyle = ComboBoxStyle.DropDownList
      Me.ComboBoxCulture.Items.AddRange(New Object() {"id-ID (Indonesian)", "en-US (English)"})
      Me.ComboBoxCulture.Location = New Point(150, 25)
      Me.ComboBoxCulture.Size = New Size(200, 23)
      Me.ComboBoxCulture.TabIndex = 0

      Me.LabelCurrencySymbol.AutoSize = True
      Me.LabelCurrencySymbol.Location = New Point(15, 58)
      Me.LabelCurrencySymbol.Text = "Currency Symbol:"

      Me.TextBoxCurrencySymbol.Location = New Point(150, 55)
      Me.TextBoxCurrencySymbol.Size = New Size(100, 23)
      Me.TextBoxCurrencySymbol.TabIndex = 1

      Me.LabelDateFormat.AutoSize = True
      Me.LabelDateFormat.Location = New Point(15, 88)
      Me.LabelDateFormat.Text = "Date Format:"

      Me.TextBoxDateFormat.Location = New Point(150, 85)
      Me.TextBoxDateFormat.Size = New Size(150, 23)
      Me.TextBoxDateFormat.TabIndex = 2

      ' GroupBoxPrint
      Me.GroupBoxPrint.Controls.Add(Me.ComboBoxOrientation)
      Me.GroupBoxPrint.Controls.Add(Me.LabelOrientation)
      Me.GroupBoxPrint.Controls.Add(Me.NumericPrintFontSize)
      Me.GroupBoxPrint.Controls.Add(Me.LabelPrintFontSize)
      Me.GroupBoxPrint.Controls.Add(Me.CheckBoxAlternatingRows)
      Me.GroupBoxPrint.Location = New Point(15, 145)
      Me.GroupBoxPrint.Size = New Size(485, 120)
      Me.GroupBoxPrint.Text = "Print & Export Settings"

      Me.LabelOrientation.AutoSize = True
      Me.LabelOrientation.Location = New Point(15, 28)
      Me.LabelOrientation.Text = "Default Orientation:"

      Me.ComboBoxOrientation.DropDownStyle = ComboBoxStyle.DropDownList
      Me.ComboBoxOrientation.Items.AddRange(New Object() {"Portrait", "Landscape"})
      Me.ComboBoxOrientation.Location = New Point(150, 25)
      Me.ComboBoxOrientation.Size = New Size(150, 23)
      Me.ComboBoxOrientation.TabIndex = 0

      Me.LabelPrintFontSize.AutoSize = True
      Me.LabelPrintFontSize.Location = New Point(15, 58)
      Me.LabelPrintFontSize.Text = "Print Font Size:"

      Me.NumericPrintFontSize.Location = New Point(150, 55)
      Me.NumericPrintFontSize.Minimum = 6
      Me.NumericPrintFontSize.Maximum = 14
      Me.NumericPrintFontSize.Value = 8
      Me.NumericPrintFontSize.Size = New Size(80, 23)
      Me.NumericPrintFontSize.TabIndex = 1

      Me.CheckBoxAlternatingRows.AutoSize = True
      Me.CheckBoxAlternatingRows.Location = New Point(15, 88)
      Me.CheckBoxAlternatingRows.Text = "Enable Alternating Row Colors"
      Me.CheckBoxAlternatingRows.TabIndex = 2

      ' GroupBoxUI
      Me.GroupBoxUI.Controls.Add(Me.CheckBoxAutoLoadReport)
      Me.GroupBoxUI.Controls.Add(Me.CheckBoxConfirmDelete)
      Me.GroupBoxUI.Location = New Point(15, 275)
      Me.GroupBoxUI.Size = New Size(485, 85)
      Me.GroupBoxUI.Text = "UI Behavior"

      Me.CheckBoxAutoLoadReport.AutoSize = True
      Me.CheckBoxAutoLoadReport.Location = New Point(15, 28)
      Me.CheckBoxAutoLoadReport.Text = "Auto-load reports on open"
      Me.CheckBoxAutoLoadReport.TabIndex = 0

      Me.CheckBoxConfirmDelete.AutoSize = True
      Me.CheckBoxConfirmDelete.Location = New Point(15, 53)
      Me.CheckBoxConfirmDelete.Text = "Confirm before deleting records"
      Me.CheckBoxConfirmDelete.TabIndex = 1

      ' ButtonResetDefaults
      Me.ButtonResetDefaults.BackColor = Color.FromArgb(244, 67, 54)
      Me.ButtonResetDefaults.ForeColor = Color.White
      Me.ButtonResetDefaults.Location = New Point(15, 368)
      Me.ButtonResetDefaults.Size = New Size(150, 28)
      Me.ButtonResetDefaults.Text = "🔄 Reset to Defaults"
      Me.ButtonResetDefaults.UseVisualStyleBackColor = False

      ' Bottom Buttons
      Me.ButtonSave.BackColor = Color.FromArgb(76, 175, 80)
      Me.ButtonSave.ForeColor = Color.White
      Me.ButtonSave.Location = New Point(338, 500)
      Me.ButtonSave.Size = New Size(95, 38)
      Me.ButtonSave.Text = "💾 SAVE"
      Me.ButtonSave.UseVisualStyleBackColor = False
      Me.ButtonSave.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)

      Me.ButtonCancel.BackColor = Color.FromArgb(244, 67, 54)
      Me.ButtonCancel.ForeColor = Color.White
      Me.ButtonCancel.Location = New Point(443, 500)
      Me.ButtonCancel.Size = New Size(95, 38)
      Me.ButtonCancel.Text = "❌ CANCEL"
      Me.ButtonCancel.UseVisualStyleBackColor = False
      Me.ButtonCancel.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)

      ' FormSetting
      Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
      Me.AutoScaleMode = AutoScaleMode.Font
      Me.ClientSize = New Size(550, 550)
      Me.Controls.Add(Me.ButtonCancel)
      Me.Controls.Add(Me.ButtonSave)
      Me.Controls.Add(Me.TabControlSettings)
      Me.Controls.Add(Me.LabelTitle)
      Me.FormBorderStyle = FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FormSetting"
      Me.StartPosition = FormStartPosition.CenterParent
      Me.Text = "Application Settings"
      Me.TabControlSettings.ResumeLayout(False)
      Me.TabPageDatabase.ResumeLayout(False)
      Me.GroupBoxDatabase.ResumeLayout(False)
      Me.GroupBoxDatabase.PerformLayout()
      Me.TabPageAppSettings.ResumeLayout(False)
      Me.GroupBoxFormat.ResumeLayout(False)
      Me.GroupBoxFormat.PerformLayout()
      Me.GroupBoxPrint.ResumeLayout(False)
      Me.GroupBoxPrint.PerformLayout()
      CType(Me.NumericPrintFontSize, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBoxUI.ResumeLayout(False)
      Me.GroupBoxUI.PerformLayout()
      Me.ResumeLayout(False)
   End Sub

   Friend WithEvents LabelTitle As Label
   Friend WithEvents TabControlSettings As TabControl
   Friend WithEvents TabPageDatabase As TabPage
   Friend WithEvents GroupBoxDatabase As GroupBox
   Friend WithEvents LabelServer As Label
   Friend WithEvents LabelDatabase As Label
   Friend WithEvents LabelUserId As Label
   Friend WithEvents LabelPassword As Label
   Friend WithEvents LabelPort As Label
   Friend WithEvents TextBoxServer As TextBox
   Friend WithEvents TextBoxDatabase As TextBox
   Friend WithEvents TextBoxUserId As TextBox
   Friend WithEvents TextBoxPassword As TextBox
   Friend WithEvents TextBoxPort As TextBox
   Friend WithEvents ButtonTest As Button
   Friend WithEvents ButtonPasswordDemo As Button
   Friend WithEvents TabPageAppSettings As TabPage
   Friend WithEvents GroupBoxFormat As GroupBox
   Friend WithEvents LabelCulture As Label
   Friend WithEvents ComboBoxCulture As ComboBox
   Friend WithEvents LabelCurrencySymbol As Label
   Friend WithEvents TextBoxCurrencySymbol As TextBox
   Friend WithEvents LabelDateFormat As Label
   Friend WithEvents TextBoxDateFormat As TextBox
   Friend WithEvents GroupBoxPrint As GroupBox
   Friend WithEvents LabelOrientation As Label
   Friend WithEvents ComboBoxOrientation As ComboBox
   Friend WithEvents LabelPrintFontSize As Label
   Friend WithEvents NumericPrintFontSize As NumericUpDown
   Friend WithEvents CheckBoxAlternatingRows As CheckBox
   Friend WithEvents GroupBoxUI As GroupBox
   Friend WithEvents CheckBoxAutoLoadReport As CheckBox
   Friend WithEvents CheckBoxConfirmDelete As CheckBox
   Friend WithEvents ButtonResetDefaults As Button
   Friend WithEvents ButtonSave As Button
   Friend WithEvents ButtonCancel As Button
End Class