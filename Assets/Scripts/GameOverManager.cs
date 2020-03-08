using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("For Dark Mode")]
    public GameObject ObjectsNormal;
    public GameObject ObjectsLight;
    public Camera cam;

    [Space]
    public Color ColorDark;
    public Color ColorLight;

    [Header("Text")]
    public Text ScoreTextLight;
    public Text highScoreTextLight;
    public Text ScoreTextDark;
    public Text highScoreTextDark;

    [Header("Animator")]
    public Animator animCrown;

    [Header("Audio")]
    public AudioSource Audio;

    private static int myscore;
    private static string level;

    void Start()
    {
        myscore = BallGravity.score;
        level = LevelSelectionManager.SelectetedLevel;

        int lastHighscore = PlayerPrefs.GetInt("HIGHSCORE_" + level, 0);

        ScoreTextLight.text = myscore.ToString();
        highScoreTextLight.text = lastHighscore.ToString();
        ScoreTextDark.text = myscore.ToString();
        highScoreTextDark.text = lastHighscore.ToString();

        // Menu Music
        if (PlayerPrefs.GetInt("SETTINGS_INGAMEMUSIC", 1) == 1)
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

    public void ChangeToScene(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
