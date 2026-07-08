using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Boss Settings")]
    public bool isBoss = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(gameObject.name + " HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        {
            Debug.Log("Zombie dood");

            if (ZombieCounter.Instance != null)
            {
                ZombieCounter.Instance.ZombieKilled();
            }
        }

        Destroy(gameObject);
    }
}