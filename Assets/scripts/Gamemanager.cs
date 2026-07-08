using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private void Awake()
    {
        Instance = this;
    }

    public void RestartToFirstLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("VRPproject_Joey");
    }
}