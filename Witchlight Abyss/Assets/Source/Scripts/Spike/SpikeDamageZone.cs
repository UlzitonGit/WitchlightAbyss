using UnityEngine;

public class SpikeDamageZone : MonoBehaviour
{
    [SerializeField] private float _damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().GetDamage(_damage);
        }
    }
}
