using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour , IWeapon , ICoolDown
{
       [Header("Base Weapon Stats")]
    [SerializeField] protected float cooldown = 1f;

    protected float lastFireTime;
    protected Transform weaponHolder;

    public virtual bool IsReadyToFire => Time.time >= lastFireTime + cooldown;

    public virtual void Equip(Transform holder)
    {
        weaponHolder = holder;
        transform.SetParent(holder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public abstract void Fire(Vector3 direction);

    public virtual void TriggerCooldown()
    {
        lastFireTime = Time.time;
    }
}
