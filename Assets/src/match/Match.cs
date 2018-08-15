using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour {
    Player[] players;
    HexGrid grid;

    [NonSerialized] public Player currentPlayer;

    void Awake() {
        grid = GetComponentInChildren<HexGrid>();
        players = GetComponentsInChildren<Player>();
    }

    void Start() {
        StartCoroutine(Begin());
    }

    public IEnumerator Begin() {
        // first turn
        foreach(var player in players) {
            player.table.CreatePile();
            currentPlayer = player;
            player.table.DrawHero();
            while(!HeroWasPlaced(player)) yield return null;
            endTurn = false;
        }
        
        while(true) {
            foreach(var player in players) {
                currentPlayer = player;

                for(var i = 0; i < player.table.maxHandSize; i++) {
                    player.table.Draw();
                }
                
                while(!endTurn) yield return null;
                endTurn = false;
            }
            
        }
    }

    bool HeroWasPlaced(Player player) {
        return player.ownedTiles.Any(x => x.isHero) && endTurn;
    }

    private bool endTurn = false;
    public void TurnEndPress() {
        endTurn = true;
    }
}
