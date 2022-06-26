using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class FlyerNewMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private GravityCoin coin;

    private Camera mainCamera;
    private CharacterController characterController;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    private Vector3 oldDirection;
    private PlayerControls playerControls;
    private Vector3 direction;

    [HideInInspector] public int scoreCoin;
    [HideInInspector] public bool isFirstTouched;

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
    }
    private void OnDisable()
    {
        playerControls.Touch.PrimaryContactHold.started -= ctx => FingerTouched(ctx);
        playerControls.Disable(); 
    }


    private void FingerTouched(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
        RaycastHit hit;
        
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider != null)
            {
                if ((hit.collider.CompareTag("Draggable"))) //if draggable object touched(player)
                {
                    StartCoroutine(DragUpdate(hit.collider.gameObject));
                }
            }
        }
    }
    private IEnumerator DragUpdate(GameObject touchedObject) //drag the player
    {
        //calculate distance.
        float initialDistance = Vector3.Distance(touchedObject.transform.position, mainCamera.transform.position); 


        while (playerControls.Touch.PrimaryContact.ReadValue<float>() != 0) //while touching the screen.
        {

            Ray ray = mainCamera.ScreenPointToRay(playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()); //to find point.

            if (characterController != null)
            {
                //calculate moving direction.
                direction = (ray.GetPoint(initialDistance) - touchedObject.transform.position).normalized;
                direction.z = 0;

                //if moving the finger.
                if (Touchscreen.current.primaryTouch.phase.ReadValue() == (UnityEngine.InputSystem.TouchPhase.Moved))
                {
                    if (oldDirection != direction)
                        characterController.Move(direction * playerSpeed);  //move the player.
                }
                oldDirection = direction;
                yield return waitForFixedUpdate; //do it evert fixed update.
            }
            else
            {
                yield return null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin") //collect coins and add to score.
        {
            scoreCoin += coin.coinValue;
        }
    }
}
