using UnityEngine;
using UnityEngine.InputSystem;

public class DoodleMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private Coin coin;
    [SerializeField] private float gravityValue = 0f;
    [SerializeField] public float jumpHeight = 0f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform body;

    [HideInInspector] public Vector3 move;
    [HideInInspector] public bool powerUp;
    [HideInInspector] public int checkScore;
    [HideInInspector] public PlayerControls playerControls;
    [HideInInspector] public int scoreCoin;
    [HideInInspector] public bool touched;

    private Camera mainCamera;
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private Vector3 direction;
    private GameObject brokenBlock;

    private void Awake()
    {
        playerControls = new PlayerControls();
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Touch.PrimaryContactHold.started += ctx => FingerTouched(ctx);
        playerControls.Touch.PrimaryContactHold.canceled += ctx => FingerStopTouched(ctx);
    }
    private void OnDisable()
    {
        playerControls.Touch.PrimaryContactHold.started -= ctx => FingerTouched(ctx);
        playerControls.Touch.PrimaryContactHold.canceled -= ctx => FingerStopTouched(ctx);
        playerControls.Disable();
    }
    private void FingerTouched(InputAction.CallbackContext context)
    {
        direction = Utils.ScreenToRay(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(),layerMask);
        //point we touched is the direction the player will move.
    }
    private void FingerStopTouched(InputAction.CallbackContext context)
    {
        direction = Vector3.zero;
        //when not touching screen the player will not move left or right.
    }
    void Update()
    {
        Move(); //every frame calculate direction.
    }
    public void Move()
    {
        move = new Vector3(direction.x * playerSpeed * Time.fixedDeltaTime, playerVelocity.y, 0f);

        //body rotarion depends on direction.
        if (direction.x > 0.1)
        {
            body.rotation = Quaternion.Euler(0f, 130f, 0f);
        }
        else if (direction.x < -0.1)
        {
            body.rotation = Quaternion.Euler(0f, 190f, 0f);
        }

        playerVelocity.y -= gravityValue * Time.deltaTime; //player falling

        if (GetComponent<PowerUp>().checkPowerUp()) //check power up
        {
            powerUp = true;
        }
        else
        {
            powerUp = false;
        }

        if(touched) //check if palyer touched the block.
        {
            brokenBlock.GetComponent<BrokenBlock>().BlockGravity();
            touched = false;
        }
        PlayAnimation();
    }
    private void FixedUpdate()
    {
        characterController.Move(move * Time.fixedDeltaTime); //Move
        KeepOnScreen();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if block then jump.
        if (other.tag == "Block") 
        {
            if (playerVelocity.y < 0)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * gravityValue);
            }
        }
        if (other.tag == "BrokenBlock")
        {
            if (playerVelocity.y < 0)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * gravityValue);
                brokenBlock = other.gameObject;
                touched = true;
            }
        }
        //if coin collect and add to score.
        if (other.tag == "Coin")
        {
            scoreCoin += FindObjectOfType<Coin>().coinValue;
        }
    }
    public void KeepOnScreen()//keep player on screen.
    {
        Vector3 newPos = transform.position;

        Vector3 veiwPos = Camera.main.WorldToViewportPoint(newPos);

        if (veiwPos.x > 1)
        {
            newPos.x = -newPos.x + 0.5f;
        }
        else if (veiwPos.x < 0)
        {
            newPos.x = -newPos.x - 0.5f;
        }
        transform.position = newPos;
    }

    public void PlayAnimation() //play animation.
    {
        if (playerVelocity.y > 0)
        {
            GetComponentInChildren<Animator>().SetBool("Jump", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("Jump", false);
        }
    }
}
