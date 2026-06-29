using UnityEngine;

public class DoubleDoor : MonoBehaviour
{
    [Header("Hinges (NOT doors!)")]
    public Transform leftHinge;
    public Transform rightHinge;

    [Header("Settings")]
    public float openAngle = 90f;
    public float openSpeed = 2f;

    private Quaternion leftStartRot;
    private Quaternion rightStartRot;

    private Quaternion leftTargetRot;
    private Quaternion rightTargetRot;

    private bool isOpening = false;

    void Start()
    {
        // Start rotaties van de hinges
        leftStartRot = leftHinge.rotation;
        rightStartRot = rightHinge.rotation;

        // Open richtingen
        leftTargetRot = leftStartRot * Quaternion.Euler(0, -openAngle, 0);
        rightTargetRot = rightStartRot * Quaternion.Euler(0, openAngle, 0);
    }

    public void OpenGate()
    {
        Debug.Log("Dubbele deuren openen via hinges!");
        isOpening = true;
    }

    void Update()
    {
        if (!isOpening) return;

        // Linker deur (via hinge)
        leftHinge.rotation = Quaternion.Slerp(
            leftHinge.rotation,
            leftTargetRot,
            Time.deltaTime * openSpeed
        );

        // Rechter deur (via hinge)
        rightHinge.rotation = Quaternion.Slerp(
            rightHinge.rotation,
            rightTargetRot,
            Time.deltaTime * openSpeed
        );
    }
}