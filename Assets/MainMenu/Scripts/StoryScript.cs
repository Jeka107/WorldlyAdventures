using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript : MonoBehaviour
{
    [SerializeField] private GameObject storyCanvasChapter1;
    [SerializeField] private GameObject storyCanvasChapter11;
    [SerializeField] private GameObject storyCanvasChapter2;
    [SerializeField] private GameObject storyCanvasChapter22;
    [SerializeField] private GameObject storyCanvasChapter3;
    [SerializeField] private GameObject storyCanvasChapter33;
    [SerializeField] private GameObject storyCanvasChapter4;
    [SerializeField] private GameObject storyCanvasChapter44;
    [SerializeField] private MainMenuScript mainMenuCanvas;
    private void Awake()
    {
        //checks if the player finished the last level of each world to enable the end level story chapter
        mainMenuCanvas = FindObjectOfType<MainMenuScript>();
        if (PlayerPrefs.GetInt("TutorialRunner") == 1)
        {
            if (PlayerPrefs.GetInt("Chapter11") != 1)
            {
                storyCanvasChapter11.SetActive(true);
        }
    }
        if (PlayerPrefs.GetInt("ToyFlyer") == 1)
        {
            if (PlayerPrefs.GetInt("Chapter22") != 1)
            {
                storyCanvasChapter22.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("JapaneseRunner") == 1)
        {
            if (PlayerPrefs.GetInt("Chapter33") != 1)
            {
                storyCanvasChapter33.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("JellyMaze") == 1)
        {
            if (PlayerPrefs.GetInt("Chapter44") != 1)
            {
                storyCanvasChapter44.SetActive(true);
            }  
        }
    }
    public void Chapter1()
    {
        //starts the first story chapter for each world accoring to which world is chosen
        if (mainMenuCanvas.chooseWorld == 0)
        {
            if (PlayerPrefs.GetInt("Chapter1") == 0)
            {
                storyCanvasChapter1.SetActive(true);
                PlayerPrefs.SetInt("Chapter1", 1);
            }
        }
        if (mainMenuCanvas.chooseWorld == 1)
        {
            if (PlayerPrefs.GetInt("Chapter2") == 0)
            {
                storyCanvasChapter2.SetActive(true);
                PlayerPrefs.SetInt("Chapter2", 1);
            }
        }
        if (mainMenuCanvas.chooseWorld == 2)
        {
            if (PlayerPrefs.GetInt("Chapter3") == 0)
            {
                storyCanvasChapter3.SetActive(true);
                PlayerPrefs.SetInt("Chapter3", 1);
            }
        }
        if (mainMenuCanvas.chooseWorld == 3)
        {
            if (PlayerPrefs.GetInt("Chapter4") == 0)
            {
                storyCanvasChapter4.SetActive(true);
                PlayerPrefs.SetInt("Chapter4", 1);
            }
        }

    }
    //button functions for each end level story chapter to save the player progression
    public void EndChapter1()
    {
        PlayerPrefs.SetInt("Chapter11", 1);
    }
    public void EndChapter2()
    {
        PlayerPrefs.SetInt("Chapter22", 1);
    }
    public void EndChapter3()
    {
        PlayerPrefs.SetInt("Chapter33", 1);
    }
    public void EndChapter4()
    {
        PlayerPrefs.SetInt("Chapter44", 1);
    }
}
