using System.Collections.Generic;
using UnityEngine;

public class SoldierShooter : BaseShooter
{
    [SerializeField] private bool powerUp;
    [SerializeField] private float addSpeed;

    private List<GameObject> enemies;
    private float remmemberSpeed;
    private void Start()
    {
        enemies = FindObjectOfType<Spawner>().enemies; //list of enimies.
        remmemberSpeed = projectileSpeed; //remmeber default speed.
    }
    void Update()
    {
        powerUp = GetComponent<PowerUp>().checkPowerUp();

        if(powerUp&& GameObject.FindGameObjectWithTag("Enemy") != null) //checking power up on and enimies.
        {
            projectileSpeed += addSpeed;
            PowerUpFire();
        }
        else
        {
            projectileSpeed = remmemberSpeed;
            Fire();
        }
    }
    private void PowerUpFire()//shoot big projectile on enemy position.
    {
        if (Time.time > playerTimeLastShot)
        {
            GameObject instance = Instantiate(BigprojectilePrefab, transform.position, Quaternion.identity); //create bullet.
            instance.GetComponent<BigProjectile>().enemyTransform = enemies[0].transform;                    //set enemy positon.

            playerTimeLastShot = Time.time + 1f;
            Destroy(instance, projectileLifetime);
        }
    }
}
