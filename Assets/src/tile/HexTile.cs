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

    [NonSerialized] public Quaternion wantedRotation;
    [NonSerialized] public Vector3 wantedPosition;

    public Sector this[Direction dir] { get {
        return sectors[(int)dir];
    } }

    public bool isHero { get { return type == Type.Hero; } }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, wantedPosition, 0.5f);
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, 0.1f);
    }
}
