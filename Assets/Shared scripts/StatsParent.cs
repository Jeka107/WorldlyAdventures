using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsParent : MonoBehaviour
{
    [SerializeField] public int health = 15;
    [SerializeField] public int enemyValue;
    [SerializeField] private bool applyCameraShake;

    [HideInInspector] public CameraShake cameraShake;

    private void Awake()
    {
        if (Camera.main.GetComponent<CameraShake>() != null)
        {
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
