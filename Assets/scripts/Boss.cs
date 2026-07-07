using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Monster HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Boss dood!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.BossDefeated(gameObject);
        }
        else
        {
            Debug.LogError("Geen GameManager gevonden!");
        }

        Destroy(gameObject);
    }
}