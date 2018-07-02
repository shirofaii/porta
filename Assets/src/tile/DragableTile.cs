using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableTile : MonoBehaviour {
    private HexTile tile;
    private HexSlot slot;
    private Collider collider;

    void OnEnable() {
        tile = GetComponent<HexTile>();
        slot = GetComponentInParent<HexSlot>();
        collider = GetComponentInParent<Collider>();
    }

    void Update() {
        
    }
}
