using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public float bottomLimit = -6f;

    void Update()
    {
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
