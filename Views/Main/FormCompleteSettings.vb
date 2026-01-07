Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Services
Imports WinFormsApp_Latihan.Controllers

Public Class FormCompleteSettings
   Inherits System.Windows.Forms.Form

   Private _settingsManager As SettingsManager
   Private _appSettings As ApplicationSettings
   Private _dbConfig As ConfigModel

   ' UI Controls
   Private tabControl As TabControl
   Private tabDatabase As TabPage
   Private tabApplication As TabPage

   ' Database controls
   Private txtServer, txtDatabase, txtUserId, txtPassword, txtPort As TextBox
   Private btnTestConnection, btnSave, btnCancel As Button

   ' App settings controls
   Private cmbCulture, cmbOrientation As ComboBox
   Private txtCurrency, txtDateFormat As TextBox
   Private numFontSize As NumericUpDown
   Private chkAlternating, chkAutoLoad, chkConfirm As CheckBox
   Private btnReset As Button

   Public Sub New()
      MyBase.New()
      InitializeComponent()
   End Sub

   Private Sub InitializeComponent()
      ' Form properties
      Me.Text = AppInfo.GetWindowTitle("Settings")
      Me.FormBorderStyle = FormBorderStyle.FixedDialog
      Me.StartPosition = FormStartPosition.CenterParent
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.ClientSize = New Size(600, 550)

      ' Title
      Dim lblTitle As New Label With {
         .Text = "APPLICATION SETTINGS",
         .Font = New Font("Segoe UI", 14, FontStyle.Bold),
         .ForeColor = Color.White,
         .BackColor = Color.FromArgb(25, 118, 210),
         .Dock = DockStyle.Top,
         .Height = 50,
         .TextAlign = ContentAlignment.MiddleCenter
      }
      Me.Controls.Add(lblTitle)

      ' TabControl
      tabControl = New TabControl With {
         .Location = New Point(10, 60),
         .Size = New Size(580, 430)
      }

      ' Application Tab - FIRST
      tabApplication = New TabPage("Application Preferences")
      CreateApplicationTab()
      tabControl.TabPages.Add(tabApplication)

      ' Database Tab - SECOND
      tabDatabase = New TabPage("Database Configuration")
      CreateDatabaseTab()
      tabControl.TabPages.Add(tabDatabase)

      Me.Controls.Add(tabControl)

      ' Bottom buttons
      btnSave = New Button With {
         .Text = "SAVE",
         .Location = New Point(390, 500),
         .Size = New Size(95, 35),
         .BackColor = Color.FromArgb(76, 175, 80),
         .ForeColor = Color.White,
         .Font = New Font("Segoe UI", 9, FontStyle.Bold),
         .FlatStyle = FlatStyle.Flat
      }
      AddHandler btnSave.Click, AddressOf BtnSave_Click
      Me.Controls.Add(btnSave)

      btnCancel = New Button With {
         .Text = "CANCEL",
         .Location = New Point(495, 500),
         .Size = New Size(95, 35),
         .BackColor = Color.FromArgb(244, 67, 54),
         .ForeColor = Color.White,
         .Font = New Font("Segoe UI", 9, FontStyle.Bold),
         .FlatStyle = FlatStyle.Flat
      }
      AddHandler btnCancel.Click, AddressOf BtnCancel_Click
      Me.Controls.Add(btnCancel)
   End Sub

   Private Sub CreateDatabaseTab()
      Dim grp As New GroupBox With {
         .Text = "Database Connection",
         .Location = New Point(15, 15),
         .Size = New Size(540, 200),
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }

      ' Server
      grp.Controls.Add(New Label With {.Text = "Server:", .Location = New Point(15, 30), .AutoSize = True})
      txtServer = New TextBox With {.Location = New Point(120, 27), .Size = New Size(400, 23)}
      grp.Controls.Add(txtServer)

      ' Database
      grp.Controls.Add(New Label With {.Text = "Database:", .Location = New Point(15, 60), .AutoSize = True})
      txtDatabase = New TextBox With {.Location = New Point(120, 57), .Size = New Size(400, 23)}
      grp.Controls.Add(txtDatabase)

      ' User ID
      grp.Controls.Add(New Label With {.Text = "User ID:", .Location = New Point(15, 90), .AutoSize = True})
      txtUserId = New TextBox With {.Location = New Point(120, 87), .Size = New Size(400, 23)}
      grp.Controls.Add(txtUserId)

      ' Password
      grp.Controls.Add(New Label With {.Text = "Password:", .Location = New Point(15, 120), .AutoSize = True})
      txtPassword = New TextBox With {.Location = New Point(120, 117), .Size = New Size(400, 23), .PasswordChar = "*"c}
      grp.Controls.Add(txtPassword)

      ' Port
      grp.Controls.Add(New Label With {.Text = "Port:", .Location = New Point(15, 150), .AutoSize = True})
      txtPort = New TextBox With {.Location = New Point(120, 147), .Size = New Size(100, 23), .Text = "3306"}
      grp.Controls.Add(txtPort)

      ' Test button
      btnTestConnection = New Button With {
         .Text = "Test Connection",
         .Location = New Point(230, 145),
         .Size = New Size(130, 28),
         .BackColor = Color.FromArgb(255, 152, 0),
         .ForeColor = Color.White,
         .FlatStyle = FlatStyle.Flat
      }
      AddHandler btnTestConnection.Click, AddressOf BtnTest_Click
      grp.Controls.Add(btnTestConnection)

      tabDatabase.Controls.Add(grp)
   End Sub

   Private Sub CreateApplicationTab()
      Dim yPos = 15

      ' Format group
      Dim grpFormat As New GroupBox With {
         .Text = "Format & Culture",
         .Location = New Point(15, yPos),
         .Size = New Size(540, 110),
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }

      grpFormat.Controls.Add(New Label With {.Text = "Culture:", .Location = New Point(15, 28), .AutoSize = True})
      cmbCulture = New ComboBox With {
         .Location = New Point(150, 25),
         .Size = New Size(200, 23),
         .DropDownStyle = ComboBoxStyle.DropDownList
      }
      cmbCulture.Items.AddRange({"id-ID (Indonesian)", "en-US (English)"})
      AddHandler cmbCulture.SelectedIndexChanged, AddressOf CmbCulture_Changed
      grpFormat.Controls.Add(cmbCulture)

      grpFormat.Controls.Add(New Label With {.Text = "Currency:", .Location = New Point(15, 58), .AutoSize = True})
      txtCurrency = New TextBox With {.Location = New Point(150, 55), .Size = New Size(100, 23)}
      grpFormat.Controls.Add(txtCurrency)

      grpFormat.Controls.Add(New Label With {.Text = "Date Format:", .Location = New Point(15, 88), .AutoSize = True})
      txtDateFormat = New TextBox With {.Location = New Point(150, 85), .Size = New Size(150, 23)}
      grpFormat.Controls.Add(txtDateFormat)

      tabApplication.Controls.Add(grpFormat)
      yPos += 120

      ' Print group
      Dim grpPrint As New GroupBox With {
         .Text = "Print Settings",
         .Location = New Point(15, yPos),
         .Size = New Size(540, 110),
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }

      grpPrint.Controls.Add(New Label With {.Text = "Orientation:", .Location = New Point(15, 28), .AutoSize = True})
      cmbOrientation = New ComboBox With {
         .Location = New Point(150, 25),
         .Size = New Size(150, 23),
         .DropDownStyle = ComboBoxStyle.DropDownList
      }
      cmbOrientation.Items.AddRange({"Portrait", "Landscape"})
      grpPrint.Controls.Add(cmbOrientation)

      grpPrint.Controls.Add(New Label With {.Text = "Font Size:", .Location = New Point(15, 58), .AutoSize = True})
      numFontSize = New NumericUpDown With {
         .Location = New Point(150, 55),
         .Size = New Size(80, 23),
         .Minimum = 6,
         .Maximum = 14,
         .Value = 8
      }
      grpPrint.Controls.Add(numFontSize)

      chkAlternating = New CheckBox With {
         .Text = "Enable Alternating Row Colors",
         .Location = New Point(15, 85),
         .AutoSize = True
      }
      grpPrint.Controls.Add(chkAlternating)

      tabApplication.Controls.Add(grpPrint)
      yPos += 120

      ' UI group
      Dim grpUI As New GroupBox With {
         .Text = "UI Behavior",
         .Location = New Point(15, yPos),
         .Size = New Size(540, 80),
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
      }

      chkAutoLoad = New CheckBox With {
         .Text = "Auto-load reports on open",
         .Location = New Point(15, 25),
         .AutoSize = True
      }
      grpUI.Controls.Add(chkAutoLoad)

      chkConfirm = New CheckBox With {
         .Text = "Confirm before deleting",
         .Location = New Point(15, 50),
         .AutoSize = True
      }
      grpUI.Controls.Add(chkConfirm)

      tabApplication.Controls.Add(grpUI)

      ' Reset button
      btnReset = New Button With {
         .Text = "Reset to Defaults",
         .Location = New Point(15, 350),
         .Size = New Size(150, 30),
         .BackColor = Color.FromArgb(244, 67, 54),
         .ForeColor = Color.White,
         .FlatStyle = FlatStyle.Flat
      }
      AddHandler btnReset.Click, AddressOf BtnReset_Click
      tabApplication.Controls.Add(btnReset)
   End Sub

   Private Sub FormCompleteSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      _settingsManager = SettingsManager.GetInstance()
      _dbConfig = _settingsManager.GetDatabaseConfig()
      _appSettings = _settingsManager.GetApplicationSettings()

      LoadDatabaseSettings()
      LoadApplicationSettings()
   End Sub

   Private Sub LoadDatabaseSettings()
      txtServer.Text = _dbConfig.Server
      txtDatabase.Text = _dbConfig.Database
      txtUserId.Text = _dbConfig.Username
      txtPassword.Text = _dbConfig.Password
      txtPort.Text = _dbConfig.Port
   End Sub

   Private Sub LoadApplicationSettings()
      cmbCulture.SelectedIndex = If(_appSettings.CultureCode = "id-ID", 0, 1)
      txtCurrency.Text = _appSettings.CurrencySymbol
      txtDateFormat.Text = _appSettings.DateFormat
      cmbOrientation.SelectedIndex = If(_appSettings.DefaultPrintOrientation = "Portrait", 0, 1)
      numFontSize.Value = _appSettings.PrintFontSize
      chkAlternating.Checked = _appSettings.EnableAlternatingRowColors
      chkAutoLoad.Checked = _appSettings.AutoLoadReportOnOpen
      chkConfirm.Checked = _appSettings.ConfirmBeforeDelete
   End Sub

   Private Sub CmbCulture_Changed(sender As Object, e As EventArgs)
      If cmbCulture.SelectedIndex = 0 Then
         txtCurrency.Text = "Rp"
         txtDateFormat.Text = "dd/MM/yyyy"
      Else
         txtCurrency.Text = "$"
         txtDateFormat.Text = "MM/dd/yyyy"
      End If
   End Sub

   Private Sub BtnTest_Click(sender As Object, e As EventArgs)
      Try
         Dim testConfig As New ConfigModel(
            txtServer.Text.Trim(),
            txtDatabase.Text.Trim(),
            txtUserId.Text.Trim(),
            txtPassword.Text.Trim(),
            txtPort.Text.Trim()
         )

         If _settingsManager.TestDatabaseConnection(testConfig) Then
            MessageBox.Show("Connection successful!", "Test Connection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show("Connection failed! Please check your configuration.",
                          "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
      Catch ex As Exception
         MessageBox.Show($"Connection failed: {ex.Message}",
                        "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub BtnSave_Click(sender As Object, e As EventArgs)
      Try
         ' Save database config
         _dbConfig = New ConfigModel(
            txtServer.Text.Trim(),
            txtDatabase.Text.Trim(),
            txtUserId.Text.Trim(),
            txtPassword.Text.Trim(),
            txtPort.Text.Trim()
         )
         _settingsManager.SaveDatabaseConfig(_dbConfig)

         ' Save app settings
         _appSettings.CultureCode = If(cmbCulture.SelectedIndex = 0, "id-ID", "en-US")
         _appSettings.CurrencySymbol = txtCurrency.Text.Trim()
         _appSettings.DateFormat = txtDateFormat.Text.Trim()
         _appSettings.DefaultPrintOrientation = If(cmbOrientation.SelectedIndex = 0, "Portrait", "Landscape")
         _appSettings.PrintFontSize = CInt(numFontSize.Value)
         _appSettings.EnableAlternatingRowColors = chkAlternating.Checked
         _appSettings.AutoLoadReportOnOpen = chkAutoLoad.Checked
         _appSettings.ConfirmBeforeDelete = chkConfirm.Checked

         If _appSettings.CultureCode = "id-ID" Then
            _appSettings.CurrencyDecimalSeparator = ","
            _appSettings.CurrencyGroupSeparator = "."
         Else
            _appSettings.CurrencyDecimalSeparator = "."
            _appSettings.CurrencyGroupSeparator = ","
         End If
         _appSettings.DateTimeFormat = _appSettings.DateFormat & " HH:mm"

         _settingsManager.SaveApplicationSettings(_appSettings)

         MessageBox.Show("Settings saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.DialogResult = DialogResult.OK
         Me.Close()
      Catch ex As Exception
         MessageBox.Show($"Error saving: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub BtnReset_Click(sender As Object, e As EventArgs)
      If MessageBox.Show("Reset all application settings to default?",
                        "Confirm", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) = DialogResult.Yes Then
         _appSettings = New ApplicationSettings()
         _appSettings.ResetToDefaults()
         LoadApplicationSettings()
         MessageBox.Show("Settings reset. Click SAVE to apply.",
                        "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub
End Class
