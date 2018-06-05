using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public enum Type { Base, Unit, Action, Upgrade, Floor };

    public Type type;
    [SerializeField] private readonly Sector[] sectors;

    public Sector this[Direction dir] { get {
        return sectors[(int)dir];
    } }


}
