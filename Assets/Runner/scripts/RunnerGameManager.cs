using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class RunnerGameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private int chooseCharacter;
    [SerializeField] private GameObject coin;
    [SerializeField] private Vector3 startSpanwCoinPosition;
    [SerializeField] private GameObject coinParent;
    [SerializeField] private int numOfCoinsToSpawn;
    [SerializeField] private List<float> numX;
    [SerializeField] private Transform lastBlockPosision;
    [SerializeField] private int betweenYCoinDisMin;
    [SerializeField] private int betweenYCoinDisMax;
    [SerializeField] private GameObject planeToFindClicks;

    public GameObject currentCharacter;

    [SerializeField] private GameObject tutorialPause1;
    [SerializeField] private GameObject tutorialPause2;

    [HideInInspector] public Animator AnimateCharacter;
    private int randomIndexX;
    private int randomIndexZ;

    void Start()
    {
        Time.timeScale = 1;
        chooseCharacter = PlayerPrefs.GetInt("charSelected");
        SpawnCharacter();
        AnimateCharacter = currentCharacter.GetComponentInChildren<Animator>();
        randomIndexZ = (int)startSpanwCoinPosition.z;

        if (PlayerPrefs.GetInt("NewRunnerPlayer") == 0)
        {
            if (tutorialPause1 != null && tutorialPause2 != null)
            {
                tutorialPause1.SetActive(true);
                tutorialPause2.SetActive(true);
            }
        }
    }
    private void Update()
    {
        SpawnCoin();

        if (currentCharacter.GetComponent<RunnerMovement>().enabled==false)
        {
            AnimateCharacter.SetBool("IsRunning", false);
        }
        if (currentCharacter.GetComponent<RunnerMovement>().enabled == true)
        {
            AnimateCharacter.SetBool("IsRunning", true);
        }
        if (currentCharacter.GetComponent<CharacterController>().isGrounded)
        {
          AnimateCharacter.SetBool("IsJumping", false);
        }
        if (currentCharacter.GetComponent<CharacterController>().isGrounded==false)
        {
            AnimateCharacter.SetBool("IsJumping", true);
        }
        
       
    }
    private void SpawnCharacter() //spawn selected character.
    {
        currentCharacter = Instantiate(characters[chooseCharacter], characters[chooseCharacter].transform.position, Quaternion.identity);
    }
    private void SpawnCoin() //spawn coins
    {
        if (lastBlockPosision)
        {
            if (randomIndexZ < (int)lastBlockPosision.position.z)
            {
                randomIndexX = Random.Range(0, 3);
                randomIndexZ += Random.Range(betweenYCoinDisMin, betweenYCoinDisMax);
                Instantiate(coin, new Vector3(numX[randomIndexX], 1, randomIndexZ), Quaternion.identity, coinParent.transform);
            }
        }
    }
    public void RestartScene() //call to restart scene.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartRunnerLevel()
    {
        currentCharacter.GetComponent<RunnerMovement>().enabled = true; //enable player movement.
        currentCharacter.GetComponent<Swipe>().enabled = true; //enable swipe.
        planeToFindClicks.SetActive(true); 
    }
    public void MovementOnHit()
    {
        currentCharacter.GetComponent<RunnerMovement>().enabled = false;
        Invoke("DisableMoveMentOnHit", 1.5f);
    }
    private void DisableMoveMentOnHit()
    {
        currentCharacter.GetComponent<RunnerMovement>().enabled = true;
    }

}
