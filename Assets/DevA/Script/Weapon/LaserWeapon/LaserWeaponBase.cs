using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeaponBase : WeaponBase
{
    [Header("Laser Settings")]
    [SerializeField] private float laserLength = 10f;
    [SerializeField] private float laserWidth = 0.2f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float laserDuration = 0.1f; // how long the laser is visible

    private float laserTimer;

    public override void Fire(Vector3 direction)
    {
        if (!IsReadyToFire) return;

        Vector3 start = transform.position;
        Vector3 end = start + direction.normalized * laserLength;

        // Damage enemies in a laser line
        RaycastHit2D[] hits = Physics2D.RaycastAll(start, direction, laserLength, enemyLayer);
        foreach (var hit in hits)
        {
            if (hit.collider.TryGetComponent<IDamageAble>(out var target))
            {
                target.Damage(damage);
            }
        }

        // Show laser visually
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
            lineRenderer.enabled = true;
            laserTimer = laserDuration;
        }

        TriggerCooldown();
    }

    private void Update()
    {
        if (lineRenderer != null && lineRenderer.enabled)
        {
            laserTimer -= Time.deltaTime;
            if (laserTimer <= 0f)
            {
                lineRenderer.enabled = false;
            }
        }
    }
}
