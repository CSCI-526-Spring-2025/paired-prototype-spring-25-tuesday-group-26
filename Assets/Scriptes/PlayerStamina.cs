using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For restarting on Game Over
using System.Collections; // Required for Coroutine

public class PlayerStamina : MonoBehaviour
{
    public Slider staminaBar; // Assign in Inspector
    public float maxStamina = 100f;
    private float currentStamina;
    public float knockbackForce = 5f; // Jerk effect intensity
    private Rigidbody2D rb;

    void Start()
    {
        currentStamina = maxStamina;
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody for applying knockback
        UpdateStaminaBar();
    }

    void OnCollisionEnter2D(Collision2D collision) // Detects collision with enemies
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy")) // Ensure it's an enemy
        {
            Debug.Log("Collided with Enemy!");

            SpriteRenderer enemySprite = collision.gameObject.GetComponent<SpriteRenderer>();
            SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();

            if (enemySprite != null && playerSprite != null)
            {
                if (!CompareColors(playerSprite.color, enemySprite.color)) // If colors are different
                {
                    Debug.Log("Colors are different! Reducing Stamina & Applying Knockback");
                    TakeDamage(20f); // Reduce stamina by 20
                    StartCoroutine(ApplyKnockback(collision.gameObject.transform.position));
                }
                else
                {
                    Debug.Log("Colors Match! No Stamina Reduction.");
                }
            }
        }
    }

    void TakeDamage(float damage)
    {
        currentStamina -= damage;
        UpdateStaminaBar();

        if (currentStamina <= 0)
        {
            GameOver();
        }
    }

    void UpdateStaminaBar()
    {
        if (staminaBar != null)
        {
            staminaBar.value = currentStamina / maxStamina;
        }
    }

    IEnumerator ApplyKnockback(Vector3 enemyPosition)
    {
        Vector2 knockbackDirection = (transform.position - enemyPosition).normalized; // Move away from enemy
        rb.velocity = knockbackDirection * knockbackForce;

        yield return new WaitForSeconds(0.2f); // Stop movement briefly

        rb.velocity = Vector2.zero; // Reset velocity after knockback
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart game
    }

    bool CompareColors(Color c1, Color c2)
    {
        return Mathf.Approximately(c1.r, c2.r) &&
               Mathf.Approximately(c1.g, c2.g) &&
               Mathf.Approximately(c1.b, c2.b);
    }
}
