using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform spawnPoint;

    private void Start()
    {
        if (spawnPoint != null && PersistentXROrigin.instance != null)
        {
            PersistentXROrigin.instance.transform.position = spawnPoint.position;
            PersistentXROrigin.instance.transform.rotation = spawnPoint.rotation;
        }
    }
}