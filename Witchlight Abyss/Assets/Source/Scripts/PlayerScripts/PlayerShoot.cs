using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeBetweenShoots;
    private Camera _camera;
    private ManaMananger _manaMananger;
    private bool _canShoot = true;
    private int _manaCost = 10;
    public bool IsActive = true;
    private void Start()
    {
        _manaMananger = GetComponent<ManaMananger>();
        _camera = FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        if (!IsActive) return;
        Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);
        if (Input.GetKey(KeyCode.Mouse1) && _canShoot && _manaMananger.Mana > 0)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        StartCoroutine(Reload());
        _manaMananger.MinusMana(_manaCost);
        _animator.SetTrigger("Shoot");
        Instantiate(_bullet, transform.position, transform.rotation);
    }
    IEnumerator Reload()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_timeBetweenShoots);
        _canShoot = true;
    }
}