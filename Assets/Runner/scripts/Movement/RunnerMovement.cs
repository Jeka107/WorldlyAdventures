using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RunnerMovement : MonoBehaviour
{
    public delegate void StartTouch(Vector3 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector3 position, float time);
    public event EndTouch OnEndTouch;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] public Vector3 direction;
    [SerializeField] private float gravityScale;
    [SerializeField] private float jumpForce;
    [SerializeField] private float laneDistance;
    [SerializeField] private float sideForce;
    [SerializeField] public Vector3 kick;
    [SerializeField] private Coin coin;

    private CharacterController characterController;
    private PlayerControls playerControls;
    private Camera mainCamera;
    private int swipeDirection;
    private int currentLane;

    [HideInInspector] public bool powerUp;
    [HideInInspector] public int scoreCoin;
    [HideInInspector] public EnemyRunnerWall[] enemies;

    private void Awake()
    {
        playerControls = FindObjectOfType<InputManager>().playerControls;
        mainCamera = Camera.main;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        enemies = FindObjectsOfType<EnemyRunnerWall>();

        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch!=null)
        {
            OnStartTouch(Utils.ScreenToRay(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(),layerMask)
                ,(float)context.startTime); //touch started
        }
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
        {
            OnEndTouch(Utils.ScreenToRay(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(), layerMask)
                , (float)context.time); //touch ended.
        }

        //swipe direction 
        swipeDirection = FindObjectOfType<Swipe>().swipeDirection;

        if (characterController.isGrounded)
        {
            if (swipeDirection == 2)//jumping
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            if (swipeDirection == -2)  //falling
            {
                direction.y = -jumpForce;
            }
        }
        if (swipeDirection == -1)    //moving left
        {
            currentLane = Mathf.Clamp(currentLane - 1, -1, 1);
        }
        if (swipeDirection == 1)     //moving right
        {
            currentLane = Mathf.Clamp(currentLane + 1, -1, 1);
        }
    }

    private void Update()
    {
        Move();
    }
    public void Move()
    {
        if (GetComponent<PowerUp>().checkPowerUp())
        {
            powerUp = true;
        }
        else
        {
            powerUp = false;
        }

        direction.y += gravityScale * Time.deltaTime;

        direction.x = (-transform.position.x + currentLane * laneDistance) * sideForce; //move direction
    }
    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime); //move player in direction.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin") //collect coin and add to score.
        {
            scoreCoin += coin.coinValue;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Wall") //player hit wall
        {
            GetComponentInChildren<Animator>().SetBool("isHit", true);
            direction = kick;
            characterController.Move(direction * Time.deltaTime);
            FindObjectOfType<RunnerGameManager>().MovementOnHit();
            StartCoroutine(WaitBeforeRestart());
        }
    }
    public IEnumerator WaitBeforeRestart() //restart scene
    {
        yield return new WaitForSeconds(1.2f);
        FindObjectOfType<RunnerGameManager>().RestartScene();
    }
}
