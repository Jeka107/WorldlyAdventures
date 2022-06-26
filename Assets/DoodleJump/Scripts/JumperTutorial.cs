using UnityEngine;
using UnityEngine.InputSystem;

public class JumperTutorial : MonoBehaviour
{
    [SerializeField] private GameObject blackCanvas;
    [SerializeField] private bool Happened;

    private void Start()
    {
        blackCanvas.SetActive(false);
    }

    void Update()
    {
        if (Touchscreen.current != null)
        {
            if (!Happened)
            {
                if (Time.timeScale == 0)
                {
                    //if touched 
                    if (Touchscreen.current.primaryTouch.phase.ReadValue() == (UnityEngine.InputSystem.TouchPhase.Began))
                    {
                        Time.timeScale = 1;
                        blackCanvas.SetActive(false); //Tutorial canavas off.
                        Happened = true;
                        PlayerPrefs.SetInt("NewJumperPlayer", 1);//not a new player.
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("NewJumperPlayer") == 0) //when triggered activate Tutorial Canavas.when new player.
        {
            blackCanvas.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
