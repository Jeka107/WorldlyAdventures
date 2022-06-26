using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int health = 15;
    [SerializeField] public int enemyValue;
    [SerializeField] private bool applyCameraShake;

    CameraShake cameraShake;
    bool checkPowerUp = false;

    private void Awake()
    {
        if (Camera.main.GetComponent<CameraShake>() != null)
        {
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
    }
    private void Update()
    {
        checkPowerUp = GetComponent<PowerUp>().checkPowerUp();
    }
    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            if (checkPowerUp && this.tag == "Player")//enemy body cant hurt player
            {
                return; 
            }
            else
            {
                TakeDamage(damageDealer.GeTDamage());
                if (cameraShake != null)
                {
                    ShakeCamera();
                }
                damageDealer.Hit();
            }
        }
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (FindObjectOfType<FlyerNewMovement>())
            {
                FindObjectOfType<FlyerNewMovement>().scoreCoin += enemyValue;
            }
            Destroy(gameObject);
        }
    }
    private void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
