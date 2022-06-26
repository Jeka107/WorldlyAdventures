using UnityEngine;

public class PlatformCoinsSpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] int randomMax;
    [SerializeField] float aboveTheBlock;

    private int random;

    private void Start()
    {
        //spawn coins on random positons.

        random = Random.Range(0, randomMax);

        if (random == 1)
        {
            Instantiate(coin, new Vector3(transform.position.x, transform.position.y + aboveTheBlock, transform.position.z),
                Quaternion.identity,transform);
        }
    }
}
