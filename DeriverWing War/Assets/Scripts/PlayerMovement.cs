using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform wallCheck2;
    [SerializeField] private Transform wallCheck3;
    [SerializeField] private Transform wallCheck4;

    private float moveInput;
    private bool movingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;

        CheckDirection();

        if (!Physics2D.Raycast(wallCheck.position, movingRight ? Vector2.right : Vector2.left, 0.1f, wallLayer) && 
            !Physics2D.Raycast(wallCheck2.position, movingRight ? Vector2.right : Vector2.left, 0.1f, wallLayer) &&
            !Physics2D.Raycast(wallCheck3.position, movingRight ? Vector2.right : Vector2.left, 0.1f, wallLayer) &&
            !Physics2D.Raycast(wallCheck4.position, movingRight ? Vector2.right : Vector2.left, 0.1f, wallLayer))
        {
            transform.position += new Vector3(moveInput * moveSpeed * Time.deltaTime, 0f, 0f);
        }

        Jump();
    }
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void CheckDirection()
    {
        if (moveInput > 0 && transform.localScale.x < 0)
        {
            Flip();
            movingRight = true;
        }
        else if (moveInput < 0 && transform.localScale.x > 0)
        {
            Flip();
            movingRight = false;
        }
    }
}
