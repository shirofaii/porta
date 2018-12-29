using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexRotator : MonoBehaviour {
    void Update() {
        if(Input.mouseScrollDelta == Vector2.zero) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if(hit.collider == null) return;

        var slot = hit.collider.GetComponent<HexSlot>();
        if(slot == null || slot.tile == null) return;
        
        var tile = slot.tile;
        var dt = Input.GetAxis("Mouse ScrollWheel");
        slot.tile.wantedRotation = Quaternion.AngleAxis(slot.tile.wantedRotation.eulerAngles.z + 60 * dt, Vector3.forward);
        slot.tile.impaledTiles.ForEach(x => {
            x.wantedRotation = Quaternion.AngleAxis(x.wantedRotation.eulerAngles.z + 60 * dt, Vector3.forward);
            StartCoroutine(FixAngle(x));
        });

        StartCoroutine(FixAngle(slot.tile));
    }

    IEnumerator FixAngle(HexTile tile) {
        yield return new WaitForSeconds(0.5f);
        if(tile == null) yield break;

        var a = tile.wantedRotation.eulerAngles.z;

        if(a <= 30 + 60*0 && a >= -30)       tile.wantedRotation = Quaternion.AngleAxis(0*60, Vector3.forward);
        if(a <= 30 + 60*1 && a >= 30 + 60*0) tile.wantedRotation = Quaternion.AngleAxis(1*60, Vector3.forward);
        if(a <= 30 + 60*2 && a >= 30 + 60*1) tile.wantedRotation = Quaternion.AngleAxis(2*60, Vector3.forward);
        if(a <= 30 + 60*3 && a >= 30 + 60*2) tile.wantedRotation = Quaternion.AngleAxis(3*60, Vector3.forward);
        if(a <= 30 + 60*4 && a >= 30 + 60*3) tile.wantedRotation = Quaternion.AngleAxis(4*60, Vector3.forward);
        if(a <= 30 + 60*5 && a >= 30 + 60*4) tile.wantedRotation = Quaternion.AngleAxis(5*60, Vector3.forward);
        if(a <= 30 + 60*6 && a >= 30 + 60*5) tile.wantedRotation = Quaternion.AngleAxis(6*60, Vector3.forward);
    }
}
