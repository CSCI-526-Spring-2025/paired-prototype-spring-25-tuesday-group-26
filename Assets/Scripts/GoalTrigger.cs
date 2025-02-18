using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    public GameObject winText;
    private bool gameEnded = false;
    public GameObject replayButton;

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
            {
                winText.SetActive(true);
                Text bannerText = winText.GetComponentInChildren<Text>();
                if (bannerText != null)
                {
                    bannerText.text = "You Win!";
                }
            }
            Time.timeScale = 0f;

            if (replayButton != null)
            {
                replayButton.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Enemy.enemyKillCount = 0;  
        if (Enemy.enemyKillCountText != null)
        {
            Enemy.enemyKillCountText.text = "Enemies Killed: 0";  
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
