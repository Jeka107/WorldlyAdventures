using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Vector3 enemySpeed;
    [SerializeField] private bool xRotaion;
    [SerializeField] private bool zRotaion;

    private Rigidbody rb;
    private bool start=true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (start == true)
        {
            Invoke("EnemyMove", 1f);
        }
        else
        {
            EnemyMove();
        }
    }
    private void EnemyMove()
    {
        rb.velocity = new Vector3(enemySpeed.x, enemySpeed.y, enemySpeed.z)*Time.fixedDeltaTime;
        start = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.tag=="Wall")
        {
            enemySpeed = -enemySpeed;
            FlipEnemyFacing();
        }
        if (other.tag == "Player")
        {
            if (FindObjectOfType<MazeGameManager>())
            {
                FindObjectOfType<MazeGameManager>().RestartScene();
            }
            if (FindObjectOfType<PlatformGameManager>())
            {
                FindObjectOfType<PlatformGameManager>().RestartScene();
            }
        }
    }
    private void FlipEnemyFacing()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (xRotaion)
        {
            transform.localScale = new Vector3(-(Mathf.Sign(rb.velocity.x)), 1f, 1f);
        }
        if (zRotaion)
        {
            transform.localScale = new Vector3(1f, 1f, -(Mathf.Sign(rb.velocity.z)));
        }
    }
}
