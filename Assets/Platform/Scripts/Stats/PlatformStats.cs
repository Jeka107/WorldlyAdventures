using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStats : StatsParent
{
    private void OnTriggerEnter(Collider other)
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
        if (health <= 0)
            FindObjectOfType<PlatformGameManager>().RestartScene();
    }
}
