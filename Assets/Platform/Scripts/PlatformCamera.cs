using System.Collections;
using UnityEngine;
using Cinemachine;

public class PlatformCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    private GameObject currentCharacter;
    private CinemachineFramingTransposer framingTransposer;
    private int checkDirection;

    void Start()
    {
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        StartCoroutine(SetCamera());    
    }
    IEnumerator SetCamera()
    {
        yield return new WaitForSeconds(0.1f); //for safety.
        currentCharacter = FindObjectOfType<PlatformGameManager>().currentCharacter; //get current character.
        GetComponent<CinemachineVirtualCamera>().Follow = currentCharacter.transform; //set object to followe
    }
    private void Update()
    {
        checkDirection = FindObjectOfType<PlatformPlayerMovement>().checkDirection; //get direction.

        //depends on moving diraction change framing transposer.
        if (checkDirection==1)
        {
            framingTransposer.m_ScreenX = 0.25f;
        }
        else if(checkDirection == -1)
        {
            framingTransposer.m_ScreenX = 0.75f;
        }
    }

}
