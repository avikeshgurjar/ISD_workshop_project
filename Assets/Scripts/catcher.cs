using UnityEngine;
using UnityEngine.InputSystem;

public class Catcher : MonoBehaviour
{
    public float speed = 10f;
    private InputAction moveAction;

    void Start()
    {
        // Automatically binds to WASD, Arrow Keys, and Gamepad Left Stick in Unity 6+
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        // Reads a Vector2 where .x is horizontal (-1 to 1) and .y is vertical
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }
}
