Public Class ProfileManager_Rename
    Private Sub btn_RenameProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RenameProfile.Click
        ProfileManager.RenameProfile(txt_ProfileName.Text)
        Close()
    End Sub

    Private Sub btn_CancelRenameProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CancelRenameProfile.Click
        Close()
    End Sub

    Private Sub ProfileManager_New_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ProfileManager.NewProfileName = Nothing
        AcceptButton = btn_RenameProfile
    End Sub
End Class