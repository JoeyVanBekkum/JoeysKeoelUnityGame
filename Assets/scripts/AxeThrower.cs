using UnityEngine;
using UnityEngine.InputSystem;

public class AxeThrower : MonoBehaviour
{
    public GameObject axePrefab;
    public Transform throwPoint;

    public float throwForce = 15f;
    public float spinTorque = 1000f;

    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            ThrowAxe();
        }
    }

    void ThrowAxe()
    {
        GameObject axe = Instantiate(axePrefab, throwPoint.position, throwPoint.rotation);

        Rigidbody rb = axe.GetComponent<Rigidbody>();

        rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
        rb.AddTorque(throwPoint.right * spinTorque, ForceMode.Impulse);
    }
}