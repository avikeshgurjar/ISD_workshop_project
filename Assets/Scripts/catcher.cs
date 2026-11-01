using UnityEngine;
using UnityEngine.InputSystem;

public class Catcher : MonoBehaviour
{
    public float speed = 10f;
    public float xLimit = 7.5f;
    private InputAction moveAction;

    void Start()
    {
        if (InputSystem.actions != null)
        {
            moveAction = InputSystem.actions.FindAction("Move");
        }
    }

    void Update()
    {
        if (moveAction == null) return;

        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xLimit, xLimit);
        transform.position = clampedPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            if (GameManager.Instance != null) GameManager.Instance.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            if (GameManager.Instance != null) GameManager.Instance.GameOver();
        }
    }
}
