using UnityEngine;

public class ClubDamage : MonoBehaviour
{
    public int damage = 25;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Club raakt: " + collision.gameObject.name);

        MonsterHealth monster = collision.gameObject.GetComponentInParent<MonsterHealth>();

        if (monster != null)
        {
            Debug.Log("Monster geraakt!");
            monster.TakeDamage(damage);
        }
    }
}