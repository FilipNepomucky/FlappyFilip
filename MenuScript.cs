using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle cloudsToggle;
    public Toggle fullScreenToggle;
    public static bool cloudsOn;

    private void Awake()
    {
        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    // ------------------ MY METHODS ------------------
    public void StartGame()
    {
        Debug.Log("Game started.");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("User quit the game.");
        Application.Quit();
    }

    // SETTINGS ------------------
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen mode active: " + isFullscreen.ToString());
    }

    public void ControlClouds(bool areActive)
    {
        
        if(areActive)
        {
            cloudsOn = true;
        }
        else
        {
            cloudsOn = false;
        }
    }

    public void SaveSettings()
    {
        // Volume settings
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);

        // Fulscreen settings
        if(Screen.fullScreen)
        {
            PlayerPrefs.SetString("isFullscreen", "true");
        }
        else
        {
            PlayerPrefs.SetString("isFullscreen", "false");
        }

        // Clouds settings
        if (cloudsOn)
        {
            PlayerPrefs.SetString("CloudsActive", "true");
        }
        else
        {
            PlayerPrefs.SetString("CloudsActive", "false");
        }

        Debug.Log("Settings saved.");
    }

    public void LoadSettings()
    {
        // Volume
        if (PlayerPrefs.HasKey("Volume") == false)
        {
            AudioListener.volume = 1.0f;
            volumeSlider.value = 1.0f;
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = AudioListener.volume;
        }

        // Fulscreen
        if (PlayerPrefs.HasKey("isFullscreen") == false)
        {
            Screen.fullScreen = true;
            fullScreenToggle.isOn = true;
            PlayerPrefs.SetString("isFullscreen", "true");
        }
        else
        {
            if(PlayerPrefs.GetString("isFullscreen") == "true")
            {
                Screen.fullScreen = true;
                fullScreenToggle.isOn = true;
            }
            else
            {
                Screen.fullScreen = false;
                fullScreenToggle.isOn = false;
            }
        }

        // Clouds
        if (PlayerPrefs.HasKey("CloudsActive") == false)
        {
            cloudsOn = true;
            cloudsToggle.isOn = true;
            PlayerPrefs.SetString("CloudsActive", "true");
        }
        else
        {
            if (PlayerPrefs.GetString("CloudsActive") == "true")
            {
                cloudsOn = true;
                cloudsToggle.isOn = true;
            }
            else
            {
                cloudsOn = false;
                cloudsToggle.isOn = false;
            }
        }

        Debug.Log("Settings loaded.");
    }
}
