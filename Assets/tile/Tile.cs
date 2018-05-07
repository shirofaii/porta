using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public enum Type { Base, Unit, Action, Upgrade };

    public Type type;
    public int health;
    
}
