using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunnerWall : MonoBehaviour
{
    [SerializeField] private List<GameObject> rockMaterials;
    [SerializeField] private GameObject cube;

    private int materialNum;

    private void Start()
    {
        //randomize blocks and spawn them.

        materialNum = Random.Range(0, 4);
        Destroy(cube);
        Instantiate(rockMaterials[materialNum], transform.position, Quaternion.identity,transform);
    }
}
