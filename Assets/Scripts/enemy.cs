using UnityEngine;
using TMPro;  

public class Enemy : MonoBehaviour
{
    public static int enemyKillCount = 0;
    public static TMP_Text enemyKillCountText; 

    public GameObject vanishEffectPrefab;

    void Start()
    {
        
        if (enemyKillCountText == null)
        {
            enemyKillCountText = GameObject.Find("EnemyKillCountText")?.GetComponent<TMP_Text>();
            if (enemyKillCountText == null)
            {
                Debug.LogWarning("ui not found!");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer playerSprite = collision.gameObject.GetComponent<SpriteRenderer>();

            if (playerSprite != null && CompareColors(playerSprite.color, GetComponent<SpriteRenderer>().color))
            {
                enemyKillCount++; 
                if (enemyKillCountText != null)
                    enemyKillCountText.text = "Enemies Killed: " + enemyKillCount; 

                VanishEffect();
                Destroy(gameObject); 
            }
        }
    }

    void VanishEffect()
    {
        if (vanishEffectPrefab != null)
        {
            GameObject effect = Instantiate(vanishEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                Destroy(effect, ps.main.duration);
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

