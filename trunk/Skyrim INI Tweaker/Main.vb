Imports System.IO
Imports System.Math
Imports System.Environment
Imports System.Diagnostics.Process
Imports System.Windows.Forms

Public Class Main
    ' Initial load
    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        txtVersion.Text = "Version: " & BuildInfo.ProductVersion

        LoadInfo.All()
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

    ' Input checks
    Private Sub Main_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        ' Display tab
        AddHandler txt_iSizeW.TextChanged, AddressOf SanityChecks.CheckInput
        AddHandler txt_iSizeH.TextChanged, AddressOf SanityChecks.CheckInput
        AddHandler txt_iShadowMapResolution.TextChanged, AddressOf SanityChecks.CheckInput
        AddHandler txt_iShadowMapResolutionPrimary.TextChanged, AddressOf SanityChecks.CheckInput
        AddHandler txt_iShadowMapResolutionSecondary.TextChanged, AddressOf SanityChecks.CheckInput
        AddHandler txt_fShadowDistance.TextChanged, AddressOf SanityChecks.CheckInput
        AddHandler txt_fInteriorShadowDistance.TextChanged, AddressOf SanityChecks.CheckInput
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
End Class