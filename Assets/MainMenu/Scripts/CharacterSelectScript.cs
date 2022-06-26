using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScript : MonoBehaviour
{
    //handles the character selction for all other scence through buttons on the main menu
    public void SelectMainChar()
    {
        PlayerPrefs.SetInt("charSelected", 0);
    }
    public void SelectSoliderChar()
    {
        PlayerPrefs.SetInt("charSelected", 1);
    }
    public void SelectNinjaChar()
    {
        PlayerPrefs.SetInt("charSelected", 2);
    }
    public void SelectGummyChar()
    {
        PlayerPrefs.SetInt("charSelected", 3);
    }
}
