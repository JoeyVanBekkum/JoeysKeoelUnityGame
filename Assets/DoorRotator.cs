using System.Collections;
using UnityEngine;

public class DoorRotator : MonoBehaviour
{
    [SerializeField] private float rotateAngle = 90f;
    [SerializeField] private float rotateSpeed = 90f; // degrees per second

    public UnlockItem unlockItem;

    private Quaternion closedRotation;
    private bool isOpen;
    private Coroutine rotateCoroutine;

    private void Awake() {
        unlockItem.OnUnlock += RotateDoor;
    }

    private void Start()
    {
        closedRotation = transform.rotation;
    }


    [ContextMenu("rotate")]
    public void RotateDoor()
    {
        unlockItem.OnUnlock -= RotateDoor;
        isOpen = !isOpen;

        Quaternion targetRotation = isOpen
            ? closedRotation * Quaternion.Euler(0f, rotateAngle, 0f)
            : closedRotation;

        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
        }

        rotateCoroutine = StartCoroutine(RotateTo(targetRotation));
    }

    private IEnumerator RotateTo(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );

            yield return null;
        }

        transform.rotation = targetRotation;
    }
}