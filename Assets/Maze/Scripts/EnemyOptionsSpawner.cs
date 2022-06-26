using System.Collections.Generic;
using UnityEngine;

public class EnemyOptionsSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyOptions;

    private int random;

    void Start() //activate enemies randomize bewtween some options.
    {
        random = Random.Range(0, enemyOptions.Count-1);

        enemyOptions[random].SetActive(true);
    }
}
