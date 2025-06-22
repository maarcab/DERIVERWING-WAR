using UnityEngine;

public class CargolAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; 
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private Transform wallCheck; 

    private bool movingRight = true;
    private bool raycastHit;

    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        transform.Translate(Vector2.right * (movingRight ? 1 : -1) * moveSpeed * Time.deltaTime);

        raycastHit = !Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer) ||
           Physics2D.Raycast(wallCheck.position, movingRight ? Vector2.right : Vector2.left, 0.1f, groundLayer);

        if (raycastHit)
        {
            Flip();
        }
    }
    private void Flip()
    {
        movingRight = !movingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
