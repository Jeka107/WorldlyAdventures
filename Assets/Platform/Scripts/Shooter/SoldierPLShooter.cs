
public class SoldierPLShooter : BaseShooter
{
    private void Update()
    {
        bool checkPowerUp = false;

        checkPowerUp = GetComponent<PowerUp>().checkPowerUp();

        if (checkPowerUp)//power up on
        {
            if (GetComponent<PlatformPlayerMovement>().checkDirection == 1) //check face direction
            {
                direction = transform.right; //shoot right
                Fire();                      //shoot
            }
            if (GetComponent<PlatformPlayerMovement>().checkDirection == -1)//check face direction
            {
                direction = -transform.right; //shoot left
                Fire();                       //shoot
            }
        }
    }
}
