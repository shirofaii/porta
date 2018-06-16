using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Immunity {
    Steel, Fire, Ice, Acid, Wind, Holy, Dark,
    Ranged, Melee,
    Hero,
    All, None
}

public class DefenseSlot : MonoBehaviour {
    public Immunity immunity = Immunity.None;
}
