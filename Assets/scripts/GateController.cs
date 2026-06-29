using UnityEngine;

public class GateController : MonoBehaviour
{
    public void OpenGate()
    {
        Debug.Log("Hek geopend!");

        gameObject.SetActive(false);
    }
}