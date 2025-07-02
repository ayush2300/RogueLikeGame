using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBase :WeaponBase
{
    [Header("Projectile Weapon Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float projectileSpeed = 10f;

    public override void Fire(Vector3 direction)
    {
        if (!IsReadyToFire || projectilePrefab == null || firePoint == null)
        {
            Debug.LogWarning($"{gameObject.name} cannot fire. Check firePoint or projectilePrefab.");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * projectileSpeed;
        }

        TriggerCooldown();
    }
}
