using System.Collections;
using UnityEngine;

public class PlayerMeleAttack : MonoBehaviour
{
    [SerializeField] private GameObject _meleAttack;
    private bool _canAttack = true;
    private float _timeBetweenAttacks = 0.6f;
  
    void Update()
    {
        if( _canAttack && Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Attacking());
        }
    }
    IEnumerator Attacking()
    {
        _canAttack = false;
        _meleAttack.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _meleAttack.SetActive(false);
        yield return new WaitForSeconds(_timeBetweenAttacks);
        _canAttack = true;
    }
}
