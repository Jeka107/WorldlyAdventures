using UnityEngine;

public class NinjaFlyerStats : StatsParent
{
    [SerializeField] private GameObject particleEffect;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;
    bool checkPowerUp = false;

    private GameManager gameManager;

    private void Start()
    {
        Heart1 = GameObject.Find("Heart1");
        Heart2 = GameObject.Find("Heart2");
        Heart3 = GameObject.Find("Heart3");
        Heart4 = GameObject.Find("Heart4");
        Heart5 = GameObject.Find("Heart5");
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        checkPowerUp = GetComponent<PowerUp>().checkPowerUp();

        if (health <= 50 && health > 40)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
            Heart5.SetActive(true);
        }
        if (health <= 40 && health > 30)
        {
            Heart1.SetActive(false);
        }
        if (health <= 30 && health > 20)
        {
            Heart2.SetActive(false);
        }
        if (health <= 20 && health > 10)
        {
            Heart3.SetActive(false);
        }
        if (health <= 10)
        {
            Heart4.SetActive(false);
        }

        if(checkPowerUp)//power up on
        {
            particleEffect.SetActive(true);  //particles on
        }
        else
        {
            particleEffect.SetActive(false); //particles off
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            if (checkPowerUp)//enemy body cant hurt player
            {
                return;
            }
            else //take damage regulery.
            {           
                TakeDamage(damageDealer.GeTDamage());
                if (cameraShake != null)
                {
                    ShakeCamera();
                }
                damageDealer.Hit();
                if (health <= 0)
                {
                    gameManager.RestartScene();
                }
            }
        }
    }
}
