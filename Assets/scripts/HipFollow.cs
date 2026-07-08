using UnityEngine;

public class HipSocketFollow : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        transform.position = cameraTransform.position 
            + cameraTransform.right * 0.35f
            - Vector3.up * 0.5f;
    }
}