using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {
    public enum Type { Hero, Unit, Action, Upgrade, Floor };

    public Type type;
    private Sector[] sectors = new Sector[6];
    public GameObject[] sectorLocators;
    public GameObject sectorPrefab;
    public SpriteRenderer background;
    [NonSerialized] public Player player;

    public Sector this[Direction dir] { get {
        return sectors[(int)dir];
    } }

    public bool isHero { get { return type == Type.Hero; } }
}
