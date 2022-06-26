
public class GummyDoodleShooter : BaseShooter
{
    private DoodleMovement doodleMovement;
    private void Start()
    {
        doodleMovement = GetComponent<DoodleMovement>();
        direction = transform.up;
    }
    void Update()
    {
        if (doodleMovement.powerUp) //check gummy power up
        {
            Fire(); //shoot
        }
    }
}
