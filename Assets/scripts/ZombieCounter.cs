using UnityEngine;
using TMPro;

public class ZombieCounter : MonoBehaviour
{
    public static ZombieCounter Instance;

    [Header("Kill settings")]
    public int zombiesToKill = 5;
    private int zombiesKilled = 0;

    [Header("Gate")]
    public DoubleDoor gate;

    [Header("UI")]
    public TextMeshProUGUI gateText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void ZombieKilled()
    {
        zombiesKilled++;

        Debug.Log("Zombies gedood: " + zombiesKilled + "/" + zombiesToKill);

        UpdateUI();

        if (zombiesKilled >= zombiesToKill)
        {
            OpenGate();
        }
    }

    void UpdateUI()
    {
        if (gateText != null)
        {
            if (zombiesKilled < zombiesToKill)
            {
                gateText.text = "Clear the area first!\nZombies: " 
                                + zombiesKilled + "/" + zombiesToKill;
            }
            else
            {
                gateText.text = "Gate unlocked!";
            }
        }
    }

    void OpenGate()
    {
        if (gate != null)
        {
            gate.OpenGate();
        }
    }
}