using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject powerUpText;

    private FlyerNewMovement flyerPlayer;
    private PlatformPlayerMovement platformPlayer;
    private MazePlayerMovement mazePlayer;
    private RunnerMovement runnerPlayer;
    private DoodleMovement doodlePlayer;

    [Header("Button")]
    [SerializeField] public GameObject firebutton;
    [SerializeField] public GameObject jumpbutton;

    private void Start()
    {
        Invoke("GameCheck", 0.1f); //for saftey.
    }
    private void GameCheck()
    {
        //cheking which game.
        if (FindObjectOfType<FlyerNewMovement>())
        {
            flyerPlayer = FindObjectOfType<FlyerNewMovement>();
        }
        if (FindObjectOfType<PlatformPlayerMovement>())
        {
            platformPlayer = FindObjectOfType<PlatformPlayerMovement>();
        }
        if (FindObjectOfType<MazePlayerMovement>())
        {
            mazePlayer = FindObjectOfType<MazePlayerMovement>();
        }
        if (FindObjectOfType<RunnerMovement>())
        {
            runnerPlayer = FindObjectOfType<RunnerMovement>();
        }
        if (FindObjectOfType<DoodleMovement>())
        {
            doodlePlayer = FindObjectOfType<DoodleMovement>();
        }
    }
    void Update()
    {
        //update score text in correct game.
        if (flyerPlayer)
        {
            scoreText.text = flyerPlayer.scoreCoin.ToString();
        }
        if(platformPlayer)
        {
            scoreText.text = platformPlayer.GetComponent<PlatformPlayerMovement>().scoreCoin.ToString();
        }
        if(mazePlayer)
        {
            scoreText.text = mazePlayer.scoreCoin.ToString();
        }
        if (runnerPlayer)
        {
            scoreText.text = runnerPlayer.scoreCoin.ToString();
        }
        if (doodlePlayer)
        {
            scoreText.text = doodlePlayer.scoreCoin.ToString();
        }
    }

    //activate power up text.
    public void PowerUpTextOn()
    {
        powerUpText.SetActive(true);
    }
    //deactivate power up text.
    public void PowerUpTextOff()
    {
        powerUpText.SetActive(false);
    }
}
