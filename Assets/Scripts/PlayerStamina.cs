using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerStamina : MonoBehaviour
{
    public int maxHits = 5;
    private int currentHits = 0;
    public float knockbackForce = 5f;
    private Rigidbody2D rb;

    public GameObject[] healthLabels;

    public GameObject gameOverBanner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (healthLabels != null)
        {
            foreach (GameObject label in healthLabels)
            {
                label.SetActive(true);
            }
        }

        if (gameOverBanner != null)
        {
            gameOverBanner.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Collided with Enemy!");

            SpriteRenderer enemySprite = collision.gameObject.GetComponent<SpriteRenderer>();
            SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();

            if (enemySprite != null && playerSprite != null)
            {
                if (!CompareColors(playerSprite.color, enemySprite.color))
                {
                    Debug.Log("Colors are different! Reducing Health & Applying Knockback");
                    TakeDamage();
                    StartCoroutine(ApplyKnockback(collision.gameObject.transform.position));
                }
                else
                {
                    Debug.Log("Colors Match! No Damage Taken.");
                }
            }
        }
    }

    void TakeDamage()
    {
        currentHits++;

        if (healthLabels != null && currentHits - 1 < healthLabels.Length)
        {
            healthLabels[currentHits - 1].SetActive(false);
        }

        if (currentHits >= maxHits)
        {
            GameOver();
        }
    }

    IEnumerator ApplyKnockback(Vector3 enemyPosition)
    {
        Vector2 knockbackDirection = (transform.position - enemyPosition).normalized;
        rb.velocity = knockbackDirection * knockbackForce;
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector2.zero;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;

        if (gameOverBanner != null)
        {
            gameOverBanner.SetActive(true);
            Text bannerText = gameOverBanner.GetComponentInChildren<Text>();
            if (bannerText != null)
            {
                bannerText.text = "Game Over, You Failed";
            }
        }
    }

    bool CompareColors(Color c1, Color c2)
    {
        return Mathf.Approximately(c1.r, c2.r) &&
               Mathf.Approximately(c1.g, c2.g) &&
               Mathf.Approximately(c1.b, c2.b);
    }
}
