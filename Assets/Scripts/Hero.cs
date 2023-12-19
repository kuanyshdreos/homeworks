using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
        UpdateAnimator();
    }

    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        sprite.flipX = (horizontalInput < 0);
    }

    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalInput * speed, jumpForce);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (isGrounded)
        {
            animator.SetBool("IsJump", false);
        }
        else
        {
            animator.SetBool("IsJump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}