using UnityEngine;

public class EnemyAttackMananger : MonoBehaviour
{
    [SerializeField] private MeleEnemy _mele;
    public void Attack()
    {
        _mele.Attacking();
    }
}
