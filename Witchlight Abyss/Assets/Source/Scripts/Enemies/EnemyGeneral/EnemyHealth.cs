using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private GameObject _mana;
    [SerializeField] private GameObject _heal;
    [SerializeField] private float _dropChance = 35;
    public virtual void GetDamage(float damage)
    {
      
        _health -= damage;
        if(_health < 0)
        {
            for (int i = 0; i < Random.Range(9, 12); i++)
            {
                Instantiate(_mana, transform.position + new Vector3(Random.Range(0.2f, 2f), Random.Range(0.2f, 2f), Random.Range(0.2f, 2f)), Quaternion.identity);
            }
            if(_dropChance >= Random.Range(0, 100))
            {
                Instantiate(_heal, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
