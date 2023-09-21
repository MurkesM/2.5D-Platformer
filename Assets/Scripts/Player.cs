using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [Header("Movement Fields")]
    [SerializeField] private float moveSpeed = 5;
    private float horizontalInput;
    private Vector3 moveDirection = new();

    [Header("Gravity Fields")]
    [SerializeField] private float gravityForce = 10;
    private Vector3 fallDirection = new();

    [Header("Jump Fields")]
    [SerializeField] private float jumpDistance = 2;
    [SerializeField] private float maxJumps = 2;
    private float jumpCount = 0;
    private Vector3 jumpDirection = new();
    private bool isGrounded;

    private void Update()
    {
        isGrounded = characterController.isGrounded;

        HandleMovementInput();

        HandleJump();
        
        HandleGravity();
    }

    private void HandleMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        moveDirection = horizontalInput * moveSpeed * Time.deltaTime * transform.right;

        characterController.Move(moveDirection);
    }

    private void HandleJump()
    {
        if (isGrounded)
            jumpCount = 0;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            jumpCount++;

            jumpDirection = jumpDistance * transform.up;

            characterController.Move(jumpDirection);
        }
    }

    private void HandleGravity()
    {
        fallDirection = gravityForce * Time.deltaTime * -transform.up;

        characterController.Move(fallDirection);
    }
}