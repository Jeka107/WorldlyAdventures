using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    private EnemySpawner enemySpawner;
    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private bool checkInScreen=false;
    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Count) 
        {
            Vector3 targetPosition = waypoints[waypointIndex].position; //point position.
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta); //move to point target.
            if (transform.position == targetPosition)
            {
                waypointIndex++; //go to next point.
            }
        }   
        else
        {
            Destroy(gameObject); //no point targer destroy gameobject.
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Wall")
        {
            checkInScreen = true;
        }
    }
    public bool GetCheckInScreen()
    {
        return checkInScreen;
    }
}
