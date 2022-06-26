using UnityEngine;

public class GummyMazeMovement : MazePlayerMovement
{
    [SerializeField] GameObject assFire;
    [SerializeField] GameObject killer;

    void Update()
    {
        powerUp = GetComponent<PowerUp>().checkPowerUp();

        if(powerUp)//power up on
        {
            assFire.SetActive(true); //activate fire.
            killer.SetActive(true);  //activate enemy killer
        }
        else
        {
            assFire.SetActive(false); //deactivate fire.
            killer.SetActive(false); //deactivate enemy killer
        }

        Move();
        FlipPlayer();
    }
}
