Imports System.IO
Imports System.Text.RegularExpressions

Public Class ProfileManager
    Public NewProfileName As String
    Public CurrentProfile As String

    ' List profiles
    Private Sub GetProfiles()
        If Directory.Exists(INITweakerProfileDir & "Default") = False Then
            Directory.CreateDirectory(INITweakerProfileDir & "Default")
            CurrentProfile = "Default"
            TweakerINI.Save(INITweakerSettings)
        Else
            TweakerINI.Load(INITweakerSettings)
            CurrentProfile = TweakerINI.GetKeyValue("General", "Profile")
        End If

        Dim dirs As DirectoryInfo() = New DirectoryInfo(INITweakerProfileDir).GetDirectories
        Dim Profile
        cmb_ProfileList.Items.Clear()
        For Each Profile In dirs
            cmb_ProfileList.Items.Add(Profile.Name)
        Next
        cmb_ProfileList.SelectedItem = CurrentProfile
    End Sub

    ' Startup event
    Private Sub ProfileManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetProfiles()
    End Sub

    ' Button checking
    Private Sub CheckButtons()
        If cmb_ProfileList.SelectedItem = Nothing Then
            CriticalButtonsEnabled(False, False, False)
        ElseIf cmb_ProfileList.SelectedItem = CurrentProfile Then
            CriticalButtonsEnabled(False, False, False)
        ElseIf cmb_ProfileList.SelectedItem = "Default" Then
            CriticalButtonsEnabled(True, False, False)
        Else
            CriticalButtonsEnabled(True, True, True)
        End If
    End Sub

    ' Button toggling
    Private Sub CriticalButtonsEnabled(ByVal SelectButton As Boolean, ByVal RenameButton As Boolean, ByVal DeleteButton As Boolean)
        btn_SelectProfile.Enabled = SelectButton
        btn_RenameProfile.Enabled = RenameButton
        btn_DeleteProfile.Enabled = DeleteButton
    End Sub

    ' New profile
    Public Sub NewProfile(ByVal NewProfileName As String)
        If NewProfileName = Nothing Then
            MsgBox("You must enter a name!", MsgBoxStyle.Exclamation)
        Else
            If Regex.IsMatch(NewProfileName, "[(?*"",\\<>&#~%{}+_.@:\/!;]+") Then
                MsgBox("Invalid characters!", MsgBoxStyle.Exclamation)
            ElseIf Directory.Exists(INITweakerProfileDir & NewProfileName) Then
                MsgBox("A profile with this name already exists, choose another name.", MsgBoxStyle.Exclamation)
            Else
                Directory.CreateDirectory(INITweakerProfileDir & NewProfileName)
                File.Copy(SkyrimSettingsFolder & "Skyrim.ini", INITweakerProfileDir & NewProfileName & "\Skyrim.ini")
                File.Copy(SkyrimSettingsFolder & "SkyrimPrefs.ini", INITweakerProfileDir & NewProfileName & "\SkyrimPrefs.ini")
                GetProfiles()
            End If
        End If
    End Sub

    ' Rename profile
    Public Sub RenameProfile(ByVal NewProfileName As String)
        If NewProfileName = Nothing Then
            MsgBox("You must enter a name!", MsgBoxStyle.Exclamation)
        Else
            If Regex.IsMatch(NewProfileName, "[(?*"",\\<>&#~%{}+_.@:\/!;]+") Then
                MsgBox("Invalid characters!", MsgBoxStyle.Exclamation)
            ElseIf Directory.Exists(INITweakerProfileDir & NewProfileName) Then
                MsgBox("A profile with this name already exists, choose another name.", MsgBoxStyle.Exclamation)
            Else
                Directory.CreateDirectory(INITweakerProfileDir & NewProfileName)
                File.Move(INITweakerProfileDir & cmb_ProfileList.SelectedItem & "\Skyrim.ini", INITweakerProfileDir & NewProfileName & "\Skyrim.ini")
                File.Move(INITweakerProfileDir & cmb_ProfileList.SelectedItem & "\SkyrimPrefs.ini", INITweakerProfileDir & NewProfileName & "\SkyrimPrefs.ini")
                Directory.Delete(INITweakerProfileDir & cmb_ProfileList.SelectedItem)
                GetProfiles()
            End If
        End If
    End Sub

    ' ProfileList dropdown handler
    Private Sub cmb_ProfileList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ProfileList.SelectedValueChanged
        CheckButtons()
    End Sub

    ' SelectProfile button handler
    Private Sub btn_SelectProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SelectProfile.Click
        File.Move(SkyrimSettingsFolder & "Skyrim.ini", INITweakerProfileDir & CurrentProfile & "\Skyrim.ini")
        File.Move(SkyrimSettingsFolder & "SkyrimPrefs.ini", INITweakerProfileDir & CurrentProfile & "\SkyrimPrefs.ini")
        File.Move(INITweakerProfileDir & cmb_ProfileList.SelectedItem & "\Skyrim.ini", SkyrimSettingsFolder & "Skyrim.ini")
        File.Move(INITweakerProfileDir & cmb_ProfileList.SelectedItem & "\SkyrimPrefs.ini", SkyrimSettingsFolder & "SkyrimPrefs.ini")
        TweakerINI.SetKeyValue("General", "Profile", cmb_ProfileList.SelectedItem)
        TweakerINI.Save(INITweakerSettings)
        LoadInfo.All()
        Close()
    End Sub

    ' NewProfile button handler
    Private Sub btn_NewProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NewProfile.Click
        ProfileManager_New.ShowDialog()
    End Sub

    ' RenameProfile button handler
    Private Sub btn_RenameProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RenameProfile.Click
        ProfileManager_Rename.ShowDialog()
    End Sub

    ' DeleteProfile button handler
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
        End If
    End Sub
End Class