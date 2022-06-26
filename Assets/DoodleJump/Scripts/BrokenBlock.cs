using UnityEngine;

public class BrokenBlock : MonoBehaviour
{
    [SerializeField] private float timeToWait;

    public void BlockGravity()//when called block falls down.
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
