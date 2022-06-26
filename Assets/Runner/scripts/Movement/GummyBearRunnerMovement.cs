using UnityEngine;

public class GummyBearRunnerMovement : RunnerMovement
{
    [SerializeField] private GameObject bigCollider;

    private bool done;

    private void Update()
    {
        Move();
        if (powerUp) //power up on
        {
            if (!done)
            {
                IncreaseSize();
            }
        }
        else
        {       
            if (done)
            {
                ReduceSize();
            }
        }
    }
    private void IncreaseSize() //increase animation on.
    {
        bigCollider.SetActive(true); //collider on.
        if (GetComponentInChildren<Animator>())
        {
            Invoke("AbleBigColliderAnimation", 0.05f);
        }
        done = true;
    }
    private void ReduceSize() //reduce player.
    {
        if (GetComponentInChildren<Animator>())
        {
            GetComponentInChildren<Animator>().SetBool("Increase", false); //reduce animation.
        }
        
        Invoke("DisableBigCollider", 1f); //collider of after second.
        done = false;
    }
    private void DisableBigCollider()
    {
        bigCollider.SetActive(false); //collider off
    }
    private void AbleBigColliderAnimation() 
    {
        GetComponentInChildren<Animator>().SetBool("Increase", true); //animation activated.
    }
}
