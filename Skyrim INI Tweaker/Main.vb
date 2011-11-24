Imports System.IO
Imports System.Environment
Imports System.Diagnostics.Process

Module Constructor
    Dim Documents As String = GetFolderPath(SpecialFolder.MyDocuments)
    Public SkyrimSettingsFolder As String = Documents & "\My Games\Skyrim\"
    Public INITweakerDir As String = SkyrimSettingsFolder & "INITweaker\"
    Public INITweakerProfileDir As String = INITweakerDir & "Profiles\"
    Public INITweakerSettings As String = INITweakerDir & "INITweaker.ini"

    Public SkyrimINI As New IniFile
    Public SkyrimPrefsINI As New IniFile
    Public TweakerINI As New IniFile
End Module

Public Class Main
    ' Startup event
    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        txtVersion.Text = "Version: " & BuildInfo.ProductVersion

        CreateInitialDirectories()
        CreateInitialINI()
        LoadInfo.All()
        InputChecks.All()
    End Sub

    ' Initial INITweaker directory creation
    Private Sub CreateInitialDirectories()
        If Directory.Exists(INITweakerDir) = False Then
            Directory.CreateDirectory(INITweakerDir)
        End If
        If Directory.Exists(INITweakerProfileDir) = False Then
            Directory.CreateDirectory(INITweakerProfileDir)
        End If
    End Sub

    ' Initial INITweaker.ini creation
    Private Sub CreateInitialINI()
        If File.Exists(INITweakerSettings) = False Then
            TweakerINI.SetKeyValue("General", "Profile", "Default")
            TweakerINI.Save(INITweakerSettings)
        End If
    End Sub

    ' VSync toggle warning
    Private Sub chk_iPresentInterval_Toggle(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_iPresentInterval.Click
        If chk_iPresentInterval.Checked = False Then
            Dim WarningMessage As Object = MsgBox("Warning, disabling VSync may cause some serious issues with timing." & _
                ControlChars.NewLine & "Are you sure you wish to continue?", MsgBoxStyle.YesNo)
            If WarningMessage = 6 Then
                chk_iPresentInterval.Checked = False
            Else
                chk_iPresentInterval.Checked = True
            End If
        End If
    End Sub

    ' Button - Apply
    Private Sub btn_Apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Apply.Click
        If SaveInfo.All() = True Then
            StatusMessage.Show("Applied!", btn_Apply)
        End If
    End Sub

    Private Sub btn_Apply_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Apply.MouseLeave
        StatusMessage.Hide(btn_Apply)
    End Sub

    ' Button - Reload
    Private Sub btn_Reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reload.Click
        If LoadInfo.All() = True Then
            StatusMessage.Show("Reloaded!", btn_Reload)
        End If
    End Sub

    Private Sub btn_Reload_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reload.MouseLeave
        StatusMessage.Hide(btn_Reload)
    End Sub

    ' PyroNetwork link
    Private Sub lnkPyroNetwork_LinkClicked(ByVal sender As System.Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lnkPyroNetwork.LinkClicked
        Start("http://pyronet.tv")
    End Sub

    Private Sub btn_ProfileManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ProfileManager.Click
        ProfileManager.ShowDialog()
    End Sub
End Class