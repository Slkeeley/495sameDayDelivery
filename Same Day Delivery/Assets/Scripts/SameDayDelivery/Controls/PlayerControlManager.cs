using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlManager : MonoBehaviour
{
    public delegate void InputEvent();
    public InputEvent Interact;
    
    public Vector2 move;
    
    private void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    private void OnInteract(InputValue value)
    {
        if (value.isPressed)
            Interact?.Invoke();
    }

    private void MoveInput(Vector2 value)
    {
        move = value;
    }
}
