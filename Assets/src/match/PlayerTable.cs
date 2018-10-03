using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerTable : MonoBehaviour {
    public Pile library;
    public Pile discard;
    public HexSlot[] choices;
    [NonSerialized] public Player player;

    void Awake() {
        choices = GetComponentsInChildren<HexSlot>();
        player = GetComponentInParent<Player>();
    }

    public void DiscardHand() {
        // foreach(var choice in choices) {
        //     var tile = choice.Unpin();
        //     if(tile == null) continue;

        //     tile.transform.SetParent(discard);
        //     tile.gameObject.SetActive(false);
        // }
    }

    void MakeNewPileFromDiscard() {
        // foreach(var tile in discard.GetComponentsInChildren<HexTile>()) {
        //     tile.transform.SetParent(pile);
        // }
    }
}
