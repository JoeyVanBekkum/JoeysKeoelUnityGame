using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Boss Settings")]
    public bool isBoss = false;

    [Header("Audio")]
    public AudioClip bossDeathSound;

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
        Debug.Log(gameObject.name + " dood");

        // Alleen voor de boss
        if (isBoss)
        {
            // Speel het geluid af
            if (bossDeathSound != null)
            {
                AudioSource.PlayClipAtPoint(bossDeathSound, transform.position);
            }

            // Laat het victory scherm zien
            if (GameManager.Instance != null)
            {
                GameManager.Instance.BossDefeated();
            }
        }
        else
        {
            // Normale zombies tellen mee
            if (ZombieCounter.Instance != null)
            {
                ZombieCounter.Instance.ZombieKilled();
            }
        }

        Destroy(gameObject);
    }
}