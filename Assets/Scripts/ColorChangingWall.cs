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
        if (collision.gameObject.CompareTag("colored"))
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
        if (other.CompareTag("colored"))
        {
            other.isTrigger = false;
        }
    }

    bool ColorsAreSimilar(Color c1, Color c2)
    {
        return c1 == c2;
    }
}

