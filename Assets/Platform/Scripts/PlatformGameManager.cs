using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformGameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private int chooseCharacter;

    public GameObject currentCharacter;

    void Start()
    {
        Time.timeScale = 1;
        chooseCharacter = PlayerPrefs.GetInt("charSelected");
        spawnCharacter();
    }
    private void spawnCharacter()
    {
        currentCharacter =Instantiate(characters[chooseCharacter], characters[chooseCharacter].transform.position, Quaternion.identity);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
