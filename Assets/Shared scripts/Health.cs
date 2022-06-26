using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 15;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;
    
    private void Awake()
    {
        if (Camera.main.GetComponent<CameraShake>() != null)
        {
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer!=null)
        {
            TakeDamage(damageDealer.GeTDamage());
            if (cameraShake != null)
            {
                ShakeCamera();
            }
            damageDealer.Hit();
        }
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }    
    private void ShakeCamera()
    {
        if(cameraShake!=null&&applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
