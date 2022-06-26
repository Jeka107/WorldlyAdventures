

public class MainMazeMovement : MazePlayerMovement
{
    void Update()
    {
        powerUp = GetComponent<PowerUp>().checkPowerUp();

        if (powerUp&&!jumped) //power up on and not jumped yet.
        {
            button.SetActive(true); //activate buuton
        }
        else if(jumped) //if jumped 
        {
            jumped = false; 
            GetComponent<PowerUp>().SetBool(); //set power up off
            button.SetActive(false); //deactivate button.
        }

        Move();
        FlipPlayer();
    }
}
