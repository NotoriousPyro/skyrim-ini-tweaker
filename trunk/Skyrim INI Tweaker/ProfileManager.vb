Imports System.IO
Imports System.Text.RegularExpressions

Public Class ProfileManager
    Public NewProfileName As String
    Private Sub GetProfiles()
        Dim dirs As DirectoryInfo() = New DirectoryInfo(INITweakerProfileDir).GetDirectories
        Dim Profile
        cmb_ProfileList.Items.Clear()
        For Each Profile In dirs
            cmb_ProfileList.Items.Add(Profile.Name)
        Next
    End Sub

    Private Sub ProfileManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetProfiles()
        TweakerINI.Load(INITweakerSettings)
        Dim CurrentProfile As String = TweakerINI.GetKeyValue("General", "Profile")
        cmb_ProfileList.SelectedItem = CurrentProfile
        If cmb_ProfileList.SelectedItem = String.Empty Then
            CriticalButtonsEnabled(False)
        End If
    End Sub

    Private Sub btn_SelectProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SelectProfile.Click
        Dim CurrentProfile As String = TweakerINI.GetKeyValue("General", "Profile")
        If Directory.Exists(INITweakerProfileDir & "Default") = False Then
            Directory.CreateDirectory(INITweakerProfileDir & "Default")
            CurrentProfile = "Default"
        End If
        File.Move(SkyrimSettingsFolder & "Skyrim.ini", INITweakerProfileDir & CurrentProfile & "\Skyrim.ini")
        File.Move(SkyrimSettingsFolder & "SkyrimPrefs.ini", INITweakerProfileDir & CurrentProfile & "\SkyrimPrefs.ini")
        File.Move(INITweakerProfileDir & cmb_ProfileList.SelectedItem & "\Skyrim.ini", SkyrimSettingsFolder & "Skyrim.ini")
        File.Move(INITweakerProfileDir & cmb_ProfileList.SelectedItem & "\SkyrimPrefs.ini", SkyrimSettingsFolder & "SkyrimPrefs.ini")
        TweakerINI.SetKeyValue("General", "Profile", cmb_ProfileList.SelectedItem)
        TweakerINI.Save(INITweakerSettings)
        LoadInfo.All()
        Close()
    End Sub

    Private Sub btn_NewProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NewProfile.Click
        ProfileManager_New.ShowDialog()
    End Sub

    Public Sub MakeProfile(ByVal NewProfileName As String)
        If NewProfileName = "" Then
            MsgBox("You must enter a name!", MsgBoxStyle.Exclamation)
        Else
            If Directory.Exists(INITweakerProfileDir & NewProfileName) Then
                MsgBox("This profile already exists, choose another name.", MsgBoxStyle.Exclamation)
            ElseIf Regex.IsMatch(NewProfileName, "[(?*"",\\<>&#~%{}+_.@:\/!;]+") Then
                MsgBox("Invalid characters!", MsgBoxStyle.Exclamation)
            Else
                Directory.CreateDirectory(INITweakerProfileDir & NewProfileName)
                File.Copy(SkyrimSettingsFolder & "Skyrim.ini", INITweakerProfileDir & NewProfileName & "\Skyrim.ini")
                File.Copy(SkyrimSettingsFolder & "SkyrimPrefs.ini", INITweakerProfileDir & NewProfileName & "\SkyrimPrefs.ini")
                GetProfiles()
                Dim CurrentProfile As String = TweakerINI.GetKeyValue("General", "Profile")
                cmb_ProfileList.SelectedItem = CurrentProfile
            End If
        End If
    End Sub

    Private Sub btn_RenameProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RenameProfile.Click
        MsgBox("Not implemented yet")
    End Sub

    Private Sub btn_DeleteProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DeleteProfile.Click
        Dim ConfirmDelete = MsgBox("Are you sure you wish to delete that profile?" & _
                                   ControlChars.NewLine & _
                                   ControlChars.NewLine & _
                                   "This action cannot be undone!", MsgBoxStyle.YesNo)
        If ConfirmDelete = 6 Then
            File.Delete(INITweakerProfileDir & cmb_ProfileList.SelectedItem & "\Skyrim.ini")
            File.Delete(INITweakerProfileDir & cmb_ProfileList.SelectedItem & "\SkyrimPrefs.ini")
            Directory.Delete(INITweakerProfileDir & cmb_ProfileList.SelectedItem)
            GetProfiles()
            Dim CurrentProfile As String = TweakerINI.GetKeyValue("General", "Profile")
            cmb_ProfileList.SelectedItem = CurrentProfile
        End If
    End Sub

    Private Sub cmb_ProfileList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ProfileList.SelectedValueChanged
        Dim CurrentProfile As String = TweakerINI.GetKeyValue("General", "Profile")
        If cmb_ProfileList.SelectedItem = CurrentProfile Then
            CriticalButtonsEnabled(False)
        ElseIf cmb_ProfileList.SelectedItem = "Default" Then
            btn_SelectProfile.Enabled = True
            btn_RenameProfile.Enabled = False
            btn_DeleteProfile.Enabled = False
        Else
            CriticalButtonsEnabled(True)
        End If
    End Sub

    Private Sub CriticalButtonsEnabled(ByVal Type As Boolean)
        If Type = True Then
            btn_SelectProfile.Enabled = True
            btn_RenameProfile.Enabled = True
            btn_DeleteProfile.Enabled = True
        Else
            btn_SelectProfile.Enabled = False
            btn_RenameProfile.Enabled = False
            btn_DeleteProfile.Enabled = False
        End If
    End Sub
End Class