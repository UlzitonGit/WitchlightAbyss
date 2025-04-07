using NavMeshPlus.Extensions;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

abstract public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected Animator _anim;
    [SerializeField] protected float _rageDistance;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    protected GameObject _player;
    protected PlayerHealth _playerHealth;
    protected bool _isDead = false;
    protected bool _isRaged;
    protected bool _canAttack = true;
    protected bool _inAttackRange = false;
    public bool IsActive = true;
    
    private void Start()
    {
        IsActive = true;
        //_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _player = FindAnyObjectByType<PlayerHealth>().gameObject;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _playerHealth = _player.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        if (!IsActive) return;
        float dist = Vector2.Distance(_player.transform.position, transform.position);
        if (dist < _rageDistance)
        {
            _agent.SetDestination(_player.transform.position);
            _isRaged = true;
            _spriteRenderer.flipX = transform.position.x > _player.transform.position.x;
            
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
