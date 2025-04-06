using NavMeshPlus.Extensions;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

abstract public class EnemyBehaviour : MonoBehaviour
{
    
    [SerializeField] protected float _rageDistance;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected float _reloadTime;
    protected GameObject _player;
    protected PlayerHealth _playerHealth;
    protected bool _isDead = false;
    protected bool _isRaged;
    protected bool _canAttack = true;
    protected bool _inAttackRange = false;
    private void Start()
    {
        _player = FindAnyObjectByType<PlayerHealth>().gameObject;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _playerHealth = _player.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        float dist = Vector2.Distance(_player.transform.position, transform.position);
        if (dist < _rageDistance)
        {
            _agent.SetDestination(_player.transform.position);
            _isRaged = true;
        }
        _inAttackRange = dist < _attackDistance;
        if(_inAttackRange && _canAttack)
        {
            _inAttackRange=true;
            Attack();
        }
    }
    virtual protected void Attack()
    {
        StartCoroutine(ReloadAttack());
    }
    IEnumerator ReloadAttack()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_reloadTime);
        _canAttack = true;
    }
}
