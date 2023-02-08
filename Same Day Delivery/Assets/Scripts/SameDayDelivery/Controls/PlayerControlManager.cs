using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlManager : MonoBehaviour
{
    public delegate void InputEvent();
    public InputEvent InteractBegin;
    public InputEvent InteractEnd;
    public InputEvent MoveBegin;
    public InputEvent MoveEnd;
    public InputEvent SprintBegin;
    public InputEvent SprintEnd;
    public InputEvent MountBegin;
    public InputEvent MountEnd;
    
    public Vector2 move;
    public bool sprinting;
    public bool interacting;
    public bool mounting;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            move = context.ReadValue<Vector2>();
            MoveBegin?.Invoke();
        }

        if (context.canceled)
        {
            move = Vector2.zero;
            MoveEnd?.Invoke();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        Debug.Log($"Sprinting!");
        if (context.performed)
        {
            sprinting = true;
            SprintBegin?.Invoke();
        }

        if (context.canceled)
        {
            sprinting = false;
            SprintEnd?.Invoke();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log($"Interacting!");
        if (context.performed)
        {
            interacting = true;
            InteractBegin?.Invoke();
        }

        if (context.canceled)
        {
            interacting = false;
            InteractEnd?.Invoke();
        }
    }

    public void OnMount(InputAction.CallbackContext context)
    {
        Debug.Log($"Mounting!");
        if (context.performed)
        {
            mounting = true;
            MountBegin?.Invoke();
        }

        if (context.canceled)
        {
            mounting = false;
            MountEnd?.Invoke();
        }
    }
}
