using UnityEngine;

public class RangedEnemy : EnemyBehaviour
{
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private Transform _spp;
    protected override void Attack()
    {
        Instantiate(_enemyBullet, _spp.position, _spp.rotation);
        base.Attack();
    }
}
