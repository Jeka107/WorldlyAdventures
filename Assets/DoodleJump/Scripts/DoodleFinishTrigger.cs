using UnityEngine;
using UnityEngine.SceneManagement;

public class DoodleFinishTrigger : MonoBehaviour
{
    [SerializeField] GameObject finishLevelLabel;

    private void Start()
    {
        finishLevelLabel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //activates finish trigger and using playerprefs for memory.
        if (other.tag == "Player")
        {
            finishLevelLabel.SetActive(true);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Coin", other.GetComponent<DoodleMovement>().scoreCoin);
            PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") + other.GetComponent<DoodleMovement>().scoreCoin);
            PlayerPrefs.Save();
            Time.timeScale = 0;
        }
    }
}
