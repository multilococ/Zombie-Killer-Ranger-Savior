using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public void TakeDamage(float damage)
    {
        Debug.Log(gameObject.name + "is taked damage");
    }
}
