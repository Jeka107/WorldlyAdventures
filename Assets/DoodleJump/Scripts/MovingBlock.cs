using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveBlock();
        KeepOnScreen();
    }
    private void MoveBlock()
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
    }
    private void KeepOnScreen()
    {
        Vector3 newPos = transform.position;

        Vector3 veiwPos = Camera.main.WorldToViewportPoint(newPos);

        if (veiwPos.x > 1)
        {
            newPos.x = -newPos.x + 0.2f;
        }
        else if (veiwPos.x < 0)
        {
            newPos.x = -newPos.x - 0.2f;
        }

        transform.position = newPos;
    }
}
