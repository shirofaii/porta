using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class HexSlot : MonoBehaviour {
    [HideInInspector] public HexGrid grid;
    public HexPosition position;
    public List<HexTile> tiles = new List<HexTile>();

    public HexTile tile { get {
        if(tiles.Count == 0) return null;
        return tiles[tiles.Count - 1];
    } }

    public void Init(HexPosition pos, HexGrid grid) {
        this.grid = grid;
        this.position = pos;
        name = pos.ToString();

        transform.position = grid.layout.HexCenter(pos);
    }

    public void Place(List<HexTile> list) {
        foreach(var tile in list) {
            Place(tile);
        }
    }

    public void ToggleImpale() {
        if(tiles.Count < 2) return;

        var impaledTile = tiles.Find(x => x.impaledTiles.Count > 0);
        if(impaledTile != null) {
            if(tiles.Count == impaledTile.impaledTiles.Count + 1) {
                //only one implaed stack in this slot
                Impale(false);
            } else {
                // reform many stacks into big one
                Impale(false);
                Impale(true);
            }
        } else {
            Impale(true);
        }
    }

    void Impale(bool value) {
        if(value) {
            tile.impaledTiles = tiles.GetRange(0, tiles.Count - 1);
        } else {
            tiles.ForEach(x => x.impaledTiles = new List<HexTile>());
        }
    }

    public void Place(HexTile tile) {
        tiles.Push(tile);
        
        tile.transform.SetParent(transform);
        tile.gameObject.SetActive(true);

        tile.wantedPosition = transform.position;
        for(var i = 0; i < tiles.Count; i++) {
            tiles[i].GetComponent<SortingGroup>().sortingOrder = i;
        }
    }

    public HexTile Take() {
        return tiles.Pop();
    }

    void OnMouseDrag() {
        if(tile == null) return;

        var mp = Input.mousePosition;
        mp.z = 1f;
        tile.wantedPosition = Camera.main.ScreenToWorldPoint(mp);
    }

    void OnMouseUp() {
        if(tile == null) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if(hit.collider == null) { CancelDrop(); return; }

        var slot = hit.collider.gameObject.GetComponent<HexSlot>();
        if(slot == null) { CancelDrop(); return; }

        DropTo(slot);
    }

    public void DropTo(HexSlot target) {
        if(tile.impaledTiles.Count > 0) {
            var impaled = Take();
            for(var i = 0; i < impaled.impaledTiles.Count; i++) {
                Take();
            }
            //for(var i = impaled.impaledTiles.Count - 1; i >= 0; i--) {
            for(var i = 0; i < impaled.impaledTiles.Count; i++) {
                target.Place(impaled.impaledTiles[i]);
            }
            target.Place(impaled);
        } else {
            target.Place(this.Take());
        }
    }

    void CancelDrop() {
        tile.wantedPosition = transform.position;
    }
}
