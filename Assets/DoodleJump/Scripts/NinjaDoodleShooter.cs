using System.Collections.Generic;
using UnityEngine;

public class NinjaDoodleShooter : BaseShooter
{
    private DoodleMovement doodleMovement;
    private List<GameObject> enemies;

    private void Start()
    {
        doodleMovement = GetComponent<DoodleMovement>();
        enemies = FindObjectOfType<CountEnemies>().enemies;
    }
    void Update()
    {
        if(doodleMovement.powerUp)//if power up is on.
        {
            if (Time.time > playerTimeLastShot)
            {
                GameObject instance = Instantiate(BigprojectilePrefab, transform.position, Quaternion.identity);
                if (enemies.Count != 0)//if enemis existing
                {
                    instance.GetComponent<BigProjectile>().enemyTransform = enemies[0].transform; //set first enemy in list transform.
                }
                else
                {
                    direction = transform.up; //shoot just up.
                    rb = instance.GetComponent<Rigidbody>();
                }
                playerTimeLastShot = Time.time + 1f;   //synchronize shoots.
                Destroy(instance, projectileLifetime); //destroy shoot after time.
            }
        }
    }
}
