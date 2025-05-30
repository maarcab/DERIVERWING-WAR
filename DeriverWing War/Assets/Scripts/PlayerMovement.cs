using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck;

    private float moveInput;
    private bool movingRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        CheckDirection();

        if (!Physics2D.Raycast(wallCheck.position, movingRight ? Vector2.right : Vector2.left, 0.1f, wallLayer))
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
