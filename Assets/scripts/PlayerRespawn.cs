using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Respawn")]
    public Transform spawnPoint;
    public float fallHeight = -10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < fallHeight)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = spawnPoint.position;

        // Reset snelheid zodat de speler niet blijft vallen
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}