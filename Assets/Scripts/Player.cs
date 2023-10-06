using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;

    [Header("Movement Fields")]
    public float moveSpeed = 5;
    public float horizontalInput;
    public Vector3 moveDirection = new();

    [Header("Gravity Fields")]
    public float gravityForce = 10;
    public bool useGravity = true;

    [Header("Jump Fields")]
    public float jumpDistance = 2;
    public float maxJumps = 2;
    public float jumpCount = 0;
    public bool isGrounded;

    public float yMovement;

    private MovingPlatform movingPlatform;        

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        isGrounded = characterController.isGrounded;

        moveDirection.x = horizontalInput * moveSpeed;

        if (isGrounded)
            jumpCount = 0;

        else if (useGravity)
            yMovement -= gravityForce;
            
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            jumpCount++;

            yMovement = transform.position.y;

            yMovement += jumpDistance;
        }

        moveDirection.y = yMovement;

        if (movingPlatform)
            moveDirection += movingPlatform.movingDirection;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Moving Platform"))
            movingPlatform = hit.gameObject.GetComponent<MovingPlatform>();
        else
            movingPlatform = null;
    }
}