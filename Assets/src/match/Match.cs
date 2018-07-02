using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour {
    Player[] players;
    HexGrid grid;

    void Awake() {
        grid = GetComponentInChildren<HexGrid>();
        players = GetComponentsInChildren<Player>();
    }

    void Start() {
        StartCoroutine(Begin());
    }

    public IEnumerator Begin() {
        foreach(var player in players) {
            player.table.DrawHero();
            yield return player.controller.SetupHero();
        }
        yield return null;
    }
}