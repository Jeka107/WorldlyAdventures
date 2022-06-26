using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public GameObject CurrentWorld;
    [SerializeField] private Canvas MainMenu;
    [SerializeField] private GameObject SubPlayMenu0;
    [SerializeField] private GameObject SubPlayMenu1;
    [SerializeField] private GameObject SubPlayMenu2;
    [SerializeField] private GameObject SubPlayMenu3;
    public List<GameObject> Worlds;
    public int chooseWorld;
    [SerializeField] private TMP_Text CoinSum;
    [SerializeField] private TMP_Text NewTitles;
    [SerializeField] private GameObject RightArrow;
    [SerializeField] private GameObject LeftArrow;
    [SerializeField] private List<GameObject> TitlesList;
    [SerializeField] private int chooseTitle;
    [SerializeField] private GameObject Titles;
    private bool isDone;
    [SerializeField] private GameObject BigTitle1;
    [SerializeField] private GameObject BigTitle2;

    void Start()
    {
        //makes sure the game isn't paused unless the story script is active
       Time.timeScale = 1;
       //set the default state of the menu
        NewTitles.text = "Tutorial Island";
        spawnWorld();
        //sets the main title according to player progression (removes the "welcome to")
        if (PlayerPrefs.GetInt("Chapter1") == 0)
        {
            BigTitle1.SetActive(true);
            BigTitle2.SetActive(false);
        }
        else
        {
            BigTitle1.SetActive(false);
            BigTitle2.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        //updates the curret world chosen in UI
        if (isDone==true)
        {
            spawnWorld();
            isDone = false;
        }
      //updates the coin Sum in the UI
        CoinSum.text = PlayerPrefs.GetInt("Total Coins").ToString();
        
    }
    private void spawnWorld()
    {
        //creates the world object on the menu UI
        CurrentWorld = Instantiate(Worlds[chooseWorld],new Vector3(0.005f,1,-8.7f), Quaternion.identity);
        
        /*  Titles = Instantiate(TitlesList[chooseTitle], new Vector3(540,1460.5f, 0), Quaternion.identity,
              GameObject.FindGameObjectWithTag("Titles").transform);*/
    }

    void DestroyWorld()
    {
        //destroys the last world bedfore the new one is created
        Destroy(Titles);
        Destroy(CurrentWorld);
        isDone = true;
    }

    public void WorldUP()
    {

        //forward button functions for the arrows to move between worlds at UI
        chooseWorld++;
        if (chooseWorld<=1)
        {
            LeftArrow.SetActive(true);
            NewTitles.text = "Tutorial Island";
        }
        if (chooseWorld == 1)
        {
            NewTitles.text = "Toy World";
        }
        if (chooseWorld == 2)
        {
            NewTitles.text = "Japanese World";
        }
        if (chooseWorld == 3)
        {
            RightArrow.SetActive(false);
            NewTitles.text = "Jelly World";
        }
      /*  chooseTitle ++;
        if (chooseTitle <= 1)
        {
            LeftArrow.SetActive(true);


        }
        if (chooseTitle == 3)
        {
            RightArrow.SetActive(false);
        }*/
        DestroyWorld();

    }
    public void WorldDown()
    {
        //backward button functions for the arrows to move between worlds at UI
        chooseWorld = chooseWorld-1;
        if (chooseWorld == 0)
        {
            LeftArrow.SetActive(false);
            NewTitles.text = "Tutorial Island";
        }
        if (chooseWorld == 3)
        {
            NewTitles.text = "Jelly World";
        }
        if (chooseWorld == 1)
        {
            NewTitles.text = "Toy World";
        }
        if (chooseWorld == 2)
        {
            RightArrow.SetActive(true);
            NewTitles.text = "Japanese World";
        }
    /*    chooseTitle = chooseTitle - 1;
        if (chooseTitle == 0)
        {
            LeftArrow.SetActive(false);
        }
        if (chooseTitle <= 2)
        {
            RightArrow.SetActive(true);

        }*/
        DestroyWorld();
    }
    public void OpenSubMenu()
    {
        //"play" button function - opens sub menu according to current world
        if (chooseWorld == 0)
        {
            SubPlayMenu0.SetActive(true);
        }
        if (chooseWorld == 1)
        {
            SubPlayMenu1.SetActive(true);
        }
        if (chooseWorld == 2)
        {
            SubPlayMenu2.SetActive(true);
        }
        if (chooseWorld == 3)
        {
            SubPlayMenu3.SetActive(true);
        }

    }

}
