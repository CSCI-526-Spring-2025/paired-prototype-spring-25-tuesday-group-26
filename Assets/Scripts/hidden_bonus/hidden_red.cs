using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRed : MonoBehaviour
{
    private SpriteRenderer objectRenderer;
    public Color requiredColor = Color.red; 

    void Start()
    {
        objectRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            SpriteRenderer playerRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            if (playerRenderer != null)
            {
                bool isSameColor = ColorsAreSimilar(playerRenderer.color, requiredColor);

                if (isSameColor)
                {
                    BoxCollider2D collider = GetComponent<BoxCollider2D>(); 
                    if (collider != null)
                    {
                        collider.isTrigger = true;
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.isTrigger = false;
            }
        }
    }

    bool ColorsAreSimilar(Color c1, Color c2)
    {
        return c1 == c2;
    }
}

