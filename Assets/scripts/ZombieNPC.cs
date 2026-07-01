using UnityEngine;

public class ZombieNPC : MonoBehaviour
{
    [Header("Zombie instellingen")]
    public int health = 100;

    [Header("Visuals")]
    public GameObject zombieVisual;
    public GameObject zombieExplosionEffectPrefab;
    public GameObject destroyedZombiePrefab;

    [Header("Geluid")]
    public AudioClip zombieExplodeSound;

    [Header("Destroy")]
    public float destroyDelay = 0.1f;

    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

            health -= damage;

        if (health <= 0)
        {
            ExplodeZombie(transform.position, 500f, damage);
        }
    }

    public void ExplodeZombie(Vector3 explosionPosition, float explosionForce, int damage)
    {
        if (isDead)
        {
            return;
        }

        health -= damage;

        if (health > 0)
        {
            return;
        }

        isDead = true;

        if (zombieExplosionEffectPrefab != null)
        {
            Instantiate(zombieExplosionEffectPrefab, transform.position, Quaternion.identity);
        }

        if (zombieExplodeSound != null)
        {
            GameObject soundObject = new GameObject("Zombie Explosion Sound");
            soundObject.transform.position = transform.position;

            AudioSource source = soundObject.AddComponent<AudioSource>();
            source.clip = zombieExplodeSound;
            source.spatialBlend = 1f;
            source.Play();

            Destroy(soundObject, zombieExplodeSound.length + 0.2f);
        }

        if (destroyedZombiePrefab != null)
        {
            GameObject destroyedZombie = Instantiate(destroyedZombiePrefab, transform.position, transform.rotation);

            Rigidbody[] rigidbodies = destroyedZombie.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rigidbodies)
            {
                rb.AddExplosionForce(explosionForce, explosionPosition, 5f);
            }
        }

        if (zombieVisual != null)
        {
            zombieVisual.SetActive(false);
        }

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }

        Destroy(gameObject, destroyDelay);
    }
}
