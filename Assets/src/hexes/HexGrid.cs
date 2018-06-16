using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HexGrid : MonoBehaviour {
    Dictionary<HexPosition, HexSlot> map = new Dictionary<HexPosition, HexSlot>();
    public HexLayout layout;
    public int radius = 3;
    public HexSlot slotPrefab;

    [Button] public void Init() {
        layout = new HexLayout() { radius = slotPrefab.GetComponent<CircleCollider2D>().radius };
        map = new Dictionary<HexPosition, HexSlot>();
        new HexPosition(0, 0, 0).AreaInRadius(radius).ForEach(x => {
            CreateSlot(x);
        });
    }

    public HexSlot CreateSlot(HexPosition atPos) {
        var newSlot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, transform);
        newSlot.Init(atPos, this);
        map[atPos] = newSlot;
        return newSlot;
    }

    public HexSlot this[HexPosition pos] { get {
        if(!map.ContainsKey(pos)) return null;
        return map[pos];
    } set {
        map[pos] = value;
    }}

    
}
