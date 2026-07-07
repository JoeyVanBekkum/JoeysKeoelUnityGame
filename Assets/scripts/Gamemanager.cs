using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverCanvas;
    public GameObject victoryCanvas;

    [Header("Victory Settings")]
    public GameObject bossObject;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BossDefeated(GameObject defeatedObject)
    {
        if (defeatedObject == bossObject)
        {
            Debug.Log("Victory scherm openen");

            victoryCanvas.SetActive(true);
            Time.timeScale = 0f;

            Debug.Log("BossDefeated wordt uitgevoerd");

        if (defeatedObject == bossObject)
            {
                Debug.Log("Juiste boss verslagen, canvas openen");

                victoryCanvas.SetActive(true);
                Time.timeScale = 0f;
                }
        }
    }

    public void RestartToFirstLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("VRPproject_Joey");
    }
}