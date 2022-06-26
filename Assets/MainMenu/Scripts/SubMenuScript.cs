using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SubMenuScript : MonoBehaviour
{
    [SerializeField] private Button TheBoy;
    [SerializeField] private Button TheSolider;
    [SerializeField] private Button NinjaDog;
    [SerializeField] private Button GummyBear;
    [SerializeField] private GameObject MainMenu;

    [SerializeField] private Image soliderLock0;
    [SerializeField] private Image soliderLock1;
    [SerializeField] private Image soliderLock2;
    [SerializeField] private Image soliderLock3;

    [SerializeField] private Image ninjaLock0;
    [SerializeField] private Image ninjaLock1;
    [SerializeField] private Image ninjaLock2;
    [SerializeField] private Image ninjaLock3;

    [SerializeField] private Image gummyLock0;
    [SerializeField] private Image gummyLock1;
    [SerializeField] private Image gummyLock2;
    [SerializeField] private Image gummyLock3;

    public Sprite ActiveCharButton;
    public Sprite InActiveCharButton;

    void Update()
    {
        //updating the character select menu visuals according to the character chosen
        if (PlayerPrefs.GetInt("charSelected") == 0)
        {
            TheBoy.GetComponent<Image>().sprite = ActiveCharButton;
            TheSolider.GetComponent<Image>().sprite = InActiveCharButton;
            NinjaDog.GetComponent<Image>().sprite = InActiveCharButton;
            GummyBear.GetComponent<Image>().sprite = InActiveCharButton;
        }
        if (PlayerPrefs.GetInt("charSelected") == 1)
        {
           TheSolider.GetComponent<Image>().sprite = ActiveCharButton;
            TheBoy.GetComponent<Image>().sprite = InActiveCharButton;
            NinjaDog.GetComponent<Image>().sprite = InActiveCharButton;
            GummyBear.GetComponent<Image>().sprite = InActiveCharButton;
        }
        if (PlayerPrefs.GetInt("charSelected") == 2)
        {
            NinjaDog.GetComponent<Image>().sprite = ActiveCharButton;
            TheBoy.GetComponent<Image>().sprite = InActiveCharButton;
            TheSolider.GetComponent<Image>().sprite = InActiveCharButton;
            GummyBear.GetComponent<Image>().sprite = InActiveCharButton;
        }
        if (PlayerPrefs.GetInt("charSelected") == 3)
        {
            GummyBear.GetComponent<Image>().sprite = ActiveCharButton;
            TheBoy.GetComponent<Image>().sprite = InActiveCharButton;
            TheSolider.GetComponent<Image>().sprite = InActiveCharButton;
            NinjaDog.GetComponent<Image>().sprite = InActiveCharButton;
        }
        //updating the character select menu visuals according to the characters bought in the store
        if (PlayerPrefs.GetInt("SoliderSold") == 1)
            {
                soliderLock0.enabled = false;
                soliderLock1.enabled = false;
                soliderLock2.enabled = false;
                soliderLock3.enabled = false;
            }
            else
            {
                soliderLock0.enabled = true;
                soliderLock1.enabled = true;
                soliderLock2.enabled = true;
                soliderLock3.enabled = true;
            }
            if (PlayerPrefs.GetInt("NinjaSold") == 1)
            {
                ninjaLock0.enabled = false;
                ninjaLock1.enabled = false;
                ninjaLock2.enabled = false;
                ninjaLock3.enabled = false;
            }
            else
            {
                ninjaLock0.enabled = true;
                ninjaLock1.enabled = true;
                ninjaLock2.enabled = true;
                ninjaLock3.enabled = true;
            }
            if (PlayerPrefs.GetInt("GummySold") == 1)
            {
                gummyLock0.enabled = false;
                gummyLock1.enabled = false;
                gummyLock2.enabled = false;
                gummyLock3.enabled = false;
            }
            else
            {
                gummyLock0.enabled = true;
                gummyLock1.enabled = true;
                gummyLock2.enabled = true;
                gummyLock3.enabled = true;
            }
        
    }
    //All the calls (buttons) for the 13 games scenes (levels) from the menu
    #region Load Game Scences
    public void OpenTutorialJumper()
    {
        StartCoroutine(TutorialJumper());
    }
    IEnumerator TutorialJumper()
    {
        SceneManager.LoadScene("LoadingScreen");
        Debug.Log("yes");
        SceneManager.LoadScene("TutorialDoodleJump");
        yield return new WaitForSecondsRealtime(3);
    }
    public void OpenTutorialRunner()
    {
        SceneManager.LoadScene("TutorialRunner");
    }
    public void OpenToyRunner()
    {
        SceneManager.LoadScene("ToyRunner");
    }
    public void OpenToyPlayform()
    {
        SceneManager.LoadScene("ToyPlatform");
    }
    public void OpenToyFlyer()
    {
        SceneManager.LoadScene("ToyFlyer");
    }
    public void OpenJapJumper()
    {
        SceneManager.LoadScene("JapaneseDoodleJump");
    }
    public void OpenJapPlatform()
    {
        SceneManager.LoadScene("JapanesePlatform");
    }
    public void OpenJapMaze()
    {
        SceneManager.LoadScene("JapaneseMaze");
    }
    public void OpenJapRunner()
    {
        SceneManager.LoadScene("JapaneseRunner");
    }
    public void OpenJellyJumper()
    {
        SceneManager.LoadScene("JellyDoodleJump");
    }
    public void OpenJellyPlat()
    {
        SceneManager.LoadScene("JellyPlatformer");
    }
    public void OpenJellyFlyer()
    {
        SceneManager.LoadScene("JellyFlyer");
    }
    public void OpenJellyMaze()
    {
        SceneManager.LoadScene("JellyMaze");
    }
    #endregion


}
