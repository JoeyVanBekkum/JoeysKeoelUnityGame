using UnityEngine;

public class DoubleDoor : MonoBehaviour
{
    [Header("Hinges (NOT doors!)")]
    public Transform leftHinge;
    public Transform rightHinge;

    [Header("Settings")]
    public float openAngle = 90f;
    public float openSpeed = 2f;

    [Header("Audio")]
    public AudioClip gateOpenSound;

    private AudioSource audioSource;

    private Quaternion leftStartRot;
    private Quaternion rightStartRot;

    private Quaternion leftTargetRot;
    private Quaternion rightTargetRot;

    private bool isOpening = false;

    void Start()
    {
        // AudioSource ophalen
        audioSource = GetComponent<AudioSource>();

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

    if (!isOpening)
    {
        if (gateOpenSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gateOpenSound);
        }

        isOpening = true;
    }
}

    void Update()
    {
        if (!isOpening) return;

        leftHinge.rotation = Quaternion.Slerp(
            leftHinge.rotation,
            leftTargetRot,
            Time.deltaTime * openSpeed
        );

        rightHinge.rotation = Quaternion.Slerp(
            rightHinge.rotation,
            rightTargetRot,
            Time.deltaTime * openSpeed
        );
    }
}