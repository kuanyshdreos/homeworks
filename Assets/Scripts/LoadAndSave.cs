using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaver : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "game_data.txt");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveGame();
            ReturnToMainMenu();
        }
    }

    private void SaveGame()
    {
        PlayerPrefs.SetString("lastLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        string data = SceneManager.GetActiveScene().name;
        File.WriteAllText(filePath, data);
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLastLevel()
    {
        string lastLevel = PlayerPrefs.GetString("lastLevel");
        if (!string.IsNullOrEmpty(lastLevel))
        {
            SceneManager.LoadScene(lastLevel);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}