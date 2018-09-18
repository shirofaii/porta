using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType {
    None, Steel, Fire, Ice, Acid, Wind, Holy, Dark
}

public class WeaponSlot : MonoBehaviour {
    public DamageType damageType = DamageType.Steel;
    public GameObject[] weaponView;
}
