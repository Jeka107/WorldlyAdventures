using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping;
    
    
    private WaveConfig currentWave;
    private GameObject enemy;
    private List<GameObject> enemies;
    private bool spawnedAll;
    private int j;

    [HideInInspector] public bool done;

    void Start()
    {
        enemies = FindObjectOfType<Spawner>().enemies;
        StartCoroutine(SpawnWaves());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnWaves()
    {
        do
        {
            foreach (WaveConfig wave in waveConfigs) //spawn waves in current spawner.
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++) //spawn enemy
                {
                    //create and spawn enemy.
                    enemy=Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0f,0f,180f), transform);
                    enemies.Add(enemy); //adding to list to remmeber.
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime()); //wait between each enemy spawn.
                }
                j++;
                if (j < waveConfigs.Count) 
                {
                    yield return new WaitForSeconds(timeBetweenWaves); //wait time between waves.if last wave then no need to wait.
                }
            }
        } while (isLooping);
        spawnedAll = true; //all enemies spawned.
    }
    private void Update()
    {
        if (enemies.Count != 0) //if first enemy destroyed in list then remove first place.
        {
            if (enemies[0] == null)
            {
                enemies.RemoveAt(0);
            } 
        }
        else if (spawnedAll && enemies.Count == 0) //if all spawned.
        {
            done = true;
        }
    }
}
