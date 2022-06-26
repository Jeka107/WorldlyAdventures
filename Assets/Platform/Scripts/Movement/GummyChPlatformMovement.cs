using UnityEngine;

public class GummyChPlatformMovement : PlatformPlayerMovement
{
    [SerializeField] private DamageDealer damageDealer;
    [SerializeField] GameObject enemyKiller;

    void Update()
    {
        if (FindObjectOfType<PowerUp>().checkPowerUp()) //power up on
        {
            enemyKiller.SetActive(true); //activate enemy killer.
        }
        else
        {
            enemyKiller.SetActive(false); //deactivate enemy killer.
        }
        Move();
        FlipPlayer();
    }
}
