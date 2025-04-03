using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    private float _moveSpeed = 5f;

    private bool isFlipped = false;
    Rigidbody2D rb;
    [SerializeField] private GameObject _flipPart;
    [SerializeField] private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {

        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        FlipX(horizontal < 0);
        Vector2 move = new Vector2(horizontal, vertical);
        rb.linearVelocity = move * _moveSpeed;

        animator.SetBool("Move", move.magnitude > 0);
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
}