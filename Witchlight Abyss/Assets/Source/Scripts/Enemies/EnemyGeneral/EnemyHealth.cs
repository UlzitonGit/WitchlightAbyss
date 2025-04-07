using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private GameObject _mana;
    [SerializeField] private GameObject _heal;
    [SerializeField] private float _dropChance = 35;
    [SerializeField] private Animator _anim;
    private EnemyBehaviour _enemyBehaviour;
    private bool _dead = false;
    private RoomZone _roomZone;
    private bool _isCounted = false;
    private void Start()
    {
        _enemyBehaviour = GetComponent<EnemyBehaviour>();
    }
    public virtual void GetDamage(float damage)
    {
        if (_dead) return;
        _health -= damage;
        _anim.SetTrigger("GetDamage");
        if (_health < 0)
        {
            for (int i = 0; i < Random.Range(9, 12); i++)
            {
                Instantiate(_mana, transform.position + new Vector3(Random.Range(0.2f, 2f), Random.Range(0.2f, 2f), Random.Range(0.2f, 2f)), Quaternion.identity);
            }
            if(_dropChance >= Random.Range(0, 100))
            {
                Instantiate(_heal, transform.position, Quaternion.identity);
            }
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        _roomZone._enemyCount -= 1;
        _dead = true;
        _enemyBehaviour.IsActive = false;
        _anim.SetBool("Death", true);
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FightZone") && !_isCounted)
        {
            _roomZone = collision.GetComponent<RoomZone>();
            _roomZone._enemyCount ++;
            _isCounted = true;
        }
    }
}
