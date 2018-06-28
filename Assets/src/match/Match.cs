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

    public IEnumerator Begin() {
        yield return null;
    }
}