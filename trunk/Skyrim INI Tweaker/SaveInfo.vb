Module SaveInfo
    ' Saving
    Public Function All()
        Try
            ' Prepare the changes
            GeneralTabSave()
            GraphicsTabSave()
            GameplayTabSave()
            AdvancedTabSave()

            ' Save the files
            CheckDefaultINI("Skyrim.ini")
            CheckDefaultINI("SkyrimPrefs.ini")
            SkyrimINI.Save(SkyrimSettingsFolder & "Skyrim.ini")
            SkyrimPrefsINI.Save(SkyrimSettingsFolder & "SkyrimPrefs.ini")
            Return True
        Catch
            Return False
        End Try
    End Function

    ' General tab Save
    Private Sub GeneralTabSave()
        ' Main [General]
        SkyrimINI.SetKeyValue("General", "sLanguage", Main.txt_sLanguage.Text)
        SkyrimINI.SetKeyValue("General", "uInterior Cell Buffer", Main.txt_uInteriorCellBuffer.Text)
        SkyrimINI.SetKeyValue("General", "uExterior Cell Buffer", Main.txt_uExteriorCellBuffer.Text)

        ' Main [MAIN]
        SkyrimPrefsINI.SetKeyValue("MAIN", "bGamepadEnable", CInt(Main.chk_bGamepadEnable.Checked))

        ' Subtitles [Interface]
        SkyrimPrefsINI.SetKeyValue("Interface", "bGeneralSubtitles", CInt(Main.chk_bGeneralSubtitles.Checked))
        SkyrimPrefsINI.SetKeyValue("Interface", "bDialogueSubtitles", CInt(Main.chk_bDialogueSubtitles.Checked))
    End Sub

    ' Graphics tab Save
    Private Sub GraphicsTabSave()
        ' Main [Display]
        SkyrimPrefsINI.SetKeyValue("Display", "iSize W", Main.txt_iSizeW.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "iSize H", Main.txt_iSizeH.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "bFull Screen", CInt(Main.chk_bFullScreen.Checked))
        Dim iAnisotropy As String = Main.cmb_iMaxAnisotropy.SelectedItem
        Select Case iAnisotropy
            Case "Off"
                SkyrimPrefsINI.SetKeyValue("Display", "iMaxAnisotropy", 0)
            Case "2x"
                SkyrimPrefsINI.SetKeyValue("Display", "iMaxAnisotropy", 2)
            Case "4x"
                SkyrimPrefsINI.SetKeyValue("Display", "iMaxAnisotropy", 4)
            Case "8x"
                SkyrimPrefsINI.SetKeyValue("Display", "iMaxAnisotropy", 8)
            Case "12x"
                SkyrimPrefsINI.SetKeyValue("Display", "iMaxAnisotropy", 12)
            Case "16x"
                SkyrimPrefsINI.SetKeyValue("Display", "iMaxAnisotropy", 16)
        End Select

        Dim iMultiSample As String = Main.cmb_iMultiSample.SelectedItem
        Select Case iMultiSample
            Case "Off"
                SkyrimPrefsINI.SetKeyValue("Display", "iMultiSample", 0)
            Case "2x"
                SkyrimPrefsINI.SetKeyValue("Display", "iMultiSample", 2)
            Case "4x"
                SkyrimPrefsINI.SetKeyValue("Display", "iMultiSample", 4)
            Case "8x"
                SkyrimPrefsINI.SetKeyValue("Display", "iMultiSample", 8)
        End Select
        SkyrimPrefsINI.SetKeyValue("Display", "bFXAAEnabled", CInt(Main.chk_bFXAAEnabled.Checked))
        SkyrimPrefsINI.SetKeyValue("Display", "bTransparencyMultisampling", CInt(Main.chk_bTransparencyMultisampling.Checked))

        If Main.chk_iPresentInterval.Checked = True Then
            SkyrimINI.SetKeyValue("Display", "iPresentInterval", 1)
        Else
            SkyrimINI.SetKeyValue("Display", "iPresentInterval", 0)
        End If

        ' Shadows tab [Display]
        SkyrimPrefsINI.SetKeyValue("Display", "bDrawShadows", CInt(Main.chk_bDrawShadows.Checked))
        ' Shadow map resolution
        SkyrimPrefsINI.SetKeyValue("Display", "iShadowMapResolution", Main.txt_iShadowMapResolution.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "iShadowMapResolutionPrimary", Main.txt_iShadowMapResolutionPrimary.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "iShadowMapResolutionSecondary", Main.txt_iShadowMapResolutionSecondary.Text)
        ' Self-shadowing
        SkyrimPrefsINI.SetKeyValue("Display", "bTreesReceiveShadows", CInt(Main.chk_bTreesReceiveShadows.Checked))
        SkyrimPrefsINI.SetKeyValue("Display", "bDrawLandShadows", CInt(Main.chk_bDrawLandShadows.Checked))
        SkyrimINI.SetKeyValue("Display", "bShadowsOnGrass", CInt(Main.chk_bShadowsOnGrass.Checked))
        SkyrimINI.SetKeyValue("Display", "bActorSelfShadowing", CInt(Main.chk_bActorSelfShadowing.Checked))
        SkyrimINI.SetKeyValue("Display", "bEquippedTorchesCastShadows", CInt(Main.chk_bEquippedTorchesCastShadows.Checked))
        ' Shadow distance
        SkyrimPrefsINI.SetKeyValue("Display", "fShadowDistance", Main.txt_fShadowDistance.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "fInteriorShadowDistance", Main.txt_fInteriorShadowDistance.Text)
        ' Shadow LOD
        SkyrimPrefsINI.SetKeyValue("Display", "fShadowLODStartFade", Main.txt_fShadowLODStartFade.Text)
        SkyrimINI.SetKeyValue("Display", "fShadowLODMinStartFade", Main.txt_fShadowLODMinStartFade.Text)
        SkyrimINI.SetKeyValue("Display", "fShadowLODMaxStartFade", Main.txt_fShadowLODMaxStartFade.Text)
        SkyrimINI.SetKeyValue("Display", "fShadowLODRange", Main.txt_fShadowLODRange.Text)

        SkyrimPrefsINI.SetKeyValue("Display", "iBlurDeferredShadowMask", Main.cmb_iBlurDeferredShadowMask.SelectedItem)
        SkyrimPrefsINI.SetKeyValue("Display", "fShadowBiasScale", Main.txt_fShadowBiasScale.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "iShadowMaskQuarter", Main.txt_iShadowMaskQuarter.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "iShadowMode", Main.txt_iShadowMode.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "iShadowFilter", Main.txt_iShadowFilter.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "iShadowSplitCount", Main.txt_iShadowSplitCount.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "bShadowMaskZPrepass", CInt(Main.chk_bShadowMaskZPrepass.Checked))

        ' Mesh tab [Display]
        SkyrimPrefsINI.SetKeyValue("Display", "fMeshLODFadeBoundDefault", Main.txt_fMeshLODFadeBoundDefault.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "fMeshLODLevel1FadeDist", Main.txt_fMeshLODLevel1FadeDist.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "fMeshLODLevel2FadeDist", Main.txt_fMeshLODLevel2FadeDist.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "fMeshLODLevel1FadeTreeDistance", Main.txt_fMeshLODLevel1FadeTreeDistance.Text)
        SkyrimPrefsINI.SetKeyValue("Display", "fMeshLODLevel2FadeTreeDistance", Main.txt_fMeshLODLevel2FadeTreeDistance.Text)

        ' Grass tab [Grass]
        SkyrimPrefsINI.SetKeyValue("Grass", "b30GrassVS", CInt(Main.chk_b30GrassVS.Checked))
        SkyrimPrefsINI.SetKeyValue("Grass", "fGrassStartFadeDistance", Main.txt_fGrassStartFadeDistance.Text)
        SkyrimPrefsINI.SetKeyValue("Grass", "fGrassMinStartFadeDistance", Main.txt_fGrassMinStartFadeDistance.Text)
        SkyrimPrefsINI.SetKeyValue("Grass", "fGrassMaxStartFadeDistance", Main.txt_fGrassMaxStartFadeDistance.Text)
    End Sub

    ' Gameplay tab Save
    Private Sub GameplayTabSave()
        ' Main [GamePlay]
        Dim iDifficulty As String = Main.cmb_iDifficulty.SelectedItem
        Select Case iDifficulty
            Case "Novice"
                SkyrimPrefsINI.SetKeyValue("GamePlay", "iDifficulty", 0)
            Case "Apprentice"
                SkyrimPrefsINI.SetKeyValue("GamePlay", "iDifficulty", 1)
            Case "Adept"
                SkyrimPrefsINI.SetKeyValue("GamePlay", "iDifficulty", 2)
            Case "Expert"
                SkyrimPrefsINI.SetKeyValue("GamePlay", "iDifficulty", 3)
            Case "Master"
                SkyrimPrefsINI.SetKeyValue("GamePlay", "iDifficulty", 4)
        End Select
        SkyrimPrefsINI.SetKeyValue("GamePlay", "bShowQuestMarkers", CInt(Main.chk_bShowQuestMarkers.Checked))
        SkyrimPrefsINI.SetKeyValue("GamePlay", "bShowFloatingQuestMarkers", CInt(Main.chk_bShowFloatingQuestMarkers.Checked))

        ' Main [MAIN]
        SkyrimPrefsINI.SetKeyValue("MAIN", "bCrosshairEnabled", CInt(Main.chk_bCrosshairEnabled.Checked))

        ' Main [Interface]
        SkyrimPrefsINI.SetKeyValue("Interface", "bShowCompass", CInt(Main.chk_bShowCompass.Checked))

        ' Save on [SaveGame]
        SkyrimPrefsINI.SetKeyValue("SaveGame", "fAutoSaveEveryXMins", Main.cmb_fAutosaveEveryXMins.SelectedItem)

        ' Save on [MAIN]
        SkyrimPrefsINI.SetKeyValue("MAIN", "bSaveOnPause", CInt(Main.chk_bSaveOnPause.Checked))
        SkyrimPrefsINI.SetKeyValue("MAIN", "bSaveOnWait", CInt(Main.chk_bSaveOnWait.Checked))
        SkyrimPrefsINI.SetKeyValue("MAIN", "bSaveOnRest", CInt(Main.chk_bSaveOnRest.Checked))
        SkyrimPrefsINI.SetKeyValue("MAIN", "bSaveOnTravel", CInt(Main.chk_bSaveOnTravel.Checked))
    End Sub

    ' Advanced tab Save
    Private Sub AdvancedTabSave()
        ' Main [Papyrus]
        SkyrimINI.SetKeyValue("Papyrus", "iMinMemoryPageSize", Main.txt_iMinMemoryPageSize.Text)
        SkyrimINI.SetKeyValue("Papyrus", "iMaxMemoryPageSize", Main.txt_iMaxMemoryPageSize.Text)
        SkyrimINI.SetKeyValue("Papyrus", "iMaxAllocatedMemoryBytes", Main.txt_iMaxAllocatedMemoryBytes.Text)

        ' Threading [General]
        SkyrimINI.SetKeyValue("General", "bMultiThreadMovement", CInt(Main.chk_bMultiThreadMovement.Checked))
        SkyrimINI.SetKeyValue("General", "bUseThreadedTempEffects", CInt(Main.chk_bUseThreadedTempEffects.Checked))
        SkyrimINI.SetKeyValue("General", "bUseThreadedParticleSystem", CInt(Main.chk_bUseThreadedParticleSystem.Checked))
        SkyrimINI.SetKeyValue("General", "bUseThreadedMorpher", CInt(Main.chk_bUseThreadedMorpher.Checked))

        ' Threading [Decals]
        SkyrimINI.SetKeyValue("Decals", "bDecalMultithreaded", CInt(Main.chk_bDecalMultithreaded.Checked))

        ' Threading [BackgroundLoad]
        SkyrimINI.SetKeyValue("BackgroundLoad", "bUseMultiThreadedTrees", CInt(Main.chk_bUseMultiThreadedTrees.Checked))
        SkyrimINI.SetKeyValue("BackgroundLoad", "bUseMultiThreadedFaceGen", CInt(Main.chk_bUseMultiThreadedFaceGen.Checked))

        ' Threading [Animation]
        SkyrimINI.SetKeyValue("Animation", "bMultiThreadBoneUpdate", CInt(Main.chk_bMultiThreadBoneUpdate.Checked))

        ' Threading [HAVOK]
        SkyrimINI.SetKeyValue("HAVOK", "iNumThreads", Main.txt_iNumThreads.Text)
    End Sub
End Module