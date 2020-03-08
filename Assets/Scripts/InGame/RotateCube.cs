using UnityEngine;
using UnityEngine.UI;

public class RotateCube : MonoBehaviour
{
    [Header("Animators")]
    public Animator animCube;
    public Animator animTriangle;
    public Animator animPentagon;

    [Space]
    public Animator Instructions;

    [Header("Instructions")]
    public Color DarkColor;
    public Color LightColor;

    [Header("Audio")]
    public AudioSource audRotate;

    int actualState;
    bool firstClick;

    private static string level;

    private void Start()
    {
        actualState = 0;
        firstClick = true;
        level = LevelSelectionManager.SelectetedLevel; // Gets the level from the previous Scene
        firstClick = true;
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                switch (level)
                {
                    case "TRIANGLE":
                        Rotate_Triangle();
                        break;
                    case "CUBE":
                        Rotate_Cube();
                        break;
                    case "PENTAGON":
                        Rotate_Pentagon();
                        break;
                }

                if (firstClick)
                {
                    if (PlayerPrefs.GetInt("SETTINGS_DARKMODE", 0) == 1)
                    {
                        Instructions.SetTrigger("HideLight");
                    }
                    else
                    {
                        Instructions.SetTrigger("HideDark");
                    }

                    firstClick = false;
                }

                audRotate.Play();
            }
        }
    }
    
    /// <summary>
    /// Rotates the Cube (Rectangle)
    /// </summary>
    private void Rotate_Cube()
    {
        switch (actualState)
        {
            case 0:
                animCube.SetTrigger("GreenToBlue");
                actualState = 1;
                break;
            case 1:
                animCube.SetTrigger("BlueToYellow");
                actualState = 2;
                break;
            case 2:
                animCube.SetTrigger("YellowToRed");
                actualState = 3;
                break;
            case 3:
                animCube.SetTrigger("RedToGreen");
                actualState = 0;
                break;
        }
    }

    /// <summary>
    /// Rotates the Triangle
    /// </summary>
    private void Rotate_Triangle()
    {
        switch (actualState)
        {
            case 0:
                animTriangle.SetTrigger("BlueToYellow");
                actualState = 1;
                break;
            case 1:
                animTriangle.SetTrigger("YellowToRed");
                actualState = 2;
                break;
            case 2:
                animTriangle.SetTrigger("RedToBlue");
                actualState = 0;
                break;
        }
    }

    /// <summary>
    /// Rotates the Pentagon
    /// </summary>
    private void Rotate_Pentagon()
    {
        switch (actualState)
        {
            case 0:
                animPentagon.SetTrigger("PurpleToGreen");
                actualState = 1;
                break;
            case 1:
                animPentagon.SetTrigger("GreenToBlue");
                actualState = 2;
                break;
            case 2:
                animPentagon.SetTrigger("BlueToYellow");
                actualState = 3;
                break;
            case 3:
                animPentagon.SetTrigger("YellowToRed");
                actualState = 4;
                break;
            case 4:
                animPentagon.SetTrigger("RedToPurple");
                actualState = 0;
                break;
        }
    }
}
