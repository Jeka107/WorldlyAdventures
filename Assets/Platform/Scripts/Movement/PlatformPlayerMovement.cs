using UnityEngine;

public class PlatformPlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float jumpTime;
    [SerializeField] public int scoreCoin;
    [SerializeField] private Coin coin;
    [SerializeField] public Transform body;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool isJumping;
    private float jumpTimeCount;
    private Vector3 move;

    private Vector2 movementInput;
    private float staticSpeed;
    [HideInInspector] public PlayerControls playerInput;
    [HideInInspector] public int checkDirection;
    private void Awake()
    {
        staticSpeed = playerSpeed;
        playerInput = new PlayerControls();
        controller = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        Move();
        FlipPlayer();
    }
    public void Move()
    {
        groundedPlayer = controller.isGrounded; //to check if player on the ground.
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
        }

        movementInput = playerInput.Player.Move.ReadValue<Vector2>(); //get movement input when using controller.
        move = new Vector3(movementInput.x, playerVelocity.y, 0f);   //set move.

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }


        if (playerInput.Player.Jump.triggered && groundedPlayer)//first jump
        {
            playerVelocity.y = Mathf.Sqrt(-jumpHeight * gravityValue);
            jumpTimeCount = jumpTime;
            isJumping = true;
            GetComponent<Animator>().SetBool("isJumping", true); //jump animation
        }
        if (playerInput.Player.Jump.inProgress && isJumping)//continuous jump
        {
            if (jumpTimeCount > 0)
            {
                playerVelocity.y = Mathf.Sqrt(-jumpHeight * gravityValue);
                jumpTimeCount -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                GetComponent<Animator>().SetBool("isJumping", false); 
            }
        }
        else
        {
            isJumping = false;
            GetComponent<Animator>().SetBool("isJumping", false); //set false jump animation
        }
        if (groundedPlayer==false)
        {
            GetComponent<Animator>().SetBool("isJumping", true); //set true jump animation
        }
        playerVelocity.y += gravityValue * 2f * Time.deltaTime;

        if (move != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Running", true); //set true running animation
        }
        else
        {
            GetComponent<Animator>().SetBool("Running", false);//set false running animation
        }

        //move direction
        if (movementInput.x > 0)
        {
            checkDirection = 1;
        }
        else if (movementInput.x < 0)
        {
            checkDirection = -1;
        }
        else
        {
            GetComponent<Animator>().SetBool("Running", false); //not moving set false running animation.
        }
    }
    private void FixedUpdate()
    {
        controller.Move(move * Time.fixedDeltaTime * playerSpeed); //move player.
    }
    public void FlipPlayer() //flip player to moving direction.
    {
        bool playerMovingX = Mathf.Abs(movementInput.x) > Mathf.Epsilon;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (playerMovingX)
        {
            body.localScale = new Vector3(24f, 24f, Mathf.Sign(movementInput.x)*24);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin") //collect coin and add to score.
        {
            scoreCoin += coin.coinValue;
        }
    }

    public void SetNewSpeed(float newSpeed) //to set new speed. used in power up.
    {
        playerSpeed = newSpeed;
        Invoke("SetOldSpeed", GetComponent<PowerUp>().waitTime);
    }
    private void SetOldSpeed() //back to default speed.
    {
        playerSpeed = staticSpeed;
    }
}
