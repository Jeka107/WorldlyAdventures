using System.Collections.Generic;
using UnityEngine;

public class PathFinderOne : MonoBehaviour
{
    private TwoEnemySpawner enemySpawner;
    private WaveConfigTwo waveConfig;
    private List<Transform> waypoints;
    private bool checkInScreen = false;
    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<TwoEnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypointsOne();
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
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            checkInScreen = true;
        }
    }
    public bool GetCheckInScreen()
    {
        return checkInScreen;
    }
}
