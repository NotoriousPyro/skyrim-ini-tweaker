Module LoadInfo
    ' Loading
    Public Function All()
        Try
            ' Check the file exists and load it
            SanityChecks.CheckDefaultINI("Skyrim.ini")
            SanityChecks.CheckDefaultINI("SkyrimPrefs.ini")
            SkyrimINI.Load(SkyrimSettingsFolder & "Skyrim.ini")
            SkyrimPrefsINI.Load(SkyrimSettingsFolder & "SkyrimPrefs.ini")

            ' Load the info into the program
            GeneralTabLoad()
            GraphicsTabLoad()
            GameplayTabLoad()
            AdvancedTabLoad()
            Return True
        Catch
            Return False
        End Try
    End Function

    ' General tab Load
    Private Sub GeneralTabLoad()
        ' Main [General]
        Main.txt_sLanguage.Text = SkyrimINI.GetKeyValue("General", "sLanguage")
        Main.txt_uInteriorCellBuffer.Text = SkyrimINI.GetKeyValue("General", "uInterior Cell Buffer")
        Main.txt_uExteriorCellBuffer.Text = SkyrimINI.GetKeyValue("General", "uExterior Cell Buffer")

        ' Main [MAIN]
        Main.chk_bGamepadEnable.Checked = SkyrimPrefsINI.GetKeyValue("MAIN", "bGamepadEnable", "bool")

        ' Subtitles [Interface]
        Main.chk_bGeneralSubtitles.Checked = SkyrimPrefsINI.GetKeyValue("Interface", "bGeneralSubtitles", "bool")
        Main.chk_bDialogueSubtitles.Checked = SkyrimPrefsINI.GetKeyValue("Interface", "bDialogueSubtitles", "bool")
    End Sub

    ' Graphics tab Load
    Private Sub GraphicsTabLoad()
        ' Main [Display]
        Main.txt_iSizeW.Text = SkyrimPrefsINI.GetKeyValue("Display", "iSize W")
        Main.txt_iSizeH.Text = SkyrimPrefsINI.GetKeyValue("Display", "iSize H")
        Main.chk_bFullScreen.Checked = SkyrimPrefsINI.GetKeyValue("Display", "bFull Screen", "bool")
        Dim iAnisotropy As Int16 = SkyrimPrefsINI.GetKeyValue("Display", "iMaxAnisotropy")
        Select Case iAnisotropy
            Case 0
                Main.cmb_iMaxAnisotropy.SelectedItem = "Off"
            Case 2
                Main.cmb_iMaxAnisotropy.SelectedItem = "2x"
            Case 4
                Main.cmb_iMaxAnisotropy.SelectedItem = "4x"
            Case 8
                Main.cmb_iMaxAnisotropy.SelectedItem = "8x"
            Case 12
                Main.cmb_iMaxAnisotropy.SelectedItem = "12x"
            Case 16
                Main.cmb_iMaxAnisotropy.SelectedItem = "16x"
        End Select

        Dim iMultiSample As Int16 = SkyrimPrefsINI.GetKeyValue("Display", "iMultiSample")
        Select Case iMultiSample
            Case 0
                Main.cmb_iMultiSample.SelectedItem = "Off"
            Case 2
                Main.cmb_iMultiSample.SelectedItem = "2x"
            Case 4
                Main.cmb_iMultiSample.SelectedItem = "4x"
            Case 8
                Main.cmb_iMultiSample.SelectedItem = "8x"
        End Select
        Main.chk_bFXAAEnabled.Checked = SkyrimPrefsINI.GetKeyValue("Display", "bFXAAEnabled", "bool")
        Main.chk_bTransparencyMultisampling.Checked = SkyrimPrefsINI.GetKeyValue("Display", "bTransparencyMultisampling", "bool")

        If SkyrimINI.GetKeyValue("Display", "iPresentInterval", "bool") = False Then
            SkyrimINI.SetKeyValue("Display", "iPresentInterval", 1)
        End If
        Main.chk_iPresentInterval.Checked = SkyrimINI.GetKeyValue("Display", "iPresentInterval", "bool")

        ' Shadows Tab [Display]
        Main.chk_bDrawShadows.Checked = SkyrimPrefsINI.GetKeyValue("Display", "bDrawShadows", "bool")
        ' Shadow map resolution
        Main.txt_iShadowMapResolution.Text = SkyrimPrefsINI.GetKeyValue("Display", "iShadowMapResolution")
        Main.txt_iShadowMapResolutionPrimary.Text = SkyrimPrefsINI.GetKeyValue("Display", "iShadowMapResolutionPrimary")
        Main.txt_iShadowMapResolutionSecondary.Text = SkyrimPrefsINI.GetKeyValue("Display", "iShadowMapResolutionSecondary")
        ' Self-shadowing
        Main.chk_bTreesReceiveShadows.Checked = SkyrimPrefsINI.GetKeyValue("Display", "bTreesReceiveShadows", "bool")
        Main.chk_bDrawLandShadows.Checked = SkyrimPrefsINI.GetKeyValue("Display", "bDrawLandShadows", "bool")
        Main.chk_bShadowsOnGrass.Checked = SkyrimINI.GetKeyValue("Display", "bShadowsOnGrass", "bool")
        Main.chk_bActorSelfShadowing.Checked = SkyrimINI.GetKeyValue("Display", "bActorSelfShadowing", "bool")
        Main.chk_bEquippedTorchesCastShadows.Checked = SkyrimINI.GetKeyValue("Display", "bEquippedTorchesCastShadows", "bool")
        ' Shadow distance
        Main.txt_fShadowDistance.Text = SkyrimPrefsINI.GetKeyValue("Display", "fShadowDistance")
        Main.txt_fInteriorShadowDistance.Text = SkyrimPrefsINI.GetKeyValue("Display", "fInteriorShadowDistance")
        ' Shadow LOD
        Main.txt_fShadowLODStartFade.Text = SkyrimPrefsINI.GetKeyValue("Display", "fShadowLODStartFade")
        Main.txt_fShadowLODMinStartFade.Text = SkyrimINI.GetKeyValue("Display", "fShadowLODMinStartFade")
        Main.txt_fShadowLODMaxStartFade.Text = SkyrimINI.GetKeyValue("Display", "fShadowLODMaxStartFade")
        Main.txt_fShadowLODRange.Text = SkyrimINI.GetKeyValue("Display", "fShadowLODRange")

        Main.cmb_iBlurDeferredShadowMask.SelectedItem = SkyrimPrefsINI.GetKeyValue("Display", "iBlurDeferredShadowMask")
        Main.txt_fShadowBiasScale.Text = SkyrimPrefsINI.GetKeyValue("Display", "fShadowBiasScale")
        Main.txt_iShadowMaskQuarter.Text = SkyrimPrefsINI.GetKeyValue("Display", "iShadowMaskQuarter")
        Main.txt_iShadowMode.Text = SkyrimPrefsINI.GetKeyValue("Display", "iShadowMode")
        Main.txt_iShadowFilter.Text = SkyrimPrefsINI.GetKeyValue("Display", "iShadowFilter")
        Main.txt_iShadowSplitCount.Text = SkyrimPrefsINI.GetKeyValue("Display", "iShadowSplitCount")
        Main.chk_bShadowMaskZPrepass.Checked = SkyrimPrefsINI.GetKeyValue("Display", "bShadowMaskZPrepass", "bool")

        ' Mesh Tab [Display]
        Main.txt_fMeshLODFadeBoundDefault.Text = SkyrimPrefsINI.GetKeyValue("Display", "fMeshLODFadeBoundDefault")
        Main.txt_fMeshLODLevel1FadeDist.Text = SkyrimPrefsINI.GetKeyValue("Display", "fMeshLODLevel1FadeDist")
        Main.txt_fMeshLODLevel2FadeDist.Text = SkyrimPrefsINI.GetKeyValue("Display", "fMeshLODLevel2FadeDist")
        Main.txt_fMeshLODLevel1FadeTreeDistance.Text = SkyrimPrefsINI.GetKeyValue("Display", "fMeshLODLevel1FadeTreeDistance")
        Main.txt_fMeshLODLevel2FadeTreeDistance.Text = SkyrimPrefsINI.GetKeyValue("Display", "fMeshLODLevel2FadeTreeDistance")

        ' Grass Tab [Grass]
        Main.chk_b30GrassVS.Checked = SkyrimPrefsINI.GetKeyValue("Grass", "b30GrassVS", "bool")
        Main.txt_fGrassStartFadeDistance.Text = SkyrimPrefsINI.GetKeyValue("Grass", "fGrassStartFadeDistance")
        Main.txt_fGrassMinStartFadeDistance.Text = SkyrimPrefsINI.GetKeyValue("Grass", "fGrassMinStartFadeDistance")
        Main.txt_fGrassMaxStartFadeDistance.Text = SkyrimPrefsINI.GetKeyValue("Grass", "fGrassMaxStartFadeDistance")
    End Sub

    ' Gameplay tab Load
    Private Sub GameplayTabLoad()
        ' Main [GamePlay]
        Dim iDifficulty As Int16 = SkyrimPrefsINI.GetKeyValue("GamePlay", "iDifficulty")
        Select Case iDifficulty
            Case 0
                Main.cmb_iDifficulty.SelectedItem = "Novice"
            Case 1
                Main.cmb_iDifficulty.SelectedItem = "Apprentice"
            Case 2
                Main.cmb_iDifficulty.SelectedItem = "Adept"
            Case 3
                Main.cmb_iDifficulty.SelectedItem = "Expert"
            Case 4
                Main.cmb_iDifficulty.SelectedItem = "Master"
        End Select
        Main.chk_bShowQuestMarkers.Checked = SkyrimPrefsINI.GetKeyValue("GamePlay", "bShowQuestMarkers", "bool")
        Main.chk_bShowFloatingQuestMarkers.Checked = SkyrimPrefsINI.GetKeyValue("GamePlay", "bShowFloatingQuestMarkers", "bool")

        ' Main [MAIN]
        Main.chk_bCrosshairEnabled.Checked = SkyrimPrefsINI.GetKeyValue("MAIN", "bCrosshairEnabled", "bool")

        ' Main [Interface]
        Main.chk_bShowCompass.Checked = SkyrimPrefsINI.GetKeyValue("Interface", "bShowCompass", "bool")

        ' Save on [SaveGame]
        If SkyrimPrefsINI.GetKeyValue("SaveGame", "fAutoSaveEveryXMins") Is String.Empty Then
            Main.cmb_fAutosaveEveryXMins.SelectedItem = "15"
        Else
            Main.cmb_fAutosaveEveryXMins.SelectedItem = Str(SkyrimPrefsINI.GetKeyValue("SaveGame", "fAutosaveEveryXMins")).Trim
        End If

        ' Save on [MAIN]
        Main.chk_bSaveOnPause.Checked = SkyrimPrefsINI.GetKeyValue("MAIN", "bSaveOnPause", "bool")
        Main.chk_bSaveOnWait.Checked = SkyrimPrefsINI.GetKeyValue("MAIN", "bSaveOnWait", "bool")
        Main.chk_bSaveOnRest.Checked = SkyrimPrefsINI.GetKeyValue("MAIN", "bSaveOnRest", "bool")
        Main.chk_bSaveOnTravel.Checked = SkyrimPrefsINI.GetKeyValue("MAIN", "bSaveOnTravel", "bool")
    End Sub

    ' Advanced tab Load
    Private Sub AdvancedTabLoad()
        ' Main [Papyrus]
        Main.txt_iMinMemoryPageSize.Text = SkyrimINI.GetKeyValue("Papyrus", "iMinMemoryPageSize")
        Main.txt_iMaxMemoryPageSize.Text = SkyrimINI.GetKeyValue("Papyrus", "iMaxMemoryPageSize")
        Main.txt_iMaxAllocatedMemoryBytes.Text = SkyrimINI.GetKeyValue("Papyrus", "iMaxAllocatedMemoryBytes")

        ' Threading [General]
        If SkyrimINI.GetKeyValue("General", "bMultiThreadMovement", "bool") = False Then
            SkyrimINI.SetKeyValue("General", "bMultiThreadMovement", "1")
        End If
        Main.chk_bMultiThreadMovement.Checked = SkyrimINI.GetKeyValue("General", "bMultiThreadMovement", "bool")
        If SkyrimINI.GetKeyValue("General", "bUseThreadedTempEffects", "bool") = False Then
            SkyrimINI.SetKeyValue("General", "bUseThreadedTempEffects", "1")
        End If
        Main.chk_bUseThreadedTempEffects.Checked = SkyrimINI.GetKeyValue("General", "bUseThreadedTempEffects", "bool")
        Main.chk_bUseThreadedParticleSystem.Checked = SkyrimINI.GetKeyValue("General", "bUseThreadedParticleSystem", "bool")
        Main.chk_bUseThreadedMorpher.Checked = SkyrimINI.GetKeyValue("General", "bUseThreadedMorpher", "bool")

        ' Threading [Decals]
        Main.chk_bDecalMultithreaded.Checked = SkyrimINI.GetKeyValue("Decals", "bDecalMultithreaded", "bool")

        ' Threading [BackgroundLoad]
        If SkyrimINI.GetKeyValue("BackgroundLoad", "bUseMultiThreadedTrees", "bool") = False Then
            SkyrimINI.SetKeyValue("BackgroundLoad", "bUseMultiThreadedTrees", "1")
        End If
        Main.chk_bUseMultiThreadedTrees.Checked = SkyrimINI.GetKeyValue("BackgroundLoad", "bUseMultiThreadedTrees", "bool")
        If SkyrimINI.GetKeyValue("BackgroundLoad", "bUseMultiThreadedFaceGen", "bool") = False Then
            SkyrimINI.SetKeyValue("BackgroundLoad", "bUseMultiThreadedFaceGen", "1")
        End If
        Main.chk_bUseMultiThreadedFaceGen.Checked = SkyrimINI.GetKeyValue("BackgroundLoad", "bUseMultiThreadedFaceGen", "bool")

        ' Threading [Animation]
        If SkyrimINI.GetKeyValue("Animation", "bMultiThreadBoneUpdate", "bool") = False Then
            SkyrimINI.SetKeyValue("Animation", "bMultiThreadBoneUpdate", "1")
        End If
        Main.chk_bMultiThreadBoneUpdate.Checked = SkyrimINI.GetKeyValue("Animation", "bMultiThreadBoneUpdate", "bool")

        ' Threading [HAVOK]
        Main.txt_iNumThreads.Text = SkyrimINI.GetKeyValue("HAVOK", "iNumThreads")
    End Sub
End Module