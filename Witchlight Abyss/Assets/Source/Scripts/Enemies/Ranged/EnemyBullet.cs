using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Vector3 _dir;
    [SerializeField] private ParticleSystem _vfx;
    [SerializeField] private float _damage = 10;
    void Update()
    {
        transform.Translate(_dir * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Player"))
        {
            _vfx.Play();
            _dir = _dir * 0;
            GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(Destroy());
            if (collision.CompareTag("Player")) collision.GetComponent<PlayerHealth>().GetDamage(_damage);
        }
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }
}