using UnityEngine;

public class AxeProjectile : MonoBehaviour
{
    private bool stuck = false;

    private void OnCollisionEnter(Collision collision)
    
    {
        ZombieHealth zombie = collision.gameObject.GetComponent<ZombieHealth>();

        if (zombie != null)
        {
        zombie.TakeDamage(100);
        }
        if (stuck) return;

        stuck = true;

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.isKinematic = true;

        transform.SetParent(collision.transform);

        if (collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(collision.gameObject);
        }
    }
}