using UnityEngine;


public class FlyerStats : StatsParent
{
    private GameManager gameManager;
    public Canvas MainCanvas;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;
    

 void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        MainCanvas = FindObjectOfType<Canvas>();
        Heart1 = MainCanvas.transform.Find("Heart1").gameObject;
        Heart2 = MainCanvas.transform.Find("Heart2").gameObject;
        Heart3 = MainCanvas.transform.Find("Heart3").gameObject;
        Heart4 = MainCanvas.transform.Find("Heart4").gameObject;
        Heart5 = MainCanvas.transform.Find("Heart5").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>(); //get enemy damage.

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GeTDamage()); //take damage reduce health.
            
            if (cameraShake != null)
            {
                ShakeCamera();//shake the camera when hit.
            }
            damageDealer.Hit();

            if (health <= 0)//player died
            {
                gameManager.RestartScene(); //call function to restart scene.
            }
        }
    }
void Update()
    {
        //depends on health remove hearts.
        if (health<=50&&health>40)
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
        if (health <= 30 && health >20)
        {

            Heart1.SetActive(false);
            Heart2.SetActive(false);
          
           
        }
        if (health <= 20 && health > 10)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
           
        }
        if (health <= 10)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            Heart4.SetActive(false);

        }
    }
}
