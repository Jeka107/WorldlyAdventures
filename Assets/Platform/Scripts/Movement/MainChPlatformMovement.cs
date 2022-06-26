using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChPlatformMovement : PlatformPlayerMovement
{
    [SerializeField] private float speedOnPowerUp = 0f;
    [SerializeField] private GameObject particleEffect;

    private void Update()
    {
        if(GetComponent<PowerUp>().checkPowerUp()) //power up on
        {
            particleEffect.SetActive(true); //activate particles.
            SetNewSpeed(speedOnPowerUp);    //set new speed for player.
            Move();
            FlipPlayer();
        }
        else
        {
            particleEffect.SetActive(false); //deactivate particles.
            Move();
            FlipPlayer();
        }
    }
}
