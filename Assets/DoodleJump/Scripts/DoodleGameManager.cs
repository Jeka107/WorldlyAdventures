using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoodleGameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private int chooseCharacter;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinsParent;
    [SerializeField] private float waitTime;
    [SerializeField] private int numCoins;
    [SerializeField] private Vector3 spawnCoinPosition;
    [SerializeField] private GameObject tapToStart;

    public GameObject currentCharacter;

    [SerializeField] private GameObject TutorialPause1;
    [SerializeField] private GameObject TutorialPause2;

    
    void Start()
    {
        Time.timeScale = 1;
        chooseCharacter = PlayerPrefs.GetInt("charSelected"); //for spawning the character that we choosen.
        spawnCharacter();
        StartCoroutine(SpawnCoins());

        //using TutorialPause in first levels.
        if (PlayerPrefs.GetInt("NewJumperPlayer")==0)
        {
            TutorialPause1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("NewJumperPlayer2") == 0)
        {
            TutorialPause2.SetActive(true);
        }
    }

    IEnumerator SpawnCoins()//spawn coin after some second.
    {
        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < numCoins; i++)
        {
            float randCoinx = Random.Range(-3f, 3f);
            float randCoiny = Random.Range(10f, 15f);

            spawnCoinPosition.x = randCoinx;
            spawnCoinPosition.y += randCoiny;

            Instantiate(coinPrefab, spawnCoinPosition, Quaternion.identity, coinsParent);
        }
    }

    private void spawnCharacter() //spawn our character.
    {
        currentCharacter = Instantiate(characters[chooseCharacter], characters[chooseCharacter].transform.position, Quaternion.identity);
    }
    public void RestartScene() //function to restart the scene.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartJumperLevel() //to start the level.
    {
        currentCharacter.GetComponent<DoodleMovement>().enabled = true;
        tapToStart.SetActive(false);
    }
}
