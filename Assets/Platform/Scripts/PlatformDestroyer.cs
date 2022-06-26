using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //call restart function if player triggered.
        {
            FindObjectOfType<PlatformGameManager>().RestartScene();
        }
        if (other.gameObject.tag == "Coin") //destroy coin if triggered.
        {
            FindObjectOfType<PlatformGameManager>().RestartScene();
        }
    }
}
