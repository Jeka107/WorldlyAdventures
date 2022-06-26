using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeFinishTrigger : MonoBehaviour
{
    [SerializeField] GameObject finishLevelLabel;

    private void Start()
    {
        finishLevelLabel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //finish the level when player tirggered and update playerprefs.
        if (other.tag == "Player")
        {
            finishLevelLabel.SetActive(true);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Coin", other.GetComponent<MazePlayerMovement>().scoreCoin);
            PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") + other.GetComponent<MazePlayerMovement>().scoreCoin);
            PlayerPrefs.Save();
            Time.timeScale = 0;
        }
    }
}
