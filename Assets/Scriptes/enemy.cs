using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int enemyKillCount = 0;
    public static UnityEngine.UI.Text enemyKillCountText; // UI text reference
    public GameObject vanishEffectPrefab; // Assign in Inspector

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer playerSprite = collision.gameObject.GetComponent<SpriteRenderer>();

            if (playerSprite != null && CompareColors(playerSprite.color, GetComponent<SpriteRenderer>().color))
            {
                enemyKillCount++; // Increase kill count
                if (enemyKillCountText != null)
                    enemyKillCountText.text = "Enemies Killed: " + enemyKillCount;

                VanishEffect(); // Play Particle Effect
                Destroy(gameObject); // Remove enemy
            }
        }
    }

    void VanishEffect()
{
    if (vanishEffectPrefab != null)
    {
        GameObject effect = Instantiate(vanishEffectPrefab, transform.position, Quaternion.identity);
        Debug.Log("Particle Effect Spawned at: " + transform.position);

        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
            Destroy(effect, ps.main.duration); // Destroy after effect duration
        }
    }
    else
    {
        Debug.LogWarning("VanishEffectPrefab is NOT assigned!");
    }
}


    bool CompareColors(Color c1, Color c2)
    {
        return Mathf.Approximately(c1.r, c2.r) &&
               Mathf.Approximately(c1.g, c2.g) &&
               Mathf.Approximately(c1.b, c2.b);
    }
}
