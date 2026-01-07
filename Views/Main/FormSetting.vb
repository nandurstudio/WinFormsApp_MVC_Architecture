' ============================================================
' Nama            : Nandang Duryat
' NIM             : 312310233
' Kelas           : TI.23.B1
' Universitas     : Pelita Bangsa
' Pertemuan Ke    : 3
' Mata Kuliah     : Pemrograman Visual (Desktop)
' Dosen Pengampu  : Asep Muhidin, S.Kom., M.Kom.
' ============================================================

Imports System.IO
Imports WinFormsApp_Latihan.Controllers
Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Services

Public Class FormSetting

   Private _settingsManager As SettingsManager
   Private _databaseConfig As ConfigModel
   Private _appSettings As ApplicationSettings

   Private Sub FormSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Text = AppInfo.GetWindowTitle("Settings")
      FormBorderStyle = FormBorderStyle.FixedDialog
      StartPosition = FormStartPosition.CenterParent
      MaximizeBox = False
      MinimizeBox = False

      ' Initialize Settings Manager
      _settingsManager = SettingsManager.GetInstance()

      ' Load current settings
      LoadAllSettings()
   End Sub

   Private Sub LoadAllSettings()
      LoadDatabaseSettings()
      LoadApplicationSettings()
   End Sub

   Private Sub LoadDatabaseSettings()
      _databaseConfig = _settingsManager.GetDatabaseConfig()
      TextBoxServer.Text = _databaseConfig.Server
      TextBoxDatabase.Text = _databaseConfig.Database
      TextBoxUserId.Text = _databaseConfig.Username
      TextBoxPassword.Text = _databaseConfig.Password
      TextBoxPort.Text = _databaseConfig.Port
   End Sub

   Private Sub LoadApplicationSettings()
      _appSettings = _settingsManager.GetApplicationSettings()

      ' Format Settings
      If _appSettings.CultureCode = "id-ID" Then
         ComboBoxCulture.SelectedIndex = 0
      Else
         ComboBoxCulture.SelectedIndex = 1
      End If

      TextBoxCurrencySymbol.Text = _appSettings.CurrencySymbol
      TextBoxDateFormat.Text = _appSettings.DateFormat

      ' Print Settings
      If _appSettings.DefaultPrintOrientation = "Portrait" Then
         ComboBoxOrientation.SelectedIndex = 0
      Else
         ComboBoxOrientation.SelectedIndex = 1
      End If

      NumericPrintFontSize.Value = _appSettings.PrintFontSize
      CheckBoxAlternatingRows.Checked = _appSettings.EnableAlternatingRowColors

      ' UI Settings
      CheckBoxAutoLoadReport.Checked = _appSettings.AutoLoadReportOnOpen
      CheckBoxConfirmDelete.Checked = _appSettings.ConfirmBeforeDelete
   End Sub

   Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
      If ValidateInput() Then
         SaveAllSettings()
      End If
   End Sub

   Private Function ValidateInput() As Boolean
      ' Validate Database Settings
      If String.IsNullOrWhiteSpace(TextBoxServer.Text) Then
         TabControlSettings.SelectedTab = TabPageDatabase
         MessageBox.Show("Server must be filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxServer.Focus()
         Return False
      End If

      If String.IsNullOrWhiteSpace(TextBoxDatabase.Text) Then
         TabControlSettings.SelectedTab = TabPageDatabase
         MessageBox.Show("Database must be filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxDatabase.Focus()
         Return False
      End If

      If String.IsNullOrWhiteSpace(TextBoxUserId.Text) Then
         TabControlSettings.SelectedTab = TabPageDatabase
         MessageBox.Show("User ID must be filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxUserId.Focus()
         Return False
      End If

      ' Validate Application Settings
      If String.IsNullOrWhiteSpace(TextBoxCurrencySymbol.Text) Then
         TabControlSettings.SelectedTab = TabPageAppSettings
         MessageBox.Show("Currency symbol must be filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxCurrencySymbol.Focus()
         Return False
      End If

      If String.IsNullOrWhiteSpace(TextBoxDateFormat.Text) Then
         TabControlSettings.SelectedTab = TabPageAppSettings
         MessageBox.Show("Date format must be filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxDateFormat.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub SaveAllSettings()
      Try
         ' Save Database Configuration
         Dim newDbConfig As New ConfigModel(
            TextBoxServer.Text.Trim(),
            TextBoxDatabase.Text.Trim(),
            TextBoxUserId.Text.Trim(),
            TextBoxPassword.Text.Trim(),
            TextBoxPort.Text.Trim()
         )

         ' Validate database config
         Dim settingController As New SettingController()
         Dim validation = settingController.ValidateConfiguration(newDbConfig)
         If Not validation.IsValid Then
            TabControlSettings.SelectedTab = TabPageDatabase
            MessageBox.Show(validation.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
         End If

         ' Save Application Settings
         UpdateApplicationSettingsFromUI()

         ' Save both to files
         _settingsManager.SaveDatabaseConfig(newDbConfig)
         _settingsManager.SaveApplicationSettings(_appSettings)

         MessageBox.Show("All settings saved successfully!" & vbCrLf & vbCrLf &
                        "Note: Some changes may require restarting the application to take full effect.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

         DialogResult = DialogResult.OK
         Close()

      Catch ex As Exception
         MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub UpdateApplicationSettingsFromUI()
      ' Format Settings
      If ComboBoxCulture.SelectedIndex = 0 Then
         _appSettings.CultureCode = "id-ID"
      Else
         _appSettings.CultureCode = "en-US"
      End If

      _appSettings.CurrencySymbol = TextBoxCurrencySymbol.Text.Trim()
      _appSettings.DateFormat = TextBoxDateFormat.Text.Trim()

      ' Update other culture-related properties based on selection
      If _appSettings.CultureCode = "id-ID" Then
         _appSettings.CurrencyDecimalSeparator = ","
         _appSettings.CurrencyGroupSeparator = "."
         _appSettings.DateTimeFormat = _appSettings.DateFormat & " HH:mm"
      Else
         _appSettings.CurrencyDecimalSeparator = "."
         _appSettings.CurrencyGroupSeparator = ","
         _appSettings.DateTimeFormat = _appSettings.DateFormat & " HH:mm"
      End If

      ' Print Settings
      If ComboBoxOrientation.SelectedIndex = 0 Then
         _appSettings.DefaultPrintOrientation = "Portrait"
      Else
         _appSettings.DefaultPrintOrientation = "Landscape"
      End If

      _appSettings.PrintFontSize = CInt(NumericPrintFontSize.Value)
      _appSettings.EnableAlternatingRowColors = CheckBoxAlternatingRows.Checked

      ' UI Settings
      _appSettings.AutoLoadReportOnOpen = CheckBoxAutoLoadReport.Checked
      _appSettings.ConfirmBeforeDelete = CheckBoxConfirmDelete.Checked
   End Sub

   Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
      DialogResult = DialogResult.Cancel
      Close()
   End Sub

   Private Sub ButtonTest_Click(sender As Object, e As EventArgs) Handles ButtonTest.Click
      Try
         Dim testConfig As New ConfigModel(
            TextBoxServer.Text.Trim(),
            TextBoxDatabase.Text.Trim(),
            TextBoxUserId.Text.Trim(),
            TextBoxPassword.Text.Trim(),
            TextBoxPort.Text.Trim()
         )

         If _settingsManager.TestDatabaseConnection(testConfig) Then
            MessageBox.Show("✅ Connection successful!" & vbCrLf & vbCrLf &
                          $"Server: {testConfig.Server}" & vbCrLf &
                          $"Database: {testConfig.Database}",
                          "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show("❌ Connection failed!" & vbCrLf & vbCrLf &
                          "Please check your configuration.",
                          "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         MessageBox.Show($"❌ Connection failed!" & vbCrLf & vbCrLf &
                        $"Error: {ex.Message}",
                        "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub ButtonPasswordDemo_Click(sender As Object, e As EventArgs) Handles ButtonPasswordDemo.Click
      Dim passwordDemo As New FormPasswordDemo()
      passwordDemo.ShowDialog()
   End Sub

   Private Sub ButtonResetDefaults_Click(sender As Object, e As EventArgs) Handles ButtonResetDefaults.Click
      Dim result = MessageBox.Show(
         "Are you sure you want to reset all application settings to default?" & vbCrLf & vbCrLf &
         "Note: Database settings will NOT be changed.",
         "Reset to Defaults",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Question)

      If result = DialogResult.Yes Then
         _appSettings = New ApplicationSettings()
         _appSettings.ResetToDefaults()
         LoadApplicationSettings()

         MessageBox.Show("Application settings have been reset to defaults." & vbCrLf &
                        "Click SAVE to apply changes.",
                        "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub ComboBoxCulture_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCulture.SelectedIndexChanged
      ' Auto-update currency symbol and date format based on culture
      If ComboBoxCulture.SelectedIndex = 0 Then ' Indonesian
         TextBoxCurrencySymbol.Text = "Rp"
         TextBoxDateFormat.Text = "dd/MM/yyyy"
      Else ' English
         TextBoxCurrencySymbol.Text = "$"
         TextBoxDateFormat.Text = "MM/dd/yyyy"
      End If
   End Sub

End Class