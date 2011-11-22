Imports System.IO
Imports System.Environment

Module SanityChecks
    Dim Documents As String = GetFolderPath(SpecialFolder.MyDocuments)
    Public SkyrimSettingsFolder As String = Documents & "\My Games\Skyrim\"
    Public SkyrimINI As New IniFile
    Public SkyrimPrefsINI As New IniFile

    Public Sub CheckFileExists(ByVal FileName As String)
        If File.Exists(SkyrimSettingsFolder & FileName) = False Then
            MsgBox(FileName & " not found in " & SkyrimSettingsFolder & _
                   ControlChars.NewLine & _
                   ControlChars.NewLine & _
                   "Please ensure you've run the game at least once.")
            End
        End If
    End Sub

    Public Sub CheckInput(ByVal Sender As Object, ByVal e As EventArgs)
        If Sender.Text = String.Empty Then
            Main.btn_Apply.Enabled = False
        Else
            Main.btn_Apply.Enabled = True
        End If
    End Sub
End Module