using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {
    public enum Type { Hero, Unit, Action, Upgrade, Floor, Wall, Secret };

    [NonSerialized] public List<HexTile> impaledTiles = new List<HexTile>();

    //[SerializeField] Sector[] sectors = new Sector[6];
    //public SpriteRenderer background;

    [NonSerialized] public Player player;
    //public Type type;

    public string name;
    [TextArea(3,10)]
    public string text;

    Quaternion _wantedRotation;
    public Quaternion wantedRotation { get {
        return _wantedRotation;
    } set {
        _wantedRotation = value;
    }}

    Vector3 _wantedPosition;
    public Vector3 wantedPosition { get {
        return _wantedPosition;
    } set {
        impaledTiles.ForEach(x => x._wantedPosition = value);
        _wantedPosition = value;
    } }


    // public Sector this[Direction dir] { get {
    //     return sectors[(int)dir];
    // } }

    //public bool isHero { get { return type == Type.Hero; } }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, wantedPosition, 0.5f);
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, 0.1f);
    }

    public void SetColor(Color color) {
        Array.ForEach(GetComponentsInChildren<SpriteRenderer>(), x => x.color = color);
        impaledTiles.ForEach(x => x.SetColor(color));
    }

    [NonSerialized] public bool frozen = false;
    public void ToggleFreeze() {
        frozen = !frozen;

        var frozenColor = Color.Lerp(player.color, Color.white, 0.6f);
        SetColor(frozen ? frozenColor : player.color);
    }

    [NonSerialized] public bool taped = false;
    public void ToggleTap() {
        taped = !taped;

        var tapedColor = Color.Lerp(player.color, Color.black, 0.4f);
        SetColor(taped ? tapedColor : player.color);
    }
}
