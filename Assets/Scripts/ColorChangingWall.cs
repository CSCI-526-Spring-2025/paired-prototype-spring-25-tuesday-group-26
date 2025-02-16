using UnityEngine;

public class ChangeColorOnPass : MonoBehaviour
{
    private SpriteRenderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>(); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SpriteRenderer wallRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            if (wallRenderer != null)
            {
                bool isSameColor = ColorsAreSimilar(playerRenderer.color, wallRenderer.color);

                if (isSameColor)
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            other.isTrigger = false;
        }
    }

    bool ColorsAreSimilar(Color c1, Color c2, float threshold = 0.1f)
    {
        return Mathf.Abs(c1.r - c2.r) < threshold &&
               Mathf.Abs(c1.g - c2.g) < threshold &&
               Mathf.Abs(c1.b - c2.b) < threshold;
    }
}

