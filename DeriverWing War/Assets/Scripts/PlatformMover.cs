using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private Vector3 currentTarget;
    private bool isMoving = false;
    private bool isCloseToATarget;
    private bool isCloseToStart;
    private bool isCloseToEnd;

    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform start, end;

    void Start()
    {
        currentTarget = end.position;
    }

    void Update()
    {
        if (!isMoving) return;

        Move();

        isCloseToATarget = transform.position.x >= currentTarget.x - 0.1f && transform.position.x <= currentTarget.x + 0.1f && transform.position.y >= currentTarget.y - 0.1f && transform.position.y <= currentTarget.y + 0.1f;

        if (isCloseToATarget)
        {
            isMoving = false;
            ToggleTarget();
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    public void StartMoving()
    {
        if (isMoving) return;

        isMoving = true;
    }

    private void ToggleTarget()
    {
        isCloseToStart = transform.position.x >= start.position.x - 0.5f && transform.position.x <= start.position.x + 0.5f && transform.position.y >= start.position.y - 0.5f && transform.position.y <= start.position.y + 0.5f;
        isCloseToEnd = transform.position.x >= end.position.x - 0.5f && transform.position.x <= end.position.x + 0.5f && transform.position.y >= end.position.y - 0.5f && transform.position.y <= end.position.y + 0.5f;
        if (isCloseToStart)
        {
            currentTarget = end.position;
        }
        else if (isCloseToEnd)
        {
            currentTarget = start.position;
        }
    }
}
