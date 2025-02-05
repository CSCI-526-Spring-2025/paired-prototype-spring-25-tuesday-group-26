using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    public GameObject winText;
    private bool gameEnded = false;

    void Start()
    {
        if (winText != null)
            winText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameEnded && other.CompareTag("Player"))
        {
            gameEnded = true;
            Debug.Log("You Win!");
            
            if (winText != null)
                winText.SetActive(true);
            
            Invoke("RestartGame", 2f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
