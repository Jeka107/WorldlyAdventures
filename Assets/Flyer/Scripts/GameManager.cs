using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private int chooseCharacter;
    [SerializeField] private float waitTime;
    [SerializeField] private int numCoins;
    [SerializeField] private GameObject planeToFindClicks;
    [SerializeField] private GameObject TutorialPause;

    public GameObject currentCharacter;

    void Start()
    {
        
        Time.timeScale = 1;
        chooseCharacter = PlayerPrefs.GetInt("charSelected");
        spawnCharacter();
        if (PlayerPrefs.GetInt("NewFlyerPlayer")==1)
        {
            planeToFindClicks.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            TutorialPause.SetActive(true);
        }
        
    }
    
    private void spawnCharacter()
    {
        currentCharacter=Instantiate(characters[chooseCharacter], characters[chooseCharacter].transform.position, Quaternion.identity);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartFlyerLevel()
    {   
        planeToFindClicks.SetActive(false);
        Time.timeScale = 1;
    }
}
