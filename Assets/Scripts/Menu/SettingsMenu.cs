using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer music, SFX;
    public TMP_Dropdown resDropdown;
    UniversalAdditionalCameraData cameraRenderingOpts;
    Resolution[] res;
    bool msaaOn;

    private void Start() {

        cameraRenderingOpts = Camera.main.GetUniversalAdditionalCameraData();

        res = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> opt = new List<string>();

        int currentResIndex = 0;


        for (int i = 0; i < res.Length; i++) {

        
            opt.Add(res[i].width + "x" + res[i].height);

            if (res[i].width == Screen.currentResolution.width &&
                res[i].height == Screen.currentResolution.height)
                currentResIndex = i;
        
        }

        resDropdown.AddOptions(opt);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();

    }

    #region Video Settings

    public void ScreenResolution(int screenResIndex) {
        Resolution r = res[screenResIndex];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    public void Fullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void PostProcessing(bool isPPOn) {
        cameraRenderingOpts.renderPostProcessing = isPPOn;
    }

    public void AntiAliasing(int aaModeIndex) {

        switch (aaModeIndex) {
            case 0:
                cameraRenderingOpts.antialiasing = AntialiasingMode.None;
                msaaOn = false;
                QualitySettings.antiAliasing = 0;
                break;
            case 1:
                cameraRenderingOpts.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
                msaaOn = false;
                QualitySettings.antiAliasing = 0;
                break;
            case 2:
                cameraRenderingOpts.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                msaaOn = false;
                QualitySettings.antiAliasing = 0;
                break;
            case 3:
                cameraRenderingOpts.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
                msaaOn = true;
                break;
            case 4:
                cameraRenderingOpts.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                msaaOn = true;
                break;
        }
        
    }

    public void SMAA(int smaaQualityIndex) {

        switch (smaaQualityIndex) {
            case 0:
                cameraRenderingOpts.antialiasingQuality = AntialiasingQuality.Low;
                break;
            case 1:
                cameraRenderingOpts.antialiasingQuality = AntialiasingQuality.Medium;
                break;
            case 2:
                cameraRenderingOpts.antialiasingQuality = AntialiasingQuality.High;
                break;
        }

    }

    public void MSAA(int msaaQualityIndex) {

        if (msaaOn)
            QualitySettings.antiAliasing = (int) Mathf.Pow(2, msaaQualityIndex+1);
    }

    #endregion

    #region Sound Settings

    public void ChangeMasterVolume(float newVolume) {
        AudioListener.volume = newVolume;
    }

    public void ChangeSFXVolume(float newVolume) {
        SFX.SetFloat("volume", newVolume);
    }

    public void ChangeMusicVolume(float newVolume) {
        music.SetFloat("volume", newVolume);
    }

    #endregion

    #region Controls Settings

    public void SetControlsToDefault() {

    }

    #endregion

    #region Accessibility Setiings

    public void ColorBlindMode() {

    }

    #endregion
}
