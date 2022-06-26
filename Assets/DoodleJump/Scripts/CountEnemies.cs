using System.Collections.Generic;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemies;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy") //if enemy add to list.
        {
            enemies.Add(other.gameObject);
        }
    }
    private void Update()
    {
        if (enemies.Count != 0)//if first in list empty then remove.
        {
            if (enemies[0] == null)
                enemies.RemoveAt(0);
        }
    }
}
