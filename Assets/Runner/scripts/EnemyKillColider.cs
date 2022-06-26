using UnityEngine;

public class EnemyKillColider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //used for power up .when activate then player destroyes wall and enemy.
        if (other.tag == "Wall")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
