using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    private bool isMovingRight = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isMovingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spriteRenderer.flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isMovingRight = !isMovingRight;
        }
    }
}