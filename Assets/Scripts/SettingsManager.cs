using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("For Dark Mode")]
    public GameObject ObjectsNormal;
    public GameObject ObjectsLight;
    public Camera cam;

    [Space]
    public Color ColorDark;
    public Color ColorLight;

    [Header("Slider")]
    public Slider LightMenuMusic;
    public Slider LightInGameMusic;
    public Slider LightSoundEffects;
    public Slider LightDarkMode;

    [Space]
    public Slider DarkMenuMusic;
    public Slider DarkInGameMusic;
    public Slider DarkSoundEffects;
    public Slider DarkDarkMode;
    

    [Header("Audio")]
    public AudioSource Audio;

    private bool initialisationFinished = false;

    private void Start()
    {
        UpdateScene();
        initialisationFinished = true;
    }

    /// <summary>
    /// Updates saved Settings
    /// </summary>
    public void UpdateSettings()
    {
        if (initialisationFinished)
        {
            if (PlayerPrefs.GetInt("SETTINGS_DARKMODE", 0) == 0)
            {
                if (LightMenuMusic.value == 0f) PlayerPrefs.SetInt("SETTINGS_MENUMUSIC", 0);
                else PlayerPrefs.SetInt("SETTINGS_MENUMUSIC", 1);
                if (LightInGameMusic.value == 0f) PlayerPrefs.SetInt("SETTINGS_INGAMEMUSIC", 0);
                else PlayerPrefs.SetInt("SETTINGS_INGAMEMUSIC", 1);
                if (LightSoundEffects.value == 0f) PlayerPrefs.SetInt("SETTINGS_SOUNDEFFECTS", 0);
                else PlayerPrefs.SetInt("SETTINGS_SOUNDEFFECTS", 1);
                if (LightDarkMode.value == 0f) PlayerPrefs.SetInt("SETTINGS_DARKMODE", 0);
                else PlayerPrefs.SetInt("SETTINGS_DARKMODE", 1);
            }
            else
            {
                if (DarkMenuMusic.value == 0f) PlayerPrefs.SetInt("SETTINGS_MENUMUSIC", 0);
                else PlayerPrefs.SetInt("SETTINGS_MENUMUSIC", 1);
                if (DarkInGameMusic.value == 0f) PlayerPrefs.SetInt("SETTINGS_INGAMEMUSIC", 0);
                else PlayerPrefs.SetInt("SETTINGS_INGAMEMUSIC", 1);
                if (DarkSoundEffects.value == 0f) PlayerPrefs.SetInt("SETTINGS_SOUNDEFFECTS", 0);
                else PlayerPrefs.SetInt("SETTINGS_SOUNDEFFECTS", 1);
                if (DarkDarkMode.value == 0f) PlayerPrefs.SetInt("SETTINGS_DARKMODE", 0);
                else PlayerPrefs.SetInt("SETTINGS_DARKMODE", 1);
            }

            UpdateScene();
        }
    }

    /// <summary>
    /// Updates Slider Values
    /// </summary>
    private void UpdateScene()
    {
        // Menu Audio Slider
        if (PlayerPrefs.GetInt("SETTINGS_MENUMUSIC", 1) == 1)
        {
            LightMenuMusic.value = 1;
            DarkMenuMusic.value = 1;
            Audio.mute = false;
        }
        else
        {
            Audio.mute = true;
        }

        // In Game Audio Slider
        if (PlayerPrefs.GetInt("SETTINGS_INGAMEMUSIC", 1) == 1)
        {
            LightInGameMusic.value = 1;
            DarkInGameMusic.value = 1;
        }
        else
        {
            LightInGameMusic.value = 0;
            DarkInGameMusic.value = 0;
        }

        // Sound Effects Audio Slider
        if (PlayerPrefs.GetInt("SETTINGS_SOUNDEFFECTS", 1) == 1)
        {
            LightSoundEffects.value = 1;
            DarkSoundEffects.value = 1;
        }
        else
        {
            LightSoundEffects.value = 0;
            DarkSoundEffects.value = 0;
        }

        // Dark Mode Slider
        if (PlayerPrefs.GetInt("SETTINGS_DARKMODE", 0) == 1)
        {
            LightDarkMode.value = 1;
            DarkDarkMode.value = 1;

            ObjectsNormal.SetActive(false);
            ObjectsLight.SetActive(true);
            cam.backgroundColor = ColorDark;
        }
        else
        {
            LightDarkMode.value = 0;
            DarkDarkMode.value = 0;

            ObjectsNormal.SetActive(true);
            ObjectsLight.SetActive(false);
            cam.backgroundColor = ColorLight;
        }
    }

    /// <summary>
    /// Changes to a specific Scene
    /// </summary>
    /// <param name="sceneToChangeTo"></param>
    public void ChangeToScene(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
