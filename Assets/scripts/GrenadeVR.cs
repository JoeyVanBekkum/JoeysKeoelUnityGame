using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrenadeVR : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private GrenadeExplosive grenadeExplosive;
    private Rigidbody rb;

    private bool fuseStarted = false;

    [Header("Throw Detection")]
    public float minimumThrowSpeed = 1f;

    private void Awake()
    {
        grabInteractable =
            GetComponent<XRGrabInteractable>();

        grenadeExplosive =
            GetComponent<GrenadeExplosive>();

        rb =
            GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (fuseStarted)
            return;

        float speed = 0f;

        if (rb != null)
        {
            speed = rb.linearVelocity.magnitude;
        }

        if (speed >= minimumThrowSpeed)
        {
            fuseStarted = true;

            Debug.Log("Grenade thrown");

            grenadeExplosive.StartFuse();
        }
    }
}