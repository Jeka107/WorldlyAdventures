using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoEnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigTwo> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping;

    private WaveConfigTwo currentWave;
    private List<GameObject> enemies;
    private GameObject enemyOne;
    private GameObject enemyTwo;
    private bool spawnedAll;
    private int j;

    [HideInInspector] public bool done;

    //similer to reguler enemy spawner but spawning to path in the same time.
    void Start()
    {
        enemies = FindObjectOfType<Spawner>().enemies;
        StartCoroutine(SpawnWaves());
    }

    public WaveConfigTwo GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnWaves()
    {
        do
        {
            foreach (WaveConfigTwo wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCountOne(); i++)
                {
                    enemyOne = Instantiate(currentWave.GetEnemyPrefabOne(i), currentWave.GetStartingWayPointOne().position, Quaternion.Euler(0f, 0f, 180f), transform);
                    enemyTwo = Instantiate(currentWave.GetEnemyPrefabTwo(i), currentWave.GetStartingWayPointTwo().position, Quaternion.Euler(0f, 0f, 180f), transform);
                    enemies.Add(enemyOne);
                    enemies.Add(enemyTwo);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                j++;
                if (j < waveConfigs.Count)
                {
                    yield return new WaitForSeconds(timeBetweenWaves);
                }
            }
            
        } while (isLooping);
        spawnedAll = true;
    }
    private void Update()
    {
        if (enemies.Count != 0)
        {
            if (enemies[0] == null)
            {
                enemies.RemoveAt(0);
            }
        }
        else if (spawnedAll && enemies.Count == 0)
        {
            done = true;
        }
    }
}
