using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    private SpriteRenderer sr; // Get SpriteRenderer Component

    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // Get Player's SpriteRenderer
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press "1"
        {
            sr.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Press "2"
        {
            sr.color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // Press "3"
        {
            sr.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) // Press "4"
        {
            sr.color = new Color(1f, 1f, 0f, 1f);
        }
    }
}
