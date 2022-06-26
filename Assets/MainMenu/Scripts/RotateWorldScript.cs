using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateWorldScript : MonoBehaviour
{
    [SerializeField]private float rotatespeed = 10f;

    private Rigidbody rb;
    private float startingPosition;
    private PlayerControls playerControls;
    private Camera mainCamera;
    private Vector3 startPosition;
    private Vector3 endposition;
    private WaitForEndOfFrame waitForUpdate = new WaitForEndOfFrame();
    private Vector3 startTouch;
    private Vector3 endTouch;
    private Vector3 direction;
    private float startTime;

    //a script for moving to the world in the main menu UI

    private void Awake()
    {
        //set the compenents and objects to use in the script
        playerControls = new PlayerControls();
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerControls.Enable(); 
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Start()
    {
        playerControls.Touch.PrimaryContact.started += ctx => StartFingerTouched(ctx);
        playerControls.Touch.PrimaryContact.started += ctx => MoveFingerTouched(ctx);
    }

    private void StartFingerTouched(InputAction.CallbackContext context)
    {
        //sets all the values for the moment the finger touches the screen
        Ray ray = mainCamera.ScreenPointToRay(playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if ((hit.collider.CompareTag("Draggable")))
                {
                    float initialDistance = Vector3.Distance(hit.collider.gameObject.transform.position, mainCamera.transform.position);
                    startTouch = (ray.GetPoint(initialDistance) - hit.collider.gameObject.transform.position).normalized;
                    startTime = (float)context.startTime;
                }
            }
        }
    }
    private void MoveFingerTouched(InputAction.CallbackContext context)
    {
        //sets all the values for the moment the finger moves on the screen
        float time;
        Ray ray = mainCamera.ScreenPointToRay(playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if ((hit.collider.CompareTag("Draggable")))
                {
                    time = (float)context.time;
                    StartCoroutine(DragUpdate(hit.collider.gameObject, time));
                }
            }
        }
    }
    private IEnumerator DragUpdate(GameObject touchedObject,float time)
    {
        // the coroutine for using all the touch values
        float initialDistance = Vector3.Distance(touchedObject.transform.position, mainCamera.transform.position);
        
        
        while (playerControls.Touch.PrimaryContact.ReadValue<float>() != 0)
        {
            
            Ray ray = mainCamera.ScreenPointToRay(playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
            
            endTouch = (ray.GetPoint(initialDistance) - touchedObject.transform.position).normalized;
            endTouch.z = 0;
            
            if (Touchscreen.current.primaryTouch.phase.ReadValue() == (UnityEngine.InputSystem.TouchPhase.Moved))
            {

                direction = (endTouch - startTouch).normalized ;
                direction.z = 0;


                float x = direction.x * Mathf.Deg2Rad * rotatespeed * Time.deltaTime;
                transform.RotateAround(Vector3.down, x);

                float y = direction.y * Mathf.Deg2Rad * rotatespeed*Time.deltaTime;
                transform.RotateAround(Vector3.right, y);

                startTouch = endTouch;
            }

            yield return waitForUpdate;
        }
    }

    /*void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startingPosition = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    if (startingPosition > touch.position.x)
                    {
                        CurrentWorlds.transform.Rotate(Vector3.back, -rotatespeed * Time.deltaTime);
                    }
                    else if (startingPosition < touch.position.x)
                    {
                        CurrentWorlds.transform.Rotate(Vector3.back, rotatespeed * Time.deltaTime);
                    }
                    break;
            }
        }
    }*/
}