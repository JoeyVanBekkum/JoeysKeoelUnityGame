using UnityEngine;

public class PhysicsGate : MonoBehaviour
{
    public Vector3 openOffset = new Vector3(0, 3f, 0);
    public float openSpeed = 2f;

    private Rigidbody rb;
    private Vector3 startPos;
    private Vector3 targetPos;

    private bool isOpening = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        targetPos = startPos + openOffset;
    }

    public void OpenGate()
    {
        Debug.Log("Physics gate opent!");
        isOpening = true;

        // laat physics controle los
        rb.isKinematic = true;
    }

    void Update()
    {
        if (!isOpening) return;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * openSpeed
        );
    }
}