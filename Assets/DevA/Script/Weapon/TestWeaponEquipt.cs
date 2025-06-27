using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeaponEquipt : MonoBehaviour
{
    public WeaponHandler weaponHandler;
    public GameObject testWeaponPrefab;

    private void Start()
    {
        IWeapon weapon = Instantiate(testWeaponPrefab).GetComponent<IWeapon>();
        weaponHandler.EquipWeapon(weapon);
    }

}
