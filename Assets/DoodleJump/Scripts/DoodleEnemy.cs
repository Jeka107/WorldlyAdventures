using UnityEngine;

public class DoodleEnemy : MonoBehaviour
{
    [SerializeField] public float speed;

    [HideInInspector] public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        MoveEnemy();
        KeepOnScreen();
    }
    private void OnTriggerEnter(Collider other)
    {
        //check soldier power up if soldier power is on the ignore colision
        if (other.gameObject.tag == "Player"&&other.GetComponent<SoldierDoodleMovement>()) 
        {
            if (FindObjectOfType<DoodleMovement>().powerUp)             
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), other,true);
            }
            else
            {
                FindObjectOfType<GameManager>().RestartScene();
            }
            Physics.IgnoreCollision(GetComponent<Collider>(), other, false);
        }
        else if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().RestartScene();
        }
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    private void MoveEnemy() //enemy movement
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
        rb.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    private void KeepOnScreen() //keep enemy on screen
    {
        Vector3 newPos = transform.position;

        Vector3 veiwPos = Camera.main.WorldToViewportPoint(newPos);

        if (veiwPos.x > 1.1)
        {
            newPos.x = -newPos.x + 0.1f;
        }
        else if (veiwPos.x < -0.1)
        {
            newPos.x = -newPos.x - 0.1f;
        }

        transform.position = newPos;
    }
}
