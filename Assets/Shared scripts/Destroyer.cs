using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Player")
        {
           if(FindObjectOfType<DoodleGameManager>())
            {
                FindObjectOfType<DoodleGameManager>().RestartScene();
            }
            if (FindObjectOfType<PlatformGameManager>())
            {
                FindObjectOfType<PlatformGameManager>().RestartScene();
            }
        }
        if(other.gameObject.tag=="Coin")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Tree")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(other.gameObject);
        }
    }

}
