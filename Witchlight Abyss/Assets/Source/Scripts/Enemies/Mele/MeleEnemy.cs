using UnityEngine;

public class MeleEnemy : EnemyBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private Animator _anim;
    protected override void Attack()
    {
        base.Attack();
        _anim.SetTrigger("Attack");
    }
    public void Attacking()
    {
        if (!_inAttackRange) return;
        _playerHealth.GetDamage(_damage);
    }
}
