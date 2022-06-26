using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : DoodleEnemy
{
    [SerializeField] private float timeDiraction;
    [SerializeField] private bool xRotaion;
    [SerializeField] private bool zRotaion;

    void Update()
    {
        MoveBlockEnemy();
    }
    private void MoveBlockEnemy()//move enemy in the right direction.
    {
        if (MovingRight())
        {
            rb.velocity = new Vector3(speed, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector3(-speed, 0f, 0f);
        }
    }
    bool MovingRight()//checking the direction.
    {
        return rb.velocity.x > 0;
    }
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Wall") //on trigger change direction.
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.x = newVelocity.x * (-1);
            rb.velocity = newVelocity;
           
            if (transform.rotation != Quaternion.Euler(0f, 0f, 0f)) //flip enemy
            {
                FlipEnemyFacing();
            }
            else
            {
                FlipEnemyFacing2();
            }
        }
        if (other.gameObject.tag == "Player" && other.GetComponent<SoldierDoodleMovement>()) //when soldier power up is on.
        {
            if (FindObjectOfType<DoodleMovement>().powerUp) //if on then ignore collision with enemyis.
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), other, true);
            }
            else
            {
                FindObjectOfType<DoodleGameManager>().RestartScene(); //else restart the secne,game over.
            }
            Physics.IgnoreCollision(GetComponent<Collider>(), other, false); //colision back.
        }
        else if (other.gameObject.tag == "Player") //restart scene,game over.
        {
            FindObjectOfType<DoodleGameManager>().RestartScene();
        }
        if(other.gameObject.tag == "Bullet") //kill enemy.
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    private void FlipEnemyFacing() //function to flip gameobject
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      
        if (xRotaion)
        {
            transform.localScale = new Vector3(-(Mathf.Sign(rb.velocity.x)), 1f, 1f);
        }
    }
    private void FlipEnemyFacing2() //function to flip gameobject
    {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        if (xRotaion)
        {
            transform.localScale = new Vector3(-(Mathf.Sign(rb.velocity.x)), 1f, 1f);
        }
    }
}
