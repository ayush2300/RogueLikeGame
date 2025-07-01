using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBase :WeaponBase
{

    [Header("Projectile")]
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform firePoint; // Assign in prefab
    [SerializeField] protected float projectileSpeed = 10f;

    public override void Fire(Vector3 direction)
    {
        if (!IsReadyToFire || projectilePrefab == null || firePoint == null) return;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * projectileSpeed;
        }

        TriggerCooldown();
    }
}
