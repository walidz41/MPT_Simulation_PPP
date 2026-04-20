using UnityEngine;
using UnityEngine.InputSystem; // Required for the input button!

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange;

    // When something enters our player's bubble...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            if (interactable.CanInteract())
            {
                interactableInRange = interactable;
            }
        }
    }

    // When we walk away from the NPC...
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            if (interactableInRange == interactable)
            {
                interactableInRange = null;
            }
        }
    }

    // This is the function your button press will actually trigger!
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && interactableInRange != null)
        {
            interactableInRange.Interact();
        }
    }
}