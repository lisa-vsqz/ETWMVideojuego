using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;
    public Vector3 playerPosition;
    public int playerHealth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(Vector3 position, int health)
    {
        playerPosition = position;
        playerHealth = health;
        // Save to PlayerPrefs or a file
        PlayerPrefs.SetFloat("PlayerPosX", position.x);
        PlayerPrefs.SetFloat("PlayerPosY", position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", position.z);
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        // Load from PlayerPrefs or a file
        playerPosition = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));
        playerHealth = PlayerPrefs.GetInt("PlayerHealth");
    }
}
