using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {
    public enum Type { Hero, Unit, Action, Upgrade, Floor, Wall, Secret };

    [SerializeField] Sector[] sectors = new Sector[6];
    public SpriteRenderer background;

    [NonSerialized] public Player player;
    [NonSerialized] public Type type;

    public Sector this[Direction dir] { get {
        return sectors[(int)dir];
    } }

    public bool isHero { get { return type == Type.Hero; } }
}
