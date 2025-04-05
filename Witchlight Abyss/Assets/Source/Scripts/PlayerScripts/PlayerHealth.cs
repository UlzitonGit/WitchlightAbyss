using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _hp;
    private float _maxHealth;
    private void Start()
    {
        _maxHealth = _hp;
    }
    public void GetDamage(float damage)
    {
        _hp -= damage;
        _hpBar.fillAmount = _hp / _maxHealth;
        if (_hp < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
