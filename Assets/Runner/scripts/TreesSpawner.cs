using UnityEngine;

public class TreesSpawner : MonoBehaviour //similer to JapTreeSpanwer
{
    [SerializeField] GameObject treePrefab;
    [SerializeField] int distanceOnStartTrees;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Transform finishTriggerTransform;

    private GameObject treeLeft;
    private GameObject treeRight;
    private Vector3 treePlaceLeft;
    private Vector3 treePlaceRight;
    private float randomYRotaion;
    
    void Start()
    {
        treePlaceLeft = new Vector3(-5f, -2.5f, 0f);
        treePlaceRight = new Vector3(7f, -2.5f, 0f);
        SpawnStartTree();
    }

    void Update()
    {
        if (Camera.main.transform.position.z> spawnPosition.z-100&& Camera.main.transform.position.z <= finishTriggerTransform.position.z-225)
        {
            SpawnNewTrees();
            spawnPosition.z += 5;
        }
        
    }

    private void SpawnStartTree()
    {
        for(int i=5;i< distanceOnStartTrees;)
        {
            randomYRotaion = Random.Range(0f, 100f);
            treePlaceLeft.z += 5;
            treePlaceRight.z += 5;
            treeLeft = Instantiate(treePrefab, treePlaceLeft, Quaternion.identity,transform);
            treeLeft.transform.Rotate(0f, randomYRotaion, 0f, Space.Self);
            treeRight = Instantiate(treePrefab, treePlaceRight, Quaternion.identity, transform);
            treeRight.transform.Rotate(0f, randomYRotaion, 0f, Space.Self);
            i += 5;
        }
    }
    private void SpawnNewTrees()
    {
        randomYRotaion = Random.Range(0f, 100f);
        treePlaceLeft.z += 5;
        treePlaceRight.z += 5;
        

        treeLeft = Instantiate(treePrefab, treePlaceLeft, Quaternion.identity, transform);
        treeLeft.transform.Rotate(0f, randomYRotaion, 0f, Space.Self);
        treeRight = Instantiate(treePrefab, treePlaceRight, Quaternion.identity, transform);
        treeRight.transform.Rotate(0f, randomYRotaion, 0f, Space.Self);
    }
}
