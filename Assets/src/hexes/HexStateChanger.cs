using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexStateChanger : MonoBehaviour {
    void Update() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if(hit.collider == null) return;

        var slot = hit.collider.GetComponent<HexSlot>();
        if(slot == null || slot.tile == null) return;

        if(Input.GetKeyDown(KeyCode.F)) {
            slot.tile.ToggleFreeze();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            slot.tile.ToggleTap();
        }
    }
}
