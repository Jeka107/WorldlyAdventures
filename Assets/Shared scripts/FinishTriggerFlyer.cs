using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTriggerFlyer : MonoBehaviour
{
    [SerializeField] private GameObject finishLavelLabel;
    [SerializeField] private GameObject spawner;

    private FlyerNewMovement flyerMovement;
    private bool Happened;

    private void Start()
    {
        flyerMovement = FindObjectOfType<FlyerNewMovement>();
        Happened = false;
    }
    void Update()
    {
        if (Happened==false)
        {
            if (spawner.GetComponent<Spawner>().finished == true)
            {
                Time.timeScale = 0;
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Coin", flyerMovement.scoreCoin);
                PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") + PlayerPrefs.GetInt("ToyFlyerCoin"));
                PlayerPrefs.Save();
                finishLavelLabel.SetActive(true);
                Happened = true;
            }
        }
       
    }
}
