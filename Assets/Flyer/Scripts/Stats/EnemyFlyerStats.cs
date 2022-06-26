using UnityEngine;

public class EnemyFlyerStats : StatsParent
{
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject powerUp;
    private int random;
    private int random2;
    private FlyerNewMovement Player;

    private void Start()
    {
        Player = FindObjectOfType<FlyerNewMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>(); //get player damage.

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GeTDamage());
            if (health <= 0) //if enemy die.
            {
                random = Random.Range(0, 2);
                random2 = Random.Range(0, 7);
                if (random==0)//spawn coin random
                {
                    Instantiate(coin, transform.position, Quaternion.identity);
                }
                else if (random2 ==1)//spawn power up random
                {
                    Instantiate(powerUp, transform.position, Quaternion.identity);
                }
                Player.scoreCoin += enemyValue; //add coin value to score.
            }
            if (cameraShake != null)
            {
                ShakeCamera(); 
            }
            damageDealer.Hit(); //hit the enemy.
        }
    }
}

