using UnityEngine;

public class ClubDamage : MonoBehaviour
{
    public int damage = 25;

    private void OnCollisionEnter(Collision collision)
    {
        ZombieHealth zombie = collision.gameObject.GetComponent<ZombieHealth>();

        if (zombie != null)
        {
            zombie.TakeDamage(damage);
        }
    }
}