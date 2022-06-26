using UnityEngine;

public class CameraFollowRunner : MonoBehaviour
{
    [SerializeField] private RunnerGameManager gameManager;

    [SerializeField] private Transform playerPosition;
    private Vector3 offSet;

    void Start()
    {
        playerPosition = gameManager.currentCharacter.transform;
        offSet = playerPosition.position - transform.position;
    }
    void Update()
    { 
        //follow player on z.
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPosition.position.z - offSet.z);
    }
}
