using UnityEngine;

public class BaseShooter : MonoBehaviour
{
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public GameObject BigprojectilePrefab;
    [SerializeField] public float projectileSpeed = 10f;
    [SerializeField] public float projectileLifetime = 5f;
    [SerializeField] public float baseFiringRate = 2f;

    [HideInInspector] public  float playerTimeLastShot = 0f;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Vector3 direction;

    private void Awake()
    {
        direction = transform.up;
    }
    private void Update()
    {
        Fire();
    }
    public void Fire()
    {
        if (Time.time > playerTimeLastShot) //timing shoots.
        {  
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);//create shoot.
            rb = instance.GetComponent<Rigidbody>();

            playerTimeLastShot = Time.time + baseFiringRate;
            Destroy(instance, projectileLifetime); //destroy shoot after time.
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed * Time.fixedDeltaTime; //send shoot in direction.
        }
    }
}
