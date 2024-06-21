using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;

    void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false); // Ensure the GameOverCanvas is inactive at the start
        }
    }

    public void GameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); // Show the GameOverCanvas
        }

        // Stop time to freeze the game
        Time.timeScale = 0f;
    }
}
