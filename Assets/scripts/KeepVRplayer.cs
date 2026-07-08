using UnityEngine;

public class PersistentXROrigin : MonoBehaviour
{
    public static PersistentXROrigin instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}