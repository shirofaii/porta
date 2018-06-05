using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType {
    Steel, Fire, Ice, Acid, Wind, Holy, Dark
}

public class WeaponSlot : MonoBehaviour {
    public bool ranged = false;
    public DamageType damageType = DamageType.Steel;
}
