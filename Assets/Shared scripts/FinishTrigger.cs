using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] GameObject finishLevelLabel;

    private void Start()
    {
        finishLevelLabel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            finishLevelLabel.SetActive(true);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name+"Coin", other.GetComponent<RunnerMovement>().scoreCoin);
            Time.timeScale = 0;
        }
    }
}
