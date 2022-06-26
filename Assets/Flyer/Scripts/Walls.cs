using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject downWall;

    void Start()
    {
        Vector3 newLeftWallPos = leftWall.GetComponent<Transform>().position;
        Vector3 newRightWallPos = rightWall.GetComponent<Transform>().position;
        Vector3 newtopWallPos = topWall.GetComponent<Transform>().position;
        Vector3 newdownWallPos = downWall.GetComponent<Transform>().position;
        Vector3 veiwPortPositionLeft = Camera.main.WorldToViewportPoint(newLeftWallPos);
        Vector3 veiwPortPositionRight = Camera.main.WorldToViewportPoint(newRightWallPos);
        Vector3 veiwPortPositionTop = Camera.main.WorldToViewportPoint(newtopWallPos);
        Vector3 veiwPortPositionDown = Camera.main.WorldToViewportPoint(newdownWallPos);

        while (veiwPortPositionLeft.x>-0.1)
        {
            newLeftWallPos.x -= 1f;
            veiwPortPositionLeft = Camera.main.WorldToViewportPoint(newLeftWallPos);
        }
        while (veiwPortPositionRight.x < 1.05)
        {
            newRightWallPos.x += 1f;
            veiwPortPositionRight = Camera.main.WorldToViewportPoint(newRightWallPos);
        }
        while (veiwPortPositionTop.y < 1)
        {
            newtopWallPos.y +=1f;
            veiwPortPositionTop = Camera.main.WorldToViewportPoint(newtopWallPos);
        }
        while (veiwPortPositionDown.y > -0.1)
        {
            newdownWallPos.y -= 1.8f;
            veiwPortPositionDown = Camera.main.WorldToViewportPoint(newdownWallPos);
        }


        leftWall.GetComponent<Transform>().position = newLeftWallPos;
        rightWall.GetComponent<Transform>().position = newRightWallPos;
        topWall.GetComponent<Transform>().position = newtopWallPos;
        downWall.GetComponent<Transform>().position = newdownWallPos;

        Camera.main.orthographic = false;
    }
}
