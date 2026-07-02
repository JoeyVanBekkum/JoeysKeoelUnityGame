using UnityEngine;

public class ClubDamage : MonoBehaviour
{
    public int damage = 25;

    private void OnCollisionEnter(Collision collision)
    {
        MonsterHealth monster = collision.gameObject.GetComponent<MonsterHealth>();

        if (monster != null)
        {
            monster.TakeDamage(damage);
        }

        BossHealth boss = collision.gameObject.GetComponent<BossHealth>();

        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
    }
}
