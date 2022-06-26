using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaRunnerMovement : RunnerMovement
{

    [SerializeField] private GameObject particleEffect;
    private void Update()
    { 
        if (powerUp) //power up on
        {
           particleEffect.SetActive(true); //particles on
            foreach (EnemyRunnerWall enemy in enemies) //for each enemy disable collider.
            {
                if (enemy != null)
                {
                    enemy.GetComponent<Collider>().enabled = false;
                }
            }
        }
        else
        {
            particleEffect.SetActive(false); //particles off.
            foreach (EnemyRunnerWall enemy in enemies) //for eah enemy enable collider back.
            {
                if (enemy)
                {
                    enemy.GetComponent<Collider>().enabled = true;
                }
            }
        }
        Move();
    }
   
}
