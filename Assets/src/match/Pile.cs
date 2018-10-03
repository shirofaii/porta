using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pile : MonoBehaviour {
    [NonSerialized] public Player owner;
    [NonSerialized] public HexSlot slot;

    public DeckAsset deck;

    void Start() {
        owner = GetComponentInParent<Player>();
        slot = GetComponent<HexSlot>();

        if(deck != null) {
            CreatePile(deck);
        }
    }

    public void CreatePile(DeckAsset deck) {
        var list = deck.tiles.SelectMany(x => {
            return new HexTile[x.amount].Select(_ => Instantiate(x.prefab, transform));
        }).Select(x => {
            var tile = x.GetComponent<HexTile>();
            x.SetActive(false);
            tile.player = owner;
            tile.background.color = owner.color;

            return tile;
        }).ToList();
        list.Shuffle();
        slot.Place(list);
    }

    public void Draw() {
        if(slot.tile == null) return;

        var tile = slot.Take();
        var firstAvailable = owner.table.choices.FirstOrDefault(x => x.tile == null);
        if(firstAvailable == null) return;

        firstAvailable.Place(tile);
    }
}
