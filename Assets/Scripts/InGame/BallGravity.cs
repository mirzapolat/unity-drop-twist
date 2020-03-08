using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class BallGravity : MonoBehaviour
{
    [Header("The Ball")]
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    [Header("Texts")]
    public Text scoreText;
    public Text highscoreText;
    public Text scoreTextDark;

    [Header("Colors")]
    public Color colorGold;

    [Space]
    public Color colorRed;
    public Color colorGreen;
    public Color colorBlue;
    public Color colorYellow;
    public Color colorPurple;

    [Header("Gravity")]
    public float currentGravity;
    public float gravityIncrease;

    [Header("Animations")]
    public Animator animCrown;

    [Header("Particles")]
    public ParticleSystem partStars;
    public ParticleSystem partHit;

    [Header("Audio")]
    public AudioSource audPop;

    public static int score = 0;
    private static string level;

    private bool firstHighscore = true;

    void Start()
    {
        score = 0;
        level = LevelSelectionManager.SelectetedLevel;

        SetBallRandomColor();

        highscoreText.enabled = true;
        highscoreText.text = PlayerPrefs.GetInt("HIGHSCORE_" + level, 0).ToString();
    }

    /// <summary>
    /// Lets the Ball fall down
    /// </summary>
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - currentGravity);
    }

    /// <summary>
    /// Triggers if the Ball collides with an other object
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.tag == collision.tag)
        {
            audPop.Play();

            score++;
            scoreText.text = score.ToString();
            scoreTextDark.text = score.ToString();

            var main = partHit.main;  // Particles
            main.startColor = sr.color; // Particles

            SetBallRandomColor();

            partHit.Play(); // Particles

            currentGravity += gravityIncrease;

            if (score > PlayerPrefs.GetInt("HIGHSCORE_" + level, 0))
            {
                animCrown.SetTrigger("Wubble");

                scoreText.color = colorGold;
                scoreTextDark.color = colorGold;
                highscoreText.enabled = false;

                PlayerPrefs.SetInt("HIGHSCORE_" + level, score);

                if (firstHighscore)
                {
                    partStars.Play(); // Particles

                    firstHighscore = false;
                }
            }
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    /// <summary>
    /// Gives the Ball a random Color end moves it to the top of the screen
    /// </summary>
    private void SetBallRandomColor()
    {
        List<string> colors = new List<string>();
        colors.Add("red");
        colors.Add("blue");
        colors.Add("yellow");
        colors.Add("green");
        colors.Add("purple");

        List<string> neededColors = GetOnlyNeeded(colors);

        neededColors.Remove(transform.tag);

        switch (neededColors[UnityEngine.Random.Range(0, neededColors.Count)])
        {
            case "red":
                sr.color = colorRed;
                transform.tag = "red";
                break;
            case "green":
                sr.color = colorGreen;
                transform.tag = "green";
                break;
            case "blue":
                sr.color = colorBlue;
                transform.tag = "blue";
                break;
            case "yellow":
                sr.color = colorYellow;
                transform.tag = "yellow";
                break;
            case "purple":
                sr.color = colorPurple;
                transform.tag = "purple";
                break;
        }

        transform.position = new Vector3(0, 5.25f, 0);
    }

    /// <summary>
    /// Gets only the needed colors
    /// </summary>
    /// <param name="completeList"></param>
    /// <returns></returns>
    private List<string> GetOnlyNeeded(List<string> completeList)
    {
        List<string> now = new List<string>();
        int need = 0;

        switch (level)
        {
            case "TRIANGLE":
                need = 3;
                break;
            case "CUBE":
                need = 4;
                break;
            case "PENTAGON":
                need = 5;
                break;
        }

        for (int i = 0; i<need; i++)
        {
            now.Add(completeList[i]);
        }

        return now;
    }
}
