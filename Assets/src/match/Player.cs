using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public string nickname;
    public Character character;
    public Color color;
    // public DeckAsset deck;
    // public HexTile hero;

    [NonSerialized] public PlayerTable table;

    void Awake() {
        table = GetComponentInChildren<PlayerTable>();
        
    }

    public List<HexTile> ownedTiles { get {
        return HexGrid.board.AllTiles(x => x.player == this);
    } }
}
