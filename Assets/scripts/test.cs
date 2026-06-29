using UnityEngine;

public class TestMeleeHit : MonoBehaviour
{
    public int damage = 25;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryHit();
        }
    }

    void TryHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            ZombieHealth zombie = hit.collider.GetComponentInParent<ZombieHealth>();

            if (zombie != null)
            {
                zombie.TakeDamage(damage);
                Debug.Log("Zombie geraakt!");
            }
        }
    }
}