using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    public string nextLevelName = "Level2";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger door: " + other.name);
        Debug.Log("Root: " + other.transform.root.name);

        if (other.transform.root.name == "XR Origin (XR Rig)")
        {
            Debug.Log("XR Origin gevonden, level laden");
            SceneManager.LoadScene(nextLevelName);
        }
    }
}