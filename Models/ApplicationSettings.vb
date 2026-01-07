Imports System.Globalization

Namespace Models
   ''' <summary>
   ''' Application-wide settings and preferences
   ''' Centralized configuration for UI, formatting, and behavior
   ''' </summary>
   Public Class ApplicationSettings
      ' Culture & Formatting Settings
      Public Property CultureCode As String = "id-ID" ' Indonesian
      Public Property CurrencySymbol As String = "Rp"
      Public Property CurrencyDecimalDigits As Integer = 2
      Public Property CurrencyDecimalSeparator As String = ","
      Public Property CurrencyGroupSeparator As String = "."
      Public Property DateFormat As String = "dd/MM/yyyy"
      Public Property DateTimeFormat As String = "dd/MM/yyyy HH:mm"
      Public Property TimeFormat As String = "HH:mm"

      ' Print/Export Settings
      Public Property DefaultPrintOrientation As String = "Landscape" ' Portrait or Landscape
      Public Property PrintFontName As String = "Arial"
      Public Property PrintFontSize As Integer = 8
      Public Property PrintHeaderFontSize As Integer = 12
      Public Property EnableAlternatingRowColors As Boolean = True
      Public Property AlternatingRowColor As String = "#F0F0F0" ' Light gray
      Public Property HeaderBackColor As String = "#34495e" ' Dark blue
      Public Property HeaderTextColor As String = "#FFFFFF" ' White

      ' CSV Export Settings
      Public Property CsvDelimiter As String = ","
      Public Property CsvIncludeHeaders As Boolean = True
      Public Property CsvIncludeAppInfo As Boolean = True
      Public Property CsvIncludeSummary As Boolean = True

      ' UI Settings
      Public Property DefaultGridRowHeight As Integer = 25
      Public Property EnableGridAlternatingColors As Boolean = True
      Public Property ShowWelcomeMessage As Boolean = True
      Public Property AutoRefreshReports As Boolean = True
      Public Property ConfirmBeforeDelete As Boolean = True

      ' Report Settings
      Public Property DefaultReportPeriod As String = "CurrentMonth" ' Today, CurrentWeek, CurrentMonth, Custom
      Public Property MaxRowsPerPage As Integer = 50
      Public Property AutoLoadReportOnOpen As Boolean = True

      ' Shared Instance (Singleton)
      Private Shared _instance As ApplicationSettings
      Private Shared ReadOnly _lockObject As New Object()

      ''' <summary>
      ''' Get singleton instance of ApplicationSettings
      ''' </summary>
      Public Shared Function GetInstance() As ApplicationSettings
         If _instance Is Nothing Then
            SyncLock _lockObject
               If _instance Is Nothing Then
                  _instance = New ApplicationSettings()
               End If
            End SyncLock
         End If
         Return _instance
      End Function

      ''' <summary>
      ''' Get CultureInfo based on current settings
      ''' </summary>
      Public Function GetCultureInfo() As CultureInfo
         Dim culture As New CultureInfo(CultureCode)
         culture.NumberFormat.CurrencyDecimalDigits = CurrencyDecimalDigits
         culture.NumberFormat.CurrencyDecimalSeparator = CurrencyDecimalSeparator
         culture.NumberFormat.CurrencyGroupSeparator = CurrencyGroupSeparator
         culture.NumberFormat.CurrencySymbol = CurrencySymbol
         Return culture
      End Function

      ''' <summary>
      ''' Get Color from hex string
      ''' </summary>
      Public Shared Function GetColorFromHex(hexColor As String) As Color
         If hexColor.StartsWith("#") Then
            hexColor = hexColor.Substring(1)
         End If

         Dim r As Integer = Convert.ToInt32(hexColor.Substring(0, 2), 16)
         Dim g As Integer = Convert.ToInt32(hexColor.Substring(2, 2), 16)
         Dim b As Integer = Convert.ToInt32(hexColor.Substring(4, 2), 16)

         Return Color.FromArgb(r, g, b)
      End Function

      ''' <summary>
      ''' Reset to default values
      ''' </summary>
      Public Sub ResetToDefaults()
         CultureCode = "id-ID"
         CurrencySymbol = "Rp"
         CurrencyDecimalDigits = 2
         CurrencyDecimalSeparator = ","
         CurrencyGroupSeparator = "."
         DateFormat = "dd/MM/yyyy"
         DateTimeFormat = "dd/MM/yyyy HH:mm"
         TimeFormat = "HH:mm"

         DefaultPrintOrientation = "Landscape"
         PrintFontName = "Arial"
         PrintFontSize = 8
         PrintHeaderFontSize = 12
         EnableAlternatingRowColors = True
         AlternatingRowColor = "#F0F0F0"
         HeaderBackColor = "#34495e"
         HeaderTextColor = "#FFFFFF"

         CsvDelimiter = ","
         CsvIncludeHeaders = True
         CsvIncludeAppInfo = True
         CsvIncludeSummary = True

         DefaultGridRowHeight = 25
         EnableGridAlternatingColors = True
         ShowWelcomeMessage = True
         AutoRefreshReports = True
         ConfirmBeforeDelete = True

         DefaultReportPeriod = "CurrentMonth"
         MaxRowsPerPage = 50
         AutoLoadReportOnOpen = True
      End Sub
   End Class
End Namespace
