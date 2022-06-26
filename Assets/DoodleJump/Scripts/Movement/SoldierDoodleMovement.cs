using UnityEngine;

public class SoldierDoodleMovement : DoodleMovement
{
    [SerializeField] private GameObject bubbleShield;

    void Update()
    {
        Move();
        KeepOnScreen();

        if (powerUp)//if power up is on.
        {
            bubbleShield.SetActive(true); //activate shieled.
            GetComponentInChildren<Animator>().SetBool("BubbleSize", true); //activate shieled increase.
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("BubbleSize", false);//activate shieled reduce.
            bubbleShield.SetActive(false); //deactivarte shieled.
        }
    }
}
