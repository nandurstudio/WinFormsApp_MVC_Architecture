Imports System.IO
Imports System.Text.Json
Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers

Namespace Services
   ''' <summary>
   ''' Centralized Settings Manager for Database and Application Settings
   ''' Handles loading, saving, and accessing all application configurations
   ''' </summary>
   Public Class SettingsManager
      Private Shared _instance As SettingsManager
      Private Shared ReadOnly _lockObject As New Object()

      ' Settings instances
      Private _databaseConfig As ConfigModel
      Private _appSettings As ApplicationSettings

      ' File paths
      Private Const DatabaseConfigFile As String = "database_config.json"
      Private Const AppSettingsFile As String = "app_settings.json"

      ' Private constructor for singleton
      Private Sub New()
         LoadAllSettings()
      End Sub

      ''' <summary>
      ''' Get singleton instance
      ''' </summary>
      Public Shared Function GetInstance() As SettingsManager
         If _instance Is Nothing Then
            SyncLock _lockObject
               If _instance Is Nothing Then
                  _instance = New SettingsManager()
               End If
            End SyncLock
         End If
         Return _instance
      End Function

      ''' <summary>
      ''' Get Database Configuration
      ''' </summary>
      Public Function GetDatabaseConfig() As ConfigModel
         If _databaseConfig Is Nothing Then
            LoadDatabaseConfig()
         End If
         Return _databaseConfig
      End Function

      ''' <summary>
      ''' Get Application Settings
      ''' </summary>
      Public Function GetApplicationSettings() As ApplicationSettings
         If _appSettings Is Nothing Then
            LoadApplicationSettings()
         End If
         Return _appSettings
      End Function

      ''' <summary>
      ''' Save Database Configuration
      ''' </summary>
      Public Function SaveDatabaseConfig(config As ConfigModel) As Boolean
         Try
            Dim json As String = JsonSerializer.Serialize(config, New JsonSerializerOptions With {
               .WriteIndented = True
            })
            File.WriteAllText(DatabaseConfigFile, json)
            _databaseConfig = config
            Return True
         Catch ex As Exception
            Throw New Exception($"Failed to save database configuration: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Save Application Settings
      ''' </summary>
      Public Function SaveApplicationSettings(settings As ApplicationSettings) As Boolean
         Try
            Dim json As String = JsonSerializer.Serialize(settings, New JsonSerializerOptions With {
               .WriteIndented = True
            })
            File.WriteAllText(AppSettingsFile, json)
            _appSettings = settings

            ' Update singleton instance in ApplicationSettings
            Dim instance = ApplicationSettings.GetInstance()
            CopySettings(settings, instance)

            Return True
         Catch ex As Exception
            Throw New Exception($"Failed to save application settings: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Load all settings
      ''' </summary>
      Private Sub LoadAllSettings()
         LoadDatabaseConfig()
         LoadApplicationSettings()
      End Sub

      ''' <summary>
      ''' Load Database Configuration from file
      ''' </summary>
      Private Sub LoadDatabaseConfig()
         Try
            If File.Exists(DatabaseConfigFile) Then
               ' Load from JSON (new format)
               Dim json As String = File.ReadAllText(DatabaseConfigFile)
               _databaseConfig = JsonSerializer.Deserialize(Of ConfigModel)(json)
            ElseIf File.Exists("database_config.ini") OrElse File.Exists("setting.ini") Then
               ' Migrate from old INI format
               Dim settingController As New SettingController()
               _databaseConfig = settingController.LoadConfiguration()
               
               ' Save to new JSON format
               If _databaseConfig IsNot Nothing Then
                  SaveDatabaseConfig(_databaseConfig)
               End If
            Else
               ' Create default config
               _databaseConfig = New ConfigModel("localhost", "penjualan_visual_db", "root", "", "3306")
               SaveDatabaseConfig(_databaseConfig)
            End If
         Catch ex As Exception
            ' If error, use default
            _databaseConfig = New ConfigModel("localhost", "penjualan_visual_db", "root", "", "3306")
            Try
               SaveDatabaseConfig(_databaseConfig)
            Catch
               ' Ignore save error
            End Try
         End Try
      End Sub

      ''' <summary>
      ''' Load Application Settings from file
      ''' </summary>
      Private Sub LoadApplicationSettings()
         Try
            If File.Exists(AppSettingsFile) Then
               Dim json As String = File.ReadAllText(AppSettingsFile)
               _appSettings = JsonSerializer.Deserialize(Of ApplicationSettings)(json)
            Else
               ' Create default settings
               _appSettings = New ApplicationSettings()
            End If

            ' Update singleton instance
            Dim instance = ApplicationSettings.GetInstance()
            CopySettings(_appSettings, instance)

         Catch ex As Exception
            ' If error, use default
            _appSettings = New ApplicationSettings()
         End Try
      End Sub

      ''' <summary>
      ''' Copy settings from source to target
      ''' </summary>
      Private Sub CopySettings(source As ApplicationSettings, target As ApplicationSettings)
         target.CultureCode = source.CultureCode
         target.CurrencySymbol = source.CurrencySymbol
         target.CurrencyDecimalDigits = source.CurrencyDecimalDigits
         target.CurrencyDecimalSeparator = source.CurrencyDecimalSeparator
         target.CurrencyGroupSeparator = source.CurrencyGroupSeparator
         target.DateFormat = source.DateFormat
         target.DateTimeFormat = source.DateTimeFormat
         target.TimeFormat = source.TimeFormat

         target.DefaultPrintOrientation = source.DefaultPrintOrientation
         target.PrintFontName = source.PrintFontName
         target.PrintFontSize = source.PrintFontSize
         target.PrintHeaderFontSize = source.PrintHeaderFontSize
         target.EnableAlternatingRowColors = source.EnableAlternatingRowColors
         target.AlternatingRowColor = source.AlternatingRowColor
         target.HeaderBackColor = source.HeaderBackColor
         target.HeaderTextColor = source.HeaderTextColor

         target.CsvDelimiter = source.CsvDelimiter
         target.CsvIncludeHeaders = source.CsvIncludeHeaders
         target.CsvIncludeAppInfo = source.CsvIncludeAppInfo
         target.CsvIncludeSummary = source.CsvIncludeSummary

         target.DefaultGridRowHeight = source.DefaultGridRowHeight
         target.EnableGridAlternatingColors = source.EnableGridAlternatingColors
         target.ShowWelcomeMessage = source.ShowWelcomeMessage
         target.AutoRefreshReports = source.AutoRefreshReports
         target.ConfirmBeforeDelete = source.ConfirmBeforeDelete

         target.DefaultReportPeriod = source.DefaultReportPeriod
         target.MaxRowsPerPage = source.MaxRowsPerPage
         target.AutoLoadReportOnOpen = source.AutoLoadReportOnOpen
      End Sub

      ''' <summary>
      ''' Reset all settings to default
      ''' </summary>
      Public Function ResetAllToDefaults() As Boolean
         Try
            ' Reset application settings
            _appSettings = New ApplicationSettings()
            _appSettings.ResetToDefaults()
            SaveApplicationSettings(_appSettings)

            ' Database config is not reset for safety
            Return True
         Catch ex As Exception
            Return False
         End Try
      End Function

      ''' <summary>
      ''' Test database connection
      ''' </summary>
      Public Function TestDatabaseConnection() As Boolean
         Dim settingController As New SettingController()
         Return settingController.TestDatabaseConnection(_databaseConfig)
      End Function

      ''' <summary>
      ''' Test database connection with specific config
      ''' </summary>
      Public Function TestDatabaseConnection(config As ConfigModel) As Boolean
         Dim settingController As New SettingController()
         Return settingController.TestDatabaseConnection(config)
      End Function
   End Class
End Namespace
