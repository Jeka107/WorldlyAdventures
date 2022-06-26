using UnityEngine;

public class TutorialRunnerScript : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerControls playerControls;
    public GameObject TutorialPauseCollider;
    public GameObject blackCanvas1;
    public RunnerGameManager RunnerGameManager;
    public TutorialRunnerScript tutorialRunnerScript;
    public bool Happened;

    private void Awake()
    {
        playerControls = FindObjectOfType<InputManager>().playerControls;
        Happened = tutorialRunnerScript.Happened;
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("NewRunnerPlayer") == 1) //check if first time player
        {
            Happened = true;
        }
        else
        {
            Happened = false;
        }
    }
    void Update()
    {
        if (Happened==false)
        {
            if (Time.timeScale == 0)
            {
                if (FindObjectOfType<Swipe>().swipeDirection == 2) //if swipe up(jump)
                {
                    Time.timeScale = 1;
                    blackCanvas1.SetActive(false); //deactivate tutorial canvas.
                    Happened = true;
                }
            }
        }
        if (PlayerPrefs.GetInt("NewRunnerPlayer") == 1)
        {
            Happened = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("NewRunnerPlayer") == 0) //new runner player
        {
            blackCanvas1.SetActive(true);  //activate tutorial canvas.
            Time.timeScale = 0;
        }
    }
}
