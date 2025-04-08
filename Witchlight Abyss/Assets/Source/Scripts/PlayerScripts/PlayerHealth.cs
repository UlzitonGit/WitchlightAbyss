using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _hp;
    [SerializeField] private Animator _anim;
    PlayerMovement _movement;
    private float _maxHealth;
    private void Start()
    {
        _maxHealth = _hp;
        _movement = GetComponent<PlayerMovement>();
    }
    public void GetDamage(float damage)
    {
        _hp -= damage;
        _hpBar.fillAmount = _hp / _maxHealth;
        if (_hp <= 0)
        {
            StartCoroutine(Death());
        }
    }
    public void GetHealth(float health)
    {
        _hp += health;
        if (_hp >= _maxHealth)
        {
            _hp = _maxHealth;
        }
        _hpBar.fillAmount = _hp / _maxHealth;
    }
    IEnumerator Death()
    {
        _anim.SetBool("Death", true);
        _movement._moveSpeed = 0;
        _movement.enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
