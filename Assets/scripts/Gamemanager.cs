using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverCanvas;
    public GameObject victoryCanvas;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BossDefeated()
    {
        victoryCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartToFirstLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("VRPproject_Joey");
    }
}