using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStarter : MonoBehaviour
{
    public string levelName = "Level_1";
    public string targetLevelName = "Level_2";
    public string menuLevelName = "MainMenu";

    public void StartLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == targetLevelName)
            {
                ReturnToMenu();
            }
            else
            {
                ChangeLevel(targetLevelName);
            }
        }
    }

    private void ChangeLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(menuLevelName);
    }
}