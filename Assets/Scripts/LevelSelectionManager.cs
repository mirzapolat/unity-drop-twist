using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    [Header("For Dark Mode")]
    public GameObject ObjectsNormal;
    public GameObject ObjectsLight;
    public Camera cam;

    [Space]
    public Color ColorDark;
    public Color ColorLight;

    [Header("Audio")]
    public AudioSource Audio;

    public static string SelectetedLevel = "CUBE";

    private void Start()
    {
        // Menu Music
        if (PlayerPrefs.GetInt("SETTINGS_MENUMUSIC", 1) == 1)
        {
            Audio.mute = false;
        }
        else
        {
            Audio.mute = true;
        }

        // Dark Mode
        if (PlayerPrefs.GetInt("SETTINGS_DARKMODE", 0) == 1)
        {
            ObjectsNormal.SetActive(false);
            ObjectsLight.SetActive(true);
            cam.backgroundColor = ColorDark;
        }
        else
        {
            ObjectsNormal.SetActive(true);
            ObjectsLight.SetActive(false);
            cam.backgroundColor = ColorLight;
        }
    }

    /// <summary>
    /// Changes Scene to Game and sets the Level
    /// </summary>
    /// <param name="level"></param>
    public void ChangeWithLevel(string level)
    {
        SelectetedLevel = level;
        ChangeToScene(1);
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
