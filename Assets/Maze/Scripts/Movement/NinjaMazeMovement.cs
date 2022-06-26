using UnityEngine;

public class NinjaMazeMovement : MazePlayerMovement
{
    [SerializeField] private float fieldOfView;
    [SerializeField] private float cameraTransitionSpeed;

    void Update()
    {
        powerUp = GetComponent<PowerUp>().checkPowerUp();

        if (powerUp)//power up on
        {
            Camera.main.GetComponent<CameraFollowMaze>().ChangeView(fieldOfView, cameraTransitionSpeed);//increase camera view field
        }
        else if(!powerUp)
        {
            //back to reguler camera view field.
            Camera.main.GetComponent<CameraFollowMaze>().ChangeView(Camera.main.GetComponent<CameraFollowMaze>().currentFielsOfView
                , cameraTransitionSpeed);
        }
        Move();
        FlipPlayer();
    }
}
