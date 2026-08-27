using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI Variables")]
    [SerializeField] float minimumFireRate = 0.2f;
    [SerializeField] float fireRateVariance = 0f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;
    AudioManager audioManager;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        if (useAI)
        {
            isFiring = true;
        }
    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        } else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.rotation = transform.rotation;
            Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidBody.linearVelocity = transform.up * projectileSpeed;
            Destroy(projectile, projectileLifeTime);
            audioManager.PlayShootingSFX();
            yield return new WaitForSeconds(GetRandomFireRate());
        }
    }

    float GetRandomFireRate()
    {
        float randomFireRate = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
        return Mathf.Clamp(randomFireRate, minimumFireRate, float.MaxValue);
    }
}
