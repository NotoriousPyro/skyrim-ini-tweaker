Imports System.IO

Module SanityChecks
    Public Sub CheckDefaultINI(ByVal FileName As String)
        If File.Exists(SkyrimSettingsFolder & FileName) = False Then
            MsgBox(FileName & " not found in " & SkyrimSettingsFolder & _
                ControlChars.NewLine & _
                ControlChars.NewLine & _
                "Please ensure you've run the game at least once.", MsgBoxStyle.Critical)
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