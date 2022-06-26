using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerFinishTrigger : MonoBehaviour
{
    [SerializeField] GameObject finishLevelLabel;

    private void Start()
    {
        finishLevelLabel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //finish level and update player prefs.
        if (other.tag == "Player")
        {
            finishLevelLabel.SetActive(true);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Coin", other.GetComponent<RunnerMovement>().scoreCoin);
            PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") + other.GetComponent<RunnerMovement>().scoreCoin);
            PlayerPrefs.Save();
            Time.timeScale = 0;
        }
    }
}
