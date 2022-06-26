using UnityEngine;

public class MainDoodleMovement : DoodleMovement
{
    [SerializeField] float powerUpJumpForce;
    [SerializeField] private GameObject particleEffect;

    private float oldJumpForce;

    void Start()
    {
        oldJumpForce = jumpHeight;//remmember jumphight.
    }

    void Update()
    {
        Move(); 
        KeepOnScreen();

        if (powerUp) //check power up on
        {
            particleEffect.SetActive(true); //activate particle effects.
            jumpHeight = powerUpJumpForce; //set new jumphight.
        }
        else
        {
            particleEffect.SetActive(false);// deactivate particle effects.
            jumpHeight = oldJumpForce;  //set old jumphight.
        }
    }
    
}
