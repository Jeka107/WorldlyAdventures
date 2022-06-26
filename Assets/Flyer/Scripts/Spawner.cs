using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemySpawners;
    [SerializeField] float timeToSpawnNext;
    [SerializeField] public List<GameObject> enemies;

    [HideInInspector] public bool finished;

    private int i;

    private void Start()
    {
        enemySpawners[i].SetActive(true); //activate spawner.
    }

    private void Update()
    {
        //cheking which spawner and moving on the list when all enemis are spawned in current spawner.
        if (i < enemySpawners.Count)
        {
            if (enemySpawners[i].GetComponent<EnemySpawner>() != null)
            {
                if (enemySpawners[i].GetComponent<EnemySpawner>().done)
                {
                    enemySpawners[i].SetActive(false);
                    i++;
                    if (i < enemySpawners.Count)
                    {
                        enemySpawners[i].SetActive(true);
                    }
                }
            }
            else if (enemySpawners[i].GetComponent<TwoEnemySpawner>() != null)
            {
                if (enemySpawners[i].GetComponent<TwoEnemySpawner>().done)
                {
                    enemySpawners[i].SetActive(false);
                    i++;
                    if (i < enemySpawners.Count)
                    {
                        enemySpawners[i].SetActive(true);
                    }
                }
            }
        }
        else
        {
            finished = true; //if all spawner are done.
        }
    }

}
