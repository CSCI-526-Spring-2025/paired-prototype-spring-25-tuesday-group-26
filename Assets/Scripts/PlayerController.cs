using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // speed
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D Component
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // Left/Right (A/D OR ←/→)
        movement.y = Input.GetAxisRaw("Vertical");   // Up/Down (W/S OR ↑/↓)
    }

    void FixedUpdate()
    {
        // Set Speed，Let Player Move
        rb.velocity = movement.normalized * speed;
    }
}
