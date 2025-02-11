using UnityEngine;

public class ChangeColorOnPass : MonoBehaviour
{
    private SpriteRenderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>(); // Get the player's sprite
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("colored")) // Check if it's a passable wall
        {
            SpriteRenderer wallRenderer = other.GetComponent<SpriteRenderer>(); // Get wall's color
            if (wallRenderer != null)
            {
                playerRenderer.color = wallRenderer.color; // Change player color to wall color
            }
        }
    }
}
