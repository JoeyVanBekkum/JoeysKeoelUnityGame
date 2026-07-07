using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger geraakt door: " + other.name);
        Debug.Log("Root object: " + other.transform.root.name);
    }
}