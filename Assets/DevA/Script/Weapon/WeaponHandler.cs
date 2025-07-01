using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [Header("Auto Attack")]
    [SerializeField] private Transform weaponHolder;

    [Tooltip("Assign multiple starting weapon prefabs here")]
    [SerializeField] private List<GameObject> startingWeaponPrefabs = new List<GameObject>();

    private readonly List<IWeapon> equippedWeapons = new List<IWeapon>();

    private void Start()
    {
        foreach (var prefab in startingWeaponPrefabs)
        {
            if (prefab != null)
            {
                EquipWeapon(prefab);
            }
        }
    }

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
        // TEMP: Direction toward mouse — will later become "nearest enemy"
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        dir.z = 0;
        return dir.normalized;
    }

    public void EquipWeapon(GameObject weaponPrefab)
    {
        GameObject instance = Instantiate(weaponPrefab, weaponHolder);
        IWeapon newWeapon = instance.GetComponent<IWeapon>();

        if (newWeapon != null)
        {
            newWeapon.Equip(weaponHolder);
            equippedWeapons.Add(newWeapon);
        }
        else
        {
            Debug.LogWarning($"Tried to equip {weaponPrefab.name}, but it doesn't implement IWeapon.");
        }
    }
}
