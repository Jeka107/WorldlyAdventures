using UnityEngine;

public class CameraFollowDoodle : MonoBehaviour
{
    [SerializeField] private Transform playerTramsform;
    [SerializeField] private DoodleGameManager gameManager;

    private void Start()
    {
        playerTramsform = gameManager.currentCharacter.transform;
    }

    void Update()
    {
        if (playerTramsform != null)
        {
            if (playerTramsform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x,
                    playerTramsform.position.y,
                    transform.position.z);
            }
        }
    }
}
