using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSlot : MonoBehaviour {
    [HideInInspector] public HexGrid grid;
    public HexPosition position;
    [NonSerialized] public HexTile tile;
    public bool dragable = true;

    public void Init(HexPosition pos, HexGrid grid) {
        this.grid = grid;
        this.position = pos;
        name = pos.ToString();

        transform.position = grid.layout.HexCenter(pos);
    }

    void Start() {
        tile = GetComponent<HexTile>();
    }

    public bool CanPin(HexTile target) {
        return tile == null;
    }

    public void Pin(HexTile tile) {
        this.tile = tile;
        
        tile.transform.SetParent(transform);
        tile.transform.localPosition = Vector3.zero;
        tile.gameObject.SetActive(true);
    }

    public HexTile Unpin() {
        var t = tile;
        tile = null;
        return t;
    }

    void OnMouseDrag() {
        if(!dragable || tile == null) return;

        var mp = Input.mousePosition;
        mp.z = 1f;
        tile.transform.position = Camera.main.ScreenToWorldPoint(mp);
    }

    void OnMouseUp() {
        if(!dragable || tile == null) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if(hit == null) { CancelDrop(); return; }

        var slot = hit.collider.gameObject.GetComponent<HexSlot>();
        if(slot == null) { CancelDrop(); return; }
        if(!slot.CanPin(tile)) { CancelDrop(); return; }

        DropTo(slot);
    }

    public void DropTo(HexSlot target) {
        var t = this.Unpin();
        target.Pin(t);
    }

    void CancelDrop() {
        tile.transform.position = transform.position;
    }
}
