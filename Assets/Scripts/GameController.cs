using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool isGamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Oausa");
        Time.timeScale = 0f; // Pause game time
        isGamePaused = true;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive); // Load MainMenu scene additively
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume game time
        isGamePaused = false;
        SceneManager.UnloadSceneAsync("MainMenu"); // Unload MainMenu scene
    }
}
