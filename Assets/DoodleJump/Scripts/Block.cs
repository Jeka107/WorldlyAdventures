using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private List<GameObject> branchs;  //list of different branches.
    [SerializeField] private GameObject cube;

    private GameObject branch;
    private void Awake()
    {
        int random;

        random = Random.Range(0, 2);

        //randomize block depends on position.
        if (transform.position.x<0)
        {
            branch=Instantiate(branchs[random], transform.position, Quaternion.identity, transform);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            if(random==0)
            {
                branch.transform.Rotate(0f, 0f, 90f, Space.Self);
            }
        }
        else
        {
            branch=Instantiate(branchs[random], transform.position, Quaternion.identity, transform);

            if (random == 0)
            {
                branch.transform.Rotate(0f, 0f, 90f, Space.Self);
            }
        }
        cube.SetActive(false);
    }
}
