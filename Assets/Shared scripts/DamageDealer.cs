using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    public int GeTDamage()
    {
        return damage;
    }
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
