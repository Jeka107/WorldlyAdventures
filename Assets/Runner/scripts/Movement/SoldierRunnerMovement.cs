using UnityEngine;

public class SoldierRunnerMovement : RunnerMovement
{
    [SerializeField] private GameObject Shield;

    private void Update()
    {
        Move();
        if (powerUp) //power up on
        {
            ActiveShield(); //activate shield
        }
        else
        {
            DeActiceShield();//deactivate shieldd
        }
    }
    private void ActiveShield()
    {
        Shield.SetActive(true);
    }
    private void DeActiceShield()
    {
        Shield.SetActive(false);
    }
}
