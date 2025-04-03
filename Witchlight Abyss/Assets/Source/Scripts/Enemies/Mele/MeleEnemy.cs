using UnityEngine;

public class MeleEnemy : EnemyBehaviour
{
    [SerializeField] private float _damage;
    protected override void Attack()
    {
        base.Attack();
        _playerHealth.GetDamage(_damage);
    }
}
