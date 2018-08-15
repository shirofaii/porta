using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSlot : MonoBehaviour {
    [HideInInspector] public HexGrid grid;
    public HexPosition position;
    [NonSerialized] public HexTile tile;
    public bool dragable = true;

    [NonSerialized] public Quaternion wantedRotation;
    [NonSerialized] public Vector3 wantedPosition;

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
        tile.gameObject.SetActive(true);

        wantedRotation = Quaternion.identity;
        wantedPosition = transform.position;
    }

    public HexTile Unpin() {
        var t = tile;
        tile = null;
        return t;
    }

    void Update() {
        if(tile == null) return;

        tile.transform.position = Vector3.Lerp(tile.transform.position, wantedPosition, 0.5f);
        tile.transform.rotation = Quaternion.Lerp(tile.transform.rotation, wantedRotation, 0.1f);

        // if(!dragable || Input.mouseScrollDelta == Vector2.zero) return;

        // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        // if(hit.collider == null || hit.collider != GetComponent<Collider2D>()) return;

        // OnMouseWheel(Input.GetAxis("Mouse ScrollWheel"));
    }

    void OnMouseDrag() {
        if(!dragable || tile == null) return;

        var mp = Input.mousePosition;
        mp.z = 1f;
        wantedPosition = Camera.main.ScreenToWorldPoint(mp);
    }

    // void OnMouseWheel(float dt) {
    //     wantedRotation = Quaternion.AngleAxis(wantedRotation.eulerAngles.z + 60 * dt, Vector3.forward);
    // }

    void OnMouseUp() {
        if(!dragable || tile == null) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if(hit.collider == null) { CancelDrop(); return; }

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
        wantedPosition = transform.position;
    }
}
