using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f; // Speed of the player movement
    private Rigidbody2D rb;
    private UnityEngine.Vector2 moveInput;  // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Animator animator; // Reference to the Animator component
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player   
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player     
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed; // Move the player based on input and speed
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true); // Set the walking animation based on whether the player is moving

        if (context.canceled) // If the movement input is canceled (e.g., player stops moving)
        {
            animator.SetBool("isWalking", false); // Set the walking animation to false
            animator.SetFloat("LastInputX", moveInput.x); 
            animator.SetFloat("LastInputY", moveInput.y); 
        }

        moveInput = context.ReadValue<UnityEngine.Vector2>(); // Read the movement input from the player
        animator.SetFloat("InputX", moveInput.x); // Set the horizontal movement parameter in the Animator
        animator.SetFloat("InputY", moveInput.y); // Set the vertical movement parameter in the Animator
    }
}
