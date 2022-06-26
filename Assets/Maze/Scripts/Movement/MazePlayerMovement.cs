using UnityEngine;

public class MazePlayerMovement : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] public float jumpHeight = 1.0f;
    [SerializeField] public float gravityValue = -9.81f;
    [SerializeField] private Vector3 kick = new Vector3(10f,0f, 10f);
    [SerializeField] public Coin coin;
    [SerializeField] public int scoreCoin;
    [SerializeField] public float rotationSpeed;

    private Vector2 movementInput;
    private Vector3 move;
    [HideInInspector] public GameObject button;
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public Vector3 playerVelocity;
    [HideInInspector] public bool groundedPlayer;
    [HideInInspector] public PlayerControls playerInput;
    [HideInInspector] public bool powerUp;
    [HideInInspector] public bool jumped;

    private void Awake()
    {
        playerInput = new PlayerControls();
        controller = GetComponent<CharacterController>();
        button = FindObjectOfType<GamePlayStats>().jumpbutton;
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
        groundedPlayer = controller.isGrounded; //for checking if player on the ground

        if (groundedPlayer && playerVelocity.y < 0) 
        {
            playerVelocity.y = -0.5f;
        }
         
        movementInput = playerInput.Player.Move.ReadValue<Vector2>(); //get movement input from controller.
        move = new Vector3(movementInput.x, playerVelocity.y, movementInput.y); //move direction

        if (playerInput.Player.Jump.triggered && groundedPlayer) //if touche jump button and the player is on the ground
        {
            playerVelocity.y += Mathf.Sqrt(-jumpHeight * gravityValue); //jump
            jumped = true; //jumped happened.
        }

        playerVelocity.y += gravityValue * Time.deltaTime; //player fall back to ground.
    }
    private void FixedUpdate()
    {
        controller.Move(move * Time.fixedDeltaTime * playerSpeed); //move player
    }

    public void FlipPlayer() 
    {
        Vector3 movementDirection = new Vector3(movementInput.x, 0, movementInput.y);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero) //if moving
        {
            //rotate player to the diraction we moving.
            Quaternion toRotaion = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotaion, rotationSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin") //collect coin and add to score.
        {
            scoreCoin += coin.coinValue;
        }
    }
}
