using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformFinishTrigger : MonoBehaviour
{
    [SerializeField] GameObject finishLevelLabel;

    private void Start()
    {
        finishLevelLabel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //finish level and update playerprefs.
        if (other.tag == "Player")
        {
            finishLevelLabel.SetActive(true);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Coin", other.GetComponent<PlatformPlayerMovement>().scoreCoin);
            PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") + other.GetComponent<PlatformPlayerMovement>().scoreCoin);
            PlayerPrefs.Save();
            Time.timeScale = 0;
        }
    }
}
