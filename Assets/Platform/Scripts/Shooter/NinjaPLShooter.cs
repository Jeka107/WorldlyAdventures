using UnityEngine;

public class NinjaPLShooter : BaseShooter
{
    [SerializeField] private int numBullets;

    private CharacterController controller;
    private PlayerControls playerInput;
    private GameObject button;
    private int shoot = 0;

    private void Awake()
    {
        playerInput = new PlayerControls();
        controller = GetComponent<CharacterController>();
        button = FindObjectOfType<GamePlayStats>().firebutton;
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        if (GetComponent<PowerUp>().checkPowerUp()&& shoot < numBullets) //power up on and max shoot no used.
        {
            button.gameObject.SetActive(true); //activate shoot button
        }
        else if (shoot >= numBullets) //max shoots used.
        {
            button.gameObject.SetActive(false); //deactivate shoot button.
            GetComponent<PowerUp>().SetBool(); //set false power up.
            shoot = 0;
        }

        if (playerInput.Player.Fire.triggered && shoot < numBullets) //shoot button pressed and max shoot no used.
        {
            if (GetComponent<PlatformPlayerMovement>().checkDirection == 1) //check facing direction.
            {
                direction = transform.right; //for shooting right.
                Fire(); ;                   //shoot
                shoot++;                   //count shoots.
            }

            if (GetComponent<PlatformPlayerMovement>().checkDirection == -1)//check facing direction.
            {
                direction = -transform.right;//for shooting left.
                Fire();                      //shoot
                shoot++;                     //count shoots.
            }
        }
        
    }
}
