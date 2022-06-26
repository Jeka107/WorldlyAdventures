using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialRunnerScript2 : MonoBehaviour //similer to tutorial runner.
{
    private CharacterController characterController;
    private PlayerControls playerControls;
    public GameObject TutorialPauseCollider;
    public GameObject blackCanvas2;
    public GameObject blackCanvas1;
    public RunnerGameManager RunnerGameManager;
    public TutorialRunnerScript2 tutorialRunnerScript2;
    public bool Happened2;

    private void Awake()
    {
        playerControls = FindObjectOfType<InputManager>().playerControls;
        Happened2 = tutorialRunnerScript2.Happened2;
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("NewRunnerPlayer") == 1)
        {
            Happened2 = true;
        }
        else
        {
            Happened2 = false;
        }
    }
    void Update()
    {
        if (Happened2 == false)
        {
            Debug.Log("1");
            if (Time.timeScale == 0 && RunnerGameManager.currentCharacter.transform.position.z >= 50)
            {
                if (FindObjectOfType<Swipe>().swipeDirection == -1 || FindObjectOfType<Swipe>().swipeDirection == 1)
                {
                    Time.timeScale = 1;
                    blackCanvas2.SetActive(false);
                    blackCanvas1.SetActive(false);
                    Happened2 = true;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("NewRunnerPlayer") ==0)
        {
            blackCanvas2.SetActive(true);
            PlayerPrefs.SetInt("NewRunnerPlayer", 1);
            Time.timeScale = 0;
        }
    }
}
