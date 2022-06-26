using UnityEngine;
using TMPro;

public class TimerOnPlayer : MonoBehaviour
{
    [SerializeField] private float timeDuration = 3f;

    private float time;
    [SerializeField] private TextMeshPro seconds;

    private void Awake()
    {
        timeDuration = FindObjectOfType<PowerUp>().waitTime + 1f;
        ResetTimer();
    }
    void Update()
    {
        if (time > 1)
        {
            time -= Time.deltaTime;
            if ((int)time == 3)
            {
                seconds.enabled = true;
            }
            UpdateTimerDisplay();
        }
        else
        {
            if (time != 0)
            {
                seconds.enabled = false;
                time = 0;
                ResetTimer();
                FindObjectOfType<PowerUp>().TimerOff();
            }
        }
    }
    private void UpdateTimerDisplay()
    {
        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);

        string currentTime = sec.ToString();
        seconds.text = currentTime;
    }
    private void ResetTimer()
    {
        time = timeDuration;
    }
}
