using NavMeshPlus.Extensions;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

abstract public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected GameObject _player;
    [SerializeField] protected float _rageDistance;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected float _reloadTime;
    protected PlayerHealth _playerHealth;
    protected bool _isDead = false;
    protected bool _isRaged;
    protected bool _canAttack = true;
    private void Start()
    {
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
        if(_isRaged && dist < _attackDistance && _canAttack)
        {
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
