using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandom : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> points;

    private int randomNumber;
    private Transform point;

    void Start()
    {
        randomNumber = Random.Range(0, 2);
        point = points[randomNumber].GetComponent<Transform>();

        if(point.localScale.x==1)
        {
            Instantiate(enemies[0], point.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemies[1], points[randomNumber].GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
