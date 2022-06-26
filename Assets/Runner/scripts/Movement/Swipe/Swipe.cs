using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] private float minDistance = .2f;
    [SerializeField] private float maxTime = 1f;
    [SerializeField,Range(0,1)] private float directionTreshHold = .9f;

    private RunnerMovement runnerMovement;
    private Vector3 startPosition;
    private float startTime;
    private Vector3 endPosition;
    private float endTime;

    [HideInInspector] public int swipeDirection;

    void Awake()
    {
        runnerMovement = GetComponent<RunnerMovement>();
    }
    private void OnEnable()
    {
        runnerMovement.OnStartTouch += SwipeStart;
        runnerMovement.OnEndTouch += SwipeEnd;
    }
    private void OnDisable()
    {
        runnerMovement.OnStartTouch -= SwipeStart;
        runnerMovement.OnEndTouch -= SwipeEnd;
    }
    private void SwipeStart(Vector3 position,float time)
    {
        startPosition = position;
        startTime = time;
    }
    private void SwipeEnd(Vector3 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }
    private void DetectSwipe() //detect swipe direction.
    {
        if(Vector3.Distance(startPosition,endPosition)>=minDistance&&(endTime-startTime)<=maxTime)
        {
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }
    private void SwipeDirection(Vector2 direction) //check swipe direction.
    {
        if (Vector2.Dot(Vector2.down, direction) > directionTreshHold)
        {
            swipeDirection = -2;
        }
        else if(Vector2.Dot(Vector2.up,direction)> directionTreshHold)
        {
            swipeDirection = 2;
        }
        else if(Vector2.Dot(Vector2.left, direction) > directionTreshHold)
        {
            swipeDirection = -1;
        }
        else if(Vector2.Dot(Vector2.right, direction) > directionTreshHold)
        {
            swipeDirection = 1;
        }
    }
}
