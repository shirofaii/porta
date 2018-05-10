using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Immunity {
    Steel, Fire, Ice, Acid, Wind, Holy, Dark,
    Ranged, Melee,
    Base,
    All, None
}

public class DefenseSlot : ScriptableObject {
    public Immunity immunity = Immunity.None;
    public int health = 1;
}
