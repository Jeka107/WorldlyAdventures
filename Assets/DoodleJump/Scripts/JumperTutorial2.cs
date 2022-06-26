using UnityEngine;
using UnityEngine.InputSystem;

public class JumperTutorial2 : MonoBehaviour //same as JumperTutorial
{
    [SerializeField] private GameObject blackCanvas2;
    [SerializeField] private bool Happened2;
    [SerializeField] private DoodleGameManager DoodleGameManager;

    private void Start()
    {
        blackCanvas2.SetActive(false);
    }

    void Update()
    {
            if (Touchscreen.current != null)
            {
                if (!Happened2)
                {
                    if (DoodleGameManager.currentCharacter.transform.position.y >= 10)
                    {

                        if (Time.timeScale == 0)
                        {
                            if (Touchscreen.current.primaryTouch.phase.ReadValue() == (UnityEngine.InputSystem.TouchPhase.Began))
                            {
                                Time.timeScale = 1;
                                blackCanvas2.SetActive(false);
                                Happened2 = true;
                                PlayerPrefs.SetInt("NewJumperPlayer2", 1);
                            }
                        }
                    }
                }
            }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("NewJumperPlayer2") == 0)
        {
            blackCanvas2.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
