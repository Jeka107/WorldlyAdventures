using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMaze : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [HideInInspector] public float currentFielsOfView;

    private void Start()
    {
        playerTransform = FindObjectOfType<MazeGameManager>().currentCharacter.transform;
        currentFielsOfView = GetComponent<Camera>().fieldOfView;
    }
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x,
                transform.position.y,
                playerTransform.position.z);
        }
    }
    public void ChangeView(float view,float transitionSpeed) //function to change field view. used for power up.
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, view, transitionSpeed * Time.deltaTime);
    }
}
