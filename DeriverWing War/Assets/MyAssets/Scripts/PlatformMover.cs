using System.Threading;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private Vector3 currentTarget;

    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform start, end;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = start.position;
    }
     
    // Update is called once per frame
    void Update()
    {
        if (transform.position == start.position)
        {
            currentTarget = end.position;
        }

        if (transform.position == end.position)
        {
            currentTarget = start.position;
        }
        Move();

    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
