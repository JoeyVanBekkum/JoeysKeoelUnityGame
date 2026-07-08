using UnityEngine;

public class ExampleReturn : MonoBehaviour
{
    public Transform objectToTeleport;

    private CharacterController characterController;

    void Start()
    {
        characterController = objectToTeleport.GetComponent<CharacterController>();
        Teleport();
    }

    public void Teleport()
    {
        if (objectToTeleport == null) return;

        if (characterController != null)
            characterController.enabled = false;

        objectToTeleport.position = transform.position;

        if (characterController != null)
            characterController.enabled = true;
    }
}