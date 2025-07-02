using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoetestWeapon : MonoBehaviour
{
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private float damagePerSecond = 10f;
    [SerializeField] private float duration = 3f;
    [SerializeField] private LayerMask enemyLayer;

    private float lifeTimer;

    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= duration)
        {
            Destroy(gameObject);
            return;
        }

        DamageEnemiesInZone();
    }

    private void DamageEnemiesInZone()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<IDamageAble>(out var target))
            {
                target.Damage(damagePerSecond * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
