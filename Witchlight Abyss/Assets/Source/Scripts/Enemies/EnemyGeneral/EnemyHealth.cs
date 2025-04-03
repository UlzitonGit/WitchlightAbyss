using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    public virtual void GetDamage(float damage)
    {
        _health -= damage;
        if(_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
