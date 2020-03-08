using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [Header("For Dark Mode")]
    public GameObject ObjectsNormal;
    public GameObject ObjectsLight;
    public Camera cam;
    public Animator Instructions;

    [Space]
    public Color ColorDark;
    public Color ColorLight;

    [Header("Rotators")]
    public GameObject cube;
    public GameObject triangle;
    public GameObject pentagon;

    [Header("Audio")]
    public AudioSource audPop;
    public AudioSource audRotate;
    public AudioSource audBackground;

    private static string level;

    void Start()
    {
        level = LevelSelectionManager.SelectetedLevel;

        ShowMatchingRotator();

        // In Game Music
        if (PlayerPrefs.GetInt("SETTINGS_INGAMEMUSIC", 1) == 1) audBackground.mute = false;
        else audBackground.mute = true;

        // Sound Effects
        if (PlayerPrefs.GetInt("SETTINGS_SOUNDEFFECTS", 1) == 1)
        {
            audPop.mute = false;
            audRotate.mute = false;
        }
        else
        {
            audPop.mute = true;
            audRotate.mute = true;
        }

        // Dark Mode
        if (PlayerPrefs.GetInt("SETTINGS_DARKMODE", 0) == 1)
        {
            ObjectsNormal.SetActive(false);
            ObjectsLight.SetActive(true);
            cam.backgroundColor = ColorDark;
            Instructions.SetTrigger("ShowLight");
        }
        else
        {
            ObjectsNormal.SetActive(true);
            ObjectsLight.SetActive(false);
            cam.backgroundColor = ColorLight;
        }
    }

    /// <summary>
    /// Shows the right Rotator
    /// </summary>
    private void ShowMatchingRotator()
    {
        cube.SetActive(false);
        triangle.SetActive(false);
        pentagon.SetActive(false);

        switch (level)
        {
            case "CUBE":
                cube.SetActive(true);
                break;
            case "TRIANGLE":
                triangle.SetActive(true);
                break;
            case "PENTAGON":
                pentagon.SetActive(true);
                break;
        }
    }
}
