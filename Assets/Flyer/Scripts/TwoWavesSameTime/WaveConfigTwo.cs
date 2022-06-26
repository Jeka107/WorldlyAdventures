using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WaveConfigTwo", fileName = "newWave ConfigTwo")]
public class WaveConfigTwo : ScriptableObject
{
    [SerializeField] public List<GameObject> enemyPrefabsOne;
    [SerializeField] public List<GameObject> enemyPrefabsTwo;
    [SerializeField] private Transform pathPrefab_1;
    [SerializeField] private Transform pathPrefab_2;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeBetweenSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.2f;

    //similer to reguler waveconfig but used to two paths in the same time.
    public int GetEnemyCountOne()
    {
        return enemyPrefabsOne.Count;
    }

    public GameObject GetEnemyPrefabOne(int index)
    {
        return enemyPrefabsOne[index];
    }
    public int GetEnemyCountTwo()
    {
        return enemyPrefabsTwo.Count;
    }

    public GameObject GetEnemyPrefabTwo(int index)
    {
        return enemyPrefabsTwo[index];
    }

    public Transform GetStartingWayPointOne()
    {
        return pathPrefab_1.GetChild(0);
    }
    public Transform GetStartingWayPointTwo()
    {
        return pathPrefab_2.GetChild(0);
    }

    public List<Transform> GetWaypointsOne()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab_1)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public List<Transform> GetWaypointsTwo()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab_2)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenSpawns - spawnTimeVariance, timeBetweenSpawns + spawnTimeVariance);

        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
