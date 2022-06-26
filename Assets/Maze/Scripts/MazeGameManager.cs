using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private int chooseCharacter;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int numCoins;
    [SerializeField] private Vector3 spawnCoinPosition;

    public Animator AnimateCharacter;
    public GameObject currentCharacter;
    private void Awake()
    {
        Time.timeScale = 1;
        chooseCharacter = PlayerPrefs.GetInt("charSelected");
        SpawnCharacter();
        AnimateCharacter = currentCharacter.GetComponentInChildren<Animator>();
        SpawnCoins();
    }

    private void Update()
    {
        //activate animation in conditions.
         if (currentCharacter.GetComponent<CharacterController>().velocity.x == 0 && currentCharacter.GetComponent<CharacterController>().velocity.z == 0)
         {
          AnimateCharacter.SetBool("isWalking", false);
         }
        if (currentCharacter.GetComponent<MazePlayerMovement>().playerInput.Player.Move.ReadValue<Vector2>().x !=0 || 
             currentCharacter.GetComponent<MazePlayerMovement>().playerInput.Player.Move.ReadValue<Vector2>().y != 0)
        {
            AnimateCharacter.SetBool("isWalking", true);
        }
        if (currentCharacter.GetComponent<CharacterController>().isGrounded)
        {
            AnimateCharacter.SetBool("isJumping", false);
        }
        if (currentCharacter.GetComponent<CharacterController>().isGrounded == false)
        {
            AnimateCharacter.SetBool("isJumping", true);
        }
       
    }
    private void SpawnCharacter() //spawn character selected.
    {
        currentCharacter = Instantiate(characters[chooseCharacter], characters[chooseCharacter].transform.position, Quaternion.identity);
    }
    private void SpawnCoins() //spawn coins randomly.
    {
        for (int i = 0; i < numCoins; i++)
        {
            float randCoinx = Random.Range(-9.5f, 9.5f);
            float randCoinz = Random.Range(-9.5f, 9.5f);

            spawnCoinPosition.x = randCoinx;
            spawnCoinPosition.z = randCoinz;

            Instantiate(coinPrefab, spawnCoinPosition, Quaternion.identity, transform); //create the coin at random position.
        }
    }

    public void RestartScene() //function to restart the scene.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
