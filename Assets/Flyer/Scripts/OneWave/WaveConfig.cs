using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="WaveConfig",fileName="newWave Config")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] public List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed=5f;
    [SerializeField] private float timeBetweenSpawns = 1f;
    [SerializeField] float spawnTimeVariance=0f;
    [SerializeField] float minSpawnTime = 0.2f;
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach(Transform child in pathPrefab)
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
