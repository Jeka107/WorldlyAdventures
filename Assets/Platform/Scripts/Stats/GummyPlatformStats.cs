using UnityEngine;

public class GummyPlatformStats : StatsParent
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GetComponent<PowerUp>().checkPowerUp()) //power up on
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();

            if (damageDealer != null)
            {
                TakeDamage(damageDealer.GeTDamage());

                if (cameraShake != null)
                {
                    ShakeCamera();
                }
            }
        }
        if (health <= 0)
            FindObjectOfType<PlatformGameManager>().RestartScene(); //player died
    }
}
