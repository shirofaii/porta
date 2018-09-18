using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType {
    Steel, Fire, Ice, Acid, Wind, Holy, Dark
}

public enum WeaponType {
    None = 0, Melee, Ranged
}

public class WeaponSlot : MonoBehaviour {
    public WeaponType weaponType = WeaponType.None;
    public DamageType damageType = DamageType.Steel;

    public GameObject[] weaponView;

    void Redraw() {
        foreach(var v in weaponView) {
            v.SetActive(false);
        }
        weaponView[(int)weaponType].SetActive(true);
    }
}
