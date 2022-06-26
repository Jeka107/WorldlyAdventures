using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] public float waitTime = 5f;
    [SerializeField] GameObject timer;
    [SerializeField] bool canvasTimer;

    private bool powerUp = false;
    private GamePlayStats gamePlayStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            if (timer != null)
            {
                timer.SetActive(true);
            }
            if(canvasTimer)
            {
                gamePlayStats = FindObjectOfType<GamePlayStats>();
                gamePlayStats.PowerUpTextOn();
            }
            powerUp = true;
            Destroy(other.gameObject);
            Invoke("SetBool", waitTime);
        }
    }
    public bool checkPowerUp()
    {
        return powerUp;
    }
    public void SetBool()
    {
        powerUp = false;
        
    }
    public void TimerOff()
    {
        if (timer != null)
        {
            timer.SetActive(false);
        }
        if (canvasTimer)
        {
            gamePlayStats.PowerUpTextOff();
        }
    }
}
