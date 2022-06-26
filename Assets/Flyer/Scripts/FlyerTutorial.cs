using UnityEngine;
using UnityEngine.InputSystem;

public class FlyerTutorial : MonoBehaviour
{
    [SerializeField]private GameObject blackCanvas;

    [HideInInspector] public bool Happened;

    private void Start()
    {
        if(PlayerPrefs.GetInt("NewFlyerPlayer") == 1)
        {
            GetComponent<Collider>().enabled = false;
        }
    }
    void Update()
    {
        if (Touchscreen.current != null)
        {
            if (!Happened)
            {
                if (Time.timeScale == 0)
                {
                    if (Touchscreen.current.primaryTouch.phase.ReadValue() == (UnityEngine.InputSystem.TouchPhase.Began))
                    {
                        Time.timeScale = 1;
                        blackCanvas.SetActive(false);
                        Happened = true;
                        GetComponent<Collider>().enabled = false;
                        PlayerPrefs.SetInt("NewFlyerPlayer", 1);
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("NewFlyerPlayer") == 0)
        {
            blackCanvas.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
