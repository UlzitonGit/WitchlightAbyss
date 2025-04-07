using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    private float _moveSpeed = 3.5f;

    private bool isFlipped = false;
    Rigidbody2D rb;
    [SerializeField] private GameObject _flipPart;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _dashPower;

    private PlayerMeleAttack _playerMele;
    private PlayerShoot _playerShoot;
    private bool _canDash = true;
    private bool _canWalk = true;
    private float _dashTime = 0.25f;
    private float _dashReload = 1;
    private void Start()
    {
        _playerMele = GetComponentInChildren<PlayerMeleAttack>();
        _playerShoot = GetComponentInChildren<PlayerShoot>();
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {

        Move();
    }

    public void Move()
    {
        if (!_canWalk) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _animator.SetBool("Up", vertical > 0);
        _animator.SetBool("Down", vertical < 0);
        FlipX(horizontal < 0);
        Vector2 move = new Vector2(horizontal, vertical);
        rb.linearVelocity = move * _moveSpeed;

        _animator.SetBool("Move", move.magnitude > 0);
        if(Input.GetKey(KeyCode.E) && _canDash)
        {
            Dash(new Vector2(horizontal, vertical));
        }
    }
    private void FlipX(bool flipped)
    {
        if (isFlipped != flipped)
        {
            isFlipped = flipped;
            Vector3 localScale = _flipPart.transform.localScale;
            localScale.x *= -1;
            _flipPart.transform.localScale = localScale;
        }

    }
    private void Dash(Vector2 dir)
    {
        _canWalk = false;
        rb.AddForce(dir * _dashPower, ForceMode2D.Impulse);
        StartCoroutine(Dashing());
    }
    IEnumerator Dashing()
    {
        _playerShoot.IsActive = false;
        _playerMele.IsActive = false;
        _canDash = false;
        _animator.SetTrigger("DashSide");
        yield return new WaitForSeconds(_dashTime);
        _canWalk = true;
        _playerShoot.IsActive = true;
        _playerMele.IsActive = true;
        yield return new WaitForSeconds(_dashReload);
        _canDash = true;
    }
}