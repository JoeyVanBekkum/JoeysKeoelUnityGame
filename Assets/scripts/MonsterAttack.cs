using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;

    private float nextAttackTime = 0f;

    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
}