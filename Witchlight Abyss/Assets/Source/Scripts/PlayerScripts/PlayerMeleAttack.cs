using System.Collections;
using UnityEngine;

public class PlayerMeleAttack : MonoBehaviour
{
    [SerializeField] private GameObject _meleAttack;
    [SerializeField] private Animator _anim;
    private bool _canAttack = true;
    private float _timeBetweenAttacks = 0.6f;
    public bool IsActive = true;
    void Update()
    {
        if(!IsActive) return;
        if( _canAttack && Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Attacking());
        }
    }
    IEnumerator Attacking()
    {
        
        _anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.1f);
        _canAttack = false;
        _meleAttack.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _meleAttack.SetActive(false);
        yield return new WaitForSeconds(_timeBetweenAttacks);
        _canAttack = true;
    }
}
