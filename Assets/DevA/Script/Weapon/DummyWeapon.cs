using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyWeapon : MonoBehaviour,IWeapon,ICoolDown
{
    [SerializeField] private float cooldownDuration = 0.75f;
    private float lastFireTime;

    public bool IsReadyToFire => Time.time >= lastFireTime + cooldownDuration;

    public void Fire(Vector3 direction)
    {
        if (!IsReadyToFire) return;

        Debug.Log("TestWeapon fired in direction: " + direction);
        TriggerCooldown();
    }

    public void Equip(Transform weaponHolder)
    {
        transform.position = weaponHolder.position;
        transform.SetParent(weaponHolder);
    }

    public void TriggerCooldown()
    {
        lastFireTime = Time.time;
    }
}
