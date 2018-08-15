using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerTable : MonoBehaviour {
    public uint maxHandSize = 3;
    public Transform pile;
    public Transform discard;

    private HexSlot[] choices;
    private Player player;

    void Awake() {
        choices = GetComponentsInChildren<HexSlot>();
        player = GetComponentInParent<Player>();
    }

    public List<HexTile> CreatePile() {
        return player.deck.tiles.SelectMany(x => {
            return new HexTile[x.amount].Select(_ => Instantiate(x.prefab, pile));
        }).Select(x => {
            var tile = x.GetComponent<HexTile>();
            x.SetActive(false);
            tile.player = player;
            tile.background.color = player.color;

            return tile;
        }).ToList();
    }

    public void Draw() {
        if(pile.childCount == 0) {
            MakeNewPileFromDiscard();
        }
        var tile = pile.GetComponentsInChildren<HexTile>(true).AtRandom();
        var firstAvailable = choices.First(x => x.tile == null);
        firstAvailable.Pin(tile);
    }

    public void DrawHero() {
        var tile = Instantiate(player.hero).GetComponent<HexTile>();
        tile.player = player;
        tile.background.color = player.color;

        var firstAvailable = choices.First(x => x.tile == null);
        firstAvailable.Pin(tile);
    }

    public void DiscardHand() {
        foreach(var choice in choices) {
            var tile = choice.Unpin();
            if(tile == null) continue;

            tile.transform.SetParent(discard);
            tile.gameObject.SetActive(false);
        }
    }

    void MakeNewPileFromDiscard() {
        foreach(var tile in discard.GetComponentsInChildren<HexTile>()) {
            tile.transform.SetParent(pile);
        }
    }
}
