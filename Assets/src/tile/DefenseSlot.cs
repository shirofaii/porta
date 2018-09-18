using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Immunity {
    None, Steel, Fire, Ice, Acid, Wind, Holy, Dark,
    Hero,
}

public class DefenseSlot : MonoBehaviour {
    public Immunity immunity = Immunity.None;
}
