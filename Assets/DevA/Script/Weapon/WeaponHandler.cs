using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [Header("Auto Attack")]
    [SerializeField] private Transform weaponHolder; // Assign in inspector

    private List<IWeapon> equippedWeapons = new List<IWeapon>();

    private void Update()
    {
        Vector3 fireDirection = GetAutoFireDirection();
        foreach (var weapon in equippedWeapons)
        {
            if (weapon is ICoolDown cooldownWeapon && cooldownWeapon.IsReadyToFire)
            {
                weapon.Fire(fireDirection);
            }
        }
    }


    private Vector3 GetAutoFireDirection()
    {
        // TEMP: Direction toward mouse — replace with nearest enemy logic later
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        dir.z = 0;
        return dir.normalized;
    }

    public void EquipWeapon(IWeapon weaponPrefab)
    {
        GameObject instance = Instantiate((weaponPrefab as MonoBehaviour).gameObject, weaponHolder);
        IWeapon newWeapon = instance.GetComponent<IWeapon>();
        newWeapon.Equip(weaponHolder);
        equippedWeapons.Add(newWeapon);
    }
}
