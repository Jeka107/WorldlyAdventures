using UnityEngine;

public class SoldierMazeMovement : MazePlayerMovement
{
    private GameObject road;
    private void Start()
    {
        road = FindObjectOfType<MazeGrid>().road; //find road gameobject
    }
    void Update()
    {
        powerUp = GetComponent<PowerUp>().checkPowerUp();
        if(powerUp)//power up on
        {
            road.SetActive(true);  //activate road
        }
        else
        {
            road.SetActive(false); //deactivate road
        }

        Move();
        FlipPlayer();
    }
}
