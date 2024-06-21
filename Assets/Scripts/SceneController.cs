using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        // Find the GameController in the scene
        gameController = FindObjectOfType<GameController>();
    }

    public void StartNewGame()
    {
        GameController.isGamePaused = false;
        SceneManager.LoadScene("VideoScene");
    }

    public void ResumeGame()
    {
        if (GameController.isGamePaused)
        {
            gameController.ResumeGame();
        }
    }
}
