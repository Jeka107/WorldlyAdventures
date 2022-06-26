using System.Collections;
using UnityEngine;

public class MainRunnerMovement : RunnerMovement
{
    [SerializeField] private GameObject particleEffect;

    private Vector3 beforeDeathPosition;
    private Vector3 oldDirection;

    private void Update()
    {
        Move();
        if (powerUp)//power up on
        {
            particleEffect.SetActive(true); //particles on
        }
        else
        {
            particleEffect.SetActive(false);//particles off
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Wall")
        {
            oldDirection = direction;
            GetComponentInChildren<Animator>().SetBool("isHit", true); //hit animation

            if (powerUp) //power up on
            {
                //second chance
                direction = kick;
                hit.gameObject.GetComponent<Collider>().enabled = false;
                GetComponent<PowerUp>().SetBool();
                FindObjectOfType<RunnerGameManager>().MovementOnHit();
                StartCoroutine(KeepMoving());
            }
            else //restart scene.
            {
                FindObjectOfType<RunnerGameManager>().MovementOnHit();
                StartCoroutine(WaitBeforeRestart());
            }
        }
    }
    IEnumerator KeepMoving() //when power up on after hit the player will stand up and move on.
    {
        yield return new WaitForSeconds(1.5f);
        GetComponentInChildren<Animator>().SetBool("isHit", false);
        direction.z = kick.z+8f;
        yield return new WaitForSeconds(1.5f);
        direction = oldDirection;
    }
}
