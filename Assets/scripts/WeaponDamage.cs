using UnityEngine;

public class ClubDamage : MonoBehaviour
{
    public int damage = 25;

    private void OnCollisionEnter(Collision collision)
    {
        BossHealth monster = collision.gameObject.GetComponent<BossHealth>();

        if (monster != null)
        {
            monster.TakeDamage(damage);
        }
    }
}