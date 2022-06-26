using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JapTreeSpawner : MonoBehaviour
{

    [SerializeField] GameObject treePrefab;
    [SerializeField] int distanceOnStartTrees;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Transform finishTriggerTransform;

    private GameObject treeLeft;
    private GameObject treeRight;
    private Vector3 treePlaceLeft;
    private Vector3 treePlaceRight;

    void Start()
    {
        treePlaceLeft = new Vector3(-5f, 2, -2.5f);
        treePlaceRight = new Vector3(5f, 2, -2.5f);
        SpawnStartTree(); //spawn first trees.
    }

    void Update()
    {
        if (Camera.main.transform.position.z > spawnPosition.z - 100 && Camera.main.transform.position.z <= finishTriggerTransform.position.z - 225)
        {
            SpawnNewTrees(); //spawn trees when player moving.
            spawnPosition.z += 2.5f;
        }

    }

    private void SpawnStartTree()
    {
        for (int i = 5; i < distanceOnStartTrees;)
        {
            treePlaceLeft.z += 2.5f;
            treePlaceRight.z += 2.5f;
            treeLeft = Instantiate(treePrefab, treePlaceLeft, Quaternion.identity, transform);
            treeLeft.transform.Rotate(0f, 90, 0f, Space.Self);
            treeRight = Instantiate(treePrefab, treePlaceRight, Quaternion.identity, transform);
            treeRight.transform.Rotate(0f, 90, 0f, Space.Self);
            i += 5;
        }
    }
    private void SpawnNewTrees()
    {
        treePlaceLeft.z += 2.5f;
        treePlaceRight.z += 2.5f;


        treeLeft = Instantiate(treePrefab, treePlaceLeft, Quaternion.identity, transform);
        treeLeft.transform.Rotate(0f, 90, 0f, Space.Self);
        treeRight = Instantiate(treePrefab, treePlaceRight, Quaternion.identity, transform);
        treeRight.transform.Rotate(0f, 90, 0f, Space.Self);
    }
}
