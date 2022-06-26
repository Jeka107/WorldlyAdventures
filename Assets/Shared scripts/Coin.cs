using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] public int coinValue = 50;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(other.tag=="Block")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(other.tag=="PowerUp")
        {
            Destroy(gameObject);
        }
    }
}
