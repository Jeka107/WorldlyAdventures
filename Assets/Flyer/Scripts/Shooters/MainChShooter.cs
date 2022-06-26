using UnityEngine;

public class MainChShooter : BaseShooter
{
    private bool powerUp;

    private Rigidbody rb1;
    private Rigidbody rb2;

    void Update()
    {
        powerUp = GetComponent<PowerUp>().checkPowerUp();

        if (!powerUp)//check power up on/off
        {
            Fire(); //for shooting regulery
        }
        else
        {
            PowerUpFire(); //for shooting two bullets same time.
        }
    }

    private void PowerUpFire()
    {
        //same as reguler bullet but creating two bullets.
        if (Time.time > playerTimeLastShot) 
        {
            Vector3 positionFire1 = transform.position;
            Vector3 positionFire2 = transform.position;
            positionFire1.x += 0.1f;
            positionFire2.x -= 0.1f;
            GameObject instance1 = Instantiate(projectilePrefab, positionFire1, Quaternion.identity);
            GameObject instance2 = Instantiate(projectilePrefab, positionFire2, Quaternion.identity);
            rb1 = instance1.GetComponent<Rigidbody>();
            rb2 = instance2.GetComponent<Rigidbody>();

            playerTimeLastShot = Time.time + baseFiringRate;
            Destroy(instance1, projectileLifetime);
            Destroy(instance2, projectileLifetime);
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed * Time.fixedDeltaTime;
        }
        if (rb1 != null && rb2 != null) //two bullet sending to direction.
        {
            rb1.velocity = direction * projectileSpeed * Time.fixedDeltaTime;
            rb2.velocity = direction * projectileSpeed * Time.fixedDeltaTime;
        }
    }
}
