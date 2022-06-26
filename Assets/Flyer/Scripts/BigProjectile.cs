using UnityEngine;

public class BigProjectile : MonoBehaviour
{
    //for soldier power

    [SerializeField] private float projectileSpeed = 0f;

    [HideInInspector] public Transform enemyTransform;

    private void FixedUpdate()
    {
        if (enemyTransform != null)
        {
            //move big bullet to enemy positon.
            transform.position = Vector3.MoveTowards(transform.position, enemyTransform.position, projectileSpeed * Time.fixedDeltaTime);
        }
    }
}
