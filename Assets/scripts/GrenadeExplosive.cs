using UnityEngine;

public class GrenadeExplosive : MonoBehaviour
{
    [Header("Fuse")]
    public float fuseTime = 3f;

    [Header("Explosion")]
    public float explosionRadius = 5f;
    public float explosionForce = 700f;
    public int damage = 100;

    [Header("Effects")]
    public GameObject explosionEffectPrefab;

    [Header("Audio")]
    public AudioClip explosionSound;
    [Range(0f, 1f)]
    public float soundVolume = 1f;

    private bool fuseStarted = false;
    private bool exploded = false;

    public void StartFuse()
    {
        if (fuseStarted || exploded)
            return;

        fuseStarted = true;

        Debug.Log("Fuse started");

        Invoke(nameof(Explode), fuseTime);
    }

private void Explode()
{
    if (exploded)
        return;

    exploded = true;

    Debug.Log("BOOM");

    // Particle effect
    if (explosionEffectPrefab != null)
    {
        Instantiate(
            explosionEffectPrefab,
            transform.position,
            Quaternion.identity);
    }

    // Sound
    if (explosionSound != null)
    {
        AudioSource.PlayClipAtPoint(
            explosionSound,
            transform.position,
            soundVolume);
    }

    // Damage + force
    Collider[] hits = Physics.OverlapSphere(
        transform.position,
        explosionRadius);

    foreach (Collider hit in hits)
    {
        Rigidbody rb = hit.attachedRigidbody;

        if (rb != null)
        {
            rb.AddExplosionForce(
                explosionForce,
                transform.position,
                explosionRadius);
        }

        MonsterHealth monster = hit.GetComponentInParent<MonsterHealth>();

        if (monster != null)
        {
            monster.TakeDamage(damage);
        }
    } // <-- foreach eindigt hier

    Destroy(gameObject);
} // <-- Explode() eindigt hier

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            explosionRadius);
    }
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