using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StoreScript : MonoBehaviour
{
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

    [SerializeField] private Image soliderCoin;
    [SerializeField] private Image ninjaCoin;
    [SerializeField] private Image gummyCoin;

    [SerializeField] private TMP_Text soliderPriceText;
    [SerializeField] private TMP_Text ninjaPriceText;
    [SerializeField] private TMP_Text gummyPriceText;
    [SerializeField] private TMP_Text soliderBuy;
    [SerializeField] private TMP_Text ninjaBuy;
    [SerializeField] private TMP_Text gummyBuy;

    [SerializeField] private Button TheBoy;
    [SerializeField] private Button TheSolider;
    [SerializeField] private Button NinjaDog;
    [SerializeField] private Button GummyBear;
    public Sprite ActiveCharButton;
    public Sprite InActiveCharButton;

    [SerializeField] private int soliderPrice;
    [SerializeField] private int ninjaPrice;
    [SerializeField] private int gummyPrice;
    //the script for all the buttons and functions of the store sub menu
    private void Start()
    {
        //setting the menu button states to update UI
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
        if (PlayerPrefs.GetInt("SoliderSold") == 1)
        {
            soliderLock0.enabled = false;
            soliderLock1.enabled = false;
            soliderLock2.enabled = false;
            soliderLock3.enabled = false;
            soliderBuy.text = "Select";
            soliderPriceText.text = ("Sold!");
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
            ninjaBuy.text = "Select";
            ninjaPriceText.text = ("Sold!");
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
            gummyPriceText.text = ("Sold!");
            gummyBuy.text = "Select";
        }
        else
        {
            gummyLock0.enabled = true;
            gummyLock1.enabled = true;
            gummyLock2.enabled = true;
            gummyLock3.enabled = true;
        }
    }
    private void FixedUpdate()
    {
        //checking the store state to update UI in character selction sub menus
        if (PlayerPrefs.GetInt("SoliderSold")==1)
        {
            soliderLock0.enabled = false;
            soliderLock1.enabled = false;
            soliderLock2.enabled = false;
            soliderLock3.enabled = false;
            soliderBuy.text = "Select";
            soliderPriceText.text = ("Sold!");
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
            ninjaBuy.text = "Select";
            ninjaPriceText.text = ("Sold!");
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
            gummyPriceText.text = ("Sold!");
            gummyBuy.text = "Select";
        }
        else
        {
            gummyLock0.enabled = true;
            gummyLock1.enabled = true;
            gummyLock2.enabled = true;
            gummyLock3.enabled = true;
        }
    }
    public void BuySolider()
    {
        //Buy button for the solider
        if (PlayerPrefs.GetInt("SoliderSold") == 1)
        {
            TheSolider.GetComponent<Image>().sprite = ActiveCharButton;
            TheBoy.GetComponent<Image>().sprite = InActiveCharButton;
            NinjaDog.GetComponent<Image>().sprite = InActiveCharButton;
            GummyBear.GetComponent<Image>().sprite = InActiveCharButton;
            PlayerPrefs.SetInt("charSelected", 1);
        }
        else if (PlayerPrefs.GetInt("Total Coins") >= soliderPrice)
        {
            { 
                PlayerPrefs.SetInt("SoliderSold", 1);
                PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") - soliderPrice);
                PlayerPrefs.Save();
            }  
        }
    }
    public void BuyNinja()
    {
        //Buy button for the ninja
        if (PlayerPrefs.GetInt("NinjaSold") ==1)
        {
            NinjaDog.GetComponent<Image>().sprite = ActiveCharButton;
            TheBoy.GetComponent<Image>().sprite = InActiveCharButton;
            TheSolider.GetComponent<Image>().sprite = InActiveCharButton;
            GummyBear.GetComponent<Image>().sprite = InActiveCharButton;
            PlayerPrefs.SetInt("charSelected", 2);
        }
        else if (PlayerPrefs.GetInt("Total Coins") >= ninjaPrice)
        { 
                PlayerPrefs.SetInt("NinjaSold", 1);
                PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") - ninjaPrice);
                ninjaCoin.enabled = false;
            PlayerPrefs.Save();
        }
    }
    public void BuyGummy()
    {
        //Buy button for the gummy bear
        if (PlayerPrefs.GetInt("GummySold")==1)
        {
            GummyBear.GetComponent<Image>().sprite = ActiveCharButton;
            TheBoy.GetComponent<Image>().sprite = InActiveCharButton;
            TheSolider.GetComponent<Image>().sprite = InActiveCharButton;
            NinjaDog.GetComponent<Image>().sprite = InActiveCharButton;
            PlayerPrefs.SetInt("charSelected", 3);
        }
        else if (PlayerPrefs.GetInt("Total Coins") >= gummyPrice)
        {
            PlayerPrefs.SetInt("GummySold", 1);
            PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") - gummyPrice);
            gummyCoin.enabled = false;
            PlayerPrefs.Save();
        }
    }
    public void BuyBoy()
    {
        //select button for the boy
        TheBoy.GetComponent<Image>().sprite = ActiveCharButton;
        TheSolider.GetComponent<Image>().sprite = InActiveCharButton;
        NinjaDog.GetComponent<Image>().sprite = InActiveCharButton;
        GummyBear.GetComponent<Image>().sprite = InActiveCharButton;
        PlayerPrefs.SetInt("charSelected", 0);
    }
}
