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
    [SerializeField] private float jumpDistance = 500;
    [SerializeField] private float jumpSpeed = 2;
    private Vector3 jumpDirection = new();
    private bool isGrounded;

    private void Update()
    {
        isGrounded = characterController.isGrounded;

        HandleMovementInput();

        if (isGrounded)
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpDirection = jumpDistance * jumpSpeed * transform.up;

            characterController.Move(jumpDirection);
        }
    }

    private void HandleGravity()
    {
        fallDirection = gravityForce * Time.deltaTime * -transform.up;

        characterController.Move(fallDirection);
    }
}