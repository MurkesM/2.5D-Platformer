using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float leftDistance = 1;
    public float rightDistance = 1;

    public float moveSpeed = 1;

    private Vector3 leftEnd = new();
    private Vector3 rightEnd = new();

    private Vector3 positionToMove = new();

    public Vector3 movingDirection = new(); 

    private void Awake()
    {
        leftEnd = transform.position + -transform.right * leftDistance;
        rightEnd = transform.position + transform.right * rightDistance;

        positionToMove = rightEnd;
    }

    private void Update()
    {
        if (transform.position == leftEnd)
        {
            positionToMove = rightEnd;
            movingDirection = transform.right;
        }
            

        if (transform.position == rightEnd)
        {
            positionToMove = leftEnd;
            movingDirection = -transform.right;
        }
            
        transform.position = Vector3.MoveTowards(transform.position, positionToMove, moveSpeed * Time.deltaTime);
    }
}