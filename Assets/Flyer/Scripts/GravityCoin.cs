using UnityEngine;

public class GravityCoin : MonoBehaviour
{
    [SerializeField] public int coinValue = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")//if plyaer touched then destroy gamobject.
        {
            Destroy(gameObject);
        }
    }
}