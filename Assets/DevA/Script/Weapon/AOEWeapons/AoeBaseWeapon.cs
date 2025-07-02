using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeBaseWeapon : WeaponBase
{
    [Header("AOE Settings")]
    [SerializeField] private GameObject aoePrefab;
    [SerializeField] private float spawnRadius = 3f;

    public override void Fire(Vector3 direction)
    {
        if (!IsReadyToFire || aoePrefab == null || weaponHolder == null)
        {
            Debug.LogWarning("AOEWeapon: Missing required setup.");
            return;
        }

        Vector2 randomOffset = Random.insideUnitCircle.normalized * Random.Range(1f, spawnRadius);
        Vector3 spawnPosition = weaponHolder.position + (Vector3)randomOffset;

        Instantiate(aoePrefab, spawnPosition, Quaternion.identity);
        TriggerCooldown();
    }
}
