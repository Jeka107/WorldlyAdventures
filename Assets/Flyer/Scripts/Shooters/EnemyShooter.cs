using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public float projectileSpeed = 10f;
    [SerializeField] public float projectileLifetime = 5f;
    [SerializeField] public float baseFiringRate = 2f;
    [SerializeField] public float firingRateVariance = 0f;
    [SerializeField] public float minFiringRate = 0.1f;

    [HideInInspector] public float enemyTimeLastShot = 0f;
    private bool checkPowerUp = false;
    private Rigidbody rb;

    private void Update()
    {
        EnemyFire();
        if (GetComponent<PowerUp>())
        {
            checkPowerUp = GetComponent<PowerUp>().checkPowerUp();
        }
    }
    private void EnemyFire()
    {
        if (Time.time > enemyTimeLastShot)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            rb = instance.GetComponent<Rigidbody>();


            if(checkPowerUp)//if power up on bullets cant hurt player
            {
                instance.GetComponent<Collider>().enabled = false;
            }
            else
            {
                instance.GetComponent<Collider>().enabled = true;
            }

            Destroy(instance, projectileLifetime);

            enemyTimeLastShot = Time.time + Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance); //calculate shoot timing.
            enemyTimeLastShot = Mathf.Clamp(enemyTimeLastShot, minFiringRate, float.MaxValue);
            
        }
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = transform.up * projectileSpeed * Time.fixedDeltaTime; //send shoot in direction.
        }
    }
}