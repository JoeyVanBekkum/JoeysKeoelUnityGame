using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Victory UI")]
    public GameObject victoryCanvas;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Zorg dat het scherm verborgen start
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
        }
    }

    public void BossDefeated()
    {
        Debug.Log("Boss verslagen!");

        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    public void RestartToFirstLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("VRPproject_Joey");
    }
}