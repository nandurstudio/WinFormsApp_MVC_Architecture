Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Services

Public Class FormApplicationSettings
   Inherits System.Windows.Forms.Form

   Private _settingsManager As SettingsManager
   Private _appSettings As ApplicationSettings

   Private Sub FormApplicationSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Text = AppInfo.GetWindowTitle("Application Preferences")
      FormBorderStyle = FormBorderStyle.FixedDialog
      StartPosition = FormStartPosition.CenterParent
      MaximizeBox = False
      MinimizeBox = False
      Size = New Size(550, 500)

      ' Initialize Settings Manager
      _settingsManager = SettingsManager.GetInstance()
      _appSettings = _settingsManager.GetApplicationSettings()

      InitializeUI()
      LoadSettings()
   End Sub

   Private Sub InitializeUI()
      ' Title Label
      Dim lblTitle As New Label With {
         .Text = "APPLICATION PREFERENCES",
         .Font = New Font("Segoe UI", 14, FontStyle.Bold),
         .ForeColor = Color.White,
         .BackColor = Color.FromArgb(25, 118, 210),
         .Size = New Size(550, 50),
         .Location = New Point(0, 0),
         .TextAlign = ContentAlignment.MiddleCenter
      }
      Controls.Add(lblTitle)

      ' Format GroupBox
      Dim grpFormat As New GroupBox With {
         .Text = "Format & Culture Settings",
         .Location = New Point(20, 70),
         .Size = New Size(500, 120),
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }

      Dim lblCulture As New Label With {
         .Text = "Culture:",
         .Location = New Point(15, 30),
         .AutoSize = True
      }
      grpFormat.Controls.Add(lblCulture)

      Dim cmbCulture As New ComboBox With {
         .Name = "cmbCulture",
         .DropDownStyle = ComboBoxStyle.DropDownList,
         .Location = New Point(150, 27),
         .Size = New Size(200, 23)
      }
      cmbCulture.Items.AddRange({"id-ID (Indonesian)", "en-US (English)"})
      AddHandler cmbCulture.SelectedIndexChanged, AddressOf CmbCulture_SelectedIndexChanged
      grpFormat.Controls.Add(cmbCulture)

      Dim lblCurrency As New Label With {
         .Text = "Currency Symbol:",
         .Location = New Point(15, 60),
         .AutoSize = True
      }
      grpFormat.Controls.Add(lblCurrency)

      Dim txtCurrency As New TextBox With {
         .Name = "txtCurrency",
         .Location = New Point(150, 57),
         .Size = New Size(100, 23)
      }
      grpFormat.Controls.Add(txtCurrency)

      Dim lblDate As New Label With {
         .Text = "Date Format:",
         .Location = New Point(15, 90),
         .AutoSize = True
      }
      grpFormat.Controls.Add(lblDate)

      Dim txtDate As New TextBox With {
         .Name = "txtDate",
         .Location = New Point(150, 87),
         .Size = New Size(150, 23)
      }
      grpFormat.Controls.Add(txtDate)

      Controls.Add(grpFormat)

      ' Print GroupBox
      Dim grpPrint As New GroupBox With {
         .Text = "Print & Export Settings",
         .Location = New Point(20, 200),
         .Size = New Size(500, 120),
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }

      Dim lblOrientation As New Label With {
         .Text = "Default Orientation:",
         .Location = New Point(15, 30),
         .AutoSize = True
      }
      grpPrint.Controls.Add(lblOrientation)

      Dim cmbOrientation As New ComboBox With {
         .Name = "cmbOrientation",
         .DropDownStyle = ComboBoxStyle.DropDownList,
         .Location = New Point(150, 27),
         .Size = New Size(150, 23)
      }
      cmbOrientation.Items.AddRange({"Portrait", "Landscape"})
      grpPrint.Controls.Add(cmbOrientation)

      Dim lblFontSize As New Label With {
         .Text = "Print Font Size:",
         .Location = New Point(15, 60),
         .AutoSize = True
      }
      grpPrint.Controls.Add(lblFontSize)

      Dim numFontSize As New NumericUpDown With {
         .Name = "numFontSize",
         .Location = New Point(150, 57),
         .Size = New Size(80, 23),
         .Minimum = 6,
         .Maximum = 14,
         .Value = 8
      }
      grpPrint.Controls.Add(numFontSize)

      Dim chkAlternating As New CheckBox With {
         .Name = "chkAlternating",
         .Text = "Enable Alternating Row Colors",
         .Location = New Point(15, 90),
         .AutoSize = True
      }
      grpPrint.Controls.Add(chkAlternating)

      Controls.Add(grpPrint)

      ' UI Behavior GroupBox
      Dim grpUI As New GroupBox With {
         .Text = "UI Behavior",
         .Location = New Point(20, 330),
         .Size = New Size(500, 85),
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }

      Dim chkAutoLoad As New CheckBox With {
         .Name = "chkAutoLoad",
         .Text = "Auto-load reports on open",
         .Location = New Point(15, 30),
         .AutoSize = True
      }
      grpUI.Controls.Add(chkAutoLoad)

      Dim chkConfirm As New CheckBox With {
         .Name = "chkConfirm",
         .Text = "Confirm before deleting records",
         .Location = New Point(15, 55),
         .AutoSize = True
      }
      grpUI.Controls.Add(chkConfirm)

      Controls.Add(grpUI)

      ' Buttons
      Dim btnReset As New Button With {
         .Text = "Reset to Defaults",
         .Location = New Point(20, 425),
         .Size = New Size(150, 32),
         .BackColor = Color.FromArgb(244, 67, 54),
         .ForeColor = Color.White,
         .FlatStyle = FlatStyle.Flat
      }
      AddHandler btnReset.Click, AddressOf BtnReset_Click
      Controls.Add(btnReset)

      Dim btnSave As New Button With {
         .Text = "SAVE",
         .Location = New Point(335, 425),
         .Size = New Size(90, 32),
         .BackColor = Color.FromArgb(76, 175, 80),
         .ForeColor = Color.White,
         .FlatStyle = FlatStyle.Flat,
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }
      AddHandler btnSave.Click, AddressOf BtnSave_Click
      Controls.Add(btnSave)

      Dim btnCancel As New Button With {
         .Text = "CANCEL",
         .Location = New Point(430, 425),
         .Size = New Size(90, 32),
         .BackColor = Color.FromArgb(244, 67, 54),
         .ForeColor = Color.White,
         .FlatStyle = FlatStyle.Flat,
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }
      AddHandler btnCancel.Click, AddressOf BtnCancel_Click
      Controls.Add(btnCancel)
   End Sub

   Private Sub LoadSettings()
      Dim cmbCulture = CType(Controls.Find("cmbCulture", True)(0), ComboBox)
      Dim txtCurrency = CType(Controls.Find("txtCurrency", True)(0), TextBox)
      Dim txtDate = CType(Controls.Find("txtDate", True)(0), TextBox)
      Dim cmbOrientation = CType(Controls.Find("cmbOrientation", True)(0), ComboBox)
      Dim numFontSize = CType(Controls.Find("numFontSize", True)(0), NumericUpDown)
      Dim chkAlternating = CType(Controls.Find("chkAlternating", True)(0), CheckBox)
      Dim chkAutoLoad = CType(Controls.Find("chkAutoLoad", True)(0), CheckBox)
      Dim chkConfirm = CType(Controls.Find("chkConfirm", True)(0), CheckBox)

      cmbCulture.SelectedIndex = If(_appSettings.CultureCode = "id-ID", 0, 1)
      txtCurrency.Text = _appSettings.CurrencySymbol
      txtDate.Text = _appSettings.DateFormat
      cmbOrientation.SelectedIndex = If(_appSettings.DefaultPrintOrientation = "Portrait", 0, 1)
      numFontSize.Value = _appSettings.PrintFontSize
      chkAlternating.Checked = _appSettings.EnableAlternatingRowColors
      chkAutoLoad.Checked = _appSettings.AutoLoadReportOnOpen
      chkConfirm.Checked = _appSettings.ConfirmBeforeDelete
   End Sub

   Private Sub CmbCulture_SelectedIndexChanged(sender As Object, e As EventArgs)
      Dim cmbCulture = CType(sender, ComboBox)
      Dim txtCurrency = CType(Controls.Find("txtCurrency", True)(0), TextBox)
      Dim txtDate = CType(Controls.Find("txtDate", True)(0), TextBox)

      If cmbCulture.SelectedIndex = 0 Then ' Indonesian
         txtCurrency.Text = "Rp"
         txtDate.Text = "dd/MM/yyyy"
      Else ' English
         txtCurrency.Text = "$"
         txtDate.Text = "MM/dd/yyyy"
      End If
   End Sub

   Private Sub BtnSave_Click(sender As Object, e As EventArgs)
      Try
         Dim cmbCulture = CType(Controls.Find("cmbCulture", True)(0), ComboBox)
         Dim txtCurrency = CType(Controls.Find("txtCurrency", True)(0), TextBox)
         Dim txtDate = CType(Controls.Find("txtDate", True)(0), TextBox)
         Dim cmbOrientation = CType(Controls.Find("cmbOrientation", True)(0), ComboBox)
         Dim numFontSize = CType(Controls.Find("numFontSize", True)(0), NumericUpDown)
         Dim chkAlternating = CType(Controls.Find("chkAlternating", True)(0), CheckBox)
         Dim chkAutoLoad = CType(Controls.Find("chkAutoLoad", True)(0), CheckBox)
         Dim chkConfirm = CType(Controls.Find("chkConfirm", True)(0), CheckBox)

         ' Update settings
         _appSettings.CultureCode = If(cmbCulture.SelectedIndex = 0, "id-ID", "en-US")
         _appSettings.CurrencySymbol = txtCurrency.Text.Trim()
         _appSettings.DateFormat = txtDate.Text.Trim()
         _appSettings.DefaultPrintOrientation = If(cmbOrientation.SelectedIndex = 0, "Portrait", "Landscape")
         _appSettings.PrintFontSize = CInt(numFontSize.Value)
         _appSettings.EnableAlternatingRowColors = chkAlternating.Checked
         _appSettings.AutoLoadReportOnOpen = chkAutoLoad.Checked
         _appSettings.ConfirmBeforeDelete = chkConfirm.Checked

         ' Update culture-related properties
         If _appSettings.CultureCode = "id-ID" Then
            _appSettings.CurrencyDecimalSeparator = ","
            _appSettings.CurrencyGroupSeparator = "."
         Else
            _appSettings.CurrencyDecimalSeparator = "."
            _appSettings.CurrencyGroupSeparator = ","
         End If
         _appSettings.DateTimeFormat = _appSettings.DateFormat & " HH:mm"

         ' Save to file
         _settingsManager.SaveApplicationSettings(_appSettings)

         MessageBox.Show("Application preferences saved successfully!" & vbCrLf & vbCrLf &
                        "Note: Some changes may require restarting the application to take full effect.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

         DialogResult = DialogResult.OK
         Close()

      Catch ex As Exception
         MessageBox.Show($"Error saving settings: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub BtnReset_Click(sender As Object, e As EventArgs)
      Dim result = MessageBox.Show(
         "Are you sure you want to reset all application settings to default?",
         "Reset to Defaults",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Question)

      If result = DialogResult.Yes Then
         _appSettings = New ApplicationSettings()
         _appSettings.ResetToDefaults()
         LoadSettings()

         MessageBox.Show("Application settings have been reset to defaults." & vbCrLf &
                        "Click SAVE to apply changes.",
                        "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
      DialogResult = DialogResult.Cancel
      Close()
   End Sub
End Class
