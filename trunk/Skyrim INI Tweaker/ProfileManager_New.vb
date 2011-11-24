Public Class ProfileManager_New
    Private Sub btn_CreateProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CreateProfile.Click
        ProfileManager.NewProfile(txt_ProfileName.Text)
        Close()
    End Sub

    Private Sub btn_CancelCreateProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CancelCreateProfile.Click
        Close()
    End Sub

    Private Sub ProfileManager_New_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ProfileManager.NewProfileName = Nothing
        AcceptButton = btn_CreateProfile
    End Sub
End Class