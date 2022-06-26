using System.Collections;
using UnityEngine;

public class BearExplosion : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;

    private Transform explosionTransform;
    public int score;
    private FlyerNewMovement player;

    private float x;
    private float y;

    private void Start()
    {
        explosionTransform =GetComponent<Transform>();
        player = GetComponentInParent<FlyerNewMovement>();
    }

    void Update()
    {
        if (GetComponentInParent<PowerUp>().checkPowerUp()) //if power up is on
        {
            particleEffect.SetActive(true);   //activate particles effects.
            StartCoroutine(GetBigger()); 
        }
        else
        {
            particleEffect.SetActive(false);   //deactivate particles effects.
            x = 0f;
            y = 0f;
            score = 0;
            explosionTransform.localScale = new Vector3(x, y, 0f);  //set default explotion scale.
        }

    }

    IEnumerator GetBigger()
    {
        x += 0.2f; 
        y += 0.2f;
       
        explosionTransform.localScale = new Vector3(x, y, 0f); //increase every frame the explotion.
        yield return new WaitForSeconds(0.3f);                 //increase ever 0.3 sec.
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy") //if explotion touches the enemies.
        {
            score = other.GetComponent<EnemyFlyerStats>().enemyValue; //find enemy value.
            player.scoreCoin += score;                                //add enemy value to score.
            Destroy(other.gameObject);                                //destroy enemy.
        }
    }
}
